/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 29.10.2007
 * Zeit: 17:47
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using nGenerator;


namespace xmiExport
{
	/// <summary>
	/// Description of McsDiagramInterpreter.
	/// </summary>
	public class McsDiagramInterpreter
	{
		private Generator currentGenerator;
		private XmlDocumentBuilder xmiDocumentBuilder;
		
		
		public McsDiagramInterpreter(Generator currentGenerator)
		{
			this.currentGenerator=currentGenerator;	
			xmiDocumentBuilder=new XmlDocumentBuilder();
		}
		
		public Generator CurrentGenerator{
			get{
				return this.currentGenerator;
			}
			set{
				this.currentGenerator=value;
			}
		}
		
		public XmlDocumentBuilder XmiDocumentBuilder{
			get{
				return this.xmiDocumentBuilder;
			}
			set{
				this.xmiDocumentBuilder=value;
			}
		}
		
		
		
		
	}
}
