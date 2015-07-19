/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 13.12.2007
 * Zeit: 11:20
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Xml;
using System.Collections;
using NUnit.Framework;

using sequenceChartModel;
using xmiImportPapyrus;
using xmi;

namespace xmiImport
{
	[TestFixture]
	public class SequenceChartModelCreatorTest
	{
		private Point POSITION_CONSIDERED_FIRST_ELEMENT_HORIZONTAL=new Point(4,36);
		private Point POSITION_CONSIDERED_SECOND_ELEMENT_HORIZONTAL=new Point(47,23);
		private Point POSITION_CONSIDERED_THIRD_ELEMENT_HORIZONTAL=new Point(123,12);
		private Point POSITION_CONSIDERED_FOURTH_ELEMENT_HORIZONTAL=new Point(345,124);
		private Point POSITION_CONSIDERED_FIFTH_ELEMENT_HORIZONTAL=new Point(521,63);
		
		private Point POSITION_CONSIDERED_FIRST_ELEMENT_VERTICAL=new Point(123,36);
		private Point POSITION_CONSIDERED_SECOND_ELEMENT_VERTICAL=new Point(47,75);
		private Point POSITION_CONSIDERED_THIRD_ELEMENT_VERTICAL=new Point(123,123);
		private Point POSITION_CONSIDERED_FOURTH_ELEMENT_VERTICAL=new Point(345,263);
		private Point POSITION_CONSIDERED_FIFTH_ELEMENT_VERTICAL=new Point(52,453);
		
		private Point ZERO_POSITION=new Point(0,0);
		
		private const string MODEL_DOCUMENT_NAME="TheTestModel";
		private const string UML_DIAMOND_STRING="uml#";
		private const string EMPTY_STRING="";
		
		private Lifeline firstConsideredLifelineHorizontal;
		private Lifeline secondConsideredLifelineHorizontal;
		private Lifeline thirdConsideredLifelineHorizontal;
		private Lifeline fourthConsideredLifelineHorizontal;
		private Lifeline fifthConsideredLifelineHorizontal;
		
		private Lifeline firstConsideredLifelineVertical;
		private Lifeline secondConsideredLifelineVertical;
		private Lifeline thirdConsideredLifelineVertical;
		private Lifeline fourthConsideredLifelineVertical;
		private Lifeline fifthConsideredLifelineVertical;
		
		private string FIRST_MESSAGE_ELEMENT_ID="1";
		private string SECOND_MESSAGE_ELEMENT_ID="2";
		private string THIRD_MESSAGE_ELEMENT_ID="3";
		private string FOURTH_MESSAGE_ELEMENT_ID="4";
		
		private int FIRST_MESSAGE_ELEMENT_X=34;
		private int FIRST_MESSAGE_ELEMENT_Y=97;
		private int SECOND_MESSAGE_ELEMENT_X=124;
		private int SECOND_MESSAGE_ELEMENT_Y=189;
		private int THIRD_MESSAGE_ELEMENT_X=211;
		private int THIRD_MESSAGE_ELEMENT_Y=342;
		private int FOURTH_MESSAGE_ELEMENT_X=453;
		private int FOURTH_MESSAGE_ELEMENT_Y=623;
		
		private string FIRST_LIFELINE_ELEMENT_ID="5";
		private string SECOND_LIFELINE_ELEMENT_ID="6";
		private string THIRD_LIFELINE_ELEMENT_ID="7";
		private string FOURTH_LIFELINE_ELEMENT_ID="8";
		
		private int FIRST_LIFELINE_ELEMENT_X=650;
		private int FIRST_LIFELINE_ELEMENT_Y=673;
		private int SECOND_LIFELINE_ELEMENT_X=703;
		private int SECOND_LIFELINE_ELEMENT_Y=723;
		private int THIRD_LIFELINE_ELEMENT_X=741;
		private int THIRD_LIFELINE_ELEMENT_Y=748;
		private int FOURTH_LIFELINE_ELEMENT_X=800;
		private int FOURTH_LIFELINE_ELEMENT_Y=814;
		
		private string FIRST_EXECUTION_SPEC_ELEMENT_ID="10";
		private string SECOND_EXECUTION_SPEC_ELEMENT_ID="11";
		private string THIRD_EXECUTION_SPEC_ELEMENT_ID="12";
		private string FOURTH_EXECUTION_SPEC_ELEMENT_ID="13";
		private string FIFTH_EXECUTION_SPEC_ELEMENT_ID="14";
		private string SIXTH_EXECUTION_SPEC_ELEMENT_ID="15";
		
		private int FIRST_EXECUTION_SPEC_ELEMENT_X=1002;
		private int FIRST_EXECUTION_SPEC_ELEMENT_Y=1234;
		private int FIRST_EXECUTION_SPEC_ELEMENT_WIDTH=1256;
		private int FIRST_EXECUTION_SPEC_ELEMENT_HEIGHT=1309;
		private int SECOND_EXECUTION_SPEC_ELEMENT_X=1345;
		private int SECOND_EXECUTION_SPEC_ELEMENT_Y=1431;
		private int SECOND_EXECUTION_SPEC_ELEMENT_WIDTH=1498;
		private int SECOND_EXECUTION_SPEC_ELEMENT_HEIGHT=1507;
		private int THIRD_EXECUTION_SPEC_ELEMENT_X=1513;
		private int THIRD_EXECUTION_SPEC_ELEMENT_Y=1636;
		private int THIRD_EXECUTION_SPEC_ELEMENT_WIDTH=1647;
		private int THIRD_EXECUTION_SPEC_ELEMENT_HEIGHT=1692;
		private int FOURTH_EXECUTION_SPEC_ELEMENT_X=1699;
		private int FOURTH_EXECUTION_SPEC_ELEMENT_Y=1734;
		private int FOURTH_EXECUTION_SPEC_ELEMENT_WIDTH=1771;
		private int FOURTH_EXECUTION_SPEC_ELEMENT_HEIGHT=1792;
		private int FIFTH_EXECUTION_SPEC_ELEMENT_X=1794;
		private int FIFTH_EXECUTION_SPEC_ELEMENT_Y=1803;
		private int FIFTH_EXECUTION_SPEC_ELEMENT_WIDTH=1827;
		private int FIFTH_EXECUTION_SPEC_ELEMENT_HEIGHT=1831;
		private int SIXTH_EXECUTION_SPEC_ELEMENT_X=1834;
		private int SIXTH_EXECUTION_SPEC_ELEMENT_Y=1851;
		private int SIXTH_EXECUTION_SPEC_ELEMENT_WIDTH=1934;
		private int SIXTH_EXECUTION_SPEC_ELEMENT_HEIGHT=1975;
		

		
		private string FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID="25";
		private string SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID="26";
		private string THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID="27";
		private string FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID="28";
		private string FIFTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID="29";
	
		private const int FIRST_ANCHORAGE_ELEMENT_X=2608;
		private const int FIRST_ANCHORAGE_ELEMENT_Y=2793;
		
		private const int FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X=3258;
		private const int FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y=3466;
		private const int SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X=3507;
		private const int SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y=3580;
		private const int THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X=3551;
		private const int THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y=3607;
		private const int FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X=3727;
		private const int FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y=3780;
        
		
		private const int SECOND_ANCHORAGE_ELEMENT_X=2804;
		private const int SECOND_ANCHORAGE_ELEMENT_Y=2857;
		private const int THIRD_ANCHORAGE_ELEMENT_X=2901;
		private const int THIRD_ANCHORAGE_ELEMENT_Y=2934;
		private const int FOURTH_ANCHORAGE_ELEMENT_X=3024;
		private const int FOURTH_ANCHORAGE_ELEMENT_Y=3057;
		
		
		
		
	
		
		private string INTERACTION_ELEMENT_ID="9";
		private int INTERACTION_ELEMENT_X=0;
		private int INTERACTION_ELEMENT_Y=0;
		private const string DIAGRAM_NAME="DiagramTestname"; 
		
