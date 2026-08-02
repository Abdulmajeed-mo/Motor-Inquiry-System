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
        bool ValidateCitizen(CitizenValidationRequest request);
    
    }
}
