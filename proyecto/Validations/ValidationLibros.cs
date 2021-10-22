using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using proyecto.Models;
using proyecto.Dtos;

namespace proyecto.Validations
{
    public class ValidationLibros: AbstractValidator<LibrosModels>
    {
        public ValidationLibros()
        {
            RuleFor(r => r.titulo)
                .NotEmpty()
                .NotEqual(r=>r.titulo).WithMessage("No es posible registrar el libro, se alcanzó el máximo permitido");
            RuleFor(r => r.año).NotEmpty();
            RuleFor(r => r.genero).NotEmpty();
            RuleFor(r => r.numero_paginas).NotEmpty();
            RuleFor(r => r.autor).NotEmpty();
        }
    }   
    
}
