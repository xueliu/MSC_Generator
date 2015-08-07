/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 29.10.2007
 * Zeit: 17:47
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Collections;
using nGenerator;
using mscElements;

namespace xmiExport
{
	/// <summary>
	/// Description of McsDiagramInterpreter.
	/// </summary>
	/// 
	
	
	public class MscDiagramInterpreter
	{
		
		private Generator mscGenerator;
		private XmlDocumentBuilder xmiDocumentBuilder;
		private ArrayList itemIdXmiElementPairs;
		
		class ItemIdXmiElementPair
		{
			private int itemId;
			private XmlElement xmiElement;
			
			public ItemIdXmiElementPair(int itemId,XmlElement xmiElement)
			{
				this.itemId=itemId;
				this.xmiElement=xmiElement;
			}
			
			public int ItemId{
				get{
					return this.itemId;
				}
				set{
					this.itemId=value;
				}
			}
			
			public XmlElement XmiElement{
				get{
					return this.xmiElement;
				}
				set{
					this.xmiElement=value;
				}
			}
		}
			
		public MscDiagramInterpreter(Generator currentGenerator,XmlDocumentBuilder documentBuilder)
		{
			mscGenerator=currentGenerator;	
			xmiDocumentBuilder=documentBuilder;
			itemIdXmiElementPairs=new ArrayList();
		}
		
		public Generator MscGenerator{
			get{
				return this.mscGenerator;
			}
			set{
				this.mscGenerator=value;
			}
		}
		
		public XmlDocumentBuilder XmiDocumentBuilder{
			get{
				return this.xmiDocumentBuilder;
			}
			set{
				this.xmiDocumentBuilder=value;
			}
		}
		
		public XmlDocument InterpretMscDiagram()
		{
			ArrayList proccessItems=mscGenerator.Processes;
			ArrayList diagramItems=mscGenerator.Items;
			XmlDocument createdXmiDocument=xmiDocumentBuilder.CreateXmlDocument();
			XmlElement modelElement=xmiDocumentBuilder.AddUmlModelElement("MussGeändertWerden");
			XmlElement interactionElement=xmiDocumentBuilder.AddInteractionElement(modelElement);
			this.InterpretProcessItems(proccessItems,modelElement,interactionElement);
			this.InterpretMessageItems(diagramItems,interactionElement);
			return createdXmiDocument;
		}
		
		
		private void InterpretMessageItems(ArrayList diagramItems,XmlElement interactionElement)
		{
			IEnumerator enumDiagramItems=diagramItems.GetEnumerator();
			Message currentNormalMessage;
			LostMessage currentLostMessage;
			FoundMessage currentFoundMessage;
			
			foreach(object currentDiagramItem in diagramItems)
			{
				if(currentDiagramItem is Message)
				{
					currentNormalMessage=currentDiagramItem as Message;
					InterpretNormalMessageItem(interactionElement,currentNormalMessage);
				}
				else if(currentDiagramItem is LostMessage)
				{
					currentLostMessage=currentDiagramItem as LostMessage;
					InterpretLostMessageItem(interactionElement,currentLostMessage);
				}
				else if(currentDiagramItem is FoundMessage)
				{
					currentFoundMessage=currentDiagramItem as FoundMessage;
					InterpretFoundMessageItem(interactionElement,currentFoundMessage);
				}
			}
		}
		
		private void InterpretNormalMessageItem(XmlElement interactionElement,Message normalMessageItem)
		{
			int sourceLifelineItemId=normalMessageItem.MessageSource;
			int destinationLifelineItemId=normalMessageItem.MessageDestination;
			XmlElement sourceLifelineElement=GetXmiElementByItemId(sourceLifelineItemId);
			XmlElement destinationLifelineElement=GetXmiElementByItemId(destinationLifelineItemId);
			xmiDocumentBuilder.AddMessageElement(interactionElement,normalMessageItem,sourceLifelineElement,destinationLifelineElement);
		}
		
		private void InterpretLostMessageItem(XmlElement interactionElement,LostMessage lostMessageItem)
		{
			int sourceLifelineItemId=lostMessageItem.Process;
			XmlElement sourceLifelineElement=this.GetXmiElementByItemId(sourceLifelineItemId);
			xmiDocumentBuilder.AddMessageElement(interactionElement,lostMessageItem,sourceLifelineElement,null);
		}
		
		private void InterpretFoundMessageItem(XmlElement interactionElement,FoundMessage foundMessageItem)
		{
			int destinationLifelineItemId=foundMessageItem.Process;
			XmlElement destinationLifelineElement=this.GetXmiElementByItemId(destinationLifelineItemId);
			xmiDocumentBuilder.AddMessageElement(interactionElement,foundMessageItem,null,destinationLifelineElement);
		}
		
		private void InterpretProcessItems(ArrayList processItems,XmlElement collaborationElement,XmlElement interactionElement)
		{
			XmlElement currentLifelineElement;
			
			foreach(Process currentProcessItem in processItems)
			{
				currentLifelineElement=xmiDocumentBuilder.AddLifelineElement(interactionElement,collaborationElement,currentProcessItem);
				int currentProcessItemId=mscGenerator.Processes.IndexOf(currentProcessItem);
				AddNewItemIdXmiElementPair(currentProcessItemId,currentLifelineElement);
				InterpretProcessRegionItems(interactionElement,currentProcessItemId,currentLifelineElement);
			}
		}
		
		private void AddNewItemIdXmiElementPair(int mscItemId,XmlElement xmiElement)
		{
			ItemIdXmiElementPair newItemIdXmiElementPair=new ItemIdXmiElementPair(mscItemId,xmiElement);
			itemIdXmiElementPairs.Add(newItemIdXmiElementPair);
		}
		
		private void InterpretProcessRegionItems(XmlElement interactionElement,int relevantProcessItemId,XmlElement lifelineElement)
		{
			ArrayList diagramItems=mscGenerator.Items;
			ProcessRegion currentProcessRegionItem;
			int idOfAssociatedProcessItem;
						
			foreach(object currentDiagramItem in diagramItems)
			{
				if(currentDiagramItem is ProcessRegion)
				{
					currentProcessRegionItem=currentDiagramItem as ProcessRegion;
					idOfAssociatedProcessItem=currentProcessRegionItem.Process;	
					int processRegionItemId=currentProcessRegionItem.ItemID;
					ProcessStyle processStyle=currentProcessRegionItem.MStyle;
					
					if ((idOfAssociatedProcessItem==relevantProcessItemId)&&
					    (processStyle== ProcessStyle.Activation))
					{
						xmiDocumentBuilder.AddBehaviorExecutionSpecificationElement(interactionElement,currentProcessRegionItem,lifelineElement);
					}
				}	
			}
		}
				
		private XmlElement GetXmiElementByItemId(int relevantItemId)
		{
			XmlElement foundXmiElement=null;
			int currentItemId;
			bool xmiElementNotFound=true;
			ItemIdXmiElementPair currentPair;
			IEnumerator enumItemIdXmiElementPairs=itemIdXmiElementPairs.GetEnumerator();	
				
			while(enumItemIdXmiElementPairs.MoveNext()&&xmiElementNotFound)
			{
				currentPair=(ItemIdXmiElementPair)enumItemIdXmiElementPairs.Current;
				currentItemId=currentPair.ItemId;
				if(currentItemId==relevantItemId)
				{
					foundXmiElement=currentPair.XmiElement;
					xmiElementNotFound=false;
				}
			}
			return foundXmiElement;
		}
	}
}
