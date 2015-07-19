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


process: fourthProcess, fourthProcessName;
process: fifthProcess, fifthProcessName;
process: sixthProcess, sixthProcessName;

msg: fourthProcess, fifthProcess, fourthMessageText;
msg: fifthProcess, sixthProcess, fifthMessageText;
msg: sixthProcess, fifthProcess, sixthMessageText;
msg: fifthProcess,fourthProcess, seventhMessage;

