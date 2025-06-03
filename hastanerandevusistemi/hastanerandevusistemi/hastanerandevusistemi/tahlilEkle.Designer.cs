namespace hastaneRandevuSistemi
{
    partial class tahlilEkle
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
            label5 = new Label();
            label2 = new Label();
            btnTemizle = new Button();
            cmbtahlil = new ComboBox();
            btnKaydet = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(152, 9);
            label5.Name = "label5";
            label5.Size = new Size(122, 32);
            label5.TabIndex = 21;
            label5.Text = "Tahlil İste";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 48);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 18;
            label2.Text = "Tahlil türü:";
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.ForeColor = Color.FromArgb(254, 190, 4);
            btnTemizle.Location = new Point(247, 191);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(68, 31);
            btnTemizle.TabIndex = 17;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // cmbtahlil
            // 
            cmbtahlil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbtahlil.FormattingEnabled = true;
            cmbtahlil.Items.AddRange(new object[] { "Kan Testleri", "İdrar Testleri", "Görüntüleme" });
            cmbtahlil.Location = new Point(53, 66);
            cmbtahlil.Name = "cmbtahlil";
            cmbtahlil.Size = new Size(343, 23);
            cmbtahlil.TabIndex = 12;
            cmbtahlil.SelectedIndexChanged += cmbtahlil_SelectedIndexChanged;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.Navy;
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.ForeColor = Color.FromArgb(254, 190, 4);
            btnKaydet.Location = new Point(321, 191);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 31);
            btnKaydet.TabIndex = 11;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(53, 104);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 22;
            checkBox1.Tag = "checkbox";
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(53, 129);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 23;
            checkBox2.Tag = "checkbox";
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(53, 154);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 19);
            checkBox3.TabIndex = 24;
            checkBox3.Tag = "checkbox";
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(247, 116);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(83, 19);
            checkBox4.TabIndex = 25;
            checkBox4.Tag = "checkbox";
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(247, 141);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(83, 19);
            checkBox5.TabIndex = 26;
            checkBox5.Tag = "checkbox";
            checkBox5.Text = "checkBox5";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // tahlilEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 190, 4);
            ClientSize = new Size(429, 229);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnTemizle);
            Controls.Add(cmbtahlil);
            Controls.Add(btnKaydet);
            FormBorderStyle = FormBorderStyle.None;
            Name = "tahlilEkle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "tahlilEkle";
            Load += tahlilEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label2;
        private Button btnTemizle;
        private ComboBox cmbtahlil;
        private Button btnKaydet;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
    }
}