using AutoMapper;
using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<CreateGeneroDTO, Genero>();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<CreateActorDTO, Actor>().ForMember(x => x.Foto, options => options.Ignore());

        }
    }
}
