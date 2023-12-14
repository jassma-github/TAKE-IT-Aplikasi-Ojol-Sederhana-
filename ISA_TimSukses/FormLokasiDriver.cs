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
    public partial class FormLokasiDriver : Form
    {
        public FormLokasiDriver()
        {
            InitializeComponent();
        }
        public Pesanan orderan;
        public Driver driver;
             
        private void FormLokasiDriver_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            if(textBoxLokasi.Text != "")
            {
                Pesanan.UbahStatusPesanans(orderan.KodeBooking, "diterima", driver);
                Driver.UbahLokasi(driver, textBoxLokasi.Text);
                MessageBox.Show("Orderan diterima !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Isi lokasi anda terlebih dahulu !");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
