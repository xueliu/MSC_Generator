/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 25.10.2007
 * Zeit: 15:51
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
	/// Description of ExecutionSpecificationElementCreator.
	/// </summary>
	public class ExecutionSpecificationElementCreator:XmlElementCreator
	{
		private string EXECUTION_SPECIFICATION_ELEMENT_TYPE_NAME="fragment";
		
		public ExecutionSpecificationElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
													base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateExecutionSpecificationElement(XmlElement parentElement,Task executionItem,string lifelineID)
		{
			XmlElement executionSpecificationElement=this.CreateReferenceAsElement(parentElement,EXECUTION_SPECIFICATION_ELEMENT_TYPE_NAME,UmlModel.EXECUTION_SPECIFICATION);
			AddExecutionSpecificationNameAttribute(executionSpecificationElement,executionItem);
			AddOccurrenceSpecificationStartAttribute(parentElement,executionSpecificationElement,lifelineID);
			AddOccurrenceSpecificationFinishAttribute(parentElement,executionSpecificationElement,lifelineID);
			return executionSpecificationElement;
		}
		
		private void AddExecutionSpecificationNameAttribute(XmlElement executionSpecificationElement,Task executionItem)
		{
			string executionSpecificationName=executionItem.Name;
			
			if(executionSpecificationName!=null)
			{
				AddAttribute(executionSpecificationElement,UmlModel.NAME_ATTR_NAME,executionSpecificationName);
			}
		}
				
		private void AddOccurrenceSpecificationStartAttribute(XmlElement parentElement,XmlElement executionSpecificationElement, string lifelineID)
		{
			string executionItemID=executionSpecificationElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string occurrenceSpecificationFinishID=CreateExecutionOccurrenceSpecElement(parentElement,executionItemID,lifelineID);
			AddAttribute(executionSpecificationElement,UmlModel.START_ATTR_NAME,occurrenceSpecificationFinishID);
		}
		
		private void AddOccurrenceSpecificationFinishAttribute(XmlElement parentElement,XmlElement executionSpecificationElement,string lifelineID)
		{
			string executionSpecificationID=executionSpecificationElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string occurrenceSpecificationFinishID=CreateExecutionOccurrenceSpecElement(parentElement,executionSpecificationID,lifelineID);
			AddAttribute(executionSpecificationElement,UmlModel.FINISH_ATTR_NAME,occurrenceSpecificationFinishID);
		}
		
		private string CreateExecutionOccurrenceSpecElement(XmlElement parentElement,string executionSpecificationID,string lifelineID)
		{
			string executionOccurrenceSpecID=null;
			ExecutionOccurrenceSpecElementCreator elementCreator=
				new ExecutionOccurrenceSpecElementCreator(this.XmiDocument,this.XmiDocumentBuilder);
			XmlElement executionOccurrenceSpecElement=
				elementCreator.CreateExecutionOccurrenceSpecElement(parentElement,executionSpecificationID,lifelineID);
			executionOccurrenceSpecID=executionOccurrenceSpecElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			return executionOccurrenceSpecID;
		}
		
	}
}
