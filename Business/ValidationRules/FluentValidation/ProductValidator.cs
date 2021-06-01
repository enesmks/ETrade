using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage(Messages.ProductNameCanNotBeEmpty);
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage(Messages.UnitPriceCanNotBeEmpty);
            RuleFor(x => x.UnitsInStock).NotEmpty().WithMessage(Messages.UnitsInStockCanNotBeEmpty);
            RuleFor(x => x.QuantityPerUnit).NotEmpty().WithMessage(Messages.QuantityPerUnitCanNotBeEmpty);

            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage(Messages.ErrorOfProductNameLength);
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage(Messages.ErrorOfProductNameLength);

            RuleFor(x => x.UnitPrice).LessThanOrEqualTo(0).WithMessage(Messages.WrongUnitPrice);
        }
    }
}
