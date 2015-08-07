PrintFootLine: no
Author: ""
Company: ""
Version: ""
Date: ""
Font: "Arial", "10", "Regular"
DiagramName: Zustandsinvarianten
DiagramStyle: uml
PageSize: 600, auto
PageMargins: 10, 10, 10, 10

process: p1, "Prozess 1"
process: p2, "Prozess 2"
process: p3, "Prozess 3"

stateoverall: Zustand 1;
state: p1, Zustand 2,,t
state: p2, Zustand\n3
state: p3, Zustand 4,-,b;

state: p3, Zustand 5,*,b
state: "p1,p2", Zustand 6;
state: "p1,p3", Zustand 7;
