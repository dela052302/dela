using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BawangMerah2
{
    internal class Koneksi
    {
        string mysqlCon = "server=127.0.0.1;user=root;database=bawangmerah;password=";
        public MySqlConnection koneksi;

        public void start()
        {
            koneksi = new MySqlConnection(mysqlCon);
            koneksi.Open();
        }

        public void stop()
        {
            koneksi.Close();
        }
    }
}
