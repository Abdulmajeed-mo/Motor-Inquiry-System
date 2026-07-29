using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor.Inquiry.Application.DTOs
{
    public class InquiryByPlateRequest
    {   
        public string PlateNumber { get; set; }
        public string PlateLetters { get; set; }
    }
}
