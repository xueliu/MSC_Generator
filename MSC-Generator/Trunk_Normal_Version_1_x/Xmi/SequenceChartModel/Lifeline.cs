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
		private ArrayList behaviorExecutionSpecifications;
		private ArrayList messageEnds;
		
		public Lifeline(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){
			
			behaviorExecutionSpecifications=new ArrayList();
			messageEnds=new ArrayList();
		}
		
		public ArrayList BehaviorExecutionSpecifications{
			get{
				return behaviorExecutionSpecifications;
			}
			set{
				behaviorExecutionSpecifications=value;
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
		
	
		
		
	}
}
