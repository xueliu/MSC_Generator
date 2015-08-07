DiagramName: Zeitangaben 1
DiagramStyle: uml
PageSize: 620, auto
PageMargins: 10, 10, 10, 10

process: p1, "Prozess 1",,70
process: p2, "Prozess 2",,0,20

timerbegin: t1, p1, t1=now,l,o
msg: p1, p2, Nachricht 1;
timerbegin: t2, p1, t2=now,l,n
timerbegin: t3, p2,t3,r,i
msg: p1, p2, Nachrich 2;
;
timerbegin: t4, p2,,r,n
msg: p2, p1, Nachricht 3
timerend: t1, tmax=t1+3s
timerend: t2, tmax=t2+4s;
;
timerbegin: t5, p1
msg: p1, p2, Nachricht 4
timerend: t4,{0...4s};
;
msg: p2, p1, Nachricht 5
timerend: t5
timerend: t3, {0...5s},*
