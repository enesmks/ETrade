using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage(Messages.CompanyNameCanNotBeEmpty);
            RuleFor(x => x.City).NotEmpty().WithMessage(Messages.CityCanNotBeEmpty);
            RuleFor(x => x.Address).NotEmpty().WithMessage(Messages.AddressCanNotBeEmpty);
            RuleFor(x => x.Country).NotEmpty().WithMessage(Messages.CountryCanNotBeEmpty);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(Messages.PhoneCanNotBeEmpty);
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage(Messages.PostalCodeCanNotBeEmpty);

            RuleFor(x => x.CompanyName).MaximumLength(50).WithMessage(Messages.ErrorOfCompanyNameLength);
            RuleFor(x => x.CompanyName).MinimumLength(2).WithMessage(Messages.ErrorOfCompanyNameLength);

            RuleFor(x => x.Address).MaximumLength(100).WithMessage(Messages.ErrorOfAdressLength);
            RuleFor(x => x.Address).MinimumLength(10).WithMessage(Messages.ErrorOfAdressLength);

            RuleFor(x => x.City).MaximumLength(20).WithMessage(Messages.ErrorOfCityLength);
            RuleFor(x => x.City).MinimumLength(2).WithMessage(Messages.ErrorOfCityLength);

            RuleFor(x => x.Country).MaximumLength(20).WithMessage(Messages.ErrorOfCountryLength);
            RuleFor(x => x.Country).MinimumLength(2).WithMessage(Messages.ErrorOfCountryLength);

            RuleFor(x => x.Phone).MaximumLength(10).WithMessage(Messages.ErrorOfPhoneLength);
            RuleFor(x => x.Phone).MinimumLength(10).WithMessage(Messages.ErrorOfAdressLength);

            RuleFor(x => x.PostalCode).MaximumLength(5).WithMessage(Messages.ErrorOfPostalCodeLength);
            RuleFor(x => x.PostalCode).MinimumLength(5).WithMessage(Messages.ErrorOfPostalCodeLength);
        }
    }
}
