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
    public partial class FormHapusAlat : Form
    {
        private DatabaseAlat dbAlat = new DatabaseAlat();
        private int id;
        public FormHapusAlat()
        {
            InitializeComponent();
            LoadComboBoxAlat();
        }

        private void LoadComboBoxAlat()
        {
            try
            {
                DataTable dataAlat = dbAlat.AmbilSemuaAlat();

                // Tambahkan kolom baru untuk menyimpan gabungan ID dan nama alat
                dataAlat.Columns.Add("DisplayText", typeof(string));
                foreach (DataRow row in dataAlat.Rows)
                {
                    row["DisplayText"] = $"{row["id"]} - {row["nama"]}";
                }

                comboBox1.DisplayMember = "DisplayText"; // Gunakan kolom baru
                comboBox1.ValueMember = "id"; // ID tetap sebagai nilai
                comboBox1.DataSource = dataAlat;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error memuat daftar alat: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int selectedId))
            {
                id = selectedId;
            }
        }

        private void buttonSelesai_Click(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                MessageBox.Show("Pilih alat terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool berhasil = dbAlat.HapusAlatById(id);

                if (berhasil)
                {
                    MessageBox.Show("Alat berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComboBoxAlat(); // Perbarui daftar alat setelah penghapusan
                }
                else
                {
                    MessageBox.Show("Alat tidak ditemukan atau gagal dihapus.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menghapus: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
