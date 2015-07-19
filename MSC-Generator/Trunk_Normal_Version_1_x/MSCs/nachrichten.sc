mscname: "Nachrichten"
process: process1, "Prozess 1"
process: process2, "Prozess 2"
process: process3, "Prozess 3"

msg: ENV_LEFT, process1, "Nachricht 1"
msg: process2, ENV_RIGHT, "Nachricht 2";
msg: process2, process1, "Nachricht 3"
msg: process3, process3, "Nachricht 4";
msg: process1, process3, "Nachricht 5";
msg: process3, process1, "Nachricht 6", *
