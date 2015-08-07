/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 16.10.2007
 * Zeit: 15:28
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using NUnit.Framework;



namespace xmlTestFramework
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class AssertXML
	{
		
		protected const string  ATTRIBUTE_SELECTION_QUERY_START="//@";
		
		public static void AssertChildElementsCount(XmlElement parentElement,
		                                            int expectedChildNodesCount)
		{
			XPathNavigator parentElementNavigator=parentElement.CreateNavigator();
			XPathNodeIterator childNodesSet=parentElementNavigator.SelectChildren(XPathNodeType.All) ;
			int childNodesCount=childNodesSet.Count;
			Assert.IsTrue(expectedChildNodesCount==childNodesCount);	
		}
		
		public static void AssertOwnedAttributesCount(XmlElement ownerElement,int expectedAttributeCount)
		{
			XmlAttributeCollection ownedAttributes=ownerElement.Attributes;
			int ownerAttributesCount=ownedAttributes.Count;
			Assert.IsTrue(expectedAttributeCount==ownerAttributesCount);
		}
		
		public static void AssertNamespacePrefixOfElement(XmlElement relevantElement,string expectedNamespacePrefix)
		{
			string namespacePrefixRelevantElement=relevantElement.Prefix;
			Assert.AreEqual(expectedNamespacePrefix,namespacePrefixRelevantElement);
		}
		
		public static void AssertTypeNameOfElement(XmlElement relevantElement,string expectedElementTypeName)
		{
			string typeNameRelevantElement=relevantElement.LocalName;
			Assert.AreEqual(expectedElementTypeName,typeNameRelevantElement);
		}
		
		public static void AssertIsChildElementOf(XmlElement parentElement,XmlElement expectedChildElement,string queryChildElementPath,XmlNamespaceManager namespaceManager)
		{
			XPathNavigator parentElementNavigator=parentElement.CreateNavigator();
			XPathNavigator foundChildElementNavigator=parentElementNavigator.SelectSingleNode(queryChildElementPath,namespaceManager);
			Assert.IsNotNull(foundChildElementNavigator);
			XmlElement foundChildElement=(XmlElement)foundChildElementNavigator.UnderlyingObject;
			Assert.AreSame(expectedChildElement,foundChildElement);
		}
		
		public static void AssertIsXmiAttributeOf(XmlElement ownerElement, string localAttributeName,string namespaceURI)
		{
			XPathNavigator ownerElementNavigator=ownerElement.CreateNavigator();
			bool foundAttribute=ownerElementNavigator.MoveToAttribute(localAttributeName,namespaceURI);
			Assert.IsTrue(foundAttribute);
		}
		
		public static void AssertIsCorrectXmiAttributeValue(XmlElement ownerElement,string localAttributeName,string namespaceURI,string expectedAttributeValue)
		{
			XPathNavigator ownerElementNavigator=ownerElement.CreateNavigator();
			string foundAttributeValue=ownerElementNavigator.GetAttribute(localAttributeName,namespaceURI);
			Assert.AreEqual(expectedAttributeValue,foundAttributeValue);
		}
		
		public static void AssertIsUmlAttributeOf(XmlElement relevantElement,string localAttributeName,XmlNamespaceManager namespaceManager)
		{
			XPathNavigator relevantElementNavigator=relevantElement.CreateNavigator();
			string query=ATTRIBUTE_SELECTION_QUERY_START+localAttributeName;
			XPathNavigator foundAttributeNavigator=relevantElementNavigator.SelectSingleNode(query,namespaceManager);
			Assert.IsNotNull(foundAttributeNavigator);
			XmlAttribute foundAttribute=(XmlAttribute)foundAttributeNavigator.UnderlyingObject;
			Assert.IsNotNull(foundAttribute);
		}
		
		public static void AssertValueOfUmlAttribute(XmlElement relevantElement, string localAttributeName,XmlNamespaceManager namespaceManager,string expectedAttributeValue )
		{
			XPathNavigator relevantElementNavigator=relevantElement.CreateNavigator();
			string query=ATTRIBUTE_SELECTION_QUERY_START+localAttributeName;
			XPathNavigator foundAttributeNavigator=relevantElementNavigator.SelectSingleNode(query,namespaceManager);
			Assert.IsNotNull(foundAttributeNavigator);
			XmlAttribute foundAttribute=(XmlAttribute)foundAttributeNavigator.UnderlyingObject;
			Assert.IsNotNull(foundAttribute);
			string foundAttributeValue=foundAttribute.Value;
			Assert.AreEqual(expectedAttributeValue,foundAttributeValue);
		}	
	}
}
