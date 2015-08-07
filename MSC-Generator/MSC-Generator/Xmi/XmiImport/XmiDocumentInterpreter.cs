/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 14:23
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using xmiImport;
using xmiImportPapyrus;
using xmiExport;
using nGenerator;
using mscElements;

namespace xmiImport
{
	/// <summary>
	/// Description of XmiImport.
	/// </summary>
	public class XmiDocumentInterpreter
	{
		private EditorEntryCreator mscEditorConentCreator;
		private const string EMPTY_STRING="";
		private XmlNamespaceManager namespaceManager;
		private XmlDocument loadedXmiDocument;
		private const string INTERACTION_ELEMENTS_QUERY="//packagedElement[@xmi:type='uml:Interaction']";
		private ModelElementInterpreter modelElementInterpreter;
		
		public XmiDocumentInterpreter(EditorEntryCreator mscEditorConentCreator)
		{
			this.mscEditorConentCreator=mscEditorConentCreator;
			loadedXmiDocument=new XmlDocument();
			modelElementInterpreter=new PapyrusModelElementInterpreter();
			namespaceManager=new XmlNamespaceManager(loadedXmiDocument.NameTable);
			namespaceManager.AddNamespace(UmlModel.UML_NAMESPACE_PREFIX,UmlModel.UML_NAMESPACE_URI);
			namespaceManager.AddNamespace(UmlModel.XMI_NAMESPACE_PREFIX,UmlModel.XMI_NAMESPACE_URI);
		}
		
		public XmlElement LoadXmiDocument(string xmiDocumentFileName)
		{
			loadedXmiDocument.Load(xmiDocumentFileName);
			
			XmlElement modelElement=modelElementInterpreter.InterpretModelElement(loadedXmiDocument);
			
			if(modelElement==null)
			{
				//exception
			}
			else
			{
				
			}
			return modelElement;
		}
		
		public XmlNodeList GetInteractionElements(XmlElement modelElement)
		{
			XmlNodeList modelElementList=modelElement.SelectNodes(INTERACTION_ELEMENTS_QUERY,namespaceManager);
			return modelElementList;
		}
		
		public void InterpretInteractionElement(XmlElement interactionElement)
		{
			string interactionName=interactionElement.GetAttribute(UmlModel.NAME_ATTR_NAME);
			
			
		}
		
		
			
			
			
		
		
		
	}
}
