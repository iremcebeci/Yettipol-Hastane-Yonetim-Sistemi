namespace hastaneRandevuSistemi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlleft = new Panel();
            linkLabel4 = new LinkLabel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            lblSifre = new Label();
            btnGiris = new Button();
            mskTc = new MaskedTextBox();
            txtSifre = new TextBox();
            txtAdsoyad = new TextBox();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            lblAdsoyad = new Label();
            lblTc = new Label();
            label1 = new Label();
            chcSifregoster = new CheckBox();
            pnlIcerik = new Panel();
            panel1 = new Panel();
            linkLabel3 = new LinkLabel();
            btnTemizle = new Button();
            btnDevam = new Button();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            radGoruntulu = new RadioButton();
            radHastane = new RadioButton();
            CmbHastane = new ComboBox();
            CmbBolum = new ComboBox();
            label2 = new Label();
            pnlleft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlIcerik.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlleft
            // 
            pnlleft.BackColor = Color.FromArgb(44, 62, 80);
            pnlleft.Controls.Add(linkLabel4);
            pnlleft.Controls.Add(pictureBox1);
            pnlleft.Controls.Add(label5);
            pnlleft.Controls.Add(lblSifre);
            pnlleft.Controls.Add(btnGiris);
            pnlleft.Controls.Add(mskTc);
            pnlleft.Controls.Add(txtSifre);
            pnlleft.Controls.Add(txtAdsoyad);
            pnlleft.Controls.Add(linkLabel2);
            pnlleft.Controls.Add(linkLabel1);
            pnlleft.Controls.Add(lblAdsoyad);
            pnlleft.Controls.Add(lblTc);
            pnlleft.Controls.Add(label1);
            pnlleft.Controls.Add(chcSifregoster);
            pnlleft.Dock = DockStyle.Left;
            pnlleft.ForeColor = SystemColors.ButtonFace;
            pnlleft.Location = new Point(0, 0);
            pnlleft.Margin = new Padding(3, 4, 3, 4);
            pnlleft.Name = "pnlleft";
            pnlleft.Size = new Size(300, 561);
            pnlleft.TabIndex = 0;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Cursor = Cursors.Hand;
            linkLabel4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            linkLabel4.LinkColor = Color.White;
            linkLabel4.Location = new Point(176, 227);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(90, 13);
            linkLabel4.TabIndex = 13;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Şifremi unuttum";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(86, 408);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 339);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 12;
            label5.Text = "Hesabın yok mu?";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Location = new Point(77, 179);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(42, 20);
            lblSifre.TabIndex = 11;
            lblSifre.Text = "Şifre:";
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.FromArgb(254, 190, 4);
            btnGiris.Cursor = Cursors.Hand;
            btnGiris.ForeColor = Color.Navy;
            btnGiris.Location = new Point(43, 259);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(227, 58);
            btnGiris.TabIndex = 10;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // mskTc
            // 
            mskTc.Location = new Point(125, 98);
            mskTc.Mask = "00000000000";
            mskTc.Name = "mskTc";
            mskTc.Size = new Size(145, 27);
            mskTc.TabIndex = 9;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(125, 176);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(145, 27);
            txtSifre.TabIndex = 8;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // txtAdsoyad
            // 
            txtAdsoyad.Location = new Point(125, 138);
            txtAdsoyad.Name = "txtAdsoyad";
            txtAdsoyad.Size = new Size(145, 27);
            txtAdsoyad.TabIndex = 7;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Cursor = Cursors.Hand;
            linkLabel2.LinkColor = Color.FromArgb(254, 190, 4);
            linkLabel2.Location = new Point(104, 372);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(121, 20);
            linkLabel2.TabIndex = 6;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Randevu Sorgula\r\n";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.LinkColor = Color.FromArgb(254, 190, 4);
            linkLabel1.Location = new Point(199, 339);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(53, 20);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Üye Ol";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lblAdsoyad
            // 
            lblAdsoyad.AutoSize = true;
            lblAdsoyad.Location = new Point(43, 141);
            lblAdsoyad.Name = "lblAdsoyad";
            lblAdsoyad.Size = new Size(76, 20);
            lblAdsoyad.TabIndex = 4;
            lblAdsoyad.Text = "Ad Soyad:";
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Location = new Point(29, 101);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(90, 20);
            lblTc.TabIndex = 3;
            lblTc.Text = "Tc kimlik no:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(51, 34);
            label1.Name = "label1";
            label1.Size = new Size(208, 32);
            label1.TabIndex = 2;
            label1.Text = "KULLANICI GİRİŞ";
            // 
            // chcSifregoster
            // 
            chcSifregoster.AutoSize = true;
            chcSifregoster.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            chcSifregoster.Location = new Point(175, 209);
            chcSifregoster.Name = "chcSifregoster";
            chcSifregoster.Size = new Size(95, 19);
            chcSifregoster.TabIndex = 1;
            chcSifregoster.Text = "Şifreyi Göster";
            chcSifregoster.UseVisualStyleBackColor = true;
            chcSifregoster.CheckedChanged += chcSifregoster_CheckedChanged;
            // 
            // pnlIcerik
            // 
            pnlIcerik.AutoScroll = true;
            pnlIcerik.BackColor = Color.WhiteSmoke;
            pnlIcerik.BackgroundImage = (Image)resources.GetObject("pnlIcerik.BackgroundImage");
            pnlIcerik.BackgroundImageLayout = ImageLayout.Stretch;
            pnlIcerik.Controls.Add(panel1);
            pnlIcerik.Dock = DockStyle.Right;
            pnlIcerik.Location = new Point(299, 0);
            pnlIcerik.Margin = new Padding(3, 4, 3, 4);
            pnlIcerik.Name = "pnlIcerik";
            pnlIcerik.Size = new Size(685, 561);
            pnlIcerik.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(linkLabel3);
            panel1.Controls.Add(btnTemizle);
            panel1.Controls.Add(btnDevam);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(radGoruntulu);
            panel1.Controls.Add(radHastane);
            panel1.Controls.Add(CmbHastane);
            panel1.Controls.Add(CmbBolum);
            panel1.Controls.Add(label2);
            panel1.ForeColor = SystemColors.ButtonFace;
            panel1.Location = new Point(106, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 458);
            panel1.TabIndex = 1;
            // 
            // linkLabel3
            // 
            linkLabel3.ActiveLinkColor = Color.LightGray;
            linkLabel3.AutoSize = true;
            linkLabel3.BackColor = Color.Transparent;
            linkLabel3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            linkLabel3.LinkColor = Color.WhiteSmoke;
            linkLabel3.Location = new Point(71, 158);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(220, 17);
            linkLabel3.TabIndex = 13;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Hangi bölümden randevu almalıyım?";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.ForeColor = SystemColors.ButtonFace;
            btnTemizle.Location = new Point(197, 396);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(145, 45);
            btnTemizle.TabIndex = 11;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnDevam
            // 
            btnDevam.BackColor = Color.Navy;
            btnDevam.Cursor = Cursors.Hand;
            btnDevam.ForeColor = SystemColors.ButtonFace;
            btnDevam.Location = new Point(348, 396);
            btnDevam.Name = "btnDevam";
            btnDevam.Size = new Size(145, 45);
            btnDevam.TabIndex = 10;
            btnDevam.Text = "Devam et";
            btnDevam.UseVisualStyleBackColor = false;
            btnDevam.Click += btnDevam_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.Location = new Point(71, 83);
            label6.Name = "label6";
            label6.Size = new Size(346, 21);
            label6.TabIndex = 7;
            label6.Text = "Lütfen randevu almak istediğiniz bölümü seçiniz.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(71, 297);
            label4.Name = "label4";
            label4.Size = new Size(340, 20);
            label4.TabIndex = 6;
            label4.Text = "Lütfen randevu almak istediğiniz hastaneyi seçiniz.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(156, 18);
            label3.Name = "label3";
            label3.Size = new Size(206, 30);
            label3.TabIndex = 5;
            label3.Text = "HIZLI RANDEVU AL";
            // 
            // radGoruntulu
            // 
            radGoruntulu.AutoSize = true;
            radGoruntulu.BackColor = Color.Transparent;
            radGoruntulu.Location = new Point(71, 240);
            radGoruntulu.Name = "radGoruntulu";
            radGoruntulu.Size = new Size(225, 24);
            radGoruntulu.TabIndex = 4;
            radGoruntulu.TabStop = true;
            radGoruntulu.Text = "Görüntülü görüşme randevusu";
            radGoruntulu.UseVisualStyleBackColor = false;
            // 
            // radHastane
            // 
            radHastane.AutoSize = true;
            radHastane.BackColor = Color.Transparent;
            radHastane.ForeColor = SystemColors.ButtonFace;
            radHastane.Location = new Point(313, 240);
            radHastane.Name = "radHastane";
            radHastane.Size = new Size(152, 24);
            radHastane.TabIndex = 3;
            radHastane.TabStop = true;
            radHastane.Text = "Hastane randevusu";
            radHastane.UseVisualStyleBackColor = false;
            // 
            // CmbHastane
            // 
            CmbHastane.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbHastane.FormattingEnabled = true;
            CmbHastane.Location = new Point(71, 331);
            CmbHastane.Name = "CmbHastane";
            CmbHastane.Size = new Size(394, 28);
            CmbHastane.TabIndex = 2;
            // 
            // CmbBolum
            // 
            CmbBolum.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbBolum.FormattingEnabled = true;
            CmbBolum.Items.AddRange(new object[] { "Dahiliye (İç Hastalıkları)", "Genel Cerrahi", "Kadın Hastalıkları ve Doğum", "Kardiyoloji (Kalp ve Damar Hastalıkları)", "Kulak Burun Boğaz (KBB)", "Nefroloji", "Nöroloji (Sinir Sistemi Hastalıkları)", "Ortopedi ve Travmatoloji", "Pediatri (Çocuk Sağlığı ve Hastalıkları)", "Psikiyatri", "Plastik, Rekonstüktif ve Estetik Cerrahi" });
            CmbBolum.Location = new Point(71, 118);
            CmbBolum.Name = "CmbBolum";
            CmbBolum.Size = new Size(394, 28);
            CmbBolum.TabIndex = 1;
            CmbBolum.SelectedIndexChanged += CmbBolum_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(71, 207);
            label2.Name = "label2";
            label2.Size = new Size(204, 20);
            label2.TabIndex = 0;
            label2.Text = "Lütfen randevu türünü seçiniz.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(984, 561);
            Controls.Add(pnlIcerik);
            Controls.Add(pnlleft);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1000, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yettipol Hastane Randevu Sistemi ";
            pnlleft.ResumeLayout(false);
            pnlleft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlIcerik.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlleft;
        private Panel pnlIcerik;
        private PictureBox pictureBox1;
        private Button btnGiris;
        private MaskedTextBox mskTc;
        private TextBox txtSifre;
        private TextBox txtAdsoyad;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label lblAdsoyad;
        private Label lblTc;
        private Label label1;
        private CheckBox chcSifregoster;
        private Label lblSifre;
        private Label label5;
        private Panel panel1;
        private Label label6;
        private Label label4;
        private Label label3;
        private ComboBox CmbHastane;
        private ComboBox CmbBolum;
        private Label label2;
        private Button btnDevam;
        private Button btnTemizle;
        private LinkLabel linkLabel3;
        private RadioButton radGoruntulu;
        private RadioButton radHastane;
        private LinkLabel linkLabel4;
    }
}
