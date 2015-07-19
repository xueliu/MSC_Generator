/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 14:13
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Collections;
using System.Drawing;



namespace sequenceChartModel
{
	/// <summary>
	/// Description of BehaviorExecutionSpecification.
	/// </summary>
	public class ExecutionSpecification:SequenceChartElement
	{
		private ArrayList messageSourceEnds;
		private Lifeline coveredLifeline;
		private SequenceChartElementListSorter sorter;
		private bool processingStarted=false;
		
		public ExecutionSpecification(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation)
		{
			messageSourceEnds=new ArrayList();	
			sorter =new SequenceChartElementListSorter();
		}
		
		public ArrayList MessageSourceEnds{
			get{
				return messageSourceEnds;
			}
			set{
				messageSourceEnds=value;
			}
		}
		
		public Lifeline CoveredLifeline{
			get{
				return coveredLifeline;
			}
			set{
				coveredLifeline=value;
			}
		}
		
		public bool ProcessingStarted{
			get{
				return processingStarted;
			}
			set{
				processingStarted=value;
			}
		}
		
		public bool IsMessageEndCovered(MessageEnd relevantMessageEnd)
		{
			bool executionCoversMessageEnd=false;
			
			int executionX=this.Position.X;
			int executionY=this.Position.Y;
			int executionW=this.Dimension.Width;
			int executionH=this.Dimension.Height;
			
			int relevantMessageEndX=relevantMessageEnd.Position.X;
			int relevantMessageEndY=relevantMessageEnd.Position.Y;
			int relevantMessageEndW=relevantMessageEnd.Dimension.Width;
			int relevantMessageEndH=relevantMessageEnd.Dimension.Height;
			
			//The position of a MessageEnd is given in the context to the bounds of the 
			//corresponding Lifeline, hence the Lifeline-position was added to the MessageEnd-position.
			//Although there fails the value of 5, to appoint that a MessageEnd is covered by an corresponding
			//Execution. So there is the Value 6 subducted by the x.coordinate of the Execution 
			//The with of an Execution is only 1, so there is a need to the Value 6 to the width of the Execution-Dimension.
			Rectangle relevantExecutionBounds=new Rectangle(this.Position.X-6,
			                                                this.Position.Y,
			                                                this.Dimension.Width+12,
			                                               	this.Dimension.Height+1);
			executionCoversMessageEnd=relevantExecutionBounds.Contains(relevantMessageEnd.Position);
			return executionCoversMessageEnd;
		}
		
		public bool IsLastCoveringMessageEnd(MessageEnd relevantMessageEnd)
		{
			bool isLastCoveringMessageEnd=false;
			MessageEnd actualLastMessageEnd;
			int messageSourceEndsCount=messageSourceEnds.Count;
			messageSourceEnds= sorter.SortListForVerticalPosition(messageSourceEnds);
			
			if(messageSourceEndsCount>0)
			{
				actualLastMessageEnd=(MessageEnd)messageSourceEnds[messageSourceEndsCount-1];
				
				if(actualLastMessageEnd == relevantMessageEnd)
				{
					isLastCoveringMessageEnd=true;
				}
			}
			
			return isLastCoveringMessageEnd;
		}
		
		
	/*	nicht mehr unbedigt notwendig
	 * public ArrayList CoveredSourcemessageSourceEnds()
		{
			MessageEnd currentMessageEnd;
			MessageEndKind currentMessageEndKind;
			ArrayList coveredSourcemessageSourceEnds=new ArrayList();
			IEnumerator itrmessageSourceEnds=this.messageSourceEnds.GetEnumerator();
			
			while(itrmessageSourceEnds.MoveNext())
			{
				currentMessageEnd=(MessageEnd)itrmessageSourceEnds.Current;
				currentMessageEndKind=currentMessageEnd.MessageEndKind;
				
				if(currentMessageEndKind==MessageEndKind.sourceEnd)
				{
					coveredSourcemessageSourceEnds.Add(currentMessageEnd);	
				}
			}
			
			return coveredSourcemessageSourceEnds;
		}
		
		public Message CoveredReplyMessageToExecution(BehaviorExecutionSpecification oppositeExecution)
		{
			MessageEnd currentMessageEnd;
			Message currentMessage;
			MessageEnd currentOppositeMessageEnd;
			MessageEndKind currentMessageEndKind;
			Message relevantReplyMessage=null;
			bool isCoveredByOppositeExecution=false;
			IEnumerator itrmessageSourceEnds=this.messageSourceEnds.GetEnumerator();
			
			while(itrmessageSourceEnds.MoveNext()&&(relevantReplyMessage==null))
			{
				currentMessageEnd=(MessageEnd)itrmessageSourceEnds.Current;
				currentMessageEndKind=currentMessageEnd.MessageEndKind;
				
				if(currentMessageEndKind==MessageEndKind.sourceEnd)
				{
					currentMessage=currentMessageEnd.CorrespondingMessage;
					
					currentOppositeMessageEnd=currentMessage.GetOppositeMessageEnd(currentMessageEnd);
					isCoveredByOppositeExecution=oppositeExecution.IsMessageEndCovered(currentOppositeMessageEnd);				
					
					if(isCoveredByOppositeExecution)
					{
						relevantReplyMessage=currentMessage;
					}
				}
			}	
			return relevantReplyMessage;
		}*/
	}
}
