DiagramStyle: uml
DiagramName: "LineOffset = 20"
PageSize: auto
LineOffset: 30
process: p1, Process 1;
process: p2, Process 2;

state: p2, Bereit;
msg: p1, p2, Anfrage;
state: p2, Verarbeitung;
msg: p2, p1, Antwort;
state: p2, Bereit;