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

namespace sequenceChartModel
{
	public enum MessageEndKind
	{	
		sourceEnd,
		destinationEnd
	}
	
	/// <summary>
	/// Description of MessageEnd.
	/// </summary>
	public class MessageEnd:SequenceChartElement
	{
		private Message correspondingMessage;
		private MessageEndKind messageEndKind;
		
		public MessageEnd(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){}
		
		public Message CorrespondingMessage{
			get{
				return correspondingMessage;
			}
			set{
				correspondingMessage=value;
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
