﻿using prjWebSpaceMent.Models;
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
        dbSpaceMentEntities1 db = new dbSpaceMentEntities1();
        // GET: Admin
        public ActionResult Admin_Index()
        {
            return View();
        }

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

        public ActionResult MemberManage()
        {
            // 會員總覽(系統管理者才能看到所有會員)
            var datas = from p in (new dbSpaceMentEntities1()).Members
                        select p;
            return View(datas);
        }
        public ActionResult SpaceManage()
        {
            // 場地總覽(系統管理者才能看到所有場地)
            var datas = from p in (new dbSpaceMentEntities1()).Spaces
                        select p;
            return View(datas);
        }

        public ActionResult DeleteMember(int mNumber)
        {
            var MemberDetail = db.Members.Where
                (m => m.mNumber == mNumber).FirstOrDefault();
            db.Members.Remove(MemberDetail);
            db.SaveChanges();
            return RedirectToAction("MemberManage","Admin");
        }

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

        //管理者頁面使用
        public ActionResult ShowComment_Admin(int sNumber)//列出評價
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
    }
}