/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.11.2007
 * Zeit: 16:18
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Drawing;
using mscElements;
using nGenerator;

namespace xmiExport
{
	/// <summary>
	/// Description of DiagramElementCreator.
	/// </summary>

	
	
	
	public class DiagramElementCreator:GraphElementElementCreator
	{
		private const string TYPE_INFO="sequenceDiagram";
		private const string DIAGRAM_ELEMENT_TYPE="ownedMember";
		
		public DiagramElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateDiagramElement(XmlElement parentElement)
		{
			XmlElement diagramElement= this.CreateUmlAttributeAsElement(parentElement,DIAGRAM_ELEMENT_TYPE,UmlModel.DIAGRAM);
			AddDiagramNameAttribute(diagramElement);
			AddSimpleSemanticModelAttributeAsElement(diagramElement,TYPE_INFO);
			return diagramElement;
		}
		
		private void AddDiagramNameAttribute(XmlElement diagramElement)
		{
			string diagramName=MSC.DiagramName;
			
			if(diagramName!=null)
			{
				this.AddNameAttribute(diagramElement,diagramName);
			}
		}
		
		protected void AddDimensionAttributeAsElement(XmlElement parentElement,RectangleF itemBounds)
		{
			XmlElement dimensionElement=this.CreateUmlAttributeAsElement(parentElement,UmlModel.DIMENSION_ATTR_NAME);
			float widthFloat=itemBounds.Width;
			string width=Convert.ToString(widthFloat);
			this.AddDoubleValueElement(dimensionElement,width);
			
			float heightFloat=itemBounds.Height;
			string height=Convert.ToString(heightFloat);
			this.AddDoubleValueElement(dimensionElement,height);
			parentElement.AppendChild(dimensionElement);
		}
	}
}
