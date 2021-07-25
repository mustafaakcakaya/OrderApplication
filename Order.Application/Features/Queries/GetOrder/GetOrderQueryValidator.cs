using FluentValidation;

namespace Order.Application.Features.Queries.GetOrder
{
    class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull().WithMessage("{Id} is required.")
                .Length(24).WithMessage("{Id} should be 24 characters.");
        }
    }
}
