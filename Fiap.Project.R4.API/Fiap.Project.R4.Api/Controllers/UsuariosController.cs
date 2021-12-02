using Fiap.Project.R4.Api.Helpers;
using Fiap.Project.R4.Api.Model;
using Fiap.Project.R4.Api.Validator;
using Fiap.Project.R4.Application.Interfaces;
using Fiap.Project.R4.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Project.R4.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {

            _usuarioService = usuarioService;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var validator = new AuthenticateRequestValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);

            var user = _usuarioService.Login(model.Login, model.Senha);
            // return null if user not found
            if (user == null) return Unauthorized("Login ou Senha incorreto");
            var token = _usuarioService.GenerateJwtToken(user);
            return Ok(new AuthenticateResponse(user, token));
        }

        [Authorize]
        [HttpGet("BuscarPorId")]
        public IActionResult GetbyId(int id)
        {
            var users = _usuarioService.Obter(id);
            return Ok(users);
        }

        [Authorize]
        [HttpPost("Criar")]
        public IActionResult Criar(Usuario usuario) 
        {
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);

            var userId = _usuarioService.SalvarUsuario(usuario);
            return Ok($"Usuarioid {userId} criado com sucesso.");
        }

    }
}
