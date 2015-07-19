DiagramName: Anruf
DiagramStyle: uml
PageMargins: 5, 5, 5, 5
PageSize: auto

actor: CLU, "Anrufer"
process: ON, "Zentrale des Anrufers"
process: DN, "Zentrale des Anrufempfängers"
actor: CDU, "Anrufempfänger"

stateoverall: "keine Verbindung";
msg: CLU, ON, "Anrufanfrage";
timerbegin:T1, ON, T Anrufanfrage
msg: ON, DN, Anrufanfrage;
msg: DN, ON, Anruf wird getätigt;
msg: DN, CDU, Anruf;
msg: CDU, DN, Anrufsignal;
msg: DN, ON, Signal
timerend: T1;
msg: CDU, DN, Anrufannahme;
msg: DN, ON, Verbunden;
stateoverall: Verbunden;
