namespace hastaneRandevuSistemi
{
    partial class randevugoruntule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(randevugoruntule));
            panel3 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblilk = new Label();
            lblson = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblRandevu = new Label();
            button1 = new Button();
            panel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel3.Controls.Add(flowLayoutPanel2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(button1);
            panel3.ForeColor = SystemColors.ButtonFace;
            panel3.Location = new Point(30, 32);
            panel3.Name = "panel3";
            panel3.Size = new Size(625, 494);
            panel3.TabIndex = 9;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(lblilk);
            flowLayoutPanel2.Controls.Add(lblson);
            flowLayoutPanel2.Location = new Point(197, 443);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(173, 40);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // lblilk
            // 
            lblilk.AutoSize = true;
            lblilk.Location = new Point(13, 10);
            lblilk.Margin = new Padding(13, 10, 3, 0);
            lblilk.Name = "lblilk";
            lblilk.Size = new Size(49, 15);
            lblilk.TabIndex = 6;
            lblilk.Text = "ilk sayfa";
            // 
            // lblson
            // 
            lblson.AutoSize = true;
            lblson.Location = new Point(78, 10);
            lblson.Margin = new Padding(13, 10, 3, 0);
            lblson.Name = "lblson";
            lblson.Size = new Size(56, 15);
            lblson.TabIndex = 5;
            lblson.Text = "son sayfa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(244, 15);
            label1.Name = "label1";
            label1.Size = new Size(185, 32);
            label1.TabIndex = 0;
            label1.Text = "Randevularınız";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(lblRandevu);
            flowLayoutPanel1.Location = new Point(3, 64);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(611, 373);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // lblRandevu
            // 
            lblRandevu.AutoSize = true;
            lblRandevu.BackColor = Color.Transparent;
            lblRandevu.Location = new Point(3, 0);
            lblRandevu.Name = "lblRandevu";
            lblRandevu.Size = new Size(250, 15);
            lblRandevu.TabIndex = 1;
            lblRandevu.Text = "Henüz aktif bir randevunuz bulunmamaktadır.";
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(476, 443);
            button1.Name = "button1";
            button1.Size = new Size(138, 40);
            button1.TabIndex = 2;
            button1.Text = "Yeni Randevu Al";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // randevugoruntule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel3);
            Name = "randevugoruntule";
            Size = new Size(685, 561);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblRandevu;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblilk;
        private Label lblson;
    }
}
