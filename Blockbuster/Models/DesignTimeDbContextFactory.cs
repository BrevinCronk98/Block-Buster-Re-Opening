using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlockBuster.Models
{
  public class BlockBusterContextFactory : IDesignTimeDbContextFactory<BlockBusterContext>
  {

    BlockBusterContext IDesignTimeDbContextFactory<BlockBusterContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<BlockBusterContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new BlockBusterContext(builder.Options);
    }
  }
}