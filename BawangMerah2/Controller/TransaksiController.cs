using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BawangMerah2.Model;

namespace BawangMerah2.Controller
{
    public class TransaksiController
    {
        private transaksiQuery transaksiQuery = new transaksiQuery();

        public DataTable GetAll()
        {
            return transaksiQuery.LoadData();
        }

        public void Tambah(Transaksi transaksi)
        {
            transaksiQuery.Tambah(
                transaksi.NamaPembeli,
                transaksi.Jenis,
                transaksi.HargaJual,
                transaksi.Satuan,
                transaksi.TotalHarga
            );
        }

        public void Update(Transaksi transaksi)
        {
            transaksiQuery.Update(
                transaksi.Id,
                transaksi.NamaPembeli,
                transaksi.Jenis,
                transaksi.HargaJual,
                transaksi.Satuan,
                transaksi.TotalHarga
            );
        }

        public void Hapus(int id)
        {
            transaksiQuery.Hapus(id);
        }

        public DataTable Cari(string keyword)
        {
            return transaksiQuery.Cari(keyword);
        }
    }
}
