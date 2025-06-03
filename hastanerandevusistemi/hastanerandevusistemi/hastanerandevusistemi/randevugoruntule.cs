using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Api;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class randevugoruntule : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 8;
        private int totalPageCount = 1;
        string tcno;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";


        public randevugoruntule(string tcno)
        {
            InitializeComponent();
            this.tcno = tcno;
            this.Load += randevugoruntule_Load;

            lblilk.Click += Lblilk_Click;
            lblson.Click += Lblson_Click;
        }

        private void randevugoruntule_Load(object sender, EventArgs e)
        {
            RandevulariGetir(currentPage);
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new pnlicerik());
        }



        private void RandevulariGetir(int page)
        {
            flowLayoutPanel1.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string countQuery = @"SELECT COUNT(*) FROM randevular WHERE tc_no = @tc";
                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@tc", tcno);
                int totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                totalPageCount = (int)Math.Ceiling(totalRecords / (double)pageSize);
                if (totalPageCount == 0) totalPageCount = 1; 

                if (page < 1) page = 1;
                if (page > totalPageCount) page = totalPageCount;
                currentPage = page;

                int offset = (page - 1) * pageSize;

                string query = $@"
                SELECT randevu_tarih, randevu_saat, doktor_isim, bolum_isim, randevular.doktor_id, randevu_durumu
                FROM randevular
                INNER JOIN doktorlar ON randevular.doktor_id = doktorlar.doktor_id
                INNER JOIN bolumler ON doktorlar.bolum_id = bolumler.bolum_id
                WHERE randevular.tc_no = @tc
                ORDER BY randevu_tarih DESC, randevu_saat DESC
                LIMIT @pageSize OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", tcno);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        flowLayoutPanel1.Controls.Add(OlusturLabel("Henüz aktif bir randevunuz bulunmamaktadır.", 180, 60));
                        flowLayoutPanel2.Controls.Clear();
                        return;
                    }

                    while (reader.Read())
                    {
                        DateTime tarih = DateTime.Parse(reader["randevu_tarih"].ToString());
                        TimeOnly saat = TimeOnly.Parse(reader["randevu_saat"].ToString());
                        string doktor = reader["doktor_isim"].ToString();
                        string bolum = reader["bolum_isim"].ToString();
                        int doktorId = Convert.ToInt32(reader["doktor_id"]);
                        string durum = reader["randevu_durumu"].ToString();

                        string bilgi = $"{tarih:dd.MM.yyyy} {saat:HH:mm} | {bolum} / {doktor} : {durum}";
                        var panel = OlusturPanel(bilgi, durum == "aktif", tarih, saat.ToString("HH:mm"), doktorId);
                        flowLayoutPanel1.Controls.Add(panel);

                        if (durum == "iptal")
                            panel.BackColor = Color.FromArgb(100, Color.DarkRed);
                        else if (durum == "geçmiş")
                            panel.BackColor = Color.FromArgb(100, Color.DimGray);
                        else if (durum == "aktif")
                            panel.BackColor = Color.FromArgb(100, Color.DarkGreen);
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

        private void Lblilk_Click(object sender, EventArgs e)
        {
            if (currentPage != 1)
                RandevulariGetir(1);
        }

        private void Lblson_Click(object sender, EventArgs e)
        {
            if (currentPage != totalPageCount)
                RandevulariGetir(totalPageCount);
        }

        private Panel OlusturPanel(string text, bool aktif = false, DateTime? tarih = null, string saat = null, int doktorId = 0)
        {
            Panel panel = new Panel
            {
                Width = 600,
                Height = 30,
                Margin = new Padding(5),
                BackColor = Color.Transparent
            };

            Label lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(15, 6),
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            panel.Controls.Add(lbl);

            if (aktif && tarih.HasValue && !string.IsNullOrEmpty(saat))
            {
                Label btnIptal = new Label
                {
                    Text = "X",
                    Cursor = Cursors.Hand,
                    Width = 25,
                    Height = 25,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(560, 2),
                    BackColor = Color.Transparent,
                    ForeColor = Color.IndianRed,
                    Tag = new Tuple<DateTime, string, int>(tarih.Value, saat, doktorId)
                };

                btnIptal.MouseEnter += (s, e) => btnIptal.ForeColor = Color.Red;
                btnIptal.MouseLeave += (s, e) => btnIptal.ForeColor = Color.IndianRed;
                btnIptal.Click += IptalEt_Click;

                panel.Controls.Add(btnIptal);
            }

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

        private void IptalEt_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            var tag = lbl.Tag as Tuple<DateTime, string, int>;
            DateTime tarih = tag.Item1;
            string saat = tag.Item2;
            int doktorId = tag.Item3;

            DialogResult sonuc = MessageBox.Show("Bu randevuyu iptal etmek istediğinizden emin misiniz?", "Randevu İptali", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                RandevuIptalEt(tarih, saat, doktorId);
                RandevulariGetir(1);
            }
        }

        private void RandevuIptalEt(DateTime tarih, string saat, int doktorId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE randevular 
                             SET randevu_durumu = 'iptal' 
                             WHERE tc_no = @tc AND randevu_tarih = @tarih AND randevu_saat = @saat AND doktor_id = @doktorId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", tcno);
                cmd.Parameters.AddWithValue("@tarih", tarih.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@saat", saat);
                cmd.Parameters.AddWithValue("@doktorId", doktorId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}