using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using prjWebSpaceMent.Models;

namespace prjWebSpaceMent.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        dbSpaceMentEntities1 db = new dbSpaceMentEntities1();
        // GET: Member
        public ActionResult Index()
        {
            var space =
                db.Spaces.OrderByDescending(m => m.sNumber).ToList();
            return View("../Member/Index", "_LayoutMember", space);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ShoppingCar()
        {
            string oAccount = User.Identity.Name;
            var OrderDetails = db.Orders.Where
                (m => m.oAccount == oAccount)
                .ToList();
            return View(OrderDetails);
        }
    }
}