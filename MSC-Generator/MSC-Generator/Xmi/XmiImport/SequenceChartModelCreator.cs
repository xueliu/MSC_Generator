/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 12:43
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Xml;
using System.Collections;
using xmi;
using sequenceChartModel;
using System.Diagnostics;


namespace xmiImport
{
	/// <summary>
	/// Description of SequenceChartModelCreator.
	/// Interprets the UML-Interaction and creates the nessessary MSC-Interaction-Informations
	/// </summary>
	/// 
	
	
	public class SequenceChartModelCreator
	{
		private XmiModelDocumentInterpreter modelDocumentInterpreter;
		private XmiDIDocumentInterpreter diDocumentInterpreter;
		private Point ZERO_POSITION=new Point(0,0);
	
		
		public SequenceChartModelCreator(XmiModelDocumentInterpreter modelDocumentInterpreter,XmiDIDocumentInterpreter diDocumentInterpreter)
		{
			this.modelDocumentInterpreter=modelDocumentInterpreter;
			this.diDocumentInterpreter=diDocumentInterpreter;
		
		}
		
		public XmiModelDocumentInterpreter ModelDocumentInterpreter{
			get{
				return this.modelDocumentInterpreter;
			}
		}
		
		public XmiDIDocumentInterpreter DiDocumentInterpreter{
			get{
				return this.diDocumentInterpreter;
			}
		}
		
		public Interaction CreateInteractionForInteractionElement(XmlElement interactionElement,XmlElement diagramElement)
		{
			Interaction interaction=null;
			interaction=CreateInteraction(interactionElement);
			ArrayList lifelines=CreateLifelines(interactionElement,diagramElement);
			interaction.Lifelines=lifelines;
			
			
			CreateMessages(interaction,diagramElement);
			CreateMessageEndsForLifelines(lifelines,diagramElement,interaction);
			ConnectMessageEndsToMessage(lifelines,interaction);
			CreateExecutionsForLifelines(interaction,diagramElement);
			CreateExecutionOccurenceSpecs(interaction);
			ConnectMessageEndsToBehaviorExecutionSpecs(interaction);
			return interaction;
		}
		
		protected internal Interaction CreateInteraction(XmlElement diagramElement)
		{
			string interactionName=diagramElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			string interactionId=diagramElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			Interaction newInteraction=new Interaction(ZERO_POSITION,interactionId,diagramElement);
			newInteraction.Name=interactionName;
			return newInteraction;
		}
		
		protected internal ArrayList CreateLifelines(XmlElement interactionElement,XmlElement diagramElement)
		{
			XmlElement currentLifelineElement;
			Lifeline currentLifeline;
			string currentLifelineName;
			string currentLifelineId;
			bool isCurrentLifelineDestructed;
			Point currentLifelinePosition;
			XmlNodeList lifelineElements=modelDocumentInterpreter.GetLifelineElements(interactionElement);
			ArrayList lifelines=new ArrayList();
			IEnumerator itrLifelineElements=lifelineElements.GetEnumerator();
			
			while(itrLifelineElements.MoveNext())
			{
				currentLifelineElement=(XmlElement)itrLifelineElements.Current;
				currentLifelineId=currentLifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				currentLifelineName=currentLifelineElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
				currentLifelinePosition=diDocumentInterpreter.GetLifelineGraphNodePosition(diagramElement,currentLifelineElement);
				currentLifeline=new Lifeline(currentLifelinePosition,currentLifelineId,currentLifelineElement);
				currentLifeline.Name=currentLifelineName;
				isCurrentLifelineDestructed=this.IsLifelineDestructed(interactionElement,currentLifelineId);
				currentLifeline.IsDestructed=isCurrentLifelineDestructed;
				lifelines.Add(currentLifeline);
			}
			
			lifelines=SortListForHorizontalPosition(lifelines);
			return lifelines;
		}
		
