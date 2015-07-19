/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 13.12.2007
 * Zeit: 16:18
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Collections;

namespace sequenceChartModel
{
	/// <summary>
	/// Description of Sorter.
	/// </summary>
	public class SequenceChartElementListSorter
	{
		private ArrayList sequenceChartElements;
		
		
		public ArrayList SortListForHorizontalPosition(ArrayList sequenceChartElements)
		{
			this.sequenceChartElements=sequenceChartElements;
			SelectionSortHorizontalPosition();
			return sequenceChartElements;
		}
		
		public ArrayList SortListForVerticalPosition(ArrayList sequenceChartElements)
		{
			this.sequenceChartElements=sequenceChartElements;
			SelectionSortVerticalPosition();
			return sequenceChartElements;
		}
		
		//weg
		public ArrayList SortElementsOfLifelines(ArrayList lifelines)
		{
			ArrayList elementsAllLifelines=new ArrayList();
			Lifeline currentLifeline;
			ArrayList currentLifelineBehaviorExecutionSpecs;
			ArrayList currentLifelineMessageEnds;
			IEnumerator itrLifelines=lifelines.GetEnumerator();
			
			while(itrLifelines.MoveNext())
			{
				currentLifeline=(Lifeline)itrLifelines.Current;
				currentLifelineBehaviorExecutionSpecs=currentLifeline.ExecutionSpecifications;
				currentLifelineMessageEnds=currentLifeline.MessageEnds;
				elementsAllLifelines.AddRange(currentLifelineBehaviorExecutionSpecs);
				elementsAllLifelines.AddRange(currentLifelineMessageEnds);
			}
			
			this.sequenceChartElements=elementsAllLifelines;
			SelectionSortVerticalPosition();
			ChangeRelevantMessageEndsAndExecutions(lifelines);
			DebuggSortetList(sequenceChartElements);
			return sequenceChartElements;
		}
		
		//nur zum Debuggen
		public void DebuggSortetList(ArrayList elements)
		{
			SequenceChartElement currentElement;
			Message currentMessage;
			string currentMessageName;
			MessageEnd currentMessageEnd;
			
			
			int elementsCount=elements.Count;
			
			for(int index=14;index<elementsCount;index++)
			{
				currentElement=(SequenceChartElement)elements[index];
				
				if(currentElement is ExecutionSpecification)
				{
					
				}
				else if (currentElement is MessageEnd)
				{
					currentMessageEnd=(MessageEnd)currentElement;
					currentMessage=currentMessageEnd.CorrespondingMessage;
					currentMessageName=currentMessage.Name;
				}
				
			}
			
			
		}
		
		public ArrayList SortOccurrenceSpecifications(ArrayList occurrenceSpecifications)
		{
			ArrayList sortedOccurrenceSpecifications;
			sortedOccurrenceSpecifications=SortListForVerticalPosition(occurrenceSpecifications);
			sortedOccurrenceSpecifications=ChangeRelevantOccurrenceSpecificationPositions(sortedOccurrenceSpecifications);
			return sortedOccurrenceSpecifications;
		}
		
