/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 10:29
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using nGenerator;
using xmlTestFramework;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace xmiExport
{
	/// <summary>
	/// Description of LifelineElementCreatorTest.
	/// </summary>
	
	[TestFixture]
	public class LifelineElementCreatorTest:XmlElementCreatorTest
	{
		private LifelineElementCreator elementCreator;
		private XmlElement parentElement;
		private XmlElement collaborationElement;
		private XmlElement modelElement;
		private Process lifelineItem;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=1;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=2;
		private const uint expectedIdCount=2;
		private const string LIFELINE_OBJECT_NAME="TestLifelineObjectName";
		private const string LIFELINE_TYPE_NAME_REAL=":TestLifelineTypeName";
		private const string LIFELINE_TYPE_NAME="TestLifelineTypeName";
		private const string LIFELINE_NAME="TestLifelineObjectName:TestLifelineTypeName";
		private const uint LEFT_RAND_DUMMY=0;
		private const uint RIGHT_RAND_DUMMY=0;
		private const string LIFELINE_ELEMENT_TYPE_NAME="lifeline";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:Lifeline";
		private const string EMPTY_STRING="";
		private const string DOUBLE_POINT=":";
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new LifelineElementCreator(xmiDocument,documentBuilder);
			parentElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			collaborationElement=CollaborationElementStub.CreateCollaborationElementStub(xmiDocument);
			modelElement.AppendChild(collaborationElement);
			collaborationElement.AppendChild(parentElement);
		}
		
		[Test]
		public void TestCreateLifelineElementWithClass()
		{
			lifelineItem=new Process(LIFELINE_NAME,null,LEFT_RAND_DUMMY,RIGHT_RAND_DUMMY);
						
			XmlElement createdLifelineElement=elementCreator.CreateLifelineElement(parentElement,collaborationElement,lifelineItem);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*******TestCreateLifelineElementWithClass********");
			/*Assert.IsNotNull(createdLifelineElement);
			AssertXML.AssertTypeNameOfElement(createdLifelineElement,LIFELINE_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(createdLifelineElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(createdLifelineElement,OWNED_ATTRIBUTES_COUNT);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_1);
			AssertXML.AssertIsChildElementOf(parentElement,createdLifelineElement,XPathQuerys.LIFELINE_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(createdLifelineElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdLifelineElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(createdLifelineElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(createdLifelineElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);
			AssertXML.AssertIsUmlAttributeOf(createdLifelineElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(createdLifelineElement,UmlModelElements.NAME_ATTR_NAME,this.namespaceManager,LIFELINE_NAME);
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(expectedIdCount==2);	*/
		}
		
		[Test]
		public void TestCreateLifelineElementWithoutClass()
		{
			lifelineItem=new Process(LIFELINE_OBJECT_NAME,null,LEFT_RAND_DUMMY,RIGHT_RAND_DUMMY);
						
			XmlElement createdLifelineElement=elementCreator.CreateLifelineElement(parentElement,collaborationElement,lifelineItem);
			System.Console.WriteLine(modelElement.OuterXml);
			System.Console.WriteLine("*********TestCreateLifelineElementWithoutClass *******");
		}
		
		
		[Test]
		public void TestGetLifelineObjectName()
		{
			string lifelineObjectName=elementCreator.GetLifelineObjectName(LIFELINE_OBJECT_NAME);
			Assert.AreEqual(LIFELINE_OBJECT_NAME,lifelineObjectName);
			lifelineObjectName=null;
			
			lifelineObjectName=elementCreator.GetLifelineObjectName(LIFELINE_NAME);
			Assert.AreEqual(LIFELINE_OBJECT_NAME,lifelineObjectName);
			lifelineObjectName=null;
			
			lifelineObjectName=elementCreator.GetLifelineObjectName(LIFELINE_TYPE_NAME_REAL);
			Assert.IsNull(lifelineObjectName);
			lifelineObjectName=null;
			
			lifelineObjectName=elementCreator.GetLifelineObjectName(DOUBLE_POINT);
			Assert.IsNull(lifelineObjectName);
			lifelineObjectName=null;
			
			lifelineObjectName=elementCreator.GetLifelineObjectName(null);
			Assert.IsNull(lifelineObjectName);
			lifelineObjectName=null;
		}
		
		[Test]
		public void TestGetLifelineTypeName()
		{
			string lifelineTypeName=elementCreator.GetLifelineTypeName(LIFELINE_TYPE_NAME_REAL);
			Assert.AreEqual(LIFELINE_TYPE_NAME,lifelineTypeName);
			lifelineTypeName=null;
			
			lifelineTypeName=elementCreator.GetLifelineTypeName(LIFELINE_NAME);
			Assert.AreEqual(LIFELINE_TYPE_NAME,lifelineTypeName);
			lifelineTypeName=null;
			
			lifelineTypeName=elementCreator.GetLifelineTypeName(LIFELINE_OBJECT_NAME);
			Assert.IsNull(lifelineTypeName);
			
			lifelineTypeName=elementCreator.GetLifelineTypeName(DOUBLE_POINT);
			Assert.IsNull(lifelineTypeName);
			
			lifelineTypeName=elementCreator.GetLifelineTypeName(null);
			Assert.IsNull(lifelineTypeName);
		}
	}
}
