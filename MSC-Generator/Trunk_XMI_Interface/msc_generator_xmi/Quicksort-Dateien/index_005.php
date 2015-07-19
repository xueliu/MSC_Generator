/* generated javascript */
var skin = 'monobook';
var stylepath = '/skins-1.5';

/* MediaWiki:Common.js */
/* Jedes JavaScript hier wird für alle Benutzer für jede Seite geladen. */

 // =============================================================
 // BEGIN Configuration for "star" logo in front of interwiki links to Featured Articles
 
 /** set to false in Special:Mypage/monobook.js to switch off this "feature" */
 var linkFA_enabled  = true;
 
 /** description that is displayed when cursor hovers above FA interwiki links */
 var linkFA_description = "Dieser Artikel wurde als exzellent bewertet.";
 
 // linkFA_bullet and linkFA_style werden nur für cologneblue, nostalgia and standard verwendet,
 // für monobook und simple siehe [[MediaWiki:Common.css]]
 
 /** image to use instead of the standard bullet (for cologneblue, nostalgia and standard */
 var linkFA_bullet = "http://upload.wikimedia.org/wikipedia/commons/d/d0/Monobook-bullet-star-transparent.png";
 
 /** style to use for the linkFA_bullet img */
 var linkFA_style = "margin-right: 0.2em;";
 
 /** 
 * star logo for featured articles in other languages,
 * see Template:Link_FA and MediaWiki:Common.css
 */
 function linkFA() {
     // early exit when disabled
     if (!linkFA_enabled) return;
     
     // skins need to be treated differently
     if (skin == "monobook" || skin == "simple") {
         newer();
     } 
     else if (skin == "cologneblue" || skin == "nostalgia" || skin == "standard") {
         older();
     } 
     
     /** skin == "monobook" || skin == "simple" */
     function newer() {
         // links are to replaced in p-lang only
         var pLang = document.getElementById("p-lang");
         if (!pLang) return;
         var lis = pLang.getElementsByTagName("li");
         for (var i = 0; i < lis.length; i++) {
             var li = lis[i];
             // only links with a corresponding Link_FA template are interesting
             if (!document.getElementById(li.className + "-fa"))   continue;
             // additional class so the template can be hidden with CSS
             li.className += " FA";
             // change title
             li.title = linkFA_description;
         }
     }
     
     /** skin == "cologneblue" || skin == "nostalgia" || skin == "standard" */
     function older() {
         // these root elements can contain FA-links
         var rootIds = new Array("topbar", "footer");
         for (var i=0; i<rootIds.length; i++) {
             var rootId  = rootIds[i];
             var root    = document.getElementById(rootId);
             if (!root)  continue;
             
             // if the root exists, try to decorate all the links within
             var links   = root.getElementsByTagName("a");
             for (var j=0; j<links.length; j++) {
                 var link    = links[j];
                 decorate(link);
             }
         }
     }
     
     /** id necessary, modify a link to show the FA-star (older) */
     function decorate(link) {
         // exit if not a FA-link
         var lang    = link.title.split(":")[0]; // not precise enough
         var fa      = document.getElementById("interwiki-" + lang + "-fa");
         if (!fa)    return;
         // possible problem owing the standard skin: "Link FA" template is transcluded with a non-interwiki parameter, for example "Special"
         // result: links to special pages in the topbar and/or footer might also be marked as a Featured Article
         
         // build an image-node for the FA-star
         var img = document.createElement("img");
         img.setAttribute("src",     linkFA_bullet);
         img.setAttribute("alt",     linkFA_description);
         img.setAttribute("style",   linkFA_style);
         
         // decorate the link with the image
         link.appendChild(img);
         link.appendChild(link.removeChild(link.firstChild));
         link.setAttribute("title", linkFA_description);
     }
 }
 // aOnloadFunctions[aOnloadFunctions.length] = linkFA;
 addOnloadHook(linkFA);
 
 // END Configuration for "star" logo in front of interwiki links to Featured Articles
 // ============================================================

 //***********************************************************************
 /** "Technical restrictions" title fix *****************************************
  *
  *  Description:
  *  Maintainers: [[:en:User:Interiot|User:Interiot]], [[:en:User:Mets501|User:Mets501]]
  *  adjusted to deWP by [[:de:User:CyRoXX|User:CyRoXX]]
  */
 
 // For pages that have something like Template:Lowercase, replace the title, but only if it is cut-and-pasteable as a valid wikilink.
 //	(for instance [[iPod]]'s title is updated.  <nowiki>But [[C#]] is not an equivalent wikilink, so [[C Sharp]] doesn't have its main title changed)</nowiki>
 //
 // The function looks for a banner like this: <nowiki>
 // <div id="RealTitleBanner">    <!-- div that gets hidden -->
 //   <span id="RealTitle">title</span>
 // </div>
 // </nowiki>An element with id=DisableRealTitle disables the function.
 var disableRealTitle = 0;		// users can disable this by making this true from their monobook.js
 editprefix = "Bearbeiten von ";
 
 addOnloadHook(function() {
 	try {
 		var realTitleBanner = document.getElementById("Vorlage_Korrekter_Titel");
 		if (realTitleBanner && !document.getElementById("DisableRealTitle") && !disableRealTitle) {
 			var realTitle = document.getElementById("Korrekter_Titel");
 			if (realTitle) {
 				var realTitleHTML = realTitle.innerHTML;
 				realTitleText = pickUpText(realTitle);
 
 				var isPasteable = 0;
 				//var containsHTML = /</.test(realTitleHTML);	// contains ANY HTML
 				var containsTooMuchHTML = /</.test( realTitleHTML.replace(/<\/?(sub|sup|small|big)>/gi, "") ); // contains HTML that will be ignored when cut-n-pasted as a wikilink
 				// calculate whether the title is pasteable
 				var verifyTitle = realTitleText.replace(/^ +/, "");		// trim left spaces
 				verifyTitle = verifyTitle.charAt(0).toUpperCase() + verifyTitle.substring(1, verifyTitle.length);	// uppercase first character
 
 				// if the namespace prefix is there, remove it on our verification copy.  If it isn't there, add it to the original realValue copy.
 				if (wgNamespaceNumber != 0) {
 					if (wgCanonicalNamespace == verifyTitle.substr(0, wgCanonicalNamespace.length).replace(/ /g, "_") && verifyTitle.charAt(wgCanonicalNamespace.length) == ":") {
 						verifyTitle = verifyTitle.substr(wgCanonicalNamespace.length + 1);
 					} else {
 						realTitleText = wgCanonicalNamespace.replace(/_/g, " ") + ":" + realTitleText;
 						realTitleHTML = wgCanonicalNamespace.replace(/_/g, " ") + ":" + realTitleHTML;
 					}
 				}
 
 				// verify whether wgTitle matches
 				verifyTitle = verifyTitle.replace(/^ +/, "").replace(/ +$/, "");		// trim left and right spaces
 				verifyTitle = verifyTitle.replace(/_/g, " ");		// underscores to spaces
 				verifyTitle = verifyTitle.charAt(0).toUpperCase() + verifyTitle.substring(1, verifyTitle.length);	// uppercase first character
 				isPasteable = (verifyTitle == wgTitle);
 				
 				// replace the English canonical Namespaces by the German Namespaces
 				var enNS = new Array("Media", "Special", "Talk", "User", "User talk", "Project", "Project talk", "Image", "Image talk", "MediaWiki", "MediaWiki talk", "Template", "Template talk", "Help", "Help talk", "Category", "Category talk", "Portal", "Portal talk");
 				var deNS = new Array("Media", "Spezial", "Diskussion", "Benutzer", "Benutzer Diskussion", "Wikipedia", "Wikipedia Diskussion", "Bild", "Bild Diskussion", "MediaWiki", "MediaWiki Diskussion", "Vorlage", "Vorlage Diskussion", "Hilfe", "Hilfe Diskussion", "Kategorie", "Kategorie Diskussion", "Portal", "Portal Diskussion");
 				
 				for (var i = 0; i <= enNS.length - 1; i++) {
 				    //alert(enNS[i] + "-" + deNS[i]);
 				    var NSregex = new RegExp("^" + enNS[i] + ":");
 				    realTitleText = realTitleText.replace(NSregex, deNS[i] + ":");
 				    realTitleHTML = realTitleHTML.replace(NSregex, deNS[i] + ":");
 				}
 
 				// Add the 'editprefix' to the titles, if wgAction is 'edit'
 				if (wgAction == 'edit') {
 				    realTitleText = editprefix + realTitleText;
                    realTitleHTML = editprefix + realTitleHTML;
 				}
 				
 				var h1 = document.getElementsByTagName("h1")[0];
 				if (h1 && isPasteable) {
 					h1.innerHTML = containsTooMuchHTML ? realTitleText : realTitleHTML;
 					if (!containsTooMuchHTML)
 						realTitleBanner.style.display = "none";
 				}
 				document.title = realTitleText + " - Wikipedia";
 			}
 		}
 	} catch (e) {
 		/* Something went wrong. */
 	}
 });

 
 
 // similar to innerHTML, but only returns the text portions of the insides, excludes HTML
 function pickUpText(aParentElement) {
   var str = "";
 
   function pickUpTextInternal(aElement) {
     var child = aElement.firstChild;
     while (child) {
       if (child.nodeType == 1)		// ELEMENT_NODE 
         pickUpTextInternal(child);
       else if (child.nodeType == 3)	// TEXT_NODE
         str += child.nodeValue;
 
       child = child.nextSibling;
     }
   }
 
   pickUpTextInternal(aParentElement);
 
   return str;
 }
 //********Ende erzwungener kleiner Anfangsbuchstabe********************


 //********Fügt einen Link "Alle Sprachen" auf der Hauptseite unter die Sprachverweise hinzu ********************
 function mainPageAppendCompleteListLink() {
     try {
         var node = document.getElementById( "p-lang" )
                            .getElementsByTagName('div')[0]
                            .getElementsByTagName('ul')[0];
 
         var aNode = document.createElement( 'a' );
         var liNode = document.createElement( 'li' );
 
         aNode.appendChild( document.createTextNode( 'Alle Sprachen' ) );
         aNode.setAttribute( 'href' , 'http://de.wikipedia.org/wiki/Wikipedia:Sprachen' );
         liNode.appendChild( aNode );
         liNode.className = 'interwiki-completelist';
         node.appendChild( liNode );
      } catch(e) {
        // lets just ignore what's happened
        return;
     }
 }
  
 if ( wgTitle == 'Hauptseite' && wgNamespaceNumber == 0 ) {
        addOnloadHook( mainPageAppendCompleteListLink );
 }
 //********Fügt einen Link "Alle Sprachen" auf der Hauptseite unter die Sprachverweise hinzu ********************



 //********Verändert die Tabellensortierfunktion so, dass auch deutsche Tausenderpunkt und Dezimalkommata gehen ********************
 //Orginal aus sv.wikipedia.org
 function ts_parseFloat(num) {
       if (!num) return 0;
       num = num.replace(/\./g, "");
       num = num.replace(/,/, ".");
       num = parseFloat(num);
       return (isNaN(num) ? 0 : num);
 }
 //********Ende Tabellensortierfunktionhack ********************

 /*
  * Zwingt IPs zuerst die Vorschau zu benutzen, bevor sie speichern können.
  * Copyright Marc Mongenet, 2006 aus frwp
  */
 function forcePreview() {
  if (wgUserName != null || wgAction != "edit") return;
  saveButton = document.getElementById("wpSave");
  if (!saveButton) return;
  saveButton.disabled = true;
  saveButton.value = "Seite speichern (Bitte erst die Vorschau benutzen)";
  saveButton.style.fontWeight = "normal";
  document.getElementById("wpPreview").style.fontWeight = "bold";
 }
 addOnloadHook(forcePreview);
 
 /* Ende von forcePreview</source>


 /*
  *Fügt der Suche weitere Suchengines hinzu (kopiert aus eswp)
  *
  */

 document.write('<script type="text/javascript" src="' 
 + '/w/index.php?title=MediaWiki:SpezialSuche.js'
 + '&action=raw&ctype=text/javascript&dontcountme=s&smaxage=3600"></script>');


