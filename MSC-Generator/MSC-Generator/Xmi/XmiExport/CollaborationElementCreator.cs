/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 16:36
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of ColaborationElementCreator.
	/// </summary>
	public class CollaborationElementCreator:XmlElementCreator
	{
		private string COLLABORATION_ELEMENT_TYPE_NAME="packagedElement";
		
		public CollaborationElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 	  base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateCollaborationElement(XmlElement parentElement, string collaborationName)
		{
			XmlElement collaborationElement=this.CreateUmlAttributeAsElement(parentElement,COLLABORATION_ELEMENT_TYPE_NAME,UmlModel.COLLABORATION);
			AddCollaborationNameAttribute(collaborationElement,collaborationName);
			return collaborationElement;
		}
		
		private void AddCollaborationNameAttribute(XmlElement collaborationElement,string collaborationName)
		{
			if(collaborationName!=null)
			{
				this.AddNameAttribute(collaborationElement,collaborationName);
			}
		}
	}
}
