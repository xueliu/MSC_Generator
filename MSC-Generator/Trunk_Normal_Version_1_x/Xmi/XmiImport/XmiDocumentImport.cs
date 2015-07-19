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
using sequenceChartModel;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiDocumentImport.
	/// </summary>
	/// 
	
	public class XmiDocumentImport
	{
		private SequenceChartModelCreator sequenceChartModelCreator;
		
		public XmiDocumentImport(SequenceChartModelCreator sequenceChartModelCreator)
		{
			this.sequenceChartModelCreator=sequenceChartModelCreator;
		}
		
		public void ImportXmiDocument(string fileName)
		{
			XmlElement modelElement =sequenceChartModelCreator.ModelDocumentInterpreter.LoadXmiModelDocument(fileName);
			InterpretInteractionElements(modelElement);
		}
		
		private void InterpretInteractionElements(XmlElement modelElement)
		{
			XmlNodeList interactionElements=sequenceChartModelCreator.ModelDocumentInterpreter.GetInteractionElements(modelElement);
			IEnumerator itrInteractionElements=interactionElements.GetEnumerator();
			XmlElement currentInteractionElement;
			
			while(itrInteractionElements.MoveNext())
			{
				currentInteractionElement=(XmlElement)itrInteractionElements.Current;
				InterpretInteractionElement(currentInteractionElement);
			}
		}
		
		private Interaction InterpretInteractionElement(XmlElement interactionElement)
		{
			Interaction currentInteraction=
					sequenceChartModelCreator.CreateInteractionForInteractionElement(interactionElement);
			return currentInteraction;
		}
	}
}
