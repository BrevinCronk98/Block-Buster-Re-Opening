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
using System;

namespace BlockBuster.Controllers
{
  public class MoviesController : Controller
  {
    private readonly BlockBusterContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public MoviesController(UserManager<ApplicationUser> userManager, BlockBusterContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Movie> model = _db.Movies.ToList();
      return View(model);
    }

    [HttpPost]
    public ActionResult Search(string query)
    {
      var movies = from m in _db.Movies
                   select m;
      if (!String.IsNullOrEmpty(query))
      {
        movies = movies.Where(m => m.Name.Contains(query));
      }
      return RedirectToAction("Index", movies.ToList());
    }

    [Authorize]
    public ActionResult Create()
    {
      ViewBag.DirectorId = new SelectList(_db.Directors, "DirectorId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Movie movie, int DirectorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
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

    [Authorize]
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

    [Authorize]
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

    [Authorize]
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