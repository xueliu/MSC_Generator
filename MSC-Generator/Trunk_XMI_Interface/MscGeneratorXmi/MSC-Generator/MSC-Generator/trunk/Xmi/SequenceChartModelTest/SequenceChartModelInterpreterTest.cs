/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 04.01.2008
 * Zeit: 16:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Drawing;
using xmiImport;
using NUnit.Framework;


namespace sequenceChartModel
{
	[TestFixture]
	public class SequenceChartModelInterpreterTest
	{
		private SequenceChartModelInterpreter firstModelInterpreter;
		private Interaction firstInteraction;
	
		private Lifeline firstLifeline;
		private const string FIRST_LIFELINE_ID="1";
		private const string FIRST_PROCESS_ID="firstProcessName_1";
		private const string FIRST_PROCESS_NAME="firstProcessName";
		private LifelineIdProcessEntryIdPair firstLifelineIdProcessEntryIdPair=
					new LifelineIdProcessEntryIdPair(FIRST_LIFELINE_ID,FIRST_PROCESS_ID);
		private Lifeline secondLifeline;
		private const string SECOND_LIFELINE_ID="2";
		private const string SECOND_PROCESS_ID="secondProcessName_1";
		private const string SECOND_PROCESS_NAME="secondProcessName";
		private LifelineIdProcessEntryIdPair secondLifelineIdProcessEntryIdPair=
					new LifelineIdProcessEntryIdPair(SECOND_LIFELINE_ID,SECOND_PROCESS_ID);
		private Lifeline thirdLifeline;
		private const string THIRD_LIFELINE_ID="3";
		private const string THIRD_PROCESS_ID="thirdProcessName_1";
		private const string THIRD_PROCESS_NAME="thirdProcessName";
		private LifelineIdProcessEntryIdPair thirdLifelineIdProcessEntryIdPair=
					new LifelineIdProcessEntryIdPair(THIRD_LIFELINE_ID,THIRD_PROCESS_ID);
		
		private ExecutionSpecification firstExecutionSpecFirstLifeline;
		private const int FIRST_EXECUTION_SPEC_FIRST_LIFELINE_X=5;
		private const int FIRST_EXECUTION_SPEC_FIRST_LIFELINE_Y=10;
		private Point firstExecutionSpecFirstLifelinePosition=
				new Point(FIRST_EXECUTION_SPEC_FIRST_LIFELINE_X,FIRST_EXECUTION_SPEC_FIRST_LIFELINE_Y);
		private const int FIRST_EXECUTION_SPEC_FIRST_LIFELINE_WIDTH=16;
		private const int FIRST_EXECUTION_SPEC_FIRST_LIFELINE_HEIGHT=31;
		private Size firstExecutionSpecFirstLifelineSize=
				new Size(FIRST_EXECUTION_SPEC_FIRST_LIFELINE_WIDTH,FIRST_EXECUTION_SPEC_FIRST_LIFELINE_HEIGHT);
		
		private ExecutionSpecification firstExecutionSpecSecondLifeline;
		private const int FIRST_EXECUTION_SPEC_SECOND_LIFELINE_X=30;
		private const int FIRST_EXECUTION_SPEC_SECOND_LIFELINE_Y=15;
		private Point firstExecutionSpecSecondLifelinePosition=
				new Point(FIRST_EXECUTION_SPEC_SECOND_LIFELINE_X,FIRST_EXECUTION_SPEC_SECOND_LIFELINE_Y);
		private const int FIRST_EXECUTION_SPEC_SECOND_LIFELINE_WIDTH=16;
		private const int FIRST_EXECUTION_SPEC_SECOND_LIFELINE_HEIGHT=21;
		private Size firstExecutionSpecSecondLifelineSize=
				new Size(FIRST_EXECUTION_SPEC_SECOND_LIFELINE_WIDTH,FIRST_EXECUTION_SPEC_SECOND_LIFELINE_HEIGHT);
		
		private ExecutionSpecification firstExecutionSpecThirdLifeline;
		private const int FIRST_EXECUTION_SPEC_THIRD_LIFELINE_X=65;
		private const int FIRST_EXECUTION_SPEC_THIRD_LIFELINE_Y=11;
		private Point firstExecutionSpecThirdLifelinePosition=
				new Point(FIRST_EXECUTION_SPEC_THIRD_LIFELINE_X,FIRST_EXECUTION_SPEC_THIRD_LIFELINE_Y);
		private const int FIRST_EXECUTION_SPEC_THIRD_LIFELINE_WIDTH=16;
		private const int FIRST_EXECUTION_SPEC_THIRD_LIFELINE_HEIGHT=11;
		private Size firstExecutionSpecThirdLifelineSize=
				new Size(FIRST_EXECUTION_SPEC_THIRD_LIFELINE_WIDTH,FIRST_EXECUTION_SPEC_THIRD_LIFELINE_HEIGHT);
		
		
		private Message firstMessage;
		private const string FIRST_MESSAGE_NAME="firstMessageName";
		private MessageEnd firstMessageSourceEnd;
		private const int FIRST_MESSAGE_SOURCE_END_X=13;
		private const int FIRST_MESSAGE_SOURCE_END_Y=15;
		private Point firstMessageSourceEndPosition=
					new Point(FIRST_MESSAGE_SOURCE_END_X,FIRST_MESSAGE_SOURCE_END_Y);
		private MessageEnd firstMessageDestinationEnd;
		private const int FIRST_MESSAGE_DESTINATION_END_X=43;
		private const int FIRST_MESSAGE_DESTINATION_END_Y=20;
		private Point firstMessageDestinationEndPosition=
					new Point(FIRST_MESSAGE_DESTINATION_END_X,FIRST_MESSAGE_DESTINATION_END_Y);
		
