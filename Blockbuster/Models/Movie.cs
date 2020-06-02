using System.Collections.Generic;

namespace BlockBuster.Models
{
  public class Movie
  {
    public Movie()
    {
      this.Directors = new HashSet<DirectorMovie>();
    }

    public int MovieId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public int Copies { get; set; }

    public virtual ApplicationUser User { get; set; }
    public ICollection<DirectorMovie> Directors { get; }
  }
}