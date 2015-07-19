// Core JS library for oracle.com
// Created by: Vivek Mehrotra
//Update by Ashok Chava on 12 Oct 2006

function goWin(url, x, w, h, scroll) {
 if (!x || x=="") x=1;
 if (x==1) top.location="./"+url
 else if (x==2) window.open(url,"smallWin","toolbar=0,location=0,directories=0,status=0,menubar=0,resizable=1,scrollbars="+scroll+",width="+w+",height="+h+",top=0,screenY=0,left=0,screenX=0")
 else if (x==3) window.open(url,"fullWin")
}
// eloggerF
var gUrl="http://www.oracle.com/webapps/elog/trackurl";
var baseUrl="http://"+location.hostname;
var fromUrl=escapeURL(document.URL);
var refUrl=escapeURL(document.referrer); 

function escapeURL(p_txt) {
 r1= /\&/gi;
 r2= / /gi;
 r3= /\+/gi;
 var t=p_txt;
 t=t.replace(r1,"%26");
 t=t.replace(r2,"%2B");
 t=t.replace(r3,"%2B");
 return t;
}
function trackURL(p_url, p_object_id, p_subobject_id) {
 var toUrl=escapeURL(p_url);
 var destUrl="";
 var srcUrl="";
 var trackbleUrl="";
 if (toUrl.indexOf("http")==-1) destUrl=baseUrl+toUrl;
 if (fromUrl.indexOf("http")==-1) srcUrl=baseUrl+fromUrl;
 trackbleUrl=gUrl+"?d="+destUrl+"&s="+srcUrl+"&di="+p_object_id ;
 return trackbleUrl;
}
function goURL(p_url, p_object_id, p_subobject_id) {
 location=trackURL(p_url,p_object_id,p_subobject_id);
}
function logURL(p_object_id, p_subobject_id ) {
 var destUrl="";
 var srcUrl="";
 var trackbleUrl="";
 if (fromUrl.indexOf("http")==-1) destUrl=baseUrl+fromUrl;
 if (refUrl.indexOf("http")==-1) srcUrl=baseUrl+refUrl;
 trackbleUrl=gUrl+"?d="+destUrl+"&s="+srcUrl+"&di="+p_object_id+"&a=image" ;
 document.write("<img src=\""+trackbleUrl+"\">");
}
// OTN leftnav
function dropdown(mySel)
{
 var myWin, mV;
 mV=mySel.options[mySel.selectedIndex].value;
 if(mV) {
  if(mySel.form.target) myWin=parent[mySel.form.target]; 
  else myWin=window;
  if (!myWin) return true;
  myWin.location=mV;
 }
 return false;
}
// viewlets
function isViewletCompliant()
{
 ans=true;
 version=Math.round(parseFloat(navigator.appVersion) * 1000);
 if (navigator.appName.substring(0,9)=="Microsoft")
  if(version<4000) ans=false;
 if (navigator.appName.substring(0,8)=="Netscape")
  if ((navigator.appVersion.indexOf("Mac")> 0)&&(version<5000)) ans=false;
   else if (version<4060) ans=false;
 plugins=navigator.plugins;
 if (!ans && plugins!=null)
  for(i=0;i!=plugins.length;i++)
   if((plugins[i].name.indexOf("Java Plug-in")>=0)&&(plugins[i].name.indexOf("1.0")<0)) ans=true;
 return ans;
}
function openViewlet(htmlFile,htmlWidth,htmlHeight)
{
 str = 'resizable=0,toolbar=0,menubar=0,scrollbars=0,status=0,location=0,directory=0,width=350,height=200';
 if(!isViewletCompliant())
  open("http://www.qarbon.com/warning/index.html",'Leelou',str);
 else
  window.open(htmlFile,'Leelou','width='+htmlWidth+',height='+htmlHeight+',top=10,left=20');
}

var USER = new getUserInfo();

