using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.ShipCity).NotEmpty().WithMessage(Messages.ShipCityCanNotBeEmpty);
            RuleFor(x => x.ShipCountry).NotEmpty().WithMessage(Messages.ShipCountryCanNotBeEmpty);
            RuleFor(x => x.ShipAddress).NotEmpty().WithMessage(Messages.ShipAddressNotBeEmpty);
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage(Messages.OrderDateCanNotBeEmpty);
            RuleFor(x => x.ShipAddress).NotEmpty().WithMessage(Messages.ShipAddressCanNotBeEmpty);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(Messages.PhoneCanNotBeEmpty);

            RuleFor(x => x.ShipAddress).MaximumLength(100).WithMessage(Messages.ErrorOfAdressLength);
            RuleFor(x => x.ShipAddress).MinimumLength(10).WithMessage(Messages.ErrorOfAdressLength);

            RuleFor(x => x.ShipCity).MaximumLength(20).WithMessage(Messages.ErrorOfCityLength);
            RuleFor(x => x.ShipCity).MinimumLength(2).WithMessage(Messages.ErrorOfCityLength);

            RuleFor(x => x.ShipCountry).MaximumLength(20).WithMessage(Messages.ErrorOfCountryLength);
            RuleFor(x => x.ShipCountry).MinimumLength(2).WithMessage(Messages.ErrorOfCountryLength);

            RuleFor(x => x.Phone).MaximumLength(10).WithMessage(Messages.ErrorOfPhoneLength);
            RuleFor(x => x.Phone).MinimumLength(10).WithMessage(Messages.ErrorOfPhoneLength);

            RuleFor(x => x.ArrivalDate).LessThanOrEqualTo(DateTime.Now).WithMessage(Messages.WrongArrivalDate);
        }
    }
}
