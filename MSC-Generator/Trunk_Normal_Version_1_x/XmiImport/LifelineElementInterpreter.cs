/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 06.12.2007
 * Zeit: 09:04
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
	/// Description of LifelineElementInterpreter.
	/// </summary>
	public class LifelineElementInterpreter:XmiElementInterpreter
	{
		public LifelineElementInterpreter(XmiDocumentImport documentImport):base(documentImport){}
		
		public ArrayList GetLifelinePositions(XmlElement interactionElement,XmlElement diagramElement)
		{
			Point currentLifelinePosition;
			ArrayList lifelineElements=DocumentImport.ModelDocumentInterpreter.GetLifelineElements(interactionElement);
			ArrayList lifelineProperties=new ArrayList();
			int countLifelineElements=lifelineElements.Count;
			XmlElement currentLifelineElement;
			LifelineProperty currentLifelineProperty;
						
			for(int index=0;index<countLifelineElements;index++)
			{
				currentLifelineElement=(XmlElement)lifelineElements[index];
				currentLifelinePosition=DocumentImport.DiDocumentInterpreter.GetLifelinePosition(diagramElement,currentLifelineElement);
				currentLifelineProperty=new LifelineProperty(currentLifelineElement,currentLifelineElementPositionPair.X,currentLifelineProperty.Y);
				lifelineProperties.Add(currentLifelineProperty);
			}
			
			return lifelineProperties;
		}
		
		public ArrayList CreateLifelineEditorEntries(ArrayList lifelineProperties)
		{
			LifelineProperty currentLifelineProperty;
			string relevantLifelineName;
			XmlElement currentLifelineElement;
			XmlElement relevantLifelineElement;
			int indexRelevantLifelineElement;
			int greatestX=-1;
			int currentLifelineX;
			int lifelinePropertiesCount=lifelineProperties.Count;
			LifelineProperty arrangedLifelineProperty=new LifelineProperties(null,-1,-1);
			IEnumerator itrLifelineProperties=lifelineProperties.GetEnumerator();
			ArrayList orderedLifelineProperties=new ArrayList();
			
			for(int index1=0;index<lifelinePropertiesCount;index1++)
			{
				for(int index2=0;index<lifelinePropertiesCount;index2++)
				{
					currentLifelineProperty=(LifelineProperty)lifelineProperties[index2];
					currentLifelineX=currentLifelineProperty.x;
						
					if(currentLifelineX>greatestX)
					{
						relevantLifelineElement=currentLifelineProperty.lifelineElement;
						greatestX=currentLifelineProperty.x;
						indexRelevantLifelineElement=index2;
					}
				}
				
				relevantLifelineName=relevantLifelineElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
				entryCreator.CreateProcessEditorEntry(relevantLifelineName);
				orderedLifelineProperties.Add(relevantLifelineProperty);
				lifelineProperties.Insert(arrangedLifelineProperty,indexRelevantLifelineElement);	
			}
			return orderedLifelineProperties;
		}
	}
}
