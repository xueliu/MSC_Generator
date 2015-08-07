
mscname: "Bereich"
process: process1, "Prozess 1"
process: process2, "Prozess 2"
process: process3, "Prozess 3"

inlinebegin: inline1, process1, process2, "loop (0,5)";
msg: process1, process2, "Nachricht 1";
inlineend: inline1;

inlinebegin: inline2, process1, process3, "par";
msg: process1, process2, "Nachricht 2";
inlineseperator: inline2;
msg: process1, process3, "Nachricht 3";
inlineend: inline2
