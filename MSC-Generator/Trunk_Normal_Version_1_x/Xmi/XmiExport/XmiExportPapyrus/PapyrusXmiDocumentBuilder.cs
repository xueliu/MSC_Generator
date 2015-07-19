/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.11.2007
 * Zeit: 14:52
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmiExport;

namespace xmiExportPapyrus
{
	/// <summary>
	/// Description of PapyrusDocumentBuilder.
	/// </summary>
	public class PapyrusXmiDocumentBuilder:XmlDocumentBuilder
	{
		
		public PapyrusXmiDocumentBuilder():base(){}
		
	
		public override XmlDocument CreateXmlDocument()
		{
			this.XmiDocument= new XmlDocument();
			AddXmlDeclarationElement();
			return this.XmiDocument;
		}
		
		private void AddXmlDeclarationElement()
		{
			XmlDeclarationElementCreator declarationElementCreator=new XmlDeclarationElementCreator(this.XmiDocument);
			declarationElementCreator.CreateXmlDeclarationElement();
		}
	
		public override XmlElement AddUmlModelElement(String modelName)
		{	
			PapyrusModelElementCreator elementCreator= new PapyrusModelElementCreator(this.XmiDocument,this);
			XmlElement modelElement=elementCreator.CreatePapyrusModelElement(modelName);
			return modelElement;
		}
	}
}
