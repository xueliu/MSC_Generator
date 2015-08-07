/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 15.01.2008
 * Zeit: 14:37
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
	/// Description of PapyrusXmiDocumentRootElementInterpreter.
	/// </summary>
	public class PapyrusXmiModelElementInterpreter:XmiElementInterpreter
	{
		private const string  HREF_ATTRIBUTE_NAME="href";
		private const string  HREF_ATTRIBUTE_VALUE="pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml#_0";
		private const string  ELEMENT_ELEMENT_HREF_ATTR_VALUE_QUERY="//owner/element[@xsi:type='uml:Model']";
		private const string  PAPYRUS_MODEL_FILE_XMI_VERSION="2.1";
		
		
		public XmlElement InterpretModelElement(XmlDocument xmiModelDocument)
		{
			XmlElement modelElement=xmiModelDocument.DocumentElement;
			ValidateModelElement(modelElement);
			return modelElement;
		}
		
		public override void InitNamespaceManager(XmlNameTable nameTable)
		{
			namespaceManager=new PapyrusXmiModelNamespaceManager(nameTable);
		}
		
		private void ValidateModelElement(XmlElement modelElement)
		{
			if(modelElement==null)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
			
			bool isCorrectModelElementType=XmiElementValidator.IsExpectedQualifiedElementName(modelElement,UmlModel.UML_MODEL,UmlModel.UML_NAMESPACE_PREFIX);
			
			if(!isCorrectModelElementType)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
			
			bool isCorrectXmiVersion=XmiElementValidator.IsCorrectXmiVersion(modelElement,PAPYRUS_MODEL_FILE_XMI_VERSION);
			
			if(!isCorrectXmiVersion)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
			
			IsCorrectPackageImportElement(modelElement);
		}
		
		
		
		private void IsCorrectPackageImportElement(XmlElement modelElement)
		{
			XmlElement packageImportElement=(XmlElement)modelElement.FirstChild;
			
			if(packageImportElement==null)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
					
			bool hasCorrectElementType=XmiElementValidator.IsExpectedLocalName(packageImportElement,UmlModel.PACKAGE_IMPORT);
			bool hasXmiIdAttribute=XmiElementValidator.HasXmiIdAttributeValue(packageImportElement);
			
			if(!(hasCorrectElementType&&hasXmiIdAttribute))
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}	
			
			IsCorrectImportedPackageElement(packageImportElement);
		}
		
		private void IsCorrectImportedPackageElement(XmlNode packageImportElement)
		{
			var importedPackageElement=(XmlElement)packageImportElement.FirstChild;
			
			if(importedPackageElement==null)
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
			
			bool isExpectedElement=XmiElementValidator.IsExpectedElement(importedPackageElement,UmlModel.IMPORTED_PACKAGE,UmlModel.UML_MODEL);
			bool isExpectedHrefAttrValue=XmiElementValidator.IsExpectedAttributeValue(importedPackageElement,HREF_ATTRIBUTE_NAME,HREF_ATTRIBUTE_VALUE);
			
			if(!(isExpectedElement&&isExpectedHrefAttrValue))
			{
				throw new System.Xml.XmlException(ErrorMessages.ERROR_MESSAGE_BAD_FORMED_MODEL_FILE);
			}
		}
	}
}
