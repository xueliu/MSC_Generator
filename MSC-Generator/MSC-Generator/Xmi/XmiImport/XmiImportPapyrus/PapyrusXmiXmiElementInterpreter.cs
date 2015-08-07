/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.01.2008
 * Zeit: 18:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmi;
using xmiPapyrus;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of PapyrusXmiXmiElementInterpreter.
	/// </summary>
	public class PapyrusXmiXmiElementInterpreter:XmiElementInterpreter
	{
		private const string PAPYRUS_DI_FILE_XMI_VERSION="2.0";
		private const string FIRST_DIAGRAM_ELEMENT_QUERY="//di2:Diagram[1]";
		private const string FIRST_ELEMENT_ELEMENT_QUERY="//di2:Diagram[1]/owner/element[@xsi:type='uml:Model']";
		private const string POINT_STRING=".";
		private const int UML_DIAMOND_PREFIX_LENGTH=4;
		private const int ZERO_INDEX=0;
		
		public XmlElement InterpretXmiElement(XmlDocument xmiDIDocument,XmlElement correspondingModelElement)
		{
			XmlElement xmiElement=xmiDIDocument.DocumentElement;
			ValidateXmiElement(xmiElement,correspondingModelElement);
			
			
			//XmlElement elementElement=(XmlElement)xmiElement.SelectSingleNode(ELEMENT_ELEMENT_HREF_ATTR_VALUE_QUERY);
			
			
			return xmiElement;
		}
		
		public override void InitNamespaceManager(XmlNameTable nameTable)
		{
			namespaceManager=new PapyrusXmiDiNamespaceManager(nameTable);
		}
		
		private void ValidateXmiElement(XmlElement xmiElement,XmlElement modelElement)
		{
			if(xmiElement==null)
			{
				throw new System.Xml.XmlException();
			}
			
			bool isCorrectXmiElementType=XmiElementValidator.IsExpectedQualifiedElementName(xmiElement,UmlModel.XMI_ELEMENT_NAME,UmlModel.XMI_NAMESPACE_PREFIX);
			
			if(!isCorrectXmiElementType)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
			
			bool isCorrectXmiVersion=XmiElementValidator.IsCorrectXmiVersion(xmiElement,PAPYRUS_DI_FILE_XMI_VERSION);
			
			if(!isCorrectXmiVersion)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
			
			ValidateDiagramElement(xmiElement);
			ValidateElementElement(xmiElement,modelElement);
		}
		
		private void ValidateDiagramElement(XmlElement xmiElement)
		{
			XmlElement diagramElement=(XmlElement)xmiElement.SelectSingleNode(FIRST_DIAGRAM_ELEMENT_QUERY,namespaceManager);
			
			if(diagramElement==null)
			{
				throw new System.Xml.XmlException("kein Diagram Element");
			}
		}
		
		private void ValidateElementElement(XmlElement xmiElement,XmlElement modelElement)
		{
			XmlElement elementElement=(XmlElement)xmiElement.SelectSingleNode(FIRST_ELEMENT_ELEMENT_QUERY,namespaceManager);
			
			if(elementElement==null)
			{
				throw new System.Xml.XmlException("kein ElementElement");
			}
			
			ValidateModelDocumentReference(elementElement,modelElement);	
		}
			
		private void ValidateModelDocumentReference(XmlElement elementElement,XmlElement modelElement)
		{
			string modelName=modelElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			string modelId=modelElement.GetAttribute(UmlModel.XMI_ID_ATTR_COMPLETE_NAME);
			string elementHref=elementElement.GetAttribute(UmlModel.HREF_ATTR_NAME);
			
			if(elementHref.Length<1)
			{
				throw new System.Xml.XmlException("keine Referenz auf das Modell-Dokument");
			}
			
			string hrefModelName=GetModelNameFromModelRef(elementHref);
			string hrefModelId=GetModelIdFromModelRef(elementHref);
			
			if(!(modelName.Equals(hrefModelName)))
			{
				throw new System.Xml.XmlException("der Modellname ist unkorrekt");
			}
			
			if(!(modelId.Equals(hrefModelId)))
			{
			     throw new System.Xml.XmlException("die Modell-Id ist unkorrekt");  	
			}
		}
		
		private string GetModelNameFromModelRef(string elementHref)
		{
			string modelName="";
			int positionPoint=elementHref.IndexOf(POINT_STRING);
			modelName=elementHref.Substring(ZERO_INDEX,positionPoint);
			return modelName;	
		}
		
		private string GetModelIdFromModelRef(string elementHref)
		{
			string modelId="";
			int positionPoint=elementHref.IndexOf(POINT_STRING);
			modelId=elementHref.Substring(positionPoint+UML_DIAMOND_PREFIX_LENGTH+1);
			return modelId;
		}
	}
}
