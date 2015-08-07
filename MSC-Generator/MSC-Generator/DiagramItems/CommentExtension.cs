/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 19:13
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
	/// Description of Comment.
	/// </summary>
	/// 
	partial class Comment
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 30, 60, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			PointF[] statePolygon = new PointF[5];
			statePolygon[0] = new PointF(20,10);
			statePolygon[1] = new PointF(70,10);
			statePolygon[2] = new PointF(70,70);
			statePolygon[3] = new PointF(10,70);
			statePolygon[4] = new PointF(10,20);
			drawDestination.FillPolygon(Brushes.White,statePolygon);
			drawDestination.DrawString("Comment",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawPolygon(Pens.Black,statePolygon);
			drawDestination.DrawLine(Pens.Black,10,20,20,20);
			drawDestination.DrawLine(Pens.Black,20,10,20,20);
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
			insertString = "comment: InstanceID, CommentText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}		
		public override Property GetPropertyDialog(string text)
		{
			CommentProp property = new CommentProp();
			property.CommentText = this.mName.Replace("\n",@"\n");
			property.CommentPosition = this.pos;
			property.Instance = this.mCommentInstance;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}		
	}
}
