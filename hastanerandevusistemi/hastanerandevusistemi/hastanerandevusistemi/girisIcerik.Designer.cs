namespace hastaneRandevuSistemi
{
    partial class girisIcerik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(girisIcerik));
            panel4 = new Panel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label4 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblRandevu = new Label();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label5 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label6 = new Label();
            label3 = new Label();
            panel4.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel4.Controls.Add(flowLayoutPanel4);
            panel4.Controls.Add(label7);
            panel4.ForeColor = SystemColors.ButtonFace;
            panel4.Location = new Point(416, 22);
            panel4.Name = "panel4";
            panel4.Size = new Size(255, 236);
            panel4.TabIndex = 10;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.Transparent;
            flowLayoutPanel4.Controls.Add(label4);
            flowLayoutPanel4.Location = new Point(10, 36);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(243, 182);
            flowLayoutPanel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.AppWorkspace;
            label4.Location = new Point(15, 75);
            label4.Margin = new Padding(15, 75, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(224, 13);
            label4.TabIndex = 2;
            label4.Text = "Sistemimizde tahlil bilginiz bulunmamaktadır.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(10, 12);
            label7.Name = "label7";
            label7.Size = new Size(100, 21);
            label7.TabIndex = 1;
            label7.Text = "Tahlilleriniz";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.ForeColor = SystemColors.ButtonFace;
            panel3.Location = new Point(13, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(397, 236);
            panel3.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(6, 10);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 0;
            label1.Text = "Randevularınız";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(lblRandevu);
            flowLayoutPanel1.Location = new Point(3, 37);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(391, 160);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // lblRandevu
            // 
            lblRandevu.AutoSize = true;
            lblRandevu.BackColor = Color.Transparent;
            lblRandevu.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 162);
            lblRandevu.ForeColor = SystemColors.AppWorkspace;
            lblRandevu.Location = new Point(70, 75);
            lblRandevu.Margin = new Padding(70, 75, 3, 0);
            lblRandevu.Name = "lblRandevu";
            lblRandevu.Size = new Size(225, 13);
            lblRandevu.TabIndex = 1;
            lblRandevu.Text = "Henüz aktif bir randevunuz bulunmamaktadır.";
            // 
            // button2
            // 
            button2.BackColor = Color.Navy;
            button2.Cursor = Cursors.Hand;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(144, 201);
            button2.Name = "button2";
            button2.Size = new Size(151, 32);
            button2.TabIndex = 3;
            button2.Text = "Tüm randevuları göster";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(301, 201);
            button1.Name = "button1";
            button1.Size = new Size(93, 32);
            button1.TabIndex = 2;
            button1.Text = "Randevu al";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(label2);
            panel2.ForeColor = SystemColors.ButtonFace;
            panel2.Location = new Point(13, 273);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 266);
            panel2.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Location = new Point(6, 42);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(370, 204);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.AppWorkspace;
            label5.Location = new Point(70, 90);
            label5.Margin = new Padding(70, 90, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(236, 13);
            label5.TabIndex = 2;
            label5.Text = "Sistemimizde hastalık bilginiz bulunmamaktadır.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(6, 12);
            label2.Name = "label2";
            label2.Size = new Size(120, 21);
            label2.TabIndex = 1;
            label2.Text = "Hastalıklarınız";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel1.Controls.Add(flowLayoutPanel3);
            panel1.Controls.Add(label3);
            panel1.ForeColor = SystemColors.ButtonFace;
            panel1.Location = new Point(416, 273);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 266);
            panel1.TabIndex = 7;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Transparent;
            flowLayoutPanel3.Controls.Add(label6);
            flowLayoutPanel3.Location = new Point(10, 42);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(239, 204);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label6.ForeColor = SystemColors.AppWorkspace;
            label6.Location = new Point(15, 90);
            label6.Margin = new Padding(15, 90, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(216, 13);
            label6.TabIndex = 2;
            label6.Text = "Sistemimizde ilaç bilginiz bulunmamaktadır.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(10, 12);
            label3.Name = "label3";
            label3.Size = new Size(85, 21);
            label3.TabIndex = 1;
            label3.Text = "İlaçlarınız";
            // 
            // girisIcerik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "girisIcerik";
            Size = new Size(685, 561);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label4;
        private Label label7;
        private Panel panel3;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblRandevu;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label5;
        private Label label2;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label6;
        private Label label3;
    }
}
