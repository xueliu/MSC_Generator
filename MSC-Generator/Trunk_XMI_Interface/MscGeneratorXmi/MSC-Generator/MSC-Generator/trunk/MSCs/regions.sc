mscname: "Prozesse: regions"
process: process1, "Activation"
process: process2, "Suspension"
process: process3, "Coregion"

regionstart: process1, activation
regionstart: process2, suspension
regionstart: process3, coregion;
;
regionbegin: process3, activation;
;
regionbegin: process3, suspension;
;
regionend: process3;
;
regionend: process3;
;
regionend: process1
regionend: process2
regionend: process3;
