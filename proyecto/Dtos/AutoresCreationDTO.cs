using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Dtos
{
    public class AutoresCreationDTO
    {
        
        public string nombre_completo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string ciudad_procedencia { get; set; }
        public string correo_electronico { get; set; }
    }
}
