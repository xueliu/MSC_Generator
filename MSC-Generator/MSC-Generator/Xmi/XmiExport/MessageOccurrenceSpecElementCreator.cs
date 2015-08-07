/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.10.2007
 * Zeit: 14:45
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
	/// Description of MessageOccurenceSpecification.
	/// </summary>
	
	public enum EventKind
	{
		ReceiveEvent,
		SendEvent
	}
	
	
	public class MessageOccurrenceSpecElementCreator:XmlElementCreator
	{
		private const string MESSAGE_OCCURRENCE_SPECIFICATION_ELEMENT_TYPE_NAME="fragment";
		private const string COVERED_ATTRIBUT_ELEMENT_TYPE_NAME="covered";
		private const string COVERED_BY_ELEMENT_TYPE_NAME="coveredBy";
		private string messageSort;
		private EventKind eventKind;
			
		public MessageOccurrenceSpecElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder,string messageSort,EventKind eventKind):
			base(xmiDocument,xmiDocumentBuilder)
		{
			this.messageSort=messageSort;
			this.eventKind=eventKind;
		}
		
		public MessageOccurrenceSpecElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
			base(xmiDocument,xmiDocumentBuilder){}
		
		public String MessageSort{
			
			get{
				return this.messageSort;
			}
			set{
				this.messageSort=value;
			}
		}
		
		public EventKind EventKind{
			
			get{
				return this.eventKind;
			}
			set{
				this.eventKind=value;
			}
		}
		
		public XmlElement CreateMessageOccurrenceSpecificationElement(XmlElement parentElement, XmlElement lifelineElement,string messageID)
		{
			XmlElement messageOccurrenceSpecificationElement=this.CreateUmlAttributeAsElement(parentElement,MESSAGE_OCCURRENCE_SPECIFICATION_ELEMENT_TYPE_NAME,UmlModel.MESSAGE_OCCURRENCE_SPECIFICATION);
			AddMessageAttribute(messageOccurrenceSpecificationElement,messageID);
			AddCoveredAttribute(messageOccurrenceSpecificationElement,lifelineElement);
			AddCoveredByAttrToLifelineElement(lifelineElement,messageOccurrenceSpecificationElement);
			AddEventAttribute(parentElement,messageOccurrenceSpecificationElement);
			return messageOccurrenceSpecificationElement;
		}	
		
		private void AddMessageAttribute(XmlElement messageOccurrenceSpecificationElement,string messageID)
		{
			if(messageID !=null)
			{
				AddAttribute(messageOccurrenceSpecificationElement,UmlModel.MESSAGE_ATTR_NAME,messageID);
			}
		}
		
		private void AddCoveredAttribute(XmlElement messageOccurrenceSpecificationElement,XmlElement lifelineElement)
		{
			string lifelineID=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			AddAttribute(messageOccurrenceSpecificationElement,UmlModel.COVERED_ATTR_NAME,lifelineID);
		}
		
		private void AddCoveredByAttrToLifelineElement(XmlElement lifelineElement,XmlElement messageOccurrenceSpecElement)
		{
			string messageOccurrenceSpecElementId=messageOccurrenceSpecElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			messageOccurrenceSpecElementId.Trim();
			string coveredByAttrValue=lifelineElement.GetAttribute(UmlModel.COVERED_BY_ATTR_NAME);
			
			if(coveredByAttrValue.Length==0)
			{
				this.AddAttribute(lifelineElement,UmlModel.COVERED_BY_ATTR_NAME,messageOccurrenceSpecElementId);
			}
			else
			{
				coveredByAttrValue=coveredByAttrValue+SPACE_STRING+messageOccurrenceSpecElementId;
				lifelineElement.SetAttribute(UmlModel.COVERED_BY_ATTR_NAME,coveredByAttrValue);
			}
		}
		
		private void AddEventAttribute(XmlElement parentElement,XmlElement messageOccurrenceSpecElement)
		{
			XmlElement modelElement=(XmlElement)parentElement.ParentNode;
			EventElementCreator eventElementCreator=new EventElementCreator(this.XmiDocument,this.XmiDocumentBuilder);
			XmlElement eventElement=null;
			eventElement=eventElementCreator.CreateMessageEventElement(modelElement,null,messageSort,eventKind);	
			string eventElementId=eventElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			this.AddAttribute(messageOccurrenceSpecElement,UmlModel.EVENT_ATTR_NAME,eventElementId);
		}
	}		
}
