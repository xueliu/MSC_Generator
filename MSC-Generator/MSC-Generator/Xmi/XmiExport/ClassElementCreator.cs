/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 20.11.2007
 * Zeit: 17:49
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
	/// Description of ClassElementCreator.
	/// </summary>
	public class ClassElementCreator:XmlElementCreator
	{
		private const string CLASS_ELEMENT_TYPE_NAME="packagedElement";
		
		public ClassElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		
		public XmlElement CreateClassElement(XmlElement modelElement,string className)
		{
			XmlElement createdClassElement=this.CreateUmlAttributeAsElement(modelElement,CLASS_ELEMENT_TYPE_NAME,UmlModel.CLASS);
			AddClassNameAttribute(createdClassElement,className);
			return createdClassElement;
		}
		
		private void AddClassNameAttribute(XmlElement classElement,string className)
		{
			this.AddNameAttribute(classElement,className);
		}
	}
}
