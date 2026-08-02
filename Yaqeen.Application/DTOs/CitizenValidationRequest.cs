using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaqeen.Application.DTOs
{
    public class CitizenValidationRequest
    {
        public string NationalId { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
