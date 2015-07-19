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

 

namespace MscXmiExport
{
	/// <summary>
	/// Description of XmiDocumentBuilder.
	/// </summary>

	
	public class XmiDocumentBuilder
	{	
		
		private const string VERSION ="1.0";
		private const string ENCLOSING="UTF-8";
		private const string STANDALONE="no";
        private const string NAMESPACE_PREFIX="xmlns:";
        private const string NAMESPACE_NAME="xmi";
        private const string NAMESPACE_URI="http://www.omg.org/XMI";
        private const string XMI_VERSION_PREFIX="xmi:version";
        private const string XMI_VERSION="2.0";
        private XmlNamespaceManager nameSpaceManager;
		
		
		public XmiDocumentBuilder()
		{
			//XmlNameTable nametable=new XmlNameTable();
			nameSpaceManager=new XmlNamespaceManager(new NameTable());
				nameSpaceManager.AddNamespace(NAMESPACE_NAME,NAMESPACE_URI);
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
			XmlElement documentElement=xmlDocument.CreateElement(NAMESPACE_NAME,XmiConstant.XMI,NAMESPACE_URI);
			//documentElement.Prefix=null;
		
			//documentElement.SetAttribute(XMI_VERSION_PREFIX,XMI_VERSION);
			//documentElement.SetAttribute(NAMESPACE_PREFIX+,);
			//documentElement.Prefix=NAMESPACE_NAME;
			xmlDocument.AppendChild(documentElement);
		}
		
		public void createModelElement(XmlDocument xmlDocument){
			
			
			//dummy
			XmlElement modelElement=xmlDocument.CreateElement("Modl");
			modelElement.Prefix=nameSpaceManager.LookupPrefix(NAMESPACE_URI);
			
			XmlElement rootElement=xmlDocument.DocumentElement;
			rootElement.AppendChild(modelElement);
//			return modelElement;
		}
	}
}
