/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 23.11.2007
 * Zeit: 16:59
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmlTestFramework;
using xmiExport;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace xmiExportPapyrus
{
	[TestFixture]
	public class PapyrusModelElementCreatorTest:XmlElementCreatorTest
	{
		private PapyrusModelElementCreator elementCreator;
		private XmlDocument documentElement;
		private const string MODEL_NAME="TestModelName";
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new PapyrusModelElementCreator(xmiDocument,documentBuilder);
			documentElement=new XmlDocument();
			documentBuilder.XmiDocument=documentElement;
		}
		
		[Test]
		public void TestCreatePapyrusModelElement()
		{
			XmlElement createdModelElement=elementCreator.CreatePapyrusModelElement(MODEL_NAME);
			System.Console.WriteLine(createdModelElement.OuterXml);
		}
	}
}
