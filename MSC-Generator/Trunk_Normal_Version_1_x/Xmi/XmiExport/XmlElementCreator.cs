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
 * Zeit: 09:04
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using nGenerator;
using mscElements;
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of UmlElementCreator.
	/// </summary>
	public class XmlElementCreator
	{
		private XmlDocument xmiDocument;
		private XmlDocumentBuilder xmiDocumentBuilder;
		private const string DOUBLE_POINT=":";
		private const string UML_PREFIX="uml";
		protected const string  ATTRIBUTE_SELECTION_QUERY_START="//@";
		protected const string EMPTY_STRING="";
		protected const string SPACE_STRING=" ";
		
		public XmlElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder)
		{
			this.xmiDocument=xmiDocument;
			this.xmiDocumentBuilder=xmiDocumentBuilder;
		}
		
		public XmlElementCreator(XmlDocument xmiDocument):this(xmiDocument,null){}
		
		public XmlDocument XmiDocument{
			
			get{
				return this.xmiDocument;
			}
			set{
				this.xmiDocument=value;
			}
		}
		
		public XmlDocumentBuilder XmiDocumentBuilder{
			
			get{
				return this.xmiDocumentBuilder;
			}
			set{
				this.xmiDocumentBuilder=value;
			}
		}
		
		protected void AddAttribute(XmlElement containingElement,
		                            string newAttributeName,
		                            string newAttributeValue)
		{
			XmlAttribute newAttribute=xmiDocument.CreateAttribute(newAttributeName);
			newAttribute.Value=newAttributeValue;
			containingElement.Attributes.Append(newAttribute);
		}
		
		protected XmlElement CreateUmlElement(XmlElement parentElement,
		                                      string newElementTypeName)
		{	
			XmlElement newElement=CreateUmlElement(parentElement,newElementTypeName,null);
			return newElement;
		}
		
		protected XmlElement CreateUmlElement(XmlElement parentElement,
		                                      string newElementTypeName,
		                                      string xmiTypeAttrValue)
		{	
			XmlElement newElement=xmiDocument.CreateElement(UmlModel.UML_NAMESPACE_PREFIX,
			                                                newElementTypeName,
            												UmlModel.UML_NAMESPACE_URI);
		    AddXmiIdAttribute(newElement);
		    if(xmiTypeAttrValue!=null)
		    {
		    	AddXmiTypeAttribute(newElement,xmiTypeAttrValue);
		    }
		    parentElement.AppendChild(newElement);
			return newElement;
		}
		
	 	protected XmlElement AddReferenceAsElement(XmlElement parentElement,string elementType,string referenceValue)
		{	
			XmlElement referenceElement=xmiDocument.CreateElement(elementType);
			this.AddXmiIdrefAttribute(referenceElement,referenceValue);
		    parentElement.AppendChild(referenceElement);
			return referenceElement;
		}
		
		protected XmlElement CreateUmlAttributeAsElement(XmlElement parentElement,string elementType)
		{
			XmlElement newElement=CreateUmlAttributeAsElement(parentElement,elementType,null);
			return newElement;
		}
		
		protected XmlElement CreateUmlAttributeAsElement(XmlElement parentElement,string elementType,string xmiTypeAttrValue)
		{
			XmlElement newElement=xmiDocument.CreateElement(elementType);
			this.AddXmiIdAttribute(newElement);
			this.AddXmiTypeAttribute(newElement,xmiTypeAttrValue);
			parentElement.AppendChild(newElement);
			return newElement;
		}
		
		protected void CreatePrimitiveAttributeAsElement(XmlElement parentElement,string elementType,string attrValue)
		{
			XmlElement newElement=xmiDocument.CreateElement(elementType);
			newElement.InnerText=attrValue;
			parentElement.AppendChild(newElement);
		}
		
		protected void AddXmiAttribute(XmlElement containingElement,
		                            String attributeName,
		                            String attributeValue)
		{
			XmlAttribute newXmiAttribute=xmiDocument.CreateAttribute(UmlModel.XMI_NAMESPACE_PREFIX,
			                                                         attributeName,
			                                                         UmlModel.XMI_NAMESPACE_URI);
			newXmiAttribute.Value=attributeValue;
			containingElement.Attributes.Append(newXmiAttribute);
		}
		
		protected void AddNameAttribute(XmlElement containingElement,
			                            String attributeValue)
		{
			this.AddAttribute(containingElement,UmlModel.NAME_ATTR_NAME,attributeValue);		
		}
		
		protected MSCItem GetMscItemByID(int mscItemID)
		{	
			Generator mscItemGenerator=xmiDocumentBuilder.MscItemGenerator;
			MSCItem foundMscItem=mscItemGenerator.GetMscItemByID(mscItemID);
			return foundMscItem;
		}
		
		protected void AddDoubleValueElement(XmlElement parentElement, string doubleValue)
		{
			XmlElement doubleValueElement=xmiDocument.CreateElement(UmlModel.DOUBLE_TYPE_NAME);
			doubleValueElement.Value=doubleValue;
			parentElement.AppendChild(doubleValueElement);
		}
		
		protected void AddXmiIdAttribute(XmlElement xmlElement)
		{
			string currentXmiID=this.GetCurrentXmiId();
			AddXmiAttribute(xmlElement,UmlModel.XMI_ID_ATTR_NAME,currentXmiID);
			IterateXmiIdCount();
		}
		
		protected void AddXmiIdrefAttribute(XmlElement ownerElement, string elementID)
		{
			AddXmiAttribute(ownerElement,UmlModel.XMI_IDREF_ATTR_NAME,elementID);
		}
		
		protected void AddXmiTypeAttribute(XmlElement xmlElement,String xmiType)
		{	
			if(xmiType!=null)
			{
				string completeXmiType=UML_PREFIX+DOUBLE_POINT+xmiType;
				AddXmiAttribute(xmlElement,UmlModel.XMI_TYPE_ATTR_NAME,completeXmiType);
			}
		}
		
		private String GetCurrentXmiId()
		{	
			uint xmiIDCount=xmiDocumentBuilder.CurrentXmiIdCount;
			String currentXmiId=Convert.ToString(xmiIDCount);
			return currentXmiId;
		}
		
		private void IterateXmiIdCount()
		{
			xmiDocumentBuilder.IterateXmiIdCount();	
		}
	}
}
