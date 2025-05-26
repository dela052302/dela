using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BawangMerah2.Model
{
    public class Transaksi
    {
        public int Id { get; set; }
        public string NamaPembeli { get; set; }
        public string Jenis { get; set; }
        public decimal HargaJual { get; set; }
        public string Satuan { get; set; }
        public decimal TotalHarga { get; set; }
    }
}
