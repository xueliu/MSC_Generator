mscname: "Timer2"
process: process1, "Prozess 1"
process: process2, "Prozess 2"

settimer: process1, "Timer T1 (5s)"
settimer: process2, "Timer T2 (7s)", r;
timeout: process1, "T1"
stoptimer: process2, "abbruch T2", r;
