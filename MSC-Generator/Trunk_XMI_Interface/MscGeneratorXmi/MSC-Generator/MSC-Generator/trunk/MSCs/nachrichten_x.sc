mscname: "Nachrichten 2"
process: process1, "Prozess 1"
process: process2, "Prozess 2"

msgbegin: msg1, process1, process2, "Nachricht 1";
msg: process2, process1, "Nachricht 2";
msgend: msg1
