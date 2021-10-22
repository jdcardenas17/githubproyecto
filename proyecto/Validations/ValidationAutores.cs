using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using proyecto.Models;

namespace proyecto.Validations
{
    public class ValidationAutores :AbstractValidator<AutoresModels>
    {
        public ValidationAutores()
        {
            RuleFor(r => r.nombre_completo)
                .NotEmpty()
                .Must(ValidaNombreCompletoAutor).WithMessage("El autor no está registrado");

            RuleFor(r => r.fecha_nacimiento)
                .NotEmpty()
                .Must(ValidarFechaNacimiento).WithMessage("La fecha de nacimiento es incorrecta");

            RuleFor(r => r.ciudad_procedencia).NotEmpty();
            RuleFor(r => r.correo_electronico)
                .NotEmpty()
                .EmailAddress();
        }

        private bool ValidaNombreCompletoAutor(string nombre)
        {
            if (nombre != "NULL" & nombre != "") return true;
                    return false;
        }

        private bool ValidarFechaNacimiento(DateTime fecha_nacimiento)
        {
            return (fecha_nacimiento <= DateTime.Today.AddYears(-18));
        }

    }
}
