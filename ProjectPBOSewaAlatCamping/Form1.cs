using Npgsql;
using ProjectPBOSewaAlatCamping.dataAccess;


namespace ProjectPBOSewaAlatCamping
{
    public partial class Form1 : Form
    {

        private readonly DataAccess dataAccess;


        public Form1()
        {
            InitializeComponent();
            dataAccess = new DataAccess(); // Inisialisasi DataAccess   

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = textBox1Loguser.Text;
            string password = textBox2Passuser.Text;

            string role = dataAccess.LoginUser(usernameOrEmail, password); // Panggil metode dari DataAccess

            if (!string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Login berhasil!");

                if (role == "admin")
                {
                    Berandaadmin berandaadmin = new Berandaadmin();
                    berandaadmin.Show();
                }
                else if (role == "pelanggan")
                {
                    BerandaPelanggan berandaPelanggan = new BerandaPelanggan();
                    berandaPelanggan.Show();

                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username/Email atau Password salah.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3Reg.Text;
            string email = textBox1Emailreg.Text;
            string password = textBox4Pass.Text;

            bool success = dataAccess.RegisterUser(username, email, password, "pelanggan"); // Gunakan DataAccess

            MessageBox.Show(success ? "Registrasi berhasil!" : "Username atau Email sudah terdaftar.");
        }
        private void textBox1Loguser_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}



