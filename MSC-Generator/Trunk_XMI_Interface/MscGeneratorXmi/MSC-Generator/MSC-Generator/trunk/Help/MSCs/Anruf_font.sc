PrintAuthor: yes
PrintCompany: yes
PrintVersion: yes
PrintDate: yes
PrintCreationDate: yes
PrintFileName: yes
Font: "Times New Roman", "10,5", "bold italic"
DiagramName: Anruf
DiagramStyle: uml
PageMargins: 5, 5, 5, 5
PrintFootLine: yes
Author: Martin Kotowicz
Company: ITESYS GmbH
Version: 1.0
Date: 20.10.2006
PageSize: 660, auto

process: CLU, "Anrufer"
process: ON, "Zentrale des Anrufers"
process: DN, "Zentrale des Anrufempf�ngers"
process: CDU, "Anrufempf�nger"

stateoverall: "keine Verbindung";
msg: CLU, ON, "Anrufanfrage";
timeoutbegin: ON, T Anrufanfrage
msg: ON, DN, Anrufanfrage;
msg: DN, ON, Anruf wird get�tigt;
msg: DN, CDU, Anruf;
msg: CDU, DN, Anrufsignal;
msg: DN, ON, Signal
timeoutend: ON;
msg: CDU, DN, Anrufannahme;
msg: DN, ON, Verbunden;
stateoverall: Verbunden;