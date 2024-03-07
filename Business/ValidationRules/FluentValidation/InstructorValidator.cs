using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class InstructorValidator : AbstractValidator<Instructor>
    {
        public InstructorValidator()
        {
            RuleFor(I=>I.FirstName).NotEmpty();
            RuleFor(I => I.FirstName).MinimumLength(3).Must(IsLetter).WithMessage("Eğitmen adı sadece harflerden oluşmalı");
            RuleFor(I=>I.LastName).NotEmpty();
            RuleFor(I=>I.LastName).MinimumLength(3).Must(IsLetter).WithMessage("Eğitmen soyadı sadece harflerden oluşmalı");
        }

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$");
            return regex.IsMatch(arg);
        }
    }
}
