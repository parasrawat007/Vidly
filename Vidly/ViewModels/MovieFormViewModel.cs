using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            GenreId = movie.GenreId;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}