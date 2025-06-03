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
    public partial class Form4 : Form
    {
        int teknisyenID;
        private bool cikisyap = false;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        private Form1 form1Reference;
        private string tc;
        private int currentPage = 1;
        private int pageSize = 8;
        private int totalPageCount = 1;
        public Form4(Form1 form1, string tc)
        {
            InitializeComponent();
            this.form1Reference = form1;
            this.tc = tc;
        }
        public void LoadUserControlIcerik(UserControl uc)
        {
            pnlIcerik.Controls.Clear();
            uc.Dock = DockStyle.Right;
            pnlIcerik.Controls.Add(uc);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            cikisyap = true;
            form1Reference.Show();
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cikisyap)
            {
                form1Reference.Close();
            }
        }

        private async void Form4_Load(object sender, EventArgs e)
        {

            string teknisyenAdi = await GetTekAdi(tc);
            labelAdsoyad.Text = teknisyenAdi;
            lbltc.Text = tc;
            lblbolum.Text = await GetTekBolum(tc);
            lblHastane.Text = await GetTekHastane(tc);
            teknisyenID = await GetTekId(teknisyenAdi);
            TahlilleriGetir(currentPage);
        }

        private async Task<string> GetTekAdi(string tc)
        {
            string query = "SELECT isimsoyisim FROM teknisyenler WHERE tc_no = @tc";

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

        private async Task<string> GetTekBolum(string tc)
        {
            string query = "SELECT t.tek_tur FROM teknisyenler AS t WHERE t.tc_no = @tc";

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
        private async Task<int> GetTekId(string teknisyenAdi)
        {
            string query = "SELECT teknisyen_id FROM teknisyenler WHERE isimsoyisim = @tekAdi";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tekAdi", teknisyenAdi);
                    object result = await cmd.ExecuteScalarAsync();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private async Task<string> GetTekHastane(string tc)
        {
            string query = "SELECT h.hastane_isim FROM hastaneler AS h JOIN teknisyenler AS t ON h.hastane_id = t.hastane_id WHERE t.tc_no = @tc";

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
        private void TahlilleriGetir(int page)
        {
            flowLayoutPanel1.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string countQuery = @"SELECT COUNT(*) FROM tahliller";
                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                int totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                totalPageCount = (int)Math.Ceiling(totalRecords / (double)pageSize);
                if (totalPageCount == 0) totalPageCount = 1;

                if (page < 1) page = 1;
                if (page > totalPageCount) page = totalPageCount;
                currentPage = page;

                int offset = (page - 1) * pageSize;

                string query = @"
                SELECT t.id, t.tc_no, h.hasta_isimsoyisim, t.tahlil_kategori, t.tahlil_turu, t.istek_tarihi
                FROM tahliller t
                JOIN hastalar h ON t.tc_no = h.tc_no
                JOIN teknisyenler tek ON t.teknisyen_id = tek.teknisyen_id
                WHERE tek.tc_no = @tc
                ORDER BY t.istek_tarihi DESC
                LIMIT @pageSize OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);
                cmd.Parameters.AddWithValue("@tc", tc);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        flowLayoutPanel1.Controls.Add(OlusturLabel("Henüz bir tahlil kaydı bulunmamaktadır.", 180, 160));
                        flowLayoutPanel2.Controls.Clear();
                        return;
                    }

                    while (reader.Read())
                    {
                        string tc = reader["tc_no"].ToString();
                        string isim = reader["hasta_isimsoyisim"].ToString();
                        string kategori = reader["tahlil_kategori"].ToString();
                        string tur = reader["tahlil_turu"].ToString();
                        DateTime tarih = Convert.ToDateTime(reader["istek_tarihi"]);
                        int tahlilId = Convert.ToInt32(reader["id"]);

                        string bilgi = $" {tc}    {isim}    {kategori}    {tur}    {tarih:dd.MM.yyyy HH:mm}";
                        var panel = OlusturPanel(bilgi);

                        Button islemBtn = new Button
                        {
                            Text = "İşlem",
                            Width = 60,
                            Height = 25,
                            BackColor = Color.DarkCyan,
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            Tag = tahlilId,
                            Cursor = Cursors.Hand
                        };

                        islemBtn.Click += (s, e) =>
                        {
                            int secilenId = (int)((Button)s).Tag;
                            LoadUserControlIcerik(new sonucEkle(secilenId));
                        };

                        islemBtn.Location = new Point(panel.Width - islemBtn.Width - 10, 7);
                        panel.Controls.Add(islemBtn);

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
                    TahlilleriGetir(secilenSayfa);
                };

                flowLayoutPanel2.Controls.Add(sayfaLabel);
            }
        }

        private Panel OlusturPanel(string text)
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

        private void btnGecmisrand_Click(object sender, EventArgs e)
        {

        }
    }
}
