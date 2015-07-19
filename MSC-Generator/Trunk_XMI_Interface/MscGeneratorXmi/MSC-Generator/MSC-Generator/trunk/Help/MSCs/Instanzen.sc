
DiagramName: Instanzen
DiagramStyle: uml
PageSize: auto
PageMargins: 10,10,10,10

process: p1, Prozess 1
dummyprocess: p2, 50,0
process: p3, "Prozess 3"

create: p1, p2, neu, Prozess 2, neuer Prozess;
msg: p2, p3, ende;
stop: p3;