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
    public partial class FormPemesananDriver : Form
    {
        public FormPemesananDriver()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FormatDataGrid()
        {
            dataGridViewDaftarPemesanan.Columns.Clear();
            dataGridViewDaftarPemesanan.Columns.Add("KodeBooking", "Kode Booking");
            dataGridViewDaftarPemesanan.Columns.Add("Pemesan", "Pemesan");
            dataGridViewDaftarPemesanan.Columns.Add("WaktuPesan", "Waktu Pesan");
            dataGridViewDaftarPemesanan.Columns.Add("WaktuSelesai", "Waktu Selesai");
            dataGridViewDaftarPemesanan.Columns.Add("LokasiAwal", "Lokasi Awal");
            dataGridViewDaftarPemesanan.Columns.Add("LokasiTujuan", "Lokasi Tujuan");
            dataGridViewDaftarPemesanan.Columns.Add("Harga", "Harga");
            dataGridViewDaftarPemesanan.Columns.Add("Status", "Status");
            for (int i = 0; i < dataGridViewDaftarPemesanan.Columns.Count; i++)
            {
                this.dataGridViewDaftarPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewDaftarPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            }
            dataGridViewDaftarPemesanan.AllowUserToAddRows = false;
            dataGridViewDaftarPemesanan.ReadOnly = true;
        }

        private void FormPemesananDriver_Load(object sender, EventArgs e)
        {
            listPesanan.Clear();
            form = (FormUtama)this.MdiParent;
            if (radioButtonOrderanMasuk.Checked)
            {
                foreach (Pesanan p in Pesanan.BacaData())
                {
                    if (p.Penerima.Email == form.driverLogin.Email)
                    {
                        if (p.Status == "diterima" || p.Status == "perjalanan")
                        {
                            listPesanan.Add(p);
                            labelStatusAktif.Text = p.KodeBooking.ToString();
                        }
                    }
                }
                if(listPesanan.Count<1)
                {
                    foreach (Pesanan p in Pesanan.BacaData())
                    {
                        if (p.Status == "menunggu driver")
                        {
                            listPesanan.Add(p);
                        }
                    }
                }
                FormatDataGrid();
                TampilanGridOrderanMasuk();
            }
            else if(radioButtonRiwayatOrderan.Checked)
            {
                foreach (Pesanan p in Pesanan.BacaData())
                {
                    if (p.Penerima.Email == form.driverLogin.Email)
                    {
                        if (p.Status == "selesai" || p.Status == "ditolak")
                        {
                            listPesanan.Add(p);
                        }
                    }
                }
                FormatDataGrid();
                TampilanGridRiwayat();
            }
        }
        FormUtama form;
        List<Pesanan> listPesanan = new List<Pesanan>();
        private void dataGridViewDaftarPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewDaftarPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "menunggu driver")
                {
                    Pesanan orderan = Pesanan.AmbilData("kode_booking", dataGridViewDaftarPemesanan.Rows[e.RowIndex].Cells["KodeBooking"].Value.ToString());
                    if (e.ColumnIndex == dataGridViewDaftarPemesanan.Columns["Terima"].Index && e.RowIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Terima orderan dari " + orderan.Pemesan.Nama + "?, \nPesanan yang diterima tidak dapat dibatalkan !", "Perhatian", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            FormLokasiDriver frm = new FormLokasiDriver(); //panggil 
                            frm.Owner = this;
                            frm.orderan = orderan;
                            frm.driver = form.driverLogin;
                            frm.ShowDialog();
                        }
                    }
                    else if (e.ColumnIndex == dataGridViewDaftarPemesanan.Columns["Tolak"].Index && e.RowIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Apakah Anda yakin untuk menolak orderan dari " + orderan.Pemesan.Nama + "?", "Perhatian", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            Pesanan.UbahStatusPesanans(orderan.KodeBooking, "ditolak", form.driverLogin);
                            MessageBox.Show("Orderan dari " + orderan.Pemesan.Nama + "telah ditolak");
                            radioButtonRiwayatOrderan.Checked = true;
                        }
                    }
                }
                else if (dataGridViewDaftarPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "diterima")
                {
                    if (e.ColumnIndex == dataGridViewDaftarPemesanan.Columns["Mulai Perjalanan"].Index && e.RowIndex >= 0)
                    {
                        Pesanan orderan = Pesanan.AmbilData("kode_booking", dataGridViewDaftarPemesanan.Rows[e.RowIndex].Cells["KodeBooking"].Value.ToString());
                        if (form.driverLogin.Lokasi == orderan.LokasiAwal)
                        {
                            DialogResult result = MessageBox.Show("Mulai perjalanan?", "Konfirmasi", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                Pesanan.UbahStatusPesanans(orderan.KodeBooking, "perjalanan", form.driverLogin);
                                MessageBox.Show("Anda dan " + orderan.Pemesan.Nama + " memulai perjalanan untuk kode booking " + orderan.KodeBooking);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Customer belum mengkonfirmasi bahwa anda telah tiba di lokasi penjemputan !");
                        }
                    }
                }
                else if (dataGridViewDaftarPemesanan.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "perjalanan")
                {
                    if (e.ColumnIndex == dataGridViewDaftarPemesanan.Columns["Selesai"].Index && e.RowIndex >= 0)
                    {
                        Pesanan orderan = Pesanan.AmbilData("kode_booking", dataGridViewDaftarPemesanan.Rows[e.RowIndex].Cells["KodeBooking"].Value.ToString());
                        if (form.driverLogin.Lokasi == orderan.LokasiTujuan)
                        {
                            DialogResult result = MessageBox.Show("Selesaikan perjalanan?", "Konfirmasi", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            { 
                                Pesanan.UbahStatusPesanans(orderan.KodeBooking, "selesai", form.driverLogin);
                                Pesanan.PesananSelesai(orderan, form.driverLogin);
                                MessageBox.Show("Pesanan " + orderan.KodeBooking + " telah selesai! \nNominal sebesar Rp" + orderan.Harga * 0.8 + " telah masuk ke saldo anda! \n*(Nominal diatas sudah dipotong biaya layanan TAKE IT sebesar 20%) ");
                                Driver d = Driver.AmbilData("email", form.driverLogin.Email);
                                form.driverLogin = d;
                                form.labelSaldo.Text = form.driverLogin.Saldo.ToString();
                                radioButtonRiwayatOrderan.Checked = true;
                                labelStatusAktif.Text = "Tidak Ada";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Customer belum mengkonfirmasi bahwa anda telah sampai di lokasi tujuan !");
                        }
                    }
                }
                FormPemesananDriver_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TampilanGridOrderanMasuk()
        {
            dataGridViewDaftarPemesanan.Rows.Clear();
            if (listPesanan.Count > 0)
            {
                foreach (Pesanan pes in listPesanan)
                {
                    dataGridViewDaftarPemesanan.Rows.Add(pes.KodeBooking, pes.Pemesan.Nama, pes.WaktuPesan, pes.WaktuSelesai, pes.LokasiAwal, pes.LokasiTujuan, pes.Harga, pes.Status);
                    if (pes.Status == "menunggu driver" && dataGridViewDaftarPemesanan.Columns.Contains("Terima") == false)
                    {
                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                        colUpdate.Text = "Terima";
                        colUpdate.Name = "Terima";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewDaftarPemesanan.Columns.Add(colUpdate);
                        DataGridViewButtonColumn colUpdate2 = new DataGridViewButtonColumn();
                        colUpdate2.Text = "Tolak";
                        colUpdate2.Name = "Tolak";
                        colUpdate2.UseColumnTextForButtonValue = true;
                        dataGridViewDaftarPemesanan.Columns.Add(colUpdate2);
                    }
                    else if (pes.Status == "diterima" && dataGridViewDaftarPemesanan.Columns.Contains("Mulai Perjalanan") == false)
                    {
                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                        colUpdate.Text = "Mulai Perjalanan";
                        colUpdate.Name = "Mulai Perjalanan";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewDaftarPemesanan.Columns.Add(colUpdate);
                    }
                    else if (pes.Status == "perjalanan" && dataGridViewDaftarPemesanan.Columns.Contains("Selesai") == false)
                    {
                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                        colUpdate.Text = "Pesanan Selesai";
                        colUpdate.Name = "Selesai";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewDaftarPemesanan.Columns.Add(colUpdate);
                    }
                }
                for (int i = 0; i < dataGridViewDaftarPemesanan.Columns.Count - 1; i++)
                {
                    this.dataGridViewDaftarPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.dataGridViewDaftarPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                }
            }
            else
            {
                dataGridViewDaftarPemesanan.DataSource = null;
            }
        }
        private void TampilanGridRiwayat()
        {
            dataGridViewDaftarPemesanan.Rows.Clear();
            if (listPesanan.Count > 0)
            {
                foreach (Pesanan pes in listPesanan)
                {
                    dataGridViewDaftarPemesanan.Rows.Add(pes.KodeBooking, pes.Pemesan.Nama, pes.WaktuPesan, pes.WaktuSelesai, pes.LokasiAwal, pes.LokasiTujuan, pes.Harga, pes.Status);
                }
                for (int i = 0; i < dataGridViewDaftarPemesanan.Columns.Count - 1; i++)
                {
                    this.dataGridViewDaftarPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.dataGridViewDaftarPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                }
            }
            else
            {
                dataGridViewDaftarPemesanan.DataSource = null;
            }
        }
        private void radioButtonOrderanMasuk_CheckedChanged(object sender, EventArgs e)
        {
            FormPemesananDriver_Load(this, e);
        }

        private void radioButtonRiwayatOrderan_CheckedChanged(object sender, EventArgs e)
        {
            FormPemesananDriver_Load(this, e);   
        }

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
