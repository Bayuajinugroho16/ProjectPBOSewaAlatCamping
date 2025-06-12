using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPBOSewaAlatCamping.pelanggan
{
    public class TransaksiItem
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public decimal Harga { get; set; }

        public TransaksiItem(int id, string nama, decimal harga)
        {
            Id = id;
            Nama = nama;
            Harga = harga;
        }
    }
}
