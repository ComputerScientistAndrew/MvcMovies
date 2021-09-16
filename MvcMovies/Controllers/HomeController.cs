using MvcMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBContext db = new MovieDBContext();
        public ActionResult Index()
        {
            var movies = db.Movies.OrderByDescending(m => m.IMDb).Take(5);
            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out to us!";

            return View();
        }
    }
}