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
    public partial class Form2 : Form
    {
        private Form1 form1Reference;
        public string tcno;
        public string adsoyad;
        private bool cikisyap = false;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";


        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1Reference = form1;
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

            labeltc.Text = tcno;
            labelAdsoyad.Text = adsoyad;
            RandevulariGetir();
            hastaliklariGetir();
            ilaclariGetir();
        }

        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (!cikisyap)
            {
                form1Reference.Close();
            }
        }

        private void LoadUserControlPanel(UserControl uc)
        {
            pnlleft.Controls.Clear();
            uc.Dock = DockStyle.Left;
            pnlleft.Controls.Add(uc);
        }

        private void LoadUserControlIcerik(UserControl uc)
        {
            pnlicerik.Controls.Clear();
            uc.Dock = DockStyle.Right;
            pnlicerik.Controls.Add(uc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new girisIcerik(tcno));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new pnlicerik());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cikisyap = true;
            form1Reference.Show();
            this.Close();
        }

        private void RandevulariGetir()
        {


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT randevu_tarih, randevu_saat, doktor_isim, bolum_isim, randevular.doktor_id 
                                 FROM randevular
                                 INNER JOIN doktorlar ON randevular.doktor_id = doktorlar.doktor_id
                                 INNER JOIN bolumler ON doktorlar.bolum_id = bolumler.bolum_id
                                 WHERE randevular.tc_no = @tc AND randevu_durumu = 'Aktif'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", tcno);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return;
                    }
                    flowLayoutPanel1.Controls.Clear();
                    while (reader.Read())
                    {
                        DateTime tarih = DateTime.Parse(reader["randevu_tarih"].ToString());
                        TimeOnly saat = TimeOnly.Parse(reader["randevu_saat"].ToString());
                        string doktor = reader["doktor_isim"].ToString();
                        string bolum = reader["bolum_isim"].ToString();
                        int doktorId = Convert.ToInt32(reader["doktor_id"]);

                        string bilgi = $"{tarih:dd.MM.yyyy} {saat:HH:mm} | {bolum} / {doktor}";
                        var panel = OlusturPanel(bilgi, true, tarih, saat.ToString("HH:mm"), doktorId);
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }
        }

        private void hastaliklariGetir()
        {
            flowLayoutPanel2.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT hastalik_adi, teshis_tarihi FROM hastaliklar WHERE tc_no = @tc";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", tcno);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        flowLayoutPanel2.Controls.Add(OlusturLabel("Sistemimizde hastalık bilginiz bulunmamaktadır.", 4, 80));
                        return;
                    }

                    while (reader.Read())
                    {
                        string hastalik = reader["hastalik_adi"].ToString();
                        string teshis = reader["teshis_tarihi"].ToString();

                        string bilgi = $"{teshis} tarihinde bulgulanmış {hastalik}";
                        var panel = OlusturPanel(bilgi);
                        flowLayoutPanel2.Controls.Add(panel);
                    }
                }
            }
        }

        private void ilaclariGetir()
        {
            flowLayoutPanel3.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ilac_adi, dozaj, kullanim_sikligi FROM receteler WHERE tc_no = @tc";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", tcno);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        flowLayoutPanel3.Controls.Add(OlusturLabel("Sistemimizde ilaç bilginiz bulunmamaktadır.", 4, 80));
                        return;
                    }

                    while (reader.Read())
                    {
                        string ilac = reader["ilac_adi"].ToString();
                        string dozaj = reader["dozaj"].ToString();
                        string kullanim = reader["kullanim_sikligi"].ToString();

                        string bilgi = $"{ilac} {dozaj} | {kullanim}";
                        var panel = OlusturPanel(bilgi);
                        flowLayoutPanel3.Controls.Add(panel);
                    }
                }
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Label btn = sender as Label;
            var tuple = btn.Tag as Tuple<DateTime, string, int>;

            if (tuple == null)
            {
                MessageBox.Show("Hata: randevu bilgisi bulunamadı.");
                return;
            }

            DateTime tarih = tuple.Item1;
            string saat = tuple.Item2;
            int doktorId = tuple.Item3;

            DialogResult sonuc = MessageBox.Show("Bu randevuyu iptal etmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE randevular 
                                     SET randevu_durumu = 'Iptal' 
                                     WHERE tc_no = @tc AND randevu_tarih = @tarih AND randevu_saat = @saat AND doktor_id = @doktorId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", tcno);
                    cmd.Parameters.AddWithValue("@tarih", tarih);
                    cmd.Parameters.AddWithValue("@saat", saat);
                    cmd.Parameters.AddWithValue("@doktorId", doktorId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Randevu iptal edildi.");
                RandevulariGetir();
            }
        }

        private Panel OlusturPanel(string text, bool iptalli = false, DateTime? tarih = null, string saat = null, int doktorId = 0)
        {
            Panel panel = new Panel
            {
                Width = 385,
                Height = 25,
                //Margin = new Padding(5),
                Font = new Font("Segoe UI", 8),
                BackColor = Color.Transparent
            };

            Label lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(0, 4)
            };
            panel.Controls.Add(lbl);

            if (iptalli)
            {
                Label btnIptal = new Label
                {
                    Text = "X",
                    Cursor = Cursors.Hand,
                    Width = 25,
                    Height = 25,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(365, -3),
                    BackColor = Color.Transparent,
                    ForeColor = Color.IndianRed,
                    Tag = new Tuple<DateTime, string, int>(tarih.Value, saat, doktorId)
                };

                btnIptal.MouseEnter += (s, e) => btnIptal.ForeColor = Color.Red;
                btnIptal.MouseLeave += (s, e) => btnIptal.ForeColor = Color.IndianRed;
                btnIptal.Click += BtnIptal_Click;
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
                AutoSize = true
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new randevugoruntule(tcno));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new randevugoruntule(tcno));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new hastaliklarimilaclarim(tcno));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new profilSayfam(tcno));
        }
    }
}
