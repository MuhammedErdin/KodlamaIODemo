using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        [ValidationAspect(typeof(InstructorValidator))]
        public IResult Add(Instructor ınstructor)
        {
            _instructorDal.Add(ınstructor);
            return new SuccessResult(Messages.InstructorAdded);
        }

        public IDataResult<List<Instructor>> GetAll()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll(), Messages.InstructorsListed);
        }

        public IResult Delete(Instructor ınstructor)
        {
            _instructorDal.Delete(ınstructor);
            return new SuccessResult(Messages.InstructorDeleted);
        }

        [ValidationAspect(typeof(InstructorValidator))]
        public IResult Update(Instructor ınstructor)
        {
            _instructorDal.Update(ınstructor);
            return new SuccessResult(Messages.InstructorUpdated);
        }

        public IDataResult<Instructor> GetById(int InstructorId)
        {
            var result = _instructorDal.GetAll(ı => ı.InstructorId == InstructorId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Instructor>(Messages.Error);
            }

            return new SuccessDataResult<Instructor>(_instructorDal.Get(ı => ı.InstructorId == InstructorId));
        }
    }
}
