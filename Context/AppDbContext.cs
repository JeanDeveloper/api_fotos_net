using ApiSolgisFotos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolgisFotos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        
        public DbSet<Fotos> MOVIMIENTOS_FOTOS { get; set; }


    }
}
