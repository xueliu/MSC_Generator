/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.11.2007
 * Zeit: 14:47
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
	public class GraphEdgeElementCreatorTest:XmlElementCreatorTest
	{
		private GraphEdgeElementCreator elementCreator;
		private XmlElement parentElement;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=2;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=2;
		private const uint expectedIdCount=2;
		private const string INTERACTION_ELEMENT_TYPE_NAME="contained";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:GraphEdge";
		private const string EMPTY_STRING="";
		private const string semanticModelElementId="4";
		private const string TYPE_INFO="TestTypeInfo";
		private Point sourceCoordinate;
		private Point destinationCoordinate;
		private const int sourceX=5;
		private const int sourceY=6;
		private const int destinationX=7;
		private const int destinationY=8;
		
		
		[SetUp] 
		public void Init()
		{
			base.Init();
			elementCreator=new GraphEdgeElementCreator(xmiDocument,documentBuilder);
			parentElement=DiagramElementStub.CreateDiagramElementStub(this.xmiDocument);
			sourceCoordinate=new Point(sourceX,sourceY);
			destinationCoordinate=new Point(destinationX,destinationY);
		}
		
		[Test]
		public void CreateGraphEdgeElementWithSemanticModelTest()
		{
			XmlElement createdGraphEdgeElement=
			elementCreator.CreateGraphEdgeElementWithSemanticModel(parentElement,semanticModelElementId,sourceCoordinate,destinationCoordinate);
			System.Console.WriteLine(parentElement.OuterXml);
		}
	}
}
