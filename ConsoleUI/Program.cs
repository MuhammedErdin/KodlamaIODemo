using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Course();
            CourseManager courseManager = new CourseManager(new EfCourseDal());

            foreach (var course in courseManager.GetCourseDetails())
            {
                Console.WriteLine(course.CategoryName + " / " + course.FirstName + " / "
                    + course.LastName + " / " + course.Descriptions + " / " + course.Price);
            }
        }

        private static void Course()
        {
            CourseManager courseManager = new CourseManager(new EfCourseDal());

            foreach (var course in courseManager.GetAll())
            {
                Console.WriteLine(course.CourseName + " / " + course.Descriptions + " / " + course.Price);
            }
        }
    }
}