/** includePage ************
 * force the loading of another JavaScript file (Kopie von [[Commons:Common.js]])
 *
 * Local Maintainer: [[Commons:User:Dschwen]]
 */

function includePage( name )
{
 document.write('<script type="text/javascript" src="' + wgScript + '?title='
  + name 
  + '&action=raw&ctype=text/javascript"><\/script>' 
 );
}

function PngFix()
{
    try
    {
        if (!document.body.filters)
        {
            window.PngFixDisabled = true
        }
    }
    catch (e)
    {
        window.PngFixDisabled = true
    }
    if (!window.PngFixDisabled)
    {
        var documentImages = document.images
        var documentCreateElement = document.createElement
        var funcEncodeURI = encodeURI
 
        for (var i = 0; i < documentImages.length;)
        {
            var img = documentImages[i]
            var imgSrc = img.src
 
            if (imgSrc.substr(imgSrc.length - 3).toLowerCase() == "png" && !img.onclick)
            {
                if (img.useMap)
                {
                    img.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + encodeURI(imgSrc) + "')"
                    img.src = "http://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif"
                    i++
                }
                else
                {
                    var outerSpan = documentCreateElement("span")
                    var innerSpan = documentCreateElement("span")
                    var outerSpanStyle = outerSpan.style
                    var innerSpanStyle = innerSpan.style
                    var imgCurrentStyle = img.currentStyle
 
                    outerSpan.id = img.id
                    outerSpan.title = img.title
                    outerSpan.className = img.className
                    outerSpanStyle.backgroundImage = imgCurrentStyle.backgroundImage
                    outerSpanStyle.borderWidth = imgCurrentStyle.borderWidth
                    outerSpanStyle.borderStyle = imgCurrentStyle.borderStyle
                    outerSpanStyle.borderColor = imgCurrentStyle.borderColor
                    outerSpanStyle.display = "inline-block"
                    outerSpanStyle.fontSize = "0"
                    outerSpanStyle.verticalAlign = "middle"
                    if (img.parentElement.href) outerSpanStyle.cursor = "hand"
 
                    innerSpanStyle.width = "1px"
                    innerSpanStyle.height = "1px"
                    innerSpanStyle.display = "inline-block"
                    innerSpanStyle.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + funcEncodeURI(imgSrc) + "')"
 
                    outerSpan.appendChild(innerSpan)
                    img.parentNode.replaceChild(outerSpan, img)
                }
            }
            else
            {
                i++
            }
        }
    }
}
 
