/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 04.12.2007
 * Zeit: 14:29
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Xml;
using System.Drawing;
using xmiImport;
using xmiExport;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiDocumentImport.
	/// </summary>
	/// 
	
	public class XmiDocumentImport
	{
		private XmlElement modelElement;
		private XmlElement interactionElement;
		private SequenceChartModelCreator sequenceChartModelCreator;
		private EditorEntryCreator entryCreator;
		private ArrayList lifelineProperties;
		private ArrayList orderedLifelineProperties;
		
		public XmiDocumentImport(SequenceChartModelCreator sequenceChartModelCreator)
		{
			this.sequenceChartModelCreator=sequenceChartModelCreator.SequenceChartModelCreator;
		}
		
		public void ImportXmiDocument(string fileName)
		{
			modelElement =ModelDocumentInterpreter.LoadXmiModelDocument(fileName);
			InterpretInteractionElements(modelElement);
		}
		
		private void InterpretInteractionElements(XmlElement modelElement)
		{
			XmlNodeList interactionElements=sequenceChartModelCreator.ModelDocumentInterpreter.GetInteractionElements(modelElement);
			IEnumerator itrInteractionElements=interactionElements.GetEnumerator();
			XmlElement currentInteractionElement;
			
			while(itrInteractionElements.MoveNext)
			{
				currentInteractionElement=(XmlElement)itrInteractionElements.Current;
				InterpretInteractionElement(currentInteractionElement);
			}
		}
		
		private void InterpretInteractionElement(XmlElement interactionElement)
		{
			this.sequenceChartModelCreator
		}
		
		private void InterpretExecutionElementsOfLifelines()
		{
			IEnumerator itrOrderedLifelineProperties=orderedLifelineProperties.GetEnumerator();
			LifelineProperty currentLifelineProperty;
			XmlElement currentLifelineElement;
			
			while(itrOrderedLifelineProperties.MoveNext())
			{
				currentLifelineProperty=(LifelineProperty)itrOrderedLifelineProperties.Current;
				currentLifelineElement=currentLifelineProperty.lifelineElement;
				InterpretExecutionElementsOfLifeline(currentLifelineElement);
			}
		}
		
		private void InterpretExecutionElementsOfLifeline(XmlElement lifelineElement)
		{
			
			
			
		}
	}
}
