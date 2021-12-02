using Fiap.Project.R4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.R4.Application.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Obter(int usuarioId);
        Usuario Login(string login, string senha);
        int SalvarUsuario(Usuario usuario);

        string GenerateJwtToken(Usuario usuario);
    }
}
