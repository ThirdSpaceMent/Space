using prjWebSpaceMent.Models;
using prjWebSpaceMent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWebSpaceMent.Controllers
{
    public class FavoriteController : Controller
    {
        private SPACEMENTDB db;
        public FavoriteController()
        {
            db = new SPACEMENTDB();
        }
        // GET: Favorite
        public ActionResult Favorites_Index()//查看自己的追蹤清單
        {
            string CurrentUser = User.Identity.Name;

            //取出會員編號
            var Member = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
            if (CurrentUser == "")
            {
                TempData["AlertMessage"] = "請先登入!";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //取出該會員資料
                IEnumerable<FavoriteViewModel> listFVM = (from obj in db.Favorites
                                                          join Spaces in db.Spaces on obj.fFKtoSpace equals Spaces.sNumber
                                                          where obj.fFKtoMember == Member.mNumber
                                                          select new FavoriteViewModel()
                                                          {
                                                              fFKtoSpace = obj.fFKtoSpace,
                                                              sNumber = Spaces.sNumber,
                                                              sName = Spaces.sName,
                                                              sAddr = Spaces.sAddr,
                                                              sIntro = Spaces.sIntro,
                                                              sRent = (decimal)Spaces.sRent,
                                                              fCreatedat = obj.fCreate
                                                          }).ToList();
                return View(listFVM);
            }
        }

        public ActionResult AddFavToList(int sNumber)//加入追蹤
        {
            string CurrentUser = User.Identity.Name;
            var member = db.Members.Where(m => m.mAccount == CurrentUser).FirstOrDefault();
            Favorites obj = new Favorites();
            if (CurrentUser == "")
            {
                TempData["AlertMessage"] = "請先登入";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //查詢該場地是否在資料庫內
                var data = db.Favorites.Where(m => m.fFKtoMember == member.mNumber &&
                                                    m.fFKtoSpace == sNumber).FirstOrDefault();
                if (data != null)
                {
                    TempData["AlertMessage"] = "已經在清單中!";
                    return RedirectToAction("Spaces_Detail", "Spaces", new { id = sNumber });
                }
                else
                {
                    obj.fFKtoMember = member.mNumber;
                    obj.fFKtoSpace = sNumber;
                    obj.fCreate = DateTime.Now;
                    db.Favorites.Add(obj);
                    db.SaveChanges();
                    TempData["AlertMessage"] = "追蹤成功!";
                    return RedirectToAction("Spaces_Detail", "Spaces", new { id = sNumber });
                }
            }
        }
        public ActionResult Delete(int sNumber)//從清單移除
        {
            var deleteitem = db.Favorites.Where(m => m.fFKtoSpace == sNumber).FirstOrDefault();
            db.Favorites.Remove(deleteitem);
            db.SaveChanges();
            TempData["AlertMessage"] = "移除成功!";
            return RedirectToAction("Favorites_Index");
        }
    }
}