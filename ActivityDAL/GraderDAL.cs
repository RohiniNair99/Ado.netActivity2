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
    public class GraderDAL
    {
		SqlConnection sqlCon;
		SqlCommand sqlCmd;

		public GraderDAL()
		{
			sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
		}

		public string AddGrade(GraderDTO graderObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspGraderInput", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BCFId", graderObj.PSNO);
                sqlCmd.Parameters.AddWithValue("@PSNO", graderObj.PSNO);
                sqlCmd.Parameters.AddWithValue("@Score", graderObj.Score);

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

		public List<GraderDTO> GetParticipantsbyCourse(string courseId)
		{
			List<GraderDTO> listOfParticipants = new List<GraderDTO>();
			try
			{

				sqlCmd = new SqlCommand(@"Select PSNO,Score from ufnGetParticipantsByCId(@cId)", sqlCon);
				sqlCmd.Parameters.AddWithValue("@cId", courseId);
				sqlCon.Open();
				SqlDataReader drParticipants = sqlCmd.ExecuteReader();
				while (drParticipants.Read())
				{
					listOfParticipants.Add(
						new GraderDTO
						{

							PSNO = Convert.ToInt32(drParticipants["PSNO"].ToString()),
							Score = Convert.ToInt32(drParticipants["Score"].ToString())
						});
				}
				return listOfParticipants;
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

        public List<GraderDTO> TopPerformers(string cid)
        {
            List<GraderDTO> lstToppers = new List<GraderDTO>();

            try
            {
                sqlCmd = new SqlCommand(@"Select PSNO,Score from ufnTopFiveScoreByCId", sqlCon);
                sqlCmd.Parameters.AddWithValue("@courseId", cid);
                sqlCon.Open();
                SqlDataReader BottomPerformerRead = sqlCmd.ExecuteReader();
                while (BottomPerformerRead.Read())
                {
                    lstToppers.Add(
                        new GraderDTO
                        {
                            PSNO = Convert.ToInt32(BottomPerformerRead["PSNO"].ToString()),
                            Score = Convert.ToDouble(BottomPerformerRead["Score"].ToString())
                        });
                }
                return lstToppers;
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

        public List<GraderDTO> BottomPerformance(string cid)
        {
            List<GraderDTO> lstBottomPerformers = new List<GraderDTO>();
            try
            {
                sqlCmd = new SqlCommand(@"Select PSNO,Score from ufnBottomFiveScoreByCId", sqlCon);
                sqlCmd.Parameters.AddWithValue("@courseId", cid);
                sqlCon.Open();
                SqlDataReader BottomPerformerRead = sqlCmd.ExecuteReader();
                while (BottomPerformerRead.Read())
                {
                    lstBottomPerformers.Add(
                        new GraderDTO
                        {
                            PSNO = Convert.ToInt32(BottomPerformerRead["PSNO"].ToString()),
                            Score = Convert.ToDouble(BottomPerformerRead["Score"].ToString())
                        });
                }
                return lstBottomPerformers;
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

        public List<GraderDTO> GetCoursesFromFacultyId(string psno)
        {
            List<GraderDTO> lstGraderCourses = new List<GraderDTO>();
            try
            {
                sqlCmd = new SqlCommand(@"Select PSNO,Score,CourseId from ufnGetCourseScoreByFId(@PSNO)", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PSNO", psno);
                sqlCon.Open();
                SqlDataReader GraderRead = sqlCmd.ExecuteReader();
                while (GraderRead.Read())
                {
                    lstGraderCourses.Add(
                        new GraderDTO
                        {
                            PSNO = Convert.ToInt32(GraderRead["PSNO"].ToString()),
                            Score = Convert.ToDouble(GraderRead["Score"].ToString()),
                            CourseId = GraderRead["CourseId"].ToString()
                        }); ;
                }
                return lstGraderCourses;
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
