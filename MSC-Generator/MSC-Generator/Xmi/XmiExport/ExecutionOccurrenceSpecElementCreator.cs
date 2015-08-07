/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 25.10.2007
 * Zeit: 17:51
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
	/// Description of ExecutionOccurrenceSpecElementCreator.
	/// </summary>
	public class ExecutionOccurrenceSpecElementCreator:XmlElementCreator
	{
		private const string EXECUTION_OCCURRENCE_SPECIFICATION_ELEMENT_TYPE_NAME="fragment";
		private const string COVERED_BY_ELEMENT_TYPE_NAME="coveredBy";
				
		public ExecutionOccurrenceSpecElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 	  			 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateExecutionOccurrenceSpecElement(XmlElement parentElement,string executionSpecificationID, XmlElement lifelineElement)
		{
			XmlElement executionOccurrenceSpecElement=this.CreateUmlAttributeAsElement(parentElement,EXECUTION_OCCURRENCE_SPECIFICATION_ELEMENT_TYPE_NAME,UmlModel.EXECUTION_OCCURRENCE_SPECIFICATION);
			string lifelineID=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			AddExecutionAttribute(executionOccurrenceSpecElement,executionSpecificationID);
			AddCoveredAttribute(executionOccurrenceSpecElement,lifelineID);
			AddCoveredByAttrToLifelineElement(lifelineElement,executionOccurrenceSpecElement);
			AddEventAttribute(parentElement,executionOccurrenceSpecElement);
	
			return executionOccurrenceSpecElement;
		}
		
		private void AddExecutionAttribute(XmlElement ownerElement, string executionSpecificationID)
		{
			this.AddAttribute(ownerElement,UmlModel.EXECUTION_ATTR_NAME,executionSpecificationID);
		}
		
		private void AddCoveredAttribute(XmlElement executionOccurrenceSpecElement,string lifelineID)
		{
			this.AddAttribute(executionOccurrenceSpecElement,UmlModel.COVERED_ATTR_NAME,lifelineID);
		}
		
		private void AddCoveredByAttrToLifelineElement(XmlElement lifelineElement,XmlElement executionOccurrenceSpecElement)
		{
			string executionOccurrenceSpecElementId=executionOccurrenceSpecElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			executionOccurrenceSpecElementId.Trim();
			string coveredByAttrValue=lifelineElement.GetAttribute(UmlModel.COVERED_BY_ATTR_NAME);
			
			if(coveredByAttrValue.Length==0)
			{
				this.AddAttribute(lifelineElement,UmlModel.COVERED_BY_ATTR_NAME,executionOccurrenceSpecElementId);
			}
			else
			{
				coveredByAttrValue=coveredByAttrValue+SPACE_STRING+executionOccurrenceSpecElementId;
				lifelineElement.SetAttribute(UmlModel.COVERED_BY_ATTR_NAME,coveredByAttrValue);
			}
		}
		
		private void AddEventAttribute(XmlElement parentElement,XmlElement exectionOccurrenceSpecElement)
		{
			XmlElement modelElement=(XmlElement)parentElement.ParentNode;
			EventElementCreator eventElementCreator=new EventElementCreator(this.XmiDocument,this.XmiDocumentBuilder);
			XmlElement eventElement=eventElementCreator.CreateExecutionEventElement(modelElement,null);
			string eventElementId=eventElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			this.AddAttribute(exectionOccurrenceSpecElement,UmlModel.EVENT_ATTR_NAME,eventElementId);
		}
	}
}