		protected void CreateExecutionOccurenceSpecs(Interaction relevantInteraction)
		{
			ExecutionSpecification currentExecutionSpec;
			ExecutionOccurrenceSpecification executionOccurrenceSpecStart;
			ExecutionOccurrenceSpecification executionOccurrenceSpecFinish;
			XmlElement currentBehaviorExecutionSpecElement;
			XmlElement executionOccurrenceSpecFinishElement;
			XmlElement executionOccurrenceSpecStartElement;
			Point currentExecutionSpecPosition;
			Size currentExecutionSpecDimension;
			Point executionOccurrenceSpecStartPosition;
			Point executionOccurrenceSpecFinishPosition;
			
			string currentExecutionOccurrenceSpecStartId;
			string currentExecutionOccurrenceSpecFinishId;
			ArrayList executionSpecs =relevantInteraction.ExecutionSpecs;
			IEnumerator itrExecutionSpecs =executionSpecs.GetEnumerator();
			
			while(itrExecutionSpecs.MoveNext())
			{
				currentExecutionSpec=(ExecutionSpecification)itrExecutionSpecs.Current;
				currentExecutionSpecPosition=currentExecutionSpec.Position;
				currentExecutionSpecDimension=currentExecutionSpec.Dimension;
				currentBehaviorExecutionSpecElement=currentExecutionSpec.XmlRepresentation;
				currentExecutionOccurrenceSpecStartId=currentBehaviorExecutionSpecElement.GetAttribute(UmlModel.START_ATTR_COMPLETE_NAME);
				currentExecutionOccurrenceSpecFinishId=currentBehaviorExecutionSpecElement.GetAttribute(UmlModel.FINISH_ATTR_COMPLETE_NAME);
				
				executionOccurrenceSpecStartPosition=new Point(currentExecutionSpecPosition.X,currentExecutionSpecPosition.Y);
				executionOccurrenceSpecFinishPosition=new Point(currentExecutionSpecPosition.X,
				                                               currentExecutionSpecPosition.Y+currentExecutionSpecDimension.Height);
				
				
				executionOccurrenceSpecStartElement=
						modelDocumentInterpreter.GetExecutionOccurrenceSpecElementForId(relevantInteraction.XmlRepresentation,
					                                                               		currentExecutionOccurrenceSpecStartId);
				executionOccurrenceSpecFinishElement=
						modelDocumentInterpreter.GetExecutionOccurrenceSpecElementForId(relevantInteraction.XmlRepresentation,
					                                                               		currentExecutionOccurrenceSpecFinishId);
				
				executionOccurrenceSpecStart=new ExecutionOccurrenceSpecification(executionOccurrenceSpecStartPosition,
					                                                              currentExecutionOccurrenceSpecStartId,
					                                                              relevantInteraction.XmlRepresentation);
				executionOccurrenceSpecStart.CoveredLifeline=currentExecutionSpec.CoveredLifeline;
				executionOccurrenceSpecStart.Position=executionOccurrenceSpecStartPosition;
				executionOccurrenceSpecStart.SpecificationKind= ExecutionOccurrenceSpecKind.START;
				
				
				executionOccurrenceSpecFinish=new ExecutionOccurrenceSpecification(executionOccurrenceSpecFinishPosition,
					                                                                   currentExecutionOccurrenceSpecFinishId,
					                                                                   relevantInteraction.XmlRepresentation);
				executionOccurrenceSpecFinish.CoveredLifeline=currentExecutionSpec.CoveredLifeline;
				executionOccurrenceSpecFinish.Position=executionOccurrenceSpecFinishPosition;
				executionOccurrenceSpecFinish.SpecificationKind= ExecutionOccurrenceSpecKind.FINISH;
				
				relevantInteraction.ExecutionOccurrenceSpecs.Add(executionOccurrenceSpecStart);
				relevantInteraction.ExecutionOccurrenceSpecs.Add(executionOccurrenceSpecFinish);
			}
		}
		
	
		
