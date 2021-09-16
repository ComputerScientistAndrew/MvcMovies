namespace MvcMovies.Migrations
{
    using MvcMovies.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovies.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMovies.Models.MovieDBContext context)
        {
            context.Movies.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1994-10-14"),
                    Genre = "Drama",
                    IMDb = 9.2,
                    Rated = "R",
                    ImagePath = "/Content/Images/Movies/Shawshank.jpg"
                },

                 new Movie
                 {
                     Title = "The Godfather",
                     ReleaseDate = DateTime.Parse("1972-3-27"),
                     Genre = "Crime",
                     IMDb = 9.1,
                     Rated = "R",
                     ImagePath = "/Content/Images/Movies/TheGodfather.jpg"
                 },

                 new Movie
                 {
                     Title = "The Godfather: Part II",
                     ReleaseDate = DateTime.Parse("1974-12-18"),
                     Genre = "Crime",
                     IMDb = 9.0,
                     Rated = "R",
                     ImagePath = "/Content/Images/Movies/TheGodfather2.jpg"
                 },

                 new Movie
                 {
                     Title = "The Dark Knight",
                     ReleaseDate = DateTime.Parse("2008-07-18"),
                     Genre = "Superhero",
                     IMDb = 9.0,
                     Rated = "PG-13",
                     ImagePath = "/Content/Images/Movies/TheDarkKnight.jpg"
                 },

                 new Movie
                 {
                     Title = "The Lord of the Rings: The Return of the King",
                     ReleaseDate = DateTime.Parse("2003-12-17"),
                     Genre = "Fantasy",
                     IMDb = 9.0,
                     Rated = "PG-13",
                     ImagePath = "/Content/Images/Movies/LOTRROTK.jpg"
                 },

                 new Movie
                 {
                     Title = "Inception",
                     ReleaseDate = DateTime.Parse("2010-07-16"),
                     Genre = "Thriller",
                     IMDb = 8.8,
                     Rated = "PG-13",
                     ImagePath = "/Content/Images/Movies/Inception.jpg"
                 },

                 new Movie
                 {
                     Title = "Star Wars: Episode V - The Empire Strikes Back",
                     ReleaseDate = DateTime.Parse("1980-06-20"),
                     Genre = "Sci-Fi",
                     IMDb = 9.0,
                     Rated = "PG",
                     ImagePath = "/Content/Images/Movies/StarWarsEp5.jpg"
                 },

                 new Movie
                 {
                     Title = "Pulp Fiction",
                     ReleaseDate = DateTime.Parse("1994-10-14"),
                     Genre = "Crime",
                     IMDb = 8.9,
                     Rated = "R",
                     ImagePath = "/Content/Images/Movies/PulpFiction.jpg"
                 },

                 new Movie
                 {
                     Title = "The Matrix",
                     ReleaseDate = DateTime.Parse("1999-03-31"),
                     Genre = "Action",
                     IMDb = 8.7,
                     Rated = "R",
                     ImagePath = "/Content/Images/Movies/TheMatrix.jpg"
                 },

                 new Movie
                 {
                     Title = "Forrest Gump",
                     ReleaseDate = DateTime.Parse("1994-07-06"),
                     Genre = "Drama",
                     IMDb = 8.8,
                     Rated = "PG-13",
                     ImagePath = "/Content/Images/Movies/ForrestGump.jpg"
                 }


           );
            context.MoviesInfo.AddOrUpdate(i => i.MovieTitle,
                new MovieInfo
                {
                    MovieTitle = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Production = "Castle Rock Entertainment",
                    Synopsis = "Two imprisoned men bond over a number of years, finding " +
                    "solace and eventual redemption through acts of common decency.",
                    LeadRole = "Tim Robbins",
                    Budget = 25000000,
                    OpeningWeekend = 727327,
                    GrossUSA = 28699976,
                    GrossWorld = 28786657,
                    TrailerURL = "https://www.youtube.com/embed/uMwECVb1q54"
                },

                new MovieInfo
                {
                    MovieTitle = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Production = "Paramount Pictures",
                    Synopsis = "The aging patriarch of an organized crime dynasty " +
                                "transfers control of his clandestine empire to his reluctant son.",
                    LeadRole = "Marlon Brando",
                    Budget = 6000000,
                    OpeningWeekend = 302393,
                    GrossUSA = 134966411,
                    GrossWorld = 246120974,
                    TrailerURL = "https://www.youtube.com/embed/sY1S34973zA"
                },

                new MovieInfo
                {
                    MovieTitle = "The Godfather: Part II",
                    Director = "Francis Ford Coppola",
                    Production = "Paramount Pictures",
                    Synopsis = "The early life and career of Vito Corleone in 1920s New York City " +
                    "is portrayed, while his son, Michael, expands and tightens his grip on the family " +
                    "crime syndicate.",
                    LeadRole = "Al Pacino",
                    Budget = 13000000,
                    OpeningWeekend = 171417,
                    GrossUSA = 47834595,
                    GrossWorld = 48035783,
                    TrailerURL = "https://www.youtube.com/embed/9O1Iy9od7-A"
                },

                new MovieInfo
                {
                    MovieTitle = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Production = "Warner Bros.",
                    Synopsis = "When the menace known as the Joker wreaks havoc and chaos on the people " +
                    "of Gotham, Batman must accept one of the greatest psychological and physical tests " +
                    "of his ability to fight injustice.",
                    LeadRole = "Christian Bale",
                    Budget = 185000000,
                    OpeningWeekend = 158411483,
                    GrossUSA = 535234033,
                    GrossWorld = 1004934033,
                    TrailerURL = "https://www.youtube.com/embed/kmJLuwP3MbY"
                },

                new MovieInfo
                {
                    MovieTitle = "The Lord of the Rings: The Return of the King",
                    Director = "Peter Jackson",
                    Production = "New Line Cinema",
                    Synopsis = "Gandalf and Aragorn lead the World of Men against Sauron's army " +
                    "to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    LeadRole = "Elijah Wood",
                    Budget = 94000000,
                    OpeningWeekend = 72629713,
                    GrossUSA = 377845905,
                    GrossWorld = 1142219401,
                    TrailerURL = "https://www.youtube.com/embed/r5X-hFf6Bwo"
                },

                new MovieInfo
                {
                    MovieTitle = "Inception",
                    Director = "Christopher Nolan",
                    Production = "Warner Bros.",
                    Synopsis = "A thief who steals corporate secrets through the use of dream-sharing " +
                    "technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    LeadRole = "Leonardo DiCaprio",
                    Budget = 160000000,
                    OpeningWeekend = 62785337,
                    GrossUSA = 292576195,
                    GrossWorld = 829895144,
                    TrailerURL = "https://www.youtube.com/embed/YoHD9XEInc0"
                },

                new MovieInfo
                {
                    MovieTitle = "Star Wars: Episode V - The Empire Strikes Back",
                    Director = "Irvin Kershner",
                    Production = "Lucasfilm",
                    Synopsis = "After the Rebels are brutally overpowered by the Empire on the ice " +
                    "planet Hoth, Luke Skywalker begins Jedi training with Yoda, while his friends " +
                    "are pursued by Darth Vader and a bounty hunter named Boba Fett all over the galaxy.",
                    LeadRole = "Mark Hamill",
                    Budget = 18000000,
                    OpeningWeekend = 4910483,
                    GrossUSA = 290271960,
                    GrossWorld = 547897454,
                    TrailerURL = "https://www.youtube.com/embed/JNwNXF9Y6kY"
                },

                new MovieInfo
                {
                    MovieTitle = "Pulp Fiction",
                    Director = "Quentin Tarantino",
                    Production = "Miramax",
                    Synopsis = "The lives of two mob hitmen, a boxer, a gangster and his wife, " +
                    "and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    LeadRole = "John Travolta",
                    Budget = 8000000,
                    OpeningWeekend = 9311882,
                    GrossUSA = 107928762,
                    GrossWorld = 214179088,
                    TrailerURL = "https://www.youtube.com/embed/tGpTpVyI_OQ"
                },

                new MovieInfo
                {
                    MovieTitle = "The Matrix",
                    Director = "The Wachowski Brothers",
                    Production = "Warner Bros.",
                    Synopsis = "A computer hacker learns from mysterious rebels about the true nature " +
                    "of his reality and his role in the war against its controllers.",
                    LeadRole = "Keanu Reeves",
                    Budget = 63000000,
                    OpeningWeekend = 27788331,
                    GrossUSA = 171479930,
                    GrossWorld = 465343787,
                    TrailerURL = "https://www.youtube.com/embed/m8e-FF8MsqU"
                },

                new MovieInfo
                {
                    MovieTitle = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    Production = "Paramount Pictures",
                    Synopsis = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and " +
                    "other historical events unfold through the perspective of an Alabama man with an IQ of 75, " +
                    "whose only desire is to be reunited with his childhood sweetheart.",
                    LeadRole = "Tom Hanks",
                    Budget = 55000000,
                    OpeningWeekend = 24450602,
                    GrossUSA = 330455270,
                    GrossWorld = 678222284,
                    TrailerURL = "https://www.youtube.com/embed/bLvqoHBptjg"
                }
            );
        }
    }
}
