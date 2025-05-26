using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BawangMerah2
{
    public class transaksiQuery
    {
        private Koneksi con = new Koneksi();

        public DataTable LoadData()
        {
            con.start();
            string sql = "SELECT * FROM transaksi";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con.koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.stop();
            return ds.Tables[0];
        }

        public void Tambah(string namaPembeli, string jenis, decimal hargaJual, string satuan, decimal totalHarga)
        {
            con.start();
            string sql = "INSERT INTO transaksi (NamaPembeli, Jenis, HargaJual, Satuan, TotalHarga) VALUES (@NamaPembeli, @Jenis, @HargaJual, @Satuan, @TotalHarga)";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@NamaPembeli", namaPembeli);
            cmd.Parameters.AddWithValue("@Jenis", jenis);
            cmd.Parameters.AddWithValue("@HargaJual", hargaJual);
            cmd.Parameters.AddWithValue("@Satuan", satuan);
            cmd.Parameters.AddWithValue("@TotalHarga", totalHarga);
            cmd.ExecuteNonQuery();
            con.stop();
        }

        public void Update(int id, string namaPembeli, string jenis, decimal hargaJual, string satuan, decimal totalHarga)
        {
            con.start();
            string sql = "UPDATE transaksi SET NamaPembeli = @NamaPembeli,Jenis = @Jenis, HargaJual = @HargaJual, Satuan = @Satuan, TotalHarga = @TotalHarga WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@NamaPembeli", namaPembeli);
            cmd.Parameters.AddWithValue("@Jenis", jenis);
            cmd.Parameters.AddWithValue("@HargaJual", hargaJual);
            cmd.Parameters.AddWithValue("@Satuan", satuan);
            cmd.Parameters.AddWithValue("@TotalHarga", totalHarga);
            cmd.ExecuteNonQuery();
            con.stop();
        }

        public void Hapus(int id)
        {
            con.start();
            string sql = "DELETE FROM transaksi WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.stop();
        }

        public DataTable Cari(string keyword)
        {
            con.start();
            string sql = "SELECT * FROM transaksi WHERE NamaPembeli LIKE @keyword OR Jenis LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.stop();
            return ds.Tables[0];
        }
    }
}
