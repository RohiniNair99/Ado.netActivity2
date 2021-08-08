using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;

namespace ActivityDAL
{
    public class FacultyDAL
    {

        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public FacultyDAL()
        {
            sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public string AddFaculty(FacultyDTO facultyObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspFacultyAdd", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PSNO", facultyObj.PSNO);
                sqlCmd.Parameters.AddWithValue("@EmailId", facultyObj.EmailId);
                sqlCmd.Parameters.AddWithValue("@FacultyName", facultyObj.FacultyName);

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

        public string DeleteFaculty(string facultyId)
        {
            try
            {
                sqlCmd = new SqlCommand("uspDeleteFaculty", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@psno", facultyId);

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

        public List<CourseFacultyMap_DTO> GetFacultyFromCId(string Cid)
        {
            List<CourseFacultyMap_DTO> lstFaculty = new List<CourseFacultyMap_DTO>();
            try
            {
              
                        sqlCmd = new SqlCommand(@"Select PSNO,PrimaryFaculty from ufnGetFacultyByCId(@Cid) ", sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Cid", Cid);
                        sqlCon.Open();
                        SqlDataReader FacultyFromCourseId = sqlCmd.ExecuteReader();
                        while (FacultyFromCourseId.Read())
                        {
                    lstFaculty.Add(
                        new CourseFacultyMap_DTO
                        {
                            PSNO = FacultyFromCourseId["PSNO"].ToString(),

                            PrimaryFaculty = FacultyFromCourseId["PrimaryFaculty"].ToString()
                        }) ;
                        }
                        return lstFaculty;
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


