namespace ProjectPBOSewaAlatCamping
{
    partial class FormUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdate));
            pictureBox1 = new PictureBox();
            textBoxnamaup = new TextBox();
            textBoxhargaUp = new TextBox();
            button1 = new Button();
            buttoninsert = new Button();
            buttonclose = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBoxupgambar = new PictureBox();
            comboBoxAlat = new ComboBox();
            textBoxStock = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxupgambar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1132, 705);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBoxnamaup
            // 
            textBoxnamaup.Location = new Point(429, 346);
            textBoxnamaup.Name = "textBoxnamaup";
            textBoxnamaup.Size = new Size(125, 27);
            textBoxnamaup.TabIndex = 1;
            // 
            // textBoxhargaUp
            // 
            textBoxhargaUp.Location = new Point(429, 393);
            textBoxhargaUp.Name = "textBoxhargaUp";
            textBoxhargaUp.Size = new Size(125, 27);
            textBoxhargaUp.TabIndex = 2;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Screenshot_2025_05_26_1416371;
            button1.Location = new Point(531, 483);
            button1.Name = "button1";
            button1.Size = new Size(61, 22);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttoninsert
            // 
            buttoninsert.Image = Properties.Resources.Screenshot_2025_06_01_020716;
            buttoninsert.Location = new Point(458, 306);
            buttoninsert.Name = "buttoninsert";
            buttoninsert.Size = new Size(76, 19);
            buttoninsert.TabIndex = 4;
            buttoninsert.UseVisualStyleBackColor = true;
            buttoninsert.Click += buttoninsert_Click;
            // 
            // buttonclose
            // 
            buttonclose.Image = Properties.Resources.Screenshot_2025_05_26_1417591;
            buttonclose.Location = new Point(719, 140);
            buttonclose.Name = "buttonclose";
            buttonclose.Size = new Size(51, 20);
            buttonclose.TabIndex = 5;
            buttonclose.UseVisualStyleBackColor = true;
            buttonclose.Click += buttonclose_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxupgambar
            // 
            pictureBoxupgambar.Location = new Point(438, 193);
            pictureBoxupgambar.Name = "pictureBoxupgambar";
            pictureBoxupgambar.Size = new Size(116, 97);
            pictureBoxupgambar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxupgambar.TabIndex = 6;
            pictureBoxupgambar.TabStop = false;
            // 
            // comboBoxAlat
            // 
            comboBoxAlat.FormattingEnabled = true;
            comboBoxAlat.Location = new Point(585, 197);
            comboBoxAlat.Name = "comboBoxAlat";
            comboBoxAlat.Size = new Size(168, 28);
            comboBoxAlat.TabIndex = 7;
            comboBoxAlat.SelectedIndexChanged += comboBoxAlat_SelectedIndexChanged;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(429, 442);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(125, 27);
            textBoxStock.TabIndex = 8;
            // 
            // FormUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 702);
            Controls.Add(button1);
            Controls.Add(textBoxStock);
            Controls.Add(textBoxhargaUp);
            Controls.Add(buttoninsert);
            Controls.Add(textBoxnamaup);
            Controls.Add(pictureBoxupgambar);
            Controls.Add(buttonclose);
            Controls.Add(comboBoxAlat);
            Controls.Add(pictureBox1);
            Name = "FormUpdate";
            Text = "FormUpdate";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxupgambar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBoxnamaup;
        private TextBox textBoxhargaUp;
        private Button button1;
        private Button buttoninsert;
        private Button buttonclose;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBoxupgambar;
        private ComboBox comboBoxAlat;
        private TextBox textBoxStock;
    }
}