using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
            
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public IResult Add(Course course)
        {
            if (course.CourseName.Length > 3 && course.Price > 0)
            {
                _courseDal.Add(course);
                return new SuccessResult(Messages.CourseAdded);
            }

            return new ErrorResult(Messages.CourseNameInvalid);
            
        }

        public IDataResult<List<Course>> GetAll()
        {
            if(DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<Course>>(Messages.Error);
            }

            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(), Messages.CoursesListed);
        }

        public IResult Delete(Course course)
        {
            _courseDal.Delete(course);
            return new SuccessResult(Messages.CourseDeleted);
        }

        public IResult Update(Course course)
        {
            _courseDal.Update(course);
            return new SuccessResult(Messages.CourseUpdated);
        }

        public IDataResult<List<CourseDetailDto>> GetCourseDetails(Expression<Func<Course, bool>> filter = null)
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails(filter));
        }

        public IDataResult<Course> GetById(int Id)
        {
            var result = _courseDal.GetAll(c => c.Id == Id);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Course>(Messages.Error);
            }

            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == Id));
        }
    }
}
