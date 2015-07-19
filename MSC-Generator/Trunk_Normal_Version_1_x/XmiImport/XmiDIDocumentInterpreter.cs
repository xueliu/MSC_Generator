/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 30.11.2007
 * Zeit: 16:19
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using System.Collections;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiDIDocumentInterpreter.
	/// </summary>
	public abstract class XmiDIDocumentInterpreter
	{
		private XmlDocument xmiDIDocument;
		private XmlNamespaceManager namespaceManager;
		protected const string QUERY_END="']";
		
		public XmiDIDocumentInterpreter()
		{
			xmiDIDocument=new XmlDocument();
			namespaceManager=new XmlNamespaceManager(xmiDIDocument.NameTable);
			InitNamespaceManager();
		}
		
		public XmiDIDocumentInterpreter(XmiDocument xmiDocument,XmlNamespaceManager namespaceManager)
		{
			xmiDIDocument=xmiDocument;
			namespaceManager=namespaceManager;
			InitNamespaceManager();
		}
		
		public XmlDocument XmiDIDocument{
			get{
				return xmiDIDocument;
			}
		}
		
		public XmlNamespaceManager NamespaceManager{
			get{
				return namespaceManager;
			}
		}
		public abstract Point GetMessageOccurrenceSpecGraphNodePosition(XmlElement diagramElement,XmlElement messageOccurrenceSpecElement);
		
		public abstract XmlElement GetContainerDiagramElement();
				
		public abstract Point GetPositionForElement(XmlElement diagramElement,XmlElement relevantElement,string queryStart);
		
		public abstract Point GetLifelineGraphNodePosition(XmlElement diagramElement,XmlElement lifelineElement);
		
		public abstract XmlElement GetMessageGraphNodePosition(XmlElement diagramElement, XmlElement messageElement);
		
		public abstract Point GetBehaviorExecutionSpecPosition(XmlElement diagramElement,XmlElement executionElement);
		
		public XmlElement GetContainerDiagramElement()
		{
			XmlElement diagramElement=null;
			XmlElement documentElement=xmiDIDocument.DocumentElement;
			XmlElement diagramElement=(XmlElement)documentElement.SelectSingleNode(SECOND_DIAGRAM_ELEMENT_QUERY,namespaceManager);
			return diagramElement;
		}
		
		public XmlElement GetGraphNodeForId(XmlElement diagramElement,XmlElement relevantElement,string queryStart)
		{
			XmlElement foundGraphNode;
			string relevantElementId=relevantElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string query=queryStart+relevantElementId+QUERY_END;
			XmlElement currentElementElement=diagramElement.SelectNodes(query);
			foundGraphNode=GetGraphNodeForElementElement(currentElementElement);
			return foundGraphNode;
		}
		
		protected XmlElement GetGraphNodeForElementElement(XmlElement elementElement)
		{
			XmlElement graphNodeElement=null;
			XmlElement semanticModelElement=elementElement.ParentNode;
			graphNodeElement=semanticModelElement.ParentNode;
			return graphNodeElement;
		}
		
		protected Point GetPositionForPositionString(string positonString)
		{
			Point position=new Point();
			int indexDoublePoint=positonString.IndexOf(DOUBLE_POINT);
			string xString=positonString.Substring(INDEX_ZERO,indexDoublePoint);
			string yString=positonString.Substring(INDEX_ZERO+1,positonString.Length-indexDoublePoint)
			int x=Convert.ToInt32(xString);
			int y=Convert.ToInt32(yString);
			position.X=x;
			position.Y=y;
			return position;
		}
	}
}
