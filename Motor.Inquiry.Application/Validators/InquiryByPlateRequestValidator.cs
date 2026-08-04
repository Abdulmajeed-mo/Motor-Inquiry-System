using FluentValidation;
using Motor.Inquiry.Application.DTOs;
namespace Motor.Inquiry.Application.Validators
{
    public class InquiryByPlateRequestValidator : AbstractValidator<InquiryByPlateRequest>
    {
        public InquiryByPlateRequestValidator()
        
            {
            RuleFor(x => x.NationalId)      .NotEmpty()      .WithMessage("National ID is required.");   
             
            
            RuleFor(x => x.NationalId)     .Matches(@"^[0-9]{10}$")     .WithMessage("National ID must be exactly 10 digits.");
             
            RuleFor(x => x.DateOfBirth)    .NotEmpty()          .WithMessage("Date Of Birth is required.");   
              
            RuleFor(x => x.DateOfBirth)    .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))   .WithMessage("Date Of Birth cannot be in the future.");

            RuleFor(x => x.PlateNumber)    .NotEmpty()          .WithMessage("Plate Number is required.");

            RuleFor(x => x.PlateNumber)   .Matches(@"^[0-9]+$")   .WithMessage("Plate Number must contain numbers only.");


            RuleFor(x => x.PlateLetters)     .NotEmpty()          .WithMessage("Plate Letters is required.");

            RuleFor(x => x.PlateLetters)     .Matches(@"^[A-Z]{3}$")     .WithMessage("Plate Letters must be 3 uppercase letters.");

        }
        
    }
}
