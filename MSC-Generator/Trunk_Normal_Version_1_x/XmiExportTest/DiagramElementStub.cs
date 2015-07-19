/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 08.11.2007
 * Zeit: 09:59
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiExport
{
	/// <summary>
	/// Description of DiagramElementStub.
	/// </summary>
	public class DiagramElementStub
	{
		private const string ELEMENT_TYPE="ownedMember";
		private const string XMI_TYPE="uml:Diagram";
		
		public static XmlElement CreateDiagramElementStub(XmlDocument xmiDocument)
		{
			XmlElement diagramElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			diagramElement.SetAttributeNode(typeAttr);
			return diagramElement;
		}
	}
}
