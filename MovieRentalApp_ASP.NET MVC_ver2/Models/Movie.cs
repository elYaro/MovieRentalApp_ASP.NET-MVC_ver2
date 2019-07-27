using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter movie's name")]  //OVERRIDING the default error message
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock Left")]
        [Range(1,20)]
        public short NumberInStock { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

    }
}