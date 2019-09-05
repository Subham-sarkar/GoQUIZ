using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace quizzapp
{
    class insertclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;

        public string insert_questions(questions q)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[insert_questions]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@q_title", SqlDbType.NVarChar).Value = q.q_title;
                cmd.Parameters.Add("@q_opa", SqlDbType.NVarChar,200).Value = q.q_opa;
                cmd.Parameters.Add("@q_opb", SqlDbType.NVarChar,200).Value = q.q_opb;
                cmd.Parameters.Add("@q_opc", SqlDbType.NVarChar,200).Value = q.q_opc;
                cmd.Parameters.Add("@q_opd", SqlDbType.NVarChar,200).Value = q.q_opd;
                cmd.Parameters.Add("@q_opcorrect", SqlDbType.NVarChar,200).Value = q.q_opcorrect;
                cmd.Parameters.Add("@q_addeddate", SqlDbType.NVarChar,20).Value = q.q_addeddate;
                cmd.Parameters.Add("@q_fk_ad", SqlDbType.Int).Value = q.q_fk_ad;
                cmd.Parameters.Add("@q_fk_sub", SqlDbType.Int).Value = q.q_fk_sub;

                
                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "data successfully inserted!";
            }
            catch (Exception)
            {
                msg = "data is not successfully inserted!";
            }
            finally
            {
                conn.Close();
            }
            return msg;
        }



        public string insert_setexam(string date,string stid,string exid)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[INSERT_SET_EXAM]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@set_exam_date", SqlDbType.NVarChar).Value = date;
                cmd.Parameters.Add("@stu_id_fk", SqlDbType.NVarChar,10).Value = stid;
                cmd.Parameters.Add("@exam_id_fk", SqlDbType.Int).Value = exid;



                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "data successfully inserted!";
            }
            catch (Exception)
            {
                msg = "data is not successfully inserted!";
            }
            finally
            {
                conn.Close();
            }
            return msg;
        }




        public string insert_score(int score, string stid, string exid)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[insert_score]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@score", SqlDbType.Int).Value = score;
                
                cmd.Parameters.Add("@stu_fk_id", SqlDbType.NVarChar, 10).Value = stid;
                cmd.Parameters.Add("@exam_fk_id", SqlDbType.Int).Value = exid;



                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Score successfully inserted!";
            }
            catch (Exception)
            {
                msg = "Score is not successfully inserted!";
            }
            finally
            {
                conn.Close();
            }
            return msg;
        }

        public string insert_student(student s)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

      
            
            try
            {
                SqlCommand cmd = new SqlCommand("[insert_student]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_name", SqlDbType.NVarChar,20).Value = s.std_name;
                cmd.Parameters.Add("@std_USN", SqlDbType.NVarChar, 10).Value = s.std_USN;
                cmd.Parameters.Add("@std_contact", SqlDbType.NVarChar, 20).Value = s.std_contact;
                cmd.Parameters.Add("@std_sem", SqlDbType.Int).Value = s.std_sem;
                cmd.Parameters.Add("@std_sec", SqlDbType.NVarChar, 1).Value = s.std_sec;
                cmd.Parameters.Add("@std_batchcode", SqlDbType.NVarChar, 20).Value = s.std_batchcode;
                cmd.Parameters.Add("@std_password", SqlDbType.NVarChar, 20).Value = s.std_password;
                cmd.Parameters.Add("@std_ad_id", SqlDbType.Int).Value = s.std_ad_id;
                


                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Student successfully inserted!";
            }
            catch (Exception)
            {
                msg = "Student is not successfully inserted!";
            }
            finally
            {
                conn.Close();
            }
            return msg;
        }
    }
}
