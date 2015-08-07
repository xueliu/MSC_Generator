/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.11.2007
 * Zeit: 14:20
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using System.Drawing;
using nGenerator;
using mscElements;
using xmlTestFramework;
using NUnit.Framework;

using xmi;

namespace xmiExport
{
	[TestFixture]
	public class DiagramElementCreatorTest:XmlElementCreatorTest
	{
		private DiagramElementCreator elementCreator;
		private XmlElement parentElement;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=2;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=2;
		private const uint expectedIdCount=2;
		private const string DIAGRAM_ELEMENT_TYPE_NAME="contained";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:Diagram";
		private const string EMPTY_STRING="";
		private const string TYPE_INFO="sequenceDiagram";
		
		
		[SetUp] 
		public void Init()
		{
			base.Init();
			elementCreator=new DiagramElementCreator(xmiDocument,documentBuilder);
			parentElement=ModelElementStub.CreateModelElementStub(this.xmiDocument);
		}
		
		[Test]
		public void CreateGraphNodeElementWithSemanticModelTest()
		{
			XmlElement createdDiagramElement=elementCreator.CreateDiagramElement(parentElement);
			System.Console.WriteLine(parentElement.OuterXml);
		}
	}
}
