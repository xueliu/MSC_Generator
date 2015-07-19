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
using sequenceChartModel;

namespace xmiImport
{
	public class EditorEntryCreator
	{
		private ArrayList editorContent;
		private const string  PROCESS_IDENTIFIER="process:";
		private const string  DUMMY_PROCESS_IDENTIFIER="dummyprocess:";
		private const string  MESSAGE_IDENTIFIER="msg:";
		private const string  REGION_BEGIN_IDENTIFIER="regionbegin:";
		private const string  REGION_END_IDENTIFIER="regionend:";
		private const string  CREATE_IDENTIFIER="create:";
		private const string  ONE_SPACE_TAB=" ";
		private const string  COMMA=",";
		private const string  SEMICOLON=";";
		private const string  PROCESS_ID_PREFIX="p";
		private const string  REPLY_MESSAGE_SIGN="*";
		private const string  SYNCH_CALL_SIGN="!";
		private const string  ASYNCH_CALL_SIGN="";
		/*private const string  CREATE_MESSAGE_SIGN="*";
		private const string  DELETE_MESSAGE_SIGN="*";*/
		private const string ACTIVATION="Activation";
		private const string CREATE_STEREOTYPE="<<create>>";
		private const string DIAGRAM_STYLE_STRING="DiagramStyle: uml \n";
		private const string DIAGRAM_NAME_STRING="DiagramName:";
		private const string PAGE_SIZE_STRING="PageSize: A4, H\n";
		private const string PAGE_MARGINS_STRING="PageMargins: 10,10,10,10 \n";
		private const string FONT_STRING="Font: Arial, 10, Regular \n";
		private const string LINE_OFFSET="LineOffset: 20\n";
		private const string AUTHOR="Author: ''\n";
		private const string COMPANY="Company: ''\n";
		private const string DATE="Date: ''\n";
		private const string VERSION="Version: ''\n";
		private const string PRINT_FOOT_LINE="PrintFootLine: no \n\n";
		private const string WORD_WRAP="\n";
		private const string DOUBLE_WORD_WRAP="\n\n";
		private const string REGION_ACTIVATION="Activation";
		private const string DESTRUCTION_EVENT_IDENTIFIER="stop:";
		private const string DEFAULT_INTERACTION_NAME="Interaction_";
		private static int defaultInteractionNameCount=1;
	
		public ArrayList EditorContent{
			get{
				return this.editorContent;
			}
		}
		
	
		
		public string CreateProcessEntryNoWordWrap(string processName,string processId)
		{
			string newProcessEntry="";
			newProcessEntry=PROCESS_IDENTIFIER+ONE_SPACE_TAB+processId+COMMA+ONE_SPACE_TAB+processName+WORD_WRAP;
			this.editorContent.Add(newProcessEntry);
			return newProcessEntry;
		}
		
		public string CreateProcessEntry(string processName,string processId)
		{
			string newProcessEntry="";
			newProcessEntry=PROCESS_IDENTIFIER+ONE_SPACE_TAB+processId+COMMA+ONE_SPACE_TAB+processName+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newProcessEntry);
			return newProcessEntry;
		}
		
