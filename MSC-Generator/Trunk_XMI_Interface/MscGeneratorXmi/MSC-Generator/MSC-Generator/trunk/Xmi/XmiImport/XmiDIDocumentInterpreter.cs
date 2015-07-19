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
using System.Drawing;
using System.Xml.XPath;
using System.Collections;
using xmi;
using sequenceChartModel;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiDIDocumentInterpreter.
	/// </summary>
	public abstract class XmiDIDocumentInterpreter
	{
		protected XmlNamespaceManager namespaceManager;
		protected const string QUERY_END="']";
		protected string modelDocumentName;
		protected const string POINT=".";
		private const string DOUBLE_POINT=":";
		protected const string DOUBLE_SLASH="//";
		protected const int INDEX_ZERO=0;
		
		
		public XmiDIDocumentInterpreter(string modelDocumentName)
		{
			this.modelDocumentName=modelDocumentName;
		}
				
		public XmlNamespaceManager NamespaceManager{
			get{
				return namespaceManager;
			}
		}
		
		public abstract Point GetFormalGateGraphNodePosition(XmlElement diagramElement, XmlElement formalGateElement,MessageEndKind eventKind);
		
		public abstract void InitNamespaceManager(XmlDocument loadedXmiDIDocument);
	
		public abstract XmlElement GetDiagramElement(XmlElement xmiElement,int diagramElementNumber);
		
		public abstract Point GetMessageOccurrenceSpecGraphNodePosition(XmlElement diagramElement,XmlElement messageOccurrenceSpecElement);
					
		public abstract Point GetPositionForElement(XmlElement diagramElement,XmlElement relevantElement,string queryStart);
		
		public abstract Point GetLifelineGraphNodePosition(XmlElement diagramElement,XmlElement lifelineElement);
		
		public abstract Point GetMessageGraphNodePosition(XmlElement diagramElement, XmlElement messageElement);
		
		public abstract Point GetExecutionSpecPosition(XmlElement diagramElement,XmlElement executionElement);
		
		public abstract Size GetDimensionForElement(XmlElement diagramElement,XmlElement relevantElement,string queryStart);
		
		public abstract Size GetExecutionSpecDimension(XmlElement diagramElement,XmlElement executionElement);
		
						
		public XmlElement GetGraphNodeForId(XmlElement diagramElement,string relevantElementId,string queryStart)
		{
			XmlElement foundGraphNode;
			string query=queryStart+relevantElementId+QUERY_END;
			XmlElement currentElementElement=(XmlElement)diagramElement.SelectSingleNode(query,this.namespaceManager);
			foundGraphNode=GetGraphElementForElementElement(currentElementElement);
			return foundGraphNode;
		}
		
		protected internal XmlElement GetGraphElementForElementElement(XmlElement elementElement)
		{
			XmlElement graphNodeElement=null;
			
			if(elementElement!=null)
			{
				XmlElement semanticModelElement=(XmlElement)elementElement.ParentNode;
				graphNodeElement=(XmlElement)semanticModelElement.ParentNode;
			}
			
			return graphNodeElement;
		}
		
		protected internal Point GetPositionForPositionString(string positionString)
		{
			Point position=new Point();
			
			if(positionString.Length>0)
			{
				int indexDoublePoint=positionString.IndexOf(DOUBLE_POINT);
				string xString=positionString.Substring(INDEX_ZERO,indexDoublePoint);
				string yString=positionString.Substring(indexDoublePoint+1,positionString.Length-indexDoublePoint-1);
				int x=Convert.ToInt32(xString);
				int y=Convert.ToInt32(yString);
				position.X=x;
				position.Y=y;
			}
			
			return position;
		}
		
		protected internal Size GetSizeForSizeString(string dimensionString)
		{
			Size dimension=new Size();
			int indexDoublePoint=dimensionString.IndexOf(DOUBLE_POINT);
			string widthString=dimensionString.Substring(INDEX_ZERO,indexDoublePoint);
			string heightString=dimensionString.Substring(indexDoublePoint+1,dimensionString.Length-indexDoublePoint-1);
			int width=Convert.ToInt32(widthString);
			int height=Convert.ToInt32(heightString);
			dimension.Width=width;
			dimension.Height=height;
			return dimension;
		}
	}
}
