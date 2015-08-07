/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;
using mscEditor;
using MscItemProp;

namespace mscElements
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	partial class Task
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 30, 60, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,40,10,40,70);
			drawDestination.FillRectangle(Brushes.White,10,30,60,20);
			drawDestination.DrawString("Task",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawRectangle(Pens.Black,10,30,60,20);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, ItemPos pos)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 30, 60, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.DarkGray,40,10,40,70);
			drawDestination.FillRectangle(Brushes.White,10,30,60,20);
			drawDestination.DrawString("Task",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawRectangle(Pens.Black,10,30,60,20);
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
			insertString = "task: InstanceId, TaskText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			TaskProp property = new TaskProp();
			property.TaskText = this.mName.Replace("\n",@"\n");
			property.ItemID = mID;
			property.EditorText = text;
			property.TaskPosition = this.Position;
			return property;
		}
	}
}
