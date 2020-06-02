using System.Collections.Generic;

namespace BlockBuster.Models
{
  public class Moive
  {
    public Movie()
    {
      this.Directors = new HashSet<DirectorMovies>();
    }

    public int MovieId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public int Copies { get; set; }

    public virtual ApplicationUser User { get; set; }
    public ICollection<DirectorMovies> Directors { get; }
  }
}