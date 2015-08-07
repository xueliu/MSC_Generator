/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 28.05.2008
 * Time: 18:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of Tools.
	/// </summary>
	public delegate void RunToolFunction(bool state);
	public partial class Tools
	{
		private string toolState;
		private GUI parentGUI;
		public Tools(GUI parent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			/* Example to add buttons to toolbox */
			
			IEnumerator enumerator = this.toolImageList.Images.GetEnumerator();
			enumerator.MoveNext();
			AddToolCommands((Image)enumerator.Current,"Cursor",new RunToolFunction(parent.ToolCursor));
			enumerator.MoveNext();
			AddToolCommands((Image)enumerator.Current,"Zoom",new RunToolFunction(parent.ToolZoom));
			parentGUI = parent;
		}
        public string ToolState{
        	get{
        		return toolState;
        	}
			set{
				toolState = value;
			}        
        }
		protected virtual void ToolClick(object sender, System.EventArgs e)				
		{
			System.Windows.Forms.ToolStripButton button = (System.Windows.Forms.ToolStripButton)sender;
			ToolStripItemCollection ic = this.toolStrip1.Items;
			IEnumerator enumerator = ic.GetEnumerator();
			//MessageBox.Show(((System.Windows.Forms.ToolStrip)(button.Container)).Items.Count.ToString());
			for(uint i=0; i<this.toolStrip1.Items.Count; i++){											// for all generetad preview images
				enumerator.MoveNext();
				if(((System.Windows.Forms.ToolStripButton)(enumerator.Current)).Checked==true){
					((System.Windows.Forms.ToolStripButton)(enumerator.Current)).Checked = false;
					RunToolFunction rtf = (RunToolFunction)((System.Windows.Forms.ToolStripButton)(enumerator.Current)).Tag;
					rtf(false);
				}
					
			}
			button.Checked = true;
			
			if (button.Tag!=null){
				RunToolFunction rtf = (RunToolFunction) button.Tag;
				rtf(true);
				this.ToolState = button.Text;
				
			}
			

		}
		/* Function to add a button to toolset 
		 * img: 	Image to be showed on button. Size 16x16px
		 * text: 	tooltip text
		 * rtf: 	function to be called on activate with parameter true and deactivate with parameter false
		 */
		
		public virtual void AddToolCommands(Image img, String text, RunToolFunction rtf){
			System.Windows.Forms.ToolStripButton  toolStripButtonX;
			toolStripButtonX =new System.Windows.Forms.ToolStripButton();
			toolStripButtonX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			toolStripButtonX.Image = img;
			toolStripButtonX.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButtonX.Size = new System.Drawing.Size(20, 20);
			toolStripButtonX.Text = text;
			toolStripButtonX.Click += new EventHandler(ToolClick);
			toolStripButtonX.Tag = rtf;
			this.toolStrip1.Items.Add(toolStripButtonX);
			
			System.GC.Collect();
		}
	}
}
