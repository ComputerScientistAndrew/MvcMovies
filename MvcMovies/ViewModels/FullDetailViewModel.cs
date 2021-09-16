using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcMovies.ViewModels
{
    public class FullDetailViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Production { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [DisplayName("Watchlist")]
        public bool InWatchlist { get; set; }
        public string Rated { get; set; }
        public double Rating { get; set; }
        public string Synopsis { get; set; }
        public string Actor { get; set; }
        public int Budget { get; set; }
        public int OpeningWeekend { get; set; }
        public int GrossUSA { get; set; }
        public long GrossWorld { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
    }
}