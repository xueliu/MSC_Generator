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
using xmiImportPapyrus;
using xmi;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiDocumentImport.
	/// </summary>
	/// 
	
	public abstract class XmiDocumentImport
	{
		private SequenceChartModelCreator modelCreator;
		private SequenceChartModelInterpreter modelInterpreter;
		private XmlElement modelElement;
		private XmlElement xmiElement;
		private const string BACKSLASH_STRING="\\";
		private const string POINT_STRING=".";
		
		public XmiDocumentImport()
		{
			this.modelInterpreter=new SequenceChartModelInterpreter();
		}
		
		public SequenceChartModelCreator ModelCreator{
			
			get{
				return modelCreator;
			}
			set{
				modelCreator=value;
			}
		}
		
		public SequenceChartModelInterpreter ModelInterpreter{
			get{
				return modelInterpreter;
			}
			set{
				modelInterpreter=value;
			}
		}
		
		public XmlElement ModelElement{
			
			get{
				return modelElement;
			}
			set{
				modelElement=value;
			}
		}
		
		public XmlElement XmiElement{
			
			get{
				return xmiElement;
			}
			set{
				xmiElement=value;
			}
		}
		
		
		public abstract ArrayList [] ImportXmiDocument();
		
		
		// Interprets all XML-Interaction-Elements contained in a Model-XML-Element
		protected internal ArrayList[] InterpretInteractionElements(XmlElement modelElement, XmlElement xmiElement)
		{
			ArrayList [] editorContentDiagrams;
			XmlNodeList interactionElements=modelCreator.ModelDocumentInterpreter.GetInteractionElements(modelElement);
			editorContentDiagrams=new ArrayList[interactionElements.Count];
			IEnumerator itrInteractionElements=interactionElements.GetEnumerator();
			XmlElement currentInteractionElement;
			XmlElement currentDiagramElement;
			ArrayList editorContentCurrentDiagram;
			int index=0;
			
			while(itrInteractionElements.MoveNext())
			{
				currentInteractionElement=(XmlElement)itrInteractionElements.Current;
				currentDiagramElement=
						modelCreator.DiDocumentInterpreter.GetDiagramElement(xmiElement,index+2);
				
				// Interprets the current Interaction-XML-Element 
				// and returns the corresponding MSC-editor-content
				editorContentCurrentDiagram=
							InterpretInteractionElement(currentInteractionElement,currentDiagramElement);
				editorContentDiagrams[index]=editorContentCurrentDiagram;
				index++;
			}
			return editorContentDiagrams;
		}
		
		// Interprets the relevant Interaction-XML-Element 
		// and returns the corresponding MSC-editor-content
		protected internal ArrayList InterpretInteractionElement(XmlElement interactionElement,XmlElement relevantDiagramElement)
		{
			// Creates the according Interaction-MSC-Element to the relavant Interaction-XML-Element 
			Interaction currentInteraction=
					modelCreator.CreateInteractionForInteractionElement(interactionElement,relevantDiagramElement);
			//Interprets the current Interaction-MSC-Element
			// and returns the corresponding MSC-editor-content
			ArrayList interactionEditorContent=
					this.modelInterpreter.InterpretSequenceChartModel(currentInteraction);
			
			return interactionEditorContent;
		}
		
		//Extracts the name of the UML-Model from the relevant filename
		protected internal string GetModelDocumentNameForFileName(string modelFilename)
       	{
       		string modelName;
       		int indexLastBackslash=modelFilename.LastIndexOf(BACKSLASH_STRING);
       		int indexLastPoint=modelFilename.LastIndexOf(POINT_STRING);
       		int modelNameLength=indexLastPoint-indexLastBackslash;
       		modelName=modelFilename.Substring(indexLastBackslash+1,modelNameLength-1);
       		return modelName;
       }
	}
}
