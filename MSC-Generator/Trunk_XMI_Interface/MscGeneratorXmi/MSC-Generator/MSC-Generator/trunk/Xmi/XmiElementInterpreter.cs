/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.01.2008
 * Zeit: 20:01
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmi
{
	/// <summary>
	/// Description of XmiElementInterpreter.
	/// </summary>
	public abstract class XmiElementInterpreter
	{
		protected XmlNamespaceManager namespaceManager;		
	
		public abstract void InitNamespaceManager(XmlNameTable nameTable);
	}
}
