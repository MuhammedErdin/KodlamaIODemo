using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, DataBaseContext>, ICourseDal
    {
        public List<CourseDetailDto> GetCourseDetails(Expression<Func<Course, bool>> filter = null)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var result = from c in filter == null ? context.Courses : context.Courses.Where(filter)
                             join ı in context.Instructors
                             on c.InstructorId equals ı.InstructorId
                             join ca in context.Categories
                             on c.CategoryId equals ca.CategoryId
                             select new CourseDetailDto
                             {
                                 CourseName = c.CourseName,
                                 CategoryName = ca.CategoryName,
                                 FirstName = ı.FirstName,
                                 LastName = ı.LastName,
                                 Descriptions = c.Descriptions,
                                 Price = c.Price
                             };
                return result.ToList();
            }
        }
    }
}
