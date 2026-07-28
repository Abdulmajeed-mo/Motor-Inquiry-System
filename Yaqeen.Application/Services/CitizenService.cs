using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Data;

namespace Yaqeen.Application.Services
{
    public class CitizenService : ICitizenService
    {
        public bool ValidateCitizen(string nationalId)
        {
          var isExist = MockData.Citizens.Any(c => c.NationalId == nationalId);


            return isExist ; 
        }
    }
}

