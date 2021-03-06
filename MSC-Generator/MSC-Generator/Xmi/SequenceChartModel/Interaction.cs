/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 12:14
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Xml;
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
		private ArrayList messageOccurrenceSpecs;
		private ArrayList executionOccurrenceSpecs;
		private ArrayList executionSpecs;
		private ArrayList formalGates;
		
		public Interaction(Point position,string xmiId,XmlElement xmlRepresentation):base(position,xmiId,xmlRepresentation){
			
			lifelines=new ArrayList();
			messages=new ArrayList() ;
			executionSpecs= new ArrayList();
			executionOccurrenceSpecs = new ArrayList();
			messageOccurrenceSpecs= new ArrayList();
			formalGates=new ArrayList();
		}
		
		public ArrayList Messages{
			get{
				return messages;
			}
			set{
				messages=value;
			}
		}
		
		public ArrayList Lifelines{
			get{
				return lifelines;
			}
			set{
				lifelines=value;
			}
		}
		
		public ArrayList MessageOccurrenceSpecs{
			get{
				return messageOccurrenceSpecs;
			}
			set{
				messageOccurrenceSpecs=value;
			}
		}
		
		
		public ArrayList ExecutionOccurrenceSpecs{
			get{
				return executionOccurrenceSpecs;
			}
			set{
				executionOccurrenceSpecs=value;
			}
		}
		
		public ArrayList ExecutionSpecs{
			get{
				return executionSpecs;
			}
			set{
				executionSpecs=value;
			}
			
		}
		
		public ArrayList FormalGates{
			get{
				
				return formalGates;
			}
			set{
				formalGates=value;
			}
		}
	}
}
