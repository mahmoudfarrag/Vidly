using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
       
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }
        public IEnumerable<Genre> Geners { get; set; }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel( Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;     
        }
        public string Title {
            get {
                return Id != 0 ? "Edit Movie" : "New Movie";
               
            }
        }
    }
}