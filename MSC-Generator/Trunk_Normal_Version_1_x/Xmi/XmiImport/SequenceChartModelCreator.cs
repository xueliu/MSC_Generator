/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 12:43
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Drawing;
using System.Xml;
using System.Collections;
using xmi;
using sequenceChartModel;

namespace xmiImport
{
	/// <summary>
	/// Description of SequenceChartModelCreator.
	/// </summary>
	
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
		
		public Interaction CreateInteractionForInteractionElement(XmlElement interactionElement)
		{
			Interaction interaction=null;
			XmlElement diagramElement=diDocumentInterpreter.GetContainerDiagramElement();
			interaction=CreateInteraction(interactionElement);
			ArrayList lifelines=CreateLifelines(interactionElement,diagramElement);
			interaction.Lifelines=lifelines;
			CreateExecutionsForLifelines(lifelines,diagramElement);
			CreateMessageEndsForLifelines(lifelines,diagramElement,interaction);
			return interaction;
		}
		
		protected Interaction CreateInteraction(XmlElement interactionElement)
		{
			string interactionName=interactionElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			string interactionId=interactionElement.GetAttribute(UmlModel.XMI_IDREF_ATTR_COMPLETE_NAME);
			Interaction newInteraction=new Interaction(ZERO_POSITION,interactionId,interactionElement);
			newInteraction.Name=interactionName;
			return newInteraction;
		}
		
		protected ArrayList CreateLifelines(XmlElement interactionElement,XmlElement diagramElement)
		{
			XmlElement currentLifelineElement;
			Lifeline currentLifeline;
			string currentLifelineName;
			string currentLifelineId;
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
				lifelines.Add(currentLifeline);
			}
			
