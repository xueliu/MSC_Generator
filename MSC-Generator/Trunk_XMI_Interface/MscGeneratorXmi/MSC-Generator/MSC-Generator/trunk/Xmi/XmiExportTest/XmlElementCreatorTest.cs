/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 19.10.2007
 * Zeit: 17:16
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using nGenerator;
using mscElements;
using xmlTestFramework;
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	
	
	public abstract class XmlElementCreatorTest
	{
		protected XmlDocument xmiDocument;
		protected XmlDocumentBuilder documentBuilder;
		protected XmlNamespaceManager namespaceManager;
		protected Generator mscGenerator;
		protected MSC sequenceDiagram;
		
		public virtual void Init()
		{
			xmiDocument=new XmlDocument();
			mscGenerator=new Generator(null);
			documentBuilder=new XmlDocumentBuilder();
			namespaceManager=new XmlNamespaceManager(xmiDocument.NameTable);
			namespaceManager.AddNamespace(XmiElements.UML_NAMESPACE_PREFIX,XmiElements.UML_NAMESPACE_URI);
			namespaceManager.AddNamespace(XmiElements.XMI_NAMESPACE_PREFIX,XmiElements.XMI_NAMESPACE_URI);
			sequenceDiagram=new MSC();
		}
	}
}
