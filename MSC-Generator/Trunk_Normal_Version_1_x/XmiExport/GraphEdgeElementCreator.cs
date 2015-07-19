/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.11.2007
 * Zeit: 18:48
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;

namespace xmiExport
{
	/// <summary>
	/// Description of GraphEdgeElementCreator.
	/// </summary>
	public class GraphEdgeElementCreator:GraphElementElementCreator
	{
		private const string GRAPH_EDGE_ELEMENT_TYPE="contained";
		private const string WAYPOINT_ELEMENT_TYPE="waypoints";
		
		public GraphEdgeElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									  base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateGraphEdgeElementWithSemanticModel(XmlElement parentElement,string elementId,Point sourceConnectionPoint,Point destinationConnectionPoint)
		{
			XmlElement graphEdgeElement=this.CreateUmlAttributeAsElement(parentElement,GRAPH_EDGE_ELEMENT_TYPE,UmlModel.GRAPH_EDGE);
			this.AddSemanticModelAttributeAsElement(graphEdgeElement,elementId);
			//this.AddPositionAttribute(graphEdgeElement,itemBounds);
			InitWaypointAttribute(graphEdgeElement,sourceConnectionPoint,destinationConnectionPoint);
			return graphEdgeElement;
		}
		
		public XmlElement CreateGraphEdgeElementWithSimplSemanticModel(XmlElement parentElement,string typeInfo,Point sourceConnectionPoint,Point destinationConnectionPoint)
		{
			XmlElement graphEdgeElement=this.CreateUmlAttributeAsElement(parentElement,GRAPH_EDGE_ELEMENT_TYPE,UmlModel.GRAPH_EDGE);
			this.AddSimpleSemanticModelAttributeAsElement(graphEdgeElement,typeInfo);
			//this.AddPositionAttribute(graphEdgeElement,itemBounds);
			InitWaypointAttribute(graphEdgeElement,sourceConnectionPoint,destinationConnectionPoint);
			return graphEdgeElement;
		}
		
		private void InitWaypointAttribute(XmlElement graphEdgeElement,PointF sourceConnectionPoint,Point destinationConnectionPoint)
		{
			AddWaypointAttributeAsElement(graphEdgeElement,sourceConnectionPoint);
			AddWaypointAttributeAsElement(graphEdgeElement,destinationConnectionPoint);
		}
		
		private void AddWaypointAttributeAsElement(XmlElement graphEdgeElement,PointF connectionPoint)
		{
			float xFloat=connectionPoint.X;
			string x=Convert.ToString(xFloat);
			CreatePrimitiveAttributeAsElement(graphEdgeElement,WAYPOINT_ELEMENT_TYPE,x);	
			
			float yFloat=connectionPoint.Y;
			string y=Convert.ToString(yFloat);
			CreatePrimitiveAttributeAsElement(graphEdgeElement,WAYPOINT_ELEMENT_TYPE,y);
		}
	}
}
