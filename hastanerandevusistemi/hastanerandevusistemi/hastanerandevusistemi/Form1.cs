using Google.Api;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        private string tcno;
        public Form1()
        {
            InitializeComponent();

        }
        public void LoadUserControlIcerik(UserControl uc)
        {
            pnlIcerik.Controls.Clear();
            uc.Dock = DockStyle.Right;
            pnlIcerik.Controls.Add(uc);
        }
        public void UserControlYukle(UserControl ctrl)
        {
            pnlIcerik.Controls.Clear();
            pnlIcerik.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
        }
        public void LoadUserControlPanel(UserControl uc)
        {
            pnlleft.Controls.Clear();
            uc.Dock = DockStyle.Left;
            pnlleft.Controls.Add(uc);
        }
        private async void btnGiris_Click(object sender, EventArgs e)
        {
            this.tcno = mskTc.Text;
            if (mskTc.Text == "" || txtAdsoyad.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("L�tfen bilgilerinizi giriniz ve hi�bir alan� bo� b�rakmay�n�z!", "Uyar�",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mskTc.Text.Length != 11)
            {
                MessageBox.Show("Ge�ersiz giri�! L�tfen TC kimlik numaran�z� do�ru kodlay�n�z.", "Uyar�",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool girisBasarili = await HastaGirisKontrol(mskTc.Text, txtAdsoyad.Text, txtSifre.Text);
                bool doktorGirisi = await DoktorKontrol(mskTc.Text, txtAdsoyad.Text, txtSifre.Text);
                bool teknisyenGirisi = await teknisyenKontrol(mskTc.Text, txtAdsoyad.Text, txtSifre.Text);
                bool adminGirisi = await adminKontrol(mskTc.Text, txtAdsoyad.Text, txtSifre.Text);
                if (girisBasarili)
                {
                    Form2 frm = new Form2(this);
                    frm.tcno = mskTc.Text;
                    frm.adsoyad = txtAdsoyad.Text;
                    frm.Show();
                    this.Hide();
                }
                else if (doktorGirisi)
                {

                    Form3 frm = new Form3(this, tcno);
                    string doktorAdi = GetDoktorAdi();
                    frm.Text = doktorAdi;
                    frm.Show();
                    this.Hide();
                }
                else if (teknisyenGirisi)
                {
                    Form4 frm = new Form4(this, tcno);
                    string tekAdi = GetTekAdi();
                    frm.Text = tekAdi;
                    frm.Show();
                    this.Hide();
                }
                /*else if (adminGirisi)
                {
                    Form5 frm = new Form5(this, tcno);
                }*/

                else
                {
                    MessageBox.Show("Giri� ba�ar�s�z. Bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
        public string GetTekAdi()
        {
            string tekAdi = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT isimsoyisim FROM teknisyenler WHERE tc_no = @tc";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", tcno);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        tekAdi = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return tekAdi;
        }


        public string GetDoktorAdi()
        {
            string doktorAdi = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT doktor_isim FROM doktorlar WHERE tc_no = @tc";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", tcno);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        doktorAdi = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return doktorAdi;
        }

        private async Task<bool> HastaGirisKontrol(string tc, string adsoyad, string sifre)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT COUNT(*) FROM kullanicilar WHERE tc_no = @tc AND hasta_isimsoyisim = @adsoyad AND sifre = @sifre AND rol = 'Hasta'";
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



        private async Task<bool> DoktorKontrol(string tc, string adsoyad, string sifre)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT COUNT(*) FROM kullanicilar WHERE tc_no = @tc AND hasta_isimsoyisim = @adsoyad AND sifre = @sifre AND rol = 'Doktor'";
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



        private async Task<bool> adminKontrol(string tc, string adsoyad, string sifre)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT COUNT(*) FROM kullanicilar WHERE tc_no = @tc AND hasta_isimsoyisim = @adsoyad AND sifre = @sifre AND rol = 'Admin'";
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

        private async Task<bool> teknisyenKontrol(string tc, string adsoyad, string sifre)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT COUNT(*) FROM kullanicilar WHERE tc_no = @tc AND hasta_isimsoyisim = @adsoyad AND sifre = @sifre AND rol = 'Teknisyen'";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadUserControlPanel(new uyeOl());
        }

        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbHastane.Items.Clear();
            if (CmbBolum.Text == "Dahiliye (�� Hastal�klar�)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Sar�yer Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Genel Cerrahi")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Kad�n Hastal�klar� ve Do�um")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Kardiyoloji (Kalp ve Damar Hastal�klar�)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Kulak Burun Bo�az (KBB)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Nefroloji")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "N�roloji (Sinir Sistemi Hastal�klar�)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Sar�yer Hastanesi");
            }
            else if (CmbBolum.Text == "Ortopedi ve Travmatoloji")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Sar�yer Hastanesi");
            }
            else if (CmbBolum.Text == "Pediatri (�ocuk Sa�l��� ve Hastal�klar�)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Sar�yer Hastanesi");
            }
            else if (CmbBolum.Text == "Psikiyatri")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Sar�yer Hastanesi");
            }
            else if (CmbBolum.Text == "Plastik, Rekonst�ktif ve Estetik Cerrahi")
            {
                CmbHastane.Items.Add("Yettipol Bayrampa�a Hastanesi");
                CmbHastane.Items.Add("Yettipol Sar�yer Hastanesi");
            }
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            string secilenDeger = CmbHastane.SelectedItem?.ToString();
            if (CmbBolum.Text == "Dahiliye (�� Hastal�klar�)")
            {
                var uc = new dahiliyeDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Genel Cerrahi")
            {
                var uc = new genelCerrahiDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Kad�n Hastal�klar� ve Do�um")
            {
                var uc = new kad�nHastDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Kardiyoloji (Kalp ve Damar Hastal�klar�)")
            {
                var uc = new kardiyolojiDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Kulak Burun Bo�az (KBB)")
            {
                var uc = new KBBDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Nefroloji")
            {
                var uc = new nefrolojiDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (CmbBolum.Text == "N�roloji (Sinir Sistemi Hastal�klar�)")
            {
                var uc = new norolojiDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Ortopedi ve Travmatoloji")
            {
                var uc = new ortopediDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Pediatri (�ocuk Sa�l��� ve Hastal�klar�)")
            {
                var uc = new pediatriDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Psikiyatri")
            {
                var uc = new psikiyatriDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }
                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Plastik, Rekonst�ktif ve Estetik Cerrahi")
            {
                var uc = new estetikDoktorlar(secilenDeger);
                uc.bolum = CmbBolum.Text;
                uc.hastane = CmbHastane.Text;
                if (radHastane.Checked)
                {
                    uc.randTipi = radHastane.Text;
                    LoadUserControlIcerik(uc);
                }
                else if (radGoruntulu.Checked)
                {
                    uc.randTipi = radGoruntulu.Text;
                    LoadUserControlIcerik(uc);
                }

                else
                    MessageBox.Show("L�tfen randevu tipi se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("L�tfen b�l�m se�me alan�n� bo� b�rakmay�n�z.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            CmbBolum.SelectedIndex = -1;
            CmbHastane.SelectedIndex = -1;
            radGoruntulu.Checked = false;
            radHastane.Checked = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mskTc.Text == "")
                MessageBox.Show("Aktif randevular�n�z� sorgulayabilmek i�in l�tfen tc no alan�n� doldurunuz.", "uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (mskTc.Text.Length != 11)
            {
                MessageBox.Show("Ge�ersiz giri�! L�tfen TC kimlik numaran�z� do�ru kodlay�n�z.", "Uyar�",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                LoadUserControlIcerik(new randevugoruntule(mskTc.Text));
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadUserControlIcerik(new bot());
        }
    }
}
