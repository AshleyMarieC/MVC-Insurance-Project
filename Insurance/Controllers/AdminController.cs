using Insurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var signups = db.Quotes;
                var signupVms = new List<SignUp>();
                foreach (var signup in signups)
                {
                    var signupVm = new SignUp();
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                   signupVm.TotalQuote = Convert.ToDecimal(signup.TotalQuote);
                 
                    signupVms.Add(signupVm);
                }

                return View(signupVms);
            }
        }
    }
}
