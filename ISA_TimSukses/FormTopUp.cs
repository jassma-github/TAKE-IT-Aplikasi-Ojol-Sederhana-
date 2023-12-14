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
    public partial class FormTopUp : Form
    {
        public FormTopUp()
        {
            InitializeComponent();
        }
        FormUtama formUtama;
        Customer customer;
        private void FormTopUp_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            customer = formUtama.customerLogin;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            try
            {
                Customer.TopUpSaldo(customer, double.Parse(textBoxJumlah.Text));
                MessageBox.Show("Berhasil Top Up sebesar Rp" + textBoxJumlah.Text);
                Customer c = Customer.AmbilData("email", formUtama.customerLogin.Email);
                formUtama.customerLogin = c;
                formUtama.labelSaldo.Text = formUtama.customerLogin.Saldo.ToString();
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
