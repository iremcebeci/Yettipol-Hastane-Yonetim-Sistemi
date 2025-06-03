namespace hastaneRandevuSistemi
{
    partial class pnlleft
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pnlleft));
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(87, 407);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(78, 334);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 25;
            label5.Text = "Hesabın yok mu?";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new Font("Segoe UI", 11.25F);
            lblSifre.Location = new Point(78, 178);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(42, 20);
            lblSifre.TabIndex = 24;
            lblSifre.Text = "Şifre:";
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.FromArgb(254, 190, 4);
            btnGiris.Cursor = Cursors.Hand;
            btnGiris.Font = new Font("Segoe UI", 11.25F);
            btnGiris.ForeColor = Color.Navy;
            btnGiris.Location = new Point(44, 256);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(227, 58);
            btnGiris.TabIndex = 22;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // mskTc
            // 
            mskTc.Location = new Point(126, 97);
            mskTc.Mask = "00000000000";
            mskTc.Name = "mskTc";
            mskTc.Size = new Size(145, 23);
            mskTc.TabIndex = 21;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(126, 175);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(145, 23);
            txtSifre.TabIndex = 20;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // txtAdsoyad
            // 
            txtAdsoyad.Location = new Point(126, 137);
            txtAdsoyad.Name = "txtAdsoyad";
            txtAdsoyad.Size = new Size(145, 23);
            txtAdsoyad.TabIndex = 19;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Cursor = Cursors.Hand;
            linkLabel2.Font = new Font("Segoe UI", 11.25F);
            linkLabel2.LinkColor = Color.FromArgb(254, 190, 4);
            linkLabel2.Location = new Point(111, 367);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(121, 20);
            linkLabel2.TabIndex = 18;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Randevu Sorgula";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.Font = new Font("Segoe UI", 11.25F);
            linkLabel1.LinkColor = Color.FromArgb(254, 190, 4);
            linkLabel1.Location = new Point(206, 334);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(53, 20);
            linkLabel1.TabIndex = 17;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Üye Ol";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lblAdsoyad
            // 
            lblAdsoyad.AutoSize = true;
            lblAdsoyad.Font = new Font("Segoe UI", 11.25F);
            lblAdsoyad.Location = new Point(44, 140);
            lblAdsoyad.Name = "lblAdsoyad";
            lblAdsoyad.Size = new Size(76, 20);
            lblAdsoyad.TabIndex = 16;
            lblAdsoyad.Text = "Ad Soyad:";
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Font = new Font("Segoe UI", 11.25F);
            lblTc.Location = new Point(30, 100);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(90, 20);
            lblTc.TabIndex = 15;
            lblTc.Text = "Tc kimlik no:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(63, 36);
            label1.Name = "label1";
            label1.Size = new Size(208, 32);
            label1.TabIndex = 14;
            label1.Text = "KULLANICI GİRİŞ";
            // 
            // chcSifregoster
            // 
            chcSifregoster.AutoSize = true;
            chcSifregoster.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            chcSifregoster.Location = new Point(176, 208);
            chcSifregoster.Name = "chcSifregoster";
            chcSifregoster.Size = new Size(95, 19);
            chcSifregoster.TabIndex = 13;
            chcSifregoster.Text = "Şifreyi Göster";
            chcSifregoster.UseVisualStyleBackColor = true;
            chcSifregoster.CheckedChanged += chcSifregoster_CheckedChanged;
            // 
            // pnlleft
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(lblSifre);
            Controls.Add(btnGiris);
            Controls.Add(mskTc);
            Controls.Add(txtSifre);
            Controls.Add(txtAdsoyad);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(lblAdsoyad);
            Controls.Add(lblTc);
            Controls.Add(label1);
            Controls.Add(chcSifregoster);
            ForeColor = SystemColors.ButtonFace;
            Name = "pnlleft";
            Size = new Size(300, 561);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label5;
        private Label lblSifre;
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
    }
}
