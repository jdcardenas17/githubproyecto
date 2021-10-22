using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto.Utility
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :base(dbContextOptions)
        {

        }
        public DbSet<LibrosModels> libros { get; set; }
        public DbSet<AutoresModels> autores { get; set; }
    }
}
