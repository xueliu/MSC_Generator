/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:23
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
	partial class TimeOut
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 20, 60, 30);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.Black,10,50,65,50);
			PointF[] capPolygon = new PointF[3];
			if (mMscStyle==MscStyle.SDL){
				capPolygon[0] = new PointF(10, 50);
				capPolygon[1] = new PointF(10+8, 50-4);
				capPolygon[2] = new PointF(10+8, 50+4);
				drawDestination.FillPolygon(Brushes.Black,capPolygon);				
			}
			else if (mMscStyle == MscStyle.UML2){
				drawDestination.DrawLine(Pens.Black,10,50,10+8, 50-4);
				drawDestination.DrawLine(Pens.Black,10,50,10+8, 50+4);												
			}
			capPolygon[0] = new PointF(65, 50);
			capPolygon[1] = new PointF(70, 45);
			capPolygon[2] = new PointF(60, 45);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			capPolygon[0] = new PointF(65, 50);
			capPolygon[1] = new PointF(70, 55);
			capPolygon[2] = new PointF(60, 55);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			drawDestination.DrawString("Timeout",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, ItemPos position)
		{
			StringFormat itemStringFormat = new StringFormat();		
			if (position == ItemPos.Left){
				drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
				RectangleF itemBox = new RectangleF(15, 30, 60, 12);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawLine(Pens.Black,15,50,70,50);
				PointF[] capPolygon = new PointF[3];
				if (mMscStyle==MscStyle.SDL){
					capPolygon[0] = new PointF(70, 50);
					capPolygon[1] = new PointF(70-8, 50-4);
					capPolygon[2] = new PointF(70-8, 50+4);
					drawDestination.FillPolygon(Brushes.Black,capPolygon);				
				}
				else if (mMscStyle == MscStyle.UML2){
					drawDestination.DrawLine(Pens.Black,70,50,70-8, 50-4);
					drawDestination.DrawLine(Pens.Black,70,50,70-8, 50+4);												
				}
				capPolygon[0] = new PointF(15, 50);
				capPolygon[1] = new PointF(10, 45);
				capPolygon[2] = new PointF(20, 45);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				capPolygon[0] = new PointF(15, 50);
				capPolygon[1] = new PointF(10, 55);
				capPolygon[2] = new PointF(20, 55);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				drawDestination.DrawString("TimeOut",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				
			}
			else if (position == ItemPos.Right){
				drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
				RectangleF itemBox = new RectangleF(10, 30, 60, 12);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawLine(Pens.Black,10,50,65,50);
				PointF[] capPolygon = new PointF[3];
				if (mMscStyle==MscStyle.SDL){
					capPolygon[0] = new PointF(10, 50);
					capPolygon[1] = new PointF(10+8, 50-4);
					capPolygon[2] = new PointF(10+8, 50+4);
					drawDestination.FillPolygon(Brushes.Black,capPolygon);				
				}
				else if (mMscStyle == MscStyle.UML2){
					drawDestination.DrawLine(Pens.Black,10,50,10+8, 50-4);
					drawDestination.DrawLine(Pens.Black,10,50,10+8, 50+4);												
				}
				capPolygon[0] = new PointF(65, 50);
				capPolygon[1] = new PointF(70, 45);
				capPolygon[2] = new PointF(60, 45);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				capPolygon[0] = new PointF(65, 50);
				capPolygon[1] = new PointF(70, 55);
				capPolygon[2] = new PointF(60, 55);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				drawDestination.DrawString("TimeOut",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
			insertString = "timeout: InstanceId, TimerText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			TimeOutProp property = new TimeOutProp();
			property.TimerText = this.mName.Replace("\n",@"\n");
			property.TimerPosition = this.mPos;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}		
	}
}
