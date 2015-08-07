mscname: "Zustände"
mscstyle: UML
process: process1, "Prozess 1"
process: process2, "Prozess 2"
process: process3, "Prozess 3"
state: process1, "Zustand 1"
state: process3, "Zustand 2";
state: "process1,process2", "Zustand 3"
state: process3, "Zustand 4",*;
state: "process1,process3", "Zustand 5"