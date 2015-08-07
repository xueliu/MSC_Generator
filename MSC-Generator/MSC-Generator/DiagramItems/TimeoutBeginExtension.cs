/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:28
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
	partial class TimeoutBegin
	{
		static public void RepertoryImage(Graphics drawDestination, ItemPos pos, ItemStyle style, MscStyle style2)
		{
			StringFormat itemStringFormat = new StringFormat();				
			if (style2 == MscStyle.UML2){
				if (pos == ItemPos.Left){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(10,27,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,70,20,85,20);
						drawDestination.DrawLine(Pens.Black,75,20,75,70);				
						drawDestination.DrawLine(Pens.Black,75,21,72,27);				
						drawDestination.DrawLine(Pens.Black,75,21,78,27);										
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						RectangleF itemBox = new RectangleF(0,27,35,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,30,20,85,20);
						drawDestination.DrawLine(Pens.Black,35,20,35,70);				
						drawDestination.DrawLine(Pens.Black,35,21,32,27);				
						drawDestination.DrawLine(Pens.Black,35,21,38,27);										
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(36,27,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,30,20,85,20);
						drawDestination.DrawLine(Pens.Black,35,20,35,70);				
						drawDestination.DrawLine(Pens.Black,35,21,32,27);				
						drawDestination.DrawLine(Pens.Black,35,21,38,27);										
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
				}
				else if (pos == ItemPos.Right){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(25,27,65,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,20,30,20);
						drawDestination.DrawLine(Pens.Black,25,20,25,70);				
						drawDestination.DrawLine(Pens.Black,25,21,22,27);				
						drawDestination.DrawLine(Pens.Black,25,21,28,27);										
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						RectangleF itemBox = new RectangleF(65,27,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,20,70,20);
						drawDestination.DrawLine(Pens.Black,65,20,65,70);				
						drawDestination.DrawLine(Pens.Black,65,21,62,27);				
						drawDestination.DrawLine(Pens.Black,65,21,68,27);										
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(0,27,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,20,70,20);
						drawDestination.DrawLine(Pens.Black,65,20,65,70);				
						drawDestination.DrawLine(Pens.Black,65,21,62,27);				
						drawDestination.DrawLine(Pens.Black,65,21,68,27);										
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
				}
			}
			else if (style2 == MscStyle.SDL){
				if (pos == ItemPos.Left){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(20,12,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,75,30,85,30);
						PointF[] capPolygon = new PointF[3];
						capPolygon[0] = new PointF(75, 30);
						capPolygon[1] = new PointF(80, 25);
						capPolygon[2] = new PointF(70, 25);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);
						capPolygon[0] = new PointF(75, 30);
						capPolygon[1] = new PointF(80, 35);
						capPolygon[2] = new PointF(70, 35);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);				
						drawDestination.DrawLine(Pens.Black,75,35,75,70);
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						
						RectangleF itemBox = new RectangleF(5,12,35,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,35,30,85,30);
						PointF[] capPolygon = new PointF[3];
						capPolygon[0] = new PointF(35, 30);
						capPolygon[1] = new PointF(40, 25);
						capPolygon[2] = new PointF(30, 25);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);
						capPolygon[0] = new PointF(35, 30);
						capPolygon[1] = new PointF(40, 35);
						capPolygon[2] = new PointF(30, 35);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);				
						drawDestination.DrawLine(Pens.Black,35,35,35,70);
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(35,12,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,35,30,85,30);
						PointF[] capPolygon = new PointF[3];
						capPolygon[0] = new PointF(35, 30);
						capPolygon[1] = new PointF(40, 25);
						capPolygon[2] = new PointF(30, 25);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);
						capPolygon[0] = new PointF(35, 30);
						capPolygon[1] = new PointF(40, 35);
						capPolygon[2] = new PointF(30, 35);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);				
						drawDestination.DrawLine(Pens.Black,35,35,35,70);
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
				}
				else if (pos == ItemPos.Right){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(16,12,65,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,30,25,30);
						PointF[] capPolygon = new PointF[3];
						capPolygon[0] = new PointF(25, 30);
						capPolygon[1] = new PointF(30, 25);
						capPolygon[2] = new PointF(20, 25);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);
						capPolygon[0] = new PointF(25, 30);
						capPolygon[1] = new PointF(30, 35);
						capPolygon[2] = new PointF(20, 35);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);				
						drawDestination.DrawLine(Pens.Black,25,35,25,70);
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						
						RectangleF itemBox = new RectangleF(65,12,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,30,65,30);
						PointF[] capPolygon = new PointF[3];
						capPolygon[0] = new PointF(65, 30);
						capPolygon[1] = new PointF(70, 25);
						capPolygon[2] = new PointF(60, 25);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);
						capPolygon[0] = new PointF(65, 30);
						capPolygon[1] = new PointF(70, 35);
						capPolygon[2] = new PointF(60, 35);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);				
						drawDestination.DrawLine(Pens.Black,65,35,65,70);
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(15,12,50,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,30,65,30);
						PointF[] capPolygon = new PointF[3];
						capPolygon[0] = new PointF(65, 30);
						capPolygon[1] = new PointF(70, 25);
						capPolygon[2] = new PointF(60, 25);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);
						capPolygon[0] = new PointF(65, 30);
						capPolygon[1] = new PointF(70, 35);
						capPolygon[2] = new PointF(60, 35);
						drawDestination.DrawPolygon(Pens.Black,capPolygon);				
						drawDestination.DrawLine(Pens.Black,65,35,65,70);
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
				}
			}

			itemStringFormat.Dispose();
		}
		public override Property GetPropertyDialog(string text)
		{
			TimeoutBeginProp property = new TimeoutBeginProp();
			property.TimeoutText = this.mName.Replace("\n",@"\n");
			property.TimeoutPosition = this.mPos;
			property.TimeoutStyle = this.mItemStyle;
			property.DiagramStyle = MSCItem.Style;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
