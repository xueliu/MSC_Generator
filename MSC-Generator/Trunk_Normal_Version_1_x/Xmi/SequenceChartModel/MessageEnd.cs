/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 11:53
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
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
