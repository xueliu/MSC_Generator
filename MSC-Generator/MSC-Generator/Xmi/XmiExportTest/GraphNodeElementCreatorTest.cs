/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 08.11.2007
 * Zeit: 09:08
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
	/// <summary>
	/// Description of GraphNodeElementCreatorTest.
	/// </summary>
	
	[TestFixture]
	public class GraphNodeElementCreatorTest:XmlElementCreatorTest
	{
		
		private GraphNodeElementCreator elementCreator;
		private XmlElement parentElement;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=2;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=2;
		private const uint expectedIdCount=2;
		private const string GRAPH_NODE_ELEMENT_TYPE_NAME="contained";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:GraphNode";
		private const string EMPTY_STRING="";
		private const string TYPE_INFO="TestTypeInfo";
		private const string semanticModelElementId="4";
		private RectangleF itemBounds;
		private const int x=5;
		private const int y=6;
		private const int width=7;
		private const int height=8;
		
		[SetUp] 
		public void Init()
		{
			base.Init();
			elementCreator=new GraphNodeElementCreator(xmiDocument,documentBuilder);
			parentElement=DiagramElementStub.CreateDiagramElementStub(this.xmiDocument);
			itemBounds=new Rectangle(x,y,width,height);
		}
		
		[Test]
		public void CreateGraphNodeElementWithSemanticModelTest()
		{
			XmlElement createdGraphNodeElement=
					elementCreator.CreateGraphNodeElementWithSemanticModel(parentElement,semanticModelElementId,itemBounds);
			System.Console.WriteLine(parentElement.OuterXml);
		}

		[Test]
		public void CreateGraphNodeElementWithSimpleSemanticModelTest()
		{
			XmlElement createdGraphNodeElement=
					elementCreator.CreateGraphNodeElementWithSimpleSemanticModel(parentElement,TYPE_INFO,itemBounds);
			System.Console.WriteLine(parentElement.OuterXml);
		}
		
	}
}
