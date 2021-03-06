﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RentAMovie.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte GenreTypeId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public GenreTypeDto GenreType { get; set; }

        [Required]
        public int QuantityInStock { get; set; }
    }
}