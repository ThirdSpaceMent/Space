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
using PagedList;

namespace prjWebSpaceMent.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        dbSpaceMentEntities1 db = new dbSpaceMentEntities1();

        int pageSize = 5;
        // GET: Member
        public ActionResult Index()
        {
            var space =
                db.Spaces.OrderByDescending(m => m.sNumber).ToList();
            return View("../Member/Index", "_LayoutMember", space);
        }

        //編輯後無法第二次編輯
        public ActionResult memberIndex()
        {
            string mAccount = User.Identity.Name;
            var employees = db.Members.Where(m => m.mAccount == mAccount).ToList();
            return View(employees);
            //var space =
            //    db.Spaces.OrderByDescending(m => m.sNumber).ToList();
            //return View("../Member/Index", "_LayoutMember", space);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ShoppingCar(int page = 1)
        {
            string oMemberAccount = User.Identity.Name;
            int currentPage = pageSize < 1 ? 1 : page;
            var OrderDetails = db.Orders.OrderBy
                (m => m.oMemberAccount == oMemberAccount)
                .ToList();
            var result = OrderDetails.ToPagedList(currentPage, pageSize);
            return View(result);
        }

        //public ActionResult ShoppingCar()
        //{
        //    string oMemberAccount = User.Identity.Name;
        //    var OrderDetails = db.Orders.Where
        //        (m => m.oMemberAccount == oMemberAccount)
        //        .ToList();
        //    return View(OrderDetails);


        //以下是把選擇的場地下定加入清單的方法 但因資料對接不順利的問題 因此尚待解決//
        //public ActionResult AddCar(string oAccount)
        //{
        //    string oMemberAccount = User.Identity.Name;
        //    var car = db.Orders
        //        .Where(m => m.oMemberAccount == oMemberAccount && m.oAccount == oAccount).FirstOrDefault();

        //    var space = db.Spaces.Where(m => m.oAccount == oAccount).FirstOrDefault();

        //    Orders order = new Orders();
        //    order.oAccount = space.oAccount;
        //    order.oMemberAccount = oMemberAccount;
        //    order.oCreated_at = DateTime.Now;
        //    order.oPrice = (int)space.sRent;
        //    db.Orders.Add(order);
        //    db.Configuration.ValidateOnSaveEnabled = false;
        //    db.SaveChanges();
        //    order.oScheduledTime = Convert.ToDateTime(space.sTimeRange);
        //    //db.Configuration.ValidateOnSaveEnabled = true;
        //    return RedirectToAction("ShoppingCar");
        //}


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

        public ActionResult DeleteOrder(int oNumber)
        {
            var orderDetail = db.Orders.Where
                (m => m.oNumber == oNumber).FirstOrDefault();
            db.Orders.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }

        //public ActionResult Edit1(string mAccount)
        //{
        //    var member = db.Members
        //        .Where(m => m.mAccount == mAccount).FirstOrDefault();
        //    return View(member);
        //}

        //[HttpPost]
        //public ActionResult Edit1(Members member)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var temp = db.Members
        //            .Where(m => m.mAccount == member.mAccount).FirstOrDefault();
        //        temp.mAccount = member.mAccount;
        //        temp.mPassword = member.mPassword;
        //        temp.mName = member.mName;
        //        temp.mNickName = member.mNickName;
        //        temp.mEmail = member.mEmail;
        //        temp.mPhone = member.mPhone;
        //        temp.mGender = member.mGender;
        //        temp.mTWid = member.mTWid;
        //        temp.mBirthday = member.mBirthday;
        //        temp.mPoint = member.mPoint;
        //        temp.mCreated_at = member.mCreated_at;
        //        temp.mUpdated_at = member.mUpdated_at;
        //        db.SaveChanges();
        //        return RedirectToAction("memberIndex");

        //    }

        //    return View(member);
        //}

        public ActionResult Edit(int id)
        {
            Members member = db.Members.FirstOrDefault(m => m.mNumber == id);
            if (member == null)
                return RedirectToAction("memberIndex");
            return View(member);
        }
        [HttpPost]
        public ActionResult Edit(Members member)
        {
            Members temp = db.Members.FirstOrDefault(t => t.mNumber == member.mNumber);
            if (temp != null)
            {
                temp.mAccount = member.mAccount;
                temp.mPassword = member.mPassword;
                temp.mName = member.mName;
                temp.mNickName = member.mNickName;
                temp.mEmail = member.mEmail;
                temp.mPhone = member.mPhone;
                temp.mGender = member.mGender;
                temp.mTWid = member.mTWid;
                temp.mBirthday = member.mBirthday;
                temp.mPoint = member.mPoint;
                temp.mCreated_at = member.mCreated_at;
                temp.mUpdated_at = member.mUpdated_at;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Member");
        }

    }
}
