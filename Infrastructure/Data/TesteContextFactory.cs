using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace Infrastructure.Data
{
    public class TextContextFactory : IDesignTimeDbContextFactory<TesteContext>
    {
        public TesteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TesteContext>();
            optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=openk;Database=testedb");

            return new TesteContext(optionsBuilder.Options);
        }
    }
}
