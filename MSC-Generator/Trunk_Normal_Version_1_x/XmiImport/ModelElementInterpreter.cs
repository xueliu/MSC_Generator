/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 13:35
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
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
