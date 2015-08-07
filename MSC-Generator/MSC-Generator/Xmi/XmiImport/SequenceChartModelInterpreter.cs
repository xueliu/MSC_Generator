/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 21.12.2007
 * Zeit: 14:34
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using sequenceChartModel;
using System.Xml;
using System.Collections;
using System.Drawing;

namespace xmiImport
{
	/// <summary>
	/// Description of SequenceChartModelInterpreter.
	/// </summary>
	/// 
	
	public struct LifelineIdProcessEntryIdPair
	{
		public string lifelineId;
		public string processEntryId;
		
		public LifelineIdProcessEntryIdPair(string lifelineId,string processEntryId)
		{
			this.lifelineId=lifelineId;
			this.processEntryId=processEntryId;
		}
	}
	
	public class SequenceChartModelInterpreter
	{
		private Interaction toInterpretInteraction;
		private ArrayList workedMessageEnds;
		private ArrayList workedExecutionSpecs;
		private ArrayList lifelineIdProcessEntryIdPairs;
		private EditorEntryCreator entryCreator;
		private const string ACTIVATION="Activation";
		private const string PROJECT_DEFAULT_NAME="ProjectName_";
		private int projectDefaultNameCount=1;
		private const string DOWN_SLASH="_";
		private const string SPACE_STRING=" ";
		private const string SIGNAL_STEREO_TYPE="<<signal>>";
		private ArrayList lifelineNames;
		private SequenceChartElementListSorter sorter;
		
		public SequenceChartModelInterpreter()
		{
			workedMessageEnds=new ArrayList();
			lifelineIdProcessEntryIdPairs=new ArrayList();
			workedExecutionSpecs=new ArrayList();
			entryCreator=new EditorEntryCreator();
			lifelineNames=new ArrayList();
			sorter=new SequenceChartElementListSorter();
		}
		
		public Interaction ToInterpretInteraction{
			
			get{
				return this.toInterpretInteraction;
			}
			
			set{
				this.toInterpretInteraction=value;
			}
		}
		
		public ArrayList LifelineIdProcessEntryIdPairs{
			
			get{
				return this.lifelineIdProcessEntryIdPairs;
			}
		}
		
		public EditorEntryCreator EntryCreator{
			get{
				return this.entryCreator;
			}
			set{
				entryCreator=value;
			}
		}
		
		public ArrayList WorkedExecutionSpecs{
			get{
				return workedExecutionSpecs;
			}
		}
		
		public ArrayList WorkedMessageEnds{
			get{
				return workedMessageEnds;
			}
		}
		
		public int ProjectDefaultNameCount{
			get{
				return projectDefaultNameCount;
			}
		}
		
		
		public ArrayList InterpretSequenceChartModel(Interaction toInterpretInteraction)
		{
			ArrayList interactionEditorEntry;
			this.toInterpretInteraction=toInterpretInteraction;
			InterpretInteraction(toInterpretInteraction);
			ArrayList lifelines=this.toInterpretInteraction.Lifelines;
			InterpretLifelines(lifelines);
			//InterpretElementsOfLifelines(lifelines);
			interactionEditorEntry=this.entryCreator.EditorContent;
			InterpretOccurrenceSpecifications(toInterpretInteraction);
			InterpretDestructionEvents(lifelines);
			return interactionEditorEntry;
		}
		
		protected internal void InterpretInteraction(Interaction interaction)
		{
			string interactionName=interaction.Name;
			this.entryCreator.InitEditorContent(interactionName);
		}
		
