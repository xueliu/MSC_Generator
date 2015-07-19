PrintFootLine: no
Author: ""
Company: ""
Version: ""
Date: ""
Font: "Arial", "10", "Regular"
DiagramName: State Invariants
DiagramStyle: uml
PageSize: 600, auto
PageMargins: 10, 10, 10, 10

process: p1, "Process 1"
process: p2, "Process 2"
process: p3, "Process 3"

stateoverall: State 1;
state: p1, State 2,,t
state: p2, State\n3
state: p3, State 4,-,b;

state: p3, State 5,*,b
state: "p1,p2", State 6;
state: "p1,p3", State 7;
