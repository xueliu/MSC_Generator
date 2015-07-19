/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 29.11.2007
 * Zeit: 16:01
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Xml;
using GeneratorGUI;
using NumberingEditor;
using nGenerator;
using xmiExport;
using xmiImport;
using NUnit.Framework;


namespace xmiImport
{
	/// <summary>
	/// Description of EditorEntryCreatorTest.
	/// </summary>
	[TestFixture]
	public class EditorEntryCreatorTest
	{
		private Output mscOutput;
		private ArrayList repertory;
		private NumberingEditor.NumberingEditor editor;
		private EditorEntryCreator entryCreator;
		private const string LIFELINE_NAME="testLifelineName";
		
		public EditorEntryCreatorTest()
		{
			string [] args=new string[0];
			mscOutput=new Output(args);
			repertory=mscOutput.Repertory;
			editor=mscOutput.RtbMscEditor;
			entryCreator=new EditorEntryCreator();
		}
		
		[Test]
		public void TestCreateProcessEditorEntry()
		{
			entryCreator.CreateProcessEditorEntry(LIFELINE_NAME);
			System.Console.WriteLine(editor.Text);
			
		}
	}
}
