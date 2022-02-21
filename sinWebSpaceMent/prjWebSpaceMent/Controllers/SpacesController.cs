using prjWebSpaceMent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWebSpaceMent.Controllers
{
    public class SpacesController : Controller
    {
        // 使用資料庫
        dbSpaceMentEntities1 db = new dbSpaceMentEntities1();

        // GET: Spaces
        public ActionResult Spaces_Index(string keywords, string citys, string types)
        {
            // 找場地首頁

            // 搜尋功能
            List<ClassSpaces> datas = null;

            string keyword = "";     // 關鍵字 搜尋欄位
            string city = "";        // 城市 下拉選單的值
            string type = "";        // 活動類型 下拉選單的值

            // 帶入的參數
            if (keywords != "" && keywords != null)
            {
                keyword = keywords;
            }
            else
            {
                keyword = Request.Form["txtKeyword"];
            }

            if (citys != "" && citys != null)
            {
                city = citys;
            }
            else
            {
                city = Request.Form["city"];
            }

            if (types != "" && types != null)
            {
                type = types;
            }
            else
            {
                type = Request.Form["type"];
            }

            // 如果搜尋框是空
            if (string.IsNullOrEmpty(keyword))
            {
                datas = (new CSpacesFactory()).QueryAll(city, type); // 列出所有
            }
            else
            {
                datas = (new CSpacesFactory()).QueryByKeyword(keyword, city, type);
            }

            // 辨別登入
            string mAccount = User.Identity.Name; //登入者(會員)的帳號

            var mem = db.Members
                .Where(s => s.mAccount == mAccount)
                .FirstOrDefault();

            if (mem != null)
            {
                Session["Welcome"] = "嗨，" + mem.mName + "，歡迎回來";
                return View("../Spaces/Spaces_Index", "_LayoutMember", datas);
            }
            else
            {
                return View(datas);
            }
        }

        public ActionResult Spaces_List()
        {
            // 場地清單-分為系統管理者(全部)&會員(自己的場地)

            string mAccount = User.Identity.Name; //登入者(會員)的帳號

            var mem = db.Members
                .Where(s => s.mAccount == mAccount)
                .FirstOrDefault();

            if (mAccount != null && mAccount != "") // 會員才能瀏覽
            {
                if (mAccount == "CHEEE")  //暫定這一位是管理者
                {
                    // 場地總覽(系統管理者才能看到所有場地)
                    var datas = from p in (new dbSpaceMentEntities1()).Spaces
                                select p;
                    return View(datas);
                }
                else
                {
                    // 非系統管理者 只能看到自己上架的場地
                    var mem_datas = from t in (new dbSpaceMentEntities1()).Spaces
                                    where t.FK_Space_to_Owner == mem.mNumber
                                    select t;
                    return View(mem_datas);
                }
            }
            else
            {
                return RedirectToAction("Index", "Member");
            }
        }

        public ActionResult Spaces_Delete(int? id)
        {
            // 刪除場地(會員自己的場地刪除)
            if (id != null)
            {
                (new CSpacesFactory()).delete((int)id);
            }
            return RedirectToAction("Spaces_List");
        }

        public ActionResult Spaces_Create()
        {
            return View();
        }

        public ActionResult Spaces_Save()
        {
            //建立場地的存檔(會員功能)
            Spaces SP = new Spaces();
            SP.sName = Request.Form["txtsName"];
            SP.sType = Request.Form["select_type"]; //下拉式選項
            SP.sAddr = Request.Form["txtsAddr"];
            SP.sPhone = Request.Form["txtsPhone"];
            SP.sFloor = Request.Form["txtsFloor"];
            SP.sHeight = Request.Form["txtsHeight"];
            SP.sArea = Request.Form["txtsArea"];
            SP.sCapacity = Request.Form["txtsCapacity"];
            SP.sRent = decimal.Parse(Request.Form["txtsRent"]);
            SP.sRate = decimal.Parse(Request.Form["txtsRate"]);
            SP.sIntro = Request.Form["txtsIntro"];
            SP.sOpeningTime = Request.Form["txtsOpeningTime"];
            SP.sSecurity = Request.Form["txtsSecurity"];
            SP.sTraffic = Request.Form["txtsTraffic"];

            (new CSpacesFactory()).create(SP);
            return RedirectToAction("Spaces_List"); //跳轉至LIST
        }

        public ActionResult Spaces_Edit(int? id)
        {
            // 修改場地(管理者功能)
            if (id == null)
            {
                return RedirectToAction("Spaces_List");
            }
            ClassSpaces x = (new CSpacesFactory()).QueryByfid((int)id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Spaces_Edit(ClassSpaces p)
        {
            if (p == null)
            {
                return RedirectToAction("Spaces_List");
            }
            (new CSpacesFactory()).update(p);
            return RedirectToAction("Spaces_List");
        }

        public ActionResult Spaces_Detail(int? id)
        {
            // 一般使用者-場地資訊明細
            // 會員才可下訂單

            if (id == null)
            {
                return RedirectToAction("Spaces_Index");
            }
            ClassSpaces x = (new CSpacesFactory()).QueryByfid((int)id);

            // 辨別登入
            string mAccount = User.Identity.Name; //登入者(會員)的帳號

            var mem = db.Members
                .Where(s => s.mAccount == mAccount)
                .FirstOrDefault();

            if (mem != null)
            {
                Session["Welcome"] = "嗨，" + mem.mName + "，歡迎回來";
                return View("../Spaces/Spaces_Detail", "_LayoutMember", x);
            }
            else
            {
                return View(x);
            }
        }

        public ActionResult Spaces_List_Detail(int? id)
        {
            // 場地主端-場地資訊明細
            // 不可下訂單

            if (id == null)
            {
                return RedirectToAction("Spaces_List");
            }
            ClassSpaces x = (new CSpacesFactory()).QueryByfid((int)id);
            return View(x);
        }

        public ActionResult AddCar(string oAccount, string snumsnum, string morning, string afternoon, string evening)
        {
            string oMemberAccount = User.Identity.Name;
            var car = db.Orders
                .Where(m => m.oMemberAccount == oMemberAccount && m.oAccount == oAccount).FirstOrDefault();

            var space = db.Spaces.Where(m => m.oAccount == oAccount).FirstOrDefault();

            Orders order = new Orders();
            order.oAccount = space.oAccount;
            order.oStatus = space.sName; //oStatus暫時借用來存場地名稱
            order.oMemberAccount = oMemberAccount;
            order.oCreated_at = DateTime.Now;
            order.oPrice = (int)space.sRent;
            db.Orders.Add(order);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            order.oScheduledTime = Convert.ToDateTime(space.sTimeRange);
            //db.Configuration.ValidateOnSaveEnabled = true;
            return RedirectToAction("ShoppingCar", "Member");

        }

    }
}

