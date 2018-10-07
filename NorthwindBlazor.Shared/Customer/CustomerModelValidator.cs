using FluentValidation;
using FluentValidation.Internal;

namespace NorthwindBlazor.Shared.Customer
{
    public class CustomerModelValidator: AbstractValidator<CustomerModel>
    {

        public CustomerModelValidator()
        {
            RuleFor(c => c.CompanyName)
                .NotEmpty()
                .WithMessage("Required");
        }
    }
}