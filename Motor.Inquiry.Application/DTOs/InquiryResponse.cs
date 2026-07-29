using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor.Inquiry.Application.DTOs
{
    public class InquiryResponse
    {

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
