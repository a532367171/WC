﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarMemo.aspx.cs" Inherits="Manage_richeng_CalendarMemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>我的日程计划安排</title>   
<script type="text/javascript">
    function _gt() { return new Date().getTime() }
    var _loadStartTime = _gt(), _user_email = "1735787462@qq.com", _nav = navigator.userAgent.toLowerCase(), _tsf = 141;


    _sip = false;


    _experimentalLangs = "";


    _allowGuestModifyFeature = true;
    _allowShowGuestNameFeature = false;
    _allowInviteYourselfFeature = false;
    _allowAlternateCalendarFeature = true;
    _allowPublishDialogFeature = false;
    _enableBgImages = false;
    _ol_enabled = true;
    _ol_serve_ol = false;
    _isGoogUser = false;
    _locale = "zh_CN";
    _hosted = false;
    _APP_NAME = "1735787462@qq.com";
    _OL_COOKIE_NAME = "OL_SESSION";
    _ACCOUNTS_BASE_URL = "#";
    _enable_new_oops_errors = true;
    _enableContextualTooltip = true;
    _debugContextualTooltip = false;
    _enableSnooze = false;
    _enableUndo = true;

    _preScript = _gt();
</script>
<link type="text/css" rel="stylesheet" href="6a3eb8ba4a07edb76f79a18d6bdb8933doozercompiled3.css">
<script type="text/javascript" src="6a3eb8ba4a07edb76f79a18d6bdb8933calendarjs_doozercompiled__zh_cn3.js"></script>

<script type="text/javascript">
    var _postScript = _gt();



    _SE_weatherOn = true;
    _SE_vcalNotificationsOn = false;
    _EF_mapOn = true;



    function _gLSS() {
        var ss = document.styleSheets, s = ss.length - 1;
        while (s >= 0) {
            if (ss[s].href) return ss[s];
            --s;
        }
        return null;
    }

    function _checkCSS() {
        var s = _gLSS();
        if (s) {
            var ruleName = (s.cssRules) ? 'cssRules' : 'rules';
            var r = s[ruleName];
            if (r.length > 0 && r[r.length - 1].selectorText == '.lastCalRule') return 1;
        }
        return 0;
    }

    (function () {
        if (typeof _lastCalFunc != 'function') {
            var j = document.scripts[1];
            if (j) j.src = j.src + '?rand=' + Math.random();
        }
        if (!_checkCSS()) {
            var s = _gLSS();
            if (s) s.href += '?rand=' + Math.random();
        }
    })();

</script>

<script type="text/javascript">

    var _eoHeadTime = _gt();

</script>
<style type="text/css">
  *{font-weight:normal !important;font-style:normal !important;font-stretch:normal !important}


.requiresjs{display:block}
</style>

<script type="text/javascript">window.gbar = {}; (function () { function e(a, c, g) { var f = "on" + c; if (a.addEventListener) a.addEventListener(c, g, false); else if (a.attachEvent) a.attachEvent(f, g); else { var d = a[f]; a[f] = function () { var b = d.apply(this, arguments), j = g.apply(this, arguments); return b == undefined ? j : j == undefined ? b : j && b } } }; var h = window.gbar, i, k; function l(a, c) { a.visibility = k ? "hidden" : "visible"; a.left = c + "px" } h.tg = function (a) { a = a || window.event; var c = 0, g, f = window.navExtra, d = document.getElementById("gbi"), b = a.target || a.srcElement; a.cancelBubble = true; if (!i) { i = document.createElement(Array.every || window.createPopup ? "iframe" : "div"); i.frameBorder = "0"; i.src = "javascript:''"; d.parentNode.appendChild(i).id = "gbs"; if (f) for (g in f) d.insertBefore(f[g], d.firstChild).className = "gb2"; e(document, "click", h.close) } if (b.className != "gb3") b = b.parentNode; do c += b.offsetLeft; while (b = b.offsetParent); l(d.style, c); i.style.width = d.offsetWidth + "px"; i.style.height = d.offsetHeight + "px"; l(i.style, c); k = !k }; h.close = function (a) { k && h.tg(a) } })();
</script>