function printWelcome()
{
  var loc= window.location.href;
  var tempURL= window.location.href;

  var temp = new Array();
  temp = tempURL.split('/');

  var tmp = '<span class="profile">';
  if ( USER.guid ){
	 if(temp[4] == "global" ){
		tmp += 'Welcome ' + USER.firstname + ' ( <a class="profile" href="javascript:sso_sign_out();">' +
			  'Sign Out'+ '<\/a> | <a class="profile" href="http://www.oracle.com/admin/account/index.html?'+temp[5]+ '">' + 'Account' + '<\/a> )';
	 }else{
		tmp += 'Welcome ' + USER.firstname + ' ( <a class="profile" href="javascript:sso_sign_out();">' +
			  'Sign Out'+ '<\/a> | <a class="profile" href="http://www.oracle.com/admin/account/index.html">' + 'Account' + '<\/a> )';
	 }	

  }else{
     if(temp[4] == "global" ){
    	tmp += '<a href="' + 'http://www.oracle.com/admin/account/index.html?'+temp[5]+ '">' + '(Sign In / Register for a free Oracle Web account)'+ '<\/a>';
  	 }else{
    	tmp += '<a href="' + 'http://www.oracle.com/admin/account/index.html">' + '(Sign In / Register for a free Oracle Web account)'+ '<\/a>';
	 }	
  }
  tmp += '<\/span>';
  document.write(tmp);
  document.close();
}


function printWelcomeOPN()
{
	var url = location.href;
     if (url.indexOf('html?loc' ) > -1  )
		{
		  var param = url.replace( /^[^=]+\=/, '' );
          loc = param;		 
        }
	else  loc= window.location.href;
	  loc= escape(loc)
  var tmp = '<span class="profile">';
  if ( USER.guid )
    tmp += 'Welcome ' + USER.firstname + ' ( <a class="profile" href="javascript:sso_sign_out();">' +
          'Sign Out'+ '<\/a> | <a class="profile" href="http://www.oracle.com/partners/admin/web_account.html?loc='+loc + '">' + 'Account' + '<\/a> )';
  else
    tmp += '<a href="' + 'http://www.oracle.com/partners/admin/web_account.html?loc='+loc + '">' + '(Sign In / Register for a free Oracle Web account)'+ '<\/a>';

  tmp += '<\/span>';
  document.write(tmp);
  document.close();
}



function DrawPrinterView()
{
  var printTemplate = '/ocom/ocom_item_templates/print';

  var Str = window.location.pathname;
  Str = Str.substring( 1 );
  Str = Str.substring( 0, Str.indexOf( '/' ) );
  if ( Str.length == 2 || Str.length == 5 || Str == 'global' ) printTemplate = '/ocom/ocom_item_templates/global/global_print';

  var Str = '<A href="javascript:location=location.pathname+\'?_template='+printTemplate+'\';" target=""><IMG ';
  Str += 'height=15 alt="'+strings.print_label+'" src="/admin/images/print_17x15.gif" width=17 border=0><\/A> <A class=navlink ';
  Str += 'href="javascript:location=location.pathname+\'?_template='+printTemplate+'\';" target="">'+strings.print_label+'<\/A> ';
  document.write( Str );
  document.close();
}

/*
function signout(url) {
  var exp = new Date();
  exp.setYear(70);
  var exp_str = "expires=" + exp.toGMTString() + "; domain=.oracle.com; path=/;";
  document.cookie = "ORA_UCM_VER=;" + exp_str;
  document.cookie = "ORA_UCM_INFO=;" + exp_str;
  document.cookie = "ORA_UCM_SRVC=;" + exp_str;
  top.location = url;
}
*/
function signout(url)
{

  //rUrl = window.location.href; 
  rUrl = escape(window.location.href); 
  window.location="http://profile.oracle.com/jsp/reg/signout.jsp?logouturl="+rUrl; //stage only
}
function getCookieData(label) {
  var labelLen = label.length
  var cLen = document.cookie.length
  var i = 0
  var cEnd
  while (i < cLen) {
    var j=i+labelLen;
    if (document.cookie.substring(i,j) == label) {
      cEnd=document.cookie.indexOf(";",j);
      if (cEnd==-1) {
      	cEnd=document.cookie.length;
      }
      j++;
      return unescape(document.cookie.substring(j,cEnd));
    }
    i++;
  }
  return "";
}
function getUserInfo() {
  var USER         = new Object();
  this.value_enc   = getCookieData("ORA_UCM_INFO");
  this.array       = this.value_enc.split("~");
  USER.version      = this.array[0];
  USER.guid         = this.array[1];
  USER.firstname    = this.array[2];
  USER.lastname     = this.array[3];
  USER.username     = this.array[4];
  USER.country      = this.array[5];
  USER.language     = this.array[6];
  USER.interest1    = this.array[7];
  USER.interest2    = this.array[8];
  USER.interest3    = this.array[9];
  USER.interest4    = this.array[10];
  USER.ascii        = this.array[11];	
  USER.email        = this.username;
  USER.companyname  = null;
  USER.title        = null;
  USER.characterset = null;
  USER.interest5    = null;
  return USER;
}

