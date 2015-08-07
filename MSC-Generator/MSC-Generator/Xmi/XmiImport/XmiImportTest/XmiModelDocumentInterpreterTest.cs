/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 28.11.2007
 * Zeit: 17:31
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using xmiExport;
using NUnit.Framework;

using xmi;
using xmiPapyrus;


namespace xmiImport
{
	[TestFixture]
	public class XmiModelDocumentInterpreterTest
	{
		private XmlElement modelElement;
	    private XmlElement firstInteractionElement;
		private XmlElement secondInteractionElement;
		private XmlElement thirdInteractionElement;
		private XmlElement firstMessageElement;
		private XmlElement secondMessageElement;
		private XmlElement thirdMessageElement;
		private XmlElement firstLifelineElement;
		private XmlElement secondLifelineElement;
		private XmlElement thirdLifelineElement;
		private XmlElement firstBehaviorExecutionSpecElement;
		private XmlElement secondBehaviorExecutionSpecElement;
		private XmlElement thirdBehaviorExecutionSpecElement;
		private XmlElement containerInteractionElement;
		private XmlElement containerLifelineElement;
		private const string CONTAINER_LIFELINE_ELEMENT_ID="12";
		private const string SPACE=" ";
		private XmlElement firstExecutionOccurrenceSpecElement;
		private const string FIRST_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID="34";
		private XmlElement secondExecutionOccurrenceSpecElement;
		private const string SECOND_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID="123";
		private XmlElement thirdExecutionOccurrenceSpecElement;
		private const string THIRD_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID="593";
		private XmlElement fourthExecutionOccurrenceSpecElement;
		private const string FOURTH_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID="1276";
		private const string FIRST_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID="1693";
		private const string SECOND_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID="2345";
		private const string FIRST_MESSAGE_ELEMENT_ID="3213";
		private const string FIRST_MESSAGE_OCCURRENCE_ELEMENT_ID="4261";
		private const string SECOND_MESSAGE_OCCURRENCE_ELEMENT_ID="5671";
		private const string THIRD_MESSAGE_OCCURRENCE_ELEMENT_ID="5956";
		private const string FIRST_EVENT_ID="6012";
		private XmlNamespaceManager namespaceManager;
		private XmlDocument xmiDocument;
		private XmiModelDocumentInterpreter documentInterpreter;
		