		private const string FIRST_SEND_OPERATION_EVENT_ELEMENT_ID="42";
		private const string FIRST_RECEIVE_OPERATION_EVENT_ELEMENT_ID="43";
		private const string SECOND_SEND_OPERATION_EVENT_ELEMENT_ID="44";
		private const string SECOND_RECEIVE_OPERATION_EVENT_ELEMENT_ID="45";
		
		private XmlDocument xmiDocument;
		private SequenceChartModelCreator sequenceChartModelCreator;
		private XmiModelDocumentInterpreter modelDocumentInterpreter;
		private PapyrusXmiDIDocumentInterpreter dIDocumentInterpreter;
		private Interaction interaction;
		private XmlElement interactionElement;
		private XmlElement diagramElement;
		private XmlElement modelElement;
		
		private XmlNamespaceManager namespaceManager;
		
		[SetUp]
		public void Init()
		{	
			xmiDocument= new XmlDocument();
			modelDocumentInterpreter=new XmiModelDocumentInterpreter();
			dIDocumentInterpreter=new PapyrusXmiDIDocumentInterpreter(MODEL_DOCUMENT_NAME);
			sequenceChartModelCreator=new SequenceChartModelCreator(modelDocumentInterpreter,dIDocumentInterpreter);
			namespaceManager=new XmlNamespaceManager(xmiDocument.NameTable);
			namespaceManager.AddNamespace(XmiElements.UML_NAMESPACE_PREFIX,XmiElements.UML_NAMESPACE_URI);
			namespaceManager.AddNamespace(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_NAMESPACE_URI);
			
			firstConsideredLifelineHorizontal=
					new Lifeline(POSITION_CONSIDERED_FIRST_ELEMENT_HORIZONTAL,EMPTY_STRING,null);
			secondConsideredLifelineHorizontal=
					new Lifeline(POSITION_CONSIDERED_SECOND_ELEMENT_HORIZONTAL,EMPTY_STRING,null);
			thirdConsideredLifelineHorizontal=
					new Lifeline(POSITION_CONSIDERED_THIRD_ELEMENT_HORIZONTAL,EMPTY_STRING,null);
			fourthConsideredLifelineHorizontal=
					new Lifeline(POSITION_CONSIDERED_FOURTH_ELEMENT_HORIZONTAL,EMPTY_STRING,null);
			fifthConsideredLifelineHorizontal=
					new Lifeline(POSITION_CONSIDERED_FIFTH_ELEMENT_HORIZONTAL,EMPTY_STRING,null);
			
			firstConsideredLifelineVertical=
					new Lifeline(POSITION_CONSIDERED_FIRST_ELEMENT_VERTICAL,EMPTY_STRING,null);
			secondConsideredLifelineVertical=
					new Lifeline(POSITION_CONSIDERED_SECOND_ELEMENT_VERTICAL,EMPTY_STRING,null);
			thirdConsideredLifelineVertical=
					new Lifeline(POSITION_CONSIDERED_THIRD_ELEMENT_VERTICAL,EMPTY_STRING,null);
			fourthConsideredLifelineVertical=
					new Lifeline(POSITION_CONSIDERED_FOURTH_ELEMENT_VERTICAL,EMPTY_STRING,null);
			fifthConsideredLifelineVertical=
					new Lifeline(POSITION_CONSIDERED_FIFTH_ELEMENT_VERTICAL,EMPTY_STRING,null);
			
			interactionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			interaction= new Interaction(ZERO_POSITION,EMPTY_STRING,interactionElement);
			diagramElement =DiagramElementStub.CreateDiagramElementStub(xmiDocument);
		}
		
		
		[Test]
		public void SortListForHorizontalPositionFiveElementsUnsortedTest()
		{
			ArrayList lifelines=new ArrayList();
			lifelines.Add(fifthConsideredLifelineHorizontal);
			lifelines.Add(firstConsideredLifelineHorizontal);
			lifelines.Add(thirdConsideredLifelineHorizontal);
			lifelines.Add(secondConsideredLifelineHorizontal);
			lifelines.Add(fourthConsideredLifelineHorizontal);
				
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForHorizontalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==5);
			
			Lifeline actualFirstLifeline=(Lifeline)sortedLifelines[0];
			Lifeline actualSecondLifeline=(Lifeline)sortedLifelines[1];
			Lifeline actualThirdLifeline=(Lifeline)sortedLifelines[2];
			Lifeline actualFourthLifeline=(Lifeline)sortedLifelines[3];
			Lifeline actualFifthLifeline=(Lifeline)sortedLifelines[4];
						
			Assert.AreEqual(firstConsideredLifelineHorizontal,actualFirstLifeline);
			Assert.AreEqual(secondConsideredLifelineHorizontal,actualSecondLifeline);
			Assert.AreEqual(thirdConsideredLifelineHorizontal,actualThirdLifeline);
			Assert.AreEqual(fourthConsideredLifelineHorizontal,actualFourthLifeline);
			Assert.AreEqual(fifthConsideredLifelineHorizontal,actualFifthLifeline);
		}
		
		[Test]
		public void SortListForHorizontalPositionOneElementTest()
		{
			ArrayList lifelines=new ArrayList();
			lifelines.Add(firstConsideredLifelineHorizontal);
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForHorizontalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==1);
			
