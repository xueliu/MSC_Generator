/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.11.2007
 * Zeit: 16:16
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;


namespace xmiExport
{
	/// <summary>
	/// Description of GraphNodeStub.
	/// </summary>
	public class GraphEdgeElementStub
	{
		private const string ELEMENT_TYPE="contained";
		private const string XMI_TYPE="uml:GraphEdge";
		
		public static XmlElement CreateGraphEdgeElementStub(XmlDocument xmiDocument)
		{
			XmlElement graphEdgeElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			graphEdgeElement.SetAttributeNode(typeAttr);
			return graphEdgeElement;
		}
		
		public static XmlElement CreateGraphEdgeElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement graphEdgeElement=CreateGraphEdgeElementStub(xmiDocument);
			
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			graphEdgeElement.SetAttributeNode(idAttr);
			return graphEdgeElement;
		}
	}
}
