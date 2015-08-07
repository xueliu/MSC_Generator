DiagramStyle: sdl
DiagramName: "New MSC"

PageSize: auto
PageMargins: 10,10,10,10
Font: Arial, 10, Regular
LineOffset: 20
Author: ""
Company: ""
Date: ""
Version: ""
PrintFootline: no

process: p1, Process 1;
process: p2, Process 2;

state: p1, Idle
state: p2, Idle;
fragmentbegin: alt1, p1, p2, alt;
fragmenttext: alt1, [n<=0]
msg: p1, p2, "Addition(a,b)";
state: p2, Calculating;
msg: p2, p1, "Result: z",*;
fragmentseparator: alt1;
fragmentend: alt1;
state: p2, Idle;
