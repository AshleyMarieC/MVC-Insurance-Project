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
            string CarModel, string DUI, int Tickets, string Coverage, decimal TotalQuote = 3.23m)
        {
        //    if (string.IsNullOrEmpty(FirstName))
        //    {
        //        return View("~/Views/Shared/Error.cshtml");
        //    }
        //    else
        //    {
                using(InsuranceEntities db = new InsuranceEntities())
                {

                double baseCharge = 50;
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
                    //signup.TotalQuote = Convert.ToDecimal(baseCharge);
                

                DateTime myDateTime = DateTime.Parse(DateOfBirth);
                //double baseCharge = 50;
                //decimal TotalQuote = Convert.ToDecimal(baseCharge);

                int age = 0;
                age = DateTime.Now.Year - myDateTime.Year;
                if (DateTime.Now.DayOfYear < myDateTime.DayOfYear)
                {
                    age = -1;
                }

                if (age < 18)
                {
                    baseCharge += 100;
                }
                else if (age < 25 || age > 100)
                {
                    baseCharge += 25;
                }

                if (CarYear < 2000 || CarYear > 2015)
                {
                    baseCharge += 25;
                }

                if (CarMake == "porsche" && CarModel == "911 carrera")
                {
                    baseCharge += 50;
                }
                else if (CarMake == "porsche")
                {
                    baseCharge += 25;
                }

                if (Tickets > 0)
                {
                    var ticketTotal = Tickets * 10;
                    baseCharge += ticketTotal;
                }
                if (DUI == "yes")
                {
                    var duiTotal = baseCharge * .25;
                    baseCharge += duiTotal;
                }
                if (Coverage == "full coverage")
                {
                    var coverageTotal = baseCharge * .50;
                    baseCharge += coverageTotal;
                }
                signup.TotalQuote = Convert.ToDecimal(baseCharge);
                db.Quotes.Add(signup);
                db.SaveChanges();
                }
                return View("Success");
            } 
        }
    }
//}
