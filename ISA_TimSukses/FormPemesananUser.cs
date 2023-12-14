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
    public partial class FormPemesananUser : Form
    {
        public FormPemesananUser()
        {
            InitializeComponent();
        }
         FormUtama form;
        
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void buttonPesan_Click(object sender, EventArgs e)
        {
           

            Pesanan pesan = new Pesanan();
            pesan.KodeBooking = Pesanan.GenerateKodeBooking();
            pesan.Pemesan = form.customerLogin;
            pesan.WaktuPesan = DateTime.Now;
            pesan.LokasiAwal = textBoxLokasiAwal.Text;
            pesan.LokasiTujuan = textBoxLokasiTujuan.Text;
            pesan.Harga = int.Parse(textBoxHarga.Text);
            if(pesan.Harga <= form.customerLogin.Saldo)
            {
                Pesanan.TambahPesanan(pesan);
                MessageBox.Show("Berhasil pesan ! Masih Menunggu Driver ");
                Customer c = Customer.AmbilData("email", form.customerLogin.Email);
                form.customerLogin = c;
                form.labelSaldo.Text = form.customerLogin.Saldo.ToString(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Saldo anda tidak cukup");
            }
        }
        
        private void FormPemesananUser_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
