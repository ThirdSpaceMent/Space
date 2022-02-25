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
        private dbSpaceMentEntities1 db;
        public FavoriteController()
        {
            db = new dbSpaceMentEntities1();
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
                                                          join Spaces in db.Spaces on obj.FK_Favorite_to_Space equals Spaces.sNumber
                                                          where obj.FK_Favorite_to_Member == Member.mNumber
                                                          select new FavoriteViewModel()
                                                          {
                                                              FK_Favorite_to_Space = obj.FK_Favorite_to_Space,
                                                              sNumber = Spaces.sNumber,
                                                              sName = Spaces.sName,
                                                              sAddr = Spaces.sAddr,
                                                              sIntro = Spaces.sIntro,
                                                              sRent = Spaces.sRent,
                                                              fCreated_at = obj.fCreated_at
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
                var data = db.Favorites.Where(m => m.FK_Favorite_to_Member == member.mNumber &&
                                                    m.FK_Favorite_to_Space == sNumber).FirstOrDefault();
                if (data != null)
                {
                    TempData["AlertMessage"] = "已經在清單中!";
                    return RedirectToAction("Spaces_Detail", "Spaces", new { id = sNumber });
                }
                else
                {
                    obj.FK_Favorite_to_Member = member.mNumber;
                    obj.FK_Favorite_to_Space = sNumber;
                    obj.fCreated_at = DateTime.Now;
                    db.Favorites.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Spaces_Detail", "Spaces", new { id = sNumber });
                }
            }
        }
        public ActionResult Delete(int sNumber)//從清單移除
        {
            var deleteitem = db.Favorites.Where(m => m.FK_Favorite_to_Space == sNumber).FirstOrDefault();
            db.Favorites.Remove(deleteitem);
            db.SaveChanges();
            return RedirectToAction("FavoritesIndex");
        }
    }
}