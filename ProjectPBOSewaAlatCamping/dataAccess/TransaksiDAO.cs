using Npgsql;
using ProjectPBOSewaAlatCamping.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPBOSewaAlatCamping.dataAccess
{
    public class TransaksiDAO
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=bayuaji;Database=SEWAALATCAMPING";
        public DataTable AmbilDaftarTransaksiDenganBukti()
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            string query = @"
        SELECT 
            t.id AS ""ID Transaksi"",
            t.tanggal AS ""Tanggal"",
            t.nama_pelanggan AS ""Nama Pelanggan"",
            t.metodepembayaran AS ""Metode Pembayaran"",
            t.status AS ""Status"",
            t.bukti_transfer AS ""BuktiPembayaran"",
            a.nama AS ""Nama Alat"",
            dt.jumlah AS ""Jumlah"",
            dt.harga_satuan AS ""Harga Satuan"",
            COALESCE(dt.durasisewa, 1) AS ""Durasi (Hari)"",
            (dt.jumlah * dt.harga_satuan * COALESCE(dt.durasisewa, 1)) AS ""Subtotal""
        FROM transaksi t
        JOIN detail_transaksi dt ON t.id = dt.id_transaksi
        JOIN alat a ON a.id = dt.id_alat
        ORDER BY t.tanggal DESC;
    ";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            return dt;
        }
        

        public bool SimpanTransaksi(Transaksi transaksi)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ✅ Simpan Transaksi Utama termasuk metode pembayaran
                        string queryTransaksi = @"INSERT INTO transaksi (tanggal, total_harga, nama_pelanggan, metodepembayaran)
                                                  VALUES (@tanggal, @total_harga, @nama_pelanggan, @metodepembayaran)
                                                  RETURNING id;";

                        using var insertTransaksiCmd = new NpgsqlCommand(queryTransaksi, conn, transaction);
                        insertTransaksiCmd.Parameters.AddWithValue("@tanggal", transaksi.Tanggal);
                        insertTransaksiCmd.Parameters.AddWithValue("@total_harga", transaksi.TotalHarga);
                        insertTransaksiCmd.Parameters.AddWithValue("@nama_pelanggan", transaksi.NamaPelanggan);
                        insertTransaksiCmd.Parameters.AddWithValue("@metodepembayaran", transaksi.MetodePembayaran);

                        int idTransaksi = Convert.ToInt32(insertTransaksiCmd.ExecuteScalar());

                        // ✅ Simpan Detail Transaksi
                        foreach (var detail in transaksi.DetailItems)
                        {
                            using var insertDetailCmd = new NpgsqlCommand(@"
                                INSERT INTO detail_transaksi (id_transaksi, id_alat, jumlah, harga_satuan, durasisewa)
                                VALUES (@id_transaksi, @id_alat, @jumlah, @harga_satuan, @durasisewa)", conn, transaction);

                            insertDetailCmd.Parameters.AddWithValue("@id_transaksi", idTransaksi);
                            insertDetailCmd.Parameters.AddWithValue("@id_alat", detail.AlatId);
                            insertDetailCmd.Parameters.AddWithValue("@jumlah", detail.Jumlah);
                            insertDetailCmd.Parameters.AddWithValue("@harga_satuan", detail.HargaSatuan);
                            insertDetailCmd.Parameters.AddWithValue("@durasisewa", detail.DurasiSewa);

                            insertDetailCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saat simpan transaksi: " + ex.Message);
                        try { transaction.Rollback(); } catch { }
                        return false;
                    }
                }
            }
        }

        public void UpdateStatusTransaksi(int idTransaksi, string statusBaru, string alasan)
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            string query = @"UPDATE transaksi SET status = @status WHERE id = @id";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", statusBaru);
            cmd.Parameters.AddWithValue("@id", idTransaksi);

            cmd.ExecuteNonQuery();

            if (!string.IsNullOrEmpty(alasan))
            {
                MessageBox.Show($"Transaksi #{idTransaksi} ditolak. Alasan: {alasan}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




    }


}
