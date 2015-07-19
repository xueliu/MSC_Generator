mscname: "Abmessung"
mscstyle: uml
process: process1, "Prozess 1"
process: process2, "Prozess 2"

measurebegin: process1, M1
measurebegin: process2, M2, r, *;
;
;
measureend: process1
measureend: process2, ende;
