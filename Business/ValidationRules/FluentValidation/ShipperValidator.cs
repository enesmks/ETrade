using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ShipperValidator : AbstractValidator<Shipper>
    {
        public ShipperValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage(Messages.CompanyNameCanNotBeEmpty);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(Messages.PhoneCanNotBeEmpty);

            RuleFor(x => x.CompanyName).MaximumLength(50).WithMessage(Messages.ErrorOfCompanyNameLength);
            RuleFor(x => x.CompanyName).MinimumLength(2).WithMessage(Messages.ErrorOfCompanyNameLength);

            RuleFor(x => x.Phone).MaximumLength(10).WithMessage(Messages.ErrorOfPhoneLength);
            RuleFor(x => x.Phone).MinimumLength(10).WithMessage(Messages.ErrorOfPhoneLength);
        }
    }
}
