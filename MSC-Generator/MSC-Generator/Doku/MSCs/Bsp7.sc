PrintAuthor: yes
PrintCompany: yes
PrintVersion: yes
PrintDate: yes
PrintCreationDate: yes
PrintFileName: yes
Font: "Arial", "10", "Regular"
DiagramName: Colors
DiagramStyle: uml
PageMargins: 5, 5, 5, 5
PrintFootLine: yes
Author: Martin Kotowicz
Company: ITESYS GmbH
Version: 1.0
Date: 20.10.2006
PageSize: auto, auto

process: P1, "Prozess 1"
process: P2, "Prozess 2"
process: P3, "Prozess 3"

backcolor: yellow
fillcolor: #A0A0FF
msg: P1,P2, backcolor
state: P3, fillcolor;

backcolor: none
fillcolor:none
textcolor: red


state: P2, textcolor;
