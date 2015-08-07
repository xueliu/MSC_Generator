PrintAuthor: yes
PrintCompany: yes
PrintVersion: yes
PrintDate: yes
PrintCreationDate: yes
PrintFileName: yes
Font: "Arial", "10", "Regular"
DiagramName: Call
DiagramStyle: uml
PageMargins: 5, 5, 5, 5
PrintFootLine: yes
Author: Martin Kotowicz
Company: ITESYS GmbH
Version: 1.0
Date: 20.10.2006
PageSize: 660, auto

process: CLU, "Caller"
process: ON, "Caller's Switchboard"
process: DN, "Recipient's Switchboard"
process: CDU, "Recipient"

stateoverall: "no connection";
msg: CLU, ON, "Establish Call";
timeoutbegin: ON, T Calling
msg: ON, DN, Establish Call;
msg: DN, ON, Establishing Call;
msg: DN, CDU, Incoming Call;
msg: CDU, DN, Ringing;
msg: DN, ON, Ring Signal
timeoutend: ON;
msg: CDU, DN, Answer Call;
msg: DN, ON, Connected;
stateoverall: connected;