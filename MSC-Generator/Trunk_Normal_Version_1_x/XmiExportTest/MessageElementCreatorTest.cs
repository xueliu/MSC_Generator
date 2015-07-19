/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 22.10.2007
 * Zeit: 10:11
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
using NUnit.Framework.SyntaxHelpers;

namespace xmiExport
{
	[TestFixture]
	public class MessageElementCreatorTest:XmlElementCreatorTest
	{
		private MessageElementCreator elementCreator;
		private XmlElement parentElement;
		private XmlElement modelElement;
		private const int EXPECTED_CHILD_COUNT_CASE_MESSAGE=3;
		private const int EXPECTED_CHILD_COUNT_CASE_LOST_MESSAGE=2;
		private const int EXPECTED_CHILD_COUNT_CASE_FOUND_MESSAGE=2;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
				
		private const int OWNED_ATTRIBUTES_COUNT_CASE_MESSAGE=7;
		private const int OWNED_ATTRIBUTES_COUNT_CASE_LOST_MESSAGE=6;
		private const int OWNED_ATTRIBUTES_COUNT_CASE_FOUND_MESSAGE=6;
		
		private const uint EXPECTED_ID_COUNT=2;
		
		private const string ID_SEND_EVENT_ELEMENT_CASE_MESSAGE="2";
		private const string ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE="3";
		private const string ID_SEND_EVENT_ELEMENT_CASE_LOST_MESSAGE="2";
		private const string ID_RECEIVE_EVENT_ELEMENT_CASE_FOUND_MESSAGE="2";
		
