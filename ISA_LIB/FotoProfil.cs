using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MySql.Data.MySqlClient;


namespace ISA_LIB
{
    public class FotoProfil
    {
        private int id;
        private Image foto;

        #region Constructors
        public FotoProfil(int id, Image foto)
        {
            this.Id = id;
            this.Foto = foto;
        }
        public FotoProfil()
        {
            this.Id = 1;
            this.Foto = null;
        }
        #endregion

        #region Properties

        public int Id { get => id; set => id = value; }
        public Image Foto { get => foto; set => foto = value; }
        #endregion

        #region Method
        public static FotoProfil AmbilData(string kolom, string nilai)
        {
            string sql;

            sql = "select * from fotoprofil where " + kolom + " = '" + nilai + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                FotoProfil input = new FotoProfil();
                input.Id = int.Parse(hasil.GetValue(0).ToString());
                input.Foto = null;
                
                return input;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