		protected internal void InterpretLifelines(ArrayList lifelines)
		{
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			Lifeline currentLifeline;
			bool isCurrentLifelineCreatedByMessage;
			string currentLifelineName;
			string currentLifelineId;
			string currentProcessEntryId;
			
			LifelineIdProcessEntryIdPair currentLifelineIdProcessEntryIdPair;
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				currentLifelineId=currentLifeline.XmiId;
				currentProcessEntryId=this.CreateProcessEntryId(currentLifeline);
				currentLifelineName=currentLifeline.Name;
				
				isCurrentLifelineCreatedByMessage=this.IsLifelineCreatedByMessage(currentLifeline);
				
				if(isCurrentLifelineCreatedByMessage)
				{
					entryCreator.CreateDummyProcessEntry(currentProcessEntryId);
				}
				else
				{
					entryCreator.CreateProcessEntry(currentLifelineName,currentProcessEntryId);
				}
				
				
				currentLifelineIdProcessEntryIdPair=new LifelineIdProcessEntryIdPair(currentLifelineId,currentProcessEntryId);
				lifelineIdProcessEntryIdPairs.Add(currentLifelineIdProcessEntryIdPair);
			}	
		}
		
		//ändern
		/*protected internal void InterpretElementsOfLifelines(ArrayList lifelines)
		{
			
			//Sorts the Elements that cover the Lifeline after there appearing in the Diagram
			ArrayList elementsOfLifelines=sorter.SortElementsOfLifelines(lifelines);
			IEnumerator itrElementsOfLifelines=elementsOfLifelines.GetEnumerator();
			SequenceChartElement currentElement;
			BehaviorExecutionSpecification currentExecutionSpec;
			MessageEnd currentMessageEnd;
			MessageEndKind currentMessageEndKind;
			Lifeline currentLifeline;
			
			//Debug
			int index=0;
			Message currentMessage;
			string currentMessageName;
			
			while(itrElementsOfLifelines.MoveNext())
			{
				currentElement=(SequenceChartElement)itrElementsOfLifelines.Current;
				
				if(currentElement is BehaviorExecutionSpecification)
				{
					currentExecutionSpec =(BehaviorExecutionSpecification)currentElement;
					
					if(!(this.workedExecutionSpecs.Contains(currentExecutionSpec)))
					{
						currentLifeline=currentExecutionSpec.CoveredLifeline;
						InterpretSourceMessageEndsOfExecution(currentExecutionSpec,currentLifeline);						
					}
				}
				else if(currentElement is MessageEnd)
				{
					currentMessageEnd=(MessageEnd)currentElement;
					currentMessageEndKind= currentMessageEnd.MessageEndKind;
					
					//Debug
					currentMessage=currentMessageEnd.CorrespondingMessage;
					currentMessageName=currentMessage.Name;
					
					
					if(currentMessageEndKind.Equals(MessageEndKind.sourceEnd) && !(this.workedMessageEnds.Contains(currentMessageEnd)))
					{
						currentLifeline=currentMessageEnd.CoveredLifeline;
						InterpretMessageSourceEnd(currentMessageEnd,currentLifeline);
					}
				}
				index++;
			}
		}*/
		
		
		
