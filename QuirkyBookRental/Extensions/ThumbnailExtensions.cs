using QuirkyBookRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Extensions
{
    public static class ThumbnailExtensions
    {
        public static IEnumerable<ThumbnailModel> GetBookThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null, string search = null,string option=null)
        {
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails = (from b in db.Books
                              select new ThumbnailModel
                              {
                                  BookId = b.Id,
                                  Title = b.Title,
                                  Description = b.Description,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/BookDetail/Index/" + b.Id,
                                  Author = b.Author,
                                  Genre = b.Genre,
                                  PublicationDate = b.PublicationDate
                              }).ToList();

                if(option==null && search!=null || option == "title" && search.Length>0)
                {
                    return thumbnails.Where(t => t.Title.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                }

                if (option == "author" && search.Length > 0)
                {
                    return thumbnails.Where(t => t.Author.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                }

                if (option == "genre" && search.Length>0)
                {
                    return thumbnails.Where(t => t.Genre.Name.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                }
                if (option == "year" && search.Length > 0)
                {
                    return thumbnails.Where(t => t.PublicationDate.ToLongDateString().Contains(search.ToString())).OrderBy(t => t.Title);
                }

            }
            catch(Exception ex)
            {

            }
            return thumbnails.OrderBy(t => t.Title);

        }
    }
}