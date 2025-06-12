using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPBOSewaAlatCamping.dataAccess
{
    public class AlatCamping
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public decimal Harga { get; set; }
        public int stock { get; set; }
        public byte[] Foto { get; set; }

    }
}
