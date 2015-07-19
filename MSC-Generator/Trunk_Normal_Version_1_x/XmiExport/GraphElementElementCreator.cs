/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.11.2007
 * Zeit: 12:53
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
	public abstract class GraphElementElementCreator:XmlElementCreator
	{
		private const string SEMANTIC_MODEL_ELEMENT_TYPE="semanticModel";
		private const string POSITION_ELEMENT_TYPE="position";
				
		public GraphElementElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									  base(xmiDocument,xmiDocumentBuilder){}
		
		protected void AddSemanticModelAttributeAsElement(XmlElement parentElement,string semanticModelElementId)
		{
			XmlElement semanticModelAttrElement =
					CreateUmlAttributeAsElement(parentElement,SEMANTIC_MODEL_ELEMENT_TYPE,UmlModel.CORE_SEMANTIC_MODEL_BRIDGE);
			semanticModelAttrElement.SetAttribute(UmlModel.ELEMENT_ATTR_NAME,semanticModelElementId);
		}
		
		protected void AddSimpleSemanticModelAttributeAsElement(XmlElement parentElement,string typeInfo)
		{
			XmlElement simpleSemanticModelElement=CreateUmlAttributeAsElement(parentElement,SEMANTIC_MODEL_ELEMENT_TYPE,UmlModel.SIMPLE_SEMANTIC_MODEL_ELEMENT);
			simpleSemanticModelElement.SetAttribute(UmlModel.TYPE_INFO_ATTR_NAME,typeInfo);
		}
	}
	
	
}
