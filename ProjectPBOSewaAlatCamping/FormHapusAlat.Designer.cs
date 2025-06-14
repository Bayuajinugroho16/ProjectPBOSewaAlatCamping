namespace ProjectPBOSewaAlatCamping
{
    partial class FormHapusAlat
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
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            buttonSelesai = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.editproduk__3_1;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1149, 733);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(605, 239);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(424, 338);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // buttonSelesai
            // 
            buttonSelesai.Image = Properties.Resources.Screenshot_2025_05_26_141637;
            buttonSelesai.Location = new Point(551, 515);
            buttonSelesai.Name = "buttonSelesai";
            buttonSelesai.Size = new Size(58, 19);
            buttonSelesai.TabIndex = 3;
            buttonSelesai.UseVisualStyleBackColor = true;
            buttonSelesai.Click += buttonSelesai_Click;
            // 
            // buttonClose
            // 
            buttonClose.Image = Properties.Resources.Screenshot_2025_05_26_1417591;
            buttonClose.Location = new Point(731, 156);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(58, 19);
            buttonClose.TabIndex = 4;
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormHapusAlat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 757);
            Controls.Add(buttonClose);
            Controls.Add(buttonSelesai);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Name = "FormHapusAlat";
            Text = "FormHapusAlat";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button buttonSelesai;
        private Button buttonClose;
    }
}