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
    public partial class addquestions : Form
    {
        public addquestions()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void addquestions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quizappDataSet2.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter2.Fill(this.quizappDataSet2.subjects);
            // TODO: This line of code loads data into the 'quizappDataSet1.subjects' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'quizappDataSet.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.quizappDataSet.subjects);

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = comboBox1.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questions q = new questions();
            q.q_title = textBox1.Text;
            q.q_opa = textBox2.Text;
            q.q_opb = textBox3.Text;
            q.q_opc = textBox4.Text;
            q.q_opd = textBox5.Text;
            q.q_opcorrect = textBox6.Text;
            q.q_addeddate = System.DateTime.Now.ToShortDateString();
            q.q_fk_ad = AdminLogin.fk_ad;
            q.q_fk_sub = comboBox1.SelectedValue.ToString();

            insertclass ic = new insertclass();
            
            string msg =ic.insert_questions(q);
            MessageBox.Show(msg);
            textbox();
        }
        public void textbox()
        {
            textBox1.Text= string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
