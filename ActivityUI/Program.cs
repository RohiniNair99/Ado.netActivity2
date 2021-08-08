using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityBL;
using ActivityDTO;

namespace ActivityUI
{
    class Program
    {
        static void Main(string[] args)
        {
            FacultyBL facultyblObj=new FacultyBL();
            CourseBL courseblObj=new CourseBL();
            GraderBL graderblObj=new GraderBL();

            FacultyDTO faculty;
            CourseDTO course;
            GraderDTO grader;

            Console.WriteLine("Enter the deatils of Course (CourseId,Course Title,Course Duration,Course Mode");
            string courseId = Console.ReadLine();
            string courseTitle = Console.ReadLine();
            int courseDuration = Convert.ToInt32(Console.ReadLine());
            string courseMode = Console.ReadLine();

            string result=courseblObj.AddCourse(courseId,courseTitle,courseDuration,courseMode);
            Console.WriteLine(result);

            Console.WriteLine("Enter Course Id to delete course");
            string delCourse=Console.ReadLine();
            string delCourseRes = courseblObj.DeleteCourse(delCourse);
            Console.WriteLine(delCourseRes);


            Console.WriteLine("Enter the deatils of Faculty (PSNO,EmailId,Faculty Name)");
            string psno = Console.ReadLine();
            string emailId = Console.ReadLine();
            string facultyName = Console.ReadLine();
            

            string resultFaculty = facultyblObj.AddFaculty(psno,emailId,facultyName);
            Console.WriteLine(resultFaculty);

            Console.WriteLine("Enter Faculty Id to delete faculty");
            string delFaculty = Console.ReadLine();
            string delFacultyRes = courseblObj.DeleteCourse(delCourse);
            Console.WriteLine(delCourseRes);

            Console.WriteLine("Enter Course Id to Get Faculties");
            courseId = Console.ReadLine();
            var resultFac = facultyblObj.GetFacultyFromCId(courseId);
            foreach(var item in resultFac)
            {
                Console.WriteLine(item.CourseId+"|"+item.PSNO+"|"+item.PrimaryFaculty);
            }
            

            Console.WriteLine("Enter Course Id for getting Participants");
            courseId = Console.ReadLine();
            var resultParticipants = graderblObj.GetParticipantsbyCourse(courseId);
            foreach(var item in resultParticipants)
            {
                Console.WriteLine(item.CourseId+"|"+item.PSNO+"|"+item.Score);
            }
            

            Console.WriteLine("Enter Course Id for top and bottom performers");
            courseId = Console.ReadLine();
            var resultTop = graderblObj.TopPerformers(courseId);
            Console.WriteLine("______________TOP PERFORMERS________________");
            foreach(var item in resultTop)
            {
                Console.WriteLine(item.PSNO + "|" + item.Score);
            }

            var resultBottom = graderblObj.BottomPerformance(courseId);
            Console.WriteLine("______________BOTTOM PERFORMERS________________");
            foreach (var item in resultBottom)
            {
                Console.WriteLine(item.PSNO + "|" + item.Score);
            }


        }
    }
}
