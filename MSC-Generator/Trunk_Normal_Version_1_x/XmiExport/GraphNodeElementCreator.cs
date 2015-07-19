/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.11.2007
 * Zeit: 14:49
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;

namespace xmiExport
{
	/// <summary>
	/// Description of GraphNodeElementCreator.
	/// </summary>
	public class GraphNodeElementCreator:GraphElementElementCreator
	{		 
		private const string GRAPH_ELEMENT_TYPE="contained";
		private const string COMMA=",";
		
		public GraphNodeElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									  base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateGraphNodeElementWithSemanticModel(XmlElement parentElement,string semanticModelElementId,RectangleF itemBounds)
		{
			XmlElement graphNodeElement=this.CreateUmlAttributeAsElement(parentElement,GRAPH_ELEMENT_TYPE,UmlModel.GRAPH_NODE);
			this.AddSemanticModelAttributeAsElement(graphNodeElement,semanticModelElementId);
			this.AddPositionAttribute(graphNodeElement,itemBounds);
			this.AddDimensionAttribute(graphNodeElement,itemBounds);
			return graphNodeElement;
		}
		
		public XmlElement CreateGraphNodeElementWithSimpleSemanticModel(XmlElement parentElement,string typeInfo,RectangleF itemBounds)
		{
			XmlElement graphNodeElement=this.CreateUmlAttributeAsElement(parentElement,GRAPH_ELEMENT_TYPE,UmlModel.GRAPH_NODE);
			this.AddSimpleSemanticModelAttributeAsElement(graphNodeElement,typeInfo);
			this.AddPositionAttribute(graphNodeElement,itemBounds);
			this.AddDimensionAttribute(graphNodeElement,itemBounds);
			return graphNodeElement;
		}
		
		protected void AddDimensionAttribute(XmlElement parentElement,RectangleF itemBounds)
		{
			float widthFloat=itemBounds.Width;
			string width=Convert.ToString(widthFloat);
			float heightFloat=itemBounds.Height;
			string height=Convert.ToString(heightFloat);
			string dimension=width+COMMA+height;
			this.AddAttribute(parentElement,UmlModel.DIMENSION_ATTR_NAME,dimension);
		}
			
		protected void AddPositionAttribute(XmlElement parentElement, RectangleF itemBounds)
		{
			float xFloat=itemBounds.X;
			string x=Convert.ToString(xFloat);
			float yFloat=itemBounds.Y;
			string y=Convert.ToString(yFloat);
			string position=x+COMMA+y;
			this.AddAttribute(parentElement,UmlModel.POSITION_ATTR_NAME,position);
		}
	}
}