		protected internal void CreateExecutionsForLifelines(Interaction interaction, XmlElement diagramElement)
		{
			Lifeline currentLifeline;
			ArrayList lifelines=interaction.Lifelines;
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				CreateExecutionsForLifeline(currentLifeline,interaction,diagramElement);
				
			}
		}
		

		protected internal void CreateExecutionsForLifeline(Lifeline lifeline,Interaction interaction, XmlElement diagramElement)
		{
			string lifelineId=lifeline.XmiId;
			XmlElement lifelineElement=lifeline.XmlRepresentation;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			ArrayList executions=new ArrayList();
			ArrayList executionElements=modelDocumentInterpreter.GetExecutionSpecElementsForLifeline(lifelineElement);
			IEnumerator itrExecutionElements=executionElements.GetEnumerator();
			XmlElement currentExecutionElement;
			ExecutionSpecification currentNewExecution;
			Point currentExecutionPosition;
			Size currentExecutionDimension;
			string currentExecutionId;
			
			while(itrExecutionElements.MoveNext())
			{
				currentExecutionElement=(XmlElement)itrExecutionElements.Current;
				currentExecutionPosition=diDocumentInterpreter.GetExecutionSpecPosition(diagramElement,currentExecutionElement);
				currentExecutionDimension=diDocumentInterpreter.GetExecutionSpecDimension(diagramElement,currentExecutionElement);
				currentExecutionId=currentExecutionElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				currentNewExecution=new ExecutionSpecification(currentExecutionPosition,currentExecutionId,currentExecutionElement);
				currentNewExecution.Dimension=currentExecutionDimension;
				currentNewExecution.CoveredLifeline=lifeline;
				executions.Add(currentNewExecution);
			}
			
			executions=SortListForVerticalPosition(executions);
			lifeline.ExecutionSpecifications=executions;
			
			if(executions.Count>0)
			{
				interaction.ExecutionSpecs.AddRange(executions);
			}
		}
		
