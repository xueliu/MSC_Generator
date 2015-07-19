/*
 * Erstellt mit SharpDevelop.
 * Benutzer: L G
 * Datum: 16.10.2007
 * Zeit: 13:59
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
	public class InteractionElementCreatorTest:XmlElementCreatorTest
	{
		private InteractionElementCreator elementCreator;
		private XmlElement parentElement;
		private const string DIAGRAM_NAME="TestDiagram";
		private const int  EXPECTED_CHILD_COUNT_CASE_1=1;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=3;
		private const uint expectedIdCount=2;
		private const string INTERACTION_ELEMENT_TYPE_NAME="ownedBehavior";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:Interaction";
		private const string EMPTY_STRING="";
		
		[SetUp] 
		public void Init()
		{
			base.Init();
			elementCreator=new InteractionElementCreator(xmiDocument,documentBuilder);
			parentElement=CollaborationElementStub.CreateCollaborationElementStub(this.xmiDocument);
			MSC.DiagramName=DIAGRAM_NAME;
		}
		
		[Test]
		public void CreateFirstInteractionElement()
		{
			XmlElement createdInteractionElement=elementCreator.CreateInteractionElement(parentElement);
			System.Console.WriteLine(parentElement.OuterXml);
			
		/*	Assert.IsNotNull(createdInteractionElement);
			AssertXML.AssertTypeNameOfElement(createdInteractionElement,INTERACTION_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdInteractionElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdInteractionElement,OWNED_ATTRIBUTES_COUNT);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_1);
			AssertXML.AssertIsChildElementOf(parentElement,createdInteractionElement,XPathQuerys.INTERACTION_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdInteractionElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdInteractionElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdInteractionElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdInteractionElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);
			AssertXML.AssertIsUmlAttributeOf(createdInteractionElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdInteractionElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,DIAGRAM_NAME);
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(expectedIdCount==newIdCount);*/
		}
	}
}
