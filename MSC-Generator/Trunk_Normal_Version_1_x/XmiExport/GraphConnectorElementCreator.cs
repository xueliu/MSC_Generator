/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.11.2007
 * Zeit: 19:28
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;

namespace xmiExport
{
	/// <summary>
	/// Description of GraphConnectorElementCreator.
	/// </summary>
	/// 
	
	
	public class GraphConnectorElementCreator:XmlElementCreator
	{
		private string GRAPH_CONNECTOR_ELEMENT_TYPE="anchorage";
		private const string COMMA=",";
		
		public GraphConnectorElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									  base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateGraphConnectorElement(XmlElement parentElement,XmlElement graphEdgeElement,string x,string y)
		{
			XmlElement graphConnectorElement=this.CreateUmlAttributeAsElement(parentElement,GRAPH_CONNECTOR_ELEMENT_TYPE,UmlModel.GRAPH_CONNECTOR);
			AddGraphEdgeAttribute(graphEdgeElement,graphConnectorElement);
			AddAnchorAttributeToGraphEdgeElement(graphEdgeElement,graphConnectorElement);
			AddPositionAttribute(graphConnectorElement,x,y);
			return graphConnectorElement;
		}
		
		private void AddGraphEdgeAttribute(XmlElement graphEdgeElement,XmlElement graphConnectorElement)
		{
			string graphEdgeElementId=graphEdgeElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			AddAttribute(graphConnectorElement,UmlModel.GRAPH_EDGE_ATTR_NAME,graphEdgeElementId);
		}
		
		private void AddAnchorAttributeToGraphEdgeElement(XmlElement graphEdgeElement,XmlElement graphConnectorElement)
		{
			string graphConnectorElementId=graphConnectorElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			AddAttribute(graphEdgeElement,UmlModel.ANCHOR_ATTR_NAME,graphConnectorElementId);
		}
		
		private void AddPositionAttribute(XmlElement parentElement, string x, string y)
		{
			string position=x+COMMA+y;
			this.AddAttribute(parentElement,UmlModel.POSITION_ATTR_NAME,position);
		}
	}
}
		
