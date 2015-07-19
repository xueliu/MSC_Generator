/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 12:14
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Collections;

namespace sequenceChartModel
{
	/// <summary>
	/// Description of Interaction.
	/// </summary>
	public class Interaction:SequenceChartElement
	{
		private ArrayList lifelines;
		private ArrayList messages;
		
		public Interaction(Point position,string xmiId):base(position,xmiId){
			
			lifelines=new ArrayList();
			messages=new ArrayList() ;
		}
		
		public ArrayList Messages{
			get{
				return messages;
			}
		}
		
		public ArrayList Lifelines{
			get{
				return lifelines;
			}
		}
	}
}
