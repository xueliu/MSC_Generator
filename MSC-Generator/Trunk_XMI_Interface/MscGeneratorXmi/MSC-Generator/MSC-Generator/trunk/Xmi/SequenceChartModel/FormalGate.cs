/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 07.11.2008
 * Zeit: 20:51
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;


namespace sequenceChartModel
{

	public enum FormalGateType
	{
		ENV_LEFT,
		ENV_RIGHT,
	}
	
	
	/// <summary>
	/// Description of FormalGate.
	/// </summary>
	public class FormalGate:MessageEnd
	{
		
		public FormalGate(Point position,string xmiId,XmlElement xmlRepresentation):
				base(position,xmiId,xmlRepresentation){}
		
		
		public FormalGateType FormalGateKind {
			get;
			set;
		}		
	}
}
