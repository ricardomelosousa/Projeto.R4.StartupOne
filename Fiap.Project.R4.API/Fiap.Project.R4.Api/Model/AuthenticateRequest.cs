using System.ComponentModel.DataAnnotations;

namespace Fiap.Project.R4.Api.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
