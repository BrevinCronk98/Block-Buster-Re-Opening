using BlockBuster.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlockBuster.Controllers
{
  public class DirectorsController : Controller
  {
    private readonly BlockBusterContext _db;

    public DirectorsController(BlockBusterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Director> model = _db.Directors.ToList();
      return View(model);
    }


    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Director director)
    {
      _db.Directors.Add(director);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDirector = _db.Directors
          .Include(director => director.Movies)
          .ThenInclude(join => join.Movie)
          .FirstOrDefault(director => director.DirectorId == id);
      return View(thisDirector);
    }

    public ActionResult Edit(int id)
    {
      var thisDirector = _db.Directors.FirstOrDefault(director => director.DirectorId == id);
      return View(thisDirector);
    }

    [HttpPost]
    public ActionResult Edit(Director director)
    {
      _db.Entry(director).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisDirector = _db.Directors.FirstOrDefault(director => director.DirectorId == id);
      return View(thisDirector);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDirector = _db.Directors.FirstOrDefault(director => director.DirectorId == id);
      _db.Directors.Remove(thisDirector);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}