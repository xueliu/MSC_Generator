/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 09:43
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Xml;
using xmiExport;


namespace xmiImport
{
	/// <summary>
	/// Description of XmiElementInterpreter.
	/// </summary>
	public abstract class XmiElementInterpreter
	{
		public XmiElementInterpreter(XmiDocumentImport documentImport)
		{
			this.documentImport=documentImport;
		}
		
		public XmiDocumentImport DocumentImport{
			get{
				return documentImport;
			}
		}
	}
}
