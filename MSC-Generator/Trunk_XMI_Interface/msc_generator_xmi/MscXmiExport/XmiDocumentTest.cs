/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 02.10.2007
 * Zeit: 11:38
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System.Xml;


namespace MscXmiExport
{
	[TestFixture]
	public class XmiDocumentTest
	{
		[Test]
		public void TestMethod()
		{
			XmiDocumentBuilder builder =new XmiDocumentBuilder();
			XmlDocument document=builder.createXMIDocument();
			
			Assert.IsNotNull(document);
		}
	}
}
