using Microsoft.EntityFrameworkCore;
using Proyecto_FInal_Administracion_De_Sistemas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FInal_Administracion_De_Sistemas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Condominios> Condominios { get; set; }
        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<TipoCondominios> TipoCondominios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/datosProyectoCondominio.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoCondominios>().HasData(
                    new TipoCondominios() { TipoCondominioId = 1,  Tipo = "Apartamento"},
                    new TipoCondominios() { TipoCondominioId = 2,  Tipo = "Parqueo" }
                );
        }
    }
}
