using BlockBuster.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlockBuster.Controllers
{
  public class MoviesController : Controller
  {
    private readonly BlockBusterContext _db;

    public MoviesController(BlockBusterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Movie> model = _db.Movies.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.DirectorId = new SelectList(_db.Directors, "DirectorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Movie movie, int DirectorId)
    {
      _db.Movies.Add(movie);
      if (DirectorId != 0)
      {
        _db.DirectorMovies.Add(new DirectorMovie() { DirectorId = DirectorId, MovieId = movie.MovieId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMovie = _db.Movies
        .Include(movie => movie.Directors)
        .ThenInclude(join => join.Director)
        .FirstOrDefault(movies => movies.MovieId == id);
      return View(thisMovie);
    }

    public ActionResult Edit(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      ViewBag.DirectorId = new SelectList(_db.Directors, "DirectorId", "Name");
      return View(thisMovie);
    }

    [HttpPost]
    public ActionResult Edit(Movie movie, int DirectorId)
    {
      if (DirectorId != 0)
      {
        _db.DirectorMovies.Add(new DirectorMovie() { DirectorId = DirectorId, MovieId = movie.MovieId });
      }
      _db.Entry(movie).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDirector(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      ViewBag.DirectorId = new SelectList(_db.Directors, "DirectorId", "Name");
      return View(thisMovie);
    }

    [HttpPost]
    public ActionResult AddDirector(Movie movie, int DirectorId)
    {
      if (DirectorId != 0)
      {
        _db.DirectorMovies.Add(new DirectorMovie() { DirectorId = DirectorId, MovieId = movie.MovieId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      return View(thisMovie);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      _db.Movies.Remove(thisMovie);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDirector(int joinId)
    {
      var joinEntry = _db.DirectorMovies.FirstOrDefault(entry => entry.DirectorMovieId == joinId);
      _db.DirectorMovies.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}