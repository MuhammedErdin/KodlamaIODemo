﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        IDataResult<List<Instructor>> GetAll();
        IDataResult<Instructor> GetById(int InstructorId);
        IResult Add(Instructor ınstructor);
        IResult Delete(Instructor ınstructor);
        IResult Update(Instructor ınstructor);
    }
}
