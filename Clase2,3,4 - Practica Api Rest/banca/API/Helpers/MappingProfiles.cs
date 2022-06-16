using System.Linq;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Usuario,UsuarioToReturnDto>();
            CreateMap<Cuenta,CuentaToReturnDto>()
                .ForMember(d=>d.Propietario, o => o.MapFrom(s=>s.Usuario.Nombre) )
                .ForMember(d=>d.Cedula, o => o.MapFrom(s=>s.Usuario.Cedula) );
        }
    }
}