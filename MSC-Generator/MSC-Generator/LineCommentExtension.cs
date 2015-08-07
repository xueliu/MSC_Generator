/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 10:28
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
	/// Description of Timeout.
	/// </summary>
	partial class LineComment
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(20, 30, 60, 20);
			itemStringFormat.Alignment = StringAlignment.Near;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.Black,10,40,16,40);
			drawDestination.DrawString("Comment",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, CommentPos pos, bool drawLine)
		{
			if (pos == CommentPos.Left){
				if (drawLine == true){
					StringFormat itemStringFormat = new StringFormat();				
					RectangleF itemBox = new RectangleF(0, 30, 60, 20);
					itemStringFormat.Alignment = StringAlignment.Far;
					itemStringFormat.LineAlignment = StringAlignment.Center;
					drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
					drawDestination.DrawLine(Pens.Black,70,40,64,40);
					drawDestination.DrawString("Comment",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					itemStringFormat.Dispose();										
				}
				else{
					StringFormat itemStringFormat = new StringFormat();				
					RectangleF itemBox = new RectangleF(0, 30, 70, 20);
					itemStringFormat.Alignment = StringAlignment.Far;
					itemStringFormat.LineAlignment = StringAlignment.Center;
					drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
					drawDestination.DrawString("Comment",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					itemStringFormat.Dispose();															
				}
			}
			else{
				if (drawLine == true){
					StringFormat itemStringFormat = new StringFormat();				
					RectangleF itemBox = new RectangleF(20, 30, 60, 20);
					itemStringFormat.Alignment = StringAlignment.Near;
					itemStringFormat.LineAlignment = StringAlignment.Center;
					drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
					drawDestination.DrawLine(Pens.Black,10,40,16,40);
					drawDestination.DrawString("Comment",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					itemStringFormat.Dispose();					
				}
				else{
					StringFormat itemStringFormat = new StringFormat();				
					RectangleF itemBox = new RectangleF(10, 30, 60, 20);
					itemStringFormat.Alignment = StringAlignment.Near;
					itemStringFormat.LineAlignment = StringAlignment.Center;
					drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
					drawDestination.DrawString("Comment",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					itemStringFormat.Dispose();					
				}
			}
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
			insertString = "linecomment: InstanceId, CommentText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;							
		}
		public override Property GetPropertyDialog(string text)
		{
			LineCommentProp property = new LineCommentProp();
			property.CommentText = this.mName.Replace("\n",@"\n");
			property.CommentPosition = this.mPos;
			property.CommentLine = this.mDrawLine;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
