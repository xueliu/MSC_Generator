/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 10.01.2008
 * Zeit: 11:51
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Drawing;
using NUnit.Framework;


namespace sequenceChartModel
{
	/// <summary>
	/// Description of SequenceChartElementListSorterTest.
	/// </summary>
	[TestFixture]
	public class SequenceChartElementListSorterTest
	{
		private SequenceChartElementListSorter elementListSorter;
		private Lifeline relevantLifeline;
		private ExecutionSpecification firstExecutionSpecification;
		private const int FIRST_EXECUTION_SPECIFICATION_X=10;
		private const int FIRST_EXECUTION_SPECIFICATION_Y=15;
		private Point firstExecutionSpecificationPosition=
			new Point(FIRST_EXECUTION_SPECIFICATION_X,FIRST_EXECUTION_SPECIFICATION_Y);
		private const int FIRST_EXECUTION_SPECIFICATION_WIDTH=8;
		private const int FIRST_EXECUTION_SPECIFICATION_HEIGHT=16;
		private Size firstExecutionSpecificationDimension=
			new Size(FIRST_EXECUTION_SPECIFICATION_WIDTH,FIRST_EXECUTION_SPECIFICATION_HEIGHT);
		private MessageEnd firstSourceEnd;
		private const int FIRST_SOURCE_END_X=14;
		private const int FIRST_SOURCE_END_Y=15;
		private Point firstSourceEndPosition=
			new Point(FIRST_SOURCE_END_X,FIRST_SOURCE_END_Y);
		private MessageEnd firstDestinationEnd;
		private const int FIRST_DESTINATION_END_X=14;
		private const int FIRST_DESTINATION_END_Y=20;
		private Point firstDestinationEndPosition=
			new Point(FIRST_DESTINATION_END_X,FIRST_DESTINATION_END_Y);
		private MessageEnd secondSourceEnd;
		private const int SECOND_SOURCE_END_X=14;
		private const int SECOND_SOURCE_END_Y=25;
		private Point secondSourceEndPosition=
			new Point(SECOND_SOURCE_END_X,SECOND_SOURCE_END_Y);
		private MessageEnd thirdSourceEnd;
		private const int THIRD_SOURCE_END_X=14;
		private const int THIRD_SOURCE_END_Y=35;
		private Point thirdSourceEndPosition=
			new Point(THIRD_SOURCE_END_X,THIRD_SOURCE_END_Y);
		private MessageEnd fourthSourceEnd;
		private const int FOURTH_SOURCE_END_X=14;
		private const int FOURTH_SOURCE_END_Y=40;
		private Point fourthSourceEndPosition=
			new Point(FOURTH_SOURCE_END_X,FOURTH_SOURCE_END_Y);
		private ExecutionSpecification secondExecutionSpecification;
		private const int SECOND_EXECUTION_SPECIFICATION_X=14;
		private const int SECOND_EXECUTION_SPECIFICATION_Y=45;
		private Point secondExecutionSpecificationPosition=
			new Point(SECOND_EXECUTION_SPECIFICATION_X,SECOND_EXECUTION_SPECIFICATION_Y);
		private const int SECOND_EXECUTION_SPECIFICATION_WIDTH=8;
		private const int SECOND_EXECUTION_SPECIFICATION_HEIGHT=11;
		private Size secondExecutionSpecificationDimension=
			new Size(SECOND_EXECUTION_SPECIFICATION_WIDTH,SECOND_EXECUTION_SPECIFICATION_HEIGHT);
		private MessageEnd secondDestinationEnd;
		private const int SECOND_DESTINATION_END_X=14;
		private const int SECOND_DESTINATION_END_Y=50;
		private Point secondDestinationEndPosition=
			new Point(SECOND_DESTINATION_END_X,SECOND_DESTINATION_END_Y);
		
		private Point dummyPosition=new Point(0,0);
	
	
		[SetUp]
		public void Init()
		{
			elementListSorter=new SequenceChartElementListSorter();
			relevantLifeline=new Lifeline(dummyPosition,"",null);
			firstExecutionSpecification=
				new ExecutionSpecification(firstExecutionSpecificationPosition,"",null);
			firstExecutionSpecification.Dimension=firstExecutionSpecificationDimension;
			secondExecutionSpecification=
				new ExecutionSpecification(secondExecutionSpecificationPosition,"",null);
			secondExecutionSpecification.Dimension=secondExecutionSpecificationDimension;
			firstSourceEnd=new MessageEnd(firstSourceEndPosition,"",null);
			firstSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			secondSourceEnd=new MessageEnd(secondSourceEndPosition,"",null);
			secondSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			thirdSourceEnd=new MessageEnd(thirdSourceEndPosition,"",null);
			thirdSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			fourthSourceEnd=new MessageEnd(fourthSourceEndPosition,"",null);
			fourthSourceEnd.MessageEndKind=MessageEndKind.sourceEnd;
			firstDestinationEnd=new MessageEnd(firstDestinationEndPosition,"",null);
			firstDestinationEnd.MessageEndKind=MessageEndKind.destinationEnd;
			secondDestinationEnd=new MessageEnd(secondDestinationEndPosition,"",null);
			secondDestinationEnd.MessageEndKind=MessageEndKind.destinationEnd;
		}
		
