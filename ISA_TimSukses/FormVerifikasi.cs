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
    public partial class FormVerifikasi : Form
    {
        public FormVerifikasi()
        {
            InitializeComponent();
        }
        FormUtama formUtama;
        List<Customer> listCustomer = new List<Customer>();
        List<Driver> listDriver = new List<Driver>();        
        private void FormVerifikasi_Load(object sender, EventArgs e)
        {
            listDriver.Clear();
            formUtama = (FormUtama)this.MdiParent;
            if(radioButtonDriver.Checked)
            {
                foreach (Driver d in Driver.BacaData())
                {
                    if (d.Verifikator.Username == "")
                    {
                        listDriver.Add(d);
                    }
                }
                FormatDataDriver();
                TampilDataDriver();

            } 
            else if(radioButtonCustomer.Checked)
            {
                listCustomer.Clear();
                foreach (Customer c in Customer.BacaData())
                {
                    if (c.Verifikator.Username == "")
                    {
                        listCustomer.Add(c);
                    }
                }
                FormatDataCustomer();
                TampilDataCustomer();
            }
        }
        private void TampilDataCustomer()
        {
            dataGridViewDaftarPemesanan.Rows.Clear();

            if (listCustomer.Count > 0)
            {
                foreach (Customer cust in listCustomer)
                {
                    dataGridViewDaftarPemesanan.Rows.Add(cust.Email, cust.Nama, cust.Alamat, cust.NoTelp);

                    if (dataGridViewDaftarPemesanan.Columns.Contains("Verifikasi") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.Text = "Setujui";
                        col.Name = "Verifikasi";
                        col.UseColumnTextForButtonValue = true;
                        dataGridViewDaftarPemesanan.Columns.Add(col);
                    }
                }
            }
            else
            {
                dataGridViewDaftarPemesanan.DataSource = null;
            }
        }
        private void TampilDataDriver()
        {
            dataGridViewDaftarPemesanan.Rows.Clear();

            if (listDriver.Count > 0)
            {
                foreach (Driver driver in listDriver)
                {
                    dataGridViewDaftarPemesanan.Rows.Add(driver.Email, driver.Nama, driver.Alamat, driver.NoTelp, driver.PlatNomor);

                    if (dataGridViewDaftarPemesanan.Columns.Contains("Verifikasi") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.Text = "Setujui";
                        col.Name = "Verifikasi";
                        col.UseColumnTextForButtonValue = true;
                        dataGridViewDaftarPemesanan.Columns.Add(col);

                    }
                }
            }
            else
            {
                dataGridViewDaftarPemesanan.DataSource = null;
            }
        }
        private void FormatDataCustomer()
        {
            dataGridViewDaftarPemesanan.Columns.Clear();

            dataGridViewDaftarPemesanan.Columns.Add("Email", "Email");
            dataGridViewDaftarPemesanan.Columns.Add("Nama", "Nama");
            dataGridViewDaftarPemesanan.Columns.Add("Alamat", "Alamat");
            dataGridViewDaftarPemesanan.Columns.Add("NoTelp", "No Telepon");

            dataGridViewDaftarPemesanan.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["NoTelp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (int i = 0; i < dataGridViewDaftarPemesanan.Columns.Count; i++)
            {
                this.dataGridViewDaftarPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewDaftarPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            }
            dataGridViewDaftarPemesanan.AllowUserToAddRows = false;
            dataGridViewDaftarPemesanan.ReadOnly = true;
        }
        private void FormatDataDriver()
        {
            dataGridViewDaftarPemesanan.Columns.Clear();

            dataGridViewDaftarPemesanan.Columns.Add("Email", "Email");
            dataGridViewDaftarPemesanan.Columns.Add("Nama", "Nama");
            dataGridViewDaftarPemesanan.Columns.Add("Alamat", "Alamat");
            dataGridViewDaftarPemesanan.Columns.Add("NoTelp", "No Telepon");
            dataGridViewDaftarPemesanan.Columns.Add("PlatNomor", "Plat Nomor");

            dataGridViewDaftarPemesanan.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["NoTelp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarPemesanan.Columns["PlatNomor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (int i = 0; i < dataGridViewDaftarPemesanan.Columns.Count; i++)
            {
                this.dataGridViewDaftarPemesanan.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewDaftarPemesanan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            }
            dataGridViewDaftarPemesanan.AllowUserToAddRows = false;
            dataGridViewDaftarPemesanan.ReadOnly = true;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDaftarPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDaftarPemesanan.Columns["Verifikasi"].Index && e.RowIndex >= 0)
            {
                DialogResult hasil = MessageBox.Show("Setujui verifikasi?", "Perhatian", MessageBoxButtons.YesNo);
                if (hasil == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridViewDaftarPemesanan.Rows[e.RowIndex];
                    if (radioButtonCustomer.Checked)
                    {
                        Customer cust = Customer.AmbilData("email", row.Cells["Email"].Value.ToString());
                        Customer.UbahDataVerifikasi(cust, formUtama.adminLogin);

                        MessageBox.Show("Berhasil verifikasi akun " + cust.Nama);
                    }
                    else if (radioButtonDriver.Checked)
                    {
                        Driver driver = Driver.AmbilData("email", row.Cells["Email"].Value.ToString());
                        Driver.UbahDataVerifikasi(driver, formUtama.adminLogin);

                        MessageBox.Show("Berhasil verifikasi akun " + driver.Nama);
                    }
                }
            }
            FormVerifikasi_Load(this, e);
        }

        private void radioButtonCustomer_CheckedChanged(object sender, EventArgs e)
        {
            FormVerifikasi_Load(this, e);
        }

        private void radioButtonDriver_CheckedChanged(object sender, EventArgs e)
        {
            FormVerifikasi_Load(this, e);
        }
    }
}
