using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QuirkyBookRental.Models;
using Microsoft.AspNet.Identity;
using QuirkyBookRental.Utility;
using QuirkyBookRental.ViewModel;

namespace QuirkyBookRental.Controllers
{
    public class BookDetailController : Controller
    {
        private ApplicationDbContext db;

        public BookDetailController()
        {
            db = ApplicationDbContext.Create();
        }
        // GET: BookDetail
        public ActionResult Index(int id)
        {

            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);

            var bookModel = db.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            //var x = db.Favourites.Where(f => f.UserId == userid && f.bookId == BookId).FirstOrDefault();
            var FavouriteModel = db.Favourites.Where(f => f.UserId == userid && f.bookId == bookModel.Id).FirstOrDefault();

            var rentalPrice = 0.0;
            var oneMonthRental = 0.0;
            var sixMonthRental = 0.0;
            var TwoWeeksRental = 0.0;
            var TwoMonthRental = 0.0;
            var ThreeMonthRental = 0.0;
            var FourMonthRental = 0.0;
            var FiveMonthRental = 0.0;
            var rentalCount = 0;
            
            if(userid !=null && !User.IsInRole(SD.AdminUserRole))
            {
                var chargeRate = from u in db.Users
                                 join m in db.MembershipTypes on u.MembershipTypeId equals m.Id
                                 where u.Id.Equals(userid)
                                 select new { m.ChargeRateOneMonth, m.ChargeRateSixMonth,
                                     m.ChargeRateFiveMonth,
                                     m.ChargeRateFourMonth,
                                     m.ChargeRateThreeMonth,
                                     m.ChargeRateTwoMonth,
                                     m.ChargeRateTwoweeks,
                                     u.RentalCount };

                oneMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateOneMonth)/100;
                sixMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateSixMonth) / 100;

                TwoWeeksRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateTwoweeks) / 100;
                TwoMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateTwoMonth) / 100;
                ThreeMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateThreeMonth) / 100;
                FourMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateFourMonth) / 100;
                FiveMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateFiveMonth) / 100;



                rentalCount =  Convert.ToInt32(chargeRate.ToList()[0].RentalCount);
            }
            BookRentalViewModel model = new BookRentalViewModel
            {
                //UserStatus = usermodel.Disable,
                BookId = bookModel.Id,
                ISBN = bookModel.ISBN,
                Author=bookModel.Author,
                Avaibility=bookModel.Avaibility,
                DateAdded=bookModel.DateAdded,
                Description=bookModel.Description,
                Genre=db.Genres.FirstOrDefault(g=>g.Id.Equals(bookModel.GenreId)),
                GenreId=bookModel.GenreId,
                ImageUrl=bookModel.ImageUrl,
                Pages=bookModel.Pages,
                Price=bookModel.Price,
                Publisher=bookModel.Publisher,
                PublicationDate=bookModel.PublicationDate,
                ProductDimensions=bookModel.ProductDimensions,
                Title=bookModel.Title,
                UserId = userid,
                RentalPrice=rentalPrice,
                RentalPriceOneMonth=oneMonthRental,
                RentalPriceSixMonth=sixMonthRental,
                RentalPriceTwoMonth = TwoMonthRental,
                RentalPriceThreeMonth = ThreeMonthRental,
                RentalPriceFourMonth = FourMonthRental,
                RentalPriceFiveMonth = FiveMonthRental,
                RentalPriceTwoWeeks = TwoWeeksRental,
                RentalCount=rentalCount,
                //-------------------------
                UserStatus = (user!=null) ? user.Disable:false,
                FavouriteID = (FavouriteModel != null) ? FavouriteModel.id : 0
            };

            return View(model);
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