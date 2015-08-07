/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.11.2007
 * Zeit: 15:36
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmiExport;
using xmi;

namespace xmiExportPapyrus
{
	/// <summary>
	/// Description of PapyrusModelElementCreator.
	/// </summary>
	public class PapyrusModelElementCreator:XmlElementCreator
	{
		
		private const string PACKAGE_IMPORT_ELEMENT_TYPE="packageImport";
		private const string IMPORTED_PACKAGES_ELEMENT_TYPE="importedPackage";
		private const string HREF_ATTR_NAME="href";
		
		public PapyrusModelElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									  		base(xmiDocument,xmiDocumentBuilder){}
	
	
	
		public XmlElement CreatePapyrusModelElement(string modelName)
		{
			XmlElement createdModelElement=this.XmiDocument.CreateElement(UmlModel.UML_NAMESPACE_PREFIX,UmlModel.UML_MODEL,PapyrusNamespaces.UML_NAMESPACE_URI);
			this.XmiDocument.AppendChild(createdModelElement);
			this.AddXmiIdAttribute(createdModelElement);
			this.AddNameAttribute(createdModelElement,modelName);
			this.AddXmiAttribute(createdModelElement,UmlModel.XMI_VERSION_ATTR_NAME,UmlModel.XMI_VERSION);
			XmlElement packageImportElement=CreateUmlAttributeAsElement(createdModelElement,PACKAGE_IMPORT_ELEMENT_TYPE);
			AddImportedPackageElement(packageImportElement);
			return createdModelElement;
		}
		
		private void AddImportedPackageElement(XmlElement packageImportElement)
		{
			XmlElement importedPackageElement=this.XmiDocument.CreateElement(IMPORTED_PACKAGES_ELEMENT_TYPE);
			packageImportElement.AppendChild(importedPackageElement);
			this.AddXmiTypeAttribute(importedPackageElement,UmlModel.UML_MODEL);
			this.AddAttribute(importedPackageElement,HREF_ATTR_NAME,PapyrusNamespaces.PATHMATH_NAMESPACE_URI);	
		}	
	}
}
