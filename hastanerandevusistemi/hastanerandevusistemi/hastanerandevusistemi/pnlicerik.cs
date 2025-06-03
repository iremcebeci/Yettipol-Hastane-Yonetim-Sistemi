using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastaneRandevuSistemi
{
    public partial class pnlicerik : UserControl
    {
        public pnlicerik()
        {
            InitializeComponent();
            this.Load += Pnlicerik_Load;
        }

        private void Pnlicerik_Load(object sender, EventArgs e)
        {
            Form2 frm = this.FindForm() as Form2;
            if (frm != null)
            {
                if (label3 != null)
                    label3.Text = "RANDEVU AL";

            }
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Left;
            this.Controls.Add(uc);
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            string secilenDeger = CmbHastane.SelectedItem?.ToString();
            if (CmbBolum.Text == "Dahiliye (İç Hastalıkları)")
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Kadın Hastalıkları ve Doğum")
            {
                var uc = new kadınHastDoktorlar(secilenDeger);
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Kardiyoloji (Kalp ve Damar Hastalıkları)")
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Kulak Burun Boğaz (KBB)")
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (CmbBolum.Text == "Nöroloji (Sinir Sistemi Hastalıkları)")
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Pediatri (Çocuk Sağlığı ve Hastalıkları)")
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbBolum.Text == "Plastik, Rekonstüktif ve Estetik Cerrahi")
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
                    MessageBox.Show("Lütfen randevu tipi seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("Lütfen bölüm seçme alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbHastane.Items.Clear();
            if (CmbBolum.Text == "Dahiliye (İç Hastalıkları)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Sarıyer Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Genel Cerrahi")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Kadın Hastalıkları ve Doğum")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Kardiyoloji (Kalp ve Damar Hastalıkları)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Kulak Burun Boğaz (KBB)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Nefroloji")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Tuzla Hastanesi");
            }
            else if (CmbBolum.Text == "Nöroloji (Sinir Sistemi Hastalıkları)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Sarıyer Hastanesi");
            }
            else if (CmbBolum.Text == "Ortopedi ve Travmatoloji")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Sarıyer Hastanesi");
            }
            else if (CmbBolum.Text == "Pediatri (Çocuk Sağlığı ve Hastalıkları)")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Sarıyer Hastanesi");
            }
            else if (CmbBolum.Text == "Psikiyatri")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Sarıyer Hastanesi");
            }
            else if (CmbBolum.Text == "Plastik, Rekonstüktif ve Estetik Cerrahi")
            {
                CmbHastane.Items.Add("Yettipol Bayrampaşa Hastanesi");
                CmbHastane.Items.Add("Yettipol Sarıyer Hastanesi");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            CmbBolum.SelectedIndex = -1;
            CmbHastane.SelectedIndex = -1;
            radGoruntulu.Checked = false;
            radHastane.Checked = false;
        }
    }
}
