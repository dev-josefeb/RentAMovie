using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentAMovie.Models;
using RentAMovie.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace RentAMovie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        private IEnumerable<Movie> _movies { get; set; }

        public MoviesController()
        {
            //GetMovies();
            _context = new ApplicationDbContext();
            _movies = GetMovies();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer1" },
                new Customer{ Name = "Customer2" }
            };
              
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
          
            return View(viewModel);
            
             
            ////return Content("Bananas for sale people!!!!!!");
            ////return HttpNotFound();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
        }

        [Route("Movies")]
        public ActionResult Movies()
        {
            //return View(new MoviesViewModel { Movies = _movies.ToList()});
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Movies", new MoviesViewModel { Movies = _movies.ToList() });
            else
                return View("MoviesReadOnly", new MoviesViewModel { Movies = _movies.ToList() });
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"Page Index is { pageIndex } and Sortby is { sortBy }");
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New(int? id)
        {
            if (id == null)
                return View("MoviesForm", new MovieFormViewModel { Movie = new Movie(), GenreTypes = _context.GenreTypes });

            var movie = _context.Movies.Include(m => m.GenreType).Single(m=>m.Id == id);
            var genreTypes = _context.GenreTypes;

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreTypes = genreTypes
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
                return View("MoviesForm", new MovieFormViewModel { Movie = movie, GenreTypes = _context.GenreTypes });

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.QuantityInStock = movie.QuantityInStock;
            }
            
 
            //if (movie.Id == 0)
            //    _context.Movies.Add(movie);

            //var movie = _context.Movies.Single(m => m.Id == id);
            //return View("MoviesForm", movie);
            return RedirectToAction("Movies", "Movies");
        }

        [Route("Movies/Details/{id}/")]
        public ActionResult Details(int id)
        {
            return View(_movies.Where(m => m.Id == id).FirstOrDefault()); 
        }

        private List<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.GenreType).ToList();
            //_movies = new List<Movie> { new Movie { Id = 0, Name = "Wall-E" }, new Movie { Id = 1, Name = "Tarzan" } };
        }
    }
}