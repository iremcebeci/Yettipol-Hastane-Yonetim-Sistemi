using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace hastaneRandevuSistemi
{
    public partial class uyeOl : UserControl
    {
        private string connectionString = "server=localhost;database=yettipol;uid=root;password='141002';";

        public uyeOl()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void LoadUserControlPanel(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadUserControlPanel(new pnlleft());
        }

        private async void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mskTel.Text) ||
                string.IsNullOrWhiteSpace(mskTc.Text) ||
                string.IsNullOrWhiteSpace(cmbCinsiyet.Text) ||
                string.IsNullOrWhiteSpace(txtAdsoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Geçersiz giriş! Lütfen tüm alanları doldurduğunuza emin olunuz.",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!tcdogrulama.Dogrula(mskTc.Text))
            {
                return;
            }

            if (dateTimePicker1.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Geçersiz giriş! Lütfen geçerli bir doğum tarihi giriniz.",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string isimsoyisim = txtAdsoyad.Text;
            string email = txtEposta.Text;
            string sifre = txtSifre.Text; 
            string dogumtarihi = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string telefon = mskTel.Text;
            string tc = mskTc.Text;
            string cinsiyet = cmbCinsiyet.Text;


            bool kullaniciKaydedildi = await KullaniciKaydet(email, sifre, isimsoyisim, tc, dogumtarihi, telefon, cinsiyet);
            if (!kullaniciKaydedildi)
            {
            
                return;
            }

            bool hastaKaydedildi = await HastaKaydet(tc, isimsoyisim, telefon, cinsiyet, dogumtarihi);
            if (hastaKaydedildi)
            {
                DialogResult cevap = MessageBox.Show("Kayıt başarıyla tamamlandı. Giriş ekranına yönlendiriliyorsunuz.",
                                                       "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cevap == DialogResult.OK)
                    LoadUserControlPanel(new pnlleft());
            }
        }

        public async Task<bool> KullaniciKaydet(string email, string sifre, string isimsoyisim, string tc, string dogumtarihi, string telefon, string cinsiyet)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string kontrolQuery = "SELECT COUNT(*) FROM kullanicilar WHERE tc_no = @tc";
                using (MySqlCommand kontrolCmd = new MySqlCommand(kontrolQuery, conn))
                {
                    kontrolCmd.Parameters.AddWithValue("@tc", tc);
                    long count = (long)await kontrolCmd.ExecuteScalarAsync();
                    if (count > 0)
                    {
                        MessageBox.Show("Bu TC numarasına ait bir hesap bulunmakta. Lütfen giriş yapma ekranından giriş yapınız.",
                                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                string query = "INSERT INTO kullanicilar (hasta_isimsoyisim, email, sifre, tc_no, hasta_dog_tar, hasta_telefon, hasta_cinsiyet) " +
                               "VALUES (@hasta_isimsoyisim, @email, @sifre, @tc_no, @hasta_dog_tar, @hasta_tel, @cinsiyet)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hasta_isimsoyisim", isimsoyisim);
                    cmd.Parameters.AddWithValue("@tc_no", tc);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    cmd.Parameters.AddWithValue("@hasta_dog_tar", dogumtarihi);
                    cmd.Parameters.AddWithValue("@hasta_tel", telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);

                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        private async Task<bool> HastaKaydet(string tc, string adsoyad, string telefon, string cinsiyet, string dogumtar)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string kontrolQuery = "SELECT COUNT(*) FROM hastalar WHERE tc_no = @tc";
                using (MySqlCommand kontrolCmd = new MySqlCommand(kontrolQuery, conn))
                {
                    kontrolCmd.Parameters.AddWithValue("@tc", tc);
                    long count = (long)await kontrolCmd.ExecuteScalarAsync();
                    if (count > 0)
                    {
                        return true; 
                    }
                }

                string query = "INSERT INTO hastalar (tc_no, hasta_isimsoyisim, hasta_cinsiyet, hasta_dog_tar, hasta_telefon) " +
                               "VALUES (@tc, @adsoyad, @cinsiyet, @dogum_tar, @telefon)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@adsoyad", adsoyad);
                    cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tar", dogumtar);
                    cmd.Parameters.AddWithValue("@telefon", telefon);

                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }
        private void chcSifregoster_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = !txtSifre.UseSystemPasswordChar;
        }
    }
}
