using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MvcMovies.Models;
using MvcMovies.ViewModels;
using MvcMovies.BL;

namespace MvcMovies.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        public ActionResult Index(string movieGenre, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
             
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var viewModel = movies.Select(x => new MovieViewModel
            {
                MovieId = x.ID,
                Title = x.Title,
                Year = x.ReleaseDate,
                Genre = x.Genre,
                InWatchlist = false,
                Rated = x.Rated,
                Rating = x.IMDb ?? 0,
                Image = x.ImagePath
            }).ToList();

            var id = User.Identity.GetUserId();
            var userMovies = db.UserMovies.Where(m => m.UserId == id).ToList();

            foreach (var movie in viewModel)
            {
                var m = db.UserMovies.FirstOrDefault(x => x.UserId == id && x.MovieId == movie.MovieId);
                if (m != null)
                {
                    movie.InWatchlist = true;
                }
            }

            return View(viewModel);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            MovieInfo movieInfo = db.MoviesInfo.Find(id);


            if (movie == null || movieInfo == null)
            {
                return HttpNotFound();
            }

            FullDetailViewModel viewModel = new FullDetailViewModel
            {
                MovieId = movie.ID,
                Title = movie.Title,
                Director = movieInfo.Director,
                Production = movieInfo.Production,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                InWatchlist = false,
                Rated = movie.Rated,
                Rating = movie.IMDb ?? 0,
                Synopsis = movieInfo.Synopsis,
                Actor = movieInfo.LeadRole,
                Budget = movieInfo.Budget ?? 0,
                OpeningWeekend = movieInfo.OpeningWeekend ?? 0,
                GrossUSA = movieInfo.GrossUSA ?? 0,
                GrossWorld = movieInfo.GrossWorld ?? 0,
                Image = movie.ImagePath,
                Trailer = movieInfo.TrailerURL
            };
            var userId = User.Identity.GetUserId();
            if (db.UserMovies.Any(m => m.MovieId == id && userId == m.UserId))
            {
                viewModel.InWatchlist = true;
            }

            return View(viewModel);
        }

        // GET: Movies/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditViewModel modelValues)
        {
            MovieBL.SetImagePath(modelValues);

            Movie movie = new Movie
            {
                Title = modelValues.Title,
                ReleaseDate = modelValues.ReleaseDate,
                Genre = modelValues.Genre,
                IMDb = modelValues.IMDb,
                Rated = modelValues.Rated,
                ImagePath = modelValues.ImagePath

            };

            MovieInfo movieInfo = new MovieInfo
            {
                MovieTitle = modelValues.Title,
                Director = modelValues.Director,
                Production = modelValues.Production,
                Synopsis = modelValues.Synopsis,
                LeadRole = modelValues.LeadRole,
                Budget = modelValues.Budget,
                OpeningWeekend = modelValues.OpeningWeekend,
                GrossUSA = modelValues.GrossUSA,
                GrossWorld = modelValues.GrossWorld,
                TrailerURL = modelValues.TrailerURL
            };

            db.Movies.Add(movie);
            db.MoviesInfo.Add(movieInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            MovieInfo movieInfo = db.MoviesInfo.Find(id);
            if (movie == null || movieInfo == null)
            {
                return HttpNotFound();
            }

            CreateEditViewModel viewModel = new CreateEditViewModel
            {
                ID = movie.ID,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                ImagePath = movie.ImagePath,
                Director = movieInfo.Director,
                Production = movieInfo.Production,
                Genre = movie.Genre,
                IMDb = movie.IMDb ?? 0,
                Rated = movie.Rated,
                Synopsis = movieInfo.Synopsis,
                LeadRole = movieInfo.LeadRole,
                Budget = movieInfo.Budget ?? 0,
                OpeningWeekend = movieInfo.OpeningWeekend ?? 0,
                GrossUSA = movieInfo.GrossUSA ?? 0,
                GrossWorld = movieInfo.GrossWorld ?? 0,
                TrailerURL = movieInfo.TrailerURL
            };                       

            return View(viewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateEditViewModel modelValues)
        {
            if (modelValues.ImageFile == null)
            {
                var query = db.Movies.Where(m => m.ID == modelValues.ID)
                                        .Select(x => new { ImagePath = x.ImagePath }).Single();
                modelValues.ImagePath = query.ImagePath;
            }
            else
            {
                MovieBL.SetImagePath(modelValues);
            }

            Movie movie = new Movie
            {
                ID = modelValues.ID,
                Title = modelValues.Title,
                ReleaseDate = modelValues.ReleaseDate,
                Genre = modelValues.Genre,
                IMDb = modelValues.IMDb,
                Rated = modelValues.Rated,
                ImagePath = modelValues.ImagePath

            };
            MovieInfo movieInfo = new MovieInfo
            {
                Id = modelValues.ID,
                MovieTitle = modelValues.Title,
                Director = modelValues.Director,
                Production = modelValues.Production,
                Synopsis = modelValues.Synopsis,
                LeadRole = modelValues.LeadRole,
                Budget = modelValues.Budget,
                OpeningWeekend = modelValues.OpeningWeekend,
                GrossUSA = modelValues.GrossUSA,
                GrossWorld = modelValues.GrossWorld,
                TrailerURL = modelValues.TrailerURL
            };

            db.Entry(movie).State = EntityState.Modified;
            db.Entry(movieInfo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            MovieInfo movieInfo = db.MoviesInfo.Find(id);

            db.Movies.Remove(movie);
            db.MoviesInfo.Remove(movieInfo);
            db.UserMovies.RemoveRange(db.UserMovies.Where(m => m.MovieId == id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("GetMovieInfo")]
        public ActionResult GetMovieInfo(int? MovieId)
        {
            if (MovieId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(MovieId);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var model = db.Movies.Join(
                                    db.MoviesInfo,
                                    m => m.Title,
                                    i => i.MovieTitle,
                                    (m, i) => new
                                    {
                                        MovieId = m.ID,
                                        MovieTitle = m.Title,
                                        MovieDirector = i.Director,
                                        MovieDate = m.ReleaseDate,
                                        MovieSynopsis = i.Synopsis,
                                        MovieRating = m.IMDb,
                                        MovieActor = i.LeadRole

                                    }).Where(x => x.MovieId == MovieId)
                                    .Select(v => new PartialDetailViewModel
                                    {
                                        MovieId = v.MovieId,
                                        Title = v.MovieTitle,
                                        ReleaseDate = v.MovieDate,
                                        Synopsis = v.MovieSynopsis,
                                        Director = v.MovieDirector,
                                        Actor = v.MovieActor
                                    }).ToList();

            
            return PartialView("~/Views/_DetailsPartial.cshtml", model);
        }


        [HttpPost]
        public JsonResult AddRemove(int? id, int? val)
        {
            int retval = -1;
            if (!User.Identity.IsAuthenticated)
            {
                retval = 2;
                return Json(retval);
            }
            var userId = User.Identity.GetUserId();
            if (val == 1)
            {
                var movie = db.UserMovies.FirstOrDefault(x => x.MovieId == id && x.UserId == userId);
                
                if (movie != null)
                {
                    db.UserMovies.Remove(movie);
                    retval = 0;
                }
            }
            else
            {
                db.UserMovies.Add(
                    new UserMovie
                    {
                        UserId = userId,
                        MovieId = (int)id,
                        Added = DateTime.Now
                    }
                );
                retval = 1;
            }

            db.SaveChanges();

            return Json(retval);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
