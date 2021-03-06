﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using System.Data.SqlClient;
using System.Data;
using MYDZ.DBUtility;

namespace MYDZ.Data.SqlServer.Item
{
    internal class Item : Iitems
    {

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddItems(Entity.Goods.Item model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbItems(");
            strSql.Append("CustomMadeTypeId,DelistTime,DeliveryTimeID,Desc,DescModuleInfoID,DescModules,DetailUrl,EmsFee,ExpressFee,Features,ApproveStatus,FoodSecurityID,FreightPayer,GlobalStockCountry,GlobalStockType,HasDiscount,HasInvoice,HasShowcase,HasWarranty,Increment,InnerShopAuctionTemplateId,AuctionPoint,InputPids,InputStr,Is3D,IsCspu,IsEx,IsFenxiao,IsLightningConsignment,IsOffline,IsPrepay,IsTaobao,AutoFill,IsTiming,IsVirtual,IsXinpin,ItemImgID,ItemSize,ItemWeight,ListTime,LocalityLifeID,LocationID,Modified,Barcode,MpicVideoID,Newprepay,Nick,Num,NumIid,OneStation,OpenIid,OuterId,OuterShopAuctionTemplateId,PaimaiInfoID,ChangeProp,PicUrl,PostFee,PostageId,Price,ProductId,PromotedService,PropImgID,PropertyAlias,Props,PropsName,Cid,Qualification,Score,SecondKill,SecondResult,SellPoint,SellPromise,SellerCids,ShopType,SKUID,SoldQuantity,CodPostageId,StuffStatus,SubStock,SubTitle,TemplateId,Title,Type,ValidThru,Video_ID,Violation,WapDesc,Created,WapDetailUrl,WirelessDesc,WithHoldQuantity,WwStatus,SPJC,SPZL,CBJ,DPID");
            strSql.Append(") values (");
            strSql.Append("@CustomMadeTypeId,@DelistTime,@DeliveryTimeID,@Desc,@DescModuleInfoID,@DescModules,@DetailUrl,@EmsFee,@ExpressFee,@Features,@ApproveStatus,@FoodSecurityID,@FreightPayer,@GlobalStockCountry,@GlobalStockType,@HasDiscount,@HasInvoice,@HasShowcase,@HasWarranty,@Increment,@InnerShopAuctionTemplateId,@AuctionPoint,@InputPids,@InputStr,@Is3D,@IsCspu,@IsEx,@IsFenxiao,@IsLightningConsignment,@IsOffline,@IsPrepay,@IsTaobao,@AutoFill,@IsTiming,@IsVirtual,@IsXinpin,@ItemImgID,@ItemSize,@ItemWeight,@ListTime,@LocalityLifeID,@LocationID,@Modified,@Barcode,@MpicVideoID,@Newprepay,@Nick,@Num,@NumIid,@OneStation,@OpenIid,@OuterId,@OuterShopAuctionTemplateId,@PaimaiInfoID,@ChangeProp,@PicUrl,@PostFee,@PostageId,@Price,@ProductId,@PromotedService,@PropImgID,@PropertyAlias,@Props,@PropsName,@Cid,@Qualification,@Score,@SecondKill,@SecondResult,@SellPoint,@SellPromise,@SellerCids,@ShopType,@SKUID,@SoldQuantity,@CodPostageId,@StuffStatus,@SubStock,@SubTitle,@TemplateId,@Title,@Type,@ValidThru,@Video_ID,@Violation,@WapDesc,@Created,@WapDetailUrl,@WirelessDesc,@WithHoldQuantity,@WwStatus,@SPJC,@SPZL,@CBJ,@DPID");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@AfterSaleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomMadeTypeId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@DelistTime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@DeliveryTimeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Desc", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@DescModuleInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@DescModules", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@DetailUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@EmsFee", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ExpressFee", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Features", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@ApproveStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@FoodSecurityID", SqlDbType.Int,4) ,            
                        new SqlParameter("@FreightPayer", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GlobalStockCountry", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@GlobalStockType", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@HasDiscount", SqlDbType.Bit,1) ,            
                        new SqlParameter("@HasInvoice", SqlDbType.Bit,1) ,            
                        new SqlParameter("@HasShowcase", SqlDbType.Bit,1) ,            
                        new SqlParameter("@HasWarranty", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Increment", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@InnerShopAuctionTemplateId", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuctionPoint", SqlDbType.Int,4) ,            
                        new SqlParameter("@InputPids", SqlDbType.VarChar,2000) ,            
                        new SqlParameter("@InputStr", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Is3D", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsCspu", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsEx", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsFenxiao", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsLightningConsignment", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsOffline", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IsPrepay", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsTaobao", SqlDbType.Bit,1) ,            
                        new SqlParameter("@AutoFill", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@IsTiming", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsVirtual", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsXinpin", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ItemImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ItemSize", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ItemWeight", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ListTime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@LocalityLifeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LocationID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Modified", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Barcode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@MpicVideoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Newprepay", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Nick", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Num", SqlDbType.Int,4) ,            
                        new SqlParameter("@NumIid", SqlDbType.Int,4) ,            
                        new SqlParameter("@OneStation", SqlDbType.Bit,1) ,            
                        new SqlParameter("@OpenIid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OuterId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OuterShopAuctionTemplateId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PaimaiInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ChangeProp", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PostFee", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@PostageId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PromotedService", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PropImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@PropertyAlias", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Props", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@PropsName", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Cid", SqlDbType.Int,4) ,            
                        new SqlParameter("@Qualification", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Score", SqlDbType.Int,4) ,            
                        new SqlParameter("@SecondKill", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@SecondResult", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SellPoint", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@SellPromise", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SellerCids", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ShopType", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@SKUID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SoldQuantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@CodPostageId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StuffStatus", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SubStock", SqlDbType.Int,4) ,            
                        new SqlParameter("@SubTitle", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@TemplateId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,60) ,            
                        new SqlParameter("@Type", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ValidThru", SqlDbType.Int,4) ,            
                        new SqlParameter("@Video_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Violation", SqlDbType.Bit,1) ,            
                        new SqlParameter("@WapDesc", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@WapDetailUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@WirelessDesc", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@WithHoldQuantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@WwStatus", SqlDbType.Bit,1), 
                        new SqlParameter("@SPJC", SqlDbType.VarChar,200) ,
                        new SqlParameter("@SPZL", SqlDbType.VarChar,200) ,    
                        new SqlParameter("@CBJ", SqlDbType.Decimal,13) ,  
                        new SqlParameter("@DPID", SqlDbType.VarChar,50) 
              
            };

            parameters[0].Value = model.AfterSaleId;
            parameters[1].Value = model.CustomMadeTypeId;
            parameters[2].Value = model.DelistTime;
            parameters[3].Value = model.DeliveryTime.DeliveryTimeId;
            parameters[4].Value = model.Desc;
            parameters[5].Value = model.DescModuleInfo.DescModuleInfoID;
            parameters[6].Value = model.DescModules;
            parameters[7].Value = model.DetailUrl;
            parameters[8].Value = model.EmsFee;
            parameters[9].Value = model.ExpressFee;
            parameters[10].Value = model.Features;
            parameters[11].Value = model.ApproveStatus;
            parameters[12].Value = model.FoodSecurity.FoodSecurityID;
            parameters[13].Value = model.FreightPayer;
            parameters[14].Value = model.GlobalStockCountry;
            parameters[15].Value = model.GlobalStockType;
            parameters[16].Value = model.HasDiscount;
            parameters[17].Value = model.HasInvoice;
            parameters[18].Value = model.HasShowcase;
            parameters[19].Value = model.HasWarranty;
            parameters[20].Value = model.Increment;
            parameters[21].Value = model.InnerShopAuctionTemplateId;
            parameters[22].Value = model.AuctionPoint;
            parameters[23].Value = model.InputPids;
            parameters[24].Value = model.InputStr;
            parameters[25].Value = model.Is3D;
            parameters[26].Value = model.IsCspu;
            parameters[27].Value = model.IsEx;
            parameters[28].Value = model.IsFenxiao;
            parameters[29].Value = model.IsLightningConsignment;
            parameters[30].Value = model.IsOffline;
            parameters[31].Value = model.IsPrepay;
            parameters[32].Value = model.IsTaobao;
            parameters[33].Value = model.AutoFill;
            parameters[34].Value = model.IsTiming;
            parameters[35].Value = model.IsVirtual;
            parameters[36].Value = model.IsXinpin;
            parameters[37].Value = model.ItemImgID;
            parameters[38].Value = model.ItemSize;
            parameters[39].Value = model.ItemWeight;
            parameters[40].Value = model.ListTime;
            parameters[41].Value = model.LocalityLife.LocalityLifeID;
            parameters[42].Value = model.Location.LocationId;
            parameters[43].Value = model.Modified;
            parameters[44].Value = model.Barcode;
            parameters[45].Value = model.MpicVideo.MpicVideoID;
            parameters[46].Value = model.Newprepay;
            parameters[47].Value = model.Nick;
            parameters[48].Value = model.Num;
            parameters[49].Value = model.NumIid;
            parameters[50].Value = model.OneStation;
            parameters[51].Value = model.OpenIid;
            parameters[52].Value = model.OuterId;
            parameters[53].Value = model.OuterShopAuctionTemplateId;
            parameters[54].Value = model.PaimaiInfo.PaimaiInfoId;
            parameters[55].Value = model.ChangeProp;
            parameters[56].Value = model.PicUrl;
            parameters[57].Value = model.PostFee;
            parameters[58].Value = model.PostageId;
            parameters[59].Value = model.Price;
            parameters[60].Value = model.ProductId;
            parameters[61].Value = model.PromotedService;
            if (model.PropImgs != null)
            {
                parameters[62].Value = model.PropImgs[0].PropImgId;
            }
            else
            {
                parameters[62].Value = 0;
            }
            parameters[63].Value = model.PropertyAlias;
            parameters[64].Value = model.Props;
            parameters[65].Value = model.PropsName;
            parameters[66].Value = model.Cid;
            parameters[67].Value = model.Qualification;
            parameters[68].Value = model.Score;
            parameters[69].Value = model.SecondKill;
            parameters[70].Value = model.SecondResult;
            parameters[71].Value = model.SellPoint;
            parameters[72].Value = model.SellPromise;
            parameters[73].Value = model.SellerCids;
            parameters[74].Value = model.ShopType;
            if (model.Skus != null)
            {
                parameters[75].Value = model.Skus[0].SkusId;
            }
            else
            {
                parameters[75].Value = 0;
            }
            parameters[76].Value = model.SoldQuantity;
            parameters[77].Value = model.CodPostageId;
            parameters[78].Value = model.StuffStatus;
            parameters[79].Value = model.SubStock;
            parameters[80].Value = model.SubTitle;
            parameters[81].Value = model.TemplateId;
            parameters[82].Value = model.Title;
            parameters[83].Value = model.Type;
            parameters[84].Value = model.ValidThru;
            if (model.Videos != null)
            {
                parameters[85].Value = model.Videos[0].Video_ID;
            }
            else
            {
                parameters[85].Value = 0;
            }
            parameters[86].Value = model.Violation;
            parameters[87].Value = model.WapDesc;
            parameters[88].Value = model.Created;
            parameters[89].Value = model.WapDetailUrl;
            parameters[90].Value = model.WirelessDesc;
            parameters[91].Value = model.WithHoldQuantity;
            parameters[92].Value = model.WwStatus;
            parameters[93].Value = model.SPJC;
            parameters[94].Value = model.SPZL;
            parameters[95].Value = model.CBJ;
            parameters[96].Value = model.DPID;
            int Ares = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (Ares > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateItems(Entity.Goods.Item model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbItems set ");
            strSql.Append(" CustomMadeTypeId = @CustomMadeTypeId , ");
            strSql.Append(" DelistTime = @DelistTime , ");
            strSql.Append(" DeliveryTimeID = @DeliveryTimeID , ");
            strSql.Append(" Desc = @Desc , ");
            strSql.Append(" DescModuleInfoID = @DescModuleInfoID , ");
            strSql.Append(" DescModules = @DescModules , ");
            strSql.Append(" DetailUrl = @DetailUrl , ");
            strSql.Append(" EmsFee = @EmsFee , ");
            strSql.Append(" ExpressFee = @ExpressFee , ");
            strSql.Append(" Features = @Features , ");
            strSql.Append(" ApproveStatus = @ApproveStatus , ");
            strSql.Append(" FoodSecurityID = @FoodSecurityID , ");
            strSql.Append(" FreightPayer = @FreightPayer , ");
            strSql.Append(" GlobalStockCountry = @GlobalStockCountry , ");
            strSql.Append(" GlobalStockType = @GlobalStockType , ");
            strSql.Append(" HasDiscount = @HasDiscount , ");
            strSql.Append(" HasInvoice = @HasInvoice , ");
            strSql.Append(" HasShowcase = @HasShowcase , ");
            strSql.Append(" HasWarranty = @HasWarranty , ");
            strSql.Append(" Increment = @Increment , ");
            strSql.Append(" InnerShopAuctionTemplateId = @InnerShopAuctionTemplateId , ");
            strSql.Append(" AuctionPoint = @AuctionPoint , ");
            strSql.Append(" InputPids = @InputPids , ");
            strSql.Append(" InputStr = @InputStr , ");
            strSql.Append(" Is3D = @Is3D , ");
            strSql.Append(" IsCspu = @IsCspu , ");
            strSql.Append(" IsEx = @IsEx , ");
            strSql.Append(" IsFenxiao = @IsFenxiao , ");
            strSql.Append(" IsLightningConsignment = @IsLightningConsignment , ");
            strSql.Append(" IsOffline = @IsOffline , ");
            strSql.Append(" IsPrepay = @IsPrepay , ");
            strSql.Append(" IsTaobao = @IsTaobao , ");
            strSql.Append(" AutoFill = @AutoFill , ");
            strSql.Append(" IsTiming = @IsTiming , ");
            strSql.Append(" IsVirtual = @IsVirtual , ");
            strSql.Append(" IsXinpin = @IsXinpin , ");
            strSql.Append(" ItemImgID = @ItemImgID , ");
            strSql.Append(" ItemSize = @ItemSize , ");
            strSql.Append(" ItemWeight = @ItemWeight , ");
            strSql.Append(" ListTime = @ListTime , ");
            strSql.Append(" LocalityLifeID = @LocalityLifeID , ");
            strSql.Append(" LocationID = @LocationID , ");
            strSql.Append(" Modified = @Modified , ");
            strSql.Append(" Barcode = @Barcode , ");
            strSql.Append(" MpicVideoID = @MpicVideoID , ");
            strSql.Append(" Newprepay = @Newprepay , ");
            strSql.Append(" Nick = @Nick , ");
            strSql.Append(" Num = @Num , ");
            strSql.Append(" OneStation = @OneStation , ");
            strSql.Append(" OpenIid = @OpenIid , ");
            strSql.Append(" OuterId = @OuterId , ");
            strSql.Append(" OuterShopAuctionTemplateId = @OuterShopAuctionTemplateId , ");
            strSql.Append(" PaimaiInfoID = @PaimaiInfoID , ");
            strSql.Append(" ChangeProp = @ChangeProp , ");
            strSql.Append(" PicUrl = @PicUrl , ");
            strSql.Append(" PostFee = @PostFee , ");
            strSql.Append(" PostageId = @PostageId , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" ProductId = @ProductId , ");
            strSql.Append(" PromotedService = @PromotedService , ");
            strSql.Append(" PropImgID = @PropImgID , ");
            strSql.Append(" PropertyAlias = @PropertyAlias , ");
            strSql.Append(" Props = @Props , ");
            strSql.Append(" PropsName = @PropsName , ");
            strSql.Append(" Cid = @Cid , ");
            strSql.Append(" Qualification = @Qualification , ");
            strSql.Append(" Score = @Score , ");
            strSql.Append(" SecondKill = @SecondKill , ");
            strSql.Append(" SecondResult = @SecondResult , ");
            strSql.Append(" SellPoint = @SellPoint , ");
            strSql.Append(" SellPromise = @SellPromise , ");
            strSql.Append(" SellerCids = @SellerCids , ");
            strSql.Append(" ShopType = @ShopType , ");
            strSql.Append(" SKUID = @SKUID , ");
            strSql.Append(" SoldQuantity = @SoldQuantity , ");
            strSql.Append(" CodPostageId = @CodPostageId , ");
            strSql.Append(" StuffStatus = @StuffStatus , ");
            strSql.Append(" SubStock = @SubStock , ");
            strSql.Append(" SubTitle = @SubTitle , ");
            strSql.Append(" TemplateId = @TemplateId , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" Type = @Type , ");
            strSql.Append(" ValidThru = @ValidThru , ");
            strSql.Append(" Video_ID = @Video_ID , ");
            strSql.Append(" Violation = @Violation , ");
            strSql.Append(" WapDesc = @WapDesc , ");
            strSql.Append(" Created = @Created , ");
            strSql.Append(" WapDetailUrl = @WapDetailUrl , ");
            strSql.Append(" WirelessDesc = @WirelessDesc , ");
            strSql.Append(" WithHoldQuantity = @WithHoldQuantity , ");
            strSql.Append(" WwStatus = @WwStatus , ");
            strSql.Append(" SPJC = @SPJC , ");
            strSql.Append(" CBJ= @CBJ , ");
            strSql.Append(" SPZL = @SPZL  ");
            strSql.Append(" where NumIid = @NumIid and DPID = @DPID");

            SqlParameter[] parameters = {
			            new SqlParameter("@CustomMadeTypeId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@DelistTime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@DeliveryTimeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Desc", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@DescModuleInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@DescModules", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@DetailUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@EmsFee", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ExpressFee", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Features", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@ApproveStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@FoodSecurityID", SqlDbType.Int,4) ,            
                        new SqlParameter("@FreightPayer", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GlobalStockCountry", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@GlobalStockType", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@HasDiscount", SqlDbType.Bit,1) ,            
                        new SqlParameter("@HasInvoice", SqlDbType.Bit,1) ,            
                        new SqlParameter("@HasShowcase", SqlDbType.Bit,1) ,            
                        new SqlParameter("@HasWarranty", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Increment", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@InnerShopAuctionTemplateId", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuctionPoint", SqlDbType.Int,4) ,            
                        new SqlParameter("@InputPids", SqlDbType.VarChar,2000) ,            
                        new SqlParameter("@InputStr", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Is3D", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsCspu", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsEx", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsFenxiao", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsLightningConsignment", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsOffline", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IsPrepay", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsTaobao", SqlDbType.Bit,1) ,            
                        new SqlParameter("@AutoFill", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@IsTiming", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsVirtual", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsXinpin", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ItemImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ItemSize", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ItemWeight", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ListTime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@LocalityLifeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LocationID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Modified", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Barcode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@MpicVideoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Newprepay", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Nick", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Num", SqlDbType.Int,4) ,               
                        new SqlParameter("@OneStation", SqlDbType.Bit,1) ,            
                        new SqlParameter("@OpenIid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OuterId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OuterShopAuctionTemplateId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PaimaiInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ChangeProp", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PostFee", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@PostageId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PromotedService", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PropImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@PropertyAlias", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Props", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@PropsName", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Cid", SqlDbType.Int,4) ,            
                        new SqlParameter("@Qualification", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Score", SqlDbType.Int,4) ,            
                        new SqlParameter("@SecondKill", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@SecondResult", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SellPoint", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@SellPromise", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SellerCids", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ShopType", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@SKUID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SoldQuantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@CodPostageId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StuffStatus", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SubStock", SqlDbType.Int,4) ,            
                        new SqlParameter("@SubTitle", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@TemplateId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,60) ,            
                        new SqlParameter("@Type", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ValidThru", SqlDbType.Int,4) ,            
                        new SqlParameter("@Video_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Violation", SqlDbType.Bit,1) ,            
                        new SqlParameter("@WapDesc", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@WapDetailUrl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@WirelessDesc", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@WithHoldQuantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@WwStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SPJC", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SPZL", SqlDbType.VarChar,100),
                        new SqlParameter("@DPID", SqlDbType.VarChar,50),
                        new SqlParameter("@CBJ", SqlDbType.Decimal,13)
              
            };

            parameters[0].Value = model.AfterSaleId;
            parameters[1].Value = model.CustomMadeTypeId;
            parameters[2].Value = model.DelistTime;
            parameters[3].Value = model.DeliveryTime.DeliveryTimeId;
            parameters[4].Value = model.Desc;
            parameters[5].Value = model.DescModuleInfo.DescModuleInfoID;
            parameters[6].Value = model.DescModules;
            parameters[7].Value = model.DetailUrl;
            parameters[8].Value = model.EmsFee;
            parameters[9].Value = model.ExpressFee;
            parameters[10].Value = model.Features;
            parameters[11].Value = model.ApproveStatus;
            parameters[12].Value = model.FoodSecurity.FoodSecurityID;
            parameters[13].Value = model.FreightPayer;
            parameters[14].Value = model.GlobalStockCountry;
            parameters[15].Value = model.GlobalStockType;
            parameters[16].Value = model.HasDiscount;
            parameters[17].Value = model.HasInvoice;
            parameters[18].Value = model.HasShowcase;
            parameters[19].Value = model.HasWarranty;
            parameters[20].Value = model.Increment;
            parameters[21].Value = model.InnerShopAuctionTemplateId;
            parameters[22].Value = model.AuctionPoint;
            parameters[23].Value = model.InputPids;
            parameters[24].Value = model.InputStr;
            parameters[25].Value = model.Is3D;
            parameters[26].Value = model.IsCspu;
            parameters[27].Value = model.IsEx;
            parameters[28].Value = model.IsFenxiao;
            parameters[29].Value = model.IsLightningConsignment;
            parameters[30].Value = model.IsOffline;
            parameters[31].Value = model.IsPrepay;
            parameters[32].Value = model.IsTaobao;
            parameters[33].Value = model.AutoFill;
            parameters[34].Value = model.IsTiming;
            parameters[35].Value = model.IsVirtual;
            parameters[36].Value = model.IsXinpin;
            parameters[37].Value = model.ItemImgID;
            parameters[38].Value = model.ItemSize;
            parameters[39].Value = model.ItemWeight;
            parameters[40].Value = model.ListTime;
            parameters[41].Value = model.LocalityLife.LocalityLifeID;
            parameters[42].Value = model.Location.LocationId;
            parameters[43].Value = model.Modified;
            parameters[44].Value = model.Barcode;
            parameters[45].Value = model.MpicVideo.MpicVideoID;
            parameters[46].Value = model.Newprepay;
            parameters[47].Value = model.Nick;
            parameters[48].Value = model.Num;
            parameters[49].Value = model.OneStation;
            parameters[50].Value = model.OpenIid;
            parameters[51].Value = model.OuterId;
            parameters[52].Value = model.OuterShopAuctionTemplateId;
            parameters[53].Value = model.PaimaiInfo.PaimaiInfoId;
            parameters[54].Value = model.ChangeProp;
            parameters[55].Value = model.PicUrl;
            parameters[56].Value = model.PostFee;
            parameters[57].Value = model.PostageId;
            parameters[58].Value = model.Price;
            parameters[59].Value = model.ProductId;
            parameters[60].Value = model.PromotedService;
            if (model.PropImgs != null)
            {
                parameters[61].Value = model.PropImgs[0].PropImgId;
            }
            else
            {
                parameters[61].Value = 0;
            }
            parameters[62].Value = model.PropertyAlias;
            parameters[63].Value = model.Props;
            parameters[64].Value = model.PropsName;
            parameters[65].Value = model.Cid;
            parameters[66].Value = model.Qualification;
            parameters[67].Value = model.Score;
            parameters[68].Value = model.SecondKill;
            parameters[69].Value = model.SecondResult;
            parameters[70].Value = model.SellPoint;
            parameters[71].Value = model.SellPromise;
            parameters[72].Value = model.SellerCids;
            parameters[73].Value = model.ShopType;
            if (model.Skus != null)
            {
                parameters[74].Value = model.Skus[0].SkusId;
            }
            else
            {
                parameters[74].Value = 0;
            }
            parameters[75].Value = model.SoldQuantity;
            parameters[76].Value = model.CodPostageId;
            parameters[77].Value = model.StuffStatus;
            parameters[78].Value = model.SubStock;
            parameters[79].Value = model.SubTitle;
            parameters[80].Value = model.TemplateId;
            parameters[81].Value = model.Title;
            parameters[82].Value = model.Type;
            parameters[83].Value = model.ValidThru;
            if (model.Videos != null)
            {
                parameters[84].Value = model.Videos[0].Video_ID;
            }
            else
            {
                parameters[84].Value = 0;
            }
            parameters[85].Value = model.Violation;
            parameters[86].Value = model.WapDesc;
            parameters[87].Value = model.Created;
            parameters[88].Value = model.WapDetailUrl;
            parameters[89].Value = model.WirelessDesc;
            parameters[90].Value = model.WithHoldQuantity;
            parameters[91].Value = model.WwStatus;
            parameters[92].Value = model.SPJC;
            parameters[93].Value = model.SPZL;
            parameters[94].Value = model.DPID;
            parameters[95].Value = model.CBJ;
            int Ares = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (Ares > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="NumId"></param>
        public void DeleteItems(string NumId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbItems ");
            strSql.Append(" where ");
            strSql.Append("NumIid=@NumIid");
            SqlParameter[] parameters = { 
             new SqlParameter("@NumIid", SqlDbType.Int,4)                         
             };
            parameters[0].Value = NumId;
            DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 取得一行数据
        /// </summary>
        /// <param name="NumId"></param>
        /// <returns></returns>
        public IList<Entity.Goods.Item> GetItems(string NumId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CustomMadeTypeId, DelistTime, DeliveryTimeID, Desc, DescModuleInfoID, DescModules, DetailUrl, EmsFee, ExpressFee, Features, ApproveStatus, FoodSecurityID, FreightPayer, GlobalStockCountry, GlobalStockType, HasDiscount, HasInvoice, HasShowcase, HasWarranty, Increment, InnerShopAuctionTemplateId, AuctionPoint, InputPids, InputStr, Is3D, IsCspu, IsEx, IsFenxiao, IsLightningConsignment, IsOffline, IsPrepay, IsTaobao, AutoFill, IsTiming, IsVirtual, IsXinpin, ItemImgID, ItemSize, ItemWeight, ListTime, LocalityLifeID, LocationID, Modified, Barcode, MpicVideoID, Newprepay, Nick, Num, NumIid, OneStation, OpenIid, OuterId, OuterShopAuctionTemplateId, PaimaiInfoID, ChangeProp, PicUrl, PostFee, PostageId, Price, ProductId, PromotedService, PropImgID, PropertyAlias, Props, PropsName, Cid, Qualification, Score, SecondKill, SecondResult, SellPoint, SellPromise, SellerCids, ShopType, SKUID, SoldQuantity, CodPostageId, StuffStatus, SubStock, SubTitle, TemplateId, Title, Type, ValidThru, Video_ID, Violation, WapDesc, Created, WapDetailUrl, WirelessDesc, WithHoldQuantity, WwStatus, SPJC, SPZL,DPID,CBJ");
            strSql.Append("  from tbItems ");
            strSql.Append(" where NumIid=@NumIid and DPID=@DPID");
            SqlParameter[] parameters = { 
             new SqlParameter("@NumIid", SqlDbType.Int,4),   
             new SqlParameter("@DPID", SqlDbType.VarChar,50)                         
             };
            parameters[0].Value = NumId;
            return DBHelper.ExecuteIList<Entity.Goods.Item>(CommandType.Text, strSql.ToString(), parameters);

        }
    }
}