DiagramName: Measurements 1
DiagramStyle: sdl
PageSize: auto, auto
PageMargins: 10, 10, 10, 10
left:10
right: 10

process: p1, "Process 1"
process: p2, "Process 2"

measurebegin: p1, M1
measurebegin: p2, M2, r, *
msg: p1, p2, Message 1;
;
;
msg: p2, p1, Message 2
measureend: p1
measureend: p2, ende;

