/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 11.12.2007
 * Zeit: 15:23
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of BehaviorExecutionSpecElement.
	/// </summary>
	public class BehaviorExecutionSpecElementStub
	{
		private const string ELEMENT_TYPE="fragment";
		private const string XMI_TYPE="uml:BehaviorExecutionSpecification";
		
		public static XmlElement CreateBehaviorExecutionSpecElementStub(XmlDocument xmiDocument)
		{
			XmlElement behaviorExecutionSpecElement=xmiDocument.CreateElement(ELEMENT_TYPE);
			XmlAttribute typeAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_TYPE_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			typeAttr.Value=XMI_TYPE;
			behaviorExecutionSpecElement.SetAttributeNode(typeAttr);
			return behaviorExecutionSpecElement;
		}
		
		public static XmlElement CreateBehaviorExecutionSpecElementStub(XmlDocument xmiDocument,string id)
		{
			XmlElement behaviorExecutionSpecElement=CreateBehaviorExecutionSpecElementStub(xmiDocument);
			XmlAttribute idAttr=
				xmiDocument.CreateAttribute(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_ID_ATTR_NAME,XmiElements.XMI_NAMESPACE_URI);
			idAttr.Value=id;
			behaviorExecutionSpecElement.SetAttributeNode(idAttr);
			return behaviorExecutionSpecElement;
		}
		
		public static XmlElement CreateBehaviorExecutionSpecElementStub(XmlDocument xmiDocument,string id,string name)
		{
			XmlElement behaviorExecutionSpecElement=CreateBehaviorExecutionSpecElementStub(xmiDocument,id);
			behaviorExecutionSpecElement.SetAttribute(UmlModelElements.NAME_ATTR_NAME,name);
			return behaviorExecutionSpecElement;
		}
	}
}
