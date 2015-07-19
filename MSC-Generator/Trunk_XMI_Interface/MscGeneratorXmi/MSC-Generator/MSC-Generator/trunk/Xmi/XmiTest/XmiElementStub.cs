/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 19.10.2007
 * Zeit: 15:53
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class XmiElementStub
	{
		
		public static XmlElement CreateXmiElement(XmlDocument xmiDocument)
		{
			XmlElement newXmiElement=xmiDocument.CreateElement(XmiElements.XMI_NAMESPACE_PREFIX,"XMI",XmiElements.XMI_NAMESPACE_URI);
			return newXmiElement;
		}
	}
}
