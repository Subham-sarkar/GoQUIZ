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
    public partial class test : Form
    {
        public static int score = 0;
       
        int i,C=0;
        string correctop;
        public test()
        {
            InitializeComponent();
        }

        returnclass rc = new returnclass();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void test_Load(object sender, EventArgs e)
        {
            score = 0;
            label3.Text = score.ToString();
            i = Convert.ToInt32(rc.scalarReturn(" select min(q_id) from questions where q_fk_sub="+studentlogin.exam_id));
            label1.Text = rc.scalarReturn("select q_title from questions where q_id=" + i+"and q_fk_sub=" + studentlogin.exam_id);
            radioButton1.Text = rc.scalarReturn("select q_opa from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
            radioButton2.Text = rc.scalarReturn("select q_opb from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
            radioButton3.Text = rc.scalarReturn("select q_opc from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
            radioButton4.Text = rc.scalarReturn("select q_opd from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
            correctop = rc.scalarReturn("select q_opcorrect from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
        }

        string s,lastquestion,selectedvalue;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            C++;


            if(radioButton1.Checked==true)
            {
                selectedvalue = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                selectedvalue = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                selectedvalue = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                selectedvalue = radioButton4.Text;
            }
            else
            {
                MessageBox.Show("please select one option!");
            }

            if (selectedvalue.Equals(correctop))
            {
                score++;
                label3.Text = score.ToString();

            }

            s = rc.scalarReturn("select min(q_id) from questions where q_id>"+i+ "and q_fk_sub=" + studentlogin.exam_id);
            lastquestion = rc.scalarReturn("select max(q_id) from questions where q_id>" + i + "and q_fk_sub=" + studentlogin.exam_id);
            if (s.Equals(""))
            {
                MessageBox.Show("quiz over!");
                button1.Enabled = false;

                if (lastquestion.Equals(s))
                {


                    insertclass IC = new insertclass();
                    IC.insert_score(score, studentlogin.studentid, studentlogin.exam_id);


                    this.Enabled = false;
                    messageform mf = new messageform();
                    mf.Show();
                }
            }
            else
            {


                i = Convert.ToInt32(s);
                
                label1.Text = rc.scalarReturn("select q_title from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
                radioButton1.Text = rc.scalarReturn("select q_opa from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
                radioButton2.Text = rc.scalarReturn("select q_opb from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
                radioButton3.Text = rc.scalarReturn("select q_opc from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
                radioButton4.Text = rc.scalarReturn("select q_opd from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
                correctop = rc.scalarReturn("select q_opcorrect from questions where q_id=" + i + "and q_fk_sub=" + studentlogin.exam_id);
            }
            

            
            radiobtn();
        }
        public void radiobtn()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;


        }
    }
}
