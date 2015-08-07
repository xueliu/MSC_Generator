/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.11.2007
 * Zeit: 19:38
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of LifelineElementStub.
	/// </summary>
	
	
	public class LifelineElementStub
	{
		private const string ELEMENT_TYPE="lifeline";
		private const string XMI_TYPE="uml:Lifeline";
		
		public static XmlElement CreateLifelineElementStub(XmlDocument xmiDocument)
		{
			XmlElement lifelineElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			lifelineElement.SetAttributeNode(typeAttr);
			return lifelineElement;
		}
		
		public static XmlElement CreateLifelineElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement lifelineElement=CreateLifelineElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			lifelineElement.SetAttributeNode(idAttr);
			return lifelineElement;
		}
		
		public static XmlElement CreateLifelineElementStub(XmlDocument xmiDocument,string id,string name)
		{
			XmlElement lifelineElement=CreateLifelineElementStub(xmiDocument,id);
			lifelineElement.SetAttribute(UmlModelElements.NAME_ATTR_NAME,name);
			return lifelineElement;
		}
	}
}
