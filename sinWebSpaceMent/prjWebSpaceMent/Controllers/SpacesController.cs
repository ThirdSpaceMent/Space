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
        // 找場地首頁
        public ActionResult Spaces_Index(string keywords, string citys, string types)
        {


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

        // 場地清單-分為系統管理者(全部)&會員(自己的場地)
        public ActionResult Spaces_List()
        {
            string mAccount = User.Identity.Name; //登入者(會員)的帳號

            var mem = db.Members
                .Where(s => s.mAccount == mAccount)
                .FirstOrDefault();

            if (mAccount != null && mAccount != "") // 會員才能瀏覽
            {
                if (mAccount == "CHEEE")  //暫定這一位是管理者
                {
                    // 場地總覽(系統管理者才能看到所有場地)

                    return RedirectToAction("SpaceManage", "Admin");
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

        // 刪除場地(會員自己的場地刪除)
        public ActionResult Spaces_Delete(int? id)
        {

            if (id != null)
            {
                (new CSpacesFactory()).delete((int)id);
            }
            return RedirectToAction("Spaces_List");
        }

        //建立場地的頁面
        public ActionResult Spaces_Create()
        {
            return View();
        }

        //建立場地的存檔(會員功能)
        public ActionResult Spaces_Save()
        {
            //建立場地的存檔(會員功能)

            string mAccount = User.Identity.Name; //登入者(會員)的帳號

            var mem = db.Members
                .Where(s => s.mAccount == mAccount)
                .FirstOrDefault();

            ClassSpaces SP = new ClassSpaces();
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
            SP.FK_Space_to_Owner = mem.mNumber; //綁定是誰新增場地

            (new CSpacesFactory()).create(SP);
            return RedirectToAction("Spaces_List"); //跳轉至LIST
        }

        // 修改場地(管理者功能)
        public ActionResult Spaces_Edit(int? id)
        {
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

        // 一般使用者-場地資訊明細
        // 會員才可下訂單
        public ActionResult Spaces_Detail(int? id)
        {
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

        // 場地主端-場地資訊明細
        // 不可下訂單
        public ActionResult Spaces_List_Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Spaces_List");
            }
            ClassSpaces x = (new CSpacesFactory()).QueryByfid((int)id);
            return View(x);
        }

        //下訂單，跳轉到我的預訂頁面
        public ActionResult AddCar(string oAccount, string snumsnum, string morning, string afternoon, string evening, string datepick)
        {
            string oMemberAccount = User.Identity.Name; //登入者的帳號
            var mem = db.Members.Where(m => m.mAccount == oMemberAccount).FirstOrDefault();

            //場地table
            //oAccount 場地編號 =sNumber
            int sNumber = Convert.ToInt32(oAccount); //將前端帶入的場地編號轉成int
            var space = db.Spaces.Where(m => m.sNumber == sNumber).FirstOrDefault();

            //勾選的時段部分
            string TimeRange = ""; //時段欄位

            if (morning == "1")
            {
                TimeRange = TimeRange + "上午,";
            }
            if (afternoon == "1")
            {
                TimeRange = TimeRange + "下午,";
            }
            if (evening == "1")
            {
                TimeRange = TimeRange + "晚上,";
            }
            TimeRange = TimeRange.Substring(0, TimeRange.Length - 1); //刪除最後逗點

            // 找該時段是否已被預訂
            DateTime startDateTime = Convert.ToDateTime(datepick + " 00:00:00"); // at 00:00:00
            DateTime endDateTime = Convert.ToDateTime(datepick + " 23:59:59"); // at 23:59:59

            // od.oAccount是Order table的場地編號；oAccount是前端帶過來的場地編號
            var orderdc = from od in db.Orders
                          where od.FK_Order_to_Space == sNumber && od.oScheduledTime >= startDateTime && od.oScheduledTime <= endDateTime && od.oTimeRange.Contains(TimeRange)
                          select od;

            // 找出
            decimal tc = orderdc.Count();
            if (tc > 0)
            {
                return Content("該場地時段已被預訂");
            }

            // 開始帶入資料
            Orders order = new Orders();
            order.FK_Order_to_Space = sNumber;    //場地編號
            order.oStatus = space.sName;  //oStatus暫時借用來存場地名稱
            order.oMemberAccount = oMemberAccount;  //是誰訂場地(帳號)
            order.oCreated_at = DateTime.Now;       // 下訂時間
            //order.oPrice = (int)space.sRent;        // 每時段費用
            order.oPayment = Convert.ToDecimal(snumsnum);   //小計
            order.oTimeRange = TimeRange;       //哪個時段(上午、中午、晚上)
            order.FK_Order_to_Member_Owner = space.FK_Space_to_Owner;   //場地是誰的
            order.FK_Order_to_Member_User = mem.mNumber;                //預訂的人
            order.oScheduledTime = Convert.ToDateTime(datepick);        //場地的使用日期

            db.Orders.Add(order);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();

            return RedirectToAction("ShoppingCar", "Member");
        }

        // 我的客訂單
        public ActionResult Spaces_Order()
        {
            // 跑出此會員全部客訂單 照日期排序

            string oMemberAccount = User.Identity.Name; //登入者的帳號
            var mem = db.Members.Where(m => m.mAccount == oMemberAccount).FirstOrDefault();

            // 找出Orders Table裡面的場地主id 對應到 目前登入者的id
            var order = from o in db.Orders
                        where o.FK_Order_to_Member_Owner == mem.mNumber
                        orderby o.oScheduledTime ascending     //遞增(日期從小到大)
                        select o;

            return View(order);
        }

    }
}

