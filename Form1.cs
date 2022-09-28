﻿using System;
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
                nev[i].Size = new Size(400, 400);
                nev[i].Location = new Point(110+(400*i), 125);
                nev[i].Image = Image.FromFile("torony.png");
                this.Controls.Add(nev[i]);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            honnan = Convert.ToInt32(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            hova = Convert.ToInt32(textBox3.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            korongszam = Convert.ToInt32(numericUpDown1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //majd ellenorzunk
            //form beallitasa
            FormBeallitas();
            //tornyok generalasa
            ToronyGeneralas();
            //3 gomb generalasa
            //korongszam label generalas
            KorongBeall();
            //label szeleseg/szin beallito metodus
            //label pozicio metodus
        }

        private void KorongBeall()
        {
            Label[] korong = new Label[korongszam];
            for (int i = 0; i < korongszam; i++)
            {
                    korong[i] = new Label();
                    korong[i].Name = "korong" + i;
                    korong[i].Size = new Size(400, 400);
                    korong[i].Location = new Point(110 + (400 * i), 125);
                    korong[i].BackColor = Color.Black;
                    korong[i].Text = "";
                    this.Controls.Add(korong[i]);
            }
        }

        private void FormBeallitas()
        {
            this.Size = new Size(1200, 500);
        }
    }
}
