/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 11:42
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
	partial class MeasureBeginn
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 30, 60, 20);
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(rPen,10,20,70,20);
			drawDestination.DrawLine(rPen,10,60,70,60);
			PointF[] capPolygon = new PointF[3];
			capPolygon[0] = new PointF(65, 19);
			capPolygon[1] = new PointF(69, 11);
			capPolygon[2] = new PointF(61, 11);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			capPolygon[0] = new PointF(65, 61);
			capPolygon[1] = new PointF(69, 69);
			capPolygon[2] = new PointF(61, 69);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			drawDestination.DrawLine(rPen,65,20,65,60);
			drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(15, 21);
					capPolygon[1] = new PointF(10, 26);
					capPolygon[2] = new PointF(20, 26);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					capPolygon[0] = new PointF(15, 59);
					capPolygon[1] = new PointF(10, 54);
					capPolygon[2] = new PointF(20, 54);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,15,26,15,54);
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
					
				}
				else{
					RectangleF itemBox = new RectangleF(15, 4, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(15, 19);
					capPolygon[1] = new PointF(10, 14);
					capPolygon[2] = new PointF(20, 14);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					capPolygon[0] = new PointF(15, 61);
					capPolygon[1] = new PointF(10, 66);
					capPolygon[2] = new PointF(20, 66);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,15,20,15,60);
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);					
				}
			}
			else{
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Far;
				drawDestination.DrawLine(Pens.DarkGray,10,5,10,75);
				if (style == CapStyle.Inner){
					RectangleF itemBox = new RectangleF(10, 10, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(65, 21);
					capPolygon[1] = new PointF(70, 26);
					capPolygon[2] = new PointF(60, 26);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					capPolygon[0] = new PointF(65, 59);
					capPolygon[1] = new PointF(70, 54);
					capPolygon[2] = new PointF(60, 54);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,65,26,65,54);
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);										
				}
				else{
					RectangleF itemBox = new RectangleF(10, 4, 50, 10);
					drawDestination.DrawLine(rPen,10,20,70,20);
					drawDestination.DrawLine(rPen,10,60,70,60);
					capPolygon[0] = new PointF(65, 19);
					capPolygon[1] = new PointF(70, 14);
					capPolygon[2] = new PointF(60, 14);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					capPolygon[0] = new PointF(65, 61);
					capPolygon[1] = new PointF(70, 66);
					capPolygon[2] = new PointF(60, 66);
					drawDestination.DrawPolygon(Pens.Black,capPolygon);
					drawDestination.DrawLine(rPen,65,20,65,60);
					drawDestination.DrawString("Measure",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);										
				}				
			}
			rPen.Dispose();
			itemStringFormat.Dispose();
		}
		static public void RepertoryText(NumberingEditor.NumberingRichTextBox ew)
		{
			int ss = ew.SelectionStart;
			int se = ew.SelectionStart + ew.SelectionLength;
			string st = ew.SelectedText;
			if (se>0) se--;
			if (st.IndexOf('\n')>-1){
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
				insertString = "measureend: InstanceId, MeasureEndText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = i+insertString.Length+1;		
				for(i=ss;i>0;i--){
					if (c[i]=='\n'){
						i++;
						break;							
					}
				}
				ew.SelectionStart = i;
				ew.SelectionLength = 0;
				insertString = "measurebegin: InstanceId, MeasureText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = i+insertString.Length+1;		
			}
			else{
				int nl = ew.Text.IndexOf('\n',se);
				if(nl>=0){
					nl++;
					ew.SelectionStart = nl;
					ew.SelectionLength = 0;
				}
				else {
					nl=ew.Text.Length;
					ew.SelectionStart = nl;
					ew.SelectionLength = 0;
					ew.SelectedText = "\n";		
				}
				string insertString = "measurebegin: InstanceId, MeasureText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				insertString = "measureend: InstanceId, MeasureEndText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = nl+insertString.Length+1;		
			}
		}
		public override Property GetPropertyDialog(string text)
		{
			MeasureBeginProp property = new MeasureBeginProp();
			property.MeasureText = this.mName.Replace("\n",@"\n");
			property.MeasurePosition = this.mPos;
			property.MeasureStyle = this.MeasureCapStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
