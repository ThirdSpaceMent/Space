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
        // GET: Spaces
        public ActionResult Spaces_Index()
        {
            // 找場地首頁
            // 搜尋功能

            List<ClassSpaces> datas = null;

            string keyword = Request.Form["txtKeyword"]; // 關鍵字搜尋欄位
            string city = Request.Form["city"];          // 城市 下拉選單的值
            string type = Request.Form["type"];          // 活動類型 下拉選單的值


            if (string.IsNullOrEmpty(keyword)) //如果搜尋框是空
            {
                datas = (new Spaces()).QueryAll(city, type); // 列出所有
            }
            else
            {
                datas = (new Spaces()).QueryByKeyword(keyword, city, type);
            }
            return View(datas);
        }

        public ActionResult Spaces_List()
        {
            // 場地總覽(管理者功能)
            var datas = from p in (new dbSpaceMentEntities1()).Spaces
                        select p;
            return View(datas);
        }

        public ActionResult Spaces_Delete(int? id)
        {
            // 刪除場地(管理者功能)
            if (id != null)
            {
                (new Spaces()).delete((int)id);
            }
            return RedirectToAction("Spaces_List");
        }

        public ActionResult Spaces_Create()
        {
            return View();
        }

        public ActionResult Spaces_Save()
        {
            //建立場地的存檔(管理者功能)
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

            (new Spaces()).create(SP);
            return RedirectToAction("Spaces_List"); //跳轉至LIST
        }

        public ActionResult Spaces_Edit(int? id)
        {
            // 修改場地(管理者功能)
            if (id == null)
            {
                return RedirectToAction("Spaces_List");
            }
            ClassSpaces x = (new Spaces()).QueryByfid((int)id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Spaces_Edit(ClassSpaces p)
        {
            if (p == null)
            {
                return RedirectToAction("Spaces_List");
            }
            (new Spaces()).update(p);
            return RedirectToAction("Spaces_List");
        }

        public ActionResult Spaces_Detail(int? id)
        {
            //客戶端場地資訊
            // 各場地資訊
            if (id == null)
            {
                return RedirectToAction("Spaces_Index");
            }
            ClassSpaces x = (new Spaces()).QueryByfid((int)id);
            return View(x);
        }

        public ActionResult Spaces_List_Detail(int? id)
        {
            //場地主端場地資訊
            // 各場地資訊
            if (id == null)
            {
                return RedirectToAction("Spaces_List");
            }
            ClassSpaces x = (new Spaces()).QueryByfid((int)id);
            return View(x);
        }
    }
}