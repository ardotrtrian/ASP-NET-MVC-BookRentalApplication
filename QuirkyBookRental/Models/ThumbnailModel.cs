﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Models
{
    public class ThumbnailModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}