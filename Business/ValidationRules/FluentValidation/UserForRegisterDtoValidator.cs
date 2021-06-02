using Business.Constants;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {        

        public UserForRegisterDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(Messages.FirstNameCanNotBeEmpty);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(Messages.LastNameCanNotBeEmpty);
            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.LastNameCanNotBeEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.PasswordCanNotBeEmpty);

            RuleFor(x => x.FirstName).MaximumLength(20).WithMessage(Messages.ErrorOfFirstNameLength);
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(Messages.ErrorOfFirstNameLength);

            RuleFor(x => x.LastName).MaximumLength(20).WithMessage(Messages.ErrorOfLastNameLength);
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage(Messages.ErrorOfLastNameLength);

            RuleFor(x => x.Email).MaximumLength(50).WithMessage(Messages.ErrorOfEmailLength);
            RuleFor(x => x.Email).MinimumLength(8).WithMessage(Messages.ErrorOfEmailLength);

            RuleFor(x => x.Password).MaximumLength(50).WithMessage(Messages.ErrorOfPasswordlLength);
            RuleFor(x => x.Password).MinimumLength(6).WithMessage(Messages.ErrorOfPasswordlLength);

            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage(Messages.PasswordMustContainUppercase);
            RuleFor(x => x.Password).Matches(@"[a-z]+").WithMessage(Messages.PasswordMustContainLowercase);
            RuleFor(x => x.Password).Matches(@"[0-9]+").WithMessage(Messages.PasswordMustContainNumber);

            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.NeedValidEmailAddress);
        }
    }
}