		private Message secondMessage;
		private const string SECOND_MESSAGE_NAME="secondMessageName";
		private MessageEnd secondMessageSourceEnd;
		private const int SECOND_MESSAGE_SOURCE_END_X=43;
		private const int SECOND_MESSAGE_SOURCE_END_Y=20;
		private Point secondMessageSourceEndPosition=
					new Point(SECOND_MESSAGE_SOURCE_END_X,SECOND_MESSAGE_SOURCE_END_Y);
		private MessageEnd secondMessageDestinationEnd;
		private const int SECOND_MESSAGE_DESTINATION_END_X=73;
		private const int SECOND_MESSAGE_DESTINATION_END_Y=20;
		private Point secondMessageDestinationEndPosition=
					new Point(SECOND_MESSAGE_DESTINATION_END_X,SECOND_MESSAGE_DESTINATION_END_Y);
		
		private Message thirdMessage;
		private const string THIRD_MESSAGE_NAME="thirdMessageName";
		private MessageEnd thirdMessageSourceEnd;
		private const int THIRD_MESSAGE_SOURCE_END_X=73;
		private const int THIRD_MESSAGE_SOURCE_END_Y=31;
		private Point thirdMessageSourceEndPosition=
					new Point(THIRD_MESSAGE_SOURCE_END_X,THIRD_MESSAGE_SOURCE_END_Y);
		private MessageEnd thirdMessageDestinationEnd;
		private const int THIRD_MESSAGE_DESTINATION_END_X=43;
		private const int THIRD_MESSAGE_DESTINATION_END_Y=31;
		private Point thirdMessageDestinationEndPosition=
					new Point(THIRD_MESSAGE_DESTINATION_END_X,THIRD_MESSAGE_DESTINATION_END_Y);
		
		private const string EDITOR_HEADER_ENTRY_1="DiagramStyle: uml\n";
		private const string EDITOR_HEADER_ENTRY_2="DiagramName: Neues MSC\n\n";
		private const string EDITOR_HEADER_ENTRY_3="PageSize: A4, H\n";
		private const string EDITOR_HEADER_ENTRY_4="PageMargins: 10, 10, 10, 10\n";	
		private const string EDITOR_HEADER_ENTRY_5="Font: 'Arial', '10', 'Regular'\n";
		private const string EDITOR_HEADER_ENTRY_6="LineOffset: 20\n";
		private const string EDITOR_HEADER_ENTRY_7="Author: ''\n";
		private const string EDITOR_HEADER_ENTRY_8="Company: ''\n";
		private const string EDITOR_HEADER_ENTRY_9="Date: ''\n";
		private const string EDITOR_HEADER_ENTRY_10="Version: ''\n";	
		private const string EDITOR_HEADER_ENTRY_11="PrintFootLine: no\n\n";

		
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_1="process: firstProcessName_1, firstProcessName;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_2="process: secondProcessName_1, secondProcessName;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_3="process: thirdProcessName_1, thirdProcessName;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_4="regionbegin: firstProcessName_1, Activation;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_5="regionbegin: secondProcessName_1, Activation\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_6="msg: firstProcessName_1, secondProcessName_1, firstMessageName,!;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_7="regionbegin: thirdProcessName_1, Activation\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_8="msg: secondProcessName_1, thirdProcessName_1, secondMessageName;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_9="msg: thirdProcessName_1, secondProcessName_1, thirdMessageName,*\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_10="regionend: thirdProcessName_1;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_11="regionend: secondProcessName_1;\n";
		private const string FIRST_DIAGRAM_EDITOR_ENTRY_12="regionend: firstProcessName_1;\n";
		
		//Second test
		private Interaction secondInteraction;
		private SequenceChartModelInterpreter secondModelInterpreter;
		
		private Lifeline fourthLifeline;
		private const string FOURTH_LIFELINE_ID="4";
		private const string FOURTH_PROCESS_ID="fourthProcess";
		private LifelineIdProcessEntryIdPair fourthLifelineIdPair=new LifelineIdProcessEntryIdPair(FOURTH_LIFELINE_ID,FOURTH_PROCESS_ID);
		private Lifeline fifthLifeline;
		private const string FIFTH_LIFELINE_ID="5";
		private const string FIFTH_PROCESS_ID="fifthProcess";
		private LifelineIdProcessEntryIdPair fifthLifelineIdPair=new LifelineIdProcessEntryIdPair(FIFTH_LIFELINE_ID,FIFTH_PROCESS_ID);
		private Lifeline sixthLifeline;
		private const string SIXTH_LIFELINE_ID="6";
		private const string SIXTH_PROCESS_ID="sixthProcess";
		private LifelineIdProcessEntryIdPair sixthLifelineIdPair=new LifelineIdProcessEntryIdPair(SIXTH_LIFELINE_ID,SIXTH_PROCESS_ID);
		
