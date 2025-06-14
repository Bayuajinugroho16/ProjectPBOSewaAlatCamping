using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPBOSewaAlatCamping.dataAccess;

namespace ProjectPBOSewaAlatCamping
{
    public partial class FormTambahAlat : Form
    {
        private ProjectPBOSewaAlatCamping.dataAccess.DatabaseAlat DatabaseAlat = new ProjectPBOSewaAlatCamping.dataAccess.DatabaseAlat();
        private string imagePath = "";
        
        public FormTambahAlat()
        {
            InitializeComponent();
            // Inisialisasi komponen lainnya jika diperlukan
            pictureBoxAlat.SizeMode = PictureBoxSizeMode.StretchImage; // Atur ukuran gambar agar sesuai dengan PictureBox

        }

        private void buttonPilihGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Files|*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                pictureBoxAlat.Image = Image.FromFile(imagePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Menutup form saat tombol dibatalkan ditekan

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = textBoxNamaAlat.Text;
                decimal harga = decimal.Parse(textBoxHargaAlat.Text);

                DatabaseAlat.TambahAlat(nama, harga, imagePath);
                MessageBox.Show("Data berhasil disimpan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        private void FormTambahAlat_Load(object sender, EventArgs e)
        {

        }
    }
}


