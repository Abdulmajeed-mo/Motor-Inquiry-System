using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor.Inquiry.Domain.Entities
{
    public class Inquiry
    {
        public int InquiryId { get; set; }
        public int SequenceNumber { get; set; }

        public string PlateNumber { get; set; }

        public string PlateLetters { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int ModelYear { get; set; }

        public string Color { get; set; }

        public string ChassisNumber { get; set; }
    }
}
