/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.01.2008
 * Zeit: 16:22
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using xmiImport;
using xmi;
using xmiPapyrus;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of XmiPapyrusDocumentImport.
	/// </summary>
	/// 
	public class PapyrusXmiDocumentImport:XmiDocumentImport
	{
		private const string UML_ENDING="uml files (*.uml)|*.uml";
		private const string DI2_ENDING="di2 files (*.di2)|*.di2";
		private const int ZERO_INT=0;
		private XmlDocument loadedXmiModelDocument;
		private XmlDocument loadedXmiDIDocument;
		private PapyrusXmiModelElementInterpreter modelElementInterpreter;
		private PapyrusXmiXmiElementInterpreter xmiElementInterpreter;
		
		public PapyrusXmiDocumentImport():base()
		{
			loadedXmiModelDocument=new XmlDocument();
			loadedXmiDIDocument=new XmlDocument();
			modelElementInterpreter=new PapyrusXmiModelElementInterpreter();
			xmiElementInterpreter=new PapyrusXmiXmiElementInterpreter() ;
		}
		
		public override ArrayList [] ImportXmiDocument()
		{   
			ArrayList [] editorContentDiagrams=null;;
			
			string modelFilename;
       		string diFilename;
       		string modelDocumentName;
       		
       		try
       		{
       			modelFilename=GetPapyrusModelFilename();
       		}
       		catch(System.Exception ex)
       		{
       			MessageBox.Show(ex.Message,"Fehler",MessageBoxButtons.OK,MessageBoxIcon.Stop);
       			return null;
       		}
       		
       		try
       		{
       			diFilename=GetPapyrusDiFilename();;
       		}
       		catch(System.Exception ex)
       		{
       			MessageBox.Show(ex.Message,"Fehler",MessageBoxButtons.OK,MessageBoxIcon.Stop);
       			return null;
       		}	
			
       		modelDocumentName=this.GetModelDocumentNameForFileName(modelFilename);
       		InitProperties(modelDocumentName);
       		
       		try
       		{
				this.ModelElement =LoadXmiModelDocument(modelFilename);
       		}
       		catch(System.Xml.XmlException ex)
       		{
       			MessageBox.Show(ex.Message,"Fehler",MessageBoxButtons.OK,MessageBoxIcon.Stop);
       			return null;
       		}
       		
       		try
       		{
				this.XmiElement=LoadXmiDIDocument(diFilename,this.ModelElement);
			}
       		catch(System.Xml.XmlException ex)
       		{
       			MessageBox.Show(ex.Message,"Fehler",MessageBoxButtons.OK,MessageBoxIcon.Stop);
       			return null;
       		}
				
			editorContentDiagrams=InterpretInteractionElements(this.ModelElement,this.XmiElement);
			return editorContentDiagrams;
		}
		
		private void InitProperties(string modelName)
		{
			XmiModelDocumentInterpreter modelDocumentInterpreter=new XmiModelDocumentInterpreter();
       		XmiDIDocumentInterpreter diDocumentInterpreter=new PapyrusXmiDIDocumentInterpreter(modelName);
       		SequenceChartModelInterpreter modelInterpreter=new SequenceChartModelInterpreter();
       		SequenceChartModelCreator modelCreator=new SequenceChartModelCreator(modelDocumentInterpreter,diDocumentInterpreter);
       		this.ModelCreator=modelCreator;
       		this.ModelInterpreter=modelInterpreter;
       		this.modelElementInterpreter.InitNamespaceManager(this.loadedXmiModelDocument.NameTable);
       		this.xmiElementInterpreter.InitNamespaceManager(this.loadedXmiModelDocument.NameTable);
		}
			
		private XmlElement LoadXmiModelDocument(string xmiDocumentFileName)
		{
			loadedXmiModelDocument.Load(xmiDocumentFileName);
			XmlElement modelElement=modelElementInterpreter.InterpretModelElement(loadedXmiModelDocument);
				
			if(modelElement!=null)
			{
				PapyrusXmiModelNamespaceManager namespaceManager=
								new PapyrusXmiModelNamespaceManager(this.loadedXmiModelDocument.NameTable);
				this.ModelCreator.ModelDocumentInterpreter.NamespaceManager=namespaceManager;
			}
				
			return modelElement;
		}
		
		private XmlElement LoadXmiDIDocument(string xmiDocumentFileName,XmlElement modelElement)
		{
			XmlElement xmiElement;
			loadedXmiDIDocument.Load(xmiDocumentFileName);
			xmiElement=this.xmiElementInterpreter.InterpretXmiElement(loadedXmiDIDocument, modelElement);
			
			if(xmiElement!=null)
			{
				this.ModelCreator.DiDocumentInterpreter.InitNamespaceManager(loadedXmiDIDocument);
			}
			return xmiElement;
		}
		
		protected string GetPapyrusModelFilename()
       	{
       		string modelFilename="";
       		OpenFileDialog openModelFileDialog=new OpenFileDialog();
       		openModelFileDialog.Title="Öffnen der Modell-Datei";
       		openModelFileDialog.Filter=UML_ENDING;
       		DialogResult dialogResult=openModelFileDialog.ShowDialog();
       		
       		if(dialogResult==DialogResult.OK)
       		{
       			modelFilename=openModelFileDialog.FileName;
       		}
       		
       		if(modelFilename.Length==ZERO_INT)
       		{
       			throw new Exception(ErrorMessages.ERROR_MESSAGE_WRONG_FILENAME);
       		}
       		
       		return modelFilename;
       	}
       
       protected string GetPapyrusDiFilename()
       {
       		string diFilename="";
       		OpenFileDialog openDiFileDialog=new OpenFileDialog();
       		openDiFileDialog.Title="Öffnen der Diagram-Interchange-Datei";
       		openDiFileDialog.Filter=DI2_ENDING;
       		DialogResult dialogResult=openDiFileDialog.ShowDialog();
       		
       		if(dialogResult==DialogResult.OK)
       		{
       			diFilename=openDiFileDialog.FileName;
       		}
       		
       		if(diFilename.Length==ZERO_INT)
       		{
       			throw new Exception(ErrorMessages.ERROR_MESSAGE_WRONG_FILENAME);
       		}
       		
       		return diFilename;
       }
	}
}
