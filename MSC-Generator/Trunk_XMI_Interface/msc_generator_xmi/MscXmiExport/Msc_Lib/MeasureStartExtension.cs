/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 11:57
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
	partial class MeasureStart
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 35, 60, 30);
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(rPen,10,20,70,20);
			PointF[] capPolygon = new PointF[3];
			capPolygon[0] = new PointF(65, 19);
			capPolygon[1] = new PointF(69, 11);
			capPolygon[2] = new PointF(61, 11);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			drawDestination.DrawLine(rPen,65,20,65,30);
			drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,30,10,10));
			drawDestination.DrawString("Measure\nstart",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			rPen.Dispose();
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, MeasurePos pos, CapStyle style)
		{
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			PointF[] capPolygon = new PointF[3];
			StringFormat itemStringFormat = new StringFormat();				
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			if (pos == MeasurePos.Left){
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,70,5,70,75);
				if (style == CapStyle.Inner){
					RectangleF itemBox = new RectangleF(15, 10, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					capPolygon[0] = new PointF(15, 21);
					capPolygon[1] = new PointF(10, 26);
					capPolygon[2] = new PointF(20, 26);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,15,26,15,40);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(10,40,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					itemBox = new RectangleF(22, 40, 48, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				}
				else{
					RectangleF itemBox = new RectangleF(15, 4, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					capPolygon[0] = new PointF(15, 19);
					capPolygon[1] = new PointF(10, 14);
					capPolygon[2] = new PointF(20, 14);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,15,26,15,40);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(10,40,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					itemBox = new RectangleF(22, 40, 48, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				}
			}
			else{
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,10,5,10,75);
				if (style == CapStyle.Inner){
					RectangleF itemBox = new RectangleF(10, 10, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					capPolygon[0] = new PointF(65, 21);
					capPolygon[1] = new PointF(70, 26);
					capPolygon[2] = new PointF(60, 26);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,65,26,65,40);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,40,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);										
					itemStringFormat.Alignment = StringAlignment.Far;					
					itemBox = new RectangleF(10, 40, 48, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				}
				else{
					RectangleF itemBox = new RectangleF(10, 4, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					capPolygon[0] = new PointF(65, 19);
					capPolygon[1] = new PointF(70, 14);
					capPolygon[2] = new PointF(60, 14);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,65,20,65,40);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,40,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);										
					itemStringFormat.Alignment = StringAlignment.Far;					
					itemBox = new RectangleF(10, 40, 48, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				}				
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
			insertString = "measurestart: InstanceId, GateText, MeasureText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			MeasureStartProp property = new MeasureStartProp();
			property.MeasureText = this.mName.Replace("\n",@"\n");
			property.GateText = this.mGate.Replace("\n",@"\n");
			property.MeasurePosition = this.mPos;
			property.MeasureStyle = this.mCapStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
