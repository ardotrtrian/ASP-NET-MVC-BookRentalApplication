using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Models
{
    public class Favourites
    {
        public int id { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        public int bookId { get; set; }

        public Book Book { get; set; }
    }
}