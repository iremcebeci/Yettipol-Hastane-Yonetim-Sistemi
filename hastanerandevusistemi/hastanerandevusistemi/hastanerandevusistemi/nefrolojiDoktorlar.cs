using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastaneRandevuSistemi
{
    public partial class nefrolojiDoktorlar : UserControl
    {
        string secim;
        public string bolum = "Nefroloji";
        public string hastane;
        public string randTipi = "Hastane randevusu";
        public string doktoradi;
        public nefrolojiDoktorlar(string secilenDeger)
        {
            InitializeComponent();
            this.Load += nefrolojiDoktorlar_Load;
            this.secim = secilenDeger;
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        private void nefrolojiDoktorlar_Load(object sender, EventArgs e)
        {

            lblRandevutipi.Text = randTipi;
            lblBolum.Text = bolum;
            lblHastane.Text = hastane;

            if (hastane == "")
            {
                lblHastane.Visible = false;
                ok1.Visible = false;
            }

            if (secim == "Yettipol Tuzla Hastanesi")
            {
                grpBayrampasa1.Visible = false;
                grpBayrampasa2.Visible = false;
            }
            else if (secim == "Yettipol Bayrampaşa Hastanesi")
            {
                grpTuzla1.Visible = false;
                grpTuzla2.Visible = false;
                grpTuzla3.Visible = false;
            }
            else
            {
                grpTuzla1.Visible = true;
                grpTuzla2.Visible = true;
                grpTuzla3.Visible = true;
                grpBayrampasa1.Visible = true;
                grpBayrampasa2.Visible = true;
            }
        }

        private void lblHastane_Click_1(object sender, EventArgs e)
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
    }
}
