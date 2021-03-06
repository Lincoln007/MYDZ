﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Interface.ClientUser
{
     public interface IClientUser : BaseInterface
    {
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="ClientUser"></param>
        /// <returns></returns>
        int InsertUser(tbClientUser ClientUser);
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="ClientUser"></param>
        /// <returns></returns>
        bool UpdateUser(tbClientUser ClientUser);
        /// <summary>
        /// 查询数据库中是否存在该用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        tbClientUser ExitisUser(string TBUserId, string UserNick);
         /// <summary>
         /// 根据用户ID查询用户信息
         /// </summary>
         /// <param name="UserId"></param>
         /// <param name="UserNick"></param>
         /// <returns></returns>
        tbClientUser SelectUser(string UserId, string UserNick);

    }
}
