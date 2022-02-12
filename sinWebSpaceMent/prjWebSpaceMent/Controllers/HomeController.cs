using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWebSpaceMent.Models;
using System.Web.Security;

namespace prjWebSpaceMent.Controllers
{
    
    public class HomeController : Controller
    {
        dbSpaceMentEntities1 db = new dbSpaceMentEntities1();
        public ActionResult Index()
        {
            return View("../Home/Index", "_Layout");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string mAccount, string mPassword)
        {
            var mem = db.Members
                .Where(s => s.mAccount == mAccount && s.mPassword == mPassword)
                .FirstOrDefault();
            if (mem == null)
            {
                ViewBag.Message = "帳密錯誤,登入失敗";
                return View();
            }
            Session["Welcome"] ="嗨，" +mem.mName + "，歡迎回來";
            FormsAuthentication.RedirectFromLoginPage(mAccount, true);
            return RedirectToAction("Index", "Member");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Members pMember)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var member = db.Members
                .Where(m => m.mAccount == pMember.mAccount)
                .FirstOrDefault();

            if (member == null)
            {
                db.Members.Add(pMember);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Message = "此帳號已有人使用，請重新註冊";
            return View();
        }
    }
}