		private const string ID_LIFELINE_SOURCE="45";
		private const string ID_LIFELINE_DESTINATION="46";
		private XmlElement sourceLifelineElement;
		private XmlElement destinationLifelineElement;
		private const string MESSAGE_KIND_ATTR_NAME="messageKind";
		private const string MESSAGE_SORT_ATTR_NAME="messageSort";
		private const string MESSAGE_ELEMENT_TYPE_NAME="message";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:Message";
		private const string MESSAGE_NAME="MessageTestname";
		private const string EMPTY_STRING="";
		private const int PROCESS_DUMMY=1;
		private const uint FILE_LINE_DUMMY=0;
		private const uint LINE_DUMMY=0;
		private const int MESSAGE_SOURCE_DUMMY=0;
		private const int MESSAGE_DESTINATION_DUMMY=0;
		private const string MESSAGE_OCCURRENCE_SPEC_QUERY_START="//fragment[@xmi:id='";
		private const string MESSAGE_OCCURRENCE_SPEC_QUERY_END="']";
		private const string XMI_TYPE_ATTR_MESSAGE_OCCURRENCE_SPECIFICATION="uml:MessageOccurrenceSpecification";
		
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new MessageElementCreator(xmiDocument,documentBuilder);
			parentElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			sourceLifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,ID_LIFELINE_SOURCE);
			destinationLifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,ID_LIFELINE_DESTINATION);
			modelElement=ModelElementStub.CreateModelElementStub(this.xmiDocument);
			modelElement.AppendChild(parentElement);
		}
		
		[Test]
		public void CreateNormalMessageAsyncCall()
		{
			Message normalMessageItem=new Message(FILE_LINE_DUMMY,MESSAGE_NAME,LINE_DUMMY,MESSAGE_SOURCE_DUMMY,MESSAGE_DESTINATION_DUMMY);
			normalMessageItem.MStyle=MessageStyle.Normal;	
			
			XmlElement createdMessageElement=elementCreator.CreateMessageElement(parentElement,normalMessageItem,sourceLifelineElement,destinationLifelineElement);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*********************************");
			
		 /*   Assert.IsNotNull(createdMessageElement);
			AssertXML.AssertTypeNameOfElement(createdMessageElement,MESSAGE_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdMessageElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdMessageElement,OWNED_ATTRIBUTES_COUNT_CASE_MESSAGE);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_MESSAGE);
			AssertXML.AssertIsChildElementOf(parentElement,createdMessageElement,XPathQuerys.MESSAGE_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);	
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,MESSAGE_NAME);
			VerifyMessageOccurrenceSpecElement(ID_SEND_EVENT_ELEMENT_CASE_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_SOURCE);
			VerifyMessageOccurrenceSpecElement(ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_DESTINATION);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_SORT_ASYNCH_CALL);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_KIND_COMPLETE);
			
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager,ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager,ID_SEND_EVENT_ELEMENT_CASE_MESSAGE);
			
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(EXPECTED_ID_COUNT==2);*/
		}
		
		[Test]
		public void CreateNormalMessageSyncCall()
		{
		Message normalMessageItem=new Message(FILE_LINE_DUMMY,MESSAGE_NAME,LINE_DUMMY,MESSAGE_SOURCE_DUMMY,MESSAGE_DESTINATION_DUMMY);
			normalMessageItem.MStyle=MessageStyle.Synchron;	
			
			XmlElement createdMessageElement=elementCreator.CreateMessageElement(parentElement,normalMessageItem,sourceLifelineElement,destinationLifelineElement);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*********************************");
			/*	
			Assert.IsNotNull(createdMessageElement);
			AssertXML.AssertTypeNameOfElement(createdMessageElement,MESSAGE_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdMessageElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdMessageElement,OWNED_ATTRIBUTES_COUNT_CASE_MESSAGE);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_MESSAGE);
			AssertXML.AssertIsChildElementOf(parentElement,createdMessageElement,XPathQuerys.MESSAGE_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);	
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,MESSAGE_NAME);
			VerifyMessageOccurrenceSpecElement(ID_SEND_EVENT_ELEMENT_CASE_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_SOURCE);
			VerifyMessageOccurrenceSpecElement(ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_DESTINATION);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_SORT_SYNCH_CALL);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_KIND_COMPLETE);
			
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager,ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager,ID_SEND_EVENT_ELEMENT_CASE_MESSAGE);
			
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(EXPECTED_ID_COUNT==2);*/
		}
		
		[Test]
		public void CreateNormalMessageAsyncSignal()
		{
			Message normalMessageItem=new Message(FILE_LINE_DUMMY,MESSAGE_NAME,LINE_DUMMY,MESSAGE_SOURCE_DUMMY,MESSAGE_DESTINATION_DUMMY);
			normalMessageItem.MStyle=MessageStyle.Dashed;	
			
			XmlElement createdMessageElement=elementCreator.CreateMessageElement(parentElement,normalMessageItem,sourceLifelineElement,destinationLifelineElement);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*********************************");
			
			/*Assert.IsNotNull(createdMessageElement);
			AssertXML.AssertTypeNameOfElement(createdMessageElement,MESSAGE_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdMessageElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdMessageElement,OWNED_ATTRIBUTES_COUNT_CASE_MESSAGE);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_MESSAGE);
			AssertXML.AssertIsChildElementOf(parentElement,createdMessageElement,XPathQuerys.MESSAGE_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);	
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,MESSAGE_NAME);
			VerifyMessageOccurrenceSpecElement(ID_SEND_EVENT_ELEMENT_CASE_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_SOURCE);
			VerifyMessageOccurrenceSpecElement(ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_DESTINATION);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_SORT_ASYNCH_SIGNAL);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_KIND_COMPLETE);
			
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager,ID_RECEIVE_EVENT_ELEMENT_CASE_MESSAGE);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager,ID_SEND_EVENT_ELEMENT_CASE_MESSAGE);
			
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(EXPECTED_ID_COUNT==2);*/
		}
		
		
		[Test]
		public void CreateLostMessageElement()
		{
			LostMessage lostMessageItem=new LostMessage(FILE_LINE_DUMMY,MESSAGE_NAME,LINE_DUMMY,PROCESS_DUMMY);
					
			XmlElement createdMessageElement=elementCreator.CreateMessageElement(parentElement,lostMessageItem,sourceLifelineElement,destinationLifelineElement);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*********************************");
			/*Assert.IsNotNull(createdMessageElement);
			AssertXML.AssertTypeNameOfElement(createdMessageElement,MESSAGE_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdMessageElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdMessageElement,OWNED_ATTRIBUTES_COUNT_CASE_LOST_MESSAGE);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_LOST_MESSAGE);
			AssertXML.AssertIsChildElementOf(parentElement,createdMessageElement,XPathQuerys.MESSAGE_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);	
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,MESSAGE_NAME);
			VerifyMessageOccurrenceSpecElement(ID_SEND_EVENT_ELEMENT_CASE_LOST_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_SOURCE);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_SORT_ASYNCH_CALL);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_KIND_LOST);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.SEND_EVENT_ATTR_NAME,this.namespaceManager,ID_SEND_EVENT_ELEMENT_CASE_LOST_MESSAGE);
			
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(EXPECTED_ID_COUNT==2);*/
		}
		
		[Test]
		public void CreateFoundMessageElement()
		{
			FoundMessage foundMessageItem=new FoundMessage(FILE_LINE_DUMMY,MESSAGE_NAME,LINE_DUMMY,PROCESS_DUMMY);
					
			XmlElement createdMessageElement=elementCreator.CreateMessageElement(parentElement,foundMessageItem,sourceLifelineElement,destinationLifelineElement);		
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*********************************");
		/*	Assert.IsNotNull(createdMessageElement);
			AssertXML.AssertTypeNameOfElement(createdMessageElement,MESSAGE_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdMessageElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdMessageElement,OWNED_ATTRIBUTES_COUNT_CASE_FOUND_MESSAGE);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_FOUND_MESSAGE);
			AssertXML.AssertIsChildElementOf(parentElement,createdMessageElement,XPathQuerys.MESSAGE_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdMessageElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);	
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,MESSAGE_NAME);
			VerifyMessageOccurrenceSpecElement(ID_RECEIVE_EVENT_ELEMENT_CASE_FOUND_MESSAGE,ID_OF_FIRST_XMI_ELEMENT,ID_LIFELINE_DESTINATION);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_SORT_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_SORT_ASYNCH_CALL);
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.MESSAGE_KIND_ATTR_NAME,this.namespaceManager,UmlModelElements.MESSAGE_KIND_FOUND);
			
			AssertXML.AssertIsUmlAttributeOf(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdMessageElement,UmlModelElements.RECEIVE_EVENT_ATTR_NAME,this.namespaceManager,ID_RECEIVE_EVENT_ELEMENT_CASE_FOUND_MESSAGE);
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(EXPECTED_ID_COUNT==2);*/
		}
		
		
		private void VerifyMessageOccurrenceSpecElement(string messageOccurrenceSpecID,string messageID,string lifelineID)
		{
			string query=MESSAGE_OCCURRENCE_SPEC_QUERY_START+messageOccurrenceSpecID+MESSAGE_OCCURRENCE_SPEC_QUERY_END;
			XPathNavigator  navigator=parentElement.CreateNavigator();
			XPathNavigator foundNavigator=	navigator.SelectSingleNode(query,namespaceManager);
			Assert.IsNotNull(foundNavigator);
			XmlElement messageOccurrenceSpecificationElement=(XmlElement)foundNavigator.UnderlyingObject;
			AssertXML.AssertIsCorrectXmiAttributeValue(messageOccurrenceSpecificationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTR_MESSAGE_OCCURRENCE_SPECIFICATION);
			AssertXML.AssertValueOfUmlAttribute(messageOccurrenceSpecificationElement,UmlModelElements.MESSAGE_ATTR_NAME,namespaceManager,messageID);
			
		    AssertXML.AssertChildElementsCount(messageOccurrenceSpecificationElement,1);
			XmlElement coveredAttributeElement=(XmlElement)messageOccurrenceSpecificationElement.FirstChild;
			AssertXML.AssertNamespacePrefixOfElement(coveredAttributeElement,EMPTY_STRING);
			AssertXML.AssertTypeNameOfElement(coveredAttributeElement,XmiElements.COVERED_ELEMENT_NAME);
			AssertXML.AssertChildElementsCount(coveredAttributeElement,0);
			AssertXML.AssertIsXmiAttributeOf(coveredAttributeElement,XmiElements.XMI_IDREF_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(coveredAttributeElement,XmiElements.XMI_IDREF_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,lifelineID);
		}
	}
}
