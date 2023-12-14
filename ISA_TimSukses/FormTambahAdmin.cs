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
    public partial class FormTambahAdmin : Form
    {
        public FormTambahAdmin()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(textBoxUsername.Text, textBoxPassword.Text);
            Admin.TambahData(admin);
            MessageBox.Show("Berhasil Tambah Admin");
            this.Close();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
        FormUtama formUtama;
        private void FormTambahAdmin_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
