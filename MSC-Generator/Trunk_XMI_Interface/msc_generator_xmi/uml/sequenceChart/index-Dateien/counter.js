var sc_width = screen.width;		
var sc_referer = ""+document.referrer;
var sc_title = "";
var sc_url = "";
var sc_agent = navigator.appName+' '+navigator.appVersion;
var sc_base_dir = "";
var sc_error = 0;
var sc_http_url = "http";
var sc_link_back_start = "";
var sc_link_back_end = "";
var sc_security_code = "";
var sc_counter = 1;
var sc_link_back_start = "<a href=\"http://www.StatCounter.com\" target=\"_blank\">";
var sc_link_back_end = "<\/a>";

if(window.sc_https==1) {
		sc_doc_loc = ''+document.location;
		myRE = new RegExp("^https", "i")
		if(sc_doc_loc.match(myRE)) {
			sc_http_url = "https";
		}
}

if (window.sc_partition) sc_counter = sc_partition+1;
sc_base_dir = sc_http_url+"://c"+sc_counter+".statcounter.com/";  

if(window.sc_text) sc_base_dir += "text.php?"; else	sc_base_dir += "t.php?";

if(window.sc_project) {
	sc_base_dir += "sc_project="+sc_project;
}
else if(window.usr) {
	sc_base_dir += "usr="+usr;
}
else {
	sc_error = 1;
}

if(window.sc_remove_link) {
	sc_link_back_start = "";
	sc_link_back_end = "";
}

sc_date = new Date();
sc_time = sc_date.getTime();
sc_agent = sc_agent.toUpperCase();

sc_title = ""+document.title;
sc_url = ""+document.location;
sc_referer = sc_referer.substring(0, 150);
sc_title = sc_title.substring(0, 150);
sc_url = sc_url.substring(0, 150);
sc_referer = escape(sc_referer);
sc_title = escape(sc_title);
sc_url = escape(sc_url);

if (window.sc_security) sc_security_code = ""+escape(sc_security);

var sc_tracking_url = sc_base_dir+"&resolution="+sc_width+"&camefrom="+sc_referer+"&u="+sc_url+"&t="+sc_title+"&java=1&security="+sc_security_code+"&sc_random="+Math.random();

if(sc_error==1) {
		document.writeln("Code corrupted. Insert fresh copy.");
}
else if (window.sc_invisible==1) {
	sc_img = new Image();
	sc_img.src = sc_tracking_url;
}
else if (window.sc_text) {
	document.writeln('<scr'+'ipt language="JavaScript"'+' src='+sc_tracking_url+"&text="+sc_text+'></scr'+'ipt>');
}
else {
	document.writeln(sc_link_back_start+"<IMG SRC=\""+sc_tracking_url+"\" ALT=\"StatCounter - Free Web Tracker and Counter\" BORDER=\"0\">"+sc_link_back_end);
}

if(window.sc_click_stat) {
	if (document.getElementsByTagName) {
		var anchors = document.getElementsByTagName('a');
		for (var i=0;i<anchors.length;i++) {
			var anchor = anchors[i];
			if (anchor.getAttribute('href')) {
				anchor.onclick = function () { 
					var sc_req = sc_http_url+"://c"+sc_counter+".statcounter.com/click.html?sc_project="+sc_project+"&security="+sc_security_code+"&c="+escape(this);
					var sc_req_image = new Image();
					sc_req_image.src = sc_req;
					location.href = this;
					return false; 
				}
			}
		}
	}
}