<style type="text/css">#gbar{height:22px;padding-left:1px}.gbh,.gbd{border-top:1px solid #c9d7f1;font-size:1px}.gbh{height:0;position:absolute;top:24px;width:100%}#gbi,#gbs{background:#fff;left:0;position:absolute;top:24px;visibility:hidden;z-index:1000}#gbi{border:1px solid;border-color:#c9d7f1 #36c #36c #a2bae7;z-index:1001}#guser{padding-bottom:7px !important;text-align:right}#gbar,#guser{font-size:13px;padding-top:4px !important}@media all{.gb1,.gb3{height:22px;margin-right:.5em;vertical-align:top}#gbar{float:left}}.gb2{display:block;padding:.2em .5em}a.gb1,a.gb2,a.gb3{color:#00c !important}.gb2,.gb3{text-decoration:none}a.gb2:hover{background:#36c;color:#fff !important}</style>
<link rel="SHORTCUT ICON" href="/favicon.ico" />
    
    
</head>
<body class='loc-zh_cn loc-zh ie ie6' >
<div id=loadingItem style='position:absolute;top:8em;left:2em'>
<br><font size=+2>正在加载...</font>
<br><br>针对慢速连接，&nbsp;<a href='#'>加载只读视图</a></div>

<script type="text/javascript">
    var _beginBodyTime = _gt();

</script>
<noscript>
<br>
您的浏览器必须支持 javascript。
<br>
</noscript>

<div id=gbar></div><div class=gbh style=left:0></div><div class=gbh style=right:0></div>
<div style="clear:both"></div>
<div id="guser" class="cal-gaia-bar">
<div style="display:none"><span id="offline_sc"></span><span id="offline_sep"></span></div>
</div>
<div id="calcontent"><div id="topBar">
<div id="mb1" style="display:none"></div>
<div class="noprint">
<div id="logoparent"></div>
<div class="topCtrls">

<div id="ntowner"></div>
</div>
</div>
<div id="sropt"></div></div>
<div id="lo">正在加载...</div>
<table id="mothertable" width="100%" cellpadding="0" cellspacing="0"><tr><td id="nav" class="noprint"><div class="sidebar"><div class="sidelink"><strong class="lk" onclick="_CreateNewEvent()" id="comp">创建工作日程</strong><br/><br/><strong class="lk" onclick="javascript:window.location='/Manage/Common/Memo_General.aspx'" id="Strong1">导出日程</strong>&nbsp;&nbsp;&nbsp;<strong class="lk" onclick="javascript:window.location='/Manage/Common/MyMemo.aspx'" id="Strong2">下属日程</strong></div>

</div>
<div style="margin-top:5px;"></div>
<div id="dp_0_t1" class="t1">&nbsp;</div>
<div id="dp_0_t2" class="t2">&nbsp;</div>
<h2 class="hdn">日期选择器</h2>
<div id="dp_0" class="dpdiv"></div>
<div id="dp_0_b2" class="t2">&nbsp;</div>
<div id="dp_0_b1" class="t1">&nbsp;</div>

<div class="nb_0" style="padding-top:12px"><div style="width:100%; height:2px"><div class="t1 chromeColor">&nbsp;</div>
<div class="t2 chromeColor">&nbsp;</div></div>
<h2 id="clst_my" class="calHeader goog-zippy-expanded normalText"><span class="h zippy-arrow" unselectable="on">&nbsp;</span>
我的日历</h2>
<div style="padding:0 2px 1px;clear:both" class="sidetable chromeColor" id="lhscalinner_my"><div id="calendars_my"></div>
<div class="calendarsBottom"><div class="callistLink floatLeft"><span class="lk" onmousedown="_GenSettings(1)" style="display:none;">设置</span></div>
<div class="callistLink textAlignRight"><span class="lk" onmousedown="_EH_nwC()" style="display:none;">创建</span></div></div></div></div>
<div class="nb_0" style="padding-top:12px"><div style="width:100%; height:2px"><div class="t1 chromeColor">&nbsp;</div>
<div class="t2 chromeColor">&nbsp;</div></div>

<div style="display:none;">
<h2 id="clst_fav" class="calHeader goog-zippy-expanded normalText"><span class="h zippy-arrow" unselectable="on">&nbsp;</span>
其他日历</h2>

<div style="padding:0 2px 1px;clear:both;zoom:1" class="sidetable chromeColor" id="lhscalinner_fav"><div style="background:#e0ecff;border-bottom:1px solid #c3d9ff">
</div>

