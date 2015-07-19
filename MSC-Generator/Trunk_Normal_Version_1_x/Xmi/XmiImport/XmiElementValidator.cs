/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 27.11.2007
 * Zeit: 13:20
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmi;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiElementValidor.
	/// </summary>
	public class XmiElementValidator
	{
		private const string DOUBLE_POINT=":";
		
		public static bool IsExpectedLocalName(XmlElement element,string expectedLocalName)
		{
			bool isExpectedLocalName=false;
			string actualLocalName=element.LocalName;
			
			if(expectedLocalName.Equals(actualLocalName))
			{
					isExpectedLocalName=true;	
			}
			
			return isExpectedLocalName;
		}
		
		public static bool IsExpectedElement(XmlElement element,string expectedLocalName,string expectedXmiTypeAttrValue)
		{
			bool isExpectedElement=false;
			bool isExpectedLocalName=IsExpectedLocalName(element,expectedLocalName);
			bool isExpectedXmiTypeAttrValue=IsExpectedXmiTypeAttributeValue(element,expectedXmiTypeAttrValue);
			
			if(isExpectedLocalName&&isExpectedXmiTypeAttrValue)
			{
				isExpectedElement=true;
			}
			
			return isExpectedElement;
		}
		
		public static bool IsExpectedPrefix(XmlElement element,string expectedPrefix)
		{
			bool isExpectedPrefix=false;
			string actualPrefix=element.Prefix;
			
			if(expectedPrefix.Equals(actualPrefix))
			{
				isExpectedPrefix=true;
			}
			
			return isExpectedPrefix;
		}
		
		public static bool IsExpectedQualifiedElementName(XmlElement element,string expectedLocalName,string expectedPrefix)
		{
			bool isExpectedQualifiedElementName=false;
			bool isExpectedLocalName=IsExpectedLocalName(element,expectedLocalName);
			bool isExpectedPrefix=IsExpectedPrefix(element, expectedPrefix);
			
			if(isExpectedLocalName&&isExpectedPrefix)
			{
				isExpectedQualifiedElementName=true;
			}
			return isExpectedQualifiedElementName;
		}
		
		public static bool HasXmiIdAttributeValue(XmlElement element)
		{
			bool hasXmiIdAttribute=HasAttributeValue(element,UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			return hasXmiIdAttribute;
		}
		
		public static bool HasAttributeValue(XmlElement element,string attributeName)
		{
			bool hasAttributeValue=false;
			string attributeValue=element.GetAttribute(attributeName);
			
			if(attributeValue.Length>1)
			{
				hasAttributeValue=true;
			}
			
			return hasAttributeValue;
		}
		
		public static bool IsExpectedXmiTypeAttributeValue(XmlElement element,string expectedType)
		{
			bool isExpectedAttributeValue=false;
			string expectedAttributeValue=UmlModel.UML_NAMESPACE_PREFIX+DOUBLE_POINT+expectedType;
			isExpectedAttributeValue=IsExpectedAttributeValue(element,UmlModel.XMI_TYPE_ATTR_COMPLETE_NAME,expectedAttributeValue);
			return isExpectedAttributeValue;			
		}
		
		public static bool IsExpectedAttributeValue(XmlElement element,string attributeName,string expectedAttrValue)
		{
			bool isExpectedAttrValue=false;
			string actualAttrValue=element.GetAttribute(attributeName);
			
			if(expectedAttrValue.Equals(actualAttrValue))
			{
				isExpectedAttrValue=true;
			}
			return isExpectedAttrValue;			
		}
	}
}
