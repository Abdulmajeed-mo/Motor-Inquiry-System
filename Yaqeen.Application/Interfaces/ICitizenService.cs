using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaqeen.Domain.Entities;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.DTOs;
namespace Yaqeen.Application.Interfaces
{
    public interface ICitizenService
    {
        Task<bool> ValidateCitizen(CitizenValidationRequest request, CancellationToken cancellationToken);



        //أي سيرفس للمواطن لازم يوفر عملية يجلب المواطن مع عناوينه.
        Task<CitizenAddressResponse?> GetCitizenWithAddressesAsync(string nationalId,CancellationToken cancellationToken);
    }
}
