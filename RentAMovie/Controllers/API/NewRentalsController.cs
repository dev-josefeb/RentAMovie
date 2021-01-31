using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentAMovie.Dtos;
using RentAMovie.Models;

namespace RentAMovie.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie IDs have been selected");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer ID is not valid");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            if(movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more Movie Ids are invalid");

            foreach (var movie in movies)
            {
                if (movie.QuantityAvailable == 0)
                    return BadRequest("Movie " + movie.Name + " is not available"); 

                movie.QuantityAvailable--;

                //movies.Add(_context.Movies.Add(_context.Movies.SingleOrDefault(m => m.Id == movieId)));
                Rental rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
