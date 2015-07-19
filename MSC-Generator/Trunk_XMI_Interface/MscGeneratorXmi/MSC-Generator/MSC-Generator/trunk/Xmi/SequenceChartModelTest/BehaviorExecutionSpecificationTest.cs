/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 04.01.2008
 * Zeit: 09:31
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Drawing;
using NUnit.Framework;


namespace sequenceChartModel
{
	[TestFixture]
	public class BehaviorExecutionSpecificationTest
	{
		private ExecutionSpecification executionSpecificationCoveringOneEnd;
		private ExecutionSpecification executionSpecificationCoveringFourEnds;
		private ExecutionSpecification executionSpecificationCoveringNoEnd;
		private ExecutionSpecification oppositeExecutionSpecificationReply;
		private ExecutionSpecification oppositeExecutionSpecificationNoReply;
		private MessageEnd firstCoveredMessageEndSource;
		private MessageEnd secondCoveredMessageEndSource;
		private MessageEnd thirdCoveredMessageEndSource;
		private MessageEnd fourthCoveredMessageEndSource;
		private MessageEnd fifthCoveredMessageEndDestination;
		private MessageEnd uncoveredMessageEndDestination;
		private MessageEnd replyMessageSourceEnd;
		private MessageEnd replyMessageDestinationEnd;
		private Message replyMessage;
		private const int FIRST_COVERED_MESSAGE_END_SOURCE_X=12;
		private const int FIRST_COVERED_MESSAGE_END_SOURCE_Y=10;
		private Point dummyPosition=new Point(0,0);
		private Point firstCoveredMessageEndSourcePosition=
							new Point(FIRST_COVERED_MESSAGE_END_SOURCE_X,FIRST_COVERED_MESSAGE_END_SOURCE_Y);
		private const int SECOND_COVERED_MESSAGE_END_SOURCE_X=12;
		private const int SECOND_COVERED_MESSAGE_END_SOURCE_Y=30;
		private Point secondCoveredMessageEndSourcePosition=
							new Point(SECOND_COVERED_MESSAGE_END_SOURCE_X,SECOND_COVERED_MESSAGE_END_SOURCE_Y);
		private const int THIRD_COVERED_MESSAGE_END_SOURCE_X=12;
		private const int THIRD_COVERED_MESSAGE_END_SOURCE_Y=35;
		private Point thirdCoveredMessageEndSourcePosition=
							new Point(THIRD_COVERED_MESSAGE_END_SOURCE_X,THIRD_COVERED_MESSAGE_END_SOURCE_Y);
		private const int FOURTH_COVERED_MESSAGE_END_SOURCE_X=12;
		private const int FOURTH_COVERED_MESSAGE_END_SOURCE_Y=40;
		private Point fourthCoveredMessageEndSourcePosition=
							new Point(FOURTH_COVERED_MESSAGE_END_SOURCE_X,FOURTH_COVERED_MESSAGE_END_SOURCE_Y);
		private const int FIFTH_COVERED_MESSAGE_END_DESTINATION_X=12;
		private const int FIFTH_COVERED_MESSAGE_END_DESTINATION_Y=55;
		private Point fifthCoveredMessageEndDestinationPosition=
							new Point(FIFTH_COVERED_MESSAGE_END_DESTINATION_X,FIFTH_COVERED_MESSAGE_END_DESTINATION_Y);
		private const int UNCOVERED_MESSAGE_END_DESTINATION_X=12;
		private const int UNCOVERED_MESSAGE_END_DESTINATION_Y=80;
		private Point uncoveredMessageEndDestinationPosition=
							new Point(UNCOVERED_MESSAGE_END_DESTINATION_X,UNCOVERED_MESSAGE_END_DESTINATION_Y);
		private const int REPLY_MESSAGE_DESTINATION_END_X=12;
		private const int REPLY_MESSAGE_DESTINATION_END_Y=20;
		private Point replyMessageDestinationEndPosition=
							new Point(REPLY_MESSAGE_DESTINATION_END_X,REPLY_MESSAGE_DESTINATION_END_Y);
		
