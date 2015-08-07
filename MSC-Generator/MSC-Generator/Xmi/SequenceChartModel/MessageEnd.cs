/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 11:53
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;
using System.Collections;

namespace sequenceChartModel
{
	public enum MessageEndKind
	{	
		sourceEnd,
		destinationEnd
	}
	
	public enum EventKind
	{
		sendOperationEvent,
		receiveOperationEvent,
		executionEvent
	}
	
	/// <summary>
	/// Description of MessageEnd.
	/// </summary>
	public class MessageEnd:SequenceChartElement
	{
		private Message correspondingMessage;
		private MessageEndKind messageEndKind;
		private Lifeline coveredLifeline;
		private EventKind associatedEventKind;
		private ExecutionSpecification coveredExecutionSpecification;
		
		public MessageEnd(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){}
		
		public Message CorrespondingMessage{
			get{
				return correspondingMessage;
			}
			set{
				correspondingMessage=value;
			}
		}
		
		public ExecutionSpecification CoveredExecutionSpecification{
			get{
				return coveredExecutionSpecification;
			}
			set{
				coveredExecutionSpecification=value;
			}
		}
		
		public MessageEndKind MessageEndKind{
			get{
				return messageEndKind;
			}
			set{
				messageEndKind=value;
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
		
		public EventKind AssociatedEventKind{
			get{
				return associatedEventKind;
			}
			set{
				associatedEventKind=value;
			}
		}
		
		
		public ExecutionSpecification GetExecutionForMessageEnd()
		{
			ExecutionSpecification coveringExecution=null;
			
			if(this.CoveredLifeline!=null)
			{
				ExecutionSpecification currentExecution;
				bool executionIsCoveringMessageEnd=false;
				ArrayList executionsOfLifeline=this.CoveredLifeline.ExecutionSpecifications;
				IEnumerator itrExecutionsOfLifeline=executionsOfLifeline.GetEnumerator();
				
				while(itrExecutionsOfLifeline.MoveNext()&&(coveringExecution==null))
				{
					currentExecution=(ExecutionSpecification)itrExecutionsOfLifeline.Current;
					executionIsCoveringMessageEnd=currentExecution.IsMessageEndCovered(this);
					
					if(executionIsCoveringMessageEnd)
					{
						coveringExecution=currentExecution;
					}
				}
			}
			
			return coveringExecution;
		}
	}
}
