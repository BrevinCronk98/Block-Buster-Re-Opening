using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}