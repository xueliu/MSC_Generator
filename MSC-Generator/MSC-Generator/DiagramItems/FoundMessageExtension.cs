/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 31.08.2006
 * Time: 18:53
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
	/// Description of FoundMessageExtension.
	/// </summary>
	partial class FoundMessage
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(18, 30, 42, 10);
			RectangleF itemBox2 = new RectangleF(60, 48, 10, 10);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Far;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			if (MSCItem.Style == MscStyle.SDL){
				PointF[] capPolygon = new PointF[3];
				capPolygon[0] = new PointF(10, 40);
				capPolygon[1] = new PointF(18, 44);
				capPolygon[2] = new PointF(18, 36);
				drawDestination.FillPolygon(Brushes.Black,capPolygon);
				drawDestination.DrawString("Found",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox2,itemStringFormat);
				drawDestination.DrawLine(Pens.Black,10, 40, 60,40);
				drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,35, 10,10));
			}
			else if(MSCItem.Style == MscStyle.UML2){
				
				drawDestination.DrawString("Found",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox2,itemStringFormat);
				drawDestination.DrawLine(Pens.Black,10, 40, 60,40);
				drawDestination.DrawLine(Pens.Black,10, 40, 16,43);
				drawDestination.DrawLine(Pens.Black,10, 40, 16,37);
				drawDestination.FillEllipse(Brushes.Black, new RectangleF(60,35, 10,10));
				
			}
			itemStringFormat.Dispose();
		}

		static public void RepertoryImage(Graphics drawDestination, MessagePos pos, MscStyle style)
		{
			StringFormat itemStringFormat = new StringFormat();				
			if (style == MscStyle.SDL){
				if (pos == MessagePos.Right){
					RectangleF itemBox = new RectangleF(18, 30, 42, 10);
					RectangleF itemBox2 = new RectangleF(60, 48, 10, 10);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemStringFormat.LineAlignment = StringAlignment.Far;
					drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
					PointF[] capPolygon = new PointF[3];
					capPolygon[0] = new PointF(10, 40);
					capPolygon[1] = new PointF(18, 44);
					capPolygon[2] = new PointF(18, 36);
					drawDestination.FillPolygon(Brushes.Black,capPolygon);
					drawDestination.DrawString("Found",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox2,itemStringFormat);
					drawDestination.DrawLine(Pens.Black,10, 40, 60,40);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,35, 10,10));
				}
				else {
					RectangleF itemBox = new RectangleF(20, 30, 42, 10);
					RectangleF itemBox2 = new RectangleF(10, 48, 10, 10);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemStringFormat.LineAlignment = StringAlignment.Far;
					drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
					PointF[] capPolygon = new PointF[3];
					capPolygon[0] = new PointF(70, 40);
					capPolygon[1] = new PointF(62, 44);
					capPolygon[2] = new PointF(62, 36);
					drawDestination.FillPolygon(Brushes.Black,capPolygon);
					drawDestination.DrawString("Found",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox2,itemStringFormat);
					drawDestination.DrawLine(Pens.Black,20, 40, 70,40);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(10,35, 10,10));					
				}
			}
			else if(style == MscStyle.UML2){
				if (pos == MessagePos.Right){				
					RectangleF itemBox = new RectangleF(18, 30, 42, 10);
					RectangleF itemBox2 = new RectangleF(60, 48, 10, 10);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemStringFormat.LineAlignment = StringAlignment.Far;
					drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
					drawDestination.DrawString("Found",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox2,itemStringFormat);
					drawDestination.DrawLine(Pens.Black,10, 40, 60, 40);
					drawDestination.DrawLine(Pens.Black,10, 40, 16, 43);
					drawDestination.DrawLine(Pens.Black,10, 40, 16, 37);
					drawDestination.FillEllipse(Brushes.Black, new RectangleF(60,35, 10,10));
				}
				else{
					RectangleF itemBox = new RectangleF(20, 30, 42, 10);
					RectangleF itemBox2 = new RectangleF(10, 48, 10, 10);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemStringFormat.LineAlignment = StringAlignment.Far;
					drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
					drawDestination.DrawString("Found",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox2,itemStringFormat);
					drawDestination.DrawLine(Pens.Black,70, 40, 64, 43);
					drawDestination.DrawLine(Pens.Black,70, 40, 64, 37);
					drawDestination.DrawLine(Pens.Black,20, 40, 70,40);
					drawDestination.FillEllipse(Brushes.Black, new RectangleF(10,35, 10,10));										
				}
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
			insertString = "found: InstanceId, MessageText, GateText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			FoundMessageProp property = new FoundMessageProp();
			property.MessageText = this.mName.Replace("\n",@"\n");
			property.GateText = this.mGate.Replace("\n",@"\n");
			property.MessagePosition = this.mPos;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
