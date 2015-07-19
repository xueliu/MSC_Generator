/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.11.2007
 * Zeit: 16:20
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
using NUnit.Framework.SyntaxHelpers;

namespace xmiExport
{
	[TestFixture]
	public class GraphConnectorElementCreatorTest:XmlElementCreatorTest
	{
		private GraphConnectorElementCreator elementCreator;
		private XmlElement parentElement;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=2;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=2;
		private const uint expectedIdCount=2;
		private const string GRAPH_CONNECTOR_ELEMENT_TYPE_NAME="contained";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:GraphConnector";
		private const string EMPTY_STRING="";
		private const string x="5";
		private const string y="6";
		private const string GRAPH_EDGE_ELEMENT_ID="46";
		private XmlElement graphEdgeElement;
		
		[SetUp] 
		public void Init()
		{
			base.Init();
			elementCreator=new GraphConnectorElementCreator(xmiDocument,documentBuilder);
			parentElement=GraphNodeElementStub.CreateGraphNodeElementStub(xmiDocument);
			graphEdgeElement=GraphEdgeElementStub.CreateGraphEdgeElementStub(xmiDocument);
			XmlAttribute idAttr=xmiDocument.CreateAttribute("xmi","id",XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=GRAPH_EDGE_ELEMENT_ID;
			graphEdgeElement.SetAttributeNode(idAttr);
			//graphEdgeElement.SetAttribute(XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI,GRAPH_EDGE_ELEMENT_ID);
		}
		
		[Test]
		public void CreateGraphNodeElementWithSemanticModelTest()
		{
			XmlElement createdGraphEdgeElement=
				elementCreator.CreateGraphConnectorElement(parentElement,graphEdgeElement,x,y);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine(graphEdgeElement.OuterXml);
		}
		
	}
}
