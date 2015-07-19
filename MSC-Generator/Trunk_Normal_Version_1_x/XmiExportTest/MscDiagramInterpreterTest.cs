/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 29.10.2007
 * Zeit: 17:46
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using nGenerator;
using mscElements;

namespace xmiExport
{
	[TestFixture]
	public class MscDiagramInterpreterTest
	{
		private Generator mscGenerator;
		private Process process1;
		private const string PROCESS_1_NAME="processName1";
		private const string PROCESS_1_COMPLEX_NAME="processOneObjectName:processOneObjectType";
		private const int PROCESS_1_ID=1;
		private const int PROCESS_1_Index=0;
		private Process process2;
		private const string PROCESS_2_NAME="processName2";
		string PROCESS_2_COMPLEX_NAME="processTwoObjectName:processTwoObjectType";
		private const int PROCESS_2_ID=2;
		private const int PROCESS_2_Index=1;
		private const uint LEFT_RAND=1;
		private const uint RIGHT_RAND=1;
		private const uint FILE_LINE=1;
		private const uint LINE=1;	
		
		private Task task1;
		private const string TASK_NAME_1="taskName1";
		private const int TASK_1_ID=3;
		
		private Task task2;
		private const string TASK_NAME_2="taskName2";
		private const int TASK_2_ID=4;
		
		private Message message1;
		private string MESSAGE_1_NAME="messageName1";
		
		
		public MscDiagramInterpreterTest()
		{
			mscGenerator=new Generator(null);
			process1=new Process(PROCESS_1_COMPLEX_NAME,null,LEFT_RAND,RIGHT_RAND);
			process2=new Process(PROCESS_2_COMPLEX_NAME,null,LEFT_RAND,RIGHT_RAND);
			mscGenerator.Processes.Add(process1);
			mscGenerator.Processes.Add(process2);
			
			task1=new Task(FILE_LINE,TASK_NAME_1,LINE,PROCESS_1_Index);
			task1.ItemID=TASK_1_ID;
			mscGenerator.Items.Add(task1);
			
			task2=new Task(FILE_LINE,TASK_NAME_2,LINE,PROCESS_2_Index);
			task2.ItemID=TASK_2_ID;
			mscGenerator.Items.Add(task2);
			message1=new Message(FILE_LINE,MESSAGE_1_NAME,LINE,PROCESS_1_Index,PROCESS_2_Index,MessageStyle.Synchron);
			mscGenerator.Items.Add(message1);
		}
		
		[Test]
		public void TestMethodWithSimpleProcessName()
		{
			XmlDocumentBuilder documentBuilder=new XmlDocumentBuilder();
			MscDiagramInterpreter interpreter=new MscDiagramInterpreter(mscGenerator,documentBuilder);
			XmlDocument createdDocument=interpreter.InterpretMscDiagram();
			XmlElement documentElement=createdDocument.DocumentElement;
			
			System.Console.Write(createdDocument.OuterXml);
			
		}
		
		
	}
}
