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
        public ActionResult Spaces_List()
        {
            // 場地總覽
            var datas = from p in (new dbSpaceMentEntities1()).Spaces
                        select p;
            return View(datas);
        }

        public ActionResult Spaces_Delete(int? id)
        {
            // 刪除場地
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
            //建立場地(存檔)
            Spaces SP = new Spaces();
            SP.sName = Request.Form["txtsName"];
            SP.sType = Request.Form["txtsType"];
            SP.sAddr = Request.Form["txtsAddr"];
            SP.sPhone = Request.Form["txtsPhone"];
            SP.sFloor = Request.Form["txtsFloor"];
            SP.sHeight = Request.Form["txtsHeight"];
            SP.sArea = Request.Form["txtsArea"];
            SP.sCapacity = Request.Form["txtsCapacity"];
            SP.sRent = decimal.Parse(Request.Form["txtsRent"]);
            SP.sRate = decimal.Parse(Request.Form["txtsRate"]);
            SP.sIntro = Request.Form["txtsTntro"];
            SP.sOpeningTime = Request.Form["txtsOpeningTime"];
            SP.sSecurity = Request.Form["txtsSecurity"];
            SP.sTraffic = Request.Form["txtsTraffic"];

            (new Spaces()).create(SP);
            return RedirectToAction("Spaces_List"); //跳轉至LIST
        }

        public ActionResult Spaces_Edit(int? id)
        {
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
            // 場地資訊
            if (id == null)
            {
                return RedirectToAction("Spaces_List");
            }
            ClassSpaces x = (new Spaces()).QueryByfid((int)id);
            return View(x);
        }
    }
}