// Start of functions used by new Ocom search
function trim(value)
{
  s = new String(value);
  if (value != null) {
    var beginIndex = -1;
    var endIndex   = s.length;

    for (var i = 0; i < s.length; i++)
    {
      if (s.charAt(i) != " ") {
        beginIndex = i;
        break;
      }
    }
    if (beginIndex == -1) return "";

    for (var j = s.length -1; j > beginIndex; j--) {
      if (s.charAt(j) != " ") {
        endIndex = j;
        break;
      }
    }
    if (endIndex != s.length) return s.substring(beginIndex, endIndex);
    else return s.charAt(beginIndex);
  }
  return value;
}

// Special Characters validation
// Added isSplCharsExist() on 25th April by Girish
var splCharsInKeyword;
function isSplCharsExist(value) {
    splCharsInKeyword = '';
     var iChars = "!#$%^*()+=[]\\;/{}|:<>?";
        for (var i = 0; i < value.length; i++) {
                if (iChars.indexOf(value.charAt(i)) != -1) {   
                idx = iChars.indexOf(value.charAt(i));
                splCharsInKeyword +=  iChars.charAt(idx) + ' ';

               }
     }
     
     if (splCharsInKeyword == '' || trim(splCharsInKeyword).length == 0 ) {
        return false;
      } 
     else {
        return true;
     }
}

// Serach validation Global value
// Modified isNotNull() on 25th April by Girish
//var isUserInput = false ;
function isNotNull(value)
{

	  if (value == null || trim(value).length == 0  || value == "search site" || value =="Search OPN" )
	  {
	    alert('You did not enter a search term.  Please try again.');
	    document.searchForm.keyword.value='';
	    //isUserInput = true;
	    document.searchForm.keyword.focus();
	    return false;
	  }
	  else if (isSplCharsExist(value)) {
	  
		   if (trim(splCharsInKeyword).length > 1 ) {
		     splCharsInKeyword = 'Special characters ' + splCharsInKeyword + ' are ';
		   }
		   else {
		     splCharsInKeyword = 'Special character ' + splCharsInKeyword + ' is ';
		   }
		   
	   alert ( splCharsInKeyword +"not allowed.\n");
	   document.searchForm.keyword.focus();
	   return false;
	  }
	 else
	 return true;
}


function checkSearch( value )
{
  if ( document.searchForm && document.searchForm.datasetId && typeof( langDataSetId ) != 'undefined' && langDataSetId )
  {
    document.searchForm.datasetId.value = langDataSetId;
  }

  if ( value == null || trim(value).length == 0 )
  {
    alert('Please enter the keyword(s) to search for');
    return false;
  }
  else 
  {
    if ( document.searchForm ) document.searchForm.submit();
    return true;
  }
}

function checkGlobalSearch( value )
{
  return checkSearch( value );
}


// Start of OSES JS Form Check for Broadband - Ashish Patel, MAR-24-2006
//var OTNDocsNodeId= "1_374" ;
//var OTNDocsFId= "-1" ;
function setFormValues(form,groupname) {
if(groupname == "Video and Multimedia")
{
form.showSimilarDoc.value = "false";
}else{
form.showSimilarDoc.value = "true";
}
//The following code can be used when a node level search needs to be done. Not used now
//if(groupname == "OTNDocsNode")
//{
// form.nodeid.value = OTNDocsNodeId;
// form.fid.value = OTNDocsFId;
//}
}


