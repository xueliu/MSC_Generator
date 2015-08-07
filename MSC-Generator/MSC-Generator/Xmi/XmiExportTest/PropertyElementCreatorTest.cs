/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 20.11.2007
 * Zeit: 13:24
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using nGenerator;
using xmlTestFramework;
using NUnit.Framework;

using xmi;

namespace xmiExport
{
	[TestFixture]
	public class PropertyElementCreatorTest:XmlElementCreatorTest
	{
		private PropertyElementCreator elementCreator;
		private XmlElement parentElement;
		private XmlElement classElement;
		private XmlElement modelElement;
		private const int  EXPECTED_CHILD_COUNT_CASE_1=1;
		private const string ID_OF_FIRST_XMI_ELEMENT="1";
		private const int OWNED_ATTRIBUTES_COUNT=2;
		private const uint expectedIdCount=2;
		private const string LIFELINE_OBJECT_NAME="TestLifelineObjectName";
		private const string LIFELINE_TYPE_NAME="TestLifelineTypeName";
		private const string PROPERTY_ELEMENT_TYPE_NAME="ownedAttribute";
		private const string XMI_TYPE_ATTRIBUTE_VALUE="uml:Property";
		private const string EMPTY_STRING="";
		private const string CLASS_ELEMENT_ID="35";
		private const string CLASS_ELEMENT_NAMEATTR_VALUE="TestKlassenName";
		private const string NAME_ATTR_NAME="name";
		
		[SetUp] 
		public override void Init()
		{
			base.Init();
			elementCreator=new PropertyElementCreator(xmiDocument,documentBuilder);
			parentElement=CollaborationElementStub.CreateCollaborationElementStub(xmiDocument);
			classElement=ClassElementStub.CreateClassElementStub(xmiDocument,CLASS_ELEMENT_ID);
			classElement.SetAttribute(NAME_ATTR_NAME,CLASS_ELEMENT_NAMEATTR_VALUE);
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			modelElement.AppendChild(classElement);
		}
		
		[Test]
		public void TestCreatePropertyElementWithClassElement()
		{
			XmlElement propertyElement=elementCreator.CreatePropertyElement(parentElement,LIFELINE_OBJECT_NAME,classElement);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine(modelElement.OuterXml);	
			System.Console.WriteLine("************************");
		}
		
		[Test]
		public void TestCreatePropertyElementWithoutClassElement()
		{
			XmlElement propertyElement=elementCreator.CreatePropertyElement(parentElement,LIFELINE_OBJECT_NAME,null);
			System.Console.WriteLine(parentElement.OuterXml);
			System.Console.WriteLine(modelElement.OuterXml);	
		}
	}
}
