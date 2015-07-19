DiagramName: Messungen 2
DiagramStyle: sdl
PageSize: auto, auto
PageMargins: 10, 10, 10, 10
left:10
right: 10

process: p1, "Prozess 1"
process: p2, "Prozess 2"

measurestart: p1, m1,M1
measurestart: p2, m2, M2,r, *
msg: p1, p2, Nachricht 1;
;
;
;
msg: p2, p1, Nachricht 2
measurestop: p1,m1
measurestop: p2, m2, ende,r,*;

