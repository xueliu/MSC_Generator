/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 12:26
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
	/// <summary>
	/// Description of Message.
	/// </summary>
	partial class MessageBegin
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(5, 20, 70, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			drawDestination.DrawString("Message",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			if (mMscStyle == MscStyle.SDL){
				drawDestination.DrawLine(Pens.Black,5,55,40,55);
				drawDestination.DrawLine(Pens.Black,40,35,40,55);
				drawDestination.DrawLine(Pens.Black,40,35,75,35);
				PointF[] messagePolygon = new PointF[3];
				messagePolygon[0] = new PointF(5, 55);
				messagePolygon[1] = new PointF(5+8, 55-4);
				messagePolygon[2] = new PointF(5+8, 55+4);
				drawDestination.FillPolygon(Brushes.Black,messagePolygon);
			}
			else if(mMscStyle == MscStyle.UML2){
				drawDestination.DrawLine(Pens.Black,5,55,40,55);
				drawDestination.DrawLine(Pens.Black,40,35,40,55);
				drawDestination.DrawLine(Pens.Black,40,35,75,35);
				drawDestination.DrawLine(Pens.Black,5,55,5+8, 55-4);
				drawDestination.DrawLine(Pens.Black,5,55,5+8, 55+4);								
			}
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, MessageStyle style, MscStyle style2)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(5, 20, 70, 20);
			Pen pen = new Pen(Color.Black);
			float[] pattern = {3f,3f};
			itemStringFormat.Alignment = StringAlignment.Center;
			drawDestination.DrawString("Message",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawLine(Pens.DarkGray,5,10,5,70);
			drawDestination.DrawLine(Pens.DarkGray,75,10,75,70);
			if (style2 == MscStyle.SDL){
				if((style == MessageStyle.Normal)||(style == MessageStyle.Synchron)){
					drawDestination.DrawLine(Pens.Black,5,55,40,55);
					drawDestination.DrawLine(Pens.Black,40,35,40,55);
					drawDestination.DrawLine(Pens.Black,40,35,75,35);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(5, 55);
					messagePolygon[1] = new PointF(5+8, 55-4);
					messagePolygon[2] = new PointF(5+8, 55+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
				}
				else if (style == MessageStyle.Dashed){
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					pen.DashPattern = pattern;	
					drawDestination.DrawLine(pen,5,55,40,55);
					drawDestination.DrawLine(pen,40,35,40,55);
					drawDestination.DrawLine(pen,40,35,75,35);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(5, 55);
					messagePolygon[1] = new PointF(5+8, 55-4);
					messagePolygon[2] = new PointF(5+8, 55+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;					
				}
			}
			else if(style2 == MscStyle.UML2){
				if( style == MessageStyle.Normal){
					drawDestination.DrawLine(Pens.Black,5,55,40,55);
					drawDestination.DrawLine(Pens.Black,40,35,40,55);
					drawDestination.DrawLine(Pens.Black,40,35,75,35);
					drawDestination.DrawLine(Pens.Black,5,55,5+8, 55-4);
					drawDestination.DrawLine(Pens.Black,5,55,5+8, 55+4);								
				}
				else if( style == MessageStyle.Dashed){
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					pen.DashPattern = pattern;	
					drawDestination.DrawLine(pen,5,55,40,55);
					drawDestination.DrawLine(pen,40,35,40,55);
					drawDestination.DrawLine(pen,40,35,75,35);
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;					
					drawDestination.DrawLine(Pens.Black,5,55,5+8, 55-4);
					drawDestination.DrawLine(Pens.Black,5,55,5+8, 55+4);													
				}
				else if( style == MessageStyle.Synchron){
					drawDestination.DrawLine(Pens.Black,5,55,40,55);
					drawDestination.DrawLine(Pens.Black,40,35,40,55);
					drawDestination.DrawLine(Pens.Black,40,35,75,35);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(5, 55);
					messagePolygon[1] = new PointF(5+8, 55-4);
					messagePolygon[2] = new PointF(5+8, 55+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);					
				}
			}
			pen.Dispose();
			itemStringFormat.Dispose();
		}
		static public void RepertoryText(NumberingEditor.NumberingRichTextBox ew)
		{
		}
		public override Property GetPropertyDialog(string text)
		{
			MessageBeginProp property = new MessageBeginProp();
			property.MessageText = this.mName.Replace("\n",@"\n");
			property.Style = this.mStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
