/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 12:01
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;
using xmi;

namespace sequenceChartModel
{
	public enum MessageSort{
		synchCall,
		asynchCall,
		asynchSignal,
		createMessage,
		deleteMessage,
		reply
	}
	
	public enum MessageEventKind{
		
		RECEIVING_EVENT,
		SEND_EVENT
	}
	
	/// <summary>
	/// Description of Message.
	/// </summary>
	public class Message:SequenceChartElement
	{
		private MessageEnd sourceMessageEnd; 
		private MessageEnd destinationMessageEnd;
		private MessageSort messageSort;
		
		public Message(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){}
		
		public MessageEnd SourceMessageEnd{
			get{
				return sourceMessageEnd;
			}
			set{
				sourceMessageEnd=value;
			}
		}
		
		public MessageEnd DestinationMessageEnd{
			get{
				return destinationMessageEnd;
			}
			set{
				destinationMessageEnd=value;
			}
		}
		
		public MessageSort MessageSort{
			get{
				return messageSort;
			}
			set{
				messageSort=value;
			}
		}
		
		public MessageEnd GetOppositeMessageEnd(MessageEnd relevantMessageEnd)
		{
			MessageEnd oppositeMessageEnd=null;
			MessageEnd currentMessageEnd=this.DestinationMessageEnd;
			
			if(currentMessageEnd!=relevantMessageEnd)
			{
				oppositeMessageEnd=currentMessageEnd;
			}
			else
			{
				oppositeMessageEnd=this.SourceMessageEnd;
			}
			return oppositeMessageEnd;
		}
	}
}
