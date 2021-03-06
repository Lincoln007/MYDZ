﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Shop;

namespace MYDZ.Interface.Shop
{
    public interface IShopInfo : BaseInterface
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="ShopScore"></param>
        /// <returns></returns>
        int InsertShopInfo(tbShopInfo ShopInfo);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="ShopScore"></param>
        /// <returns></returns>
        bool UpdateShopInfo(tbShopInfo ShopInfo);
        /// <summary>
        /// 查询数据( by ShopId)
        /// </summary>
        /// <param name="ScoreId"></param>
        /// <returns></returns>
        tbShopInfo SelecttbShopInfoByShopId(string ShopId);
        /// <summary>
        /// 查询数据(by ShopId)
        /// </summary>
        /// <param name="ScoreId"></param>
        /// <returns></returns>
        List<tbShopInfo> SelecttbShopInfoByTBShopId(string TBShopId);
    }
}