		/*
		[Test]
		public void SortListOfLifelineElementsTest()
		{
			relevantLifeline.BehaviorExecutionSpecifications.Add(secondExecutionSpecification);
			relevantLifeline.BehaviorExecutionSpecifications.Add(firstExecutionSpecification);
			
			relevantLifeline.MessageEnds.Add(firstDestinationEnd);	
			relevantLifeline.MessageEnds.Add(thirdSourceEnd);
			relevantLifeline.MessageEnds.Add(firstSourceEnd);
			relevantLifeline.MessageEnds.Add(fourthSourceEnd);
			relevantLifeline.MessageEnds.Add(secondSourceEnd);
			relevantLifeline.MessageEnds.Add(secondDestinationEnd);
			
			ArrayList returnedList=elementListSorter.SortLifelineElements(relevantLifeline);
			Assert.IsNotNull(returnedList);
			int returnedListCount=returnedList.Count;
			Assert.IsTrue(returnedListCount==6);
			
			BehaviorExecutionSpecification firstActualExecutionSpec=
				(BehaviorExecutionSpecification)returnedList[0];
			Assert.AreEqual(firstExecutionSpecification,firstActualExecutionSpec);
			MessageEnd firstActualSourceEnd=(MessageEnd)returnedList[1];
			Assert.AreEqual(firstSourceEnd,firstActualSourceEnd);
			MessageEnd secondActualSourceEnd=(MessageEnd)returnedList[2];
			Assert.AreEqual(secondSourceEnd,secondActualSourceEnd);
			MessageEnd thirdActualSourceEnd=(MessageEnd)returnedList[3];
			Assert.AreEqual(thirdSourceEnd,thirdActualSourceEnd);
			MessageEnd fourthActualSourceEnd=(MessageEnd)returnedList[4];
			Assert.AreEqual(fourthSourceEnd,fourthActualSourceEnd);
			BehaviorExecutionSpecification secondActualExecutionSpec=
				(BehaviorExecutionSpecification)returnedList[5];
			Assert.AreEqual(secondExecutionSpecification,secondActualExecutionSpec);
		}
		
		[Test]
		public void SortListOfLifelineElementsOnlyExecutionSpecsTest()
		{
			relevantLifeline.BehaviorExecutionSpecifications.Add(secondExecutionSpecification);
			relevantLifeline.BehaviorExecutionSpecifications.Add(firstExecutionSpecification);
			
			ArrayList returnedList=elementListSorter.SortLifelineElements(relevantLifeline);
			Assert.IsNotNull(returnedList);
			int returnedListCount=returnedList.Count;
			Assert.IsTrue(returnedListCount==2);
			BehaviorExecutionSpecification firstActualExecutionSpec=
				(BehaviorExecutionSpecification)returnedList[0];
			Assert.AreEqual(firstExecutionSpecification,firstActualExecutionSpec);
			BehaviorExecutionSpecification secondActualExecutionSpec=
				(BehaviorExecutionSpecification)returnedList[1];
			Assert.AreEqual(secondExecutionSpecification,secondActualExecutionSpec);
		}
		
		[Test]
		public void SortListOfLifelineElementsOnlyMessageEndsTest()
		{
			relevantLifeline.MessageEnds.Add(firstSourceEnd);
			relevantLifeline.MessageEnds.Add(thirdSourceEnd);
			relevantLifeline.MessageEnds.Add(secondSourceEnd);
			relevantLifeline.MessageEnds.Add(fourthSourceEnd);
			relevantLifeline.MessageEnds.Add(firstDestinationEnd);	
			relevantLifeline.MessageEnds.Add(secondDestinationEnd);
			
			ArrayList returnedList=elementListSorter.SortLifelineElements(relevantLifeline);
			Assert.IsNotNull(returnedList);
			int returnedListCount=returnedList.Count;
			Assert.IsTrue(returnedListCount==4);
			MessageEnd firstActualSourceEnd=(MessageEnd)returnedList[0];
			Assert.AreEqual(firstSourceEnd,firstActualSourceEnd);
			MessageEnd secondActualSourceEnd=(MessageEnd)returnedList[1];
			Assert.AreEqual(secondSourceEnd,secondActualSourceEnd);
			MessageEnd thirdActualSourceEnd=(MessageEnd)returnedList[2];
			Assert.AreEqual(thirdSourceEnd,thirdActualSourceEnd);
			MessageEnd fourthActualSourceEnd=(MessageEnd)returnedList[3];
			Assert.AreEqual(fourthSourceEnd,fourthActualSourceEnd);
		}
		
		[Test]
		public void SortListOfLifelineElementsNoElementsTest()
		{
			ArrayList returnedList=elementListSorter.SortLifelineElements(relevantLifeline);
			Assert.IsNotNull(returnedList);
			int returnedListCount=returnedList.Count;
			Assert.IsTrue(returnedListCount==0);
		}*/
	}
}
