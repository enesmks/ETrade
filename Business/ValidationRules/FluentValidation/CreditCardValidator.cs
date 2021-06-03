using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {        
        public CreditCardValidator()
        {
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage(Messages.CardNumberCanNotBeEmpty);
            RuleFor(x => x.Cvv).NotEmpty().WithMessage(Messages.CvvCanNotBeEmpty);
            RuleFor(x => x.ExpMonth).NotEmpty().WithMessage(Messages.ExpMonthCanNotBeEmpty);
            RuleFor(x => x.ExpYear).NotEmpty().WithMessage(Messages.ExpYearCanNotBeEmpty);

            RuleFor(x => x.CardNumber).MaximumLength(16).WithMessage(Messages.ErrorOfCardNumberLength);
            RuleFor(x => x.CardNumber).MinimumLength(16).WithMessage(Messages.ErrorOfCardNumberLength);

            RuleFor(x => x.Cvv).MaximumLength(3).WithMessage(Messages.ErrorOfCvvLength);
            RuleFor(x => x.Cvv).MinimumLength(3).WithMessage(Messages.ErrorOfCvvLength);            
        }
    }
}
