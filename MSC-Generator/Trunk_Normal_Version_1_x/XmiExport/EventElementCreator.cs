/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 26.11.2007
 * Zeit: 11:43
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;

namespace xmiExport
{
	/// <summary>
	/// Description of EventElementCreator.
	/// </summary>
	public class EventElementCreator:XmlElementCreator
	{
		private const string EVENT_ELEMENT_TYPE_NAME="packagedElement";
		
		public EventElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateMessageEventElement(XmlElement modelElement,string eventName,string messageSort, EventKind eventKind)
		{
			string umlModelType=GetEventElementUmlType(messageSort, eventKind);
			XmlElement createdMessageEventElement=CreateUmlAttributeAsElement(modelElement,EVENT_ELEMENT_TYPE_NAME,umlModelType);
			AddEventNameAttribute(createdMessageEventElement,eventName);
			return createdMessageEventElement;
		}
		
		public XmlElement CreateExecutionEventElement(XmlElement modelElement,string eventName)
		{
			XmlElement createdExecutionEventElement=CreateUmlAttributeAsElement(modelElement,EVENT_ELEMENT_TYPE_NAME,UmlModel.EXECUTION_EVENT);
			AddEventNameAttribute(createdExecutionEventElement,eventName);
			return createdExecutionEventElement;	
		}
		
		private string GetEventElementUmlType(string messageSort, EventKind eventKind)
		{
			string eventElementUmlType=null;
			
			if((messageSort.Equals(UmlModel.ASYNCH_CALL))||(messageSort.Equals(UmlModel.SYNCH_CALL)))
			{
				eventElementUmlType=GetOperationEventType(eventKind);
			}
			else if(messageSort.Equals(UmlModel.ASYNCH_SIGNAL))
			{
				eventElementUmlType=GetSignalEventType(eventKind);
			}
			
			return eventElementUmlType;
		}
		
		private string GetOperationEventType(EventKind eventKind)
		{
			string operationEventType=null; 
				
			if(eventKind.Equals(EventKind.ReceiveEvent))
			{
				operationEventType=UmlModel.RECEIVE_OPERATION_EVENT;
			}
			else if(eventKind.Equals(EventKind.SendEvent))
			{
				operationEventType=UmlModel.SEND_OPERATION_EVENT;
			}
			return operationEventType;
		}
		
		private string GetSignalEventType(EventKind eventKind)
		{
			string signalEventType=null; 
				
			if(eventKind.Equals(EventKind.ReceiveEvent))
			{
				signalEventType=UmlModel.RECEIVE_SIGNAL_EVENT;
			}
			else if(eventKind.Equals(EventKind.SendEvent))
			{
				signalEventType=UmlModel.SEND_SIGNAL_EVENT;
			}
			return signalEventType;
		}
		
		private void AddEventNameAttribute(XmlElement createdExecutionElement,string eventName)
		{
			if(eventName!=null)
			{
				this.AddNameAttribute(createdExecutionElement,eventName);
			}
		}
	}
}
