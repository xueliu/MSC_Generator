/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 17:31
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using xmiExport;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace xmiImport
{
	[TestFixture]
	public class XmiDocumentInterpreterTest
	{
		private XmlElement modelElement;
		private XmlElement firstInteractionElement;
		private XmlElement secondInteractionElement;
		private XmlElement thirdInteractionElement;
		private XmlDocument xmiDocument;
		private XmiModelDocumentInterpreter documentInterpreter;
		
		public XmiDocumentInterpreterTest()
		{
			xmiDocument=new XmlDocument();
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			firstInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			secondInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			thirdInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			modelElement.AppendChild(firstInteractionElement);
			modelElement.AppendChild(secondInteractionElement);
			modelElement.AppendChild(thirdInteractionElement);
		}
		
		
		[Test]
		public void TestGetInteractionElement()
		{
			XmlNodeList modelElementList=documentInterpreter.GetInteractionElements(modelElement);
			System.Console.WriteLine(modelElement.OuterXml);
			int modelElementCount=modelElementList.Count;
			Assert.IsTrue(modelElementCount==3);
		}
	}
}
