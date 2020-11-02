using Microsoft.EntityFrameworkCore;
using WilsonGomez_P2_AP1.Entidades;

namespace WilsonGomez_P2_AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<TiposTarea> TiposTarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source = DATA\Parcial2.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TiposTarea>().HasData(new TiposTarea(1, "Análisis"));
            modelBuilder.Entity<TiposTarea>().HasData(new TiposTarea(2, "Diseño"));
            modelBuilder.Entity<TiposTarea>().HasData(new TiposTarea(3, "Programación"));
            modelBuilder.Entity<TiposTarea>().HasData(new TiposTarea(4, "Prueba"));
        }
    }
}