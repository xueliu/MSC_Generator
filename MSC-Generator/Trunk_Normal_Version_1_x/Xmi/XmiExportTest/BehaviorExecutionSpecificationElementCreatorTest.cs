/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 29.10.2007
 * Zeit: 11:40
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using nGenerator;
using mscElements;
using xmlTestFramework;
using NUnit.Framework;
using xmi;

namespace xmiExport
{
	[TestFixture]
	public class BehaviorExecutionSpecificationElementCreatorTest:XmlElementCreatorTest
	{
		private BehaviorExecutionSpecificationElementCreator elementCreator;
		private XmlElement parentElement;
		private XmlElement lifelineElement;
		private const string EXECUTION_SPECIFICATION_ELEMENT_ID="1";
		private const string LIFELINE_ID="45";
		private const int EXPECTED_CHILD_COUNT_CASE_1=3;
		private const int OWNED_ATTRIBUTES_COUNT=5;
		private const uint expectedIdCount=2;
		private const string START_ATTR_NAME="start";
		private const string FINISH_ATTR_NAME="finish";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:BehaviorSpecification";
		private const string EMPTY_STRING="";
		private const uint FILE_LINE_DUMMY=1;
		private const uint LINE_DUMMY=1;
		private const int PROCESS_DUMMY=1;
		private const string EXECUTION_SPECIFICATION_NAME="ExecutionTestName";
		private const ItemPos ITEM_POS_DUMMY=ItemPos.Bottom;
		private ProcessRegion executionItem;
		
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new BehaviorExecutionSpecificationElementCreator(xmiDocument,documentBuilder);
			parentElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			executionItem=new ProcessRegion(FILE_LINE_DUMMY,LINE_DUMMY,PROCESS_DUMMY,ProcessStyle.Activation,ProcessStyle.Activation);
			lifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,LIFELINE_ID);
			parentElement.AppendChild(lifelineElement);
		}
		
		[Test]
		public void CreateBehaviorExecutionSpecification()
		{
			XmlElement executionSpecificationElement=elementCreator.CreateBehaviorExcecutionSpecificationElement(parentElement, executionItem,lifelineElement);
			Console.WriteLine(parentElement.OuterXml);
			
		}
	}
}
