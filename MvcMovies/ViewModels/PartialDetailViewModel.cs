using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovies.ViewModels
{
    public class PartialDetailViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Actor { get; set; }
        public string Synopsis { get; set; }
    }
}