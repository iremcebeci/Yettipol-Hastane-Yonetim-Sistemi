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
    public partial class profilSayfam : UserControl
    {
        string tcno;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        public profilSayfam(string tcno)
        {
            InitializeComponent();
            this.tcno = tcno;
            this.Load += profilSayfam_load;
        }
        private async void profilSayfam_load(object sender, EventArgs e)
        {
            GetBilgiler(tcno);
        }

        private async Task GetBilgiler(string tc)
        {
            string query = @"SELECT hasta_isimsoyisim, hasta_cinsiyet, email,
                            TIMESTAMPDIFF(YEAR, hasta_dog_tar, CURDATE()) AS yas, hasta_telefon 
                            FROM kullanicilar WHERE tc_no = @tc";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            lbltc.Text = tc;
                            lbladsoyad.Text = reader["hasta_isimsoyisim"].ToString();
                            lblcinsiyet.Text = reader["hasta_cinsiyet"].ToString();
                            lblmail.Text = reader["email"].ToString();
                            lbltel.Text = reader["hasta_telefon"].ToString();
                            lblyas.Text = reader["yas"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı.");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
