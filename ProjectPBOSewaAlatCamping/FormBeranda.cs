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
    public partial class FormBeranda : Form
    {
        public FormBeranda()
        {
            InitializeComponent();
            buttonTambah.Enabled = true; // Pastikan tombol aktif

        }


        private void buttonTambah_Click(object sender, EventArgs e)
        {
            //FormCRUD formCRUD = new FormCRUD();
            //formCRUD.Show();
            //this.Hide();

        }

        private void FormBeranda_Load(object sender, EventArgs e)
        {

        }
    }
}