		[SetUp]
		public void Init() 
		{
			xmiDocument=new XmlDocument();
			documentInterpreter =new XmiModelDocumentInterpreter();
			namespaceManager=new PapyrusXmiModelNamespaceManager(xmiDocument.NameTable);
			documentInterpreter.NamespaceManager =namespaceManager;
			modelElement=ModelElementStub.CreateModelElementStub(xmiDocument);
			firstInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			secondInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			thirdInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			firstMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			secondMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			thirdMessageElement=MessageElementStub.CreateMessageElementStub(xmiDocument);
			firstLifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument);
			secondLifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument);
			thirdLifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument);
			firstBehaviorExecutionSpecElement=BehaviorExecutionSpecElementStub.CreateBehaviorExecutionSpecElementStub(xmiDocument);
			secondBehaviorExecutionSpecElement=BehaviorExecutionSpecElementStub.CreateBehaviorExecutionSpecElementStub(xmiDocument);
			thirdBehaviorExecutionSpecElement=BehaviorExecutionSpecElementStub.CreateBehaviorExecutionSpecElementStub(xmiDocument);
			containerInteractionElement=InteractionElementStub.CreateInteractionElementStub(xmiDocument);
			containerLifelineElement=LifelineElementStub.CreateLifelineElementStub(xmiDocument,CONTAINER_LIFELINE_ELEMENT_ID);
			firstExecutionOccurrenceSpecElement=ExecutionOccurrenceSpecElementStub.CreateExecutionOccurrenceSpecElementStub(xmiDocument,FIRST_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID,CONTAINER_LIFELINE_ELEMENT_ID);
			firstExecutionOccurrenceSpecElement.SetAttribute(UmlModelElements.EXECUTION_ATTR_NAME,FIRST_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID);
			secondExecutionOccurrenceSpecElement=ExecutionOccurrenceSpecElementStub.CreateExecutionOccurrenceSpecElementStub(xmiDocument,SECOND_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID,CONTAINER_LIFELINE_ELEMENT_ID);
			secondExecutionOccurrenceSpecElement.SetAttribute(UmlModelElements.EXECUTION_ATTR_NAME,FIRST_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID);
			thirdExecutionOccurrenceSpecElement=ExecutionOccurrenceSpecElementStub.CreateExecutionOccurrenceSpecElementStub(xmiDocument,THIRD_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID,CONTAINER_LIFELINE_ELEMENT_ID);
			thirdExecutionOccurrenceSpecElement.SetAttribute(UmlModelElements.EXECUTION_ATTR_NAME,SECOND_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID);
			fourthExecutionOccurrenceSpecElement=ExecutionOccurrenceSpecElementStub.CreateExecutionOccurrenceSpecElementStub(xmiDocument,FOURTH_EXECUTION_OCCURRENCE_SPEC_ELEMENT_ID,CONTAINER_LIFELINE_ELEMENT_ID);
			fourthExecutionOccurrenceSpecElement.SetAttribute(UmlModelElements.EXECUTION_ATTR_NAME,SECOND_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID);
		}
		
		[Test]
		public void GetInteractionElementOneElementTest()
		{
			modelElement.AppendChild(firstInteractionElement);
			XmlNodeList modelElementList=documentInterpreter.GetInteractionElements(modelElement);
			Assert.IsNotNull(modelElementList);
			int modelElementCount=modelElementList.Count;
			Assert.IsTrue(modelElementCount==1);
			IEnumerator itrModelElementList=modelElementList.GetEnumerator();
			itrModelElementList.MoveNext();
			XmlElement firstActualInteractionElement=(XmlElement)itrModelElementList.Current;
			Assert.AreEqual(firstInteractionElement,firstActualInteractionElement);
		}
		
		[Test]
		public void GetInteractionElementThreeElementsTest()
		{
			modelElement.AppendChild(firstInteractionElement);
			modelElement.AppendChild(secondInteractionElement);
			modelElement.AppendChild(thirdInteractionElement);
			XmlNodeList modelElementList=documentInterpreter.GetInteractionElements(modelElement);
			Assert.IsNotNull(modelElementList);
			int modelElementCount=modelElementList.Count;
			Assert.IsTrue(modelElementCount==3);
			IEnumerator itrModelElementList=modelElementList.GetEnumerator();
			itrModelElementList.MoveNext();
			XmlElement firstActualInteractionElement=(XmlElement)itrModelElementList.Current;
			Assert.AreEqual(firstInteractionElement,firstActualInteractionElement);
			itrModelElementList.MoveNext();
			XmlElement secondActualInteractionElement=(XmlElement)itrModelElementList.Current;
			Assert.AreEqual(secondInteractionElement,secondActualInteractionElement);
			itrModelElementList.MoveNext();
			XmlElement thirdActualInteractionElement=(XmlElement)itrModelElementList.Current;
			Assert.AreEqual(thirdInteractionElement,thirdActualInteractionElement);
		}
		
		[Test]
		public void GetInteractionElementNoElementTest()
		{
			XmlNodeList modelElementList=documentInterpreter.GetInteractionElements(modelElement);
			Assert.IsNotNull(modelElementList);
			int modelElementCount=modelElementList.Count;
			Assert.IsTrue(modelElementCount==0);
		}
		
		[Test]
		public void GetMessageElementsThreeElementsTest()
		{
			containerInteractionElement.AppendChild(firstMessageElement);
			containerInteractionElement.AppendChild(secondMessageElement);
			containerInteractionElement.AppendChild(thirdMessageElement);
			XmlNodeList messageElementList=	documentInterpreter.GetMessageElements(containerInteractionElement);
			Assert.IsNotNull(messageElementList);
			int messageElementListCount=messageElementList.Count;
			Assert.IsTrue(messageElementListCount==3);
			IEnumerator itrMessageElementList=messageElementList.GetEnumerator();
			itrMessageElementList.MoveNext();
			XmlElement firstActualMessageElement=(XmlElement)itrMessageElementList.Current;
			Assert.AreEqual(firstMessageElement,firstActualMessageElement);
			itrMessageElementList.MoveNext();
			XmlElement secondActualMessageElement=(XmlElement)itrMessageElementList.Current;
			Assert.AreEqual(secondMessageElement,secondActualMessageElement);
			itrMessageElementList.MoveNext();
			XmlElement thirdActualMessageElement=(XmlElement)itrMessageElementList.Current;
			Assert.AreEqual(thirdMessageElement,thirdActualMessageElement);
		}
		
		[Test]
		public void GetMessageElementsOneElementTest()
		{
			containerInteractionElement.AppendChild(firstMessageElement);
			XmlNodeList messageElementList=	documentInterpreter.GetMessageElements(containerInteractionElement);
			Assert.IsNotNull(messageElementList);
			int messageElementListCount=messageElementList.Count;
			Assert.IsTrue(messageElementListCount==1);
			IEnumerator itrMessageElementList=messageElementList.GetEnumerator();
			itrMessageElementList.MoveNext();
			XmlElement firstActualMessageElement=(XmlElement)itrMessageElementList.Current;
			Assert.AreEqual(firstMessageElement,firstActualMessageElement);
		}
		
		[Test]
		public void GetMessageElementsNoElementTest()
		{
			XmlNodeList messageElementList=	documentInterpreter.GetMessageElements(containerInteractionElement);
			Assert.IsNotNull(messageElementList);
			int messageElementListCount=messageElementList.Count;
			Assert.IsTrue(messageElementListCount==0);
		}
		
		[Test]
		public void GetBehaviorExecutionSpecElementsThreeElementsTest()
		{
			containerInteractionElement.AppendChild(firstBehaviorExecutionSpecElement);
			containerInteractionElement.AppendChild(secondBehaviorExecutionSpecElement);
			containerInteractionElement.AppendChild(thirdBehaviorExecutionSpecElement);
			XmlNodeList behaviorExecutionSpecElementList=documentInterpreter.GetBehaviorExecutionSpecElements(containerInteractionElement);
			Assert.IsNotNull(behaviorExecutionSpecElementList);
			int behaviorExecutionSpecElementListCount=behaviorExecutionSpecElementList.Count;
			Assert.IsTrue(behaviorExecutionSpecElementListCount==3);
			IEnumerator itrBehaviorExecutionSpecElementList=behaviorExecutionSpecElementList.GetEnumerator();
			itrBehaviorExecutionSpecElementList.MoveNext();
			XmlElement firstActualBehaviorExecutionSpecElement=(XmlElement)itrBehaviorExecutionSpecElementList.Current;
			Assert.AreEqual(firstBehaviorExecutionSpecElement,firstActualBehaviorExecutionSpecElement);
			itrBehaviorExecutionSpecElementList.MoveNext();
			XmlElement secondActualBehaviorExecutionSpecElement=(XmlElement)itrBehaviorExecutionSpecElementList.Current;
			Assert.AreEqual(secondBehaviorExecutionSpecElement,secondActualBehaviorExecutionSpecElement);
			itrBehaviorExecutionSpecElementList.MoveNext();
			XmlElement thirdActualBehaviorExecutionSpecElement=(XmlElement)itrBehaviorExecutionSpecElementList.Current;
			Assert.AreEqual(thirdBehaviorExecutionSpecElement,thirdActualBehaviorExecutionSpecElement);
		}
		
		[Test]
		public void GetBehaviorExecutionSpecElementsOneElementTest()
		{
			containerInteractionElement.AppendChild(firstBehaviorExecutionSpecElement);
			XmlNodeList behaviorExecutionSpecElementList=documentInterpreter.GetBehaviorExecutionSpecElements(containerInteractionElement);
			Assert.IsNotNull(behaviorExecutionSpecElementList);
			int behaviorExecutionSpecElementListCount=behaviorExecutionSpecElementList.Count;
			Assert.IsTrue(behaviorExecutionSpecElementListCount==1);
			IEnumerator itrBehaviorExecutionSpecElementList=behaviorExecutionSpecElementList.GetEnumerator();
			itrBehaviorExecutionSpecElementList.MoveNext();
			XmlElement firstActualBehaviorExecutionSpecElement=(XmlElement)itrBehaviorExecutionSpecElementList.Current;
			Assert.AreEqual(firstBehaviorExecutionSpecElement,firstActualBehaviorExecutionSpecElement);
		}
		
		[Test]
		public void GetBehaviorExecutionSpecElementsNoElementTest()
		{
			XmlNodeList behaviorExecutionSpecElementList=documentInterpreter.GetBehaviorExecutionSpecElements(containerInteractionElement);
			Assert.IsNotNull(behaviorExecutionSpecElementList);
			int behaviorExecutionSpecElementListCount=behaviorExecutionSpecElementList.Count;
			Assert.IsTrue(behaviorExecutionSpecElementListCount==0);		
		}
		
		[Test]
		public void GetLifelineElementsThreeElementsTest()
		{
			containerInteractionElement.AppendChild(firstLifelineElement);
			containerInteractionElement.AppendChild(secondLifelineElement);
			containerInteractionElement.AppendChild(thirdLifelineElement);
			XmlNodeList lifelineElementList=documentInterpreter.GetLifelineElements(containerInteractionElement);
			Assert.IsNotNull(lifelineElementList);
			int lifelineElementListCount=lifelineElementList.Count;
			Assert.IsTrue(lifelineElementListCount==3);
			IEnumerator itrLifelineElementList=lifelineElementList.GetEnumerator();
			itrLifelineElementList.MoveNext();
			XmlElement firstActualLifelineElement=(XmlElement)itrLifelineElementList.Current;
			Assert.AreEqual(firstLifelineElement,firstActualLifelineElement);
			itrLifelineElementList.MoveNext();
			XmlElement secondActualLifelineElement=(XmlElement)itrLifelineElementList.Current;
			Assert.AreEqual(secondLifelineElement,secondActualLifelineElement);
			itrLifelineElementList.MoveNext();
			XmlElement thirdActualLifelineElement=(XmlElement)itrLifelineElementList.Current;
			Assert.AreEqual(thirdLifelineElement,thirdActualLifelineElement);
		}
		
		[Test]
		public void GetLifelineElementsOneElementTest()
		{
			containerInteractionElement.AppendChild(firstLifelineElement);
			XmlNodeList lifelineElementList=documentInterpreter.GetLifelineElements(containerInteractionElement);
			Assert.IsNotNull(lifelineElementList);
			int lifelineElementListCount=lifelineElementList.Count;
			Assert.IsTrue(lifelineElementListCount==1);
			IEnumerator itrLifelineElementList=lifelineElementList.GetEnumerator();
			itrLifelineElementList.MoveNext();
			XmlElement firstActualLifelineElement=(XmlElement)itrLifelineElementList.Current;
			Assert.AreEqual(firstLifelineElement,firstActualLifelineElement);
		}
		
		[Test]
		public void GetLifelineElementsNoElementTest()
		{
			XmlNodeList lifelineElementList=documentInterpreter.GetLifelineElements(containerInteractionElement);
			Assert.IsNotNull(lifelineElementList);
			int lifelineElementListCount=lifelineElementList.Count;
			Assert.IsTrue(lifelineElementListCount==0);
		}
		
		[Test]
		public void GetExecutionOccurrenceSpecElementsForLifelineFourElementsTwoExecutionsTest()
		{
			containerLifelineElement.AppendChild(this.firstExecutionOccurrenceSpecElement);
			containerLifelineElement.AppendChild(this.secondExecutionOccurrenceSpecElement);
			containerLifelineElement.AppendChild(this.thirdExecutionOccurrenceSpecElement);
			containerLifelineElement.AppendChild(this.fourthExecutionOccurrenceSpecElement);
			containerInteractionElement.AppendChild(containerLifelineElement);
			ArrayList containedExecutionOccurrenceSpecElements=documentInterpreter.GetExecutionOccurrenceSpecElementsForLifeline(containerLifelineElement);
			Assert.IsNotNull(containedExecutionOccurrenceSpecElements);
			int containedExecutionOccurrenceSpecElementsCount=containedExecutionOccurrenceSpecElements.Count;
			Assert.IsTrue(containedExecutionOccurrenceSpecElementsCount==2);
			XmlElement firstFoundActualExecutionOccurrenceSpecElement=(XmlElement)containedExecutionOccurrenceSpecElements[0];
			Assert.AreEqual(firstExecutionOccurrenceSpecElement,firstFoundActualExecutionOccurrenceSpecElement);
			XmlElement secondFoundActualExecutionOccurrenceSpecElement=(XmlElement)containedExecutionOccurrenceSpecElements[1];
			Assert.AreEqual(thirdExecutionOccurrenceSpecElement,secondFoundActualExecutionOccurrenceSpecElement);

		}
		
		[Test]
		public void GetExecutionOccurrenceSpecElementsForLifelineOneElementTest()
		{
			containerLifelineElement.AppendChild(this.firstExecutionOccurrenceSpecElement);
			containerInteractionElement.AppendChild(containerLifelineElement);
			ArrayList containedExecutionOccurrenceSpecElements=documentInterpreter.GetExecutionOccurrenceSpecElementsForLifeline(containerLifelineElement);
			Assert.IsNotNull(containedExecutionOccurrenceSpecElements);
			int containedExecutionOccurrenceSpecElementsCount=containedExecutionOccurrenceSpecElements.Count;
			Assert.IsTrue(containedExecutionOccurrenceSpecElementsCount==1);
			XmlElement firstActualExecutionOccurrenceSpecElement=(XmlElement)containedExecutionOccurrenceSpecElements[0];
			Assert.AreEqual(firstExecutionOccurrenceSpecElement,firstActualExecutionOccurrenceSpecElement);
		}
		
		
		[Test]
		public void GetExecutionOccurrenceSpecElementsForLifelineNoElementTest()
		{
			containerInteractionElement.AppendChild(containerLifelineElement);
			ArrayList containedExecutionOccurrenceSpecElements=documentInterpreter.GetExecutionOccurrenceSpecElementsForLifeline(containerLifelineElement);
			Assert.IsNotNull(containedExecutionOccurrenceSpecElements);
			int containedExecutionOccurrenceSpecElementsCount=containedExecutionOccurrenceSpecElements.Count;
			Assert.IsTrue(containedExecutionOccurrenceSpecElementsCount==0);
		}
		
		[Test]
		public void GetBehaviorExecutionSpecElementsForLifelineTest()
		{
			string interactionElementContent="<lifeline xmi:id='12' xmlns:xmi='http://www.omg.org/XMI' coveredBy='34 123 593 1276'/>"+
    		"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmi:id='34' xmlns:xmi='http://www.omg.org/XMI' covered='12' execution='1693'/>"+ 
    		"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmi:id='123' xmlns:xmi='http://www.omg.org/XMI'  covered='12' execution='1693'/>"+
    		"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmi:id='593' xmlns:xmi='http://www.omg.org/XMI' covered='12' execution='2345'/>"+
    		"<fragment xmi:type='uml:ExecutionOccurrenceSpecification' xmi:id='1276' xmlns:xmi='http://www.omg.org/XMI'  covered='12' execution='2345'/>"+
    		"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmi:id='1693' xmlns:xmi='http://www.omg.org/XMI' start='34'  finish='123'/>"+
    		"<fragment xmi:type='uml:BehaviorExecutionSpecification' xmi:id='2345' xmlns:xmi='http://www.omg.org/XMI' start='593'  finish='1276'/>";
			containerInteractionElement.InnerXml=interactionElementContent;
			XmlElement lifelineElement=(XmlElement)containerInteractionElement.FirstChild;
			ArrayList behaviorExecutionSpecElements=documentInterpreter.GetExecutionSpecElementsForLifeline(lifelineElement);
			Assert.IsNotNull(behaviorExecutionSpecElements);
			int behaviorExecutionSpecElementsCount=behaviorExecutionSpecElements.Count;
			Assert.IsTrue(behaviorExecutionSpecElementsCount==2);
			
			XmlElement firstBehaviorExecutionSpecElement =(XmlElement)behaviorExecutionSpecElements[0];
			string firstBehaviorExecutionSpecElementId=firstBehaviorExecutionSpecElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(FIRST_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID,firstBehaviorExecutionSpecElementId);
			XmlElement secondBehaviorExecutionSpecElement =(XmlElement)behaviorExecutionSpecElements[1];
			string secondBehaviorExecutionSpecElementId=secondBehaviorExecutionSpecElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(SECOND_BEHAVIOR_EXECUTION_SPEC_ELEMENT_ID,secondBehaviorExecutionSpecElementId);
		}
		
		[Test]
		public void GetMessageElementForMessageOccurrenceSpecTest()
		{
			string interactionElementContent="<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='4261' message='3213'/>"+
    										 "<message xmi:type='uml:Message' xmi:id='3213' xmlns:xmi='http://www.omg.org/XMI' coveredBy='4261'/>";
			containerInteractionElement.InnerXml=interactionElementContent;
			XmlElement messageOccurrenceSpecElement=(XmlElement)containerInteractionElement.FirstChild;
			XmlElement foundMessageElement=documentInterpreter.GetMessageElementForMessageOccurrenceSpec(messageOccurrenceSpecElement);
			Assert.IsNotNull(foundMessageElement);
			string foundMessageElementId=foundMessageElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(FIRST_MESSAGE_ELEMENT_ID,foundMessageElementId);
		}
		
		[Test]
		public void GetMessageElementForMessageOccurrenceSpecTestNoMessageElementTest()
		{
			string interactionElementContent="<fragment xmi:type='uml:MessageOccurrenceSpecification' xmlns:xmi='http://www.omg.org/XMI' xmi:id='4261'/>";								
			containerInteractionElement.InnerXml=interactionElementContent;
			XmlElement messageOccurrenceSpecElement=(XmlElement)containerInteractionElement.FirstChild;
			XmlElement foundMessageElement=documentInterpreter.GetMessageElementForMessageOccurrenceSpec(messageOccurrenceSpecElement);
			Assert.IsNull(foundMessageElement);
		}
		
		[Test]
		public void GetMessageOccurrenceSpecElementsForLifelineThreeElementsTest()
		{
			string interactionElementContent="<lifeline xmlns:xmi='http://www.omg.org/XMI'  xmi:id='12' />"+
				"<fragment xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:MessageOccurrenceSpecification'  xmi:id='4261' covered='12'/>"+
    			"<fragment xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:MessageOccurrenceSpecification'  xmi:id='5671' covered='12'/>"+							 
				"<fragment xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:MessageOccurrenceSpecification'  xmi:id='5956' covered='12'/>";
			containerInteractionElement.InnerXml=interactionElementContent;
			XmlElement lifelineElement=(XmlElement)containerInteractionElement.FirstChild;
			XmlNodeList foundMessageOccurrenceSpecElements=documentInterpreter.GetMessageOccurrenceSpecElementsForLifeline(lifelineElement);
			Assert.IsNotNull(foundMessageOccurrenceSpecElements);
			int foundMessageOccurrenceSpecElementsCount=foundMessageOccurrenceSpecElements.Count;
			Assert.IsTrue(foundMessageOccurrenceSpecElementsCount==3);
			IEnumerator itrFoundMessageOccurrenceSpecElements=foundMessageOccurrenceSpecElements.GetEnumerator();
			itrFoundMessageOccurrenceSpecElements.MoveNext();
			XmlElement firstFoundMessageOccurrenceElement=(XmlElement)itrFoundMessageOccurrenceSpecElements.Current;
			string firstFoundMessageOccurrenceElementId=firstFoundMessageOccurrenceElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(FIRST_MESSAGE_OCCURRENCE_ELEMENT_ID,firstFoundMessageOccurrenceElementId);
			itrFoundMessageOccurrenceSpecElements.MoveNext();
			XmlElement secondFoundMessageOccurrenceElement=(XmlElement)itrFoundMessageOccurrenceSpecElements.Current;
			string secondFoundMessageOccurrenceElementId=secondFoundMessageOccurrenceElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(SECOND_MESSAGE_OCCURRENCE_ELEMENT_ID,secondFoundMessageOccurrenceElementId);
			itrFoundMessageOccurrenceSpecElements.MoveNext();
			XmlElement thirdFoundMessageOccurrenceElement=(XmlElement)itrFoundMessageOccurrenceSpecElements.Current;
			string thirdFoundMessageOccurrenceElementId=thirdFoundMessageOccurrenceElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(THIRD_MESSAGE_OCCURRENCE_ELEMENT_ID,thirdFoundMessageOccurrenceElementId);
		}
			
		[Test]
		public void GetMessageOccurrenceSpecElementsForLifelineOneElementTest()
		{
			string interactionElementContent="<lifeline xmlns:xmi='http://www.omg.org/XMI'  xmi:id='12' />"+
				"<fragment xmlns:xmi='http://www.omg.org/XMI' xmi:type='uml:MessageOccurrenceSpecification'  xmi:id='4261' covered='12'/>";
			containerInteractionElement.InnerXml=interactionElementContent;
			XmlElement lifelineElement=(XmlElement)containerInteractionElement.FirstChild;
			XmlNodeList foundMessageOccurrenceSpecElements=documentInterpreter.GetMessageOccurrenceSpecElementsForLifeline(lifelineElement);
			Assert.IsNotNull(foundMessageOccurrenceSpecElements);
			int foundMessageOccurrenceSpecElementsCount=foundMessageOccurrenceSpecElements.Count;
			Assert.IsTrue(foundMessageOccurrenceSpecElementsCount==1);
			IEnumerator itrFoundMessageOccurrenceSpecElements=foundMessageOccurrenceSpecElements.GetEnumerator();
			itrFoundMessageOccurrenceSpecElements.MoveNext();
			XmlElement firstFoundMessageOccurrenceElement=(XmlElement)itrFoundMessageOccurrenceSpecElements.Current;
			string firstFoundMessageOccurrenceElementId=firstFoundMessageOccurrenceElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.AreEqual(FIRST_MESSAGE_OCCURRENCE_ELEMENT_ID,firstFoundMessageOccurrenceElementId);
		}	
		
		[Test]
		public void GetMessageOccurrenceSpecElementsForLifelineNoElementTest()
		{
			string interactionElementContent="<lifeline xmlns:xmi='http://www.omg.org/XMI'  xmi:id='12' />";
			containerInteractionElement.InnerXml=interactionElementContent;
			XmlElement lifelineElement=(XmlElement)containerInteractionElement.FirstChild;
			XmlNodeList foundMessageOccurrenceSpecElements=documentInterpreter.GetMessageOccurrenceSpecElementsForLifeline(lifelineElement);
			Assert.IsNotNull(foundMessageOccurrenceSpecElements);
			int foundMessageOccurrenceSpecElementsCount=foundMessageOccurrenceSpecElements.Count;
			Assert.IsTrue(foundMessageOccurrenceSpecElementsCount==0);
		}
		
		[Test]
		public void GetEventElementForMessageEnd()
		{
			string modelElementContent="<packagedElement xmi:type='uml:Interaction' xmlns:xmi='http://www.omg.org/XMI'>"+
									   			"<fragment xmi:type='uml:MessageOccurrenceSpecification' event='6012' xmlns:xmi='http://www.omg.org/XMI'/>"+
											"</packagedElement>"+	
											"<packagedElement xmi:type='uml:ExecutionEvent' xmi:id='6012' xmlns:xmi='http://www.omg.org/XMI'/>"; 
			modelElement.InnerXml=modelElementContent;
			XmlElement interactionElement=(XmlElement)modelElement.FirstChild;
			XmlElement relevantMessageOccurrenceSpecElement=(XmlElement)interactionElement.FirstChild;
			XmlElement actualEventElement=documentInterpreter.GetEventElementForMessageEnd(relevantMessageOccurrenceSpecElement);
			Assert.IsNotNull(actualEventElement);
			string actualEventElementId=actualEventElement.GetAttribute(XmiElements.XMI_ID_ATTR_COMPLETE_NAME);
			Assert.IsTrue(FIRST_EVENT_ID==actualEventElementId);
		}
	}
}
