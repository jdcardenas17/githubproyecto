using AutoMapper;
using proyecto.Dtos;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Utility
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {

            //-------------Libros----------------------//
            CreateMap<LibrosModels, LibrosDTO>()
                .ReverseMap();
            CreateMap<LibrosCreationDTO, LibrosModels>();

            //---------------Autores--------------------//
            CreateMap<AutoresModels, AutoresDTO>()
                .ReverseMap();
            CreateMap<AutoresCreationDTO, AutoresModels>();
        }
    }
}
