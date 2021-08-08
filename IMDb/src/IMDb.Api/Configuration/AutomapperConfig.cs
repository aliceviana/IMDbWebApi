using AutoMapper;
using IMDb.Api.DTO;
using IMDb.Business.Models;

namespace IMDb.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseDTO>().ReverseMap();
            CreateMap<Filme, FilmeDTO>().ReverseMap();
            CreateMap<Filme, FilmeResponseDTO>().ReverseMap();
            CreateMap<Ator, AtorDTO>().ReverseMap();
        }
    }
}