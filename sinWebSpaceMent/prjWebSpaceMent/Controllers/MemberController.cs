﻿using System;
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

        //會員的首頁
        public ActionResult Index()
        {
            var space =
                db.Spaces.OrderByDescending(m => m.sNumber).ToList();
            return View("../Member/Index", "_LayoutMember", space);
        }

        //會員編輯總覽
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

        //會員登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        //我的預訂
        public ActionResult ShoppingCar()
        {
            string oMemberAccount = User.Identity.Name;
            var OrderDetails = db.Orders.Where
                (m => m.oMemberAccount == oMemberAccount)
                .ToList();
            return View(OrderDetails);
        }

        //刪除訂單
        public ActionResult DeleteOrder(int oNumber)
        {
            var orderDetail = db.Orders.Where
                (m => m.oNumber == oNumber).FirstOrDefault();
            db.Orders.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }

        //會員資料編輯
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
