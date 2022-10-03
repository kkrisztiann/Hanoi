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
        static int korongszam;
        static int honnan;
        static int hova;
        static int melyikrol;
        static int melyikre;
        static int gombnyomasokszama=0;


        static List<Label> honnanlista = new List<Label>();
        static List<Label> jokerlista = new List<Label>();
        static List<Label> hovalista = new List<Label>();
        static Button[] gombok = new Button[3];

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
            //haugyanazahonnanmegahovaakkmessagebox

            MenuEltunes();
        }
        private void MenuEltunes()
        {
            button1.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            numericUpDown1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }
        private void SzinPoz()
        {
            for (int i = 0; i < korongszam; i++)
            {
                switch (honnanlista[i].Name)
                {
                    case "1":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(255, 160, 122);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "2":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(255, 192, 203);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "3":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(255, 215, 0);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "4":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(255, 255, 0);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "5":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(216, 191, 216);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "6":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(0, 255, 127);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "7":
                        Csinositas(i);
                        honnanlista[i].BackColor = Color.FromArgb(152, 251, 152);
                        honnanlista[i].BorderStyle = BorderStyle.FixedSingle;
                        break;
                }
            }
        }
        private void Csinositas(int i)
        {
            if (honnan == 1)
            {
                honnanlista[i].BringToFront();
                honnanlista[i].Size = new Size(145 - (20 * i), 20);
                honnanlista[i].Location = new Point(113 + (i * 10), 320 - (i * 20));
            }
            if (honnan == 2)
            {
                honnanlista[i].BringToFront();
                honnanlista[i].Size = new Size(145 - (20 * i), 20);
                honnanlista[i].Location = new Point(113 + (i * 10) + (1*400), 320 - (i * 20));
            }
            if (honnan == 3)
            {
                honnanlista[i].BringToFront();
                honnanlista[i].Size = new Size(145 - (20 * i), 20);
                honnanlista[i].Location = new Point(113 + (i * 10) + (2 * 400), 320 - (i * 20));
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
            for (int i = 0; i < 3; i++)
            {
                gombok[i] = new Button();
                this.Controls.Add(gombok[i]);
                string nev = "gomb"+i;
                gombok[i].Name = nev;
                gombok[i].Text = "Honnan";
                gombok[i].Location = new Point(135+400*i, 380);
                gombok[i].Size = new Size(100, 50);
            }
            gombok[0].Click += new EventHandler(this.Klikkeles1);
            gombok[1].Click += new EventHandler(this.Klikkeles2);
            gombok[2].Click += new EventHandler(this.Klikkeles3);

        }

        private void Klikkeles1(object sender, EventArgs e)
        {
            melyikrol = 1;
            melyikre = 1;
            if (gombnyomasokszama == 0)
            {
                gombok[0].Enabled = false;
                gombnyomasokszama++;
                gombok[1].Text = "Hova";
                gombok[2].Text = "Hova";
            }
            else if (gombnyomasokszama == 1)
            {
                gombok[1].Enabled = true;
                gombok[2].Enabled = true;
                gombnyomasokszama = 0;
                gombok[1].Text = "Honnan";
                gombok[2].Text = "Honnan";
                gombok[0].Text = "Honnan";
            }
            
            
        }
        
        private void Klikkeles2(object sender, EventArgs e)
        {
            melyikrol = 2;
            melyikre = 2;
            if (gombnyomasokszama==0)
            {
                gombok[1].Enabled = false;
                gombnyomasokszama++;
                gombok[0].Text = "Hova";
                gombok[2].Text = "Hova";
            }
            else if (gombnyomasokszama == 1)
            {
                gombok[0].Enabled = true;
                gombok[2].Enabled = true;
                gombnyomasokszama = 0;
                gombok[1].Text = "Honnan";
                gombok[2].Text = "Honnan";
                gombok[0].Text = "Honnan";
            }


        }
        private void Klikkeles3(object sender, EventArgs e)
        {
            melyikrol = 3;
            melyikre = 3;
            if (gombnyomasokszama == 0)
            {
                gombok[2].Enabled = false;
                gombnyomasokszama++;
                gombok[0].Text = "Hova";
                gombok[1].Text = "Hova";
            }
            else if (gombnyomasokszama == 1)
            {
                gombok[1].Enabled = true;
                gombok[0].Enabled = true;
                gombnyomasokszama = 0;
                gombok[1].Text = "Honnan";
                gombok[2].Text = "Honnan";
                gombok[0].Text = "Honnan";
            }

        }

        private void FormBeallitas()
        {
            this.MinimumSize = new Size(1200, 500);
            this.MaximumSize = new Size(1200, 500);
        }
    }
   
}
