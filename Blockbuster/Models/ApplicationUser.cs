using Microsoft.AspNetCore.Identity;

namespace BlockBuster.Models
{
  public class ApplicationUser : IdentityUser
  {
    public override string UserName { get; set; }
    // public override string Email { get; set; }
  }
}