﻿function aa(a){throw a;}
/** 一些变量，把这些关键字压缩为1位和2位字母变量是为了节省网络流量，
 * google为了性能真是煞费苦心，大家可以体会一下 
 * 当然他们开发人员手上的源文件肯定不是这样的，呵呵，
 * 这个是经过程序编译，压缩后生成的，所以可读性很差，大家将就把，花点功夫也不难看懂
 */
var g=true,i=null,j=false,ba=encodeURIComponent,ca=Number,da=Object,ea=alert,fa=_ol_enabled,ha=_enableBgImages,ia=Boolean,ja=_loadStartTime,ka=parseInt,la=parseFloat,ma=String,na=setTimeout,oa=decodeURIComponent,pa=isNaN,l=Math;
/** 以下函数很明显是给a类添加一个方法，此方法的实现是b函数(参数：a是一个类b是一个函数) */
function qa(a,b){return a.scrollTop=b}
function ra(a,b){return a.stop=b}
function sa(a,b){return a.toString=b}
function ta(a,b){return a.getMonth=b}
function ua(a,b){return a.onreadystatechange=b}
function va(a,b){return a.length=b}
function wa(a,b){return a.position=b}
function xa(a,b){return a.className=b}
function ya(a,b){return a.width=b}
function za(a,b){return a.collapse=b}
function Aa(a,b){return a.data=b}
function Ba(a,b){return a.load=b}
function m(a,b){return a.innerHTML=b}
function Ca(a,b){return a.onerror=b}
function Da(a,b){return a.value=b}
function Ea(a,b){return a.location=b}
function Fa(a,b){return a.disabled=b}
function Ga(a,b){return a.color=b}
function Ha(a,b){return a.currentTarget=b}
function Ja(a,b){return a.backgroundColor=b}
function Ka(a,b){return a.left=b}
function Ma(a,b){return a.textDecoration=b}
function Na(a,b){return a.target=b}
function Oa(a,b){return a.screenX=b}
function Pa(a,b){return a.screenY=b}
function Qa(a,b){return a.send=b}
function Ra(a,b){return a.remove=b}
function Sa(a,b){return a.start=b}
function Ta(a,b){return a.focus=b}
function Ua(a,b){return a.cssText=b}
function Va(a,b){return a.keyCode=b}
function Wa(a,b){return a.forEach=b}
function Xa(a,b){return a.enabled=b}
function Ya(a,b){return a.bottom=b}
function Za(a,b){return a.href=b}
function $a(a,b){return a.handleEvent=b}
function ab(a,b){return a.removeNode=b}
function bb(a,b){return a.type=b}
function cb(a,b){return a.contains=b}
function db(a,b){return a.tabIndex=b}
function eb(a,b){return a.method=b}
function fb(a,b){return a.onmousedown=b}
function gb(a,b){return a.name=b}
function hb(a,b){return a.overflow=b}
function ib(a,b){return a.display=b}
function jb(a,b){return a.height=b}
function kb(a,b){return a.borderColor=b}
function lb(a,b){return a.clientX=b}
function mb(a,b){return a.clientY=b}
function nb(a,b){return a.right=b}
function ob(a,b){return a.visibility=b}
/** 同样是一些变量，压缩后变为1到2个字母的变量，节省流量 */
var n="appendChild",pb="scrollTop",o="push",qb="stop",q="toString",rb="altKey",s="length",sb="propertyIsEnumerable",tb="version",ub="open",v="prototype",vb="test",wb="shift",xb="relatedTarget",yb="className",zb="clearTimeout",Ab="exec",Cb="width",Db="clientWidth",Eb="getBool",Fb="round",Ib="slice",Jb="setTimeout",w="replace",Kb="nodeType",Lb="document",Mb="ceil",Nb="ctrlKey",Ob="split",Pb="floor",Qb="responseText",Rb="getUTCDate",Sb="getElementById",Tb="innerHTML",Ub="offsetWidth",Vb="offsetParent",
Wb="concat",Xb="constructor",Yb="setInterval",Zb="charAt",$b="blur",ac="createTextNode",bc="stopPropagation",cc="getData",z="value",dc="location",ec="preventDefault",fc="item",gc="insertBefore",hc="button",ic="indexOf",jc="metaKey",kc="offsetLeft",lc="color",mc="hasOwnProperty",nc="compareDocumentPosition",A="dispatchEvent",B="style",oc="capture",pc="close",qc="nodeName",rc="body",sc="left",tc="write",uc="getResponseHeader",vc="ownerDocument",wc="removeChild",C="target",xc="setRequestHeader",yc="screenX",
zc="screenY",Cc="lastChild",E="call",Dc="match",Ec="status",Fc="getBoxObjectFor",Gc="send",Hc="innerHeight",Ic="readyState",Jc="charCode",Kc="remove",Lc="some",F="start",Mc="lastIndexOf",Nc="random",Oc="focus",Pc="createElement",Qc="keyCode",G="firstChild",Rc="getFullYear",Sc="forEach",Tc="enabled",Uc="colSpan",Vc="clientHeight",Wc="charCodeAt",Xc="sort",Yc="bottom",Zc="setAttribute",$c="href",I="substring",ad="handleEvent",bd="removeNode",cd="clearInterval",dd="rows",K="type",ed="contains",fd="apply",
gd="method",hd="childNodes",id="shiftKey",jd="refresh",kd="name",L="parentNode",ld="display",md="nextSibling",nd="offsetTop",od="height",pd="toUpperCase",qd="splice",rd="getTime",sd="offsetHeight",M="join",td="unshift",ud="getElementsByTagName",vd="execScript",wd="nodeValue",xd="toLowerCase",yd="frames",zd="clientX",Ad="clientY",Bd="documentElement",Cd="substr",Dd="right",Ed="event",N,Fd=[];
/**
 * Fd为一数组(成员都为函数) a参数为函数名或数字 
 * 用apply执行此函数 Pd[a].apply(this, arguments) 
 */
function Gd(a){
	return function(){
		return Fd[a][fd](this, arguments)
	}
}
window._Messages=[][Wb](window._Messages||[],{SEARCHING_FOR_MORE_MATCHES:"\u6b63\u5728\u641c\u7d22\u66f4\u591a\u4e0e <b>...</b> \u5339\u914d\u7684\u5185\u5bb9",SEARCHING_FOR_MATCHES:"\u6b63\u5728\u641c\u7d22\u4e0e <b>...</b> \u5339\u914d\u7684\u5185\u5bb9",AND_OTHERS:"\u4ee5\u53ca {$count} \u4e2a\u5176\u4ed6\u6210\u5458..."});
/** 显示a之后的活动 */
function Hd(a){return"\u663e\u793a "+a+"\u4e4b\u540e\u7684\u6d3b\u52a8"}
/** 显示a之前的活动 */
function Id(a){return"\u663e\u793a "+a+"\u4e4b\u524d\u7684\u6d3b\u52a8"}
/** a天前 */
function Jd(a){return a+" \u5929\u524d"}
/** a小时前 */
function Kd(a){return a+" \u5c0f\u65f6\u524d"}
/** a分钟前 */
function Ld(a){return a+" \u5206\u949f\u524d"}
/** 参与者：a */
function Nd(a){return"\u53c2\u4e0e\u8005\uff1a"+a}
/** 地点：a */
function Od(a){return"\u5730\u70b9\uff1a"+a}
/** 时间：a */
function Pd(a){return"\u65f6\u95f4\uff1a"+a}
/** a的搜索结果 */
function Qd(a){return a+"\u7684\u641c\u7d22\u7ed3\u679c"}
/** 在b上a的搜索结果 */
function Rd(a,b){return"\u5728"+b+" \u4e0a"+a+" \u7684\u641c\u7d22\u7ed3\u679c"}
/** 尝试指定更多a */
function Sd(a){return"\u5c1d\u8bd5\u6307\u5b9a\u66f4\u591a"+a}
/** 发现a个活动 */
function Td(a){return"\u53d1\u73b0 "+a+" \u4e2a\u6d3b\u52a8"}
/** a天 */
function Ud(a){return a+" \u5929"}
/** a小时 */
function Vd(a){return a+" \u5c0f\u65f6"}
/** a分钟 */
function Wd(a){return a+" \u5206\u949f"}
/** a-b */
function Xd(a,b){return a+" \u2013 "+b}
/** a月b日 */
function Yd(a,b){return a+"\u6708 "+b+"\u65e5"}
/** c年a月b日 */
function Zd(a,b,c){return c+"\u5e74"+a+"\u6708"+b+"\u65e5"}
/** b年a月 */
function $d(a,b){return b+"\u5e74"+a+"\u6708"}
var ae=")";
function be(a,b){return b+" ("+a+ae}
var O="",ce="0",de=":";
/**
 * 显示时钟格式：00:00/01:00/17:00 等
 * @param {Object} a 小时数
 * @param {Object} b 分钟数
 */
function ee(a, b){
	a = pa(a) ? "??" : O + a;
	if (a[s] < 2) 
		a = ce + a;//左补齐"0"
	b = !pa(b) ? (b < 10 ? ce : O) + b : "??";
	return a + de + b
}
/** 
 * 显示时钟格式：上午1:20/下午18:30 等
 * @param {Object} a 小时数
 * @param {Object} b 分钟数
 */
function fe(a, b){
	var c = a < 12 ? "\u4e0a\u5348" : "\u4e0b\u5348";
	a = pa(a) ? "??" : O + (a % 12 || 12);
	b = !pa(b) ? (b < 10 ? ce : O) + b : "??";
	return c + O + a + de + b
}
/**
 * 显示时钟格式：上午1点/下午5点 等
 * @param {Object} a 小时数
 */
function ge(a){
	var b = a < 12 ? "\u4e0a\u5348" : "\u4e0b\u5348";
	a = pa(a) ? "??" : O + (a % 12 || 12);
	return b + O + a + "\u70b9"
}
/**
 * 显示时钟格式：11:20/下午12:20
 * @param {Object} a 小时数
 * @param {Object} b 分钟数
 */
function he(a, b){
	var c = a < 12 ? O : "\u4e0b\u5348";
	a = pa(a) ? "??" : O + (a % 12 || 12);
	b = !pa(b) ? (b < 10 ? ce : O) + b : "??";
	return c + O + a + de + b
}
/**
 * 显示时钟格式：11点/下午12点
 * @param {Object} a 小时数
 */
function ie(a){
	var b = a < 12 ? O : "\u4e0b\u5348";
	a = pa(a) ? "??" : O + (a % 12 || 12);
	return b + O + a + "\u70b9"
};
var je=je||{},ke=this,le=i;
function me(a, b, c){
	a = a[Ob](".");
	c = c || ke;
	!(a[0] in c) && c[vd] && c[vd]("var " + a[0]);
	for (var d; a[s] && (d = a[wb]());) 
		if (!a[s] && ne(b)) 
			c[d] = b;
		else 
			c = c[d] ? c[d] : (c[d] = {})
}
/** 在this中寻找a参数的函数并返回若无则返回null */
function oe(a, b){
	a = a[Ob](".");
	b = b || ke;
	for (var c; c = a[wb]();) 
		if (b[c]) 
			b = b[c];
		else 
			return i;
	return b
}
/** 一个空函数 */
function pe(){}
/** 给参数a添加A方法(此方法返回a.rT) a.WI=new a */
function qe(a){
	a.A = function(){
		return a.rT || (a.rT = new a)
	}
}
var re="number",se="function";
/** 返回参数a的类型object/function/array/null/其他 */
function te(a){
	var b = typeof a;
	if (b == "object") 
		if (a) {
			if (a instanceof Array || !(a instanceof da) && da[v][q][E](a) == "[object Array]" || typeof a[s] == re && typeof a[qd] != "undefined" && typeof a[sb] != "undefined" && !a[sb]("splice")) 
				return "array";
			if (!(a instanceof da) && (da[v][q][E](a) == "[object Function]" || typeof a[E] != "undefined" && typeof a[sb] != "undefined" && !a[sb]("call"))) 
				return se
		}
		else 
			return "null";
	else 
		if (b == se && typeof a[E] == "undefined") 
			return "object";
	return b
}
/** 检查a是否为undefined */
function ne(a){return a!==undefined}
function ue(a){return ne(a)&&!(a===i)}
/** 判断参数a类型是否为array */
function ve(a){return te(a)=="array"}
function we(a){var b=te(a);return b=="array"||b=="object"&&typeof a[s]==re}
var xe="string";
/** 检查a是否为string */
function ye(a){return typeof a==xe}
/** 判断参数a类型是否为function */
function ze(a){return te(a)==se}
function Ae(a){a=te(a);return a=="object"||a=="array"||a==se}
function Be(a){if(a[mc]&&a[mc](Ce))return a[Ce];a[Ce]||(a[Ce]=++De);return a[Ce]}
var Ce="closure_hashCode_"+l[Pb](l[Nc]()*2147483648)[q](36),De=0;
/** 若是a有bb属性则运行然后重组属性后返回 */
function Ee(a){
	var b = te(a);
	if (b == "object" || b == "array") {
		if (a.bb) 
			return a.bb[E](a);
		b = b == "array" ? [] : {};
		for (var c in a) 
			b[c] = Ee(a[c]);//递归
		return b
	}
	return a
}
function P(a, b){
	var c = a.hO;
	if (arguments[s] > 2) {
		var d = Array[v][Ib][E](arguments, 2);
		c && d[td][fd](d, c);
		c = d
	}
	b = a.kO || b;
	a = a.jO || a;
	var e = b || ke;
	d = c ? function(){
		var f = Array[v][Ib][E](arguments);
		f[td][fd](f, c);
		return a[fd](e, f)
	}
 : function(){
		return a[fd](e, arguments)
	};
	d.hO = c;
	d.kO = b;
	d.jO = a;
	return d
}
/** 把arguments放入数组 然后func.apply(func1,[var1,var2,var3])调用 */
function Fe(a){
	var b = Array[v][Ib][E](arguments, 1);//Array.prototype.slice.call 相当于 [].slice 但是效率比后者高
	b[td](a, i);//Array.unshift(a,i)从数组开头添加a,i
	return P[fd](i, b)//func.call(func1,var1,var2,var3)对应func.apply(func1,[var1,var2,var3])
}
/** 返回当前时间(1970.1.1至今的毫秒数) */
var Ge=Date.now||function(){return(new Date)[rd]()};
/** 参数a类 继承 参数b类 */
function Q(a, b){
	function c(){
	}
	c.prototype = b[v];
	a.l = b[v];
	a.prototype = new c;
	a[v].constructor = a
}
/** 为function添加方法Ex */
Function[v].Ex = function(a){
	if (arguments[s] > 1) {
		var b = Array[v][Ib][E](arguments, 1);
		b[td](this, a);
		return P[fd](i, b)
	}
	else 
		return P(this, a)
};
var He={uk:j,Cm:j,jg:g,YD:O},Ie={uk:g,Cm:g,jg:j,YD:"-offline"},Je=_ol_serve_ol?Ie:He;//_ol_serve_ol是否脱机运行
function Ke(a,b){return a[ic](b)==0}
/** 把\s\xa0替换为空格 */
function Le(a){return a[w](/^[\s\xa0]+|[\s\xa0]+$/g,O)}
function Me(a,b){a=ma(a)[xd]();b=ma(b)[xd]();return a<b?-1:a==b?0:1}
var Ne="&",Oe="<",Pe=">",Qe='"';
/** 把&<>"替换为html编码 */
function R(a, b){
	if (b) 
		return a[w](Re, "&amp;")[w](Se, "&lt;")[w](Te, "&gt;")[w](Ue, "&quot;");
	else {
		if (!Ve[vb](a)) 
			return a;
		if (a[ic](Ne) != -1) 
			a = a[w](Re, "&amp;");
		if (a[ic](Oe) != -1) 
			a = a[w](Se, "&lt;");
		if (a[ic](Pe) != -1) 
			a = a[w](Te, "&gt;");
		if (a[ic](Qe) != -1) 
			a = a[w](Ue, "&quot;");
		return a
	}
}
var Re=/&/g,Se=/</g,Te=/>/g,Ue=/\"/g,Ve=/[&<>\"]/;
function We(a,b){return a[ic](b)!=-1}
/** Array.prototype.join.call(arguments,"") */
function Xe(){return Array[v][M][E](arguments,O)}
/** 判断a和b大小:a<b返回-1|a>b返回1|a=b返回0 */
function Ye(a, b){
	var c = 0;
	a = Le(ma(a))[Ob](".");
	b = Le(ma(b))[Ob](".");
	for (var d = l.max(a[s], b[s]), e = 0; c == 0 && e < d; e++) {
		var f = a[e] || O, h = b[e] || O, k = new RegExp("(\\d*)(\\D*)", "g"), p = new RegExp("(\\d*)(\\D*)", "g");
		do {
			var r = k[Ab](f) || [O, O, O], t = p[Ab](h) || [O, O, O];
			if (r[0][s] == 0 && t[0][s] == 0) 
				break;
			c = r[1][s] == 0 ? 0 : ka(r[1], 10);
			var u = t[1][s] == 0 ? 0 : ka(t[1], 10);
			c = Ze(c, u) || Ze(r[2][s] == 0, t[2][s] == 0) || Ze(r[2], t[2])
		}
		while (c == 0)
	}
	return c
}
/** 判断a和b大小:a<b返回-1|a>b返回1|a=b返回0 */
function Ze(a, b){
	if (a < b) 
		return -1;
	else 
		if (a > b) 
			return 1;
	return 0
}
var $e=Ge();
function af(a){a===i||!ne(a)};
/** 换行相关正则 */
var bf=new RegExp(O+["[\\\\'\r\n\u0008\"<>&\u0085\u2028\u2029]"],"g");
function cf(a){return df[a]}
var df;
/** 把\'"<>&换行符等替换为相应代码 */
function ef(a){
	if (!df) {
		var b = {};
		b["\\"] = "\\\\";
		b["'"] = "\\047";
		b["\u0008"] = "\\b";//匹配一个字边界，即字与空格间的位置
		b[Qe] = "\\042";
		b[Oe] = "\\074";
		b[Pe] = "\\076";
		b[Ne] = "\\046";
		b["\n"] = "\\n";
		b["\r"] = "\\r";
		b["\u0085"] = "\\205";//next line
		b["\u2028"] = "\\u2028";//line separate
		b["\u2029"] = "\\u2029";//paragraph separate
		df = b
	}
	return "'" + a[q]()[w](bf, cf) + "'"
}
var ff;
ff = "".localeCompare ? function(a, b){
	return a[xd]().localeCompare(b[xd]())
}
 : function(a, b){
	a = a[xd]();
	b = b[xd]();
	return a < b ? -1 : a === b ? 0 : 1
};
/** 匹配function名称 */
var gf=/\W*function\s+([\w\$]+)\(/,hf="name";
/** 为a添加name属性 若是此属性为this.document.documentElement则返回window.a.name 不然则直接返回a.name */
function S(a){
	if (!(hf in a)) {//a是否包含name属性
		var b = gf[Ab](a);
		gb(a, b[1])//添加a.name属性
	}
	a = a[kd];
	return ke[Lb] && a in ke[Lb][Bd] ? "window." + a : a
}
var jf=Ge();
function kf(a,b,c){
	if (a[ic]) {
		return a[ic](b, c);
	}
	if (Array[ic]) {
		return Array[ic](a, b, c);
	}
	for(c=c==i?0:c<0?l.max(0,a[s]+c):c;c<a[s];c++)
	{
		if (c in a && a[c] === b) {
			return c;
		}
	}
	return-1;
}
function lf(a, b, c){
	if (a[Sc]) 
		a[Sc](b, c);
	else 
		if (Array[Sc]) 
			Array[Sc](a, b, c);
		else 
			for (var d = a[s], e = ye(a) ? a[Ob](O) : a, f = 0; f < d; f++) 
				f in e && b[E](c, e[f], f, a)
}
function mf(a, b, c){
	if (a.map) 
		return a.map(b, c);
	if (Array.map) 
		return Array.map(a, b, c);
	for (var d = a[s], e = [], f = 0, h = ye(a) ? a[Ob](O) : a, k = 0; k < d; k++) 
		if (k in h) 
			e[f++] = b[E](c, h[k], k, a);
	return e
}
function nf(a, b, c){
	if (a[Lc]) 
		return a[Lc](b, c);
	if (Array[Lc]) 
		return Array[Lc](a, b, c);
	for (var d = a[s], e = ye(a) ? a[Ob](O) : a, f = 0; f < d; f++) 
		if (f in e && b[E](c, e[f], f, a)) 
			return g;
	return j
}
/** 判断b是否包含在a中 */
function of(a, b){
	if (a[ed]) 
		return a[ed](b);
	return kf(a, b) > -1
}
function pf(a,b){b=kf(a,b);var c;if(c=b!=-1)qf(a,b);return c}
function qf(a,b){return Array[v][qd][E](a,b,1)[s]==1}
function rf(a){
	if (ve(a)) 
		return a[Wb]();
	else {
		for (var b = [], c = 0, d = a[s]; c < d; c++) 
			b[c] = a[c];
		return b
	}
}
function sf(a){return Array[v][qd][fd](a,tf(arguments,1))}
/** Array.prototype.slice.call(Array,start,end) */
function tf(a, b, c){
	return arguments[s] <= 2 ? Array[v][Ib][E](a, b) : Array[v][Ib][E](a, b, c)
}
function uf(a,b){for(var c=[],d=0;d<b;d++)c[d]=a;return c}
function vf(){for(var a=[],b=0;b<arguments[s];b++){var c=arguments[b];ve(c)?a[o][fd](a,vf[fd](i,c)):a[o](c)}return a};
function wf(a,b,c){for(var d in a)b[E](c,a[d],d,a)}
function xf(a){var b=[],c=0;for(var d in a)b[c++]=d;return b}
/** 若a数组为空返回true否则返回false */
function yf(a){
	for (var b in a) 
		return j;
	return g
}
var zf=["constructor","hasOwnProperty","isPrototypeOf","propertyIsEnumerable","toLocaleString","toString","valueOf"];
function Af(a){
	for (var b, c, d = 1; d < arguments[s]; d++) {
		c = arguments[d];
		for (b in c) 
			a[b] = c[b];
		for (var e = 0; e < zf[s]; e++) {
			b = zf[e];
			if (da[v][mc][E](c, b)) 
				a[b] = c[b]
		}
	}
}
function Bf(){
	var a = arguments[s];
	if (a == 1 && ve(arguments[0])) 
		return Bf[fd](i, arguments[0]);
	if (a % 2) 
		aa(Error("Uneven number of arguments"));
	for (var b = {}, c = 0; c < a; c += 2) 
		b[arguments[c]] = arguments[c + 1];
	return b
}
function Cf(){
	var a = arguments[s];
	if (a == 1 && ve(arguments[0])) 
		return Cf[fd](i, arguments[0]);
	for (var b = {}, c = 0; c < a; c++) 
		b[arguments[c]] = g;
	return b
};
function Df(){}
N=Df[v];
N.tg=j;
N.Oj=Gd(45);
N.EQ=Df[v].Oj;
N.G=function(){if(!this.tg){this.tg=g;this.C()}};
N.C=function(){};
function Ef(a, b){
	Df[E](this);
	this.Gl = b;
	this.fd = [];
	if (a > this.Gl) 
		aa(Error("[goog.structs.SimplePool] Initial cannot be greater than max"));
	for (b = 0; b < a; b++) 
		this.fd[o](this.Zm())
}
Q(Ef,Df);
N=Ef[v];
N.Mk=i;
N.Ct=i;
N.oe = function(){
	if (this.fd[s]) 
		return this.fd.pop();
	return this.Zm()
};//出栈
N.pf = function(a){
	this.fd[s] < this.Gl ? this.fd[o](a) : this.oj(a)
};//压栈
N.Zm=function(){return this.Mk?this.Mk():{}};
N.oj = function(a){
	if (this.Ct) 
		this.Ct(a);
	else 
		if (ze(a.G)) 
			a.G();
		else 
			for (var b in a) 
				delete a[b]
};//运行a.G()并清空a
N.C = function(){
	Ef.l.C[E](this);
	for (var a = this.fd; a[s];) 
		this.oj(a.pop());
	delete this.fd
};//清空this.fd
var Ff,Gf,Hf,If,Jf,Kf,Lf,Mf,Nf,Of;
/** 返回用户浏览器类型否则返回null */
function Pf(){
	return ke.navigator ? ke.navigator.userAgent : i
}
function Qf(){return ke.navigator}
(function(){
	Kf = Jf = If = Hf = Gf = Ff = j;
	var a;
	if (a = Pf()) {//浏览器类型版本
		var b = Qf();
		Ff = a[ic]("Opera") == 0;
		Gf = !Ff && a[ic]("MSIE") != -1;
		If = (Hf = !Ff && a[ic]("WebKit") != -1) && a[ic]("Mobile") != -1;
		Kf = (Jf = !Ff && !Hf && b.product == "Gecko") && b.vendor == "Camino"
	}
})();
var Rf=Ff,T=Gf,Sf=Jf,Tf=Hf,Uf=If,Vf=function(){var a = Qf();return a && a.platform || O}();
(function(){//平台类型
	Lf = We(Vf, "Mac");
	Mf = We(Vf, "Win");
	Nf = We(Vf, "Linux");
	Of = !!Qf() && We(Qf().appVersion || O, "X11")
})();
var Wf=Lf,Xf=Of,Yf=function(){var a=O,b;if(Rf&&ke.opera){a=ke.opera[tb];a=typeof a==se?a():a}else{if(Sf)b=/rv\:([^\);]+)(\)|;)/;else if(T)b=/MSIE\s+([^\);]+)(\)|;)/;else if(Tf)b=/WebKit\/(\S+)/;if(b)a=(a=b[Ab](Pf()))?a[1]:O}return a}(),Zf={};function $f(a){return Zf[a]||(Zf[a]=Ye(Yf,a)>=0)};function U(a,b){bb(this,a);Na(this,b);Ha(this,this[C])}Q(U,Df);N=U[v];N.C=function(){delete this[K];delete this[C];delete this.currentTarget};N.bk=j;N.Eo=g;N.stopPropagation=function(){this.bk=g};N.preventDefault=function(){this.Eo=j};
/**
 * ag(U的子类)
 * @param {Object} a
 * @param {Object} b
 */