function sso_sign_out() 
{ 
    //rUrl = window.location.href; 
    
    rUrl = escape(window.location.href); 
		
	if (    ( rUrl.indexOf('http://oraclepartnernetwork.oracle.com/portal/' ) >-1 )  ||  (  rUrl.indexOf('http://www.oracle.com/partners' ) > -1 )  )  		
	  rUrl = "http://oraclepartnernetwork.oracle.com/";
	window.location="http://profile.oracle.com/jsp/reg/signout.jsp?logouturl="+rUrl; //stage only
} 


// Start of Live Edit Code - Dom Lindars, 28-JUL-2004
function GetCookie(sName)
{
  var aCookie = document.cookie.split("; ");
  for (var i=0; i < aCookie.length; i++)
  {
    var aCrumb = aCookie[i].split("=");
    if (sName == aCrumb[0]) return unescape(aCrumb[1]);
  }
  return null;
}

function LiveEditStatus()
{
  var Str = GetCookie( 'WOCPortalLiveEdit' );
  if ( Str == 'Enabled' || Str == 'Disabled' ) return Str;
  else return 'Not installed';
}

var LiveEdit = true;

function DrawLiveEditToolbar()
{
  if ( typeof( USER ) != 'undefined' && USER && USER.guid && USER.username && USER.username.indexOf( '@oracle.com' ) > -1 )
  {
    var Status = LiveEditStatus();

    if ( LiveEdit && Status == 'Enabled' )
    {
      var path = location.pathname
      path = path.substring(1,path.lastIndexOf("/") + 1);
  
      if ( ( location.host == 'www-portal-stage.oracle.com' || location.host == 'www.oracle.com' ) && 
           path.indexOf( 'wocportal' ) == -1 && path.indexOf( 'pls/' ) == -1 )
      {
        document.write( '<script language=Javascript src="/admin/jscripts/live_edit/live_edit.js"><\/script>' );
        document.close;
      }
    }
  }
}

// isEmployee() function added by Srinivas Kasam on 29-Mar-2005

function isEmployee()
{
  if ( typeof( USER ) != 'undefined' && USER && USER.guid && USER.username && USER.username.indexOf( '@oracle.com' ) > -1 )
  {
	  return true;
  }
  else 
  {
    return false;
  }
}

// isPartner() function added by Srinivas Kasam on 01-Apr-2005
// This function checks if a user is an ACTIVE member of OPN

