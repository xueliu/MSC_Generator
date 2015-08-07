/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 12.12.2007
 * Zeit: 19:12
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of MessageOccurrenceSpecElementStub.
	/// </summary>
	public class MessageOccurrenceSpecElementStub
	{
		private const string ELEMENT_TYPE="fragment";
		private const string XMI_TYPE="uml:MessageOccurrenceSpecification";
		
		public static XmlElement CreateMessageOccurrenceSpecElementStub(XmlDocument xmiDocument)
		{
			XmlElement messageOccurrenceSpecElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			messageOccurrenceSpecElement.SetAttributeNode(typeAttr);
			return messageOccurrenceSpecElement;
		}
		
		public static XmlElement CreateMessageOccurrenceSpecElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement messageOccurrenceSpecElement=CreateMessageOccurrenceSpecElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			messageOccurrenceSpecElement.SetAttributeNode(idAttr);
			return messageOccurrenceSpecElement;
		}
		
		public static XmlElement CreateMessageOccurrenceSpecElementStub(XmlDocument xmiDocument,string id,string name)
		{
			XmlElement messageOccurrenceSpecElement=CreateMessageOccurrenceSpecElementStub(xmiDocument,id);
			messageOccurrenceSpecElement.SetAttribute(UmlModelElements.NAME_ATTR_NAME,name);
			return messageOccurrenceSpecElement;
		}
	}
}
