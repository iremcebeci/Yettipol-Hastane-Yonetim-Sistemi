using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class receteEkle : Form
    {
        string tcno;
        int doktorID;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        public receteEkle(string tc, int doktorId)
        {
            InitializeComponent();
            this.tcno = tc;
            this.doktorID = doktorId;
        }

        private void receteEkle_Load(object sender, EventArgs e)
        {
            RoundFormCorners(this, 20);
            var btnKapat = new Button()
            {
                Text = "X",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(this.Width - 35, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += BtnKapat_Click;
            this.Controls.Add(btnKapat);
        }
        private void RoundFormCorners(Form form, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(form.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(form.Width - radius, form.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, form.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            form.Region = new Region(path);
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ilac = txtIlacadi.Text.Trim();
            string dozaj = cmbDoz.Text.Trim();
            string siklik = cmbSıklık.Text.Trim();
            string aciklama = rtxtAciklama.Text.Trim();

            if (string.IsNullOrEmpty(ilac) || string.IsNullOrEmpty(dozaj) || string.IsNullOrEmpty(siklik))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO receteler (tc_no, doktor_id, ilac_adi, dozaj, kullanim_sikligi, aciklama) VALUES (@tc, @doktor, @ilac, @dozaj, @siklik, @aciklama)", conn);
            cmd.Parameters.AddWithValue("@tc", tcno);
            cmd.Parameters.AddWithValue("@doktor", doktorID);
            cmd.Parameters.AddWithValue("@ilac", ilac);
            cmd.Parameters.AddWithValue("@dozaj", dozaj);
            cmd.Parameters.AddWithValue("@siklik", siklik);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);

            cmd.ExecuteNonQuery();
            conn.Close();

            DialogResult sonuc = MessageBox.Show("Reçete başarıyla kaydedildi. Yeni veri eklemek istiyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (sonuc == DialogResult.Yes)
            {
                txtIlacadi.Text = "";
                cmbDoz.SelectedIndex = -1;
                cmbSıklık.SelectedIndex = -1;
                rtxtAciklama.Text = "";
            }
            else
            {
                this.Close();
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtIlacadi.Text = "";
            cmbDoz.SelectedIndex = -1;
            cmbSıklık.SelectedIndex = -1;
            rtxtAciklama.Text = "";

        }
    }
}
