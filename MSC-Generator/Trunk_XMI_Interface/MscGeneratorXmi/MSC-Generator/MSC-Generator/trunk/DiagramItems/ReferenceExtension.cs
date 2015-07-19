/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 08:05
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
	/// Description of Reference.
	/// </summary>
	partial class Reference
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			if (mMscStyle==MscStyle.UML2){
				StringFormat itemStringFormat = new StringFormat();				
				RectangleF itemBox = new RectangleF(5, 20, 30, 15);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemStringFormat.LineAlignment = StringAlignment.Near;
				PointF[] statePolygon = new PointF[5];
				statePolygon[0] = new PointF(5,20);
				statePolygon[1] = new PointF(40,20);
				statePolygon[2] = new PointF(40,30);
				statePolygon[3] = new PointF(35,35);
				statePolygon[4] = new PointF(5,35);
				drawDestination.FillRectangle(Brushes.White,5,20,70,40);
				drawDestination.DrawString("ref",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawPolygon(Pens.Black,statePolygon);
				itemBox = new RectangleF(5, 30, 70, 30);
				itemStringFormat.Alignment = StringAlignment.Center;
				itemStringFormat.LineAlignment = StringAlignment.Center;
				drawDestination.DrawString("Reference",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawRectangle(Pens.Black,5,20,70,40);
				itemStringFormat.Dispose();
			}
			else if (mMscStyle==MscStyle.SDL){
				StringFormat itemStringFormat = new StringFormat();				
				RectangleF itemBox = new RectangleF(10, 25, 60, 30);
				itemStringFormat.Alignment = StringAlignment.Center;
				itemStringFormat.LineAlignment = StringAlignment.Center;
				
				drawDestination.FillPie(Brushes.White,5,20,10,10,180,90);
				drawDestination.FillPie(Brushes.White,5,50,10,10,90,90);
				drawDestination.FillPie(Brushes.White,65,20,10,10,270,90);
				drawDestination.FillPie(Brushes.White,65,50,10,10,0,90);
				
				drawDestination.FillRectangle(Brushes.White, 5, 25, 5, 30);
				drawDestination.FillRectangle(Brushes.White, 70, 25, 5, 30);
				drawDestination.FillRectangle(Brushes.White, 10, 20, 60, 40);
				
				drawDestination.DrawLine(Pens.Black,10,20,70,20);
				drawDestination.DrawLine(Pens.Black,5,25,5,55);						
				drawDestination.DrawLine(Pens.Black,10,60,70,60);						
				drawDestination.DrawLine(Pens.Black,75,25,75,55);						

				drawDestination.DrawArc(Pens.Black,5,20,10,10,180,90);
				drawDestination.DrawArc(Pens.Black,5,50,10,10,90,90);
				drawDestination.DrawArc(Pens.Black,65,20,10,10,270,90);
				drawDestination.DrawArc(Pens.Black,65,50,10,10,0,90);
				
				drawDestination.DrawString("Reference",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
			insertString = "ref: FirstInstanceId, LastInstanceId, ReferenceText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			ReferenceProp property = new ReferenceProp();
			property.ReferenceText = this.mName.Replace("\n",@"\n");
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
