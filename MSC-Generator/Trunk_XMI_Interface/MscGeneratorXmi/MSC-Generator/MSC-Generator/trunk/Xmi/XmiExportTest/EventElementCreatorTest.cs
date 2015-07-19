/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 26.11.2007
 * Zeit: 17:36
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmlTestFramework;
using NUnit.Framework;

using xmi;

namespace xmiExport
{
	[TestFixture]
	public class EventElementCreatorTest:XmlElementCreatorTest
	{
		private EventElementCreator elementCreator;
		private XmlElement parentElement;
		private XmlElement modelElement;
		private const string EVENT_NAME="TestKlassenName";
		public const string MESSAGE_SORT_SYNCH_CALL="synchCall";
		public const string MESSAGE_SORT_ASYNCH_CALL="asynchCall";
		public const string MESSAGE_SORT_ASYNCH_SIGNAL="asynchSignal";
	
	
	
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new EventElementCreator(xmiDocument,documentBuilder);
			parentElement=ModelElementStub.CreateModelElementStub(xmiDocument);
		}
			
		[Test]
		public void TestCreateMessageEventElementNameReceiveEventAsMessage()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,EVENT_NAME,MESSAGE_SORT_ASYNCH_CALL,EventKind.ReceiveEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNoNameReceiveEventAsMessage()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,null,MESSAGE_SORT_ASYNCH_CALL,EventKind.ReceiveEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNameReceiveEventSMessage()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,EVENT_NAME,MESSAGE_SORT_SYNCH_CALL,EventKind.ReceiveEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNoNameReceiveEventSMessage()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,null,MESSAGE_SORT_SYNCH_CALL,EventKind.ReceiveEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNameSendEventAsMessage()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,EVENT_NAME,MESSAGE_SORT_ASYNCH_CALL,EventKind.SendEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNoNameSendEventAsMessage()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,null,MESSAGE_SORT_ASYNCH_CALL,EventKind.SendEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNameSendEventAsSignal()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,EVENT_NAME,MESSAGE_SORT_ASYNCH_SIGNAL,EventKind.SendEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNoNameSendEventAsSignal()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,null,MESSAGE_SORT_ASYNCH_SIGNAL,EventKind.SendEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNameReceiveEventAsSignal()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,EVENT_NAME,MESSAGE_SORT_ASYNCH_SIGNAL,EventKind.ReceiveEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateMessageEventElementNoNameReceiveEventAsSignal()
		{
			XmlElement createdEventElement=elementCreator.CreateMessageEventElement(parentElement,null,MESSAGE_SORT_ASYNCH_SIGNAL,EventKind.ReceiveEvent);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateExecutionEventEventElementName()
		{
			XmlElement createdEventElement=elementCreator.CreateExecutionEventElement(parentElement,EVENT_NAME);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
		
		[Test]
		public void TestCreateExecutionEventEventElementNoName()
		{
			XmlElement createdEventElement=elementCreator.CreateExecutionEventElement(parentElement,null);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine("******************************");
		}
	}
}
