using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Movie
    {
        
        public GenreType GenreType { get; set; }

        [Display(Name = "Genre")]
        public byte GenreTypeId { get; set; }

        [Required]
        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Quantity in Stock")]
        public int QuantityInStock { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}