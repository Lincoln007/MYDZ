﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using MYDZ.Entity.Shop;
using MYDZ.Entity.Menu;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [DataContract(Namespace = "", Name = "user")]
    public class tbClientUser : Response
    {
        /// <summary>
        /// 是否第一次已成功插入
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 用户编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "user_id", Order = 0)]
        public int UserId { get; set; }

        /// <summary>
        /// 淘宝用户编号
        /// </summary>
        [DataMember(Name = "tb_user_id", Order = 1)]
        public int TbUserId { get; set; }

        /// <summary>
        /// 父用户编号
        /// </summary>
        [DataMember(Name = "parent_id", Order = 2)]
        public int ParentId { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [DataMember(Name = "user_nick", Order = 3)]
        public string UserNick { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        [DataMember(Name = "gender", Order = 4)]
        public tbClientUserGender Gender { get; set; }

        /// <summary>
        /// 用户信用
        /// </summary>
        [DataMember(Name = "credit", Order = 5)]
        public tbClientUserCredit Credit { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [DataMember(Name = "type", Order = 6)]
        public tbClientUserType Type { get; set; }

        /// <summary>
        /// 是否购买多图服务
        /// </summary>
        [DataMember(Name = "has_more_pic", Order = 7)]
        public bool HasMorePic { get; set; }

        /// <summary>
        /// 可上传商品图片数量
        /// </summary>
        [DataMember(Name = "item_img_num", Order = 8)]
        public int ItemImgNum { get; set; }

        /// <summary>
        /// 单张商品图片最大容量(单位K)
        /// </summary>
        [DataMember(Name = "item_img_size", Order = 9)]
        public int ItemImgSize { get; set; }

        /// <summary>
        /// 可上传属性图片数量
        /// </summary>
        [DataMember(Name = "prop_img_num", Order = 10)]
        public int PropImgNum { get; set; }

        /// <summary>
        /// 单张属性图片最大容量(单位K)
        /// </summary>
        [DataMember(Name = "prop_img_size", Order = 11)]
        public int PropImgSize { get; set; }

        /// <summary>
        /// 是否受限
        /// </summary>
        [DataMember(Name = "auto_repost", Order = 12)]
        public bool AutoRepost { get; set; }

        /// <summary>
        /// 是否实名认证
        /// </summary>
        [DataMember(Name = "promoted_type", Order = 13)]
        public bool PromotedType { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [DataMember(Name = "status", Order = 14)]
        public tbClientUserStatus Status { get; set; }

        /// <summary>
        /// 用户级别
        /// </summary>
        [DataMember(Name = "level", Order = 15)]
        public tbClientUserLevel Level { get; set; }

        /// <summary>
        /// 是否绑定支付宝
        /// </summary>
        [DataMember(Name = "alipay_bind", Order = 16)]
        public bool AlipayBind { get; set; }

        /// <summary>
        /// 是否参加消保
        /// </summary>
        [DataMember(Name = "protection", Order = 17)]
        public bool Protection { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        [DataMember(Name = "avatar", Order = 18)]
        public string Avatar { get; set; }

        /// <summary>
        /// 是否是无名良品用户
        /// </summary>
        [DataMember(Name = "liangpin", Order = 19)]
        public bool LiangPin { get; set; }

        /// <summary>
        /// 卖家是否签署食品卖家承诺协议
        /// </summary>
        [DataMember(Name = "sign_foods", Order = 20)]
        public bool SignFoods { get; set; }

        /// <summary>
        /// 用户作为卖家是否开过店
        /// </summary>
        [DataMember(Name = "has_shop", Order = 21)]
        public bool HasShop { get; set; }

        /// <summary>
        /// 是否24小时闪电发货(实物类)
        /// </summary>
        [DataMember(Name = "is_lightning_consignment", Order = 22)]
        public bool IsLightning { get; set; }

        /// <summary>
        /// 用户是否具备修改商品减库存权限
        /// </summary>
        [DataMember(Name = "has_sub_stock", Order = 23)]
        public bool HasSubStock { get; set; }

        /// <summary>
        /// 用户是否是金牌卖家
        /// </summary>
        [DataMember(Name = "is_golden_seller", Order = 24)]
        public bool GoldenSeller { get; set; }

        /// <summary>
        /// 是否订阅了淘宝天下杂志
        /// </summary>
        [DataMember(Name = "magazine_subscribe", Order = 25)]
        public bool Subscribe { get; set; }

        /// <summary>
        /// 用户参与垂直市场类型
        /// </summary>
        [DataMember(Name = "vertical_market", Order = 26)]
        public string VerMarket { get; set; }

        /// <summary>
        /// 用户是否为网游用户
        /// </summary>
        [DataMember(Name = "online_gaming", Order = 27)]
        public bool OnlineGaming { get; set; }

        /// <summary>
        /// 剩余邮件数
        /// </summary>
        [DataMember(Name = "email_num", Order = 28)]
        public int EmailNum { get; set; }

        /// <summary>
        /// 剩余短信数
        /// </summary>
        [DataMember(Name = "sms_num", Order = 29)]
        public int SMSNum { get; set; }

        /// <summary>
        /// 魔币余额
        /// </summary>
        [DataMember(Name = "currency", Order = 30)]
        public decimal Currency { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [DataMember(Name = "validity", Order = 31)]
        public DateTime Validity { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        [DataMember(Name = "input_date", Order = 32)]
        public DateTime InputDate { get; set; }

        /// <summary>
        /// 用户店铺关系信息
        /// </summary>
        [DataMember(Name = "user_shops", Order = 33)]
        public IList<tbClientUserShop> UserShops { get; set; }

        /// <summary>
        /// 角色信息列表
        /// </summary>
        [DataMember(Name = "user_roles", Order = 34)]
        public IList<tbRoleInfo> Roles { get; set; }

        /// <summary>
        /// 用户快捷菜单列表
        /// </summary>
        [DataMember(Name = "user_menus", Order = 35)]
        public IList<tbMenuInfo> Menus { get; set; }
    }
}
