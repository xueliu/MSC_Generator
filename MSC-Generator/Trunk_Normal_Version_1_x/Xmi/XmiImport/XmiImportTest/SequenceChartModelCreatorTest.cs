/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 10.12.2007
 * Zeit: 18:40
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmi;
using NUnit.Framework;


namespace xmiImport
{
	/// <summary>
	/// Description of SequenceChartModelCreator.
	/// </summary>
	/// 
	
	[TestFixture]
	public class SequenceChartModelCreatorTest
	{
		private XmlElement firstInteractionElement;
		private const string FIRST_INTERACTION_ELEMENT_NAME="FirstInteractionTestName";
		private const string FIRST_INTERACTION_ELEMENT_ID="12";
		private XmlElement secondInteractionElement;
		private const string SECOND_INTERACTION_ELEMENT_NAME="SecondInteractionTestName";
		private const string SECOND_INTERACTION_ELEMENT_ID="54";
		private XmlElement thirdInteractionElement;
		private const string THIRD_INTERACTION_ELEMENT_NAME="ThirdInteractionTestName";
		private const string THIRD_INTERACTION_ELEMENT_ID="99";
		private XmlElement interactionContainerElement;
		
		
		
		private SequenceChartModelCreator modelCreator;
		private XmlDocument xmiDocument;
		
		[SetUp]
		public void Init()
		{
			xmiDocument=new XmlDocument();
			firstInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument,FIRST_INTERACTION_ELEMENT_ID,FIRST_INTERACTION_ELEMENT_NAME);
			secondInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument,SECOND_INTERACTION_ELEMENT_ID,SECOND_INTERACTION_ELEMENT_NAME);
			thirdInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument,THIRD_INTERACTION_ELEMENT_ID,THIRD_INTERACTION_ELEMENT_NAME);
			interactionContainerElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			
		}
		
		[Test]
		public void tester()
		{
			XmlElement testElement =xmiDocument.CreateElement("tester");
			string testElementContent="<innerNode></thatsIt> </innerNode>";
			testElement.InnerXml=testElementContent;
		}
	}
}
