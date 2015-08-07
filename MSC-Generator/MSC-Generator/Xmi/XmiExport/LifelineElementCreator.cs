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
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of LifelineElementCreator.
	/// </summary>
	public class LifelineElementCreator:XmlElementCreator
	{
		private const string LIFELINE_ELEMENT_TYPE_NAME="lifeline";
		private const string DOUBLE_POINT=":";
		private const int INDEX_ZERO=0;
		
		public LifelineElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									 base(xmiDocument,xmiDocumentBuilder){}
		
		public XmlElement CreateLifelineElement(XmlElement parentElement,XmlElement modelElement,Process lifelineItem)
		{
			XmlElement lifelineElement=CreateUmlAttributeAsElement(parentElement,LIFELINE_ELEMENT_TYPE_NAME,UmlModel.LIFELINE);
			AddLifelineNameAttribute(lifelineElement,lifelineItem);
			XmlElement classElement=this.CreateAssociatedClassElement(modelElement,lifelineElement);
			XmlElement propertyElement=CreateAssociatedPropertyElement(modelElement,lifelineElement,classElement);
			AddRepresentsAttribute(lifelineElement,propertyElement);
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
		
		private void AddRepresentsAttribute(XmlElement lifelineElement,XmlElement propertyElement)
		{
			string propertyElementId=propertyElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			this.AddAttribute(lifelineElement,UmlModel.REPRESENTS_ATTR_NAME,propertyElementId);
		}
		
		private XmlElement CreateAssociatedClassElement(XmlElement modelElement,XmlElement lifelineElement)
		{
			XmlElement createdClassElement=null;
			string lifelineName=lifelineElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			string className=this.GetLifelineTypeName(lifelineName);
			
			if(className!=null)
			{
				ClassElementCreator elementCreator=new ClassElementCreator(this.XmiDocument,this.XmiDocumentBuilder);
				createdClassElement=elementCreator.CreateClassElement(modelElement,className);
			}
			
			return createdClassElement;
		}
		
		private XmlElement CreateAssociatedPropertyElement(XmlElement modelElement,XmlElement lifelineElement,XmlElement classElement)
		{
			XmlElement createdPropertyElement; 
			string lifelineName=lifelineElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			string lifelineObjectName=GetLifelineObjectName(lifelineName);
			string lifelineTypeName=GetLifelineTypeName(lifelineName);
			
			PropertyElementCreator elementCreator=new PropertyElementCreator(this.XmiDocument,this.XmiDocumentBuilder);
			createdPropertyElement=elementCreator.CreatePropertyElement(modelElement,lifelineObjectName,classElement);
			return createdPropertyElement;
		}
		
		public string GetLifelineObjectName(string lifelineName)
		{
			string lifelineObjectName=null;
			
			if((lifelineName!=null)&&(lifelineName.Length>0))
			{
				int indexOfDoublePoint=lifelineName.IndexOf(DOUBLE_POINT);
				
				if(indexOfDoublePoint==-1)
				{
				   	lifelineObjectName=lifelineName;	
				}
				else if((lifelineName.Length>2)&&(indexOfDoublePoint>0))
				{
					lifelineObjectName=lifelineName.Substring(INDEX_ZERO,indexOfDoublePoint);
				}
			}
			
			return lifelineObjectName;
		}
		
		public string GetLifelineTypeName(string lifelineName)
		{
			string lifelineTypeName=null;
			
			if((lifelineName!=null)&&(lifelineName.Length>1))
			{
				int indexOfDoublePoint=lifelineName.IndexOf(DOUBLE_POINT);
				
				if(indexOfDoublePoint>-1)
				{
					lifelineTypeName=lifelineName.Substring(indexOfDoublePoint+1);
				}
			}
			return lifelineTypeName;
		}
	}
}