<div style="padding:4px;display:none;">
<form id="searchAddCalForm" autocomplete="off" action=""><div class="textbox-fill-wrapper"><div class="textbox-fill-mid"><input class="textbox-fill-input" id="searchAddCal" style="font-size:90%;padding:3px;border:0" value="&#28155;&#21152;&#26379;&#21451;&#30340;&#26085;&#21382;"></div></div></form>
</div>
</div>
<div id="calendars_fav"></div>
<div class="calendarsBottom" id="calendarsBottomChrome"><div class="callistLink floatLeft"><div class="lk" onmousedown="_GenSettings(1)" style="display:none;">设置</div></div>
<div class="callistLink floatRight"><div style="cursor:pointer" id="add_cals_link" onclick="_AP_show()"><span class="lk" style="display:none;">添加</span>
<span style="color:#73a6ff;display:none;">&#9660;</span></div></div>
<div style="clear:both"></div></div></div></div>

</td>
<td id="maincell" valign="top"><div id="mainbody" class="printAlignLeft"><div id="mainnav"></div>
<div class="t1 chromeColor">&nbsp;</div>
<div class="t2 chromeColor">&nbsp;</div>
<div class="printborder mainGrid"><div class="lv-header" id="lvHeader" style="display:none"></div>
<div id="gridcontainer"></div>
</div>
<div class="t2 chromeColor">&nbsp;</div>
<div class="t1 chromeColor">&nbsp;</div></div>
<div id="cover" style="display:none"></div></td>
<td id="gadgetcell"></td></tr></table></div>
<iframe id="historyFrame" style="display:none;position:absolute" src="javascript:&#39;&#39;" scrolling="no"></iframe>

<script type="text/javascript">
    function renderBody() {
        _$('loadingItem').innerHTML = '';



        _renderInit("<%=memo %>", "6a3eb8ba4a07edb76f79a18d6bdb8933", "", [0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0], !_ol_serve_ol);



_Dispatch(['u',
[['hideInvitations', 'false'],
['locale', 'zh_CN'],
['<%=memo %>/off', 'false'],
['weekView5', 'false'],
['format24HourTime', 'true'],
['usrMigr8d2DF', '0'],
['usrMigr8d2SMS', '1'],
['<%=memo %>/off', 'false'],
['<%=memo %>/color', '9'],
['<%=memo %>/hidden', 'true'],
['country', 'CN'],
['<%=memo %>/color', '2'],
['timezone', 'Asia/Shanghai'],
['tzoffset', '28800000', 1],
['translatedtz', '(GMT+08:00) 中国时间 - 北京', 1],
['firstDay', '1'],
['defaultCalMode', 'week'],
['showDeclined', 'true'],
['remindOnRespondedEventsOnly', 'false'],
['hideInvitations_remindOnRespondedEventsOnly', 'false_false'],
['formatDateBeforeMonth', 'false'],
['dtFldOrdr', 'YMD']]]);



    _renderBody();
};

function postRender() {


    try { var rt_promo = false; } catch (e) { }
    var rt_eventDispatches = [];
    var rt_esDispatches = ['us', '<%=memo %> 20091120/20100507 0'];

 var rt_clientDispatches = [['_DS_put', '<%=memo %>', 70, 0, 0, '我的日程安排', 'Asia/Shanghai', null, null, null, 'a7fb62e329d482a056dd42a629610e57', ['<%=memo %>', 70], null, '', '1735787462@qq.com', 'CN', 'add', null, null, '(GMT+08:00) 中国时间 - 北京', [], [], null, null, 0, 1, null], ['_SE_refreshAddCalendarView'], ['ap', ['<%=memo %>', 0, '我的日程安排', '1735787462@qq.com']],
    ['_RedrawCheckboxes'],
    ['ap', ['<%=memo %>', 0, '我的日程安排', '1735787462@qq.com', '<%=memo %>', 2, '我的日程安排', '1735787462@qq.com']],
 ['sb', '<%=memo %>', 1, 3, 600],
 ['_DS_SetPublicID', 'X19wdWJsaWNfcHJpbmNpcGFsX19AcHVibGljLmNhbGVuZGFyLmdvb2dsZS5jb20'],
 ['_AddNewPerson', '我的日程安排', '<%=memo %>', '1', 'true'],
 ['_AddNewPerson', '我的日程安排', '<%=memo %>', '2', 'true']];

    var rt_extraDispatches = [];

    try {
        var startTime = "20100119", startMode = "month";
        _renderMain(rt_promo, rt_clientDispatches, rt_eventDispatches, rt_esDispatches,
          rt_extraDispatches, null, startMode, !_ol_serve_ol);
    } catch (ex) {
        rt_clientDispatches = rt_eventDispatches = rt_esDispatches =
          rt_extraDispatches = null;
    }
    _renderPost();
};
renderBody();
</script>
</body>
<script type="text/javascript">
    postRender();
</script>
</html>

