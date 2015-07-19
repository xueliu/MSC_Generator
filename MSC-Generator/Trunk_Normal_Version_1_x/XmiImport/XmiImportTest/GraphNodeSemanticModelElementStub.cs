/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 30.11.2007
 * Zeit: 17:09
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of GraphNodeSemanticModelStub.
	/// </summary>
	public class GraphNodeSemanticModelElementStub
	{
		private const string CONTAINED_ELEMENT_TYPE="contained"; 
		private const string SEMANTIC_MODEL_ELEMENT_TYPE="semanticModel";
		private const string ELEMENT_ELEMENT_TYPE="element"; 
		private const string XSI_TYPE_ATTR_NAME="type";
		private const string XSI_TYPE_ATTR_VALUE_LIFELINE="uml:Lifeline";
		
		public static XmlElement CreateGraphNodeSemanticModelElementStub(XmlDocument document)
		{
			XmlElement containedElement=document.CreateElement(CONTAINED_ELEMENT_TYPE);
			XmlElement semanticModelElement=document.CreateElement(SEMANTIC_MODEL_ELEMENT_TYPE);
			containedElement.AppendChild(semanticModelElement);
			XmlElement elementElement=document.CreateElement(ELEMENT_ELEMENT_TYPE);
			XmlAttribute xsiTypeAttr=
				document.CreateAttribute(PapyrusModel.XSI_NAMESPACE_PREFIX,XSI_TYPE_ATTR_NAME,PapyrusModel.XSI_NAMESPACE_URI);
			xsiTypeAttr.Value=XSI_TYPE_ATTR_VALUE_LIFELINE;
			elementElement.SetAttributeNode(xsiTypeAttr);
			semanticModelElement.AppendChild(elementElement);
			return containedElement;
		}
		
		public static XmlElement CreateGraphNodeSemanticModelElementStub(XmlDocument document,string id)
		{
			XmlElement containedElement=CreateGraphNodeSemanticModelElementStub(document);
			containedElement.SetAttribute("number",id);
			return containedElement;
			
		}
	}
}
