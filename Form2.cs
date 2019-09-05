using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizzapp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            addquestions a = new addquestions();
            a.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addstudents a = new addstudents();
            a.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            setexam se = new setexam();
            se.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Fetchfile ff = new Fetchfile();
            ff.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
