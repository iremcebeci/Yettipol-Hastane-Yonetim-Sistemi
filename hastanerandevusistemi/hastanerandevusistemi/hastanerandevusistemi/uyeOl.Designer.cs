namespace hastaneRandevuSistemi
{
    partial class uyeOl
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
            label5 = new Label();
            lblSifre = new Label();
            btnGiris = new Button();
            mskTc = new MaskedTextBox();
            txtSifre = new TextBox();
            txtAdsoyad = new TextBox();
            linkLabel1 = new LinkLabel();
            lblAdsoyad = new Label();
            lblTc = new Label();
            label1 = new Label();
            chcSifregoster = new CheckBox();
            mskTel = new MaskedTextBox();
            label2 = new Label();
            label3 = new Label();
            cmbCinsiyet = new ComboBox();
            label4 = new Label();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtEposta = new TextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F);
            label5.Location = new Point(60, 502);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 25;
            label5.Text = "Hesabın var mı?";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new Font("Microsoft Sans Serif", 12F);
            lblSifre.Location = new Point(60, 347);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(46, 20);
            lblSifre.TabIndex = 24;
            lblSifre.Text = "Şifre:";
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.FromArgb(254, 190, 4);
            btnGiris.Font = new Font("Microsoft Sans Serif", 12F);
            btnGiris.ForeColor = Color.Navy;
            btnGiris.Location = new Point(43, 419);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(227, 58);
            btnGiris.TabIndex = 22;
            btnGiris.Text = "Kayıt Yap";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // mskTc
            // 
            mskTc.Location = new Point(112, 87);
            mskTc.Mask = "00000000000";
            mskTc.Name = "mskTc";
            mskTc.Size = new Size(159, 23);
            mskTc.TabIndex = 21;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(112, 344);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(159, 23);
            txtSifre.TabIndex = 20;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // txtAdsoyad
            // 
            txtAdsoyad.Location = new Point(112, 130);
            txtAdsoyad.Name = "txtAdsoyad";
            txtAdsoyad.Size = new Size(159, 23);
            txtAdsoyad.TabIndex = 19;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            linkLabel1.LinkColor = Color.FromArgb(254, 190, 4);
            linkLabel1.Location = new Point(188, 502);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(74, 20);
            linkLabel1.TabIndex = 17;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Giriş Yap";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lblAdsoyad
            // 
            lblAdsoyad.AutoSize = true;
            lblAdsoyad.Font = new Font("Microsoft Sans Serif", 12F);
            lblAdsoyad.Location = new Point(27, 130);
            lblAdsoyad.Name = "lblAdsoyad";
            lblAdsoyad.Size = new Size(82, 20);
            lblAdsoyad.TabIndex = 16;
            lblAdsoyad.Text = "Ad Soyad:";
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Font = new Font("Microsoft Sans Serif", 12F);
            lblTc.Location = new Point(15, 90);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(94, 20);
            lblTc.TabIndex = 15;
            lblTc.Text = "Tc kimlik no:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(38, 25);
            label1.Name = "label1";
            label1.Size = new Size(214, 32);
            label1.TabIndex = 14;
            label1.Text = "KULLANICI KAYIT";
            // 
            // chcSifregoster
            // 
            chcSifregoster.AutoSize = true;
            chcSifregoster.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            chcSifregoster.Location = new Point(176, 373);
            chcSifregoster.Name = "chcSifregoster";
            chcSifregoster.Size = new Size(95, 19);
            chcSifregoster.TabIndex = 13;
            chcSifregoster.Text = "Şifreyi Göster";
            chcSifregoster.UseVisualStyleBackColor = true;
            chcSifregoster.CheckedChanged += chcSifregoster_CheckedChanged;
            // 
            // mskTel
            // 
            mskTel.Location = new Point(112, 213);
            mskTel.Mask = "(999) 000-0000";
            mskTel.Name = "mskTel";
            mskTel.Size = new Size(159, 23);
            mskTel.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.Location = new Point(43, 216);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 26;
            label2.Text = "Telefon:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F);
            label3.Location = new Point(39, 262);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 28;
            label3.Text = "E-Posta:";
            // 
            // cmbCinsiyet
            // 
            cmbCinsiyet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCinsiyet.FormattingEnabled = true;
            cmbCinsiyet.Items.AddRange(new object[] { "kadın", "erkek" });
            cmbCinsiyet.Location = new Point(112, 170);
            cmbCinsiyet.Name = "cmbCinsiyet";
            cmbCinsiyet.Size = new Size(159, 23);
            cmbCinsiyet.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F);
            label4.Location = new Point(38, 173);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 31;
            label4.Text = "Cinsiyet:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F);
            label6.Location = new Point(6, 305);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 32;
            label6.Text = "Doğum tarihi:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dateTimePicker1.Location = new Point(112, 302);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(159, 23);
            dateTimePicker1.TabIndex = 34;
            dateTimePicker1.Value = new DateTime(2025, 4, 13, 20, 14, 2, 0);
            // 
            // txtEposta
            // 
            txtEposta.Location = new Point(112, 259);
            txtEposta.Name = "txtEposta";
            txtEposta.Size = new Size(159, 23);
            txtEposta.TabIndex = 35;
            // 
            // uyeOl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            Controls.Add(txtEposta);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(cmbCinsiyet);
            Controls.Add(label3);
            Controls.Add(mskTel);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(lblSifre);
            Controls.Add(btnGiris);
            Controls.Add(mskTc);
            Controls.Add(txtSifre);
            Controls.Add(txtAdsoyad);
            Controls.Add(linkLabel1);
            Controls.Add(lblAdsoyad);
            Controls.Add(lblTc);
            Controls.Add(label1);
            Controls.Add(chcSifregoster);
            ForeColor = SystemColors.ButtonFace;
            Name = "uyeOl";
            Size = new Size(300, 561);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label lblSifre;
        private Button btnGiris;
        private MaskedTextBox mskTc;
        private TextBox txtSifre;
        private TextBox txtAdsoyad;
        private LinkLabel linkLabel1;
        private Label lblAdsoyad;
        private Label lblTc;
        private Label label1;
        private CheckBox chcSifregoster;
        private MaskedTextBox mskTel;
        private Label label2;
        private Label label3;
        private ComboBox cmbCinsiyet;
        private Label label4;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private TextBox txtEposta;
    }
}
