mscname: "Bereiche 2"
process: process1, "Prozess 1"
process: process2, "Prozess 2"
process: process3, "Prozess 3"

inlinebegin: inline1, process1, process3, "alt";
inlinebegin: inline2, process1, process2, "loop (0,3)";
msg: process1, process2, "Nachricht 1";
inlineend: inline2;
inlineseperator: inline1;
inlinebegin: inline3, process2, process3, "loop (0,3)";
msg: process3, process2, "Nachricht 2";
inlineend: inline3;
inlineend: inline1
