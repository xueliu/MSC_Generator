//<pre><nowiki>
// Amélioration de la page de recherche v2
// Auteur : Marc Mongenet
// Sous licence GFDL & GPL

function SpecialSearchEnhanced2() 
{

  function SearchForm(search_action_url, engine_url, engine_name, logo_url,
                      search_field_name, search_field_value,
                      site_field_name, site_field_value, extra_params)
  {
    var tr = document.createElement("tr");

    var td1 = document.createElement("td");
    td1.align = "right";
    tr.appendChild(td1);

    var a = document.createElement("a");
    a.href = engine_url;
    td1.appendChild(a);

    var img = document.createElement("img");
    img.src = logo_url;
    img.alt = engine_name;
    img.style.borderWidth = "0";
    a.appendChild(img);

    var td2 = document.createElement("td");
    tr.appendChild(td2);

    var form = document.createElement("form");
    form.method = "get";
    form.action = search_action_url;
    td2.appendChild(form);

    var input = document.createElement("input");
    input.type = "text";
    input.size = "32";
    input.name = search_field_name;
    input.value = search_field_value;
    form.appendChild(input);

    var site = document.createElement("input");
    site.type = "hidden";
    site.name = site_field_name;
    site.value = site_field_value;
    if (site.value!="" || site.name!=""){
        form.appendChild(site);
    }

    if (extra_params) {
        var l = ("" + extra_params).split("&");
        for (var i in l) {
            var param = l[i].split("=");
            var extra_input = document.createElement("input");
            extra_input.type = "hidden";
            extra_input.name = param[0];
            extra_input.value = param[1];
            form.appendChild(extra_input);
        }
    }

    var submit = document.createElement("input");
    submit.type = "submit";
    submit.value = "Benutze " + engine_name;
    form.appendChild(submit);

    return tr;
  }

  if (typeof SpecialSearchEnhanced2Disabled != 'undefined') return;
  if (wgPageName != "Spezial:Suche") return;

  var mainNode = document.getElementById("search");
  if (!mainNode) return;
//  mainNode = mainNode[0];
  var dummy = document.createElement("div")
  var id = document.createAttribute("id");
  id.nodeValue = "othersearches";
  dummy.setAttributeNode(id);
  mainNode.appendChild(dummy);
  mainNode = mainNode.lastChild;
  mainNode.appendChild(document.createElement("center"));
  mainNode = mainNode.lastChild;
  mainNode.appendChild(document.createElement("table"));
  mainNode = mainNode.lastChild;
  mainNode.style.backgroundColor = "transparent";
  mainNode.appendChild(document.createElement("tbody"));
  mainNode = mainNode.lastChild;

  var searchValue = document.getElementById("lsearchbox").value;
  var engine;
  engine = SearchForm("http://www.google.com/search", "http://www.google.com/", "Google",
                      "http://www.google.com/logos/Logo_25wht.gif", "q", searchValue,
                      "as_sitesearch", "de.wikipedia.org", "hl=de");
  mainNode.appendChild(engine);
  engine = SearchForm("http://de.wikiwix.com/index.php","http://www.wikiwix.com", "Wikiwix","http://upload.wikimedia.org/wikipedia/de/c/ce/Wikiwix_logo_mini_transparent.png", "action", searchValue,"lang", "de" ,"bg=de");
  mainNode.appendChild(engine);
  engine = SearchForm("http://de.search.yahoo.com/search", "http://de.search.yahoo.com/", "Yahoo!",
                      "http://us.yimg.com/i/yahootogo/y88red2.gif", "p", searchValue,
                      "vs", "de.wikipedia.org");
  mainNode.appendChild(engine);
  engine = SearchForm("http://search.live.com/results.aspx", "http://search.live.com/", "W. Live",
                      "http://search.live.com/s/affillogoLive.gif", "q", searchValue,
                      "q1", "site:http://de.wikipedia.org", "mkt=de-AR");
  mainNode.appendChild(engine);
  engine = SearchForm(" http://wiki.suche.web.de/wiki/", "http://www.web.de/", "Web.de",
                      "http://upload.wikimedia.org/wikipedia/de/2/22/Web.gif", "su", searchValue,
                      "&wmc=suche@home.suche@wiki");
  mainNode.appendChild(engine);


}

addOnloadHook(SpecialSearchEnhanced2);

//</nowiki></pre>