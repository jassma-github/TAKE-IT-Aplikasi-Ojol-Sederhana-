using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Transactions;
using System.Drawing;
using System.IO;

namespace ISA_LIB
{
    public class Pesanan
    {
        #region Data Member
        private string kodeBooking;
        private Customer pemesan;
        private Driver penerima;
        private DateTime waktuPesan;
        private string waktuSelesai;
        private string lokasiAwal;
        private string lokasiTujuan;
        private double harga;
        private string status;
        #endregion

        #region Constructor
        public Pesanan(string kodeBooking, Customer pemesan, Driver penerima, DateTime waktuPesan, string waktuSelesai ,string lokasiAwal, string lokasiTujuan, double harga, string status)
        {
            this.KodeBooking = kodeBooking;
            this.Pemesan = pemesan;
            this.Penerima = penerima;
            this.WaktuPesan = waktuPesan;
            this.WaktuSelesai = waktuSelesai;
            this.LokasiAwal = lokasiAwal;
            this.LokasiTujuan = lokasiTujuan;
            this.Harga = harga;
            this.Status = status;
        }
        public Pesanan()
        {
            this.KodeBooking = "";
            this.Pemesan = new Customer();
            this.Penerima = new Driver();
            this.WaktuPesan = DateTime.Now;
            this.WaktuSelesai = "";
            this.LokasiAwal = "";
            this.LokasiTujuan = "";
            this.Harga = 13000;
            this.Status = "";
        }
        #endregion

        #region Properties

        public string KodeBooking { get => kodeBooking; set => kodeBooking = value; }
        public Customer Pemesan { get => pemesan; set => pemesan = value; }
        public Driver Penerima { get => penerima; set => penerima = value; }
        public DateTime WaktuPesan { get => waktuPesan; set => waktuPesan = value; }
        public string WaktuSelesai { get => waktuSelesai; set => waktuSelesai = value; }
        public string LokasiAwal { get => lokasiAwal; set => lokasiAwal = value; }
        public string LokasiTujuan { get => lokasiTujuan; set => lokasiTujuan = value; }
        public double Harga { get => harga; set => harga = value; }
        public string Status { get => status; set => status = value; }
       
        #endregion

