using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISA_LIB;

namespace ISA_TimSukses
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
        }

        private void dataGridViewRiwayatPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "diterima")
                {
                    if (e.ColumnIndex == dataGridViewRiwayatPemesanan.Columns["Posisi Driver"].Index && e.RowIndex >= 0)
                    {
                        Pesanan pesanan = Pesanan.AmbilData("kode_booking", dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["KodeBooking"].Value.ToString());
                        DialogResult result = MessageBox.Show("Apakah driver sudah sampai di lokasi penjemputan " + pesanan.LokasiAwal + "?", "Konfirmasi", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            Driver.UbahLokasi(pesanan.Penerima, pesanan.LokasiAwal);
                        }
                    }
                }
                else if (dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "perjalanan")
                {
                    if (e.ColumnIndex == dataGridViewRiwayatPemesanan.Columns["Tiba di Tujuan"].Index && e.RowIndex >= 0)
                    {
                        Pesanan pesanan = Pesanan.AmbilData("kode_booking", dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["KodeBooking"].Value.ToString());
                        DialogResult result = MessageBox.Show("Apakah anda sudah sampai di lokasi tujuan : " + pesanan.LokasiTujuan + "?", "Konfirmasi", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            Driver.UbahLokasi(pesanan.Penerima, pesanan.LokasiTujuan);
                        }
                    }
                }
                else if (dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "selesai")
                {
                    if (e.ColumnIndex == dataGridViewRiwayatPemesanan.Columns["Bukti Transaksi"].Index && e.RowIndex >= 0)
                    {
                        Pesanan pesanan = Pesanan.AmbilData("kode_booking", dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["KodeBooking"].Value.ToString());
                        string namaFile = "TakeIt_Invoice_" + pesanan.KodeBooking;
                        Pesanan.CetakPesanan(pesanan, namaFile, new Font("Calibri", 12));
                    }
                }
                else if (dataGridViewRiwayatPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "ditolak")
                {
                    if (e.ColumnIndex == dataGridViewRiwayatPemesanan.Columns["Bukti Transaksi"].Index && e.RowIndex >= 0)
                    {
                        MessageBox.Show("Invoice untuk pesanan yang ditolak tidak tersedia");
                    }
                }
                FormHistory_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FormatDataGrid()
        {
            dataGridViewRiwayatPemesanan.Columns.Clear();

            dataGridViewRiwayatPemesanan.Columns.Add("KodeBooking", "Kode Booking");
            dataGridViewRiwayatPemesanan.Columns.Add("Pemesan", "Pemesan");
            dataGridViewRiwayatPemesanan.Columns.Add("WaktuPesan", "Waktu Pesan");
            dataGridViewRiwayatPemesanan.Columns.Add("WaktuSelesai", "Waktu Selesai");
            dataGridViewRiwayatPemesanan.Columns.Add("LokasiAwal", "Lokasi Awal");
            dataGridViewRiwayatPemesanan.Columns.Add("LokasiTujuan", "Lokasi Tujuan");
            dataGridViewRiwayatPemesanan.Columns.Add("Driver", "Driver");
            dataGridViewRiwayatPemesanan.Columns.Add("LokasiDriver", "Lokasi Driver Saat Ini");
            dataGridViewRiwayatPemesanan.Columns.Add("Harga", "Harga");
            dataGridViewRiwayatPemesanan.Columns.Add("Status", "Status");

            for (int i = 0; i < dataGridViewRiwayatPemesanan.Columns.Count; i++)
            {
                this.dataGridViewRiwayatPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewRiwayatPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            }
            dataGridViewRiwayatPemesanan.AllowUserToAddRows = false;
            dataGridViewRiwayatPemesanan.ReadOnly = true;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        FormUtama formUtama;
        List<Pesanan> listRiwayatPesanan = new List<Pesanan>();
        private void FormHistory_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            formUtama.listPesananAktifCustomer.Clear();
            if(radioButtonPesananAktif.Checked)
            {
                foreach (Pesanan p in Pesanan.BacaData("users_email", formUtama.customerLogin.Email))
                {
                    if (p.Status != "ditolak" && p.Status != "selesai")
                    {
                        formUtama.listPesananAktifCustomer.Add(p);
                        labelStatusAktif.Text = p.KodeBooking.ToString();
                    }
                }
                FormatDataGrid();
                if (formUtama.listPesananAktifCustomer.Count > 0)
                {
                    foreach (Pesanan p in formUtama.listPesananAktifCustomer)
                    {
                        dataGridViewRiwayatPemesanan.Rows.Add(p.KodeBooking, p.Pemesan.Nama, p.WaktuPesan, p.WaktuSelesai, p.LokasiAwal, p.LokasiTujuan, p.Penerima.Nama, p.Penerima.Lokasi, p.Harga, p.Status);
                        if (dataGridViewRiwayatPemesanan.Columns.Contains("Posisi Driver") == false && p.Status == "diterima")
                        {
                            if (p.LokasiAwal != p.Penerima.Lokasi)
                            {
                                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                                button.Text = "Driver Telah Tiba";
                                button.Name = "Posisi Driver";
                                button.UseColumnTextForButtonValue = true;
                                dataGridViewRiwayatPemesanan.Columns.Add(button);
                            }
                        }
                        else if (dataGridViewRiwayatPemesanan.Columns.Contains("Tiba di Tujuan") == false && p.Status == "perjalanan")
                        {
                            if (p.LokasiTujuan != p.Penerima.Lokasi)
                            {
                                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                                button.Text = "Sudah Sampai Tujuan";
                                button.Name = "Tiba di Tujuan";
                                button.UseColumnTextForButtonValue = true;
                                dataGridViewRiwayatPemesanan.Columns.Add(button);
                            }
                        }
                    }
                    for (int i = 0; i < dataGridViewRiwayatPemesanan.Columns.Count; i++)
                    {
                        this.dataGridViewRiwayatPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dataGridViewRiwayatPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                    }
                }
                else
                {
                    dataGridViewRiwayatPemesanan.DataSource = null;
                }
            }
            else if(radioButtonRiwayat.Checked)
            {
                listRiwayatPesanan.Clear();
                foreach (Pesanan p in Pesanan.BacaData("users_email", formUtama.customerLogin.Email))
                {
                    if (p.Status == "ditolak" || p.Status == "selesai")
                    {
                        listRiwayatPesanan.Add(p);
                    }
                }
                FormatDataGrid();
                if (listRiwayatPesanan.Count > 0)
                {
                    foreach (Pesanan p in listRiwayatPesanan)
                    {
                        dataGridViewRiwayatPemesanan.Rows.Add(p.KodeBooking, p.Pemesan.Nama, p.WaktuPesan, p.WaktuSelesai, p.LokasiAwal, p.LokasiTujuan, p.Penerima.Nama, p.Penerima.Lokasi, p.Harga, p.Status);
                        if (dataGridViewRiwayatPemesanan.Columns.Contains("Bukti Transaksi") == false && p.Status == "selesai")
                        {
                            DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                            colUpdate.Text = "Unduh Bukti";
                            colUpdate.Name = "Bukti Transaksi";
                            colUpdate.UseColumnTextForButtonValue = true;
                            dataGridViewRiwayatPemesanan.Columns.Add(colUpdate);
                        }
                    }
                    for (int i = 0; i < dataGridViewRiwayatPemesanan.Columns.Count; i++)
                    {
                        this.dataGridViewRiwayatPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dataGridViewRiwayatPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                    }
                }
            }
        }

        private void dataGridViewRiwayatPemesanan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void radioButtonRiwayat_CheckedChanged(object sender, EventArgs e)
        {
            FormHistory_Load(this, e);
        }

        private void radioButtonPesananAktif_CheckedChanged(object sender, EventArgs e)
        {
            FormHistory_Load(this, e);
        }
    }
}
