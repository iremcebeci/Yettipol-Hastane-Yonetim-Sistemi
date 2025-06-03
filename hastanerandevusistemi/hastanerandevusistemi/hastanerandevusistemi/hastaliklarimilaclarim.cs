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
    public partial class hastaliklarimilaclarim : UserControl
    {
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        string tcno;
        public hastaliklarimilaclarim(string tcno)
        {
            InitializeComponent();
            this.tcno = tcno;
            hastaliklariGetir();
            ilaclariGetir();
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

        private Panel OlusturPanel(string text, bool iptalli = false, DateTime? tarih = null, string saat = null, int doktorId = 0)
        {
            Panel panel = new Panel
            {
                Width = 400,
                Height = 25,
                Margin = new Padding(5),
                BackColor = Color.Transparent
            };

            Label lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(15, 4)
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
                AutoSize = true
            };
        }

        private void hastaliklarimilaclarim_Load(object sender, EventArgs e)
        {
            Form anaForm = this.FindForm();
            if (anaForm != null && anaForm.Name == "Form3")
            {
                btnilac.Visible = true;
                btnhastalik.Visible = true;
            }
            else
            {
                btnilac.Visible = false;
                btnhastalik.Visible = false;
            }
        }

        private void btnhastalik_Click(object sender, EventArgs e)
        {
            int doktorID = GetDoktorId(tcno);
            hastalikEkle form = new hastalikEkle(tcno, doktorID);
            form.ShowDialog();
            hastaliklariGetir();
        }
        public int GetDoktorId(string tcNo)
        {
            int doktorId = -1;

            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT doktor_id FROM randevular WHERE tc_no = @tc", conn);
                cmd.Parameters.AddWithValue("@tc", tcNo);
                var result = cmd.ExecuteScalar();

                if (result != null)
                    doktorId = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return doktorId;
        }

        private void btnilac_Click(object sender, EventArgs e)
        {
            int doktorID = GetDoktorId(tcno);
            receteEkle form = new receteEkle(tcno,doktorID);
            form.ShowDialog();
            ilaclariGetir();
        }
    }
}
