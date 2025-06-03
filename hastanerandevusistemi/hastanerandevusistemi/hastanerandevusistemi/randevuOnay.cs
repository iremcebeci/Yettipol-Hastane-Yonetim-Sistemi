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
    public partial class randevuOnay : UserControl
    {
        DateTime secilitarih;
        string doktoradi;
        string randevutipi;
        string secilisaat;
        private string hastane;
        private string bolum;
        private string tc = "";
        private string adsoyad = "";
        private string telefon = "";
        private string cinsiyet = "";
        private DateTime dogumtar;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";

        public randevuOnay(string hastane, string seciliSaat, DateTime seciliTarih, string doktorAdi, string randTipi, string bolum)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            this.secilisaat = seciliSaat;
            this.randevutipi = randTipi;
            this.secilitarih = seciliTarih;
            this.doktoradi = doktorAdi;
            this.bolum = bolum;
            this.hastane = hastane;
            this.lblDoktor.Text = doktorAdi;
            this.lblBolum.Text = bolum;
            this.lblRandevutipi.Text = randTipi;
            this.lblSaat.Text = seciliSaat;
            this.lblTarih.Text = seciliTarih.ToString("dd.MM.yyyy");
            this.lblHastane.Text = hastane;


            if (randTipi == "Hastane randevusu")
                randevutipi = "Hastane";
            else
                randevutipi = "Online";
        }

        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        private async Task<bool> AktifRandevuVarMi(string doktorAdi)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();


            string bolumId = null;
            string bolumQuery = "SELECT bolum_id FROM doktorlar WHERE doktor_isim = @doktor";
            using (var cmd = new MySqlCommand(bolumQuery, conn))
            {
                cmd.Parameters.AddWithValue("@doktor", doktorAdi);
                var result = await cmd.ExecuteScalarAsync();
                bolumId = result?.ToString().Trim();
            }

            if (string.IsNullOrEmpty(bolumId))
                return false;


            string randevuQuery = @"
            SELECT COUNT(*) FROM randevular
            WHERE TRIM(tc_no) = @tc AND TRIM(bolum_id) = @bolumId AND LOWER(randevu_durumu) = 'aktif'";

            using (var cmd = new MySqlCommand(randevuQuery, conn))
            {
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@bolumId", bolumId);

                var count = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(count) > 0;
            }
        }
        private async Task<bool> HastaRandevusuVarMi(DateTime tarih, string saat)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string query = @"
            SELECT COUNT(*) FROM randevular
            WHERE TRIM(tc_no) = @tc 
            AND randevu_tarih = @tarih 
            AND randevu_saat = @saat
            AND LOWER(randevu_durumu) = 'aktif'";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@tarih", tarih.Date); 
                cmd.Parameters.AddWithValue("@saat", TimeSpan.Parse(saat)); 
                var count = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(count) > 0;
            }
        }
        private async Task RandevuIptalVeYeniKaydet()
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string bolumId = null;
            string bolumQuery = "SELECT bolum_id FROM doktorlar WHERE doktor_isim = @doktor";
            using (var cmd = new MySqlCommand(bolumQuery, conn))
            {
                cmd.Parameters.AddWithValue("@doktor", doktoradi);
                var result = await cmd.ExecuteScalarAsync();
                bolumId = result?.ToString().Trim();
            }

            if (string.IsNullOrEmpty(bolumId))
            {
                MessageBox.Show("Doktorun bölümü bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updateQuery = "UPDATE randevular SET randevu_durumu = 'iptal' WHERE tc_no = @tc AND bolum_id = @bolum AND randevu_durumu = 'aktif'";
            using (var cmd = new MySqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@bolum", bolumId);
                await cmd.ExecuteNonQueryAsync();
            }
            bool basarili = await RandevuKaydet(tc, doktoradi, secilitarih, secilisaat, randevutipi);
            if (basarili)
            {
                MessageBox.Show("Yeni randevunuz başarıyla oluşturulmuştur. Randevunuzu anasayfanızdan takip edebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserControlIcerik(new girisIcerik(tc));
            }
            else
            {
                MessageBox.Show("Randevu alınırken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (mskTc.Text == "" || txtAdsoyad.Text == "" || mskTel.Text == "" || cmbCinsiyet.Text == "")
                MessageBox.Show("lütfen tüm alanları doldurunuz");
            else if (!tcdogrulama.Dogrula(mskTc.Text))
            {
                MessageBox.Show("Geçersiz giriş! Lütfen TC kimlik numaranızı doğru kodlayınız.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(dateTimePicker1.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Geçersiz giriş! Lütfen geçerli bir doğum tarihi giriniz.",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (await AktifRandevuVarMi(doktoradi))
            {
                DialogResult result = MessageBox.Show("Aynı bölümden aktif bir randevunuz bulunmaktadır. Devam ederseniz eski randevunuz iptal edilecektir. Devam etmek istediğinize emin misiniz?", "Randevu İptali", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    await RandevuIptalVeYeniKaydet();
                }
                else
                {
                    return;
                }
            }
            else if (await HastaRandevusuVarMi(secilitarih, secilisaat))
            {
                MessageBox.Show("Seçtiğiniz saatte aktif bir randevunuz bulunmaktadır. Lütfen farklı bir randevu zamanı seçiniz veya aktif randevunuzu iptal ediniz.", "Randevu İptali", MessageBoxButtons.OK);
                return;
            }

            else
            {
                tc = this.mskTc.Text;
                adsoyad = this.txtAdsoyad.Text;
                telefon = this.mskTel.Text;
                cinsiyet = this.cmbCinsiyet.Text;
                dogumtar = this.dateTimePicker1.Value;

                DialogResult sonuc = MessageBox.Show($"{doktoradi} için {secilitarih:dd.MM.yyyy} tarihli {secilisaat} saatindeki randevuyu onaylıyor musunuz?", "onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    await HastaKaydet(tc, adsoyad, telefon, cinsiyet, dogumtar);
                    await RandevuKaydet(tc, doktoradi, secilitarih, secilisaat, randevutipi);
                    MessageBox.Show("Randevunuz başarıyla alındı! Randevunuzu tc kimlik numaranız ile anasayfamızdan sorgulatabilir ve iptal edebilirsiniz. \n Sağlıklı günler dileriz", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserControlIcerik(new pnlicerik());
                }
            }
        }
        private async Task<bool> RandevuKaydet(string tc, string doktorAdi, DateTime tarih, string saat, string randevutipi)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO randevular (tc_no, doktor_id, hastane_id, bolum_id, randevu_tarih, randevu_saat, randevu_turu) VALUES (@tc, @doktorId, @hastane, @bolum, @tarih, @saat, @randevu_turu)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int doktorId = await GetDoktorId(doktorAdi, conn);
                    string hastaneId = await GetHastaneId(hastane, conn);
                    string bolumId = await GetBolumId(doktoradi, conn);
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@doktorId", doktorId);
                    cmd.Parameters.AddWithValue("@hastane", hastaneId);
                    cmd.Parameters.AddWithValue("@bolum", bolumId);
                    cmd.Parameters.AddWithValue("@tarih", tarih.Date);
                    cmd.Parameters.AddWithValue("@saat", saat);
                    cmd.Parameters.AddWithValue("@randevu_turu", randevutipi);


                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }
        private async Task<int> GetDoktorId(string doktorAdi, MySqlConnection conn)
        {
            string query = "SELECT doktor_id FROM doktorlar WHERE doktor_isim = @doktorAdi";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@doktorAdi", doktorAdi);
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        private async Task<string> GetBolumId(string doktorAdi, MySqlConnection conn)
        {
            string query = "SELECT bolum_id FROM doktorlar WHERE doktor_isim = @doktor";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@doktor", doktorAdi);
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? result.ToString() : "";
            }
        }
        private async Task<string> GetHastaneId(string hastane, MySqlConnection conn)
        {
            string query = "SELECT hastane_id FROM hastaneler WHERE hastane_isim = @hastane";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@hastane", hastane);
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? result.ToString() : "";
            }
        }
        private async Task<bool> HastaKaydet(string tc, string adsoyad, string telefon, string cinsiyet, DateTime dogumtar)
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

                string query = "INSERT INTO hastalar (tc_no, hasta_isimsoyisim, hasta_cinsiyet, hasta_dog_tar, hasta_telefon) VALUES (@tc, @adsoyad, @cinsiyet, @dogum_tar, @telefon)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@adsoyad", adsoyad);
                    cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tar", dogumtar.Date);
                    cmd.Parameters.AddWithValue("@telefon", telefon);

                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            cmbCinsiyet.SelectedIndex = -1;
            txtAdsoyad.Text = string.Empty;
            mskTc.Text = string.Empty;
            mskTel.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new pnlicerik());
        }
    }
}