		private Message fourthMessage;
		private MessageEnd fourthMessageSourceEnd;
		private const int  FOURTH_MESSAGE_SOURCE_END_X=100;
		private const int  FOURTH_MESSAGE_SOURCE_END_Y=41;
		private Point fourthMessageSourceEndPosition=new Point(FOURTH_MESSAGE_SOURCE_END_X,FOURTH_MESSAGE_SOURCE_END_Y);
		private MessageEnd fourthMessageDestinationEnd;
		private const int  FOURTH_MESSAGE_DESTINATION_END_X=130;
		private const int  FOURTH_MESSAGE_DESTINATION_END_Y=41;
		private Point fourthMessageDestinationEndPosition=new Point(FOURTH_MESSAGE_DESTINATION_END_X,FOURTH_MESSAGE_DESTINATION_END_Y);
		private Message fifthMessage;
		private MessageEnd fifthMessageSourceEnd;
		private const int  FIFTH_MESSAGE_SOURCE_END_X=130;
		private const int  FIFTH_MESSAGE_SOURCE_END_Y=61;
		private MessageEnd fifthMessageDestinationEnd;
		private Point fifthMessageSourceEndPosition=new Point(FIFTH_MESSAGE_SOURCE_END_X,FIFTH_MESSAGE_SOURCE_END_Y);
		private const int  FIFTH_MESSAGE_DESTINATION_END_X=160;
		private const int  FIFTH_MESSAGE_DESTINATION_END_Y=61;
		private Point fifthMessageDestinationEndPosition=new Point(FIFTH_MESSAGE_DESTINATION_END_X,FIFTH_MESSAGE_DESTINATION_END_Y);
		private Message sixthMessage;
		private MessageEnd sixthMessageSourceEnd;
		private const int  SIXTH_MESSAGE_SOURCE_END_X=160;
		private const int  SIXTH_MESSAGE_SOURCE_END_Y=81;
		private Point sixthMessageSourceEndPosition=new Point(SIXTH_MESSAGE_SOURCE_END_X,SIXTH_MESSAGE_SOURCE_END_Y);
		private MessageEnd sixthMessageDestinationEnd;
		private const int  SIXTH_MESSAGE_DESTINATION_END_X=130;
		private const int  SIXTH_MESSAGE_DESTINATION_END_Y=81;
		private Point sixthMessageDestinationEndPosition=new Point(SIXTH_MESSAGE_DESTINATION_END_X,SIXTH_MESSAGE_DESTINATION_END_Y);
		private Message seventhMessage;
		private MessageEnd seventhMessageSourceEnd;
		private const int  SEVENTH_MESSAGE_SOURCE_END_X=130;
		private const int  SEVENTH_MESSAGE_SOURCE_END_Y=101;
		private Point seventhMessageSourceEndPosition=new Point(SEVENTH_MESSAGE_SOURCE_END_X,SEVENTH_MESSAGE_SOURCE_END_Y);
		private MessageEnd seventhMessageDestinationEnd;
		private const int  SEVENTH_MESSAGE_DESTINATION_END_X=100;
		private const int  SEVENTH_MESSAGE_DESTINATION_END_Y=101;
		private Point seventhMessageDestinationEndPosition=new Point(SEVENTH_MESSAGE_DESTINATION_END_X,SEVENTH_MESSAGE_DESTINATION_END_Y);
		
		
		
		private Point dummyPosition=new Point(0,0);
		
		
		
