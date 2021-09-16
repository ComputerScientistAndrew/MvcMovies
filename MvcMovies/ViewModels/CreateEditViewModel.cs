using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMovies.ViewModels
{
    public class CreateEditViewModel
    {
        public int ID { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        [DisplayName("Embedded Trailer URL")]
        public string TrailerURL { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string Director { get; set; }

        [DisplayName("Production Company")]
        public string Production { get; set; }
        public string Genre { get; set; }

        [DisplayName("IMDb Rating")]
        public double IMDb { get; set; }
        public string Rated { get; set; }
        public string Synopsis { get; set; }

        [DisplayName("Lead Actor")]
        public string LeadRole { get; set; }

        [DisplayName("Estimated Budget")]
        public int Budget { get; set; } = 0;

        [DisplayName("Opening Weekend Gross")]
        public int OpeningWeekend { get; set; }

        [DisplayName("Domestic Gross")]
        public int GrossUSA { get; set; }

        [DisplayName("World Gross")]
        public long GrossWorld { get; set; }



    }
}