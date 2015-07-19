/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 13:35
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmiImport;
using nGenerator;
using mscElements;


namespace xmiImport
{
	/// <summary>
	/// Description of ModelElementInterpreter.
	/// </summary>
	public abstract class ModelElementInterpreter
	{
		public abstract XmlElement InterpretModelElement(XmlDocument xmiDocument);
	}
}
