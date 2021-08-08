using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;
using ActivityDAL;

namespace ActivityBL
{
    public class CourseBL
    {
        CourseDAL dalObj;
        CourseDTO dtoObj;
        public CourseBL()
        {
            dalObj = new CourseDAL();
            dtoObj = new CourseDTO();
        }

        public string AddCourse(string courseId,string courseTitle,int duration,string courseMode)
        {
            try
            {
                dtoObj = new CourseDTO { CourseId = courseId, CourseTitle=courseTitle,CourseDuration= duration, CourseMode=courseMode ,Curriculum=null};
                string result = dalObj.AddCourse(dtoObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteCourse(string courseId)
        {
            try
            {
                string result = dalObj.DeleteCourse(courseId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
