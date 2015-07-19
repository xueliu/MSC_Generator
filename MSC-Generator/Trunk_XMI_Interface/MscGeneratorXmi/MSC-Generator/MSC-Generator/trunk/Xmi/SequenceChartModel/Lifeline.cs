/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 11:39
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;
using System.Collections;

namespace sequenceChartModel
{
	/// <summary>
	/// Description of Lifeline.
	/// </summary>
	public class Lifeline:SequenceChartElement
	{	
		private ArrayList executionSpecifications;
		private ArrayList messageEnds;
		private bool isDestructed;
		
		
		public Lifeline(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){
			
			executionSpecifications=new ArrayList();
			messageEnds=new ArrayList();
			
		}
		
		public ArrayList ExecutionSpecifications{
			get{
				return executionSpecifications;
			}
			set{
				executionSpecifications=value;
			}
		}
		
		public ArrayList MessageEnds{
			get{
				return messageEnds;
			}
			set{
				messageEnds=value;
			}
		}
		
		public bool IsDestructed{
			get{
				return isDestructed;
			}
			set{
				isDestructed=value;
			}
		}
	
		public ArrayList GetConnectedSourceMessageEnds()
		{
			MessageEnd currentMessageEnd;
			MessageEndKind currentMessageEndKind;
			ArrayList coveredSourceMessageEnds=new ArrayList();
			IEnumerator itrMessageEnds=this.messageEnds.GetEnumerator();
			
			while(itrMessageEnds.MoveNext())
			{
				currentMessageEnd=(MessageEnd)itrMessageEnds.Current;
				currentMessageEndKind=currentMessageEnd.MessageEndKind;
				
				if(currentMessageEndKind==MessageEndKind.sourceEnd)
				{
					coveredSourceMessageEnds.Add(currentMessageEnd);	
				}
			}
			
			return coveredSourceMessageEnds;
		}
		
		public ArrayList GetConnectedDestinationMessageEnds()
		{
			MessageEnd currentMessageEnd;
			MessageEndKind currentMessageEndKind;
			ArrayList coveredDestinationMessageEnds=new ArrayList();
			IEnumerator itrMessageEnds=this.messageEnds.GetEnumerator();
			
			while(itrMessageEnds.MoveNext())
			{
				currentMessageEnd=(MessageEnd)itrMessageEnds.Current;
				currentMessageEndKind=currentMessageEnd.MessageEndKind;
				
				if(currentMessageEndKind==MessageEndKind.destinationEnd)
				{
					coveredDestinationMessageEnds.Add(currentMessageEnd);	
				}
			}
			
			return coveredDestinationMessageEnds;
		}
	}
}