function isPartner()
{
  
  var ORA_UCM_SRVC  = new private_ORA_UCM_SRVC(); // private_ORA_UCM_SRVC is defined in lib.js
  var SrvcVal = getCookieData("ORA_UCM_SRVC");
  var StartPosofExpdtSE1;
  var EndPosofExpdtSE1;
  var ExpDTString;
  var FirstHypen;
  var SecondHypen;
  var DatePortion;
  var MonthPortionString;
  var MonthPortion = 1;
  var YearPortion;
  var CurrentDate;
  var CurrentDateMilliSec;
  var ExpiryDate;
  var ExpiryDateMilliSec;

  // Check if SRVC cookie is NULL or OPN service exists or not
  if ( ORA_UCM_SRVC == null || ORA_UCM_SRVC.services.indexOf("/OPN/") == -1 )
  {
	  return false;
  }
  else 
  {

    // Use EXTRA value of OPN service cookie to find out OPN Membership Expiry date

    // Logic to extract EXPIRY DATE from the service cookie -- delimiter 'SE1:'

    StartPosofExpdtSE1 =  SrvcVal.indexOf("SE1:");
    StartPosofExpdtSE1 =  SrvcVal.indexOf("SE1:", StartPosofExpdtSE1 + 1);
    StartPosofExpdtSE1 =  SrvcVal.indexOf("SE1:", StartPosofExpdtSE1 + 1);
    EndPosofExpdtSE1   =  SrvcVal.indexOf("SE1:", StartPosofExpdtSE1 + 1);

    ExpDTString = SrvcVal.substr(StartPosofExpdtSE1 + 4, EndPosofExpdtSE1 - StartPosofExpdtSE1 - 4);

    // Logic to extract Date, Month, Year portions from EXPIRY DATE obtained above -- delimiter is '-'
    FirstHypen = ExpDTString.indexOf("-");
    SecondHypen = ExpDTString.indexOf("-", FirstHypen + 1);

	DatePortion = parseInt(ExpDTString.substr(0, FirstHypen), 10);

    MonthPortionString = ExpDTString.substr(FirstHypen + 1, SecondHypen - FirstHypen - 1);

    switch (MonthPortionString.toUpperCase()) 
    {
      case 'JAN': MonthPortion=1; break
      case 'FEB': MonthPortion=2; break
      case 'MAR': MonthPortion=3; break
      case 'APR': MonthPortion=4; break
      case 'MAY': MonthPortion=5; break
      case 'JUN': MonthPortion=6; break
      case 'JUL': MonthPortion=7; break
      case 'AUG': MonthPortion=8; break
      case 'SEP': MonthPortion=9; break
      case 'OCT': MonthPortion=10; break
      case 'NOV': MonthPortion=11; break
      case 'DEC': MonthPortion=12; break
      default: MonthPortion=1;
    }

    YearPortion = parseInt(ExpDTString.substr(SecondHypen + 1 ), 10);
    if(YearPortion>=90 && YearPortion<=99)
       YearPortion = YearPortion+1900;
    else
      YearPortion = YearPortion+2000;

    // Construct DATE object using the date, month, year portions obtained above also get the number of millisec since EPOCH
	ExpiryDate = new Date(YearPortion, MonthPortion, DatePortion );
    ExpiryDateMilliSec = Date.parse(ExpiryDate);

	// Get current date from client PC and also get the number of millisec since EPOCH
	CurrentDate = new Date();
    CurrentDateMilliSec = Date.parse(CurrentDate);


    // Check if Expiry Date IS LESS THAN Current Date
	if(ExpiryDateMilliSec < CurrentDateMilliSec) 
      return false;
    else
      return true;
 
    }
  }

DrawLiveEditToolbar();
// End of Live Edit Code 

// Peoplesoft Pop up 
function pop(url, wide, tall, xtra) {
	if (xtra == '' || xtra == null) xtra='scrollbars=yes,resizable=yes';
	window.open(url, 'palf', 'width='+wide+',height='+tall+','+xtra);
}
// Peoplesoft Pop up ends

//Functions specific to broadband
//for ebn show the Ondemand window and show Quote window
function showOndemand(showid, cmsid, regsite, bitrate) {
   showLiveViewer(showid,cmsid);
/*
  var v_regsite;
  var v_bitrate;
  if (!bitrate) v_bitrate = 'L150'; else v_bitrate = bitrate;
  if (!regsite) v_regsite = ''; else v_regsite = regsite;
	mywin = SpecialWin("onDemandWin", "popup.on_demand", showid, cmsid, v_regsite, v_bitrate, "N", 405, 675);
*/
}
function showOndemand2(showid, cmsid, src, act, bitrate) {
	showLiveViewer(showid,cmsid);
/*
  var v_bitrate;
  if (!bitrate) v_bitrate = 'L150'; else v_bitrate = bitrate;
	if(src && act) {
	  getUCMCookies();
  	if (!isUCMRegistered()) {
    	if ( confirm("This functionality is available to registered users only.\n\nWould you like to register or sign in?\n\n") ) {
      	top.location = auth_host + "/jsp/reg/register.jsp?src="+src+"&Act="+act+"&nextURL=" + escape(top.location.href);
	    }
  	  return;
	  }
	}
	mywin = SpecialWin("onDemandWin", "popup.on_demand", showid, cmsid, '', v_bitrate, "N", 405, 675);
	*/
}
function showISeminar(showid, cmsid, regsite, bitrate) {
  if(parseInt(showid)<=1546274) {
    var v_regsite;
    var v_bitrate;
    if (!bitrate) v_bitrate = 'L150'; else v_bitrate = bitrate;
    if (!regsite) v_regsite = ''; else v_regsite = regsite;
  	mywin = SpecialWin("ISeminarWin", "iseminar_viewer.ondemand", showid, cmsid, v_regsite, v_bitrate, "Y", 635, 450);
  } else {
    showLiveViewer(showid,cmsid,1180587,6);
  }
}

