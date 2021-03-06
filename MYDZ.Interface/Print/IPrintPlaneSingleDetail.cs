﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Print;
using MYDZ.Interface;

namespace MYDZ.Interface.Print
{
    public interface IPrintPlaneSingleDetail : BaseInterface
    {


        /// <summary>
        /// 根据面单模板编号查询打印面单模板明细信息列表
        /// </summary>
        /// <param name="PlaneId">面单模板编号</param>
        /// <returns></returns>
        IList<tbPrintPlaneSingleDetail> Select(int PlaneId);

        /// <summary>
        /// 添加打印面单模板明细信息
        /// </summary>
        /// <param name="PrintPlaneSingleDetail">打印面单模板明细表</param>
        /// <returns></returns>
        bool Insert(tbPrintPlaneSingleDetail PrintPlaneSingleDetail);

        /// <summary>
        /// 删除打印面单模板明细信息
        /// </summary>
        /// <param name="PlaneId">面单模板编号</param>
        /// <returns></returns>
        bool Delete(int PlaneId);
    }
}
