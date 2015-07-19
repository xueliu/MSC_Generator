//#define TRACE
/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 18.05.2005
 * Time: 14:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Diagnostics;
using mscElements;
using MscItemProp;
using GeneratorGUI;

namespace nGenerator
{
	/// <summary>
	/// Description of Generator.
	/// </summary>
	public partial class Generator
	{	
		
		private Output output = null;		
				
		public Generator(Output o)
		{
			pageHeights = new ArrayList();		// stores the heights of each page of the diagram. Necessery for auto height option
			processes = new ArrayList();		// stores the instances (proces, actor, dummy) of the diagram
			items = new ArrayList();			// stores the items of the diagram
			lines = new ArrayList();			// stores the verical lines of instance, timer, measure, etc.
			inLines = new ArrayList();			// stores the inlines of ref and inline
			mYInstanceOffset = 110;
			mYProcessName = 0;
			mHeadHeight = 0;
			mProcessNameHeight = 0;
			mInstanceNameHeight = 0;
			mLines=0;
			output = o;
		}
		
		//Added by LG
		public ArrayList Items{
			get{
				return this.items;
			}
			set{
				this.items=value;
			}
		}

		//Added by LG
		public ArrayList Processes{
			get{
				return this.processes;
			}
			set{
				this.processes=value;
			}
		}
		
		
		///<summary>
		/// Opens an options dialog of the selected msc item
		/// </summary>
		/// <param name="page">current page of msc</param>
		/// <param name="id">id of the msc item</param>
		/// <param name="text">text line of selected msc item</param>
		public void EditItemProperties(uint page, int id, string text)
		{
			IEnumerator enumerator = items.GetEnumerator();		// enumerator of items
			IEnumerator enumerator2 = lines.GetEnumerator();   	// enumerator of lines
			Rectangle bounds=new Rectangle(0,0,0,0);
			if(OptionsDialog.ActiveDialog !=null){				// options dialog visible ?
				bounds = OptionsDialog.ActiveDialog.Bounds;		// keep the location of option dialog
				OptionsDialog.ActiveDialog.Close();				// and close
			}
			Property prop = null;
			for(uint i=0;i<lines.Count;i++){					// search for diagram item in processes
				enumerator2.MoveNext();
				if (enumerator2.Current is ProcessLine){
					if ((((ProcessLine)enumerator2.Current).FirstPage<=page)&&(((ProcessLine)enumerator2.Current).LastPage>=page)){
						if (((ProcessLine)enumerator2.Current).ItemID ==id){
							prop = ((MSCItem)enumerator2.Current).GetPropertyDialog(text);
							if (prop != null){
								prop.Location = OptionsDialog.DialogLocation;
								prop.OnAcceptClick += new System.EventHandler(this.ItemPropertiesAcceptClick);
								prop.Show();
								return;
							}
						}
					}
				}
			}
			for(uint i=0;i<items.Count;i++){					// search for diagram item in items
				enumerator.MoveNext();
				if (((MSCItem)enumerator.Current).ItemID ==id){
				    if (((MSCItem)enumerator.Current).ItemPage == page){
						prop = ((MSCItem)enumerator.Current).GetPropertyDialog(text);
						if (prop != null){
							prop.OnAcceptClick += new System.EventHandler(this.ItemPropertiesAcceptClick);
							prop.Location = OptionsDialog.DialogLocation;
							prop.Show();
							return;
						}
				    }
				}
			}
		}
		
		public void ItemPropertiesAcceptClick(object sender, EventArgs e)
		{
			MSCItem item = GetMscItemByID(((Property)sender).ItemID);
			if (item != null){
				output.ChangeEditorText(item.FileLine, ((Property)sender).PropText);
			}
			MSC.Style = ((Property)sender).DiagramStyle;
			MSC.DiagramName = ((Property)sender).DiagramName;
			Output.AutosizeExport = ((Property)sender).AutosizeExport;
			output.RedrawRescaled();
		}
		
		///<summary>
		/// Draws the selection of the item as a red rectangle. Checks also the integrity on the selected page
		/// </summary>
		/// <param name="drawDestination">Graphics object of the draw destination</param>
		/// <param name="item">object of the selected item</param>
		/// <param name="text">current selected page</param>
		public void DrawSelection(Graphics drawDestination, MSCItem item, int page)
		{
			if(item!=null){
				if (item.IsOnPage(page))
					drawDestination.DrawRectangle(Pens.Red,item.bounds.X,item.bounds.Y,item.bounds.Width,item.bounds.Height);
			}
		}		
		/// <summary>
		/// returns a MscItem by a gived id
		/// </summary>
		/// <param name="id">id of the msc item</param>
		/// <returns>msc item with the given id or null if id not found</returns>
		public MSCItem GetMscItemByID (int id)
		{
			IEnumerator enumerator = items.GetEnumerator();
			IEnumerator enumerator2 = lines.GetEnumerator();
			for(uint i=0;i<items.Count;i++){
				enumerator.MoveNext();
				if (((MSCItem)enumerator.Current).ItemID == id)
					return (MSCItem)enumerator.Current;
			}
			for(uint i=0;i<lines.Count;i++){
				enumerator2.MoveNext();
				if (enumerator2.Current is ProcessLine){
					if (((MSCItem)enumerator2.Current).ItemID == id)
						return (MSCItem)enumerator2.Current;
				}
			}			
			return null;
		}
		/// <summary>
		/// returns a MscItem by a mouse position
		/// </summary>
		/// <param name="page">currently selected page</param>
		/// <param name="x">x position of the mouse pointer</param>
		/// <param name="y">y position of the mouse pointer</param>
		/// <returns>msc item under the mouse pointer or null if no msc item found</returns>
		public MSCItem GetMscItemByMouse(uint page, float x, float y)
		{
			IEnumerator enumerator = items.GetEnumerator();
			IEnumerator enumerator2 = lines.GetEnumerator();
			for(uint i=0;i<items.Count;i++){
				enumerator.MoveNext();
				if (((MSCItem)enumerator.Current).ItemPage == page){
					if (((MSCItem)enumerator.Current).bounds.Contains(x,y)){
						return ((MSCItem)enumerator.Current);
					}
				}
			}
			for(uint i=0;i<lines.Count;i++){
				enumerator2.MoveNext();
				if (enumerator2.Current is ProcessLine){
					if ((((ProcessLine)enumerator2.Current).FirstPage<=page)&&(((ProcessLine)enumerator2.Current).LastPage>=page)){
						if (((ProcessLine)enumerator2.Current).bounds.Contains(x,y)){
							return ((ProcessLine)enumerator2.Current);
						}
					}
				}
			}			
			return null;
		}
	}
}
