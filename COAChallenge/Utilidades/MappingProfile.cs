using AutoMapper;
using COAChallenge.Dtos;
using COAChallenge.Entidades;

namespace COAChallenge.Utilidades
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioToReturnDto>().PreserveReferences();
            CreateMap<UsuarioDto, Usuario>().PreserveReferences();
        }
    }
}