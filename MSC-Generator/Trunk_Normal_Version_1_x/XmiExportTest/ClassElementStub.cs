/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 20.11.2007
 * Zeit: 18:04
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiExport
{
	/// <summary>
	/// Description of ClassElementStub.
	/// </summary>
	public class ClassElementStub
	{
		private const string ELEMENT_TYPE="packagedElement";
		private const string XMI_TYPE="uml:Class";
		
		public static XmlElement CreateClassElementStub(XmlDocument xmiDocument)
		{
			XmlElement classElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			classElement.SetAttributeNode(typeAttr);
			return classElement;
		}
		
		public static XmlElement CreateClassElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement classElement=CreateClassElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			classElement.SetAttributeNode(idAttr);
			return classElement;
		}
	}
}
