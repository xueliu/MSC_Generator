DiagramName: Timer
DiagramStyle: sdl
PageSize: 1122, 793
PageMargins: 10, 10, 10, 10
PrintFootLine: no
Author: ""
Company: ""
Version: ""
Date: ""
Font: "Arial", "10", "Regular"

process: process1, "Prozess 1"
fillcolor: yellow
process: process2, "Prozess 2"

timeoutbegin: process1,"Timer (5s)",l,i
timeoutbegin: process2,"Timer (7s)",r,n;
;
;
timeoutend: process1,tes\nttest;
timeoutstop: process2, "abbruch";
timerbegin: t1, process1,"Hallo",r,i;
;
timerend: t1, "Hallo",-;