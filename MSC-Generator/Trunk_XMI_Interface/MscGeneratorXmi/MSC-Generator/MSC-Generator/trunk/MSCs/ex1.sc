Font: "Arial", "10", "Regular"
DiagramName: Beispiel MSC
DiagramStyle: uml
PageMargins: 10, 10, 10, 10
PrintFootLine: yes
Author: "Martin Kotowicz"
Company: ""
Version: ""
Date: ""
lineoffset: 100
PageSize: auto
process: CLU, "Anrufer"
process: ON, "Zentrale des Anrufers"
process: DN, "Zentrale des Anrufempfängers"
process: CDU, "Anrufempfänger"

stateoverall: "keine Verbindung";
msg: CLU, ON, "Anrufanfrage";
timeoutbegin: ON, {T Anrufanfrage}
msg: ON, DN, Anrufanfrage;
msg: DN, ON, Anruf wird getätigt;
msg: DN, CDU, Anruf;
msg: CDU, DN, Anrufsignal;
msg: DN, ON, Signal
timeoutend: ON;
msg: CDU, DN, Anrufannahme;
msg: DN, ON, Verbunden;
stateoverall: Verbunden;