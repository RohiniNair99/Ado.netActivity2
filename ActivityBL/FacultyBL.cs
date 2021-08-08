using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDAL;
using ActivityDTO;

namespace ActivityBL
{
    public class FacultyBL
    {

        FacultyDAL dalObj;
        FacultyDTO dtoObj;
        public FacultyBL()
        {
            dalObj = new FacultyDAL();
            dtoObj = new FacultyDTO();
        }

        public string AddFaculty(string psno,string emailId,string name)
        {
            try
            {
                dtoObj = new FacultyDTO { PSNO = psno, EmailId = emailId, FacultyName = name };
                string result = dalObj.AddFaculty(dtoObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteFaculty(string fId)
        {
            try
            {
                string result = dalObj.DeleteFaculty(fId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseFacultyMap_DTO> GetFacultyFromCId(string Cid)
        {
            try
            {
                var listOfFaculty = dalObj.GetFacultyFromCId(Cid);
                return listOfFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
