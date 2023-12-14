using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ISA_LIB
{
    public class Driver
    {
        #region Data Member
        private string email;
        private string nama;
        private string alamat;
        private string noTelp;
        private string password;
        private double saldo;
        private Admin verifikator;
        private string lokasi;
        private string platNomor;
        private FotoProfil fotoProfil;

        #endregion

        #region Constructor
        public Driver(string email, string nama, string alamat, string noTelp, string password, double saldo,  Admin verifikator, string lokasi, string platNomor, FotoProfil fotoProfil)
        {
            this.Email = email;
            this.Nama = nama;
            this.Alamat = alamat;
            this.NoTelp = noTelp;
            this.Password = password;
            this.Saldo = saldo;
            this.Verifikator = verifikator;
            this.Lokasi = lokasi;
            this.PlatNomor = platNomor;
            this.FotoProfil = fotoProfil;
        }
        public Driver()
        {
            this.Email = " ";
            this.Nama = " ";
            this.Alamat = " ";
            this.NoTelp = "xxxxxxxxxxx";
            this.Password = "xxxxxxxx";
            this.Saldo = 0;
            this.Verifikator = new Admin();
            this.Lokasi = " ";
            this.PlatNomor = " ";
            this.FotoProfil = new FotoProfil();
        }
        #endregion

        #region Properties

        public string Email
        {
            get => email;
            set
            {
                if (value != "")
                {
                    email = value;
                }
                else
                {
                    throw new Exception("Email tidak boleh kosong !");
                }
            }
        }
        public string Nama
        {
            get => nama; set
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
                if (value != "" && value.Length >= 11)
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
                if (value != "" && value.Length == 8)
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
        public Admin Verifikator { get => verifikator; set => verifikator = value; }
        public string Lokasi { get => lokasi; set => lokasi = value; }
        public string PlatNomor { get => platNomor; set
            {
                if (value != "")
                {
                    platNomor = value;
                }
                else
                {
                    throw new Exception("Isi data plat nomor kendaraan anda ! !");
                }
            }
        }
        public FotoProfil FotoProfil { get => fotoProfil; set => fotoProfil = value; }

        #endregion

        #region Method
        public static Driver CekLogin(string username, string password)
        {
           // IsaAesCrypt isa = new IsaAesCrypt();
            string sql = "";
            string cekuser = IsaAesCrypt.EncryptedData(username);
            string cekpass = IsaAesCrypt.EncryptedData(password);
            sql = "SELECT drivers.*, admins_drivers.*,fotoprofil_drivers.*" +
                 "FROM drivers" +
                 " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                 " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id where email  = '" + cekuser + "' and drivers.pass = '" + cekpass + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            Driver d = new Driver();
            if (hasil.Read() == true)
            {
                d.Email = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                d.Nama = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                d.Alamat = IsaAesCrypt.DecryptedData(hasil.GetValue(2).ToString());
                d.NoTelp = IsaAesCrypt.DecryptedData(hasil.GetValue(3).ToString());
                d.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(4).ToString());
                d.Saldo = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString()));
                if (hasil.GetValue(6).ToString() != "")
                {
                    Admin e = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(10).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(11).ToString()));
                    d.Verifikator = e;
                }
                d.Lokasi = IsaAesCrypt.DecryptedData(hasil.GetValue(7).ToString());
                d.PlatNomor = IsaAesCrypt.DecryptedData(hasil.GetValue(8).ToString());

                FotoProfil foto = new FotoProfil(int.Parse(hasil.GetValue(12).ToString()), null);
                d.FotoProfil = foto;

                return d;
            }
            return null;
        }

        public static void TambahData(Driver driver)
        {
            try
            {
                Koneksi kon = new Koneksi();
                // IsaAesCrypt isa = new IsaAesCrypt();
                string driverEmail = IsaAesCrypt.EncryptedData(driver.Email);
                string driverAlamat = IsaAesCrypt.EncryptedData(driver.Alamat);
                string driverNama = IsaAesCrypt.EncryptedData(driver.Nama);
                string driverNotelp = IsaAesCrypt.EncryptedData(driver.NoTelp);
                string driverPass = IsaAesCrypt.EncryptedData(driver.Password);
                string driverSaldo = IsaAesCrypt.EncryptedData("0");
                string driverLokasi = IsaAesCrypt.EncryptedData(driver.Lokasi);
                string driverPlat = IsaAesCrypt.EncryptedData(driver.PlatNomor);
                string perintah = "insert into drivers (email, nama, alamat, notelp, pass, saldo,lokasi, platnomor, fotoprofil_id) values ('" + driverEmail + "', '" + driverNama + "', '" +
                    driverAlamat + "', '" + driverNotelp + "', '" + driverPass + "', '" + driverSaldo + "', '" + driverLokasi + "', '" + driverPlat + "', '" + driver.FotoProfil.Id + "');";
                int hasil = Koneksi.JalankanPerintahNonQuery(perintah, kon);
            }
            catch (Exception ex)
            {
                //tampilkan pesan kesalahan
                throw new Exception(ex.Message);
            }
        }
        public static Driver AmbilData(string kolom, string nilai)
        {
            string ceknilai = IsaAesCrypt.EncryptedData(nilai);
            string sql = "SELECT drivers.*, admins_drivers.*,fotoprofil_drivers.*" +
                "FROM drivers" +
                " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id where " + kolom + " = '" + ceknilai + "'";
            Driver d = new Driver();
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                d.Email = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                d.Nama = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                d.Alamat = IsaAesCrypt.DecryptedData(hasil.GetValue(2).ToString());
                d.NoTelp = IsaAesCrypt.DecryptedData(hasil.GetValue(3).ToString());
                d.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(4).ToString());
                d.Saldo = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString()));
                if (hasil.GetValue(6).ToString() != "")
                {
                    Admin e = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(10).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(11).ToString()));
                    d.Verifikator = e;
                }
                d.Lokasi = IsaAesCrypt.DecryptedData(hasil.GetValue(7).ToString());
                d.PlatNomor = IsaAesCrypt.DecryptedData(hasil.GetValue(8).ToString());

                FotoProfil foto = new FotoProfil(int.Parse(hasil.GetValue(12).ToString()), null);
                d.FotoProfil = foto;
                return d;
            }
            else
            {
                return d;
            }
        }
        public static List<Driver> BacaData(string kolom = "", string nilai = "")
        {
            string sql = "";

            if (kolom == "")
            {
                sql = "SELECT drivers.*, admins_drivers.*,fotoprofil_drivers.*" +
                "FROM drivers" +
                " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id";
            }
            else if (nilai == "")
            {
                sql = "SELECT drivers.*, admins_drivers.*,fotoprofil_drivers.*" +
                "FROM drivers" +
                " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id where " + kolom + " = '" + nilai + "'";
            }
            else
            {
                string cekNilai = IsaAesCrypt.EncryptedData(nilai);
                sql = "SELECT drivers.*, admins_drivers.*,fotoprofil_drivers.*" +
                "FROM drivers" +
                " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id where " + kolom + " = '" + cekNilai + "'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Driver> listData = new List<Driver>();
            while (hasil.Read() == true)
            {
                Driver d = new Driver();
               // IsaAesCrypt isa = new IsaAesCrypt();
                d.Email = IsaAesCrypt.DecryptedData(hasil.GetValue(0).ToString());
                d.Nama = IsaAesCrypt.DecryptedData(hasil.GetValue(1).ToString());
                d.Alamat = IsaAesCrypt.DecryptedData(hasil.GetValue(2).ToString());
                d.NoTelp = IsaAesCrypt.DecryptedData(hasil.GetValue(3).ToString());
                d.Password = IsaAesCrypt.DecryptedData(hasil.GetValue(4).ToString());
                d.Saldo = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString()));
                if (hasil.GetValue(6).ToString() != "")
                {
                    Admin e = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(10).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(11).ToString()));
                    d.Verifikator = e;
                }
                d.Lokasi = IsaAesCrypt.DecryptedData(hasil.GetValue(7).ToString());
                d.PlatNomor = IsaAesCrypt.DecryptedData(hasil.GetValue(8).ToString());

                FotoProfil foto = new FotoProfil(int.Parse(hasil.GetValue(12).ToString()), null);
                d.FotoProfil = foto;
                listData.Add(d);
            }
            return listData;
        }

        public void KurangiSaldo(Driver d, double nominal, Koneksi k)
        {
            //Koneksi kon = new Koneksi();

            d.Saldo -= nominal;
            string updateSaldo = IsaAesCrypt.EncryptedData(d.Saldo.ToString());
            string cekEmail = IsaAesCrypt.EncryptedData(d.Email);
            
            string sql = "update drivers set saldo = '" + updateSaldo + "' where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, k);
        }
        public void TambahSaldo(Driver d, double nominal, Koneksi k)
        {
            //Koneksi kon = new Koneksi();
            d.Saldo += nominal;
            string updateSaldo = IsaAesCrypt.EncryptedData(d.Saldo.ToString());
            string cekEmail = IsaAesCrypt.EncryptedData(d.Email);

            string sql = "update drivers set saldo = '" + updateSaldo + "' where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, k);
        }
        public static void UbahProfil(Driver p)
        {
            Koneksi kon = new Koneksi();
            string cekEmail = IsaAesCrypt.EncryptedData(p.Email);
            string sql = "update drivers set fotoprofil_id = '" + p.FotoProfil.Id + "'  where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        public static void UbahLokasi(Driver d, string lokasiDriver)
        {
            Koneksi kon = new Koneksi();
            string cekEmail = IsaAesCrypt.EncryptedData(d.Email);
            string updateLokasiDriver = IsaAesCrypt.EncryptedData(lokasiDriver);
            string sql = "update drivers set lokasi = '" + updateLokasiDriver + "'  where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        public static void UbahDataVerifikasi(Driver driver, Admin adm)
        {
            Koneksi kon = new Koneksi();
            string admin = IsaAesCrypt.EncryptedData(adm.Username);
            string cekEmail = IsaAesCrypt.EncryptedData(driver.Email);
            string sql = "update drivers set verifikator = '" + admin + "'  where email = '" + cekEmail + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        #endregion
    }
}
