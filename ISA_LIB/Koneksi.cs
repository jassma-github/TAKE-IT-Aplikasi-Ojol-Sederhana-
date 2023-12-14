using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ISA_LIB
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        #region Properties
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region Constructors
        public Koneksi(string pServer, string pDB, string pUID, string pPWD)
        {
            string c = "server=" + pServer + ";database=" + pDB +
                        ";uid=" + pUID + ";password=" + pPWD + "Pooling = true;Min Pool Size=5;Max Pool Size=100;Connect Timeout = 15 ;";

            //ciptakan objek
            KoneksiDB = new MySqlConnection();
            //isi connectionstring-nya
            KoneksiDB.ConnectionString = c;
            Connect(); //buka jembatannya
        }
        //default constructor
        #endregion

        #region Methods
        public Koneksi()
        {
            //buka konfigurasi app.config
            Configuration myconf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //ambil section usersettings yg otomatis dibuat berdasar file .settings
            ConfigurationSectionGroup userSettings = myconf.SectionGroups["userSettings"];

            //ambil bagian setting sijualbeli.db
            var settingsSection = userSettings.Sections["ISA_TimSukses.db"] as ClientSettingsSection;

            //ambil tiap variable setting
            string pServer = settingsSection.Settings.Get("dbServer").Value.ValueXml.InnerText;
            string pDB = settingsSection.Settings.Get("dbName").Value.ValueXml.InnerText;
            string pUID = settingsSection.Settings.Get("dbUserID").Value.ValueXml.InnerText;
            string pPWD = settingsSection.Settings.Get("dbPassword").Value.ValueXml.InnerText;

            string c = "server=" + pServer + ";database=" +
                pDB + ";uid=" + pUID + ";password=" + pPWD;

            //ciptakan objek
            KoneksiDB = new MySqlConnection();
            //isi connectionstring-nya
            KoneksiDB.ConnectionString = c;
            Connect(); //buka jembatannya
        }



        //method untuk membuka jembatan database
        private void Connect()
        {   //cek jembatan sedang buka/tutup
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close(); //kalau sdg buka, tutup jembatannya
            }

            KoneksiDB.Open();

            //buka jembatan database
        }

        //buat method buat perintah select, nanti tinggal dipanggil sama class lain, biar terpusat
        // pake static method karena tergantung sama class, bkn object, classnya bnyk
        public static MySqlDataReader JalankanPerintahQuery(string pSQL)
        {
            //tinggal panggil default constructors
            Koneksi k = new Koneksi();
            //perintah selectnya
            MySqlCommand cmd = new MySqlCommand(pSQL, k.KoneksiDB);
            //tempat buat taruh hasil select nya
            MySqlDataReader hasil = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           
            return hasil;
        }
        public static void JalankanPerintahNonQuery(string pSQL)
        {//UNTUK MENJALANKAN PERINTAH INSERT UPDATE ATAU DELETE
            //tinggal panggil default constructors
            Koneksi k = new Koneksi();
            //perintah selectnya
            MySqlCommand cmd = new MySqlCommand(pSQL, k.KoneksiDB);
            //EXECUTENONQUERY UNTUK MENJALANKAN IUD
            cmd.ExecuteNonQuery();

        }
        public static int JalankanPerintahNonQuery(string pSQL, Koneksi k)
        //Koneksi k --> dikirim via parameter, agar semua transaction dapat dijalankan pada koneksi yang sama
        {   //UNTUK MENJALANKAN PERINTAH INSERT UPDATE ATAU DELETE
            //Koneksi k = new Koneksi(); 

            MySqlCommand cmd = new MySqlCommand(pSQL, k.KoneksiDB);
            //EXECUTENONQUERY UNTUK MENJALANKAN IUD
            int hasil = cmd.ExecuteNonQuery();
           
            return hasil;
        }

        #endregion
    }
}