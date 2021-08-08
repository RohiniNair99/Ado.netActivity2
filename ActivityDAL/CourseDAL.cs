using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;

namespace ActivityDAL
{
    public class CourseDAL
    {

        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public CourseDAL()
        {
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public string AddCourse(CourseDTO courseObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspAddCourses", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CourseId", courseObj.CourseId);
                sqlCmd.Parameters.AddWithValue("@CourseTitle", courseObj.CourseTitle);
                sqlCmd.Parameters.AddWithValue("@CourseDuration", courseObj.CourseDuration);
                sqlCmd.Parameters.AddWithValue("CourseMode", courseObj.CourseMode);
                sqlCmd.Parameters.AddWithValue("@Curriculum", null);

                sqlCon.Open();

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.ParameterName = "ReturnValue";
                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                sqlCmd.Parameters.Add(prmReturn);
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                var rowsAffected=sqlCmd.ExecuteNonQuery();
                int returnVal = Convert.ToInt32(prmReturn.Value);
                return $"\nRows Affected: {rowsAffected} \nReturn Value:{returnVal}";
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }
        }
        public string DeleteCourse(string cid)
        {
            try
            {
                sqlCmd = new SqlCommand("uspDeleteCourse", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CourseId", cid);
                
                sqlCon.Open();

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.ParameterName = "ReturnValue";
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                sqlCmd.Parameters.Add(prmReturn);
                int rowsAffected = sqlCmd.ExecuteNonQuery();
                int returnVal = Convert.ToInt32(prmReturn.Value);
                return $"\nRows Affected:{rowsAffected} \nReturn Value:{returnVal}";
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
