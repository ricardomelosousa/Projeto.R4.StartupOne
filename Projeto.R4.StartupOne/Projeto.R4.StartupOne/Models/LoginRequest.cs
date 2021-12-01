using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.R4.StartupOne.Models
{
    public class LoginRequest
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public bool Ativo { get; set; }
    }
}
