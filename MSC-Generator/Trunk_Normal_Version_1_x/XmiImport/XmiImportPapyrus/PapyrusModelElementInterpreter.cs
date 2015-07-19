/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 27.11.2007
 * Zeit: 13:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmiExport;
using xmiImport;
using xmiImportPapyrus;
using nGenerator;
using mscElements;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of PapyrusModelElementInterpreter.
	/// </summary>
	
	
	
	public class PapyrusModelElementInterpreter:ModelElementInterpreter
	{
		private const string  HREF_ATTRIBUTE_NAME="href";
		private const string  HREF_ATTRIBUTE_VALUE="pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml#_0";
		
		public override XmlElement InterpretModelElement(XmlDocument xmiDocument)
		{
			XmlElement modelElement=xmiDocument.DocumentElement;
			bool isCorrectModelElement=ValidateModelElement(modelElement);
			
			if(isCorrectModelElement)
			{
				CreateMSCHeaderEntry(modelElement);
			}
			else
			{
				modelElement=null;
			}
			
			return modelElement;
		}
		
		///////////////////////todo///
		private void CreateMSCHeaderEntry(XmlElement modelElement)
		{
			string modelName=modelElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			
			if(modelName.Length>0)
			{
				
			}
		}
		
		private bool ValidateModelElement(XmlElement modelElement)
		{
			bool isValidModelElement=false;
			
			if(modelElement!=null)
			{
				bool isCorrectModelElementType=XmiElementValidator.IsExpectedQualifiedElementName(modelElement,
			    	                                                                              UmlModel.UML_MODEL,
			        	                                                                          UmlModel.UML_NAMESPACE_PREFIX);
				bool isCorrectXmiVersion=IsCorrectXmiVersion(modelElement);
				bool isCorrectPackageImportElement=IsCorrectPackageImportElement(modelElement);
			
				if(isCorrectModelElementType&&isCorrectXmiVersion&&isCorrectPackageImportElement)
				{
					isValidModelElement=true;	
				}
			}
			return isValidModelElement;
		}
		
		private bool IsCorrectXmiVersion(XmlElement element)
		{
			bool isCorrectXmiVersion=false;
			string actualXmiVersion=element.GetAttribute(UmlModel.XMI_VERSION_ATTR_NAME);
			
			if(UmlModel.XMI_VERSION.Equals(actualXmiVersion))
			{
				isCorrectXmiVersion=false;
			}
			return isCorrectXmiVersion;
		}
		
		private bool IsCorrectPackageImportElement(XmlElement modelElement)
		{
			XmlElement packageImportElement=(XmlElement)modelElement.FirstChild;
			bool isCorrectPackageImportElement=false;
			bool hasCorrectElementType=XmiElementValidator.IsExpectedLocalName(packageImportElement,XmiElementTypes.PACKAGE_IMPORT);
			bool hasXmiIdAttribute=XmiElementValidator.HasXmiIdAttributeValue(packageImportElement);
			bool isCorrectImportedPackageElement=IsCorrectImportedPackageElement(packageImportElement);
			
			if(isCorrectPackageImportElement&&hasCorrectElementType&&hasXmiIdAttribute&&isCorrectImportedPackageElement)
			{
				isCorrectPackageImportElement=true;
			}
			
			return isCorrectPackageImportElement;	
		}
		
		private bool IsCorrectImportedPackageElement(XmlElement packageImportElement)
		{
			XmlElement importedPackageElement=(XmlElement)packageImportElement.FirstChild;
			bool isCorrectImportedPackage=false;
			
			bool isExpectedElement=XmiElementValidator.IsExpectedElement(importedPackageElement,XmiElementTypes.IMPORTED_PACKAGE,UmlModel.UML_MODEL);
			bool hasXmiIdAttributeValue=XmiElementValidator.HasXmiIdAttributeValue(importedPackageElement);
			bool isExpectedHrefAttrValue=XmiElementValidator.IsExpectedAttributeValue(importedPackageElement,HREF_ATTRIBUTE_NAME,HREF_ATTRIBUTE_VALUE);
			
			if(isExpectedElement&&hasXmiIdAttributeValue&&isExpectedHrefAttrValue)
			{
				isCorrectImportedPackage=true;
			}
			return isCorrectImportedPackage;
		}
	}
}
