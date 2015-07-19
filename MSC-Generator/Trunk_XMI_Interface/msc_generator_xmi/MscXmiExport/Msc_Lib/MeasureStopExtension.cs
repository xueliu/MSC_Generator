/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 12:14
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
	partial class MeasureStop
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat 	= new StringFormat();				
			RectangleF itemBox 				= new RectangleF(10, 25, 60, 30);
			float[] pattern 				= {4f,4f};
			Pen rPen 						= new Pen(Color.Black);
			rPen.DashStyle 					= System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern 				= pattern;
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(rPen,10,60,70,60);
			PointF[] capPolygon = new PointF[3];
			capPolygon[0] = new PointF(65, 61);
			capPolygon[1] = new PointF(69, 69);
			capPolygon[2] = new PointF(61, 69);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			drawDestination.DrawLine(rPen,65,50,65,60);
			drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,40,10,10));
			drawDestination.DrawString("Measure\nstop",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
					RectangleF itemBox = new RectangleF(21, 50, 49, 10);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(15, 59);
					capPolygon[1] = new PointF(10, 54);
					capPolygon[2] = new PointF(20, 54);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,15,40,15,54);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(10,30,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
					itemBox = new RectangleF(22, 30, 48, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
				}
				else{
					RectangleF itemBox = new RectangleF(21, 50, 49, 10);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(15, 61);
					capPolygon[1] = new PointF(10, 66);
					capPolygon[2] = new PointF(20, 66);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,15,40,15,60);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(10,30,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
					itemBox = new RectangleF(22, 30, 48, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
				}
			}
			else{
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,10,5,10,75);
				if (style == CapStyle.Inner){
					RectangleF itemBox = new RectangleF(10, 50, 50, 10);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(65, 59);
					capPolygon[1] = new PointF(70, 54);
					capPolygon[2] = new PointF(60, 54);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,65,40,65,54);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,30,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
					itemStringFormat.Alignment = StringAlignment.Far;
					itemBox = new RectangleF(20, 30, 40, 10);
					drawDestination.DrawString("g",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
				}
				else{
					RectangleF itemBox = new RectangleF(10, 50, 50, 10);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(65, 61);
					capPolygon[1] = new PointF(70, 66);
					capPolygon[2] = new PointF(60, 66);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,65,40,65,60);
					drawDestination.DrawEllipse(Pens.Black, new RectangleF(60,30,10,10));
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
					itemStringFormat.Alignment = StringAlignment.Far;
					itemBox = new RectangleF(20, 30, 40, 10);
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
			insertString = "measurestop: InstanceId, GateText, MeasureText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			MeasureStopProp property = new MeasureStopProp();
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
