/*
 * Erstellt mit SharpDevelop.
 * Benutzer: L G
 * Datum: 16.10.2007
 * Zeit: 14:34
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiExport
{
	/// <summary>
	/// Description of class ModelElementStub
	/// </summary>
	
	
	
	public class ModelElementStub
	{	
    	public static XmlElement CreateModelElementStub(XmlDocument xmiDocument)
		{
			XmlElement modelElement=xmiDocument.CreateElement(XmiElements.UML_NAMESPACE_PREFIX,UmlModelElements.UML_MODEL,XmiElements.UML_NAMESPACE_URI);
			return modelElement;
		}
	}
}