		protected internal void ConnectMessageEndsToBehaviorExecutionSpecs(Interaction relevantInteraction)
		{
			ArrayList currentExecutionSpecs;
			IEnumerator itrCurrentExecutionSpecs;
			IEnumerator itrLifelines;
			Lifeline currentLifeline;
			ExecutionSpecification currentExecutionSpec;
			ArrayList lifelines=relevantInteraction.Lifelines;
			itrLifelines=lifelines.GetEnumerator();
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				currentExecutionSpecs=currentLifeline.ExecutionSpecifications;
				itrCurrentExecutionSpecs=currentExecutionSpecs.GetEnumerator();
				
				while(itrCurrentExecutionSpecs.MoveNext())
				{
					currentExecutionSpec=(ExecutionSpecification)itrCurrentExecutionSpecs.Current;
					ConnectMessageEndsToBehaviorExecutionSpec(currentExecutionSpec);
				}
			}
		}
		
		protected internal void ConnectMessageEndsToBehaviorExecutionSpec(ExecutionSpecification executionSpec)
		{
			MessageEnd currentSourceMessageEnd;
			ArrayList coveringSourceMessageEnds;
			IEnumerator itrCoveringSourceMessageEnds;
			bool coversExecutionSpec;
			Lifeline coveredLifeline=executionSpec.CoveredLifeline;
			coveringSourceMessageEnds=coveredLifeline.GetConnectedSourceMessageEnds();
			itrCoveringSourceMessageEnds=coveringSourceMessageEnds.GetEnumerator();
			
			
			while(itrCoveringSourceMessageEnds.MoveNext())
			{
				currentSourceMessageEnd=(MessageEnd)itrCoveringSourceMessageEnds.Current;
				coversExecutionSpec=executionSpec.IsMessageEndCovered(currentSourceMessageEnd);
				
				if(coversExecutionSpec==true)
				{
					executionSpec.MessageSourceEnds.Add(currentSourceMessageEnd);
					currentSourceMessageEnd.CoveredExecutionSpecification=executionSpec;
				}
			}
		}
		
		protected internal void CreateMessages(Interaction interaction,XmlElement diagramElement)
		{
			XmlElement currentMessageElement;
			Message currentMessage;
			Point currentMessagePosition;
			string currentMessageName;
			string currentMessageId;
			string currentMessageSort;
			ArrayList messages=new ArrayList();
			XmlElement interactionElement=interaction.XmlRepresentation;
			XmlNodeList messageElements=modelDocumentInterpreter.GetMessageElements(interactionElement);
			IEnumerator itrMessageElements=messageElements.GetEnumerator();
			
			while(itrMessageElements.MoveNext())
			{
				currentMessageElement=(XmlElement)itrMessageElements.Current;
				currentMessagePosition=diDocumentInterpreter.GetMessageGraphNodePosition(diagramElement,currentMessageElement);
				currentMessageId=currentMessageElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				currentMessageName=currentMessageElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
				currentMessageSort=currentMessageElement.GetAttribute(UmlModel.MESSAGE_SORT_ATTR_NAME);
				currentMessage=new Message(currentMessagePosition,currentMessageId,currentMessageElement);
				currentMessage.Name=currentMessageName;
				AddMessageSort(currentMessage, currentMessageSort);
				messages.Add(currentMessage);
			}
			
			messages=SortListForVerticalPosition(messages);
			interaction.Messages=messages;
		}
		
		protected internal void CreateMessageEndsForLifelines(ArrayList lifelines,XmlElement diagramElement,Interaction interaction)
		{
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			Lifeline currentLifeline;
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				CreateMessageEndsForLifeline(currentLifeline,diagramElement,interaction);
			}
		}
		
		/*
		protected internal void CreateFormalGates(Interaction relevantInteraction,XmlElement diagramElement)
		{
			XmlElement currentFormalGateElement;
			XmlElement currentConnectedMessageElement;
			
			string currentConnectedMessageElementId;
			Point currentFormalGatePosition;
			
			MessageEndKind messageEndKind;
			string strMessageEndKind;
			string currentFormalGateId;
			FormalGate currentFormalGate;
			
			XmlElement interactionElement=relevantInteraction.XmlRepresentation;
			XmlNodeList formalGateElements=modelDocumentInterpreter.GetFormalGateElements(interactionElement);
			IEnumerator itrFormalGateElements=formalGateElements.GetEnumerator();
			
			while(itrFormalGateElements.MoveNext())
			{
				currentFormalGateElement=(XmlElement)itrFormalGateElements.Current;
				currentFormalGateId=currentFormalGateElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				currentConnectedMessageElementId=currentFormalGateElement.GetAttribute(UmlModel.MESSAGE_ATTR_NAME);
				currentConnectedMessageElement=modelDocumentInterpreter.GetMessageElementForId(diagramElement,currentConnectedMessageElementId);
				strMessageEndKind =modelDocumentInterpreter.GetEventKindForFormalGateXmlElement(currentFormalGateElement,currentConnectedMessageElement);
				
				if (strMessageEndKind.Equals(MessageEndKind.destinationEnd))
				{
					messageEndKind= MessageEndKind.destinationEnd;
					currentFormalGatePosition=diDocumentInterpreter.GetFormalGateGraphNodePosition(diagramElement,currentFormalGateElement,messageEndKind);
				}
				else if(strMessageEndKind.Equals(MessageEndKind.sourceEnd))
				{
					messageEndKind= MessageEndKind.sourceEnd;
					currentFormalGatePosition=diDocumentInterpreter.GetFormalGateGraphNodePosition(diagramElement,currentFormalGateElement,messageEndKind);
				}
						
				
				
				currentFormalGate= new FormalGate(currentFormalGatePosition,currentFormalGateId ,currentFormalGateElement);
				currentFormalGate.MessageEndKind=messageEndKind;
					
					
				
			}
		}*/
		
		
		
		protected internal void CreateMessageEndsForLifeline(Lifeline lifeline,XmlElement diagramElement,Interaction interaction)
		{
			ArrayList relevantMessageEnds;
			XmlElement currentMessageEndElement;
			MessageEnd currentMessageEnd;
			ExecutionSpecification currentBehaviorExecutionSpec;
			string currentMessageEndId;
			Point currentMessageEndPosition;
			relevantMessageEnds=new ArrayList();
			XmlElement lifelineElement=lifeline.XmlRepresentation;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			XmlNodeList messageOccurrenceSpecElements=
				modelDocumentInterpreter.GetMessageOccurrenceSpecElementsForLifeline(lifelineElement);
			IEnumerator itrMessageOccurrenceSpecElements=messageOccurrenceSpecElements.GetEnumerator();
			
			while(itrMessageOccurrenceSpecElements.MoveNext())
			{
				currentMessageEndElement=(XmlElement)itrMessageOccurrenceSpecElements.Current;
				currentMessageEndId=currentMessageEndElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				currentMessageEndPosition=
					diDocumentInterpreter.GetMessageOccurrenceSpecGraphNodePosition(diagramElement,currentMessageEndElement);
				currentMessageEnd=new MessageEnd(currentMessageEndPosition,currentMessageEndId,currentMessageEndElement);
				currentMessageEnd.CoveredLifeline=lifeline;
				currentBehaviorExecutionSpec=currentMessageEnd.GetExecutionForMessageEnd();
				
				if(currentBehaviorExecutionSpec!=null)
				{
					currentBehaviorExecutionSpec.MessageSourceEnds.Add(currentMessageEnd);
				}
				
				relevantMessageEnds.Add(currentMessageEnd);
			}
			
			relevantMessageEnds=SortListForVerticalPosition(relevantMessageEnds);
			lifeline.MessageEnds=relevantMessageEnds;
			
			if(relevantMessageEnds.Count >0)
			{
				interaction.MessageOccurrenceSpecs.AddRange(relevantMessageEnds);
			}
		}
		
		protected internal void ConnectMessageEndsToMessage(ArrayList relevantLifelines,Interaction interaction)
		{
			IEnumerator itrRelevantLifelines=relevantLifelines.GetEnumerator();
			Lifeline currentLifeline;
			ArrayList currentMessageEnds;
			
			while(itrRelevantLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrRelevantLifelines.Current;
				currentMessageEnds=currentLifeline.MessageEnds;
				IEnumerator itrRelevantMessageEnds=currentMessageEnds.GetEnumerator();
	
				MessageEnd currentMessageEnd;
				XmlElement currentMessageEndElement;
				XmlElement currentMessageElement;
				Message currentMessage;
				
				while(itrRelevantMessageEnds.MoveNext())
				{
					currentMessageEnd=(MessageEnd)itrRelevantMessageEnds.Current;
					currentMessageEndElement=currentMessageEnd.XmlRepresentation;
					currentMessageElement=
						modelDocumentInterpreter.GetMessageElementForMessageOccurrenceSpec(currentMessageEndElement);
					currentMessage=GetMessageForMessageElement(currentMessageElement,interaction);
					ConnectMessageEndToMessage(currentMessageEnd,currentMessage);
				}
			}
		}
		
		protected internal void ConnectMessageEndToMessage(MessageEnd messageEnd,Message message)
		{
			XmlElement messageElement=message.XmlRepresentation;
			XmlElement messageEndElement=messageEnd.XmlRepresentation;
			string messageReceiveEventId=messageElement.GetAttribute(UmlModel.RECEIVE_EVENT_ATTR_NAME);
			string messageSendEventId=messageElement.GetAttribute(UmlModel.SEND_EVENT_ATTR_NAME);
			string messageEndElementId=messageEndElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			
			messageEnd.CorrespondingMessage=message;					
			
			if(messageEndElementId.Equals(messageReceiveEventId))
			{
			   message.DestinationMessageEnd=messageEnd;
			   messageEnd.MessageEndKind= MessageEndKind.destinationEnd;
			}
			else if(messageEndElementId.Equals(messageSendEventId))
			{
				message.SourceMessageEnd=messageEnd;
				messageEnd.MessageEndKind= MessageEndKind.sourceEnd;
			}
			
		}
		
		protected internal EventKind GetEventForMessageEnd(XmlElement messageEndElement)
		{
			EventKind relevantEventKind;
			string relevantElementXmiType;
			XmlElement eventElement=this.modelDocumentInterpreter.GetEventElementForMessageEnd(messageEndElement);
			
			relevantElementXmiType=eventElement.GetAttribute(UmlModel.XMI_TYPE_ATTR_COMPLETE_NAME);
			
			if(relevantElementXmiType.Equals(UmlModel.SEND_OPERATION_EVENT_COMPLETE_NAME))
			{
				relevantEventKind=EventKind.sendOperationEvent;
			}
			else if(relevantElementXmiType.Equals(UmlModel.RECEIVE_OPERATION_EVENT_COMPLETE_NAME))
			{
				relevantEventKind=EventKind.receiveOperationEvent;
			}		
			else
			{
				relevantEventKind= EventKind.executionEvent;
			}
			// vielleicht noch erweitern für create-Message.....
			
			return relevantEventKind;
		}
			
		protected internal Message GetMessageForMessageElement(XmlElement relevantMessageElement,Interaction interaction)
		{
			Message relevantMessage=null;
			ArrayList messages=interaction.Messages;
			IEnumerator itrMessages=messages.GetEnumerator();
			XmlElement currentMessageElement;
			Message currentMessage;
			bool messageNotFound=true;
			
			while((itrMessages.MoveNext())&&(messageNotFound))
			{
				currentMessage=(Message)itrMessages.Current;
				currentMessageElement=currentMessage.XmlRepresentation;
				
				if(currentMessageElement==relevantMessageElement)
				{
					relevantMessage=currentMessage;
					messageNotFound=false;
				}
			}
			return relevantMessage;	
		}
		
		
		protected internal void AddMessageSort(Message message, string messageSort)
		{
			if(messageSort==null)
			{
				message.MessageSort= MessageSort.synchCall;
			}
			else if(messageSort.Equals(UmlModel.MESSAGE_SORT_ASYNCH_CALL))
			{
				message.MessageSort= MessageSort.asynchCall;
			}
			else if (messageSort.Equals(UmlModel.MESSAGE_SORT_ASYNCH_SIGNAL))
			{
				message.MessageSort= MessageSort.asynchSignal;
			}
			else if(messageSort.Equals(UmlModel.REPLY))
			{
				message.MessageSort= MessageSort.reply;    	
			}
			else if(messageSort.Equals(UmlModel.MESSAGE_SORT_CREATE_MESSAGE))
			{
				message.MessageSort=MessageSort.createMessage;
			}
		}
		
		protected internal bool IsLifelineDestructed(XmlElement interactionElement,string relevantLifelineId)
		{
			bool isDestructredLifelineId=false;
			isDestructredLifelineId=this.modelDocumentInterpreter.IsLifelineDestructed(interactionElement,relevantLifelineId);
			return isDestructredLifelineId;
		}
			
		protected internal ArrayList SortListForVerticalPosition(ArrayList sequenceChartElements)                                        
		{
			ArrayList orderedSequenceChartElements=null;
			SequenceChartElementListSorter elementListSorter=
					new SequenceChartElementListSorter();
			orderedSequenceChartElements=elementListSorter.SortListForVerticalPosition(sequenceChartElements);
			return orderedSequenceChartElements;
		}
		
		protected internal ArrayList SortListForHorizontalPosition(ArrayList sequenceChartElements)                                        
		{
			ArrayList orderedSequenceChartElements=null;
			SequenceChartElementListSorter elementListSorter=
					new SequenceChartElementListSorter();
			orderedSequenceChartElements=elementListSorter.SortListForHorizontalPosition(sequenceChartElements);
			return orderedSequenceChartElements;
		}
	}
}
