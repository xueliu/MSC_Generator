/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 14:23
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using xmiImport;
using xmiImportPapyrus;
using xmi;
using nGenerator;
using mscElements;
using System.Diagnostics;
using sequenceChartModel;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiImport.
	/// </summary>
	public class XmiModelDocumentInterpreter
	{
		private const string EMPTY_STRING="";
		private XmlNamespaceManager namespaceManager;
		private const string INTERACTION_ELEMENTS_QUERY="//packagedElement[@xmi:type='uml:Interaction']";
		private const string MESSAGE_ELEMENTS_QUERY="//message";
		private const string LIFELINE_ELEMENTS_QUERY="//lifeline";
		private const string FORMAL_GATE_ELEMENTS_QUERY="//formalGate";
		private const string LIFELINE_ELEMENT_FOR_ID_QUERY_START="//lifeline[@xmi:id='";
		private const string BEHAVIOR_EXECUTION_SPEC_ELEMENTS_QUERY="//fragment[@xmi:type='uml:BehaviorExecutionSpecification']";
		private const string ACTION_EXECUTION_SPEC_ELEMENTS_QUERY="//fragment[@xmi:type='uml:ActionExecutionSpecification']";
		private const string EXECUTION_OCCURRENCE_SPEC_ELEMENTS_QUERY="//fragment[@xmi:type='uml:ExecutionOccurrenceSpecification']";
		private const string EXECUTION_OCCURRENCE_SPEC_ELEMENTS_FOR_COVERED_QUERY_START="//fragment[@xmi:type='uml:ExecutionOccurrenceSpecification' and @covered='";
		private const string BEHAVIOR_EXECUTION_SPEC_ELEMENTS_FOR_ID_QUERY_START="//fragment[@xmi:type='uml:BehaviorExecutionSpecification' and @xmi:id='";
		private const string ACTION_EXECUTION_SPEC_ELEMENTS_FOR_ID_QUERY_START="//fragment[@xmi:type='uml:ActionExecutionSpecification' and @xmi:id='";
		private const string MESSAGE_OCCURRENCE_SPEC_ELEMENT_FOR_COVERED_QUERY_START="//fragment[@xmi:type='uml:MessageOccurrenceSpecification' and @covered='";
		private const string MESSAGE_ELEMENT_FOR_MESSAGE_OCCURRENCE_QUERY_START="//message[@xmi:id='";
		private const string EVENT_ELEMENT_FOR_MESSAGE_QUERY_START="//packagedElement[@xmi:id='";
		private const string OCCURRENCE_SPECIFICATION_ELEMENTS_FOR_LIFELINE_ID_QUERY="//fragment [@xmi:type='uml:OccurrenceSpecification' and @covered='";
		private const string DESTRUCTION_EVENT_ELEMENTS_QUERY="//packagedElement[@xmi:type='uml:DestructionEvent']";
		private const string EXECUTION_OCCURRENCE_SPEC_ELEMENT_FOR_ID_QUERY_START =  "//fragment[@xmi:type='uml:ExecutionOccurrenceSpecification' and @xmi:id='";
		private const string MESSAGE_ELEMENT_FOR_ID_QUERY_START =  "//message [@xmi:id='";
		private const string QUERY_END="']";
		private const string MESSAGE_OCCURRENCE_ELEMENT_FOR_ID_QUERY_START ="//fragment[@xmi:type='uml:MessageOccurrenceSpecification' and @xmi:id='";
		private const string FORMAL_GATE_ELEMENT_FOR_ID_QUERY_START ="//formalGate[@xmi:id='";
		
		public XmlNamespaceManager NamespaceManager{
			get{
				return namespaceManager;
			}
			set{
				this.namespaceManager=value;
			}
		}
		
		public XmlNodeList GetInteractionElements(XmlElement modelElement)
		{
			XmlNodeList interactionElementList=modelElement.SelectNodes(INTERACTION_ELEMENTS_QUERY,namespaceManager);
			return interactionElementList;
		}
	
		public XmlNodeList GetMessageElements(XmlElement interactionElement)
		{
			XmlNodeList messageElementList=interactionElement.SelectNodes(MESSAGE_ELEMENTS_QUERY,namespaceManager);
			return messageElementList;
		}
		
		public XmlNodeList GetLifelineElements(XmlElement interactionElement)
		{
			XmlNodeList lifelineElementList=interactionElement.SelectNodes(LIFELINE_ELEMENTS_QUERY,namespaceManager);
			return lifelineElementList;
		}
		
		public XmlNodeList GetBehaviorExecutionSpecElements(XmlElement interactionElement)
		{
			XmlNodeList behaviorExecutionSpecElementList=interactionElement.SelectNodes(BEHAVIOR_EXECUTION_SPEC_ELEMENTS_QUERY,namespaceManager);
			return behaviorExecutionSpecElementList;
		}
		
		public XmlNodeList GetActionExecutionSpecElements(XmlElement interactionElement)
		{
			XmlNodeList actionExecutionSpecElementList=interactionElement.SelectNodes(ACTION_EXECUTION_SPEC_ELEMENTS_QUERY,namespaceManager);
			return actionExecutionSpecElementList;
		}
		
		public XmlNodeList GetExecutionOccurrenceSpecElements(XmlElement interactionElement)
		{
			XmlNodeList executionOccurrenceSpecElementList=interactionElement.SelectNodes(EXECUTION_OCCURRENCE_SPEC_ELEMENTS_QUERY,namespaceManager);
			return executionOccurrenceSpecElementList;
		}
		
		public XmlElement GetExecutionOccurrenceSpecElementForId(XmlElement interactionElement, string relevantExecutionOccurrenceSpecId)
		{
			XmlElement relevantExecutionOccurrenceSpecElement=null;
			string query=EXECUTION_OCCURRENCE_SPEC_ELEMENT_FOR_ID_QUERY_START+relevantExecutionOccurrenceSpecId+QUERY_END;
			relevantExecutionOccurrenceSpecElement= (XmlElement)interactionElement.SelectSingleNode(query,this.namespaceManager);
			return relevantExecutionOccurrenceSpecElement;
		}
		
		public XmlElement GetMessageElementForId(XmlElement interactionElement, string messeageElementId)
		{
			XmlElement relevantMessageElement=null;
			string query=MESSAGE_ELEMENT_FOR_ID_QUERY_START+messeageElementId+QUERY_END;
			relevantMessageElement=(XmlElement)interactionElement.SelectSingleNode(query,this.namespaceManager);
			return relevantMessageElement;
		}
			
			
		
		
		public XmlNodeList GetDestructionEventElements(XmlElement interactionElement)
		{
			XmlElement modelElement=(XmlElement)interactionElement.ParentNode;
			XmlNodeList destructionEventsElements=modelElement.SelectNodes(DESTRUCTION_EVENT_ELEMENTS_QUERY,namespaceManager);
			return destructionEventsElements;
		}
		
		public XmlElement GetLifelineElementForExecutionOccurrenceSpec (XmlElement occurrenceSpecElement)
		{
			XmlElement lifelineElement;
			string relevantLifelineElmentId;
			string query;
			XmlElement interactionElement =(XmlElement) occurrenceSpecElement.ParentNode;
			relevantLifelineElmentId= occurrenceSpecElement.GetAttribute(UmlModel.COVERED_ATTR_COMPLETE_NAME);
			query=LIFELINE_ELEMENT_FOR_ID_QUERY_START+relevantLifelineElmentId+QUERY_END;
			lifelineElement=(XmlElement)interactionElement.SelectSingleNode(query,this.namespaceManager);
			return lifelineElement;
		}
		
		/** This methods are not nessessarilly needed at the moment and are not tested
		public ExecutionOccurrenceSpecKind GetExecutionOccurrenceSpecKind(XmlElement occurrenceSpecElement)
		{
			ExecutionOccurrenceSpecKind specKind=null;
			XmlElement currentExecutionSpecElement;	
			XmlElement interactionElement=(XmlElement) occurrenceSpecElement.ParentNode;
			string occurrenceSpecElementId=occurrenceSpecElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			occurrenceSpecElementId=occurrenceSpecElementId.Trim();
			XmlNodeList behaviorExecutionSpecElements;
			
			XmlNodeList actionExecutionSpecElements =
				interactionElement.SelectNodes( ACTION_EXECUTION_SPEC_ELEMENTS_QUERY,this.namespaceManager);

			specKind= GetExecutionOccurrenceSpecKindForNodeList(actionExecutionSpecElements,occurrenceSpecElementId);
			
			if(specKind==null)
			{
				behaviorExecutionSpecElements=interactionElement.SelectNodes( BEHAVIOR_EXECUTION_SPEC_ELEMENTS_QUERY,this.namespaceManager);
				specKind= GetExecutionOccurrenceSpecKindForNodeList(behaviorExecutionSpecElements,occurrenceSpecElementId);
			}
				
			return specKind;
		}
		
		
		private ExecutionOccurrenceSpecKind GetExecutionOccurrenceSpecKindForNodeList(XmlNodeList executionSpecElements, 
		                                                                              string occurrenceSpecElementId)
		{
			ExecutionOccurrenceSpecKind specKind= null;
			ÍEnumerator itrExecutionSpecElements=executionSpecElements.GetEnumerator();
			boolean isNotFound=true;
			string currentStartAttrValue;
			string currentFinishAttrValue;
			
			while(itrBehaviorExecutionSpecElements.MoveNext && isNotFound)
			{
				currentExecutionSpecElement=itrActionExecutionSpecElements.Current;
				currentStartAttrValue=currentExecutionSpecElement.GetAttribute(UmlModel.START_ATTR_COMPLETE_NAME);
				currentFinishAttrValue=currentExecutionSpecElement.GetAttribute(UmlModel.FINISH_ATTR_COMPLETE_NAME);
					
				if(currentStartAttrValue.trim() == occurrenceSpecElementId)
				{
					isNotFound=false;
					specKind=ExecutionOccurrenceSpecKind.START;
				}
				else if(currentFinishAttrValue.trim() == occurrenceSpecElementId)
				{
					isNotFound=false;
					specKind=ExecutionOccurrenceSpecKind.FINISH;
				}
			}
			
			return specKind;
		}
		**/
		
		
		public ArrayList GetExecutionSpecElementsForLifeline(XmlElement lifelineElement)
		{
			XmlElement currentExecutionOccurrenceSpecElement;
			XmlElement currentExecutionSpecElement;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			string currentExecutionAttrValue;
			string behaviorExecutionSpecQuery;
			string actionExecutionSpecQuery;
			string lifelineId=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			ArrayList relevantExecutionOccurrenceSpecElements=GetExecutionOccurrenceSpecElementsForLifeline(lifelineElement);
			ArrayList relevantExecutionSpecElements=new ArrayList();
			int count=relevantExecutionOccurrenceSpecElements.Count;
		    
			for(int index=0;index<count;index++)
			{
		    	currentExecutionOccurrenceSpecElement=(XmlElement)relevantExecutionOccurrenceSpecElements[index];
		    	currentExecutionAttrValue=currentExecutionOccurrenceSpecElement.GetAttribute(UmlModel.EXECUTION_ATTR_NAME);
		    	
		    	behaviorExecutionSpecQuery=BEHAVIOR_EXECUTION_SPEC_ELEMENTS_FOR_ID_QUERY_START+currentExecutionAttrValue+QUERY_END;
		    	currentExecutionSpecElement=(XmlElement)interactionElement.SelectSingleNode(behaviorExecutionSpecQuery,this.namespaceManager);
		    	
		    	if(currentExecutionSpecElement==null)
		    	{
		    		actionExecutionSpecQuery=ACTION_EXECUTION_SPEC_ELEMENTS_FOR_ID_QUERY_START+currentExecutionAttrValue+QUERY_END;
		    		currentExecutionSpecElement=(XmlElement)interactionElement.SelectSingleNode(actionExecutionSpecQuery,this.namespaceManager);
		    	}
		    	
		    	if(currentExecutionSpecElement!=null)
		    	{
		    		relevantExecutionSpecElements.Add(currentExecutionSpecElement);
		    	}
			}
			return relevantExecutionSpecElements;
		}	
		
		public ArrayList GetExecutionOccurrenceSpecElementsForLifeline(XmlElement lifelineElement)
		{
			XmlElement currentExecutionOccurrenceSpecElement;
			string currentCoveredAttributeValue;
			string currentExecutionAttributeValue;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			ArrayList relevantExecutionOccurrenceSpecElements=new ArrayList();
			ArrayList workedBehaviorExecutionIds=new ArrayList();
			string lifelineId=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string executionOccurrenceSpecElementsQuery=EXECUTION_OCCURRENCE_SPEC_ELEMENTS_FOR_COVERED_QUERY_START+lifelineId+QUERY_END;
			XmlNodeList executionOccurrenceSpecElements=interactionElement.SelectNodes(executionOccurrenceSpecElementsQuery,namespaceManager);
			IEnumerator itrExecutionOccurrenceSpecElements=executionOccurrenceSpecElements.GetEnumerator();
			
			while(itrExecutionOccurrenceSpecElements.MoveNext())
			{
				currentExecutionOccurrenceSpecElement=(XmlElement)itrExecutionOccurrenceSpecElements.Current;
				currentCoveredAttributeValue=currentExecutionOccurrenceSpecElement.GetAttribute(UmlModel.COVERED_ATTR_NAME);
				currentExecutionAttributeValue=currentExecutionOccurrenceSpecElement.GetAttribute(UmlModel.EXECUTION_ATTR_NAME);
				
				if(lifelineId.Equals(currentCoveredAttributeValue))
				{
					if(!(workedBehaviorExecutionIds.Contains(currentExecutionAttributeValue)))
					{
						relevantExecutionOccurrenceSpecElements.Add(currentExecutionOccurrenceSpecElement);
						workedBehaviorExecutionIds.Add(currentExecutionAttributeValue);
					}
				}
			}
			return relevantExecutionOccurrenceSpecElements;
		}	
		
		public XmlNodeList GetMessageOccurrenceSpecElementsForLifeline(XmlElement lifelineElement)
		{
			XmlNodeList relevantMessageOccurenceSpecElements;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			string lifelineId=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string query=MESSAGE_OCCURRENCE_SPEC_ELEMENT_FOR_COVERED_QUERY_START+lifelineId+QUERY_END;
			relevantMessageOccurenceSpecElements=interactionElement.SelectNodes(query,this.namespaceManager);
			return relevantMessageOccurenceSpecElements;
		}
		
		public XmlNodeList GetFormalGateElements(XmlElement interactionElement)
		{
			XmlNodeList relevantFormalGateElements;
			relevantFormalGateElements=interactionElement.SelectNodes(FORMAL_GATE_ELEMENTS_QUERY);
			return relevantFormalGateElements;
		}
		
		
		public XmlElement GetOppositeMessageEnd (XmlElement interactionElement,XmlElement startMessageEndElement,XmlElement messageElement) 
		{
			XmlElement oppositeMessageEndElement=null;
			string oppositeMessageEndElementId;
			//string messageEndElementId;
			string currEventElementId;
			string startMessageElementId;
			string query;
			
			
			startMessageElementId = startMessageEndElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			currEventElementId =messageElement.GetAttribute(UmlModel.RECEIVE_EVENT_ATTR_NAME);
			
			if(startMessageElementId.Equals(currEventElementId))
			{
				oppositeMessageEndElementId=messageElement.GetAttribute(UmlModel.SEND_EVENT_ATTR_NAME);
			}
			else
			{
				oppositeMessageEndElementId = messageElement.GetAttribute(UmlModel.SEND_EVENT_ATTR_NAME);
			}
			
			query=MESSAGE_OCCURRENCE_ELEMENT_FOR_ID_QUERY_START+oppositeMessageEndElementId+QUERY_END;
			oppositeMessageEndElement=(XmlElement)interactionElement.SelectSingleNode(query,this.namespaceManager);
			
			if (oppositeMessageEndElement == null)
			{
				query=FORMAL_GATE_ELEMENT_FOR_ID_QUERY_START +oppositeMessageEndElementId+QUERY_END;
				oppositeMessageEndElement=(XmlElement)interactionElement.SelectSingleNode(query,this.namespaceManager);
			}
			
			return oppositeMessageEndElement;
			
		}
			
			
		public XmlElement GetMessageElementForMessageOccurrenceSpec(XmlElement messageOccurrenceSpecElement)
		{
			XmlElement relevantMessageElement=null;
			XmlElement interactionElement=(XmlElement)messageOccurrenceSpecElement.ParentNode;
			string messageAttributeValue=messageOccurrenceSpecElement.GetAttribute(UmlModel.MESSAGE_ATTR_NAME);
			string query=MESSAGE_ELEMENT_FOR_MESSAGE_OCCURRENCE_QUERY_START+messageAttributeValue+QUERY_END;
			relevantMessageElement=(XmlElement)interactionElement.SelectSingleNode(query,this.namespaceManager);
			return relevantMessageElement;
		}
		
		public XmlElement GetEventElementForMessageEnd(XmlElement messageEnd)
		{
			XmlElement relevantEventElement=null;
			XmlElement interactionElement=(XmlElement)messageEnd.ParentNode;
			XmlElement modelElement=(XmlElement)interactionElement.ParentNode;
			string b=messageEnd.GetAttribute("name");
			string relevantEventElementId=messageEnd.GetAttribute(UmlModel.EVENT_ATTR_NAME);
			string query=EVENT_ELEMENT_FOR_MESSAGE_QUERY_START+relevantEventElementId+QUERY_END;
			relevantEventElement=(XmlElement)modelElement.SelectSingleNode(query,this.namespaceManager);
			return relevantEventElement;
		}
		
		public XmlNodeList GetOccurrenceSpecificationElementsForLifeline(XmlElement interactionElement,string lifelineElementId)
		{
			XmlNodeList occurrenceSpecificationElements=null;
			string query=OCCURRENCE_SPECIFICATION_ELEMENTS_FOR_LIFELINE_ID_QUERY+lifelineElementId+QUERY_END;
			occurrenceSpecificationElements=interactionElement.SelectNodes(query,namespaceManager);
			return occurrenceSpecificationElements;
		}
		
		public bool IsLifelineDestructed(XmlElement interactionElement, string lifelineElementId)
		{
			bool isLifelineDestructed=false;
			XmlElement currentOccurrenceSpecificationElement;
			string currentOccurrenceSpecificationElementEventAttrValue;
			XmlElement currentDestructionEventElement;
			string currentDestructionEventElementId;
			XmlNodeList occurrenceSpecificationElements=this.GetOccurrenceSpecificationElementsForLifeline(interactionElement,lifelineElementId);
			IEnumerator itrOccurrenceSpecificationElements= occurrenceSpecificationElements.GetEnumerator();
			XmlNodeList destructionEventElements=this.GetDestructionEventElements(interactionElement);
			IEnumerator itrDestructionEventElements=destructionEventElements.GetEnumerator();
			
			while((itrOccurrenceSpecificationElements.MoveNext())&&(!isLifelineDestructed))
			{
				currentOccurrenceSpecificationElement=(XmlElement)itrOccurrenceSpecificationElements.Current;
				currentOccurrenceSpecificationElementEventAttrValue=
											currentOccurrenceSpecificationElement.GetAttribute(UmlModel.EVENT_ATTR_NAME);
				
				while((itrDestructionEventElements.MoveNext())&&(!isLifelineDestructed))
				{
					currentDestructionEventElement=(XmlElement)itrDestructionEventElements.Current;
					currentDestructionEventElementId=currentDestructionEventElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
					
					if(currentOccurrenceSpecificationElementEventAttrValue.Equals(currentDestructionEventElementId))
					{
						isLifelineDestructed=true;
					}
				}
				
				itrDestructionEventElements.Reset();
			}
			
			return isLifelineDestructed;
		}
		
		
		public String GetEventKindForFormalGateXmlElement(XmlElement formalGateElement,XmlElement messageElement)
		{
			String eventKind=  "";
			string formalGateElementId=formalGateElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string sendEventId=messageElement.GetAttribute(UmlModel.SEND_EVENT_ATTR_NAME);
			string receiveEventId=messageElement.GetAttribute(UmlModel.RECEIVE_EVENT_ATTR_NAME);
			
			if(formalGateElementId.Equals(sendEventId))
			{
			
				eventKind= MessageEventKind.SEND_EVENT.ToString();
			}
			else if(formalGateElementId.Equals(receiveEventId))
			{
				eventKind= MessageEventKind.RECEIVING_EVENT.ToString();
			}
			
			return eventKind;
		}
	}
}
