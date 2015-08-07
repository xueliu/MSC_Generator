PrintFootLine: no
Author: ""
Company: ""
Version: ""
Date: ""
Font: "Arial", "10", "Regular"
DiagramName: Kombinierte Fragmente
DiagramStyle: uml
PageSize: 600, auto
PageMargins: 10, 10, 10, 10

process: p1, "Prozess 1"
process: p2, "Prozess 2"
process: p3, "Prozess 3"

fragmentbegin: i1, p1,p3, loop (0...5);
msg: p1, p2, Nachricht 1;
fragmentbegin: i2, p2,p3,alt;
fragmenttext: i2, "[x==1]
msg: p2, p3, Nachricht 2;
fragmentseparator: i2;
fragmenttext: i2, [else]
msg: p3, p2, Nachricht 3;
fragmentend: i2;
fragmentend: i1;


