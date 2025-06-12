using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPBOSewaAlatCamping.Models
{
    public class Transaksi
    {
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public decimal TotalHarga { get; set; }
        public string NamaPelanggan { get; set; }
        public string MetodePembayaran { get; set; }
        public string Status { get; set; } = "Menunggu Konfirmasi";
        public byte[] BuktiPembayaran { get; set; }
        public List<DetailTransaksi> DetailItems { get; set; } = new List<DetailTransaksi>();
    }
}

    public class DetailTransaksi
    {
    public int Id { get; set; }
    public string NamaAlat { get; set; }
    public int TransaksiId { get; set; }
    public int AlatId { get; set; }
    public int Jumlah { get; set; }
    public decimal HargaSatuan { get; set; }
    public int DurasiSewa { get; set; } // dalam hari
}
public class PembayaranInfo
{
    public string Metode { get; set; }
    public bool Berhasil { get; set; }
    public byte[] BuktiTransfer { get; set; }
}
