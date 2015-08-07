/*

Copyright (C) 2005-2007 by Itesys Institut fuer Technische Systeme GmbH
http://www.itesys-gmbh.de   
mailto:software@itesys.de

This file is part of sdgen. Project home:
http://www.itesys-gmbh.de/home/produkte/msc_generator.html

sdgen is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

sdgen is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with sdgen; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

*/
/*
 * Erstellt mit SharpDevelop.
 * Benutzer: LG
 * Datum: 02.10.2007
 * Zeit: 11:12
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using System.Xml;
using nGenerator;
using xmlTestFramework;
using xmiExportPapyrus;


namespace xmiExport
{
	/// <summary>
	/// Description of XmiDocumentBuilderTest.
	/// </summary>
	
	[TestFixture]
	public class XmiDocumentBuilderTest
	{	
		XmlDocumentBuilder builder;
		const string XML_VERSION="1.0";
		const string ENCODING="UTF-8";
		const string STANDALONE="no";
		const int INDEX_0=0;
		const int INDEX_1=1;
		const string LOCAL_NAME_XMI="XMI";
		const string NS_PREFIX_UML="UML";
		const string DOUBLE_POINT=":";
		
		[SetUp] 
		public void Init(){
			
			
			
		}
				
		[Test]
		public void testCreateXmiDocument(){
			
			//XmlDocumentBuilder builder =new XmlDocumentBuilder();
			//builder.CreateXmlDocument();
			Generator mscItemGenerator=new Generator(null);
			XmlDocumentBuilder builder =new XmlDocumentBuilder();
			
			XmlDocument xmiDocument=builder.CreateXmlDocument();
			
			XmlElement modelElement=xmiDocument.DocumentElement;
			System.Console.WriteLine(modelElement.OuterXml);
			// 	verifies if the created document is not Null
			/*Assert.IsNotNull(xmiDocument);
			
			XmlNodeList childNodesOfDocument=xmiDocument.ChildNodes;
			int childNodesOfDocumentSize=childNodesOfDocument.Count;
			
			// verifies if the created document has two child-nodes 
			Assert.IsTrue(childNodesOfDocumentSize==2);
			
			// verifies the XML-declaration-node of the created document 
			XmlDeclaration xmlDeclaration=(XmlDeclaration)childNodesOfDocument.Item(INDEX_0);
			Assert.IsNotNull(xmlDeclaration);
			string xmlVersion=xmlDeclaration.Version;
			string encoding=xmlDeclaration.Encoding;
			string standalone=xmlDeclaration.Standalone;
			Assert.AreEqual(XML_VERSION,xmlVersion);
			Assert.AreEqual(ENCODING,encoding);
			Assert.AreEqual(STANDALONE,standalone);
			
			// verifies the document-node that has to be the XMI-Node of the created document
			XmlElement documentElement=(XmlElement)childNodesOfDocument.Item(INDEX_1);
			Assert.IsNotNull(documentElement);
			XmlElement rootElement=xmiDocument.DocumentElement;
			Assert.AreSame(rootElement,documentElement);
			
			XmlElement modelElement=builder.addModelElement("TestModel");
			MSC msc=new MSC();
			MSC.DiagramName="TestDiagram";
			builder.createInteractionElement(modelElement);
			
			xmiDocument.Save("C:/MscXmi.xmi");*/
		}
	}
}
