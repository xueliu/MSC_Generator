DiagramStyle: uml
DiagramName: XmiDocumentInterpretation

PageSize: A4, H
PageMargins: 10, 10, 10, 10
Font: "Arial", "10", "Regular"
LineOffset: 20
Author: ""
Company: ""
Date: ""
Version: ""
PrintFootLine: no

process: p1, :XmiDocumentImport, ;
process: p2, :SequenceChartModelCreator , ;

regionbegin: p1, Activation;
regionbegin: p2, Activation
msg: p1, p2,"MessageText",*;

regionend: p2;
regionbegin: p2, Activation
msg: p1, p2,"MessageText";
regionend: p2;


regionend: p1;


