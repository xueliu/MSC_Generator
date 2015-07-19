/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 11:53
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;

namespace sequenceChartModel
{
	enum MessageEndKind
	{	
		sourceEnd,
		destinationEnd
	}
	
	/// <summary>
	/// Description of MessageEnd.
	/// </summary>
	public class MessageEnd:SequenceChartElement
	{
		private Message message;
		private MessageEndKind messageEndKind;
		
		public MessageEnd(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){
			
			this.message=message;
			this.messageEndKind=messageEndKind;
		}
		
		public Message Message{
			get{
				return message;
			}
			set{
				message=value;
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
	}
}
