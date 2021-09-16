﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovies.Models
{
    public class UserMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public DateTime Added { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual MovieInfo MovieInfo { get; set; }
    }
}