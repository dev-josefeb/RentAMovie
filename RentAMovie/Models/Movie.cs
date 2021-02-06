using System;
using System.ComponentModel.DataAnnotations;

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