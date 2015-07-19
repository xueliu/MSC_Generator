/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 27.08.2008
 * Zeit: 14:34
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Xml;

namespace sequenceChartModel
{
	/// <summary>
	/// Description of BehaviorExecutionSpecificationBegin.
	/// </summary>
	/// 
	
	public enum ExecutionOccurrenceSpecKind{
		START,
		FINISH
	}
	
	public class ExecutionOccurrenceSpecification:SequenceChartElement
	{
		private Lifeline coveredLifeline;
		private ExecutionOccurrenceSpecKind specificationKind;
		
		
		public ExecutionOccurrenceSpecification(Point position,string xmiId,XmlElement xmlRepresentation):
		base (position,xmiId,xmlRepresentation){}
		
		public ExecutionOccurrenceSpecKind SpecificationKind{
			
			get{
				
				return specificationKind;
			}
			set{
				
				specificationKind=value;
			}
		}
		
		public Lifeline CoveredLifeline{
			
			get{
				return coveredLifeline;
			}
			set{
				
				coveredLifeline=value;
			}
		}	
	}
}