function ag(a, b){
	a && this.yd(a, b)
}
Q(ag,U);
N=ag[v];
bb(N,i);
Na(N,i);
N.relatedTarget=i;
N.offsetX=0;
N.offsetY=0;
lb(N,0);
mb(N,0);
Oa(N,0);
Pa(N,0);
N.button=0;
Va(N,0);//ie使用keycode
N.charCode=0;//ff等浏览器使用charcode
N.ctrlKey=j;
N.altKey=j;
N.shiftKey=j;
N.metaKey=j;
N.Ra=i;
N.yd = function(a, b){
	bb(this, a[K]);
	Na(this, a[C] || a.srcElement);
	Ha(this, b);//currenttarget监听事件触发的对象
	this.relatedTarget = a[xb] ? a[xb] : this[K] == "mouseover" ? a.fromElement : this[K] == "mouseout" ? a.toElement : i;//得到触发事件对象的相关对象
	this.offsetX = typeof a.layerX == re ? a.layerX : a.offsetX;//ff浏览器使用layerx ie浏览器使用offsetx
	this.offsetY = typeof a.layerY == re ? a.layerY : a.offsetY;//同上
	lb(this, typeof a[zd] == re ? a[zd] : a.pageX);//ie使用clientx ff使用pagex
	mb(this, typeof a[Ad] == re ? a[Ad] : a.pageY);//同上
	Oa(this, a[yc] || 0);
	Pa(this, a[zc] || 0);
	this.button = a[hc];
	Va(this, a[Qc] || 0);
	this.charCode = a[Jc] || (this[K] == "keypress" ? a[Qc] : 0);
	this.ctrlKey = a[Nb];
	this.altKey = a[rb];
	this.shiftKey = a[id];
	this.metaKey = a[jc];
	this.Ra = a;
	delete this.Eo;
	delete this.bk
};
/** 是否阻止事件传播 */
N.stopPropagation = function(){
	this.bk = g;
	if (this.Ra[bc]) 
		this.Ra[bc]();
	else 
		this.Ra.cancelBubble = g
};
/** 是否阻止事件默认动作 */
N.preventDefault = function(){
	this.Eo = j;
	if (this.Ra[ec]) 
		this.Ra[ec]();
	else {
		this.Ra.returnValue = j;
		try {
			Va(this.Ra, -1)
		} 
		catch (a) {
		}
	}
};
N.pH=Gd(4);
N.C=function(){ag.l.C[E](this);this.Ra=i};
function bg(){}
var cg=0;
N=bg[v];N.wA=i;N.qe=i;N.za=i;N.src=i;bb(N,i);N.capture=i;N.Jq=i;N.Ad=0;N.Ah=j;N.Px=j;
N.yd = function(a, b, c, d, e, f){
	if (ze(a)) 
		this.wA = g;
	else 
		if (a && a[ad] && ze(a[ad])) 
			this.wA = j;
		else 
			aa(Error("Invalid listener argument"));
	this.qe = a;
	this.za = b;
	this.src = c;
	bb(this, d);
	this.capture = !!e;//采用capture方式:parent->child或者bubble方式:child->parent
	this.Jq = f;
	this.Px = j;
	this.Ad = ++cg;
	this.Ah = j
};
$a(N,function(a){if(this.wA)return this.qe[E](this.Jq||this.src,a);return this.qe[ad][E](this.qe,a)});
var dg={},eg={},fg={},gg=new Ef(0,600);
gg.Mk=function(){return{cb:0,Ng:0}};
gg.Ct=function(a){a.cb=0};
var hg=new Ef(0,600);
hg.Mk=function(){return[]};
hg.Ct = function(a){
	va(a, 0);
	delete a.hr;
	delete a.BB
};
var ig=new Ef(0,600);
ig.Mk=function(){function a(b){return jg[E](a.src,a.Ad,b)}return a};
function kg(){return new bg}
var lg=new Ef(0,600);
lg.Mk=kg;
function mg(){return new ag}
var ng=function(){var a=i;if(T){a=new Ef(0,600);a.Mk=mg}return a}(),og={};
/** 添加事件监听 */
function pg(a, b, c, d, e){
	if (b) 
		if (ve(b)) {//判断b是否为array
			for (var f = 0; f < b[s]; f++) 
				pg(a, b[f], c, d, e);//递归调用
			return i
		}
		else {
			d = !!d;
			var h = eg;
			b in h || (h[b] = gg.oe());
			h = h[b];
			if (!(d in h)) {
				h[d] = gg.oe();
				h.cb++
			}
			h = h[d];
			var k = Be(a), p;
			h.Ng++;
			if (h[k]) {
				p = h[k];
				for (f = 0; f < p[s]; f++) {
					h = p[f];
					if (h.qe == c && h.Jq == e) {
						if (h.Ah) 
							break;
						return p[f].Ad
					}
				}
			}
			else {
				p = h[k] = hg.oe();
				h.cb++
			}
			f = ig.oe();
			f.src = a;
			h = lg.oe();
			h.yd(c, f, a, b, d, e);
			c = h.Ad;
			f.Ad = c;
			p[o](h);
			dg[c] = h;
			fg[k] || (fg[k] = hg.oe());
			fg[k][o](h);
			if (a.addEventListener) {//一般浏览器使用
				if (a == ke || !a.aG) 
					a.addEventListener(b, f, d)
			}
			else 
				a.attachEvent(qg(b), f);//IE浏览器使用
			return c
		}
	else 
		aa(Error("Invalid event type"))
}
function rg(a, b, c, d, e){
	if (ve(b)) {
		for (var f = 0; f < b[s]; f++) 
			rg(a, b[f], c, d, e);
		return i
	}
	a = pg(a, b, c, d, e);
	dg[a].Px = g;
	return a
}
/** 移除事件监听 */
function sg(a, b, c, d, e){
	if (ve(b)) {
		for (var f = 0; f < b[s]; f++) 
			sg(a, b[f], c, d, e);//递归调用
		return i
	}
	d = !!d;
	a = tg(a, b, d);
	if (!a) 
		return j;
	for (f = 0; f < a[s]; f++) 
		if (a[f].qe == c && a[f][oc] == d && a[f].Jq == e) 
			return ug(a[f].Ad);
	return j
}
/** 移除事件监听 */
function ug(a){
	if (!dg[a]) 
		return j;
	var b = dg[a];
	if (b.Ah) 
		return j;
	var c = b.src, d = b[K], e = b.za, f = b[oc];
	if (c.removeEventListener) {
		if (c == ke || !c.aG) 
			c.removeEventListener(d, e, f)
	}
	else 
		c.detachEvent && c.detachEvent(qg(d), e);
	c = Be(c);
	e = eg[d][f][c];
	if (fg[c]) {
		var h = fg[c];
		pf(h, b);
		h[s] == 0 && delete fg[c]
	}
	b.Ah = g;
	e.BB = g;
	vg(d, f, c, e);
	delete dg[a];
	return g
}
function vg(a, b, c, d){
	if (!d.hr) 
		if (d.BB) {
			for (var e = 0, f = 0; e < d[s]; e++) 
				if (d[e].Ah) 
					lg.pf(d[e]);
				else {
					if (e != f) 
						d[f] = d[e];
					f++
				}
			va(d, f);
			d.BB = j;
			if (f == 0) {
				hg.pf(d);
				delete eg[a][b][c];
				eg[a][b].cb--;
				if (eg[a][b].cb == 0) {
					gg.pf(eg[a][b]);
					delete eg[a][b];
					eg[a].cb--
				}
				if (eg[a].cb == 0) {
					gg.pf(eg[a]);
					delete eg[a]
				}
			}
		}
}
function wg(a, b, c){
	var d = 0, e = a == i, f = b == i, h = c == i;
	c = !!c;
	if (e) 
		wf(fg, function(p){
			for (var r = p[s] - 1; r >= 0; r--) {
				var t = p[r];
				if ((f || b == t[K]) && (h || c == t[oc])) {
					ug(t.Ad);
					d++
				}
			}
		});
	else {
		a = Be(a);
		if (fg[a]) {
			a = fg[a];
			for (e = a[s] - 1; e >= 0; e--) {
				var k = a[e];
				if ((f || b == k[K]) && (h || c == k[oc])) {
					ug(k.Ad);
					d++
				}
			}
		}
	}
	return d
}
function tg(a, b, c){
	var d = eg;
	if (b in d) {
		d = d[b];
		if (c in d) {
			d = d[c];
			a = Be(a);
			if (d[a]) 
				return d[a]
		}
	}
	return i
}
/** 给a事件添加'on'前缀 */
function qg(a){
	if (a in og) 
		return og[a];
	return og[a] = "on" + a
}
function xg(a, b, c, d, e){
	var f = 1;
	b = Be(b);
	if (a[b]) {
		a.Ng--;
		a = a[b];
		if (a.hr) 
			a.hr++;
		else 
			a.hr = 1;
		try {
			for (var h = a[s], k = 0; k < h; k++) {
				var p = a[k];
				if (p && !p.Ah) 
					f &= yg(p, e) !== j
			}
		}
		finally {
			a.hr--;
			vg(c, d, b, a)
		}
	}
	return ia(f)
}
function yg(a, b){
	b = a[ad](b);
	a.Px && ug(a.Ad);
	return b
}
function jg(a, b){
	if (!dg[a]) 
		return g;
	a = dg[a];
	var c = a[K], d = eg;
	if (!(c in d)) 
		return g;
	d = d[c];
	var e, f;
	if (T) {
		e = b || oe("window.event");
		b = g in d;
		var h = j in d;
		if (b) {
			if (e[Qc] < 0 || e.returnValue != undefined) 
				return g;
			a: {
				var k = j;
				if (e[Qc] == 0) 
					try {
						Va(e, -1);
						break a
					} 
					catch (p) {
						k = g
					}
				if (k || e.returnValue == undefined) 
					e.returnValue = g
			}
		}
		k = ng.oe();
		k.yd(e, this);
		e = g;
		try {
			if (b) {
				for (var r = hg.oe(), t = k.currentTarget; t; t = t[L]) 
					r[o](t);
				f = d[g];
				f.Ng = f.cb;
				for (var u = r[s] - 1; !k.bk && u >= 0 && f.Ng; u--) {
					Ha(k, r[u]);
					e &= xg(f, r[u], c, g, k)
				}
				if (h) {
					f = d[j];
					f.Ng = f.cb;
					for (u = 0; !k.bk && u < r[s] && f.Ng; u++) {
						Ha(k, r[u]);
						e &= xg(f, r[u], c, j, k)
					}
				}
			}
			else 
				e = yg(a, k)
		}
		finally {
			if (r) {
				va(r, 0);
				hg.pf(r)
			}
			k.G();
			ng.pf(k)
		}
		return e
	}
	f = new ag(b, this);
	try {
		e = yg(a, f)
	}
	finally {
		f.G()
	}
	return e
};
/** 继承 Df 的一个子类 添加事件监听/移除事件监听/执行事件 */
function V(){}
Q(V,Df);
N=V[v];
N.aG=g;
N.aC=i;
N.Cz=function(){return this.aC};
N.zw=Gd(50);
N.addEventListener=function(a,b,c,d){pg(this,a,b,c,d)};
N.removeEventListener=function(a,b,c,d){sg(this,a,b,c,d)};
N.dispatchEvent = function(a){
	{
		a = a;
		if (ye(a)) 
			a = new U(a, this);
		else 
			if (a instanceof U) 
				Na(a, a[C] || this);
			else {
				var b = a;
				a = new U(a[K], this);
				Af(a, b)
			}
		b = 1;
		var c, d = a[K], e = eg;
		if (d in e) {
			e = e[d];
			d = g in e;
			var f;
			if (d) {
				c = [];
				for (f = this; f; f = f.Cz()) 
					c[o](f);
				f = e[g];
				f.Ng = f.cb;
				for (var h = c[s] - 1; !a.bk && h >= 0 && f.Ng; h--) {
					Ha(a, c[h]);
					b &= xg(f, c[h], a[K], g, a) && a.Eo != j
				}
			}
			if (j in e) {
				f = e[j];
				f.Ng = f.cb;
				if (d) 
					for (h = 0; !a.bk && h < c[s] && f.Ng; h++) {
						Ha(a, c[h]);
						b &= xg(f, c[h], a[K], j, a) && a.Eo != j
					}
				else 
					for (c = this; !a.bk && c && f.Ng; c = c.Cz()) {
						Ha(a, c);
						b &= xg(f, c, a[K], j, a) &&
						a.Eo != j
					}
			}
			a = ia(b)
		}
		else 
			a = g
	}
	return a
};
N.C=function(){V.l.C[E](this);wg(this);this.aC=i};
function zg(){
	V[E](this);
	this.aA = {};
	this.RL = {};
	this.gD = i;
	this.XB = g
}
Q(zg,V);
qe(zg);
zg[v].yd=function(a){this.XB=a};
zg[v].Fr=Gd(27);
zg[v].Rb=function(a,b,c,d,e,f){Ag(this,g,a,b,i,c,d,e,f)};
Qa(zg[v],function(a,b,c,d,e,f,h){Ag(this,j,a,b,c,d,e,f,h)});
function Ag(a, b, c, d, e, f, h, k, p){
	f = f || pe;
	h = h || pe;
	if (ye(h)) 
		h = a.gD ? Fe(a.gD, h) : pe;
	if (a.XB) {
		f = P(a.EX, a, c, d, f);
		r = Bg(f, h, k);
		a = P(a.zE, a, p);
		b ? Cg(c, d, r, a) : Dg(c, d, e, r, a)
	}
	else {
		var r = P(a.JS, a, c, d, f, h, p);
		ke[Jb](function(){
			r();
			p && p()
		}, 0)
	}
}
zg[v].EX=function(a,b,c,d){this.RL[a]&&this.RL[a](b);return c(d[Qb])};
zg[v].JS=function(a,b,c,d){if(this.aA[a]){a=this.aA[a](b);a!==j?c(a):d()}};
zg[v].zE=function(a,b,c,d){this[A](new Eg(d,c,b));a&&a(b,c,d)};
function Eg(a,b,c){U[E](this,"msr-rr");this.ZV=a;this.Yw=b;this.Hi=c}
Q(Eg,U);
Eg[v].C=function(){delete this.Hi;Eg.l.C[E](this)};
var Fg="true";
function Gg(a, b, c){
	if (!(a[s] == 0)) {
		for (var d = [], e = j, f = 0; f < a[s]; ++f) {
			if (Hg == a[f]) 
				e = g;
			d[o]("dtid", a[f])
		}
		if (Ig !== g) {
			d[o]("init", Fg);
			Ig = g;
			if (!e) {
				d[o]("dtid", Hg);
				a[o](Hg)
			}
		}
		//zg.A().Rb("caldetails.ashx", d, b, "\u975e\u5e38\u62b1\u6b49\uff0c\u65e0\u6cd5\u52a0\u8f7d\u60a8\u65e5\u5386\u7684\u8be6\u7ec6\u4fe1\u606f\uff0c\u8bf7\u7a0d\u540e\u518d\u8bd5", 4, c)
	}
}
var Ig;
function Jg(){V[E](this);this.na={}}
Q(Jg,V);
qe(Jg);
N=Jg[v];
N.add = function(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H, J, ga, La, Ia, Hb, Bb, Gb, Ac, Bc, Md){
	b = new Kg(b, c, d, e, f, R(h), k, p, r, t, j, u, a, x, y, D, H, J, ga, La, Ia, Hb, Bb, Gb, Ac, Bc, Md);
	this.na[a] = b;
	this[A](new Lg(a, b))
};
N.b=function(a,b){this.na[a]=b};
N.O=function(a){return this.na[a]};
Ra(N,function(a){delete this.na[a]});
Wa(N,function(a){for(var b in this.na)if(a(b,this.na[b])===j)return});
function Lg(a,b){U[E](this,"detailsadd");this.id=a;this.af=b}
Q(Lg,U);
function Kg(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H, J, ga, La, Ia, Hb, Bb, Gb, Ac, Bc, Md, Tj){
	this.id = x;
	this.ze = a;
	this.ck = b;
	bb(this, c);
	this.Fv = this.tb = d;
	this.Bs = e;
	this.zs = Ia;
	Ea(this, f);
	this.af = h;
	this.Mq = k;
	this.qw = p;
	this.Vg = r;
	this.Bd = t;
	this.UE = J;
	this.origin = u;
	this.kI = y;
	this.eq = D;
	this.country = H;
	this.wd = ga;
	this.Et = La;
	this.yi = Hb;
	this.iw = Bb;
	this.wp = Gb;
	this.Wp = Ac;
	this.Hs = !!Bc;
	this.pD = !!Md;
	this.XN = Tj
};
function Mg(a){return function(){return a}}
Mg(j);
Mg(g);
function Ng(a,b,c){this.$=a;this.vw(b,c)}
N=Ng[v];
N.mc=O;
N.wi=O;
N.I=function(){return this.$};
N.Jo=function(a){this.$=a};
N.vw = function(a, b){
	this.da = a;
	this.va = b;
	var c = a.L();
	this.bd = pa(a.S);
	this.Dl = b.L() >= Og(c);
	this.Ry = !this.bd && Pg(b) == 0;
	this.lM = (c << 1) + !this.Dl + c % 1
};
N.eb=function(){return this.mc};
N.we=function(a){this.mc=a};
N.ml=function(){return i};
N.ba=function(a){if(this==a)return g;return!!a&&a.I()==this.I()};
function Qg(a,b,c){return b.lM-c.lM||c.va.L()-b.va.L()||a(b,c)||Me(b.eb(),c.eb())};
function Rg(){}
Rg[v].mi=function(){return Sg[6]};
function Tg(a){return!a||a[Dc](/^\s*$/)?"\uff08\u65e0\u4e3b\u9898\uff09":Ug(a)}
N=Rg[v];
N.il=function(a){return Tg(a.eb())};
N.Al=function(){return g};
N.io=function(){return j};
N.ho=function(){return j};
N.Mu=function(){return j};
N.kl=function(){return O};
N.fl=function(){return O};
N.Gn=function(){return Fe(Qg,Mg(0))};
function Vg(){Rg[E](this)}
Q(Vg,Rg);
N=Vg[v];
N.mi=function(a){a=Wg(a);return a=Sg[a]};
N.il=function(a){a=a;var b=Le(a.eb());b=(!b?O:b[w](Xg,O))||"\uff08\u65e0\u4e3b\u9898\uff09";return b+Yg(a)};
N.Al=function(a){return!Zg(a)};
N.io=function(a){return this.Al(a)};
N.Mu=function(a){return!this.Al(a)&&!(a.I()=="gcal$vevent$skeletonId")};
N.ho=function(a){return(a.Z&7)==2};
N.fl = function(a, b){
	a = a;
	var c = a.Z & 7;
	return c != 0 && c != 3 ? O : b ? $g("cic-ques") : ah(Wg(a))
};
N.kl = function(a, b){
	if (!b) 
		return O;
	a = a;
	b = [];
	var c;
	if (a.Og) 
		c = !!a.Og[s];
	else {
		c = bh[a.R];
		if (c == undefined) 
			c = bh[a.R] = !!ch(a.R)[s]
	}
	(c = c) && b[o]($g("cic-tmr"));
	if (a.Z & 8192) 
		b[o]($g("cic-spcl"));
	else 
		a.Z & 2048 && b[o]($g("cic-rcr"));
	a.Z & 4096 && b[o]($g("cic-priv"));
	if (dh(a)) 
		eh(a) ? b[o]($g("cic-noprs")) : b[o]($g("cic-prsn"));
	return b[M](O)
};
N.Gn=function(){return Fe(Qg,fh)};
function fh(a, b){
	return gh[a.R] - gh[b.R]
};
function W(a, b){
	this.Zo = a;
	this.nW = !!b
}
/** 匹配 /空格/ /A-Za-z0-9_/ */
var hh=/>(\s+)</g,ih=/\s{2,}/g,jh=/\$\{(\w+)\}/g;
N=W[v];
N.nA=j;
var X=" ";
N.ao = function(){
	if (!this.nA) {
		var a = this.Zo;
		delete this.Zo;
		this.nW || (a = a[w](hh, "><")[w](ih, X));//替换><之间的空格再把整个字符串的2个以上连续空格替换为一个空格
		var b = [];
		this.Gb = b;
		this.Ca = {};
		for (var c = a[Dc](jh) || [], d = 0, e = c[s], f = 0; f < e; ++f) {//查找${}变量
			var h = c[f], k = a[ic](h, d);
			d != k && b[o](a[I](d, k));
			d = k + h[s];
			h = h[I](2, h[s] - 1);
			k = this.Ca[h];
			if (!k) {
				k = [];
				this.Ca[h] = k
			}
			k[o](b[s]);
			b[o](undefined)
		}
		d != a[s] && b[o](a[I](d));
		this.nA = g
	}
};
N.bb = function(){
	this.ao();
	var a = new W(O);
	a.nA = g;
	a.Gb = [][Wb](this.Gb);
	a.Ca = {};
	for (var b in this.Ca) 
		a.Ca[b] = this.Ca[b];
	return a
};
N.b = function(a, b){
	this.ao();
	a = this.Ca[a];
	var c = a[s];
	if (c == 1) 
		this.Gb[a[0]] = b;
	else 
		for (; c--;) 
			this.Gb[a[c]] = b
};
sa(N,function(){this.ao();return this.Gb[M](O)});
N.$d=Gd(1);
N.Vc=Gd(63);
var kh=new W('<i class="cic ${icon}">&nbsp;</i>'),lh="icon";
function $g(a){kh.b(lh,a);return kh[q]()};
var mh,nh=T&&Ye(Yf,"6")==0;
T&&Ye(Yf,"7");
var oh=Tf&&Ye(Yf,"522")>=0,ph=Sf&&Ye(Yf,"1.9")<0,qh=Sf&&Ye(Yf,"1.9")>=0;
(function(){
	var a = j;
	if (Tf) 
		if (ke.navigator) 
			a = ke.navigator.userAgent[ic](" Chrome/") != -1;//Chrome浏览器
	mh = a
})();
var rh=!!mh;
var sh=/<[^>]*>|&[^;]+;/g;
function th(a, b){
	return b ? a[w](sh, X) : a
}
var uh=new RegExp("[\u0591-\u07ff\ufb1d-\ufdff\ufe70-\ufefc]"),vh=new RegExp("^[^\u0591-\u07ff\ufb1d-\ufdff\ufe70-\ufefc]*[A-Za-z\u00c0-\u00d6\u00d8-\u00f6\u00f8-\u02b8\u0300-\u0590\u0800-\u1fff\u2c00-\ufb1c\ufe00-\ufe6f\ufefd-\uffff]"),wh=new RegExp("^[^A-Za-z\u00c0-\u00d6\u00d8-\u00f6\u00f8-\u02b8\u0300-\u0590\u0800-\u1fff\u2c00-\ufb1c\ufe00-\ufe6f\ufefd-\uffff]*[\u0591-\u07ff\ufb1d-\ufdff\ufe70-\ufefc]"),xh=new RegExp("^[\u0000- !-@[-`{-\u00bf\u00d7\u00f7\u02b9-\u02ff\u2000-\u2bff]*$|^http://"),yh=/(\([^\)]*\))|(\[[^\]]*\])|({[^}]*})|(&lt;[^&]*&gt;)/g,zh=/(\([^\)]*\))|(\[[^\]]*\])|({[^}]*})|(<[^>]*>)/g;
function Ah(a){
	if (uh[vb](a)) 
		return a[w](yh, "<span dir=rtl>$&</span>");
	return a[w](yh, "<span dir=ltr>$&</span>")
}
function Bh(a){
	var b = uh[vb](a) ? "\u200f" : "\u200e";
	return a[w](zh, b + "$&" + b)
}
var Ch="</span>";
function Dh(a){
	if (a[Zb](0) == Oe) 
		return a[w](/<\w+/, "$& dir=rtl");
	return "\n<span dir=rtl>" + a + Ch
}
function Eh(a, b){
	var c;
	var d = c = 0;
	a = th(a, b)[Ob](X);
	for (b = 0; b < a[s]; b++) 
		if (wh[vb](th(a[b], undefined))) {
			c++;
			d++
		}
		else 
			xh[vb](th(a[b], undefined)) || d++;
	c = d == 0 ? 0 : c / d;
	return c > 0.4
};
var Fh={};
function Gh(a, b){
	var c = a * 2 + b, d = Fh[c];
	if (!d) {
		d = [];
		var e = j != a;
		if (b && ph && e) {
			d[o]("width:1000px");
			d[o]("text-align:right")
		}
		if (a) {
			d[o]("direction:rtl");
			if (b) 
				T && d[o]("zoom:1");
			else 
				d[o]("unicode-bidi:embed")
		}
		d = d[M](";");
		Fh[c] = d
	}
	return d
}
function Hh(a,b){var c;c=Eh(a);a=b||a;return c=c?Dh(a):a}
function Ih(a){return"\u202b"+a+"\u202c"}
function Ug(a){return uh[vb](a)?Ih(Bh(a)):a}
function Jh(a){return Ug(R(a))}
function Kh(a){ea(Ug(a))}
var Lh="</div>";
function Mh(a, b){
	return ph && b !== j ? '<div style="float:right">' + a + Lh : a
};
function Nh(){this.BF=[]}
N=Nh[v];
N.al=0;
N.gA=[];
N.sM=0;
N.FG=0;
var Oh="px";
N.DG=Oh;
var Ph="left";
N.HG=Ph;
N.wl=O;
N.zf=100;
var Qh="%";
N.RM=Qh;
N.ft=O;
N.rF=O;
N.Zo=O;
N.yD=O;
N.Dx="#fff";
N.Fx="#000";
N.kk=function(a){this.wl=a};
N.Cw=function(a,b){this.zf=a;this.RM=b};
N.sL=function(a,b){this.ft=a;this.rF=b||O};
function Rh(a, b){
	switch (b || 0) {
		case 1:
			b = a.Xi;
			a = a.Yi;
			break;
		case 2:
			b = a.Yi;
			a = a.vk;
			break;
		case 0:
		default:
			b = a.Dm;
			a = a.Ns;
			break
	}
	return {
		bgColor: b,
		borderColor: a
	}
}
function Sh(a,b,c){if(c)a.al|=b;else a.al&=~b}
var Th='">';
function Uh(a, b, c, d){
	var e = i, f = i;
	if (c) 
		if (c = Gh(Eh(c), g)) {
			e = '<div style="' + c + Th;
			b = b;
			f = Lh
		}
	a.ab.b(d, b || i);
	a.ab.b(d + "BidiStart", e);
	a.ab.b(d + "BidiEnd", f)
}
function Vh(a,b){if(!a)return"auto";return a-(b?5:3)+Oh}
function Wh(){}
function Xh(a, b){
	var c = O, d = O;
	if (b) {
		c = '<span class="${titleClass}">';
		d = Ch
	}
	if (a) 
		return '<dt style="background-color:${captionColor};">${captionBidiStart}${beforeIcons}' + c + "${caption}" + d + "${icons}${captionBidiEnd}</dt>";
	return "<dd>${textBidiStart}" + c + "${text}" + d + "${textBidiEnd}</dd>"
}
(function(){
	var a = Wh[v];
	a.EF = "border-color:${borderColor};background-color:${bgColor};";
	var b = '<div class="cb1" style="' + a.EF + '">&nbsp;</div>';
	a.rY = '<div class="ct" style="border-bottom-color:${borderColor}">&nbsp;</div>';
	a.qY = '<div class="cb2" style="border-color:${borderColor}">&nbsp;</div>' + b;
	a.gO = b + '<div class="cb2" style="border-color:${borderColor}">&nbsp;</div>';
	a.OY = Xh(g, j);
	a.m0 = Xh(g, g);
	a.PY = Xh(j, j);
	a.nY = Xh(j, g);
	a.SW = '<div class="resizer"><div class="rszr_icon">&nbsp;</div></div>'
})();
var Yh=new W('<div class="$[classes] chip" style="top:$[top]px;$[edge]:$[offset]$[offsetUnit];width:$[width]$[widthUnit];"> ${templateContentPre}<dl class="$[extraClasses]" style="height:$[height];${templateColors}">${templateContent}</dl>${templateContentPost}</div>');
Wh[v].Jx = function(a, b, c, d){
	if (c && a) 
		return i;
	a = {
		templateColors: this.EF,
		templateContentPre: b ? a ? this.qY : this.rY : O,
		templateContentPost: b ? this.gO : O
	};
	b = O;
	b = this.OY + (d ? this.nY : this.PY);
	if (c) 
		b += this.SW;
	a.templateContent = b;
	for (var e in a) 
		Yh.b(e, a[e]);
	c = Yh[q]()[w](/\[/g, "{")[w](/\]/g, "}");
	return new W(c)
};
function Zh(){
	this.jM = [];
	for (var a = new Wh, b = 0; b < 16; b++) {
		var c = a.Jx(b & 1, b & 2, b & 4, b & 8);
		if (c) 
			this.jM[b] = c
	}
}
qe(Zh);
/** 若是a小于10则左补齐"0" */
function $h(a){return a<10?ce+a:ma(a)}
/** 若a不是数字则返回"??"若是则"0"左补齐 */
function ai(a){return pa(a)?"??":$h(a)}
/** 12个月各自天数，2月不能确定所以为空，待用时再计算 */
var bi=[,31,,31,30,31,30,31,31,30,31,30,31];
/**
 * 返回指定年月的月份天数 
 * 闰年的计算 (4年一闰 and 100年不闰) or (400年又闰) 用按位与来计算4的倍数
 * @param {Object} a year
 * @param {Object} b month
 * @return {number} 月份含天数
 */
function ci(a, b){
	return bi[b] || bi[a] || (bi[a] = 28 + ((a & 3 ? j : a % 100 ? g : a % 400 ? j : g) ? 1 : 0))
}
function di(a){return a==0||a==6}
/** 返回指定年月日是周几 0 (Sunday) and 6 (Saturday). */
var ei={};
/** 返回输入a,b年月的(1号)是周几(日一二三四五六对应0123456) */
function fi(a, b){
	var c = a << 4 | b;
	return ei[c] || (ei[c] = (new Date(a, b - 1, 1, 0, 0, 0, 0)).getDay())
}
/** 12个月的起始天数，从零算起，默认2月为28天 */
var gi=[,0,31,59,90,120,151,181,212,243,273,304,334];
/** 参数:a:year b:month c:day 返回当日是这年里的第几日 大于2月要计算闰年 */
function hi(a, b, c){
	a = b <= 2 || 29 - ci(a, 2);
	return gi[b] + c - a
};
/** 
 * 参数:a:year b:month c:day 
 * 返回:每一个日期对应一个唯一整数
 * 注释:年份与1970年相减->左移4位(因为最大月份为12对应二进制为1100)->加上月份->左移5(因为最大日期为31对应二进制为11111)->加上日期 
*/
function ii(a, b, c){
	return ((a - 1970 << 4) + b << 5) + c
}
/** 
 * 参数:a:hour b:minute c:second 7.62939453125E-6=2的(-17)次方 (a最大24小时占5位/b最大59分钟占6位/c最大59秒占6位/总共17位)
 */
function ji(a,b,c){return(((a<<6)+b<<6)+c+1)*7.62939453125E-6}
var ki=ii(-65535,1,1),li=ii(65535,12,31);
/** 把a还原为"yyyyMMdd"的形式 */
function mi(a){
	return ma((a >> 9) + 1970) + $h(a >> 5 & 15) + $h(a & 31)
}
/** 给a加1天 */
function Og(a){
	if ((a & 31) < 28)//日期小于28直接加1天返回
		return a + 1;
	var b = a >> 5 & 15;//月份
	if ((a & 31) < (bi[b] || ci((a >> 9) + 1970, 2))) 
		return a + 1;//不是当月最后一天直接加1天返回
	else {
		var c = (a >> 9) + 1970;
		if (++b > 12) {
			b = 1;
			++c
		}
		return ii(c, b, 1) + a % 1
	}
}
function ni(a, b){
	var c = a;
	a % 1 || (a += 7.62939453125E-6);
	(b - 7.62939453125E-6) % 1 || (b -= 7.62939453125E-6);
	return function(d, e){
		return d < b && (e > a || d >= c)
	}
};
/** 一个具体日期的基类 */
function oi(){}
N=oi[v];
N.K=NaN;/** year */
N.J=NaN;/** month */
N.F=NaN;/** day */
N.S=NaN;/** hour */
N.T=NaN;/** minute */
N.ha=NaN;/** second */
sa(N,function(){return this.SX||(this.SX=this.um())});
N.Sa=function(){var a;return a=this.L()|0};
N.min=function(a){return this.L()<a.L()?this:a};
N.max=function(a){return this.L()>a.L()?this:a};
function pi(a, b){
	var c = qi(a);
	if (!pa(a.K)) {
		c.K = NaN;
		c.J = NaN;
		c.F = ri(a, b)
	}
	if (!pa(a.S)) {
		c.S -= b.S;
		c.T -= b.T;
		c.ha -= b.ha
	}
	return new si(c.F, c.S, c.T, c.ha)
}
/**
 *一天的毫秒数86400000
 *Date.UTC(year,month,day,hours,minutes,seconds,ms)UTC() 方法可根据世界时返回 1970 年 1 月 1 日 到指定日期的毫秒数。
 *返回this和a两者的天数间隔
 */
