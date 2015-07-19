/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.01.2008
 * Zeit: 14:27
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Xml;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiDocumentRootElementInterpreter.
	/// </summary>
	public abstract class XmiDocumentRootElementInterpreter
	{
		public abstract XmlElement InterpretModelElement(XmlDocument xmiDocument);
		
		public abstract XmlElement InterpretXmiElement(XmlDocument xmiDocument,XmlElement correspondingModelElement);
	}
}
