/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.01.2008
 * Zeit: 18:40
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
	public class PapyrusXmiModelNamespaceManager:XmlNamespaceManager
	{
		public const string UML_NAMESPACE_PREFIX="uml";
        public const string UML_NAMESPACE_URI="http://www.eclipse.org/uml2/2.1.0/UML";
        public const string XMI_NAMESPACE_PREFIX="xmi";
        public const string XMI_NAMESPACE_URI="http://schema.omg.org/spec/XMI/2.1";
        public const string ECORE_NAMESPACE_PREFIX="ecore";
        public const string ECORE_NAMESPACE_URI="http://www.eclipse.org/emf/2002/Ecore";
		
		public PapyrusXmiModelNamespaceManager(System.Xml.XmlNameTable nameTable):base(nameTable)
		{
			this.AddNamespace(UML_NAMESPACE_PREFIX,UML_NAMESPACE_URI);
			this.AddNamespace(XMI_NAMESPACE_PREFIX,XMI_NAMESPACE_URI);
			this.AddNamespace(ECORE_NAMESPACE_PREFIX,ECORE_NAMESPACE_URI);
		}
	}
}
