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
        private dbSpaceMentEntities1 db;
        public RatingController()
        {
            db = new dbSpaceMentEntities1();
        }
        // GET: Rating
        public ActionResult Rating_Index_Admin()//場地清單
        {
            IEnumerable<ClassSpaces> ListSpaces = (from obj in db.Spaces
                                                   select new ClassSpaces()
                                                   {
                                                       sName = obj.sName,
                                                       sType = obj.sType,
                                                       sNumber = obj.sNumber,
                                                       sIntro = obj.sIntro
                                                   }).ToList();
            return View(ListSpaces);
        }
        public ActionResult ShowComment(int sNumber)//列出評價
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
        public ActionResult AddComment(int sNumber)
        {
            ViewBag.sNumber = sNumber;
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(int sNumber, int rating, string rComment)//送出評價
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
                return RedirectToAction("Index");
            }
        }
    }
}