if (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.substr(22, 1) == "6")
{
    window.attachEvent("onload", PngFix)
}

(function() { 
	if (document.cookie.indexOf("hidesnmessage=1") == -1) return;
	var d = new Date(); d.setTime(d.getTime()+(64*24*60*60*1000)); 
	document.cookie = "hidesnmessage=1; expires=" + d.toGMTString() + "; path=/"; 
})();

/* MediaWiki:Monobook.js (deprecated; migrate to Common.js!) */
 // ============================================================
 // BEGIN Externhinweis
 // NEEDS Enable multiple onload functions
 
 /*
 function externHinweis() {
    if (
       (document.getElementById("pt-login")) &&  // ob der Benutzer NICHT angemeldet ist
       (document.getElementById("ca-edit")) &&   // ob die seite nicht geschützt ist
       (!document.getElementById("ca-nstab-user")) &&   // ob die seite keine benutzerseite ist
       (document.referrer != "") &&             // ob der referrer nicht leer ist
       (document.referrer.search(/wikipedia\.org/) == -1) // ob der Referrer NICHT wikipedia.org enthält
       )
    {
        var externHinweis = document.createElement("div");
        externHinweis.setAttribute('id','externHinweis');
            // Hier kann der Text verändert werden.
            // Bitte keine einfachen Anführungsstriche im Text verwenden!
            // Wikisyntax funktioniert nicht!
        externHinweis.innerHTML = '<a href="/wiki/Wikipedia:Willkommen" title="Wikipedia:Willkommen">Korrigiere Fehler oder erweitere diesen Artikel!</</a>';
       document.getElementById("content").appendChild(externHinweis);
    }
 }
 
 addOnloadHook(externHinweis);
 */
 
 // END Externhinweis
 // ============================================================

 // ============================================================
 // BEGIN Dynamic Navigation Bars
 // NEEDS Enable multiple onload functions 
 
 // set up the words in your language
 var NavigationBarHide = 'Einklappen';
 var NavigationBarShow = 'Ausklappen';
 
 // set up max count of Navigation Bars on page,
 // if there are more, all will be hidden
 // NavigationBarShowDefault = 0; // all bars will be hidden
 // NavigationBarShowDefault = 1; // on pages with more than 1 bar all bars will be hidden
 if (typeof NavigationBarShowDefault == 'undefined' ) {
     var NavigationBarShowDefault = 1;
 }
 
 // shows and hides content and picture (if available) of navigation bars
 // Parameters:
 //     indexNavigationBar: the index of navigation bar to be toggled
 function toggleNavigationBar(indexNavigationBar)
 {
    var NavToggle = document.getElementById("NavToggle" + indexNavigationBar);
    var NavFrame = document.getElementById("NavFrame" + indexNavigationBar);
 
    if (!NavFrame || !NavToggle) {
        return false;
    }
 
    // if shown now
    if (NavToggle.firstChild.data == NavigationBarHide) {
        for (
                var NavChild = NavFrame.firstChild;
                NavChild != null;
                NavChild = NavChild.nextSibling
            ) {
            if (NavChild.className == 'NavPic') {
                NavChild.style.display = 'none';
            }
            if (NavChild.className == 'NavContent') {
                NavChild.style.display = 'none';
            }
            if (NavChild.className == 'NavToggle') {
                NavChild.firstChild.data = NavigationBarShow;
            }
        }
 
    // if hidden now
    } else if (NavToggle.firstChild.data == NavigationBarShow) {
        for (
                var NavChild = NavFrame.firstChild;
                NavChild != null;
                NavChild = NavChild.nextSibling
            ) {
            if (NavChild.className == 'NavPic') {
                NavChild.style.display = 'block';
            }
            if (NavChild.className == 'NavContent') {
                NavChild.style.display = 'block';
            }
            if (NavChild.className == 'NavToggle') {
                NavChild.firstChild.data = NavigationBarHide;
            }
        }
    }
 }
 
 // adds show/hide-button to navigation bars
 function createNavigationBarToggleButton()
 {
    var indexNavigationBar = 0;
    // iterate over all < div >-elements
    var divs = document.getElementsByTagName("div");
    for (var i=0;  i<divs.length; i++) {
        var NavFrame = divs[i];
        // if found a navigation bar
        if (NavFrame.className == "NavFrame") {
 
            indexNavigationBar++;
            var NavToggle = document.createElement("a");
            NavToggle.className = 'NavToggle';
            NavToggle.setAttribute('id', 'NavToggle' + indexNavigationBar);
            NavToggle.setAttribute('href', 'javascript:toggleNavigationBar(' + indexNavigationBar + ');');
 
            var NavToggleText = document.createTextNode(NavigationBarHide);
            NavToggle.appendChild(NavToggleText);
 
            // add NavToggle-Button as first div-element 
            // in < div class="NavFrame" >
            NavFrame.insertBefore(
                NavToggle,
                NavFrame.firstChild
            );
            NavFrame.setAttribute('id', 'NavFrame' + indexNavigationBar);
        }
    }
    // if more Navigation Bars found than Default: hide all
    if (NavigationBarShowDefault < indexNavigationBar) {
        for(
                var i=1; 
                i<=indexNavigationBar; 
                i++
        ) {
            toggleNavigationBar(i);
        }
    }
 
 }
 
 addOnloadHook(createNavigationBarToggleButton);
 
 // END Dynamic Navigation Bars
 // ============================================================

 // ============================================================
 // BEGIN Moving of the editsection links
 
 /*
 * moveEditsection
 * Dieses Script verschiebt die [Bearbeiten]-Buttons vom rechten Fensterrand
 * direkt rechts neben die jeweiligen Überschriften.
 * This script moves the [edit]-buttons from the right border of the window
 * directly right next to the corresponding headings.
 *
 * Zum Abschalten die folgende Zeile (ohne führendes Sternchen) in die eigene
 * monobook.js (zu finden unter [[Special:Mypage/monobook.js|Benutzer:Name/monobook.js]]) kopieren:
 * var oldEditsectionLinks = true;
 *
 * dbenzhuser (de:Benutzer:Dbenzhuser)
 */
 function moveEditsection() {
     if (typeof oldEditsectionLinks == 'undefined' || oldEditsectionLinks == false) {
         var spans = document.getElementsByTagName("span");
         for(var i = 0; i < spans.length; i++) {
             if(spans[i].className == "editsection") {
                 spans[i].style.fontSize = "x-small";
                 spans[i].style.fontWeight = "normal";
                 spans[i].style.cssFloat = "none";
                 spans[i].style.marginLeft = "0px";
                 spans[i].parentNode.appendChild(document.createTextNode(" "));
                 spans[i].parentNode.appendChild(spans[i]);
             }
         }
     }
 }
 // onload
 addOnloadHook(moveEditsection);
 
 // END Moving of the editsection links
 // ============================================================

 // ============================================================
 // BEGIN import Onlyifediting-functions
 // SEE ALSO [[MediaWiki:Onlyifediting.js]]
 
 if (document.URL.indexOf("action=edit") > 0 || document.URL.indexOf("action=submit") > 0) {
     document.write('<script type="text/javascript" src="/w/index.php?title=MediaWiki:Onlyifediting.js&action=raw&ctype=text/javascript&dontcountme=s"></script>');
 }
 
 // END import Onlyifediting-functions
 // ============================================================

 // ============================================================
 // BEGIN import Onlyifuploading-functions
 // SEE ALSO [[MediaWiki:Onlyifuploading.js]]
 
 if ( wgCanonicalSpecialPageName == "Upload" ) {
     document.write('<script type="text/javascript" src="/w/index.php?title=MediaWiki:Onlyifuploading.js&action=raw&ctype=text/javascript&dontcountme=s"></script>');
 }
 
 // END import Onlyifuploading-functions
 // ============================================================

 // ============================================================
 // BEGIN pageview counter
 // SEE ALSO [[MediaWiki:Pagecounter.js]]
 //     Please talk to User:LeonWeber before changing anything or 
 //     if there are any issues with this.
 
 // disable the counter
 var disable_counter = 0; 
 
 document.write('<script type="text/javascript" src="/w/index.php?title=MediaWiki:Pagecounter.js&action=raw&ctype=text/javascript&dontcountme=s&smaxage=3600"></script>');
 
 // END pageview counter 
 // ============================================================

/** Fügt das Bookmarklet zum Markieren aller Versionen auf Special:Undelete ein */
addOnloadHook(function() {
    var form        = document.forms["undelete"];
    if (!form)  return;
    var elements    = form.elements;
    var resetBtn   = elements["mw-undelete-reset"];
    if (!resetBtn) return;
    var toggleBtn   = document.createElement("input");
    toggleBtn.type  = "button";
    toggleBtn.value ="Auswahl umkehren";
    toggleBtn.onclick   = function() {
        for (var i=0; i<elements.length; i++) {
            var input   = elements[i];
            if (input.type != "checkbox")   continue;
            input.checked   = !input.checked;
        }
    }
    resetBtn.parentNode.insertBefore(toggleBtn, resetBtn);
});