using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimalni_trvanlivost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void MinTrvanlivostDny(DateTimePicker Datum,TextBox pocetDniTrvanlivosti, TextBox Cena, ref bool trvanlivost, ref int pocetDni, ref double cena, ref bool prodejne)
        {
            DateTime denKoupeni = new DateTime();
            denKoupeni = Datum.Value;
            DateTime dnes = DateTime.Today;
            try
            {
                int dnyTrvanlivosti = Convert.ToInt32(pocetDniTrvanlivosti.Text);
                cena = Convert.ToInt32(Cena.Text);
                denKoupeni = denKoupeni.AddDays(dnyTrvanlivosti);
                TimeSpan pomocna = denKoupeni - dnes;
                if(pomocna.TotalDays < 0)
                {
                    trvanlivost = false;
                    if (pocetDni > -10)
                    {
                        prodejne = false;
                    } 
                    else
                    {
                        prodejne = true;
                        cena = cena * 0.50;
                    }
                }
                else
                {
                    trvanlivost = true;
                    pocetDni = (int)pomocna.TotalDays;
                    if(pocetDni <= 3)
                    {
                        cena = cena * 0.75;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Zadejte v číslech , ne v textu!", "error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odpoved.Text = "Odpoved";
            bool trvanlivost = false;
            bool prodejne = true;
            int poceDni = 0;
            double cena = 0;
            MinTrvanlivostDny(dateTimePicker1, textBox1, textBox2, ref trvanlivost, ref poceDni, ref cena, ref prodejne);
            if(trvanlivost == true)
            {
                odpoved.Text = "Zboží není prošlé.\nPočet dní než zboží projde: " + poceDni + "\nCena Zboží: " + cena;
            }
            else
            {
                if(prodejne == true)
                {
                    odpoved.Text = "Zboží je prošlé!\n Lze ale koupit s výhodnou cenou: " + cena;
                }
                else
                {
                    odpoved.Text = "Zboží je prošlé a nelze být prodáno!";   
                }
            }
        }
    }
}
