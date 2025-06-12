namespace ProjectPBOSewaAlatCamping
{
    partial class FormBeranda
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
            buttonTambah = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.berandaadmin__2_;
            pictureBox1.Location = new Point(13, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1359, 782);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonTambah
            // 
            buttonTambah.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonTambah.Image = Properties.Resources.Screenshot_2025_05_22_002906;
            buttonTambah.Location = new Point(622, 191);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(139, 29);
            buttonTambah.TabIndex = 1;
            buttonTambah.TextAlign = ContentAlignment.TopLeft;
            buttonTambah.UseVisualStyleBackColor = true;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // FormBeranda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1383, 806);
            Controls.Add(buttonTambah);
            Controls.Add(pictureBox1);
            Name = "FormBeranda";
            Text = "FormBeranda";
            Load += FormBeranda_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonTambah;
    }
}