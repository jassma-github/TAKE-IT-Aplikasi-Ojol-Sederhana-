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
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }
       
        private void topUpDllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormTopUp"];
            if (frm == null)
            {
                FormTopUp f = new FormTopUp();
                f.MdiParent = this;
                f.Show();
          
            }
            else
            {
                frm.BringToFront();
                frm.Show();
          
            }
        }

        private void pesanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPesananAktifCustomer.Clear();
            foreach (Pesanan p in Pesanan.BacaData("users_email", customerLogin.Email))
            {
                if (p.Status != "ditolak" && p.Status != "selesai")
                {
                    listPesananAktifCustomer.Add(p);
                }
            }
            if (listPesananAktifCustomer.Count > 0)
            {
                MessageBox.Show("Anda masih memiliki pesanan yang aktif !");
            }
            else
            {
                Form frm = Application.OpenForms["FormPemesananUser"];
                if (frm == null)
                {
                    FormPemesananUser f = new FormPemesananUser();
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    frm.BringToFront();
                    frm.Show();
                }
            }
        }

        private void riwayatPemesananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormHistory"];
            if (frm == null)
            {
                FormHistory f = new FormHistory();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormProfil"];
            if (frm == null)
            {
                FormProfil f = new FormProfil();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void verifikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormVerifikasi"];
            if (frm == null)
            {
                FormVerifikasi f = new FormVerifikasi();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void orderanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fr = Application.OpenForms["FormPemesananDriver"];
            if (fr == null)
            {
                FormPemesananDriver f = new FormPemesananDriver();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                fr.BringToFront();
                fr.Show();
            }
        }
        public Customer customerLogin;
        public Driver driverLogin;
        public Admin adminLogin;
        public List<Pesanan> listPesananAktifCustomer = new List<Pesanan>();
        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
        

            this.Visible = false; //tampilan formutama dimatikan
            FormLogin frm = new FormLogin(); //panggil formlogin

            frm.Owner = this;
            frm.ShowDialog();
            AturTampilanMenu();

            if (customerLogin != null)
            {
                //position = Position.BacaData("id", employeeLogin.EmployeePosition.ToString());
                labelStatus.Text = "Customer";
                labelNama.Text = customerLogin.Nama;
                labelSaldo.Text = customerLogin.Saldo.ToString();
            }
            else if (driverLogin!=null)
            {
                labelStatus.Text = "Driver";
                labelNama.Text = driverLogin.Nama;
                labelSaldo.Text = driverLogin.Saldo.ToString();

            }
            else if(adminLogin!=null)
            {
                labelStatus.Text = "Admin";
                labelNama.Text = adminLogin.Username;
            }
            else
            {
                this.Close();
            }
        }
        public void AturTampilanMenu()
        {
            if (customerLogin is null)
            {
                if (driverLogin != null)
                {
                    topUpDllToolStripMenuItem.Visible = false;
                    pesanToolStripMenuItem.Visible = false;
                    verifikasiToolStripMenuItem.Visible = false;
                    riwayatPemesananToolStripMenuItem.Visible = false;
                    tambahAdminStripMenuItem.Visible = false;

                }
                else if (adminLogin != null)
                {
                    
                    orderanToolStripMenuItem.Visible = false;
                    topUpDllToolStripMenuItem.Visible = false;
                    pesanToolStripMenuItem.Visible = false;
                    riwayatPemesananToolStripMenuItem.Visible = false;
                    profileToolStripMenuItem.Visible = false;
                    labelSaldo.Visible = false;
                    label1.Visible = false;

                }
            }
            else
            {
                verifikasiToolStripMenuItem.Visible = false;
                orderanToolStripMenuItem.Visible = false;
                tambahAdminStripMenuItem.Visible=false;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tambahAdminStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fr = Application.OpenForms["FormTambahAdmin"];
            if (fr == null)
            {
                FormTambahAdmin f = new FormTambahAdmin();
                f.MdiParent = this;
                f.Show();
               
            }
            else
            {
                fr.BringToFront();
                fr.Show();
               
            }
        }
    }
}
