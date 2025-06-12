
using Npgsql;

namespace ProjectPBOSewaAlatCamping
{
    internal class Database
    {
        internal string LoginUser(string usernameOrEmail, string password)
        {
            
                using var conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=SEWAALATCAMPING;Username=postgres;Password=bayuaji");
                conn.Open();

                using var cmd = new NpgsqlCommand("SELECT role FROM users WHERE (username = @u OR email = @u) AND password = @p", conn);
                cmd.Parameters.AddWithValue("u", usernameOrEmail);
                cmd.Parameters.AddWithValue("p", password);

                var role = cmd.ExecuteScalar()?.ToString();
                return role;
        }

        internal bool RegisterUser(string username, string email, string password, string role)
        {
            
            using var conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=SEWAALATCAMPING;Username=postgres;Password=bayuaji");
            conn.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO users (username, email, password, role) VALUES (@u, @e, @p, @r)", conn);
            cmd.Parameters.AddWithValue("u", username);
            cmd.Parameters.AddWithValue("e", email);
            cmd.Parameters.AddWithValue("p", password);
            cmd.Parameters.AddWithValue("r", role);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (PostgresException)
            {
                return false;
            }
        }


    }
}