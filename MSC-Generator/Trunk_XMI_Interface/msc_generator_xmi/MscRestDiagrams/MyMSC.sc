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

process: firstProcess, FirstProcess, ;
process: secondProcess, SecondProcess, ;
regionbegin: firstProcess,Activation;
regionbegin: secondProcess, Activation
msg: firstProcess,secondProcess, MyFirstMessage( );
regionend: firstProcess;
regionend: secondProcess;


