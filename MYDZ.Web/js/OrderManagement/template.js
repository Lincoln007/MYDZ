﻿(function ($) {
    jQuery.fn.imageMaps = function (options) {
        options = $.extend({
            Data: [],
            Size: { width: 0, height: 0 }
        }, options);

        var CurrentObj = null;
        var GlobalObj = null;
        var ItemList = [];

        var PId = $("input[name=PId]").val();
        var TId = $("input[name=TId]").val();
        var UId = $("input[name=UId]").val();
        var LImg = $("input[name=LImg]").val();
        var LId = $("input[name=LId]").val();
        var FilePath = "/UploadFile/Print/" + UId;
        var Single = 'true';


        var container = this;
        if (container.length == 0) return false;

        var images = container.find('img[ref=imageMaps]');
        options.Size.width = images.width();
        options.Size.height = images.height();

        images.wrap('<div class="image-maps-conrainer" style="position:relative;"></div>');
        var img_conrainer = images.parent();

        img_conrainer.append($.browser.msie ? $("<div class='position-conrainer' style='position:absolute'></div>").css({
            background: '#fff',
            opacity: 0
        }) : '<div class="position-conrainer" style="position:absolute"></div>');

        var img_offset = $(this).offset();
        var img_conrainer_offset = img_conrainer.offset();
        var position_conrainer = img_conrainer.find('.position-conrainer');

        position_conrainer.css({
            top: img_offset.top - img_conrainer_offset.top,
            left: img_offset.left - img_conrainer_offset.left,
            width: $(this).width(),
            height: $(this).height()
        });

        //创建图像标尺
        function CreatePageRuler() {
            var rh = $("<div></div>").addClass("PageRuler_H");
            var rv = $("<div></div>").addClass("PageRuler_V");
            container.append(rh).append(rv);

            var w = options.Size.width;
            var h = options.Size.height;

            rh.css({ width: w });
            rv.css({ height: h });

            //创建标尺数值
            for (var i = 0; i < w; i += 1) {
                if (i % 50 === 0) {
                    $('<span class="n">' + i + '</span>').css("left", i + 2).appendTo(rh);
                }
            }
            //垂直标尺数值
            for (var i = 0; i < h; i += 1) {
                if (i % 50 === 0) {
                    $('<span class="n">' + i + '</span>').css("top", i + 2).appendTo(rv);
                }
            }
        }

        //创建网格线
        function CreateGrid() {
            var rh = $("<div></div>").addClass("PagGrid_H");
            var rv = $("<div></div>").addClass("PagGrid_V");
            container.append(rh).append(rv);

            var w = options.Size.width;
            var h = options.Size.height;

            rh.add(rv).css({ width: w, height: h });

            //水平网格
            for (var i = 0; i < parseInt(h / 8); i++) {
                $('<span></span>').css("top", i * 8).appendTo(rh);
            }

            //垂直网格
            for (var i = 0; i < parseInt(w / 8); i++) {
                $('<span></span>').css("left", i * 8).appendTo(rv);
            }

            rh.find("span").css({ width: w });
            rv.find("span").css({ height: h });
        }

        //显示/隐藏图片标尺
        function ChangeRuler() {
            var rh = $("div.PageRuler_H");
            var rv = $("div.PageRuler_V");

            if (rh.is(":hidden")) {
                rh.add(rv).show();
            } else {
                rh.add(rv).hide();
            }
        }

        //显示/隐藏网格线
        function ChangeGrid() {
            var rh = $("div.PagGrid_H");
            var rv = $("div.PagGrid_V");

            if (rh.is(":hidden")) {
                rh.add(rv).show();
            } else {
                rh.add(rv).hide();
            }
        }

        //CreatePageRuler();
        //ChangeRuler();
        //CreateGrid();
        //ChangeGrid();

        var img_conrainer = images.parent();

        function InitData() {
            $.post("/OrderManagement/PrintContent.html", {}, function (data) {
                ItemList = data.List;
                var InnerHtml = [];
                InnerHtml.push('<div class="toolbar">');
                InnerHtml.push('    <ul class="toolbar_hd">');
                InnerHtml.push('        <li><h2>打印内容设置</h2></li>');
                InnerHtml.push('        <li class="tool_wrap_ico"><a href="javascript:void();" hidefocus="true" class="tool_ico_stretch" title="收缩/展开"></a></li>');
                InnerHtml.push('    </ul>');
                InnerHtml.push('    <ul class="toolbar_bd" style="height:' + parseInt(options.Size.height - 40) + 'px;">');

                for (var i = 0; i < data.List.length; i++) {
                    InnerHtml.push('<li><a href="javascript:void();" hidefocus="true" data-ids="' + data.List[i].Id + '" data-name="' + data.List[i].Name + '" ' + (data.List[i].Id == 49 ? "style='width:110px;padding:0px;text-align:center;'" : "") + '>' + data.List[i].Name + '</a></li>');
                }

                InnerHtml.push('    </ul>');
                InnerHtml.push('</div>');

                container.append(InnerHtml.join(''));

                var nicesx = $("ul.toolbar_bd").niceScroll({ touchbehavior: false, cursorcolor: "#424242", cursoropacitymax: 0.6, cursorwidth: 4 });
                $("div.nicescroll-rails").css("z-index", "199");
            }).done(
                function () {
                    $("ul.toolbar_bd a").click(function () { CreateRect(this); });
                }
            );
        }

        InitData();

        function InitList() {
            var Id = parseInt(PId) > 0 ? parseInt(PId) : parseInt(TId);
            if (Id > 0) {
                $.post("/OrderManagement/PrintDetail.html", { Id: Id },
                    function (data) {
                        for (var i = 0; i < data.List.length; i++) {
                            CreateRect(null, data.List[i]);
                        }
                    }
                );
            }
        }

        InitList();

        //创建矩形区域
        function CreateRect(obj, data) {
            var name, ids; var left = 10, top = 10, width = 90, height = 30; fid = 1; font = 12; bold = false; item = ""; param = 1; align = 1;
            if (obj != null) {
                name = $(obj).attr("data-name"); ids = $(obj).attr("data-ids");
            } else {
                name = data.Title; ids = data.Id; left = data.Left; top = data.Top; width = data.Width; height = data.Height; fid = data.Font; font = data.FontSize; bold = data.Bold; item = data.Sub; param = data.Num; align = data.Align;
            }

            if (parseInt(ids) == 44) {
                if (obj != null) {
                    fid = 160;
                    font = 160;
                    position_conrainer.append('<div class="map-position" style="left:' + left + 'px;top:' + top + 'px;width:' + width + 'px;height:' + height + 'px;"><div class="map-position-bg"></div><span class="link-number-text" style="text-align:' + (align == 1 ? "left" : align == 2 ? "center" : align == 3 ? "right" : "left") + ';">' + name + '</span><span class="edit" title="设置" data-id="' + ids + '" data-fid="' + fid + '" data-font="' + font + '" data-bold="' + bold + '" data-item="' + item + '" data-param="' + param + '" data-align="' + align + '">+</span><span class="delete" title="删除">X</span><span class="resize"></span></div>');
                } else {
                    position_conrainer.append('<div class="map-position" style="left:' + left + 'px;top:' + top + 'px;width:' + width + 'px;height:' + height + 'px;"><div class="map-position-bg"></div><span class="link-number-text" style="text-align:' + (align == 1 ? "left" : align == 2 ? "center" : align == 3 ? "right" : "left") + ';"><img src="' + item + '" style="width:' + fid + 'px;height:' + font + 'px;" /></span><span class="edit" title="设置" data-id="' + ids + '" data-fid="' + fid + '" data-font="' + font + '" data-bold="' + bold + '" data-item="' + item + '" data-param="' + param + '" data-align="' + align + '">+</span><span class="delete" title="删除">X</span><span class="resize"></span></div>');
                }
            } else {
                var family = $("select[name=font] option[value=" + fid + "]").text();
                position_conrainer.append('<div class="map-position" style="left:' + left + 'px;top:' + top + 'px;width:' + width + 'px;height:' + height + 'px;"><div class="map-position-bg"></div><span class="link-number-text" style="font-family:\'' + family + '\';font-size:' + font + 'px;font-weight:' + (eval(bold) ? "700" : "normal") + ';text-align:' + (align == 1 ? "left" : align == 2 ? "center" : align == 3 ? "right" : "left") + ';">' + name + '</span><span class="edit" title="设置" data-id="' + ids + '" data-fid="' + fid + '" data-font="' + font + '" data-bold="' + bold + '" data-item="' + item + '" data-param="' + param + '" data-align="' + align + '">+</span><span class="delete" title="删除">X</span><span class="resize"></span></div>');
            }

            bind_map_event();
            define_css();
        }

        //绑定map事件
        function bind_map_event() {
            $('.position-conrainer .map-position').each(
                function () {
                    $(this).unbind('click').click(function (event) {
                        $('.position-conrainer .map-position').css("border", "1px solid #5489BB").find(".map-position-bg").css("background", "#02FFFE");
                        $(this).css("border", "1px solid #F1E38B").find(".map-position-bg").css("background", "#FFFAE3");
                        CurrentObj = this;
                        return false;
                    }).unbind('mouseover').mouseover(
                        function () {
                            $(this).find(".edit,.delete").css("display", "block");
                        }
                    ).unbind('mouseout').mouseout(
                        function () {
                            $(this).find(".edit,.delete").css("display", "none");
                        }
                    );
                }
            );



            $(document).unbind('mousedown').mousedown(function (event) {
                if (3 == event.which) {
                    $('.position-conrainer .map-position .resize').each(
                        function () {
                            $(this).data('mousedown', false);
                        }
                    );
                }
            });

            $('.position-conrainer .map-position .map-position-bg').each(function () {
                var map_position_bg = $(this);
                var conrainer = $(this).parent().parent();
                map_position_bg.unbind('mousedown').mousedown(function (event) {
                    if (3 == event.which) {
                        $(this).parent().find(".resize").data('mousedown', false);
                    }
                    map_position_bg.data('mousedown', true);
                    map_position_bg.data('pageX', event.pageX);
                    map_position_bg.data('pageY', event.pageY);
                    map_position_bg.css('cursor', 'move');
                    return false;
                }).unbind('mouseup').mouseup(function (event) {
                    map_position_bg.data('mousedown', false);
                    map_position_bg.css('cursor', 'default');
                    return false;
                });
                conrainer.mousemove(function (event) {
                    if (!map_position_bg.data('mousedown')) return false;
                    var dx = event.pageX - map_position_bg.data('pageX');
                    var dy = event.pageY - map_position_bg.data('pageY');
                    if ((dx == 0) && (dy == 0)) {
                        return false;
                    }

                    var index = $('.position-conrainer .map-position .map-position-bg').index(map_position_bg);
                    var map_position = map_position_bg.parent();
                    var p = map_position.position();
                    var left = p.left + dx;
                    if (left < 0) left = 0;
                    var top = p.top + dy;
                    if (top < 0) top = 0;
                    var bottom = top + map_position.height();
                    if (bottom > conrainer.height()) {
                        top = top - (bottom - conrainer.height());
                    }
                    var right = left + map_position.width();
                    if (right > conrainer.width()) {
                        left = left - (right - conrainer.width());
                    }
                    map_position.css({
                        left: left,
                        top: top
                    });
                    map_position_bg.data('pageX', event.pageX);
                    map_position_bg.data('pageY', event.pageY);

                    bottom = top + map_position.height();
                    right = left + map_position.width();

                    return false;
                }).mouseup(function (event) {
                    map_position_bg.data('mousedown', false);
                    map_position_bg.css('cursor', 'default');
                    return false;
                });
            });

            $('.position-conrainer .map-position .resize').each(function () {
                var map_position_resize = $(this);
                var conrainer = $(this).parent().parent();
                map_position_resize.unbind('mousedown').mousedown(function (event) {
                    map_position_resize.data('mousedown', true);
                    map_position_resize.data('pageX', event.pageX);
                    map_position_resize.data('pageY', event.pageY);
                    return false;
                }).unbind('mouseup').mouseup(function (event) {
                    map_position_resize.data('mousedown', false);
                    return false;
                });
                conrainer.mousemove(function (event) {
                    if (!map_position_resize.data('mousedown')) return false;
                    var dx = event.pageX - map_position_resize.data('pageX');
                    var dy = event.pageY - map_position_resize.data('pageY');
                    if ((dx == 0) && (dy == 0)) {
                        return false;
                    }

                    var index = $('.position-conrainer .map-position .resize').index(map_position_resize);
                    var map_position = map_position_resize.parent();
                    var p = map_position.position();
                    var left = p.left;
                    var top = p.top;
                    var height = map_position.height() + dy;
                    if ((top + height) > conrainer.height()) {
                        height = height - ((top + height) - conrainer.height());
                    }
                    if (height < 14) height = 14;
                    var width = map_position.width() + dx;
                    if ((left + width) > conrainer.width()) {
                        width = width - ((left + width) - conrainer.width());
                    }
                    if (width < 30) width = 30;
                    map_position.css({
                        width: width,
                        height: height
                    });
                    map_position_resize.data('pageX', event.pageX);
                    map_position_resize.data('pageY', event.pageY);

                    bottom = top + map_position.height();
                    right = left + map_position.width();

                    return false;
                }).mouseup(function (event) {
                    map_position_resize.data('mousedown', false);
                    return false;
                });
            });

            $('.position-conrainer .map-position .delete').unbind('click').click(function () {
                var _position_conrainer = $(this).parents(".position-conrainer:eq(0)");
                $(this).parents(".map-position:eq(0)").remove();
            });

            $('.position-conrainer .map-position .edit').unbind('click').click(function () {
                GlobalObj = this;
                MyMaskLayer.Control.Show({ "Opacity": 40 });
                var diaglog = $(".dialogContainer");
                var width = $(window).width();
                var height = $(window).height();
                var top = $(document).scrollTop();

                var id = parseInt($(this).attr("data-id"));
                diaglog.find("tr").show();
                var tr_items = diaglog.find("tr.tr_name,tr.tr_item,tr.tr_param,tr.tr_width,tr.tr_height,tr.tr_url").hide();
                var txt = $(this).prev().text().Trim();
                var test = $.grep(ItemList, function (n, j) {
                    return n.Id == id;
                });

                if (test.length > 0) {
                    var tmpList = $(this).attr("data-item").split(',');
                    var num = $(this).attr("data-param");
                    $.ajax({
                        type: "post", url: "/OrderManagement/PrintContent.html", cache: false, async: false, dataType: "json", data: { ParentId: id },
                        success: function (data) {
                            if (data.List.length > 0) {
                                var html = [];
                                for (var i = 0; i < data.List.length; i++) {
                                    var tst = $.grep(tmpList, function (n, j) {
                                        return n == data.List[i].Id;
                                    });
                                    var ischk = tst.length > 0;
                                    html.push('<label style="padding:5px 5px 5px 0px;" class="checkbox ' + (ischk ? "checked" : "") + '"><span><input value="' + data.List[i].Id + '" type="checkbox"' + (ischk ? "checked" : "") + ' hidefocus="true"></span><em>' + data.List[i].Name + '</em></label>');
                                }
                                if (id == 8) {
                                    tr_items.eq(2).show().find("input").val(num);
                                }
                                tr_items.eq(1).show().find("td:last").empty().append(html.join(''));
                            }
                        }
                    });
                }

                if (id == 19) {
                    tr_items.eq(0).show();
                }

                tr_items.eq(0).find("input").val(txt);

                if (id == 44) {
                    diaglog.find("tr").hide();
                    tr_items.eq(0).find("input").val("图片");
                    tr_items.eq(3).add(tr_items.eq(4)).add(tr_items.eq(5)).show();
                    diaglog.find("input[name=img_w]").val($(this).attr("data-fid"));
                    diaglog.find("input[name=img_h]").val($(this).attr("data-font"));
                    diaglog.find("input[name=img_url]").val($(this).attr("data-item"));
                    diaglog.find("input[name=fontSize]").val("12");
                } else {
                    diaglog.find("input[name=fontSize]").val($(this).attr("data-font"));
                    var bold = eval($(this).attr("data-bold"));
                    var boldtxt = diaglog.find("input[name=bold]");
                    if (boldtxt[0].checked != bold) {
                        boldtxt[0].checked = bold;
                        boldtxt.parents("label.checkbox").toggleClass("checked");
                    }
                    diaglog.find("select[name=font]").select2("val", $(this).attr("data-fid"));
                    diaglog.find("select[name=align]").select2("val", $(this).attr("data-align"));
                }

                diaglog.attr("data-index", $(".position-conrainer span.edit").index(this)).css(
                {
                    left: (width - diaglog.width()) / 2, top: (height - diaglog.height()) / 2 + top
                }).fadeIn();
            });
        }

        $(document).click(
            function () {
                $('.position-conrainer .map-position').css("border", "1px solid #5489BB").find(".map-position-bg").css("background", "#02FFFE");
                CurrentObj = null;
            }
        ).keydown(
            function (event) {
                if (CurrentObj == null) { return; }
                event = event || window.event;
                var key = event.which || event.KeyCode;

                var l = $(CurrentObj).position();
                switch (key) {
                    case 37:
                        $(CurrentObj).css("left", l.left - 1);
                        break;
                    case 38:
                        $(CurrentObj).css("top", l.top - 1);
                        break;
                    case 39:
                        $(CurrentObj).css("left", l.left + 1);
                        break;
                    case 40:
                        $(CurrentObj).css("top", l.top + 1);
                        break;
                }
                event.stopPropagation();
                return false;
            }
        );

        //样式定义
        function define_css() {
            container.find('.map-position').css({
                position: 'absolute',
                border: '1px solid #5489bb',
                'font-weight': 'bold',
                'z-index': 30,
                'overflow': "hidden"
            });

            container.find('.map-position .map-position-bg').css({
                position: 'absolute',
                background: '#02fffe',
                opacity: 0.5,
                top: 0,
                left: 0,
                right: 0,
                bottom: 0,
                'z-index': 20
            });

            container.find('.map-position .resize').css({
                display: 'block',
                position: 'absolute',
                right: 0,
                bottom: 0,
                width: 5,
                height: 5,
                cursor: 'nw-resize',
                background: '#000',
                "z-index": 21
            });

            container.find('.map-position .edit').css({
                display: 'none',
                position: 'absolute',
                right: 14,
                top: 0,
                width: 9,
                height: 14,
                background: '#000',
                color: '#fff',
                'font-family': 'Arial',
                cursor: 'pointer',
                'line-height': '14px',
                'font-size': 12,
                'font-weight': 'bold',
                'padding-left': '3px',
                opactiey: 1,
                "z-index": 21
            });

            container.find('.map-position .delete').css({
                display: 'none',
                position: 'absolute',
                right: 0,
                top: 0,
                width: 10,
                height: 14,
                'line-height': '14px',
                'font-size': 12,
                'font-weight': 'bold',
                background: '#000',
                color: '#fff',
                'font-family': 'Arial',
                'padding-left': '3px',
                cursor: 'pointer',
                opactiey: 1,
                "z-index": 21
            });
        }

        $(".dialogContainer a.dialogContainer-close,.dialogContainer a.cancel").click(function () { SaveConfig(); });
        $(".dialogContainer a.save").click(function () { SaveConfig(true); });

        function SaveConfig(state) {
            var diaglog = $(".dialogContainer");
            if (state) {
                var tr_items = diaglog.find("tr.tr_item,tr.tr_param");
                var isok = !tr_items.eq(0).is(":hidden");
                var fontSize = diaglog.find("input[name=fontSize]");
                var font = diaglog.find("select[name=font]");
                var align = diaglog.find("select[name=align]");
                var bold = diaglog.find("input[name=bold]")[0].checked;
                var custom = diaglog.find("tr.tr_name input");

                if (fontSize.val().IsEmpty()) {
                    fontSize.focus();
                    return;
                } else {
                    if (!fontSize.val().Trim().CheckInteger()) {
                        fontSize.val("").focus();
                        return;
                    }
                }

                if (custom.val().IsEmpty()) {
                    custom.focus();
                    return;
                }

                if (isok) {
                    var num = tr_items.eq(1).find("input");
                    if (!tr_items.eq(1).is(":hidden")) {
                        if (num.val().IsEmpty()) {
                            num.focus();
                            return;
                        } else {
                            if (!num.val().Trim().CheckInteger()) {
                                num.val("").focus();
                                return;
                            }
                        }
                    } else {
                        num.val("1");
                    }

                    $(GlobalObj).attr("data-param", num.val().Trim());
                    var IdList = []
                    tr_items.eq(0).find("input[type=checkbox]").each(
                        function () {
                            if (this.checked) {
                                IdList.push(this.value.Trim());
                            }
                        }
                    );

                    $(GlobalObj).attr("data-item", IdList.join(','));
                }

                var id = parseInt($(GlobalObj).attr("data-id"));
                if (id == 19) {
                    $(GlobalObj).prev().text(custom.val().Trim());
                }

                if (id == 44) {
                    var tr_imgs = diaglog.find("tr.tr_width,tr.tr_height,tr.tr_url");
                    var img_width = diaglog.find("input[name=img_w]");
                    var img_height = diaglog.find("input[name=img_h]");
                    var img_url = diaglog.find("input[name=img_url]");

                    if (img_width.val().IsEmpty()) {
                        img_width.focus();
                        return;
                    } else {
                        if (!img_width.val().Trim().CheckInteger()) {
                            img_width.val("").focus();
                            return;
                        }
                    }

                    if (img_height.val().IsEmpty()) {
                        img_height.focus();
                        return;
                    } else {
                        if (!img_height.val().Trim().CheckInteger()) {
                            img_height.val("").focus();
                            return;
                        }
                    }

                    if (img_url.val().IsEmpty()) {
                        img_url.focus();
                        return;
                    }

                    $(GlobalObj).attr("data-fid", img_width.val().Trim());
                    $(GlobalObj).attr("data-font", img_height.val().Trim());
                    $(GlobalObj).attr("data-item", img_url.val().Trim());
                    $(GlobalObj).prev().html('<img src="' + img_url.val().Trim() + '" style="width:' + img_width.val().Trim() + 'px;height:' + img_height.val().Trim() + 'px;" />').parent().css({ width: img_width.val().Trim(), height: img_height.val().Trim() });

                } else {
                    var dir = parseInt(align.val().Trim());
                    $(GlobalObj).attr("data-fid", font.val().Trim());
                    $(GlobalObj).attr("data-font", fontSize.val().Trim());
                    $(GlobalObj).attr("data-align", dir);
                    $(GlobalObj).attr("data-bold", bold);
                    $(GlobalObj).prev().attr("style", "font-family:'" + font.find("option:selected").text() + "';font-size:" + fontSize.val().Trim() + "px;font-weight:" + (bold ? "700" : "normal") + ";text-align:" + (dir == 1 ? "left" : dir == 2 ? "center" : dir == 3 ? "right" : "left") + ";");
                }
            }

            diaglog.fadeOut();
            MyMaskLayer.Control.Remove();
        }

        /*
        $('#uploadify').uploadify({
        'swf': '../../js/swfupload/swfupload.swf',
        'buttonText': '上传图片',
        'fileTypeDesc': '请选择图片文件',
        'fileTypeExts': '*.jpg;*.jpeg;*.gif;*.png',
        'buttonImg': '../../images/upload_btn.png',
        'fileSizeLimit': '300KB',
        'width': 94,
        'height': 29,

        'formData': {
        'folder': FilePath
        },
        'uploader': '/Common/ImageHandler.ashx',
        'onUploadSuccess': function (event, data, status) {
        if (status) {
        LImg = FilePath + "/" + data;
        }
        }
        });
        */

        $("button[name=save]").click(
            function () {
                var Data = verify()

                if (Data.Status) {
                    $.post("/OrderManagement/Template.html", Data,
                        function (data) {
                            if (!data.Status) {
                                alert("保存数据失败，请与管理员联系。");
                            }
                            else { alert("保存数据成功！即将刷新页面"); }
                        }
                    ).done(
                        function () {
                            window.location.href = window.location.href;
                        }
                    );
                }
            }
        );

        $("button[name=restore]").click(
            function () {
                $.post("/OrderManagement/restore.html", { PId: PId }, function (data) { }).done(function () { window.location.href = window.location.href; });
            }
        );

        function verify() {
            var Data = { Status: false };
            var Obj
            var lwidth = $("input[name=lwidth]");
            if (lwidth.val().IsEmpty()) {
                lwidth.focus();
                return Data;
            } else {
                if (!lwidth.val().Trim().CheckInteger()) {
                    lwidth.val("").focus();
                    return Data;
                }
            }
            var lheight = $("input[name=lheight]");
            if (lheight.val().IsEmpty()) {
                lheight.focus();
                return Data;
            } else {
                if (!lheight.val().Trim().CheckInteger()) {
                    lheight.val("").focus();
                    return Data;
                }
            }

            Data = { Status: true, PlaneId: PId, UserId: UId, LogisticsId: LId, Image: LImg, Width: lwidth.val().Trim(), Height: lheight.val().Trim(), IsSingle: Single };

            var List = [];
            $("div.map-position").each(
                function (index) {
                    var position = $(this).position();
                    var edit = $(this).find("span.edit");
                    List.push('"DetailList[' + index + '].ContentId":"' + edit.attr("data-id") + '","DetailList[' + index + '].Title":"' + $(this).find("span.link-number-text").text().Trim() + '","DetailList[' + index + '].Font":"' + edit.attr("data-fid") + '","DetailList[' + index + '].FontSize":"' + edit.attr("data-font") + '","DetailList[' + index + '].Bold":' + eval(edit.attr("data-bold")) + ',"DetailList[' + index + '].SubList":"' + edit.attr("data-item") + '","DetailList[' + index + '].Number":"' + edit.attr("data-param") + '","DetailList[' + index + '].Left":"' + position.left + '","DetailList[' + index + '].Top":"' + position.top + '","DetailList[' + index + '].Width":"' + $(this).width() + '","DetailList[' + index + '].Height":"' + $(this).height() + '","DetailList[' + index + '].Align":"' + edit.attr("data-align") + '"');
                }
            );

            Data = $.extend(Data, eval('({' + List.join(',') + '})'));

            return Data;
        }
    };
})(jQuery);

var Template = function () {
    this.Page = {
        Init: function () {
            $('.imgMap').imageMaps();
            $("select[name=font],select[name=align]").select2();
            $("div.dialogContainer").delegate("input[type=checkbox]", "change",
                function () {
                    $(this).parents("label.checkbox:eq(0)").toggleClass("checked");
                }
            );
        }
    };
}

$(document).ready(
    function () {
        new Template().Page.Init();
        $(document).delegate("input[type='checkbox']", "change", function () {
            $(this).parent().parent().toggleClass("checked");
        });
    }
);