
DiagramName: Instances
DiagramStyle: uml
PageSize: auto
PageMargins: 10,10,10,10
left: 100
right: 50

process: p1, Prozess 1
dummyprocess: p2, 50, 0
process: p1, Process 3

create: p1, p2, neu, Process 2, new Prozess;
msg: p2, p3, end;
stop: p3;       
