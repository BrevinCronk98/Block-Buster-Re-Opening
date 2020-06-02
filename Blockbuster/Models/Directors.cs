using System.Collections.Generic;

namespace BlockBuster.Models
{
  public class Director
  {
    public Director()
    {
      this.Movies = new HashSet<DirectorMovies>();
    }

    public int DirectorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DirectorMovies> Movies { get; set; }
  }
}