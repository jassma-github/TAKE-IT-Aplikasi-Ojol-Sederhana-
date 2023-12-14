using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace ISA_LIB
{
    public class CustomPrint
    {
        private Font tipeFont;
        private StreamReader filePrint;
        private float rightMargin, leftMargin, topMargin, bottomMargin;

        public CustomPrint(Font tipeFont, string alamatFile, float rightMargin, float leftMargin, float topMargin, float bottomMargin)
        {
            this.TipeFont = tipeFont;
            this.FilePrint = new StreamReader(alamatFile);
            this.RightMargin = rightMargin;
            this.LeftMargin = leftMargin;
            this.TopMargin = topMargin;
            this.BottomMargin = bottomMargin;
        }

        public Font TipeFont { get => tipeFont; set => tipeFont = value; }
        public StreamReader FilePrint { get => filePrint; set => filePrint = value; }
        public float RightMargin { get => rightMargin; set => rightMargin = value; }
        public float LeftMargin { get => leftMargin; set => leftMargin = value; }
        public float TopMargin { get => topMargin; set => topMargin = value; }
        public float BottomMargin { get => bottomMargin; set => bottomMargin = value; }

        public void CetakTeks(object sender, PrintPageEventArgs e)
        {
            int maxRow = (int)((e.MarginBounds.Height - BottomMargin - TopMargin) / TipeFont.GetHeight(e.Graphics));
            float y = TopMargin;
            float rowNum = 0;

            string rowText = FilePrint.ReadLine();
            while (rowNum < maxRow && rowText != null)
            {
                y = TopMargin + (rowNum * tipeFont.GetHeight(e.Graphics));

                e.Graphics.DrawString(rowText, tipeFont, Brushes.Black, leftMargin, y);

                rowNum++;
                rowText = FilePrint.ReadLine();
            }

            if (rowText != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        public void Print()
        {
            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            p.PrinterSettings.PrintToFile = true;

            p.PrintPage += new PrintPageEventHandler(CetakTeks);

            p.Print();

            FilePrint.Close();
        }
    }
}

