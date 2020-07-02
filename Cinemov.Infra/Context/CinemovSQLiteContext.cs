using Cinemov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.Infra.Context
{
    public class CinemovSQLiteContext : DbContext
    {
        public readonly string ConnectionString;

        public DbSet<Avaliacao> Avaliacoes { get; set; }


        public CinemovSQLiteContext()
        {
                
        }
        public CinemovSQLiteContext(string connectionString)
        {
            ConnectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}
