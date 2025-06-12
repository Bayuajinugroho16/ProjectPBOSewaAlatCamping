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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectPBOSewaAlatCamping
{
    public partial class LihatDaftarSewa : Form
    {
        private TransaksiDAO transaksiDAO = new TransaksiDAO();
        public LihatDaftarSewa()
        {
            InitializeComponent();
            LoadTransaksiKeGrid();
        }

        private void LoadTransaksiKeGrid()
        {
            try
            {
                DataTable data = transaksiDAO.AmbilDaftarTransaksiDenganBukti();
                dataGridViewLihatAlat.DataSource = data;

                dataGridViewLihatAlat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewLihatAlat.ReadOnly = true;
                dataGridViewLihatAlat.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data transaksi:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Berandaadmin berandaAdmin = new Berandaadmin();
            berandaAdmin.ShowDialog();
            Close();
        }
    }
}
