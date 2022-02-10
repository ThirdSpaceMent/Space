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
            var datas = from p in (new SPACEMENTEntities()).Spaces
                        select p;
            return View(datas);
        }

        public ActionResult Spaces_Delete(int? id)
        {
            if (id != null)
            {
                (new CSpacesFactory()).delete((int)id);
            }
            return RedirectToAction("Spaces_List");
        }
    }
}