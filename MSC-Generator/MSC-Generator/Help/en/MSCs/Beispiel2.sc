DiagramName: Example 2
DiagramStyle: uml
PageSize: 400, auto
PageMargins: 10, 10, 10, 10

process: p1, "Process 1"
process: p2, "Process 2"

state: p1, State 1
state: p2, State\n2;
msg: p1, p2,Message 1;

msg: p2, p1, Message 2
timerbegin: t2, p1,t2=now
timerbegin: t1, p2, t1=now,r;
;
;
msg: p2, p1, Message 3
timerend: t1;;

msg: p2,p1, Message 4;
msg: p1,p2, Message 5
timerend: t2, t2+1s

