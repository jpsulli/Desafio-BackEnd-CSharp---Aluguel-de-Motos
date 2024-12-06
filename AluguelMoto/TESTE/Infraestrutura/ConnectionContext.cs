using Microsoft.EntityFrameworkCore;
using TESTE.Model;

namespace TESTE.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Moto> Motos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Obter senha do ambiente ou outra configuração
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "defaultPassword";

            optionsBuilder.UseNpgsql(
                $"Server=localhost;" +
                $"Port=5003;" +
                $"Database=postgres;" +
                $"User Id=postgres;" +
                $"Password={password};");
        }
    }
}
