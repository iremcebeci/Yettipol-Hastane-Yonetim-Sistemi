using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace hastaneRandevuSistemi
{
    public partial class tahliller : UserControl
    {
        private int pageSize = 8;
        private int totalPageCount = 1;
        private int currentPage = 1;
        string tc;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";

        public tahliller(string tc)
        {
            InitializeComponent();
            this.tc = tc;
            TahlilleriGetir(tc, 1);
        }
        private int GetDoktorIdByAd(string doktorAd)
        {
            int doktorId = -1;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT doktor_id FROM doktorlar WHERE doktor_isim = @ad LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ad", doktorAd);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        doktorId = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return doktorId;
        }

        private void TahlilleriGetir(string hastatc,int page)
        {
            flowLayoutPanel1.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string countQuery = "SELECT COUNT(*) FROM tahliller";
                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                int totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                totalPageCount = (int)Math.Ceiling(totalRecords / (double)pageSize);
                currentPage = Math.Clamp(page, 1, totalPageCount);
                int offset = (currentPage - 1) * pageSize;

                string query = @"
                SELECT 
                    t.id AS tahlil_id,
                    h.tc_no,
                    h.hasta_isimsoyisim,
                    t.tahlil_kategori,
                    t.tahlil_turu,
                    t.istek_tarihi,
                    EXISTS (
                        SELECT 1 FROM tahlil_sonuclari s WHERE s.hasta_id = t.id LIMIT 1
                    ) AS sonuc_var_mi
                FROM tahliller t
                JOIN hastalar h ON h.tc_no = t.tc_no
                WHERE t.tc_no = @tc
                ORDER BY t.istek_tarihi DESC
                LIMIT @pageSize OFFSET @offset";

                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", hastatc);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tc = reader["tc_no"].ToString();
                        string isim = reader["hasta_isimsoyisim"].ToString();
                        string kategori = reader["tahlil_kategori"].ToString();
                        string tur = reader["tahlil_turu"].ToString();
                        DateTime tarih = Convert.ToDateTime(reader["istek_tarihi"]);
                        bool sonucVar = Convert.ToBoolean(reader["sonuc_var_mi"]);
                        int tahlilId = Convert.ToInt32(reader["tahlil_id"]);

                        string bilgi = $"{tc}   {isim}   {kategori}   {tur}   {tarih:dd.MM.yyyy HH:mm}";
                        Panel panel = OlusturPanel(bilgi);

                        Button sonucBtn = new Button
                        {
                            Width = 90,
                            Height = 25,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            Tag = tahlilId
                        };

                        if (sonucVar)
                        {
                            sonucBtn.Text = "PDF İndir";
                            sonucBtn.BackColor = Color.ForestGreen;
                            sonucBtn.ForeColor = Color.White;
                            sonucBtn.Enabled = true;
                            sonucBtn.Click += (s, e) =>
                            {
                                // PDF oluşturma fonksiyonu çağrılır
                                int id = (int)((Button)s).Tag;
                                PDFOlustur(id);
                            };
                        }
                        else
                        {
                            sonucBtn.Text = "Sonuç Girilmedi";
                            sonucBtn.BackColor = Color.Gray;
                            sonucBtn.ForeColor = Color.White;
                            sonucBtn.Enabled = false;
                        }

                        sonucBtn.Location = new Point(panel.Width - sonucBtn.Width - 10, 7);
                        panel.Controls.Add(sonucBtn);
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }

            SayfalamaGoster();
        }
        private void SayfalamaGoster()
        {
            flowLayoutPanel2.Controls.Clear();

            for (int i = 1; i <= totalPageCount; i++)
            {
                Label sayfaLabel = new Label
                {
                    Text = i.ToString(),
                    AutoSize = true,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = (i == currentPage) ? Color.Orange : Color.WhiteSmoke
                };

                sayfaLabel.Click += (s, e) =>
                {
                    int secilenSayfa = int.Parse((s as Label).Text);
                    TahlilleriGetir(tc, secilenSayfa);
                };

                flowLayoutPanel2.Controls.Add(sayfaLabel);
            }
        }

        private void btntahlil_Click(object sender, EventArgs e)
        {
            string doktorAdi = this.FindForm()?.Text;
            int doktorID = GetDoktorIdByAd(doktorAdi);
            tahlilEkle form = new tahlilEkle(tc,doktorID);
            form.ShowDialog();
        }
        private Panel OlusturPanel(string text, DateTime? tarih = null, string saat = null)
        {
            Panel panel = new Panel
            {
                Width = 600,
                Height = 40,
                Margin = new Padding(5),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(15, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = Color.Transparent
            };
            panel.Controls.Add(lbl);

            return panel;
        }

        private void PDFOlustur(int tahlilId)
        {
            string hastaAd = "";
            string hastaTc = "";
            string tahlilAdi = "";
            List<(string Parametre, string Birim, string Deger)> satirlar = new();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 1. Hasta + tahlil bilgisi
                var infoCmd = new MySqlCommand(@"
            SELECT h.hasta_isimsoyisim, h.tc_no, t.tahlil_turu
            FROM tahliller t
            JOIN hastalar h ON h.tc_no = t.tc_no
            WHERE t.id = @id", conn);
                infoCmd.Parameters.AddWithValue("@id", tahlilId);
                using (var reader = infoCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hastaAd = reader["hasta_isimsoyisim"].ToString();
                        hastaTc = reader["tc_no"].ToString();
                        tahlilAdi = reader["tahlil_turu"].ToString();
                    }
                }

                // 2. Sonuç verileri
                var dataCmd = new MySqlCommand(@"
            SELECT p.isim, p.birim, s.deger
            FROM tahlil_sonuclari s
            JOIN parametreler p ON p.id = s.parametre_id
            WHERE s.hasta_id = @id", conn);
                dataCmd.Parameters.AddWithValue("@id", tahlilId);

                using (var reader = dataCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string param = reader["isim"].ToString();
                        string birim = reader["birim"].ToString();
                        string deger = reader["deger"].ToString();
                        satirlar.Add((param, birim, deger));
                    }
                }
            }

            // PDF oluşturma
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Tahlil Raporu";
            PdfPage page = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);
            XFont bold = new XFont("Arial", 13);

            int y = 40;
            gfx.DrawString("Tahlil Sonuç Raporu", bold, XBrushes.Black, new XPoint(40, y));
            y += 30;
            gfx.DrawString($"Hasta: {hastaAd} - TC: {hastaTc}", font, XBrushes.Black, new XPoint(40, y));
            y += 25;
            gfx.DrawString($"Tahlil Türü: {tahlilAdi}", font, XBrushes.Black, new XPoint(40, y));
            y += 30;

            foreach (var s in satirlar)
            {
                gfx.DrawString($"{s.Parametre} : {s.Deger} {s.Birim}", font, XBrushes.Black, new XPoint(40, y));
                y += 20;
            }

            string dosyaAdi = $"TahlilRaporu_{hastaAd}_{tahlilAdi}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), dosyaAdi);
            pdf.Save(yol);

            MessageBox.Show($"PDF başarıyla oluşturuldu:\n{yol}", "PDF Oluşturuldu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
