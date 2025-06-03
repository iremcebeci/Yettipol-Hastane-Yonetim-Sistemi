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

    public partial class pnlleft : UserControl
    {
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        public pnlleft()
        {
            InitializeComponent();
        }
        public void LoadUserControlPanel(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Left;
            this.Controls.Add(uc);
        }
        public void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadUserControlPanel(new uyeOl());
        }

        private async void btnGiris_Click(object sender, EventArgs e)
        {
            if (mskTc.Text == "" || txtAdsoyad.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Lütfen bilgilerinizi giriniz ve hiçbir alanı boş bırakmayınız!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mskTc.Text.Length != 11)
            {
                MessageBox.Show("Geçersiz giriş! Lütfen TC kimlik numaranızı doğru kodlayınız.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool girisBasarili = await HastaGirisKontrol(mskTc.Text, txtAdsoyad.Text, txtSifre.Text);
                if (girisBasarili)
                {
                    Form1 form = this.FindForm() as Form1;
                    Form2 frm = new Form2(form);
                    frm.tcno = mskTc.Text;
                    frm.adsoyad = txtAdsoyad.Text;
                    frm.Show();
                    form.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş başarısız. Bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> HastaGirisKontrol(string tc, string adsoyad, string sifre)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT COUNT(*) FROM kullanicilar WHERE tc_no = @tc AND hasta_isimsoyisim = @adsoyad AND sifre = @sifre";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@adsoyad", adsoyad);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    object result = await cmd.ExecuteScalarAsync();
                    int count = Convert.ToInt32(result);
                    return count > 0;
                }
            }
        }
        private void chcSifregoster_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = !txtSifre.UseSystemPasswordChar;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mskTc.Text == "")
                MessageBox.Show("Aktif randevularınızı sorgulayabilmek için lütfen tc no alanını doldurunuz.", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (mskTc.Text.Length != 11)
            {
                MessageBox.Show("Geçersiz giriş! Lütfen TC kimlik numaranızı doğru kodlayınız.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1 frm = this.FindForm() as Form1;
            if (frm != null)
            {
                frm.UserControlYukle(new randevugoruntule(mskTc.Text));
            }

        }
    }
}
