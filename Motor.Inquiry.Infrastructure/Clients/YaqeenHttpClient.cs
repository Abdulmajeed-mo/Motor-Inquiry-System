using Motor.Inquiry.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor.Inquiry.Infrastructure.Clients
{
    public class YaqeenHttpClient : IYaqeenHttpClient
    {


       //private field

        private readonly HttpClient _httpClient;

        //constructor
        public YaqeenHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }




    }
}
