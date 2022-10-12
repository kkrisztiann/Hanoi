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
        static int joker;
        static int melyikrol;
        static int melyikre;
        static double megoldaslegkevesebblepesbol;
        static int lepesekszama=0;
        static int gombnyomasokszama=0;
        static Label pontszam = new Label();
        static Label megoldaslegkevesebblepesbolLbl = new Label();


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

            korongszam = Convert.ToInt32(numericUpDown1.Text);
            honnan = Convert.ToInt32(textBox2.Text);
            hova = Convert.ToInt32(textBox3.Text);
            joker = 6 - honnan - hova;
            megoldaslegkevesebblepesbol = Math.Pow(2, Convert.ToDouble(korongszam)) - 1;
            FormBeallitas();

            ToronyGeneralas();

            GombGeneralas();

            PontszamoloGeneralas();

            KorongBeall();

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
        private void PontszamoloGeneralas()
        {
            //MessageBox.Show(megoldaslegkevesebblepesbol.ToString());
            megoldaslegkevesebblepesbolLbl.Text ="Minimum lépések száma: " +megoldaslegkevesebblepesbol.ToString();
            megoldaslegkevesebblepesbolLbl.Location = new Point(530, 50);
            megoldaslegkevesebblepesbolLbl.Size = new Size(200, 200);
            megoldaslegkevesebblepesbolLbl.BringToFront();
            this.Controls.Add(megoldaslegkevesebblepesbolLbl);
            pontszam.Text = "Lépések száma: " + lepesekszama;
            pontszam.Location = new Point(550, 25);
            pontszam.BringToFront();
            this.Controls.Add(pontszam);
        }
        private void Klikkeles1(object sender, EventArgs e)
        {
            if (gombnyomasokszama == 0)
            {
                melyikrol = 1;
                gombok[0].Enabled = false;
                gombnyomasokszama++;
                gombok[1].Text = "Hova";
                gombok[2].Text = "Hova";
            }
            else if (gombnyomasokszama == 1)
            {
                melyikre = 1;
                gombok[1].Enabled = true;
                gombok[2].Enabled = true;
                gombnyomasokszama = 0;
                gombok[1].Text = "Honnan";
                gombok[2].Text = "Honnan";
                gombok[0].Text = "Honnan";
                Mozgatas();
            }
            
            
        }
        
        private void Klikkeles2(object sender, EventArgs e)
        {
            if (gombnyomasokszama==0)
            {
                melyikrol = 2;
                gombok[1].Enabled = false;
                gombnyomasokszama++;
                gombok[0].Text = "Hova";
                gombok[2].Text = "Hova";
            }
            else if (gombnyomasokszama == 1)
            {
                melyikre = 2;
                gombok[0].Enabled = true;
                gombok[2].Enabled = true;
                gombnyomasokszama = 0;
                gombok[1].Text = "Honnan";
                gombok[2].Text = "Honnan";
                gombok[0].Text = "Honnan";
                Mozgatas();
            }


        }
        private void Klikkeles3(object sender, EventArgs e)
        {
            if (gombnyomasokszama == 0)
            {
                melyikrol = 3;
                gombok[2].Enabled = false;
                gombnyomasokszama++;
                gombok[0].Text = "Hova";
                gombok[1].Text = "Hova";
            }
            else if (gombnyomasokszama == 1)
            {
                melyikre = 3;
                gombok[1].Enabled = true;
                gombok[0].Enabled = true;
                gombnyomasokszama = 0;
                gombok[1].Text = "Honnan";
                gombok[2].Text = "Honnan";
                gombok[0].Text = "Honnan";
                Mozgatas();
            }

        }

        private void Mozgatas()
        {
            if (melyikrol==honnan)
            {
                if (melyikre==hova)
                {
                    if (RaLehetERakni(honnanlista, hovalista))
                    {
                        GyuruAtRakas(honnanlista, hovalista);
                    }
                }
                if (melyikre==joker)
                {
                    if (RaLehetERakni(honnanlista, jokerlista))
                    {
                        GyuruAtRakas(honnanlista, jokerlista);
                    }
                }
            }
            if (melyikrol == hova)
            {
                if (melyikre == honnan)
                {
                    if (RaLehetERakni(hovalista, honnanlista))
                    {
                        GyuruAtRakas(hovalista, honnanlista);
                    }
                }
                if (melyikre == joker)
                {
                    if (RaLehetERakni(hovalista, jokerlista))
                    {
                        GyuruAtRakas(hovalista, jokerlista);
                    }
                }
            }
            if (melyikrol == joker)
            {
                if (melyikre == honnan)
                {
                    if (RaLehetERakni(jokerlista, honnanlista))
                    {
                        GyuruAtRakas(jokerlista, honnanlista);
                    }
                }
                if (melyikre == hova)
                {
                    if (RaLehetERakni(jokerlista, hovalista))
                    {
                        GyuruAtRakas(jokerlista, hovalista);
                    }
                }
            }
            //rakd oda

        }

        private void GyuruAtRakas(List<Label> honnanka, List<Label> hovacska)
        {
            Label seged = new Label();
            hovacska.Add(honnanka[honnanka.Count - 1]);
            honnanka.RemoveAt(honnanka.Count - 1);
            PozicioAtrakas(hovacska);

        }

        private void PozicioAtrakas(List<Label> labellista)
        {
            labellista[labellista.Count-1].Location = new Point(113 + ((Convert.ToInt32(labellista[labellista.Count-1].Name)-1) * 10)+400*(melyikre-1), 320 - ((labellista.Count-1) * 20));
            lepesekszama++;
            pontszam.Text = "Lépések száma: " + lepesekszama;
            if (hovalista.Count==korongszam)
            {
                MessageBox.Show("Nyertél ügyi bügyi");
                Close();
            }
        }

        private bool RaLehetERakni(List<Label> honnanka, List<Label> hovacska)
        {
            if (hovacska.Count!=0)
            {
                if (Convert.ToInt32(honnanka[honnanka.Count - 1].Name) > Convert.ToInt32(hovacska[hovacska.Count - 1].Name))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void FormBeallitas()
        {
            this.MinimumSize = new Size(1200, 500);
            this.MaximumSize = new Size(1200, 500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
   
}