function showLiveViewer(showid,cmsid,src,act) {
    if(src && act) {
      getUCMCookies();
      if (!isUCMRegistered()) {
        if ( confirm("This functionality is available to registered users only.\n\nWould you like to register or sign in?\n\n") ) {
          top.location = auth_host + "/jsp/reg/register.jsp?src="+src+"&Act="+act+"&nextURL=" + escape(top.location.href);
        }
        return;
      }
    }

    var vWidth = 800;
    var vHeight = 360;
    var vTop = Math.ceil((screen.availHeight - vHeight)/2) - 25;
    var vLeft = Math.ceil((screen.availWidth - vWidth)/2);

    if(screen.width <= 800) {
      if(screen.width < 700) {
        alert("800x600 screen resolution or higher is recommended.");
      }
      vTop = 0;
      vLeft = 0;
      vWidth = screen.availWidth - 10;
      vHeight = screen.availHeight-46;
    }
    url = "http://www.oracle.com/pls/ebn/live_viewer.main?p_shows_id=" + showid + "&p_referred=" + cmsid;
    window.open(url,"liveWin","top="+vTop+",left="+vLeft+",width="+vWidth+",height="+vHeight+",status=yes,resizable=no");
}

function ISLive(showid, cmsid, regsite, bitrate) {
  var v_regsite;
  var v_bitrate;
  if (!bitrate) v_bitrate = 'L150'; else v_bitrate = bitrate;
  if (!regsite) v_regsite = ''; else v_regsite = regsite;
	mywin = SpecialWin("ISLiveWin", "iseminar_viewer.live", showid, cmsid, v_regsite, v_bitrate, "Y", 635, 600);
}

function SpecialWin(name, purl, showid, cmsid, regsite, bitrate, reg, w, h) {
	mywin=window.open('http://www.oracle.com/pls/ebn/' + purl + '?p_shows_id='+ showid + '&p_regreq=' + reg  + '&p_referred=' + cmsid + '&p_regsite=' + regsite + '&p_win_size=' + bitrate, name,'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=0,resizable=no,width=' + w + ',height=' + h );
	return mywin;
}

function showDemo(id,ref,vWidth,vHeight)
{
    if(!vHeight) vHeight = 600;
    if(!vWidth) vWidth = 800;
    var vTop = Math.ceil((screen.availHeight - vHeight)/2) - 25;
    var vLeft = Math.ceil((screen.availWidth - vWidth)/2);
    if(screen.width <= 800) {
      if(screen.width < 700) {
        alert("800x600 screen resolution or higher is recommended.");
      }
      vTop = 0;
      vLeft = 0;
      vWidth = screen.availWidth - 10;
      vHeight = screen.availHeight-46;
    }
  window.open("http://www.oracle.com/pls/ebn/swf_viewer.load?p_shows_id="+id+"&p_referred="+ref+"&p_width="+vWidth+"&p_height="+vHeight,"demoWin","width="+vWidth+",height="+vHeight+",resizable=0,top="+vTop+",left="+vLeft);
}

function Shwing(login, page, name, popup_width, popup_height) {
	var test = login.indexOf('%');
	if (test < 0) login = escape(login);
	page = page + '&args=' + login;
	window.open(page, name, 'toolbar=no,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=no,scrollbars=yes,width=' + popup_width + ',height=' + popup_height);
}

//This is an additional function to handle certain Broadband shows which work only on Windows Media Player
function showWmViewer(showid,cmsid,src,act) {
    if(src && act) {
      getUCMCookies();
      if (!isUCMRegistered()) {
        if ( confirm("This functionality is available to registered users only.\n\nWould you like to register or sign in?\n\n") ) {
          top.location = auth_host + "/jsp/reg/register.jsp?src="+src+"&Act="+act+"&nextURL=" + escape(top.location.href);
        }
        return;
      }
    }
    var vWidth = 800;
    var vHeight = 360;
    var vTop = Math.ceil((screen.availHeight - vHeight)/2) - 25;
    var vLeft = Math.ceil((screen.availWidth - vWidth)/2);

    if(screen.width <= 800) {
      if(screen.width < 700) {
        alert("800x600 screen resolution or higher is recommended.");
      }
      vTop = 0;
      vLeft = 0;
      vWidth = screen.availWidth - 10;
      vHeight = screen.availHeight-46;
    }
    url = "http://www.oracle.com/pls/ebn/wm_viewer.main?p_shows_id=" + showid; 
    window.open(url,"WmvWin","top="+vTop+",left="+vLeft+",width="+vWidth+",height="+vHeight+",status=yes,resizable=no");
}

