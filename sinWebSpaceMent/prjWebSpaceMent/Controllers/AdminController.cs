using prjWebSpaceMent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWebSpaceMent.Controllers
{
    public class AdminController : Controller
    {
        // 使用資料庫
        dbSpaceMentEntities1 db = new dbSpaceMentEntities1();
        // GET: Admin
        public ActionResult MemberManage()
        {
            // 會員總覽(系統管理者才能看到所有會員)
            var datas = from p in (new dbSpaceMentEntities1()).Members
                        select p;
            return View(datas);
        }
        public ActionResult SpaceManage()
        {
            // 場地總覽(系統管理者才能看到所有場地)
            var datas = from p in (new dbSpaceMentEntities1()).Spaces
                        select p;
            return View(datas);
        }

        public ActionResult DeleteMember(int mNumber)
        {
            var MemberDetail = db.Members.Where
                (m => m.mNumber == mNumber).FirstOrDefault();
            db.Members.Remove(MemberDetail);
            db.SaveChanges();
            return RedirectToAction("MemberManage","Admin");
        }
    }
}