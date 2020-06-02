using System.Collections.Generic;

namespace BlockBuster.Models
{
  public class Director
  {
    public Director()
    {
      this.Movies = new HashSet<DirectorMovie>();
    }

    public int DirectorId { get; set; }
    public string Name { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<DirectorMovie> Movies { get; set; }
  }
}