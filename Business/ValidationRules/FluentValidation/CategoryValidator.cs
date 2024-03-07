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
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(Ca => Ca.CategoryName).NotEmpty();
            RuleFor(Ca => Ca.CategoryName).MinimumLength(2).Must(IsLetter).WithMessage("Kategori adı sadece harflerden oluşmalı");
        }

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$");
            return regex.IsMatch(arg);
        }
    }
}
