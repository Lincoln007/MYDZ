﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Print;
using MYDZ.Interface.Print;

namespace MYDZ.Business.DataBase_BLL.Print
{
    public class PrintPlaneSingleDetail
    {
        public static IPrintPlaneSingleDetail SetPrintPlaneSingleDetail = (IPrintPlaneSingleDetail)MYDZ.DALFactory.DataAccess.Create("Print.PrintPlaneSingleDetail");
        /// <summary>
        /// 根据面单模板编号查询打印面单模板明细信息列表
        /// </summary>
        /// <param name="PlaneId">面单模板编号</param>
        /// <returns></returns>
        public static IList<tbPrintPlaneSingleDetail> Select(int PlaneId)
        {
            return SetPrintPlaneSingleDetail.Select(PlaneId);
        }

        /// <summary>
        /// 添加打印面单模板明细信息
        /// </summary>
        /// <param name="PrintPlaneSingleDetail">打印面单模板明细表</param>
        /// <returns></returns>
        public static bool Insert(tbPrintPlaneSingleDetail PrintPlaneSingleDetail)
        {
            return SetPrintPlaneSingleDetail.Insert(PrintPlaneSingleDetail);
        }

        /// <summary>
        /// 删除打印面单模板明细信息
        /// </summary>
        /// <param name="PlaneId">面单模板编号</param>
        /// <returns></returns>
        public static bool Delete(int PlaneId)
        {
            return SetPrintPlaneSingleDetail.Delete(PlaneId);
        }
    }
}
