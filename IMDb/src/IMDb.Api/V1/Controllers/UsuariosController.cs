using AutoMapper;
using IMDb.Api.Controllers;
using IMDb.Api.DTO;
using IMDb.Business.Helpers;
using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuarios")]
    public class UsuariosController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsuariosController(IMapper mapper,
                                  IUsuarioService usuarioService,
                                  IConfiguration configuration,
                                  INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioDTO>> Adicionar(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioDTO));

            if (usuario != null)
            {
                var usuarioRetorno = _mapper.Map<UsuarioResponseDTO>(usuario);

                return CustomResponse(usuarioRetorno);
            }

            return CustomResponse(usuarioDTO);
        }        
       
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> Atualizar(Guid id, UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            usuario.Id = id;

            await _usuarioService.Atualizar(usuario);

            usuarioDTO.Senha = "";

            return CustomResponse(usuarioDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> Excluir(Guid id)
        {
            var usuarioDTO = await Obter(id);

            if (usuarioDTO == null) return NotFound();

            await _usuarioService.Remover(id);

            return CustomResponse(usuarioDTO);
        }       

        private async Task<UsuarioDTO> Obter(Guid id)
        {
            return _mapper.Map<UsuarioDTO>(await _usuarioService.ObterPorId(id));
        }

        [HttpGet("obter-nao-administradores")]
        [Authorize(Roles = "administrador")]
        public async Task<ResponseDTO<UsuarioResponseDTO>> ObterUsuariosNaoAdministradores([FromQuery] Filtro filtro)
        {
            var response = await _usuarioService.ObterUsuariosNaoAdministradores(filtro);
            return new ResponseDTO<UsuarioResponseDTO>(_mapper.Map<List<UsuarioResponseDTO>>(response.Dados), response.Total);
        }
    }
}
