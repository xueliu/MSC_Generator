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
	public class BehaviorExecutionSpecificationElementCreator:XmlElementCreator
	{
		private string BEHAVIOR_SPECIFICATION_ELEMENT_TYPE_NAME="fragment";
		
		public BehaviorExecutionSpecificationElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
													base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateBehaviorExcecutionSpecificationElement(XmlElement parentElement,ProcessRegion executionItem,XmlElement lifelineElement)
		{
			XmlElement executionSpecificationElement=this.CreateUmlAttributeAsElement(parentElement,BEHAVIOR_SPECIFICATION_ELEMENT_TYPE_NAME,UmlModel.BEHAVIOR_EXECUTION_SPECIFICATION);
			AddExecutionSpecificationNameAttribute(executionSpecificationElement,executionItem);
			AddOccurrenceSpecificationStartAttribute(parentElement,executionSpecificationElement,lifelineElement);
			AddOccurrenceSpecificationFinishAttribute(parentElement,executionSpecificationElement,lifelineElement);
			AddCoveredByAttrToLifelineElement(lifelineElement,executionSpecificationElement);
			AddCoveredAttribute(executionSpecificationElement,lifelineElement);
			return executionSpecificationElement;
		}
		
		private void AddExecutionSpecificationNameAttribute(XmlElement executionSpecificationElement,ProcessRegion executionItem)
		{
			string executionSpecificationName=executionItem.Name;
			
			if(executionSpecificationName!=null)
			{
				AddAttribute(executionSpecificationElement,UmlModel.NAME_ATTR_NAME,executionSpecificationName);
			}
		}
				
		private void AddOccurrenceSpecificationStartAttribute(XmlElement parentElement,XmlElement executionSpecificationElement, XmlElement lifelineElement)
		{
			string executionItemID=executionSpecificationElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string occurrenceSpecificationFinishID=CreateExecutionOccurrenceSpecElement(parentElement,executionItemID,lifelineElement);
			AddAttribute(executionSpecificationElement,UmlModel.START_ATTR_NAME,occurrenceSpecificationFinishID);
		}
		
		private void AddOccurrenceSpecificationFinishAttribute(XmlElement parentElement,XmlElement executionSpecificationElement,XmlElement lifelineElement)
		{
			string executionSpecificationID=executionSpecificationElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string occurrenceSpecificationFinishID=CreateExecutionOccurrenceSpecElement(parentElement,executionSpecificationID,lifelineElement);
			AddAttribute(executionSpecificationElement,UmlModel.FINISH_ATTR_NAME,occurrenceSpecificationFinishID);
		}
		
		private string CreateExecutionOccurrenceSpecElement(XmlElement parentElement,string executionSpecificationID,XmlElement lifelineElement)
		{
			string executionOccurrenceSpecID=null;
			ExecutionOccurrenceSpecElementCreator elementCreator=
				new ExecutionOccurrenceSpecElementCreator(this.XmiDocument,this.XmiDocumentBuilder);
			XmlElement executionOccurrenceSpecElement=
				elementCreator.CreateExecutionOccurrenceSpecElement(parentElement,executionSpecificationID,lifelineElement);
			executionOccurrenceSpecID=executionOccurrenceSpecElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			return executionOccurrenceSpecID;
		}
		
		private void AddCoveredByAttrToLifelineElement(XmlElement lifelineElement,XmlElement behaviorExecutionElement)
		{
			string behaviorExecutionElementId=behaviorExecutionElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			behaviorExecutionElementId.Trim();
			string coveredByAttrValue=lifelineElement.GetAttribute(UmlModel.COVERED_BY_ATTR_NAME);
			
			if(coveredByAttrValue.Length==0)
			{
				this.AddAttribute(lifelineElement,UmlModel.COVERED_BY_ATTR_NAME,behaviorExecutionElementId);
			}
			else
			{
				coveredByAttrValue=coveredByAttrValue+SPACE_STRING+behaviorExecutionElementId;
				lifelineElement.SetAttribute(UmlModel.COVERED_BY_ATTR_NAME,coveredByAttrValue);
			}
		}
		
		private void AddCoveredAttribute(XmlElement behaviorExecutionElement,XmlElement lifelineElement)
		{
			string lifelineElementId=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			lifelineElementId.Trim();
			string coveredAttrValue=lifelineElement.GetAttribute(UmlModel.COVERED_ATTR_NAME);
			
			if(coveredAttrValue.Length==0)
			{
				this.AddAttribute(behaviorExecutionElement,UmlModel.COVERED_ATTR_NAME,lifelineElementId);
			}
			else
			{
				coveredAttrValue=coveredAttrValue+SPACE_STRING+lifelineElementId;
				behaviorExecutionElement.SetAttribute(UmlModel.COVERED_ATTR_NAME,coveredAttrValue);
			}
		}
	}
}
