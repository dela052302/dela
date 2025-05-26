using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BawangMerah2
{
    public class loginQuery
    {
        private Koneksi con = new Koneksi();

        public bool CekLogin(string username, string password)
        {
            bool hasil = false;
            try
            {
                con.start();
                string sql = "SELECT * FROM user WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    hasil = true;
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.stop();
            }
            return hasil;
        }
    }
}