			SortListForHorizontalPosition(lifelines);
			return lifelines;
		}
		
		protected void CreateExecutionsForLifelines(ArrayList lifelines,XmlElement diagramElement)
		{
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			Lifeline currentLifeline;
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				CreateExecutionsForLifeline(currentLifeline,diagramElement);
			}
		}
		
		protected void CreateExecutionsForLifeline(Lifeline lifeline,XmlElement diagramElement)
		{
			string lifelineId=lifeline.XmiId;
			XmlElement lifelineElement=lifeline.XmlRepresentation;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			ArrayList executions=new ArrayList();
			ArrayList executionElements=modelDocumentInterpreter.GetBehaviorExecutionSpecElementsForLifeline(lifelineElement);
			IEnumerator itrExecutionElements=executionElements.GetEnumerator();
			XmlElement currentExecutionElement;
			BehaviorExecutionSpecification currentNewExecution;
			Point currentExecutionPosition;
			string currentExecutionId;
			
			while(itrExecutionElements.MoveNext())
			{
				currentExecutionElement=(XmlElement)itrExecutionElements.Current;
				currentExecutionPosition=diDocumentInterpreter.GetBehaviorExecutionSpecPosition(diagramElement,currentExecutionElement);
				currentExecutionId=currentExecutionElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				currentNewExecution=new BehaviorExecutionSpecification(currentExecutionPosition,currentExecutionId,null);
				executionElements.Add(currentNewExecution);
			}
			
			this.SortListForVerticalPosition(executionElements);
			lifeline.BehaviorExecutionSpecifications=executionElements;
		}
		
		protected void CreateMessages(Interaction interaction,XmlElement diagramElement)
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
			
			this.SortListForVerticalPosition(messages);
			interaction.Messages=messages;
		}
		
		protected void CreateMessageEndsForLifelines(ArrayList lifelines,XmlElement diagramElement,Interaction interaction)
		{
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			Lifeline currentLifeline;
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				CreateMessageEndsForLifeline(currentLifeline,diagramElement,interaction);
			}
		}
		
		protected void CreateMessageEndsForLifeline(Lifeline lifeline,XmlElement diagramElement,Interaction interaction)
		{
			ArrayList relevantMessageEnds;
			XmlElement currentMessageEndElement;
			MessageEnd currentMessageEnd;
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
				relevantMessageEnds.Add(currentMessageEnd);
			}
			
			this.SortListForVerticalPosition(relevantMessageEnds);
			lifeline.MessageEnds=relevantMessageEnds;
		}
		
		protected void ConnectMessageEndsToMessage(ArrayList relevantMessageEnds,Interaction interaction)
		{
			IEnumerator itrRelevantMessageEnds=relevantMessageEnds.GetEnumerator();
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
		
		protected void ConnectMessageEndToMessage(MessageEnd messageEnd,Message message)
		{
			XmlElement messageElement=message.XmlRepresentation;
			XmlElement messageEndElement=messageEnd.XmlRepresentation;
			string messageElementId=messageElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string messageReceiveElementId=messageElement.GetAttribute(UmlModel.RECEIVE_EVENT_ATTR_NAME);
			string messageSendEventId=messageElement.GetAttribute(UmlModel.SEND_SIGNAL_EVENT);
			string messageEndElementId=messageEndElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			
			messageEnd.CorrespondingMessage=message;					
			
			if(messageElementId.Equals(messageReceiveElementId))
			{
			   message.DestinationMessageEnd=messageEnd;	
			}
			else if(messageElementId.Equals(messageSendEventId))
			{
				message.SourceMessageEnd=messageEnd;
			}
		}
			
		protected Message GetMessageForMessageElement(XmlElement relevantMessageElement,Interaction interaction)
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
		
		
		protected void AddMessageSort(Message message, string messageSort)
		{
			if(messageSort.Equals(UmlModel.MESSAGE_SORT_ASYNCH_CALL))
			{
				message.MessageSort= MessageSort.asynchCall;
			}
			else if(messageSort.Equals(UmlModel.MESSAGE_SORT_SYNCH_CALL))
			{
				message.MessageSort= MessageSort.syncCall;
			}
			else if (messageSort.Equals(UmlModel.MESSAGE_SORT_ASYNCH_SIGNAL))
			{
				message.MessageSort= MessageSort.asynchSignal;
			}
		}
			
		protected void SortListForVerticalPosition(ArrayList sequenceChartElements)                                        
		{
			SequenceChartElement currentSequenceChartElement;
			SequenceChartElement relevantSequenceChartElement=null;
			int indexRelevantSequenceChartElement=0;
			int smallestY=int.MaxValue;
			int currentSequenceChartElementY;
			int sequenceChartElementsCount=sequenceChartElements.Count;
			Lifeline arrangedSequenceChartElement=new Lifeline(new Point(-1,-1),"",null);
			ArrayList orderedSequenceChartElements=new ArrayList();
			
			for(int index1=0;index1<sequenceChartElementsCount;index1++)
			{
				for(int index2=0;index2<sequenceChartElementsCount;index2++)
				{
					currentSequenceChartElement=(SequenceChartElement)sequenceChartElements[index2];
					currentSequenceChartElementY=currentSequenceChartElement.Position.Y;
						
					if(currentSequenceChartElementY<smallestY)
					{
						relevantSequenceChartElement=currentSequenceChartElement;
						smallestY=currentSequenceChartElement.Position.Y;
						indexRelevantSequenceChartElement=index2;
					}
				}
				
				orderedSequenceChartElements.Add(relevantSequenceChartElement);
				sequenceChartElements.Insert(indexRelevantSequenceChartElement,arrangedSequenceChartElement);	
			}
			
			sequenceChartElements=orderedSequenceChartElements;
			orderedSequenceChartElements=null;
		}
		
		protected void SortListForHorizontalPosition(ArrayList sequenceChartElements)                                        
		{
			SequenceChartElement currentSequenceChartElement;
			SequenceChartElement relevantSequenceChartElement=null;
			int indexRelevantSequenceChartElement=0;
			int smallestX=int.MaxValue;
			int currentSequenceChartElementX;
			int sequenceChartElementsCount=sequenceChartElements.Count;
			Lifeline arrangedSequenceChartElement=new Lifeline(new Point(-1,-1),"",null);
			ArrayList orderedSequenceChartElements=new ArrayList();
			
			for(int index1=0;index1<sequenceChartElementsCount;index1++)
			{
				for(int index2=0;index2<sequenceChartElementsCount;index2++)
				{
					currentSequenceChartElement=(SequenceChartElement)sequenceChartElements[index2];
					currentSequenceChartElementX=currentSequenceChartElement.Position.Y;
						
					if(currentSequenceChartElementX<smallestX)
					{
						relevantSequenceChartElement=(SequenceChartElement)currentSequenceChartElement;
						smallestX=currentSequenceChartElement.Position.X;
						indexRelevantSequenceChartElement=index2;
					}
				}
				
				orderedSequenceChartElements.Add(relevantSequenceChartElement);
				sequenceChartElements.Insert(indexRelevantSequenceChartElement,arrangedSequenceChartElement);	
			}
			sequenceChartElements=orderedSequenceChartElements;
			orderedSequenceChartElements=null;
		}
	}
}
