PageSize: A0, H
PageMargins: 75, 75, 10, 10
PrintFootLine: no
mscstyle: uml
mscname: "Beispiel MSC"
Author: Martin Kotowicz
Company: Itesys Institut für technische Systeme GmbH
Date: 11.11.2004
Version: 1.2

actor: CLU, "Anrufer"
process: ON, "Zentrale des Anrufers"
process: DN, "Zentrale des Anrufempfängers"
process: CDU, "Anrufempfänger"

stateoverall: "keine Verbindung";
msg: CLU, ON, "Anrufanfrage";
timeoutbegin: ON, T Anrufanfrage;
;;
msg: ON, DN, Anrufanfrage;
msg: DN, ON, Anruf wird getätigt;
msg: DN, CDU, Anruf;
msg: CDU, DN, Anrufsignal;
msg: DN, ON, Signal;
sidecomment: "test",l;
timeoutstop: ON;
msg: CDU, DN, Anrufannahme;
msg: DN, ON, Verbunden;
stateoverall: Verbunden;
