/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 30.11.2007
 * Zeit: 16:21
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using System.Drawing;
using xmiImport;
using xmi;
using xmiPapyrus;
using sequenceChartModel;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of PapyrusXmiDIDocumentInterpreter.
	/// </summary>
	public class PapyrusXmiDIDocumentInterpreter:XmiDIDocumentInterpreter
	{
		private const string ELEMENT_TYPE_LIFELINE_FOR_ID_QUERY="//contained/contained/semanticModel/element[@xsi:type='uml:Lifeline' and @href='";
		private const string ELEMENT_TYPE_MESSAGE_OCCURRENCE_SPEC_FOR_ID_QUERY="//contained/contained/semanticModel/element[@xsi:type='uml:MessageOccurrenceSpecification' and @href='";
		private const string ELEMENT_TYPE_BEHAVIOR_EXECUTION_SPEC_FOR_ID_QUERY="//contained/contained/semanticModel/element[@xsi:type='uml:BehaviorExecutionSpecification' and @href='";
		private const string ELEMENT_TYPE_ACTION_EXECUTION_SPEC_FOR_ID_QUERY="//contained/contained/semanticModel/element[@xsi:type='uml:ActionExecutionSpecification' and @href='";
		private const string ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY="//contained/semanticModel/element[@xsi:type='uml:Message' and @href='";
		private const string ELEMENT_TYPE_ANCHORAGE_FOR_GRAPH_EDGE_ID_QUERY="./contained/contained/anchorage[@graphEdge='";
		private const string LIFELINE_ELEMENT_ID_FOR_GRAPH_NODE_QUERY="./semanticModel/element[@xsi:type='uml:Lifeline']";
		private const string UML_DIAMOND_STRING="uml#";
		private const string DIAGRAM_ELEMENT_FOR_NUMBER_QUERY_START="//di2:Diagram[";
		private const string DIAGRAM_ELEMENT_FOR_NUMBER_QUERY_END="][@type='SequenceDiagram']";
		private const string QUERY_END_WITHOUT_QUOTE="]";
		private string hrefPrefix;
		private EmfQueryConverter converter;
		
		public PapyrusXmiDIDocumentInterpreter(string modelDocumentName):base(modelDocumentName)
		{
			hrefPrefix=modelDocumentName+POINT+UML_DIAMOND_STRING;
			converter=new EmfQueryConverter();
		}
		
		public override void InitNamespaceManager(XmlDocument xmiDIDocument)
		{
			namespaceManager=new PapyrusXmiDiNamespaceManager(xmiDIDocument.NameTable);
		}
		
		public override XmlElement GetDiagramElement(XmlElement xmiElement,int diagramElementNumber)
		{
			XmlElement relevantDiagramElement=null;
			string diagramElementNumberString=Convert.ToString(diagramElementNumber);
			string query=DIAGRAM_ELEMENT_FOR_NUMBER_QUERY_START+diagramElementNumberString+DIAGRAM_ELEMENT_FOR_NUMBER_QUERY_END;
			relevantDiagramElement=(XmlElement)xmiElement.SelectSingleNode(query,namespaceManager);
			return relevantDiagramElement;
		}
		
		public override Point GetPositionForElement(XmlElement diagramElement,XmlElement relevantElement,string queryStart)
		{
			Point relevantElementPosition;
			string relevantElementId=relevantElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			relevantElementId=modelDocumentName+POINT+UML_DIAMOND_STRING+relevantElementId;
			XmlElement relevantElementGraphNode=this.GetGraphNodeForId(diagramElement,relevantElementId,queryStart);
			string relevantElementPositionString=relevantElementGraphNode.GetAttribute(UmlModel.POSITION_ATTR_NAME);
			relevantElementPosition=GetPositionForPositionString(relevantElementPositionString);	
			return relevantElementPosition;			
		}
		
		public override Size GetDimensionForElement(XmlElement diagramElement,XmlElement relevantElement,string queryStart)
		{
			Size relevantElementSize;
			string relevantElementId=relevantElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			relevantElementId=modelDocumentName+POINT+UML_DIAMOND_STRING+relevantElementId;
			XmlElement relevantElementGraphNode=this.GetGraphNodeForId(diagramElement,relevantElementId,queryStart);
			string relevantElementSizeString=relevantElementGraphNode.GetAttribute(UmlModel.SIZE_ATTR_NAME);
			relevantElementSize=GetSizeForSizeString(relevantElementSizeString);	
			return relevantElementSize;	
		}
		
		public override Point GetLifelineGraphNodePosition(XmlElement diagramElement,XmlElement lifelineElement)
		{
			Point lifelinePosition=GetPositionForElement(diagramElement,lifelineElement,ELEMENT_TYPE_LIFELINE_FOR_ID_QUERY);
			return lifelinePosition;
		}
		
		public override Point GetMessageGraphNodePosition(XmlElement diagramElement, XmlElement messageElement)
		{
			Point messagePosition=this.GetPositionForElement(diagramElement,messageElement,ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY);
			return messagePosition;
		}
		
		public override Point GetExecutionSpecPosition(XmlElement diagramElement,XmlElement executionElement)
		{
			Point executionPosition=new Point(-10000,-10000);
			string elementType=executionElement.GetAttribute(UmlModel.XMI_TYPE_ATTR_COMPLETE_NAME);
			
			if(elementType.Equals(UmlModel.UML_BEHAVIOR_EXECUTION_SPECIFICATION))
			{
				executionPosition=this.GetPositionForElement(diagramElement,executionElement,ELEMENT_TYPE_BEHAVIOR_EXECUTION_SPEC_FOR_ID_QUERY);
			}
			else if(elementType.Equals(UmlModel.UML_ACTION_EXECUTION_SPECIFICATION))
			{
				executionPosition=this.GetPositionForElement(diagramElement,executionElement,ELEMENT_TYPE_ACTION_EXECUTION_SPEC_FOR_ID_QUERY);
			}
			
			return executionPosition;
		}
		
		public override Size GetExecutionSpecDimension(XmlElement diagramElement,XmlElement executionElement)
		{
			Size executionDimension=new Size(-100000,-100000);
			
			string elementType=executionElement.GetAttribute(UmlModel.XMI_TYPE_ATTR_COMPLETE_NAME);
			
			if(elementType.Equals(UmlModel.UML_BEHAVIOR_EXECUTION_SPECIFICATION))
			{
				executionDimension=GetDimensionForElement(diagramElement,executionElement,ELEMENT_TYPE_BEHAVIOR_EXECUTION_SPEC_FOR_ID_QUERY);
			}
			else if(elementType.Equals(UmlModel.UML_ACTION_EXECUTION_SPECIFICATION))
			{
		    	executionDimension=GetDimensionForElement(diagramElement,executionElement,ELEMENT_TYPE_ACTION_EXECUTION_SPEC_FOR_ID_QUERY);
		    }
			
			return executionDimension;
		}
		
		/*public override Point GetFormalGateGraphNodePosition(XmlElement diagramElement, XmlElement formalGateElement,MessageEndKind messageEndType)
		{
			Point relevantPosition;
			string relevantPositionString="";
			XmlElement anchorageElement=null;
			string anchorageElementId;
			string messageId=formalGateElement.GetAttribute(UmlModel.MESSAGE_ATTR_NAME);
			string messageQuery=ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY+this.hrefPrefix+messageId+QUERY_END;
			XmlElement messageElement=(XmlElement)diagramElement.SelectSingleNode(messageQuery,this.namespaceManager);
			XmlElement messageGraphNode=this.GetGraphElementForElementElement(messageElement);
			string emfQuerys=messageGraphNode.GetAttribute(UmlModel.ANCHOR_ATTR_NAME);
			
			ArrayList convertedAnchorageQueries=converter.ConvertEmfQuery(emfQuerys);
			
			if(messageEndType== MessageEndKind.sourceEnd)
			{
				anchorageElementId=(string)convertedAnchorageQueries[0];
				anchorageElement=GetAnchorageElement(anchorageElementId,diagramElement);
			}
			else if(messageEndType== MessageEndKind.destinationEnd)
			{
				anchorageElementId=(string)convertedAnchorageQueries[1];
				anchorageElement=GetAnchorageElement(anchorageElementId,diagramElement);
			}
			
			relevantPositionString=anchorageElement.GetAttribute(UmlModel.POSITION_ATTR_NAME);
			relevantPosition=this.GetPositionForPositionString(relevantPositionString);
			return relevantPosition;
		}*/
		
		public override Point GetMessageOccurrenceSpecGraphNodePosition(XmlElement diagramElement,XmlElement messageOccurrenceSpecElement)
		{
			Point relevantPosition;
			string relevantPositionString="";
			string relevantLifelineGraphNodePositionString="";
			Point relevantLifelineGraphNodePosition;
			string coveredAttrValue=messageOccurrenceSpecElement.GetAttribute(UmlModel.COVERED_ATTR_NAME);
			string messageId=messageOccurrenceSpecElement.GetAttribute(UmlModel.MESSAGE_ATTR_NAME);
			string messageQuery=ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY+this.hrefPrefix+messageId+QUERY_END;
			XmlElement messageElement=(XmlElement)diagramElement.SelectSingleNode(messageQuery,this.namespaceManager);
			XmlElement messageGraphNode=this.GetGraphElementForElementElement(messageElement);
			string emfQuerys=messageGraphNode.GetAttribute(UmlModel.ANCHOR_ATTR_NAME);
			
			
			ArrayList convertedAnchorageQueries=converter.ConvertEmfQuery(emfQuerys);
			string firstAnchorageId=(string)convertedAnchorageQueries[0];
			XmlElement firstAnchorageElement=GetAnchorageElement(firstAnchorageId,diagramElement);
			XmlElement firstAnchoredLifelineGraphNode=(XmlElement)firstAnchorageElement.ParentNode;
			string firstAnchoredLifelineElementId=GetLifelineElementIdForLifelineGraphNode(firstAnchoredLifelineGraphNode);
			string secondAnchorageId=(string)convertedAnchorageQueries[1];
			XmlElement secondAnchorageElement=GetAnchorageElement(secondAnchorageId,diagramElement);
			XmlElement secondAnchoredLifelineGraphNode=(XmlElement)secondAnchorageElement.ParentNode;
			string secondAnchoredLifelineElementId=GetLifelineElementIdForLifelineGraphNode(secondAnchoredLifelineGraphNode);
			
			
			if(coveredAttrValue.Equals(firstAnchoredLifelineElementId))
			{
				relevantPositionString=
							firstAnchorageElement.GetAttribute(UmlModel.POSITION_ATTR_NAME);
				
				relevantLifelineGraphNodePositionString=firstAnchoredLifelineGraphNode.GetAttribute(UmlModel.POSITION_ATTR_NAME);
			}
			else if(coveredAttrValue.Equals(secondAnchoredLifelineElementId))
			{
				relevantPositionString=
						secondAnchorageElement.GetAttribute(UmlModel.POSITION_ATTR_NAME);
				relevantLifelineGraphNodePositionString=secondAnchoredLifelineGraphNode.GetAttribute(UmlModel.POSITION_ATTR_NAME);
			}
			
			relevantPosition=this.GetPositionForPositionString(relevantPositionString);
			relevantLifelineGraphNodePosition=this.GetPositionForPositionString(relevantLifelineGraphNodePositionString);
			relevantPosition.X=relevantPosition.X+relevantLifelineGraphNodePosition.X;
			relevantPosition.Y=relevantPosition.Y+relevantLifelineGraphNodePosition.Y;
			return relevantPosition;
		}
		
		public override Point GetFormalGateGraphNodePosition(XmlElement diagramElement,XmlElement formalGateElement,MessageEndKind messageEndType)
		{
			Point relevantPosition;
			string relevantPositionString="";
			string messageElementId;
			//string formalGateElementId;
			string relevantAnchorageElementId="";
			XmlElement relevantAnchorageElement;
			
			messageElementId=formalGateElement.GetAttribute(UmlModel.MESSAGE_ATTR_NAME);
			string messageQuery=ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY+this.hrefPrefix+messageElementId+QUERY_END;
			XmlElement messageElement=(XmlElement)diagramElement.SelectSingleNode(messageQuery,this.namespaceManager);
			XmlElement messageGraphNode=this.GetGraphElementForElementElement(messageElement);
			string emfQuerys=messageGraphNode.GetAttribute(UmlModel.ANCHOR_ATTR_NAME);
			
			
			ArrayList convertedAnchorageQueries=converter.ConvertEmfQuery(emfQuerys);
			
			if(messageEndType==MessageEndKind.sourceEnd) 
			{
				relevantAnchorageElementId=(string)convertedAnchorageQueries[0];
			}
			else if(messageEndType==MessageEndKind.destinationEnd)
			{
				relevantAnchorageElementId=(string)convertedAnchorageQueries[1];
			}
				
			relevantAnchorageElement=GetAnchorageElement(relevantAnchorageElementId,diagramElement);
			relevantPositionString=relevantAnchorageElement.GetAttribute(UmlModel.POSITION_ATTR_NAME);
			relevantPosition=this.GetPositionForPositionString(relevantPositionString);
		
			return relevantPosition;
		}
		
		protected internal XmlElement GetAnchorageElement(string anchorageQuery,XmlElement diagramElement)
		{
			XmlElement anchorageElement=null;
			string query=DOUBLE_SLASH+anchorageQuery;
			anchorageElement=(XmlElement)diagramElement.SelectSingleNode(query,namespaceManager);
			return anchorageElement;
		}
		
		protected internal string GetLifelineElementIdForLifelineGraphNode(XmlElement lifelineGraphNode)
		{
			string lifelineElementId=null;
			XmlElement elementElement=(XmlElement)lifelineGraphNode.SelectSingleNode(LIFELINE_ELEMENT_ID_FOR_GRAPH_NODE_QUERY,namespaceManager);
			string hrefAttrValue=elementElement.GetAttribute(UmlModel.HREF_ATTR_NAME);
			lifelineElementId=hrefAttrValue.Remove(INDEX_ZERO,this.hrefPrefix.Length);
			return lifelineElementId;
		}	
	}
}
