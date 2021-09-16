using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovies.Models;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Threading.Tasks;
using MvcMovies.ViewModels;
using System.Net;

namespace MvcMovies.Controllers
{
    public class WatchlistController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Watchlist
        [Authorize]
        public ActionResult Index()
        {

            var id = User.Identity.GetUserId();
            var userMovies = db.UserMovies.Where(m => m.UserId == id);            

            var viewModel = userMovies.Select(x => new WatchlistViewModel
            {
                MovieId = x.MovieId,
                Title = x.Movie.Title,
                Year = x.Movie.ReleaseDate,
                Genre = x.Movie.Genre,
                Rating = x.Movie.IMDb ?? 0,
                Rated = x.Movie.Rated,
                Added = x.Added,
                Image = x.Movie.ImagePath
            }).ToList();

            return View(viewModel);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            UserMovie movie = db.UserMovies.Single(m => m.MovieId == id);
         
            db.UserMovies.Remove(movie);
            db.SaveChanges();
            return View("Index");
        }

    }
}