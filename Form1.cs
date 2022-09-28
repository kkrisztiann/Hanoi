using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanoi
{
    public partial class Form1 : Form
    {
        public static int korongszam;
        public static int honnan;
        public static int hova;

        static List<Label> honnanlista = new List<Label>();
        static List<Label> jokerlista = new List<Label>();
        static List<Label> hovalista = new List<Label>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ToronyGeneralas()
        {

            PictureBox[] nev = new PictureBox[3];
            for (int i = 0; i < 3; i++)
            {
                nev[i]  = new PictureBox();
                nev[i].Name = "pictureBox";
                nev[i].Size = new Size(153, 226);
                nev[i].Location = new Point(110+(400*i), 125);
                nev[i].Image = Image.FromFile("torony.png");
                this.Controls.Add(nev[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //majd ellenorzunk
            //form beallitasa
            korongszam = Convert.ToInt32(numericUpDown1.Text);
            honnan = Convert.ToInt32(textBox2.Text);
            hova = Convert.ToInt32(textBox3.Text);
            FormBeallitas();
            //tornyok generalasa
            ToronyGeneralas();
            //3 gomb generalasa
            GombGeneralas();
            //korongszam label generalas
            KorongBeall();
            //label szeleseg/szin beallito metodus
            //label pozicio metodus
        }

        private void SzinPoz()
        {
            for (int i = 0; i < korongszam; i++)
            {
                switch (honnanlista[i].Name)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    case "8":

                        break;
                    case "9":

                        break;
                    case "10":
                        honnanlista[i].BringToFront();
                        honnanlista[i].Size = new Size(145,20);
                        honnanlista[i].Location = new Point(113,320);
                        break;

                }

            }
        }

        private void KorongBeall()
        {
            Label[] korong = new Label[korongszam];
            for (int i = 0; i < korongszam; i++)
            {
                    korong[i] = new Label();
                    korong[i].Name = (i+1).ToString();
                    //korong[i].Size = new Size(50, 50);
                    //korong[i].Location = new Point(110 + (400 * i), 525);
                    korong[i].BackColor = Color.YellowGreen;
                    korong[i].Text = "";
                    honnanlista.Add(korong[i]);
                    this.Controls.Add(korong[i]);
            }
                    SzinPoz();
        }

        private void GombGeneralas()
        {
            Button[] gombok = new Button[3];
            for (int i = 0; i < 3; i++)
            {
                gombok[i] = new Button();
                this.Controls.Add(gombok[i]);
                string nev = "gomb"+i;
                gombok[i].Name = nev;
                gombok[i].Text = "Cica";
                gombok[i].Location = new Point(135+400*i, 380);
                gombok[i].Size = new Size(100, 50);
                gombok[i].Click += new EventHandler(this.Klikkeles);
            }

        }

        private void Klikkeles(object sender, EventArgs e)
        {
            
        }

        private void FormBeallitas()
        {
            this.Size = new Size(1200, 500);
        }
    }
}
