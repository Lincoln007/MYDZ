﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.Entity.Order;
using System.Data;
using MYDZ.DBUtility;
using System.Data.SqlClient;

namespace MYDZ.Data.SqlServer.Order
{
    public class ConsigneeInfo : IConsigneeInfo
    {
        private const string SQL_SELECT = "SelectConsigneeByOrdersNumber";                                  //根据订单编号查询收件人信息
        private const string SQL_INSERT = "InsertConsigneeInfo";                                            //添加收件人信息
        private const string SQL_UPDATE = "UpdateConsigneeInfo";                                            //修改收件人信息

        private const string PARM_ID = "@ConsigneeId";                                                      //收货人编号
        private const string PARM_NUMBER = "@OrdersNumber";                                                 //订单编号
        private const string PARM_NAME = "@Name";                                                           //收货人姓名
        private const string PARM_PHONE = "@Phone";                                                         //收货人电话
        private const string PARM_MOBILE = "@Mobile";                                                       //收货人手机
        private const string PARM_CODE = "@PostCode";                                                       //收货人邮编
        private const string PARM_PROVICE = "@Provice";                                                     //收货人所在省
        private const string PARM_CITY = "@City";                                                           //收货人所在市
        private const string PARM_DIS = "@District";                                                        //收货人所在区 
        private const string PARM_ZID = "@ZoneId";                                                          //区域编号
        private const string PARM_PID = "@ProviceId";                                                       //省份编号
        private const string PARM_CID = "@CityId";                                                          //市编号
        private const string PARM_DID = "@DistrictId";                                                      //区编号
        private const string PARM_ADDRESS = "@ConsigneeAddress";                                            //收货人地址
        private const string PARM_DATE = "@InputDate";                                                      //录入日期

        public tbConsigneeInfo Select(string OrdersNumber)
        {
            tbConsigneeInfo Consignee = null;
            IDbDataParameter[] parm = GetSelectNumberParam();
            parm[0].Value = OrdersNumber;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parm))
            {
                if (MyReader.Read())
                {
                    Consignee = new tbConsigneeInfo()
                    {
                        ConsigneeId = MyReader.GetInt32(0),
                        OrdersNumber = MyReader.GetString(1),
                        Name = MyReader.GetString(2),
                        Phone = MyReader.GetString(3),
                        Mobile = MyReader.GetString(4),
                        PostCode = MyReader.GetString(5),
                        Provice = MyReader.GetString(6),
                        City = MyReader.GetString(7),
                        District = MyReader.GetString(8),
                        ZoneId = MyReader.GetInt32(9),
                        ProviceId = MyReader.GetInt32(10),
                        CityId = MyReader.GetInt32(11),
                        DistrictId = MyReader.GetInt32(12),
                        ConsigneeAddress = MyReader.GetString(13),
                        InputDate = MyReader.GetDateTime(14)
                    };
                }
            }

