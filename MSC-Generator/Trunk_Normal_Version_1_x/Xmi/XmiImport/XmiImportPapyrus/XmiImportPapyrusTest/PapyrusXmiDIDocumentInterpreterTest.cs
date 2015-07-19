/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 30.11.2007
 * Zeit: 17:04
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using xmiImport;
using NUnit.Framework;


namespace xmiImportPapyrus
{
	[TestFixture]
	public class PapyrusXmiDIDocumentInterpreterTest
	{
		private PapyrusXmiDIDocumentInterpreter dIDocumentInterpreter;
		private XmlDocument document;
		private XmlElement diagramElement;
		private XmlElement firstContainedElement;
		private XmlElement secondContainedElement;
		private XmlElement thirdContainedElement;
		
		[SetUp]
		public void Init()
		{
			document=new XmlDocument();
			dIDocumentInterpreter =new PapyrusXmiDIDocumentInterpreter();
			diagramElement=ContainedElementStub.CreateContainedElementStub(document);
			firstContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document,"1");
			secondContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document,"2");
			thirdContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document,"3");
			diagramElement.AppendChild(firstContainedElement);
			diagramElement.AppendChild(secondContainedElement);
			diagramElement.AppendChild(thirdContainedElement);
		}
		
		
		[Test]
		public void GetElementElementsTest()
		{
			//XmlNodeList elementElementsList=dIDocumentInterpreter.GetElementElements(diagramElement);
			
			XPathNavigator navigator=document.CreateNavigator();
			XPathNodeIterator myItr=(XPathNodeIterator)navigator.Evaluate("//contained");
			myItr.MoveNext();
			XPathNavigator firstNavi=myItr.Current;
			/*XmlElement firstNode=(XmlElement)firstNavi.UnderlyingObject;
			Assert.AreSame(firstContainedElement,firstNode);
			System.Console.WriteLine(firstNode.OuterXml);
			System.Console.WriteLine("+++++++++++++++++++++++++++++++");*/
			
			//XPathNodeIterator mySecondItr=(XPathNodeIterator)navigator.Evaluate("./1/");
			//XPathNavigator secondNavi=mySecondItr.Current;
			//XmlElement secondNode=(XmlElement)secondNavi.UnderlyingObject;
			//Assert.AreSame(firstContainedElement,firstNode);
			//System.Console.WriteLine(secondNode.OuterXml);
			//XmlNodeList elementElementsList =diagramElement.SelectNodes("//contained[1]");
			//int elementElementsCount=elementElementsList.Count;
			//Assert.IsTrue(elementElementsCount==3);
		}
	}
}
