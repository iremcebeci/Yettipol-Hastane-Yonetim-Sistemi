namespace hastaneRandevuSistemi
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            pnlIcerik = new Panel();
            pnlBugun = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblilk = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblRandevu = new Label();
            pnlleft = new Panel();
            btnAnasayfa = new Button();
            lblbolum = new Label();
            lblHastane = new Label();
            btnGelecekrand = new Button();
            label5 = new Label();
            label4 = new Label();
            btnGecmisrand = new Button();
            labelAdsoyad = new Label();
            lbltc = new Label();
            btnCikis = new Button();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            pnlIcerik.SuspendLayout();
            pnlBugun.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlleft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pnlIcerik
            // 
            pnlIcerik.BackgroundImage = (Image)resources.GetObject("pnlIcerik.BackgroundImage");
            pnlIcerik.BackgroundImageLayout = ImageLayout.Stretch;
            pnlIcerik.Controls.Add(pnlBugun);
            pnlIcerik.Dock = DockStyle.Right;
            pnlIcerik.Location = new Point(299, 0);
            pnlIcerik.Name = "pnlIcerik";
            pnlIcerik.Size = new Size(685, 561);
            pnlIcerik.TabIndex = 3;
            // 
            // pnlBugun
            // 
            pnlBugun.BackColor = Color.FromArgb(200, 0, 0, 0);
            pnlBugun.Controls.Add(flowLayoutPanel2);
            pnlBugun.Controls.Add(label1);
            pnlBugun.Controls.Add(flowLayoutPanel1);
            pnlBugun.ForeColor = SystemColors.ButtonFace;
            pnlBugun.Location = new Point(25, 35);
            pnlBugun.Name = "pnlBugun";
            pnlBugun.Size = new Size(648, 483);
            pnlBugun.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(lblilk);
            flowLayoutPanel2.Location = new Point(286, 442);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(64, 32);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // lblilk
            // 
            lblilk.AutoSize = true;
            lblilk.Location = new Point(13, 10);
            lblilk.Margin = new Padding(13, 10, 3, 0);
            lblilk.Name = "lblilk";
            lblilk.Size = new Size(13, 15);
            lblilk.TabIndex = 6;
            lblilk.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(188, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 32);
            label1.TabIndex = 0;
            label1.Text = "Üzerinize Atanan Tahliller";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(lblRandevu);
            flowLayoutPanel1.Location = new Point(14, 44);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(620, 374);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // lblRandevu
            // 
            lblRandevu.AutoSize = true;
            lblRandevu.BackColor = Color.Transparent;
            lblRandevu.Location = new Point(3, 0);
            lblRandevu.Name = "lblRandevu";
            lblRandevu.Size = new Size(231, 15);
            lblRandevu.TabIndex = 1;
            lblRandevu.Text = "Henüz aktif bir randevu bulunmamaktadır.";
            // 
            // pnlleft
            // 
            pnlleft.BackColor = Color.FromArgb(44, 62, 80);
            pnlleft.Controls.Add(btnAnasayfa);
            pnlleft.Controls.Add(lblbolum);
            pnlleft.Controls.Add(lblHastane);
            pnlleft.Controls.Add(btnGelecekrand);
            pnlleft.Controls.Add(label5);
            pnlleft.Controls.Add(label4);
            pnlleft.Controls.Add(btnGecmisrand);
            pnlleft.Controls.Add(labelAdsoyad);
            pnlleft.Controls.Add(lbltc);
            pnlleft.Controls.Add(btnCikis);
            pnlleft.Controls.Add(label9);
            pnlleft.Controls.Add(pictureBox2);
            pnlleft.Dock = DockStyle.Left;
            pnlleft.Location = new Point(0, 0);
            pnlleft.Name = "pnlleft";
            pnlleft.Size = new Size(300, 561);
            pnlleft.TabIndex = 2;
            // 
            // btnAnasayfa
            // 
            btnAnasayfa.BackColor = Color.FromArgb(254, 190, 4);
            btnAnasayfa.Cursor = Cursors.Hand;
            btnAnasayfa.Font = new Font("Microsoft Sans Serif", 12F);
            btnAnasayfa.ForeColor = Color.Navy;
            btnAnasayfa.Location = new Point(-9, 340);
            btnAnasayfa.Name = "btnAnasayfa";
            btnAnasayfa.Size = new Size(309, 58);
            btnAnasayfa.TabIndex = 57;
            btnAnasayfa.Text = "Anasayfa";
            btnAnasayfa.UseVisualStyleBackColor = false;
            // 
            // lblbolum
            // 
            lblbolum.AutoSize = true;
            lblbolum.Font = new Font("Segoe UI", 9.75F);
            lblbolum.ForeColor = SystemColors.ButtonFace;
            lblbolum.Location = new Point(104, 298);
            lblbolum.MaximumSize = new Size(163, 115);
            lblbolum.Name = "lblbolum";
            lblbolum.Size = new Size(70, 17);
            lblbolum.TabIndex = 56;
            lblbolum.Text = "TC gelecek";
            // 
            // lblHastane
            // 
            lblHastane.AutoSize = true;
            lblHastane.Font = new Font("Segoe UI", 9.75F);
            lblHastane.ForeColor = SystemColors.ButtonFace;
            lblHastane.Location = new Point(104, 263);
            lblHastane.MaximumSize = new Size(163, 115);
            lblHastane.Name = "lblHastane";
            lblHastane.Size = new Size(70, 17);
            lblHastane.TabIndex = 55;
            lblHastane.Text = "TC gelecek";
            // 
            // btnGelecekrand
            // 
            btnGelecekrand.BackColor = Color.FromArgb(254, 190, 4);
            btnGelecekrand.Cursor = Cursors.Hand;
            btnGelecekrand.Font = new Font("Microsoft Sans Serif", 12F);
            btnGelecekrand.ForeColor = Color.Navy;
            btnGelecekrand.Location = new Point(-9, 451);
            btnGelecekrand.Name = "btnGelecekrand";
            btnGelecekrand.Size = new Size(309, 58);
            btnGelecekrand.TabIndex = 54;
            btnGelecekrand.Text = "Girilecek Sonuçlar";
            btnGelecekrand.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(25, 260);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 53;
            label5.Text = "Hastane:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(43, 296);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 52;
            label4.Text = "Bölüm:";
            // 
            // btnGecmisrand
            // 
            btnGecmisrand.BackColor = Color.FromArgb(254, 190, 4);
            btnGecmisrand.Cursor = Cursors.Hand;
            btnGecmisrand.Font = new Font("Microsoft Sans Serif", 12F);
            btnGecmisrand.ForeColor = Color.Navy;
            btnGecmisrand.Location = new Point(-9, 395);
            btnGecmisrand.Name = "btnGecmisrand";
            btnGecmisrand.Size = new Size(309, 58);
            btnGecmisrand.TabIndex = 47;
            btnGecmisrand.Text = "Girilen Sonuçlar";
            btnGecmisrand.UseVisualStyleBackColor = false;
            btnGecmisrand.Click += btnGecmisrand_Click;
            // 
            // labelAdsoyad
            // 
            labelAdsoyad.AutoSize = true;
            labelAdsoyad.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelAdsoyad.ForeColor = SystemColors.ButtonFace;
            labelAdsoyad.Location = new Point(71, 172);
            labelAdsoyad.Name = "labelAdsoyad";
            labelAdsoyad.Size = new Size(189, 30);
            labelAdsoyad.TabIndex = 44;
            labelAdsoyad.Text = "Ad Soyad Gelecek";
            // 
            // lbltc
            // 
            lbltc.AutoSize = true;
            lbltc.Font = new Font("Segoe UI", 9.75F);
            lbltc.ForeColor = SystemColors.ButtonFace;
            lbltc.Location = new Point(104, 229);
            lbltc.Name = "lbltc";
            lbltc.Size = new Size(70, 17);
            lbltc.TabIndex = 43;
            lbltc.Text = "TC gelecek";
            // 
            // btnCikis
            // 
            btnCikis.BackColor = Color.FromArgb(254, 190, 4);
            btnCikis.Cursor = Cursors.Hand;
            btnCikis.Font = new Font("Microsoft Sans Serif", 12F);
            btnCikis.ForeColor = Color.Navy;
            btnCikis.Location = new Point(-9, 503);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(309, 58);
            btnCikis.TabIndex = 42;
            btnCikis.Text = "Çıkış Yap";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(0, 227);
            label9.Name = "label9";
            label9.Size = new Size(107, 20);
            label9.TabIndex = 41;
            label9.Text = "Tc kimlik no:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(85, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(141, 133);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 39;
            pictureBox2.TabStop = false;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(984, 561);
            Controls.Add(pnlIcerik);
            Controls.Add(pnlleft);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form4";
            Text = "Form4";
            FormClosing += Form4_FormClosing;
            Load += Form4_Load;
            pnlIcerik.ResumeLayout(false);
            pnlBugun.ResumeLayout(false);
            pnlBugun.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlleft.ResumeLayout(false);
            pnlleft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIcerik;
        private Panel pnlBugun;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblilk;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblRandevu;
        private Panel pnlleft;
        private Button btnAnasayfa;
        private Label lblbolum;
        private Label lblHastane;
        private Label label5;
        private Label label4;
        private Label labelAdsoyad;
        private Label lbltc;
        private Button btnCikis;
        private Label label9;
        private PictureBox pictureBox2;
        private Button btnGelecekrand;
        private Button btnGecmisrand;
    }
}