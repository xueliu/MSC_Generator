/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 24.10.2007
 * Zeit: 10:08
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using nGenerator;
using mscElements;
using xmlTestFramework;
using NUnit.Framework;

using xmi;

namespace xmiExport
{
	[TestFixture]
	public class MessageOccurrenceSpecElementCreatorTest:XmlElementCreatorTest
	{
		private MessageOccurrenceSpecElementCreator elementCreator;
		private XmlElement parentElement;
		private const string MESSAGE_ELEMENT_ID="5";
		private const int EXPECTED_CHILD_COUNT_CASE_1=1;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=3;
		private const uint expectedIdCount=2;
		private const string MESSAGE_ATTR_NAME="message";
		private const string MESSAGE_OCCURRENCE_SPEC_ELEMENT_TYPE_NAME="fragment";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:MessageOccurrenceSpecification";
		private const string MESSAGE_OCCURRENCE_SPECIFICATION_NAME="MessageOccurrenceSpecificationTestname";
		private const string EMPTY_STRING="";
		private const string LIFELINE_ID="45";
		private XmlElement lifelineElement;
		private XmlElement modelElement;
		public const string MESSAGE_SORT_SYNCH_CALL="synchCall";
		public const string MESSAGE_SORT_ASYNCH_CALL="asynchCall";
		public const string MESSAGE_SORT_ASYNCH_SIGNAL="asynchSignal";
	
		[SetUp] 
		public override void Init()
		{
			base.Init();
			parentElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			lifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,LIFELINE_ID);
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			modelElement.AppendChild(parentElement);
		}
		
		[Test]
		public void CreateMessageOccurrenceSpecElementSMessageReceive()
		{
			
			elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,documentBuilder,MESSAGE_SORT_SYNCH_CALL,EventKind.ReceiveEvent);
			XmlElement messageOccurrenceSpecificationElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,MESSAGE_ELEMENT_ID);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("****************************************************");
			
			
			/*
			Assert.IsNotNull(messageOccurrenceSpecificationElement);
			AssertXML.AssertTypeNameOfElement(messageOccurrenceSpecificationElement,MESSAGE_OCCURRENCE_SPEC_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(messageOccurrenceSpecificationElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(messageOccurrenceSpecificationElement,OWNED_ATTRIBUTES_COUNT);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_1);
			AssertXML.AssertIsChildElementOf(parentElement,messageOccurrenceSpecificationElement,XPathQuerys.MESSAGE_OCCURRENCE_SPECIFICATION_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(messageOccurrenceSpecificationElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(messageOccurrenceSpecificationElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(messageOccurrenceSpecificationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(messageOccurrenceSpecificationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);
			AssertXML.AssertIsUmlAttributeOf(messageOccurrenceSpecificationElement,UmlModelElements.MESSAGE_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(messageOccurrenceSpecificationElement,UmlModelElements.MESSAGE_ATTR_NAME,this.namespaceManager,MESSAGE_ELEMENT_ID);
			
			AssertXML.AssertChildElementsCount(messageOccurrenceSpecificationElement,1);
			XmlElement coveredAttributeElement=(XmlElement)messageOccurrenceSpecificationElement.FirstChild;
			AssertXML.AssertNamespacePrefixOfElement(coveredAttributeElement,EMPTY_STRING);
			AssertXML.AssertTypeNameOfElement(coveredAttributeElement,XmiElements.COVERED_ELEMENT_NAME);
			AssertXML.AssertChildElementsCount(coveredAttributeElement,0);
			AssertXML.AssertIsXmiAttributeOf(coveredAttributeElement,XmiElements.XMI_IDREF_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(coveredAttributeElement,XmiElements.XMI_IDREF_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,LIFELINE_ID);
			
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(expectedIdCount==2);*/
		}
		
		[Test]
		public void CreateMessageOccurrenceSpecElementSMessageSend()
		{
			
			elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,documentBuilder,MESSAGE_SORT_SYNCH_CALL,EventKind.SendEvent);
			XmlElement messageOccurrenceSpecificationElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,MESSAGE_ELEMENT_ID);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("****************************************************");
		}
		
		[Test]
		public void CreateMessageOccurrenceSpecElementASMessageReceive()
		{
			
			elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,documentBuilder,MESSAGE_SORT_ASYNCH_CALL,EventKind.ReceiveEvent);
			XmlElement messageOccurrenceSpecificationElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,MESSAGE_ELEMENT_ID);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("****************************************************");
		}
		
		[Test]
		public void CreateMessageOccurrenceSpecElementASMessageSend()
		{
			
			elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,documentBuilder,MESSAGE_SORT_ASYNCH_CALL,EventKind.SendEvent);
			XmlElement messageOccurrenceSpecificationElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,MESSAGE_ELEMENT_ID);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("****************************************************");
		}
		
		[Test]
		public void CreateMessageOccurrenceSpecElementASSignalReceive()
		{
			
			elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,documentBuilder,MESSAGE_SORT_ASYNCH_SIGNAL,EventKind.ReceiveEvent);
			XmlElement messageOccurrenceSpecificationElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,MESSAGE_ELEMENT_ID);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("****************************************************");
		}
		
		[Test]
		public void CreateMessageOccurrenceSpecElementASSignalSend()
		{
			
			elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,documentBuilder,MESSAGE_SORT_ASYNCH_SIGNAL,EventKind.SendEvent);
			XmlElement messageOccurrenceSpecificationElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,MESSAGE_ELEMENT_ID);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("****************************************************");
		}
	}
}
