/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 12:01
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;

namespace sequenceChartModel
{
	enum MessageSort{
		syncCall,
		asynchCall,
		asynchSignal
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
	}
}
