/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 16:51
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
	public class CollaborationElementCreatorTest:XmlElementCreatorTest
	{
		private CollaborationElementCreator elementCreator;
		private XmlElement parentElement;
		private const string COLLABORATION_ELEMENT_TYPE_NAME="ownedMember";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:Collaboration";
		private const string COLLABORATION_NAME="CollaborationTestname";
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=3;
		private const uint expectedIdCount=2;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=1;
		private const string EMPTY_STRING="";
		
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new CollaborationElementCreator(xmiDocument,documentBuilder);
			parentElement=ModelElementStub.CreateModelElementStub(xmiDocument);
		}
		
		
		[Test]
		public void createCollaborationElement()
		{
			XmlElement createdCollaborationElement=elementCreator.CreateCollaborationElement(parentElement,COLLABORATION_NAME);
			System.Console.WriteLine(parentElement.OuterXml);
			/*
			Assert.IsNotNull(createdCollaborationElement);
			AssertXML.AssertTypeNameOfElement(createdCollaborationElement,COLLABORATION_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdCollaborationElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdCollaborationElement,OWNED_ATTRIBUTES_COUNT);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_1);
			AssertXML.AssertIsChildElementOf(parentElement,createdCollaborationElement,XPathQuerys.COLLABORATION_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdCollaborationElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdCollaborationElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdCollaborationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdCollaborationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);
			AssertXML.AssertIsUmlAttributeOf(createdCollaborationElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdCollaborationElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,COLLABORATION_NAME);
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(expectedIdCount==newIdCount);*/
		}
	}
}
