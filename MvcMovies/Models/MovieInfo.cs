using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovies.Models
{
    public class MovieInfo
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string Director { get; set; }
        public string Production { get; set; }
        public string Synopsis { get; set; }
        public string LeadRole { get; set; }
        public int? Budget { get; set; }
        public int? OpeningWeekend { get; set; }
        public int? GrossUSA { get; set; }
        public long? GrossWorld { get; set; }
        public string TrailerURL { get; set; }

        public virtual Movie Movie { get; set; }
    }
}