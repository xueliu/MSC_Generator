DiagramStyle: uml
DiagramName: Neues MSC

PageSize: A2, H
PageMargins: 10, 10, 10, 10
Font: "Arial", "10", "Regular"
LineOffset: 20
Author: ""
Company: ""
Date: ""
Version: ""
PrintFootLine: no

process: p1, :XmiDocumentImport, ;
process: p2, :XmiModelDocumentInterpreter, ;
process: p3, :PapyrusXmiDIDocumentInterpreter,;
process: p4, :EditorEntryCreator,;
process: p5, orderedLifelineElements:ArrayList, ;
process: p6, modelElement:XmlElement, ;
process: p7, interactionElements:ArrayList, ;
process: p8, relevantBehaviorExecutionSpecElements:ArrayList, ;
process: p9, lifelinePositionPairs:ArrayList, ;


regionbegin: p1, Activation;
regionbegin: p2, Activation
msg: p1, p2,"LoadXmiModelDocument(xmiDocumentFileName )",!;
msg: p2, p1,"modelElement",*
regionend: p2;
regionbegin: p2, Activation
msg: p1, p2,"GetInteractionElements(modelElement)",!;
msg: p2, p1,"interactionElements",*
regionend: p2;
regionbegin: p2, Activation
msg: p1, p2,"GetLifelineElements(interactionElement)",!;
msg: p2, p1,"lifelineElements",*
regionend: p2;
regionbegin: p1, Activation
msgbegin: m1, p1,p1, GetLifelinePositions(lifelineElements);
fragmentbegin: f2, p1, p3, loop (for each lifelineElement in lifelineElements);
regionbegin: p3, Activation
msg: p1, p3, GetLifelinePositions(lifelineElements),!;
msg: p3, p1, lifelinePositionPairs,*
regionend: p3;
fragmentend: f2;
msgend:m1;
regionend: p1;
regionbegin: p1, Activation
msgbegin: m2, p1,p1, CreateLifelineEditorEntrys( ),!;
fragmentbegin: f3, p1, p4, loop (for each element in lifelinePositionPairs);
regionbegin: p4, Activation
msg: p1,p4,CreateProcessEditorEntry(lifelineName),!;
regionend: p4;
regionbegin: p5, Activation
msg: p1, p5, Add(currentLifelineElement);
regionend: p5;

fragmentend: f3;
msgend:m2;
regionend: p1;



fragmentbegin: f1, p1, p2,loop:(for each lifelineElement in lifelineElements);
regionbegin: p2, Activation
msg: p1,p2,"GetBehaviorExecutionSpecElementsForLifeline(interactionElement,lifelineId)",!;
msg: p2,p1,"relevantBehaviorExecutionSpecElements",*;
regionend: p2;





fragmentend: f1;
regionend: p1;


