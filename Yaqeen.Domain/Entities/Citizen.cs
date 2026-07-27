using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaqeen.Domain.Entities
{
    public class Citizen
    {
       public string NationalId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FullName  { get; set; }
       public string Gender { get; set; }
        public string Nationality { get; set; }

    }
}
