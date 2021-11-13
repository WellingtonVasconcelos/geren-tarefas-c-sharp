using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenTarefas.Models
{
    public class GerenTarefasContext : DbContext
    {
        public GerenTarefasContext(DbContextOptions<GerenTarefasContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
