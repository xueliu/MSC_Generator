DiagramStyle: uml 
DiagramName: Interaction1

PageSize: A4, H
PageMargins: 10,10,10,10 
Font: Arial, 10, Regular 
LineOffset: 20
Author: ''
Company: ''
Date: ''
Version: ''
PrintFootLine: no 

process: FirstLifeline_1, FirstLifeline;
process: SecondLifeline_1, SecondLifeline;
process: ThirdLifeline_1, ThirdLifeline;
process: FourthLifeline_1, FourthLifeline;
msg: FirstLifeline_1, SecondLifeline_1, FirstMessage;
msg: SecondLifeline_1, ThirdLifeline_1, SecondMessage;
msg: ThirdLifeline_1, SecondLifeline_1, ThirdMessage;
msg: SecondLifeline_1, FirstLifeline_1, FourthMessage;
msg: FirstLifeline_1, FourthLifeline_1, FifthMessage;
msg: FourthLifeline_1, SecondLifeline_1, SixthMessage;
msg: SecondLifeline_1, ThirdLifeline_1, SeventhMessage;
msg: ThirdLifeline_1, FirstLifeline_1, EigthMessage;
