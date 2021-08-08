using AutoMapper;
using IMDb.Api.Controllers;
using IMDb.Api.DTO;
using IMDb.Api.Token;
using IMDb.Business.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace IMDb.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/token")]
    public class AutorizacaoController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public AutorizacaoController(IMapper mapper,
                                  IUsuarioService usuarioService,
                                  IConfiguration configuration,
                                  INotificador notificador) : base(notificador)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Token([FromBody] AutorizacaoDTO atutorizacaoDTO)
        {
            var user = await _usuarioService.ObterPorUserNameSenha(atutorizacaoDTO.Email, atutorizacaoDTO.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user, _configuration);

            return new
            {
                token = token
            };
        }

    }
}
