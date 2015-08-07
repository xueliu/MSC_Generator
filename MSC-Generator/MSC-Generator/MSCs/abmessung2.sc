
mscname: "Abmessung 2"
mscstyle: uml
process: process1, "Prozess 1"
process: process2, "Prozess 2"

measurestart: process1, g1, M1,,*
measurestart: process2, g2, M2, r;
;
;
measurestop: process1, g1,,,*
;
measurestop: process2, g2,test,r;