using Fiap.Project.R4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.R4.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Obter(int usuarioId);
        Usuario Login(Usuario user);
        int SalvarUsuario(Usuario usuario);
    }
}
