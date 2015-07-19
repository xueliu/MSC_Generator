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

process: P1, ErsterProzess, ;
process: P2, ZweiterProzess, ;
regionbegin: P1, Activation;
regionbegin: P2, Activation;
msg: P1, P2, meineMessage( );
regionend:P1 ;
regionend: P2;
regionbegin: P1, Activation;
regionbegin: P2, Activation;
msg: P1,P2, meineZweiteMessage();
msg: P1,P2, meineDritteMessage();
msg: P2, P1,"",*;
regionend: P1;
regionend: P2;





