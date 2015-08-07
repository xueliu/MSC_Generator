/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 19.10.2007
 * Zeit: 15:49
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class XmiDocumentWithModelElementStub:XmlDocument
	{
		private XmlElement xmiElement;
		private XmlElement modelElement;
		
		public XmiDocumentWithModelElementStub():base()
		{
			this.xmiElement=XmiElementStub.CreateXmiElement(this);
			this.modelElement=ModelElementStub.CreateModelElementStub(this);
			this.AppendChild(xmiElement);
			xmiElement.AppendChild(modelElement);
		}
		
		public XmlElement XmiElement{
			
			get{
				return this.xmiElement;
			}
		}
		
		public XmlElement ModelElement{
			
			get{
				return this.modelElement;
			}
		}
	}
}
