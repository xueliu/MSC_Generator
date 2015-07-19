/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 20.11.2007
 * Zeit: 18:55
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using nGenerator;
using xmlTestFramework;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace xmiExport
{
	/// <summary>
	/// Description of ClassElementCreatorTest.
	/// </summary>
	 
	[TestFixture]
	public class ClassElementCreatorTest:XmlElementCreatorTest
	{
		private ClassElementCreator elementCreator;
		private XmlElement parentElement;
		private const string CLASS_NAME="TestKlassenName";
	
	
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new ClassElementCreator(xmiDocument,documentBuilder);
			parentElement=ModelElementStub.CreateModelElementStub(xmiDocument);
		}
		
		[Test]
		public void TestCreateClassElement()
		{
			XmlElement createdClassElement=elementCreator.CreateClassElement(parentElement,CLASS_NAME);
			System.Console.WriteLine(parentElement.OuterXml);
		}
	}
}
