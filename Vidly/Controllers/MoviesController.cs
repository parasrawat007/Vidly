using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
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
        // GET: Movies
        public ActionResult Index()
        {
            var Movies = _context.Movies.Include(m => m.Genre).ToList(); ;
            return View(Movies);
        }

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.DateAdded=DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x=>x.Genre).SingleOrDefault(m => m.Id == id);
            if(movie==null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer() { Name="Customer 1"},
                new Customer() { Name="Customer 2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

      
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}