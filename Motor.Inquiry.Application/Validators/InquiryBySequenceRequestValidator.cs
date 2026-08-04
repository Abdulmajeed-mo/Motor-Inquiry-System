using FluentValidation;
using Motor.Inquiry.Application.DTOs;

namespace Motor.Inquiry.Application.Validators
{
    public class InquiryBySequenceRequestValidator : AbstractValidator<InquiryBySequenceRequest>
    {
        public InquiryBySequenceRequestValidator()
        {
            RuleFor(x => x.NationalId)   .NotEmpty()  .WithMessage("National ID is required.");

            RuleFor(x => x.NationalId) .Matches(@"^[0-9]{10}$")       .WithMessage("National ID must be exactly 10 digits.");

            RuleFor(x => x.DateOfBirth)   .NotEmpty()  .WithMessage("Date Of Birth is required.");

            RuleFor(x => x.DateOfBirth)  .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))     .WithMessage("Date Of Birth cannot be in the future.");
             
            RuleFor(x => x.SequenceNumber)   .NotEmpty()    .WithMessage("Sequence Number is required.");
        }

    }
}