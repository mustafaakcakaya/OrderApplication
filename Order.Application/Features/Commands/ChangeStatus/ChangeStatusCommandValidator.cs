using FluentValidation;

namespace Order.Application.Features.Commands.ChangeStatus
{
    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull().WithMessage("{Id} is required.")
                .Length(24).WithMessage("{Id} should be 24 characters.");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{Status} is required.")
                .NotNull().WithMessage("{Status} is required.");
            
        }
    }
}
