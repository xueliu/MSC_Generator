/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 10:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using xmiExport;
using xmiImport;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace xmiImport
{
	[TestFixture]
	public class XmiElementValidatorTest
	{
		private XmlElement lifelineElement;
		private XmlDocument xmiDocument;
		private XmlElement modelElement;
		private XmlElement testElement;
		private XmlElement testElementWithoutAttribute;
		private const string  TEST_ELEMENT_TYPE="typeTestElement";
		private const string  TEST_ELEMENT_WITHOUT_ATTRIBUTE_TYPE="typeTestElementWithoutAttributeType";
		private const string  TEST_ELEMENT_ATTRIBUTE_NAME="dummyAttributeName";
		private const string  FALSE_TEST_ELEMENT_ATTRIBUTE_NAME="FalseAttributeName";
		private const string  TEST_ELEMENT_ATTRIBUTE_VALUE="dummyValue";
		private const string  FALSE_TEST_ELEMENT_ATTRIBUTE_VALUE="falseDummyValue";
		private const string  LIFELINE_ELEMENT_LOCAL_NAME="lifeline";
		private const string  LIFELINE_ATTR_XMI_TYPE_VALUE="Lifeline";
		private const string  LIFELINE_XMI_ID_ATTR_VALUE="47";
		private const string  MESSAGE_ELEMENT_LOCAL_NAME="message";
		private const string  MESSAGE_ATTR_XMI_TYPE_VALUE="Message";
		private const string  EMPTY_STRING="";
		private const string  MODEL_ELEMENT_PREFIX="uml";
		private const string  MODEL_ELEMENT_LOCAL_NAME="Model";
		private const string  FALSE_MODEL_ELEMENT_PREFIX="Uml";
		
		
		public XmiElementValidatorTest()
		{
			xmiDocument=new XmlDocument();
			lifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,LIFELINE_XMI_ID_ATTR_VALUE);
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			testElement=xmiDocument.CreateElement(TEST_ELEMENT_TYPE);
			testElement.SetAttribute(TEST_ELEMENT_ATTRIBUTE_NAME,TEST_ELEMENT_ATTRIBUTE_VALUE);
			testElementWithoutAttribute=xmiDocument.CreateElement(TEST_ELEMENT_WITHOUT_ATTRIBUTE_TYPE);
		}
		
		[Test]
		public void TestIsExpectedLocalName()
		{
			bool actualReturnValue=XmiElementValidator.IsExpectedLocalName(lifelineElement,LIFELINE_ELEMENT_LOCAL_NAME);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedLocalName(lifelineElement,MESSAGE_ELEMENT_LOCAL_NAME);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedLocalName(lifelineElement,EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
		}
		
		[Test]
		public void TestIsExpectedElement()
		{
			bool actualReturnValue=XmiElementValidator.IsExpectedElement(lifelineElement,
			                                                             LIFELINE_ELEMENT_LOCAL_NAME,
			                                                             LIFELINE_ATTR_XMI_TYPE_VALUE);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedElement(lifelineElement,
			                                                        LIFELINE_ELEMENT_LOCAL_NAME,
			                                                        MESSAGE_ATTR_XMI_TYPE_VALUE);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedElement(lifelineElement,
			                                                        MESSAGE_ELEMENT_LOCAL_NAME,
			                                                        LIFELINE_ATTR_XMI_TYPE_VALUE);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedElement(lifelineElement,
			                                                        MESSAGE_ELEMENT_LOCAL_NAME,
			                                                        EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
		}
		
		[Test]
		public void TestIsExpectedPrefix()
		{
			bool actualReturnValue=XmiElementValidator.IsExpectedPrefix(modelElement,MODEL_ELEMENT_PREFIX);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedPrefix(modelElement,EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);              
			
			actualReturnValue=XmiElementValidator.IsExpectedPrefix(modelElement,FALSE_MODEL_ELEMENT_PREFIX);
			Assert.IsFalse(actualReturnValue);  
			
			actualReturnValue=XmiElementValidator.IsExpectedPrefix(lifelineElement,EMPTY_STRING);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedPrefix(lifelineElement,MODEL_ELEMENT_PREFIX);
			Assert.IsFalse(actualReturnValue);		
		}
		
		[Test]
		public void TestIsExpectedQualifiedElementName()
		{
			bool actualReturnValue=XmiElementValidator.IsExpectedQualifiedElementName(modelElement,
			                                                                          MODEL_ELEMENT_LOCAL_NAME,
			                                                                          MODEL_ELEMENT_PREFIX);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedQualifiedElementName(modelElement,
			                                                                     MODEL_ELEMENT_LOCAL_NAME,
			                                                                     EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedQualifiedElementName(modelElement,
			                                                                     MODEL_ELEMENT_LOCAL_NAME,
			                                                                     FALSE_MODEL_ELEMENT_PREFIX);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedQualifiedElementName(lifelineElement,
			                                                                     LIFELINE_ELEMENT_LOCAL_NAME,
			                                                                     EMPTY_STRING);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedQualifiedElementName(lifelineElement,
			                                                                     LIFELINE_ELEMENT_LOCAL_NAME,
			                                                                     MODEL_ELEMENT_PREFIX);
			Assert.IsFalse(actualReturnValue);
		}
		
		[Test]
		public void TestHasXmiIdAttributeValue()
		{
			bool actualReturnValue=XmiElementValidator.HasXmiIdAttributeValue(lifelineElement);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.HasXmiIdAttributeValue(testElement);
			Assert.IsFalse(actualReturnValue);
		}
		
		[Test]
		public void TestHasAttributeValue()
		{
			bool actualReturnValue=XmiElementValidator.HasAttributeValue(testElement,TEST_ELEMENT_ATTRIBUTE_NAME);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.HasAttributeValue(testElement,FALSE_TEST_ELEMENT_ATTRIBUTE_NAME);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.HasAttributeValue(testElement,EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.HasAttributeValue(testElementWithoutAttribute,EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
		}
		
		[Test]
		public void IsExpectedXmiTypeAttributeValue()
		{
			bool actualReturnValue=XmiElementValidator.IsExpectedXmiTypeAttributeValue(lifelineElement,
			                                                                           LIFELINE_ATTR_XMI_TYPE_VALUE);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedXmiTypeAttributeValue(lifelineElement,
			                                                                      EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedXmiTypeAttributeValue(lifelineElement,
			                                                                      MESSAGE_ATTR_XMI_TYPE_VALUE);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedXmiTypeAttributeValue(testElementWithoutAttribute,
			                                                                      EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedXmiTypeAttributeValue(testElementWithoutAttribute,
			                                                                      MESSAGE_ATTR_XMI_TYPE_VALUE);
			Assert.IsFalse(actualReturnValue);
		}
		
		[Test]
		public void TestIsExpectedAttributeValue()
		{
			bool actualReturnValue=XmiElementValidator.IsExpectedAttributeValue(testElement,
			                                                                    TEST_ELEMENT_ATTRIBUTE_NAME,
			                                                                    TEST_ELEMENT_ATTRIBUTE_VALUE);
			Assert.IsTrue(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedAttributeValue(testElement,
			                                                               TEST_ELEMENT_ATTRIBUTE_NAME,
			                                                               FALSE_TEST_ELEMENT_ATTRIBUTE_VALUE);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedAttributeValue(testElement,
			                                                               FALSE_TEST_ELEMENT_ATTRIBUTE_NAME,
			                                                               TEST_ELEMENT_ATTRIBUTE_VALUE);
			Assert.IsFalse(actualReturnValue);
			
			actualReturnValue=XmiElementValidator.IsExpectedAttributeValue(testElement,
			                                                               TEST_ELEMENT_ATTRIBUTE_NAME,
			                                                               EMPTY_STRING);
			Assert.IsFalse(actualReturnValue);	
		}
	}
}