//Functions specific to broadband ends
//Added for net Call by Ashok Chava
function getArg(arg_name, str) {
	var value = "", tmpstr = "";
	if (!str) str = location.search.substring(1);
	if (!str) return value;
	else {
		var tmparray = str.split("&");
		for (i=0; i<tmparray.length; i++) {
			tmpstr = tmparray[i].toUpperCase();
			if (tmpstr.indexOf(arg_name.toUpperCase() + "=") != -1) {
				var tmp2array = tmparray[i].split("=");
				value = tmp2array[1];
			}
		}
	}
	return value;
}
function startNewCallback(ichannel,tmp) {

  var netcall_url = "http://" + location.hostname + "/admin/netcall/";
  
  var w = 565;
  var h = 515;

  var codes = new Array();
  codes[0] = [ "Oracle.com", "0i2wzK12842", "321884", "0", "0", "1", "newlauncher.html", "newthankyou.html", "nhthankyou.html", "newerror.html", "5:00 - 17:00 PST"  ];
  codes[1] = [ "Oracle Education", "2WcKOh12631", "322065", "0", "0", "1", "launcher.html", "thankyou.html","nhthankyou.html", "error.html", "5:00am - 5:00pm PST"  ];
  codes[2] = [ "Oracle Brazil", "QoEOxb13081", "344401", "0", "0", "55", "launcher-br.html", "thankyou-br.html","nhthankyou.html", "error-br.html", "9h00 - 18h00"  ];
  codes[3] = [ "Oracle Consulting", "invalid", "379366", "0", "0", "1", "launcher.html", "thankyou.html","nhthankyou.html", "error.html", " "  ];
  codes[4] = [ "Oracle Netherlands", "8StUfs2022", "365383", "0", "0", "31", "launcher.html", "thankyou.html","nhthankyou.html", "error.html", " "  ];
  codes[5] = [ "Oracle UK", "EIKzPM13381", "365383", "0", "0", "44", "launcher.html", "thankyou.html","nhthankyou.html", "error.html", "9:00am - 6:00pm"  ];
  codes[6] = [ "Oracle France", "Osyzdu3268", "365383", "0", "0", "33", "launcher-fr.html", "thankyou-fr.html","nhthankyou.html", "error-fr.html", "9h à 18h CET"  ];
  codes[7] = [ "Oracle Portugal", "okWd3e3309", "365383", "0", "0", "351", "launcher.html", "thankyou.html","nhthankyou.html", "error.html", "9:00am - 6:00pm"  ];
  codes[8] = [ "Oracle Spain", "1M4DJm3310", "365383", "0", "0", "34", "launcher.html", "thankyou.html","nhthankyou.html", "error.html", " "  ];

	for (var i = 0; i < codes.length; i++) {
		if (ichannel == codes[i][1]) {
		
      // build url
     
      var url = netcall_url  + codes[i][6]+
        "?memberid=" + codes[i][2] +
        "&country=" + codes[i][5] +
        "&responseurl=" + netcall_url  + codes[i][7] +
        "&errorurl=" + netcall_url  + codes[i][9] +
        "&timezone=" + escape(codes[i][10]) +
        "&ichannel=" + escape(codes[i][1])+
        "&nhresponseurl1=" + netcall_url  + codes[i][8] ;
      
      // adjust window size if necessary
      width = ((codes[i][3] == 0) ? w : codes[i][3]);
      height = ((codes[i][4] == 0) ? h : codes[i][4]);

      win = window.open(url,'netcall',"width=" + width + ",height="+ height +",scrollbars=yes,resizable=yes,menubar=no,location=no");
      win.opener = self;
			break;
		}
	}
}