		private const int EXECUTION_SPECIFICATION_COVERING_ONE_END_X=5;
		private const int EXECUTION_SPECIFICATION_COVERING_ONE_END_Y=10;
		private Point executionSpecificationCoveringOneEndPosition=
							new Point(EXECUTION_SPECIFICATION_COVERING_ONE_END_X,EXECUTION_SPECIFICATION_COVERING_ONE_END_Y);
		
		private const int EXECUTION_SPECIFICATION_COVERING_ONE_END_WIDTH=16;
		private const int EXECUTION_SPECIFICATION_COVERING_ONE_END_HEIGHT=15;
		private Size executionSpecificationCoveringOneEndSize=
							new Size(EXECUTION_SPECIFICATION_COVERING_ONE_END_WIDTH,EXECUTION_SPECIFICATION_COVERING_ONE_END_HEIGHT);
	
		private const int EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_X=5;
		private const int EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_Y=30;
		private Point executionSpecificationCoveringFourEndsPosition=
							new Point(EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_X,EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_Y);
		private const int EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_WIDTH=16;
		private const int EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_HEIGHT=25;
		private Size executionSpecificationCoveringFourEndsSize=
							new Size(EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_WIDTH,EXECUTION_SPECIFICATION_COVERING_FOUR_ENDS_HEIGHT);
		private const int EXECUTION_SPECIFICATION_COVERING_NO_END_X=5;
		private const int EXECUTION_SPECIFICATION_COVERING_NO_END_Y=60;
		private Point executionSpecificationCoveringNoEndPosition=
							new Point(EXECUTION_SPECIFICATION_COVERING_NO_END_X,EXECUTION_SPECIFICATION_COVERING_NO_END_Y);
		private const int EXECUTION_SPECIFICATION_COVERING_NO_END_WIDTH=16;
		private const int EXECUTION_SPECIFICATION_COVERING_NO_END_HEIGHT=10;
		private Size executionSpecificationCoveringNoEndSize=
							new Size(EXECUTION_SPECIFICATION_COVERING_NO_END_WIDTH,EXECUTION_SPECIFICATION_COVERING_NO_END_HEIGHT);
		
