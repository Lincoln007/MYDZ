﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Entity.ClientUser;
using MYDZ.Business.InitUser;

namespace MYDZ.WebUI.Member
{
    // Controller--->BaseController
    public class MemberController : Controller
    {
        public ViewResult Index()
        {

            // 仅做测试之用
            tbClientUser User = new tbClientUser();
            tbClientUserShop sh = new tbClientUserShop();

            sh.SessionKey = "6201f00fhj8b68346bac1b7fae0cf20b50b30f6929dd558264760512";
            sh.UserId =15;
            sh.Shop = new Entity.Shop.tbShopInfo();
            sh.Shop.ShopId = 20;
            User.UserNick = "andrinuo旗舰店";
            User.UserShops = new List<tbClientUserShop>();
            User.UserShops.Add(sh);
            User.UserId =15;
            //tbClientUser User = new UserInfo().FromCodeToGetAccesToken(code);
            Session["UserInfo"] = User;

            return View();
        }
    }
}
