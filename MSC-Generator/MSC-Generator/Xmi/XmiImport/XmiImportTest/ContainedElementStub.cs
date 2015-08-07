/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 30.11.2007
 * Zeit: 17:58
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiImport
{
	/// <summary>
	/// Description of ContainedElementStub.
	/// </summary>
	public class ContainedElementStub
	{
		private const string CONTAINED_ELEMENT_TYPE="contained"; 
		
		public static XmlElement CreateContainedElementStub(XmlDocument document)
		{
			XmlElement containedElement=document.CreateElement(CONTAINED_ELEMENT_TYPE);
			return containedElement;
			
		}
	}
}
