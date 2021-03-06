using prjWebSpaceMent.Models;
using prjWebSpaceMent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace prjWebSpaceMent.Controllers
{
    public class AdminController : Controller
    {
        // 使用資料庫
        SPACEMENTEntitiesLocalDB db = new SPACEMENTEntitiesLocalDB();
        // GET: Admin

        //管理者首頁
        public ActionResult Admin_Index()
        {
            string CurrentUser = User.Identity.Name;
            var memberdata = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
            if (CurrentUser == "CHEEE")
            {
                Session["Welcome"] = "嗨，" + memberdata.mName + "，歡迎回來";
                return View("Admin_Index", "_LayoutAdmin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //管理者登入頁面
        public ActionResult Admin_Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin_Login(string mAccount, string mPassword)
        {
            var mem = db.Members
                .Where(s => s.mAccount == mAccount && s.mPassword == mPassword)
                .FirstOrDefault();

            if (mAccount == "CHEEE")  //暫定這一位是管理者
            {
                Session["Welcome"] = "嗨，" + mem.mName + "，歡迎回來";
                FormsAuthentication.RedirectFromLoginPage(mAccount, true);
                return RedirectToAction("Admin_Index", "Admin");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        //會員管理
        public ActionResult MemberManage()
        {
            // 會員總覽(系統管理者才能看到所有會員)
            var datas = from p in (new SPACEMENTEntitiesLocalDB()).Members
                        select p;
            return View(datas);
        }

        //場地管理
        public ActionResult SpaceManage()
        {
            // 場地總覽(系統管理者才能看到所有場地)
            var datas = from p in (new SPACEMENTEntitiesLocalDB()).Spaces
                        select p;
            return View(datas);
        }

        //刪除會員
        public ActionResult DeleteMember(int mNumber)
        {
            var MemberDetail = db.Members.Where
                (m => m.mNumber == mNumber).FirstOrDefault();
            db.Members.Remove(MemberDetail);
            db.SaveChanges();
            return RedirectToAction("MemberManage","Admin");
        }

        //場地管理場地明細
        public ActionResult Spaces_Detail_Admin(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SpaceManage");
            }
            ClassSpaces x = (new CSpacesFactory()).QueryByfid((int)id);

            // 辨別登入
            string mAccount = User.Identity.Name; //登入者(會員)的帳號

            var mem = db.Members
                .Where(s => s.mAccount == mAccount)
                .FirstOrDefault();
            if (mAccount == "CHEEE")  //暫定這一位是管理者
            {
                // 場地總覽(系統管理者才能看到所有場地)

                return View(x);
            }
            else
            {
                return RedirectToAction("SpaceManage");
            }
           
        }

        // 修改場地(管理者功能)
        public ActionResult Spaces_Edit_Admin(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SpaceManage");
            }
            ClassSpaces x = (new CSpacesFactory()).QueryByfid((int)id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Spaces_Edit_Admin(ClassSpaces p)
        {
            if (p == null)
            {
                return RedirectToAction("SpaceManage");
            }
            (new CSpacesFactory()).update(p);
            return RedirectToAction("SpaceManage");
        }

        //管理者頁面使用
        //評價管理
        public ActionResult Rating_Index_Admin()
        {
            //List<Rates> ListRates = (from d in db.Rates select d).ToList();
            IEnumerable<RatingViewModel> ListRVM = (from obj in db.Rates
                                                    join sp in db.Spaces on obj.FK_Rate_to_Space equals sp.sNumber
                                                    select new RatingViewModel()
                                                    {
                                                        FK_Rate_to_Space = (int)obj.FK_Rate_to_Space,
                                                        FK_Rate_to_Member = (int)obj.FK_Rate_to_Member,
                                                        FK_Rate_to_Order = (int)obj.FK_Rate_to_Order,
                                                        rRate = (decimal)obj.rRate,
                                                        rNumber = obj.rNumber,
                                                        rComment = obj.rComment,
                                                        rCreated_at = (DateTime)obj.rCreated_at,
                                                        sNumber = sp.sNumber,
                                                        sName = sp.sName
                                                    }).ToList();
            return View(ListRVM);
        }

        //列出評價
        public ActionResult ShowRating_Admin(int sNumber)
        {
            IEnumerable<RatingViewModel> listRVM = (from obj in db.Rates
                                                    where obj.FK_Rate_to_Space == sNumber
                                                    select new RatingViewModel()
                                                    {
                                                        FK_Rate_to_Space = (int)obj.FK_Rate_to_Space,
                                                        FK_Rate_to_Member = (int)obj.FK_Rate_to_Member,
                                                        FK_Rate_to_Order = (int)obj.FK_Rate_to_Order,
                                                        rRate = (decimal)obj.rRate,
                                                        rNumber = obj.rNumber,
                                                        rComment = obj.rComment,
                                                        rCreated_at = obj.rCreated_at
                                                    }).ToList();
            ViewBag.sNumber = sNumber;
            return View(listRVM);
        }
        public ActionResult DeleteRating(int rNumber)
        {
            Rates obj = db.Rates.Where(m => m.rNumber == rNumber).FirstOrDefault();
            db.Rates.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Rating_Index_Admin");
        }
    }
}