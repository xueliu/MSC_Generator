/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 04.01.2008
 * Zeit: 14:28
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using NUnit.Framework;


namespace sequenceChartModel
{
	[TestFixture]
	public class MessageTest
	{
		private Message message;
		private MessageEnd sourceMessageEnd;
		private MessageEnd destinationMessageEnd;
		private Point dummyPoint=new Point(0,0);
		
		[SetUp]
		public void Init()
		{
			message=new Message(dummyPoint,"",null);
			sourceMessageEnd=new MessageEnd(dummyPoint,"",null);
			destinationMessageEnd=new MessageEnd(dummyPoint,"",null);
			message.SourceMessageEnd=sourceMessageEnd;
			message.DestinationMessageEnd=destinationMessageEnd;
			sourceMessageEnd.CorrespondingMessage=message;
			destinationMessageEnd.CorrespondingMessage=message;
		}
		
		[Test]
		public void GetOppositeMessageEnd()
		{
			MessageEnd returnedMessageEnd=message.GetOppositeMessageEnd(sourceMessageEnd);
			Assert.AreEqual(destinationMessageEnd,returnedMessageEnd);
			
			returnedMessageEnd=message.GetOppositeMessageEnd(destinationMessageEnd);
			Assert.AreEqual(sourceMessageEnd,returnedMessageEnd);
			
		}
	}
}
