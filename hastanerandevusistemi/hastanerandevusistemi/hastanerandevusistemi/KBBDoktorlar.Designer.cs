namespace hastaneRandevuSistemi
{
    partial class KBBDoktorlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KBBDoktorlar));
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblHastane = new Label();
            ok1 = new Label();
            lblBolum = new Label();
            ok2 = new Label();
            lblRandevutipi = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label10 = new Label();
            grpTuzla1 = new GroupBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            grpTuzla2 = new GroupBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            grpBayrampasa1 = new GroupBox();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            button3 = new Button();
            grpBayrampasa2 = new GroupBox();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            button4 = new Button();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            grpTuzla1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpTuzla2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            grpBayrampasa1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            grpBayrampasa2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
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
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(685, 75);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // lblHastane
            // 
            lblHastane.AutoSize = true;
            lblHastane.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHastane.ForeColor = SystemColors.ButtonFace;
            lblHastane.Location = new Point(20, 10);
            lblHastane.Margin = new Padding(20, 10, 0, 0);
            lblHastane.Name = "lblHastane";
            lblHastane.Size = new Size(114, 20);
            lblHastane.TabIndex = 2;
            lblHastane.Text = "Seçilen Hastane";
            lblHastane.Click += lblHastane_Click;
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
            lblBolum.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBolum.ForeColor = SystemColors.ButtonFace;
            lblBolum.Location = new Point(208, 10);
            lblBolum.Margin = new Padding(20, 10, 0, 0);
            lblBolum.Name = "lblBolum";
            lblBolum.Size = new Size(103, 20);
            lblBolum.TabIndex = 0;
            lblBolum.Text = "Seçilen Bölüm";
            lblBolum.Click += lblHastane_Click;
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
            lblRandevutipi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblRandevutipi.ForeColor = SystemColors.ButtonFace;
            lblRandevutipi.Location = new Point(385, 10);
            lblRandevutipi.Margin = new Padding(20, 10, 0, 0);
            lblRandevutipi.Name = "lblRandevutipi";
            lblRandevutipi.Size = new Size(146, 20);
            lblRandevutipi.TabIndex = 4;
            lblRandevutipi.Text = "Seçilen Randevu Tipi";
            lblRandevutipi.Click += lblHastane_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            flowLayoutPanel1.Controls.Add(label10);
            flowLayoutPanel1.Controls.Add(grpTuzla1);
            flowLayoutPanel1.Controls.Add(grpTuzla2);
            flowLayoutPanel1.Controls.Add(grpBayrampasa1);
            flowLayoutPanel1.Controls.Add(grpBayrampasa2);
            flowLayoutPanel1.Location = new Point(57, 99);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(576, 445);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label10.ForeColor = SystemColors.ButtonFace;
            label10.Location = new Point(13, 10);
            label10.Margin = new Padding(13, 10, 130, 20);
            label10.Name = "label10";
            label10.Size = new Size(366, 25);
            label10.TabIndex = 7;
            label10.Text = "Lütfen randevu alacağınız doktoru seçiniz.";
            // 
            // grpTuzla1
            // 
            grpTuzla1.BackColor = Color.White;
            grpTuzla1.Controls.Add(label1);
            grpTuzla1.Controls.Add(pictureBox1);
            grpTuzla1.Controls.Add(button1);
            grpTuzla1.Location = new Point(10, 58);
            grpTuzla1.Margin = new Padding(10, 3, 10, 10);
            grpTuzla1.Name = "grpTuzla1";
            grpTuzla1.Size = new Size(161, 178);
            grpTuzla1.TabIndex = 0;
            grpTuzla1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 2;
            label1.Text = "Dr. Tolga OKANER";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(31, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(31, 138);
            button1.Name = "button1";
            button1.Size = new Size(100, 34);
            button1.TabIndex = 0;
            button1.Text = "Randevu al";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DoktorButon_Click;
            // 
            // grpTuzla2
            // 
            grpTuzla2.BackColor = Color.White;
            grpTuzla2.Controls.Add(label2);
            grpTuzla2.Controls.Add(pictureBox2);
            grpTuzla2.Controls.Add(button2);
            grpTuzla2.Location = new Point(191, 58);
            grpTuzla2.Margin = new Padding(10, 3, 10, 10);
            grpTuzla2.Name = "grpTuzla2";
            grpTuzla2.Size = new Size(161, 178);
            grpTuzla2.TabIndex = 1;
            grpTuzla2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(28, 10);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 2;
            label2.Text = "Dr. Çağla SERT";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(31, 33);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 99);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(31, 138);
            button2.Name = "button2";
            button2.Size = new Size(100, 34);
            button2.TabIndex = 0;
            button2.Text = "Randevu al";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DoktorButon_Click;
            // 
            // grpBayrampasa1
            // 
            grpBayrampasa1.BackColor = Color.White;
            grpBayrampasa1.Controls.Add(label3);
            grpBayrampasa1.Controls.Add(pictureBox3);
            grpBayrampasa1.Controls.Add(button3);
            grpBayrampasa1.Location = new Point(372, 58);
            grpBayrampasa1.Margin = new Padding(10, 3, 10, 10);
            grpBayrampasa1.Name = "grpBayrampasa1";
            grpBayrampasa1.Size = new Size(161, 178);
            grpBayrampasa1.TabIndex = 3;
            grpBayrampasa1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(24, 10);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 2;
            label3.Text = "Dr. Mark SLOAN";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(31, 33);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 99);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(31, 138);
            button3.Name = "button3";
            button3.Size = new Size(100, 34);
            button3.TabIndex = 0;
            button3.Text = "Randevu al";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DoktorButon_Click;
            // 
            // grpBayrampasa2
            // 
            grpBayrampasa2.BackColor = Color.White;
            grpBayrampasa2.Controls.Add(label4);
            grpBayrampasa2.Controls.Add(pictureBox4);
            grpBayrampasa2.Controls.Add(button4);
            grpBayrampasa2.Location = new Point(10, 249);
            grpBayrampasa2.Margin = new Padding(10, 3, 10, 10);
            grpBayrampasa2.Name = "grpBayrampasa2";
            grpBayrampasa2.Size = new Size(161, 178);
            grpBayrampasa2.TabIndex = 4;
            grpBayrampasa2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(30, 10);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 2;
            label4.Text = "Dr. Lexie GREY";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(31, 33);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 99);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(31, 138);
            button4.Name = "button4";
            button4.Size = new Size(100, 34);
            button4.TabIndex = 0;
            button4.Text = "Randevu al";
            button4.UseVisualStyleBackColor = true;
            button4.Click += DoktorButon_Click;
            // 
            // KBBDoktorlar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            Name = "KBBDoktorlar";
            Size = new Size(685, 561);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            grpTuzla1.ResumeLayout(false);
            grpTuzla1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpTuzla2.ResumeLayout(false);
            grpTuzla2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            grpBayrampasa1.ResumeLayout(false);
            grpBayrampasa1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            grpBayrampasa2.ResumeLayout(false);
            grpBayrampasa2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblHastane;
        private Label ok1;
        private Label lblBolum;
        private Label ok2;
        private Label lblRandevutipi;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label10;
        private GroupBox grpTuzla1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button1;
        private GroupBox grpTuzla2;
        private Label label2;
        private PictureBox pictureBox2;
        private Button button2;
        private GroupBox grpBayrampasa1;
        private Label label3;
        private PictureBox pictureBox3;
        private Button button3;
        private GroupBox grpBayrampasa2;
        private Label label4;
        private PictureBox pictureBox4;
        private Button button4;
    }
}
