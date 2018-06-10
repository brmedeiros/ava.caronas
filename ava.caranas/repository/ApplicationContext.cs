using ava.caronas.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caronas.repository {
    public class ApplicationContext : DbContext {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Carona> Caronas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = avaCaronasAppDB; Integrated Security = True");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
