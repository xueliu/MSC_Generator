/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 02.06.2005
 * Time: 14:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
using mscEditor;
using MscItemProp;

namespace mscElements
{
	
	partial class Mark
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 20, 60, 20);
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			itemStringFormat.Alignment = StringAlignment.Far;
			itemStringFormat.LineAlignment = StringAlignment.Far;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(rPen,10,50,20,40);
			drawDestination.DrawLine(rPen,20,40,70,40);
			drawDestination.DrawString("Mark",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			rPen.Dispose();
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, MarkPos pos)
		{
			StringFormat itemStringFormat = new StringFormat();				
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			if (pos == MarkPos.TopLeft){
				RectangleF itemBox = new RectangleF(1, 10, 60, 20);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
				drawDestination.DrawLine(rPen,60,30,70,40);
				drawDestination.DrawLine(rPen,1,30,60,30);
				drawDestination.DrawString("Mark",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);			
			}
			else if (pos == MarkPos.TopRight){
				RectangleF itemBox = new RectangleF(20, 10, 59, 20);
				itemStringFormat.Alignment = StringAlignment.Far;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
				drawDestination.DrawLine(rPen,10,40,20,30);
				drawDestination.DrawLine(rPen,20,30,79,30);
				drawDestination.DrawString("Mark",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);			
			}
			else if (pos == MarkPos.BottomLeft){
				RectangleF itemBox = new RectangleF(1, 30, 60, 20);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
				drawDestination.DrawLine(rPen,60,50,70,40);
				drawDestination.DrawLine(rPen,1,50,60,50);
				drawDestination.DrawString("Mark",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);			
			}
			else if (pos == MarkPos.BottomRight){
				RectangleF itemBox = new RectangleF(20, 30, 59, 20);
				itemStringFormat.Alignment = StringAlignment.Far;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
				drawDestination.DrawLine(rPen,10,40,20,50);
				drawDestination.DrawLine(rPen,20,50,79,50);
				drawDestination.DrawString("Mark",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);			
			}
			rPen.Dispose();
			itemStringFormat.Dispose();
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
			insertString = "mark: InstanceId, MarkText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			MscMarkProp property 	= new MscMarkProp();
			property.MarkText 		= this.mName.Replace("\n",@"\n");
			property.MarkPosition 	= this.mPos;
			property.ItemID 		= mID;
			property.EditorText 	= text;
			return property;
		}
	}
}
