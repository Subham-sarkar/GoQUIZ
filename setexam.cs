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
    public partial class setexam : Form
    {
        public setexam()
        {
            InitializeComponent();
        }

        private void setexam_Load(object sender, EventArgs e)
        {
            string q = "select * from student_record";
            viewclass vc = new viewclass(q);
            dataGridView1.DataSource = vc.showrecord();

            SqlDataAdapter dadpter = new SqlDataAdapter("Select distinct std_batchcode from student_record", "Data Source=DESKTOP-2K3QFUN\\SARKARSQL;Initial Catalog=quizapp;Persist Security Info=True;User ID=sa;Password=qwerty1234");
            DataSet dset = new DataSet();
            dadpter.Fill(dset);
            comboBox1.DataSource = dset.Tables[0];
            comboBox1.DisplayMember = "std_batchcode"; //to display roll no.in combobox
            comboBox1.ValueMember = "std_batchcode";


            SqlDataAdapter dadpter2 = new SqlDataAdapter("select * from subjects", "Data Source=DESKTOP-2K3QFUN\\SARKARSQL;Initial Catalog=quizapp;Persist Security Info=True;User ID=sa;Password=qwerty1234");
            DataSet dset2 = new DataSet();
            dadpter2.Fill(dset2);
            comboBox2.DataSource = dset2.Tables[0];
            comboBox2.DisplayMember = "sub_name"; //to display roll no.in combobox
            comboBox2.ValueMember = "sub_id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select * from student_record where std_batchcode='" + comboBox1.SelectedValue.ToString()+"'";
            viewclass vc = new viewclass(q);
            dataGridView1.DataSource = vc.showrecord();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertclass ic = new insertclass();
            ic.insert_setexam(System.DateTime.Now.ToShortDateString(), textBox1.Text, comboBox2.SelectedValue.ToString());

            string q = "select * from set_exam";
            viewclass vc = new viewclass(q);
            dataGridView2.DataSource = vc.showrecord();
            q = "select * from student_record where std_batchcode='" + comboBox1.SelectedValue.ToString() + "'";

            viewclass vc2 = new viewclass(q);
            dataGridView1.DataSource = vc2.showrecord();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
