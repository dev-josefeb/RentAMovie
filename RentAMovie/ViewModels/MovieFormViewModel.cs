using System.Collections.Generic;
using RentAMovie.Models;

namespace RentAMovie.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<GenreType> GenreTypes { get; set; }
    }
}