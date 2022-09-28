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
        public Form1()
        {
            toronyGeneralas();
            InitializeComponent();
        }

        private void toronyGeneralas()
        {
            PictureBox torony = new PictureBox();


                torony.Name = "pictureBox";
                torony.Size = new Size(16, 16);
                torony.Location = new Point(100, 100);
                torony.Image = Image.FromFile("torony.png");

            
            this.Controls.Add(torony);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int honnan = Convert.ToInt32(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int hova = Convert.ToInt32(textBox3.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int korongszam = Convert.ToInt32(numericUpDown1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //majd ellenorzunk
            //form beallitasa
            //tornyok generalasa
            //3 gomb generalasa
            //korongszam label generalas
            //label szeleseg/szin beallito metodus
            //label pozicio metodus
        }
    }
}
