/*

Copyright (C) 2005-2007 by Itesys Institut fuer Technische Systeme GmbH
http://www.itesys-gmbh.de   
mailto:software@itesys.de

This file is part of sdgen. Project home:
http://www.itesys-gmbh.de/home/produkte/msc_generator.html

sdgen is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

sdgen is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with sdgen; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

*/
/*
 * Erstellt mit SharpDevelop.
 * Benutzer: LG
 * Datum: 15.10.2007
 * Zeit: 12:31
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;

namespace xmiExport
{
	/// <summary>
	/// Description of MessageElementCreator.
	/// </summary>
	
	public class MessageElementCreator:XmlElementCreator
	{	
		private const string MESSAGE_ELEMENT_TYPE_NAME="message";
		
		public MessageElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateMessageElement(XmlElement parentElement, MSCItem messageItem,XmlElement sourceLifeLineElement,XmlElement destinationLifeLineElement)
		{
			XmlElement messageElement=this.CreateUmlAttributeAsElement(parentElement,MESSAGE_ELEMENT_TYPE_NAME,UmlModel.MESSAGE);
			AddMessageNameAttribute(messageElement,messageItem);
			AddMessageSortAttribute(messageElement, messageItem);
			AddMessageKindAttribute(messageElement, messageItem);
			AddMessageOccurrenceSpecificationElements(parentElement,messageElement,sourceLifeLineElement,destinationLifeLineElement,messageItem);
			return messageElement;
		}
				
		private void AddMessageNameAttribute(XmlElement messageElement,MSCItem messageItem)
		{
			string messageName=messageItem.Name;
			if(messageName!=null)
			{
				this.AddNameAttribute(messageElement,messageName);
			}
		}
		
		private void AddMessageSortAttribute(XmlElement messageElement, MSCItem messageItem)
		{	
			string messageSort=this.GetMessageSort(messageItem);
			this.AddAttribute(messageElement,UmlModel.MESSAGE_SORT_ATTR_NAME,messageSort);
		}
		
		private void AddMessageKindAttribute(XmlElement messageElement, MSCItem messageItem)
		{	
			string messageKind=this.GetMessageKind(messageItem);
			this.AddAttribute(messageElement,UmlModel.MESSAGE_KIND_ATTR_NAME,messageKind);
		}
		
		private string GetMessageKind(MSCItem messageItem)
		{	
			string messageKind=null;
			
			if(messageItem is Message)
			{
				messageKind=UmlModel.MESSAGE_KIND_COMPLETE;	
			}
			else if(messageItem is LostMessage)
			{
				messageKind=UmlModel.MESSAGE_KIND_LOST;
			}
			else if (messageItem is FoundMessage)
			{
				messageKind=UmlModel.MESSAGE_KIND_FOUND;
			}
			return messageKind;
		}
		
		private string GetMessageSort(MSCItem messageItem)
		{
			string messageSort=null;
					
			if(messageItem is Message)
			{
				Message normalMessage=messageItem as Message;
				messageSort= GetMessageSortNormalMessage(normalMessage);
			}
			else if((messageItem is LostMessage)||(messageItem is FoundMessage))
			{
				messageSort=UmlModel.MESSAGE_SORT_ASYNCH_CALL;
			}
			return messageSort;
		}
								
		private string GetMessageSortNormalMessage(Message normalMessage)
		{
			string messageSort=null;
			MessageStyle messageStyle=normalMessage.MStyle;
			
			if(messageStyle==MessageStyle.Normal)
			{
				messageSort=UmlModel.MESSAGE_SORT_ASYNCH_CALL;	
			}
			else if (messageStyle==MessageStyle.Dashed)
			{
				messageSort=UmlModel.MESSAGE_SORT_ASYNCH_SIGNAL;
			}
			else if(messageStyle==MessageStyle.Synchron)
			{
				messageSort=UmlModel.MESSAGE_SORT_SYNCH_CALL;
			}
			return messageSort;
		}
		
		private void AddMessageOccurrenceSpecificationElements(XmlElement parentElement,XmlElement messageElement,XmlElement sourceLifeLine,XmlElement destinationLifeLine,MSCItem messageItem)
		{
			if(messageItem is Message)
			{
				AddMessageOccurrenceSpecSendEvent(parentElement,messageElement,sourceLifeLine);
				AddMessageOccurrenceSpecReceiveEvent(parentElement,messageElement,destinationLifeLine);	
			}
			else if(messageItem is LostMessage)
			{
				AddMessageOccurrenceSpecSendEvent(parentElement,messageElement,sourceLifeLine);
			}
			else if(messageItem is FoundMessage)
			{
				AddMessageOccurrenceSpecReceiveEvent(parentElement,messageElement,destinationLifeLine);
			}		
		}
		
		private void AddMessageOccurrenceSpecReceiveEvent(XmlElement parentElement,XmlElement messageElement,XmlElement lifelineElement)
		{
			XmlElement eventElement=CreateMessageOccurrenceSpecElement(parentElement,messageElement,lifelineElement,EventKind.ReceiveEvent);
			string eventElementID=eventElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			this.AddAttribute(messageElement,UmlModel.RECEIVE_EVENT_ATTR_NAME,eventElementID);
		}
		
		private void AddMessageOccurrenceSpecSendEvent(XmlElement parentElement,XmlElement messageElement,XmlElement lifelineElement)
		{
			XmlElement eventElement=CreateMessageOccurrenceSpecElement(parentElement,messageElement,lifelineElement,EventKind.SendEvent);
			string eventElementID=eventElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			this.AddAttribute(messageElement,UmlModel.SEND_EVENT_ATTR_NAME,eventElementID);
		}
		
		private XmlElement CreateMessageOccurrenceSpecElement(XmlElement parentElement,XmlElement messageElement,XmlElement lifelineElement,EventKind eventKind)
		{
			string messageElementID=messageElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string messageSort=messageElement.GetAttribute(UmlModel.MESSAGE_SORT_ATTR_NAME);
			MessageOccurrenceSpecElementCreator elementCreator=
						new MessageOccurrenceSpecElementCreator(this.XmiDocument,this.XmiDocumentBuilder,messageSort,eventKind);
			XmlElement newMessageOccurenceSpecElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifelineElement,messageElementID);
			return newMessageOccurenceSpecElement;
		}
	}
}
