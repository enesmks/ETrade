using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {

        public EmployeeValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage(Messages.AddressCanNotBeEmpty);
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(Messages.BirthdayCanNotBeEmpty);
            RuleFor(x => x.City).NotEmpty().WithMessage(Messages.CityCanNotBeEmpty);
            RuleFor(x => x.Country).NotEmpty().WithMessage(Messages.CountryCanNotBeEmpty);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(Messages.FirstNameCanNotBeEmpty);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(Messages.LastNameCanNotBeEmpty);
            RuleFor(x => x.HireDate).NotEmpty().WithMessage(Messages.HireDateCanNotBeEmpty);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(Messages.PhoneCanNotBeEmpty);
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage(Messages.PostalCodeCanNotBeEmpty);

            RuleFor(x => x.Address).MaximumLength(100).WithMessage(Messages.ErrorOfAdressLength);
            RuleFor(x => x.Address).MaximumLength(10).WithMessage(Messages.ErrorOfAdressLength);

            RuleFor(x => x.FirstName).MaximumLength(20).WithMessage(Messages.ErrorOfFirstNameLength);
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(Messages.ErrorOfFirstNameLength);

            RuleFor(x => x.LastName).MaximumLength(20).WithMessage(Messages.ErrorOfLastNameLength);
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage(Messages.ErrorOfLastNameLength);

            RuleFor(x => x.Country).MaximumLength(20).WithMessage(Messages.ErrorOfCountryLength);
            RuleFor(x => x.Country).MinimumLength(2).WithMessage(Messages.ErrorOfCountryLength);

            RuleFor(x => x.Phone).MaximumLength(10).WithMessage(Messages.ErrorOfPhoneLength);
            RuleFor(x => x.Phone).MinimumLength(10).WithMessage(Messages.ErrorOfPhoneLength);

            RuleFor(x => x.PostalCode).MaximumLength(5).WithMessage(Messages.ErrorOfPostalCodeLength);
            RuleFor(x => x.PostalCode).MinimumLength(5).WithMessage(Messages.ErrorOfPostalCodeLength);

            RuleFor(x => x.City).MaximumLength(20).WithMessage(Messages.ErrorOfCityLength);
            RuleFor(x => x.City).MinimumLength(2).WithMessage(Messages.ErrorOfCityLength);

            RuleFor(x => x.BirthDate).LessThanOrEqualTo(DateTime.Now).WithMessage(Messages.WrongBirthDate);
            RuleFor(x => x.HireDate).GreaterThan(DateTime.Now).WithMessage(Messages.WrongHireDate);
        }
    }
}
