namespace ProjectPBOSewaAlatCamping
{
    partial class FormTambahAlat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTambahAlat));
            pictureBox1 = new PictureBox();
            textBoxNamaAlat = new TextBox();
            textBoxHargaAlat = new TextBox();
            buttonPilihGambar = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBoxAlat = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlat).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(29, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1215, 738);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBoxNamaAlat
            // 
            textBoxNamaAlat.Location = new Point(589, 400);
            textBoxNamaAlat.Name = "textBoxNamaAlat";
            textBoxNamaAlat.Size = new Size(116, 27);
            textBoxNamaAlat.TabIndex = 1;
            // 
            // textBoxHargaAlat
            // 
            textBoxHargaAlat.BackColor = Color.White;
            textBoxHargaAlat.Location = new Point(592, 453);
            textBoxHargaAlat.Name = "textBoxHargaAlat";
            textBoxHargaAlat.Size = new Size(116, 27);
            textBoxHargaAlat.TabIndex = 3;
            // 
            // buttonPilihGambar
            // 
            buttonPilihGambar.Image = Properties.Resources.Screenshot_2025_05_26_141516;
            buttonPilihGambar.Location = new Point(611, 351);
            buttonPilihGambar.Name = "buttonPilihGambar";
            buttonPilihGambar.Size = new Size(90, 18);
            buttonPilihGambar.TabIndex = 4;
            buttonPilihGambar.Text = "button1";
            buttonPilihGambar.UseVisualStyleBackColor = true;
            buttonPilihGambar.Click += buttonPilihGambar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxAlat
            // 
            pictureBoxAlat.Location = new Point(591, 232);
            pictureBoxAlat.Name = "pictureBoxAlat";
            pictureBoxAlat.Size = new Size(123, 99);
            pictureBoxAlat.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAlat.TabIndex = 5;
            pictureBoxAlat.TabStop = false;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Screenshot_2025_05_26_141637;
            button1.Location = new Point(621, 535);
            button1.Name = "button1";
            button1.Size = new Size(68, 26);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.Screenshot_2025_05_26_141759;
            button2.Location = new Point(813, 169);
            button2.Name = "button2";
            button2.Size = new Size(68, 18);
            button2.TabIndex = 7;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormTambahAlat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 775);
            Controls.Add(button2);
            Controls.Add(pictureBoxAlat);
            Controls.Add(button1);
            Controls.Add(textBoxHargaAlat);
            Controls.Add(textBoxNamaAlat);
            Controls.Add(buttonPilihGambar);
            Controls.Add(pictureBox1);
            Name = "FormTambahAlat";
            Text = "FormTambahAlat";
            Load += FormTambahAlat_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBoxNamaAlat;
        private TextBox textBoxHargaAlat;
        private Button buttonPilihGambar;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBoxAlat;
        private Button button1;
        private Button button2;
    }
}