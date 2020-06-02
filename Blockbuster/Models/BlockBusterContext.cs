using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlockBuster.Models
{
  public class BlockBusterContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<DirectorMovie> DirectorMovies { get; set; }

    public BlockBusterContext(DbContextOptions options) : base(options) { }
  }
}
