using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace barkod2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Zen.Barcode.Code128BarcodeDraw cd128 = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && textBox2.Text !="")
            {
                pictureBox1.Image = cd128.Draw(textBox1.Text, 55);
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("İlgili Alanları Doldurunuz.");
            }

        }
        public void yazdir(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(pictureBox1.Image, 35, 40);
            e.Graphics.DrawString(textBox1.Text, this.Font, new SolidBrush(Color.Black), 50, pictureBox1.Image.Height+45);
            e.Graphics.DrawString(textBox2.Text, this.Font, new SolidBrush(Color.Black), 35, pictureBox1.Image.Height + 60);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=null&&textBox2.Text!=null)
            {
                PrintDocument dos = new PrintDocument();
                PrinterSettings settings = new PrinterSettings();
                string defaultPrinterName = settings.PrinterName;
                dos.PrinterSettings.PrinterName = defaultPrinterName;
                dos.PrinterSettings.DefaultPageSettings.Landscape = true;
                dos.PrintPage += new PrintPageEventHandler(yazdir);
                dos.DefaultPageSettings.PaperSize = new PaperSize("A", 197, 157);
                dos.Print();
                textBox1.Clear();
                textBox2.Clear();
                pictureBox1.Image = null;
            }
            else
            {
                MessageBox.Show("İlgili Alanları Doldurunuz.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
