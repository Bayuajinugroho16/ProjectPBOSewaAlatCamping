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
    public partial class VerivfikasiPembayaran : Form
    {
        private TransaksiDAO transaksiDAO = new TransaksiDAO();
        private DataTable transaksiTable;
        private DataGridView dataGridView1;
        private PictureBox pictureBoxBukti;
        private Button btnSetujui;
        private Button btnTolak;

        public VerivfikasiPembayaran()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            this.Text = "Verifikasi Pembayaran";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            dataGridView1 = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(600, 250),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            pictureBoxBukti = new PictureBox
            {
                Location = new Point(640, 20),
                Size = new Size(220, 220),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            btnSetujui = new Button
            {
                Text = "✔ Setujui",
                Location = new Point(640, 260),
                Size = new Size(100, 40),
                BackColor = Color.LightGreen,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnSetujui.Click += btnSetujui_Click;

            btnTolak = new Button
            {
                Text = "❌ Tolak",
                Location = new Point(760, 260),
                Size = new Size(100, 40),
                BackColor = Color.LightCoral,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnTolak.Click += btnTolak_Click;

            this.Controls.Add(dataGridView1);
            this.Controls.Add(pictureBoxBukti);
            this.Controls.Add(btnSetujui);
            this.Controls.Add(btnTolak);
        }

        private void LoadData()
        {
            transaksiTable = transaksiDAO.AmbilDaftarTransaksiDenganBukti();
            dataGridView1.DataSource = transaksiTable;

            if (dataGridView1.Columns.Contains("BuktiPembayaran"))
            {
                dataGridView1.Columns["BuktiPembayaran"].Visible = false; // Jangan tampilkan kolom gambar byte[]
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (row.Cells["BuktiPembayaran"].Value is byte[] bukti && bukti.Length > 0)
                {
                    using MemoryStream ms = new MemoryStream(bukti);
                    pictureBoxBukti.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBoxBukti.Image = null;
                }
            }
        }

        private void btnSetujui_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idTransaksi = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Transaksi"].Value);
                transaksiDAO.UpdateStatusTransaksi(idTransaksi, "Disetujui", null);
                LoadData();
                MessageBox.Show("Transaksi disetujui.");
            }
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idTransaksi = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID Transaksi"].Value);
                string alasan = Microsoft.VisualBasic.Interaction.InputBox("Alasan penolakan:", "Tolak Pembayaran", "");
                transaksiDAO.UpdateStatusTransaksi(idTransaksi, "Ditolak", alasan);
                LoadData();
                MessageBox.Show("Transaksi ditolak.");
            }
        }
    }
}
