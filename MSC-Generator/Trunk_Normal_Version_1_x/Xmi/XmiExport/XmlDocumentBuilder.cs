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
 * Created with SharpDevelop.
 * User: LG
 * Date: 01.10.2007
 * Time: 10:13

 */

using System;
using System.Xml;
using nGenerator;
using mscElements;
using System.Drawing; 

namespace xmiExport
{
	/// <summary>
	/// Description of XmiDocumentBuilder.
	/// </summary>

	
	public class XmlDocumentBuilder
	{	
        private const string XML_NAMESPACE_PREFIX="xmlns";
		private const string XML_NAMESPACE_URI="http://www.w3.org/TR/REC-xml-names/";          
        private const string NAME_ATTR_NAME="name";
        private const string FRAGMENT_ELEMENT_TYPE_NAME="fragment";
        private const uint INITIAL_XMI_ID_COUNT=1;
        private const string DOUBLE_POINT=":";
        private uint currentXmiIdCount;
		private Generator mscItemGenerator;
		private XmlDocument xmiDocument;
			
		public XmlDocumentBuilder()
		{
			currentXmiIdCount=INITIAL_XMI_ID_COUNT;
		}
	
		public XmlDocument XmiDocument{
			get{
				return this.xmiDocument;
			}
			set{
				this.xmiDocument=value;
			}
		}
				
		public uint CurrentXmiIdCount{
			get{
				return this.currentXmiIdCount;
			}
			set{
				this.currentXmiIdCount=value;
			}
		}
		
		public Generator MscItemGenerator{
			get{
				return this.mscItemGenerator;
			}
			set{
				this.mscItemGenerator=value;
			}
		}
		
		public virtual XmlDocument CreateXmlDocument()
		{
			xmiDocument= new XmlDocument();
			XmlDeclarationElementCreator declarationElementCreator=new XmlDeclarationElementCreator(xmiDocument);
			XmiDocumentElementCreator documentElementCreator= new XmiDocumentElementCreator(xmiDocument);
			InitXmlDocument(declarationElementCreator,documentElementCreator);
			return xmiDocument;
		}
		
		public virtual XmlElement  AddUmlModelElement(String modelName)
		{
			UmlModelElementCreator elementCreator=new UmlModelElementCreator(xmiDocument,this);
			XmlElement newUmlModelElement=elementCreator.CreateUmlModelElement(modelName);
			return newUmlModelElement;
		}
		
		public XmlElement AddCollaborationElement(XmlElement modelElement, string collaborationName)
		{
			CollaborationElementCreator elementCreator=new CollaborationElementCreator(xmiDocument,this);
			XmlElement collaborationElement=elementCreator.CreateCollaborationElement(modelElement,collaborationName);
			return collaborationElement;
		}
				
		public XmlElement AddInteractionElement(XmlElement parentElement)
		{
			InteractionElementCreator elementCreator=new InteractionElementCreator(xmiDocument,this);
			XmlElement newInteractionElement=AddInteractionElement(parentElement, elementCreator);
			return newInteractionElement;
		}
		
		public XmlElement AddInteractionElement(XmlElement parentElement,InteractionElementCreator elementCreator)
		{
			XmlElement newInteractionElement=elementCreator.CreateInteractionElement(parentElement);
			return newInteractionElement;
		}	
		
		public XmlElement AddLifelineElement(XmlElement parentElement,XmlElement collaborationElement,Process lifelineItem)
		{
			LifelineElementCreator elementCreator=new LifelineElementCreator(xmiDocument,this);
			XmlElement newLifelineElement=elementCreator.CreateLifelineElement(parentElement,collaborationElement,lifelineItem);
			return newLifelineElement;
		}
		
		public XmlElement AddBehaviorExecutionSpecificationElement(XmlElement parentElement,ProcessRegion executionItem,XmlElement lifelineElement)
		{
			BehaviorExecutionSpecificationElementCreator elementCreator=new BehaviorExecutionSpecificationElementCreator(xmiDocument,this);
			XmlElement newExecutionSpecificationElement=elementCreator.CreateBehaviorExcecutionSpecificationElement(parentElement,executionItem,lifelineElement);
			return newExecutionSpecificationElement;
		}
			
		public XmlElement AddExecutionOccurrenceSpecificationElement(XmlElement parentElement,string executionSpecificationID, XmlElement lifelineElement)
		{
			ExecutionOccurrenceSpecElementCreator elementCreator= new ExecutionOccurrenceSpecElementCreator(xmiDocument,this);
			XmlElement newExecutionOccurrenceSpecElement=elementCreator.CreateExecutionOccurrenceSpecElement(parentElement,executionSpecificationID,lifelineElement);
			return newExecutionOccurrenceSpecElement;
		}
		
		public XmlElement AddMessageElement(XmlElement parentElement, MSCItem messageItem,XmlElement sourceLifeLine,XmlElement destinationLifeLine)
		{
			MessageElementCreator elementCreator=new MessageElementCreator(xmiDocument,this);
			XmlElement newMessageElement=elementCreator.CreateMessageElement(parentElement,messageItem,sourceLifeLine,destinationLifeLine);
			return newMessageElement;
		}
		
		public XmlElement AddMessageOccurrenceSpecificationElement(XmlElement parentElement, string messageID,XmlElement lifeline)
		{
			MessageOccurrenceSpecElementCreator elementCreator=new MessageOccurrenceSpecElementCreator(xmiDocument,this);
			XmlElement newMessageOccurrenceSpecElement=elementCreator.CreateMessageOccurrenceSpecificationElement(parentElement,lifeline, messageID);
			return newMessageOccurrenceSpecElement;
		}
		
		public void IterateXmiIdCount()
		{
		    currentXmiIdCount++;     
		}
		
		private void InitXmlDocument(XmlDeclarationElementCreator declarationElementCreator,XmiDocumentElementCreator documentElementCreator)
		{
			declarationElementCreator.CreateXmlDeclarationElement();
			documentElementCreator.CreateXmiDocumentElement();
		}
	}
}
