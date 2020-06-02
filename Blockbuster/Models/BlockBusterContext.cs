using Microsoft.EntityFrameworkCore;

namespace BlockBuster.Models
{
  public class BlockBusterContext : DbContext
  {
    public virtual DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<DirectorMovies> DirectorMovies { get; set; }

    public BlockBusterContext(DbContextOptions options) : base(options) { }
  }
}
