using ProjectPBOSewaAlatCamping.dataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPBOSewaAlatCamping
{
    public partial class FormUpdate : Form
    {

        private DatabaseAlat dbAlat = new DatabaseAlat();
        private int _currentId;
        private string imagePath = "";
        private byte[]? fotobyteLama = Array.Empty<byte>();


        public FormUpdate(int id)
        {
            InitializeComponent();
            _currentId = id; // Memastikan ID alat tersimpan
            fotobyteLama = Array.Empty<byte>(); // Inisialisasi foto lama
            LoadComboBoxAlat();
            LoadDataAlat(id);
        }

        private void LoadComboBoxAlat()
        {
            try
            {
                DataTable dataAlat = dbAlat.AmbilSemuaAlat();
                comboBoxAlat.DisplayMember = "nama";
                comboBoxAlat.ValueMember = "id";
                comboBoxAlat.DataSource = dataAlat;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error memuat daftar alat: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxAlat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAlat.SelectedValue != null && int.TryParse(comboBoxAlat.SelectedValue.ToString(), out int selectedId))
            {
                _currentId = selectedId;
                LoadDataAlat(_currentId);
            }
        }

        private void LoadDataAlat(int id)
        {
            try
            {
                Console.WriteLine($"DEBUG: Memeriksa alat dengan ID = {id}");

                if (id <= 0)
                {
                    MessageBox.Show("ID alat tidak valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AlatCamping? alat = dbAlat.AmbilAlatById(id); // Correct type based on the provided signature

                if (alat == null)
                {
                    MessageBox.Show($"Data alat dengan ID {id} tidak ditemukan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine($"ERROR: Data alat dengan ID {id} tidak ditemukan.");
                    return;
                }

                // Access properties directly from the AlatCamping object
                textBoxnamaup.Text = alat.Nama ?? "";
                textBoxhargaUp.Text = alat.Harga.ToString();
                textBoxStock.Text = alat.stock > 0 ? alat.stock.ToString() : "0";

                fotobyteLama = alat.Foto ?? Array.Empty<byte>();

                pictureBoxupgambar.Image = ConvertBytesToImage(fotobyteLama);
                imagePath = "";

                Console.WriteLine($"DEBUG: Data alat ditemukan! ID = {id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error memuat data alat: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private Image? ConvertBytesToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0) return null;
            try
            {
                using MemoryStream ms = new MemoryStream(imageBytes);
                return Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan saat mengonversi gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void buttoninsert_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Pilih Gambar"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                pictureBoxupgambar.Image = Image.FromFile(imagePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxnamaup.Text) || string.IsNullOrEmpty(textBoxhargaUp.Text) || string.IsNullOrEmpty(textBoxStock.Text))
                {
                    MessageBox.Show("Harap isi nama, harga, dan stok baru!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxhargaUp.Text, out decimal hargaBaru) || hargaBaru <= 0)
                {
                    MessageBox.Show("Harga harus berupa angka positif!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(textBoxStock.Text, out int stock))
        {
            MessageBox.Show("Stok harus berupa bilangan bulat!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

                string namaBaru = textBoxnamaup.Text;
                byte[]? fotoBytes = File.Exists(imagePath) ? File.ReadAllBytes(imagePath) : fotobyteLama ?? Array.Empty<byte>();

                Console.WriteLine($"Mengirim data update: ID={_currentId}, Nama={namaBaru}, Harga={hargaBaru}, Stok={stock}, Foto={(fotoBytes.Length > 0 ? "Ada Foto" : "Foto Kosong")}");

                bool berhasil = dbAlat.PerbaruiAlat(_currentId, namaBaru, hargaBaru, stock, fotoBytes);

                if (berhasil)
                {
                    MessageBox.Show("Data alat berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Gagal memperbarui data alat!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi error saat memperbarui data: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
