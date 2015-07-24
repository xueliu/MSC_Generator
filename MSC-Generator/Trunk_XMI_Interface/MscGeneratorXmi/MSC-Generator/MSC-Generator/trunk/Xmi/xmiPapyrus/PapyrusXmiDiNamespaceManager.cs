/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.01.2008
 * Zeit: 18:29
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;

namespace xmiPapyrus
{
	/// <summary>
	/// Description of PapyrusXmiModelNamespaceManager.
	/// </summary>
	public sealed class PapyrusXmiDiNamespaceManager:System.Xml.XmlNamespaceManager
	{
		private const string PAPYRUS_DI_NAMESPACE_PREFIX="di2";
		private const string PAPYRUS_DI_NAMESPACE_URI="http://www.papyrusuml.org";
		private const string XMI_NAMESPACE_PREFIX="xmi";
		private const string XMI_NAMESPACE_URI="http://www.omg.org/XMI";
		private const string XSI_NAMESPACE_PREFIX="xsi";
		private const string XSI_NAMESPACE_URI="http://www.w3.org/2001/XMLSchema-instance";
		private const string UML_NAMESPACE_PREFIX="uml";
		private const string UML_NAMESPACE_URI="http://www.eclipse.org/uml2/2.1.0/UML";
		
		public PapyrusXmiDiNamespaceManager(System.Xml.XmlNameTable nameTable):base(nameTable)
		{
			this.AddNamespace(PAPYRUS_DI_NAMESPACE_PREFIX,PAPYRUS_DI_NAMESPACE_URI);
			this.AddNamespace(XMI_NAMESPACE_PREFIX,XMI_NAMESPACE_URI);
			this.AddNamespace(XSI_NAMESPACE_PREFIX,XSI_NAMESPACE_URI);
			this.AddNamespace(UML_NAMESPACE_PREFIX,UML_NAMESPACE_URI);
		}
	}
}
