/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.11.2007
 * Zeit: 16:34
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiExport
{
	/// <summary>
	/// Description of GraphNodeElementStub.
	/// </summary>
	public class GraphNodeElementStub
	{
		private const string ELEMENT_TYPE="contained";
		private const string XMI_TYPE="uml:GraphNode";
		
		public static XmlElement CreateGraphNodeElementStub(XmlDocument xmiDocument)
		{
			XmlElement graphNodeElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			graphNodeElement.SetAttributeNode(typeAttr);
			return graphNodeElement;
		}
		
		public static XmlElement CreateGraphNodeElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement graphNodeElement=CreateGraphNodeElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			graphNodeElement.SetAttributeNode(idAttr);
			return graphNodeElement;
		}
	}
}
