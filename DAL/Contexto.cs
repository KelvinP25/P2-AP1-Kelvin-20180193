using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2_KELVIN_20180193.Entidades;

namespace P2_KELVIN_20180193.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<TipoTareas> TipoTareas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\ProyectoSegundoParcial.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoTareas>().HasData(new TipoTareas
            {
                TipoTareaId = 1,
                DescripcionTipoTarea = "Análisis",
                TiempoAcumulado = 0
            });
            modelBuilder.Entity<TipoTareas>().HasData(new TipoTareas
            {
                TipoTareaId = 2,
                DescripcionTipoTarea = "Diseño",
                TiempoAcumulado = 0
            });
            modelBuilder.Entity<TipoTareas>().HasData(new TipoTareas
            {
                TipoTareaId = 3,
                DescripcionTipoTarea = "Programación",
                TiempoAcumulado = 0
            });
            modelBuilder.Entity<TipoTareas>().HasData(new TipoTareas
            {
                TipoTareaId = 4,
                DescripcionTipoTarea = "Prueba",
                TiempoAcumulado = 0
            });
        }
    }
}
