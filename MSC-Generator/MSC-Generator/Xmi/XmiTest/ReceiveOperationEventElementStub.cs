/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 14.01.2008
 * Zeit: 15:49
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of ReceiveOperationEventElementStub.
	/// </summary>
	public class ReceiveOperationEventElementStub
	{
		private const string ELEMENT_TYPE="packagedElement";
		private const string XMI_TYPE="uml:ReceiveOperationEvent";
		
		public static XmlElement CreateReceiveOperationEventElementStub(XmlDocument xmiDocument)
		{
			XmlElement eventElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			eventElement.SetAttributeNode(typeAttr);
			return eventElement;
		}
		
		public static XmlElement CreateReceiveOperationEventElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement eventElement=CreateReceiveOperationEventElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			eventElement.SetAttributeNode(idAttr);
			return eventElement;
		}
		
		public static XmlElement CreateReceiveOperationEventElementStub(XmlDocument xmiDocument,string id,string name)
		{
			XmlElement eventElement=CreateReceiveOperationEventElementStub(xmiDocument,id);
			eventElement.SetAttribute(UmlModelElements.NAME_ATTR_NAME,name);
			return eventElement;
		}
	}
}
