using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Dtos
{
    public class LibrosCreationDTO
    {
        
        public string titulo { get; set; }
        public int año { get; set; }
        public string genero { get; set; }
        public int numero_paginas { get; set; }
        public string autor { get; set; }
    }
}
