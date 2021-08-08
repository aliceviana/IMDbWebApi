using AutoMapper;
using IMDb.Api.Controllers;
using IMDb.Api.DTO;
using IMDb.Business.Helpers;
using IMDb.Business.Intefaces;
using IMDb.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/filmes")]
    public class FilmesController : MainController
    {
        private readonly IFilmeService _filmeService;
        private readonly IVotoService _votoService;
        private readonly IMapper _mapper;

        public FilmesController(IMapper mapper,
                                IFilmeService filmeService,
                                IVotoService votoService,
                                INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _filmeService = filmeService;
            _votoService = votoService;
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult<FilmeDTO>> Adicionar(FilmeDTO filmeDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _filmeService.Adicionar(_mapper.Map<Filme>(filmeDTO));

            return CustomResponse(filmeDTO);
        }

        [HttpPut("{id:Guid}/votar")]
        [Authorize(Roles = "usuario")]
        public async Task<ActionResult<VotoDTO>> Votar(Guid id, VotoDTO votoDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _votoService.Votar(id, votoDTO.Nota, User.Identity.Name);            

            return CustomResponse(votoDTO);
        }

        [HttpGet]        
        public async Task<ResponseDTO<FilmeResponseDTO>> Obter([FromQuery] FiltroFilme filtro)
        {
            var response = await _filmeService.Obter(filtro);

            return new ResponseDTO<FilmeResponseDTO>(_mapper.Map<List<FilmeResponseDTO>>(response.Dados), response.Total);
        }

        [HttpGet("{id:guid}")]
        public async Task<FilmeResponseDTO> Obter(Guid id)
        {
            return _mapper.Map<FilmeResponseDTO>(await _filmeService.ObterPorId(id));
        }
    }
}