		private ArrayList GetOccurrenceSpecificationsOfInteraction(Interaction relevantInteraction)
		{
			ArrayList occurrenceSpecifications= new ArrayList();
			IEnumerator itrMessageOccurrenceSpecs;
			MessageEnd  currentMessageEnd;
			
			if(relevantInteraction.ExecutionOccurrenceSpecs.Count>0)
			{
				occurrenceSpecifications.AddRange(relevantInteraction.ExecutionOccurrenceSpecs);
			}
			
			if(relevantInteraction.MessageOccurrenceSpecs.Count>0)
			{
				itrMessageOccurrenceSpecs=relevantInteraction.MessageOccurrenceSpecs.GetEnumerator();
				
				while(itrMessageOccurrenceSpecs.MoveNext())
				{
					currentMessageEnd=(MessageEnd)itrMessageOccurrenceSpecs.Current;
				
					if(currentMessageEnd.MessageEndKind == MessageEndKind.sourceEnd)
					{
						occurrenceSpecifications.Add(currentMessageEnd);
					}
				}
			}
			return occurrenceSpecifications;
		}
			
			
		
		
		protected internal void InterpretOccurrenceSpecifications(Interaction relevantInteraction)
		{
			SequenceChartElement currentOccurrenceSpec;
			SequenceChartElement nextOccurrenceSpec;
			ArrayList occurrenceSpecifications;
			int occurrenceSpecificationsCount;
			
			occurrenceSpecifications=GetOccurrenceSpecificationsOfInteraction(relevantInteraction);
			occurrenceSpecifications=sorter.SortOccurrenceSpecifications(occurrenceSpecifications);
			occurrenceSpecificationsCount=occurrenceSpecifications.Count;
			
			for(int count=0;count<occurrenceSpecificationsCount;count++)
			{
				currentOccurrenceSpec=(SequenceChartElement)occurrenceSpecifications[count];
				nextOccurrenceSpec=null;
				
				if(count<occurrenceSpecificationsCount-1)
				{
					nextOccurrenceSpec=	(SequenceChartElement)occurrenceSpecifications[count+1];
				}
				
				if(currentOccurrenceSpec is MessageEnd)
				{
					if(((MessageEnd)currentOccurrenceSpec).MessageEndKind == MessageEndKind.sourceEnd)
					{
						this.InterpretMessageOccurrenceSpec((MessageEnd)currentOccurrenceSpec);
					}
				}
				else if(currentOccurrenceSpec is ExecutionOccurrenceSpecification)
				{
					this.InterpretExecutionOccurrenceSpecification((ExecutionOccurrenceSpecification)currentOccurrenceSpec,nextOccurrenceSpec);
				}
			}	
		}
			
		protected internal void InterpretExecutionOccurrenceSpecification(ExecutionOccurrenceSpecification executionOccurrenceSpec,
		                                                                  SequenceChartElement nextOccurrenceSpec)
		{
			Lifeline coveredLifeline=executionOccurrenceSpec.CoveredLifeline;
			string coveredLifelineId = coveredLifeline.XmiId;
			string processEntryId=this.GetProcessEntryIdForLifelineId(coveredLifelineId);

			if(executionOccurrenceSpec.SpecificationKind== ExecutionOccurrenceSpecKind.START)
			{
				// >>>>>> Creates an RegionBegin-entry that represents only an Activation
				// >>>>>> there is no desicion for Coregions and Suspensions
			
				if(nextOccurrenceSpec is MessageEnd)
				{
					this.entryCreator.CreateRegionBeginEditorEntryNoWordWrap(processEntryId,ACTIVATION);
				}
				else
				{
					this.entryCreator.CreateRegionBeginEditorEntry(processEntryId,ACTIVATION);
				}
			}
			else if(executionOccurrenceSpec.SpecificationKind== ExecutionOccurrenceSpecKind.FINISH)
			{
				this.entryCreator.CreateRegionEndEditorEntry(processEntryId);
			}
		}
		
		protected internal void InterpretMessageOccurrenceSpec(MessageEnd sourceMessageOccurrenceSpec)
		{
			Message connectedMessage;
			MessageEnd destinationMessageOccurrenceSpec;
			ExecutionSpecification coveredExecutionSpec;
			Lifeline sourceLifeline;
			string sourceProcessId;
			Lifeline destinationLifeline;
			string destinationProcessId;
			bool isLastMessageEndOfLifeline=false;
			
			connectedMessage=sourceMessageOccurrenceSpec.CorrespondingMessage;
			destinationMessageOccurrenceSpec=connectedMessage.DestinationMessageEnd;
			sourceLifeline=sourceMessageOccurrenceSpec.CoveredLifeline;
			sourceProcessId=this.GetProcessEntryIdForLifelineId(sourceLifeline.XmiId);
			destinationLifeline=destinationMessageOccurrenceSpec.CoveredLifeline;
			destinationProcessId=this.GetProcessEntryIdForLifelineId(destinationLifeline.XmiId);
			
			string messageName=connectedMessage.Name; 
			
			coveredExecutionSpec=sourceMessageOccurrenceSpec.CoveredExecutionSpecification;
			
			if(coveredExecutionSpec!=null)
			{
				isLastMessageEndOfLifeline=coveredExecutionSpec.IsLastCoveringMessageEnd(sourceMessageOccurrenceSpec);
			}
			
		
			if((isLastMessageEndOfLifeline==true)&&(connectedMessage.MessageSort== MessageSort.reply))
			{
				this.CreateMessageEditorEntry(connectedMessage,sourceProcessId,destinationProcessId,false);
			}
			else
			{
				this.CreateMessageEditorEntry(connectedMessage,sourceProcessId,destinationProcessId,true);
			}
		}
		
		
		
