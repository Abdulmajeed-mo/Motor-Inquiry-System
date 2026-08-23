using FluentValidation;
using FluentValidation.AspNetCore;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Application.Mapping;
using Motor.Inquiry.Application.Services;
using Motor.Inquiry.Application.Validators;

namespace Motor.Inquiry.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IInquiryService, InquiryService>();

        services.AddFluentValidationAutoValidation();

        services.AddAutoMapper(cfg =>{cfg.AddProfile<InquiryMappingProfile>();});


        //ليس معناها أننا نسجل الـ Sequence Validator فقط.
        //كنقطة مرجعية للـ Assembly
        services.AddValidatorsFromAssemblyContaining<InquiryBySequenceRequestValidator>();

        return services;
    }
}