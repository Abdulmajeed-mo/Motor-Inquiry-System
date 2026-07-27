using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaqeen.Domain.Entities
{
    public class Vehicle
    {
        public string SequenceNumber { get; set; }
        public string PlateNumber { get; set; }
        public string PlateLetters { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int ModelYear { get; set; }

        public string Color { get; set; }

        public string ChassisNumber { get; set; }

        public string OwnerNationalId { get; set; }


    }
}
