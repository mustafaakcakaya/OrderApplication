using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Features.Commands.UpdateOrder
{
    class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull().WithMessage("{Id} is required.")
                .Length(24).WithMessage("{Id} should be 24 characters.");
            
            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("{CustomerId} is required.")
                .NotNull().WithMessage("{CustomerId} is required.")
                .Length(24).WithMessage("{CustomerId} should be 24 characters.");

            RuleFor(p => p.Quantity)
                .NotNull().WithMessage("{Quantity} is required.")
               .GreaterThan(0).WithMessage("{Quantity} should be greater then zero.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Price} is required.")
                .GreaterThan(0).WithMessage("{Price} should be greater than zero.");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{Status} is required.")
                .NotNull().WithMessage("{Status} is required.")
                .MinimumLength(3).WithMessage("{Status} should be at least 3 characters.");

            RuleFor(p => p.Address.City)
                .NotEmpty().WithMessage("{City} is required.")
                .NotNull().WithMessage("{City} is required.")
                .MinimumLength(3).WithMessage("{City} should be at least 3 characters.");
            RuleFor(p => p.Address.CityCode)
                .NotNull().WithMessage("{CityCode} is required.")
                .GreaterThanOrEqualTo(1).WithMessage("{CityCode} should be at greater then 0.")
                .LessThanOrEqualTo(81).WithMessage("{CityCode} should be less then or equal 81.");
            RuleFor(p => p.Address.Country)
                .NotEmpty().WithMessage("{Country} is required.")
                .NotNull().WithMessage("{Country} is required.")
                .MinimumLength(3).WithMessage("{Country} should be at least 3 characters.");

        }
    }
}
