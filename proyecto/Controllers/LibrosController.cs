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
    [Route("/api/libros")]
    public class LibrosController :Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
        

        public LibrosController(AppDbContext appDbContext,IMapper mapper)
        {

            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        //Retorna todos los libros
        public async Task<ActionResult<List<LibrosDTO>>> Get()
        {
            var Libros = await appDbContext.libros.ToListAsync();
            return mapper.Map<List<LibrosDTO>>(Libros);
        }

        [HttpGet("{id}",Name ="GetLibros")]
        //Retorna el libro por id
        public async Task<ActionResult<LibrosDTO>> Get(int Id_libros)
        {
            var libro = await appDbContext.libros.FirstOrDefaultAsync(c => c.id_libro == Id_libros);
            if (libro == null)
            {
                return NotFound("");
            }
            return mapper.Map<LibrosDTO>(libro);
        }

        [HttpPost]
        //Se envia datos a la DB
        public async Task<ActionResult> Post(LibrosCreationDTO librosCreationDTO)
        {
            
            var libro = mapper.Map<LibrosModels>(librosCreationDTO);
            appDbContext.Add(libro);
            await appDbContext.SaveChangesAsync();
            var dto = mapper.Map<LibrosDTO>(libro);
            return new CreatedAtRouteResult("GetLibros", new { id = libro.id_libro }, dto);  
            

        }
    }
}

