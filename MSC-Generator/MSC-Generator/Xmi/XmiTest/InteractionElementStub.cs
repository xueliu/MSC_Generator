/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 08:29
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmi;

namespace xmi
{
	/// <summary>
	/// Description of InteractionElementStub.
	/// </summary>
	/// 
	
	
	
	public class InteractionElementStub
	{
		private const string ELEMENT_TYPE="packagedElement";
		private const string XMI_TYPE="uml:Interaction";
		
		public static XmlElement CreateInteractionElementStub(XmlDocument xmiDocument)
		{
			XmlElement interactionElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			interactionElement.SetAttributeNode(typeAttr);
			return interactionElement;
		}
		
		public static XmlElement CreateInteractionElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement interactionElement=CreateInteractionElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			interactionElement.SetAttributeNode(idAttr);
			return interactionElement;
		}
		
		public static XmlElement CreateInteractionElementStub(XmlDocument xmiDocument,string id,string interactionName)
		{
			XmlElement interactionElement=CreateInteractionElementStub(xmiDocument,id);
			interactionElement.SetAttribute(UmlModelElements.NAME_ATTR_NAME,interactionName);
			return interactionElement;
		}
	}
}
