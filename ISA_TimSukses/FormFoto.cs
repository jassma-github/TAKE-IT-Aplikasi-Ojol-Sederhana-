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
    public partial class FormFoto : Form
    {
        public FormFoto()
        {
            InitializeComponent();
        }
        public Customer customerGantiFoto;
        //public Customer customer;
        public Driver driverGantiFoto;
        //public Driver driver;
        //FormUtama form;
        //FormProfil prof;
        private void FormFoto_Load(object sender, EventArgs e)
        {
            if (customerGantiFoto != null)
            {
                if (customerGantiFoto.FotoProfil.Id == 1)
                {
                    radioButtonWoman.Checked = true;
                }
                else if (customerGantiFoto.FotoProfil.Id == 2)
                {
                    radioButtonAthlete.Checked = true;
                }
                else if (customerGantiFoto.FotoProfil.Id == 3)
                {
                    radioButtonMan.Checked = true;
                }
                else if (customerGantiFoto.FotoProfil.Id == 4)
                {
                    radioButtonWinner.Checked = true;
                }
                else if (customerGantiFoto.FotoProfil.Id == 5)
                {
                    radioButtonAuthor.Checked = true;
                }
                else if (customerGantiFoto.FotoProfil.Id == 6)
                {
                    radioButtonSafetyMan.Checked = true;
                }
            }
            else if (driverGantiFoto != null)
            {
                if (driverGantiFoto.FotoProfil.Id == 1)
                {
                    radioButtonWoman.Checked = true;
                }
                else if (driverGantiFoto.FotoProfil.Id == 2)
                {
                    radioButtonAthlete.Checked = true;
                }
                else if (driverGantiFoto.FotoProfil.Id == 3)
                {
                    radioButtonMan.Checked = true;
                }
                else if (driverGantiFoto.FotoProfil.Id == 4)
                {
                    radioButtonWinner.Checked = true;
                }
                else if (driverGantiFoto.FotoProfil.Id == 5)
                {
                    radioButtonAuthor.Checked = true;
                }
                else if (driverGantiFoto.FotoProfil.Id == 6)
                {
                    radioButtonSafetyMan.Checked = true;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //prof = (FormProfil)this.Owner;

            if (customerGantiFoto != null)
            {
                if (radioButtonWoman.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(1, pictureBoxWoman.Image);
                    customerGantiFoto.FotoProfil = fotoBaru;
                    //driverGantiFoto.FotoProfil = fotoBaru;

                }
                else if (radioButtonAthlete.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(2, pictureBoxAthlete.Image);
                    customerGantiFoto.FotoProfil = fotoBaru;
                    //driverGantiFoto.FotoProfil = fotoBaru;

                }
                else if (radioButtonMan.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(3, pictureBoxMan.Image);
                    customerGantiFoto.FotoProfil = fotoBaru;
                    //driverGantiFoto.FotoProfil = fotoBaru;
                }
                else if (radioButtonWinner.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(4, pictureBoxMsWinner.Image);
                    customerGantiFoto.FotoProfil = fotoBaru;
                    //driverGantiFoto.FotoProfil = fotoBaru;
                }
                else if (radioButtonAuthor.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(5, pictureBoxAuthor.Image);
                    customerGantiFoto.FotoProfil = fotoBaru;
                    //driverGantiFoto.FotoProfil = fotoBaru;
                }
                else if (radioButtonSafetyMan.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(6, pictureBoxMan2.Image);
                    customerGantiFoto.FotoProfil = fotoBaru;
                    //driverGantiFoto.FotoProfil = fotoBaru;
                }
                Customer.UbahProfil(customerGantiFoto);

            }
            else if (driverGantiFoto != null)
            {
                if (radioButtonWoman.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(1, pictureBoxWoman.Image);
                    //customerGantiFoto.FotoProfil = fotoBaru;
                    driverGantiFoto.FotoProfil = fotoBaru;

                }
                else if (radioButtonAthlete.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(2, pictureBoxAthlete.Image);
                    //customerGantiFoto.FotoProfil = fotoBaru;
                    driverGantiFoto.FotoProfil = fotoBaru;

                }   
                else if (radioButtonMan.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(3, pictureBoxMan.Image);
                    //customerGantiFoto.FotoProfil = fotoBaru;
                    driverGantiFoto.FotoProfil = fotoBaru;
                }
                else if (radioButtonWinner.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(4, pictureBoxMsWinner.Image);
                    //customerGantiFoto.FotoProfil = fotoBaru;
                    driverGantiFoto.FotoProfil = fotoBaru;
                }
                else if (radioButtonAuthor.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(5, pictureBoxAuthor.Image);
                    //customerGantiFoto.FotoProfil = fotoBaru;
                    driverGantiFoto.FotoProfil = fotoBaru;
                }
                else if (radioButtonSafetyMan.Checked)
                {
                    FotoProfil fotoBaru = new FotoProfil(6, pictureBoxMan2.Image);
                    //customerGantiFoto.FotoProfil = fotoBaru;
                    driverGantiFoto.FotoProfil = fotoBaru;
                }
                Driver.UbahProfil(driverGantiFoto);
            }
            MessageBox.Show("Berhasil ubah foto profil");
            this.Close();
        }
    }
}
