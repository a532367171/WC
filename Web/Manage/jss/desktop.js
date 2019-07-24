﻿myLib.NS("desktop");myLib.desktop={winWH:function(){$("body").data("winWh",{"w":$(window).width(),"h":$(window).height()})},desktopPanel:function(){$("body").data("panel",{"taskBar":{"_this":$("#taskBar"),"task_lb":$("#task_lb")},"navBar":$("#navBar"),"wallpaper":$("#wallpapers"),"lrBar":{"_this":$("#lr_bar"),"default_app":$("#default_app"),"start_block":$("#start_block"),"start_btn":$("#start_btn"),"start_item":$("#start_item"),"default_tools":$("#default_tools")},"desktopPanel":{"_this":$("#desktopPanel"),"innerPanel":$("#desktopInnerPanel"),"deskIcon":$("ul.deskIcon")},"powered_by":$("a.powered_by")})},iconDataInit:function(data){for(var a in data){$("#"+a).data("iconData",data[a])}},getMydata:function(){return $("body").data()},mouseXY:function(){var mouseXY=[];$(document).bind("mousemove",function(e){mouseXY[0]=e.pageX;mouseXY[1]=e.pageY});return mouseXY},contextMenu:function(jqElem,data,menuName,textLimit){var _this=this,mXY=_this.mouseXY();jqElem.smartMenu(data,{name:menuName,textLimit:textLimit,afterShow:function(){var menu=$("#smartMenu_"+menuName);var myData=myLib.desktop.getMydata(),wh=myData.winWh;var menuXY=menu.offset(),menuH=menu.height(),menuW=menu.width();if(menuXY.top>wh["h"]-menuH){menu.css("top",mXY[1]-menuH-2)}if(menuXY.left>wh["w"]-menuW){menu.css("left",mXY[0]-menuW-2)}}});$(document.body).click(function(event){event.preventDefault();$.smartMenu.hide()})}};myLib.NS("desktop.win");myLib.desktop.win={winHtml:function(title,url,id){return"<div class='windows corner' id="+id+"><div class='win_title'><b>"+title+"</b><span class='win_btnblock'><a href='#' class='winMinimize' title='最小化'></a><a href='#' class='winMaximize' title='最大化'></a><a href='#' class='winHyimize' title='还原'></a><a href='#' class='winClose' title='关闭'></a></span></div><iframe frameborder='0' name='myFrame_"+id+"' id='myFrame_"+id+"' class='winframe' scrolling='auto' width='100%' src=''></iframe></div>"},iframFix:function(obj){obj.each(function(){var o=$(this);if(o.find(".zzDiv").size()<=0){o.append($("<div class='zzDiv' style='width:100%;height:"+(o.innerHeight()-16)+"px;position:absolute;z-index:900;left:0;top:16px;'></div>"))}})},maxWinZindex:function($win){return Math.max.apply(null,$.map($win,function(e,n){if($(e).css("position")=="absolute"){return parseInt($(e).css("z-index"))||1}}))},findTopWin:function($win,maxZ){var topWin;$win.each(function(index){if($(this).css("z-index")==maxZ){topWin=$(this);return false}});return topWin},closeWin:function(obj){var _this=this,$win=$("div.windows").not(".hideWin"),maxZ,topWin;myLib.desktop.taskBar.delWinTab(obj);obj.hide(200,function(){$(this).remove()});if($win.size()>1){maxZ=_this.maxWinZindex($win.not(obj));topWin=_this.findTopWin($win,maxZ);_this.switchZindex(topWin)}},minimize:function(obj){var _this=this,$win=$("div.windows").not(".hideWin"),maxZ,topWin,objTab;obj.css({"left":obj.position().left-10000}).addClass("hideWin");if($win.size()>1){maxZ=_this.maxWinZindex($win.not(obj));topWin=_this.findTopWin($win,maxZ);_this.switchZindex(topWin)}else{objTab=myLib.desktop.taskBar.findWinTab(obj);objTab.removeClass("selectTab").addClass("defaultTab")}},maximizeWin:function(obj){var myData=myLib.desktop.getMydata(),panel=$("#desktopInnerPanel").offset(),wh=myData.winWh;obj.css({"width":wh["w"],"height":wh["h"],"left":-panel.left,"top":-panel.top}).draggable("disable").resizable("disable").removeClass("ui-state-disabled").find(".zzDiv").hide().end().find(".winframe").css({"width":wh["w"],"height":wh["h"]-16})},hyimizeWin:function(obj){var myData=obj.data(),winLocation=myData.winLocation;obj.css({"width":winLocation["w"],"height":winLocation["h"],"left":winLocation["left"],"top":winLocation["top"]}).draggable("enable").resizable("enable").find(".winframe").css({"width":winLocation["w"],"height":winLocation["h"]-16})},switchZindex:function(obj){var myData=myLib.desktop.getMydata(),$topWin=myData.topWin,$topWinTab=myData.topWinTab,curWinZindex=obj.css("z-index"),maxZ=myData.maxZindex,objTab=myLib.desktop.taskBar.findWinTab(obj);if(!$topWin.is(obj)){obj.css("z-index",maxZ);objTab.removeClass("defaultTab").addClass("selectTab");$topWin.css("z-index",curWinZindex);$topWinTab.removeClass("selectTab").addClass("defaultTab");this.iframFix($topWin);$("body").data("topWin",obj).data("topWinTab",objTab)}},newWin:function(options){var myData=myLib.desktop.getMydata(),wh=myData.winWh,$windows=$("div.windows"),_this=this,curwinNum=myLib._is(myData.winNum,"Number")?myData.winNum:0;_this.iframFix($windows);var defaults={WindowTitle:null,WindowsId:null,WindowPositionTop:1,WindowPositionLeft:205,WindowWidth:0.75,WindowHeight:0.84,WindowMinWidth:250,WindowMinHeight:250,iframSrc:null,WindowResizable:true,WindowMaximize:true,WindowMinimize:true,WindowClosable:true,WindowDraggable:true,WindowStatus:"regular",WindowAnimationSpeed:500,WindowAnimation:"none"};var options=$.extend(defaults,options);var dxy=Math.floor((Math.random()*100)),panelLeft=$("#desktopInnerPanel").position(),wLeft=0,wTop=0,ww=options["WindowWidth"]<1?Math.round(wh["w"]*options["WindowWidth"]):options["WindowWidth"],hh=options["WindowHeight"]<1?Math.round(wh["h"]*options["WindowHeight"]):options["WindowHeight"];
if(options["WindowPositionLeft"]=="center"){wLeft=(wh["w"]-ww)/2-panelLeft.left}else{if(options["WindowPositionLeft"]+ww>wh["w"]){wLeft=(options["WindowPositionLeft"]+wh["w"])/ww-panelLeft.left}else{wLeft=options["WindowPositionLeft"]-panelLeft.left}}if(options["WindowPositionTop"]=="center"){wTop=(wh["h"]-hh)/2}else{if(options["WindowPositionTop"]+hh>wh["h"]){wTop=(options["WindowPositionTop"]+hh)/wh["h"]}else{wTop=options["WindowPositionTop"]}}var zindex=curwinNum+500;var id="myWin_"+options["WindowsId"];$("body").data("winNum",curwinNum+1);if($("#"+id).size()<=0){myLib.desktop.taskBar.addWinTab(options["WindowTitle"],options["WindowsId"]);$(_this.winHtml(options["WindowTitle"],options["iframSrc"],id)).appendTo("#desktopInnerPanel");var $newWin=$("#"+id),$icon=$("#"+options["WindowsId"]),$iconOffset=$icon.offset(),$fram=$newWin.find(".winframe"),$winTitle=$newWin.find(".win_title"),winMaximize_btn=$newWin.find("a.winMaximize"),winMinimize_btn=$newWin.find("a.winMinimize"),winClose_btn=$newWin.find("a.winClose"),winHyimize_btn=$newWin.find("a.winHyimize");winHyimize_btn.hide();if(!options["WindowMaximize"]){winMaximize_btn.hide()}if(!options["WindowMinimize"]){winMinimize_btn.hide()}if(!options["WindowClosable"]){winClose_btn.hide()}$("body").data({"maxZindex":zindex,"topWin":$newWin});var index=$("#navBar a").index($(".currTab"));$newWin.data("index",index);$newWin.css({"width":ww,"height":hh,"left":wLeft,"top":wTop,"z-index":zindex}).addClass("loading").show(10,function(){$(this).find(".winframe").attr("src",options["iframSrc"]).load(function(){$(this).show()})}).data("winLocation",{"w":ww,"h":hh,"left":wLeft,"top":wTop}).bind({"mousedown":function(event){_this.switchZindex($(this))},"mouseup":function(){$(this).find(".zzDiv").remove()}}).find(".winframe").css({"width":ww,"height":hh-26});if(options["WindowDraggable"]){}if(options["WindowResizable"]){_this.resize(ww,hh,wh["w"]-wLeft,wh["h"]-wTop-35,$newWin,wh)}$winTitle.dblclick(function(){var hasMaximizeBtn=$(this).find(winMaximize_btn);if(!hasMaximizeBtn.is(":hidden")){winMaximize_btn.trigger("click")}else{winHyimize_btn.trigger("click")}});winClose_btn.click(function(event){event.stopPropagation();_this.closeWin($newWin)});winMaximize_btn.click(function(event){event.stopPropagation();if(options["WindowStatus"]=="regular"){_this.maximizeWin($newWin);$(this).hide();winHyimize_btn.show();options["WindowStatus"]="maximized";$("#desktopPanel").css("z-index",95)}});$(window).wresize(function(){if(options["WindowStatus"]=="maximized"){_this.maximizeWin($newWin)}});winHyimize_btn.click(function(event){event.stopPropagation();if(options["WindowStatus"]=="maximized"){_this.hyimizeWin($newWin);$(this).hide();winMaximize_btn.show();options["WindowStatus"]="regular";$("#desktopPanel").css("z-index",70)}});winMinimize_btn.click(function(){_this.minimize($newWin)})}else{var wins=$("#"+id),objTab=myLib.desktop.taskBar.findWinTab(wins);objTab.removeClass("defaultTab").addClass("selectTab").trigger("click");myLib.desktop.win.switchZindex(wins);wins.find("iframe").attr("src",options["iframSrc"])}},upWinResize_block:function(win){var offset=win.offset();win.resizable("option",{"maxWidth":$(window).width()-offset.left-10,"maxHeight":$(window).height()-offset.top-35})},drag:function(arr,$newWin,wh){var _this=this;$newWin.draggable({handle:"div.win_title",iframeFix:false,scroll:false}).bind("dragstart",function(event,ui){_this.iframFix($(this));$("#desktopPanel").css("z-index",95)}).bind("dragstop",function(event,ui){$("#desktopPanel").css("z-index",70);var obj_this=$(this);var offset=obj_this.offset();_this.upWinResize_block(obj_this);obj_this.data("winLocation",{"w":obj_this.width(),"h":obj_this.height(),"left":offset.left,"top":offset.top}).find(".zzDiv").remove();if(event.pageY>wh.h-50){$(this).css("top",event.pageY-90)}else{if(event.pageY<-35){$(this).css("top",-35)}}});$("div.win_title").css("cursor","move")},resize:function(minW,minH,maxW,maxH,$newWin,wh){var _this=this;$newWin.resizable({minHeight:minH,minWidth:minW,containment:"document",maxWidth:maxW,maxHeight:maxH}).css("position","absolute").bind("resize",function(event,ui){var h=$(this).innerHeight(),w=$(this).innerWidth();_this.iframFix($(this));$(this).children(".winframe").css({"width":w,"height":h-16})}).bind("resizestop",function(event,ui){var obj_this=$(this);var offset=obj_this.offset();var h=obj_this.innerHeight(),w=obj_this.innerWidth();obj_this.data("winLocation",{"w":w,"h":h,"left":offset.left,"top":offset.top}).find(".zzDiv").remove()})}};myLib.NS("desktop.lrBar");myLib.desktop.lrBar={upLrBar:function(){var myData=myLib.desktop.getMydata(),$lrBar=myData.panel.lrBar["_this"],wh=myData.winWh;$lrBar.css({"top":Math.floor((wh["h"]-$lrBar.height())/2)-60})},init:function(iconData){var myData=myLib.desktop.getMydata(),$default_tools=myData.panel.lrBar["default_tools"],$def_tools_Btn=$default_tools.find("span"),$start_btn=myData.panel.lrBar["start_btn"],$start_block=myData.panel.lrBar.start_block,$start_item=myData.panel.lrBar["start_item"],$default_app=myData.panel.lrBar["default_app"],$lrBar=myData.panel.lrBar["_this"],wh=myData.winWh,_this=this;
_this.upLrBar();myLib.desktop.iconDataInit(iconData);$(window).wresize(function(){myLib.desktop.winWH();_this.upLrBar()});$def_tools_Btn.hover(function(){$(this).css("background-color","#999")},function(){$(this).css("background-color","transparent")});$default_app.find("li").hover(function(){$(this).addClass("btnOver")},function(){$(this).removeClass("btnOver")}).click(function(){var data=$(this).data("iconData");data.WindowsId=this.id;if(data.isLinks==undefined||!data.isLinks){if(!$("#myWin_"+this.id).size()){myLib.desktop.win.newWin(data);$(this).data("currPanel",$("ul.currDesktop").index("ul.deskIcon"))}else{$("#myWinTab_"+this.id).trigger("click")}}else{window.open(data.iframSrc)}}).draggable({helper:"clone",scroll:false,opacity:0.7,scope:"a",appendTo:"parent",start:function(){$lrBar.css("z-index",90)}})}};myLib.NS("desktop.message");myLib.desktop.message={show:function(info,stay){$("#closebutton").click(function(){$("#msg1").notificationmsg("hide")});$("#modalbody").html(info);$("#msg1").notificationmsg({animation:"slide"});$("#msg1").notificationmsg({period:stay});$("#msg1").notificationmsg({speed:775});$("#msg1").notificationmsg("show")}};myLib.NS("desktop.taskBar");myLib.desktop.taskBar={timer:function(obj){var curDaytime=new Date().toLocaleString().split(" ");obj.innerHTML=curDaytime[1];obj.title=curDaytime[0];setInterval(function(){obj.innerHTML=new Date().toLocaleString().split(" ")[1]},1000)},upTaskWidth:function(){var myData=myLib.desktop.getMydata(),$task_bar=myData.panel.taskBar["_this"];var maxHdTabNum=Math.floor($(window).width()/100);$task_bar.width(maxHdTabNum*100);$("body").data("maxHdTabNum",maxHdTabNum-2)},init:function(){var myData=myLib.desktop.getMydata();var $task_lb=myData.panel.taskBar["task_lb"],$task_bar=myData.panel.taskBar["_this"],wh=myData.winWh;var _this=this;_this.upTaskWidth();$(window).wresize(function(){_this.upTaskWidth()})},contextMenu:function(tab,id){var _this=this;var data=[[{text:"刷新本页",func:function(){var win=$("#myWin_"+tab.data("win"));var data=$("#"+tab.data("win")).data("iconData");win.find("iframe").attr("src",data.iframSrc)}}],[{text:"关闭所有窗口",func:function(){$("#task_lb > a").remove();$("div.windows").remove()}}],[{text:"关闭本窗口",func:function(){$("#smartMenu_taskTab_menu"+id).remove();myLib.desktop.win.closeWin($("#myWin_"+tab.data("win")))}}]];myLib.desktop.contextMenu(tab,data,"taskTab_menu"+id,10)},addWinTab:function(text,id){var myData=myLib.desktop.getMydata();var $task_lb=myData.panel.taskBar["task_lb"],$task_bar=myData.panel.taskBar["_this"],$navBar=myData.panel.navBar,$navTab=$navBar.find("a"),tid="myWinTab_"+id,allTab=$task_lb.find("a"),curTabNum=allTab.size(),docHtml="<a href='#' id='"+tid+"'>"+text+"</a>";$task_lb.append($(docHtml));var $newTab=$("#"+tid);this.contextMenu($newTab,id);$task_lb.find("a.selectTab").removeClass("selectTab").addClass("defaultTab");$newTab.data("win",id).data("index",$("ul.currDesktop").index("ul.deskIcon")).addClass("selectTab").click(function(){var win=$("#myWin_"+$(this).data("win")),tabId=this.id,iconId=tabId.split("_")[1],desk=$("#"+iconId).parent(),i=desk.index("ul.deskIcon");if(i<0){i=$(this).data("index")}if(win.hasClass("hideWin")){win.css({"left":win.position().left+10000}).removeClass("hideWin");$(this).removeClass("defaultTab").addClass("selectTab");myLib.desktop.win.switchZindex(win)}else{myLib.desktop.win.switchZindex(win)}$navTab.eq(i).trigger("click")});$("body").data("topWinTab",$newTab);if(curTabNum>myData.maxHdTabNum-1){var LeftBtn=$("#leftBtn"),rightBtn=$("#rightBtn"),bH;LeftBtn.show().find("a").click(function(){var pos=$task_lb.position();if(pos.top<0){$task_lb.animate({"top":pos.top+40},50)}});rightBtn.show().find("a").click(function(){var pos=$task_lb.position(),h=$task_lb.height(),row=h/40;if(pos.top>(row-1)*(-40)){$task_lb.animate({"top":pos.top-40},50)}});$task_lb.parent().css("margin","0 100")}},delWinTab:function(wObj){var myData=myLib.desktop.getMydata(),$task_lb=myData.panel.taskBar["task_lb"],$task_bar=myData.panel.taskBar["_this"],LeftBtn=$("#leftBtn"),rightBtn=$("#rightBtn"),pos=$task_lb.position();this.findWinTab(wObj).remove();var newH=$task_lb.height();if(Math.abs(pos.top)==newH){LeftBtn.find("a").trigger("click")}if(newH==40){LeftBtn.hide();rightBtn.hide();$task_lb.parent().css("margin",0)}},findWinTab:function(wObj){var myData=myLib.desktop.getMydata(),$task_lb=myData.panel.taskBar["task_lb"],objTab;$task_lb.find("a").each(function(index){var id="#myWin_"+$(this).data("win");if($(id).is(wObj)){objTab=$(this)}});return objTab}};myLib.NS("desktop.navBar");myLib.desktop.navBar={init:function(){var myData=myLib.desktop.getMydata(),$navBar=myData.panel.navBar,$innerPanel=myData.panel.desktopPanel.innerPanel,$deskIcon=myData.panel.desktopPanel["deskIcon"],desktopWidth=$deskIcon.width(),lBarWidth=myData.panel.lrBar["_this"].outerWidth(),_self=this;_self.upTabBar();$navBar.find("b").hover(function(){$(this).addClass("hover")},function(){$(this).removeClass("hover")}).click(function(){$("#appManagerPanel").css("top",0);
$("#desktopPanel,#navBar,#taskBarWrap,#lr_bar,#timebox").hide();myLib.desktop.appManagerPanel.init()})},upTabBar:function(){var $navBar=$("#navBar"),myData=myLib.desktop.getMydata(),$navTab=$navBar.find("a:not('.tabadd')"),lBarWidth=myData.panel.lrBar["_this"].outerWidth(),$innerPanel=myData.panel.desktopPanel.innerPanel,$deskIcon=myData.panel.desktopPanel["deskIcon"],desktopWidth=$deskIcon.width();$navBar.css("margin-left",($navBar.width()+20)*-1/2).draggable({scroll:false});$navTab.droppable({scope:"a",over:function(event,ui){$(this).trigger("click");var i=$navTab.index($(this))},drop:function(event,ui){var i=$navTab.index($(this)),desktopData=$("body").data("desktopData");ui.draggable.addClass("desktop_icon").insertBefore($deskIcon.eq(i).find(".add_icon")).find("span").addClass("icon");myLib.desktop.deskIcon.init(desktopData);myLib.desktop.lrBar.init()}}).live("click",function(event){event.preventDefault();event.stopPropagation();var i=$navTab.index($(this));myLib.desktop.deskIcon.desktopMove($innerPanel,$deskIcon,$navTab,500,desktopWidth+lBarWidth,i)})},addDesktop:function(){var $navBar=$("#navBar"),navTabCon=$navBar.find("span"),desktopInnerPanel=$("#desktopInnerPanel"),$tabadd=$navBar.find("a.tabadd"),desktopData=$("body").data("desktopData");$("<a herf='#'></a>").insertBefore($tabadd);desktopInnerPanel.append("<ul class='deskIcon'><li class='desktop_icon add_icon' > <span class='icon'><img src='themes/default/images/add_icon.png'/></span> <div class='text'>添加 <s></s></div> </li></ul>");myLib.desktop.desktopPanel();this.upTabBar();myLib.desktop.deskIcon.init(desktopData)}};myLib.NS("desktop.wallpaper");myLib.desktop.wallpaper={init:function(imgUrl){myLib.desktop.winWH();var myData=myLib.desktop.getMydata(),winWh=myData.winWh,wallpaper=myData.panel.wallpaper,_this=this;if(imgUrl!==null){wallpaper.html("<img src='"+imgUrl+"'></img>");var img=wallpaper.find("img");myLib.getImgWh(imgUrl,function(imgW,imgH){if(imgW<=winWh.w){img.css("width",winWh.w)}else{img.css({"margin-left":-(imgW-winWh.w)/2})}if(imgH<=winWh.h){img.css("height",winWh.h)}else{img.css({"margin-top":-(imgH-winWh.h)/2})}})}window.onresize=function(){_this.init(imgUrl)}}};myLib.NS("desktop.deskIcon");myLib.desktop.deskIcon={arrangeIcons:function(desktop){var myData=myLib.desktop.getMydata(),winWh=myData.winWh,$navBar=myData.panel.navBar,navBarHeight=$navBar.outerHeight(),iconNum=desktop.find("li").size();desktop.data("deskIconNum",iconNum);var gH=88;var gW=88;var rows=Math.floor((winWh["h"]-navBarHeight-75)/gH);var cols=Math.ceil(iconNum/rows);var curcol=0,currow=0;desktop.find("li").css({"position":"absolute","margin":0,"left":function(index,value){var v=curcol*gW+30;if((index+1)%rows==0){curcol=curcol+1}return v},"top":function(index,value){var v=(index-rows*currow)*gH+20;if((index+1)%rows==0){currow=currow+1}return v}})},upDesktop:function($deskIcon,$deskIconBlock,$innerPanel,$deskIconNum,navBarHeight,lBarWidth){var myData=myLib.desktop.getMydata(),winWh=myData.winWh,w=winWh["w"]-lBarWidth,h=(winWh["h"]-75-navBarHeight),desktopData=$("body").data("desktopData"),_this=this;$innerPanel.css({"width":((w+lBarWidth)*$deskIconNum)+"px","height":h+"px"});$deskIcon.css({"width":w+"px","height":h+"px","margin-right":lBarWidth});$deskIconBlock.css({"width":w+"px","height":h+"px","margin-top":navBarHeight+10,"margin-left":lBarWidth+"px","margin-bottom":75+"px"});$deskIcon.each(function(){_this.arrangeIcons($(this))})},desktopMove:function($innerPanel,$deskIcon,$navTab,dates,moveDx,nextIndex){$innerPanel.stop().animate({left:-(nextIndex)*moveDx},dates,function(){$deskIcon.removeClass("currDesktop").eq(nextIndex).addClass("currDesktop");$navTab.removeClass("currTab").eq(nextIndex).addClass("currTab")})},init:function(iconData){var myData=myLib.desktop.getMydata(),winWh=myData.winWh,$deskIconBlock=myData.panel.desktopPanel["_this"],$innerPanel=myData.panel.desktopPanel.innerPanel,$deskIcon=myData.panel.desktopPanel["deskIcon"],$deskIconNum=$deskIcon.size(),$navBar=myData.panel.navBar,navBarHeight=$navBar.outerHeight(),lBarWidth=myData.panel.lrBar["_this"].outerWidth(),_this=this;_this.upDesktop($deskIcon,$deskIconBlock,$innerPanel,$deskIconNum,navBarHeight,lBarWidth);$(window).wresize(function(){myLib.desktop.winWH();_this.upDesktop($deskIcon,$deskIconBlock,$innerPanel,$deskIconNum,navBarHeight,lBarWidth)});myLib.desktop.iconDataInit(iconData);$("body").data("desktopData",iconData);var timeStart,timeEnd,dxStart,dxEnd;$innerPanel.draggable({axis:"x",start:function(event,ui){$(this).css("cursor","move");timeStart=new Date().getTime();dxStart=event.pageX},stop:function(event,ui){var $navTab=$navBar.find("a:not('.tabadd')");$(this).css("cursor","inherit");timeEnd=new Date().getTime();dxEnd=event.pageX;var timeCha=timeEnd-timeStart,dxCha=dxEnd-dxStart,currDesktop=$(this).find("ul.currDesktop"),deskIndex=$deskIcon.index(currDesktop),moveDx=$deskIcon.width()+lBarWidth,dates=1000+timeCha;if(dxCha<-150&&deskIndex<$deskIcon.size()-1){_this.desktopMove($(this),$deskIcon,$navTab,dates,moveDx,deskIndex+1)
}else{if(dxCha>150&&deskIndex>0){_this.desktopMove($(this),$deskIcon,$navTab,dates,moveDx,deskIndex-1)}else{$(this).animate({left:-(deskIndex)*moveDx},500)}}}});$deskIcon.find("li").hover(function(){$(this).addClass("desktop_icon_over")},function(){$(this).removeClass("desktop_icon_over")}).not("li.add_icon").click(function(){var data=$(this).data("iconData"),id=this.id;if(data.isLinks==undefined||!data.isLinks){data.WindowsId=id;myLib.desktop.win.newWin(data)}else{window.open(data.iframSrc)}}).draggable({helper:"clone",scroll:false,opacity:0.7,scope:"a",appendTo:"body",zIndex:91,start:function(event,ui){ui.helper.removeClass("desktop_icon_over")}})}};myLib.NS("desktop.startBtn");myLib.desktop.startBtn={init:function(data){var myData=myLib.desktop.getMydata(),$start_btn=myData.panel.lrBar["start_btn"],$start_item=myData.panel.lrBar["start_item"],_this=this;function creatItme(d,a){var itemHtml="",i,j;if(a){itemHtml+="<ul class='item childItem'>"}else{itemHtml+="<ul class='item'>"}for(i=0;i<d.length;i++){var arr=d[i];if(i!=0){itemHtml+="<div class='line'></div>"}for(j=0;j<arr.length;j++){if(arr[j]["childItem"]==undefined){itemHtml+="<li id="+arr[j]["id"]+"><span><img src='"+arr[j]["icon"]+"'/>"+arr[j]["text"]+"</span></li>"}else{itemHtml+="<li id="+arr[j]["id"]+"><span><img src='"+arr[j]["icon"]+"'/>"+arr[j]["text"]+"</span><b></b>";itemHtml+=creatItme(arr[j]["childItem"],1);itemHtml+="</li>"}$("#"+arr[j]["id"]).live("click",arr[j]["func"])}}itemHtml+="</ul >";return itemHtml}$start_item.append(creatItme(data,0));$(".item li").hover(function(){$(this).children(".childItem").show()},function(){$(this).children(".childItem").hide()});$start_btn.click(function(event){event.preventDefault();event.stopPropagation();if($start_item.is(":hidden")){$start_item.show()}else{$start_item.hide()}});$("body").click(function(event){event.preventDefault();$start_item.hide();$(".childItem").hide()})}};myLib.NS("desktop.appManagerPanel");myLib.desktop.appManagerPanel={init:function(){var appManagerPanel=$("#appManagerPanel"),aMg_close=$(".aMg_close"),aMg_dock_container=$(".aMg_dock_container"),aMg_folder_container=$(".aMg_folder_container"),aMg_folder_innercontainer=$(".aMg_folder_innercontainer"),aMg_prev=$("#aMg_prev"),aMg_next=$("#aMg_next"),wh=$(window).height(),ww=$(window).width(),deskTopNum=$("ul.deskIcon").size(),dhtml="",_self=this;aMg_folder_container.height(wh-aMg_dock_container.height());aMg_dock_container.html($("#default_app").clone(true));function amgClose(){appManagerPanel.css("top","-9999px");$("#desktopPanel,#navBar,#taskBarWrap,#lr_bar,#timebox").show();aMg_folder_innercontainer.css("margin-left",0)}aMg_close.click(function(){amgClose()});for(var i=0;i<deskTopNum;i++){dhtml+="<div class='folderItem folderItem_turn' id='folder_"+i+"'><div class='folder_bg'>"+(i+1)+"</div><div class='folderOuter'><ul class='folderInner' style='overflow: hidden;'></ul></div><div class='aMg_line_y'></div></div>"}aMg_folder_innercontainer.html(dhtml);var folderItem=$("div.folderItem"),fitemWidth=parseInt(ww/5),folderOuter=$(".folderOuter");folderItem.css("width",fitemWidth);for(var i=0;i<deskTopNum;i++){$("#folder_"+i).find(".folderInner").append($("ul.deskIcon").eq(i).find("li:not(.add_icon)").clone());$("#folder_"+i).find(".folderOuter").niceScroll("#folder_"+i+" .folderInner",{touchbehavior:false,cursorcolor:"#666",horizrailenabled:true,cursoropacitymax:0.8,cursorborder:"1px solid #ccc"});$(window).wresize(function(){$("#folder_"+i).find(".folderOuter").getNiceScroll().resize()})}var folderIcon=folderItem.find(".desktop_icon");folderIcon.on("mouseover",function(){$(this).addClass("hover")}).on("mouseout",function(){$(this).removeClass("hover")}).attr("style","");$(".aMg_dock_container,.folderItem").find(".desktop_icon").on("click",function(e){var i=$(this).parent().parent().parent().attr("id").split("_")[1],navBar=$("#navBar");var index=i==undefined?$(".currDesktop").index(".deskIcon"):i;amgClose();navBar.find("span > a").eq(parseInt(index)).trigger("click");$("#"+this.id).trigger("click");$("#myWin_"+this.id).css("left",205+$(window).width()*parseInt(index));var ev=e||event;ev.stopPropagation();return false});aMg_folder_innercontainer.width(deskTopNum*(fitemWidth)).height(wh-aMg_dock_container.height());$(window).wresize(function(){var h=$(window).height()-aMg_dock_container.height(),fw=$(window).width()/5;aMg_folder_container.height(h);aMg_folder_innercontainer.height(h).width(deskTopNum*fw);folderItem.css("width",fw);fitemWidth=parseInt(fw)});if(deskTopNum>5){aMg_prev.show();aMg_next.show()}var moveIndex=0,maxMoveNum=deskTopNum-5;function move_amg(a){aMg_folder_innercontainer.animate({"margin-left":"+="+a},100)}aMg_prev.click(function(){moveIndex=parseInt(aMg_folder_innercontainer.css("margin-left"));if(moveIndex<0){move_amg(fitemWidth)}});aMg_next.click(function(){moveIndex=parseInt(aMg_folder_innercontainer.css("margin-left"));if(moveIndex>maxMoveNum*-1*fitemWidth){move_amg(-1*fitemWidth)}})}};                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    