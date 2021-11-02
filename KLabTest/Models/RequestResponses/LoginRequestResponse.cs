using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLabTest.Models.RequestResponses
{
    public class LoginRequestResponse
    {
        public string JwtToken { get; private set; }
        public string Email { get; private set; }

        public LoginRequestResponse(string JwtToken, string Email)
        {
            this.JwtToken = JwtToken;
            this.Email = Email;
        }

        public LoginRequestResponse()
        {

        }
    }
}