		public ArrayList ChangeRelevantOccurrenceSpecificationPositions(ArrayList occurrenceSpecifications)
		{
			ArrayList changedOccurrenceSpecifications;
			SequenceChartElement currentOccurrenceSpecElement;
			SequenceChartElement nextOccurrenceSpecElement;
	
			
			changedOccurrenceSpecifications=occurrenceSpecifications;
			int countEnd=occurrenceSpecifications.Count-1;
			
			for(int count=0;count<countEnd;count++)
			{				
				currentOccurrenceSpecElement=(SequenceChartElement)changedOccurrenceSpecifications[count];
				nextOccurrenceSpecElement= (SequenceChartElement)changedOccurrenceSpecifications[count+1];
				
				if(currentOccurrenceSpecElement.Position.Y == nextOccurrenceSpecElement.Position.Y)
				{
					if((currentOccurrenceSpecElement is MessageEnd) &&
					   (nextOccurrenceSpecElement is ExecutionOccurrenceSpecification))
					{
					   	if(((ExecutionOccurrenceSpecification)nextOccurrenceSpecElement).SpecificationKind==ExecutionOccurrenceSpecKind.START)
					   	{
					   		changedOccurrenceSpecifications[count]=nextOccurrenceSpecElement;
					   		changedOccurrenceSpecifications[count+1]=currentOccurrenceSpecElement;
					   	}
					}
					else if((nextOccurrenceSpecElement is  MessageEnd) &&
					       (currentOccurrenceSpecElement is ExecutionOccurrenceSpecification))
					{
					 	if(((ExecutionOccurrenceSpecification)currentOccurrenceSpecElement).SpecificationKind==ExecutionOccurrenceSpecKind.FINISH)
					   	{
					 		changedOccurrenceSpecifications[count]=nextOccurrenceSpecElement;
					 		changedOccurrenceSpecifications[count+1]=currentOccurrenceSpecElement;
					   	}				
					}
				}
			}
			
			return changedOccurrenceSpecifications;
		}
			
		
		/*public ArrayList SortLifelineElements(Lifeline lifeline)
		{
			ArrayList executionSpecs=lifeline.BehaviorExecutionSpecifications;
			ArrayList messageEnds=lifeline.GetConnectedSourceMessageEnds();
			ArrayList elementsOfLifeline=new ArrayList();
			elementsOfLifeline.AddRange(executionSpecs);
			elementsOfLifeline.AddRange(messageEnds);
			sequenceChartElements=elementsOfLifeline;
			SelectionSortVerticalPosition();
			ChangeRelevantMessageEndsAndExecutions();
		
			return sequenceChartElements;
		}*/
		
		
		//mal anschauen
		protected void ChangeRelevantMessageEndsAndExecutions(ArrayList lifelines)
		{
			int sequenceChartElementsCount=sequenceChartElements.Count-1;
			SequenceChartElement currentElement;
			Point currentElementPosition;
			SequenceChartElement nextElement;
			Lifeline currentElementLifeline;
			int currentElementLifelinePosition;
			Lifeline nextElementLifeline;
			int nextElementLifelinePosition;
			
			
			for(int index=0;index<sequenceChartElementsCount;index++)
			{
				currentElement=(SequenceChartElement)sequenceChartElements[index];
				currentElementPosition=currentElement.Position;
				nextElement=(SequenceChartElement)sequenceChartElements[index+1];
				
				
				if((currentElement is MessageEnd)&&(nextElement is ExecutionSpecification)
				   &&(currentElement.Position.Y==nextElement.Position.Y))
				{
					currentElementLifeline=((MessageEnd)currentElement).CoveredLifeline;
					currentElementLifelinePosition=lifelines.IndexOf(currentElementLifeline);
					nextElementLifeline=((ExecutionSpecification)nextElement).CoveredLifeline;
					nextElementLifelinePosition=lifelines.IndexOf(nextElementLifeline);
					
					if(currentElementLifelinePosition==nextElementLifelinePosition)
					{
						sequenceChartElements[index+1]=currentElement;
						sequenceChartElements[index]=nextElement;
					}
				}
			}
		}
		
		protected void SelectionSortHorizontalPosition()
		{
			int sequenceChartElementsCount=sequenceChartElements.Count;
			int minIndex;
			
			for(int index=0;index<sequenceChartElementsCount;index++)
			{
				minIndex=GetMinimumPositionForX(index);
				ExchangeElements(minIndex,index);
			}
		}
		
		protected void SelectionSortVerticalPosition()
		{
			int sequenceChartElementsCount=sequenceChartElements.Count;
			int minIndex;
			
			for(int index=0;index<sequenceChartElementsCount;index++)
			{
				minIndex=GetMinimumPositionForY(index);
				ExchangeElements(minIndex,index);
			}
		}
		
		protected int GetMinimumPositionForX(int startIndex)
		{
			SequenceChartElement currentElement;
			Point currentElementPosition;
			int currentElementPositionX;
			
			SequenceChartElement minElement=(SequenceChartElement)sequenceChartElements[startIndex];
			Point minElementPosition=minElement.Position;
			int minElementPositionX=minElementPosition.X;
			int relevantIndex=startIndex;
			int sequenceChartElementsCount=sequenceChartElements.Count;
			
			for(int index=startIndex+1; index<sequenceChartElementsCount;index++) 
			{
				currentElement=(SequenceChartElement)sequenceChartElements[index];
				currentElementPosition=currentElement.Position;
				currentElementPositionX=currentElementPosition.X;
				
				if(minElementPositionX>currentElementPositionX)
				{
					minElementPositionX=currentElementPositionX;
					relevantIndex=index;
				}
			}
			
			return relevantIndex;
		}
		
		protected int GetMinimumPositionForY(int startIndex)
		{
			SequenceChartElement currentElement;
			Point currentElementPosition;
			int currentElementPositionY;
			
			SequenceChartElement minElement=(SequenceChartElement)sequenceChartElements[startIndex];
			Point minElementPosition=minElement.Position;
			int minElementPositionY=minElementPosition.Y;
			int relevantIndex=startIndex;
			int sequenceChartElementsCount=sequenceChartElements.Count;
			
			for(int index=startIndex+1; index<sequenceChartElementsCount;index++) 
			{
				currentElement=(SequenceChartElement)sequenceChartElements[index];
				currentElementPosition=currentElement.Position;
				currentElementPositionY=currentElementPosition.Y;
				
				if(minElementPositionY>currentElementPositionY)
				{
					minElementPositionY=currentElementPositionY;
					relevantIndex=index;
				}
			}
			
			return relevantIndex;
		}
		
		private void ExchangeElements(int index1,int index2)
		{
			SequenceChartElement savedElement=(SequenceChartElement)sequenceChartElements[index1];
			sequenceChartElements[index1]=sequenceChartElements[index2];
			sequenceChartElements[index2]=savedElement;
		}
	}
}
