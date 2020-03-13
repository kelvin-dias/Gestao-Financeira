using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() { }
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }

    }
}
