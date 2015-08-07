/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:11
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
	
	partial class State
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(15, 30, 50, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,40,10,40,70);
			if (mMscStyle == MscStyle.SDL){
				PointF[] statePolygon = new PointF[6];
				statePolygon[0] = new PointF(5,40);
				statePolygon[1] = new PointF(15,30);
				statePolygon[2] = new PointF(65,30);
				statePolygon[3] = new PointF(75,40);
				statePolygon[4] = new PointF(65,50);
				statePolygon[5] = new PointF(15,50);
				drawDestination.FillPolygon(Brushes.White,statePolygon);
				drawDestination.DrawString("State",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				drawDestination.DrawPolygon(Pens.Black,statePolygon);
			}
			else if(mMscStyle == MscStyle.UML2){
					drawDestination.FillRectangle(Brushes.White,itemBox);
					drawDestination.FillEllipse(Brushes.White,5,30,20,20);
					drawDestination.FillEllipse(Brushes.White,55,30,20,20);
					drawDestination.DrawLine(Pens.Black,15,30,65,30);						
					drawDestination.DrawLine(Pens.Black,15,50,65,50);
					drawDestination.DrawArc(Pens.Black,5,30,20,20,90,180);
					drawDestination.DrawArc(Pens.Black,55,30,20,20,270,180);
					drawDestination.DrawString("State",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			}
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, StateStyle style, MscStyle style2)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(15, 30, 50, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.DarkGray,40,10,40,70);
			if (style2 == MscStyle.SDL){
				if (style == StateStyle.Box){
					PointF[] statePolygon = new PointF[6];
					statePolygon[0] = new PointF(5,40);
					statePolygon[1] = new PointF(15,30);
					statePolygon[2] = new PointF(65,30);
					statePolygon[3] = new PointF(75,40);
					statePolygon[4] = new PointF(65,50);
					statePolygon[5] = new PointF(15,50);
					drawDestination.FillPolygon(Brushes.White,statePolygon);
					drawDestination.DrawString("State",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					drawDestination.DrawPolygon(Pens.Black,statePolygon);
				}
				else if(style == StateStyle.Bracket){
					drawDestination.FillRectangle(Brushes.White,itemBox);
					drawDestination.DrawString("{State}",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				}
			}
			else if(style2 == MscStyle.UML2){
				if (style == StateStyle.Box){
					drawDestination.FillRectangle(Brushes.White,itemBox);
					drawDestination.FillEllipse(Brushes.White,5,30,20,20);
					drawDestination.FillEllipse(Brushes.White,55,30,20,20);
					drawDestination.DrawLine(Pens.Black,15,30,65,30);						
					drawDestination.DrawLine(Pens.Black,15,50,65,50);
					drawDestination.DrawArc(Pens.Black,5,30,20,20,90,180);
					drawDestination.DrawArc(Pens.Black,55,30,20,20,270,180);
					drawDestination.DrawString("State",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
				}
				else if(style == StateStyle.Bracket){
					drawDestination.FillRectangle(Brushes.White,itemBox);
					drawDestination.DrawString("{State}",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
			insertString = "state: InstanceId, StateText;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}		
		public override Property GetPropertyDialog(string text)
		{
			StateProp property = new StateProp();
			property.StateText = this.mName.Replace("\n",@"\n");
			property.StatePosition = this.mPos;
			property.Style = this.mStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
