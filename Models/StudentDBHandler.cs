using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCInterview.Models
{
    public class StudentDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["StudentInfo"].ToString();
            con = new SqlConnection(constring);
        }

        // 1. ********** Insertion Query **********
        public bool InsertStudent(StudentInfoModel studentInfoModel)
        {
            connection();
            string query = "INSERT INTO studentInfo VALUES('" + studentInfoModel.Name + "','" + studentInfoModel.Email + "' ,'"+studentInfoModel.Rollno+ "', '" + studentInfoModel.Phone + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        // Get All List
        public List<StudentInfoModel> GetStudentList()
        {
            connection();
            List<StudentInfoModel> stList = new List<StudentInfoModel>();

            string query = "SELECT * FROM studentInfo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                stList.Add(new StudentInfoModel
                {
                    stID = Convert.ToInt32(dr["st_id"]),
                    Name = Convert.ToString(dr["st_name"]),
                    Rollno = Convert.ToString(dr["st_roll"]),
                    Phone = Convert.ToString(dr["st_phone"]),
                    Email = Convert.ToString(dr["st_email"])
                });
            }
            return stList;
        }

    }
}