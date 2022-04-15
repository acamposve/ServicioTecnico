using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Application.DTOs.Account
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
