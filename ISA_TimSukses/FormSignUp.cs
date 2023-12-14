using System;
using ISA_LIB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISA_TimSukses
{
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = (FormLogin)this.Owner;
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxKonfirmPassword.Text == textBoxPassword.Text)
                {
                    string nama = textBoxNama.Text;
                    string alamat =textBoxAlamat.Text;
                    string notelp = textBoxNoHp.Text;
                    string email = textBoxEmail.Text;
                    string password = textBoxPassword.Text;
                    string plat = textBoxPlatNomor.Text;
                    double saldo = 0;
                    FotoProfil foto = new FotoProfil();
                    Admin admin = new Admin();

                    if (radioButtonDriver.Checked)
                    {
                        Driver driver = new Driver(email, nama, alamat, notelp, password,saldo , admin, "", plat, foto);
                        Driver.TambahData(driver);

                        MessageBox.Show("Pembuatan akun Take-It berhasil ! \nAkun anda sedang dalam proses verifikasi, tunggu hingga 1x24 jam");
                        this.Close();
                    }
                    else if (radioButtonPengguna.Checked)
                    {
                        Customer customer = new Customer(email, nama, alamat, notelp, password,saldo,foto, admin);

                        Customer.TambahData(customer);

                        MessageBox.Show("Pembuatan akun Take-It berhasil ! \nAkun anda sedang dalam proses verifikasi, tunggu hingga 1x24 jam");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Pastikan anda mengisi kolom konfirm password dengan benar!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void radioButtonPengguna_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlatNomor.Visible = false;
            label8.Visible = false;
        }

        private void radioButtonDriver_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlatNomor.Visible = true;
            label8.Visible = true;
        }
    }
}
            

    
    