		public string CreateDummyProcessEntry(string processId)
		{
			string newProcessEntry="";
			newProcessEntry=DUMMY_PROCESS_IDENTIFIER+ONE_SPACE_TAB+processId+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newProcessEntry);
			return newProcessEntry;
		}
		
		
		public string CreateRegionBeginEditorEntry(string processInstanceId, string regionType)
		{
			string newRegionBeginEntry=REGION_BEGIN_IDENTIFIER+ONE_SPACE_TAB+processInstanceId+COMMA+ONE_SPACE_TAB+regionType+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newRegionBeginEntry);
			return newRegionBeginEntry;
		}
		
		public string CreateRegionBeginEditorEntryNoWordWrap(string processInstanceId, string regionType)
		{
			string newRegionBeginEntry=REGION_BEGIN_IDENTIFIER+ONE_SPACE_TAB+processInstanceId+COMMA+ONE_SPACE_TAB+regionType+WORD_WRAP;
			this.editorContent.Add(newRegionBeginEntry);
			return newRegionBeginEntry;
		}
		
		public string CreateRegionEndEditorEntry(string processInstanceId)
		{
			string newRegionEndEntry=REGION_END_IDENTIFIER+ONE_SPACE_TAB+processInstanceId+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newRegionEndEntry);
			return newRegionEndEntry;
		}
		
		public string CreateRegionEndEditorEntryNoWordWrap(string processInstanceId)
		{
			string newRegionEndEntry=REGION_END_IDENTIFIER+ONE_SPACE_TAB+processInstanceId+WORD_WRAP;
			this.editorContent.Add(newRegionEndEntry);
			return newRegionEndEntry;
		}
		
		protected internal string CreateMessageEditorEntry(string messageName,string sourceProcessId,string destinationProcessId,string messageSort)
		{
			string newMessageEntry=MESSAGE_IDENTIFIER+ONE_SPACE_TAB+sourceProcessId+COMMA+ONE_SPACE_TAB+destinationProcessId+COMMA+ONE_SPACE_TAB+messageName+COMMA+messageSort+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newMessageEntry);
			return newMessageEntry;
		}
		
		protected string CreateMessageEditorEntryNoWordWrap(string messageName,string sourceProcessId,string destinationProcessId,string messageSort)
		{
			string newMessageEntry=MESSAGE_IDENTIFIER+ONE_SPACE_TAB+sourceProcessId+COMMA+ONE_SPACE_TAB+destinationProcessId+COMMA+ONE_SPACE_TAB+messageName+COMMA+messageSort+WORD_WRAP;
			this.editorContent.Add(newMessageEntry);
			return newMessageEntry;
		}
		
		public string CreateReplyMessageEditorEntry(string messageName,string sourceProcessId,string destinationProcessId)
		{
			string newMessageEntry=CreateMessageEditorEntry(messageName,sourceProcessId,destinationProcessId,REPLY_MESSAGE_SIGN);
			return newMessageEntry;
		}
		
		public string CreateReplyMessageEditorEntryNoWordWrap(string messageName,string sourceProcessId,string destinationProcessId)
		{
			string newMessageEntry=CreateMessageEditorEntryNoWordWrap(messageName,sourceProcessId,destinationProcessId,REPLY_MESSAGE_SIGN);
			return newMessageEntry;
		}
		
		public string CreateSynchronCallEditorEntry(string messageName,string sourceProcessId,string destinationProcessId)
		{
			string newMessageEntry=CreateMessageEditorEntry(messageName,sourceProcessId,destinationProcessId,SYNCH_CALL_SIGN);
			return newMessageEntry;
		}
		
		public string CreateSynchronCallEditorEntryNoWordWrap(string messageName,string sourceProcessId,string destinationProcessId)
		{
			string newMessageEntry=CreateMessageEditorEntryNoWordWrap(messageName,sourceProcessId,destinationProcessId,SYNCH_CALL_SIGN);
			return newMessageEntry;
		}
		
		public string CreateAsynchronCallEditorEntry(string messageName,string sourceProcessId,string destinationProcessId)
		{
			string newMessageEntry=MESSAGE_IDENTIFIER+ONE_SPACE_TAB+sourceProcessId+COMMA+ONE_SPACE_TAB+destinationProcessId+COMMA+ONE_SPACE_TAB+messageName+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newMessageEntry);
			return newMessageEntry;
		}
		
		public string CreateAsynchronCallEditorEntryNoWordWrap(string messageName,string sourceProcessId,string destinationProcessId)
		{
			string newMessageEntry=MESSAGE_IDENTIFIER+ONE_SPACE_TAB+sourceProcessId+COMMA+ONE_SPACE_TAB+destinationProcessId+COMMA+ONE_SPACE_TAB+messageName+WORD_WRAP;
			this.editorContent.Add(newMessageEntry);
			return newMessageEntry;
		}
		
		public string CreateCreateMessageEditorEntry(string sourceProcessId,string destinationProcessId,string messageName,string createdProcessName)
		{
			messageName=CREATE_STEREOTYPE+ONE_SPACE_TAB+messageName;
			string newMessageEntry=CREATE_IDENTIFIER+ONE_SPACE_TAB+sourceProcessId+COMMA+ONE_SPACE_TAB+
																	destinationProcessId+COMMA+ONE_SPACE_TAB+
																	messageName+COMMA+ONE_SPACE_TAB+
																	createdProcessName+WORD_WRAP;
			this.editorContent.Add(newMessageEntry);
			return newMessageEntry;
		}
		
		public string CreateDestructionEventEditorEntry(string processId)
		{
			string newDestructionEventEntry=DESTRUCTION_EVENT_IDENTIFIER+ONE_SPACE_TAB+processId+SEMICOLON+WORD_WRAP;
			this.editorContent.Add(newDestructionEventEntry);
			return newDestructionEventEntry;
		}
		
		public void InitEditorContent(string diagramName)
		{
			if(diagramName.Length==0)
			{
				string defaultInteractionNameCountString=Convert.ToString(defaultInteractionNameCount);
				diagramName=DEFAULT_INTERACTION_NAME+defaultInteractionNameCountString;
				defaultInteractionNameCount++;
			}
			
			this.editorContent=new ArrayList();
			editorContent.Add(DIAGRAM_STYLE_STRING);
			editorContent.Add(DIAGRAM_NAME_STRING+ONE_SPACE_TAB+diagramName+DOUBLE_WORD_WRAP);
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
