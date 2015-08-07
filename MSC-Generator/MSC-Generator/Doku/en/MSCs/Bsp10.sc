
DiagramName: Instances
DiagramStyle: uml
PageSize: auto
PageMargins: 10,10,10,10

actor: p1, Process 1
dummyprocess: p2, 50,0
process: p3, "Process 3"

create: p1, p2, new, Process 2, new Process;
msg: p2, p3, end;
stop: p3