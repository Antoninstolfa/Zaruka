using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace záruka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         void ZarukaRoky(DateTimePicker Datum, TextBox PocetLet,ref int pocetDni, ref bool zaruka)
        {
            DateTime denKoupeni = new DateTime();
            denKoupeni = Datum.Value;
            DateTime dnes = DateTime.Today;
            try
            {
                int rokyZaruky = Convert.ToInt32(PocetLet.Text);
                denKoupeni = denKoupeni.AddYears(rokyZaruky);
                TimeSpan pomocna = denKoupeni - dnes;
                if(pomocna.TotalDays < 0)
                {
                    zaruka = false;
                }
                else
                {
                    zaruka = true;
                    pocetDni = (int)pomocna.TotalDays;
                }
            }
            catch
            {
                MessageBox.Show("Zadejte v číslech , ne v textu!", "error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool zaruka = false;
            int pocetDni = 0;
            ZarukaRoky(dateTimePicker1, textBox1, ref pocetDni, ref zaruka);
            if(zaruka == true)
            {
                odpoved.Text = "Vaše zboží je stále v záruce.\nPočet dní zbývající záruky:" + pocetDni;
            }
            else
            {
                odpoved.Text = "Vaše zboží už není v záruce.";
            }
        }
    }
}