		[SetUp]
		public void Init()
		{
			firstCoveredMessageEndSource=new MessageEnd(firstCoveredMessageEndSourcePosition,"",null);
			firstCoveredMessageEndSource.MessageEndKind=MessageEndKind.sourceEnd;
			secondCoveredMessageEndSource=new MessageEnd(secondCoveredMessageEndSourcePosition,"",null);
			secondCoveredMessageEndSource.MessageEndKind=MessageEndKind.sourceEnd;
			thirdCoveredMessageEndSource=new MessageEnd(thirdCoveredMessageEndSourcePosition,"",null);
			thirdCoveredMessageEndSource.MessageEndKind=MessageEndKind.sourceEnd;
			fourthCoveredMessageEndSource=new MessageEnd(fourthCoveredMessageEndSourcePosition,"",null);
			fourthCoveredMessageEndSource.MessageEndKind=MessageEndKind.sourceEnd;
			fifthCoveredMessageEndDestination=new MessageEnd(fifthCoveredMessageEndDestinationPosition,"",null);
			fifthCoveredMessageEndDestination.MessageEndKind=MessageEndKind.destinationEnd;
			uncoveredMessageEndDestination=new MessageEnd(uncoveredMessageEndDestinationPosition,"",null);
			uncoveredMessageEndDestination.MessageEndKind=MessageEndKind.destinationEnd;
			executionSpecificationCoveringOneEnd=new ExecutionSpecification (executionSpecificationCoveringOneEndPosition,"",null);
			executionSpecificationCoveringOneEnd.Dimension=executionSpecificationCoveringOneEndSize;
			executionSpecificationCoveringOneEnd.MessageSourceEnds.Add(firstCoveredMessageEndSource);
			executionSpecificationCoveringFourEnds=new ExecutionSpecification (executionSpecificationCoveringFourEndsPosition,"",null);
			executionSpecificationCoveringFourEnds.Dimension=executionSpecificationCoveringFourEndsSize;
			executionSpecificationCoveringFourEnds.MessageSourceEnds.Add(secondCoveredMessageEndSource);
			executionSpecificationCoveringFourEnds.MessageSourceEnds.Add(thirdCoveredMessageEndSource);
			executionSpecificationCoveringFourEnds.MessageSourceEnds.Add(fourthCoveredMessageEndSource);
			executionSpecificationCoveringFourEnds.MessageSourceEnds.Add(fifthCoveredMessageEndDestination);
			executionSpecificationCoveringNoEnd=new ExecutionSpecification (executionSpecificationCoveringNoEndPosition,"",null);
			executionSpecificationCoveringNoEnd.Dimension=executionSpecificationCoveringNoEndSize;
			
			oppositeExecutionSpecificationReply=new ExecutionSpecification(dummyPosition,"",null);
			replyMessage=new Message(dummyPosition,"",null);
			replyMessageSourceEnd=new MessageEnd(dummyPosition,"",null);
			replyMessageSourceEnd.CorrespondingMessage=replyMessage;
			replyMessageDestinationEnd=new MessageEnd(replyMessageDestinationEndPosition,"",null);
			replyMessageDestinationEnd.CorrespondingMessage=replyMessage;
			replyMessage.SourceMessageEnd=replyMessageSourceEnd;
			replyMessage.DestinationMessageEnd=replyMessageDestinationEnd;
		}
		
		
		[Test]
		public void IsMessageEndCoveredTest()
		{
			bool isCovered=executionSpecificationCoveringOneEnd.IsMessageEndCovered(firstCoveredMessageEndSource);
			Assert.IsTrue(isCovered);

			
			isCovered=executionSpecificationCoveringOneEnd.IsMessageEndCovered(uncoveredMessageEndDestination);
			Assert.IsFalse(isCovered);
			
			isCovered=executionSpecificationCoveringFourEnds.IsMessageEndCovered(secondCoveredMessageEndSource);
			Assert.IsTrue(isCovered);
		
			isCovered=executionSpecificationCoveringFourEnds.IsMessageEndCovered(thirdCoveredMessageEndSource);
			Assert.IsTrue(isCovered);
		
			isCovered=executionSpecificationCoveringFourEnds.IsMessageEndCovered(fourthCoveredMessageEndSource);
			Assert.IsTrue(isCovered);
			
			isCovered=executionSpecificationCoveringFourEnds.IsMessageEndCovered(fifthCoveredMessageEndDestination);
			Assert.IsTrue(isCovered);
	
			isCovered=executionSpecificationCoveringFourEnds.IsMessageEndCovered(uncoveredMessageEndDestination);
			Assert.IsFalse(isCovered);
		}
		

		[Test]
		public void CoveredSourceMessageEndsTest()
		{
			/*ArrayList sourceMessageEnds=executionSpecificationCoveringOneEnd.CoveredSourceMessageEnds();
			Assert.IsTrue(sourceMessageEnds.Count==1);
			sourceMessageEnds=executionSpecificationCoveringFourEnds.CoveredSourceMessageEnds();
			Assert.IsTrue(sourceMessageEnds.Count==3);
			sourceMessageEnds=executionSpecificationCoveringNoEnd.CoveredSourceMessageEnds();
			Assert.IsTrue(sourceMessageEnds.Count==0);*/
		}
		
		[Test]
		public void CoveredReplyMessageToExecution()
		{
			/*oppositeExecutionSpecificationReply.MessageSourceEnds.Add(replyMessageSourceEnd);
			executionSpecificationCoveringOneEnd.MessageSourceEnds.Add(replyMessageDestinationEnd);
			Message returnedMessage=oppositeExecutionSpecificationReply.CoveredReplyMessageToExecution(executionSpecificationCoveringOneEnd);
			Assert.IsNotNull(returnedMessage);*/
			
		}
	}
}
