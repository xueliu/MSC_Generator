/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:07
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
	partial class SetTimer
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 30, 60, 30);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.Black,10,30,65,30);
			PointF[] capPolygon = new PointF[3];
			capPolygon[0] = new PointF(65, 30);
			capPolygon[1] = new PointF(70, 25);
			capPolygon[2] = new PointF(60, 25);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			capPolygon[0] = new PointF(65, 30);
			capPolygon[1] = new PointF(70, 35);
			capPolygon[2] = new PointF(60, 35);
			drawDestination.DrawPolygon(Pens.Black,capPolygon);
			drawDestination.DrawString("SetTimer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, ItemPos position)
		{
			StringFormat itemStringFormat = new StringFormat();		
			if (position == ItemPos.Left){
				drawDestination.DrawLine(Pens.DarkGray,70,10,70,70);
				RectangleF itemBox = new RectangleF(15, 10, 60, 12);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawLine(Pens.Black,15,30,70,30);
				PointF[] capPolygon = new PointF[3];
				capPolygon[0] = new PointF(15, 30);
				capPolygon[1] = new PointF(10, 25);
				capPolygon[2] = new PointF(20, 25);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				capPolygon[0] = new PointF(15, 30);
				capPolygon[1] = new PointF(10, 35);
				capPolygon[2] = new PointF(20, 35);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				drawDestination.DrawString("SetTimer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				
			}
			else if (position == ItemPos.Right){
				drawDestination.DrawLine(Pens.DarkGray,10,10,10,70);
				RectangleF itemBox = new RectangleF(10, 10, 60, 12);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				drawDestination.DrawLine(Pens.Black,10,30,65,30);
				PointF[] capPolygon = new PointF[3];
				capPolygon[0] = new PointF(65, 30);
				capPolygon[1] = new PointF(70, 25);
				capPolygon[2] = new PointF(60, 25);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				capPolygon[0] = new PointF(65, 30);
				capPolygon[1] = new PointF(70, 35);
				capPolygon[2] = new PointF(60, 35);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				drawDestination.DrawString("SetTimer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
			insertString = "settimer: InstanceId, TimerText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			SetTimerProp property = new SetTimerProp();
			property.TimerText = this.mName.Replace("\n",@"\n");
			property.TimerPosition = this.mPos;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
