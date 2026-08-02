using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Data;
using Yaqeen.Application.DTOs;

namespace Yaqeen.Application.Services
{
    public class CitizenService : ICitizenService
    {
        public bool ValidateCitizen(CitizenValidationRequest request)
        {
          var isExist = MockData.Citizens.Any(c => c.NationalId == request.NationalId && c.DateOfBirth == request.DateOfBirth);


            return isExist ; 
        }
    }
}

