using Npgsql;
using NpgsqlTypes;
using ProjectPBOSewaAlatCamping.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectPBOSewaAlatCamping.dataAccess
{
    public class DatabaseAlat
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=SEWAALATCAMPING;Username=postgres;Password=bayuaji";
        private string? connStr;

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
        public List<AlatCamping> AmbilSemuaAlatCamping()
        {
            var list = new List<AlatCamping>();
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT id, nama, harga, stock, foto FROM alat", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new AlatCamping
                {
                    Id = reader.GetInt32(0),
                    Nama = reader.GetString(1),
                    Harga = reader.GetDecimal(2),
                    stock = reader.GetInt32(3),
                    Foto = reader.IsDBNull(4) ? null : (byte[])reader[4]
                });
            }

            return list;
        }


        public bool SimpanTransaksi(ListBox listBoxTransaksi, decimal totalHarga)
        {
            using var conn = GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                using var cmdTransaksi = new NpgsqlCommand("INSERT INTO transaksi (tanggal, total_harga) VALUES (@tanggal, @total) RETURNING id", conn);
                cmdTransaksi.Parameters.AddWithValue("@tanggal", DateTime.Now);
                cmdTransaksi.Parameters.AddWithValue("@total", totalHarga);
                int idTransaksi = Convert.ToInt32(cmdTransaksi.ExecuteScalar());

                foreach (var item in listBoxTransaksi.Items)
                {
                    string itemText = item.ToString();
                    if (string.IsNullOrWhiteSpace(itemText)) continue;

                    string[] parts = itemText.Split('-');
                    if (parts.Length < 2) continue;

                    string namaAlat = parts[0].Trim();
                    string[] qtyAndHarga = parts[1].Split('x');
                    if (qtyAndHarga.Length < 2) continue;

                    if (!int.TryParse(qtyAndHarga[0].Trim(), out int jumlah)) continue;

                    string hargaPart = qtyAndHarga[1].Split('=')[0].Replace("Rp", "").Trim();
                    if (!decimal.TryParse(hargaPart, out decimal hargaSatuan)) continue;

                    using var cmdGetId = new NpgsqlCommand("SELECT id FROM alat WHERE nama = @nama LIMIT 1", conn);
                    cmdGetId.Parameters.AddWithValue("@nama", namaAlat);
                    object? result = cmdGetId.ExecuteScalar();
                    if (result == null) continue;

                    int idAlat = Convert.ToInt32(result);

                    using var cmdDetail = new NpgsqlCommand("INSERT INTO detail_transaksi (id_transaksi, id_alat, jumlah, harga_satuan) VALUES (@id_transaksi, @id_alat, @jumlah, @harga)", conn);
                    cmdDetail.Parameters.AddWithValue("@id_transaksi", idTransaksi);
                    cmdDetail.Parameters.AddWithValue("@id_alat", idAlat);
                    cmdDetail.Parameters.AddWithValue("@jumlah", jumlah);
                    cmdDetail.Parameters.AddWithValue("@harga", hargaSatuan);
                    cmdDetail.ExecuteNonQuery();

                    using var cmdUpdateStok = new NpgsqlCommand("UPDATE alat SET stock = stock - @jumlah WHERE id = @id AND stock >= @jumlah", conn);
                    cmdUpdateStok.Parameters.AddWithValue("@jumlah", jumlah);
                    cmdUpdateStok.Parameters.AddWithValue("@id", idAlat);

                    int updated = cmdUpdateStok.ExecuteNonQuery();
                    if (updated == 0)
                        throw new Exception($"Stok tidak mencukupi untuk: {namaAlat}");
                }

                transaction.Commit();
                MessageBox.Show("Transaksi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"Error saat menyimpan transaksi:\n{ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void TambahAlat(string nama, decimal harga, string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                throw new ArgumentException("Silakan pilih gambar terlebih dahulu!");

            byte[] foto = File.ReadAllBytes(imagePath);

            using var conn = GetConnection();
            conn.Open();
            string query = "INSERT INTO alat (nama, harga, foto) VALUES (@nama, @harga, @foto)";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@harga", harga);
            cmd.Parameters.AddWithValue("@foto", foto);
            cmd.ExecuteNonQuery();
        }


        public int AmbilStokAlat(int idAlat)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT stock FROM alat WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", idAlat);
            object result = cmd.ExecuteScalar();
            return result is int stok ? stok : 0;
        }


        public bool PerbaruiStokAlat(int idAlat, int perubahanStok)
        {
            if (perubahanStok == 0) return false;

            using var conn = GetConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("UPDATE alat SET stock = stock + @p WHERE id = @id AND (stock + @p) >= 0", conn);
            cmd.Parameters.AddWithValue("@p", perubahanStok);
            cmd.Parameters.AddWithValue("@id", idAlat);
            return cmd.ExecuteNonQuery() > 0;

        }

        public bool HapusAlatById(int id)
        {
            using var conn = GetConnection();
            conn.Open();

            using var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM alat WHERE id = @id", conn);
            checkCmd.Parameters.AddWithValue("@id", id);
            if (Convert.ToInt32(checkCmd.ExecuteScalar()) == 0)
            {
                MessageBox.Show($"Alat dengan ID {id} tidak ditemukan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using var cmd = new NpgsqlCommand("DELETE FROM alat WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Alat berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            MessageBox.Show("Penghapusan gagal.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public DataTable AmbilSemuaAlat()
        {
            DataTable dt = new DataTable();
            try
            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("SELECT id, nama, harga, stock, foto FROM alat", conn);
                using var reader = cmd.ExecuteReader();
                dt.Load(reader);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["foto"] is byte[] imgData && imgData.Length == 0)
                        row["foto"] = DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }

            return dt;
        }

        public AlatCamping? AmbilAlatById(int id)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT id, nama, harga, stock, foto FROM alat WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (id <= 2)
                {
                    Console.WriteLine($"ERROR: ID alat tidak valid = {id}");
                    return null;
                }
                return new AlatCamping
                {

                    Id = reader.GetInt32(0),
                    Nama = reader.GetString(1),
                    Harga = reader.GetDecimal(2),
                    stock = reader.GetInt32(3), // Pastikan properti sesuai dengan kelas AlatCamping
                    Foto = reader.IsDBNull(4) ? null : (byte[])reader["foto"] // Tangani NULL lebih aman
                };
            }

            Console.WriteLine($"DEBUG: ID alat yang dikirim = {id}");
            return null;
        }

        public bool PerbaruiAlat(int id, string namaBaru, decimal hargaBaru, int perubahanStock, byte[] foto)
        {
            using var conn = GetConnection();
            try
            {
                conn.Open();

                int stokSekarang = AmbilStokAlat(id);
                int stokBaru = stokSekarang + perubahanStock;

                if (stokBaru < 0)
                {
                    MessageBox.Show("Stok tidak boleh negatif!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(namaBaru) && hargaBaru == 0 && perubahanStock == 0)
                {
                    MessageBox.Show("Tidak ada perubahan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                string query = foto.Length > 0
                    ? "UPDATE alat SET nama = @nama, harga = @harga, stock = @stok, foto = @foto WHERE id = @id"
                    : "UPDATE alat SET nama = @nama, harga = @harga, stock = @stok WHERE id = @id";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nama", namaBaru);
                cmd.Parameters.AddWithValue("@harga", hargaBaru);
                cmd.Parameters.AddWithValue("@stok", stokBaru);
                if (foto.Length > 0) cmd.Parameters.AddWithValue("@foto", foto);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data alat berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Update gagal. Tidak ada data diubah.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi error: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


       

    }
}