		//kann eigentlich weg		
		/*protected internal void InterpretMessageSourceEnd(MessageEnd relevantMessageEnd,Lifeline relevantLifeline)
		{
			ArrayList messageEnds=relevantLifeline.MessageEnds;
			IEnumerator itrMessageEnds=messageEnds.GetEnumerator();
			BehaviorExecutionSpecification currentCoveringExecution;
			Message correspondingMessage;
			MessageEndKind relevantMessageEndKind;
			bool messageEndIsWorked;
			bool executionSpecIsWorked;
			
			messageEndIsWorked=this.workedMessageEnds.Contains(relevantMessageEnd);
			relevantMessageEndKind=relevantMessageEnd.MessageEndKind;
				
			if((relevantMessageEndKind.Equals(MessageEndKind.sourceEnd))&&(!messageEndIsWorked))
			{
				currentCoveringExecution=relevantMessageEnd.GetExecutionForMessageEnd();
					
				if(currentCoveringExecution==null)
				{
					correspondingMessage=relevantMessageEnd.CorrespondingMessage;
					InterpretDestinationMessageEnd(relevantMessageEnd,correspondingMessage,currentCoveringExecution);
					this.workedMessageEnds.Add(relevantMessageEnd);
				}
				else
				{
					executionSpecIsWorked=this.workedExecutionSpecs.Contains(currentCoveringExecution);
						
					if(!executionSpecIsWorked)
					{
						InterpretSourceMessageEndsOfExecution(currentCoveringExecution,relevantLifeline);
					}
					this.workedExecutionSpecs.Add(currentCoveringExecution);
				}
			}	
		}
		
		//kann eigentlich weg
		protected internal void InterpretSourceMessageEndsOfExecution(BehaviorExecutionSpecification coveringExecution,
		                                                              Lifeline lifeline)
		{
			MessageEnd currentSourceMessageEnd;
			Message correspondingMessage;
			string lifelineId=lifeline.XmiId;
			string processEntryId=this.GetProcessEntryIdForLifelineId(lifelineId);
			ArrayList coveredSourceMessageEnds=coveringExecution.CoveredSourceMessageEnds();
			IEnumerator itrCoveredSourceMessageEnds=coveredSourceMessageEnds.GetEnumerator();
			this.entryCreator.CreateRegionBeginEditorEntry(processEntryId,ACTIVATION);
			coveringExecution.ProcessingStarted=true;
			
			while(itrCoveredSourceMessageEnds.MoveNext())
			{
				currentSourceMessageEnd=(MessageEnd)itrCoveredSourceMessageEnds.Current;
				
				
				correspondingMessage=currentSourceMessageEnd.CorrespondingMessage;
				
				InterpretDestinationMessageEnd(currentSourceMessageEnd,correspondingMessage,coveringExecution);
			}
			
			this.entryCreator.CreateRegionEndEditorEntry(processEntryId);
			this.workedExecutionSpecs.Add(coveringExecution);
		}
		
		// kann eigentlich weg
		protected internal void InterpretSourceMessageEndsOfExecutionWithoutRegionEntries(BehaviorExecutionSpecification coveringExecution,
		                                                                                  Lifeline sourceLifeline)
		{
			MessageEnd currentSourceMessageEnd;
			MessageEnd currentDestinationMessageEnd;
			Lifeline  destinationLifeline;
			Message correspondingMessage;
			BehaviorExecutionSpecification destinationExecutionSpec=null;
			bool processingStartedDestinationExecutionSpec=false;
			int destinationLifelineIndex;
			int sourceLifelineIndex;
			string destinationProcessEntryId;
			string destinationLifelineId;
			MessageSort correspondingMessageSort;
			string sourceLifelineId=sourceLifeline.XmiId;
			string sourceProcessEntryId=this.GetProcessEntryIdForLifelineId(sourceLifelineId);
			ArrayList coveredSourceMessageEnds=coveringExecution.CoveredSourceMessageEnds();
			IEnumerator itrCoveredSourceMessageEnds=coveredSourceMessageEnds.GetEnumerator();
			coveringExecution.ProcessingStarted=true;
				
			while(itrCoveredSourceMessageEnds.MoveNext())
			{		
				currentSourceMessageEnd=(MessageEnd)itrCoveredSourceMessageEnds.Current;
				correspondingMessage=currentSourceMessageEnd.CorrespondingMessage;
				currentDestinationMessageEnd=correspondingMessage.DestinationMessageEnd;
				destinationLifeline=currentDestinationMessageEnd.CoveredLifeline;
				//sourceLifelineIndex=toInterpretInteraction.Lifelines.IndexOf(sourceLifeline);
				//destinationLifelineIndex=toInterpretInteraction.Lifelines.IndexOf(destinationLifeline);
				destinationExecutionSpec=currentDestinationMessageEnd.GetExecutionForMessageEnd();
				
				if(destinationExecutionSpec!=null)
				{
					processingStartedDestinationExecutionSpec=destinationExecutionSpec.ProcessingStarted;
				}
				
				
				if((!processingStartedDestinationExecutionSpec)&&(destinationExecutionSpec!=null))
				{
					InterpretDestinationMessageEnd(currentSourceMessageEnd,correspondingMessage,coveringExecution);
				}
				else
				{
					destinationLifelineId=destinationLifeline.XmiId;
					destinationProcessEntryId=this.GetProcessEntryIdForLifelineId(destinationLifelineId);
					correspondingMessageSort=correspondingMessage.MessageSort;
					CreateMessageEditorEntry(correspondingMessage,sourceProcessEntryId,destinationProcessEntryId);
					this.workedMessageEnds.Add(currentSourceMessageEnd);
				}
				
				this.workedExecutionSpecs.Add(coveringExecution);
			}
		}
		
		//kann eigentlich weg
		protected internal void InterpretDestinationMessageEnd(MessageEnd sourceMessageEnd,Message relevantMessage,BehaviorExecutionSpecification sourceExecution)
		{
			bool destinationMessageEndIsLastEndOfExecution=false;
			MessageEnd destinationMessageEnd=relevantMessage.GetOppositeMessageEnd(sourceMessageEnd);
			
			Lifeline destinationLifeline=destinationMessageEnd.CoveredLifeline;
			string destinationLifelineId=destinationLifeline.XmiId;
			string destinationProcessEntryId=GetProcessEntryIdForLifelineId(destinationLifelineId);
			Lifeline sourceLifeline=sourceMessageEnd.CoveredLifeline;
			string sourceLifelineId=sourceLifeline.XmiId;
			string sourceProcessEntryId=GetProcessEntryIdForLifelineId(sourceLifelineId);
			string relevantMessageName=relevantMessage.Name;
			BehaviorExecutionSpecification destinationExecution=destinationMessageEnd.GetExecutionForMessageEnd();
			
			if(destinationExecution==null)
			{
				CreateMessageEditorEntry(relevantMessage,sourceProcessEntryId,destinationProcessEntryId);
			}
			else
			{
				ArrayList sourceEndsDestinationExecution=destinationExecution.CoveredSourceMessageEnds();
				int positionOfDestinationMessageEnd=destinationExecution.MessageEnds.IndexOf(destinationMessageEnd);
				int positionOfLastMessageEnd=destinationExecution.MessageEnds.Count-1;
				ArrayList messageEndsDestinationExecution=destinationExecution.MessageEnds;
				MessageEnd lastMessageEndOfDestinationExecution=(MessageEnd)
											messageEndsDestinationExecution[messageEndsDestinationExecution.Count-1];
				
				if(positionOfDestinationMessageEnd==positionOfLastMessageEnd)
				{
					destinationMessageEndIsLastEndOfExecution=true;
				}	
				
				if((sourceEndsDestinationExecution.Count==0)||(destinationExecution.ProcessingStarted&&destinationMessageEndIsLastEndOfExecution))
				{
					entryCreator.CreateRegionBeginEditorEntryNoWordWrap(destinationProcessEntryId,ACTIVATION);
					CreateMessageEditorEntry(relevantMessage,sourceProcessEntryId,destinationProcessEntryId);
					entryCreator.CreateRegionEndEditorEntry(destinationProcessEntryId);
					
				}
				else if(destinationExecution.ProcessingStarted&&(!destinationMessageEndIsLastEndOfExecution))
				{
					CreateMessageEditorEntry(relevantMessage,sourceProcessEntryId,destinationProcessEntryId);
				}
				else if((sourceEndsDestinationExecution.Count>0)&&(!destinationExecution.ProcessingStarted))
				{
					entryCreator.CreateRegionBeginEditorEntryNoWordWrap(destinationProcessEntryId,ACTIVATION);
					
					CreateMessageEditorEntry(relevantMessage,sourceProcessEntryId,destinationProcessEntryId);
					InterpretSourceMessageEndsOfExecutionWithoutRegionEntries(destinationExecution,destinationLifeline);
					
					if(lastMessageEndOfDestinationExecution.MessageEndKind == MessageEndKind.sourceEnd)
					{
						entryCreator.CreateRegionEndEditorEntry(destinationProcessEntryId);
					}
				}
				this.workedMessageEnds.Add(sourceMessageEnd);
				this.workedExecutionSpecs.Add(destinationExecution);
			}
		}*/
		
