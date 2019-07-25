using Microsoft.AspNet.Identity;
using QuirkyBookRental.Models;
using QuirkyBookRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace QuirkyBookRental.Controllers
{
    public class FavouritesController : Controller
    {
        private ApplicationDbContext db;

        public FavouritesController()
        {
            db = ApplicationDbContext.Create();
        }
        // GET: Favourites
        //Show all favourite books of user by id
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var book = db.Books.Include(b=>b.Genre).ToList();
            var favourite = db.Favourites.Include(f => f.Book).Where(f=>f.UserId==userid).ToList();


            return View(favourite);
        }


        public ActionResult Add(int BookId)
        {
            var userid = User.Identity.GetUserId();
            var model = new Favourites
            {
                UserId = userid,
                bookId = BookId
            };
            db.Favourites.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "BookDetail",new { id=BookId});
        }

        
        public ActionResult Remove(int BookId)
        {
            var userid = User.Identity.GetUserId();
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = db.Favourites.Where(f => f.UserId == userid && f.bookId == BookId).FirstOrDefault();
            db.Favourites.Remove(x);
            db.SaveChanges();

            return RedirectToAction("Index", "BookDetail",new { id=BookId});
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}