/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 10:08
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using nGenerator;

namespace xmiExport
{
	/// <summary>
	/// Description of LifelineElementCreator.
	/// </summary>
	public class LifelineElementCreator:XmlElementCreator
	{
		private const string LIFELINE_ELEMENT_TYPE_NAME="lifeline";
		
		public LifelineElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateLifelineElement(XmlElement parentElement,Process lifelineItem)
		{
			XmlElement lifelineElement=CreateReferenceAsElement(parentElement,LIFELINE_ELEMENT_TYPE_NAME,UmlModel.LIFELINE);
			AddLifelineNameAttribute(lifelineElement,lifelineItem);
			return lifelineElement;
		}
		
		private void AddLifelineNameAttribute(XmlElement lifelineElement,Process lifelineItem)
		{
			string lifelineName=lifelineItem.ProcessName;
			
			if(lifelineName!=null)
			{
				this.AddNameAttribute(lifelineElement,lifelineName);
			}
		}
	}
}
