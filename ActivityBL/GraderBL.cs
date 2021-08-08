using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDAL;
using ActivityDTO;

namespace ActivityBL
{
    public class GraderBL
    {
        GraderDAL dalObj;
        GraderDTO dtoObj;
        public GraderBL()
        {
            dalObj = new GraderDAL();
            dtoObj = new GraderDTO();
        }

        public string AddGrader(GraderDTO obj)
        {
            try
            {
                string result = dalObj.AddGrade(obj);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<GraderDTO> GetParticipantsbyCourse(string courseId)
        {
            try
            {
                var listOfGrades = dalObj.GetParticipantsbyCourse(courseId);
                return listOfGrades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GraderDTO> TopPerformers(string cid)
        {
            try
            {
                var listOfTopPerformers = dalObj.TopPerformers(cid);
                return listOfTopPerformers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<GraderDTO> BottomPerformance(string cid)
        {
            try
            {
                var listOfBottomPerformers = dalObj.BottomPerformance(cid);
                return listOfBottomPerformers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<GraderDTO> GetCoursesFromFacultyId(string psno)
        {
            try
            {
                var listOfCourses = dalObj.GetCoursesFromFacultyId(psno);
                return listOfCourses;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