        #region Method
        public static Pesanan AmbilData(string kolom,string nilai)
        {
            string cekNilai = IsaAesCrypt.EncryptedData(nilai);
            string sql = "";
            if (kolom != "kode_booking" && kolom != "waktu_mulai" && kolom != "waktu_selesai" && kolom != "status")
            {
                sql = "SELECT pesanans.*,customers.*, admins_customers.*,fotoprofil_customers.* , drivers.*, admins_drivers.*, fotoprofil_drivers.* FROM pesanans " +
                " LEFT JOIN customers ON pesanans.users_email = customers.email" +
                " LEFT JOIN admins AS admins_customers ON customers.verifikator = admins_customers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_customers ON customers.fotoprofil_id = fotoprofil_customers.id " +
                " LEFT JOIN drivers ON pesanans.drivers_email = drivers.email" +
                " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id" +

                " WHERE " + kolom + " = '" + cekNilai + "'";
            }
            else
            {
                sql = "SELECT pesanans.*,customers.*, admins_customers.*,fotoprofil_customers.* , drivers.*, admins_drivers.*, fotoprofil_drivers.* FROM pesanans " +
                " LEFT JOIN customers ON pesanans.users_email = customers.email" +
                " LEFT JOIN admins AS admins_customers ON customers.verifikator = admins_customers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_customers ON customers.fotoprofil_id = fotoprofil_customers.id " +
                " LEFT JOIN drivers ON pesanans.drivers_email = drivers.email" +
                " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id" +
                " WHERE " + kolom + " = '" + nilai + "'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                Pesanan input = new Pesanan();
                input.KodeBooking = hasil.GetValue(0).ToString();
                FotoProfil profilCustomer = new FotoProfil(int.Parse(hasil.GetValue(19).ToString()), null);
                Admin verifikatorCustomer = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(17).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(18).ToString()));
                Customer pemesan = new Customer
                (
                    IsaAesCrypt.DecryptedData(hasil.GetValue(9).ToString()),
                    IsaAesCrypt.DecryptedData(hasil.GetValue(10).ToString()),
                    IsaAesCrypt.DecryptedData(hasil.GetValue(12).ToString()),
                    IsaAesCrypt.DecryptedData(hasil.GetValue(12).ToString()),
                    IsaAesCrypt.DecryptedData(hasil.GetValue(13).ToString()),
                    double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(14).ToString())),
                    profilCustomer, verifikatorCustomer
                );
                input.Pemesan = pemesan;
                if (hasil.GetValue(2).ToString() != "")
                {
                    FotoProfil profilDriver = new FotoProfil(int.Parse(hasil.GetValue(33).ToString()), null);
                    Admin verifikatorDriver = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(31).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(32).ToString()));
                    Driver penerima = new Driver
                    (
                        IsaAesCrypt.DecryptedData(hasil.GetValue(21).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(22).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(23).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(24).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(25).ToString()),
                        double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(26).ToString())),
                        verifikatorDriver,
                        IsaAesCrypt.DecryptedData(hasil.GetValue(28).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(29).ToString()),
                        profilDriver
                    );
                    input.Penerima = penerima;
                }
                else
                {
                    input.Penerima = new Driver();

                }
                input.WaktuPesan = DateTime.Parse(hasil.GetValue(3).ToString());
                if (hasil.GetValue(4).ToString() != "")
                {
                    input.WaktuSelesai = (hasil.GetValue(4).ToString());
                }
                input.LokasiAwal = IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString());
                input.LokasiTujuan = IsaAesCrypt.DecryptedData(hasil.GetValue(6).ToString());
                input.Harga = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(7).ToString()));
                input.Status = hasil.GetValue(8).ToString();

                return input;
            }
            else
            {
                return null;
            }
        }
        public static string GenerateKodeBooking()
        {
            // yyyy/mm/dd/4digitnourut
            string sql = "SELECT kode_booking FROM pesanans WHERE DATE(waktu_mulai) = DATE(CURRENT_DATE) ORDER BY kode_booking DESC LIMIT 1";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            string kodebooking = "";
            if (hasil.Read()) //sudah pernah ada nota di hari ini
            {
                string kodebookingSebelumnya = hasil.GetString(0);
                int noUrutTerakhir = int.Parse(kodebookingSebelumnya.Substring(kodebookingSebelumnya.Length - 4));
                kodebooking = DateTime.Now.ToString("yyyyMMdd") + (noUrutTerakhir + 1).ToString("D4");
            }
            else //belum ada nota hari ini di database
            {
                kodebooking = DateTime.Now.ToString("yyyyMMdd") + "0001";
            }
            return kodebooking;
        }
        public static void UbahStatusPesanans(string pkodebooking, string pStatus, Driver d)
        {
            Koneksi kon = new Koneksi();
            string cekEmail = IsaAesCrypt.EncryptedData(d.Email);

            string sql = "update pesanans set status='" + pStatus + "' , drivers_email = '" + cekEmail + "' where kode_booking = '" + pkodebooking + "';";
            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }

        public static void PesananSelesai(Pesanan pesan, Driver driver )
        {
            using (TransactionScope t = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    string sql = "update pesanans set status= 'selesai' , waktu_selesai = now() where kode_booking = '" + pesan.KodeBooking + "';";
                    int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
                    if (hasil > 0)
                    {
                        pesan.Penerima.TambahSaldo(pesan.Penerima, pesan.Harga * 0.8, kon);
                    }
                    t.Complete();
                }
                catch (Exception ex)
                {   //jika gagal, gagalkan semua rangkaian perintah
                    t.Dispose();
                    //tampilkan pesan kesalahan
                    throw new Exception(ex.Message);
                }
            }
}
        public static void TambahPesanan(Pesanan p)
        {
            using (TransactionScope t = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    string addPemesan = IsaAesCrypt.EncryptedData(p.Pemesan.Email);
                    string addLokasiAwal = IsaAesCrypt.EncryptedData(p.LokasiAwal);
                    string addLokasiTujuan = IsaAesCrypt.EncryptedData(p.LokasiTujuan);
                    string addHarga = IsaAesCrypt.EncryptedData(p.Harga.ToString());
                    string sql = "insert into pesanans (kode_booking, users_email, waktu_mulai, lokasi_awal, lokasi_tujuan, harga, status)" +
                        " values ('" + p.KodeBooking + "', '" + addPemesan+ "', now() , '" + addLokasiAwal + "', '" + addLokasiTujuan + "', '" + addHarga + "', 'menunggu driver') ;";
                    int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
                    if (hasil > 0)
                    {
                        p.pemesan.KurangiSaldo(p.pemesan, p.Harga, kon);
                    }
                    t.Complete();
                }
                catch (Exception ex)
                {   //jika gagal, gagalkan semua rangkaian perintah
                    t.Dispose();
                    //tampilkan pesan kesalahan
                    throw new Exception(ex.Message);
                }
            }
        }

        public static List<Pesanan> BacaData(string kolom = "", string nilai = "")
        {
            string sql;
            List<Pesanan> listPesanan = new List<Pesanan>();
            if (nilai != null || nilai !="")
            {
                string cekNilai = IsaAesCrypt.EncryptedData(nilai);
                if (kolom == "") //JIKA TANPA FILTER:
                {
                    sql = "SELECT pesanans.*,customers.*, admins_customers.*,fotoprofil_customers.* , drivers.*, admins_drivers.*, fotoprofil_drivers.* FROM pesanans " +
                        " LEFT JOIN customers ON pesanans.users_email = customers.email" +
                        " LEFT JOIN admins AS admins_customers ON customers.verifikator = admins_customers.username" +
                        " LEFT JOIN fotoprofil AS fotoprofil_customers ON customers.fotoprofil_id = fotoprofil_customers.id " +
                        " LEFT JOIN drivers ON pesanans.drivers_email = drivers.email" +
                        " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                        " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id ";
                }
                else //JIKA ADA FILTER DARI USER:
                {
                    if (kolom != "kode_booking" && kolom != "waktu_mulai" && kolom != "waktu_selesai" && kolom != "status")
                    {
                        sql = "SELECT pesanans.*,customers.*, admins_customers.*,fotoprofil_customers.* , drivers.*, admins_drivers.*, fotoprofil_drivers.* FROM pesanans " +
                        " LEFT JOIN customers ON pesanans.users_email = customers.email" +
                        " LEFT JOIN admins AS admins_customers ON customers.verifikator = admins_customers.username" +
                        " LEFT JOIN fotoprofil AS fotoprofil_customers ON customers.fotoprofil_id = fotoprofil_customers.id " +
                        " LEFT JOIN drivers ON pesanans.drivers_email = drivers.email" +
                        " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                        " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id" +

                        " WHERE " + kolom + " = '" + cekNilai + "'";
                    }
                    else
                    {
                        sql = "SELECT pesanans.*,customers.*, admins_customers.*,fotoprofil_customers.* , drivers.*, admins_drivers.*, fotoprofil_drivers.* FROM pesanans " +
                        " LEFT JOIN customers ON pesanans.users_email = customers.email" +
                        " LEFT JOIN admins AS admins_customers ON customers.verifikator = admins_customers.username" +
                        " LEFT JOIN fotoprofil AS fotoprofil_customers ON customers.fotoprofil_id = fotoprofil_customers.id " +
                        " LEFT JOIN drivers ON pesanans.drivers_email = drivers.email" +
                        " LEFT JOIN admins AS admins_drivers ON drivers.verifikator = admins_drivers.username" +
                        " LEFT JOIN fotoprofil AS fotoprofil_drivers ON drivers.fotoprofil_id = fotoprofil_drivers.id" +
                        " WHERE " + kolom + " = '" + nilai + "'";
                    }
                }
                //STEP 2. panggil jalankanperintahselect
                MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
                while (hasil.Read() == true)
                {
                    Pesanan input = new Pesanan();
                    input.KodeBooking = hasil.GetValue(0).ToString();
                    FotoProfil profilCustomer = new FotoProfil(int.Parse(hasil.GetValue(19).ToString()), null);
                    Admin verifikatorCustomer = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(17).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(18).ToString()));
                    Customer pemesan = new Customer
                    (
                        IsaAesCrypt.DecryptedData(hasil.GetValue(9).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(10).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(12).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(12).ToString()),
                        IsaAesCrypt.DecryptedData(hasil.GetValue(13).ToString()),
                        double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(14).ToString())),
                        profilCustomer,verifikatorCustomer
                    );
                    input.Pemesan = pemesan;
                    if (hasil.GetValue(2).ToString() != "")
                    {
                        FotoProfil profilDriver = new FotoProfil(int.Parse(hasil.GetValue(33).ToString()), null);
                        Admin verifikatorDriver = new Admin(IsaAesCrypt.DecryptedData(hasil.GetValue(31).ToString()), IsaAesCrypt.DecryptedData(hasil.GetValue(32).ToString()));
                        Driver penerima = new Driver
                        (
                            IsaAesCrypt.DecryptedData(hasil.GetValue(21).ToString()),
                            IsaAesCrypt.DecryptedData(hasil.GetValue(22).ToString()),
                            IsaAesCrypt.DecryptedData(hasil.GetValue(23).ToString()),
                            IsaAesCrypt.DecryptedData(hasil.GetValue(24).ToString()),
                            IsaAesCrypt.DecryptedData(hasil.GetValue(25).ToString()),
                            double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(26).ToString())),
                            verifikatorDriver,
                            IsaAesCrypt.DecryptedData(hasil.GetValue(28).ToString()),
                            IsaAesCrypt.DecryptedData(hasil.GetValue(29).ToString()),
                            profilDriver
                        );
                        input.Penerima = penerima;
                    }
                    else
                    {
                        input.Penerima = new Driver();

                    }
                    input.WaktuPesan = DateTime.Parse(hasil.GetValue(3).ToString());
                    if (hasil.GetValue(4).ToString() != "")
                    {
                        input.WaktuSelesai = (hasil.GetValue(4).ToString());
                    }
                    input.LokasiAwal = IsaAesCrypt.DecryptedData(hasil.GetValue(5).ToString());
                    input.LokasiTujuan = IsaAesCrypt.DecryptedData(hasil.GetValue(6).ToString());
                    input.Harga = double.Parse(IsaAesCrypt.DecryptedData(hasil.GetValue(7).ToString()));
                    input.Status = hasil.GetValue(8).ToString();
                    listPesanan.Add(input);
                }
                hasil.Close();
                return listPesanan;
            }
            else
            {
                return listPesanan;
            }
        }
        public static void CetakPesanan(Pesanan pesan, string alamatFile, Font tipeFont)
        {
            StreamWriter fileCetak = new StreamWriter(alamatFile);

            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("------------------------- BUKTI PEMESANAN -------------------------");
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("Kode Pesanan \t\t : " + pesan.KodeBooking);
            fileCetak.WriteLine("");
            fileCetak.WriteLine("Nama Pemesan \t\t : " + pesan.Pemesan.Nama);
            fileCetak.WriteLine("Nama Driver \t\t :" + pesan.Penerima.Nama);
            fileCetak.WriteLine("Waktu pemesanan\t\t : " + pesan.WaktuPesan.ToString("dd-MM-yyyy HH:mm:ss"));
            fileCetak.WriteLine("Waktu pemesanan selesai\t : " + pesan.WaktuSelesai);
            fileCetak.WriteLine("Lokasi Jemput \t\t : " + pesan.LokasiAwal);
            fileCetak.WriteLine("Lokasi Antar \t\t : " + pesan.LokasiTujuan);
            fileCetak.WriteLine("Harga \t\t\t : " + pesan.Harga.ToString());
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("Dicetak tanggal = " + DateTime.Now.ToString());
            fileCetak.WriteLine("===============================================");
            fileCetak.Close();

            CustomPrint p = new CustomPrint(tipeFont, alamatFile, 20, 10, 10, 10);
            p.Print();
        }
        #endregion
    }
}
