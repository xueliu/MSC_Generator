/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 31.08.2006
 * Time: 19:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
using mscEditor;

namespace mscElements
{
	/// <summary>
	/// Description of InLineBeginn.
	/// </summary>
	partial class InLineSeparator
	{
		public static void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(5, 15, 30, 15);
			RectangleF itemBox2 = new RectangleF(5, 35, 70, 15);
			itemStringFormat.Alignment = StringAlignment.Near;
			itemStringFormat.LineAlignment = StringAlignment.Near;
			PointF[] statePolygon = new PointF[5];
			statePolygon[0] = new PointF(5,15);
			statePolygon[1] = new PointF(40,15);
			statePolygon[2] = new PointF(40,25);
			statePolygon[3] = new PointF(35,30);
			statePolygon[4] = new PointF(5,30);
			drawDestination.FillPolygon(Brushes.White,statePolygon);
			drawDestination.DrawPolygon(Pens.LightGray,statePolygon);
			drawDestination.DrawRectangle(Pens.LightGray,5,15,70,50);
			drawDestination.DrawString("frag",new Font("Arial",8,FontStyle.Regular),Brushes.LightGray,itemBox,itemStringFormat);
			Pen rPen = new Pen(Color.Black);
			float[] pattern = {4f,4f};
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			itemStringFormat.Alignment = StringAlignment.Center;
			drawDestination.DrawString("separator",new Font("Arial",8,FontStyle.Italic),Brushes.Black,itemBox2,itemStringFormat);
			drawDestination.DrawLine(rPen, 5, 50, 75, 50);
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
			insertString = "fragmentseparator: FragmentId;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
	}
}
