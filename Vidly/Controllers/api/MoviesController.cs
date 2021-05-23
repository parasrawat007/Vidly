using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET api/movies

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
        //Get api/movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movie;
        }
        //POST api/movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        //PUT api/movies/1
        [HttpPut]
        public void UpdateMovie(int id,Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb==null)
            {
                new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();
        }
        //DELETE api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

    }
}
