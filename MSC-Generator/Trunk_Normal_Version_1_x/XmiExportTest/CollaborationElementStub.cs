/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 17:31
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiExport
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class CollaborationElementStub
	{
		private const string ELEMENT_TYPE="packagedElement";
		private const string XMI_TYPE="uml:Collaboration";
		
		public static XmlElement CreateCollaborationElementStub(XmlDocument xmiDocument)
		{
			XmlElement collaborationElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			collaborationElement.SetAttributeNode(typeAttr);
			return collaborationElement;
		}
	}
}
