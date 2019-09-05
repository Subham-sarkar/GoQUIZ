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
    public partial class addstudents : Form
    {
        public addstudents()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            student s = new student();
            s.std_name = textBox1.Text;
            s.std_USN = textBox2.Text;
            s.std_contact = textBox3.Text;
            s.std_sem = textBox4.Text;
            s.std_sec = textBox5.Text;
            s.std_batchcode = textBox6.Text;
            s.std_password = textBox7.Text;

            s.std_ad_id = AdminLogin.fk_ad;
           

            insertclass ic = new insertclass();
            
            string msg = ic.insert_student(s);
            MessageBox.Show(msg);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
