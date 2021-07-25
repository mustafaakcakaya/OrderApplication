using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Features.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull().WithMessage("{Id} is required.")
                .Length(24).WithMessage("{Id} should be 24 characters.");
        }
    }
}
