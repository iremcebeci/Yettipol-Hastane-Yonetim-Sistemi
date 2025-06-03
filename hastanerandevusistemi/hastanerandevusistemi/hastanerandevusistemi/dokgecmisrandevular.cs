using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class dokgecmisrandevular : UserControl
    {
        int doktorID;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        private string tc;
        private int currentPage = 1;
        private int pageSize = 7;
        private int totalPageCount = 1;
        public dokgecmisrandevular(string tc)
        {
            InitializeComponent();
            this.tc = tc;
        }

        private async void dokgecmisrandevular_Load(object sender, EventArgs e)
        {
            string doktorAdi = await GetDoktorAdi(tc);
            doktorID = await GetDoktorId(doktorAdi);
            RandevulariGetir(currentPage);
        }
        private async Task<string> GetDoktorAdi(string tc)
        {
            string query = "SELECT doktor_isim FROM doktorlar WHERE tc_no = @tc";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);
                    object result = await cmd.ExecuteScalarAsync();
                    return result != null ? result.ToString() : "";
                }
            }
        }

        private async Task<int> GetDoktorId(string doktorAdi)
        {
            string query = "SELECT doktor_id FROM doktorlar WHERE doktor_isim = @doktorAdi";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@doktorAdi", doktorAdi);
                    object result = await cmd.ExecuteScalarAsync();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void RandevulariGetir(int page)
        {
            flowLayoutPanel1.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string countQuery = @"SELECT COUNT(*) FROM randevular WHERE doktor_id = @doktor and DATE(randevu_tarih) < CURDATE()";
                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@doktor", doktorID);
                int totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                totalPageCount = (int)Math.Ceiling(totalRecords / (double)pageSize);
                if (totalPageCount == 0) totalPageCount = 1;

                if (page < 1) page = 1;
                if (page > totalPageCount) page = totalPageCount;
                currentPage = page;

                int offset = (page - 1) * pageSize;

                string query = $@"
                SELECT r.randevu_tarih, r.randevu_saat, h.tc_no, h.hasta_isimsoyisim, h.hasta_cinsiyet, h.hasta_dog_tar, r.doktor_id
                FROM randevular AS r
                INNER JOIN doktorlar AS d ON d.doktor_id = r.doktor_id
                INNER JOIN hastalar AS h ON  h.tc_no = r.tc_no
                WHERE r.doktor_id = @doktor AND r.randevu_tarih < now()
                ORDER BY randevu_tarih DESC, randevu_saat DESC
                LIMIT @pageSize OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@doktor", doktorID);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        flowLayoutPanel1.Controls.Add(OlusturLabel("Henüz aktif bir randevunuz bulunmamaktadır.", 180, 160));
                        flowLayoutPanel2.Controls.Clear();
                        return;
                    }

                    while (reader.Read())
                    {
                        DateTime tarih = DateTime.Parse(reader["randevu_tarih"].ToString());
                        TimeOnly saat = TimeOnly.Parse(reader["randevu_saat"].ToString());
                        string tc = reader["tc_no"].ToString();
                        string adsoyad = reader["hasta_isimsoyisim"].ToString();
                        DateTime dogumtarihi = DateTime.Parse(reader["hasta_dog_tar"].ToString());
                        string cinsiyet = reader["hasta_cinsiyet"].ToString();

                        string bilgi = $" {tc}      {adsoyad}      {dogumtarihi:dd.MM.yyyy}       {cinsiyet}      {tarih:dd.MM.yyyy} {saat:HH:mm}";
                        var panel = OlusturPanel(bilgi, tarih, saat.ToString("HH:mm"));
                        Button buton = new Button
                        {
                            Text = "Detay",
                            Width = 80,
                            Height = 30,
                            BackColor = Color.Navy,
                            ForeColor = Color.WhiteSmoke,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            Tag = bilgi 
                        };


                        buton.Click += (s, e) =>
                        {
                            MessageBox.Show($"Bilgi: {bilgi}\nTarih: {tarih}\nSaat: {saat:HH:mm}", "Detay");
                        };


                        buton.Location = new Point(panel.Width - buton.Width - 5, 4);
                        panel.Controls.Add(buton);


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
                    RandevulariGetir(secilenSayfa);
                };

                flowLayoutPanel2.Controls.Add(sayfaLabel);
            }
        }

        private Panel OlusturPanel(string text, DateTime? tarih = null, string saat = null)
        {
            Panel panel = new Panel
            {
                Width = 600,
                Height = 40,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Transparent
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

        private Label OlusturLabel(string text, int marginLeft, int marginTop)
        {
            return new Label
            {
                Text = text,
                Margin = new Padding(marginLeft, marginTop, 0, 0),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
        }
    }
}
