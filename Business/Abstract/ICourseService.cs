using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService
    {
        List<Course> GetAll();
        List<CourseDetailDto> GetCourseDetails();
        void Add(Course course);
        void Delete(Course course);
        void Update(Course course);
    }
}
