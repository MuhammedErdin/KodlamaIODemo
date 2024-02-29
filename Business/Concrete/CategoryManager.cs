using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            if (category.CategoryName.Length > 3)
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.CategoryAdded);
            }

            return new ErrorResult(Messages.CategoryNameInvalid);

        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IDataResult<Category> GetById(int CategoryId)
        {
            var result = _categoryDal.GetAll(c => c.CategoryId == CategoryId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Category>(Messages.Error);
            }

            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == CategoryId));
        }
    }
}
