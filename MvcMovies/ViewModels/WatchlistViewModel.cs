using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovies.ViewModels
{
    public class WatchlistViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public string Rated { get; set; }
        public DateTime Added { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
    }
}