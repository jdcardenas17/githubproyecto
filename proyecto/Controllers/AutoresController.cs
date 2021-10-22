using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Dtos;
using proyecto.Models;
using proyecto.Utility;
using proyecto.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController :Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
        //private readonly IValidator<AutoresModels> _validacionAutores;

        
        public AutoresController(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        //Retorna todos los autores
        public async Task<ActionResult<List<AutoresDTO>>> Get()
        {
            var Autores = await appDbContext.autores.ToListAsync();

            return mapper.Map<List<AutoresDTO>>(Autores);
        }
        [HttpGet("{id}", Name = "GetAutores")]
        //Retorna el autor por id
        public async Task<ActionResult<AutoresDTO>> Get(int Id_autores)
        {
            var autor = await appDbContext.autores.FirstOrDefaultAsync(c => c.id_autor == Id_autores);
            if (autor == null)
            {
                return NotFound("");
            }
            return mapper.Map<AutoresDTO>(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AutoresCreationDTO autoresCreationDTO)
        {
            

            var autor = mapper.Map<AutoresModels>(autoresCreationDTO);
            appDbContext.Add(autor);
            await appDbContext.SaveChangesAsync();

            var dto = mapper.Map<AutoresDTO>(autor);
            return new CreatedAtRouteResult("GetAutores", new { id = autor.id_autor }, dto);
        }



    }
}
