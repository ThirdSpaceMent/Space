using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using prjWebSpaceMent.Models;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;


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
            string oMemberAccount = User.Identity.Name;
            var OrderDetails = db.Orders.Where
                (m => m.oMemberAccount == oMemberAccount)
                .ToList();
            return View(OrderDetails);
        }

        //public ActionResult ShoppingCar()
        //{
        //    string oMemberAccount = User.Identity.Name;
        //    var OrderDetails = db.Orders.Where
        //        (m => m.oMemberAccount == oMemberAccount)
        //        .ToList();
        //    return View(OrderDetails);
 

        //以下是把選擇的場地下定加入清單的方法 但因資料對接不順利的問題 因此尚待解決//
        public ActionResult AddCar(string oAccount)
        {
            string oMemberAccount = User.Identity.Name;
            var car = db.Orders
                .Where(m => m.oMemberAccount == oMemberAccount && m.oAccount == oAccount).FirstOrDefault();

            var space = db.Spaces.Where(m => m.oAccount == oAccount).FirstOrDefault();
            
            Orders order = new Orders();
            order.oAccount = space.oAccount;
            order.oMemberAccount = oMemberAccount;
            order.oCreated_at = DateTime.Now;
            order.oPrice = (int)space.sRent;
            db.Orders.Add(order);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            order.oScheduledTime = Convert.ToDateTime(space.sTimeRange);
            //db.Configuration.ValidateOnSaveEnabled = true;
            return RedirectToAction("ShoppingCar");
        }


        //以下是測試會員編輯功能 尚未成功//
        //public ActionResult Member_Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("ShoppingCar");
        //    }
        //    Members x = (new Members()).QueryByfid1((int)id);
        //    return View(x);
        //}

        //[HttpGet]
        //public ActionResult Member_Edit(Members p)
        //{
        //    if (p == null)
        //    {
        //        return RedirectToAction("ShoppingCar");
        //    }
        //    (new Members()).update1(p);
        //    return RedirectToAction("ShoppingCar");
        //}


    }
}
