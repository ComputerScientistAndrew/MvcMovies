using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcMovies.ViewModels
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        [DisplayName ("Watchlist")]
        public bool InWatchlist { get; set; }
        public string Rated { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }

    }
}