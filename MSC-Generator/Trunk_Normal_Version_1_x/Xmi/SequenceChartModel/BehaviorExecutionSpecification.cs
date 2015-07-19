/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 14:13
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Xml;
using System.Collections;
using System.Drawing;

namespace sequenceChartModel
{
	/// <summary>
	/// Description of BehaviorExecutionSpecification.
	/// </summary>
	public class BehaviorExecutionSpecification:SequenceChartElement
	{
		ArrayList messageEnds;
		
		public BehaviorExecutionSpecification(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation)
		{
			messageEnds=new ArrayList();	
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
