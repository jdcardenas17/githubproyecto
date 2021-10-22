using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace proyecto.Models
{
    public class LibrosModels
    {
        [Key]
        public int id_libro { get; set; }

        
        public string titulo { get; set; }
        
        
        public int año { get; set; }

        
        public string genero { get; set; }

        
        public int numero_paginas { get; set; }

       
        public string autor { get; set; }
       
    }
   
}
