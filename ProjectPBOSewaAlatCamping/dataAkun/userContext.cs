//using Microsoft.VisualBasic.ApplicationServices;
//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProjectPBOSewaAlatCamping.dataAkun
//{
//    internal class userContext
//    {
//        private readonly string connStr;
//        internal static string User;

//        public userContext()
//        {
//            connStr = "Host=localhost;Username=postgres;Password=bayuaji;Database=pbobayu";
//        }

//        public bool RegisterUser(string username, string email, string password, string role)
//        {
//            username = username.Trim();

//            using var conn = new NpgsqlConnection(connStr);
//            conn.Open();

//            // **Cek apakah username atau email sudah digunakan**
//            string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
//            using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
//            {
//                checkCmd.Parameters.AddWithValue("username", username);
//                checkCmd.Parameters.AddWithValue("email", email);
//                int existingUsers = Convert.ToInt32(checkCmd.ExecuteScalar());

//                if (existingUsers > 0)
//                {
//                    return false; // Username atau Email sudah terdaftar
//                }
//            }

//            // **Tambahkan pengguna baru jika belum terdaftar**
//            string query = "INSERT INTO users (username, email, password, role) VALUES (@username, @email, @password, @role)";
//            using var cmd = new NpgsqlCommand(query, conn);
//            cmd.Parameters.AddWithValue("username", username);
//            cmd.Parameters.AddWithValue("email", email);
//            cmd.Parameters.AddWithValue("password", password);
//            cmd.Parameters.AddWithValue("role", role);

//            try
//            {
//                cmd.ExecuteNonQuery();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Terjadi kesalahan saat registrasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }


//        }

//        public bool LoginUser(string usernameOrEmail, string password, out string role)
//        {
//            using var conn = new NpgsqlConnection(connStr);
//            conn.Open();
//            string query = "SELECT role FROM users WHERE (username = @usernameOrEmail OR email = @usernameOrEmail) AND password = @password";
//            using var cmd = new NpgsqlCommand(query, conn);
//            cmd.Parameters.AddWithValue("usernameOrEmail", usernameOrEmail);
//            cmd.Parameters.AddWithValue("password", password);
//            object result = cmd.ExecuteScalar();
//            if (result != null)
//            {
//                role = result.ToString();
//                return true; // Login berhasil
//            }
//            else
//            {
//                role = null;
//                return false; // Login gagal
//            }
//        }
//    }
//}
