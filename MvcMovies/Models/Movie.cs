using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required, StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public double? IMDb { get; set; }
        [StringLength(5)]
        public string Rated { get; set; }
        public string ImagePath { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
        public DbSet<MovieInfo> MoviesInfo { get; set; }
    }
}