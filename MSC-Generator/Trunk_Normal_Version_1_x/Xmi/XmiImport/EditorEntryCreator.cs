/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 27.11.2007
 * Zeit: 12:16
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using xmiImport;
using xmiExport;
using nGenerator;
using mscElements;
using NumberingEditor;
using System.Collections;
using GeneratorGUI;

namespace xmiImport
{
	public class EditorEntryCreator
	{
		private ArrayList editorContent;
		private ArrayList repertory;
		private const string  PROCESS_IDENTIFIER="process:";
		private const string  MESSAGE_IDENTIFIER="msg:";
		private const string  REGION_BEGIN_IDENTIFIER="regionbegin";
		private const string  REGION_END_IDENTIFIER="regionend";
		private const string  COMMA=",";
		private const string  SEMICOLON=";";
		private const string  PROCESS_ID_PREFIX="p";
		private int processIdCount=0;
		private const string ACTIVATION="Activation";
		private const string DIAGRAM_STYLE_STRING="DiagramStyle: uml";
		private const string DIAGRAM_NAME_STRING="DiagramName: Neues MSC";
		private const string PAGE_SIZE_STRING="PageSize: A4, H";
		private const string PAGE_MARGINS_STRING="PageMargins: 10, 10, 10, 10";
		private const string FONT_STRING="Font: 'Arial', '10', 'Regular'";
		private const string LINE_OFFSET="LineOffset: 20";
		private const string AUTHOR="Author: ''";
		private const string COMPANY="Company: ''";
		private const string DATE="Date: ''";
		private const string VERSION="Version: ''";
		private const string PRINT_FOOT_LINE="PrintFootLine: no";

		
		public EditorEntryCreator()
		{
			InitEditorContent();
		}
		
		public ArrayList EditorContent{
			get{
				return this.editorContent;
			}
		}
		
		
		
		public void CreateInteractionEditorEntry(string fragmentName)
		{
			//////////todo createEditorCommand
		}
		
		public void CreateProcessEditorEntry(string processName)
		{
			string currentProcessId=this.GetCurrentProcessId();
			string newProcessString=PROCESS_IDENTIFIER+currentProcessId+COMMA+processName+COMMA+SEMICOLON;
			this.editorContent.Add(newProcessString);	
		}
		
		public void CreateRegionBeginEditorEntry(string processInstanceId, string regionType)
		{
			string newRegionBeginString=REGION_BEGIN_IDENTIFIER+processInstanceId+COMMA+regionType+SEMICOLON;
			this.editorContent.Add(newRegionBeginString);
		}
		
		public void CreateRegionEndEditorEntry(string processInstanceId)
		{
			string newRegionBeginString=REGION_BEGIN_IDENTIFIER+processInstanceId+SEMICOLON;
			this.editorContent.Add(newRegionBeginString);
		}
		
		public void CreateMessageEditorEntry(string messageName,string firstProcessId,string secondProcessId)
		{
			string newMessageString=MESSAGE_IDENTIFIER+firstProcessId+COMMA+secondProcessId+COMMA+messageName+SEMICOLON;
			this.editorContent.Add(newMessageString);
		}
		
		private string GetCurrentProcessId()
		{
			string currentProcessId;
			processIdCount++;
			currentProcessId=PROCESS_ID_PREFIX+processIdCount;
			return currentProcessId;
		}
		
		private void InitEditorContent()
		{
			this.editorContent=new ArrayList();
			editorContent.Add(DIAGRAM_STYLE_STRING);
			editorContent.Add(DIAGRAM_NAME_STRING);
			editorContent.Add(PAGE_SIZE_STRING);
			editorContent.Add(PAGE_MARGINS_STRING);
			editorContent.Add(FONT_STRING);
			editorContent.Add(LINE_OFFSET);
			editorContent.Add(AUTHOR);
			editorContent.Add(COMPANY);
			editorContent.Add(DATE);
			editorContent.Add(VERSION);
			editorContent.Add(PRINT_FOOT_LINE);
		}
			
			
	}
}