		[SetUp]
		public void Init()
		{
			firstInteraction=new Interaction(dummyPosition,"",null);
			firstModelInterpreter=new SequenceChartModelInterpreter ();
			firstModelInterpreter.ToInterpretInteraction=firstInteraction;
		
			firstLifeline= new Lifeline(dummyPosition,FIRST_LIFELINE_ID,null);
			firstLifeline.Name=FIRST_PROCESS_NAME;
			secondLifeline= new Lifeline(dummyPosition,SECOND_LIFELINE_ID,null);
			secondLifeline.Name=SECOND_PROCESS_NAME;
			thirdLifeline= new Lifeline(dummyPosition,THIRD_LIFELINE_ID,null);
			thirdLifeline.Name=THIRD_PROCESS_NAME;
			
			firstInteraction.Lifelines.Add(firstLifeline);
			firstInteraction.Lifelines.Add(secondLifeline);
			firstInteraction.Lifelines.Add(thirdLifeline);
			
			firstExecutionSpecFirstLifeline= 
					new ExecutionSpecification(firstExecutionSpecFirstLifelinePosition,"",null);
			firstExecutionSpecFirstLifeline.Dimension=firstExecutionSpecFirstLifelineSize;
			firstLifeline.ExecutionSpecifications.Add(firstExecutionSpecFirstLifeline);
			firstExecutionSpecSecondLifeline= 
					new ExecutionSpecification(firstExecutionSpecSecondLifelinePosition,"",null);
			firstExecutionSpecSecondLifeline.Dimension=firstExecutionSpecSecondLifelineSize;
			secondLifeline.ExecutionSpecifications.Add(firstExecutionSpecSecondLifeline);
			firstExecutionSpecThirdLifeline= 
					new ExecutionSpecification(firstExecutionSpecThirdLifelinePosition,"",null);
			firstExecutionSpecThirdLifeline.Dimension=firstExecutionSpecThirdLifelineSize;
			thirdLifeline.ExecutionSpecifications.Add(firstExecutionSpecThirdLifeline);
			
			firstMessage=new Message(dummyPosition,"",null);
			firstMessage.Name=FIRST_MESSAGE_NAME;
			firstMessage.MessageSort= MessageSort.synchCall;
			firstMessageSourceEnd=new MessageEnd(firstMessageSourceEndPosition,"",null);
			firstMessageSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			firstMessageDestinationEnd=new MessageEnd(firstMessageDestinationEndPosition,"",null);
			firstMessageDestinationEnd.MessageEndKind= MessageEndKind.destinationEnd;
			firstMessage.SourceMessageEnd=firstMessageSourceEnd;
			firstMessage.DestinationMessageEnd=firstMessageDestinationEnd;
			firstMessageSourceEnd.CorrespondingMessage=firstMessage;
			firstMessageSourceEnd.CoveredLifeline=firstLifeline;
			firstMessageDestinationEnd.CorrespondingMessage=firstMessage;
			firstMessageDestinationEnd.CoveredLifeline=secondLifeline;
			
			secondMessage=new Message(dummyPosition,SECOND_MESSAGE_NAME,null);
			secondMessage.Name=SECOND_MESSAGE_NAME;
			secondMessage.MessageSort=MessageSort.asynchCall;
			secondMessageSourceEnd=new MessageEnd(secondMessageSourceEndPosition,"",null);
			secondMessageSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			secondMessageDestinationEnd=new MessageEnd(secondMessageDestinationEndPosition,"",null);
			secondMessageDestinationEnd.MessageEndKind=MessageEndKind.destinationEnd;
			secondMessage.SourceMessageEnd=secondMessageSourceEnd;
			secondMessage.DestinationMessageEnd=secondMessageDestinationEnd;
			secondMessageSourceEnd.CorrespondingMessage=secondMessage;
			secondMessageSourceEnd.CoveredLifeline=secondLifeline;
			secondMessageDestinationEnd.CorrespondingMessage=secondMessage;
			secondMessageDestinationEnd.CoveredLifeline=thirdLifeline;
			
			thirdMessage=new Message(dummyPosition,THIRD_MESSAGE_NAME,null);
			thirdMessage.Name=THIRD_MESSAGE_NAME;
			thirdMessage.MessageSort= MessageSort.reply;
			thirdMessageSourceEnd=new MessageEnd(thirdMessageSourceEndPosition,"",null);
			thirdMessageSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			thirdMessageDestinationEnd=new MessageEnd(thirdMessageDestinationEndPosition,"",null);
			thirdMessageDestinationEnd.MessageEndKind=MessageEndKind.destinationEnd;
			thirdMessage.SourceMessageEnd=thirdMessageSourceEnd;
			thirdMessage.DestinationMessageEnd=thirdMessageDestinationEnd;
			thirdMessageSourceEnd.CorrespondingMessage=thirdMessage;
			thirdMessageSourceEnd.CoveredLifeline=thirdLifeline;
			thirdMessageDestinationEnd.CorrespondingMessage=thirdMessage;
			thirdMessageDestinationEnd.CoveredLifeline=secondLifeline;
			
			firstLifeline.MessageEnds.Add(firstMessageSourceEnd);
			secondLifeline.MessageEnds.Add(firstMessageDestinationEnd);
			secondLifeline.MessageEnds.Add(secondMessageSourceEnd);
			secondLifeline.MessageEnds.Add(thirdMessageDestinationEnd);
			thirdLifeline.MessageEnds.Add(secondMessageDestinationEnd);
			thirdLifeline.MessageEnds.Add(thirdMessageSourceEnd);
			
			firstExecutionSpecFirstLifeline.MessageSourceEnds.Add(firstMessageSourceEnd);
			firstExecutionSpecSecondLifeline.MessageSourceEnds.Add(firstMessageDestinationEnd);
			firstExecutionSpecSecondLifeline.MessageSourceEnds.Add(secondMessageSourceEnd);
			firstExecutionSpecSecondLifeline.MessageSourceEnds.Add(thirdMessageDestinationEnd);
			firstExecutionSpecThirdLifeline.MessageSourceEnds.Add(secondMessageDestinationEnd);
			firstExecutionSpecThirdLifeline.MessageSourceEnds.Add(thirdMessageSourceEnd);
			
			//Second test
			secondInteraction=new Interaction(dummyPosition,"",null);
			secondModelInterpreter=new SequenceChartModelInterpreter();
			secondModelInterpreter.ToInterpretInteraction=secondInteraction;
			
			fourthLifeline=new Lifeline(dummyPosition,"",null);
			fifthLifeline=new Lifeline(dummyPosition,"",null);
			sixthLifeline=new Lifeline(dummyPosition,"",null);
			secondInteraction.Lifelines.Add(fourthLifeline);
			secondInteraction.Lifelines.Add(fifthLifeline);
			secondInteraction.Lifelines.Add(sixthLifeline);
			
			fourthMessage=new Message(dummyPosition,"",null);
			fourthMessageSourceEnd=new MessageEnd(fourthMessageSourceEndPosition,"",null);
			fourthMessage.SourceMessageEnd=fourthMessageSourceEnd;
			fourthMessageSourceEnd.CorrespondingMessage=fourthMessage;
			fourthMessageSourceEnd.CoveredLifeline=fourthLifeline;
			fourthLifeline.MessageEnds.Add(fourthMessageSourceEnd);
			fourthMessageDestinationEnd=new MessageEnd(fourthMessageDestinationEndPosition,"",null);
			fourthMessage.DestinationMessageEnd=fourthMessageDestinationEnd;
			fourthMessageDestinationEnd.CorrespondingMessage=fourthMessage;
			fourthMessageDestinationEnd.CoveredLifeline=fifthLifeline;
			fifthLifeline.MessageEnds.Add(fourthMessageDestinationEnd);
			fifthMessage=new Message(dummyPosition,"",null);
			fifthMessageSourceEnd=new MessageEnd(fifthMessageSourceEndPosition,"",null);
			fifthMessage.SourceMessageEnd=fifthMessageSourceEnd;
			fifthMessageSourceEnd.CorrespondingMessage=fifthMessage;
			fifthMessageSourceEnd.CoveredLifeline=fifthLifeline;
			fifthLifeline.MessageEnds.Add(fifthMessageSourceEnd);
			fifthMessageDestinationEnd=new MessageEnd(fifthMessageDestinationEndPosition,"",null);
			fifthMessage.DestinationMessageEnd=fifthMessageDestinationEnd;
			fifthMessageDestinationEnd.CorrespondingMessage=fifthMessage;
			fifthMessageDestinationEnd.CoveredLifeline=sixthLifeline;
			sixthLifeline.MessageEnds.Add(fifthMessageDestinationEnd);
			sixthMessage=new Message(dummyPosition,"",null);
			sixthMessageSourceEnd=new MessageEnd(sixthMessageSourceEndPosition,"",null);
			sixthMessage.SourceMessageEnd=sixthMessageSourceEnd;
			sixthMessageSourceEnd.CorrespondingMessage=sixthMessage;
			sixthMessageSourceEnd.CoveredLifeline=sixthLifeline;
			sixthLifeline.MessageEnds.Add(sixthMessageSourceEnd);
			sixthMessageDestinationEnd=new MessageEnd(sixthMessageDestinationEndPosition,"",null);
			sixthMessage.DestinationMessageEnd=sixthMessageDestinationEnd;
			sixthMessageDestinationEnd.CorrespondingMessage=sixthMessage;
			sixthMessageDestinationEnd.CoveredLifeline=fifthLifeline;
			fifthLifeline.MessageEnds.Add(sixthMessageDestinationEnd);
			seventhMessage=new Message(dummyPosition,"",null);
			seventhMessageSourceEnd=new MessageEnd(seventhMessageSourceEndPosition,"",null);
			seventhMessage.SourceMessageEnd=seventhMessageSourceEnd;
			seventhMessageSourceEnd.CorrespondingMessage=seventhMessage;
			seventhMessageSourceEnd.CoveredLifeline=fifthLifeline;
			fifthLifeline.MessageEnds.Add(seventhMessageSourceEnd);
			seventhMessageDestinationEnd=new MessageEnd(seventhMessageDestinationEndPosition,"",null);
			seventhMessage.DestinationMessageEnd=seventhMessageDestinationEnd;
			seventhMessageDestinationEnd.CorrespondingMessage=seventhMessage;
			seventhMessageDestinationEnd.CoveredLifeline=fourthLifeline;
			fourthLifeline.MessageEnds.Add(seventhMessageDestinationEnd);
			
		}
		
