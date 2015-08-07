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

Lineoffset: 5

process: CLU, "Caller"
process: ON, "Caller's Switchboard"
process: DN, "Recipient's Switchboard"
process: CDU, "Recipient"

stateoverall: "no connection";
msg: CLU, ON, "Establish call";
timeoutbegin: ON, T Calling
msg: ON, DN, Establish call;
msg: DN, ON, Establishing call;
msg: DN, CDU, Incoming call;
msg: CDU, DN, Ringing;
msg: DN, ON, Ring signal
timeoutend: ON;
msg: CDU, DN, Answer call;
msg: DN, ON, Connected;
stateoverall: connected;