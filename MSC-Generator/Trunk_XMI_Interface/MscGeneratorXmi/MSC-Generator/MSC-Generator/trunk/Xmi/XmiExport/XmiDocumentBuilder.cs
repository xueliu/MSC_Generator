/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 01.10.2007
 * Zeit: 10:13
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

 

namespace nGenerator
{
	/// <summary>
	/// Description of XmiDocumentBuilder.
	/// </summary>

	
	public class XmiDocumentBuilder
	{	
		
		private const string VERSION ="1.0";
		private const string ENCLOSING="UTF-8";
		private const string STANDALONE="no";
        private const string XML_NAMESPACE_PREFIX="xmlns";
		private const string XML_NAMESPACE_URI="http://www.w3.org/TR/REC-xml-names/";
        
        private const string XMI_NAMESPACE_URI="http://www.omg.org/XMI";
        private const string XMI_NAMESPACE_PREFIX="xmi";
        private const string XMI_VERSION="2.0";
        private const string XMI_VERSION_ATTR_NAME="version";
		private const string XMI_ID_ATTR_NAME="id";        
        private const string UML_NAMESPACE_PREFIX="uml";
        private const string UML_NAMESPACE_URI="http://www.omg.org";
        private XmlNamespaceManager nameSpaceManager;
		
		private const string DOUBLE_POINT=":";
		private string currentXmiElementID="1";
		private int xmiElementCount=1;
        
		public XmiDocumentBuilder()
		{
			
			nameSpaceManager=new XmlNamespaceManager(new NameTable());
			nameSpaceManager.AddNamespace(XMI_NAMESPACE_PREFIX,XMI_NAMESPACE_URI);
			nameSpaceManager.AddNamespace(UML_NAMESPACE_PREFIX,UML_NAMESPACE_URI);
		}
	
		public XmlDocument createXMIDocument()
		{
			XmlDocument xmiDocument= new XmlDocument();
			createXmlDeclaration(xmiDocument);
			createDocumentElement(xmiDocument);
			return xmiDocument;
		}
		
		private void createXmlDeclaration(XmlDocument xmlDocument)
		{
			XmlDeclaration xmlDeclaration=
					xmlDocument.CreateXmlDeclaration(VERSION,ENCLOSING,STANDALONE);
			xmlDocument.AppendChild(xmlDeclaration);	
		}
		
		private void createDocumentElement(XmlDocument xmlDocument)
		{
			XmlElement documentElement=xmlDocument.CreateElement(XMI_NAMESPACE_PREFIX,XmiConstant.XMI,XMI_NAMESPACE_URI);	
			xmlDocument.AppendChild(documentElement);
			
			//XmlAttribute umlNamespaceAttr=  xmlDocument.CreateAttribute("XML_NAMESPACEPREFIX",UML_NAMESPACE_PREFIX,XML_NAMESPACE_URI);
			//umlNamespaceAttr.Value=UML_NAMESPACE_URI;
			//documentElement.Attributes.Append(umlNamespaceAttr);
			
			XmlAttribute xmiVersionAttr=  xmlDocument.CreateAttribute(XMI_NAMESPACE_PREFIX,XMI_VERSION,XMI_NAMESPACE_URI);
			xmiVersionAttr.Value=XMI_VERSION;
			documentElement.Attributes.Append(xmiVersionAttr);
			
		}
		
		public void createModelElement(XmlDocument xmiDocument){
			
			XmlElement modelElement=createXmiElement(SequenceChartConstant.UML_MODEL,xmiDocument);
			XmlElement documentElement=xmiDocument.DocumentElement;
			documentElement.AppendChild(modelElement);    	
		}
		
		public void createInteractionElement(XmlDocument xmiDocument, MSC interaction){
			
			XmlElement interactionElement=createXmiElement(SequenceChartConstant.INTERACTION,xmiDocument);
			String interactionName=interaction.
		}
		
		private XmlElement createXmiElement(String xmiElementName,XmlDocument xmiDocument){
			
			XmlElement newXmiElement=xmiDocument.CreateElement(xmiElementName);
			iterateXmiElementId();
			appendXmiAttribute(xmiDocument,newXmiElement,XMI_ID_ATTR_NAME);
			return newXmiElement;
		}
		
		private void appendXmiAttribute(XmlDocument xmiDocument,
		                                XmlElement enclosingXmlElement){
			
			XmlAttribute idAttribute=xmiDocument.CreateAttribute(XMI_NAMESPACE_PREFIX,
			                                                     ID_ATTRIBUTE_NAME,
			                                                     XMI_NAMESPACE_URI);
			idAttribute.Value=currentXmiElementID;
			enclosingXmlElement.Attributes.Append(idAttribute);
			iterateXmiElementId();  
		}
		
		private void appendAttribute(XmlDocument xmiDocument,
		                             XmlElement enclosingXmlElement,
		                             String attributeName,
		                             String attributeVale){
			
			XmlAttribute newAttribute=xmiDocument.CreateAttribute(XMI_NAMESPACE_PREFIX,
			                                                     attributeName,
			                                                     XMI_NAMESPACE_URI);
			newAttribute.Value=attributeVale;
			enclosingXmlElement.Attributes.Append(newAttribute);
			iterateXmiElementId();  
		}
		                                     
		private void iterateXmiElementId(){
		    xmiElementCount++;   
		    currentXmiElementID=new String(xmiElementCount);                                  	
		}
	}
}
