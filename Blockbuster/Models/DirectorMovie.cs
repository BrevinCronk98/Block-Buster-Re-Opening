namespace BlockBuster.Models
{
  public class DirectorMovie
  {
    public int DirectorMovieId { get; set; }
    public int MovieId { get; set; }
    public int DirectorId { get; set; }
    public Movie Movie { get; set; }
    public Director Director { get; set; }
  }
}
