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
using xmiExport;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of PapyrusXmiDIDocumentInterpreter.
	/// </summary>
	public class PapyrusXmiDIDocumentInterpreter:XmiDIDocumentInterpreter
	{
		
		private const string PAPYRUS_DI_NAMESPACE_PREFIX="di2";
		private const string PAPYRUS_DI_NAMESPACE_URI="http://www.papyrusuml.org";
		private const string XMI_NAMESPACE_PREFIX="xmi";
		private const string XMI_NAMESPACE_URI="http://www.omg.org/XMI";
		private const string XSI_NAMESPACE_PREFIX="xsi";
		private const string XSI_NAMESPACE_URI="http://www.w3.org/2001/XMLSchema-instance";
		private const string UML_NAMESPACE_PREFIX="uml";
		private const string UML_NAMESPACE_URI="http://www.eclipse.org/uml2/2.1.0/UML";
		private const string ELEMENT_TYPE_LIFELINE_FOR_ID_QUERY="//contained/semanticModel/element[@xsi:type='uml:Lifeline' href='";
		private const string ELEMENT_TYPE_MESSAGE_OCCURRENCE_SPEC_FOR_ID_QUERY="//contained/semanticModel/element[@xsi:type='uml:MessageOccurrenceSpecification' href='";
		private const string ELEMENT_TYPE_BEHAVIOR_EXECUTION_SPEC_FOR_ID_QUERY="//contained/semanticModel/element[@xsi:type='uml:BehaviorExecutionSpecification' href='";
		private const string ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY="//contained/semanticModel/element[@xsi:type='uml:Message' href=']";
		private const string SECOND_DIAGRAM_ELEMENT_QUERY="//Diagram";
		private const string DOUBLE_POINT=":";
		private const int INDEX_ZERO=0;
		
		private XmlDocument xmiDIDocument;
		private XmlNamespaceManager namespaceManager;
		
		public PapyrusXmiDIDocumentInterpreter():base(){}
		
		public PapyrusXmiDIDocumentInterpreter(XmlDocument xmiDIDocument,XmlNamespaceManager namespaceManager):base(xmiDIDocument,namespaceManager){}
		
		protected void InitNamespaceManager()
		{
			namespaceManager.AddNamespace(PAPYRUS_DI_NAMESPACE_PREFIX,PAPYRUS_DI_NAMESPACE_URI);
			namespaceManager.AddNamespace(XMI_NAMESPACE_PREFIX,XMI_NAMESPACE_URI);
			namespaceManager.AddNamespace(XSI_NAMESPACE_PREFIX,XSI_NAMESPACE_URI);
			namespaceManager.AddNamespace(UML_NAMESPACE_PREFIX,UML_NAMESPACE_URI);
		}
		
		public Point GetPositionForElement(XmlElement diagramElement,XmlElement relevantElement,string queryStart)
		{
			Point relevantElementPosition=null;
			string relevantElementId=relevantElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			XmlElement relevantElementGraphNode=this.GetGraphNodeForId(diagramElement,relevantElement,queryStart);
			string relevantElementPositionString=relevantElementGraphNode.GetAttribute(UmlModel.POSITION_ATTR_NAME);
			relevantElementPosition=GetPositionForPositionString(relevantElementPositionString)	
			return relevantElementPosition;			
		}
		
		public Point GetLifelineGraphNodePosition(XmlElement diagramElement,XmlElement lifelineElement)
		{
			Point lifelinePosition=GetPositionForElement(diagramElement,lifelineElement,ELEMENT_TYPE_LIFELINE_FOR_ID_QUERY);
			return lifelinePosition;
		}
		
		public XmlElement GetMessageGraphNodePosition(XmlElement diagramElement, XmlElement messageElement)
		{
			XmlElement foundMessageGraphNode=this.GetPositionForElement(diagramElement,messageElement,ELEMENT_TYPE_MESSAGE_FOR_ID_QUERY);
			return foundMessage;
		}
		
		public Point GetBehaviorExecutionSpecPosition(XmlElement diagramElement,XmlElement executionElement)
		{
			Point executionPosition=this.GetPositionForElement(diagramElement,executionElement,ELEMENT_TYPE_BEHAVIOR_EXECUTION_SPEC_FOR_ID_QUERY);
			return executionPosition;
		}
		
		public Point GetMessageOccurrenceSpecGraphNodePosition(XmlElement diagramElement,XmlElement messageOccurrenceSpecElement)
		{
			Point messageOccurrenceSpecPosition=this.GetPositionForElement(diagramElement,messageOccurrenceSpecElement,);
			return messageOccurrenceSpecPosition;
		}
	}
}
