/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 07:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using mscEditor;
using nGenerator;
using MscItemProp;

namespace mscElements
{
	
	partial class ProcessLine
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 10, 60, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.Black,40,30,40,70);
			drawDestination.FillRectangle(Brushes.White,10,10,60,20);
			drawDestination.DrawString("Process",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawRectangle(Pens.Black,10,10,60,20);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImageActor(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 38, 60, 12);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawEllipse(Pens.Black,36,10,8,8);
			drawDestination.DrawLine(Pens.Black,40,18,40,28);
			drawDestination.DrawLine(Pens.Black,32,20,48,20);
			drawDestination.DrawLine(Pens.Black,40,28,48,36);
			drawDestination.DrawLine(Pens.Black,40,28,32,36);
			drawDestination.DrawString("Actor",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawLine(Pens.Black,40,50,40,70);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, ProcessType type)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 10, 60, 20);
			Pen pen = new Pen(Color.Black);
			float[] pattern = {3f,3f};
			if(MSCItem.Style == MscStyle.UML2){
				pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
				pen.DashPattern = pattern;	
			}
			else if (MSCItem.Style == MscStyle.SDL){
				pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			}
			if(type == ProcessType.Actor){
				itemBox = new RectangleF(10, 0, 60, 14);
				itemStringFormat.Alignment = StringAlignment.Center;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawString("Description",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				itemStringFormat.LineAlignment = StringAlignment.Center;
				drawDestination.DrawEllipse(Pens.Black,36,14,8,8);
				drawDestination.DrawLine(Pens.Black,40,22,40,32);
				drawDestination.DrawLine(Pens.Black,32,24,48,24);
				drawDestination.DrawLine(Pens.Black,40,32,48,40);
				drawDestination.DrawLine(Pens.Black,40,32,32,40);
				itemBox = new RectangleF(10, 42, 60, 12);
				drawDestination.DrawString("Actor",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawLine(pen,40,56,40,75);
			}
			else if (type == ProcessType.Normal){
				itemBox = new RectangleF(10, 0, 60, 14);
				itemStringFormat.Alignment = StringAlignment.Center;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawString("Description",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				itemStringFormat.LineAlignment = StringAlignment.Center;
				drawDestination.FillRectangle(Brushes.White,10,14,60,20);
				itemBox = new RectangleF(10, 14, 60, 20);
				drawDestination.DrawString("Process",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawRectangle(Pens.Black,10,14,60,20);
				drawDestination.DrawLine(pen,40,34,40,75);
			}
			itemStringFormat.Dispose();
			pen.Dispose();
		}
		static public void RepertoryText(NumberingEditor.NumberingRichTextBox ew)
		{
			int ss = ew.SelectionStart;
			int se = ew.SelectionStart + ew.SelectionLength;
			if (se>0) se--;
			string insertString;
			char [] c = ew.Text.ToCharArray();
			int i=0;
			for(i=se;i<c.Length;i++){
				if (c[i]=='\n'){
					i++;
					break;
				}
			}
			ew.SelectionStart = i;
			ew.SelectionLength = 0;
			insertString = "process: InstanceId, ProcessName, ProcessDescription;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		static public void RepertoryTextActor(NumberingEditor.NumberingRichTextBox ew)
		{
			int ss = ew.SelectionStart;
			int se = ew.SelectionStart + ew.SelectionLength;
			if (se>0) se--;
			string insertString;
			char [] c = ew.Text.ToCharArray();
			int i=0;
			for(i=se;i<c.Length;i++){
				if (c[i]=='\n'){
					i++;
					break;
				}
			}
			ew.SelectionStart = i;
			ew.SelectionLength = 0;
			insertString = "actor: InstanceId, ActorName, ActorDescription;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			if (mCreatingProcess!=null){				// created by ProcessCreate-Command
				return mCreatingProcess.GetPropertyDialog(text);
			}
			else{
				ProcessLineProp property = new ProcessLineProp();
				property.ProcessText = this.mName.Replace("\n",@"\n");
				property.DescriptionText = this.mDescription.Replace("\n",@"\n");
				property.Type = this.mType;
				property.LeftText = this.mLeft;
				property.RightText = this.mRight;
				property.ItemID = mID;
				property.EditorText = text;
				return property;
			}
		}
	}
}
