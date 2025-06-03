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
    public partial class dahiliyeDoktorlar : UserControl
    {
        string secim;
        public string bolum = "Dahiliye (İç Hastalıkları)";
        public string hastane;
        public string randTipi = "Hastane randevusu";
        public string doktoradi;
        public dahiliyeDoktorlar(string secilenDeger)
        {
            InitializeComponent();
            this.Load += dahiliyeDoktorlar_Load;
            this.secim = secilenDeger;
            btnReha.Click += DoktorButon_Click;
            btnVefa.Click += DoktorButon_Click;
            btnNazlı.Click += DoktorButon_Click;
            btnEllis.Click += DoktorButon_Click;
            btnRichard.Click += DoktorButon_Click;
            btnEylem.Click += DoktorButon_Click;
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        private void dahiliyeDoktorlar_Load(object sender, EventArgs e)
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
                grpBayrampasa2.Visible = false;
                grpBayrampasa1.Visible = false;
                grpSariyer2.Visible = false;
                grpSariyer1.Visible = false;

            }
            else if (secim == "Yettipol Bayrampaşa Hastanesi")
            {
                grpTuzla1.Visible = false;
                grpTuzla2.Visible = false;
                grpSariyer2.Visible = false;
                grpSariyer1.Visible = false;
            }
            else if (secim == "Yettipol Sarıyer Hastanesi")
            {
                grpTuzla1.Visible = false;
                grpTuzla2.Visible = false;
                grpBayrampasa2.Visible = false;
                grpBayrampasa1.Visible = false;

            }
            else
            {
                grpBayrampasa2.Visible = true;
                grpBayrampasa1.Visible = true;
                grpSariyer2.Visible = true;
                grpSariyer1.Visible = true;
                grpTuzla1.Visible = true;
                grpTuzla2.Visible = true;
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

    }
}
