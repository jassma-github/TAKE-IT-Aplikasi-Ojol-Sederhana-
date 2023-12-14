using ISA_LIB;
using System;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        FormUtama form = new FormUtama();
        Customer customer = new Customer();
        Driver driver = new Driver();
       
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //customer
            //textBoxEmail.Text = "lin";
            //textBoxPassword.Text = "12345678";

            //driver
            /*textBoxEmail.Text = "ttt";
            textBoxPassword.Text = "12345678";*/

            //admin
            /* textBoxEmail.Text = "jassma";
             textBoxPassword.Text = "12345678";*/
            try
            {
                Driver driver = Driver.CekLogin(textBoxEmail.Text, textBoxPassword.Text);
                Admin admin = Admin.CekLogin(textBoxEmail.Text, textBoxPassword.Text);
                customer = Customer.CekLogin(textBoxEmail.Text, textBoxPassword.Text);

                if (customer != null)
                {
                    if(customer.Verifikator.Username != "" )
                    {
                        FormUtama form = new FormUtama();
                        form = (FormUtama)this.Owner;
                        form.customerLogin = customer;
                        MessageBox.Show("Selamat datang " + form.customerLogin.Nama);
                        form.Visible = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Akun anda masih dalam proses verifikasi! \nTunggu hingga 1x24 jam atau hubungi CS Take-It 1500900");
                    }
                }
                else if (driver != null)
                {
                    if (driver.Verifikator.Username != "")
                    {
                        FormUtama form = new FormUtama();
                        form = (FormUtama)this.Owner;
                        form.driverLogin = driver;
                        MessageBox.Show("Selamat datang " + form.driverLogin.Nama);
                        form.Visible = true;
                        this.Close();
                     
                    }
                    else
                    {
                        MessageBox.Show("Akun anda masih dalam proses verifikasi! \nTunggu hingga 1x24 jam atau hubungi CS Take-It 1500900");
                    }
                }
                else if (admin != null)
                {
                    FormUtama form = new FormUtama();
                    form = (FormUtama)this.Owner;
                    form.adminLogin = admin;
                    MessageBox.Show("Selamat datang " + form.adminLogin.Username);

                    form.Visible = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login gagal, pastikan email dan password anda benar!", "Error");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Pesan kesalahan : " + x.Message);
            }
        }
    

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            //this.MaximizeBox = true;

            try
            {
                //this.IsMdiContainer = true;
                Koneksi koneksi = new Koneksi();
                /* MessageBox.Show("Koneksi Berhasil");*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSignUp form = new FormSignUp();
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
