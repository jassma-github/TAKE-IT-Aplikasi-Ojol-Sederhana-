using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_LIB
{
    public class Admin
    {
        private string username;
        private string password;

        #region Constructor
        public Admin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public Admin()
        {
            this.Username = "";
            this.Password = "";
        }
        #endregion

        #region Properties

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region method
        public static Admin CekLogin(string username, string password)
        {
            string sql = "";
            string cekuser = IsaAesCrypt.EncryptedData(username);
            string cekpass = IsaAesCrypt.EncryptedData(password);
            sql = "select * from admins where username = '" + cekuser + "' and pass = '" + cekpass + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            Admin userLogin = new Admin();
            if (hasil.Read() == true)
            {
                userLogin.Username =IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                userLogin.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                return userLogin;
            }
            else
            {
                return null;
            }
        }
        public static void TambahData(Admin admin)
        {
            try
            {
                Koneksi kon = new Koneksi();
                // IsaAesCrypt isa = new IsaAesCrypt();
                string adminUsername = IsaAesCrypt.EncryptedData(admin.Username);
                string adminPass = IsaAesCrypt.EncryptedData(admin.Password);
                string perintah = "insert into admins (username, pass) values ('" + adminUsername + "', '" + adminPass + "');";
                int hasil = Koneksi.JalankanPerintahNonQuery(perintah, kon);
            }
            catch (Exception ex)
            {
                //tampilkan pesan kesalahan
                throw new Exception(ex.Message);
            }
        }
        public static Admin AmbilData(string kolom = "", string nilai = "")
        {
            string sql;
            string cekNilai = IsaAesCrypt.EncryptedData(nilai); 
            if (kolom != "")
            {
                sql = "select * from admins where " + kolom + " = '" + cekNilai + "'";
            }
            else
            {
                sql = "select * from admins";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Admin e = new Admin();

                e.Username = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                e.Password= IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                return e;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
