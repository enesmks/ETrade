using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(Messages.CategoryCanNotBeEmpty);
        }
    }
}
