DiagramName: Combined Fragments
DiagramStyle: uml
PageSize: auto, auto
PageMargins: 10, 10, 10, 10

process: p1, "Process 1"
process: p2, "Process 2"
process: p3, "Process 3"

fragmentbegin: i1, p1,p3, loop (0...5);
msg: p1, p2, Message 1;
fragmentbegin: i2, p2,p3,alt;
fragmenttext: i2, "[x==1]
msg: p2, p3, Message 2;
fragmentseparator: i2;
fragmenttext: i2, [else]
msg: p3, p2, Message 3;
fragmentend: i2;
fragmentend: i1


