/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 26.10.2007
 * Zeit: 08:49
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
	public class ExecutionOccurrenceSpecElementCreatorTest:XmlElementCreatorTest
	{
		private ExecutionOccurrenceSpecElementCreator elementCreator;
		private XmlElement parentElement;
		private const string EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID="1";
		private XmlElement lifelineElement;
		private const string LIFE_LINE_ID="45";
		private const string EXECUTION_SPECIFICATION_ID="46";
		private const int EXPECTED_CHILD_COUNT_CASE_1=1;
		private const int OWNED_ATTRIBUTES_COUNT=3;
		private const uint expectedIdCount=2;
		private const string EXECUTION_ATTR_NAME="execution";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:ExecutionOccurrenceSpecification";
		private const string EMPTY_STRING="";
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new ExecutionOccurrenceSpecElementCreator(xmiDocument,documentBuilder);
			parentElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			lifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,LIFE_LINE_ID);
			parentElement.AppendChild(lifelineElement);
		}
		
		[Test]
		public void CreateExecutionOccurrenceSpecElement()
		{
			XmlElement executionOccurrenceSpecificationElement=elementCreator.CreateExecutionOccurrenceSpecElement(parentElement,EXECUTION_SPECIFICATION_ID,lifelineElement);
			Console.WriteLine(parentElement.OuterXml);
			
			/*Assert.IsNotNull(executionOccurrenceSpecificationElement);
			AssertXML.AssertTypeNameOfElement(executionOccurrenceSpecificationElement,EXECUTION_OCCURRENCE_SPEC_ELEMENT_TYPE_NAME);
			AssertXML.AssertNamespacePrefixOfElement(executionOccurrenceSpecificationElement,EMPTY_STRING);
			AssertXML.AssertOwnedAttributesCount(executionOccurrenceSpecificationElement,OWNED_ATTRIBUTES_COUNT);
			AssertXML.AssertChildElementsCount(parentElement,EXPECTED_CHILD_COUNT_CASE_1);*/
			
			/*AssertXML.AssertIsChildElementOf(parentElement,executionOccurrenceSpecificationElement,XPathQuerys.MESSAGE_OCCURRENCE_SPECIFICATION_ELEMENT_PATH,namespaceManager);
			AssertXML.AssertIsXmiAttributeOf(executionOccurrenceSpecificationElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(executionOccurrenceSpecificationElement,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,ID_OF_FIRST_XMI_ELEMENT);
			AssertXML.AssertIsXmiAttributeOf(executionOccurrenceSpecificationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(executionOccurrenceSpecificationElement,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,XMI_TYPE_ATTRIBUTE_VALUE);
			AssertXML.AssertIsUmlAttributeOf(executionOccurrenceSpecificationElement,UmlModelElements.MESSAGE_ATTR_NAME,this.namespaceManager);
			AssertXML.AssertValueOfUmlAttribute(executionOccurrenceSpecificationElement,UmlModelElements.MESSAGE_ATTR_NAME,this.namespaceManager,MESSAGE_ELEMENT_ID);
			
			AssertXML.AssertChildElementsCount(executionOccurrenceSpecificationElement,1);
			XmlElement coveredAttributeElement=(XmlElement)executionOccurrenceSpecificationElement.FirstChild;
			AssertXML.AssertNamespacePrefixOfElement(coveredAttributeElement,EMPTY_STRING);
			AssertXML.AssertTypeNameOfElement(coveredAttributeElement,XmiElements.COVERED_ELEMENT_NAME);
			AssertXML.AssertChildElementsCount(coveredAttributeElement,0);
			AssertXML.AssertIsXmiAttributeOf(coveredAttributeElement,XmiElements.XMI_IDREF_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			AssertXML.AssertIsCorrectXmiAttributeValue(coveredAttributeElement,XmiElements.XMI_IDREF_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,LIFELINE_ID);
			
			uint newIdCount=documentBuilder.CurrentXmiIdCount;
			Assert.IsTrue(expectedIdCount==2);
			*/
			
			
			
			
			
		}
	}
}