function ri(a, b){
	return a.K == b.K ? hi(a.K, a.J, a.F) - hi(b.K, b.J, b.F) : l[Fb]((Date.UTC(a.K, a.J - 1, a.F) - Date.UTC(b.K, b.J - 1, b.F)) / 86400000)
}
function ti(a){
	var b;
	b = a.K;
	var c = a.J;
	a = a.F;
	if (++a > 28 && a > ci(b, c)) {
		a = 1;
		if (++c === 13) {
			c = 1;
			++b
		}
	}
	return b = ui(b, c, a)
}
function vi(a){return a.S||a.T||a.ha?ti(a):a.V()}
function wi(a,b){return xi(a.K,a.J,a.F+b).V()}
function yi(a,b){return wi(a,-((a.Ka()-b+7)%7))}
function zi(a,b){return wi(a,(b-a.Ka()+7)%7)}
/** 返回一个具体日期是周几 */
oi[v].Ka=function(){return(fi(this.K,this.J)+this.F-1)%7};
/** 把当前日期添加到ui数组中 */
oi[v].V=function(){return ui(this.K||0,this.J||1,this.F||1)};
oi[v].X=function(){return new Ai(this.K||0,this.J||1,this.F||1,this.S||0,this.T||0,this.ha||0)};
oi[v].yf=function(){return new Bi(this.S||0,this.T||0,this.ha||0)};
function Pg(a){return a.S*60+a.T};
/** 继承 oi 的一个子类 */
function Ci(){}
Q(Ci,oi);
/** 继承 oi 的一个子类 */
function Bi(a,b,c){oi[E](this);this.S=a;this.T=b;this.ha=c}
Q(Bi,oi);
N=Bi[v];
N.yf=function(){return this};
var Di="T";
N.um=function(){return Xe(Di,$h(this.S),$h(this.T),$h(this.ha))};
N.ba=function(a){return this[Xb]===a[Xb]&&this.L()==a.L()};
N.L=function(){return this.Ve||(this.Ve=ji(this.S,this.T,this.ha))};
N.qb=function(){return g};
/** 继承 Ci 的一个子类 */
function Ai(a, b, c, d, e, f){
	this.K = a;
	this.J = b;
	this.F = c;
	this.S = d;
	this.T = e;
	this.ha = f
}
Q(Ai,Ci);
N=Ai[v];
N.X=function(){return this};
N.L = function(){
	return this.Ve || (this.Ve = ((this.K - 1970 << 4) + this.J << 5) + this.F + (((this.S << 6) + this.T << 6) + this.ha + 1) * 7.62939453125E-6)
};
N.qb=function(){return g};
N.um=function(){return Xe(ma(this.K),$h(this.J),$h(this.F),Di,$h(this.S),$h(this.T),$h(this.ha))};
N.ba=function(a){return this[Xb]===a[Xb]&&this.L()==a.L()};
/** 返回一个Ai */
function Ei(a){
	return new Ai(a.getUTCFullYear(), a.getUTCMonth() + 1, a[Rb](), a.getUTCHours(), a.getUTCMinutes(), a.getUTCSeconds())
};
function Fi(){}
Q(Fi,Ci);
/** 返回一个Fi对象,并把这个对象添加到到Hi中 */
function Gi(a, b, c, d){
	var e = new Fi;
	e.K = a;
	e.J = b;
	e.F = c;
	e.Ve = d;
	return Hi[d] = e
}
N=Fi[v];
N.V=function(){return this};
N.L=function(){return this.Ve};
N.qb=function(){return g};
N.um=function(){return Xe(ma(this.K),$h(this.J),$h(this.F))};
N.ba=function(a){return this===a};
var Hi={};
function ui(a,b,c){var d=ii(a,b,c);return Hi[d]||Gi(a,b,c,d)}
function Ii(a){return Hi[a]||Gi((a>>9)+1970,a>>5&15,a&31,a)}
function Ji(a){return ui(a.getUTCFullYear(),a.getUTCMonth()+1,a[Rb]())};
/** 继承 oi 的一个子类 */
function si(a, b, c, d){
	oi[E](this);
	this.Si = a = ((a * 24 + b) * 60 + c) * 60 + d;//总秒数
	this.ha = a % 60;//取余(秒数)
	a = a / 60 | 0;//总分钟(按位或取整)
	this.T = a % 60;//取余(分钟)
	a = a / 60 | 0;//总小时(按位或取整)
	this.S = a % 24;//取余(小时)
	this.F = a / 24 | 0//天数
}
Q(si,oi);
/** 取整运算(按位或取整是所有方法中最快的) */
function Ki(a){return a.Si/60|0}
si[v].L=function(){return this.Ve||(this.Ve=this.F+ji(this.S,this.T,this.ha))};
si[v].um = function(){
	var a = this.S || this.T || this.ha || 0, b = this.F || a;
	b = b < 0 ? -1 : b > 0 ? 1 : 0;
	var c = b < 0 ? "-P" : "P";
	if (this.F) 
		c += this.F % 7 ? b * this.F + "D" : b * this.F / 7 + "W";
	if (a) {
		c += Di;
		if (this.S) 
			c += b * this.S + "H";
		if (this.T) 
			c += b * this.T + "M";
		if (this.ha) 
			c += b * this.ha + "S"
	}
	else 
		b || (c += "0D");
	return c
};
si[v].ba=function(a){return this[Xb]===a[Xb]&&this.L()==a.L()};
new si(1,0,0,0);
/** 继承 oi 的一个子类 一个时间类(年月日时分秒) */
function Li(){}
Q(Li,oi);
N=Li[v];
N.K=0;//year
N.J=0;//month
N.F=0;//day
N.S=0;//hour
N.T=0;//minute
N.ha=0;//second
N.L = function(){
	var a = this.Sa();
	pa(this.S) || (a += ji(this.S, this.T, this.ha));
	return a
};
N.Sa=function(){Mi(this);return ii(this.K,this.J,this.F)};
function Ni(a,b){a.F+=b.F;a.S+=b.S;a.T+=b.T;a.ha+=b.ha}
/** 跨天处理 */
function Mi(a){
	if (a.S || a.T || a.ha) {
		var b = (a.S * 60 + a.T) * 60 + a.ha, c = l[Pb](b / 86400);
		b -= c * 86400;
		a.F += c;
		a.ha = b % 60;
		b /= 60;
		a.T = (b | 0) % 60;
		b /= 60;
		a.S = (b | 0) % 24
	}
	Oi(a);
	//校验年月日(确保月份1～12月每月1～31天)
	for (b = ci(a.K, a.J); a.F < 1;) {
		a.J -= 1;
		Oi(a);
		b = ci(a.K, a.J);
		a.F += b
	}
	for (; a.F > b;) {
		a.F -= b;
		a.J += 1;
		Oi(a);
		b = ci(a.K, a.J)
	}
}
/** 跨年处理 */
function Oi(a){
	var b;
	if (a.J < 1 || a.J > 12) {
		b = l[Pb]((a.J - 1) / 12);
		a.J -= 12 * b;
		a.K += b
	}
}
N=Li[v];
N.V=function(){Mi(this);return ui(this.K,this.J,this.F)};
N.X=function(){Mi(this);return new Ai(this.K,this.J,this.F,this.S,this.T,this.ha)};
N.ib=Gd(23);
N.Sd=Gd(9);
N.yf=function(){Mi(this);return new Bi(this.S,this.T,this.ha)};
N.Ka=function(){Mi(this);return(fi(this.K,this.J)+this.F-1)%7};//返回周几
N.ba=function(a){return this[Xb]==a[Xb]&&this.L()==a.L()};
function qi(a){return Pi(a.K||0,a.J||0,a.F||0,a.S||0,a.T||0,a.ha||0)}
function Qi(a){return Pi(a.K,a.J,a.F,a.S,a.T,a.ha)}
function Pi(a,b,c,d,e,f){var h=new Li;h.K=a;h.J=b;h.F=c;h.S=d;h.T=e;h.ha=f;return h}
function xi(a,b,c){var d=new Li;d.K=a;d.J=b;d.F=c;return d};
function Ri(a, b){
	Sa(this, a);
	if (b[Xb] === si) {
		a = qi(a);
		Ni(a, b);
		this.W = this[F] instanceof Ai ? a.X() : a.V();
		this.Jf = b
	}
	else {
		this.W = b;
		this.Jf = pi(this.W, this[F])
	}
}
sa(Ri[v],function(){return this[F]+"/"+this.W});
Ri[v].ba=function(a){return this[Xb]===a[Xb]&&this[F].ba(a[F])&&this.W.ba(a.W)};
cb(Ri[v],function(a){a=a.L();return a>=this[F].L()&&a<this.W.L()});
/** 计算时分秒("0")=48 | (48*10+48=528) */
function Si(a, b){
	return a[Wc](b) * 10 + a[Wc](b + 1) - 528
}
/** 返回一个ui或者Ai两者都继承于Ci */
function Ti(a){
	var b = ka(a, 10), c = b % 100;//b:yyyyMMdd c:dd
	b /= 100;
	var d = (b | 0) % 100;
	b = b / 100 | 0;
	var e = a[s];
	if (e == 8)//yyyyMMdd格式
		return ui(b, d, c);
	else 
		if (e == 15)//yyyyMMddThhmmss格式
			return new Ai(b, d, c, Si(a, 9), Si(a, 11), Si(a, 13))
};
function Ui(a, b, c, d, e){
	this.Fi = a;
	this.Vt = b;
	this.NM = b.Ka();
	this.Ge = c;
	this.kc = d;
	this.At = e || 7;
	this.size = this.Ge * this.kc
}
function Vi(a){
	for (var b = a.Vt.Sa(), c = a.kc, d = a.At, e = [], f = 0, h = 0; h < a.Ge; h++) {
		for (var k = 0; k < c; k++) {
			e[f++] = b;
			b = Og(b)
		}
		for (; k < d; k++) 
			b = Og(b)
	}
	return a.jP = e
}
function Wi(a){return a.jP||Vi(a)}
Ui[v].ba=function(a){return this.Fi.ba(a.Fi)&&this.Vt.ba(a.Vt)&&this.Ge==a.Ge&&this.kc==a.kc&&this.At==a.At};
Ui[v].Hn=function(){return(this.Ge-1)*this.At+this.kc};
Ui[v].Uc=Gd(15);
function Xi(){}
function Yi(a){this.ez=a}
Q(Yi,Xi);
Yi[v].rt = function(a){
	var b = qi(a);
	b.F = 1 - (ne(undefined) ? undefined : 1);
	var c = (b.V().Ka() - this.ez + 7) % 7;
	b.F -= c;
	return a = new Ui(a, b.V(), 6, 7)
};
function Zi(a, b, c, d, e){
	this.aH = b;
	this.uv = c;
	this.pU = d;
	this.Zx = [];
	this.RD = [];
	b = this.Zx;
	c = this.RD;
	var f;
	d = 0;
	var h = this.uv, k = this.aH, p = ni(k.L(), wi(k, h).L());
	for (f = 0; f < h; f++) {
		b[f] = [];
		c[f] = []
	}
	f = 0;
	for (var r = a[s]; f < r; f++) {
		var t = a[f];
		if (p(t.da.L(), t.va.L())) {
			var u = t.Dl, x = 0, y = ri(t.da.V(), k);
			if (y < 0) {
				if (!u) 
					continue;
				y = 0;
				x |= 1
			}
			var D = ri(vi(t.va), k);
			if (D > h) {
				D = h;
				x |= 2
			}
			u = new $i(t, u ? D - y : 1, x);
			if (t.ml()) 
				c[y][o](u);
			else {
				b[y][o](u);
				d++
			}
		}
	}
	this.Yk = a = d;
	this.cO = e
}
function $i(a,b,c){this.event=a;this.colSpan=b;this.Z=c}
var aj="</td>";
function bj(a, b){
	for (var c = a.uv, d = a.Yk, e = a.pU, f = uf(0, c), h = uf(0, c), k = uf(0, c), p = [], r = 0, t = 0; d;) {
		if (r == c) {
			r = 0;
			t++
		}
		var u = a.Zx[r][f[r]++];
		if (u) {
			for (var x = u[Uc]; x--;) {
				k[r] = t;
				if (t + 1 == e) 
					p[r] = u;
				else 
					if (t >= e) {
						h[r]++;
						if (p[r]) 
							p[r].MS = g
					}
				r++
			}
			--d
		}
		else 
			r++
	}
	f = uf(0, c);
	d = [];
	x = t;
	r = a.cO ? 1 : 0;
	e = l.min(x, e - 1);
	var y = e + 1 + r;
	for (t = 0; t < y; t++) {
		var D = y - t;
		b.se[o]("<tr>");
		for (r = 0; r < c; r++) 
			if (!d[r]) {
				u = a.Zx[r][f[r]++];
				var H = t >= k[r];
				if (t == e && (h[r] || p[r] && p[r].MS)) {
					u = "ca-mlp" + wi(a.aH, r).Sa();
					b.se[o]('<td class="', u, " st-more " +
					(b.DM ? O : "st-moreul ") +
					'st-c">');
					b.DM ? b.se[o]('<div class="', u, X, 'st-moreicon" >\u25bc</div>') : b.se[o]("\u53e6\u5916 " + (h[r] + (p[r] ? 1 : 0)) + " \u4e2a");
					b.se[o](aj)
				}
				else 
					if (u && t <= e) {
						var J = 1;
						if (u[Uc] > 1) 
							r += u[Uc] - 1;
						else 
							if (H && t != x) {
								J = D;
								d[r] = g
							}
						H = !!(u.Z & 1);
						var ga = !!(u.Z & 2), La = "ca-evp" + Be(u[Ed]);
						b.VK(u, J, j, H, ga, La);
						b.vC(u, J, j, H, ga, La);
						b.UK(u, J, j, H, ga, La)
					}
					else {
						u = (d[r] = H) ? D : 1;
						J = b.se;
						J[o]('<td class="st-c st-s"');
						u > 1 && J[o](" rowspan=", u);
						J[o](">&nbsp;")
					}
			}
	}
};
function cj(a,b,c){this.$h=a;this.Ug=b;this.hA=c}
cj[v].TC=function(a){this.$h=a};
function dj(a){Rg[E](this);this.jG=a;this.zh={}}
Q(dj,Rg);
dj[v].Gr=Gd(55);
function ej(a,b){return a.zh[b.R]||a.jG}
N=dj[v];
N.mi=function(a){return ej(this,a).mi(a)};
N.il=function(a){return ej(this,a).il(a)};
N.Al=function(a){return ej(this,a).Al(a)};
N.io=function(a){return ej(this,a).io(a)};
N.ho=function(a){return ej(this,a).ho(a)};
N.Mu=function(a){return ej(this,a).Mu(a)};
N.kl=function(a,b){return ej(this,a).kl(a,b)};
N.fl=function(a,b){return ej(this,a).fl(a,b)};
N.Gn=function(){return this.jG.Gn()};
function fj(a,b){this.x=ne(a)?a:0;this.y=ne(b)?b:0}
fj[v].bb=function(){return new fj(this.x,this.y)};
function gj(a,b){ya(this,a);jb(this,b)}
N=gj[v];
N.bb=function(){return new gj(this[Cb],this[od])};
N.jc=Gd(34);
N.ceil=function(){ya(this,l[Mb](this[Cb]));jb(this,l[Mb](this[od]));return this};
N.floor=function(){ya(this,l[Pb](this[Cb]));jb(this,l[Pb](this[od]));return this};
N.round=function(){ya(this,l[Fb](this[Cb]));jb(this,l[Fb](this[od]));return this};
var hj;
function ij(a){return(a=a[yb])&&typeof a[Ob]==se?a[Ob](X):[]}
function jj(a){
	for (var b = ij(a), c = tf(arguments, 1), d = 0, e = 0; e < c[s]; e++) 
		if (!of(b, c[e])) {
			b[o](c[e]);
			d++
		}
	c = d == c[s];
	xa(a, b[M](X));
	return c
}
function kj(a){
	for (var b = ij(a), c = tf(arguments, 1), d = 0, e = 0; e < b[s]; e++) 
		if (of(c, b[e])) {
			sf(b, e--, 1);
			d++
		}
	c = d == c[s];
	xa(a, b[M](X));
	return c
}
function lj(a, b){
	return of(ij(a), b)
};
function mj(a){return a?new nj(oj(a)):hj||(hj=new nj)}
function pj(a){return ye(a)?document[Sb](a):a}
var qj=pj,rj="class";
function sj(a, b){
	wf(b, function(c, d){
		if (d == "style") 
			Ua(a[B], c);
		else 
			if (d == rj) 
				xa(a, c);
			else 
				if (d == "for") 
					a.htmlFor = c;
				else 
					if (d in tj) 
						a[Zc](tj[d], c);
					else 
						a[d] = c
	})
}
var uj = "height", vj = "width", tj = {
	cellpadding: "cellPadding",
	cellspacing: "cellSpacing",
	colspan: "colSpan",
	rowspan: "rowSpan",
	valign: "vAlign",
	height: uj,
	width: vj,
	usemap: "useMap",
	frameborder: "frameBorder",
	type: "type"
};
function wj(){return xj(document,arguments)}
function xj(a, b){
	var c = b[0], d = b[1];
	if (T && d && (d[kd] || d[K])) {
		c = [Oe, c];
		d[kd] && c[o](' name="', R(d[kd]), Qe);
		if (d[K]) {
			c[o](' type="', R(d[K]), Qe);
			d = Ee(d);
			delete d[K]
		}
		c[o](Pe);
		c = c[M](O)
	}
	var e = a[Pc](c);
	if (d) 
		if (ye(d)) {
			xa(e, d);
		}
		else {
			sj(e, d);
		}
	if (b[s] > 2) {
		function f(h){
			if (h) 
				e[n](ye(h) ? a[ac](h) : h)
		}
		for (d = 2; d < b[s]; d++) {
			c = b[d];
			we(c) && !(Ae(c) && c[Kb] > 0) ? lf(yj(c) ? rf(c) : c, f) : f(c)
		}
	}
	return e;
}
var zj=wj;
function Aj(a,b){a[n](b)}
function Bj(a){for(var b;b=a[G];)a[wc](b)}
function Cj(a,b){b[L]&&b[L][gc](a,b)}
function Dj(a,b){b[L]&&b[L][gc](a,b[md])}
function Ej(a){return a&&a[L]?a[L][wc](a):i}
function Fj(a,b){var c=b[L];c&&c.replaceChild(a,b)}
function Gj(a){
	var b, c = a[L];
	if (c && c[Kb] != 11) 
		if (a[bd]) 
			return a[bd](j);
		else {
			for (; b = a[G];) 
				c[gc](b, a);
			return Ej(a)
		}
}
function Hj(a){for(a=a[G];a&&a[Kb]!=1;)a=a[md];return a=a}
var Ij=Tf&&Ye(Yf,"521")<=0;
function Jj(a, b){
	if (typeof a[ed] != "undefined" && !Ij && b[Kb] == 1) 
		return a == b || a[ed](b);
	if (typeof a[nc] != "undefined") 
		return a == b || ia(a[nc](b) & 16);
	for (; b && a != b;) 
		b = b[L];
	return b == a
}
function oj(a){return a[Kb]==9?a:a[vc]||a[Lb]}
function Kj(a, b){
	if ("textContent" in a) 
		a.textContent = b;
	else 
		if (a[G] && a[G][Kb] == 3) {
			for (; a[Cc] != a[G];) 
				a[wc](a[Cc]);
			Aa(a[G], b)
		}
		else {
			Bj(a);
			var c = oj(a);
			a[n](c[ac](b))
		}
}
function Lj(a,b){var c=[];return Mj(a,b,c,g)?c[0]:undefined}
function Mj(a, b, c, d){
	if (a != i) 
		for (var e = 0, f; f = a[hd][e]; e++) {
			if (b(f)) {
				c[o](f);
				if (d) 
					return g
			}
			if (Mj(f, b, c, d)) 
				return g
		}
	return j
}
var Nj = {
	SCRIPT: 1,
	STYLE: 1,
	HEAD: 1,
	IFRAME: 1,
	OBJECT: 1
}, Oj = {
	IMG: X,
	BR: "\n"
};
function Pj(a, b, c){
	if (!(a[qc] in Nj)) 
		if (a[Kb] == 3) 
			c ? b[o](ma(a[wd])[w](/(\r\n|\r|\n)/g, O)) : b[o](a[wd]);
		else 
			if (a[qc] in Oj) 
				b[o](Oj[a[qc]]);
			else 
				for (a = a[G]; a;) {
					Pj(a, b, c);
					a = a[md]
				}
}
function yj(a){
	if (a && typeof a[s] == re) 
		if (Ae(a)) 
			return typeof a[fc] == se || typeof a[fc] == xe;
		else 
			if (ze(a)) 
				return typeof a[fc] == se;
	return j
}
function Qj(a, b, c, d){
	if (!c) 
		a = a[L];
	c = d == i;
	for (var e = 0; a && (c || e <= d);) {
		if (b(a)) 
			return a;
		a = a[L];
		e++
	}
	return i
}
function nj(a){this.gc=a||ke[Lb]||document}
N=nj[v];
N.wc=mj;
N.Ea=Gd(40);
N.o=function(a){return ye(a)?this.gc[Sb](a):a};
N.ja=nj[v].o;
N.ne=Gd(64);
N.ex=nj[v].ne;
N.N=Gd(25);
N.createElement=function(a){return this.gc[Pc](a)};
N.createTextNode=function(a){return this.gc[ac](a)};
N.Uf=Gd(12);
N.appendChild=Aj;
N.tC=Bj;
N.qA=Cj;
N.pA=Dj;
ab(N,Ej);
N.replaceNode=Fj;
N.nQ=Gj;
N.rH=Hj;
cb(N,Jj);
N.Oo=Kj;
N.iQ=Lj;
N.oH=Qj;
function Rj(){}
var Sj="color";
function Uj(a, b, c, d, e, f, h){
	Vj.b(Sj, d);
	Vj.b("outerClasses", e || O);
	Vj.b("paddingClasses", h || O);
	Vj.b("extraHtml", f || O);
	a = Eh(c);
	Vj.b("content", b);
	Vj.b("dir", !a ? O : ";direction:rtl;;text-align:left");
	return Vj[q]()
}
var Wj=new W('<div class="${outerClasses} rb-o" style="color:${color}${dir}"><div class="${paddingClasses} rb-m" style="background-color:${color}">${extraHtml}<div class="rb-i">${content}</div></div></div>'),Xj=new W('<div class="${outerClasses} ${paddingClasses} rb-n" style="background-color:${color}${dir}">${extraHtml}${content}</div>'),Vj=qh||oh?Xj:Wj;
function Yj(){}
var Zj=new W('<div class="${extraClasses} te" style="color:${color}">'+Mh('<span class="te-t">${time}&nbsp;</span><span class="te-s">${subject}</span>',j)+Lh),$j=new W('<div class="${extraClasses} te" style="color:${color}"><table cellpadding=0 cellspacing=0 class="te-rev"><tr><td class="te-t">${time}&nbsp;</td><td class="te-rev-s"><div class="te-rev-spos">&nbsp;<div class="te-rev-scont" dir="rtl">'+Mh("${subject}",g)+"</div></div></td></tr></table></div>");
function ak(a, b, c, d, e){
	this.ke = a;
	this.Ja = b;
	this.l0 = new Yj;
	this.xE = new Rj;
	this.uX = c || j;
	this.DM = !!d;
	this.RH = !!e
}
ak[v].se=i;
ak[v].Mo=function(a){this.se=a};
ak[v].Hr=function(){this.se=i};
function bk(a){a.se[o]('<table cellpadding="0" cellspacing="0" class="st-grid">')}
function ck(a){
	a.se[o]("</table>")
}
var dk="title";
function ek(a, b){
	a = a.se;
	for (var c = 0; c < b[s]; c++) {
		var d = b[c], e = d[Ed].ml();
		if (e.FA()) {
			fk.b(dk, R(e.eb()));
			fk.b("iconURL", R(e.hI));
			d = "ca-evp" + Be(d[Ed]) + " st-wc";
			if (e.ll()) 
				d += " st-wc-click";
			fk.b(rj, d);
			a[o](fk[q]())
		}
	}
}
ak[v].VK=function(){};
ak[v].vC = function(a, b, c, d, e, f){
	c = this.se;
	c[o]('<td class="st-c"');
	b > 1 && c[o](" rowspan=", b);
	a[Uc] > 1 && c[o](" colspan=", a[Uc]);
	c[o](Pe);
	c[o](a[Ed].Dl || a[Ed].bd ? gk(this, a[Ed], j, d, e, f) : hk(this, a[Ed], j, f));
	c[o](aj)
};
ak[v].UK=function(){};
var ik="time";
function hk(a, b, c, d){
	c = d || O;
	d = a.Ja.fl(b, j);
	var e = a.Ja.il(b);
	if (e && a.RH) 
		e = '<span class="' + ("ca-elp" + Be(b)) + Th + e + Ch;
	var f = a.Ja.kl(b, j);
	e = e + f;
	f = a.Ja.mi(b);
	f = a.Ja.ho(b) ? f.Yi : f.Ns;
	a = d + a.ke.Xa(b.da, g, a.uX);
	b = Zj;
	if (Eh(e)) 
		b = $j;
	b.b(Sj, f);
	b.b(ik, a);
	b.b("subject", e);
	b.b("extraClasses", c);
	return a = b[q]()
}
var jk="(";
function gk(a, b, c, d, e, f){
	var h = a.Ja.fl(b, g), k = a.Ja.il(b);
	if (k && a.RH) 
		k = '<span class="' + ("ca-elp" + Be(b)) + Th + k + Ch;
	var p = a.Ja.kl(b, g);
	k = k + p;
	if (!b.bd && !d) 
		k = jk + a.ke.Xa(b.da) + ") " + k;
	else 
		if (c) {
			c = pi(b.va, b.da);
			if (c.F > 1) 
				k = jk + kk(a.ke, c) + ") " + k
		}
	k = h + k;
	h = a.Ja.mi(b);
	h = a.Ja.ho(b) ? h.Yi : a.Ja.io(b) ? h.Xi : h.Dm;
	c = d ? "st-ad-mpad" : O;
	return Uj(a.xE, k, b.eb(), h, f, lk(a, d, e), c)
}
function lk(a,b,c){if(!b&&!c)return O;return(b?'<div class="st-ad-ml"> </div>':O)+(c?'<div class="st-ad-mr"> </div>':O)}
var fk=new W('<img src="${iconURL}" class="${class}" title="${title}" alt="${title}">');
var mk=T?'<table style="table-layout:fixed" cellpadding=0 cellspacing=0><tr><td>':O,nk=T?"</tr></td></table>":O,ok=0,pk="div";
function qk(){
	if (ok) 
		return ok;
	var a = document[Pc](pk);
	Ua(a[B], "visibility:hidden;overflow-y:scroll;position:absolute;top:0;width:100px;height:100px");
	document[rc][n](a);
	ok = a[Ub] - a[Db] || 18;
	document[rc][wc](a);
	return ok
};
function rk(a, b, c, d){
	ak[E](this, a, b, c, j, d)
}
Q(rk,ak);
rk[v].VK=function(a,b,c,d,e,f){a=a[Ed];b=a.da;sk(this,a,f,d,j,b)};
rk[v].UK=function(a,b,c,d,e,f){a=a[Ed];b=a.va;b=wi(vi(b),-1);sk(this,a,f,j,e,b)};
rk[v].vC=function(a,b,c,d,e,f){rk.l.vC[E](this,a,b,c,j,j,f)};
function sk(a, b, c, d, e, f){
	var h = O;
	if (e || d) {
		h = a.ke.Pf(f) + "&nbsp;";
		b = a.Ja.mi(b).vk;
		f = O;
		if (d) {
			c += " wk-more-prealign";
			f = "st-ad-mpad"
		}
		h = Uj(a.xE, h, h, b, c, lk(a, d, e), f)
	}
	a = a.se;
	a[o]('<td class="wk-sideevents">');
	a[o](h);
	a[o](aj)
};
function tk(a,b,c){this.QD=[];this.$c=b||uk;this.dL=c||"gcal$func$";this.fX=a}
Q(tk,Df);
var uk=ke.gcal$func$={},vk=0,wk=new tk;
tk[v].C = function(){
	for (var a = 0, b = this.QD[s]; a < b; ++a) 
		delete this.$c[this.QD[a]];
	tk.l.C[E](this)
};
tk[v].qg = function(a, b){
	if (b = b || this.fX) 
		a = P(a, b);
	b = vk++;
	this.$c[b] = a;
	this.QD[o](b);
	return this.dL + "[" + b + "]"
};
tk[v].KP=function(a){delete this.$c[a[I](this.dL[s]+1,a[s]-1)]};
var xk=P(wk.qg,wk);
P(wk.KP,wk);
function yk(){};
function zk(a,b,c,d){this.event=a;Sa(this,b);this.W=c;this.PO=d;this.lw=[]};
function Ak(a,b,c,d){this.top=a;nb(this,b);Ya(this,c);Ka(this,d)}
Ak[v].bb=function(){return new Ak(this.top,this[Dd],this[Yc],this[sc])};
cb(Ak[v],function(a){
	a = !this || !a ? j : a instanceof Ak ? a[sc] >= this[sc] && a[Dd] <= this[Dd] && a.top >= this.top && a[Yc] <= this[Yc] : a.x >= this[sc] && a.x <= this[Dd] && a.y >= this.top && a.y <= this[Yc];
	return a
});
Ak[v].expand = function(a, b, c, d){
	if (Ae(a)) {
		this.top -= a.top;
		this.right += a[Dd];
		this.bottom += a[Yc];
		this.left -= a[sc]
	}
	else {
		this.top -= a;
		this.right += b;
		this.bottom += c;
		this.left -= d
	}
	return this
};
function Bk(a,b){a=ca(a);b=ca(b);Sa(this,a<b?a:b);this.W=a<b?b:a}
Bk[v].bb = function(){
	return new Bk(this[F], this.W)
};
function Ck(a,b,c,d){Ka(this,a);this.top=b;ya(this,c);jb(this,d)}
Ck[v].bb=function(){return new Ck(this[sc],this.top,this[Cb],this[od])};
Ck[v].rA=Gd(57);
cb(Ck[v],function(a){
	return a instanceof Ck ? this[sc] <= a[sc] && this[sc] + this[Cb] >= a[sc] + a[Cb] && this.top <= a.top && this.top + this[od] >= a.top + a[od] : a.x >= this[sc] && a.x <= this[sc] + this[Cb] && a.y >= this.top && a.y <= this.top + this[od]
});
function Dk(a,b,c){return l.min(l.max(a,b),c)};
var Ek,Fk,Gk,Hk,Ik,Jk;
(function(){//各种浏览器
	Jk = Ik = Hk = Gk = Fk = Ek = j;
	var a = Pf();
	if (a) 
		if (a[ic]("Firefox") != -1) 
			Ek = g;
		else 
			if (a[ic]("Camino") != -1) 
				Fk = g;
			else 
				if (a[ic]("iPhone") != -1 || a[ic]("iPod") != -1) 
					Gk = g;
				else 
					if (a[ic]("Android") != -1) 
						Hk = g;
					else 
						if (a[ic]("Chrome") != -1) 
							Ik = g;
						else 
							if (a[ic]("Safari") != -1) 
								Jk = g
})();
var Kk=Ik;function Lk(a){
	return new fj(a[kc], a[nd])
}
function Mk(a){return a?ye(a)||a[Kb]==3?g:nf(a,Mk):j}
var Nk=Sf&&!$f("1.9"),Ok=Sf?"MozUserSelect":Tf?"WebkitUserSelect":i;
function Pk(a, b, c, d, e, f, h, k){
	Df[E](this);
	this.da = a;
	this.EB = b;
	this.mM = c;
	this.Yf = d;
	this.sO = d / 2;
	this.Yq = e;
	this.qQ = f;
	this.Zf = h;
	this.eG = k ? 0 : 1
}
Q(Pk,Df);
N=Pk[v];
N.H=i;
N.ed=i;
N.Wj=30;
N.C=function(){Pk.l.C[E](this)};
N.Nm=function(a){this.H=a;this.ed=mj(a)};
N.o=function(){return this.H};
N.wc=Gd(38);
function Qk(a,b,c,d){this.gi=a;this.Ja=b;this.Zf=c||"tg";this.$B=d||j}
N=Qk[v];
N.Yf=42;
N.Ri=0;
N.vs=40;
N.Hv=i;
N.mv=i;
function Rk(a,b){a.Ri=b}
Qk[v].Mo=function(a){this.Hv=a};
Qk[v].Hr=function(){this.Hv=i};
var Sk=!(oh||qh),Tk="top",Uk="borderColor",Vk="bgColor",Wk="icons";
function Xk(a, b, c, d, e, f){
	var h = new Nh;
	Sh(h, 2, Sk);
	var k = a.Ja.mi(d), p = 0;
	if (a.Ja.ho(d)) 
		p = 2;
	else 
		if (a.Ja.io(d)) 
			p = 1;
	k = Rh(k, p);
	h.Dx = k.bgColor;
	h.Fx = k.borderColor;
	k = Yk(a, b);
	h.sM = k;
	h.FG = e * 100;
	h.DG = Qh;
	h.HG = Ph;
	b = Ki(pi(c, b));
	h.kk(b / 60 * a.Yf);
	h.Cw(f * 100, Qh);
	f = a.Ja.io(d);
	Sh(h, 1, f);
	f = a.Ja.Mu(d);
	Sh(h, 4, f);
	f = a.Ja.il(d);
	if (b > 30) {
		b = Zk(a, d.da, d.va);
		c = O;
		h.Zo = f
	}
	else {
		b = Zk(a, d.da, d.va, f);
		c = f
	}
	b = a.Ja.fl(d, g) + b + a.Ja.kl(d, g);
	h.sL(b, c);
	a = "ca-evp" + Be(d);
	h.BF[o](a);
	d = "ca-elp" + Be(d);
	h.yD = d;
	Sh(h, 8, !!d);
	d = Zh.A();
	h.ab = d.jM[h.al];
	h.ab.b("classes", h.BF[M](X));
	d = [];
	!!(h.al & 1) && d[o]("cro");
	!!(h.al & 2) || d[o]("cbrd");
	h.ab.b("extraClasses", d[M](X));
	h.ab.b(Tk, h.sM);
	h.ab.b("offset", h.FG);
	h.ab.b("offsetUnit", h.DG);
	h.ab.b("edge", h.HG);
	h.ab.b(vj, h.zf);
	h.ab.b("widthUnit", h.RM);
	d = Vh(h.wl, !!(h.al & 2));
	h.ab.b(uj, d);
	h.ab.b(Uk, h.Fx);
	h.ab.b(Vk, h.Dx);
	h.ab.b("captionColor", h.al & 1 ? h.Dx : h.Fx);
	Uh(h, h.ft, h.rF, "caption");
	Uh(h, h.Zo, h.Zo, "text");
	h.yD && h.ab.b("titleClass", h.yD);
	if (h.gA) {
		d = [];
		a = [];
		for (f = 0; f < h.gA[s]; f++) {
			b = h.gA[f];
			(b == "cic-ques" ? d : a)[o]($g(b))
		}
		h.ab.b("beforeIcons", d[M](O));
		h.ab.b(Wk, a[M](O))
	}
	else {
		h.ab.b("beforeIcons", O);
		h.ab.b(Wk, O)
	}
	return h = h.ab[q]()
}
function Zk(a, b, c, d){
	b = a.gi.Xa(b.yf(), g, g);
	return Xd(b, d || a.gi.Xa(c.yf(), g, g))
}
var $k="id";
Qk[v].oa = function(a, b, c){
	var d = a[s], e = this.Hv, f = c && c.V(), h = 24 * this.Yf;
	e[o]('<table id="', this.Zf, 'Table" class="tg-timedevents" cellpadding="0" cellspacing="0" style="height:', h, 'px">');
	var k = c || i, p = this.Hv, r = this.gi, t = '<td style="width:' + this.vs + 'px;"></td>';
	p[o]("<tr>", t);
	this.Ri && p[o](t);
	p[o]('<td colspan="', d, '"><div class="tg-spanningwrapper" id="', this.Zf, 'spanningwrapper"><div class="tg-hourmarkers" style="font-size:', this.Yf / 2 - 1, 'px">');
	for (t = 0; t < 24; t++) 
		p[o]('<div class="tg-dualmarker"></div>');
	p[o]("</div></div></td></tr>");
	p[o]('<tr><td class="tg-times');
	this.Ri && p[o](" tg-timesnotlast");
	p[o]('" style="width:', this.vs, 'px;">');
	if (k) {
		k = Yk(this, k);
		p[o]('<div id="', this.Zf, 'nowptr" class="tg-nowptr" style="left:0;top:' + (k - 4) + 'px;"></div>')
	}
	k = Pi(2000, 1, 1, 0, 0, 0);
	var u;
	if (this.Ri) {
		u = Qi(k);
		u.T += this.Ri
	}
	t = '<div class="tg-time" style="height:' + (this.Yf - 1) + 'px">';
	for (var x = [], y = 0; y < 24; ++y) {
		var D = k.X();
		p[o](t, r.Xa(D, g), Lh);
		if (this.Ri) {
			x[o](t, r.Xa(u.X(), g), Lh);
			u.S++
		}
		k.S++
	}
	p[o](aj);
	if (this.Ri) {
		p[o]('<td class="tg-times">');
		p[o](x[M](O));
		p[o](aj)
	}
	p = this.ZM;
	r = "height:" + h + "px;margin-bottom:-" + h + "px;";
	p.b("heightStyles", r);
	u = b;
	for (h = 0; h < d; h++) {
		t = [];
		p.b($k, this.Zf + "Col" + h);
		k = a[h];
		if (k[s]) {
			t = k[s];
			x = [];
			y = [];
			D = [];
			for (var H = 0; H < t; ++H) {
				var J = k[H], ga = J.da;
				if (ga.F != u.F) 
					ga = u.X();
				for (var La = Pg(ga), Ia = 0; y[Ia] > La;) 
					Ia++;
				var Hb = J.va;
				if (Hb.F == u.F && Pg(Hb) - La < 30) {
					Hb = qi(ga);
					Hb.T += 30;
					Hb = Hb.X()
				}
				if (Hb.F != u.F) 
					Hb = ti(u).X();
				J = new zk(J, ga, Hb, Ia);
				(ga = D[Ia]) || (ga = D[Ia] = []);
				ga[o](J);
				y[Ia] = Pg(Hb) || 1440;
				x[Ia] = J;
				if (Ia != 0) {
					J.dv = [x[Ia - 1]];
					x[Ia - 1].lw[o](J)
				}
				for (Ia = Ia + 1; y[Ia] <= La;) 
					Ia++;
				if (La = x[Ia]) {
					J.lw[o](La);
					La.dv[o](J)
				}
			}
			k = D;
			k = Array[v][Wb][fd]([], k);
			t = k[s];
			D = y = x = undefined;
			for (y = t; y--;) {
				H = 1;
				La = 0;
				x = k[y];
				for (D = x.lw[s]; D--;) {
					Ia = x.lw[D];
					La = l.max(La, Ia.VL);
					H = l.min(H, Ia[sc])
				}
				x.VL = La + 1;
				ya(x, H / (x.PO + 1));
				Ka(x, H - x[Cb])
			}
			for (y = 0; y < t; y++) {
				x = k[y];
				Ka(x, 0);
				if (x.dv) 
					for (D = x.dv[s]; D--;) {
						H = x.dv[D];
						Ka(x, l.max(x[sc], H[sc] + H[Cb]))
					}
				D = (1 - x[sc]) / x.VL;
				ya(x, l.max(x[Cb], D));
				x.aQ = l.min(1 - x[sc], x[Cb] + 0.7 * D)
			}
			k = k;
			t = [];
			x = k[s];
			y = undefined;
			for (y = 0; y < x; y++) 
				t[o](Xk(this, k[y][F], k[y].W, k[y][Ed], k[y][sc], k[y].aQ));
			t = t
		}
		t[s] == 0 && t[o]("&nbsp;");
		x = k = O;
		if (f && u == f) {
			k = '<div class="tg-today" style="' + r + '">&nbsp;</div>';
			x = '<div class="tg-hourmarker tg-nowmarker" id="' + this.Zf + 'nowmarker" style="top: ' + Yk(this, c || i) + 'px;"></div>'
		}
		p.b("dayBg", k);
		p.b("nowMarker", x);
		p.b("colClasses", di(u.Ka()) ? "tg-col tg-weekend" : "tg-col");
		p.b("events", t[M](O));
		e[o](p[q]());
		this.$B || (u = ti(u))
	}
	e[o]("</tr>");
	e[o]("</table>");
	c = (this.Ri ? 2 : 1) * this.vs + 3;
	f = e = NaN;
	a = Array[v][Wb][fd]([], a);
	p = a[s];
	for (h = 0; h < p; h++) {
		u = a[h];
		r = Pg(u.da);
		u = Pg(u.va);
		if (!(u < r)) 
			if (pa(e)) {
				e = r;
				f = u
			}
			else {
				e = l.min(e, r);
				f = l.max(f, u)
			}
	}
	a = pa(e) ? i : new Bk(e, f);
	this.mv = new Pk(b, d, c, this.Yf, j, a, this.Zf, this.$B)
};
function Yk(a, b){
	return (b.S + b.T / 60) * a.Yf | 0
}
function al(a, b, c){
	for (var d = [], e = {}, f = 0; f < c; f++) {
		d[f] = [];
		e[wi(b, f).Sa()] = f + 1
	}
	f = 0;
	for (b = a[s]; f < b; f++) {
		c = a[f];
		var h = e[c.da.Sa()];
		h && d[h - 1][o](c);
		var k = e[c.va.Sa()];
		k && k != h && !c.Ry && d[k - 1][o](c)
	}
	return d
}
Qk[v].ZM=new W('<td class="${colClasses}">${dayBg}<div class="tg-col-eventwrapper" style="${heightStyles}">${events}</div><div class="tg-col-overlaywrapper" id="${id}">${nowMarker}</div></td>');
var bl=new Bk(5,20);
function cl(a, b, c, d, e){
	var f = [];
	if (c) {
		c = Pg(c);
		f[o](c);
		e && f[o](c + e, c - e)
	}
	if (d) {
		c = Pg(d);
		f[o](c);
		e && f[o](c + e, c - e)
	}
	(d = a.qQ) && f[o](d[F], d.W);
	f[o](bl[F] * 60, bl.W * 60, 1440, 0);
	a = a.Yf;
	d = a * 24;
	c = e = NaN;
	for (var h = 0; h < f[s]; ++h) {
		var k = Dk(f[h] * a / 60, 0, d);
		if (pa(e)) 
			e = c = k;
		else {
			if (k < e) 
				e = l.max(k, c - b);
			else 
				if (k > c) 
					c = l.min(k, e + b);
			if (c - e >= b) 
				break
		}
	}
	return e
};
function dl(a,b,c,d){this.gi=a;this.$=ma(b);this.Im=c;this.Kh=d}
function el(a,b,c){this.qW=a;this.wD=b||0;this.dX=c||O}dl[v].$o=new el(O);
dl[v].TC=function(a){this.gi=a};
function fl(a, b, c){
	var d = a.$o.qW, e = a.$o.dX, f = a.$o.wD, h = [];
	h[o]('<td class="wk-tzlabel" style="width:60px;" rowspan="3">', d);
	f && h[o](aj, '<td class="wk-tzlabel" style="width:60px;" rowspan="3">', e);
	b && h[o]('<div id="' + ("allday-disclose" + a.$) + '" style="left:' + (60 * (a.$o.wD ? 2 : 1) - 14) + 'px;" class="wk-disclose goog-zippy-' + (c ? "collapsed" : "expanded") + '"><div class="wk-zip"></div></div>');
	h[o](aj);
	return h[M](O)
};
function gl(){
	V[E](this);
	this.Ja = new dj(new Vg);
	this.Ug = new ak(hl, this.Ja, g);
	this.QY = new ak(hl, this.Ja, g, g, g);
	this.Kh = new Qk(hl, this.Ja);
	this.Oh = new dl(hl, "wk", this.QY, this.Kh);
	this.lv = new cj(hl, this.Ug, O);
	this.Mf = {};
	this.uc = [];
	this.Cp = il(jl(), "CollapseAllday", j)
}
Q(gl,V);
qe(gl);
N=gl[v];
N.QA=O;
N.BI=i;
N.NA=i;
N.Rj=0;
N.gw=j;
N.Ff=i;
N.HC=0;
function kl(){return ll.On.Zq}
gl[v].rq=Gd(29);
var ml="gridcontainer";
function nl(){return qj(ml)}
function ol(a){return qj("scrolltimedevents"+a.Oh.$)}
var pl="_";
gl[v].refresh = function(a, b, c, d){
	if (this[A]("gcal-er-br")) {
		var e = ql();
		rl();
		var f = qj(ml)[sd];
		sl(e, "refresh_resize");
		var h = c.SM;
		b = c.gH == i ? b : zi(b, c.gH);
		var k = l[Mb](tl(ul) / 7), p = new Ui(a, b, k, h, h + c.DX);
		k = !this.Ff || !p.ba(this.Ff);
		this.Ff = p;
		p = wi(b, this.Ff.Hn());
		if (d) 
			p = [];
		else {
			p = Y.oN(new Ri(b, p), vl);
			p[Xc](this.Ja.Gn())
		}
		var r = i;
		d = wl(xl);
		var t = yl(g);
		if (c.Zq) {
			a = R(jl().O("tzlabel", O));
			r = R(jl().O("sectzlabel", O));
			c = zl();
			var u = Al();
			f = 0;
			if (Bl() && u && u != c) {
				var x = Cl([c, u]);
				if (x[c] && x[u]) {
					x = ul;
					f = x.Ua;
					x = tl(x);
					var y = xl.GX;
					f = Date.UTC(f.K, f.J - 1, f.F, 0, 0, 0) + x * 86400000 / 2 - y;
					{
						f = f / 60000;
						if (u == c) 
							f = 0;
						else {
							x = Cl([u, c]);
							u = x[u];
							c = x[c];
							f = u && c ? Dl(u, f) - Dl(c, f) : i
						}
					}
				}
			}
			c = f || 0;
			this.Oh.TC(t);
			this.Oh.$o = new el(a, c, r);
			a = this.Oh;
			t = !!this.Cp;
			c = [];
			y = j;
			u = {};
			r = [];
			f = 0;
			for (x = p[s]; f < x; f++) {
				var D = p[f];
				if (D.bd || D.Dl || D.ml()) {
					c[o](D);
					if (!D.ml() && !y) 
						a: {
							y = D.da.V();
							D = D.va.V();
							var H = b.max(y);
							y = wi(b, h).min(D);
							for (D = H; D.L() < y.L(); D = ti(D)) {
								H = D.Sa();
								if (u[H]) {
									y = g;
									break a
								}
								else 
									u[H] = g
							}
							y = j
						}
				}
				else 
					r[o](D)
			}
			u = [];
			u[o]('<table class="wk-weektop" cellpadding="0" cellspacing="0"><tr class="wk-daynames">');
			u[o](fl(a, y, t));
			f = d.V();
			for (y = 0; y < h; y++) {
				x = wi(b, y);
				D = h == 1 ? a.gi.ih(x) : a.gi.iq(x);
				u[o]('<th title="', D, '" scope="col"><div class="wk-dayname');
				x.ba(f) && u[o](" wk-today");
				u[o]('"><span class="', "ca-cdp" + x.Sa(), ' wk-daylink">', D, "</span></div></th>")
			}
			u[o](['<th class="wk-dummyth" rowspan=3 style="width: ', qk() - 1, 'px;">&nbsp;</th>'][M](O));
			u[o]("</tr>");
			u[o]("<tr>");
			u[o]('<td class="wk-allday" colspan="', h, '"><div id="', "weekViewAllDay" + a.$, Th);
			a.Im.Mo(u);
			bk(a.Im);
			t = new Zi(c, b, h, t ? 1 : 200, g);
			bj(t, a.Im);
			ck(a.Im);
			u[o]("</div></td>");
			u[o]('</tr><tr class="wk-webcontent">');
			t = t.RD;
			for (c = 0; c < h; c++) {
				u[o]('<td class="wk-webcontent-td">');
				ek(a.Im, t[c]);
				u[o](aj)
			}
			a.Im.Hr();
			u[o]("</tr>");
			u[o]("</table>");
			t = [];
			t[o](mk);
			c = a.$o.wD;
			a.Kh.vs = 60;
			c && Rk(a.Kh, c);
			a.Kh.Mo(t);
			h = al(r, b, h);
			a.Kh.oa(h, b, d);
			a.Kh.Hr();
			t[o](nk);
			b = {
				sY: u[M](O),
				iY: t[M](O)
			};
			h = b.sY;
			r = b.iY
		}
		else {
			this.lv.TC(t);
			b = this.lv;
			h = this.Ff;
			t = xl.Pa;
			c = l[Pb](((f - 14) / h.Ge - 17) / 17);
			u = [];
			u[o]('<div class="mv-container"><table cellpadding=0 cellspacing=0 class="mv-daynames-table"><tr>');
			for (x = 0; x < h.kc; x++) {
				y = Ii(Wi(h)[0 * h.kc + x]).Ka();
				y = b.$h.cu(y);
				u[o]('<th class="mv-dayname" title="', y, Th, y, "</th>")
			}
			u[o]('</tr></table><div class="mv-event-container" id="mvEventContainer', b.hA, Qe);
			T && u[o](' style="height:', f - 14, 'px"');
			u[o](Pe);
			f = 100 / h.Ge;
			b.Ug.Mo(u);
			for (x = 0; x < h.Ge; x++) {
				y = Ii(Wi(h)[x * h.kc + 0]);
				u[o]('<div class="month-row" style="top:', f * x, "%;height:", f, '%">');
				D = b.Ug.se;
				D[o]('<table cellpadding=0 cellspacing=0 class="st-bg-table"><tr>');
				H = h.kc;
				for (var J = y; H--; J = ti(J)) {
					D[o]('<td class="st-bg');
					J.ba(t) && D[o](" st-bg-today");
					D[o]('">&nbsp;')
				}
				D[o]("</table>");
				bk(b.Ug);
				D = new Zi(p, y, h.kc, c);
				H = b.Ug;
				J = P(b.$h.Cn, b.$h);
				var ga = H.se;
				ga[o]("<tr>");
				for (var La = 0; La < h.kc; La++) {
					var Ia = wi(y, La);
					ga[o]('<td class="st-dtitle');
					t.ba(Ia) && ga[o](" st-dtitle-today");
					Ia.J != a.J && ga[o](" st-dtitle-nonmonth");
					ga[o](Th);
					ek(H, D.RD[La]);
					ga[o]('<span class="' + ("ca-cdp" + Ia.Sa()) + Th, J(Ia), Ch)
				}
				bj(D, b.Ug);
				ck(b.Ug);
				u[o](Lh)
			}
			u[o](Lh);
			b.Ug.Hr();
			h = u[M](O)
		}
		b = pl + this.Ff.Hn();
		sl(e, "refresh_computeContent_" + b);
		this.uc = p;
		this.Mf = {};
		for (a = 0; a < p[s]; a++) 
			this.Mf[Be(p[a])] = p[a];
		if (h != this.QA || r != this.BI) {
			this.QA = h;
			this.BI = r;
			this[A]("gcal-er-u");
			this.gw = g;
			if (kl(this)) {
				if (!ol(this)) 
					m(nl(this), '<div id="' + ("topcontainer" + this.Oh.$) + '"></div><div id="' + ("scrolltimedevents" + this.Oh.$) + '" class="wk-scrolltimedevents"></div>');
				m(qj("topcontainer" + this.Oh.$), h);
				p = ol(this);
				m(p, r);
				El(this);
				h = this.Kh.mv;
				h.Nm(p[G]);
				Fl(this);
				if (k || !this.NA || p[pb] == this.Rj) {
					this.Rj = cl(h, p[Vc], d, undefined, 30);
					qa(p, this.Rj)
				}
				this.NA = h
			}
			else {
				m(nl(this), h);
				El(this)
			}
			this[A]("gcal-er-r");
			sl(e, "refresh_insertDom_" + b)
		}
		else 
			this[A]("gcal-er-s")
	}
};
function Gl(a){m(nl(a),O);Hl(j)}
function Il(a){a.QA=O}
function Jl(a){var b=ol(a);if(b&&a.HC)qa(b,a.HC);a[A]("gcal-er-r")}
gl[v].CD=Gd(39);
gl[v].Wa = function(){
	Il(this);
	Kl(this);
	this.Mf = {};
	this.uc = [];
	this.Ff = i;
	this[A]("gcal-er-u");
	this.gw = j
};
function Fl(a){
	if (a.gw && kl(a)) {
		var b = ol(a);
		if (b) {
			var c = nl(a);
			a = pj("topcontainer" + a.Oh.$);
			c = l.max(100, c[sd] - a[sd] - 2) + Oh;
			if (a = qj("bgImage")) 
				jb(a[B], c);
			jb(b[B], c)
		}
	}
}
function Kl(a){var b=qj("bgImage");b&&Ej(b);xa(nl(a),O)}
function El(a){
	var b = nl(a), c = ha && Je.jg && jl().O("BackgroundImage", O) || i;
	if (c) {
		var d = qj("bgImage"), e = !d;
		if (e) {
			d = document[Pc]("img");
			d.id = "bgImage";
			xa(b, "bg-exists")
		}
		if (d.src != c) {
			Ca(d, P(a.ZN, a));
			d.src = c
		}
		if (e) 
			if (kl(a)) {
				Ua(d[B], "bottom:1px;left:0;;width:100%;position:absolute");
				b[gc](d, b[G])
			}
			else {
				Ua(d[B], "top:0;height:100%;left:0;width:100%;position:absolute");
				a = qj("mvEventContainer" + a.lv.hA);
				a[gc](d, a[G])
			}
	}
	else 
		Kl(a)
}
gl[v].ZN=function(){jl().set("BackgroundImage",O);jl().Kb();Il(this)};
gl[v].Gr=Gd(54);
var Ll={index:4,name:"guests"},Ml={index:5,name:"myresponse"},Nl={index:6,name:"options"},Ol={index:8,name:"comments"},Pl={index:11,name:"invite-yourself"},Ql="blank.gif",Rl="combined_v7.gif",_dbmode=j;
var Sl=[];
function Tl(a,b){Sl[o]([a,b])}
Tl("last updated",function(){return new Date});
var Ul=/^(https?:\/\/[^\/]*)\/calendar(\/((hosted)|(a))\/[^\/]*)?/,Vl=typeof window!="undefined"?window[dc][$c]:O;Vl[w](/#.*/,O);
function Wl(a){return!!(a&&a[Dc](/^(?:https?:)?\/\/(?:[^:\/]+\.)?google\.com(?::\d+)?(?:\/.*$|$)/))}
function Xl(a){return Wl(a)?a[w](/^https?:\/\//i,"//"):a}
function Yl(a){return oa(ma(a)[w](/^(?:(?:[^:\/]+:)?\/\/[^\/]*)/,O)[w](/^.*\/|[?#].*$/g,O))}
function Zl(a){
	a = (a = (a || Vl)[Dc](Ul)) && a[2];
	if (!a) 
		return i;
	return a[Ob]("/")[1]
}
function $l(a){return(a=(a||Vl)[Dc](Ul))&&a[1]||i};
function am(a,b){this.mc=a;this.hI=b}
am[v].eb=function(){return this.mc||O};
am[v].FA=function(){if(this.hI)return g;return j};
function bm(a, b, c){
	switch (typeof b) {
		case xe:
			cm(a, b, c);
			break;
		case re:
			c[o](isFinite(b) && !pa(b) ? b : "null");
			break;
		case "boolean":
			c[o](b);
			break;
		case "undefined":
			c[o]("null");
			break;
		case "object":
			if (b == i) {
				c[o]("null");
				break
			}
			if (ve(b)) {
				var d = b[s];
				c[o]("[");
				for (var e = O, f = 0; f < d; f++) {
					c[o](e);
					bm(a, b[f], c);
					e = ","
				}
				c[o]("]");
				break
			}
			c[o]("{");
			d = O;
			for (e in b) 
				if (b[mc](e)) {
					f = b[e];
					if (typeof f != se) {
						c[o](d);
						cm(a, e, c);
						c[o](de);
						bm(a, f, c);
						d = ","
					}
				}
			c[o]("}");
			break;
		case se:
			break;
		default:
			aa(Error("Unknown type: " + typeof b))
	}
}
var dm={'"':'\\"',"\\":"\\\\","/":"\\/","\u0008":"\\b","\u000c":"\\f","\n":"\\n","\r":"\\r","\t":"\\t","\u000b":"\\u000b"},em=/\uffff/[vb]("\uffff")?/[\\\"\x00-\x1f\x7f-\uffff]/g:/[\\\"\x00-\x1f\x7f-\xff]/g;
function cm(a, b, c){
	c[o](Qe, b[w](em, function(d){
		if (d in dm) 
			return dm[d];
		var e = d[Wc](0), f = "\\u";
		if (e < 16) 
			f += "000";
		else 
			if (e < 256) 
				f += "00";
			else 
				if (e < 4096) 
					f += ce;
		return dm[d] = f + e[q](16)
	}), Qe)
};
function fm(a){am[E](this,a.t,Xl(a.i));this.ka=a}
Q(fm,am);
var gm=Bf([2,1,0,3]);
fm[v].nl=Gd(44);
fm[v].el=Gd(26);
fm[v].ll=function(){return this.ka.u};
fm[v].lb=Gd(36);
function hm(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H){
	Ng[E](this, a, c, d);
	this.we(b || O);
	this.R = f;
	this.wi = r || O;
	this.Z = k;
	this.Yc = e;
	this.$e = h;
	this.ek = p;
	this.He = t;
	this.Mm = i;
	this.ps = u;
	this.Ke = x ||
	{};
	this.Yv = y ||
	{};
	this.uE = (this.Og = D) ? im(D) : i;
	this.Od = H
}
Q(hm,Ng);
var jm=new RegExp("\u0001","g"),km=new RegExp("\u0002","g");
hm[v].SD=i;
hm[v].vw = function(a, b){
	hm.l.vw[E](this, a.X(), b.X());
	var c = pa(a.S);
	this.bd = c;
	this.Ry = !c && this.Ry;
	this.Oi = a.Sa();
	a = b.Sa();
	if (a == this.Oi || b.S || b.T || b.ha) 
		a = Og(a);
	this.tj = a
};
hm[v].Od=i;
hm[v].Ga = function(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H){
	hm[E](this, a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H)
};
function im(a){for(var b=[],c=0;c<a[s];++c){var d=a[c];3==d[gd]&&b[o](d.Qd)}return b}
function lm(a){if(!a.Mm){a.Mm=ye(a.ps)?mm(a.ps):a.ps||{};a.ps=i}return a.Mm}
function mm(a){
	if (a[s] == 0) 
		return {};
	a = a[Ob]("\u0001");
	for (var b = a[s], c = {}, d = 0; d < b; ++d) {
		var e = a[d][Ob]("\u0002"), f = e[s];
		c[e[0]] = {
			rb: e[1] | 0,
			FF: f >= 2 ? e[2] || i : i,
			Zj: f >= 3 ? e[3] | 0 : 0,
			Th: f >= 4 ? e[4] || i : i
		}
	}
	return c
}
hm[v].Lq=Gd(42);
hm[v].DA=Gd(37);
sa(hm[v],function(){var a=this.eb();if(a[s]>16)a=a[I](0,13)+"...";return"[Event "+this.I()+": "+a+" on "+this.R+"]"});
hm[v].ml = function(){
	var a = this.Ke && this.Ke["goo.richContent"];
	if (a && !this.SD) 
		this.SD = new fm(a);
	return this.SD
};
function nm(a, b, c, d){
	this.Tj = a;
	this.kG = b;
	this.mU = c;
	this.Y = d
}
Q(nm,Df);
nm[v].ua=window;
nm[v].ss=i;
nm[v].Qr=i;
nm[v].fv=i;
function om(a){
	if (a.ss == i) 
		a.ss = a.ua[Yb](P(a.WB, a), a.kG / 2);
	a.Qr = Ge();
	if (a.fv == i) 
		a.fv = a.Qr
}
nm[v].C = function(){
	nm.l.C[E](this);
	if (this.ss != i) {
		this.ua[cd](this.ss);
		this.ss = i
	}
	this.Y = this.Tj = i
};
nm[v].WB = function(){
	if (!(this.Qr == i)) {
		var a = Ge();
		if (a >= this.Qr + this.kG || a >= this.fv + this.mU) {
			this.Tj[E](this.Y);
			this.Qr = i;
			this.fv = a
		}
	}
};
function pm(a,b,c){this.K=a;this.J=b;this.F=c}
Q(pm,Ci);
oi[v].ib=Gd(22);
N=pm[v];
N.ib=Gd(21);
N.qb=function(){return!!(this.K&&this.J&&this.F)};
N.L = function(){
	if (this.Ve === undefined) 
		this.Ve = this.qb() ? ii(this.K, this.J, this.F) : NaN;
	return this.Ve
};
N.ba=function(a){return this[Xb]===a[Xb]&&this[q]()==a[q]()};
N.um=function(){return Xe(this.K?ma(this.K):"????",ai(this.J),ai(this.F))};
function qm(a, b, c, d, e, f){
	this.K = a;
	this.J = b;
	this.F = c;
	this.S = d;
	this.T = e;
	this.ha = f
}
Q(qm,Ci);
qm[v].ib=Gd(20);
oi[v].Sd=Gd(8);
N=qm[v];
N.Sd=Gd(7);
N.qb=function(){return!!(this.K&&this.J&&this.F)&&!(pa(this.S)||pa(this.T)||pa(this.ha))};
N.L = function(){
	if (this.Ve === undefined) 
		this.Ve = this.qb() ? ((this.K - 1970 << 4) + this.J << 5) + this.F + (((this.S << 6) + this.T << 6) + this.ha + 1) * 7.62939453125E-6 : NaN;
	return this.Ve
};
N.ba=function(a){return this[Xb]===a[Xb]&&this[q]()==a[q]()};
N.um = function(){
	return Xe(this.K ? ma(this.K) : "????", ai(this.J), ai(this.F), Di, ai(this.S), ai(this.T), ai(this.ha))
};
function rm(a, b){
	Sa(this, a);
	this.W = b;
	try {
		this.Jf = pi(this.W, this[F])
	} 
	catch (c) {
		this.Jf = i
	}
}
sa(rm[v],function(){return this[F]+"/"+this.W});
rm[v].ba=function(a){return this[Xb]===a[Xb]&&this[F].ba(a[F])&&this.W.ba(a.W)};
function sm(a){
	var b = a[ic]("/");
	if (b >= 0) {
		var c = sm(a[I](0, b));
		a = sm(a[I](b + 1));
		return pa(c.L() + a.L()) ? new rm(c, a) : new Ri(c, a)
	}
	else 
		return a[ic]("?") < 0 ? tm(a) : um(a)
}
/** a第一个字符为0~9则调用Ti(a) */
function tm(a){
	var b = a[Wc](0);
	//"T" 的 Unicode 编码为 84
	return b >= 48 && b < 58 ? Ti(a) : b == 84 ? Pi(0, 0, 0, Si(a, 1), Si(a, 3), Si(a, 5)).yf() : a[Wc](0) == 80 ? vm(a[I](1), 1) : vm(a[I](2), 44 - b)
}
function vm(a, b){
	for (var c = a[s], d = new Li, e = 0; e < c; e += 1) {
		var f = 0, h = 0;
		do {
			h = a[Zb](e);
			if (h < ce || h > "9") 
				break;
			f += 1
		}
		while ((e += 1) < c);
		if (!(f === 0)) {
			h = 0;
			for (f = e - f; f < e; ++f) 
				h = h * 10 + (a[Wc](f) - 48);
			f = h;
			h = f * b;
			switch (a[Zb](e)) {
				case "W":
					d.F += 7 * h;
					break;
				case "D":
					d.F += h;
					break;
				case "H":
					d.S += h;
					break;
				case "M":
					d.T += h;
					break;
				case "S":
					d.ha += h;
					break;
				default:
					aa(new Error("Bad duration: " + a))
			}
		}
	}
	return new si(d.F, d.S, d.T, d.ha)
}
var wm=/^(?:([0-9]{4,})|\?{4})(?:([0-9]{2})|\?{2})(?:([0-9]{2})|\?{2})$/,xm=new RegExp("^(?:([0-9]{4,})|\\?{4})(?:([0-9]{2})|\\?{2})(?:([0-9]{2})|\\?{2})T(?:([0-9]{2})|\\?{2})(?:([0-9]{2})|\\?{2})(?:([0-9]{2})|\\?{2})$");
function ym(a){
	var b = a[ic]("/"), c = a[s];
	if (b >= 0) 
		return new rm(ym(a[I](0, b)), ym(a[I](b + 1, c)));
	return um(a)
}
function um(a){
	var b = a[Dc](xm);
	b || (b = a[Dc](wm));
	for (a = b[s]; --a >= 1;) 
		b[a] = b[a] ? ka(b[a], 10) : NaN;
	return 7 === b[s] ? new qm(b[1], b[2], b[3], b[4], b[5], b[6]) : new pm(b[1], b[2], b[3])
};
function zm(){
	V[E](this);
	this.Lf = {};
	this.Bh = {};
	this.Ck = {};
	this.sc = [];
	this.Kg = [];
	this.Hx = this.Rm = j;
	this.Qm = [];
	this.xi = [];
	this.Yk = 0;
	this.Ul = {};
	this.bj = i;
	this.uP = new nm(this.lQ, 1000, 5000, this)
}
Q(zm,V);
function Am(a,b){return a.Lf[b]||i}
zm[v].Xl = function(a){
	var b = this.Lf[a];
	if (b) {
		this[A](new Bm(a));
		Cm(this, b, b.Oi, b.tj);
		delete this.Lf[a];
		b.ek && delete this.Ul[b.ek][a];
		--this.Yk;
		this[A](Dm)
	}
	return b
};
Wa(zm[v],function(a){for(var b in this.Lf)if(a(this.Lf[b])===j)break});
zm[v].lQ=function(){if(this.bj){this[A](this.bj);this.bj=i}};
function Em(){U[E](this,"estoreadd");this.JG=[]}
Q(Em,U);
function Bm(a){U[E](this,"estoredelete");this.un=a}
Q(Bm,U);
function Fm(a,b){U[E](this,"estorerenumber");this.O_=a;this.K_=b}
Q(Fm,U);
var Dm="estorechange";
zm[v].oN = function(a, b){
	var c = a[q]() + de + b.toCacheKey(), d = this.Bh[c];
	if (undefined !== d) 
		return d;
	Gm(this);
	var e = Hm(this, a[F].Sa()), f = Hm(this, Im(a[F], a.W).Sa());
	d = [];
	var h = {};
	for (e = e; e < f; ++e) 
		for (var k = Jm(this, e), p = 0; p < k[s]; ++p) {
			var r = k[p];
			if (!h[r.I()]) {
				h[r.I()] = g;
				var t;
				(t = r.va.L() >= a[F].L() && r.da.L() <= a.W.L()) && b(r) && d[o](r)
			}
		}
	Km(this, c, d);
	return d
};
function Lm(a, b, c, d, e){
	var f = b[q]() + " +" + c + de + d.toCacheKey(), h = a.Bh[f];
	if (undefined !== h) 
		return h;
	Gm(a);
	h = b.Sa();
	var k = Hm(a, h), p = k < a.sc[s] && a.sc[k].Gf === h;
	h = [];
	c = c;
	var r = {};
	for (k = k; k < a.sc[s]; ++k) {
		for (var t = Jm(a, k), u = j, x = 0; x < t[s]; ++x) {
			var y = t[x];
			if (!e) {
				if (r[y.I()]) 
					continue;
				r[y.I()] = g
			}
			if ((!p || y.va.L() > b.L()) && d(y)) {
				if (!u) {
					e && h[o](Ii(t.Gf));
					u = g
				}
				h[o](y);
				if (--c <= 0) {
					k = a.sc[s];
					break
				}
			}
		}
		p = j
	}
	Km(a, f, h);
	return h
}
function Mm(a, b, c, d, e){
	var f = b[q]() + " -" + c + de + d.toCacheKey(), h = a.Bh[f];
	if (undefined !== h) 
		return h;
	Gm(a);
	h = Nm(b).Sa();
	var k = Hm(a, h), p = k > 0 && h == Og(a.sc[k - 1].Gf);
	h = [];
	c = c;
	var r = {};
	for (k = k; --k >= 0;) {
		for (var t = Jm(a, k), u = j, x = t[s]; --x >= 0;) {
			var y = t[x];
			if (!e) {
				if (r[y.I()]) 
					continue;
				r[y.I()] = g
			}
			if ((!p || y.da.L() < b.L()) && d(y)) {
				h[o](y);
				u = g;
				if (--c <= 0) {
					k = -1;
					break
				}
			}
		}
		u && e && h[o](Ii(t.Gf));
		p = j
	}
	h.reverse();
	Km(a, f, h);
	return h
}
function Hm(a, b){
	var c = a.Ck[b];
	if (undefined !== c) 
		return c < 0 ? ~ c : c;
	for (var d = c = 0, e = a.sc[s] - 1, f = j; e >= d;) {
		c = e + d >> 1;
		var h = a.sc[c].Gf - b;
		if (0 === h) {
			f = g;
			break
		}
		else 
			if (h < 0) 
				d = c + 1;
			else 
				e = c - 1
	}
	if (c < a.sc[s] && b > a.sc[c].Gf) 
		c += 1;
	a.Ck[b] = f ? c : ~ c;
	return c
}
function Gm(a){
	a.Rm && a.sc[Xc](Om);
	if (a.Hx || a.Rm) {
		a.Ck = {};
		for (var b = a.sc[s]; --b >= 0;) 
			a.Ck[a.sc[b].Gf] = b;
		a.Hx = j
	}
	if (a.Rm) 
		a.Rm = j
}
function Km(a,b,c){if(!a.Bh.size||a.Bh.size>10){a.Bh={};a.Bh.size=0}a.Bh[b]=c;++a.Bh.size}
function Jm(a,b){a=a.sc[b];if(a.ce){a[Xc](Pm);a.ce=j}return a}
function Qm(a,b){return Rm(a.xi,function(c){return c.R in b})}
function Cm(a, b, c, d){
	var e = b.I();
	delete a.Kg[e];
	var f = a.Qm;
	if (f[s]) {
		c = b.Z & 32768 ? [c, d] : Sm(f, [c, d]);
		d = j;
		f = 0;
		for (var h = c[s]; f < h;) {
			b = c[f++];
			for (var k = c[f++], p = b; p < k; p = Og(p)) {
				b = a.Ck[p];
				if (b !== undefined && b >= 0) {
					var r = a.sc[b];
					for (b = 0; b < r[s]; ++b) 
						if (r[b].I() === e) {
							r[qd](b, 1);
							d = g;
							break
						}
				}
			}
		}
		d && Tm(a)
	}
}
function Um(a, b){
	var c = a.Qm;
	if (c[s]) {
		var d = b.Oi, e = b.tj, f = [d, e];
		c = b.Z & 32768 ? f : Sm(c, f);
		if (c[s] !== 2 || d < c[0] || e > c[c[s] - 1]) 
			a.Kg[b.I()] = g;
		for (d = 0; d < c[s];) {
			e = c[d++];
			f = c[d++];
			Vm(a, b, e, f)
		}
		Tm(a)
	}
	else 
		a.Kg[b.I()] = g
}
function Vm(a, b, c, d){
	for (c = c; c < d; c = Og(c)) {
		var e = a.Ck[c];
		if (e !== undefined && e >= 0) 
			e = a.sc[e];
		else {
			e = [];
			e.Gf = c;
			a.Rm = a.Rm || !!a.sc[s] && e.Gf < a.sc[a.sc[s] - 1].Gf;
			a.Hx = g;
			a.Ck[c] = a.sc[s];
			a.sc[o](e)
		}
		e[o](b);
		e.ce = e[s] > 1
	}
}
function Tm(a){a.Bh={}}
var Y=new zm;
function Wm(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H){
	c = c;
	var J = d;
	if (typeof c == xe) 
		c = Ti(c);
	if (typeof J == xe) 
		J = Ti(J);
	d = Y.Lf[a];
	if (d === undefined) {
		d = new hm(a, b, c, J, e, f, h, k, p, r, t, u, x, y, D, H);
		++Y.Yk;
		Um(Y, d);
		p && Y.Lf[p] && Y.Xl(p)
	}
	else {
		var ga = d.Z & 7, La = d.Oi, Ia = d.tj;
		d.Ga(a, b, c, J, e, f, h, k, p, r, t, u, x, y, D, H);
		if (ga !== (d.Z & 7) || La !== d.Oi || Ia !== d.tj) {
			Cm(Y, d, La, Ia);
			Um(Y, d)
		}
	}
	if (p) {
		Y.Ul[p] || (Y.Ul[p] = {});
		Y.Ul[p][a] = g
	}
	else 
		if (b = Y.Ul[a]) {
			for (var Hb in b) 
				Y.Xl(Hb);
			delete Y.Ul[a]
		}
	Y.Lf[a] = d;
	if (!Y.bj) 
		Y.bj = new Em;
	Y.bj.JG[o](a);
	om(Y.uP);
	Y[A](Dm);
	return a = d
}
function Xm(a){return Y.Xl(a)}
function Ym(a, b){
	var c = Y.Lf[a];
	if (c) {
		c.Jo(b);
		Y.Lf[b] = c;
		delete Y.Lf[a];
		if (a in Y.Kg) {
			Y.Kg[b] = Y.Kg[a];
			delete Y.Kg[a]
		}
		c.Z &= -65;
		Y[A](new Fm(a, b));
		Y[A](Dm)
	}
}
function Im(a,b){return b.S||b.T||b.ha||a.F===b.F&&a.J===b.J&&a.K===b.K?ti(b):b.V()}
function Nm(a){return pa(a.S)||a.S||a.T||a.ha?ti(a):a.V()}
function Om(a,b){return a.Gf-b.Gf}
function Pm(a, b){
	var c = a.da.L() - b.da.L();
	if (c) 
		return c;
	if (c = a.va.L() - b.va.L()) 
		return c;
	a = a.I();
	b = b.I();
	return a == b ? 0 : a < b ? -1 : 1
}
function Zm(){var a=$m(Y.xi);if(!a[s])return undefined;return[a[0],a[a[s]-1]]}
function an(){return bn(Y.xi)};
function cn(){Df[E](this);this.he={};this.$l={}}
Q(cn,Df);
cn[v].rL=i;
var dn=cn[v].ia=i;
function en(){dn||(dn=new cn);return dn}
N=cn[v];
N.C=function(){for(var a in this.he)sg(this.he[a].Fa,"focus",this.hB,j,this);cn.l.C[E](this)};
N.Fn=Gd(62);
N.lg=Gd(10);
N.hB=function(){fn(gn,"focuswidget",undefined)};
N.bh=Gd(2);
N.Pv=function(a,b){if(this.ia)this.ia.Pv(a,b);else this.$l[a]=b};
var hn=new function(){this.jx=this.jz=i};
function _addGadget(a,b){if(hn.jx)hn.jx(a,b);else hn.jz=a};
function jn(a){if(a==1)window[dc].reload(g);else{a=window[dc][$c][w](/#.*/,Tf?"?":O);Za(window[dc],a)}}
function Z(a){return document[Sb](a)}
function kn(a, b, c){
	b(a) && c[o](a);
	for (a = a[G]; a; a = a[md]) 
		kn(a, b, c)
}
function ln(a){
	if ("pageYOffset" in a) 
		return a.pageYOffset;
	else 
		if ("documentElement" in a[Lb] && "scrollTop" in a[Lb][Bd]) 
			return a[Lb][Bd][pb];
		else 
			if ("scrollTop" in a[Lb][rc]) 
				return a[Lb][rc][pb];
	return 0
}
function mn(a){
	if ("innerHeight" in a) 
		return a[Hc];
	else 
		if ("documentElement" in a[Lb] && "clientHeight" in a[Lb][Bd]) 
			return a[Lb][Bd][Vc];
		else 
			if ("clientHeight" in a[Lb][rc]) 
				return a[Lb][rc][Vc];
	return 0
}
function _EV_Blur(a){a[$b]&&a[$b]();window[Oc]()};
var nn="i",on=new RegExp("((mailto:)?\\b\\w[\\w+\\-.]*@(?:(?:(?:(?:[a-z-]|[0-9]{0,10}[a-z-])[a-z0-9-]{0,30}\\.){1,8}((com|org|net|edu|gov|aero|biz|cat|coop|info|int|jobs|mobi|museum|name|pro|travel|[a-z][a-z])\\b))|\\d{1,3}(\\.\\d{1,3}){3}))",nn);
function pn(){};
function qn(a, b){
	this.cJ = {};
	this.fq = [];
	this.Di = i;
	this.$Y = P(this.CS, this);
	this.aZ = P(this.FS, this);
	this.KX = ye(a) ? a : O;
	this.LX = ye(b) ? b : rn
}
function sn(a){this.id=a;this.Dv=[]}
sn[v].jm=0;
sn[v].code=i;
var tn={},rn="__"+"zh_CN"[xd]()+".js";
qn[v].qo=i;
qn[v].$y=pe;
function un(a){
	if (!a.Di) {
		for (var b, c; a.fq[s] > 0;) {
			c = a.fq[wb]();
			var d = c.sB;
			c = c.RG;
			var e = vn(a, d);
			if (e.jm == 1) {
				if (c) {
					a.Di = wn(a, d, g);
					xn(a, d);
					a.Di = i
				}
			}
			else 
				if (e.jm == 0) {
					b = d;
					break
				}
		}
		if (b) {
			d = a.KX + b + a.LX;
			a.Di = wn(a, b, c);
			a.qo(d, a.$Y, a.aZ)
		}
	}
}
qn[v].CS = function(a){
	var b = this.Di.sB, c = this.Di.RG, d = vn(this, b);
	d.code = a;
	if (c) 
		xn(this, b);
	else 
		d.jm = 1;
	this.Di = i;
	un(this)
};
qn[v].FS=function(){this.$y(this.Di.sB);this.Di=i;un(this)};
/** 参数a为动态得到的js字符串 此函数加载此js文件 execute JavaScript code from a string */
function xn(a, b){
	var c = vn(a, b), d = g;
	try {
		var e = c.code;
		if (ke[vd]) //若是ie浏览器 调用execscript执行js
			ke[vd](e, "JavaScript");
		else 
			if (ke.eval) {//若是其他浏览器 调用eval执行js
				if (le == i) {
					ke.eval("var _et_ = 1;");//定义一个变量 _et_=1
					if (typeof ke._et_ != "undefined") {//判断_et_变量是否定义成功
						delete ke._et_;
						le = g//成功设置true
					}
					else 
						le = j//失败设置false
				}
				if (le)//eval有效
					ke.eval(e);
				else {//eval无效
					var f = ke[Lb], h = f[Pc]("script");
					bb(h, "text/javascript");//h.type = "text/javascript"
					h.defer = j;//defer=false 不延时
					h[n](f[ac](e));
					//h.appendChild(this.document.createTextNode(e))
					//但是这里ie会报错"意外的调用了方法或属性访问"其他浏览器正常
					//h.text =e;//建议使用这句话代替上一句
					f[rc][n](h);//this.document.body.appendChild(h)
					f[rc][wc](h)//this.document.body.removeChild(h)
				}
			}
			else //不支持eval则报错
				aa(Error("goog.globalEval not available"))
	} 
	catch (k) {
		d = j;
		a.$y(b)
	}
	if (d) 
		for (; c.Dv[s] > 0;) {
			a = c.Dv[wb]();
			try {
				a[E](i)
			} 
			catch (p) {
			}
		}
	c.jm = 2;
	c.Dv = [];
	c.code = i;
	return d
}
function wn(a,b,c){return{sB:b,RG:c}}
function vn(a,b){return a.cJ[b]||(a.cJ[b]=new sn(b))}
qn[v].wK=function(a){this.fq[o](wn(this,a,j));un(this)};
function fn(a, b, c){
	switch (vn(a, b).jm) {
		case 0:
		case 1:
			for (var d = tn[b] || [], e = 0, f = d[s]; e < f; ++e) {
				vn(a, d[e]).jm != 2 && a.fq[o](wn(a, d[e], g));
			}
			a.fq[o](wn(a, b, g));
			c && vn(a, b).Dv[o](c);
			un(a);
			break;
		case 2:
			c && c[E](i);
			break;
	}
}
function yn(a,b){a.$y=b};
function zn(a,b,c,d){this.Pe=a;this.ra=b;this.We=c;this.dg=d}
function An(a){a=a.dg;return 0==a||1==a||3==a||8==a}
function Bn(a){a=a.dg;return 1==a||3==a};
function Cn(){V[E](this);this.Tl={};this.yo={}}
Q(Cn,V);
qe(Cn);
Cn[v].C=function(){this.yo=this.Tl=i;Cn.l.C[E](this)};
var Dn="@";
function En(a, b){
	var c = a.Tl[b];
	if (c) 
		return c;
	if (b[ic](Dn) >= 0) 
		return a.yo[b];
	return i
}
Wa(Cn[v],function(a){for(var b in this.Tl)a(this.Tl[b])});
function Fn(a, b){
	for (var c = 0; c < b[s]; c += 4) {
		var d = b[c], e = ka(b[c + 1], 10);
		Gn(a, d, b[c + 3], b[c + 2], e)
	}
}
function Gn(a, b, c, d, e){
	var f = a.Tl[b];
	if (f) {
		f.ra != c && delete a.yo[f.ra];
		f.Pe = b;
		f.ra = c;
		f.We = d;
		f.dg = e
	}
	else 
		f = new zn(b, c, d, e);
	a.Tl[b] = f;
	a.yo[c] = f;
	a[A](new Hn(f))
}
function Hn(a){U[E](this,"gcal$pae");this.rW=a}
Q(Hn,U);
function In(a){Fn(Cn.A(),a)};
function Jn(a,b){this.xY=a;this.Or=b}
Jn[v].I=function(){return this.xY};
function Dl(a,b){for(var c=a.Or[s]-2;c>0;c-=2)if(b>=a.Or[c])return a.Or[c+1];return a.Or[0]}
var Kn={},Ln="1";
function Cl(a, b){
	for (var c = {}, d = g, e = b ? Fe(function(r){
		b(Mn(r))
	}, a) : i, f = ["tzMode", Ln], h = 0; h < a[s]; ++h) {
		var k = a[h], p = Kn[k];
		if (p) 
			c[k] = p;
		else {
			d = j;
			f[o]("ctz", k)
		}
	}
	if (d) 
		b && b(c);
	else 
		Cg("dispTzOffset", f, i, e);
	return c
}
function Mn(a){
	for (var b = {}, c = 0; c < a[s]; ++c) {
		var d = a[c];
		b[d] = Kn[d]
	}
	return b
}
function _setTzTransitions(a){
	a = a[Ob]("{");
	for (var b = a[0], c = [], d = 1; d < a[s]; d++) 
		c[o](ka(a[d], 36));
	if (c[s] % 2 == 1) 
		Kn[b] = new Jn(b, c)
};
function Nn(){V[E](this);this.vi=j;this.fa={};this.JD={}}
Q(Nn,V);
qe(Nn);
Nn[v].O=function(a,b){a=this.fa[a];return ne(a)?a:b};
Nn[v].getBool=function(a,b){a=this.fa[a];return ne(a)?On(a):b};
function il(a,b,c){return a[Eb](b,c)}
function Pn(a,b,c){a=a.fa[b];return ne(a)?la(a):c}
function Qn(a,b,c){return Pn(a,b,c)}
Nn[v].set = function(a, b){
	var c = this.fa[a] != b;
	if (c) {
		this.fa[a] = b;
		if (this.vi) 
			this.JD[a] = 0
	}
	return c
};
Wa(Nn[v],function(a){for(var b in this.fa)a(b,this.fa[b])});
function Rn(a){U[E](this,"upue");this.J_=a}Q(Rn,U);
function Sn(a,b,c){a.fa[b]===undefined&&a.set(b,c)}
function On(a){return Fg==a}
function Tn(a){
	var b = ["hl", Un];
	if (a.vi) 
		for (c in a.JD) {
			d = a.fa[c];
			b[o]("eup", c + de + d)
		}
	else {
		for (var c in a.fa) {
			var d = a.fa[c];
			b[o]("eup", c + de + d)
		}
		b[s] && b[o]("lstor", Fg)
	}
	return b
}
Nn[v].Kb = function(a){
	if (this.vi) {
		var b = Tn(this);
		if (b[s] > 2) {
			zg.A().Rb("user_prefs.ashx", b, a, "\u65e0\u6cd5\u4fdd\u5b58\u9996\u504f\u597d\u9009\u9879", 13);
			this[A](new Rn(g))
		}
	}
};
function jl(){return Nn.A()}
function Vn(a){
	var b = Nn.A();
	b.vi = g;
	for (var c = 0; c < a[s]; c++) {
		var d = a[c], e = d[0];
		b.fa[e] = d[1];
		delete b.JD[e]
	}
	b[A](new Rn(j))
}
function Wn(){return jl().O("dtFldOrdr","MDY")}
var Xn=Cf(["AE","BD","BH","DJ","DZ","EG","IL","IQ","IR","JO","KW","LB","LY","MA","MR","OM","PK","PS","QA","SA","SD","SO","SY","YE"]);function Yn(){var a=jl().O("country","US");return!Xn[a]}
var Zn="false";
function $n(){return Yn()?jl()[Eb]("weekView5",On(Zn)):j}
function ao(){return Qn(jl(),"firstDay",la(ce))}
function bo(){return jl().O("customCalMode","custom,4")};
var co=["\u5468\u65e5","\u5468\u4e00","\u5468\u4e8c","\u5468\u4e09","\u5468\u56db","\u5468\u4e94","\u5468\u516d"],eo=["\u65e5","\u4e00","\u4e8c","\u4e09","\u56db","\u4e94","\u516d"],fo=["\u661f\u671f\u65e5","\u661f\u671f\u4e00","\u661f\u671f\u4e8c","\u661f\u671f\u4e09","\u661f\u671f\u56db","\u661f\u671f\u4e94","\u661f\u671f\u516d"];
function go(a){this.Sl=a||new ho}
Q(go,yk);
ta(go[v],Gd(19));
go[v].lq=function(a){return eo[a]};
function io(a,b){return b.K==a.Sl.ou().K&&l.abs(b.J-a.Sl.ou().J)<4}
N=go[v];N.Xa=function(a,b,c){b=this.Sl.wH()||pa(a.S)?ee:b&&0==a.T?c?ie:ge:c?he:fe;return b(a.S,a.T)};
N.Pf=function(a){return jo(a,this.Sl.En())};
N.oc=function(a){return ko(a,this.Sl.En())};
N.ih=function(a,b){return be((b?co:fo)[a.Ka()],this.Pf(a))};
N.Of=function(a,b){var c;c=ma(a.J);c=io(this,a)?Yd(c,a.F):Zd(c,a.F,a.K);return be((b?co:fo)[a.Ka()],c)};
N.Cn=function(a){return a.F==1?Yd(ma(a.J),a.F):ma(a.F)};
N.Kd=function(a,b){var c=ma(a.J);return b?Yd(c,a.F):Zd(c,a.F,a.K)};
N.Bn=function(a,b,c,d){d=d||this.Sl.ou();return this.Kd(a,d.K==b.K&&d.K==c.K)};
N.yj = function(a, b){
	var c = a.K, d = a.J, e = a.F, f = b.K, h = b.J;
	b = b.F;
	var k = ma(d), p = ma(h);
	if (c == f) 
		if (d == h) 
			if (e == b) {
				c = Zd(k, e, c);
				return be(fo[a.Ka()], c)
			}
			else 
				return c + "\u5e74" + k + "\u6708" + e + "\u65e5 \u2013 " + b + "\u65e5";
		else 
			return c + "\u5e74" + k + "\u6708" + e + "\u65e5 \u2013 " + p + "\u6708" + b + "\u65e5";
	return Xd(Zd(k, e, c), Zd(p, b, f))
};
N.Dn=Gd(32);
N.Aj=function(a){return $d(ma(a.J),a.K)};N.bu=Gd(11);
N.zj=function(a){return a};
N.iq=function(a){return be(this.zj(co[a.Ka()]),this.Pf(a))};
N.cu=function(a){return this.zj(co[a])};
function lo(a, b){
	if (pa(b)) 
		return "?";
	return b[q]()
}
var mo={bE:Wd(0),dE:"1 \u5206\u949f",eE:Wd,aE:"1 \u5c0f\u65f6",gx:Vd,ZD:"1 \u5929",$D:Ud},no=", ";
function kk(a, b, c, d){
	var e = b.F, f = b.S;
	b = b.T;
	d = d || mo;
	if (c) {
		if (f && b && !(b % 15)) {
			f += b / 60;
			b = 0
		}
		if (e && f && !b && !(f % 6)) {
			e += f / 24;
			f = 0
		}
	}
	c = [];
	if (0 !== e) 
		c[o](1 !== e ? d.$D(lo(a, e)) : d.ZD);
	if (0 !== f) 
		c[o](1 !== f ? d.gx(lo(a, f)) : d.aE);
	else 
		e && b && c[o](d.gx(lo(a, f)));
	if (0 !== b) 
		c[o](1 !== b ? d.eE(lo(a, b)) : d.dE);
	return c[s] ? c[M](no) : d.bE
}
var oo = {
	bE: "\u4e0d\u5230\u4e00\u5206\u949f\u4e4b\u524d",
	dE: "1 \u5206\u949f\u524d",
	eE: Ld,
	aE: "1 \u5c0f\u65f6\u524d",
	gx: Kd,
	ZD: "1 \u5929\u524d",
	$D: Jd
};
go[v].En=function(){return this.Sl.En()};
function ho(a,b,c){this.HY=a||j;this.kP=b||0;this.zW=c||Ji(new Date)}
ho[v].wH=function(){return this.HY};
ho[v].En=function(){return this.kP};
ho[v].ou=function(){return this.zW};
var po="-";
function ko(a, b){
	var c = a.F ? a.F < 10 && b == 2 && 1 ? ce + a.F : ma(a.F) : "??", d = a.J ? a.J < 10 && b == 2 && 1 ? ce + a.J : ma(a.J) : "??";
	a = a.K || "????";
	switch (b) {
		case 1:
			return c + "/" + d + "/" + a;
		case 2:
			return a + po + d + po + c;
		default:
			return d + "/" + c + "/" + a
	}
}
function jo(a, b){
	switch (b) {
		case 1:
			return a.F + "/" + a.J;
		case 0:
			return a.J + "/" + a.F;
		case 2:
			return a.J + "/" + a.F;
		default:
			return a.J + "/" + a.F
	}
};
function qo(a, b, c, d, e, f, h, k){
	Df[E](this);
	this.D = d;
	this.la = a;
	this.id = e || this.la.id + pl;
	xa(this, f || "dp-");
	this.oo = c;
	this.iz = b;
	this.By = {};
	a = ne(h) ? h : 1;
	k = (1 << a + 7) - (1 << a + (k || 5));
	this.RY = k = k + (k >> 7);
	ro[this.id] = this
}
Q(qo,Df);
var ro={};qo[v].jd=j;qo[v].PC=i;qo[v].qL=i;qo[v].WI=0;
function so(a){
	for (var b = [], c = 48; c--;) {
		var d = ["cell"];
		if (c & 2) {
			d[o](c & 1 ? "weekend-selected" : "weekday-selected");
			c & 8 && d[o]("today-selected")
		}
		else {
			d[o](c & 1 ? "weekend" : "weekday");
			c & 8 && d[o]("today")
		}
		d[o](c & 4 ? "onmonth" : "offmonth");
		c & 16 && d[o]("day-left");
		c & 32 && d[o]("day-right");
		b[c] = a + d[M](X + a) + X
	}
	return b
}
function to(a){
	a.dG = [];
	for (var b = 7; b--;) 
		a.dG[b] = a.iz.zj(a.iz.lq(b));
	a.zF = so(a[yb]);
	a.by = [];
	a.Np = a.id + "day_";
	a.dJ = a.id + "cur";
}
var uo="pointer",vo="default";
qo[v].oa = function(){
	if (this.jd) {
		var a = [], b = this.id, c = this[yb] + "cell " + this[yb], d = this.ld;
		this.Np || to(this);
		a[o]('<table cellspacing=0 cellpadding=0 id="', b, 'tbl" class="', this[yb], 'monthtable" style="-moz-user-select:none;-webkit-user-select:none;">');
		a[o]('<tr style="cursor:pointer" class="', c, 'heading"  id="', b, 'header"><td id="', b, 'prev" class="', c, 'prev">&laquo;</td><td colspan=', d.kc - 2, ' id="', this.dJ, '" class="', c, 'cur">', this.iz.Aj(this.ld.Fi), '</td><td id="', b, 'next" class="', c, 'next">&raquo;</td></tr>');
		a[o]('<tr class="', this[yb], 'days">');
		b = this.ld.NM;
		for (var e = 0; e < d.kc; e++) 
			a[o]('<td class="', c, 'dayh">', this.dG[(b + e) % 7], aj);
		a[o]("</tr>");
		c = this.ld;
		d = c.kc;
		b = this.id;
		e = this.RY;
		var f = this.zF, h = Wi(c), k = this.PC, p = k ? this.PC.Sa() : 1, r = k ? this.qL.Sa() : 0;
		k = k ? uo : vo;
		var t = this.vm.Sa(), u = this.ld.Fi.J, x = 0;
		if (this.fG) 
			this.By = this.fG(c);
		for (var y = 0; y < this.ld.Ge; y++) {
			a[o]('<tr style="cursor:', k, '" id="', b, "row_", y, Th);
			for (var D = c.NM, H = d; H--; x++) {
				var J = h[x], ga = (J == t && 8) | ((J >> 5 & 15) == u && 4) | (J >= p && J <= r && 2) |
				(H == d - 1 &&
				16) |
				(H == 0 && 32) |
				e >> D & 1;
				D = (D + 1) % 7;
				this.by[x] = ga;
				a[o]('<td id="', this.Np, J, '" class="', f[ga], this.By[J], Th, J & 31, aj)
			}
			a[o]("</tr>")
		}
		a[o]("</table>");
		m(this.la, a[M](O));
		this.HX = j;
		wo(this.id, this.D)
	}
};
function wo(a, b){
	fb(b.ja(a + "prev"), function(){
		ro[a].Xj(-1)
	});
	fb(b.ja(a + "next"), function(){
		ro[a].Xj(1)
	})
}
qo[v].o=function(){return this.la};
qo[v].Xj=function(a){xo(this,xi(this.ld.Fi.K,this.ld.Fi.J+a,1).V())};
function xo(a,b){var c=a.ld.Fi;if(b.K!=c.K||b.J!=c.J){a.ld=a.oo.rt(b);a.Ga()}}
N=qo[v];
N.Ga=function(){if(this.WI)this.HX=g;else this.jd&&this.oa()};
N.I=function(){return this.id};
N.fb=function(){this.jd=g;this.oa()};
N.qa=function(){m(this.la,O);this.jd=j};
N.ta=Gd(65);
N.rq=Gd(28);
N.em=function(a){this.vm=a;if(this.ld)this.Ga();else this.ld=this.oo.rt(a)};
N.C=function(){delete this.la;delete ro[this.id];qo.l.C[E](this)};
function yo(){V[E](this)}
Q(yo,V);
N=yo[v];
N.In=function(){return this.Ua};
N.wq=function(){return this.bc};
N.IB=i;
N.zJ=i;
N.yJ=i;
N.Kw=function(a,b,c){this.uf(c)};
N.uf=function(a){this.Kw(a,a,a)};
N.Xj=function(a){this.uf(wi(a>0?this.bc:this.Ua,a))};
cb(N,function(a){return a.L()>=this.Ua.L()&&a.L()<=this.bc.L()});
function tl(a){return ri(a.bc,a.Ua)+1}
yo[v].xj = function(){
	if (!this.IB || !this[Oc].ba(this.yJ) || !this.Ua.ba(this.IB) || !this.bc.ba(this.zJ)) {
		this.yJ = this[Oc];
		this.IB = this.Ua;
		this.zJ = this.bc;
		this[A]("change")
	}
};
yo[v].set=function(a,b,c){this.Ua=a;this.bc=b;Ta(this,c);this.xj()};
function zo(a, b, c, d, e){
	yo[E](this);
	this.Ui = b;
	this.So = c;
	this.Wt = ne(d) ? d : 1;
	this.TD = e || 5;
	this.Hc = a;
	this.nb = 1
}
Q(zo,yo);
zo[v].KB=i;
function Ao(a, b){
	if (a[Oc]) {
		if (!a[ed](a[Oc])) {
			var c = a.Hc.Pa;
			Ta(a, a[ed](c) ? c : b.L() < a.Ua.L() ? a.Ua : b.L() > a.bc.L() ? a.bc : b)
		}
	}
	else 
		Ta(a, b)
}
function Bo(a,b,c){var d=b;if(c>7&&c%7==0)b=yi(b,a.Ui);a.Ua=b;a.bc=wi(b,c-1);Ao(a,d);a.nb=1;a.xj()}
zo[v].xj=function(){zo.l.xj[E](this);if(!this.KB||this.nb!=this.KB){this.KB=this.nb;this[A]("gcal-ds-mc")}};
function Co(a, b, c, d, e){
	var f = b.K, h = b.J;
	b = ui(f, h, 1);
	f = ui(f, h, ci(f, h));
	if (!c) {
		f = yi(f, a.Wt);
		b = zi(b, a.Wt + a.TD - 1)
	}
	if (d) {
		b = yi(b, a.Ui);
		f = zi(f, a.Ui + 6)
	}
	e.Ua = b;
	e.bc = f
}
function Do(a, b){
	Co(a, b, a.So, j, a);
	Ao(a, b);
	Co(a, b, a.So, g, a);
	a.nb = 3;
	a.xj()
}
function Eo(a, b, c){
	var d = yi(b, a.Ui);
	if (!ne(c)) 
		c = a.So;
	c || (d = zi(d, a.Wt));
	a.Ua = d;
	a.bc = wi(d, c ? 6 : a.TD - 1);
	Ao(a, b);
	a.nb = 2;
	a.xj()
}
zo[v].uf = function(a){
	Ta(this, a);
	if (this[ed](a)) 
		this.nb == 3 || this.Ua.ba(this.bc) ? Eo(this, a) : Bo(this, a, 1);
	else 
		Fo(this)
};
function Fo(a, b){
	var c = a[Oc];
	if (a.nb == 3) 
		Do(a, c);
	else 
		if (a.nb == 2) {
			b = b ? a.So : tl(a) == 7;
			Eo(a, c, b)
		}
		else {
			if (tl(a) > 7) 
				c = yi(c, a.Ui);
			Bo(a, c, tl(a))
		}
}
zo[v].Kw = function(a, b, c){
	this.Ua = a;
	this.bc = b;
	Ta(this, c);
	if (tl(this) > 7) {
		this.Ua = yi(this.Ua, this.Ui);
		this.bc = zi(this.bc, this.Ui + 6)
	}
	a = this.Ua;
	b = this.bc;
	c = tl(this);
	this.nb = 1;
	if (c == 7 && a.Ka() == this.Ui || c == this.TD && a.Ka() == this.Wt) 
		this.nb = 2;
	else {
		c = wi(a, 10);
		var d = {};
		Co(this, c, this.So, g, d);
		if (a.ba(d.Ua) && b.ba(d.bc)) {
			b = c.J;
			this.nb = 3;
			if (this[Oc].J != b) {
				c = c.K;
				d = ui(c, b, 1);
				Ta(this, this[Oc].L() < a.L() ? d : ui(c, b, ci(c, b)))
			}
		}
	}
	this.xj()
};
zo[v].Xj = function(a){
	if (this.nb == 3) 
		Do(this, xi(this[Oc].K, this[Oc].J + a, 1).V());
	else {
		var b = this.nb == 2 ? 7 : tl(this);
		this.Ua = wi(this.Ua, a * b);
		this.bc = wi(this.bc, a * b);
		Ao(this, wi(this[Oc], a * b));
		this.xj()
	}
};
function Go(a){Ta(a,a.Hc.Pa);Fo(a)}
function Ho(a,b,c){if(b==1){if(a.nb==1)Ta(a,a.Ua);if(c){Bo(a,a[Oc],c);return}}a.nb=b;Fo(a,g)};
var Io;
function Jo(a,b,c,d,e){this.Ns=a;this.Xi=b;this.Dm=c;this.vk=d;this.Yi=e}
var Ko=[6,1,12,9,14,4,21,8,19,7,2,11,10,3,20,13,5,15,16,17,18],Sg=function(){
	for (var a = [], b = "666666888888aaaaaabbbbbbdddddda32929cc3333d96666e69999f0c2c2b1365fdd4477e67399eea2bbf5c7d67a367a994499b373b3cca2cce1c7e15229a36633cc8c66d9b399e6d1c2f029527a336699668cb399b3ccc2d1e12952a33366cc668cd999b3e6c2d1f01b887a22aa9959bfb391d5ccbde6e128754e32926265ad8999c9b1c2dfd00d78131096184cb05288cb8cb8e0ba52880066aa008cbf40b3d580d1e6b388880eaaaa11bfbf4dd5d588e6e6b8ab8b00d6ae00e0c240ebd780f3e7b3be6d00ee8800f2a640f7c480fadcb3b1440edd5511e6804deeaa88f5ccb8865a5aa87070be9494d4b8b8e5d4d47057708c6d8ca992a9c6b6c6ddd3dd4e5d6c6274878997a5b1bac3d0d6db5a69867083a894a2beb8c1d4d4dae54a716c5c8d8785aaa5aec6c3cedddb6e6e41898951a7a77dc4c4a8dcdccb8d6f47b08b59c4a883d8c5ace7dcce"[pd](), c = 0; c < 22; c++) {
		function d(e){
			return "#" + b[Cd](c * 30 + e * 6, 6)
		}
		a[c] = new Jo(d(0), d(1), d(2), d(3), d(4))
	}
	return a;
}();
function Lo(a){
	for (var b = 0; b < Ko[s]; ++b) {
		var c = Ko[b];
		if (!(c in a)) 
			return c
	}
	a = l[Nc]() * Ko[s] | 0;
	return Ko[a]
};
function Mo(){this.Vj={}}
qe(Mo);
Mo[v].reset=function(){this.Vj={}};
var No=/\W/g;
Mo[v].log = function(a, b){
	if (!(b < 0 || b > 600000)) {
		a = a[w](No, pl);
		a in this.Vj || (this.Vj[a] = []);
		this.Vj[a][o](b)
	}
};
function Oo(a, b, c){
	var d = [];
	c = c || O;
	b = b || O;
	for (var e in a.Vj) {
		d[o](b + e + c);
		d[o](a.Vj[e][M]("#"))
	}
	return d[M](de)
}
Mo[v].getData=function(){return this.Vj};
function Po(a){this.kK=a;Qo(this)}
Po[v].Nc=function(a){a=a||this.kd;var b=Ge();this.kK.log(a,b-this.bH);this.VA=b};
function sl(a,b){b=b||a.kd;var c=Ge();a.kK.log(b,c-a.VA);a.VA=c}
function Qo(a,b){a.bH=b||Ge();a.VA=a.bH}
function Ro(a,b){Mo.A().log(a,b)}
function So(a){Mo.A().log(a,0)}
function ql(){var a;a=Mo.A();return a=new Po(a)}
function To(){Mo.A().reset()}
me("gcal.perf.getLogString",function(){return Oo(Mo.A())},undefined);
me("gcal.perf.reset",To,undefined);
function Uo(a, b){
	var c = [][Wb](b);
	c[Xc](function(r, t){
		return r - t
	});
	var d = c[s], e = (d + 1) / 2 - 1;
	l[Pb](e);
	l[Mb](e);
	e = (c[l[Pb](e)] + c[l[Mb](e)]) / 2;
	for (var f = 0, h = 0; h < d; ++h) 
		f += c[h];
	h = f / d;
	for (var k = 0, p = 0; p < d; ++p) 
		k += l.pow(c[p] - h, 2);
	k = k / d;
	p = l.sqrt(k);
	gb(this, a);
	Aa(this, b);
	this.sorted = c;
	this.sz = d;
	this.median = l[Mb](e);
	this.sum = f;
	this.avg = l[Mb](h);
	this.vari = l[Mb](k);
	this.stddev = l[Mb](p)
}
function Vo(){
	var a;
	a = Mo.A()[cc]();
	var b = xf(a);
	b[Xc]();
	for (var c = [], d = 0; d < b[s]; ++d) {
		var e = b[d];
		c[o](new Uo(e, a[e]))
	}
	return a = c
}
me("gcal.perf.getSampleData",Vo,undefined);
var Xg=/([\u200e\u200f]*)<\/?\w[^>]*>\1/g;
function Wo(a, b, c){
	V[E](this);
	this.dP = a;
	this.vY = b || Infinity;
	this.QU = c;
	this.GX = Xo(this, Ge() + 0);
	this.OD();
	this.Vv()
}
Q(Wo,V);
Wo[v].OD=function(){this.vm=new Date(Yo(this))};
function Xo(a, b){
	var c = a.dP;
	if (c === undefined) 
		c = (new Date(b)).getTimezoneOffset() * -60000;//将当地时间转换成其它时区
	else 
		if (b >= a.vY) 
			c = a.QU;
	return c
}
function Yo(a){var b=Ge()+0;return Xo(a,b)+b}
Wo[v].Vv = function(){
	var a = this.vm, b = new Date(Yo(this)), c = 1800000 - b[rd]() % 1800000;
	window[Jb](Wo[v].Vv.Ex(this), c);
	if (a[Rb]() !== b[Rb]()) {
		this.OD();
		this[A]("newday")
	}
};
Wo[v].OD=function(){this.vm=new Date(Yo(this));this.Pa=Ji(this.vm)};
function wl(a){
	return Ei(new Date(Yo(a)))
};
function Zo(a){this.Y=a}Q(Zo,Df);
var $o=new Ef(0,100);
Zo[v].B = function(a, b, c, d, e){
	if (ve(b)) 
		for (var f = 0; f < b[s]; f++) 
			this.B(a, b[f], c, d, e);
	else {
		a = pg(a, b, c || this, d || j, e || this.Y || this);
		ap(this, a)
	}
	return this
};
function bp(a, b, c, d, e, f){
	if (ve(c)) 
		for (var h = 0; h < c[s]; h++) 
			bp(a, b, c[h], d, e, f);
	else {
		b = rg(b, c, d || a, e || j, f || a.Y || a);
		ap(a, b)
	}
	return a
}
function ap(a, b){
	if (a.Ca) 
		a.Ca[b] = g;
	else 
		if (a.Jc) {
			a.Ca = $o.oe();
			a.Ca[a.Jc] = g;
			a.Jc = i;
			a.Ca[b] = g
		}
		else 
			a.Jc = b
}
Zo[v].jb=Gd(43);
Zo[v].Dc = function(){
	if (this.Ca) {
		for (var a in this.Ca) {
			ug(a);
			delete this.Ca[a]
		}
		$o.pf(this.Ca);
		this.Ca = i
	}
	else 
		this.Jc && ug(this.Jc)
};
Zo[v].C=function(){Zo.l.C[E](this);this.Dc()};
$a(Zo[v],function(){aa(Error("EventHandler.handleEvent not implemented"))});
function cp(a){V[E](this);this.H=a;this.ev=pg(this.H,Sf?"DOMMouseScroll":"mousewheel",this)}
Q(cp,V);$a(cp[v],function(a){
	var b = 0;
	a = a.Ra;
	var c = "vertical";
	if (a[K] == "mousewheel") {
		b = -a.wheelDelta / 40;
		if (Tf) {
			$f("530.4") || (b /= 3);
			if (a.wheelDeltaX) 
				c = "horizontal"
		}
	}
	else 
		b = a.detail;
	if (typeof a.axis != "undefined" && typeof a.HORIZONTAL_AXIS != "undefined" && a.axis == a.HORIZONTAL_AXIS) 
		c = "horizontal";
	if (b > 100) 
		b = 3;
	else 
		if (b < -100) 
			b = -3;
	b = new dp(b, a, c);
	try {
		this[A](b)
	}
	finally {
		b.G()
	}
});
cp[v].C=function(){cp.l.C[E](this);ug(this.ev);delete this.ev};
function dp(a, b, c){
	ag[E](this, b);
	bb(this, "mousewheel");
	this.axis = c || "vertical";
	this.detail = a
}
Q(dp,ag);
function ep(a, b){
	V[E](this);
	this.ri = a || 1;
	this.ts = b || fp;
	this.Gx = P(this.om, this);
	this.mo = Ge()
}
Q(ep,V);
Xa(ep[v],j);
var fp=ke.window;
N=ep[v];
N.ua=i;
N.setInterval = function(a){
	this.ri = a;
	if (this.ua && this[Tc]) {
		this[qb]();
		this[F]()
	}
	else 
		this.ua && this[qb]()
};
N.om = function(){
	if (this[Tc]) {
		var a = Ge() - this.mo;
		if (a > 0 && a < this.ri * 0.8) 
			this.ua = this.ts[Jb](this.Gx, this.ri - a);
		else {
			this[A]("tick");
			if (this[Tc]) {
				this.ua = this.ts[Jb](this.Gx, this.ri);
				this.mo = Ge()
			}
		}
	}
};
Sa(N,function(){Xa(this,g);if(!this.ua){this.ua=this.ts[Jb](this.Gx,this.ri);this.mo=Ge()}});
ra(N,function(){Xa(this,j);if(this.ua){this.ts[zb](this.ua);this.ua=i}});
N.C=function(){ep.l.C[E](this);this[qb]();delete this.ts};
function gp(a, b, c){
	V[E](this);
	this.rj = pj(a);
	this.KG = b ? pj(b) : i;
	this.xg = c == g;
	db(this.rj, 0);
	pg(this.rj, "click", this.nV, j, this);
	pg(this.rj, "keydown", this.oV, j, this);
	this.Ki(this.xg)
}
Q(gp,V);
N=gp[v];
N.C=function(){wg(this.rj);gp.l.C[E](this)};
N.expand=function(){this.Ki(g)};za(N,Gd(58));
var hp="none";
N.Ki = function(a){
	if (this.KG) 
		ib(this.KG[B], a ? O : hp);
	if (a) {
		kj(this.rj, "goog-zippy-collapsed");
		jj(this.rj, "goog-zippy-expanded")
	}
	else {
		kj(this.rj, "goog-zippy-expanded");
		jj(this.rj, "goog-zippy-collapsed")
	}
	this.xg = a;
	this[A](new ip("toggle", this, this.xg))
};
N.oV = function(a){
	if (a[Qc] == 13 || a[Qc] == 32) {
		this.Ki(!this.xg);
		a[ec]();
		a[bc]()
	}
};
N.nV=function(){this.Ki(!this.xg)};
function ip(a,b,c){U[E](this,a,b);this.r_=c}
Q(ip,U);
//显示类型 按天/周/月/列表等显示
var jp=["day","week","month","list","compact","custom","search"],kp={};
kp[0]=g;
kp[1]=g;
kp[2]=g;
kp[3]=g;
kp[6]=g;
(function(){
	tn.extras = ["delayedcore"];
	tn.detailssettings = ["delayedcore", "extras", "eventform"];
	tn.eventform = ["delayedcore", "extras"];
	tn.offline = ["delayedcore", "extras"];
	tn.search = ["delayedcore", "extras", "eventform"];
	tn.focuswidget = ["delayedcore", "extras"];
	tn.dasher = ["delayedcore", "extras", "eventform"];
	tn.tdl = ["delayedcore", "extras"]
})();
var gn;function lp(a){
	fn(gn, "delayedcore", a)
}
/** 加载extras文件.js */
function mp(a){fn(gn,"extras",a)}
/** 加载detailssettings文件.js */
function np(a){fn(gn,"detailssettings",a)}
/** 加载eventform文件.js */
function op(a){fn(gn,"eventform",a)}
/** 加载search文件.js */
function pp(a){fn(gn,"search",a)};
/** 用户行事历单元的x,y坐标fp,ol宽高py */
function qp(a, b, c, d, e){
	this.x = a;
	this.y = b;
	this.fp = c;
	this.ol = d;
	this.py = e
}
cb(qp[v],function(a){return this.x<=a.x&&a.x<this.x+this.fp&&this.y<=a.y&&a.y<this.y+this.ol});
sa(qp[v],function(){return"[R "+this.fp+"x"+this.ol+"+"+this.x+"+"+this.y+"]"});
qp[v].bb=function(){return new qp(this.x,this.y,this.fp,this.ol,this.py)};
qp[v].ba=function(a){return a.fp===this.fp&&a.ol===this.ol&&a.x===this.x&&a.y===this.y&&a.py==this.py};
var rp=i;
function sp(a){rp=a}
function tp(){return rp!==i}
function _ASP_getChangePasswordUrl(){return"https://www.google.com/a/"+rp+"/ChangePassword?service=cl&hl=zh-CN"};
function up(a,b){for(var c={},d=0;d<b[s];++d)c[b[d]]=1;b=[];for(d=0;d<a[s];++d)c[a[d]]||b[o](a[d]);return b};
/**
 * 读取cookie 参数a为变量名称 返回变量的值 若无则返回null
 * @param {Object} a
 */
function vp(a){
	if (a == "secid") {
		return "XzB6zTFMc6XNcnCn-AlrnWsP3Z4";
	}
	for (var b = document.cookie[Ob](/\s*;\s*/), c = a[s], d = 0, e = b[s]; d < e; ++d) {
		var f = b[d];
		if (!(f[s] <= c || f[Zb](c) != "=")) 
			if (f[I](0, c) === a) 
				return unescape(f[I](c + 1))
	}
	return i
};
function wp(a){
	var b = a[vc];
	if (b && b[Fc]) {
		a = b[Fc](a);
		return new qp(a.x, a.y, a[Cb], a[od], window)
	}
	for (var c = b = 0, d = a; d[Vb]; d = d[Vb]) {
		b += d[kc];
		c += d[nd]
	}
	return new qp(b, c, a[Ub], a[sd], window)
} 
function xp(a){
	var b = a[vc];
	return b && b[Fc] ? b[Fc](a)[od] : a[sd]
}
function yp(a){
	var b = a[vc];
	return b && b[Fc] ? b[Fc](a)[Cb] : a[Ub]
};
/** 创建XMLHttpRequest对象 */
var zp=["MSXML2.XMLHTTP.5.0","MSXML2.XMLHTTP.4.0","MSXML2.XMLHTTP.3.0","MSXML2.XMLHTTP","MICROSOFT.XMLHTTP.1.0","MICROSOFT.XMLHTTP.1","MICROSOFT.XMLHTTP"],Ap=undefined;
(function(){
	if (typeof XMLHttpRequest == "undefined" && typeof ActiveXObject != "undefined") {
		for (var a = 0; a < zp[s]; a++) {
			var b = zp[a];
			try {
				new ActiveXObject(b);
				Ap = b;
				break
			} 
			catch (c) {
			}
		}
		if (!Ap) 
			aa("Could not create ActiveXObject")
	}
})();
/** 创建XMLHttpRequest对象 */
function Bp(){
	return Ap ? new ActiveXObject(Ap) : new XMLHttpRequest
}
var Cp=j;
/**
 * xmlhttprequest-GET-方式请求数据 
 * @param {Object} a xmlhttprequest对象
 * @param {Object} b url
 * @param {Object} c function
 */
function Dp(a, b, c){
	ua(a, Ep(b, a, c, "GET"));//XMLHttpRequest.onreadystatechange
	a[ub]("GET", b, g);//XMLHttpRequest.open() 参数(bstrMethod,bstrUrl,varAsync,bstrUser,bstrPassword)
	try {
		a[Gc](i)//XMLHttpRequest.send()
	} 
	catch (d) {
	}
}
/** xmlhttprequest-POST-方式请求数据 */
function Fp(a, b, c, d, e, f, h){
	ua(a, Ep(b, a, e, "POST"));
	a[ub]("POST", b, !f);
	a[xc]("Content-Type", d);
	Cp || a[xc]("Content-Length", c[s]);
	if (h) 
		for (b = 0; b < h[s]; ++b) {
			d = h[b];
			a[xc](d[0], d[1])
		}
	try {
		a[Gc](c)
	} 
	catch (k) {
	}
}
/** return xmlhttprequest.status 若是正常响应并且Content-Type不为空则返回200 其他返回-43 */
function Gp(a){
	var b = -1;
	try {
		b = a[Ec];
		if ((b == 200 || b <= 0) && !a[uc]("Content-Type")) 
			b = -43
	} 
	catch (c) {
	}
	return b
}
/** XMLHttpRequest.readystate=4读取服务器响应结束后运行c函数 */
function Ep(a, b, c){
	//XMLHttpRequest readyState
	//0:open() has not been called yet.
	//1:open() has been called, but send() has not been called.
	//2:send() has been called, but the server has not responded yet.
	//3:Data is being received from the server.
	//4:The server's response is complete.
	return function(){
		if (b[Ic] == 4) {
			ua(b, Hp);//b.onreadystatechange={} 清空函数
			c()
		}
	}
}
function Hp(){};
function Bg(a, b, c){
	return function(d){
		var e = Gp(d);
		if (e == 200 || e == 204) {
			e = g;
			if (a) 
				if (typeof a == xe) {
					Ip(a);
				}
				else {
					e = a(d);
				}
			return e;
		}
		else {
			a: {
				if (Jp(d)) {
					e = j;
					e = tp() ? vp("CALH") || vp("CALHS") || vp("CALHP") : vp("CAL") || vp("CALS");
					e = !!e;
					if (!e) {
						if (Yl(window[dc]) == "render") {
							Kh("\u5f88\u62b1\u6b49\uff0c\u60a8\u5df2\u9000\u51fa [\u53ef\u80fd\u5728\u53e6\u4e00\u7a97\u53e3]\u3002\u8bf7\u518d\u6b21\u767b\u5f55\u3002");
							jn(1);
							e = g;
							break a;
						}
					}
				}
				e = j;
			}
			if (!e && b) {
				c && Kp(c);
				typeof b == xe ? Ip(b) : b(d)
			}
			return undefined;
		}
	}
}
function Kp(a){
	Lp(a, "ERR");
	Lp(a, "ERR2");
}
function Lp(a, b){
	var c = vp(b);
	if (c) {
		c = c[Ob](Ne);
		for (var d = j, e = 0; e < c[s]; ++e) {
			var f = c[e], h = f[ic]("=");
			if (h >= 0 && f[I](0, h) == a) {
				d = g;
				c[e] = a + "=" + (1 + ka(f[I](h + 1), 10) || 1);
				break
			}
		}
		d || c[o](a + "=1");
		c = c[M](Ne);
		a = new Date(Ge() + 31622400000);
		d = window[dc].pathname || O;
		/calendar$/[vb](d) || (d = d[I](0, d[Mc]("/") + 1));
		d = d;
		d = [d];
		if (/\/$/[vb](d[0]) && a instanceof Date && a[Rc]() < 2000) 
			for (e = d[0]; O !== (e = e[w](/([^\/]+|\/)$/, O));) 
				d[o](e);
		a: switch (b) {
			case "CAL":
			case "CALH":
				f = "." + window[dc].host;
				break a;
			default:
				f = i;
				break a
		}
		for (h = 0; h < d[s]; ++h) {
			e = d[h];
			var k = [];
			k[o](b + "=" + c);
			k[o]("path=" + e);
			f && k[o]("domain=" + f);
			a instanceof Date && k[o]("expires=" + a.toUTCString());
			document.cookie = k[M]("; ")
		}
	}
}
function Jp(a){
	var b = Gp(a);
	if (b == -43) {
		return g;
	}
	if (b != 301 && b != 302) {
		return j;
	}
	a = a[uc]("Location");
	if (!Wl(a)) {
		return j;
	}
	a = Yl(a);
	return a == "Login" || a == "ServiceLogin" || a == "logout" || a == "Logout"
};
var Mp=i,Np=i;
function Op(a){
	if (a) {
		if (xe == typeof a[0]) 
			a = [a];
		for (var b = 0; b < a[s]; ++b) {
			var c = a[b], d = c[0];
			c = c[Ib](1);
			var e = Mp[d];
			if (!e && se == typeof oe(d)) 
				e = oe(d);
			Np(d, c);
			if (e) 
				try {
					e[fd](i, c)
				} 
				catch (f) {
				}
		}
	}
}
function Pp(){};
var Qp=0;function Rp(){return vp("secid")}
/** xmlResponse返回结果判断js是否请求成功 */
function Sp(a){
	try {
		var b = a[uc]("Content-Type");
		if (b && (b[ic]("text/javascript") == 0 || b[ic]("application/x-javascript") == 0)) 
			return g
	} 
	catch (c) {
	}
	return j
}
/** 
 * 显示用户行事历信息
 * @param {Object} a xmlhttprequest
 * @param {Object} b 
 * @param {Object} c url
 * @param {Object} d
 * @param {Object} e true ? "POST" : "GET"
 * @param {Object} f
 * @param {Object} g
 */
function Tp(a, b, c, d, e, f, h){
	a[Ic] == 4 &&
	na(function(){//readystate为4表示数据接收完毕
		var k = g;
		if (f) 
			k = !(j === f(a));
		if (200 === Gp(a)) //xmlhttprequest返回正常
			try {
				(new Date)[rd]();
				if (k && a[Qb][s] && Sp(a)) {//responsetext不为空
					var p = eval(Up(a[Qb]));//把while(1);替换为""后eval运行
					p instanceof Array && p[s] && Op(p)
				}
			} 
			catch (r) {
				aa(r)
			}
		if (h) 
			h(a, c, e ? "POST" : "GET")
	}, 0)
}
function Vp(a){
	if (!a) 
		return O;
	for (var b = [], c = O, d = 0; d < a[s];) {
		var e = a[d++], f = a[d++];
		b[o](c, ba(e));
		c = Ne;
		ue(f) && b[o]("=", ba(f[q]()))
	}
	return b[M](O)
}
function Wp(a,b){b=Vp(b);var c=a[ic]("?")>=0?Ne:"?";return b?a+c+b:a}
function Dg(a,b,c,d,e){a=Wp(a,b);Xp(a,c,i,d,e)}
function Cg(a, b, c, d, e, f){
	var h = Rp();
	h && b[o]("secid", h);
	b = Vp(b);
	Xp(a, b, i, c, d, e, f)
}
var Yp={};
Yp.caldetails=g;
Yp.event=g;Ba(Yp,g);
/**
 * xmlhttprequest动态获取数据(获取用户行事历信息等)
 * @param {Object} a URL
 * @param {Object} b URL后边的参数字符串
 * @param {Object} c 表单提交的编码类型
 * @param {Object} d 
 * @param {Object} e 
 * @param {Object} f 请求方式 true:post false:get
 */
function Xp(a, b, c, d, e, f, h){
	var k = ++Qp, p = Bp(), r = Ge();//创建xmlhttprequest对象 //返回当前时间(1970.1.1至今的毫秒数)
	c = c || "application/x-www-form-urlencoded";//表单提交的编码类型
	b = b ? b[q]() : O;//url后面的参数字符串
	if (!f && !h && Yp[a] && c == "application/x-www-form-urlencoded" && b[s] < 1680) {//get方式下url长度有限制，这里url参数长度限制在1680下
		a += "?" + b;
		b = O//清空
	}
	var t = b != O;
	d = Fe(Tp, p, k, a, r, t, d, e);//显示用户行事历信息的函数
	t ? Fp(p, a, b, c, d, f, h) : Dp(p, a, d)//Pn:post方式 Mn:get方式
}
/** 替换字符串中while(1);为"" */
function Up(a){return a[w](/^\s*while\s*\(\s*1\s*\)\s*;/,O)};
var _icalfp=tm;
oi[v].toSource=function(){return"_icalfp("+ef(this)+ae};
function Zp(a, b){
	for (var c = 0, d = 0, e = a[s], f = b[s], h = [], k = -Infinity; c < e && d < f;) {
		var p = a[c], r = b[d], t = a[c + 1], u = b[d + 1];
		if (r <= p) {
			k = u;
			d += 2
		}
		else 
			if (k >= u) 
				d += 2;
			else 
				if (k >= t) 
					c += 2;
				else {
					p = k > p ? k : p;
					t = r < t ? r : t;
					p < t && h[o](p, t);
					k = t == r ? u : t
				}
	}
	for (; c < e;) {
		p = a[c++];
		p = p > k ? p : k;
		t = a[c++];
		p < t && h[o](p, t)
	}
	return h
}
function Sm(a, b){
	var c = [];
	$p(a, b, c);
	return c
}
function $p(a, b, c){
	for (var d = 0, e = 0, f = a[s], h = b[s], k = -1; d < f && e < h;) {
		var p = a[d], r = b[e], t = a[d + 1], u = b[e + 1];
		if (p < r) 
			if (t <= r) 
				d += 2;
			else 
				if (u <= t) {
					c[++k] = r;
					c[++k] = u;
					e += 2
				}
				else {
					c[++k] = r;
					c[++k] = t;
					d += 2
				}
		else 
			if (u <= p) 
				e += 2;
			else 
				if (t <= u) {
					c[++k] = p;
					c[++k] = t;
					d += 2
				}
				else {
					c[++k] = p;
					c[++k] = u;
					e += 2
				}
	}
	++k < c[s] && c[qd](k, c[s] - k)
}
function aq(a, b, c){
	var d = a[s] - 1;
	if (d >= 0 && a[d] >= b) 
		a[d] = c;
	else 
		a[o](b, c)
};
var xl;
function bq(){return g}
function cq(){return"MDY"}
function dq(){}
Q(dq,ho);
var eq={};
eq.MDY=0;
eq.YMD=2;
eq.DMY=1;
dq[v].wH=function(){return bq()};
dq[v].En=function(){return eq[cq()]};
dq[v].ou=function(){return xl.Pa};
var hl=new go(new dq);
function yl(){return hl};
var fq,gq;
function hq(a,b,c,d){this.R=a;this.Le=b;this.Jd=c;this.Bj=d}
sa(hq[v],function(){
	var a;
	{
		//检测是否含控制符(ascii码表中前32个字符和第127个字符为控制符)
		//uri编码并且把+替换为%2B
		a = this.R;
		a = /[\x00-\x20\"]/[vb](a) ? Qe + ba(a)[w](iq, "%2B") + Qe : a
	}
	return a + X + mi(this.Le) + "/" + mi(this.Jd) + X + this.Bj
});
function jq(a,b){var c=[];kq(a,b,function(d,e){c[o](!e||d&&d.Bj>=e.Bj?d:e)});return lq(c)}
function mq(a,b){var c=[];kq(a,b,function(d,e){if(e)d&&e&&c[o](e);else c[o](d)});return lq(c)}
function nq(a,b){var c=[];kq(a,b,function(d,e){e||c[o](d)});return lq(c)}
function oq(a){
	var b = [];
	if (a) {
		a = a[Ob](/\n/g);
		for (var c = 0; c < a[s]; ++c) {
			var d = a[c][Dc](/^(\S+) (\d+)\/(\d+) (\d+)$/);
			d && b[o](new hq(pq(d[1]), Ti(d[2]).Sa(), Ti(d[3]).Sa(), ca(d[4])))
		}
		b[Xc](qq)
	}
	return b
}
function $m(a){
	for (var b = [], c = 0; c < a[s]; ++c) {
		var d = a[c];
		b[o]([d.Le, d.Jd])
	}
	a = [];
	b[Xc](rq);
	for (var e = 0; e < b[s];) {
		c = b[e];
		d = c[1];
		for (e = e + 1; e < b[s] && d >= b[e][0];) {
			d = l.max(d, b[e][1]);
			++e
		}
		a[o](c[0], d);
		e = e
	}
	return b = a
}
function Rm(a,b){for(var c=[],d=0;d<a[s];++d){var e=a[d];b(e)&&c[o](e)}return c}
function sq(a,b,c){b=l.max(b,a.Le);c=l.min(c,a.Jd);return new hq(a.R,b,c,a.Bj)}
function qq(a,b){return a.R<b.R?-1:a.R>b.R?1:a.Le-b.Le}
function kq(a, b, c){
	var d = 0, e = 0, f = a[s], h = b[s], k = ki, p = i;
	function r(H, J){
		var ga;
		if (H) {
			ga = b[e];
			if (J === i || J >= ga.Jd) 
				++e
		}
		else {
			ga = a[d];
			if (J === i || J >= ga.Jd) 
				++d
		}
		J = sq(ga, k, J || ga.Jd);
		k = J.Jd;
		p = ga.R;
		H ? c(i, J) : c(J, i)
	}
	for (; d < f && e < h;) {
		var t = a[d], u = b[e];
		if (t.R !== u.R) 
			if (t.R < u.R) {
				if (t.R !== p) 
					k = ki;
				r(0, i)
			}
			else {
				if (u.R !== p) 
					k = ki;
				r(1, i)
			}
		else {
			if (t.R != p) 
				k = ki;
			var x = l.max(k, t.Le), y = l.max(k, u.Le);
			if (x !== y) 
				x < y ? r(0, u.Le) : r(1, t.Le);
			else {
				y = l.min(t.Jd, u.Jd);
				var D = sq(t, x, y);
				x = sq(u, x, y);
				k = y;
				p = t.R;
				c(D, x);
				t.Jd <= y && ++d;
				u.Jd <= y && ++e
			}
		}
	}
	if (d < f) {
		do {
			if (a[d].R !== p) 
				k = ki;
			r(0, i)
		}
		while (d < f)
	}
	else 
		for (; e < h;) {
			if (b[e].R !== p) 
				k = ki;
			r(1, i)
		}
}
function lq(a){
	for (var b = [], c = i, d = 0; d < a[s]; ++d) {
		var e = a[d];
		if (c && c.R === e.R && c.Bj === e.Bj && c.Jd === e.Le) 
			c = b[b[s] - 1] = new hq(c.R, c.Le, e.Jd, c.Bj);
		else {
			b[o](e);
			c = e
		}
	}
	return b
}
function rq(a,b){return a[0]-b[0]||b[1]-a[1]}
function bn(a){
	for (var b = [], c = undefined, d = 0; d < a[s]; ++d) {
		var e = a[d];
		c !== e.R && b[o](e.R);
		c = e.R
	}
	return b
}
var iq=/\+/g;
function pq(a){
	if (!a[s] || a[Zb](0) !== Qe) 
		return a;
	a = a[I](1, a[s] - 1)[w](iq, X);
	return oa(a)
}
function tq(a, b, c){
	var d = [];
	if (b > a) 
		for (var e = 0; e < c[s]; ++e) 
			d[o](new hq(c[e], a, b, 0));
	d[Xc]();
	return a = d
};
function uq(a, b, c){
	this.wU = b || 40;
	this.ZE = c || Infinity;
	this.Ch = a;
	m(this.Ch, '<table cellpadding=0 cellspacing=0 style="table-layout:fixed;width:100%"><tr><td></table>');
	this.JC = this.Ch[G];
	this.kj = this.JC[ud]("td")[0]
}
var vq="hidden";
uq[v].tE = function(){
	var a = xp(this.JC), b = l.max(this.ZE, this.wU), c = this.Ch[B];
	if (a > b) {
		jb(c, b + Oh);
		if (Sf) 
			hb(c, "-moz-scrollbars-vertical");
		else 
			if (T) {
				c.overflowX = vq;
				c.overflowY = "scroll";
				ya(this.JC[B], "auto");
				ya(c, "auto")
			}
			else 
				hb(c, "auto");
		wa(c, "relative")
	}
	else {
		jb(c, O);
		if (Sf) 
			hb(c, O);
		else 
			if (T) {
				c.overflowX = O;
				c.overflowY = O
			}
		wa(c, O)
	}
};
uq[v].gR=uq[v].tE;
function wq(a,b){a.ZE=b;a.tE()};
function xq(){V[E](this);this.pn={};this.kt=0;this.fC=j}
Q(xq,V);
qe(xq);
cb(xq[v],function(a){return a in this.pn});
function yq(a,b){return a.pn[b]||i}
Wa(xq[v],function(a, b){
	zq(this, g);
	try {
		for (var c in this.pn) {
			var d = this.pn[c];
			if ((b || !d.Bp) && a(d) === j) 
				break
		}
	}
	finally {
		zq(this, j)
	}
});
function Aq(a){var b=[];a[Sc](function(c){c.mf&&!c.Ob&&b[o](c.id)},g);return b}
function Bq(a,b,c){var d=yq(a,c);if(!(d[K]==b)){bb(d,b);a[A](new Cq([c]))}}
function Dq(a, b){
	var c = yq(a, b);
	c.Ob = !c.Ob;
	var d = jl();
	d.set(b + "/hidden", c.Ob ? Fg : Zn);
	c.Ob || d.set(b + "/off", Zn);
	if (b == "cCN3ZWF0aGVyQGdyb3VwLnYuY2FsZW5kYXIuZ29vZ2xlLmNvbQ") 
		if (c.Ob) {
			var e = d.O("weather", O);
			d.set("weather", O);
			d.set("weatherOld", e)
		}
		else {
			e = d.O("weatherOld", O);
			e = Eq(e);
			d.set("weather", e);
			d.set("weatherOld", O)
		}
	d.Kb();
	Fq(a, !c.Ob, b);
	Gq(a)
}
function Hq(a,b){b&&a[ed](b)&&yq(a,b).Ob&&Dq(a,b)}
function Iq(a, b, c, d){
	if (b && a[ed](b) && c != yq(a, b).mf) {
		c && Hq(a, b);
		Fq(a, c, b);
		if (!d) {
			d = jl();
			d.set(b + "/off", c ? Zn : Fg);
			d.Kb()
		}
		Jq();
		a[A](new Kq(b, c))
	}
}
function Fq(a, b, c){
	var d = yq(a, c);
	d.mf = !!b;
	if (b && !of(an(), c) && !d.Bp) {
		var e = ql();
		Lq(g, "AlterVisible");
		Mq([c], function(){
			e.Nc("sec_cal_load_server");
			Lq(j, "AlterVisible")
		}, function(){
			e.Nc("sec_cal_load_total")
		});
		Nq(c) || Gg([c]);
		Gq(a)
	}
	else 
		Oq()
}
function Pq(a, b){
	if (a.id == b.id) 
		return 0;
	if (a.id == Hg) 
		return -1;
	if (b.id == Hg) 
		return 1;
	var c = b[K] - a[K];
	return c == 0 || a[K] != 2 && b[K] != 2 ? ff(Qq(xq.A(), a), Qq(xq.A(), b)) : c
}
function Qq(a,b){return Rq(a,b.id,g)}
function Rq(a,b,c){var d=Nq(b);a=d&&d.tb?d.tb:yq(a,b)[kd];return c?a:R(a)}
function Sq(a, b){
	var c = yq(a, b);
	if (c) {
		c = ["cid", b, "ltyp", c[K], "lact", "DELETE"];
		var d = a;
		zg.A().Rb("editcallist", c, function(){
			b != Hg && Tq(d, b)
		}, "\u65e0\u6cd5\u79fb\u9664\u65e5\u5386", 5)
	}
}
function Uq(a, b, c){
	if (typeof c == xe) 
		c = c == Fg;
	if (c) 
		Tq(a, b);
	else {
		var d = a;
		c = function(f){
			f == 0 && Sq(d, b)
		};
		var e = Nq(b);
		a = e && e.tb ? e.tb : yq(a, b)[kd];
		a = R(a);
		Vq(c, "\u65e0\u6cd5\u79fb\u9664", "\u60a8\u65e0\u6cd5\u4ece\u65e5\u5386\u5217\u8868\u4e2d\u79fb\u9664 <B>" + a + "</B>\uff0c\u56e0\u4e3a\u60a8\u662f\u76ee\u524d\u552f\u4e00\u5177\u6709\u5bf9\u6b64\u65e5\u5386\u7684\u5b8c\u5168\u8bbf\u95ee\u6743\u7684\u4eba\u3002<BR>\u60a8\u53ef\u6388\u4e88\u53e6\u5916\u4e00\u540d\u7528\u6237\u5b8c\u5168\u8bbf\u95ee\u6743\u4ee5\u7ee7\u7eed\u7ba1\u7406\u6b64\u65e5\u5386\uff0c\u6216\u8005\u5c06\u65e5\u5386\u5b8c\u5168\u5220\u9664\u3002", [Wq("\u5220\u9664"), Wq("\u53d6\u6d88")])
	}
}
function _HandleRemoveCalendarResult(a,b){Uq(xq.A(),a,b)}
function Tq(a,b){Fq(a,j,b);delete a.pn[b];Xq(b);Yq(b);a[A](new Zq(b));Gq(a);Oq(j,i,g);$q(1)}
function Gq(a){if(a.kt==0){a.fC=j;a[A](new ar)}else a.fC=g}
function zq(a,b){if(b)a.kt++;else a.kt--;a.kt==0&&a.fC&&Gq(a)}
function br(a, b, c, d, e, f, h, k){
	var p = !!d && (d | 0) == d && 1 <= d && d <= 21;
	p || (d = cr(a));
	a.pn[c] = new dr(b, c, d, e, !f, h, k || j);
	p || jl().set(c + "/color", d[q]());
	a[A](new er(c))
}
function cr(a){var b={};a[Sc](function(c){c.Ob||(b[c[lc]]=1)});return Lo(b)}
function dr(a,b,c,d,e,f,h){gb(this,a);this.id=b;Ga(this,c);bb(this,d);this.mf=e;this.Ob=f;this.Bp=h}
function ar(){U[E](this,"clm.updated")}
Q(ar,U);
function er(a){U[E](this,"clm.added");this.id=a}
Q(er,U);
function Zq(a){U[E](this,"clm.removed");this.id=a}
Q(Zq,U);
function Cq(a){
	U[E](this, "clm.expanded");
	this.YS = a
}
Q(Cq,U);
function Kq(a,b){U[E](this,"clm.itemstate");this.id=a;this.mf=b}
Q(Kq,U);
var gh={};
function fr(a, b, c, d){
	var e = xq.A();
	if (e[ed](a)) 
		Iq(e, a, g);
	else {
		a = ["cid", a, "ltyp", 0, "lact", "ADD", "cpub", b ? Fg : Zn];
		c && a[o]("invEmailKey", c);
		zg.A().Rb("editcallist", a, undefined, "\u975e\u5e38\u62b1\u6b49\uff0c\u65e0\u6cd5\u52a0\u8f7d\u60a8\u7684\u65e5\u5386\u3002 \u8bf7\u7a0d\u7b49\u51e0\u5206\u949f\uff0c\u7136\u540e\u518d\u8bd5", 8, d)
	}
}
function gr(a){for(var b=0;b<a[s];b++)Iq(xq.A(),a[b],j,g)};
function hr(a, b, c, d, e, f, h){
	Df[E](this);
	this.et = a;
	this.Sj = b;
	this.Iy = c;
	this.zk = h ? new uq(qj(this.Iy)) : i;
	this.kj = h ? this.zk.kj : qj(this.Iy);
	this.M = new Zo(this);
	this.Kv = f;
	this.vc = new tk(this);
	this.M = new Zo(this);
	this.Qe = new gp(e, d, g);
	var k = this;
	pg(this.Sj, "clm.updated", function(){
		ir(k)
	});
	pg(this.Sj, "clm.expanded", function(p){
		a: {
			p = p.YS;
			for (var r = p[s], t = 0; t < r; t++) 
				if (jr(k, p[t])) {
					k.Qe.expand();
					break a
				}
		}
	});
	pg(this.Sj, "clm.itemstate", function(p){
		p = p.id;
		if (jr(k, p)) {
			kr();
			k.dH(qj("label-" + p), 1)
		}
	});
	pg(this.Qe, "toggle", function(){
		lr()
	})
}
Q(hr,Df);
hr[v].Kr = function(){
	this.M.B(qj(this.kj), "mousedown", this.aS);
	var a = Je.YD, b = this.vc.qg(this.dH);
	this.VS = new W("<div class=calListRow><div class=calListChip" + a + ' id="${labelId}" title="${name}">${chipInternals}</div><div class=calListImg' + a + ' id="popup-${itemId}" style="background-position:${dist}px -103px"></div></div>');
	this.HO = new W('<div style="background-color:${frameColor};" class=t2>&nbsp;</div><div style="background-color:${bgcolor};" class=calListLabelOuter><div class=calListLabel style="color:${fgcolor};text-decoration:${textDec};${bidiStyles}" onmouseover="' + b +
	'(this.parentNode.parentNode,2)" onmouseout="' +
	b +
	'(this.parentNode.parentNode,1)">${name}</div></div><div style="background-color:${frameColor};" class=t2>&nbsp;</div>');
	this.Kr = pe
};
hr[v].C=function(){this.M.G();this.vc.G();m(this.kj,O);this.Qe.G();hr.l.C[E](this)};
function ir(a){
	a.Kr();
	var b = [];
	a.Sj[Sc](function(h){
		h.Ob || b[o](h)
	}, g);
	b[Xc](Pq);
	for (var c = O, d = 0; d < b[s]; ++d) {
		gh[b[d].id] = d;
		var e = b[d], f = Qq(a.Sj, e);
		if (jr(a, e.id)) 
			c += mr(a, e, Jh(f))
	}
	m(a.kj, c[s] > 0 ? "<div class=calList>" + c + Lh : O);
	a.zk && a.zk.gR();
	lr()
}
function jr(a,b){if(b==Hg)return a.Kv;b=yq(a.Sj,b);return a.Kv?2==b[K]:1==b[K]||0==b[K]}
function nr(a,b,c){a=b+po;if(Ke(c,a))return c[Cd](a[s]);return i}
function or(a, b){
	a = b.id;
	return b = Nq(a) ? Nq(a).ze >= 60 : a == Hg || 2 == b[K]
}
function pr(a,b){var c=Sg[b[lc]];return or(a,b)?c.Dm:c.Xi}
function mr(a, b, c){
	var d = b.id, e = "label-" + d, f = b[lc], h = b.mf;
	or(a, b);
	var k = a.VS, p = h ? "white" : pr(a, b);
	b = h ? pr(a, b) : "white";
	k.b("chipInternals", qr(a, c, p, b, b, h ? hp : "underline", nr(a, "label", e)));
	k.b("dist", -15 * (f - 1) - 26);
	k.b("labelId", e);
	k.b(hf, c);
	k.b("itemId", d);
	return k[q]()
}
function qr(a, b, c, d, e, f){
	a = a.HO;
	a.b(hf, b);
	a.b("fgcolor", c);
	a.b("bgcolor", d);
	a.b("frameColor", e);
	a.b("textDec", f);
	a.b("bidiStyles", Gh(Eh(b), g));
	return a[q]()
}
hr[v].aS = function(a){
	for (var b = a[C]; b && b != this.kj;) {
		var c = b.id;
		if (c) 
			if (a = nr(this, "popup", c)) {
				rr();
				sr() && this.et && this.et.CR(a, b, this.Iy);
				break
			}
			else 
				if (a = nr(this, "label", c)) {
					if (!rr() && sr()) {
						b = ql();
						c = this.Sj;
						var d = a && yq(c, a), e = j;
						if (d) {
							e = !d.mf;
							Iq(c, a, e)
						}
						a = e;
						b.Nc(a ? "cal_check" : "cal_uncheck")
					}
					break
				}
		b = b[L]
	}
};
hr[v].dH = function(a, b){
	for (var c = yq(this.Sj, nr(this, "label", a.id)), d = a[ud](pk), e = [], f = 0; f < d[s]; ++f) {
		var h = d[f];
		lj(h, "calListLabel") && e[o](h)
	}
	d = e;
	d = d[0];
	var k, p;
	e = hp;
	f = pr(this, c);
	switch (b) {
		case 1:
			if (c.mf) {
				k = "white";
				p = f
			}
			else {
				k = f;
				p = "white";
				e = "underline"
			}
			break;
		case 2:
			e = "underline";
			k = "black";
			p = Sg[c[lc]].Yi;
			break
	}
	b = p;
	Ma(d[B], e);
	a = a[ud](pk);
	c = a[s];
	for (d = 0; d < c; ++d) {
		e = a[d];
		f = e[yb];
		if (f == "t2" || f == "b2") {
			Ja(e[B], b);
			kb(e[B], b)
		}
		else 
			if (f == "calListLabel") 
				Ga(e[B], k);
			else 
				if (f == "calListLabelOuter") {
					Ja(e[B], p);
					kb(e[B], b)
				}
	}
};
function tr(){
	return jl().O("timezone")
}
function ur(a){
	vr(a);
	a = bn(a);
	var b = jl(), c = xq.A();
	zq(c, g);
	try {
		for (var d = 0; d < a[s]; ++d) {
			var e = a[d];
			Iq(c, e, !b[Eb](e + "/off", j))
		}
	}
	finally {
		zq(c, j)
	}
}
function vr(a){
	for (var b = Zp($m(a), Y.Qm), c = Y.Qm, d, e = d = 0, f = b[s], h = c[s], k = []; d < f && e < h;) {
		var p = b[d], r = c[e];
		if (p <= r) {
			p = p;
			r = b[++d];
			for (++d; e < h && c[e + 1] <= r;) 
				e += 2
		}
		else {
			p = r;
			r = c[++e];
			for (++e; d < f && b[d + 1] <= r;) 
				d += 2
		}
		aq(k, p, r)
	}
	if (d < f) {
		do 
			aq(k, b[d++], b[d++]);
		while (d < f)
	}
	else 
		for (; e < h;) 
			aq(k, c[e++], c[e++]);
	d = k;
	e = [];
	f = [];
	b = Zp(b, c);
	for (var t in Y.Kg) {
		c = Y.Lf[t];
		f[0] = c.Oi;
		f[1] = c.tj;
		$p(b, f, e);
		for (h = 0; h <= e[s];) {
			k = e[h++];
			p = e[h++];
			Vm(Y, c, k, p)
		}
		e = Zp(f, d);
		e[s] || delete Y.Kg[t]
	}
	Y.Qm = d;
	Y.xi = jq(Y.xi, a);
	Y[A]("estoreupmanifest");
	wr[0] = nq(wr[0], a);
	wr[1] = nq(wr[1], a)
}
function xr(a, b, c, d, e){
	a = a.Sa();
	b = Nm(b).Sa();
	var f = an();
	c = f[Wb](up(c, f));
	f = c[s] > f[s];
	var h = Zm();
	if (undefined === h) {
		a = a;
		b = b
	}
	else {
		var k = f;
		if (a < h[0]) {
			a = a;
			k = g
		}
		else 
			a = h[0];
		if (b > h[1]) {
			b = b;
			k = g
		}
		else 
			b = h[1];
		if (!k) {
			d && d();
			e && e();
			return
		}
	}
	yr(tq(a, b, c), f, d, e)
}
function Yq(a){
	Y[Sc](function(b){
		b.R === a && Xm(b.I())
	});
	Y.xi = Rm(Y.xi, function(b){
		return b.R !== a
	});
	Tm(Y)
}
function Mq(a, b, c){
	var d = an();
	a = up(a, d);
	if (a[s] == 0) {
		b && b();
		c && c()
	}
	else {
		d = Zm();
		if (undefined !== d) 
			yr(tq(d[0], d[1], a), g, b, c);
		else {
			b && b();
			c && c()
		}
	}
}
function yr(a, b, c, d, e){
	if (a[s]) {
		var f = [];
		e || Y.xi[Ib](0);
		var h = Y.xi[Ib](0);
		e = an();
		a = mq(a, h);
		f[o]("emf", a[M]("\n"), "ctz", tr(), "hl", Un);
		for (h = 0; h < e[s]; ++h) 
			f[o]("lef", e[h]);
		b && f[o]("nusr", Fg);
		b = a;
		zg.A().Rb("load.ashx", f, c, "\u975e\u5e38\u62b1\u6b49\uff0c\u65e0\u6cd5\u52a0\u8f7d\u60a8\u7684\u6d3b\u52a8\uff0c\u8bf7\u7a0d\u540e\u518d\u8bd5", 6, d);
		c = Ge();
		if (c - zr >= 30000) 
			wr[1] = wr[0];
		wr[0] = jq(wr[0], b);
		zr = c
	}
	else {
		c && c();
		d && d()
	}
}
function Ar(a){return a.Ke&&"goo.richContent"in a.Ke}
function Br(a){
	if (Ar(a)) {
		var b = a.Ke["goo.richContent"];
		if (!b.srcId) {
			b.srcId = a.R;
			b.eid = a.I()
		}
		return b
	}
	else 
		return i
}
function dh(a){
	return a.He > 1 || a.He !== 0 && !(Hg in lm(a))
}
function eh(a){
	a = lm(a);
	var b = j, c = Cn.A();
	for (var d in a) 
		if (!(d == Hg)) {
			var e = En(c, d);
			if (!(!e || Bn(e))) {
				if (a[d].rb != 2) 
					return j;
				b = g
			}
		}
	return b
}
var wr=[[],[]],zr=0;
function Wg(a){return yq(xq.A(),a.R)[lc]};
var Hg=undefined,Cr=j,Un=window._locale;
Tl("locale",function(){return Un});
Tl("pref locale",function(){return jl().O("locale")});
Tl("message locale",function(){return"zh_CN"});
var Dr=j,Er=j,Fr=i,Gr=j;
function Oq(a,b,c){if(sr())b?Hr(Ir,a):Jr();else{if(a)Er=g;if(b)Fr=b;Dr=g}c||Kr()}
function Hr(a,b){Lr(a[K],a.ub,b)}
function rr(){
	if (sr() || !Mr()) 
		return j;
	if (Gr) {
		Nr();
		return j
	}
	var a = Dr, b = Er, c = Fr;
	Er = Dr = j;
	Fr = i;
	if (c) {
		Hr(c, b);
		return g
	}
	if (b) {
		Hr({
			type: jp[Or[K]],
			ub: Or.ub
		}, b);
		return g
	}
	if (a || ln(window)) {
		Pr();
		Jr();
		return g
	}
	Pr();
	return g
}
function Qr(a){
	var b = ql();
	kr();
	rr();
	ll.XD(a);
	b.Nc(ll[q]() + ".AlterPeriod(" + a + ae)
}
function vl(a){
	var b = yq(xq.A(), a.R);
	if (!b || !b.mf || b.Ob) 
		return j;
	if (Cr || Or[K] == 6) 
		return g;
	return 2 != (a.Z & 7)
}
vl.toCacheKey=function(){return"att:"+Aq(xq.A())[M](X)+"/"+Cr};
function Rr(a, b, c, d){
	if (!d) {
		d = jl();
		d.set(b + "/hidden", Zn);
		d.set(b + "/off", Zn);
		d.Kb()
	}
	Sr(Tr, a, b, c)
}
function Ur(){this.Rv=[];this.eC=i}
var Tr=new Ur;
function Sr(a, b, c, d){
	if (yq(xq.A(), c)) 
		d != yq(xq.A(), c)[K] && Bq(xq.A(), d, c);
	else {
		var e = {};
		gb(e, b);
		e.id = c;
		bb(e, d);
		b = jl();
		e.Ob = b[Eb](c + "/hidden", j);
		e.wJ = e.Ob || b[Eb](c + "/off", j);
		a.Rv[o](e);
		if (a.eC === i) {
			var f = a;
			a.eC = na(function(){
				f.eC = i;
				Vr(f)
			}, 0)
		}
	}
}
function Vr(a, b){
	b = b || Wr;
	for (var c = [], d = [], e = xq.A(), f = jl(), h = 0; h < a.Rv[s]; ++h) {
		var k = a.Rv[h], p = k.id;
		if (!yq(e, p)) {
			if (!k.Ob) {
				d[o](p);
				k.wJ || c[o](p)
			}
			var r = Pn(f, p + "/color", 0);
			br(e, k[kd], p, r, k[K], !!k.wJ, !!k.Ob)
		}
	}
	f.Kb();
	window[Jb](function(){
		Gg(d, function(){
			na(Oq, 0)
		})
	}, 0);
	b(c);
	e[A](new Cq(c));
	a.Rv = []
}
for (var Xr = ["custom,2", "2 \u5929", "custom,3", "3 \u5929", "custom,4", "4 \u5929", "custom,5", "5 \u5929", "custom,6", "6 \u5929", "custom,7", "7 \u5929", "custom,14", "2 \u5468", "custom,21", "3 \u5468", "custom,28", "4 \u5468"], Yr = {}, Zr = 0; Zr < Xr[s];) {
	var Ir = Xr[Zr++], $r = Xr[Zr++];
	Yr[Ir] = $r
}
function as(){
	var a = window[ub]("javascript:''", "goocalprint", "location=0,status=0,fullscreen=0, directories=0,toolbar=0,menubar=0,width=600,height=680", g);
	pp(function(){
		bs(a)
	})
}
function Zg(a){
	if (a.Z & 64) 
		return j;
	else 
		if (a.Z & 256) 
			return (a = Nq(a.R)) && a.ze >= 60;
	return j
}
function _SetInputBox(a,b){if(a=Z(a))Da(a,b)};
var cs=[],ds=-1,es=j,fs=j,gs=i;
function hs(a){
	if (a == 0 && gs && !gs.OP) {
		is(gs.gy, gs[kd], gs.id);
		gs.OP = g
	}
	else 
		if (!(a === ds)) 
			if (cs[a]) {
				var b = a;
				ds = a;
				es = g;
				cs[b].gy(a < b);
				es = j
			}
}
function js(a, b, c){
	if (!es) 
		if (!(ds >= 0 && cs[ds].id == c)) 
			if (fs) 
				is(a, b, c);
			else {
				fs = g;
				gs = {
					id: c,
					name: b,
					gy: a
				};
				js(ks(Or[K], Or.ub, undefined), "Welcome to Calendar", "Welcome to Calendar")
			}
}
function is(a, b, c){
	++ds;
	cs[ds] = {
		id: c,
		name: b,
		gy: a
	};
	if (document[yd]) 
		try {
			var d = document[yd].historyFrame[Lb];
			d[ub]();
			d[tc]("<html><head><title>" + b + '</title></head><body onload="window.parent._goHist(' + ds + ')">' + b + "</body></html>");
			d[pc]()
		} 
		catch (e) {
		}
	else 
		Z("historyFrame").src = "echo.html#" + ds
};
function ls(){}
qe(ls);
ls[v].ge=g;
function ms(a,b){var c=a.ge;a.ge=b;return c};
var ns=Ge(),os=j,ps=j;
function qs(){
	if (ps) 
		return pe;
	return function(){
		rs(ss)
	}
}
pg(window,"resize",function(){if(!ps){var a=Ge();a-ns>=100&&na(qs(),100);ns=a}});
function rs(a){
	if (!(ps || a < ss)) 
		if (Ge() - ns < 40) 
			na(qs(), 40);
		else {
			a = Z(ml);
			if (!a || a[sd] == 0) 
				os = g;
			else {
				ps = g;
				++ss;
				try {
					var b = Z(ml), c = b[pb];
					rl();
					Jr();
					qa(b, c)
				}
				finally {
					ps = j
				}
			}
		}
}
var ss=0;
function ts(){V[E](this);this.MQ=this.LF=this.WY=10}
Q(ts,V);
qe(ts);
function us(a,b,c,d){a.WY=b;a.LF=c;a.MQ=d;a[A]("gcal-chr-hc")}
function rl(){
	var a = Z(ml), b = Lk(a), c = Lk(Z("mothertable")), d = Z("funbox"), e = d && jl()[Eb]("funboxVisible", g) ? d[sd] || 26 : 0;
	d = mn(window);
	e = l.max(250, d - b.y - e - vs);
	(b = l.abs(e - a[sd]) >= 5) && us(ts.A(), d, l.max(e, d - c.y), e);
	if (a[B][od] != e + Oh) 
		jb(a[B], e + Oh);
	a = ll instanceof ws;
	if (!b && !a) 
		return j;
	a = Z("calendars_fav");
	c = wp(a);
	lr();
	wp(a).ba(c) || xs && xs.qa();
	Fl(gl.A());
	return g
}
function lr(){
	if (ys) {
		var a = wp(qj("clst_my")).y;
		a = mn(window) - a;
		var b = xp(qj("clst_my")), c = xp(qj("calendarsBottomChrome"));
		a = a / 2 - (vs + b + c);
		b = (b = qj("searchAddCal")) ? xp(b) : 0;
		b = a - b;
		c = l.max(a - xp(ys.kj), 0);
		var d = l.max(b - xp(zs.kj), 0);
		ys.zk && wq(ys.zk, a + d);
		zs.zk && wq(zs.zk, b + c)
	}
}
var vs=T||Tf?18:16,As=i;
function Mr(a){if(As&&As(a))return j;As=i;return g}
var Bs=i,Cs=i;
function Ds(){Cs||(Cs=Z("cover"));return Cs}
function Es(){Bs||(Bs=Z("mainbody"));return Bs}
function Fs(){var a=Gs;if(a&&a.Hy){ug(a.Hy);a.Hy=undefined}}
var Hs="#c3d9ff";
function Is(a, b){
	if (!(Js === b)) {
		Js = b;
		if (Z("dp_0_header")) 
			for (var c = [O, "_t1", "_t2", "_b2", "_b1"], d = 0; d < c[s]; ++d) {
				var e = Z("dp_0" + c[d])[B];
				if (e.backgroundColor !== b) 
					Ja(e, b)
			}
	}
	if (!(a == "main")) 
		if (!(Hs === b)) {
			Hs = b;
			a = "chrome_" + a;
			for (c = 2; c < 8; ++c) 
				if (d = Z(a + c)) {
					d = d[B];
					e = g;
					if (d.backgroundColor !== b) {
						Ja(d, b);
						e = j
					}
					if (d.borderColor !== b) {
						kb(d, b);
						e = j
					}
					if (e) 
						break
				}
		}
}
var Js="#c3d9ff";
function sr(){return Z("mainbody")[B][ld]!=hp}
function Ks(){
	if (Mr()) {
		var a = Ds(), b = Es();
		ms(ls.A(), g);
		ib(a[B], hp);
		ib(b[B], O);
		ll instanceof ws && Jl(gl.A());
		Fs();
		if (os) {
			os = j;
			rs(ss)
		}
	}
}
function kr(a,b){b||Ls();xs&&xs.qa()}
function Pr(){js(function(){rr()},"\u65e5\u5386\u4e3b\u89c6\u56fe","ShowMainView");Is("main","#c3d9ff");Ks()}
function Ms(a){Ns.b("prefix",a);Ns.b("nav",O);return Ns[q]()}
var Ns=new W('<div class=printAlignLeft id=co>${nav} <div style="width:100%;height:2px"><div style="background:#c3d9ff;border-color:#c3d9ff" class=t1 id="chrome_${prefix}4">&nbsp;</div><div style="background:#c3d9ff;border-color:#c3d9ff" class=t2 id="chrome_${prefix}5">&nbsp;</div></div><div id="chrome_${prefix}2" style="background: #c3d9ff none repeat scroll 0%;border-color:#c3d9ff" class=printborder>'),Os=new W('<div id=tc_top><table id="chrome_${prefix}1" cellpadding=0 cellspacing=0 style="background:#fff;vertical-align:bottom;width:100%;border-color:#c3d9ff"><tr><td>${dateNavigationTable}</td><td style="float:right;text-align:right">${modeLinkTable}</td></tr></table></div>');
function Ps(a){
	Os.b("prefix", a);
	a = S(Qr);
	Qs.b("ondblclick_prev", T ? ' ondblclick="' + a + '(-1);return false;"' : O);
	Qs.b("ondblclick_next", T ? ' ondblclick="' + a + '(1);return false;"' : O);
	Qs.b("advfunc", a);
	Qs.b("blankImageUrl", Ql);
	a = Qs[q]();
	Os.b("dateNavigationTable", a);
	a = bo();
	var b = Yr[a], c = S(as);
	a = "<table cellpadding=0 cellspacing=0><tr>" +
	(Je.jg ? '<td id=printlink><span id=printlinkSpan class=lk onclick="' +
	c +
	'()"></span><div id=printmsg class=printonly>\u8981\u67e5\u770b\u9488\u5bf9\u6253\u5370\u4f18\u5316\u540e\u7684\u66f4\u7b80\u6d01\u7684\u65e5\u5386\u7248\u672c\uff0c\u8bf7\u70b9\u51fb\u5de6\u4fa7\u7684\u6253\u5370\u673a\u56fe\u6807\uff08\u9700\u8981 Acrobat Reader\uff09</div></td>' : O) +
	Rs("\u641c\u7d22\u7ed3\u679c", "search", g) +
	Rs("\u65e5", "day") +
	Rs("\u5468", "week") +
	Rs("\u6708", "month") +
	Rs(b, a) +
	Rs("\u65e5\u7a0b", "list") +
	"</tr></table>";
	Os.b("modeLinkTable", a);
	return Os[q]()
}
var Qs=new W('<table cellpadding=0 cellspacing=0 id=t1><tr><td class=noprint><img class="navbutton navBack" src="${blankImageUrl}" alt="\u4e0a\u4e00\u4e2a" height=17 width=29 onmousedown="${advfunc}(-1);return false;" ${ondblclick_prev}></td><td class=noprint><img class="navbutton navForward" src="${blankImageUrl}"alt="\u4e0b\u4e00\u4e2a" height=17 width=29 onmousedown="${advfunc}(1);return false;"${ondblclick_next}></td><td class=noprint><button onclick="${advfunc}(0);return false;" id=todayButton style="font-size:85%;padding:0 1px">\u4eca\u5929</button></td><td><h2><span id=dateunderlay></span></h2></td>'+(Je.jg?'<td class=noprint>&nbsp;&nbsp;&nbsp;</td>':O)+"</tr></table>");
function Ss(a){Ts.b("prefix",a);return Ts[q]()}
var Ts=new W('</div><table id="chrome_${prefix}3" width="100%" cellspacing=0 cellpadding=0 style="background: #c3d9ff none repeat scroll 0%;"><tr height=2><td></td></tr><tr><td width=8></td><td></td></tr><tr height=4><td></td></tr></table><div style="height:2px"><div style="background:#c3d9ff;border-color:#c3d9ff" class=t2 id="chrome_${prefix}6">&nbsp;</div><div style="background:#c3d9ff;border-color:#c3d9ff" class=t1 id="chrome_${prefix}7">&nbsp;</div></div></div>'),Us=j,Vs=i;
function Ws(){
	var a = Z("nt1");
	if (!a) {
		a = '<div style="background:#fad163;border-color:#fad163" class=t1>&nbsp;</div>'[w]("t1", "t2");
		m(Z("ntowner"), '<div style="visibility: hidden"id=nt1><div style="padding-bottom:4px" align=center><table class="mbox" style="background:#fff" cellpadding=0 cellspacing=0><tr><td><div style="background:#fad163;border-color:#fad163" class=t1>&nbsp;</div>' + a + '<div style="background:#fad163;border-color:#fad163" class="mbox-cont" id=nt2>.</div>' + a + '<div style="background:#fad163;border-color:#fad163" class=t1>&nbsp;</div></td></tr></table></div></div>');
		a = Z("nt1");
		Jr()
	}
	return a
}
function Ls(a){if(Us){Us=j;var b=Ws();if(!(a&&a!=Vs))ob(b[B],vq)}}
var Xs=i;
function Ys(a){
	var b = Ws();
	Us = g;
	Xs && Xs();
	if (b && b[B].visibility != O) 
		ob(b[B], O);
	if (b = Z("nt2")) {
		var c = b[sd];
		m(b, a);
		b[sd] != c && Jr()
	}
}
function Ip(a,b){af(a);if(ve(a))a=a[M]("<br>");Ys(a);Vs=b}
function Zs(){var a=Z("mb1");if(a){ib(a[B],hp);rl()}}
function $s(a, b, c){
	if (!((new Date).getTimezoneOffset() != c)) {
		var d = S(Zs);
		c = ['&nbsp;&nbsp;&nbsp;<a href="javascript:', d, "();", S(at), "('", a, "')\">\u662f</a>"][M](O);
		a = ['&nbsp;&nbsp;&nbsp;<a href="javascript:', d, "();", S(bt), "('", a, "')\">\u5426</a>"][M](O);
		d = ['&nbsp;&nbsp;&nbsp;<a href="javascript:', d, "();", S(ct), '()">\u4e0d\u518d\u8be2\u95ee</a>'][M](O);
		b = "\u8981\u5c06\u65f6\u533a\u66f4\u6539\u4e3a" + b + "\u5417\uff1f " + c + X + a + d;
		af(b);
		if (c = Z("mb1")) {
			m(c, b);
			ib(c[B], "block");
			rl()
		}
	}
}
var dt={};
Tl("Who's loading?",function(){var a=[];for(var b in dt)a[o](b);return a[M](no)});
function Lq(a, b, c){
	var d = Z("lo");
	if (a) {
		dt[b] = 1;
		a = 16;
		b = 1;
		if (c) {
			var e = yp(document[rc]);
			c = wp(c);
			a += e - c.x - c.fp;
			b += c.y
		}
		nb(d[B], a + Oh);
		d[B].top = b + Oh;
		ib(d[B], O);
		m(d, "\u6b63\u5728\u52a0\u8f7d...");//正在加载
	}
	else {
		delete dt[b];
		ib(d[B], hp)
	}
}
function et(a){return function(){Lq(j,a)}}
function _insertAxsScript(a){
	a = zj("script", {
		src: a + "axs_standalone.js"
	});
	document[rc][n](a);
	Ej(qj("axsLink"))
};
var ft=i;
function _setMapLink(a){ft=a};
var gt=0,ht=[],it=[],jt=180000,kt=i,lt=undefined;
Tl("ping_running_",mt);
Tl("ping_counter_ (ms)",function(){return gt});
Tl("ping_period_",function(){return jt});
/** setInterval每隔3分钟向服务器请求一次数据 */
function nt(a, b){
	if (!mt()) {
		lt = window[Yb](Fe(ot, i, i, i), l.max(jt, 1000));
		if (a) 
			(b || ot)()
	}
}
/** 向服务器请求数据 */
function pt(a, b, c, d){
	c = (c || Gp)(d);
	qt(b, c < 300 && c >= 200);
	a.zE(undefined, d, kt, "POST")
}
function ot(a, b, c, d){
	var e = ++gt, f;
	f = [];
	for (var h = ht[s]; --h >= 0;) 
		if (it[h] === -1) {
			it[h] = e;
			var k = ht[h];
			try {
				var p = k.tH();
				p && Array[v][o][fd](f, p)
			} 
			catch (r) {
			}
		}
	f = f;
	a = a || zg.A();
	c = c || Dg;
	b = Fe(b || pt, a, e, undefined);
	d = d || qt;
	if (f = rt(f)) 
		try {
			a.XB ? c(kt, undefined, f, b) : a[Gc](kt, [], f, P(d, i, e, g), P(d, i, e, j))
		} 
		catch (t) {
			qt(e, j)
		}
	else 
		d(e, j)
}
function st(){window[cd](lt);lt=undefined;nt(g)}
function mt(){return ne(lt)}
function qt(a,b){for(var c=ht[s];--c>=0;)if(it[c]==a){it[c]=-1;if(b){var d=ht[c];undefined!==d.ny&&d.ny()}}}
function rt(a){return mf(a,function(b){return Wp(b[0],b[Ib](1))})[M]("\n")};
var ut = {
	tH: function(){
		var a = Qm(Y, tt());
		if (a[s]) {
			a = ["load.ashx", "emf", a[M]("\n"), "ctz", tr(), "hl", Un];
			for (var b = an(), c = 0; c < b[s]; ++c) 
				a[o]("lef", b[c]);
			return [a]
		}
		return []
	},
	ny: undefined
}, vt = {
	tH: function(){
		var a = Mo.A();
		if (yf(a.Vj)) 
			return undefined;
		var b = ["perf", "perf", Oo(a, undefined, _isGoogUser ? "_g" : O)];
		a.reset();
		return [b]
	},
	ny: undefined
};
function wt(a){
	na(function(){
		var b = Qm(Y, tt());
		if (b[s]) {
			b = ["emf", b[M]("\n"), "ctz", tr(), "hl", Un];
			zg.A().Rb("load.ashx", b)
		}
	}, a)
}
function tt(){var a={};xt(function(b){a[b.id]=g});return a}
Tl("active calendars",function(){var a=[];for(var b in tt())a[o](b);return a[M](no)});
var ll=i,yt=60,ys=undefined,zs=undefined;
function _setDefaultEventLengthInMinutes(a){yt=a}
function zt(){bb(this,-1);this.ub=1}
sa(zt[v],function(){return"[type: "+(this[K]>=0&&this[K]<jp[s]?jp[this[K]]:this[K][q]())+", extent: "+this.ub+"]"});
var Or=new zt;
function At(a){
	var b = Bt(), c = ul[Oc].V(), d = j;
	if (a) 
		d = g;
	else 
		if (Or[K] == 2) 
			d = xl.Pa.ba(c);
		else 
			if (Or[K] == 1) {
				if (b.L() <= xl.Pa.L()) {
					d = qi(b);
					d.F += 6;
					d = xl.Pa.L() <= d.V().L()
				}
			}
			else 
				if (Or[K] == 4 && Or.ub > 7) {
					a = ri(xl.Pa, b);
					if (0 <= a && a < 7) 
						d = g
				}
				else 
					d = xl.Pa.ba(b);
	if (a = Z("todayButton")) 
		Fa(a, d)
}
var Ct=[];
function Dt(a){
	Ct = Ct[Wb](up(a, Ct))
}
function Wr(a){Lq(g,"RegisterCalendars");Mq(a,et("RegisterCalendars"))}
function Et(){
	var a, b;
	a = xl.Pa;
	var c = ui(a.K, a.J, 1);
	b = qi(c);
	var d = _hosted;
	if (ll && !d) 
		if (Y) {
			var e = Zm();
			if (e && e[s]) {
				d = ri(Ii(e[1]), Ii(e[0]));
				d = Y.Yk / d >= 5
			}
		}
	if (d || _hosted) {
		c = c.Ka() - ao();
		if (c < 0) 
			c += 7;
		if (ci(a.K, a.J) < 30 || c < 5) 
			c += 7;
		b.F -= c;
		a = b.X();
		b.F += 49;
		b = b.X()
	}
	else {
		b.F -= 42;
		a = b.X();
		b.F += 168;
		b = b.X()
	}
	Lq(g, "eventLoad");
	xr(a, b, Ct, Ft())
}
function Ft(){
	var a = ql();
	return function(){
		a.Nc("secondaryCalLoadTime");
		Ro("timeToSecondaryCalsLoaded", Ge() - ja);
		Ct = [];
		rg(Gt.A(), "rgerf", Ht);
		Lq(j, "eventLoad")
	}
}
var It=j;
function Ht(){
	if (!It) {
		var a = Ct[s];
		if (!(a > 1 || a == 1 && Ct[0] != Hg)) {
			It = g;
			Jt.Nc("allCalsVisible")
		}
	}
}
var ul=i;
function Kt(){Jr();var a=Z("dateunderlay");if(a)m(a,ll.Os());At()}
function Bt(){return ul.Ua.V()}
function Lt(a){
	var b = a;
	if (Mt(b)) 
		b = Nt(bo());
	window[Jb](function(){
		js(ks(Or[K], Or.ub, b), "Changing modes", "CAL_setModeWithHist" + b);
		Lr(b)
	}, 0)
}
function ks(a,b,c){return function(d){d||c==undefined?Lr(a,b):Lr(c,undefined)}}
/** 画行事历部分 */
function Lr(a, b, c){
	var d = ql();
	a = a;
	var e = b;
	if (Mt(a)) {
		a = Nt(bo());
		e = undefined
	}
	kr();
	rr();
	b = a;
	e = e;
	if (typeof b != re || b < 0 || b >= jp[s]) {
		if (typeof b == xe && typeof e == "undefined") {
			var f = b[Ob](",", 2);
			if (f[s] == 2) {
				b = f[0];
				e = ka(f[1], 10)
			}
		}
		for (f = 0; f < jp[s]; f++) 
			if (jp[f] == b) {
				b = f;
				break
			}
	}
	b = {
		Ql: b,
		ub: e
	};
	var h;
	switch (b.Ql) {
		case 0://day
			h = new Ot;			b.ub = 1;
			break;
		case 1://week
			h = new Pt(ao(), $n());
			b.ub = h.On.SM;
			break;
		case 2://month
			h = new Qt(ao(), $n());
			b.ub = 31;
			break;
		case 3://list
			h = new Rt;			b.ub = 1;
			break;
		case 6://search
			h = new St;			b.ub = 1;
			break;
		case 4://compact
			h = new ws(b.ub);
			break;
		default:
	}
	h = h;
	f = (e = Or[K] !== b.Ql || Or.ub !== b.ub) || b.Ql === 6;
	if (c === g) 
		f = g;
	if (!f) 
		return j;
	c = Or[K];
	if (b.Ql === 6 && e) {
		Tt = {};
		Tt.ub = Or.ub;
		bb(Tt, Or[K])
	}
	Or.ub = b.ub;
	bb(Or, b.Ql);
	Fs();
	if (c === 6 || c === 3 && e) {
		Ut = i;
		m(Z("lvHeader"), O);
		ib(Z("lvHeader")[B], hp);
		xa(Z(ml), O)
	}
	ll instanceof ws && !(h instanceof ws) && gl.A().Wa();
	if (b.Ql === 6 || b.Ql === 3 && e) 
		Ut || (Ut = new Vt("listview"));
	h instanceof ws && !(ll instanceof ws) && Gl(gl.A());
	ll = h;
	if (e) {
		c = jp[Or[K]];
		if (Or[K] == 4) 
			c += "," + Or.ub;
		c = c;
		c = Nt(c);
		for (h = 0; h < Wt[s]; ++h) {
			b = Z("mode_link" + h)[ud]("DIV");
			e = Wt[h] == c;
			for (f = 0; f < b[s]; ++f) {
				var k = b[fc](f);
				if (k[yb] == "t1" || k[yb] == "t2") 
					k[B].background = e ? "#c3d9ff" : "#e8eef7";
				else 
					xa(k, e ? "modelinkOn" : "modelinkOff")
			}
		}
	}
	Xt() || Kt();
	d.Nc("SetMode." + a);
	return g
}
function Xt(){
	if (Gs && Gs.hv()) 
		return j;
	var a;
	a = Or[K];
	a = a = a == 2 ? 3 : a == 1 ? 2 : 1;
	var b = ul;
	if (a != b.nb || (a == 1 || a == 2) && Or.ub != tl(b)) {
		Ho(b, a, Or.ub);
		return !!Gs
	}
	return j
}
var Wt=[],Yt=0;
function Rs(a, b, c){
	var d = "mode_link" + Wt[s], e, f = b;
	if (Mt(b)) {
		e = "id=customModeLabel";
		Yt = Wt[s];
		f = Nt(b)
	}
	else 
		e = 'id="mode-' + b + Qe;
	b = S(Lt) + jk + ef(b) + ae;
	Wt[o](f);
	Zt.b("idval", d);
	Zt.b("mousedown", b);
	Zt.b("text", R(a));
	Zt.b("optid", e);
	Zt.b("style", c ? 'style="display:none"' : O);
	return Zt[q]()
}
var Zt=new W('<td id="${idval}" ${style} onmousedown="${mousedown};return false;" class=noprint> <div style="background:#e8eef7" class=t1>&nbsp;</div> <div style="background:#e8eef7" class=t2>&nbsp;</div> <div class=modelinkOff><nobr ${optid}>${text}</nobr></div> </td> <td class=noprint>&nbsp;</td>');
function $t(a){var b=Yr[a||bo()],c=Z("customModeLabel");if(c)m(c,R(b));Wt[Yt]=Nt(a)}
var au=/^custom/;
function Mt(a){return!!(typeof a==xe&&a[Dc](au))}
function Nt(a){return a[w](au,"compact")}
var bu=O;
function cu(a){bu!=a&&du()}
function Nr(){Ip("\u6b63\u5728\u5237\u65b0 Google \u65e5\u5386...");jn(0)}
function du(){if(sr())Nr();else Gr=g}
function eu(){fu(i)}
var xs=i;
function gu(){Vr(Tr,Dt)};
var Gs=i,hu=i;
function Kr(){Gs&&Gs.Q.Ga()};
function _renderInit(a, b, c, d, e){
	Hg = a;
	bu = b;
	pn(!ne(Io));
	Io = d;
	gn = new qn(b + "calendarjs_", "compiled__" + "zh_CN"[xd]() + ".js" + c);
	gn.qo = function(f, h, k){
		var p = Bp();
		Dp(p, f, function(){
			Gp(p) == 200 && Sp(p) ? h(p[Qb]) : k()
		})
	};
	yn(gn, Fe(Ip, '\u62b1\u6b49\uff0cGoogle \u65e5\u5386\u6682\u65f6\u4e0d\u53ef\u7528\u3002\u8bf7\u7a0d\u540e\u518d\u8bd5\u3002\u5982\u679c\u95ee\u9898\u4ecd\u7136\u5b58\u5728\uff0c\u8bf7\u8bbf\u95ee<a href="//www.google.com/support/calendar/bin/answer.py?answer=63579&hl=zh-CN">\u652f\u6301\u4e2d\u5fc3</a>\u3002'));
	zg.A().yd(e);
	ht = [];
	it = [];
	if (jt !== 600000) {
		jt = 600000;
		if (mt()) {
			window[cd](lt);
			lt = window[Yb](Fe(ot, i, i, i), jt)
		}
	}
	kt = "ping";
	ht[o](ut);
	it[o](-1);
	ht[o](vt);
	it[o](-1);
	window[Jb](Fe(lp, pe), 0);
	window[Jb](P(gn.wK, gn, "eventform"), 6000);
	window[Jb](P(gn.wK, gn, "detailssettings"), 30000);
	pg(Y, "estoredelete", function(f){
		f = f.un;
		iu && f in iu && ju(f)
	})
}
function _renderBody(){
	m(Z("mainnav"), Ps("main"));
	m(Z("cover"), [Ms("cover"), "<div id=coverinner></div>", Ss("cover")][M](O));
	var a = Io[18] ? $l() + "/calendar/" + Zl() + "/c/" + rp + "/" : "/calendar/c/";
	en().rL = a;
	pg(Cn.A(), "gcal$pae", ku);
	zg.A().gD = Ip
}
function _renderMain(a, b, c, d, e, f, h, k){
	if (T)//是否为ie浏览器
		try {//解决背景变换时鼠标闪烁问题
			document.execCommand("BackgroundImageCache", j, g)
		} 
		catch (p) {
		}
	if (a) 
		if (a = Z("promo_ads")) 
			ib(a[B], O);
	ys = new hr(i, xq.A(), "calendars_my", "lhscalinner_my", "clst_my", g, g);
	zs = new hr(i, xq.A(), "calendars_fav", "lhscalinner_fav", "clst_fav", j, g);
	a = jl();
	var r = new Date(1970, 11, 29, 13, 0, 0, 0), t = Zn;
	if ("toLocaleTimeString" in r) 
		t = r.toLocaleTimeString()[ic]("13") >= 0 ? Fg : Zn;
	Sn(a, "format24HourTime", t);
	var u = r.toLocaleDateString();
	r = u[ic]("12");
	t = u[ic]("29");
	if (r < 0 && t >= 0) 
		for (var x = (new Date(1970, 8, 29, 13, 0, 0, 0)).toLocaleDateString(), y = l.min(u[s], x[s]), D = 0; D < y; D++) 
			if (u[Wc](D) != x[Wc](D)) {
				r = D;
				break
			}
	if ((r | t) >= 0) {
		x = "MDY";
		u = u[ic]("70");
		x = r < t ? u >= 0 && u < r ? "YMD" : "MDY" : "DMY";
		Sn(a, "dtFldOrdr", x)
	}
	Sn(a, "weekView5", Zn);
	Sn(a, "defaultCalMode", "week");
	Sn(a, "showDeclined", Fg);
	Sn(a, "locale", Un);
	if (fa && _ol_serve_ol) {
		_ol_load_prefs();
		$t(bo())
	}
	a = jl();
	Cr = Fg == a.O("showDeclined", Fg);
	r = jl();
	xl = new Wo(Pn(jl(), "tzoffset"), Pn(r, "tztransn", undefined), Pn(r, "tznextoff", undefined));
	b && Op(b);//加载所有日历信息
	c && Op(c);//加载用户行事历信息
	d && Op(d);//加载时间范围信息
	b = f ? sm(f).V() : xl.Pa;
	d = ao();
	c = xl;
	f = !$n();
	r = Yn() ? 5 : 7;
	d = new zo(c, d, f, 1, r);
	b = b || c.Pa;
	d.set(b, b, b);
	ul = d;
	h || (h = a.O("defaultCalMode", "week"));//显示模式 day/week(default)/month
	k && gu();//画行事历部分
	Lr(h);
	At();
	Et();
	e && Op(e);
	a.Kb()
}
var lu=i,Jt=i;
function _renderPost(){
	nt();
	var a = ao(), b = new go;
	a = new Yi(a);
	var c = new nj, d = Yn() ? 5 : 7;
	hu = new qo(qj("dp_0"), b, a, c, undefined, undefined, 1, d);
	hu.em(xl.Pa);
	hu.fb();
	Gq(xq.A());
	if (sr() && Mr()) {
		b = {};
		if ((a = window[dc][$c][Dc](/^(([^:\/?#]+):)?(\/\/([^\/?#]*))?([^?#]*)(\?([^#]*))?(#(.*))?/)) && a[7]) {
			a = a[7][Ob](/&/g);
			c = 0;
			for (d = a[s]; c < d; ++c) {
				var e = a[c], f = e[ic]("="), h;
				if (f >= 0) {
					h = e[I](0, f);
					e = e[I](f + 1)
				}
				else {
					h = e;
					e = O
				}
				h = oa(h[w](/\+/g, X));
				e = oa(e[w](/\+/g, X));
				(b[h] || (b[h] = []))[o](e)
			}
		}
		b = b;
		if ("settings" in b) {
			b = ca(b.settings[0]);
			pa(b) || mu(b, j)
		}
	}
	lu = b = Ge();
	a = Mo.A();
	Jt = new Po(a);
	Qo(Jt, ja - _tsf);
	Jt.Nc("totalLoadTime");
	Ro("scriptTime", _postScript - _preScript);
	Ro("renderHeadTime", _eoHeadTime - ja);
	Ro("waitTime", _beginBodyTime - _eoHeadTime);
	Ro("loadTime", b - ja);
	Ro("defaultMode", Or[K]);
	Ht();
	if (gq) 
		gq();
	else 
		fq = g
}
function ku(a){a=a.rW;a.dg!=0&&An(a)&&en().Pv(a.ra,a.We)};
bq=function(){return jl()[Eb]("format24HourTime",On(Zn))};
if(typeof Wn==se)cq=Wn;
function nu(a,b){return yl(b).oc(a)};
function ou(){}
ou[v].Ps=function(){var a=ul;return[a.Ua,a.bc]};
ou[v].XD=function(a){a==0?Go(ul):ul.Xj(a)};
function pu(a){
	this.id = a;
	this.cq = {};
	this.uc = [];
	this.Ce = [];
	this.Kl = 32;
	this.kJ = 25;
	this.zB = 5;
	this.Lc = 0;
	qu || (qu = {});
	if (a) 
		qu[a] = this
}
var qu;pu[v].$A=i;
function ru(a, b){
	for (var c = [], d = [], e = 0; e < b[s]; ++e) {
		var f = b[e];
		hm === f[Xb] ? d[o](f) : c[o]({
			Cg: f,
			vn: d[s]
		})
	}
	a.uc = d;
	a.Ce = c
}
pu[v].oa = function(a){
	var b = Z("lv_" + this.id);
	if (b) {
		var c = xp(Z(ml)) / 25, d = ['<table class="printFullHeight listv" cellspacing=0>'], e = this.uc, f = this.Ce, h = ll.Ms();
		this.Z & 1 && h && su(this, d, "<i>" + Hd(nu(Ii(Zm()[0]), g)) + '. <span class=lk onmousedown="' + S(tu) + '()">\u67e5\u627e\u66f4\u65e9\u7684\u6d3b\u52a8</span></i>');
		h = j;
		for (var k = 0, p = i, r = i, t = 0; t < f[s]; ++t) {
			h = !h;
			var u = f[t], x = u.Cg;
			u = u.vn;
			var y = t + 1 < f[s] ? f[t + 1].vn : e[s];
			if (!(this.Lc > y)) {
				if (this.Lc > u) 
					u = this.Lc;
				if (y > u && x) {
					if (p === i) 
						p = x;
					r = yq(xq.A(), e[u].R)[lc];
					this.VD(x, d, h, y - u, r, f[0].Cg, f[f[s] - 1].Cg);
					r = x
				}
				for (var D = g, H = u; H < y; H++, k++) {
					var J;
					J = e[H];
					var ga = yq(xq.A(), J.R)[lc], La = J.bd, Ia = j;
					if (!La && J.Dl && !x.ba(J.da.V())) 
						if (x.ba(J.va.V())) 
							Ia = g;
						else 
							La = g;
					if (!D) {
						d[o]('<tr class="cal', ga, " lv-row");
						h && d[o](" lv-alt");
						y - u == 1 && d[o](" lv-lastevent");
						xl.Pa.ba(x) && d[o](" lv-today");
						d[o](Th)
					}
					D = ' onmousedown="' + S(uu) + "(event," + ef(this.id) + "," + ef(J.I()) + "," + ef(x) + ');"';
					var Hb = undefined;
					Hb = J.Z & 7;
					var Bb = Sg[ga], Gb = Hb == 2, Ac = Gb ? Bb.vk : Bb.Xi;
					Hb = Hb == 3 || Hb == 0 ? "<img" + D + vu(ga) + Pe : Hb == 2 ? '<font style="padding-left:3px" color=' +
					Ac +
					">X</font>" : "&nbsp;";
					d[o]('<td class="lv-eventcell lv-status">', Hb, aj);
					d[o]('<td class="lv-eventcell lv-time"');
					if (La) {
						ga = Zg(J);
						ga = Gb ? Bb.Yi : ga ? Bb.Dm : Bb.Xi;
						d[o]('><div class="lv-allday"', D, '><div class=t2 style="background-color:', ga, '">&nbsp;</div><div class="lv-chipbody" style="background-color:', ga, '">&nbsp;</div><div class=b2 style="background-color:', ga, '">&nbsp;</div></div>')
					}
					else {
						d[o]('><a href="javascript:void(0)" ', D, ' class="lv-event-title" style="color:', Ac, ';">');
						Ia ? d[o]("&raquo;", hl.Xa(J.va, g)) : d[o](J.da.ba(J.va) ? hl.Xa(J.da, g) : Xd(hl.Xa(J.da, g), hl.Xa(J.va, g)));
						d[o]("</a>")
					}
					d[o](aj);
					ga = Je.jg && Ar(J);
					La = Ar(J) ? Br(J).t : J.eb() || "\uff08\u65e0\u4e3b\u9898\uff09";
					Ia = R(J.wi);
					d[o]('<td class="lv-eventcell lv-titlecell">');
					if (ga) {
						Bb = Br(J);
						Bb = Xl(Bb.i);
						d[o]("<div><img class=webContent ", 'onclick="', S(wu), jk, ef(J.I()), ',this)" src="', Bb, '"></div>')
					}
					if (La) {
						Bb = [];
						Bb[o]('<a href="javascript:void(0)" class="lv-event-title" style="color:', Ac);
						if (ga) {
							Bb[o](";margin-left: 20px");
							La = R(La)
						}
						Bb[o](Qe, D, Pe, Ah(La), "</a>");
						d[o](Hh(La, Bb[M](O)));
						Ia && d[o]('<em class="lv-location"> - ', Ia, "</em>")
					}
					d[o](X);
					(i == J.Og ? ch(J.R) : J.Og)[s] > 0 && d[o](xu(-19, -71, 9, 7));
					(J.Z & 10272) === 2048 && d[o](xu(-28, -64, 9, 7));
					(J.Z & 8224) === 8192 && d[o](xu(-28, -71, 9, 7));
					(J.Z & 4128) === 4096 && d[o](xu(-36, -75, 9, 7));
					!(J.Z & 32) && dh(J) && !eh(J) && d[o](xu(-19, -64, 9, 7));
					!(J.Z & 32) && dh(J) && eh(J) && d[o](xu(-45, -57, 10, 7));
					D = J.I() + po + x[q]();
					d[o]('<div id="li-', D, Th);
					(D = this.cq[D]) && yu(this, d, J);
					d[o](Lh);
					J = D;
					d[o]("</td></tr>");
					if (J = J) 
						k += 5;
					D = j
				}
				if (k > c) 
					break
			}
		}
		this.$A = r;
		if (h = ll.Ms()) {
			if (this.Z & 2) {
				c = Ii(Zm()[1]);
				e = S(zu) + "()"
			}
			else {
				c = r;
				e = S(Qr) + "(1)"
			}
			su(this, d, "<i>" + Id(nu(c, g)) + '. <span class=lk onmousedown="' + e + '">\u67e5\u627e\u66f4\u591a</span></i>')
		}
		d[o]("</table>");
		m(b, d[M](O));
		a && p != i && Bo(ul, p, 1)
	}
};
function Au(a){
	var b = Zm(), c = Ii(b[0]).X();
	b = qi(Ii(b[1]));
	b.F += 61;
	b = b.X();
	Lq(g, "LoadLaterEventsFromServer");
	xr(c, b, [], function(){
		na(function(){
			a !== g && Qr(1);
			Lq(j, "LoadLaterEventsFromServer")
		}, 0)
	}, undefined)
}
function zu(){Au()}
function Bu(a){
	var b = Zm(), c = Ii(b[1]).X();
	b = qi(Ii(b[0]));
	b.F -= 61;
	b = b.X();
	Lq(g, "LoadEarlierEventsFromServer");
	xr(b, c, [], function(){
		na(function(){
			a !== g && Qr(-1);
			Lq(j, "LoadEarlierEventsFromServer")
		}, 0)
	}, undefined)
}
function tu(){Bu()}
function Cu(a,b){if(!(undefined===a&&undefined===b)){pu[E](this,a);this.wn=b;this.b_=xl.Pa.X()}}
Q(Cu,pu);
Cu[v].VD = function(a, b, c, d, e, f, h){
	c = c ? " lv-alt" : O;
	e = d == 1 ? O : " lv-lastevent";
	var k = xl.Pa.ba(a) ? " lv-today" : O;
	b[o]('<tr class="lv-row lv-newdate lv-firstevent ', k, c, e, Qe, '><th class="lv-datecell" rowspan="', d, '"><a class="lv-datelink" href="javascript:void(', S(Du), jk, ef(a), '))">', co[a.Ka()], X, yl(g).Bn(a, f, h), "</a></th>")
};
function Du(a){a=sm(a).V();Bo(ul,a,1);Lt("day")}
function su(a,b,c){b[o]("<tr><td colspan=5><blockquote>",c,"</blockquote></td></tr>")}
function uu(a, b, c, d){
	function e(){
		var f = Am(Y, c);
		if (yq(xq.A(), f.R).Bp) 
			Eu.ql(f, new ag(a));
		else {
			f = qu[b];
			var h = Z("li-" + c + po + d);
			if (f.cq[c + po + d] === g) {
				ib(h[B], hp);
				delete f.cq[c + po + d]
			}
			else 
				Fu(h, c, d, f)
		}
	}
	mp(function(){
		ph ? na(e, 0) : e()
	})
}
function Fu(a, b, c, d){
	d.cq[b + po + c] = g;
	if (a[Tb][s] == O) {
		c = [];
		b = Am(d.wn, b);
		yq(xq.A(), b.R)[lc];
		yu(d, c, b);
		m(a, c[M](O))
	}
	ib(a[B], O)
}
function wu(a, b){
	mp(function(){
		var c = new Gu(document[rc], 180);
		c.LP();
		var d = Am(Y, a);
		Hu(b, d, c)
	})
}
function Iu(a){return a.id&&/^li-/[vb](a.id)}
function Ju(a, b){
	a = qu[a];
	if (b) {
		b = [];
		for (var c = Z("lv_" + a.id)[G]; c; c = c[md]) 
			kn(c, Iu, b);
		b = b;
		for (c = 0; c < b[s]; ++c) {
			var d = b[c].id[Ob](po);
			Fu(b[c], d[1], d[2], a)
		}
	}
	else {
		a.cq = {};
		a.oa()
	}
}
function yu(a,b,c){a=Ku(c);b[o]('<div class="lv-event-info">',a,Lh)}
Cu[v].scrollTo=function(a){Bo(ul,a,1);this.Lc=0;this.uc=[];this.Ce=[];this.scrollBy(0)};
Cu[v].scroll = function(a){
	var b = i, c = j, d = wp(Z(ml));
	if (a == 1) {
		c = ul[Oc];
		c = this.$A ? ti(c).max(this.$A) : wi(c, 28);
		ul.uf(c.V())
	}
	else {
		if (a == -1) {
			a = 0;
			var e = this.Ce, f = this.uc;
			c = j;
			for (var h = 0; h < e[s]; ++h) {
				if (c) 
					break;
				var k = e[h], p = k.Cg, r = k.vn;
				k = h + 1 < e[s] ? e[h + 1].vn : f[s];
				if (!(this.Lc > k)) {
					if (this.Lc > r) 
						r = this.Lc;
					for (r = r; r < k; ++r) {
						b = f[r].I() + po + p[q]();
						if (b = Z("li-" + b)) {
							b = wp(b[L]);
							if (b.y + b.ol > d.y + d.ol) {
								c = g;
								break
							}
							++a
						}
					}
				}
			}
			a = l.min(-a + 1, -5)
		}
		else 
			if (a == 2) 
				a = 1;
			else 
				if (a == -2) 
					a = -1;
		Lu(this, a);
		this.oa(g)
	}
};
Cu[v].scrollBy=function(a){Lu(this,a);this.oa(g)};
function Lu(a, b){
	var c = qi(Bt()).V();
	af(a.uc);
	if (a.uc[s] === 0) 
		Mu(a, c);
	else 
		if (a.Lc + b < 0) {
			var d = a.Ce[0].Cg;
			d = Mm(a.wn, d, a.Kl, Nu(a), g);
			if (d[s] == 0) {
				a.Z |= 1;
				a.Lc = 0
			}
			else {
				c = Lm(a.wn, c, a.Kl, Nu(a), g);
				ru(a, d[Wb](c));
				c = Ou(d);
				a.Lc += b + c;
				if (a.Lc < 0) {
					a.Lc = 0;
					a.Z |= 1
				}
				else 
					a.Z &= -2
			}
		}
		else 
			a.Lc += b;
	if (a.Lc > 0) 
		a.Z &= -2;
	if (a.uc[s] - a.Lc < a.kJ) {
		var e = -1;
		for (c = 0; c < a.Ce[s]; ++c) {
			if (a.Ce[c].vn >= a.Lc + b) 
				break;
			e = c
		}
		d = e == -1 ? Bt() : a.Ce[e].Cg;
		c = Lm(a.wn, d, a.Kl, Nu(a), g);
		if (c[s] > 0) {
			e = e == -1 ? 0 : a.Ce[e].vn;
			var f = Ou(c);
			if (e + f >= a.uc[s]) 
				if (f < a.kJ) 
					Mu(a, d);
				else {
					a.Lc -= e;
					f = Ou(c);
					if (f < a.Kl) 
						a.Z |= 2;
					else 
						a.Z &= -3;
					ru(a, c)
				}
		}
	}
	if (ll.Ms()) 
		if (b > 1 && a.Z & 2) 
			Au(g);
		else 
			b < -1 && a.Z & 1 && Bu(g)
}
function Mu(a, b){
	a.Lc = 0;
	var c = Lm(a.wn, b, a.Kl, Nu(a), g), d = Ou(c);
	if (d < a.zB) {
		a.Z |= 2;
		b = Mm(a.wn, b, a.Kl, Nu(a), g);
		var e = Ou(b);
		c = b[Wb](c);
		if (d + e < a.zB) 
			a.Z |= 1;
		else 
			a.Lc = d + e - a.zB
	}
	ru(a, c)
}
function Ou(a){
	for (var b = 0, c = a[s] - 1; c >= 0; --c) 
		a[c] instanceof hm && ++b;
	return b
}
function vu(a){
	var b = -((a - 1) % 10) * 14;
	a = -l[Pb]((a - 1) / 10) * 14;
	return ' src="' + Ql + '" width=14 height=14 style="background-position: ' + b + "px " + a + "px; background-image: url(" + Rl + ');" ';
}
function xu(a, b, c, d){
	return '<img src="' + Ql + '" style="width: ' + c + "px; height " + d + "px; background-position: " + a + "px " + b + "px; background-image: url(" + Rl + ');" width="' + c + '" height="' + d + '"> ';
}
var Ut=i;
function Vt(a){Cu[E](this,a,Y);this.Kl=46}
Q(Vt,Cu);
function Nu(){if(Or[K]===6)return Pu;return vl}
Vt[v].VD=function(a,b,c,d,e,f,h){a&&Vt.l.VD[E](this,a,b,c,d,e,f,h)};
function Qu(){
	var a = [];
	a[o]("<div id=" + ("lv_" + Ut.id) + "></div>");
	m(Z(ml), a[M](O));
	xa(Z(ml), "lv-gridcontainer");
	ib(Z("lvHeader")[B], O)
}
function Ru(){
	var a = [];
	Qu();
	var b = S(Ju);
	a[o]('<div class="chead cheadNotToday noprint"><a id=expand_all_link href="javascript:void(0)" onclick="', b, "('", "listview", '\', true)">\u5168\u90e8\u663e\u793a</a>&nbsp;&nbsp;&nbsp;<a id=collapse_all_link href="javascript:void(0)" onclick="', b, "('", "listview", "', false)\">\u5168\u90e8\u9690\u85cf</a></div>");
	b = S(Qr);
	a[o]('<div style="position:absolute;right:0"><img src="' + Ql + '" width=17 height=9 style="background-position: -181px -2px; background-image: url(' +
	Rl +
	');"onmousedown="', b, '(-2);"> <img src="' + Ql + '" width=17 height=9 style="background-position: -181px -13px; background-image: url(' + Rl + '); padding-right:1em"onmousedown="', b, '(2);"></div>');
	m(Z("lvHeader"), a[M](O));
	Hl(g);
	rl();
	Ut.oa()
}
function Su(){m(Z("lvHeader"),Tu());Qu();Hl(g);rl();Ut.oa();Uu()==0&&Vu()};
function Rt(){}
Q(Rt,ou);
Rt[v].XD=function(a){if(a)Ut.scroll(a);else{a=wl(xl).V();Bo(ul,a,1);Ut.scrollTo(a)}};
sa(Rt[v],function(){return"[ListPolicy]"});
Rt[v].Os=function(){var a=Bt();return yl(g).Of(a)};
Rt[v].Ms=function(){return g};
function St(){Rt[E](this)}
Q(St,Rt);
sa(St[v],function(){return"[SearchPolicy]"});
St[v].Ms=function(){return j};
/** 各个Policy的基类 继承于ou */
function ws(a){
	ou[E](this);
	this.jJ = a;
	Wu(this)
}
Q(ws,ou);
ws[v].rv=j;
function Wu(a){
	var b = (a instanceof Pt || a instanceof Qt) && a.rv;
	a.On = new Xu(a.jJ, b ? 2 : 0, b ? 1 : i)
}
sa(ws[v],function(){return"[CompactPolicy "+this.jJ+"]"});
ws[v].Os=function(){var a=ul;return yl(g).yj(a.In(),a.wq())};
function Xu(a, b, c){
	this.Zq = a <= 7;
	this.SM = (this.Zq ? a : 7) - b;
	this.DX = b;
	this.gH = c
};
/** 显示模式DayPolicy */
function Ot(){
	ws[E](this, 1)
}
Q(Ot,ws);
sa(Ot[v],function(){return"[DayPolicy]"});
/** 显示模式MonthPolicy */
function Qt(a, b){
	this.rv = b;
	ws[E](this, 35);
	this.lJ = a
}
Q(Qt,ws);
Qt[v].Ps=function(){var a=qi(ul[Oc].V());a.F=1;var b=a.X();a.F=ci(a.K,a.J);a=a.X();return[b,a]};
Qt[v].Os=function(){var a=ul[Oc].V();return yl(g).Aj(ui(a.K,a.J,1))};
sa(Qt[v],function(){return"[MonthPolicy]"});
/** 显示模式WeekPolicy */
function Pt(a, b){
	this.rv = b;
	ws[E](this, 7);
	this.lJ = a
}
Q(Pt,ws);
sa(Pt[v],function(){return"[WeekPolicy]"});
function _AP_show(){
	pp(function(){
		Yu()
	})
};
function _ME_ScheduleMeeting(){fn(gn,"dasher",function(){Zu()})};
var $u=100;
function Gt(){V[E](this)}
Q(Gt,V);
qe(Gt);
function Jr(){
	if (ll instanceof ws) 
		gl.A()[jd](ul[Oc].V(), Bt(), ll.On, $u != 100);
	else {
		m(Z(ml), O);
		jb(Z(ml)[B], O);
		Ut.Lc = 0;
		Ut.uc = [];
		Ut.Ce = [];
		Ut.scrollBy(0);
		Or[K] == 6 ? Su() : Ru()
	}
	Gt.A()[A]("rgerf")
}
function Hl(a){var b=Z(ml);if(!a)qa(b,0);b[B].overflowY=a?"scroll":nh?vq:"visible"}
function ah(a){
	var b = -((a - 1) % 14 * 9 + 14);
	a = -(l[Pb]((a - 1) / 14) * 9 + 28);
	return '<img src="' + Ql + '" width="9" height="9" style="background-position: ' + b + "px " + a + "px; background-image: url(" + Rl + ');">&nbsp;'
};
function av(a, b){
	if (a.He >= 5) 
		return i;
	var c = Cn.A();
	b = En(c, a.R).dg == 0 ? a.R : b;
	var d = j, e = i;
	a = lm(a);
	var f = 0;
	for (var h in a) 
		if (!(a[h].rb == 4)) {
			var k = En(c, h);
			if (!(!k || k.dg != 0)) {
				if (++f > 2) 
					return i;
				if (b != h) 
					e = k;
				else 
					d = g
			}
		}
	if (f == 2 && d && e) 
		return e && e.dg != 0 && (!e.We || e.We == e.ra) ? i : e;
	return i
}
function Yg(a){var b=O;if(_allowShowGuestNameFeature){a=av(a,Hg);if(a!=i)b=" ("+(a.We||a.ra)+ae}return b};
function bv(a,b){mp(function(){cv(a,b)})}
function dv(a,b,c,d,e,f,h){mp(function(){ev(a,b,c,d,e,f,h)})}
function Vq(a, b, c, d, e, f, h){
	d || (d = [Wq("&nbsp;&nbsp;&nbsp;\u662f&nbsp;&nbsp;&nbsp;"), Wq("&nbsp;&nbsp;&nbsp;\u5426&nbsp;&nbsp;&nbsp;")]);
	dv(a, b, c, d, e, f, h)
}
function fv(a,b,c){dv(i,a,b,[Wq("&nbsp;&nbsp;&nbsp;\u786e\u5b9a&nbsp;&nbsp;&nbsp;")],c)}
function Wq(a,b,c){var d=["<button"];b&&d[o](' id="',R(b),Qe);c&&d[o](' onclick="',c,Qe);d[o](Pe,a,"</button>");return d[M](O)};
function Nq(a){return Jg.A().O(a)}
function Xq(a){Jg.A()[Kc](a)}
function gv(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H, J, ga, La, Ia, Hb, Bb, Gb, Ac, Bc, Md){
	var Tj = jl().O(a + "/name");
	if (Tj) 
		e = Tj;
	Jg.A().add(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, H, J, ga, La, Ia, Hb, Bb, Gb, Ac, Bc, Md)
}
var hv="__public_principal__";
function iv(a){hv=a}
function jv(){np(function(){var a=kv();lv(a,0,j)})}
function _ShowDetails(a,b,c){np(function(){lv(a,b,c)})}
function _ShareCalendarWithUser(a, b){
	np(function(){
		mv(a, b)
	})
}
function _DT_confirmShareInvite(a, b, c, d, e, f){
	function h(k){
		if (!(k !== 0)) {
			k = ["invAction", "INVITE", "hl", Un];
			for (var p = 0; p < e[s]; ++p) 
				k[o]("invEmailKey", e[p]);
			k[o]("cid", f);
			Cg("invitecaluser", k)
		}
	}
	c = [Wq(c), Wq(d)];
	Vq(h, a, b, c)
}
function xt(a){xq.A()[Sc](function(b){if(b.mf)if(j===a(b))return j})}
function nv(a){xq.A()[Sc](function(b){if(!b.Ob)if(j===a(b))return j})}
var _SE_weatherOn=j,_SE_vcalNotificationsOn=j;
function $q(a){
	if (Mr(function(){
		$q(a)
	})) {
		a = a || 0;
		kr();
		js(function(){
			$q(a)
		}, "\u65e5\u5386\u8bbe\u7f6e\u6807\u7b7e " + a, "GenSettings" + a);
		mu(a, j)
	}
}
function _getChangePasswordUrl(){return"https://www.google.com/accounts/ManageAccount?service=cl&amp;hl=zh-CN"}
function mu(a,b){np(function(){ov(a,b)})}
var pv=[];
function qv(a,b){pv[o]([a,b])}
var rv=-1;
function tv(){rv!=-1&&uv(rv)}
function _SE_ShowInvite(a,b){np(function(){return vv(a,b)})}
function wv(){var a=jl().O("smsVerifiedFlag",Zn);return On(a)}
function zl(){return jl().O("timezone","Etc/GMT")}
function Al(){return jl().O("SecondaryDisplayTimezone")||zl()}
function Bl(){return On(jl().O("HasSecondaryTimezone",Zn))}
function at(a){np(function(){var b={};b.timezone=a;xv(b)})}
function bt(a){var b=jl();b.set("ignoredSuggestTz",a);b.Kb()}
function ct(){var a=jl();a.set("neverSuggestTz",Fg);a.Kb()};
var yv=j,zv=O,Av=O,Bv,Cv,Dv,Ev=O,Fv=O,Gv=O,Hv=i,Iv=i,Jv=O,iu={},Kv={},Tt;
function Lv(a){
	yv = a;
	Jv = Gv = Av = Fv = Ev = zv = O;
	Iv = Hv = i;
	Bv = {
		length: 0
	};
	Cv = {
		length: 0
	};
	Dv = {
		length: 0
	};
	nv(function(b){
		var c = b.id;
		switch (b[K]) {
			case 2:
				Bv[c] = b;
				++Bv.length;
				break;
			case 0:
				Cv[c] = b;
				++Cv.length;
				break;
			case 1:
				Dv[c] = b;
				++Dv.length;
				break
		}
	});
	kr()
}
function Mv(a){
	Lv(j);
	if (Bv[s] == 0 && Cv[s] == 0 && Dv[s] == 0) 
		Ip("\u641c\u7d22\u65e0\u6548 \u2013 \u8bf7\u81f3\u5c11\u6307\u5b9a\u4e00\u4e2a\u8981\u641c\u7d22\u7684\u65e5\u5386\u3002");
	else {
		zv = a;
		a = Le(a);
		a == O ? Ip("\u641c\u7d22\u65e0\u6548 \u2013 \u8bf7\u8f93\u5165\u4e00\u4e2a\u67e5\u8be2\u6761\u4ef6\u3002") : Nv(tr(), j, O, O, a, O, O, O, O, O)
	}
}
function Ov(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D){
	if (!iu[a]) {
		Kv[f] = f in Kv ? Kv[f] + 1 : 1;
		iu[a] = f
	}
	if (!Am(Y, a)) {
		a = Wm(a, b, c, d, e, f, h, k, p, r, t, u, x, y, D, i);
		if (a.I() in Y.Kg) {
			b = Zp([a.Oi, a.tj], Y.Qm);
			for (c = 0; c < b[s];) {
				d = b[c++];
				e = b[c++];
				Vm(Y, a, d, e)
			}
			delete Y.Kg[a.I()];
			a.Z |= 32768
		}
	}
}
function ju(a){if(a in iu){Kv[iu[a]]--;delete iu[a]}}
function Pv(){Qv();Or[K]==6&&Lr(Tt[K],Tt.ub)}
var Rv=j;
function Sv(a){na(function(){Mv(a)},0)}
function Tv(){var a=Z("maininput"),b=a[z];a[$b]();Sv(b)}
function Uv(){pp(function(){Vv()})}
function Qv(){
	m(Z("sropt"), O);
	var a = Z("srreg");
	if (a) 
		ib(a[B], O);
	typeof Wv != "undefined" && Wv();
	Rv = j;
	rs(ss);
	kr()
}
function Jq(){Rv&&pp(function(){Xv()})}
function Yv(){
	Lq(j, "SR_searchServer");
	var a = xq.A();
	zq(a, g);
	try {
		for (var b in Kv) 
			Kv[b] > 0 && !yq(a, b).Ob && Iq(a, b, g);
		Gq(a)
	}
	finally {
		zq(a, j)
	}
	ib(Z("mode_link0")[B], O);
	Tm(Y);
	Lt("search");
	Hv && ul.uf(Hv.V())
}
function Vu(){
	var a = ['<div style="background-color:#fff;margin-top:100px;text-align:center;height:100%">\u6ca1\u6709\u4efb\u4f55\u6d3b\u52a8\u7b26\u5408\u60a8\u7684\u641c\u7d22\u6761\u4ef6\u3002'];
	yv || a[o](X, Sd('<span class=lk onclick="' + S(Uv) + '(); return false;">\u9009\u9879</span>.'));
	a[o](Lh);
	m(Z(ml), a[M](O))
}
function Tu(){
	var a = ["<b>"];
	if (zv) 
		a[o](R(Zv(zv, 50)));
	else 
		Ev && a[o](R(Zv(Ev, 20)));
	Jv && a[o]("&nbsp;</b>" + Nd("<b>" + R(Zv(Jv, 20)) + "</b>") + "<b>");
	Fv && a[o]("&nbsp;</b>" + Od("<b>" + R(Zv(Fv, 20)) + "</b>") + "<b>");
	Hv && a[o]("&nbsp;</b>" + Pd("<b>" + nu(Hv) + " - " + nu(Iv) + "</b>") + "<b>");
	Gv && a[o]("&nbsp;-", R(Zv(Gv, 20)));
	a[o]("</b>");
	//返回到日历
	var b = '<span onmousedown="_SR_backToCalendar()" class=lk><b>&laquo; \u8fd4\u56de\u5230\u65e5\u5386</b></span>&nbsp;&nbsp;&nbsp;&nbsp;';
	if (Av) {
		var c, d;
		if (Av == "my") {
			c = "\u6211\u5168\u90e8\u7684\u65e5\u5386";//我全部的日历
			d = g
		}
		else 
			if (Av == "other") {
				c = "\u6240\u6709\u5176\u4ed6\u65e5\u5386";//所有其他日历
				d = g
			}
			else 
				if (Av == "all") {
					c = "\u6240\u6709\u65e5\u5386";//所有日历
					d = g
				}
				else {
					c = Rq(xq.A(), Av, j);
					d = j
				}
		b += (d ? Rd : Rd)(a[M](O), "<b>" + c + "</b>")
	}
	else 
		b += Qd(a[M](O));
	return '<table width="100%" cellspacing=0 cellpadding=2 style="font-size:10pt"><tr><td>' + b + "</td><td align=right><font size=-1>" + Td("<b>" + Uu() + "</b>") + "&nbsp;&nbsp;</td></tr></table>";
}
function Uu(){var a=0,b=xq.A();for(var c in Kv)if(b[ed](c)&&yq(b,c).mf&&!yq(b,c).Ob)a+=Kv[c];return a}
function $v(){if(Mr()){Pv();st();rr()}}
function Nv(a, b, c, d, e, f, h, k, p, r){
	iu = {};
	Kv = {};
	a = ["ctz", a, "hl", "zh_CN", "as_tp", yv ? "advanced" : "basic"];
	for (var t in Bv) 
		t != "length" && a[o]("as_myuids", t);
	for (t in Cv) 
		t != "length" && a[o]("as_otheruids", t);
	for (t in Dv) 
		t != "length" && a[o]("as_otheruids", t);
	t = a[s];
	if (b) {
		a[o]("as_cal", f);
		h && a[o]("as_ttl", h);
		k && a[o]("as_ppl", Jv);
		p && a[o]("as_loc", p);
		r && a[o]("as_eq", r);
		c && d && a[o]("as_sdt", c, "as_edt", d)
	}
	else {
		e && a[o]("as_q", e);
		var u = [];
		xt(function(x){
			u[o](x.id)
		});
		u[s] == 0 && u[o](Hg);
		a[o]("as_cal", u[M](";"))
	}
	if (t === a[s]) 
		Ip("\u641c\u7d22\u65e0\u6548 \u2013 \u8bf7\u8f93\u5165\u4e00\u4e2a\u67e5\u8be2\u6761\u4ef6\u3002");
	else {
		Lq(g, "SR_searchServer");
		Cg("search", a, pe, Bg(aw, bw, 12))
	}
}
function aw(){Yv()}
function bw(){Lq(j,"SR_searchServer");Ip("\u65e0\u6cd5\u641c\u7d22\u6211\u7684\u65e5\u5386")}
function Zv(a,b){if(!a)return O;return a[s]>b?a[I](0,b)+"...":a}
function Pu(a){return a.I()in iu&&vl(a)}
Pu.toCacheKey=function(){var a=["search"];nv(function(b){b.mf&&a[o](b.id)});return a[M]()};
function cw(a){So("bubble_delete");op(function(){dw(a)})}
function ew(a){op(function(){return fw(a)})};
function gw(a){a=qi(a);var b=wl(xl);a.S=b.S;a.T=b.T<30?30:60;a.ha=0;return a.X()}
function hw(a){if(a){var b=a.cols;b>20||(b=40);b=l.max(iw(a[z],b),5);if(b!=a[dd]){a.rows=b;jw()}}}
function jw(){T||na(kw,0)}
function kw(){
	var a = Z("cannonBall"), b = Z("comments") || Z("options");
	if (b && !a) {
		a = document[Pc]("DIV");
		a.id = "cannonBall";
		m(a, "&nbsp;");
		b[L][gc](a, b);
		na(lw, 100)
	}
}
function lw(){var a=Z("cannonBall");a&&a[L][wc](a)}
function iw(a, b){
	for (var c = 1, d = 0, e; d < a[s]; d = e + 1) {
		var f = 1;
		e = a[ic]("\n", d);
		if (e < 0) {
			e = a[s];
			f = 0
		}
		else 
			if (e - d == b) 
				f = 0;
		c += l[Pb]((e - d) / b) + f
	}
	return c
}
function fu(a){var b=ql();b.kd="ef_new_from_link";op(function(){return mw(a,b)})}
var nw="src";
function mw(a, b){
	if (Mr(function(){
		Qo(b);
		mw(a, b)
	})) {
		var c = ll.Ps();
		c = xl.Pa.max(c[0]).min(c[1]);
		c = gw(c);
		var d = qi(c);
		d.T += yt;
		d = d.X();
		var e = [];
		a !== i && e[o](nw, a);
		e[o]("dates", c + "/" + d);
		e[o]("pprop", "HowCreated:BUTTON");
		ow(e, b)
	}
};
var pw={},bh={};
function qw(a, b, c, d){
	if (a[ic](de) >= 0) 
		aa(new Error("id " + a + " contains a colon"));
	d = b == 1 ? d : -1;
	this.zp = a;
	bb(this, b);
	eb(this, c);
	this.Qd = d
}
sa(qw[v],function(){return rw(this)});
var sw=qw;
function rw(a){return a.zp+de+a[K]+de+a[gd]+de+a.Qd}
function tw(a,b,c,d){b=new qw(a,b,c,d);c=pw[a];delete bh[a];c||(c=pw[a]={});a=rw(b);c[a]=b}
function ch(a){
	var b = [], c = pw[a];
	if (!c) 
		return b;
	for (var d in c) {
		var e = c[d];
		if (e && e.zp == a && e[K] == 1 && (wv() || e[gd] != 2)) 
			b[o](e)
	}
	return b
}
function uw(a, b){
	a = a[Dc](/^(\d+):(-?\d+):(-?\d+)$/);
	if (!a) 
		return i;
	return ka(a[3], 10) >= 0 ? new sw(b, 1, ka(a[1], 10), ka(a[2], 10)) : i
}
function vw(a, b){
	if (i == a) 
		return i;
	for (var c = [], d = 0; d < a[s]; ++d) {
		var e = uw(a[d], b);
		e && c[o](e)
	}
	return c
};
function ww(a){ea(a)}
/** 各种接收信息的分类 */
function xw(a, b){
	switch (a) {
		case "a":
		case "_SR_updateResult":
		case "us":
			a: switch (a) {
				case "a":
				case "_SR_updateResult":
					b[2] = Ti(b[2]);
					b[3] = Ti(b[3]);
					if (b[5] === undefined) {
						b[5] = b[4];
					}
					if (b[6] === undefined) {
						b[6] = b[4];
					}
					b[10] || (b[10] = 0);
					if (b[12]) {
						var c = b[12], d = {};
						for (a = 0; a < c[s]; a += 2) {
							var e = c[a], f = c[a + 1];
							if (e == "goo.richContent") 
								f = eval(f);
							d[e] = f
						}
						b[12] = d
					}
					b[14] = vw(b[14], b[5]);
					c = b[15];
					if (c != i) {
						d = c[4];
						for (a = d[s]; --a >= 0;) {
							e = d[a];
							d[a] = {
								MF: e[0],
								TE: e[1],
								SF: Ti(e[2])
							}
						}
						a = {
							Tv: c[0],
							aj: c[1],
							Nr: c[2] && c[2][0],
							zn: c[2] && Ti(c[2][1]),
							Qp: c[3],
							hj: d,
							As: c[5],
							Nq: c[6]
						};
						b[15] = a
					}
					break a;
				case "us":
					if (b[s] === 1) {
						b[0] = oq(b[0]);
					}
					else {
						b[0] = sm(b[0]);
						b[1] = sm(b[1])
					}
					break a;
				default:
					break a;
			}
			break;
		case "_OpenSettings":
			b[0] = ka(b[0], 10);
			b[1] = b[1] == Fg;
			break;
		case "_AddNewPerson":
			b[2] = ka(b[2], 10);
			b[3] = b[3] == Fg;
			break;
		case "_DS_put":
			b[1] = ka(b[1], 10);
			b[2] = ka(b[2], 10);
			break;
		case "_ShowLoading":
			b[0] = b[0] == Fg;
			break;
		case "_Ping":
			b[0] = ka(b[0], 10);
			break;
		case "sb":
			b[1] = ka(b[1], 10);
			b[2] = ka(b[2], 10);
			if (b[3]) {
				b[3] = ka(b[3], 10);
			}
			break;
		case "_SE_PromptAddCalendars":
			a = b[s];
			c = [];
			for (d = 0; d < a; ++d) {
				f = b[d];
				e = {};
				e.id = f[0];
				e.tb = f[1];
				e.th = f[2];
				e.EA = f[3];
				e.kB = f[4];
				(f = yq(xq.A(), e.id)) && !f.Ob || c[o](e);
			}
			b[0] = c;
			b[qd](1, b[s] - 1);
			break;
	}
}
(function(){
	var a = {};
	a.v = cu;
	a.a = Wm;
	a.d = Xm;
	a.r = Ym;
	a.us = ur;
	a.h = qv;
	a.e = ww;
	a.u = Vn;
	a.ap = In;
	a.sb = tw;
	Mp = a;
	Np = xw
})();
var yw,zw,Aw,Bw=new RegExp("\\.(?:com|edu|gov|int|mil|net|org|aero|asia|cat|coop|museum|biz|info|jobs|mobi|name|pro|tel|travel|\\w\\w)$",nn);
(function(){
	zw = new RegExp('^(((?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*"))(?:\\.(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*")))*)@((?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)(?:\\.(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+))*)))$');
	yw = new RegExp('^(?:(((?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*"))(?:\\.(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*")))*)@(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)(?:\\.(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+))*))|(?:((?:(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)(?:\\040+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*")(?:\\040*))*(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*"))))(?:\\040*)(?:<(?:@(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)(?:\\.(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+))*)(?:,+@(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)(?:\\.(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+))*))*:)?(((?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*"))(?:\\.(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:"(?:[^\\\\"]|\\\\[\\s\\S])*")))*)@(?:(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)(?:\\.(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+))*))>)))$');
	Aw = new RegExp('^(?:(?:"(?:[^\\\\"]|\\\\[\\s\\S])*")|(?:\\[(?:[^\\[\\]\\\\\r]|\\\\[\\s\\S])*\\])|(?:[^\\(\\)<>@,;:\\\\"\\.\\[\\]\\000-\\037\\177\\040]+)|(?:\\040+))')
})();
function Eq(a){if(!a)return Cw();if(a&&(a=="F"||a=="C"))return a;if(a[Zb](0)==pl)return Eq(a[I](1));return Cw()}
function Cw(){return jl().O("country","US")=="US"?"F":"C"};
var _MODULE_TYPE_ATTENDING=Ml,_MODULE_TYPE_INVITE_YOURSELF=Pl,_MODULE_TYPE_COMMENTS=Ol,_MODULE_TYPE_INVITEES=Ll,_MODULE_TYPE_OPTIONS=Nl,_WHACK=jw,_$=Z,_ES_BadPrincipals=gr,_RefreshCalendarWhenDisplayedNext=Oq;
function _SpawnQuickAddEvent(a,b,c,d,e,f,h,k){op(function(){return Dw(a,b,c,d,e,f,h,k)})}
var _ShowMessage=Ip;
function _ShowMessageUndoable(a){mp(function(){Ew(a)})}
var _HideMessage=Ls,_SuggestTimeZone=$s,_DS_SetPublicID=iv,_DS_put=gv,_DS_delete=Xq,_OpenSettings=mu,_OpenQuickAdd=pe,_CreateNewEvent=eu,_SR_updateResult=Ov,_AddNewPerson=Rr;
function _RedrawCheckboxes(){Gq(xq.A())}
var _ShowMainView=Pr,_ReportOperationError=Pp,_ShowLoading=Lq,_Ping=wt,_Dispatch=Op;
function _uid(){return Hg}
var _GenSettings=$q,_bubbleDeleteEvent=cw,_reportSpamEvent=ew,_SE_refreshAddCalendarView=tv,_SR_searchBasic=Mv,_SR_backToCalendar=$v,_SR_showResults=Yv,_SR_searchCalendars=Tv,_SR_showSearchOptions=Uv,_EH_nwC=jv,_EH_nav=Qr;
function _EH_vw(a){Lt(a)}
function _EF_ShowEventDetails(a,b,c,d){var e=ql();e.kd="ef_view_from_other";op(function(){Fw(a,b,c,d,e)})}
function _EF_MailAttendees(){op(function(){Gw()})}
function _EF_MailOrganizer(){op(function(){Hw()})}
function _EF_Dismiss(a,b){op(function(){Iw(a,b)})}
var _goHist=hs,_DI_Alert=fv,_DI_CloseDialog=bv;
function _wi_rpd(a){op(function(){Jw(a)})}
var _rta=hw,_forceRefresh=jn,_ASP_put=sp,_TT_LC=fr;
function _wi_pc(a,b){op(function(){Kw(a,b)})}
function _wi_sr(a,b){op(function(){Lw(a,b)})}
function _SE_PromptAddCalendars(a){np(function(){Mw(a)})}
function _SE_PromptAddGadget(a,b,c,d,e,f){np(function(){Nw(a,b,c,d,e,f)})}
function _SE_PromptUpdateGadget(a,b){np(function(){Ow(a,b)})}
function _TZ_updateCache(a,b,c){np(function(){Pw(a,b,c)})}
function _TZ_redrawTimeZones(a,b){np(function(){Qw(a,b)})}
function _showVarZWindow(){np(function(){Rw()})}
function _ShowPerf(){np(function(){Sw()})}
function _wi_showCurrentEventXmlDocument(){op(function(){Tw()})};
function _lastCalFunc(){};
i(d[3]).Sa(), ca(d[4])))
		}
		b[Xc](qq)
	}
	return b
}
function $m(a){
	for (var b = [], c = 0; c < a[s]; ++c) {
		var d = a[c];
		b[o]([d.Le, d.Jd])
	}
	a = [];
	b[Xc](rq);
	for (var e = 0; e < b[s];) {
		c = b[e];
		d = c[1];
		for (e = e + 1; e < b[s] && d >= b[e][0];) {
			d = l.max(d, b[e][1]);
			++e
		}
		a[o](c[0], d);
		e = e
	}
	return b = a
}
function Rm(a,b){for(var c=[],d=0;d<a[s];++d){var e=a[d];b(e)&&c[o](e)}return c}
function sq(a,b,c){b=l.max(b,a.Le);c=l.min(c,a.Jd);return new hq(a.R,b,c,a.Bj)}
function qq(a,b){return a.R<b.R?-1:a.R>b.R?1:a.Le-b.Le}
function kq(a, b, c){
	var d = 0, e = 0, f = a[s], h = b[s], k = ki, p = i;
	function r(H, J){
		var ga;
		if (H) {
			ga = b[e];
			if (J === i || J >= ga.Jd) 
				++e
		}
		else {
			ga = a[d];
			if (J === i || J >= ga.Jd) 
				++d
		}
		J = sq(ga, k, J || ga.Jd);
		k = J.Jd;
		p = ga.R;
		H ? c(i, J) : c(J, i)
	}
	for (; d < f && e < h;) {
		var t = a[d], u = b[e];
		if (t.R !== u.R) 
			if (t.R < u.R) {
				if (t.R !== p) 
					k = ki;
				r(0, i)
			}
			else {
				if (u.R !== p) 
					k = ki;
				r(1, i)
			}
		else {
			if (t.R != p) 
				k = ki;
			var x = l.max(k, t.Le), y = l.max(k, u.Le);
			if (x !== y) 
				x < y ? r(0, u.Le) : r(1, t.Le);
			else {
				y = l.min(t.Jd, u.Jd);
				var D = sq(t, x, y);
				x = sq(u, x, y);
				k = y;
				p = t.R;
				c(D, x);
				t.Jd <= y && ++d;
				u.Jd <= y && ++e
			}
		}
	}
	if (d < f) {
		do {
			if (a[d].R !== p) 
				k = ki;
			r(0, i)
		}
		while (d < f)
	}
	else 
		for (; e < h;) {
			if (b[e].R !== p) 
				k = ki;
			r(1, i)
		}
}
function lq(a){
	for (var b = [], c = i, d = 0; d < a[s]; ++d) {
		var e = a[d];
		if (c && c.R === e.R && c.Bj === e.Bj && c.Jd === e.Le) 
			c = b[b[s] - 1] = new hq(c.R, c.Le, e.Jd, c.Bj);
		else {
			b[o](e);
			c = e
		}
	}
	return b
}
function rq(a,b){return a[0]-b[0]||b[1]-a[1]}
function bn(a){
	for (var b = [], c = undefined, d = 0; d < a[s]; ++d) {
		var e = a[d];
		c !== e.R && b[o](e.R);
		c = e.R
	}
	return b
}
var iq=/\+/g;
function pq(a){
	if (!a[s] || a[Zb](0) !== Qe) 
		return a;
	a = a[I](1, a[s] - 1)[w](iq, X);
	return oa(a)
}
function tq(a, b, c){
	var d = [];
	if (b > a) 
		for (var e = 0; e < c[s]; ++e) 
			d[o](new hq(c[e], a, b, 0));
	d[Xc]();
	return a = d
};
function uq(a, b, c){
	this.wU = b || 40;
	this.ZE = c || Infinity;
	this.Ch = a;
	m(this.Ch, '<table cellpadding=0 cellspacing=0 style="table-layout:fixed;width:100%"><tr><td></table>');
	this.JC = this.Ch[G];
	this.kj = this.JC[ud]("td")[0]
}
var vq="hidden";
uq[v].tE = function(){
	var a = xp(this.JC), b = l.max(this.ZE, this.wU), c = this.Ch[B];
	if (a > b) {
		jb(c, b + Oh);
		if (Sf) 
			hb(c, "-moz-scrollbars-vertical");
		else 
			if (T) {
				c.overflowX = vq;
				c.overflowY = "scroll";
				ya(this.JC[B], "auto");
				ya(c, "auto")
			}
			else 
				hb(c, "auto");
		wa(c, "relative")
	}
	else {
		jb(c, O);
		if (Sf) 
			hb(c, O);
		else 
			if (T) {
				c.overflowX = O;
				c.overflowY = O
			}
		wa(c, O)
	}
};
uq[v].gR=uq[v].tE;
function wq(a,b){a.ZE=b;a.tE()};
function xq(){V[E](this);this.pn={};this.kt=0;this.fC=j}
Q(xq,V);
qe(xq);
cb(xq[v],function(a){return a in this.pn});
function yq(a,b){return a.pn[b]||i}
Wa(xq[v],function(a, b){
	zq(this, g);
	try {
		for (var c in this.pn) {
			var d = this.pn[c];
			if ((b || !d.Bp) && a(d) === j) 
				break
		}
	}
	finally {
		zq(this, j)
	}
});
function Aq(a){var b=[];a[Sc](function(c){c.mf&&!c.Ob&&b[o](c.id)},g);return b}
function Bq(a,b,c){var d=yq(a,c);if(!(d[K]==b)){bb(d,b);a[A](new Cq([c]))}}
function Dq(a, b){
	var c = yq(a, b);
	c.Ob = !c.Ob;
	var d = jl();
	d.set(b + "/hidden", c.Ob ? Fg : Zn);
	c.Ob || d.set(b + "/off", Zn);
	if (b == "cCN3ZWF0aGVyQGdyb3VwLnYuY2FsZW5kYXIuZ29vZ2xlLmNvbQ") 
		if (c.Ob) {
			var e = d.O("weather", O);
			d.set("weather", O);
			d.set("weatherOld", e)
		}
		else {
			e = d.O("weatherOld", O);
			e = Eq(e);
			d.set("weather", e);
			d.set("weatherOld", O)
		}
	d.Kb();
	Fq(a, !c.Ob, b);
	Gq(a)
}
function Hq(a,b){b&&a[ed](b)&&yq(a,b).Ob&&Dq(a,b)}
function Iq(a, b, c, d){
	if (b && a[ed](b) && c != yq(a, b).mf) {
		c && Hq(a, b);
		Fq(a, c, b);
		if (!d) {
			d = jl();
			d.set(b + "/off", c ? Zn : Fg);
			d.Kb()
		}
		Jq();
		a[A](new Kq(b, c))
	}
}
function Fq(a, b, c){
	var d = yq(a, c);
	d.mf = !!b;
	if (b && !of(an(), c) && !d.Bp) {
		var e = ql();
		Lq(g, "AlterVisible");
		Mq([c], function(){
			e.Nc("sec_cal_load_server");
			Lq(j, "AlterVisible")
		}, function(){
			e.Nc("sec_cal_load_total")
		});
		Nq(c) || Gg([c]);
		Gq(a)
	}
	else 
		Oq()
}
function Pq(a, b){
	if (a.id == 