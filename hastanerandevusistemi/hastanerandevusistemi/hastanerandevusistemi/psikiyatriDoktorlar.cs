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
    public partial class psikiyatriDoktorlar : UserControl
    {
        string secim;
        public string bolum = "Psikiyatri";
        public string hastane;
        public string randTipi = "Hastane randevusu";
        public string doktoradi;
        public psikiyatriDoktorlar(string secilenDeger)
        {
            InitializeComponent();
            this.Load += psikiyatriDoktorlar_Load;
            this.secim = secilenDeger;
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        private void psikiyatriDoktorlar_Load(object sender, EventArgs e)
        {

            lblRandevutipi.Text = randTipi;
            lblBolum.Text = bolum;
            lblHastane.Text = hastane;

            if (hastane == "")
            {
                lblHastane.Visible = false;
                ok1.Visible = false;
            }
            if (secim == "Yettipol Bayrampaşa Hastanesi")
            {
                grpSariyer2.Visible = false;
                grpSariyer1.Visible = false;
            }
            else if (secim == "Yettipol Sarıyer Hastanesi")
            {
                grpBayrampasa2.Visible = false;
                grpBayrampasa1.Visible = false;

            }
            else
            {
                grpBayrampasa2.Visible = true;
                grpBayrampasa1.Visible = true;
                grpSariyer2.Visible = true;
                grpSariyer1.Visible = true;
            }
        }

        private void lblHastane_Click(object sender, EventArgs e)
        {
            LoadUserControlIcerik(new pnlicerik());
        }
        private void DoktorButon_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
            {
                MessageBox.Show("Buton null referans içeriyor!");
                return;
            }

            GroupBox parentGroupBox = btn.Parent as GroupBox;

            if (parentGroupBox == null)
            {
                MessageBox.Show("GroupBox bulunamadı!");
                return;
            }

            Label doktorAdiLabel = parentGroupBox.Controls.OfType<Label>().FirstOrDefault();

            if (doktorAdiLabel == null)
            {
                MessageBox.Show("'doktorAdiLabel' bulunamadı! Lütfen Label'ın adı doğru yazıldığından emin olun.");
                return;
            }

            string doktorAdi = doktorAdiLabel.Text;

            randevuSec randevu = new randevuSec(doktorAdi, randTipi, bolum, hastane);
            LoadUserControlIcerik(randevu);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
