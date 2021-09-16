using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMovies.Models;
using MvcMovies.ViewModels;
using System.IO;
using System.Configuration;

namespace MvcMovies.BL
{
    public class MovieBL
    {
        public static void SetImagePath(CreateEditViewModel modelValues)
        {
            string FileName = Path.GetFileNameWithoutExtension(modelValues.ImageFile.FileName);

            string FileExt = Path.GetExtension(modelValues.ImageFile.FileName);

            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

            modelValues.ImagePath = "/Content/Images/Movies/" + FileName + FileExt;

            modelValues.ImageFile.SaveAs(UploadPath + modelValues.ImageFile.FileName);
        }
    }
}