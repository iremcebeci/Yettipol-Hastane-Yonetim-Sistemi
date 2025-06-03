using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class randevuSec : UserControl
    {
        int doktorId;
        private DayOfWeek izinGunu;
        private DayOfWeek akademikIzin;
        private HashSet<DateTime> tatilGunleri = new HashSet<DateTime>();
        private string hastane = "";
        private string tc = "";
        private string bolum = "";
        private string randTipi = "";
        private DateTime currentDate;
        private string seciliSaat = "";
        private DateTime seciliTarih;
        private string doktorAdi = "";
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        string hastaneId;
        string bolumId;

        public randevuSec(string doktor, string randTipi, string bolum, string hastane)
        {
            Form2 frm = this.FindForm() as Form2;
            if (frm != null)
            {
                this.tc = frm.tcno;
            }
            InitializeComponent();
            this.randTipi = randTipi;
            this.bolum = bolum;
            this.doktorAdi = doktor;
            lblDoktor.Text = doktorAdi;
            this.lblBolum.Text = bolum;
            this.lblRandevutipi.Text = randTipi;
            this.lblHastane.Text = hastane;
            if (randTipi == "Hastane randevusu")
                this.randTipi = "Hastane";
            else
                this.randTipi = "Online";
            currentDate = GetHaftaninIlkGunu(DateTime.Now);
            UpdateDateDisplay();
            this.Load += Pnlicerik_Load;
            this.Load += async (s, e) =>
            {
                string hastaneAdi = await GetHastaneAdiAsync(doktorAdi);
                this.lblHastane.Text = hastaneAdi;

                await TatilGunleriniYukle();
                izingunu();
                await PopulateDaysAndHours();
            };
        }

        private void Pnlicerik_Load(object sender, EventArgs e)
        {
            Form2 frm = this.FindForm() as Form2;
            if (frm != null)
            {
                this.tc = frm.tcno;
            }
        }

        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }

        private void UpdateDateDisplay()
        {
            lblDateDisplay.Text = $"{currentDate:dd MMMM} - {currentDate.AddDays(6):dd MMMM yyyy}";
        }

        private async Task PopulateDaysAndHours()
        {
            for (int i = 0; i < 7; i++)
            {
                DateTime day = currentDate.AddDays(i);
                var alinanSaatler = await GetAlinanSaatlerAsync(day, doktorAdi);

                if (i < flowLayoutPanelDays.Controls.Count)
                {
                    FlowLayoutPanel dayPanel = (FlowLayoutPanel)flowLayoutPanelDays.Controls[i];
                    Label dayLabel = (Label)dayPanel.Controls[0];
                    dayLabel.Text = day.ToString("dd MMMM dddd", new CultureInfo("tr-TR"));
                    dayLabel.Tag = day;

                    for (int hour = 9; hour <= 17; hour++)
                    {
                        if (hour == 12) continue;

                        int index = (hour < 12) ? hour - 9 + 1 : hour - 9;
                        Label hourLabel = (Label)dayPanel.Controls[index];
                        hourLabel.Text = $"{hour:00}:00";
                        hourLabel.Cursor = Cursors.Hand;

                        DateTime saatTarihi = new DateTime(day.Year, day.Month, day.Day, hour, 0, 0);
                        string saatStr = saatTarihi.ToString("HH:mm");

                        if (saatTarihi < DateTime.Now || alinanSaatler.Contains(saatStr) ||
                            saatTarihi.DayOfWeek == izinGunu ||
                            saatTarihi.DayOfWeek == akademikIzin ||
                            tatilGunleri.Contains(saatTarihi.Date))
                        {
                            hourLabel.BackColor = Color.LightGray;
                            hourLabel.ForeColor = Color.DarkGray;
                            hourLabel.Cursor = Cursors.Default;
                            hourLabel.Enabled = false;
                        }
                        else if (randTipi == "Online")
                        {
                            if (saatTarihi.DayOfWeek == DayOfWeek.Saturday)
                            {
                                hourLabel.BackColor = Color.LimeGreen;
                                hourLabel.ForeColor = Color.WhiteSmoke;
                                hourLabel.Enabled = true;
                                hourLabel.Click += HourLabel_Click;
                            }
                            else
                            {
                                hourLabel.BackColor = Color.LightGray;
                                hourLabel.ForeColor = Color.DarkGray;
                                hourLabel.Cursor = Cursors.Default;
                                hourLabel.Enabled = false;
                            }
                        }
                        else
                        {
                            if (saatTarihi.DayOfWeek == DayOfWeek.Saturday || saatTarihi.DayOfWeek == DayOfWeek.Sunday)
                            {
                                hourLabel.BackColor = Color.LightGray;
                                hourLabel.ForeColor = Color.DarkGray;
                                hourLabel.Cursor = Cursors.Default;
                                hourLabel.Enabled = false;
                            }
                            else
                            {
                                hourLabel.BackColor = Color.LimeGreen;
                                hourLabel.ForeColor = Color.WhiteSmoke;
                                hourLabel.Enabled = true;
                                hourLabel.Click += HourLabel_Click;
                            }
                        }
                    }
                }
            }
        }
        private void izingunu()
        {
            string izinGunuStr = "";
            string akademikIzinGunuStr = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT izingunu, akademik_izin FROM doktorlar WHERE doktor_isim = @doktorAdi";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@doktorAdi", doktorAdi);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            izinGunuStr = reader["izingunu"].ToString();
                            akademikIzinGunuStr = reader["akademik_izin"].ToString();
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(izinGunuStr))
            {
                this.izinGunu = CevirGune(izinGunuStr);
            }

            if (!string.IsNullOrEmpty(akademikIzinGunuStr))
            {
                this.akademikIzin = CevirGune(akademikIzinGunuStr);
            }
        }


        private DayOfWeek CevirGune(string gunStr)
        {
            switch (gunStr.ToLower())
            {
                case "pazartesi": return DayOfWeek.Monday;
                case "salı": return DayOfWeek.Tuesday;
                case "çarşamba": return DayOfWeek.Wednesday;
                case "perşembe": return DayOfWeek.Thursday;
                case "cuma": return DayOfWeek.Friday;
                case "cumartesi": return DayOfWeek.Saturday;
                case "pazar": return DayOfWeek.Sunday;
                default: throw new ArgumentException("Geçersiz gün: " + gunStr);
            }
        }
        private async Task TatilGunleriniYukle()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT tarih FROM tatil_gunleri";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (DateTime.TryParse(reader["tarih"].ToString(), out DateTime tarih))
                        {
                            tatilGunleri.Add(tarih.Date);
                        }
                    }
                }
            }
        }

        private async void HourLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            foreach (FlowLayoutPanel dayPanel in flowLayoutPanelDays.Controls)
            {
                foreach (Control control in dayPanel.Controls)
                {
                    if (control is Label hourLabel && hourLabel != dayPanel.Controls[0])
                    {
                        if (hourLabel.Enabled)
                        {
                            hourLabel.BackColor = Color.LimeGreen;
                            hourLabel.ForeColor = Color.WhiteSmoke;
                        }
                    }
                }
            }

            seciliSaat = clickedLabel.Text;

            FlowLayoutPanel parentPanel = clickedLabel.Parent as FlowLayoutPanel;
            Label gunLabel = parentPanel.Controls[0] as Label;

            seciliTarih = (DateTime)gunLabel.Tag;

            clickedLabel.BackColor = Color.Orange;
            clickedLabel.ForeColor = Color.White;
        }

        private async Task<HashSet<string>> GetAlinanSaatlerAsync(DateTime tarih, string doktor)
        {
            HashSet<string> saatler = new HashSet<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string query = @"
                SELECT r.randevu_saat
                FROM randevular r
                JOIN doktorlar d ON r.doktor_id = d.doktor_id
                WHERE r.randevu_tarih = @tarih AND d.doktor_isim = @doktor;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@doktor", doktor);
                    cmd.Parameters.AddWithValue("@tarih", tarih.Date);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string saatStr = reader["randevu_saat"].ToString();
                            if (!string.IsNullOrEmpty(saatStr))
                            {
                                saatler.Add(DateTime.Parse(saatStr).ToString("HH:mm"));
                            }
                        }
                    }
                }
            }

            return saatler;
        }

        private void lblSonraki_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            UpdateDateDisplay();
            _ = PopulateDaysAndHours();
        }

        private void lblOnceki_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            UpdateDateDisplay();
            _ = PopulateDaysAndHours();
        }

        private DateTime GetHaftaninIlkGunu(DateTime tarih)
        {
            int fark = ((int)tarih.DayOfWeek + 6) % 7;
            return tarih.Date.AddDays(-fark);
        }
        private async Task<string> GetHastaneAdiAsync(string doktorAdi)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string query = @"
                SELECT h.hastane_isim
                FROM doktorlar d
                JOIN hastaneler h ON d.hastane_id = h.hastane_id
                WHERE d.doktor_isim = @doktorAdi";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@doktorAdi", doktorAdi);

                    object result = await cmd.ExecuteScalarAsync();

                    if (result != null)
                    {
                        hastane = result.ToString();
                        return hastane;
                    }
                    else
                    {
                        return "Bilinmiyor";
                    }
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
                    
                    doktorId = await GetDoktorId(doktorAdi, conn);
                    hastaneId = await GetHastaneId(hastane, conn);
                    bolumId = await GetBolumId(doktorAdi, conn);
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
                cmd.Parameters.AddWithValue("@tarih", tarih.Date);  // sadece tarih kısmı önemli
                cmd.Parameters.AddWithValue("@saat", TimeSpan.Parse(saat)); // saat Time olarak kaydediliyor

                var count = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(count) > 0;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var conn = new MySqlConnection(connectionString);

            if (string.IsNullOrEmpty(seciliSaat))
            {
                MessageBox.Show("Lütfen bir saat seçin.", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (await AktifRandevuVarMi(doktorAdi))
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
            else if(await HastaRandevusuVarMi(seciliTarih, seciliSaat))
            {
                MessageBox.Show("Seçtiğiniz saatte aktif bir randevunuz bulunmaktadır. Lütfen farklı bir randevu zamanı seçiniz veya aktif randevunuzu iptal ediniz.", "Randevu İptali", MessageBoxButtons.OK);
                return;
            }

            else if (!string.IsNullOrEmpty(tc))
            {
                DialogResult sonuc = MessageBox.Show($"{doktorAdi} için {seciliTarih:dd.MM.yyyy} tarihli {seciliSaat} saatindeki randevuyu onaylıyor musunuz?", "onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    bool basarili = await RandevuKaydet(tc, doktorAdi, seciliTarih, seciliSaat, randTipi);

                    if (basarili)
                    {
                        MessageBox.Show("Randevunuz başarıyla alındı! Randevunuzu anasayfanızdan ve randevularım sayfanızdan sorgulatabilir ve iptal edebilirsiniz.\n Sağlıklı günler dileriz", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserControlIcerik(new girisIcerik(tc));
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                LoadUserControlIcerik(new randevuOnay(hastane, seciliSaat, seciliTarih, doktorAdi, randTipi, bolum));
            }
        }

        private async Task RandevuIptalVeYeniKaydet()
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            // Bölüm ID'si çekiliyor
            string bolumId = null;
            string bolumQuery = "SELECT bolum_id FROM doktorlar WHERE doktor_isim = @doktor";
            using (var cmd = new MySqlCommand(bolumQuery, conn))
            {
                cmd.Parameters.AddWithValue("@doktor", doktorAdi);
                var result = await cmd.ExecuteScalarAsync();
                bolumId = result?.ToString().Trim();
            }

            if (string.IsNullOrEmpty(bolumId))
            {
                MessageBox.Show("Doktorun bölümü bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Eski randevuyu iptal et
            string updateQuery = "UPDATE randevular SET randevu_durumu = 'iptal' WHERE tc_no = @tc AND bolum_id = @bolum AND randevu_durumu = 'aktif'";
            using (var cmd = new MySqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@bolum", bolumId);
                await cmd.ExecuteNonQueryAsync();
            }

            // Yeni randevuyu kaydet
            bool basarili = await RandevuKaydet(tc, doktorAdi, seciliTarih, seciliSaat, randTipi);
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

        private void lblHastane_Click_1(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new pnlicerik());
        }

        private void lblDoktor_Click(object sender, EventArgs e)
        {
            // LoadUserControlIcerik();
        }
    }
}