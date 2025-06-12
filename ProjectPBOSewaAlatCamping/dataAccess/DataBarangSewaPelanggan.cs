using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPBOSewaAlatCamping.dataAccess
{
    internal class DataBarangSewaPelanggan
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=SEWAALATCAMPING;Username=postgres;Password=bayuaji";

        public Tuple<int, string, decimal> AmbilDataAlat(int id)
        {
            string query = "SELECT id, nama, harga FROM SEWAALATCAMPING WHERE id = @id";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString)) // Gunakan NpgsqlConnection
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn)) // Gunakan NpgsqlCommand
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader()) // Gunakan NpgsqlDataReader
                        {
                            if (reader.Read())
                            {
                                return new Tuple<int, string, decimal>(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetDecimal(2)
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mengambil data alat: {ex.Message}");
            }

            return null; // Kembalikan null jika data tidak ditemukan atau terjadi error
        }
    }
}