			Lifeline actualFirstLifeline=(Lifeline)sortedLifelines[0];					
			Assert.AreEqual(firstConsideredLifelineHorizontal,actualFirstLifeline);
	
		}
		
		[Test]
		public void SortListForHorizontalPositionNoElement()
		{
			ArrayList lifelines=new ArrayList();
			
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForHorizontalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==0);
		}
		
		[Test]
		public void SortListForHorizontalPositionFiveElementsReverseTest()
		{
			ArrayList lifelines=new ArrayList();
			lifelines.Add(fifthConsideredLifelineHorizontal);
			lifelines.Add(fourthConsideredLifelineHorizontal);
			lifelines.Add(thirdConsideredLifelineHorizontal);
			lifelines.Add(secondConsideredLifelineHorizontal);
			lifelines.Add(firstConsideredLifelineHorizontal);
				
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForHorizontalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==5);
			
			Lifeline actualFirstLifeline=(Lifeline)sortedLifelines[0];
			Lifeline actualSecondLifeline=(Lifeline)sortedLifelines[1];
			Lifeline actualThirdLifeline=(Lifeline)sortedLifelines[2];
			Lifeline actualFourthLifeline=(Lifeline)sortedLifelines[3];
			Lifeline actualFifthLifeline=(Lifeline)sortedLifelines[4];
						
			Assert.AreEqual(firstConsideredLifelineHorizontal,actualFirstLifeline);
			Assert.AreEqual(secondConsideredLifelineHorizontal,actualSecondLifeline);
			Assert.AreEqual(thirdConsideredLifelineHorizontal,actualThirdLifeline);
			Assert.AreEqual(fourthConsideredLifelineHorizontal,actualFourthLifeline);
			Assert.AreEqual(fifthConsideredLifelineHorizontal,actualFifthLifeline);
		}
		
		[Test]
		public void SortListForVerticalPositionFiveElementsUnsortedTest()
		{
			ArrayList lifelines=new ArrayList();
			lifelines.Add(fifthConsideredLifelineVertical);
			lifelines.Add(firstConsideredLifelineVertical);
			lifelines.Add(thirdConsideredLifelineVertical);
			lifelines.Add(secondConsideredLifelineVertical);
			lifelines.Add(fourthConsideredLifelineVertical);
				
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForVerticalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==5);
			
			Lifeline actualFirstLifeline=(Lifeline)sortedLifelines[0];
			Lifeline actualSecondLifeline=(Lifeline)sortedLifelines[1];
			Lifeline actualThirdLifeline=(Lifeline)sortedLifelines[2];
			Lifeline actualFourthLifeline=(Lifeline)sortedLifelines[3];
			Lifeline actualFifthLifeline=(Lifeline)sortedLifelines[4];
						
			Assert.AreEqual(firstConsideredLifelineVertical,actualFirstLifeline);
			Assert.AreEqual(secondConsideredLifelineVertical,actualSecondLifeline);
			Assert.AreEqual(thirdConsideredLifelineVertical,actualThirdLifeline);
			Assert.AreEqual(fourthConsideredLifelineVertical,actualFourthLifeline);
			Assert.AreEqual(fifthConsideredLifelineVertical,actualFifthLifeline);
		}
		
		[Test]
		public void SortListForVerticalPositionNoElement()
		{
			ArrayList lifelines=new ArrayList();
			
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForVerticalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==0);
		}
		
		[Test]
		public void SortListForVerticalPositionFiveElementsReverseTest()
		{
			ArrayList lifelines=new ArrayList();
			lifelines.Add(fifthConsideredLifelineVertical);
			lifelines.Add(fourthConsideredLifelineVertical);
			lifelines.Add(thirdConsideredLifelineVertical);
			lifelines.Add(secondConsideredLifelineVertical);
			lifelines.Add(firstConsideredLifelineVertical);
				
			ArrayList sortedLifelines=sequenceChartModelCreator.SortListForVerticalPosition(lifelines);
			Assert.IsNotNull(lifelines);
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==5);
			
			Lifeline actualFirstLifeline=(Lifeline)sortedLifelines[0];
			Lifeline actualSecondLifeline=(Lifeline)sortedLifelines[1];
			Lifeline actualThirdLifeline=(Lifeline)sortedLifelines[2];
			Lifeline actualFourthLifeline=(Lifeline)sortedLifelines[3];
			Lifeline actualFifthLifeline=(Lifeline)sortedLifelines[4];
						
			Assert.AreEqual(firstConsideredLifelineVertical,actualFirstLifeline);
			Assert.AreEqual(secondConsideredLifelineVertical,actualSecondLifeline);
			Assert.AreEqual(thirdConsideredLifelineVertical,actualThirdLifeline);
			Assert.AreEqual(fourthConsideredLifelineVertical,actualFourthLifeline);
			Assert.AreEqual(fifthConsideredLifelineVertical,actualFifthLifeline);
		}
		
		[Test]
		public void CreateMessagesFourElementsTest()
		{
			string interactionElementContent= "<message xmlns:xmi='http://www.omg.org/XMI'  xmi:type='uml:Message' xmi:id='2'/>"+
										"<message xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:Message' xmi:id='4'/>"+
										"<message xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:Message' xmi:id='1'/>"+
										"<message xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:Message' xmi:id='3'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained xsi:type='di2:GraphEdge' position='34:97' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#1'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='124:189' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#2'/>"+
										 	"</semanticModel>" +
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='211:342' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#3'/>"+
										 	"</semanticModel>" +
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='453:623' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#4'/>"+
										 	"</semanticModel>" +
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			sequenceChartModelCreator.CreateMessages(interaction,diagramElement);
			
			ArrayList messages=interaction.Messages;
			int messagesCount=messages.Count;
			Assert.IsTrue(messagesCount==4);
			
			Message firstActualMessage=(Message)messages[0];
			this.AssertXmiId(firstActualMessage,FIRST_MESSAGE_ELEMENT_ID);
			this.AssertPosition(firstActualMessage,FIRST_MESSAGE_ELEMENT_X,FIRST_MESSAGE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(firstActualMessage,FIRST_MESSAGE_ELEMENT_ID);
			
			Message secondActualMessage=(Message)messages[1];
			this.AssertXmiId(secondActualMessage,SECOND_MESSAGE_ELEMENT_ID);
			this.AssertPosition(secondActualMessage,SECOND_MESSAGE_ELEMENT_X,SECOND_MESSAGE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(secondActualMessage,SECOND_MESSAGE_ELEMENT_ID);
			
			Message thirdActualMessage=(Message)messages[2];
			this.AssertXmiId(thirdActualMessage,THIRD_MESSAGE_ELEMENT_ID);
			this.AssertPosition(thirdActualMessage,THIRD_MESSAGE_ELEMENT_X,THIRD_MESSAGE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(thirdActualMessage,THIRD_MESSAGE_ELEMENT_ID);
			
			Message fourthActualMessage=(Message)messages[3];
			this.AssertXmiId(fourthActualMessage,FOURTH_MESSAGE_ELEMENT_ID);
			this.AssertPosition(fourthActualMessage,FOURTH_MESSAGE_ELEMENT_X,FOURTH_MESSAGE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(fourthActualMessage,FOURTH_MESSAGE_ELEMENT_ID);
			
		}
		
		[Test]
		public void CreateMessagesOneElementTest()
		{
			string interactionElementContent= "<message xmlns:xmi='http://www.omg.org/XMI'  xmi:type='uml:Message' xmi:id='1'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained xsi:type='di2:GraphEdge' position='34:97' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#1'/>"+
										 	"</semanticModel>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			sequenceChartModelCreator.CreateMessages(interaction,diagramElement);
			
			ArrayList messages=interaction.Messages;
			int messagesCount=messages.Count;
			Assert.IsTrue(messagesCount==1);
			
			Message firstActualMessage=(Message)messages[0];
			this.AssertXmiId(firstActualMessage,FIRST_MESSAGE_ELEMENT_ID);
			this.AssertPosition(firstActualMessage,FIRST_MESSAGE_ELEMENT_X,FIRST_MESSAGE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(firstActualMessage,FIRST_MESSAGE_ELEMENT_ID);
		}
		
		[Test]
		public void CreateMessagesNoElementTest()
		{
			sequenceChartModelCreator.CreateMessages(interaction,diagramElement);
			
			ArrayList messages=interaction.Messages;
			int messagesCount=messages.Count;
			Assert.IsTrue(messagesCount==0);
		}
		
		[Test]
		public void CreateLifelinesFourElementsTest()
		{
			string interactionElementContent= "<lifeline xmlns:xmi='http://www.omg.org/XMI'  xmi:type='uml:Lifeline' xmi:id='8'/>"+
											  "<lifeline xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:Lifeline' xmi:id='5'/>"+
										      "<lifeline xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:Lifeline' xmi:id='6'/>"+
										      "<lifeline xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:Lifeline' xmi:id='7'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphEdge' position='650:673' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#5'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='703:723' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#6'/>"+
										 	"</semanticModel>" +
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='741:748' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#7'/>"+
										 	"</semanticModel>" +
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='800:814' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#8'/>"+
										 	"</semanticModel>" +
										 "</contained>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			ArrayList lifelines =sequenceChartModelCreator.CreateLifelines(interactionElement,diagramElement);
			 
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==4);
			
			Lifeline firstActualLifeline=(Lifeline)lifelines[0];
			this.AssertXmiId( firstActualLifeline,FIRST_LIFELINE_ELEMENT_ID);
			this.AssertPosition(firstActualLifeline,FIRST_LIFELINE_ELEMENT_X,FIRST_LIFELINE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(firstActualLifeline,FIRST_LIFELINE_ELEMENT_ID);
			
			Lifeline secondActualLifeline=(Lifeline)lifelines[1];
			this.AssertXmiId( secondActualLifeline,SECOND_LIFELINE_ELEMENT_ID);
			this.AssertPosition(secondActualLifeline,SECOND_LIFELINE_ELEMENT_X,SECOND_LIFELINE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(secondActualLifeline,SECOND_LIFELINE_ELEMENT_ID);
			
			Lifeline thirdActualLifeline=(Lifeline)lifelines[2];
			this.AssertXmiId( thirdActualLifeline,THIRD_LIFELINE_ELEMENT_ID);
			this.AssertPosition(thirdActualLifeline,THIRD_LIFELINE_ELEMENT_X,THIRD_LIFELINE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(thirdActualLifeline,THIRD_LIFELINE_ELEMENT_ID);
			
			Lifeline fourthActualLifeline=(Lifeline)lifelines[3];
			this.AssertXmiId( fourthActualLifeline,FOURTH_LIFELINE_ELEMENT_ID);
			this.AssertPosition(fourthActualLifeline,FOURTH_LIFELINE_ELEMENT_X,FOURTH_LIFELINE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(fourthActualLifeline,FOURTH_LIFELINE_ELEMENT_ID);
		}
		
		[Test]
		public void CreateLifelinesOneElementTest()
		{
			string interactionElementContent= "<lifeline xmlns:xmi='http://www.omg.org/XMI'  xmi:type='uml:Lifeline' xmi:id='5'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphEdge' position='650:673' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#5'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			ArrayList lifelines =sequenceChartModelCreator.CreateLifelines(interactionElement,diagramElement);
			 
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==1);
			
			Lifeline firstActualLifeline=(Lifeline)lifelines[0];
			this.AssertXmiId( firstActualLifeline,FIRST_LIFELINE_ELEMENT_ID);
			this.AssertPosition(firstActualLifeline,FIRST_LIFELINE_ELEMENT_X,FIRST_LIFELINE_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(firstActualLifeline,FIRST_LIFELINE_ELEMENT_ID);
			
		}
		
		[Test]
		public void CreateLifelinesNoElementTest()
		{
			ArrayList lifelines =sequenceChartModelCreator.CreateLifelines(interactionElement,diagramElement);
			 
			int lifelinesCount=lifelines.Count;
			Assert.IsTrue(lifelinesCount==0);
		}
		
		[Test]
		public void CreateInteractionTest()
		{
			interactionElement.SetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME,INTERACTION_ELEMENT_ID);
			interactionElement.SetAttribute(UmlModelElements.NAME_ATTR_NAME,DIAGRAM_NAME);
			
			Interaction createdInteraction=sequenceChartModelCreator.CreateInteraction(interactionElement);
			Assert.IsNotNull(createdInteraction);
			this.AssertIdOfXmiRepresentation(createdInteraction,INTERACTION_ELEMENT_ID);
			string createdInteractionName=createdInteraction.Name;
			Assert.AreEqual(DIAGRAM_NAME,createdInteractionName);
			this.AssertPosition(createdInteraction,INTERACTION_ELEMENT_X,INTERACTION_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(createdInteraction,INTERACTION_ELEMENT_ID);
		}
		
		[Test]
		public void CreateExecutionsForLifelineThreeExecutionsTest()
		{
			string interactionElementContent = "<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='11'/>"+
									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI'  xmi:id='10'/>"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI'  xmi:id='12'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='11'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='11'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='12'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='12'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphEdge' position='1002:1234' size='1256:1309' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#10'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1345:1431' size='1498:1507' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#11'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1513:1636' size='1647:1692' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#12'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			XmlElement lifelineElement=(XmlElement)interactionElement.FirstChild;
			Lifeline lifeline=new Lifeline(ZERO_POSITION,"",lifelineElement);
			
			//sequenceChartModelCreator.CreateExecutionsForLifeline(lifeline,diagramElement);
			
			ArrayList executions=lifeline.ExecutionSpecifications;
			int executionsCount=executions.Count;
			Assert.IsTrue(executionsCount==3);
			
			ExecutionSpecification firstActualBehaviorSpec=
							(ExecutionSpecification)executions[0];
			AssertXmiId(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			AssertPosition(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_X,FIRST_EXECUTION_SPEC_ELEMENT_Y);
			AssertDimension(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_WIDTH,FIRST_EXECUTION_SPEC_ELEMENT_HEIGHT);
			AssertIdOfXmiRepresentation(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			
			ExecutionSpecification secondActualBehaviorSpec=
							(ExecutionSpecification)executions[1];
			AssertXmiId(secondActualBehaviorSpec,SECOND_EXECUTION_SPEC_ELEMENT_ID);
			AssertPosition(secondActualBehaviorSpec,SECOND_EXECUTION_SPEC_ELEMENT_X,SECOND_EXECUTION_SPEC_ELEMENT_Y);
			AssertDimension(secondActualBehaviorSpec,SECOND_EXECUTION_SPEC_ELEMENT_WIDTH,SECOND_EXECUTION_SPEC_ELEMENT_HEIGHT);
			AssertIdOfXmiRepresentation(secondActualBehaviorSpec,SECOND_EXECUTION_SPEC_ELEMENT_ID);
			
			ExecutionSpecification thirdActualBehaviorSpec=
							(ExecutionSpecification)executions[2];
			AssertXmiId(thirdActualBehaviorSpec,THIRD_EXECUTION_SPEC_ELEMENT_ID);
			AssertPosition(thirdActualBehaviorSpec,THIRD_EXECUTION_SPEC_ELEMENT_X,THIRD_EXECUTION_SPEC_ELEMENT_Y);
			AssertDimension(thirdActualBehaviorSpec,THIRD_EXECUTION_SPEC_ELEMENT_WIDTH,THIRD_EXECUTION_SPEC_ELEMENT_HEIGHT);
			AssertIdOfXmiRepresentation(thirdActualBehaviorSpec,THIRD_EXECUTION_SPEC_ELEMENT_ID);
		}
		
		[Test]
		public void CreateExecutionsForLifelineOneExecutionTest()
		{
			string interactionElementContent = "<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' covered='5' execution='10'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphEdge' position='1002:1234' size='1256:1309' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#10'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			XmlElement lifelineElement=(XmlElement)interactionElement.FirstChild;
			Lifeline lifeline=new Lifeline(ZERO_POSITION,"",lifelineElement);
			
			//sequenceChartModelCreator.CreateExecutionsForLifeline(lifeline,diagramElement);
			
			ArrayList executions=lifeline.ExecutionSpecifications;
			int executionsCount=executions.Count;
			Assert.IsTrue(executionsCount==1);
			
			ExecutionSpecification firstActualBehaviorSpec=
							(ExecutionSpecification)executions[0];
			AssertXmiId(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			AssertPosition(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_X,FIRST_EXECUTION_SPEC_ELEMENT_Y);
			AssertDimension(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_WIDTH,FIRST_EXECUTION_SPEC_ELEMENT_HEIGHT);
			AssertIdOfXmiRepresentation(firstActualBehaviorSpec,FIRST_EXECUTION_SPEC_ELEMENT_ID);
		}
		
		[Test]
		public void CreateExecutionsForLifelineNoExecutionTest()
		{
			string interactionElementContent = "<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained></contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			XmlElement lifelineElement=(XmlElement)interactionElement.FirstChild;
			Lifeline lifeline=new Lifeline(ZERO_POSITION,"",lifelineElement);
			
			//sequenceChartModelCreator.CreateExecutionsForLifeline(lifeline,diagramElement);
			
			ArrayList executions=lifeline.ExecutionSpecifications;
			int executionsCount=executions.Count;
			Assert.IsTrue(executionsCount==0);
		}
		
		[Test]
		public void CreateExecutionsForLifelinesThreeElementsTest()
		{
			string interactionElementContent = "<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='11'/>"+
									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI'  xmi:id='10'/>"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI'  xmi:id='12'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='11'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='11'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='12'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='12'/>"+
									"<lifeline xmi:id='6' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='14'/>"+	
									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='15'/>"+		
									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='6' execution='13'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='6' execution='13'/>"+
				                    "<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='6' execution='14'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='6' execution='14'/>"+
									"<lifeline xmi:id='7' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='13'/>"+		
									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='7' execution='15'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='7' execution='15'/>";
				                 
				
			interactionElement.InnerXml=interactionElementContent;
			XmlElement firstLifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='5']",namespaceManager);
			Lifeline firstLifeline=new Lifeline(ZERO_POSITION,"",firstLifelineElement);
			XmlElement secondLifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='6']",namespaceManager);
			Lifeline secondLifeline=new Lifeline(ZERO_POSITION,"",secondLifelineElement);
			XmlElement thirdLifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='7']",namespaceManager);
			Lifeline thirdLifeline=new Lifeline(ZERO_POSITION,"",thirdLifelineElement);
			ArrayList lifelines=new ArrayList();
			lifelines.Add(firstLifeline);
			lifelines.Add(secondLifeline);
			lifelines.Add(thirdLifeline);
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphEdge' position='1002:1234' size='1256:1309' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#10'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1345:1431' size='1498:1507' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#11'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1513:1636' size='1647:1692' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#12'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1699:1734' size='1771:1792' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#13'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
				                          "<contained xsi:type='di2:GraphEdge' position='1794:1803' size='1827:1831' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#14'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
				                         "<contained xsi:type='di2:GraphEdge' position='1834:1851' size='1934:1975' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#15'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
		//	sequenceChartModelCreator.CreateExecutionsForLifelines(lifelines,diagramElement);
            
			ArrayList executionSpecsFirstLifeline=firstLifeline.ExecutionSpecifications;
			Assert.IsNotNull(executionSpecsFirstLifeline);
			int executionSpecsFirstLifelineCount=executionSpecsFirstLifeline.Count;
			Assert.IsTrue(executionSpecsFirstLifelineCount==3);
			
			ExecutionSpecification firstExecutionSpecFirstLifeline=
									(ExecutionSpecification)executionSpecsFirstLifeline[0];
			Assert.IsNotNull(firstExecutionSpecFirstLifeline);
			this.AssertIdOfXmiRepresentation(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_X,FIRST_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_WIDTH,FIRST_EXECUTION_SPEC_ELEMENT_HEIGHT);
			ExecutionSpecification secondExecutionSpecFirstLifeline=
									(ExecutionSpecification)executionSpecsFirstLifeline[1];
			Assert.IsNotNull(secondExecutionSpecFirstLifeline);
			this.AssertIdOfXmiRepresentation(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_X,SECOND_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_WIDTH,SECOND_EXECUTION_SPEC_ELEMENT_HEIGHT);
			ExecutionSpecification thirdExecutionSpecFirstLifeline=
									(ExecutionSpecification)executionSpecsFirstLifeline[2];
			Assert.IsNotNull(secondExecutionSpecFirstLifeline);
			this.AssertIdOfXmiRepresentation(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_X,THIRD_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_WIDTH,THIRD_EXECUTION_SPEC_ELEMENT_HEIGHT);
			
			ArrayList executionSpecsSecondLifeline=secondLifeline.ExecutionSpecifications;
			Assert.IsNotNull(executionSpecsSecondLifeline);
			int executionSpecsSecondLifelineCount=executionSpecsSecondLifeline.Count;
			Assert.IsTrue(executionSpecsSecondLifelineCount==2);
			ExecutionSpecification firstExecutionSpecSecondLifeline=
									(ExecutionSpecification)executionSpecsSecondLifeline[0];
			Assert.IsNotNull(firstExecutionSpecSecondLifeline);
			this.AssertIdOfXmiRepresentation(firstExecutionSpecSecondLifeline,FOURTH_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(firstExecutionSpecSecondLifeline,FOURTH_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(firstExecutionSpecSecondLifeline,FOURTH_EXECUTION_SPEC_ELEMENT_X,FOURTH_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(firstExecutionSpecSecondLifeline,FOURTH_EXECUTION_SPEC_ELEMENT_WIDTH,FOURTH_EXECUTION_SPEC_ELEMENT_HEIGHT);
			ExecutionSpecification secondExecutionSpecSecondLifeline=
									(ExecutionSpecification)executionSpecsSecondLifeline[1];
			Assert.IsNotNull(secondExecutionSpecSecondLifeline);
			this.AssertIdOfXmiRepresentation(secondExecutionSpecSecondLifeline,FIFTH_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(secondExecutionSpecSecondLifeline,FIFTH_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(secondExecutionSpecSecondLifeline,FIFTH_EXECUTION_SPEC_ELEMENT_X,FIFTH_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(secondExecutionSpecSecondLifeline,FIFTH_EXECUTION_SPEC_ELEMENT_WIDTH,FIFTH_EXECUTION_SPEC_ELEMENT_HEIGHT);
			ArrayList executionSpecsThirdLifeline=thirdLifeline.ExecutionSpecifications;
			Assert.IsNotNull(executionSpecsThirdLifeline);
			int executionSpecsThirdLifelineCount=executionSpecsThirdLifeline.Count;
			Assert.IsTrue(executionSpecsThirdLifelineCount==1);
			ExecutionSpecification thirdExecutionSpecThirdLifeline=
									(ExecutionSpecification)executionSpecsThirdLifeline[0];
			Assert.IsNotNull(thirdExecutionSpecThirdLifeline);
			this.AssertIdOfXmiRepresentation(thirdExecutionSpecThirdLifeline,SIXTH_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(thirdExecutionSpecThirdLifeline,SIXTH_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(thirdExecutionSpecThirdLifeline,SIXTH_EXECUTION_SPEC_ELEMENT_X,SIXTH_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(thirdExecutionSpecThirdLifeline,SIXTH_EXECUTION_SPEC_ELEMENT_WIDTH,SIXTH_EXECUTION_SPEC_ELEMENT_HEIGHT);
		}
		
	
		[Test]
		public void CreateExecutionsForLifelinesOneElementTest()
		{
			string interactionElementContent = "<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='11'/>"+
									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI'  xmi:id='10'/>"+
 									"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmlns:xmi='http://www.omg.org/XMI'  xmi:id='12'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='10'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='11'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='11'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='12'/>"+
 									"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI'  covered='5' execution='12'/>";
				                 
				
			interactionElement.InnerXml=interactionElementContent;
			XmlElement firstLifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='5']",namespaceManager);
			Lifeline firstLifeline=new Lifeline(ZERO_POSITION,"",firstLifelineElement);
			ArrayList lifelines=new ArrayList();
			lifelines.Add(firstLifeline);
			
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphEdge' position='1002:1234' size='1256:1309' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#10'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1345:1431' size='1498:1507' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#11'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='1513:1636' size='1647:1692' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:BehaviorExecutionSpecification' href='TheTestModel.uml#12'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										"</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
		//	sequenceChartModelCreator.CreateExecutionsForLifelines(lifelines,diagramElement);
            
			ArrayList executionSpecsFirstLifeline=firstLifeline.ExecutionSpecifications;
			Assert.IsNotNull(executionSpecsFirstLifeline);
			int executionSpecsFirstLifelineCount=executionSpecsFirstLifeline.Count;
			Assert.IsTrue(executionSpecsFirstLifelineCount==3);
					
			ExecutionSpecification firstExecutionSpecFirstLifeline=
									(ExecutionSpecification)executionSpecsFirstLifeline[0];
			Assert.IsNotNull(firstExecutionSpecFirstLifeline);
			this.AssertIdOfXmiRepresentation(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_X,FIRST_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(firstExecutionSpecFirstLifeline,FIRST_EXECUTION_SPEC_ELEMENT_WIDTH,FIRST_EXECUTION_SPEC_ELEMENT_HEIGHT);
			ExecutionSpecification secondExecutionSpecFirstLifeline=
									(ExecutionSpecification)executionSpecsFirstLifeline[1];
			Assert.IsNotNull(secondExecutionSpecFirstLifeline);
			this.AssertIdOfXmiRepresentation(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_X,SECOND_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(secondExecutionSpecFirstLifeline,SECOND_EXECUTION_SPEC_ELEMENT_WIDTH,SECOND_EXECUTION_SPEC_ELEMENT_HEIGHT);
			ExecutionSpecification thirdExecutionSpecFirstLifeline=
									(ExecutionSpecification)executionSpecsFirstLifeline[2];
			Assert.IsNotNull(secondExecutionSpecFirstLifeline);
			this.AssertIdOfXmiRepresentation(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertXmiId(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_ID);
			this.AssertPosition(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_X,THIRD_EXECUTION_SPEC_ELEMENT_Y);
			this.AssertDimension(thirdExecutionSpecFirstLifeline,THIRD_EXECUTION_SPEC_ELEMENT_WIDTH,THIRD_EXECUTION_SPEC_ELEMENT_HEIGHT);
		}
		
		[Test]
		public void CreateExecutionsForLifelinesOneLifelineNoInteractionsTest()
		{
			
				  
			interactionElement.InnerXml="<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />";
			XmlElement lifelineElement= (XmlElement)interactionElement.FirstChild;
			Lifeline lifeline=new Lifeline(ZERO_POSITION,FIRST_LIFELINE_ELEMENT_ID,lifelineElement);
			ArrayList lifelines=new ArrayList();
			lifelines.Add(lifeline);
			
			string diagramElementContent="<contained>" +
										"</contained>";
			diagramElement.InnerXml=diagramElementContent;
			//sequenceChartModelCreator.CreateExecutionsForLifelines(lifelines,diagramElement);
			ArrayList executionSpecsLifeline=lifeline.MessageEnds;
			Assert.IsNotNull(executionSpecsLifeline);
			int executionSpecsLifelineCount=executionSpecsLifeline.Count;
			Assert.IsTrue(executionSpecsLifelineCount==0);
			
		}

		
		//**********************************************************************
		[Test]
		public void CreateMessageEndsForLifelineFourMessageOccurrenceSpecsTest()
		{			
			string interactionElementContent = "<message xmi:id='1' xmlns:xmi='http://www.omg.org/XMI' />"+
								    "<message xmi:id='2' xmlns:xmi='http://www.omg.org/XMI' />"+
									"<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />"+
									"<lifeline xmi:id='6' xmlns:xmi='http://www.omg.org/XMI' />"+
 									"<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='27' message='2' event='44' covered='5'/>"+
									"<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='25' message='1' event='42' covered='5'/>"+
 									"<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='28' message='2' event='45' covered='6'/>"+
 									"<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='26' message='1' event='43' covered='6'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphNode' position='650:673' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' >"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#5'/>"+
										 	"</semanticModel>"+
											"<anchorage position='2608:2793' graphEdge='/0/@contained.1'/>"+
											"<anchorage position='2901:2934' graphEdge='/0/@contained.2'/>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphNode' position='703:723' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#6'/>"+
										 	"</semanticModel>"+
											"<anchorage position='2804:2857' graphEdge='/0/@contained.1'/>"+
				                            "<anchorage position='3024:3057' graphEdge='/0/@contained.2'/>"+
										 "</contained>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='34:97' anchor='/1/@contained.0/@contained.0/@anchorage.0 /1/@contained.0/@contained.1/@anchorage.0' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#1'/>"+
										 	"</semanticModel>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='124:189' anchor='/1/@contained.0/@contained.0/@anchorage.1 /1/@contained.0/@contained.1/@anchorage.1' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#2'/>"+
										 	"</semanticModel>"+
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			
			XmlElement firstSendOperationEventElement=
					SendOperationEventElementStub.CreateSendOperationEventElementStub(xmiDocument,FIRST_SEND_OPERATION_EVENT_ELEMENT_ID,"");
			XmlElement firstReceiveOperationEventElement=
					ReceiveOperationEventElementStub.CreateReceiveOperationEventElementStub(xmiDocument,FIRST_RECEIVE_OPERATION_EVENT_ELEMENT_ID,"");
			XmlElement secondSendOperationEventElement=
					SendOperationEventElementStub.CreateSendOperationEventElementStub(xmiDocument,SECOND_SEND_OPERATION_EVENT_ELEMENT_ID,"");
			XmlElement secondReceiveOperationEventElement=
					ReceiveOperationEventElementStub.CreateReceiveOperationEventElementStub(xmiDocument,SECOND_RECEIVE_OPERATION_EVENT_ELEMENT_ID,"");
			
			modelElement.AppendChild(interactionElement);
			modelElement.AppendChild(firstSendOperationEventElement);
			modelElement.AppendChild(firstReceiveOperationEventElement);
			modelElement.AppendChild(secondSendOperationEventElement);
			modelElement.AppendChild(secondReceiveOperationEventElement);
			
			Interaction interaction=new Interaction(ZERO_POSITION,"",interactionElement);
			
			XmlElement lifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='5']",this.namespaceManager);
			Lifeline lifeline=new Lifeline(ZERO_POSITION,"5",lifelineElement);
			
			sequenceChartModelCreator.CreateMessageEndsForLifeline(lifeline,diagramElement,interaction);
			
			ArrayList messageOccurrenceSpecs=lifeline.MessageEnds;
			int messageOccurrenceSpecsCount=messageOccurrenceSpecs.Count;
			Assert.IsTrue(messageOccurrenceSpecsCount==2);
			
			MessageEnd firstActualMessageEnd=(MessageEnd)messageOccurrenceSpecs[0];
			this.AssertXmiId(firstActualMessageEnd,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			this.AssertPosition(firstActualMessageEnd,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(firstActualMessageEnd,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			EventKind firstMessageEndEventKind=firstActualMessageEnd.AssociatedEventKind;
			Assert.IsTrue(firstMessageEndEventKind==EventKind.sendOperationEvent);
			
			MessageEnd thirdActualMessageEnd=(MessageEnd)messageOccurrenceSpecs[1];
			this.AssertXmiId(thirdActualMessageEnd,THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			this.AssertPosition(thirdActualMessageEnd,THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X,THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(thirdActualMessageEnd,THIRD_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			EventKind thirdMessageEndEventKind=thirdActualMessageEnd.AssociatedEventKind;
			Assert.IsTrue(thirdMessageEndEventKind==EventKind.sendOperationEvent);
			
			XmlElement secondLifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='6']",this.namespaceManager);;
			Lifeline secondLifeline=new Lifeline(ZERO_POSITION,"",secondLifelineElement);
			
			sequenceChartModelCreator.CreateMessageEndsForLifeline(secondLifeline,diagramElement,interaction);
			
			messageOccurrenceSpecs=secondLifeline.MessageEnds;
			messageOccurrenceSpecsCount=messageOccurrenceSpecs.Count;
			Assert.IsTrue(messageOccurrenceSpecsCount==2);
			MessageEnd secondActualMessageEnd=(MessageEnd)messageOccurrenceSpecs[0];
			this.AssertXmiId(secondActualMessageEnd,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			this.AssertPosition(secondActualMessageEnd,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(secondActualMessageEnd,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			EventKind secondMessageEndEventKind=secondActualMessageEnd.AssociatedEventKind;
			Assert.IsTrue(secondMessageEndEventKind==EventKind.receiveOperationEvent);
			
			MessageEnd fourthActualMessageEnd=(MessageEnd)messageOccurrenceSpecs[1];
			this.AssertXmiId(fourthActualMessageEnd,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			this.AssertPosition(fourthActualMessageEnd,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(fourthActualMessageEnd,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			EventKind fourthMessageEndEventKind=fourthActualMessageEnd.AssociatedEventKind;
			Assert.IsTrue(fourthMessageEndEventKind==EventKind.receiveOperationEvent);
		}
		
		
		[Test]
		public void CreateMessageEndsForLifelineTwoMessageOccurrenceSpecTest()
		{
			
		string interactionElementContent = "<message xmi:id='1' xmlns:xmi='http://www.omg.org/XMI' />"+
									"<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />"+
									"<lifeline xmi:id='6' xmlns:xmi='http://www.omg.org/XMI' />"+
									"<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='25' message='1' covered='5' event='42'/>"+
 									"<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='26' message='1' covered='6' event='43'/>";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "<contained xsi:type='di2:GraphNode' position='650:673' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' >"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#5'/>"+
										 	"</semanticModel>"+
											"<anchorage position='2608:2793' graphEdge='/0/@contained.1'/>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphNode' position='703:723' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Lifeline' href='TheTestModel.uml#6'/>"+
										 	"</semanticModel>"+
											"<anchorage position='2804:2857' graphEdge='/0/@contained.1'/>"+
										 "</contained>"+
										 "</contained>"+
										 "<contained xsi:type='di2:GraphEdge' position='34:97' anchor='/1/@contained.0/@contained.0/@anchorage.0 /1/@contained.0/@contained.1/@anchorage.0' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>"+
										 	"<semanticModel>"+
										 		"<element xsi:type='uml:Message' href='TheTestModel.uml#1'/>"+
										 	"</semanticModel>"+
										 "</contained>";

			diagramElement.InnerXml=diagramElementContent;
			
			XmlElement firstSendOperationEventElement=
					SendOperationEventElementStub.CreateSendOperationEventElementStub(xmiDocument,FIRST_SEND_OPERATION_EVENT_ELEMENT_ID,"");
			XmlElement firstReceiveOperationEventElement=
					ReceiveOperationEventElementStub.CreateReceiveOperationEventElementStub(xmiDocument,FIRST_RECEIVE_OPERATION_EVENT_ELEMENT_ID,"");
			
			modelElement.AppendChild(interactionElement);
			modelElement.AppendChild(firstSendOperationEventElement);
			modelElement.AppendChild(firstReceiveOperationEventElement);
			
			
			Interaction interaction=new Interaction(ZERO_POSITION,"",interactionElement);
			
			XmlElement lifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='5']",this.namespaceManager);;
			Lifeline lifeline=new Lifeline(ZERO_POSITION,"",lifelineElement);
			
			sequenceChartModelCreator.CreateMessageEndsForLifeline(lifeline,diagramElement,interaction);
			
			ArrayList messageOccurrenceSpecs=lifeline.MessageEnds;
			int messageOccurrenceSpecsCount=messageOccurrenceSpecs.Count;
			Assert.IsTrue(messageOccurrenceSpecsCount==1);
			
			MessageEnd firstActualMessageEnd=(MessageEnd)messageOccurrenceSpecs[0];
			this.AssertXmiId(firstActualMessageEnd,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			this.AssertPosition(firstActualMessageEnd,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(firstActualMessageEnd,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			EventKind firstMessageEndEventKind=firstActualMessageEnd.AssociatedEventKind;
			Assert.IsTrue(firstMessageEndEventKind==EventKind.sendOperationEvent);
			
			
			XmlElement secondLifelineElement=(XmlElement)interactionElement.SelectSingleNode("//lifeline[@xmi:id='6']",this.namespaceManager);;
			Lifeline secondLifeline=new Lifeline(ZERO_POSITION,"",secondLifelineElement);
			
			sequenceChartModelCreator.CreateMessageEndsForLifeline(secondLifeline,diagramElement,interaction);
			
			messageOccurrenceSpecs=secondLifeline.MessageEnds;
			messageOccurrenceSpecsCount=messageOccurrenceSpecs.Count;
			Assert.IsTrue(messageOccurrenceSpecsCount==1);
			MessageEnd secondActualMessageEnd=(MessageEnd)messageOccurrenceSpecs[0];
			this.AssertXmiId(secondActualMessageEnd,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			this.AssertPosition(secondActualMessageEnd,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_X,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_Y);
			this.AssertIdOfXmiRepresentation(secondActualMessageEnd,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			EventKind secondMessageEndEventKind=secondActualMessageEnd.AssociatedEventKind;
			Assert.IsTrue(secondMessageEndEventKind==EventKind.receiveOperationEvent);
		}
		
		[Test]
		public void CreateMessageEndsForLifelineNoMessageOccurrenceSpecTest()
		{
			string interactionElementContent = "<lifeline xmi:id='5' xmlns:xmi='http://www.omg.org/XMI' />";
			interactionElement.InnerXml=interactionElementContent;
			
			string diagramElementContent="<contained>" +
										 "</contained>";
			diagramElement.InnerXml=diagramElementContent;
			
			XmlElement lifelineElement=(XmlElement)interactionElement.FirstChild;
			Lifeline lifeline=new Lifeline(ZERO_POSITION,"",lifelineElement);
			Interaction interaction=new Interaction(ZERO_POSITION,"",interactionElement);
			
			sequenceChartModelCreator.CreateMessageEndsForLifeline(lifeline,diagramElement,interaction);
			
			ArrayList messageOccurrenceSpecs=lifeline.MessageEnds;
			int messageOccurrenceSpecsCount=messageOccurrenceSpecs.Count;
			Assert.IsTrue(messageOccurrenceSpecsCount==0);
		}
		
		
		
		[Test]
		public void ConnectMessageEndToMessagesTest()
		{
			XmlElement firstMessageElement =MessageElementStub.CreateMessageElementStub(xmiDocument,FIRST_MESSAGE_ELEMENT_ID);
			firstMessageElement.SetAttribute(UmlModelElements.SEND_EVENT_ATTR_NAME,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			firstMessageElement.SetAttribute(UmlModelElements.RECEIVE_EVENT_ATTR_NAME,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			Message firstMessage =new Message(ZERO_POSITION,FIRST_MESSAGE_ELEMENT_ID,firstMessageElement);
			
			XmlElement firstSourceMessageEndElement=
				MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(xmiDocument,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			firstSourceMessageEndElement.SetAttribute(UmlModelElements.MESSAGE_ATTR_NAME,FIRST_MESSAGE_ELEMENT_ID);
			MessageEnd firstSourceMessageEnd=new MessageEnd(ZERO_POSITION,FIRST_MESSAGE_ELEMENT_ID,firstSourceMessageEndElement);
			
			XmlElement firstDestinationMessageEndElement=
					MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(xmiDocument,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			firstDestinationMessageEndElement.SetAttribute(UmlModelElements.MESSAGE_ATTR_NAME,FIRST_MESSAGE_ELEMENT_ID);
			MessageEnd firstDestinationMessageEnd=new MessageEnd(ZERO_POSITION,FOURTH_MESSAGE_ELEMENT_ID,firstDestinationMessageEndElement);
			
			XmlElement secondMessageElement =MessageElementStub.CreateMessageElementStub(xmiDocument,SECOND_MESSAGE_ELEMENT_ID);
			secondMessageElement.SetAttribute(UmlModelElements.SEND_EVENT_ATTR_NAME,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			secondMessageElement.SetAttribute(UmlModelElements.RECEIVE_EVENT_ATTR_NAME,FIFTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			Message secondMessage =new Message(ZERO_POSITION,SECOND_MESSAGE_ELEMENT_ID,secondMessageElement);
			
			XmlElement secondSourceMessageEndElement=
				MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(xmiDocument,SECOND_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			secondSourceMessageEndElement.SetAttribute(UmlModelElements.MESSAGE_ATTR_NAME,SECOND_MESSAGE_ELEMENT_ID);
			MessageEnd secondSourceMessageEnd=new MessageEnd(ZERO_POSITION,SECOND_MESSAGE_ELEMENT_ID,secondSourceMessageEndElement);
			
			XmlElement secondDestinationMessageEndElement=
					MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(xmiDocument,FIFTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			secondDestinationMessageEndElement.SetAttribute(UmlModelElements.MESSAGE_ATTR_NAME,SECOND_MESSAGE_ELEMENT_ID);
			MessageEnd secondDestinationMessageEnd=new MessageEnd(ZERO_POSITION,FIFTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID,secondDestinationMessageEndElement);
			
			Lifeline firstLifeline=new Lifeline(ZERO_POSITION,"",null);
			firstLifeline.MessageEnds.Add(firstSourceMessageEnd);
			firstLifeline.MessageEnds.Add(secondSourceMessageEnd);
			
			Lifeline secondLifeline=new Lifeline(ZERO_POSITION,"",null);
			secondLifeline.MessageEnds.Add(firstDestinationMessageEnd);
			secondLifeline.MessageEnds.Add(secondDestinationMessageEnd);
			
			interactionElement.AppendChild(firstMessageElement);
			interactionElement.AppendChild(secondMessageElement);
			interactionElement.AppendChild(firstSourceMessageEndElement);
			interactionElement.AppendChild(firstDestinationMessageEndElement);
			interactionElement.AppendChild(secondSourceMessageEndElement);
			interactionElement.AppendChild(secondDestinationMessageEndElement);
			
			Interaction interaction=new Interaction(ZERO_POSITION,"",null);
			interaction.Messages.Add(firstMessage);
			interaction.Messages.Add(secondMessage);
			
			ArrayList relevantMessageEnds=new ArrayList();
			relevantMessageEnds.Add(firstSourceMessageEnd);
			relevantMessageEnds.Add(firstDestinationMessageEnd);
			relevantMessageEnds.Add(secondSourceMessageEnd);
			relevantMessageEnds.Add(secondDestinationMessageEnd);
			
			ArrayList relevantLifelines=new ArrayList();
			relevantLifelines.Add(firstLifeline);
			relevantLifelines.Add(secondLifeline);
			
			sequenceChartModelCreator.ConnectMessageEndsToMessage(relevantLifelines,interaction);
			
			MessageEnd firstActualSoureMessageEnd=firstMessage.SourceMessageEnd;
			Assert.IsNotNull(firstActualSoureMessageEnd);
			Assert.AreEqual(firstSourceMessageEnd,firstActualSoureMessageEnd);
			MessageEnd firstActualDestinationMessageEnd=firstMessage.DestinationMessageEnd;
			Assert.IsNotNull(firstActualDestinationMessageEnd);
			Assert.AreEqual(firstActualDestinationMessageEnd,firstActualDestinationMessageEnd);
			
			MessageEnd secondActualSoureMessageEnd=secondMessage.SourceMessageEnd;
			Assert.IsNotNull(secondActualSoureMessageEnd);
			Assert.AreEqual(secondSourceMessageEnd,secondActualSoureMessageEnd);
			MessageEnd secondActualDestinationMessageEnd=secondMessage.DestinationMessageEnd;
			Assert.IsNotNull(secondActualDestinationMessageEnd);
			Assert.AreEqual(secondActualDestinationMessageEnd,secondActualDestinationMessageEnd);
			
			
		}
		
		[Test]
		public void ConnectMessageEndToMessageTest()
		{
			XmlElement messageElement =MessageElementStub.CreateMessageElementStub(xmiDocument,FIRST_MESSAGE_ELEMENT_ID);
			messageElement.SetAttribute(UmlModelElements.SEND_EVENT_ATTR_NAME,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			messageElement.SetAttribute(UmlModelElements.RECEIVE_EVENT_ATTR_NAME,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			Message message =new Message(ZERO_POSITION,FIRST_MESSAGE_ELEMENT_ID,messageElement);
			
			XmlElement sourceMessageEndElement=
				MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(xmiDocument,FIRST_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			sourceMessageEndElement.SetAttribute(UmlModelElements.MESSAGE,FIRST_MESSAGE_ELEMENT_ID);
			MessageEnd sourceMessageEnd=new MessageEnd(ZERO_POSITION,FIRST_MESSAGE_ELEMENT_ID,sourceMessageEndElement);
			
			XmlElement destinationMessageEndElement=
					MessageOccurrenceSpecElementStub.CreateMessageOccurrenceSpecElementStub(xmiDocument,FOURTH_MESSAGE_OCCURRENCE_SPEC_ELEMENT_ID);
			destinationMessageEndElement.SetAttribute(UmlModelElements.MESSAGE,FIRST_MESSAGE_ELEMENT_ID);
			MessageEnd destinationMessageEnd=new MessageEnd(ZERO_POSITION,FOURTH_MESSAGE_ELEMENT_ID,destinationMessageEndElement);
			
			sequenceChartModelCreator.ConnectMessageEndToMessage(sourceMessageEnd,message);
			MessageEnd actualSoureMessageEnd=message.SourceMessageEnd;
			Assert.IsNotNull(actualSoureMessageEnd);
			Assert.AreEqual(sourceMessageEnd,actualSoureMessageEnd);
			MessageEnd actualDestinationMessageEnd=message.DestinationMessageEnd;
			Assert.IsNull(actualDestinationMessageEnd);
			
			message.SourceMessageEnd=null;
			sequenceChartModelCreator.ConnectMessageEndToMessage(destinationMessageEnd,message);
			actualDestinationMessageEnd=message.DestinationMessageEnd;
			Assert.IsNotNull(actualDestinationMessageEnd);
			Assert.AreEqual(destinationMessageEnd,actualDestinationMessageEnd);
			MessageEnd actualSourceElement=message.SourceMessageEnd;
			Assert.IsNull(actualSourceElement);
		}
		
		[Test]
		public void GetMessageForMessageElementThreeElementsTest()
		{
			XmlElement firstMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			XmlElement secondMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			XmlElement thirdMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			Message firstMessage=new Message(ZERO_POSITION,"",firstMessageElement);
			Message secondMessage=new Message(ZERO_POSITION,"",secondMessageElement);
			Message thirdMessage=new Message(ZERO_POSITION,"",thirdMessageElement);
			Interaction interaction=new Interaction(ZERO_POSITION,"",null);
			interaction.Messages.Add(firstMessage);
			interaction.Messages.Add(secondMessage);
			interaction.Messages.Add(thirdMessage);
			
			Message actualFirstMessage=sequenceChartModelCreator.GetMessageForMessageElement(firstMessageElement,interaction);
			Assert.IsNotNull(actualFirstMessage);
			Assert.AreEqual(firstMessage,actualFirstMessage);
			
			Message actualSecondMessage=sequenceChartModelCreator.GetMessageForMessageElement(secondMessageElement,interaction);
			Assert.IsNotNull(actualFirstMessage);
			Assert.AreEqual(secondMessage,actualSecondMessage);
			
			Message actualThirdMessage=sequenceChartModelCreator.GetMessageForMessageElement(thirdMessageElement,interaction);
			Assert.IsNotNull(actualThirdMessage);
			Assert.AreEqual(thirdMessage,actualThirdMessage);
			
		}
		
		[Test]
		public void GetMessageForMessageElementOneElementTest()
		{
			XmlElement firstMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			Message firstMessage=new Message(ZERO_POSITION,"",firstMessageElement);
			Interaction interaction=new Interaction(ZERO_POSITION,"",null);
			interaction.Messages.Add(firstMessage);
			
			Message actualFirstMessage=sequenceChartModelCreator.GetMessageForMessageElement(firstMessageElement,interaction);
			Assert.IsNotNull(actualFirstMessage);
			Assert.AreEqual(firstMessage,actualFirstMessage);
		}
		
		[Test]
		public void GetMessageForMessageElementNoElementTest()
		{
			Interaction interaction=new Interaction(ZERO_POSITION,"",null);
			Message actualFirstMessage=sequenceChartModelCreator.GetMessageForMessageElement(null,interaction);
			Assert.IsNull(actualFirstMessage);
		}
		
		private void AssertXmiId(SequenceChartElement modelElement,string assertId)
		{
			string actualId=modelElement.XmiId;
			Assert.AreEqual(assertId,actualId);
		}
		
		private void AssertIdOfXmiRepresentation(SequenceChartElement modelElement,string assertElementId)
		{
			XmlElement xmlElement=modelElement.XmlRepresentation;
			string actualElementId=xmlElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(assertElementId,actualElementId);
		}
		
		private void AssertPosition(SequenceChartElement modelElement,int assertX,int assertY )
		{
			int actualX=modelElement.Position.X;
			int actualY=modelElement.Position.Y;
			Assert.IsTrue(assertX==actualX);
			Assert.IsTrue(assertY==actualY);
		}
		
		private void AssertDimension(SequenceChartElement modelElement,int assertWidth,int assertHeight )
		{
			int actualHeight=modelElement.Dimension.Height;
			int actualWidth=modelElement.Dimension.Width;
			Assert.IsTrue(assertHeight==actualHeight);
			Assert.IsTrue(assertWidth==actualWidth);
		}
	}
}
