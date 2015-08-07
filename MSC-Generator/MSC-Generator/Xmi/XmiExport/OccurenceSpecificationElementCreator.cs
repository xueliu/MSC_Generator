/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 10:56
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using nGenerator;
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of OccurenceSpecificationElementCreator.
	/// </summary>
	public class OccurenceSpecificationElementCreator:XmlElementCreator
	{
		private string OCCURENCE_SPECIFICATION_ELEMENT_TYPE_NAME="fragment"; 
		
		public OccurenceSpecificationElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 				base(xmiDocument,xmiDocumentBuilder){}
		
		
		public XmlElement CreateOccurenceSpecificationElement(XmlElement parentElement)
		{
			XmlElement occurenceSpecificationElement=this.AddReferenceAsElement(parentElement,OCCURENCE_SPECIFICATION_ELEMENT_TYPE_NAME,UmlModel.MESSAGE_OCCURRENCE_SPECIFICATION);
			
			return occurenceSpecificationElement;
			
		}
		
	}
}
