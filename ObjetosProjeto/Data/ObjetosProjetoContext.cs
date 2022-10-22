using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ObjetosProjeto.Models;

namespace ObjetosProjeto.Data
{
    public class ObjetosProjetoContext : DbContext
    {
        public ObjetosProjetoContext (DbContextOptions<ObjetosProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<ObjetosProjeto.Models.ContatoModel> ContatoModel { get; set; } = default!;

        public DbSet<ObjetosProjeto.Models.ObjetoModel> ObjetoModel { get; set; } = default!;

        }
} 
