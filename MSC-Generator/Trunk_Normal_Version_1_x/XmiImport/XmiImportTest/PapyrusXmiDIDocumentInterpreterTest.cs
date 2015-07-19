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
using NUnit.Framework.SyntaxHelpers;

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
			firstContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document);
			secondContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document);
			thirdContainedElement=GraphNodeSemanticModelElementStub.CreateGraphNodeSemanticModelElementStub(document);
			diagramElement.AppendChild(firstContainedElement);
			diagramElement.AppendChild(secondContainedElement);
			diagramElement.AppendChild(thirdContainedElement);
		}
		
		
		[Test]
		public void GetElementElementsTest()
		{
			XmlNodeList elementElementsList=dIDocumentInterpreter.GetElementElements(diagramElement);
			int elementElementsCount=elementElementsList.Count;
			Assert.IsTrue(elementElementsCount==3);
		}
	}
}
