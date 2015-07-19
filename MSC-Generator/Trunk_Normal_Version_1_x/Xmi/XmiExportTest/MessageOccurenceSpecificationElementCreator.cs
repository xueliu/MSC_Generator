/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 14:45
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;

namespace xmiExport
{
	/// <summary>
	/// Description of MessageOccurenceSpecification.
	/// </summary>
	public class MessageOccurenceSpecificationElementCreator:XmlElementCreator
	{
		private const string MESSAGE_OCCURENCE_SPECIFICATION_ELEMENT_TYPE_NAME="fragment";
		
		public MessageOccurenceSpecificationElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
			base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement createMessageOccurenceSpecificationElement(XmlElement parentElement, MSCItem messageOccurenceSpecificationItem)
		{
			XmlElement messageOccurenceSpecificationElement=this.CreateUmlAttributeAsElement(parentElement,MESSAGE_OCCURENCE_SPECIFICATION_ELEMENT_TYPE_NAME,UmlModel.MESSAGE_OCCURRENCE_SPECIFICATION);
			AddMessageOccurenceSpecificationNameAttribute(messageOccurenceSpecificationElement,messageOccurenceSpecificationItem);
			return messageOccurenceSpecificationElement;
		}
			
		//todo mName field is protected; do messageOccurenceSpe
		private void AddMessageOccurenceSpecificationNameAttribute(XmlElement messageOccurenceSpecificationElement,MSCItem messageOccurenceItem)
		{
				
		}
	}
}
