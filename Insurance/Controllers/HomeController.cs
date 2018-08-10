using Insurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Quote(string FirstName, string LastName, string EmailAddress, string DateOfBirth, int CarYear, string CarMake,
            string CarModel, string DUI, int Tickets, string Coverage, decimal TotalQuote)
        {
        //    if (string.IsNullOrEmpty(FirstName))
        //    {
        //        return View("~/Views/Shared/Error.cshtml");
        //    }
        //    else
        //    {
                using(InsuranceEntities db = new InsuranceEntities())
                {
                    var signup = new Quote();
                    signup.FirstName = FirstName;
                    signup.LastName = LastName;
                    signup.EmailAddress = EmailAddress;
                    signup.DateOfBirth = DateOfBirth;
                    signup.CarYear = CarYear;
                    signup.CarMake = CarMake;
                    signup.CarModel = CarModel;
                    signup.DUI = DUI;
                    signup.Tickets = Tickets;
                    signup.Coverage = Coverage;
                    signup.TotalQuote = TotalQuote;

                    db.Quotes.Add(signup);
                    db.SaveChanges();
                }
                return View("Success");
            } 
        }
    }
//}