            return Consignee == null ? new tbConsigneeInfo() : Consignee;
        }

        public bool Insert(tbConsigneeInfo ConsigneeInfo)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetInsertParam();
            parm[0].Value = ConsigneeInfo.OrdersNumber;
            parm[1].Value = ConsigneeInfo.Name;
            parm[2].Value = ConsigneeInfo.Phone;
            parm[3].Value = ConsigneeInfo.Mobile;
            parm[4].Value = ConsigneeInfo.PostCode;
            parm[5].Value = ConsigneeInfo.Provice;
            parm[6].Value = ConsigneeInfo.City;
            parm[7].Value = ConsigneeInfo.District;
            parm[8].Value = ConsigneeInfo.ZoneId;
            parm[9].Value = ConsigneeInfo.ProviceId;
            parm[10].Value = ConsigneeInfo.CityId;
            parm[11].Value = ConsigneeInfo.DistrictId;
            parm[12].Value = ConsigneeInfo.ConsigneeAddress;
            parm[13].Value = ConsigneeInfo.InputDate;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_INSERT, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        /// <summary>
        /// 批量插入收货人信息表
        /// </summary>
        /// <param name="ListConsigneeInfo"></param>
        /// <returns></returns>
        public bool InsertListConsigneeInfo(List<tbConsigneeInfo> ListConsigneeInfo)
        {
            bool Result = false;
            try
            {
                //新建一张datatable
                DataTable dt = new DataTable("tbConsigneeInfo_temp");
                DataColumn dc = null;

                dc = dt.Columns.Add("OrdersNumber", Type.GetType("System.String"));
                dc = dt.Columns.Add("Name", Type.GetType("System.String"));
                dc = dt.Columns.Add("Phone", Type.GetType("System.String"));
                dc = dt.Columns.Add("Mobile", Type.GetType("System.String"));
                dc = dt.Columns.Add("PostCode", Type.GetType("System.String"));
                dc = dt.Columns.Add("Provice", Type.GetType("System.String"));

                dc = dt.Columns.Add("City", Type.GetType("System.String"));
                dc = dt.Columns.Add("District", Type.GetType("System.String"));
                dc = dt.Columns.Add("ZoneId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("ProviceId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("CityId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("DistrictId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("ConsigneeAddress", Type.GetType("System.String"));
                dc = dt.Columns.Add("InputDate", Type.GetType("System.DateTime"));

                if (ListConsigneeInfo != null)
                {
                    foreach (tbConsigneeInfo ConsigneeInfo in ListConsigneeInfo)
                    {
                        dt.Rows.Add(new object[] {
                        ConsigneeInfo.OrdersNumber,ConsigneeInfo.Name,ConsigneeInfo.Phone,ConsigneeInfo.Mobile,
                        ConsigneeInfo.PostCode,ConsigneeInfo.Provice,ConsigneeInfo.City,ConsigneeInfo.District,
                        ConsigneeInfo.ZoneId,ConsigneeInfo.ProviceId,ConsigneeInfo.CityId,ConsigneeInfo.DistrictId,
                        ConsigneeInfo.ConsigneeAddress,ConsigneeInfo.InputDate
                        });
                    }
                    SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(DBHelper.ConnectionStr);
                    //要插入数据库的名称
                    sqlBulkCopy.DestinationTableName = "tbConsigneeInfo_temp";

                    if (dt != null && dt.Rows.Count != 0)
                    {
                        sqlBulkCopy.WriteToServer(dt);
                    }
                    sqlBulkCopy.Close();
                    string SqlStr = string.Format(@"update [dbo].[tbConsigneeInfo]  ---更新存在相同点数据
                                                   set [Name]=B.Name
                                                      ,[Phone]=B.Phone
                                                      ,[Mobile]=B.Mobile
                                                      ,[PostCode]=B.PostCode
                                                      ,[Provice]=B.Provice
                                                      ,[City]=B.City
                                                      ,[District]=B.District
                                                      ,[ZoneId]=B.ZoneId
                                                      ,[ProviceId]=B.ProviceId
                                                      ,[CityId]=B.CityId
                                                      ,[DistrictId]=B.DistrictId
                                                      ,[ConsigneeAddress]=B.ConsigneeAddress
                                                      ,[InputDate]=B.InputDate
                                                   from [dbo].[tbConsigneeInfo] A,[dbo].[tbConsigneeInfo_temp] B 
                                                   where  B.OrdersNumber=A.OrdersNumber 
                                                   and  B.NowDay >= convert(varchar(10),getdate(),120);                                               
                                                   ---插入不存在相同点数据
                                                   insert into [dbo].[tbConsigneeInfo] 
                                                 (	  [OrdersNumber]
	                                                  ,[Name],[Phone]
                                                      ,[Mobile],[PostCode]
                                                      ,[Provice],[City]
                                                      ,[District],[ZoneId]
                                                      ,[ProviceId],[CityId]
                                                      ,[DistrictId],[ConsigneeAddress]
                                                      ,[InputDate])
                                                 select [OrdersNumber]
	                                                  ,[Name],[Phone]
                                                      ,[Mobile],[PostCode]
                                                      ,[Provice],[City]
                                                      ,[District],[ZoneId]
                                                      ,[ProviceId],[CityId]
                                                      ,[DistrictId],[ConsigneeAddress]
                                                      ,[InputDate]
                                                 from [dbo].[tbConsigneeInfo_temp] A 
                                                 where   not exists(
                                                 select [OrdersNumber]
                                                 from [dbo].[tbConsigneeInfo] B
                                                 where B.OrdersNumber= A.OrdersNumber)
                                                 and  A.NowDay >= convert(varchar(10),getdate(),120);
                                        ");

                    if (DBHelper.ExecuteNonQuery(CommandType.Text, SqlStr) > 0)
                        Result = true;

                }
            }
            catch (Exception EX)
            {
                Result = false;
                throw EX;
            }
            return Result;
        }

        public bool Update(tbConsigneeInfo ConsigneeInfo)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetUpdateParam();
            parm[0].Value = ConsigneeInfo.ConsigneeId;
            parm[1].Value = ConsigneeInfo.OrdersNumber;
            parm[2].Value = ConsigneeInfo.Name;
            parm[3].Value = ConsigneeInfo.Phone;
            parm[4].Value = ConsigneeInfo.Mobile;
            parm[5].Value = ConsigneeInfo.PostCode;
            parm[6].Value = ConsigneeInfo.Provice;
            parm[7].Value = ConsigneeInfo.City;
            parm[8].Value = ConsigneeInfo.District;
            parm[9].Value = ConsigneeInfo.ZoneId;
            parm[10].Value = ConsigneeInfo.ProviceId;
            parm[11].Value = ConsigneeInfo.CityId;
            parm[12].Value = ConsigneeInfo.DistrictId;
            parm[13].Value = ConsigneeInfo.ConsigneeAddress;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UPDATE, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        private static IDbDataParameter[] GetSelectNumberParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50)
                };

                DBHelper.CacheParameters(SQL_SELECT, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetInsertParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_INSERT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_NAME,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_PHONE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_MOBILE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_CODE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_PROVICE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_CITY,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_DIS,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_ZID,SqlDbType.Int,4),
                     new SqlParameter(PARM_PID,SqlDbType.Int,4),
                     new SqlParameter(PARM_CID,SqlDbType.Int,4),
                     new SqlParameter(PARM_DID,SqlDbType.Int,4),
                     new SqlParameter(PARM_ADDRESS,SqlDbType.VarChar,200),
                     new SqlParameter(PARM_DATE,SqlDbType.DateTime)
                };

                DBHelper.CacheParameters(SQL_INSERT, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_ID,SqlDbType.Int,4),
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_NAME,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_PHONE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_MOBILE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_CODE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_PROVICE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_CITY,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_DIS,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_ZID,SqlDbType.Int,4),
                     new SqlParameter(PARM_PID,SqlDbType.Int,4),
                     new SqlParameter(PARM_CID,SqlDbType.Int,4),
                     new SqlParameter(PARM_DID,SqlDbType.Int,4),
                     new SqlParameter(PARM_ADDRESS,SqlDbType.VarChar,200)
                };

                DBHelper.CacheParameters(SQL_UPDATE, parm);
            }

            return parm;
        }
    }
}
