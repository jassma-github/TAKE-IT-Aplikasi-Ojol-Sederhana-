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
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }
        public Customer gantiFoto;
        //public Customer customer;
        //public Driver driver;
        public Driver driverGantiFoto;
        FormUtama form;
        private void FormProfil_Load(object sender, EventArgs e)
        {
            try
            {
                form = (FormUtama)this.MdiParent;

                if (form.customerLogin != null)
                {
                    FotoProfil foto = FotoProfil.AmbilData("id", form.customerLogin.FotoProfil.Id.ToString());
                    pictureBoxProfil.Image = UserFoto();
                    labelAlamatUser.Text = form.customerLogin.Alamat.ToString();
                    labelEmailUser.Text = form.customerLogin.Email.ToString();
                    labelNamaUser.Text = form.customerLogin.Nama.ToString();
                    labelNoTeleponUser.Text = form.customerLogin.NoTelp.ToString();
                }
                else if (form.driverLogin != null)
                {
                    FotoProfil foto = FotoProfil.AmbilData("id", form.driverLogin.FotoProfil.Id.ToString());
                    pictureBoxProfil.Image = UserFoto();
                    labelAlamatUser.Text = form.driverLogin.Alamat.ToString();
                    labelEmailUser.Text = form.driverLogin.Email.ToString();
                    labelNamaUser.Text = form.driverLogin.Nama.ToString();
                    labelNoTeleponUser.Text = form.driverLogin.NoTelp.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal. Pesan Kesalahan : " + ex.Message);
            }
        }
        public Image UserFoto()
        {
            if (form.customerLogin != null)
            {
                if (form.customerLogin.FotoProfil.Id == 1)
                {
                    return Properties.Resources.woman;
                }
                else if (form.customerLogin.FotoProfil.Id == 2)
                {
                    return Properties.Resources.athlete;
                }
                else if (form.customerLogin.FotoProfil.Id == 3)
                {
                    return Properties.Resources.man;
                }
                else if (form.customerLogin.FotoProfil.Id == 4)
                {
                    return Properties.Resources.winner;
                }
                else if (form.customerLogin.FotoProfil.Id == 5)
                {
                    return Properties.Resources.author;
                }
                else if (form.customerLogin.FotoProfil.Id == 6)
                {
                    return Properties.Resources.man__1_;
                }
                else
                {
                    return Properties.Resources.profile;
                }
                //return Properties.Resources.woman;
            }
            else if (form.driverLogin != null)
            {
                if (form.driverLogin.FotoProfil.Id == 1)
                {
                    return Properties.Resources.woman;
                }
                else if (form.driverLogin.FotoProfil.Id == 2)
                {
                    return Properties.Resources.athlete;
                }
                else if (form.driverLogin.FotoProfil.Id == 3)
                {
                    return Properties.Resources.man;
                }
                else if (form.driverLogin.FotoProfil.Id == 4)
                {
                    return Properties.Resources.winner;
                }
                else if (form.driverLogin.FotoProfil.Id == 5)
                {
                    return Properties.Resources.author;
                }
                else if (form.driverLogin.FotoProfil.Id == 6)
                {
                    return Properties.Resources.man__1_;
                }
                else
                {
                    return Properties.Resources.profile;
                }
            }
            else
            {
                return Properties.Resources.profile;
            }
        }

        private void buttonUbahFoto_Click(object sender, EventArgs e)
        {
            FormFoto frm = new FormFoto();
            frm.Owner = this;
            if (form.customerLogin != null)
            {
                frm.customerGantiFoto = form.customerLogin;

            }
            else if (form.driverLogin != null)
            {
                frm.driverGantiFoto = form.driverLogin;
            }

            frm.ShowDialog();

            FormProfil_Load(this, e);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
