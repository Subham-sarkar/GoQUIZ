using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizzapp
{
    public partial class studentlogin : Form
    {
        public static string exam_id,studentid;
        public studentlogin()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb, passworddb;
            
            returnclass rc = new returnclass();

            userdb = rc.scalarReturn("select count(std_USN) from student_record where std_USN='"+ textBox1.Text+"'");

            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid username!!!");
            }
            else
            {
                passworddb = rc.scalarReturn("select std_password from student_record where std_USN='" + textBox1.Text + "'");

                if (passworddb.Equals(password))
                {

                    // MessageBox.Show("login success!!!");
                    string val = rc.scalarReturn(" select count(std_USN) from student_record where std_USN='(select stu_id_fk from set_exam where stu_id_fk='"+textBox1.Text+"' and exam_id_fk="+comboBox1.SelectedValue.ToString()+")'");
                    if (val.Equals("0"))
                    {
                        MessageBox.Show("No such exam set!!!");
                    }
                    else
                    {
                        studentid = textBox1.Text;
                        exam_id = comboBox1.SelectedValue.ToString();
                        test t = new test();
                        t.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void studentlogin_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dadpter2 = new SqlDataAdapter("select * from subjects", "Data Source=DESKTOP-2K3QFUN\\SARKARSQL;Initial Catalog=quizapp;Persist Security Info=True;User ID=sa;Password=qwerty1234");
            DataSet dset2 = new DataSet();
            dadpter2.Fill(dset2);
            comboBox1.DataSource = dset2.Tables[0];
            comboBox1.DisplayMember = "sub_name"; //to display roll no.in combobox
            comboBox1.ValueMember = "sub_id";
        }
    }
}
