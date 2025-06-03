using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore.V1;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class tahlilEkle : Form
    {
        string tcno;
        int doktorID;
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        public tahlilEkle(string tc, int doktorid)
        {
            InitializeComponent();
            tcno = tc;
            doktorID = doktorid;
        }

        private void tahlilEkle_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "checkbox")
                {
                    ctrl.Visible = false;
                }
            }
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
        private void cmbtahlil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtahlil.Text == "Kan Testleri")
            {
                checkBox1.Text = "Hemogram (Tam Kan Sayımı)";
                checkBox2.Text = "Biyokimya";
                checkBox3.Text = "Vitamin Testi";
                checkBox4.Text = "Hormon Testi";
                checkBox5.Text = "Kan Şekeri";
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
            }
            else if (cmbtahlil.Text == "İdrar Testleri")
            {
                checkBox1.Text = "Tam İdrar Tahlili";
                checkBox2.Text = "İdrar Kültürü";
                checkBox3.Text = "24 Saatlik İdrar";
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
            }
            else if (cmbtahlil.Text == "Görüntüleme")
            {
                checkBox1.Text = "Röntgen";
                checkBox2.Text = "BT";
                checkBox3.Text = "MR";
                checkBox4.Text = "Ultrason";
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = false;
            }
            else
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "checkbox")
                    {
                        ctrl.Visible = false;
                    }
                }
            }

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string kategori = cmbtahlil.Text.Split(' ')[0].Trim();

            if (string.IsNullOrEmpty(kategori))
            {
                MessageBox.Show("Lütfen tahlil kategorisi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> secilenTahliller = new List<string>();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox cb && cb.Visible && cb.Checked)
                {
                    secilenTahliller.Add(cb.Text);
                }
            }

            if (secilenTahliller.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir tahlil seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                foreach (string tahlilTuru in secilenTahliller)
                {
                    int teknisyenId = GetUygunTeknisyen(tcno, kategori, conn);
                    if (teknisyenId == -1)
                    {
                        MessageBox.Show($"{tahlilTuru} için uygun teknisyen bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    var cmd = new MySqlCommand("INSERT INTO tahliller (isteyen_doktor, tc_no, teknisyen_id, tahlil_kategori, tahlil_turu) VALUES (@doktor, @tc, @tek, @kat, @tur)", conn);
                    cmd.Parameters.AddWithValue("@doktor", doktorID);
                    cmd.Parameters.AddWithValue("@tc", tcno);
                    cmd.Parameters.AddWithValue("@tek", teknisyenId);
                    cmd.Parameters.AddWithValue("@kat", kategori.ToLower());
                    cmd.Parameters.AddWithValue("@tur", tahlilTuru);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            MessageBox.Show(kategori);
            MessageBox.Show("Tahliller başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmbtahlil.SelectedIndex = -1;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    cb.Visible = false;
                    cb.Checked = false;
                }
            }
        }

        private int GetUygunTeknisyen(string hastaTc, string kategori, MySqlConnection conn)
        {
            int teknisyenId = -1;
            string bugun = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("tr-TR"));

            var check = new MySqlCommand("SELECT teknisyen_id FROM tahliller WHERE tc_no = @tc AND tahlil_kategori = @kat LIMIT 1", conn);
            check.Parameters.AddWithValue("@tc", hastaTc);
            check.Parameters.AddWithValue("@kat", kategori.ToLower());
            var onceki = check.ExecuteScalar();
            if (onceki != null)
                return Convert.ToInt32(onceki);


            var hastaneCmd = new MySqlCommand("SELECT hastane_id FROM doktorlar WHERE doktor_id = @doktor", conn);
            hastaneCmd.Parameters.AddWithValue("@doktor", doktorID);
            var hastaneId = hastaneCmd.ExecuteScalar()?.ToString();
            if (string.IsNullOrEmpty(hastaneId)) return -1;

            var tekCmd = new MySqlCommand(@"SELECT teknisyen_id FROM teknisyenler 
            WHERE tek_tur = @kat AND izin_gunu != @bugun AND hastane_id = @hastane 
            ORDER BY RAND() LIMIT 1", conn);

            tekCmd.Parameters.AddWithValue("@kat", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(kategori));
            tekCmd.Parameters.AddWithValue("@bugun", bugun);
            tekCmd.Parameters.AddWithValue("@hastane", hastaneId);
            var result = tekCmd.ExecuteScalar();


            if (result != null)
                teknisyenId = Convert.ToInt32(result);

            return teknisyenId;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmbtahlil.SelectedIndex = -1;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    cb.Visible = false;
                    cb.Checked = false;
                }
            }
        }
    }
}
