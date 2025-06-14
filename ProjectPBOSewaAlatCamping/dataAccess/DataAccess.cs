using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPBOSewaAlatCamping.dataAccess
{
    public class DataAccess
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=SEWAALATCAMPING;Username=postgres;Password=bayuaji";

        public bool RegisterUser(string username,string email, string password,string role )
            {
            using var conn = new Npgsql.NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new Npgsql.NpgsqlCommand("INSERT INTO users (username, email, password, role) VALUES (@u, @e, @p, @r)", conn);
            cmd.Parameters.AddWithValue("u", username);
            cmd.Parameters.AddWithValue("e", email);
            cmd.Parameters.AddWithValue("p", password);
            cmd.Parameters.AddWithValue("r", role);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Npgsql.PostgresException)
            {
                return false;
            }
        }

        public string LoginUser(string usernameOrEmail, string password)
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT role FROM users WHERE (username = @u OR email = @u) AND password = @p", conn);
            cmd.Parameters.AddWithValue("u", usernameOrEmail);
            cmd.Parameters.AddWithValue("p", password);

            var role = cmd.ExecuteScalar()?.ToString();
            return role;
        }
    }
}
