using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.ToList();
            }
        }

        public static List<Movie> GetAllCheckedOutMovies()
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        CheckedIn = t.CheckedIn
                    }).Where(w => w.CheckedIn == "N")
                        .Select(m => new Movie
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId
                        }).ToList();
            }

        }

        public static List<Genre> GetAllMoviesByGenreDescription()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Genres
                    .Select(e => new Genre
                    {
                    GenreId = e.GenreId,
                    GenreDescr = e.GenreDescr
                    }).ToList();
             }
        }

        public static List<Director> GetAllMoviesByDirectorLastName()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Directors
                    .Select(e => new Director
                    {
                        DirectorId = e.DirectorId,
                        LastName = e.LastName
                    }).ToList();
            }
        }

        public static List<Movie> GetAllMoviesFull()
        {
            using ( var db = new SE407_BlockBusterContext())
            {
                var movies = db.Movies
                    .Include(movies => movies.Director)
                    .Include(movies => movies.Genre)
                    .ToList();

                return movies;
            }
        }

    }
}
