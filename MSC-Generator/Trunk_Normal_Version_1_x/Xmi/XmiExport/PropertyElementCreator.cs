/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 19.11.2007
 * Zeit: 17:09
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using nGenerator;
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of PropertyElementCreator.
	/// </summary>
	public class PropertyElementCreator:XmlElementCreator
	{
		private const string PROPERTY_ELEMENT_TYPE_NAME="ownedAttribute";
		
		public PropertyElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreatePropertyElement(XmlElement parentElement,string lifelineObjectName,XmlElement classElement)
		{
			XmlElement propertyElement=
				CreateUmlAttributeAsElement(parentElement,PROPERTY_ELEMENT_TYPE_NAME,UmlModel.PROPERTY);
			AddPropertyNameAttribute(propertyElement,lifelineObjectName);
			AddPropertyTypeAttribute(propertyElement,classElement);
			return propertyElement;
		}
		
		private void AddPropertyNameAttribute(XmlElement propertyElement,string lifelineObjectName)
		{
			if(lifelineObjectName!=null)
			{
				this.AddNameAttribute(propertyElement,lifelineObjectName);
			}
		}
		
		private void AddPropertyTypeAttribute(XmlElement propertyElement,XmlElement classElement)
		{
			if(classElement!=null)
			{
				string classElementId=classElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
				this.AddAttribute(propertyElement,UmlModel.TYPE_ATTR_NAME,classElementId);
			}
		}
	}
}
