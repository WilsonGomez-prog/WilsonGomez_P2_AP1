using Microsoft.EntityFrameworkCore;

namespace WilsonGomez_P2_AP1.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source = DATA\Parcial2.db");
        }
    }
}