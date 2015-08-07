/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 11.12.2007
 * Zeit: 16:20
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of ExecutionOccurrenceSpecElementStub.
	/// </summary>
	public class ExecutionOccurrenceSpecElementStub
	{
		private const string ELEMENT_TYPE="fragment";
		private const string XMI_TYPE="uml:ExecutionOccurrenceSpecification";
		
		public static XmlElement CreateExecutionOccurrenceSpecElementStub(XmlDocument xmiDocument)
		{
			XmlElement executionOccurrenceSpecElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			executionOccurrenceSpecElement.SetAttributeNode(typeAttr);
			return executionOccurrenceSpecElement;
		}
		
		public static XmlElement CreateExecutionOccurrenceSpecElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement executionOccurrenceSpecElement=CreateExecutionOccurrenceSpecElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			executionOccurrenceSpecElement.SetAttributeNode(idAttr);
			return executionOccurrenceSpecElement;
		}
		
		public static XmlElement CreateExecutionOccurrenceSpecElementStub(XmlDocument xmiDocument,string id,string coveredAttrValue)
		{
			XmlElement executionOccurrenceSpecElement=CreateExecutionOccurrenceSpecElementStub(xmiDocument,id);
			executionOccurrenceSpecElement.SetAttribute(UmlModelElements.COVERED_ATTR_NAME,coveredAttrValue);
			return executionOccurrenceSpecElement;
		}
	}
}
