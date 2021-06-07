using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategory>
    {
        public SubCategoryValidator()
        {
            RuleFor(x => x.SubCategoryName).NotEmpty().WithMessage(Messages.SubCategoryCanNotBeEmpty);
        }
    }
}