		[Test]
		public void InterpretSequenceChartModelTest()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			string fourthExpectedEditorEntry;
			string fifthExpectedEditorEntry;
			string sixthExpectedEditorEntry;
			string seventhExpectedEditorEntry;
			string eigthExpectedEditorEntry;
			string ninthExpectedEditorEntry;
			string tenthExpectedEditorEntry;
			string eleventhExpectedEditorEntry;
			string twelfthExpectedEditorEntry;
			string thirteenthExpectedEditorEntry;
			string fourteenthExpectedEditorEntry;
			string fifteenthExpectedEditorEntry;
			
		
			firstModelInterpreter.InterpretSequenceChartModel(firstInteraction);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==23);
			
			//this.AssertEditorContentHeader(contentEntries);
			
			
			
			firstExpectedEditorEntry=(string)contentEntries[11];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_1,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[12];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_2,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[13];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_3,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[14];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_4,fourthExpectedEditorEntry);
			fifthExpectedEditorEntry=(string)contentEntries[15];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_5,fifthExpectedEditorEntry);
			sixthExpectedEditorEntry=(string)contentEntries[16];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_6,sixthExpectedEditorEntry);	
			seventhExpectedEditorEntry=(string)contentEntries[17];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,seventhExpectedEditorEntry);	
			eigthExpectedEditorEntry=(string)contentEntries[18];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,eigthExpectedEditorEntry);	
			ninthExpectedEditorEntry=(string)contentEntries[19];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,ninthExpectedEditorEntry);
			tenthExpectedEditorEntry=(string)contentEntries[20];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,tenthExpectedEditorEntry);
			eleventhExpectedEditorEntry=(string)contentEntries[21];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_11,eleventhExpectedEditorEntry);
			twelfthExpectedEditorEntry=(string)contentEntries[22];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_12,twelfthExpectedEditorEntry);
			
			ArrayList actualWorkedExecutions=firstModelInterpreter.WorkedExecutionSpecs;
			Assert.IsNotNull(actualWorkedExecutions);
			int actualWorkedExecutionsCount=actualWorkedExecutions.Count;
			Assert.IsTrue(actualWorkedExecutionsCount==3);
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecFirstLifeline));
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecSecondLifeline));
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecThirdLifeline));
			
			ArrayList actualWorkedMessageEnds=firstModelInterpreter.WorkedMessageEnds;
			Assert.IsNotNull(actualWorkedMessageEnds);
			int actualWorkedMessageEndsCount=actualWorkedMessageEnds.Count;
			Assert.IsTrue(actualWorkedMessageEndsCount==3);
			Assert.IsTrue(actualWorkedMessageEnds.Contains(firstMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(secondMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(thirdMessageSourceEnd));
		}
		
		
		[Test]
		public void InterpretLifelinesTest()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			LifelineIdProcessEntryIdPair firstActualIdPair;
			LifelineIdProcessEntryIdPair secondActualIdPair;
			LifelineIdProcessEntryIdPair thirdActualIdPair;
			
			ArrayList lifelines=new ArrayList();
			
			lifelines.Add(firstLifeline);
			lifelines.Add(secondLifeline);
			lifelines.Add(thirdLifeline);
			
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			firstModelInterpreter.InterpretLifelines(lifelines);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			this.PrintEditorContent(contentEntries);
			Assert.IsTrue(contentEntriesCount==3);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_1,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_2,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_3,thirdExpectedEditorEntry);
			
			ArrayList actualEntryPairs=firstModelInterpreter.LifelineIdProcessEntryIdPairs;
			Assert.IsNotNull(actualEntryPairs);
			int actualEntryPairsCount=actualEntryPairs.Count;
			Assert.IsTrue(actualEntryPairsCount==3);
			
			firstActualIdPair=(LifelineIdProcessEntryIdPair)actualEntryPairs[0];
			Assert.AreEqual(firstLifelineIdProcessEntryIdPair,firstActualIdPair);
			secondActualIdPair=(LifelineIdProcessEntryIdPair)actualEntryPairs[1];
			Assert.AreEqual(secondLifelineIdProcessEntryIdPair,secondActualIdPair);
			thirdActualIdPair=(LifelineIdProcessEntryIdPair)actualEntryPairs[2];
			Assert.AreEqual(thirdLifelineIdProcessEntryIdPair,thirdActualIdPair);
		}
		
		[Test]
		public void InterpretElementsOfLifelinesWithExecutionSpecsTest()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			string fourthExpectedEditorEntry;
			string fifthExpectedEditorEntry;
			string sixthExpectedEditorEntry;
			string seventhExpectedEditorEntry;
			string eigthExpectedEditorEntry;
			string ninthExpectedEditorEntry;
			
			ArrayList lifelines=new ArrayList();
			lifelines.Add(firstLifeline);
			lifelines.Add(secondLifeline);
			lifelines.Add(thirdLifeline);
			
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(firstLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(secondLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(thirdLifelineIdProcessEntryIdPair);
			
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			//firstModelInterpreter.InterpretElementsOfLifelines(lifelines);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==9);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_4,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_5,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_6,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,fourthExpectedEditorEntry);
			fifthExpectedEditorEntry=(string)contentEntries[4];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,fifthExpectedEditorEntry);
			sixthExpectedEditorEntry=(string)contentEntries[5];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,sixthExpectedEditorEntry);	
			seventhExpectedEditorEntry=(string)contentEntries[6];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,seventhExpectedEditorEntry);	
			eigthExpectedEditorEntry=(string)contentEntries[7];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_11,eigthExpectedEditorEntry);	
			ninthExpectedEditorEntry=(string)contentEntries[8];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_12,ninthExpectedEditorEntry);
			
			ArrayList actualWorkedExecutions=firstModelInterpreter.WorkedExecutionSpecs;
			Assert.IsNotNull(actualWorkedExecutions);
			int actualWorkedExecutionsCount=actualWorkedExecutions.Count;
			Assert.IsTrue(actualWorkedExecutionsCount==3);
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecFirstLifeline));
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecSecondLifeline));
			
			ArrayList actualWorkedMessageEnds=firstModelInterpreter.WorkedMessageEnds;
			Assert.IsNotNull(actualWorkedMessageEnds);
			int actualWorkedMessageEndsCount=actualWorkedMessageEnds.Count;
			Assert.IsTrue(actualWorkedMessageEndsCount==3);
			Assert.IsTrue(actualWorkedMessageEnds.Contains(firstMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(secondMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(thirdMessageSourceEnd));
		}
		
		/*[Test]
		public void InterpretElementsOfLifelineWithExecutionSpecsTest()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			string fourthExpectedEditorEntry;
			string fifthExpectedEditorEntry;
			string sixthExpectedEditorEntry;
			string seventhExpectedEditorEntry;
			string eigthExpectedEditorEntry;
			string ninthExpectedEditorEntry;
			
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(firstLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(secondLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(thirdLifelineIdProcessEntryIdPair);
			
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			firstModelInterpreter.InterpretElementsOfLifeline(firstLifeline);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==9);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_4,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_5,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_6,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,fourthExpectedEditorEntry);
			fifthExpectedEditorEntry=(string)contentEntries[4];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,fifthExpectedEditorEntry);
			sixthExpectedEditorEntry=(string)contentEntries[5];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,sixthExpectedEditorEntry);	
			seventhExpectedEditorEntry=(string)contentEntries[6];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,seventhExpectedEditorEntry);	
			eigthExpectedEditorEntry=(string)contentEntries[7];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_11,eigthExpectedEditorEntry);	
			ninthExpectedEditorEntry=(string)contentEntries[8];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_12,ninthExpectedEditorEntry);
			
			ArrayList actualWorkedExecutions=firstModelInterpreter.WorkedExecutionSpecs;
			Assert.IsNotNull(actualWorkedExecutions);
			int actualWorkedExecutionsCount=actualWorkedExecutions.Count;
			Assert.IsTrue(actualWorkedExecutionsCount==3);
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecFirstLifeline));
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecSecondLifeline));
			
			ArrayList actualWorkedMessageEnds=firstModelInterpreter.WorkedMessageEnds;
			Assert.IsNotNull(actualWorkedMessageEnds);
			int actualWorkedMessageEndsCount=actualWorkedMessageEnds.Count;
			Assert.IsTrue(actualWorkedMessageEndsCount==3);
			Assert.IsTrue(actualWorkedMessageEnds.Contains(firstMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(secondMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(thirdMessageSourceEnd));
		}*/
		
		[Test]
		public void InterpretDestinationMessageEndTest()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			string fourthExpectedEditorEntry;
			string fifthExpectedEditorEntry;
			string sixthExpectedEditorEntry;
			string seventhExpectedEditorEntry;
			
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(firstLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(secondLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(thirdLifelineIdProcessEntryIdPair);
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			//firstModelInterpreter.InterpretDestinationMessageEnd(secondMessageSourceEnd,secondMessage,firstExecutionSpecSecondLifeline);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==4);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,fourthExpectedEditorEntry);
			
			
			
			
			contentEntries.Clear();
			//firstModelInterpreter.InterpretDestinationMessageEnd(firstMessageSourceEnd,firstMessage,firstExecutionSpecFirstLifeline);
			contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==7);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_5,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_6,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,fourthExpectedEditorEntry);
			fifthExpectedEditorEntry=(string)contentEntries[4];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,fifthExpectedEditorEntry);
			sixthExpectedEditorEntry=(string)contentEntries[5];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,sixthExpectedEditorEntry);
			seventhExpectedEditorEntry=(string)contentEntries[6];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_11,seventhExpectedEditorEntry);
		}
		
		[Test]
		public void InterpretSourceMessageEndsOfExecutionWithoutRegionEntriesTest()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			string fourthExpectedEditorEntry;
			string fifthExpectedEditorEntry;
			string sixthExpectedEditorEntry;
			string seventhExpectedEditorEntry;
			
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(firstLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(secondLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(thirdLifelineIdProcessEntryIdPair);
			
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			//firstModelInterpreter.InterpretSourceMessageEndsOfExecutionWithoutRegionEntries(firstExecutionSpecThirdLifeline,thirdLifeline);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==1);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,firstExpectedEditorEntry);
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			
			
			//firstModelInterpreter.InterpretSourceMessageEndsOfExecutionWithoutRegionEntries(firstExecutionSpecSecondLifeline,secondLifeline);
			contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==4);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,fourthExpectedEditorEntry);
			
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			//firstModelInterpreter.InterpretSourceMessageEndsOfExecutionWithoutRegionEntries(firstExecutionSpecFirstLifeline,firstLifeline);
			contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==7);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_5,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_6,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,fourthExpectedEditorEntry);
			fifthExpectedEditorEntry=(string)contentEntries[4];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,fifthExpectedEditorEntry);
			sixthExpectedEditorEntry=(string)contentEntries[5];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,sixthExpectedEditorEntry);
			seventhExpectedEditorEntry=(string)contentEntries[6];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_11,seventhExpectedEditorEntry);
		}
		
		[Test]
		public void InterpretSourceMessageEndsOfExecution()
		{
			string firstExpectedEditorEntry;
			string secondExpectedEditorEntry;
			string thirdExpectedEditorEntry;
			string fourthExpectedEditorEntry;
			string fifthExpectedEditorEntry;
			string sixthExpectedEditorEntry;
			string seventhExpectedEditorEntry;
			string eigthExpectedEditorEntry;
			string ninthExpectedEditorEntry;
			
			
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(firstLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(secondLifelineIdProcessEntryIdPair);
			firstModelInterpreter.LifelineIdProcessEntryIdPairs.Add(thirdLifelineIdProcessEntryIdPair);
			
			firstModelInterpreter.EntryCreator.EditorContent.Clear();
			//firstModelInterpreter.InterpretSourceMessageEndsOfExecution(firstExecutionSpecFirstLifeline,firstLifeline);
			ArrayList contentEntries=firstModelInterpreter.EntryCreator.EditorContent;
			Assert.IsNotNull(contentEntries);
			int contentEntriesCount=contentEntries.Count;
			Assert.IsTrue(contentEntriesCount==9);
			firstExpectedEditorEntry=(string)contentEntries[0];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_4,firstExpectedEditorEntry);
			secondExpectedEditorEntry=(string)contentEntries[1];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_5,secondExpectedEditorEntry);
			thirdExpectedEditorEntry=(string)contentEntries[2];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_6,thirdExpectedEditorEntry);
			fourthExpectedEditorEntry=(string)contentEntries[3];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_7,fourthExpectedEditorEntry);
			fifthExpectedEditorEntry=(string)contentEntries[4];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_8,fifthExpectedEditorEntry);
			sixthExpectedEditorEntry=(string)contentEntries[5];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_9,sixthExpectedEditorEntry);	
			seventhExpectedEditorEntry=(string)contentEntries[6];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_10,seventhExpectedEditorEntry);	
			eigthExpectedEditorEntry=(string)contentEntries[7];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_11,eigthExpectedEditorEntry);	
			ninthExpectedEditorEntry=(string)contentEntries[8];
			Assert.AreEqual(FIRST_DIAGRAM_EDITOR_ENTRY_12,ninthExpectedEditorEntry);
			
			ArrayList actualWorkedExecutions=firstModelInterpreter.WorkedExecutionSpecs;
			Assert.IsNotNull(actualWorkedExecutions);
			int actualWorkedExecutionsCount=actualWorkedExecutions.Count;
			Assert.IsTrue(actualWorkedExecutionsCount==3);
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecFirstLifeline));
			Assert.IsTrue(actualWorkedExecutions.Contains(firstExecutionSpecSecondLifeline));
			
			ArrayList actualWorkedMessageEnds=firstModelInterpreter.WorkedMessageEnds;
			Assert.IsNotNull(actualWorkedMessageEnds);
			int actualWorkedMessageEndsCount=actualWorkedMessageEnds.Count;
			Assert.IsTrue(actualWorkedMessageEndsCount==3);
			Assert.IsTrue(actualWorkedMessageEnds.Contains(firstMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(secondMessageSourceEnd));
			Assert.IsTrue(actualWorkedMessageEnds.Contains(thirdMessageSourceEnd));
		}
		
		
		[Test]
		public void InterpretDestinationMessageEndWithoutExecutionsTest()
		{
			/*secondModelInterpreter.LifelineIdProcessEntryIdPairs.Add(fourthLifelineIdProcessEntryIdPair);
			secondModelInterpreter.LifelineIdProcessEntryIdPairs.Add(fifthLifelineIdProcessEntryIdPair);
			secondModelInterpreter.LifelineIdProcessEntryIdPairs.Add(sixthLifelineIdProcessEntryIdPair);
			
			secondModelInterpreter.InterpretDestinationMessageEnd(fourthMessageSourceEnd,fourthMessage,ExecutionSpecSecondLifeline);
			ArrayList contentEntrys=firstModelInterpreter.EntryCreator.EditorContent;
			IEnumerator itrContentEntry=contentEntrys.GetEnumerator();
			string content="";
			string currentContent;
			
			while(itrContentEntry.MoveNext())
			{
				currentContent=(string)itrContentEntry.Current;
				content=content+currentContent;
			}
			
			System.Console.WriteLine(content);
			/*contentEntrys.Clear();
			//System.Console.WriteLine("****************************");
			firstModelInterpreter.InterpretDestinationMessageEnd(firstMessageSourceEnd,firstMessage,firstExecutionSpecFirstLifeline);
			contentEntrys=firstModelInterpreter.EntryCreator.EditorContent;
			itrContentEntry=contentEntrys.GetEnumerator();
			content="";
		
			
			while(itrContentEntry.MoveNext())
			{
				currentContent=(string)itrContentEntry.Current;
				content=content+currentContent;
			}
			
			System.Console.WriteLine(content);*/
			
		}
		
		
		protected void AssertEditorContentHeader(ArrayList editorContent)
		{
			string firstActualHeaderEntry;
			string secondActualHeaderEntry;
			string thirdActualHeaderEntry;
			string fourthActualHeaderEntry;
			string fifthActualHeaderEntry;
			string sixthActualHeaderEntry;
			string seventhActualHeaderEntry;
			string eigthActualHeaderEntry;
			string ninthActualHeaderEntry;
			string tenthActualHeaderEntry;
			string eleventhActualHeaderEntry;
			
			this.PrintEditorContent(editorContent);
			
			
			Assert.IsNotNull(editorContent);
			int editorContentCount=editorContent.Count;
			Assert.IsTrue(editorContentCount>10);
			firstActualHeaderEntry=(string)editorContent[0];
			Assert.Equals(EDITOR_HEADER_ENTRY_1,firstActualHeaderEntry);
			secondActualHeaderEntry=(string)editorContent[1];
			Assert.Equals(EDITOR_HEADER_ENTRY_2,secondActualHeaderEntry);
			thirdActualHeaderEntry=(string)editorContent[2];
			Assert.Equals(EDITOR_HEADER_ENTRY_3,thirdActualHeaderEntry);
			fourthActualHeaderEntry=(string)editorContent[3];
			Assert.Equals(EDITOR_HEADER_ENTRY_4,fourthActualHeaderEntry);
			fifthActualHeaderEntry=(string)editorContent[4];
			Assert.Equals(EDITOR_HEADER_ENTRY_5,fifthActualHeaderEntry);
			sixthActualHeaderEntry=(string)editorContent[5];
			Assert.Equals(EDITOR_HEADER_ENTRY_6,sixthActualHeaderEntry);
			seventhActualHeaderEntry=(string)editorContent[6];
			Assert.Equals(EDITOR_HEADER_ENTRY_7,seventhActualHeaderEntry);
			eigthActualHeaderEntry=(string)editorContent[7];
			Assert.Equals(EDITOR_HEADER_ENTRY_8,eigthActualHeaderEntry);
			ninthActualHeaderEntry=(string)editorContent[8];
			Assert.Equals(EDITOR_HEADER_ENTRY_9,ninthActualHeaderEntry);
			tenthActualHeaderEntry=(string)editorContent[9];
			Assert.Equals(EDITOR_HEADER_ENTRY_10,tenthActualHeaderEntry);
			eleventhActualHeaderEntry=(string)editorContent[10];
			Assert.Equals(EDITOR_HEADER_ENTRY_10,eleventhActualHeaderEntry);
		}
		
		
		protected void PrintEditorContent(ArrayList editorContent)
		{
			IEnumerator itrEditorContent=editorContent.GetEnumerator();
			string content="";
			string currentContent;
			
			while(itrEditorContent.MoveNext())
			{
				currentContent=(string)itrEditorContent.Current;
				content=content+currentContent;
			}
			
			System.Console.WriteLine(content);
		}
	}
}
