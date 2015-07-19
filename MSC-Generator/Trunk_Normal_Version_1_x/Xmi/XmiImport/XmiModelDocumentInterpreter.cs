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

namespace xmiImport
{
	/// <summary>
	/// Description of XmiImport.
	/// </summary>
	public class XmiModelDocumentInterpreter
	{
	
		private const string EMPTY_STRING="";
		private XmlNamespaceManager namespaceManager;
		private XmlDocument loadedXmiDocument;
		private const string INTERACTION_ELEMENTS_QUERY="//packagedElement[@xmi:type='uml:Interaction']";
		private const string MESSAGE_ELEMENTS_QUERY="//message[@xmi:type='uml:Message']";
		private const string LIFELINE_ELEMENTS_QUERY="//lifeline[@xmi:type='uml:Lifeline']";
		private const string BEHAVIOR_EXECUTION_SPEC_ELEMENTS_QUERY="//fragement[@xmi:type='uml:BehaviorExecutionSpecification']";
		private const string EXECUTION_OCCURRENCE_SPEC_ELEMENTS_FOR_COVERED_QUERY_START="//fragement[@xmi:type='uml:ExecutionOccurrenceSpecification' @covered='";
		private const string QUERY_END="']";
		private const string EXECUTION_SPEC_ELEMENTS_FOR_ID_QUERY_START="//fragement[@xmi:type='uml:BehaviorExecutionSpecification' @xmi:id='";
		private const string MESSAGE_OCCURRENCE_SPEC_ELEMENT_FOR_COVERED_QUERY_START="//fragement[@xmi:type='uml:MessageOccurrenceSpecification' @covered='";
		private const string MESSAGE_ELEMENT_FOR_MESSAGE_QUERY_START="message[@xmi:type='uml:Message' @xmi:id=']";
		
		private ModelElementInterpreter modelElementInterpreter;
		
		public XmiModelDocumentInterpreter()
		{
			loadedXmiDocument=new XmlDocument();
			modelElementInterpreter=new PapyrusModelElementInterpreter();
			namespaceManager=new XmlNamespaceManager(loadedXmiDocument.NameTable);
			namespaceManager.AddNamespace(UmlModel.UML_NAMESPACE_PREFIX,UmlModel.UML_NAMESPACE_URI);
			namespaceManager.AddNamespace(UmlModel.XMI_NAMESPACE_PREFIX,UmlModel.XMI_NAMESPACE_URI);
		}
		
		public XmlElement LoadXmiModelDocument(string xmiDocumentFileName)
		{
			loadedXmiDocument.Load(xmiDocumentFileName);
			
			XmlElement modelElement=modelElementInterpreter.InterpretModelElement(loadedXmiDocument);
			
			if(modelElement==null)
			{
				//exception
			}
			
			return modelElement;
		}
		
		public XmlNodeList GetInteractionElements(XmlElement modelElement)
		{
			XmlNodeList modelElementList=modelElement.SelectNodes(INTERACTION_ELEMENTS_QUERY,namespaceManager);
			return modelElementList;
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
			XmlNodeList behaviorExecutionSpecElementList=interactionElement.SelectNodes(LIFELINE_ELEMENTS_QUERY,namespaceManager);
			return behaviorExecutionSpecElementList;
		}
		
		public ArrayList GetBehaviorExecutionSpecElementsForLifeline(XmlElement lifelineElement)
		{
			XmlElement currentExecutionOccurrenceSpecElement;
			XmlElement currentExecutionSpecElement;
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			string currentExecutionAttrValue;
			string executionSpecElementForIdQuery;
			string lifelineId=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			ArrayList relevantExecutionOccurrenceSpecElements=GetExecutionOccurrenceSpecElementsForLifeline(lifelineElement);
			ArrayList relevantExecutionSpecElements=new ArrayList();
			int count=relevantExecutionOccurrenceSpecElements.Count;
		    
			for(int index=0;index<count;index++)
			{
		    	currentExecutionOccurrenceSpecElement=(XmlElement)relevantExecutionOccurrenceSpecElements[index];
		    	currentExecutionAttrValue=currentExecutionOccurrenceSpecElement.GetAttribute(UmlModel.EXECUTION_ATTR_NAME);
		    	executionSpecElementForIdQuery=EXECUTION_SPEC_ELEMENTS_FOR_ID_QUERY_START+currentExecutionAttrValue+QUERY_END;
		    	currentExecutionSpecElement=(XmlElement)interactionElement.SelectSingleNode(executionSpecElementForIdQuery);
		    	
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
			XmlElement interactionElement=(XmlElement)lifelineElement.ParentNode;
			ArrayList relevantExecutionOccurrenceSpecElements=new ArrayList();
			string lifelineId=lifelineElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string executionOccurrenceSpecElementsQuery=EXECUTION_OCCURRENCE_SPEC_ELEMENTS_FOR_COVERED_QUERY_START+lifelineId+QUERY_END;
			XmlNodeList executionOccurrenceSpecElements=interactionElement.SelectNodes(executionOccurrenceSpecElementsQuery,namespaceManager);
			IEnumerator itrExecutionOccurrenceSpecElements=executionOccurrenceSpecElements.GetEnumerator();
			
			while(itrExecutionOccurrenceSpecElements.MoveNext())
			{
				currentExecutionOccurrenceSpecElement=(XmlElement)itrExecutionOccurrenceSpecElements.Current;
				currentCoveredAttributeValue=currentExecutionOccurrenceSpecElement.GetAttribute(UmlModel.COVERED_ATTR_NAME);
				
				if(lifelineId.Equals(currentCoveredAttributeValue))
				{
					if(!(relevantExecutionOccurrenceSpecElements.Contains(currentExecutionOccurrenceSpecElement)))
					{
						relevantExecutionOccurrenceSpecElements.Add(currentExecutionOccurrenceSpecElement);
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
			relevantMessageOccurenceSpecElements=interactionElement.SelectNodes(query);
			return relevantMessageOccurenceSpecElements;
		}
		
		public XmlElement GetMessageElementForMessageOccurrenceSpec(XmlElement messageOccurrenceSpecElement)
		{
			XmlElement relevantMessageElement=null;
			XmlElement interactionElement=(XmlElement)messageOccurrenceSpecElement.ParentNode;
			string messageOccurrenceSpecElementId=messageOccurrenceSpecElement.GetAttribute(UmlModel.MESSAGE_ATTR_NAME);
			string query=MESSAGE_ELEMENT_FOR_MESSAGE_QUERY_START+messageOccurrenceSpecElementId+QUERY_END;
			relevantMessageElement=(XmlElement)interactionElement.SelectSingleNode(query);
			return relevantMessageElement;
		}
	}
}
