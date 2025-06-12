namespace ProjectPBOSewaAlatCamping
{
    partial class LihatDaftarSewa
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
            dataGridViewLihatAlat = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLihatAlat).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.berandaadmin__12_;
            pictureBox1.Location = new Point(17, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1255, 741);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewLihatAlat
            // 
            dataGridViewLihatAlat.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewLihatAlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLihatAlat.Location = new Point(117, 249);
            dataGridViewLihatAlat.Name = "dataGridViewLihatAlat";
            dataGridViewLihatAlat.RowHeadersWidth = 51;
            dataGridViewLihatAlat.Size = new Size(1101, 359);
            dataGridViewLihatAlat.TabIndex = 1;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Screenshot_2025_06_12_235644;
            button1.Location = new Point(514, 182);
            button1.Name = "button1";
            button1.Size = new Size(86, 27);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.Screenshot_2025_05_24_210207;
            button2.Location = new Point(617, 182);
            button2.Name = "button2";
            button2.Size = new Size(86, 27);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.Screenshot_2025_05_24_210240;
            button3.Location = new Point(713, 182);
            button3.Name = "button3";
            button3.Size = new Size(86, 27);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            // 
            // LihatDaftarSewa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 781);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewLihatAlat);
            Controls.Add(pictureBox1);
            Name = "LihatDaftarSewa";
            Text = "LihatDaftarSewa";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLihatAlat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewLihatAlat;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}