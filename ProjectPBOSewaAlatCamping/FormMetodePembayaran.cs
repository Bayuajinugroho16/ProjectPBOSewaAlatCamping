using ProjectPBOSewaAlatCamping.dataAccess;
using ProjectPBOSewaAlatCamping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPBOSewaAlatCamping
{
    public partial class FormMetodePembayaran : Form
    {
        private PictureBox pictureQR;
        private Button buttonCetak;
        private Button buttonKonfirmasiBayar;
        private PrintDocument printDoc;

        private decimal total;
        private string namaPelanggan;
        private List<DetailTransaksi> detailItems;

        private Label labelTotal;
        private Label labelNama;
        private ComboBox comboMetode;
        private Button buttonBayar;

        public PembayaranInfo InfoPembayaran { get; private set; } = new PembayaranInfo();

        public FormMetodePembayaran(decimal total, string namaPelanggan, List<DetailTransaksi> detailItems)
        {
            InitializeComponent();
            this.total = total;
            this.namaPelanggan = namaPelanggan;
            this.detailItems = detailItems;

            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Metode Pembayaran";
            this.Size = new Size(450, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            labelNama = new Label
            {
                Text = $"Nama: {namaPelanggan}",
                Location = new Point(20, 20),
                Size = new Size(400, 25),
                Font = new Font("Arial", 10)
            };

            labelTotal = new Label
            {
                Text = $"Total Pembayaran: Rp {total:N0}",
                Location = new Point(20, 50),
                Size = new Size(400, 25),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            comboMetode = new ComboBox
            {
                Location = new Point(20, 90),
                Size = new Size(300, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboMetode.Items.AddRange(new string[] { "QRIS", "CASH/BAYAR DI TEMPAT" });
            comboMetode.SelectedIndex = 0;

            buttonBayar = new Button
            {
                Text = "Lanjutkan",
                Location = new Point(20, 140),
                Size = new Size(200, 40),
                BackColor = Color.LightGreen
            };
            buttonBayar.Click += ButtonBayar_Click;

            this.Controls.Add(labelNama);
            this.Controls.Add(labelTotal);
            this.Controls.Add(comboMetode);
            this.Controls.Add(buttonBayar);
        }

        private void ButtonBayar_Click(object sender, EventArgs e)
        {
            InfoPembayaran.Metode = comboMetode.SelectedItem?.ToString();

            if (InfoPembayaran.Metode == "QRIS")
            {
                ShowQRIS();
            }
            else
            {
                InfoPembayaran.Berhasil = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ShowQRIS()
        {
            string path = Path.Combine(Application.StartupPath, "assets", "qris_sample.png");

            if (!File.Exists(path))
            {
                MessageBox.Show("File QRIS tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pictureQR = new PictureBox
            {
                Size = new Size(200, 200),
                Location = new Point(20, 200),
                Image = Image.FromFile(path),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            buttonKonfirmasiBayar = new Button
            {
                Text = "Saya Sudah Bayar",
                Location = new Point(20, 420),
                Size = new Size(200, 40),
                BackColor = Color.Orange
            };
            buttonKonfirmasiBayar.Click += ButtonKonfirmasiBayar_Click;

            this.Controls.Add(pictureQR);
            this.Controls.Add(buttonKonfirmasiBayar);
        }

        private void ButtonKonfirmasiBayar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Upload Bukti Transfer";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InfoPembayaran.BuktiTransfer = File.ReadAllBytes(openFileDialog.FileName);
                InfoPembayaran.Berhasil = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Anda belum mengunggah bukti pembayaran.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
