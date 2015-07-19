DiagramStyle: uml
DiagramName: Neues MSC

PageSize: A4, H
PageMargins: 10, 10, 10, 10
Font: "Arial", "10", "Regular"
LineOffset: 20
Author: ""
Company: ""
Date: ""
Version: ""
PrintFootLine: no

process: firstProcess, ProcessName;
process: secondProcess, ProcessName;
process: thirdProcess, ProcessName;
regionbegin: firstProcess, Activation;
regionbegin: secondProcess, Activation
msg: firstProcess, secondProcess,"firstMessageName",!;
regionbegin: thirdProcess, Activation
msg: secondProcess, thirdProcess,"secondMessageName",!;
msg: thirdProcess,secondProcess,"thirdMessageName",*
regionend: thirdProcess;
regionend: secondProcess;
regionend: firstProcess;
