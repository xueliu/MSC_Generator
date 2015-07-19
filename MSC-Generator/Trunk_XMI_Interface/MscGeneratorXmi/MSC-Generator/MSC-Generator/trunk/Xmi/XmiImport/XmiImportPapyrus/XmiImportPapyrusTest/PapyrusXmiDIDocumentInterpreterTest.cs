/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 30.11.2007
 * Zeit: 17:04
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Xml;
using System.Xml.XPath;
using xmiImport;
using xmi;
using NUnit.Framework;


namespace xmiImportPapyrus
{
	[TestFixture]
	public class PapyrusXmiDIDocumentInterpreterTest
	{
		private PapyrusXmiDIDocumentInterpreter dIDocumentInterpreter;
		private XmlDocument document;
		private XmlElement diagramElement;
		private XmlElement firstContainedElement;
		private XmlElement secondContainedElement;
		private XmlElement thirdContainedElement;
		private const string DOUBLE_POINT=":";
		private const int FIRST_POSITION_X_INT=345;
		private const int FIRST_POSITION_Y_INT=712;
		private const string FIRST_POSITION_STRING="345:712";
		private const int SECOND_POSITION_X_INT=2;
		private const int SECOND_POSITION_Y_INT=5674756;
		private const string SECOND_POSITION_STRING="2:5674756";
		private const int THIRD_POSITION_X_INT=354623;
		private const int THIRD_POSITION_Y_INT=6;
		private const string THIRD_POSITION_STRING="354623:6";
		private const int FOURTH_POSITION_X_INT=0;
		private const int FOURTH_POSITION_Y_INT=1;
		private const string FOURTH_POSITION_STRING="0:1";
		private const int FIRST_DIMENSION_WIDTH_INT=453;
		private const int FIRST_DIMENSION_HEIGHT_INT=563;
		private const string FIRST_DIMENSION_STRING="453:563";
		private const int SECOND_DIMENSION_WIDTH_INT=613;
		private const int SECOND_DIMENSION_HEIGHT_INT=635;
		private const string SECOND_DIMENSION_STRING="613:635";
		private const int THIRD_DIMENSION_WIDTH_INT=673;
		private const int THIRD_DIMENSION_HEIGHT_INT=698;
		private const string THIRD_DIMENSION_STRING="673:698";
		private const int FOURTH_DIMENSION_WIDTH_INT=712;
		private const int FOURTH_DIMENSION_HEIGHT_INT=753;
		private const string FOURTH_DIMENSION_STRING="712:753";
		
		private const string MODEL_DOCUMENT_NAME="TheTestModel";
		private const string UML_DIAMOND_STRING="uml#";
		private const string TEST_POSITION_X="4563";
		private const string TEST_POSITION_Y="93";
		private const int TEST_POSITION_INT_X=4563;
		private const int TEST_POSITION_INT_Y=93;
		private const string TEST_DIMENSION_WIDTH="6324";
		private const string TEST_DIMENSION_HEIGHT="7435";
		private const int TEST_DIMENSION_WIDTH_INT=6324;
		private const int TEST_DIMENSION_HEIGHT_INT=7435;
		private const string TEST_ELEMENT_ID="_number361";
		private const string FIRST_LIFELINE_ELEMENT_ID="_number444";
		private const string SECOND_LIFELINE_ELEMENT_ID="_number555";
		
		private const int FIRST_LIFELINE_ELEMENT_X=5023;
		private const int FIRST_LIFELINE_ELEMENT_Y=123;
		private const int SECOND_LIFELINE_ELEMENT_X=5127;
		private const int SECOND_LIFELINE_ELEMENT_Y=135;
		private const int FIRST_ANCHORAGE_ELEMENT_X=5156;
		private const int FIRST_ANCHORAGE_ELEMENT_Y=141;
		private const int SECOND_ANCHORAGE_ELEMENT_X=5258;
		private const int SECOND_ANCHORAGE_ELEMENT_Y=167;
		private const string MESSAGE_ELEMENT_ID="_number777";
		private const string FIRST_MESSAGE_OCCURRENCE_ELEMENT_ID="_number888";
		private const string SECOND_MESSAGE_OCCURRENCE_ELEMENT_ID="_number999";
		
		private const int FIRST_MESSAGE_OCCURRENCE_ELEMENT_X=10179;
		private const int FIRST_MESSAGE_OCCURRENCE_ELEMENT_Y=264;
		private const int SECOND_MESSAGE_OCCURRENCE_ELEMENT_X=10385;
		private const int SECOND_MESSAGE_OCCURRENCE_ELEMENT_Y=302;
		
