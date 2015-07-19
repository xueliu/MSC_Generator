/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 09:41
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmiExport;
using System.Collections;

namespace xmiImport
{
	/// <summary>
	/// Description of ExecutionElementInterpreter.
	/// </summary>
	public class ExecutionElementInterpreter:XmiElementInterpreter
	{
		public ExecutionElementInterpreter(XmlDocumentImport documentImport):base(documentImport){}
		
		public ArrayList GetExecutionPositionsForLifeline(XmlElement lifelineElement,XmlElement diagramElement)
		{
			Point currentExecutionPosition;
			XmlElement currentExecutionElement;
			ExecutionProperty currentExecutionProperty;
			ArrayList executionElements=DocumentImport.ModelDocumentInterpreter.GetBehaviorExecutionSpecElementsForLifeline(lifelineElement);
			ArrayList executionProperties=new ArrayList();
			int countExecutionElements=executionElements.Count;
					
			for(int index=0;index<countExecutionElements;index++)
			{
				currentExecutionElement=(XmlElement)executionElements[index];
				currentExecutionPosition=DocumentImport.DiDocumentInterpreter.GetExecutionPosition(diagramElement,currentExecutionElement);
				currentExecutionProperty=new ExecutionProperty(currentExecutionElement,currentExecutionElementPositionPair.X,currentExecutionProperty.Y);
				executionProperties.Add(currentExecutionProperty);
			}
			return executionProperties;
		}
		
		
	}
}
