/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 11:30
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Xml;

namespace sequenceChartModel
{
	/// <summary>
	/// Description of SequenceChartElement.
	/// </summary>
	 
	
	public abstract class SequenceChartElement
	{
		protected Point position;
		protected string name;
		protected string xmiId;
		protected XmlElement xmlRepresentation;
		
		public SequenceChartElement(Point position,string xmiId,XmlElement xmlRepresentation)
		{
			this.position=position;
			this.xmiId=xmiId;
			this.xmlRepresentation=xmlRepresentation;
		}
		
		public Point Position{
			get{
				return position;
			}
			set{
				position=value;
			}
		}
		
		public string Name{
			get{
				return name;
			}
			set{
				name=value;
			}	
		}
		
		public string XmiId{
			get{
				return xmiId;
			}
			set{
				xmiId=value;
			}	
		}
		
		public XmlElement XmlRepresentation{
			get{
				return xmlRepresentation;
			}
			set{
				xmlRepresentation=value;
			}
		}
	}
}