		protected internal string CreateMessageEditorEntry(Message message, string sourceProcessEntryId,string destinationProcessEntryId, bool isWordWrap)
		{
			MessageSort messageSort=message.MessageSort;
			string messageName=message.Name;
			string createdEditorEntry="";
			
			if(messageSort==MessageSort.synchCall)
			{
				if(isWordWrap==true)
				{
					createdEditorEntry=entryCreator.CreateSynchronCallEditorEntry(messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
				else
				{
					createdEditorEntry=entryCreator.CreateSynchronCallEditorEntryNoWordWrap(messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
			}
			else if(messageSort==MessageSort.asynchCall)
			{
				if(isWordWrap==true)
				{
					createdEditorEntry=entryCreator.CreateAsynchronCallEditorEntry(messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
				else
				{
					createdEditorEntry=entryCreator.CreateAsynchronCallEditorEntryNoWordWrap(messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
			}
			else if(messageSort==MessageSort.reply)
			{
				if(isWordWrap==true)
				{
					createdEditorEntry=entryCreator.CreateReplyMessageEditorEntry(messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
				else
				{
					createdEditorEntry=entryCreator.CreateReplyMessageEditorEntryNoWordWrap(messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
			}	
			else if (messageSort==MessageSort.asynchSignal)
			{
				if(isWordWrap==true)
				{
					createdEditorEntry=entryCreator.CreateAsynchronCallEditorEntry(SIGNAL_STEREO_TYPE+SPACE_STRING+messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
				else
				{
					createdEditorEntry=entryCreator.CreateAsynchronCallEditorEntryNoWordWrap(SIGNAL_STEREO_TYPE+SPACE_STRING+messageName,sourceProcessEntryId,destinationProcessEntryId);
				}
			}
			else if(messageSort==MessageSort.createMessage)
			{
				MessageEnd destinationEnd=message.DestinationMessageEnd;
				Lifeline tiedLifeline=destinationEnd.CoveredLifeline;
				string processName=tiedLifeline.Name;
				createdEditorEntry=
							entryCreator.CreateCreateMessageEditorEntry(sourceProcessEntryId,destinationProcessEntryId,messageName,processName);
			}
			return createdEditorEntry;
		}
		
		protected internal string GetProcessEntryIdForLifelineId(string relevantLifelineId)
		{
			string foundProcessEntryId="";
			bool processEntryIdNotFound=true;
			IEnumerator itrIdPairs=this.lifelineIdProcessEntryIdPairs.GetEnumerator();
			LifelineIdProcessEntryIdPair currentIdPair;
			string currentLifelineId;
			
			while(itrIdPairs.MoveNext()&&processEntryIdNotFound)
			{
				currentIdPair=(LifelineIdProcessEntryIdPair)itrIdPairs.Current;
				currentLifelineId=currentIdPair.lifelineId;
				
				if(currentLifelineId.Equals(relevantLifelineId))
				{
					foundProcessEntryId=currentIdPair.processEntryId;
					processEntryIdNotFound=false;
				}
			}
			return foundProcessEntryId;
		}
		
		protected internal void InterpretDestructionEvents(ArrayList lifelines)
		{
			Lifeline currentLifeline;
			bool isCurrentLifelineDestructed;
			string currentProcessId;
			string lifelineId;
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				isCurrentLifelineDestructed=currentLifeline.IsDestructed;
				
				if(isCurrentLifelineDestructed)
				{
					lifelineId=currentLifeline.XmiId;
					currentProcessId=this.GetProcessEntryIdForLifelineId(lifelineId);
					this.entryCreator.CreateDestructionEventEditorEntry(currentProcessId);
				}
			}
		}
		
		protected internal string AppearanceNumberOfLifelineName(string relevantLifelineName)
		{
			string appearanceNumber="";
			int appearanceNumberInt=0;
			string currentLifelineName;
			relevantLifelineName.Trim();
			IEnumerator itrLifelineNames=lifelineNames.GetEnumerator();
			
			while(itrLifelineNames.MoveNext())
			{
				currentLifelineName=(String)itrLifelineNames.Current;
				
				if(relevantLifelineName.Equals(currentLifelineName))
				{
					appearanceNumberInt++;
				}
			}
			
			appearanceNumberInt++;
			appearanceNumber=Convert.ToString(appearanceNumberInt);
			return appearanceNumber;
		}
		
		protected internal bool IsLifelineCreatedByMessage(Lifeline relevantLifeline)
		{
			bool isLifelineCreatedByMessage=false;
			MessageEnd currentDestinationMessageEnd;
			Message currentCorrespondingMessage;
			MessageSort currentCorrespondingMessageSort;
			ArrayList destinationEndsOfLifeline=relevantLifeline.GetConnectedDestinationMessageEnds();
			IEnumerator itrDestinationEndsOfLifeline=destinationEndsOfLifeline.GetEnumerator();
			
			while((itrDestinationEndsOfLifeline.MoveNext())&&(!isLifelineCreatedByMessage))
			{
				currentDestinationMessageEnd=(MessageEnd)itrDestinationEndsOfLifeline.Current;
				currentCorrespondingMessage=currentDestinationMessageEnd.CorrespondingMessage;
				currentCorrespondingMessageSort= currentCorrespondingMessage.MessageSort;
				
				if(currentCorrespondingMessageSort.Equals(MessageSort.createMessage))
				{
					isLifelineCreatedByMessage=true;	
				}
			}
			return isLifelineCreatedByMessage;
		}
		
		protected internal string CreateProcessEntryId(Lifeline lifeline)
		{
			string newProcessEntryId="";
			string lifelineName=lifeline.Name;
			
			if(lifelineName==null)
			{
				string defaultProjectNumber=Convert.ToString(projectDefaultNameCount);
				newProcessEntryId=PROJECT_DEFAULT_NAME+defaultProjectNumber;
				projectDefaultNameCount++;
			}
			else
			{
				string appearanceNumber=this.AppearanceNumberOfLifelineName(lifelineName);
				newProcessEntryId=lifelineName+DOWN_SLASH+appearanceNumber;
				this.lifelineNames.Add(lifelineName);
			}
			
			return newProcessEntryId;
		}
	}
}
