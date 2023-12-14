using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace ISA_LIB
{
    public class Customer
    {
        #region Data Member
        private string email;
        private string nama;
        private string alamat;
        private string noTelp;
        private string password;
        private double saldo;
        private FotoProfil fotoProfil;
        private Admin verifikator;
        #endregion

        #region Constructor
        public Customer(string email, string nama, string alamat, string noTelp, string password,double saldo, FotoProfil fotoProfil, Admin verifikator)
        {
            this.Email = email;
            this.Nama = nama;
            this.Alamat = alamat;
            this.NoTelp = noTelp;
            this.Password = password;
            this.Saldo = saldo;
            this.FotoProfil = fotoProfil;
            this.verifikator = verifikator;
        }
        public Customer()
        {
            this.Email = " ";
            this.Nama = " ";
            this.Alamat = " ";
            this.NoTelp = "xxxxxxxxxxx";
            this.Password = "xxxxxxxx";
            this.Saldo = 0;
            this.FotoProfil = new FotoProfil();
            this.verifikator = new Admin();
        }
        #endregion

        #region Properties

        public string Email { get => email; 
            set
            {
                if ( value != "")
                {
                    email = value;
                }
                else
                {
                    throw new Exception("Email tidak boleh kosong !");
                }
            }
        }
        public string Nama { get => nama; set
            {
                if (value != "")
                {
                     nama = value;
                }
                else
                {
                    throw new Exception("Nama tidak boleh kosong !");
                }
            }
        }
        public string Alamat
        {
            get => alamat; set
            {
                if (value != "")
                {
                    alamat = value;
                }
                else
                {
                    throw new Exception("Alamat tidak boleh kosong !");
                }
            }
        }
        public string NoTelp
        {
            get => noTelp; set
            {
                if (value != "" && value.Length>=11)
                {
                    noTelp = value;
                }
                else
                {
                    throw new Exception("No telp tidak sesuai format !");
                }
            }
        }
        public string Password
        {
            get => password; set
            {
                if (value != "" && value.Length==8)
                {
                    password = value;
                }
                else
                {
                    throw new Exception("Password harus 8 digit !");
                }
            }
        }
        public double Saldo { get => saldo; private set => saldo = value; }
        public FotoProfil FotoProfil { get => fotoProfil; set => fotoProfil = value; }
        public Admin Verifikator { get => verifikator; set => verifikator = value; }
        #endregion

        #region Method
        public static Customer CekLogin(string email, string password)
        {
            string sql = "";
            string cekEmail = IsaAesCrypt.EncryptedData(email);
            string cekPass = IsaAesCrypt.EncryptedData(password);
            sql = "SELECT customers.*, admins.*,fotoprofil.*" +
                "FROM customers" +
                " LEFT JOIN admins  ON customers.verifikator = admins.username" +
                " LEFT JOIN fotoprofil ON customers.fotoprofil_id = fotoprofil.id where email  = '" + cekEmail + "' and customers.pass = '" + cekPass +"'";
       
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            Customer userLogin = new Customer();
            if (hasil.Read() == true)
            {
                userLogin.Email = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                userLogin.Nama = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                userLogin.Alamat = IsaAesCrypt.DecryptedData(hasil.GetValue(2).ToString());
                userLogin.NoTelp = IsaAesCrypt.DecryptedData(hasil.GetValue(3).ToString());
                userLogin.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(4).ToString());
                userLogin.Saldo = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString()));

                FotoProfil foto = new FotoProfil(int.Parse(hasil.GetValue(10).ToString()), null);
                userLogin.fotoProfil = foto;

                if(hasil.GetValue(7).ToString()!= "")
                {
                    Admin e = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(8).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(9).ToString()));
                    userLogin.Verifikator = e;
                }
                hasil.Close();
                return userLogin;
            }
            else
            {
                return null;
            }
        }

        public static void TambahData(Customer customer)
        {
            try
            {
                Koneksi kon = new Koneksi();
                string customerEmail = IsaAesCrypt.EncryptedData(customer.Email);
                string customerAlamat = IsaAesCrypt.EncryptedData(customer.Alamat);
                string customerNama = IsaAesCrypt.EncryptedData(customer.Nama);
                string customerNotelp = IsaAesCrypt.EncryptedData(customer.NoTelp);
                string customerPass = IsaAesCrypt.EncryptedData(customer.Password);
                string customerSaldo = IsaAesCrypt.EncryptedData("0");

                string perintah = "insert into customers (email, nama, alamat, notelp, pass, saldo, fotoprofil_id) values ('" + customerEmail + "', '" + customerNama + "', '" +
                    customerAlamat + "', '" + customerNotelp + "', '" + customerPass + "', '" + customerSaldo + "' , '" + customer.FotoProfil.Id + "');";

                int hasil = Koneksi.JalankanPerintahNonQuery(perintah, kon);
            }
            catch (Exception ex)
            {
                //tampilkan pesan kesalahan
                throw new Exception(ex.Message);
            }
        }
        public static Customer AmbilData(string kolom, string nilai)
        {
            string cekNilai = IsaAesCrypt.EncryptedData(nilai);
            string sql = "SELECT customers.*, admins.*,fotoprofil.*" +
                "FROM customers" +
                " LEFT JOIN admins  ON customers.verifikator = admins.username" +
                " LEFT JOIN fotoprofil ON customers.fotoprofil_id = fotoprofil.id where  " + kolom + " = '" + cekNilai + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                Customer c = new Customer();
                
                c.Email = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                c.Nama = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                c.Alamat = IsaAesCrypt.DecryptedData(hasil.GetValue(2).ToString());
                c.NoTelp = IsaAesCrypt.DecryptedData(hasil.GetValue(3).ToString());
                c.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(4).ToString());
                c.Saldo = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString()));
                FotoProfil foto = new FotoProfil(int.Parse(hasil.GetValue(10).ToString()), null);
                c.fotoProfil = foto;
                if (hasil.GetValue(7).ToString() != "")
                {
                    Admin e = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(8).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(9).ToString()));
                    c.Verifikator = e;
                }

                return c;
            }
            else
            {
                return null;
            }
        }
        public static List<Customer> BacaData(string kolom = "", string nilai = "")
        {
            string sql = "";
            
            if (kolom == "")
            {
                sql = "SELECT customers.*, admins.*,fotoprofil.*" +
                "FROM customers" +
                " LEFT JOIN admins  ON customers.verifikator = admins.username" +
                " LEFT JOIN fotoprofil ON customers.fotoprofil_id = fotoprofil.id";
            }
            else if (nilai == "") 
            {
                sql = "SELECT customers.*, admins.*,fotoprofil.*" +
                "FROM customers" +
                " LEFT JOIN admins  ON customers.verifikator = admins.username" +
                " LEFT JOIN fotoprofil ON customers.fotoprofil_id = fotoprofil.id where " + kolom + " = '" + nilai + "'";
            }
            else
            {
                string cekNilai = IsaAesCrypt.EncryptedData(nilai);
                sql = "SELECT customers.*, admins.*,fotoprofil.*" +
                "FROM customers" +
                " LEFT JOIN admins  ON customers.verifikator = admins.username" +
                " LEFT JOIN fotoprofil ON customers.fotoprofil_id = fotoprofil.id where " + kolom + " = '" + cekNilai + "'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Customer> listData = new List<Customer>();
            while (hasil.Read() == true)
            {
                Customer input = new Customer();
                input.Email = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                input.Nama = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                input.Alamat = IsaAesCrypt.DecryptedData(hasil.GetValue(2).ToString());
                input.NoTelp = IsaAesCrypt.DecryptedData(hasil.GetValue(3).ToString());
                input.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(4).ToString());
                input.Saldo = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString()));

                FotoProfil foto = new FotoProfil(int.Parse(hasil.GetValue(10).ToString()), null);
                input.fotoProfil = foto;

                if (hasil.GetValue(7).ToString() != "")
                {
                    Admin e = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(8).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(9).ToString()));
                    input.Verifikator = e;
                }
                listData.Add(input);
            }
            return listData;
        }

        public void KurangiSaldo(Customer c, double nominal, Koneksi k)
        {
            //Koneksi kon = new Koneksi();
            c.Saldo -= nominal;
            string updateSaldo = IsaAesCrypt.EncryptedData(c.Saldo.ToString());
            string cekEmail = IsaAesCrypt.EncryptedData(c.Email);
            string sql = "update customers set saldo = '" + updateSaldo + "' where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, k);
        }
        public void TambahSaldo(Customer c, double nominal, Koneksi k )
        {
            //Koneksi kon = new Koneksi();
            c.Saldo += nominal;
            string updateSaldo = IsaAesCrypt.EncryptedData(c.Saldo.ToString());
            string cekEmail = IsaAesCrypt.EncryptedData(c.Email);
            string sql = "update customers set saldo = '" + updateSaldo + "' where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, k);
        }
        public static void TopUpSaldo(Customer c, double nominal)
        {
            Koneksi kon = new Koneksi();
            c.Saldo += nominal;
            string updateSaldo = IsaAesCrypt.EncryptedData(c.Saldo.ToString());
            string cekEmail = IsaAesCrypt.EncryptedData(c.Email);
            string sql = "update customers set saldo = '" + updateSaldo + "' where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }

        public static void UbahProfil(Customer p)
        {
            Koneksi kon = new Koneksi();
            string cekEmail = IsaAesCrypt.EncryptedData(p.Email);
            string sql = "update customers set fotoprofil_id = '" + p.FotoProfil.Id + "'  where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        public static void UbahDataVerifikasi(Customer cust, Admin adm)
        {
            Koneksi kon = new Koneksi();
            string admin = IsaAesCrypt.EncryptedData(adm.Username);
            string cekEmail = IsaAesCrypt.EncryptedData(cust.Email);
            //string sql = "update customers set fotoprofil_id = '" + p.FotoProfil + "' where email = '" + p.Email + "'";
            string sql = "update customers set verifikator = '" + admin + "'  where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        #endregion
    }
}
