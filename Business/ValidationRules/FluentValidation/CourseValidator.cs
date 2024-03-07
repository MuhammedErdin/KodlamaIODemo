using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.CourseName).NotEmpty();
            RuleFor(c => c.CourseName).MinimumLength(4);
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.Descriptions).NotEmpty();
        }
    }
}
