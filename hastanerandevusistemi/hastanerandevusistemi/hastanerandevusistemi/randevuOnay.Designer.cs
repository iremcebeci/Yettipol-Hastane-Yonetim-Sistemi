namespace hastaneRandevuSistemi
{
    partial class randevuOnay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(randevuOnay));
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblHastane = new Label();
            ok1 = new Label();
            lblBolum = new Label();
            ok2 = new Label();
            lblRandevutipi = new Label();
            ok3 = new Label();
            lblDoktor = new Label();
            ok4 = new Label();
            lblTarih = new Label();
            ok5 = new Label();
            lblSaat = new Label();
            panel1 = new Panel();
            btnTemizle = new Button();
            label3 = new Label();
            button1 = new Button();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label4 = new Label();
            cmbCinsiyet = new ComboBox();
            mskTel = new MaskedTextBox();
            label2 = new Label();
            mskTc = new MaskedTextBox();
            txtAdsoyad = new TextBox();
            lblAdsoyad = new Label();
            lblTc = new Label();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.FromArgb(44, 62, 80);
            flowLayoutPanel2.Controls.Add(lblHastane);
            flowLayoutPanel2.Controls.Add(ok1);
            flowLayoutPanel2.Controls.Add(lblBolum);
            flowLayoutPanel2.Controls.Add(ok2);
            flowLayoutPanel2.Controls.Add(lblRandevutipi);
            flowLayoutPanel2.Controls.Add(ok3);
            flowLayoutPanel2.Controls.Add(lblDoktor);
            flowLayoutPanel2.Controls.Add(ok4);
            flowLayoutPanel2.Controls.Add(lblTarih);
            flowLayoutPanel2.Controls.Add(ok5);
            flowLayoutPanel2.Controls.Add(lblSaat);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(685, 75);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // lblHastane
            // 
            lblHastane.AutoSize = true;
            lblHastane.Cursor = Cursors.Hand;
            lblHastane.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHastane.ForeColor = SystemColors.ButtonFace;
            lblHastane.Location = new Point(20, 10);
            lblHastane.Margin = new Padding(20, 10, 0, 0);
            lblHastane.Name = "lblHastane";
            lblHastane.Size = new Size(114, 20);
            lblHastane.TabIndex = 2;
            lblHastane.Text = "Seçilen Hastane";
            // 
            // ok1
            // 
            ok1.AutoSize = true;
            ok1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok1.ForeColor = SystemColors.ButtonFace;
            ok1.Location = new Point(154, 10);
            ok1.Margin = new Padding(20, 10, 3, 0);
            ok1.Name = "ok1";
            ok1.Size = new Size(31, 20);
            ok1.TabIndex = 1;
            ok1.Text = "-->";
            // 
            // lblBolum
            // 
            lblBolum.AutoSize = true;
            lblBolum.Cursor = Cursors.Hand;
            lblBolum.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBolum.ForeColor = SystemColors.ButtonFace;
            lblBolum.Location = new Point(208, 10);
            lblBolum.Margin = new Padding(20, 10, 0, 0);
            lblBolum.Name = "lblBolum";
            lblBolum.Size = new Size(103, 20);
            lblBolum.TabIndex = 0;
            lblBolum.Text = "Seçilen Bölüm";
            lblBolum.Click += button1_Click_1;
            // 
            // ok2
            // 
            ok2.AutoSize = true;
            ok2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok2.ForeColor = SystemColors.ButtonFace;
            ok2.Location = new Point(331, 10);
            ok2.Margin = new Padding(20, 10, 3, 0);
            ok2.Name = "ok2";
            ok2.Size = new Size(31, 20);
            ok2.TabIndex = 3;
            ok2.Text = "-->";
            // 
            // lblRandevutipi
            // 
            lblRandevutipi.AutoSize = true;
            lblRandevutipi.Cursor = Cursors.Hand;
            lblRandevutipi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblRandevutipi.ForeColor = SystemColors.ButtonFace;
            lblRandevutipi.Location = new Point(385, 10);
            lblRandevutipi.Margin = new Padding(20, 10, 0, 0);
            lblRandevutipi.Name = "lblRandevutipi";
            lblRandevutipi.Size = new Size(146, 20);
            lblRandevutipi.TabIndex = 4;
            lblRandevutipi.Text = "Seçilen Randevu Tipi";
            lblRandevutipi.Click += button1_Click_1;
            // 
            // ok3
            // 
            ok3.AutoSize = true;
            ok3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok3.ForeColor = SystemColors.ButtonFace;
            ok3.Location = new Point(551, 10);
            ok3.Margin = new Padding(20, 10, 3, 0);
            ok3.Name = "ok3";
            ok3.Size = new Size(31, 20);
            ok3.TabIndex = 5;
            ok3.Text = "-->";
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDoktor.ForeColor = SystemColors.ButtonFace;
            lblDoktor.Location = new Point(20, 40);
            lblDoktor.Margin = new Padding(20, 10, 0, 0);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(106, 20);
            lblDoktor.TabIndex = 6;
            lblDoktor.Text = "Seçilen Doktor";
            lblDoktor.Click += button1_Click_1;
            // 
            // ok4
            // 
            ok4.AutoSize = true;
            ok4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok4.ForeColor = SystemColors.ButtonFace;
            ok4.Location = new Point(146, 40);
            ok4.Margin = new Padding(20, 10, 3, 0);
            ok4.Name = "ok4";
            ok4.Size = new Size(31, 20);
            ok4.TabIndex = 8;
            ok4.Text = "-->";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTarih.ForeColor = SystemColors.ButtonFace;
            lblTarih.Location = new Point(200, 40);
            lblTarih.Margin = new Padding(20, 10, 0, 0);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(91, 20);
            lblTarih.TabIndex = 7;
            lblTarih.Text = "Seçilen Tarih";
            // 
            // ok5
            // 
            ok5.AutoSize = true;
            ok5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok5.ForeColor = SystemColors.ButtonFace;
            ok5.Location = new Point(311, 40);
            ok5.Margin = new Padding(20, 10, 3, 0);
            ok5.Name = "ok5";
            ok5.Size = new Size(31, 20);
            ok5.TabIndex = 9;
            ok5.Text = "-->";
            // 
            // lblSaat
            // 
            lblSaat.AutoSize = true;
            lblSaat.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSaat.ForeColor = SystemColors.ButtonFace;
            lblSaat.Location = new Point(365, 40);
            lblSaat.Margin = new Padding(20, 10, 0, 0);
            lblSaat.Name = "lblSaat";
            lblSaat.Size = new Size(87, 20);
            lblSaat.TabIndex = 10;
            lblSaat.Text = "Seçilen saat";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel1.Controls.Add(btnTemizle);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbCinsiyet);
            panel1.Controls.Add(mskTel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(mskTc);
            panel1.Controls.Add(txtAdsoyad);
            panel1.Controls.Add(lblAdsoyad);
            panel1.Controls.Add(lblTc);
            panel1.Location = new Point(89, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 417);
            panel1.TabIndex = 8;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.ForeColor = SystemColors.ButtonFace;
            btnTemizle.Location = new Point(233, 358);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(145, 45);
            btnTemizle.TabIndex = 45;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(145, 23);
            label3.Name = "label3";
            label3.Size = new Size(228, 37);
            label3.TabIndex = 44;
            label3.Text = "RANDEVU ONAY";
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(384, 358);
            button1.Name = "button1";
            button1.Size = new Size(144, 45);
            button1.TabIndex = 43;
            button1.Text = "Devam et";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(33, 74);
            label1.Name = "label1";
            label1.Size = new Size(460, 21);
            label1.TabIndex = 42;
            label1.Text = "Lütfen randevunuzun onaylanabilmesi için gerekli bilgileri giriniz.";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dateTimePicker1.Location = new Point(191, 247);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(159, 23);
            dateTimePicker1.TabIndex = 41;
            dateTimePicker1.Value = new DateTime(2025, 5, 14, 21, 57, 53, 0);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(38, 247);
            label6.Name = "label6";
            label6.Size = new Size(121, 24);
            label6.TabIndex = 40;
            label6.Text = "Doğum tarihi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(73, 203);
            label4.Name = "label4";
            label4.Size = new Size(80, 24);
            label4.TabIndex = 39;
            label4.Text = "Cinsiyet:";
            // 
            // cmbCinsiyet
            // 
            cmbCinsiyet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCinsiyet.FormattingEnabled = true;
            cmbCinsiyet.Items.AddRange(new object[] { "kadın", "erkek" });
            cmbCinsiyet.Location = new Point(190, 203);
            cmbCinsiyet.Name = "cmbCinsiyet";
            cmbCinsiyet.Size = new Size(159, 23);
            cmbCinsiyet.TabIndex = 38;
            // 
            // mskTel
            // 
            mskTel.Location = new Point(191, 290);
            mskTel.Mask = "(999) 000-0000";
            mskTel.Name = "mskTel";
            mskTel.Size = new Size(159, 23);
            mskTel.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(80, 290);
            label2.Name = "label2";
            label2.Size = new Size(79, 24);
            label2.TabIndex = 36;
            label2.Text = "Telefon:";
            // 
            // mskTc
            // 
            mskTc.Location = new Point(191, 115);
            mskTc.Mask = "00000000000";
            mskTc.Name = "mskTc";
            mskTc.Size = new Size(159, 23);
            mskTc.TabIndex = 35;
            // 
            // txtAdsoyad
            // 
            txtAdsoyad.Location = new Point(191, 158);
            txtAdsoyad.Name = "txtAdsoyad";
            txtAdsoyad.Size = new Size(159, 23);
            txtAdsoyad.TabIndex = 34;
            // 
            // lblAdsoyad
            // 
            lblAdsoyad.AutoSize = true;
            lblAdsoyad.BackColor = Color.Transparent;
            lblAdsoyad.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblAdsoyad.ForeColor = SystemColors.ButtonFace;
            lblAdsoyad.Location = new Point(62, 157);
            lblAdsoyad.Name = "lblAdsoyad";
            lblAdsoyad.Size = new Size(97, 24);
            lblAdsoyad.TabIndex = 33;
            lblAdsoyad.Text = "Ad Soyad:";
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.BackColor = Color.Transparent;
            lblTc.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblTc.ForeColor = SystemColors.ButtonFace;
            lblTc.Location = new Point(44, 115);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(115, 24);
            lblTc.TabIndex = 32;
            lblTc.Text = "Tc kimlik no:";
            // 
            // randevuOnay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel2);
            Name = "randevuOnay";
            Size = new Size(685, 561);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblHastane;
        private Label ok1;
        private Label lblBolum;
        private Label ok2;
        private Label lblRandevutipi;
        private Label ok3;
        private Label lblDoktor;
        private Label ok4;
        private Label lblTarih;
        private Label ok5;
        private Label lblSaat;
        private Panel panel1;
        private Label label4;
        private ComboBox cmbCinsiyet;
        private MaskedTextBox mskTel;
        private Label label2;
        private MaskedTextBox mskTc;
        private TextBox txtAdsoyad;
        private Label lblAdsoyad;
        private Label lblTc;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Label label1;
        private Button button1;
        private Label label3;
        private Button btnTemizle;
    }
}