		private XmlNamespaceManager namespaceManager;
		
		
		[SetUp]
		public void Init()
		{
			document=new XmlDocument();
			namespaceManager=new XmlNamespaceManager(document.NameTable);
			namespaceManager.AddNamespace(XmiElements.UML_NAMESPACE_PREFIX,XmiElements.UML_NAMESPACE_URI);
			namespaceManager.AddNamespace(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_NAMESPACE_URI);
			dIDocumentInterpreter =new PapyrusXmiDIDocumentInterpreter(MODEL_DOCUMENT_NAME);
			diagramElement=DiagramElementStub.CreateDiagramElementStub(document);
			firstContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document,"1");
			secondContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document,"2");
			thirdContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document,"3");
			diagramElement.AppendChild(firstContainedElement);
			diagramElement.AppendChild(secondContainedElement);
			diagramElement.AppendChild(thirdContainedElement);
		}
		
		[Test]
		public void GetPositionForPositionStringTest()
		{
			Point returnedPosition=dIDocumentInterpreter.GetPositionForPositionString(FIRST_POSITION_STRING);
			Assert.IsNotNull(returnedPosition);
			int actualX=returnedPosition.X;
			Assert.IsTrue(FIRST_POSITION_X_INT==actualX);
			int actualY=returnedPosition.Y;
			Assert.IsTrue(FIRST_POSITION_Y_INT==actualY);
			
			returnedPosition=dIDocumentInterpreter.GetPositionForPositionString(SECOND_POSITION_STRING);
			Assert.IsNotNull(returnedPosition);
			actualX=returnedPosition.X;
			Assert.IsTrue(SECOND_POSITION_X_INT==actualX);
			actualY=returnedPosition.Y;
			Assert.IsTrue(SECOND_POSITION_Y_INT==actualY);
			
			returnedPosition=dIDocumentInterpreter.GetPositionForPositionString(THIRD_POSITION_STRING);
			Assert.IsNotNull(returnedPosition);
			actualX=returnedPosition.X;
			Assert.IsTrue(THIRD_POSITION_X_INT==actualX);
			actualY=returnedPosition.Y;
			Assert.IsTrue(THIRD_POSITION_Y_INT==actualY);
			
			returnedPosition=dIDocumentInterpreter.GetPositionForPositionString(FOURTH_POSITION_STRING);
			Assert.IsNotNull(returnedPosition);
			actualX=returnedPosition.X;
			Assert.IsTrue(FOURTH_POSITION_X_INT==actualX);
			actualY=returnedPosition.Y;
			Assert.IsTrue(FOURTH_POSITION_Y_INT==actualY);
		}
		
		[Test]
		public void GetSizeForSizeStringTest()
		{
			Size returnedDimension=dIDocumentInterpreter.GetSizeForSizeString(FIRST_DIMENSION_STRING);
			Assert.IsNotNull(returnedDimension);
			int actualWidth=returnedDimension.Width;
			Assert.IsTrue(FIRST_DIMENSION_WIDTH_INT==actualWidth);
			int actualHeight=returnedDimension.Height;
			Assert.IsTrue(FIRST_DIMENSION_HEIGHT_INT==actualHeight);
			
			returnedDimension=dIDocumentInterpreter.GetSizeForSizeString(SECOND_DIMENSION_STRING);
			Assert.IsNotNull(returnedDimension);
			actualWidth=returnedDimension.Width;
			Assert.IsTrue(SECOND_DIMENSION_WIDTH_INT==actualWidth);
			actualHeight=returnedDimension.Height;
			Assert.IsTrue(SECOND_DIMENSION_HEIGHT_INT==actualHeight);
			
			returnedDimension=dIDocumentInterpreter.GetSizeForSizeString(THIRD_DIMENSION_STRING);
			Assert.IsNotNull(returnedDimension);
			actualWidth=returnedDimension.Width;
			Assert.IsTrue(THIRD_DIMENSION_WIDTH_INT==actualWidth);
			actualHeight=returnedDimension.Height;
			Assert.IsTrue(THIRD_DIMENSION_HEIGHT_INT==actualHeight);
			
			returnedDimension=dIDocumentInterpreter.GetSizeForSizeString(FOURTH_DIMENSION_STRING);
			Assert.IsNotNull(returnedDimension);
			actualWidth=returnedDimension.Width;
			Assert.IsTrue(FOURTH_DIMENSION_WIDTH_INT==actualWidth);
			actualHeight=returnedDimension.Height;
			Assert.IsTrue(FOURTH_DIMENSION_HEIGHT_INT==actualHeight);
		}
		
		[Test]
		public void GetGraphNodeForElementElementTest()
		{
			XmlElement relevantGraphNodeElement=GraphNodeElementStub.CreateGraphNodeElementStub(document);
			XmlElement semanticModelElement=document.CreateElement("semanticModel");
			XmlElement elementElement=document.CreateElement("element");
			relevantGraphNodeElement.AppendChild(semanticModelElement);
			semanticModelElement.AppendChild(elementElement);
			XmlElement returnedElement=dIDocumentInterpreter.GetGraphElementForElementElement(elementElement);
			Assert.IsNotNull(returnedElement);
			Assert.AreEqual(relevantGraphNodeElement,returnedElement);
		}
		
		[Test]
		public void GetLifelineGraphNodePositionTest()
		{
			string diagramElementContent=CreateDiagramElementContent(UmlModelElements.LIFELINE_TYPE_ATTR_VALUE);
			diagramElement.InnerXml=diagramElementContent;
			XmlElement lifelineElement=LifelineElementStub.CreateLifelineElementStub(document,TEST_ELEMENT_ID);
			Point returnedPosition =dIDocumentInterpreter.GetLifelineGraphNodePosition(diagramElement,lifelineElement);
			Assert.IsNotNull(returnedPosition);
			int actualX=returnedPosition.X;
			Assert.IsTrue(TEST_POSITION_INT_X==actualX);
			int actualY=returnedPosition.Y;
			Assert.IsTrue(TEST_POSITION_INT_Y==actualY);
		}
		
		[Test]
		public void GetMessageGraphNodePositionTest()
		{
			string diagramElementContent="<contained xsi:type='di2:GraphNode' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' position='4563:93' >"+
        								 		"<semanticModel xsi:type='di2:Uml1SemanticModelBridge' graphElement=''>"+
          											"<element xsi:type='uml:Message' href='TheTestModel.uml#_number361'/>"+
       											"</semanticModel>"+
											"</contained>";
			diagramElement.InnerXml=diagramElementContent;
			XmlElement messageElement=MessageElementStub.CreateMessageElementStub(document,TEST_ELEMENT_ID);
			Point returnedPosition =dIDocumentInterpreter.GetMessageGraphNodePosition(diagramElement,messageElement);
			Assert.IsNotNull(returnedPosition);
			int actualX=returnedPosition.X;
			Assert.IsTrue(TEST_POSITION_INT_X==actualX);
			int actualY=returnedPosition.Y;
			Assert.IsTrue(TEST_POSITION_INT_Y==actualY);
		}
		
		[Test]
		public void GetBehaviorExecutionSpecPositionTest()
		{
			string diagramElementContent=CreateDiagramElementContent(UmlModelElements.BEHAVIOR_EXECUTION_SPEC_TYPE_ATTR_VALUE);
			diagramElement.InnerXml=diagramElementContent;
			XmlElement behaviorExecutionSpecElement=BehaviorExecutionSpecElementStub.CreateBehaviorExecutionSpecElementStub(document,TEST_ELEMENT_ID);
			Point returnedPosition =dIDocumentInterpreter.GetExecutionSpecPosition(diagramElement,behaviorExecutionSpecElement);
			Assert.IsNotNull(returnedPosition);
			int actualX=returnedPosition.X;
			Assert.IsTrue(TEST_POSITION_INT_X==actualX);
			int actualY=returnedPosition.Y;
			Assert.IsTrue(TEST_POSITION_INT_Y==actualY);
		}
		
		[Test]
		public void GetBehaviorExecutionSpecDimensionTest()
		{
			string diagramElementContent=CreateDiagramElementContent(UmlModelElements.BEHAVIOR_EXECUTION_SPEC_TYPE_ATTR_VALUE);
			diagramElement.InnerXml=diagramElementContent;
			XmlElement behaviorExecutionSpecElement=BehaviorExecutionSpecElementStub.CreateBehaviorExecutionSpecElementStub(document,TEST_ELEMENT_ID);
			Size returnedSize =dIDocumentInterpreter.GetExecutionSpecDimension(diagramElement,behaviorExecutionSpecElement);
			Assert.IsNotNull(returnedSize);
			int actualWidth=returnedSize.Width;
			Assert.IsTrue(TEST_DIMENSION_WIDTH_INT==actualWidth);
			int actualHeight=returnedSize.Height;
			Assert.IsTrue(TEST_DIMENSION_HEIGHT_INT==actualHeight);
		}
		
		[Test]
		public void GetMessageOccurrenceSpecGraphNodePositionTest()
		{
			string diagramElementContent="<contained xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:type='di2:GraphNode'>"+
										 "<contained xsi:type='di2:GraphNode' position='5023:123'>"+
        								 	"<semanticModel xsi:type='di2:Uml1SemanticModelBridge'>"+
          										"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#_number444'/>"+
        									"</semanticModel>"+
        									"<anchorage position='5156:141' graphEdge='/1/@contained.1'/>"+
      									 "</contained>"+
										 "<contained xsi:type='di2:GraphNode' position='5127:135'>"+
        								 	"<semanticModel xsi:type='di2:Uml1SemanticModelBridge'>"+
          										"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#_number555'/>"+
        									"</semanticModel>"+
        									"<anchorage position='5258:167' graphEdge='/1/@contained.1'/>"+
      									 "</contained>"+
										 "</contained>"+
				                         "<contained xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:type='di2:GraphEdge' anchor='/1/@contained.0/@contained.0/@anchorage.0 /1/@contained.0/@contained.1/@anchorage.0'>"+
      									 	"<semanticModel xsi:type='di2:Uml1SemanticModelBridge'>"+
        								 		"<element xsi:type='uml:Message' href='TheTestModel.uml#_number777'/>"+
      										 "</semanticModel>"+
    									 "</contained>";
				
			diagramElement.InnerXml=diagramElementContent;
			XmlElement firstMessageOccurrenceSpecElement=MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(document,FIRST_MESSAGE_OCCURRENCE_ELEMENT_ID);
			firstMessageOccurrenceSpecElement.SetAttribute(UmlModelElements.MESSAGE_ATTR_NAME,MESSAGE_ELEMENT_ID);
			firstMessageOccurrenceSpecElement.SetAttribute(UmlModelElements.COVERED_ATTR_NAME,FIRST_LIFELINE_ELEMENT_ID);
			Point  returnedPosition=dIDocumentInterpreter.GetMessageOccurrenceSpecGraphNodePosition(diagramElement,firstMessageOccurrenceSpecElement);
			int returnedPositionX=returnedPosition.X;
			int returnedPositionY=returnedPosition.Y;
			Assert.IsNotNull(returnedPosition);
			Assert.IsTrue(returnedPositionX==FIRST_MESSAGE_OCCURRENCE_ELEMENT_X);
			Assert.IsTrue(returnedPositionY==FIRST_MESSAGE_OCCURRENCE_ELEMENT_Y);
			
			XmlElement secondMessageOccurrenceSpecElement=MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(document,SECOND_MESSAGE_OCCURRENCE_ELEMENT_ID);
			secondMessageOccurrenceSpecElement.SetAttribute(UmlModelElements.MESSAGE_ATTR_NAME,MESSAGE_ELEMENT_ID);
			secondMessageOccurrenceSpecElement.SetAttribute(UmlModelElements.COVERED_ATTR_NAME,SECOND_LIFELINE_ELEMENT_ID);
			returnedPosition=dIDocumentInterpreter.GetMessageOccurrenceSpecGraphNodePosition(diagramElement,secondMessageOccurrenceSpecElement);
			returnedPositionX=returnedPosition.X;
			returnedPositionY=returnedPosition.Y;
			Assert.IsNotNull(returnedPosition);
			Assert.IsTrue(returnedPositionX==SECOND_MESSAGE_OCCURRENCE_ELEMENT_X);
			Assert.IsTrue(returnedPositionY==SECOND_MESSAGE_OCCURRENCE_ELEMENT_Y);
			
		}
		
		private string CreateDiagramElementContent(string elementElementType)
		{
			string diagramElementContent="<contained xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:type='di2:GraphNode'>"+
      									 	"<contained xsi:type='di2:GraphNode' position='4563:93' size='6324:7435'>"+
        								 		"<semanticModel xsi:type='di2:Uml1SemanticModelBridge' graphElement=''>"+
          											"<element xsi:type='"+elementElementType+"' href='TheTestModel.uml#_number361'/>"+
       											"</semanticModel>"+
											"</contained>"+
										 "</contained>";
			
			return diagramElementContent;
		}
		
		[Test]
		public void GetElementElementsTest()
		{
			//XmlNodeList elementElementsList=dIDocumentInterpreter.GetElementElements(diagramElement);
			
			XPathNavigator navigator=document.CreateNavigator();
			XPathNodeIterator myItr=(XPathNodeIterator)navigator.Evaluate("//contained");
			myItr.MoveNext();
			XPathNavigator firstNavi=myItr.Current;
			/*XmlElement firstNode=(XmlElement)firstNavi.UnderlyingObject;
			Assert.AreSame(firstContainedElement,firstNode);
			System.Console.WriteLine(firstNode.OuterXml);
			System.Console.WriteLine("+++++++++++++++++++++++++++++++");*/
			
			//XPathNodeIterator mySecondItr=(XPathNodeIterator)navigator.Evaluate("./1/");
			//XPathNavigator secondNavi=mySecondItr.Current;
			//XmlElement secondNode=(XmlElement)secondNavi.UnderlyingObject;
			//Assert.AreSame(firstContainedElement,firstNode);
			//System.Console.WriteLine(secondNode.OuterXml);
			//XmlNodeList elementElementsList =diagramElement.SelectNodes("//contained[1]");
			//int elementElementsCount=elementElementsList.Count;
			//Assert.IsTrue(elementElementsCount==3);
		}
	}
}
