using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace quizzapp
{
    public partial class Fetchfile : Form
    {
        private string connectionString = "Data Source=DESKTOP-2K3QFUN\\SARKARSQL;Initial Catalog=quizapp;Persist Security Info=True;User ID=sa;Password=qwerty1234";
        public string q;
        public Fetchfile()
        {
            InitializeComponent();
        }

        private void Fetchfile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quizappDataSet4.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.quizappDataSet4.subjects);

            

            SqlDataAdapter dadpter = new SqlDataAdapter("Select distinct std_batchcode from student_record", "Data Source=DESKTOP-2K3QFUN\\SARKARSQL;Initial Catalog=quizapp;Persist Security Info=True;User ID=sa;Password=qwerty1234");
            DataSet dset = new DataSet();
            dadpter.Fill(dset);
            comboBox1.DataSource = dset.Tables[0];
            comboBox1.DisplayMember = "std_batchcode"; //to display roll no.in combobox
            comboBox1.ValueMember = "std_batchcode";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            q = "SELECT student_record.std_USN, student_record.std_name, student_record.std_batchcode, student_record.std_sem, student_record.std_sec, score.score, subjects.sub_name, set_exam.set_exam_date, subjects.sub_id FROM score INNER JOIN student_record ON score.stu_fk_id = student_record.std_USN and student_record.std_batchcode='" + comboBox1.SelectedValue.ToString() + "' INNER JOIN set_exam ON student_record.std_USN = set_exam.stu_id_fk INNER JOIN subjects ON score.exam_fk_id = subjects.sub_id AND set_exam.exam_id_fk = subjects.sub_id and subjects.sub_name='" + comboBox2.SelectedValue.ToString()+"'";
            viewclass vc = new viewclass(q);
            dataGridView1.DataSource = vc.showrecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
           
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
              SqlConnection cnn;

      

            string sql = null;

            string data = null;

            int i = 0;

            int j = 0;



            Excel.Application xlApp;

            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);





            cnn = new SqlConnection(connectionString);

            cnn.Open();

            sql = q;

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);

            DataSet ds = new DataSet();

            dscmd.Fill(ds);



            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)

            {

                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)

                {

                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();

                    xlWorkSheet.Cells[i + 1, j + 1] = data;

                }

            }



            xlWorkBook.SaveAs(@"C:\Users\Subham Sarkar\Desktop\studentReport.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();



            releaseObject(xlWorkSheet);

            releaseObject(xlWorkBook);

            releaseObject(xlApp);



            MessageBox.Show("Excel file created , you can find the file ");


             
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
