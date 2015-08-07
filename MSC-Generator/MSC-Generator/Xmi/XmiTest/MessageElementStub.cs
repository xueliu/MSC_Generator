/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 11.12.2007
 * Zeit: 14:39
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of MessageElementStub.
	/// </summary>
	public class MessageElementStub
	{
		private const string ELEMENT_TYPE="message";
		private const string XMI_TYPE="uml:Message";
		
		
		public static XmlElement CreateMessageElementStub(XmlDocument xmiDocument)
		{
			XmlElement messageElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			messageElement.SetAttributeNode(typeAttr);
			return messageElement;
		}
		
		public static XmlElement CreateMessageElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement messageElement=CreateMessageElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			messageElement.SetAttributeNode(idAttr);
			return messageElement;
		}
		
		public static XmlElement CreateMessageElementStub(XmlDocument xmiDocument,string id,string messageName)
		{
			XmlElement messageElement=CreateMessageElementStub(xmiDocument,id);
			XmlAttribute nameAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,UmlModelElements.NAME_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			nameAttr.Value=messageName;
			messageElement.SetAttributeNode(nameAttr);
			return messageElement;
		}
	}
}
