/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 04.01.2008
 * Zeit: 14:40
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using NUnit.Framework;


namespace sequenceChartModel
{
	[TestFixture]
	public class MessageEndTest
	{
		private Lifeline   lifeline;
		private Point dummyPosition=new Point(0,0);
		private MessageEnd coveredMessageEnd;
		private const int COVERED_MESSAGE_END_X=13;
		private const int COVERED_MESSAGE_END_Y=10;
		private Point coveredMessageEndPosition=new Point(COVERED_MESSAGE_END_X,COVERED_MESSAGE_END_Y);
		private MessageEnd uncoveredMessageEnd;
		private const int UNCOVERED_MESSAGE_END_X=13;
		private const int UNCOVERED_MESSAGE_END_Y=25;
		private Point unCoveredMessageEndPosition=new Point(UNCOVERED_MESSAGE_END_X,UNCOVERED_MESSAGE_END_Y);
		private ExecutionSpecification coveringExecutionSpecification;
		private const int COVERING_EXECUTION_SPECIFICATION_X=5;
		private const int COVERING_EXECUTION_SPECIFICATION_Y=10;
		private Point coveringExecutionSpecificationPosition=new Point(COVERING_EXECUTION_SPECIFICATION_X,COVERING_EXECUTION_SPECIFICATION_Y);
		private const int COVERING_EXECUTION_SPECIFICATION_WIDTH=16;
		private const int COVERING_EXECUTION_SPECIFICATION_HEIGHT=11;
		private Size coveringExecutionSpecificationSize=new Size(COVERING_EXECUTION_SPECIFICATION_WIDTH,COVERING_EXECUTION_SPECIFICATION_HEIGHT);
		private ExecutionSpecification notCoveringExecutionSpecification;
		private const int NOT_COVERING_EXECUTION_SPECIFICATION_X=5;
		private const int NOT_COVERING_EXECUTION_SPECIFICATION_Y=30;
		private Point notCoveringExecutionSpecificationPosition=new Point(NOT_COVERING_EXECUTION_SPECIFICATION_X,NOT_COVERING_EXECUTION_SPECIFICATION_Y);
		private const int NOT_COVERING_EXECUTION_SPECIFICATION_WIDTH=16;
		private const int NOT_COVERING_EXECUTION_SPECIFICATION_HEIGHT=12;
		private Size notCoveringExecutionSpecificationSize=new Size(NOT_COVERING_EXECUTION_SPECIFICATION_WIDTH,NOT_COVERING_EXECUTION_SPECIFICATION_HEIGHT);
		
		
		
		[SetUp]
		public void Init()
		{
			lifeline=new Lifeline(dummyPosition,"",null);
			coveredMessageEnd=new MessageEnd(coveredMessageEndPosition,"1",null);
			uncoveredMessageEnd=new MessageEnd(unCoveredMessageEndPosition,"2",null);
			coveringExecutionSpecification=new ExecutionSpecification(coveringExecutionSpecificationPosition,"",null);
			coveringExecutionSpecification.Dimension=coveringExecutionSpecificationSize;
			coveringExecutionSpecification.MessageSourceEnds.Add(coveredMessageEnd);
			notCoveringExecutionSpecification=new ExecutionSpecification(coveringExecutionSpecificationPosition,"",null);
			notCoveringExecutionSpecification.Dimension=notCoveringExecutionSpecificationSize;
			lifeline.MessageEnds.Add(coveredMessageEnd);
			lifeline.MessageEnds.Add(uncoveredMessageEnd);
			lifeline.ExecutionSpecifications.Add(coveringExecutionSpecification);
			lifeline.ExecutionSpecifications.Add(notCoveringExecutionSpecification);
			coveredMessageEnd.CoveredLifeline=lifeline;
			uncoveredMessageEnd.CoveredLifeline=lifeline;
		}
		
		[Test]
		public void GetExecutionForMessageEnd()
		{
			ExecutionSpecification returnedExecutionSpecification=coveredMessageEnd.GetExecutionForMessageEnd();
			Assert.IsNotNull(returnedExecutionSpecification);
			Assert.AreEqual(coveringExecutionSpecification,returnedExecutionSpecification);
			
			returnedExecutionSpecification=uncoveredMessageEnd.GetExecutionForMessageEnd();
			Assert.IsNull(returnedExecutionSpecification);
		}
	}
}
