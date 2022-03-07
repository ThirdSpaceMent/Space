using prjWebSpaceMent.Models;
using prjWebSpaceMent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWebSpaceMent.Controllers
{
    public class RatingController : Controller
    {
        private SPACEMENTEntitiesLocalDB db;
        public RatingController()
        {
            db = new SPACEMENTEntitiesLocalDB();
        }
        // GET: Rating
        public ActionResult Rating_Index_Admin()//場地評價清單
        {
            IEnumerable<Spaces> ListSpaces = (from obj in db.Spaces
                                              select new Spaces()
                                              {
                                                  sName = obj.sName,
                                                  sType = obj.sType,
                                                  sNumber = obj.sNumber,
                                                  sIntro = obj.sIntro
                                              }).ToList();
            return View(ListSpaces);
        }
        public ActionResult Rating_Index()//用戶查看自己給予的評價
        {
            string CurrentUser = User.Identity.Name;

            //取出會員帳號
            var Member = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
            if (CurrentUser == "")
            {
                TempData["AlertMessage"] = "請先登入!";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //取出該會員資料
                IEnumerable<RatingViewModel> ListRates = (from obj in db.Rates
                                                          join Spaces in db.Spaces on obj.FK_Rate_to_Space equals Spaces.sNumber
                                                          where obj.FK_Rate_to_Member == Member.mNumber
                                                          select new RatingViewModel()
                                                          {
                                                              sNumber = obj.Spaces.sNumber,
                                                              sName = obj.Spaces.sName,
                                                              rRate = (decimal)obj.rRate,
                                                              rNumber = obj.rNumber,
                                                              rComment = obj.rComment,
                                                              rCreated_at = (DateTime)obj.rCreated_at,
                                                              rUpdated_at = (DateTime)obj.rUpdated_at,
                                                              FK_Rate_to_Member = (int)obj.FK_Rate_to_Member,
                                                              FK_Rate_to_Order = (int)obj.FK_Rate_to_Order,
                                                              FK_Rate_to_Space = (int)obj.FK_Rate_to_Space
                                                          }).ToList();
                return View(ListRates);
            }
        }
        public ActionResult ShowRating(int sNumber)//列出該場地評價
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
                                                        rCreated_at = (DateTime)obj.rCreated_at
                                                    }).ToList();
            ViewBag.sNumber = sNumber;
            return View(listRVM);
        }
        public ActionResult AddRating(int sNumber)//進行評價
        {
            ViewBag.sNumber = sNumber;
            return View();
        }
        [HttpPost]
        public ActionResult AddRating(int sNumber, int rating, string rComment)//送出評價
        {
            string CurrentUser = User.Identity.Name;
            if (CurrentUser == "")
            {
                ViewBag.Message = "請先登入";
                return View();
            }
            else
            {
                var member = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
                Rates obj = new Rates();
                obj.FK_Rate_to_Member = member.mNumber;
                obj.FK_Rate_to_Space = sNumber;
                obj.rComment = rComment;
                obj.rRate = rating;
                obj.rCreated_at = DateTime.Now;
                obj.rUpdated_at = DateTime.Now;
                db.Rates.Add(obj);
                db.SaveChanges();
                return RedirectToAction("ShowRating", new { sNumber = sNumber });
            }
        }
        public ActionResult EditRating(int sNumber)//修改評價
        {
            string CurrentUser = User.Identity.Name;
            var member = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
            Rates editdata = db.Rates.Where(r => r.FK_Rate_to_Space == sNumber&r.FK_Rate_to_Member==member.mNumber).FirstOrDefault();
            ViewBag.sNumber = sNumber;
            return View(editdata);
        }
        [HttpPost]
        public ActionResult EditRating(int sNumber, int rating, string rComment)
        {
            string CurrentUser = User.Identity.Name;
            var member = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
            Rates obj = db.Rates.Where(r => r.FK_Rate_to_Space == sNumber & r.FK_Rate_to_Member == member.mNumber).FirstOrDefault();
            obj.rComment = rComment;
            obj.rRate = rating;
            obj.rUpdated_at = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Rating_Index");
        }

        public ActionResult DeleteRating(int rNumber)//未開放用戶使用 功能已完成
        {
            Rates obj = db.Rates.Where(m => m.rNumber == rNumber).FirstOrDefault();
            db.Rates.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Rating_Index");
        }
    }
}