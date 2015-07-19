/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:17
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
	/// <summary>
	/// Description of TimeoutEnd.
	/// </summary>
	partial class StopTimer
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 20, 60, 30);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.Black,10,50,65,50);
			drawDestination.DrawLine(Pens.Black,61,46,69,54);
			drawDestination.DrawLine(Pens.Black,61,54,69,46);
			drawDestination.DrawString("Stop timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, ItemPos position)
		{
			StringFormat itemStringFormat = new StringFormat();		
			if (position == ItemPos.Left){
				drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
				RectangleF itemBox = new RectangleF(15, 12, 60, 14);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawLine(Pens.Black,15,30,70,30);
				drawDestination.DrawLine(Pens.Black,11,26,19,34);
				drawDestination.DrawLine(Pens.Black,11,34,19,26);
				drawDestination.DrawString("StopTimer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			}
			else if (position == ItemPos.Right){
				drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
				RectangleF itemBox = new RectangleF(11, 12, 60, 14);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawLine(Pens.Black,10,30,65,30);
				drawDestination.DrawLine(Pens.Black,61,26,69,34);
				drawDestination.DrawLine(Pens.Black,61,34,69,26);
				drawDestination.DrawString("StopTimer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			}
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
			insertString = "stoptimer: InstanceId, TimerText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			StopTimerProp property = new StopTimerProp();
			property.TimerText = this.mName.Replace("\n",@"\n");
			property.TimerPosition = this.mPos;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}		
	}
}
