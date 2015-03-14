﻿$(function () {
    var Search = {
    };

    var NowPageIndex = 1;
    var GoodsTotalNum = null;

    function initpage() {
        var URL = "/TradeRate/OnloadRate.html";
        OnloadGoods(URL);
    }

    /*页面初始化加载信息*/
    function OnloadGoods(URL) {
        ChecknowGoodsState();
        istuijian = null;
        $(".table_wrap").empty().load(URL, Search, function () {
        });
    }
    function hoverShow() {

        $(".table_wrap").delegate(".data_table_item", "mouseover", function () {
            $(this).find(".editdiv").each(
            function (i, item) {
                var states = $(item).find(".save").is(":hidden");
                if (states == true || states === undefined) {
                    $(item).find(".edita").css("visibility", "visible");
                } else {

                }
            });
        });
        $(".table_wrap").delegate(".data_table_item", "mouseout", function () {
            $(this).find(".editdiv").each(
                function (i, item) {
                    $(item).find(".edita").css("visibility", "hidden");
                }
            );
        });
    }


    /*初始化分页控件*/
    function Loadpaging() {
        PageConfig.Page = function (index) {
            ChangePageNo(index);
        }
        $(".page_box").unbind("click");
        PageConfig.PageIndex = NowPageIndex;
        $(".page_box").Pager(PageConfig);
        GoodsTotalNum = PageConfig.MaxRowNumber;
    }

    /*页面初始化加载店铺类目*/
    function LoadDPLM() {
        $(".DPLM").select2({ placeholder: "默认查询所有店铺分类商品，最多允许选择32个店铺分类", maximumInputLength: 10 });
        $("#SPLMs").select2();
    }

    /*加载商品总数*/
    function LoadTotalNum() {
        $(".selected").find(".TotalNumOnsales").html("(" + GoodsTotalNum + ")");
        $(".selected").siblings().find(".TotalNumOnsales").html("");
    }

    /*------------------------------------ 页面初始化注册方法-------------------------------------------------*/
    initpage();
    ChangeGoodStatus();
    SelectAllCheckBox();
    OutTimeRate();
    AlertRateframework();
    batchunseller();
    /*  initpage();
    ChangeGoodStatus();
    GoodsSort();
    
    batchunseller();
    batchedit();
    ShowEditTemplate();
    HideEditTemplate();
    hidenBya();
    SetBatchEdit();
    hoverShow();*/
    /*--------------------------------------------------------------------------------------------------------*/
    /*弹出评价框*/
    function AlertRateframework() {
        $("body").delegate("input[name=rateeditor]", "click", function () {
            PopWindow.Controller.Init({ type: "window", opacity: 0, width: 455, height: 230, url: "/TradeRate/SaveRate.html?item=" + encodeURI($(this).attr("data")), title: "交易评价" });
        });
    }


    /*检查当前商品状态*/
    function ChecknowGoodsState() {
        $('.tab .GoodStatus').each(function (i, item) {
            if ($(item).hasClass('selected')) {
                var values = $('input[name=HasShowcase]').eq(0).val();
                Search.HasShowcase = values;
            }
        });
    }
    /*加载新的页码 （例：页码1--页码2 跳转）*/
    function ChangePageNo(index) {
        Search.PageNo = index;
        Search.PageSize = 10;
        var URL = "/Merchandise/SHowGoodsOnsales.html";
        NowPageIndex = index;
        OnloadGoods(URL);
    }

    //更换商品显示状态
    function ChangeGoodStatus() {
        $('.tab .RateStatus').click(function () {
            var type = $(this).attr("data");
            if (!$(this).hasClass('selected')) {
                $(this).siblings().removeClass('selected');
                $(this).addClass('selected');
            }
            var targets = $('input[name=HasShowcase]').eq(0);
            if (0 === parseInt(type)) {
                targets.val("RATE_BUYER_SELLER");
            } else if (1 === parseInt(type)) {
                targets.val("RATE_BUYER_UNSELLER");
            } else {
                targets.val(null)
            }
            $('#QueryCriteria').submit();
        });
    }

    //商品排序
    function GoodsSort() {
        $('.tab_sort a').click(function () {
            var targetss = $('input[name=OrderBy]').eq(0);
            $('.tab_sort a').not(this).removeClass("sort_current");
            var date = $(this).attr("data");
            if ($(this).hasClass('sort_current')) {
                var i = $(this).parent().find('i');
                i.toggleClass("down");
                if (i.hasClass('down')) {
                    targetss.val(date + ":asc");
                } else {
                    targetss.val(date + ":desc");
                }

            } else {
                $(this).addClass('sort_current');
                targetss.val(date + ":desc");
            }
            $('#QueryCriteria').submit();
            Loadpaging();
            LoadTotalNum();
        });
    }
    //针对过期的评价的选择
    function OutTimeRate() {//[type='chexkbox']
        $(document).delegate("input[name=CheckboxGoods]", "click", function () {
            if ($(this).attr("type") === "checkbox") {
                var parent = $(this).parent().parent();
                var result = parent.find("input[name=Ratestate]").val();
                if (result === true || result === "true") {
                    if (parent.hasClass('checked')) {
                        // parent.removeClass("checked");
                    } else {
                        //  parent.addClass("checked");
                    }
                }
                else if (result === false || result === "false") {
                    parent.removeClass("checked");
                }
            }
        });
    }

    //全选和全不选
    function SelectAllCheckBox() {
        $('input[name=chk_all]').change(function () {
            var parent = $(this).parent().parent();
            if (parent.hasClass('checked')) {
                ChangeGoodsId(false);
            } else {
                ChangeGoodsId(true);
            }
           
        });
    }

    //更改商品选择框状态
    function ChangeGoodsId() {
        $('.data_table tbody').find('input[name=CheckboxGoods]').each(function (i, item) {
            checktypecheckbox(item);
        });
    }

    //返回选中的商品的ID（数组）
    function RetunrGoodsId() {
        var checkedList = [];
        $('table input[name=CheckboxGoods]').each(function (i, item) {
            var parent = $(item).parent().parent();
            if (parent.hasClass('checked')) {
                var goodsid = $(item).parent().parent().find("input[name=GoodsId]").eq(0).val();
                checkedList.push(goodsid);
            }
        });
        $('input[name=ListGoodId]').val(checkedList.toLocaleString());
        return checkedList;
    }


    //改变checkbox的选中状态（有效的状态下）
    function checktypecheckbox(obj) {
        if ($(obj).attr("type") === "checkbox") {
            var parent = $(obj).parent().parent();
            var result = parent.find("input[name=Ratestate]").val();
            if (result === true || result === "true") {
                if (parent.hasClass('checked')) {
                    parent.removeClass("checked");
                } else {
                    parent.addClass("checked");
                }
            }
            else if (result === false || result === "false") {
                parent.removeClass("checked");                
            }
        }
    }


    //返回选中的商品外部ID（数组）
    function RetunrGoodsouterId() {
        var checkedList = [];
        $('table input[name=CheckboxGoods]').each(function (i, item) {
            var parent = $(item).parent().parent();
            if (parent.hasClass('checked')) {
                var goodsid = $(parent).parent().parent().find(".outerGoodsID").eq(0).html();
                checkedList.push(goodsid);
            }
        });
        return checkedList;
    }

    //批量评价
    function batchunseller() {
        $('.BatchUnShelve').click(function () {
            RetunrGoodsId();
            var value = $('input[name=ListGoodId]').val();
            if ($.trim(value) != '' && $.trim(value) != null && $.trim(value).length != 0) {
                PopWindow.Controller.Init({ type: "window", opacity: 0, width: 700, height: 394, url: "/TradeRate/RateTemple.html?item=" + encodeURI($(this).attr("data")), title: "模板选择" });
            } else {
                PopWindow.Controller.Init({ type: "prompt", opacity: 0, width: 352, height: 198, title: "请至少选中一项！" });
                return false;
            }
        });
    }

    function batchedit() {
        $('.BatchEdit').click(function () {
            $('.Nomargin').toggle();
            return false;
        })
        $('body').not('.BatchEdit').click(function () {
            $('.Nomargin').hide();
        });
    }
    //  PopWindow.Controller.Init({ type: "window", opacity: 0, width: 720, height: 405, url: "/Merchandise/SetBatchEdit.html", title: "批量修改" });

    //显示编辑模板
    function ShowEditTemplate() {
        $(".table_wrap").delegate(".edita", "click", function () {
            $(this).parent().toggle();
            $(this).parent().siblings().toggle();
        });
    }

    //隐藏编辑模板
    function HideEditTemplate() {
        $(".table_wrap").delegate(".savea", "click", function () {
            var parent = $(this).parent();
            var status = false;
            var html;
            var updatestr = {};
            var goodid = $.trim(parent.parent().parent().parent().find("input[name=GoodsId]").val());
            updatestr.ListGoodsId = goodid;
            var Errmsg = null;
            //开始验证
            if ($(this).attr("title").indexOf("标题") >= 0) {
                html = parent.find('textarea').val();
                if (html.length > 0 && html.length < 30) {
                    status = true;
                    updatestr.Title = html;
                } else {
                    status = false;
                    Errmsg = "标题长度必须大于0个字符或小于30字符";
                }
            } else if ($(this).attr("title").indexOf("金额") >= 0) {
                html = parent.find('textarea').val();
                html = $.trim(html);
                if (parseInt(html) > 0 && parseInt(html) < 100000000 && checkPrice(html)) {
                    status = true;
                    updatestr.Price = html;
                }
                else {
                    status = false;
                    Errmsg = "正数精确到分位，且金额在该商品的价格区间内 ;即（MinPrice≤Price≤Maxprice）";
                }
            } else if ($(this).attr("title").indexOf("库存") >= 0) {
                html = parent.find('textarea').val();
                html = $.trim(html);
                if (parseInt(html) > 0 && parseInt(html) < 900000000 && checkNum(html)) {
                    updatestr.Num = html;
                    status = true;
                } else {
                    status = false;
                    Errmsg = "正整数且库存等于多SKU的库存之和 ;即 库存=SKU1+Sku2+...";
                }
            }
            if (status == true) {
                $(this).parent().toggle();
                $(this).parent().siblings().toggle();
                parent.parent().find('a').eq(0).html(html);
                $.post("/Merchandise/SetupdateGoods.html", updatestr, function (data) {
                    if (!data.ErrorMsg.join(",") != null && data.ErrorMsg.join(",") != "") {
                        PopWindow.Controller.Init({ type: "error", opacity: 0, width: 352, height: 198, title: data.ErrorMsg.join(",") });
                    }
                });
            } else {
                PopWindow.Controller.Init({ type: "prompt", opacity: 0, width: 352, height: 198, title: Errmsg });
                return false;
            }
        });
    }
    function hidenBya() {
        $(".table_wrap").delegate(".saveESC", "click", function () {
            var parent = $(this).parent();
            var editico = parent.find('.editico');
            parent.find('.saveico').hide();
            parent.find('.saveESC').hide();
            editico.show();
            parent.attr("contenteditable", false);
            parent.css("background-color", "");
        });
    }

    //验证金额
    function checkPrice(price) {
        return (/^(([1-9]\d{0,9})|0)(\.\d{1,2})?$/).test(price.toString());
    }

    //验证整数
    function checkNum(number) {
        return (/^\d+$/).test(number);
    }

    //批量修改
    function SetBatchEdit() {
        $(".Nomargin li a").click(function () {
            var str = $(this).attr("data");
            var checkedList = [];
            checkedList = RetunrGoodsId();
            if (str === null) {
                return false;
            } else if (str === "HotDot") {
                PopWindow.Controller.Init({ type: "window", opacity: 0, width: 500, height: 220, url: "/Merchandise/" + str + ".html?item=" + encodeURI(checkedList), title: "批量修改" + $(this).text() });
            } else if (str === "Describe") {
                PopWindow.Controller.Init({ type: "window", opacity: 0, width: 700, height: 350, url: "/Merchandise/" + str + ".html?item=" + encodeURI(checkedList), title: "批量修改" + $(this).text() });
            } else if (checkedList.length != 0) {
                PopWindow.Controller.Init({ type: "window", opacity: 0, width: 405, height: 200, url: "/Merchandise/" + str + ".html?item=" + encodeURI(checkedList), title: "批量修改" + $(this).text() });
            } else {
                PopWindow.Controller.Init({ type: "prompt", opacity: 0, width: 352, height: 198, title: "请至少选中一件商品！" });
            }
        });
    }

});
