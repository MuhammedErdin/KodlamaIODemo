using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<Course>> GetAll();
        IDataResult<Course> GetById(int Id);
        IDataResult<List<CourseDetailDto>> GetCourseDetails(Expression<Func<Course, bool>> filter = null);
        IResult Add(Course course);
        IResult Delete(Course course);
        IResult Update(Course course);
    }
}
