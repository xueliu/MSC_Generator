/*

Copyright (C) 2005-2007 by Itesys Institut fuer Technische Systeme GmbH
http://www.itesys-gmbh.de   
mailto:software@itesys.de

This file is part of sdgen. Project home:
http://www.itesys-gmbh.de/home/produkte/msc_generator.html

sdgen is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

sdgen is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with sdgen; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

*/
/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 19.05.2005
 * Time: 14:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Message.
	/// </summary>
	public enum MessageStyle{
		NotUsed,
		Normal,
		Dashed,
		Synchron
	}
	
	public partial class Message : MSCItem
	{
		private int 			mMessageSource;
		private int 			mMessageDestination;
		private uint 			mInitialHeight;
		private MessageStyle 	mStyle;
		
		public Message(uint fileLine, string name, uint line, int messageSource, int messageDestination)
		{
			this.mName 					= name;
			this.mLine 					= line;
			this.mMessageSource 		= messageSource;
			this.mMessageDestination 	= messageDestination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= MessageStyle.Normal;
			this.mFileLine 				= fileLine;
			this.mInitialHeight 		= 4;
			if (messageSource==messageDestination) mInitialHeight=30; else mInitialHeight=0;
		}
		
		public Message(uint fileLine, string name, uint line, int messageSource, int messageDestination, MessageStyle style)
		{
			this.mName 					= name;
			this.mLine 					= line;
			this.mMessageSource 		= messageSource;
			this.mMessageDestination 	= messageDestination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= style;
			this.mFileLine 				= fileLine;
			this.mInitialHeight 		= 4;
			if (messageSource==messageDestination) mInitialHeight=30; else mInitialHeight=0;
		}		
		
		public int MessageSource{
			get{
				return mMessageSource;
			}
			set{
				mMessageSource=value;
			}
		}
		public int MessageDestination{
			get{
				return mMessageDestination;
			}
			set{
				mMessageDestination=value;
			}
		}
		
		//author LG
		public MessageStyle MStyle{
			
			get{
				return this.mStyle;
			}set{
				this.mStyle=value;
			}			
		}
		
		public float GetHeight(Graphics drawDestination, float xPosSource, float xPosDestination)
		{
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			if (xPosSource!=xPosDestination){
				itemTextSize=new SizeF(Math.Abs(xPosSource-xPosDestination), MSCItem.ItemLayoutSize.Height);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			}
			else{
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET, MSCItem.ItemLayoutSize.Height-mInitialHeight);	
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			}
			itemStringFormat.Dispose();
			return mInitialHeight+itemNameSize.Height;
		}
				
		public void DrawItem(Graphics drawDestination, float xPosSource, float xPosDestination, float yPos, float lineHeight,float xLeftPos,float xRightPos, ProcessStyle sourceStyle, ProcessStyle destinationStyle)
		{
			float[] pattern = {6f,6f};
			RectangleF itemBox = new RectangleF();
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			
			if (xPosSource == Generator.ENV_LEFT)
				xPosSource = xLeftPos;
			if (xPosSource == Generator.ENV_RIGHT)
				xPosSource = xRightPos;
			if (xPosDestination == Generator.ENV_LEFT)
				xPosDestination = xLeftPos;
			if (xPosDestination == Generator.ENV_RIGHT)
				xPosDestination = xRightPos;
			
			if (xPosDestination<xPosSource){
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource -=5;
				if ((destinationStyle == ProcessStyle.Activation)||(destinationStyle == ProcessStyle.Suspension))
					xPosDestination +=5;
			}
			if (xPosDestination>xPosSource){
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource +=5;
				if ((destinationStyle == ProcessStyle.Activation)||(destinationStyle == ProcessStyle.Suspension))
					xPosDestination -=5;
			}
			if (xPosDestination==xPosSource){
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource -=5;
				if ((destinationStyle == ProcessStyle.Activation)||(destinationStyle == ProcessStyle.Suspension))
					xPosDestination -=5;
			}
			
			if (mMscStyle == MscStyle.SDL){
				if (xPosSource!=xPosDestination){
					itemTextSize=new SizeF(Math.Abs(xPosDestination-xPosSource)-2, MSCItem.ItemLayoutSize.Height);
					if 	(this.mStyle==MessageStyle.Dashed){
						mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
						mItemPen.DashPattern = pattern;
					}
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					if (xPosDestination>xPosSource){
						drawDestination.FillRectangle(mBackBrush, xPosSource + ((xPosDestination-xPosSource)/2)- itemNameSize.Width / 2, yPos+lineHeight-itemNameSize.Height , itemNameSize.Width, itemNameSize.Height);
						itemBox = new RectangleF(xPosSource+1, yPos+lineHeight-itemNameSize.Height, itemTextSize.Width, itemNameSize.Height);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
						PointF[] messagePolygon = new PointF[3];
						messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
						messagePolygon[1] = new PointF(xPosDestination-8, yPos+lineHeight-4);
						messagePolygon[2] = new PointF(xPosDestination-8, yPos+lineHeight+4);
						drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					}
					if (xPosDestination<xPosSource){
						drawDestination.FillRectangle(mBackBrush, xPosDestination + ((xPosSource-xPosDestination)/2)- itemNameSize.Width / 2, yPos+lineHeight-itemNameSize.Height,itemNameSize.Width, itemNameSize.Height);
						itemBox = new RectangleF(xPosDestination+1, yPos+lineHeight-itemNameSize.Height, itemTextSize.Width, itemNameSize.Height);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					
						drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
						PointF[] messagePolygon = new PointF[3];
						messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
						messagePolygon[1] = new PointF(xPosDestination+8, yPos+lineHeight-4);
						messagePolygon[2] = new PointF(xPosDestination+8, yPos+lineHeight+4);
						drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					}
					this.mBounds.X = Math.Min(xPosSource,xPosDestination);
					this.mBounds.Width = Math.Max(xPosSource, xPosDestination)-this.mBounds.X;
					if (itemBox.Height == 0){
						this.mBounds.Y = itemBox.Y-4;
						this.mBounds.Height = 8;
					}
					else{
						this.mBounds.Y = itemBox.Y;
						this.mBounds.Height = (yPos+lineHeight+4) - this.mBounds.Y;	
					}
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
				}
				else{
					itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET, MSCItem.ItemLayoutSize.Height-mInitialHeight);		
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					yPos += Math.Max(0,(lineHeight-(itemNameSize.Height+mInitialHeight)));
					itemStringFormat.Alignment = StringAlignment.Near;
					itemBox = new RectangleF(xPosSource-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET, yPos, itemNameSize.Width, itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush,itemBox);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource,yPos+itemNameSize.Height, xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height);
					drawDestination.DrawLine(mItemPen,xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height, xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height+mInitialHeight);
					drawDestination.DrawLine(mItemPen,xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height+mInitialHeight, xPosSource,yPos+itemNameSize.Height+mInitialHeight);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(xPosDestination, yPos+itemNameSize.Height+mInitialHeight);
					messagePolygon[1] = new PointF(xPosDestination-8, yPos+itemNameSize.Height+mInitialHeight-4);
					messagePolygon[2] = new PointF(xPosDestination-8, yPos+itemNameSize.Height+mInitialHeight+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					this.mBounds.X = itemBox.X;
					this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
					this.mBounds.Y = itemBox.Y;
					this.mBounds.Height = (yPos+itemNameSize.Height+mInitialHeight+4) - this.mBounds.Y;
					
				}
			}
			else if (mMscStyle == MscStyle.UML2){
				if (xPosSource!=xPosDestination){
					itemTextSize=new SizeF(Math.Abs(xPosDestination-xPosSource)-2, MSCItem.ItemLayoutSize.Height);
					if 	(this.mStyle==MessageStyle.Dashed){
						mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
						mItemPen.DashPattern = pattern;
					}
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					if (xPosDestination>xPosSource){
						drawDestination.FillRectangle(mBackBrush, xPosSource + ((xPosDestination-xPosSource)/2)- itemNameSize.Width / 2, yPos+lineHeight-itemNameSize.Height , itemNameSize.Width, itemNameSize.Height);
						itemBox = new RectangleF(xPosSource+1, yPos+lineHeight-itemNameSize.Height, itemTextSize.Width, itemNameSize.Height);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
						if (this.mStyle==MessageStyle.Synchron){
							PointF[] messagePolygon = new PointF[3];
							messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
							messagePolygon[1] = new PointF(xPosDestination-8, yPos+lineHeight-4);
							messagePolygon[2] = new PointF(xPosDestination-8, yPos+lineHeight+4);
							drawDestination.FillPolygon(Brushes.Black,messagePolygon);
						}
						else{
							drawDestination.DrawLine(mItemPen, xPosDestination, yPos+lineHeight, xPosDestination-8, yPos+lineHeight-4);
							drawDestination.DrawLine(mItemPen, xPosDestination, yPos+lineHeight, xPosDestination-8, yPos+lineHeight+4);							
						}
					}
					if (xPosDestination<xPosSource){
						drawDestination.FillRectangle(mBackBrush, xPosDestination + ((xPosSource-xPosDestination)/2)- itemNameSize.Width / 2, yPos+lineHeight-itemNameSize.Height,itemNameSize.Width, itemNameSize.Height);
						itemBox = new RectangleF(xPosDestination+1, yPos+lineHeight-itemNameSize.Height, itemTextSize.Width, itemNameSize.Height);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					
						drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
						if (this.mStyle==MessageStyle.Synchron){
							PointF[] messagePolygon = new PointF[3];
							messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
							messagePolygon[1] = new PointF(xPosDestination+8, yPos+lineHeight-4);
							messagePolygon[2] = new PointF(xPosDestination+8, yPos+lineHeight+4);
							drawDestination.FillPolygon(Brushes.Black,messagePolygon);
						}
						else{
							mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
							drawDestination.DrawLine(mItemPen, xPosDestination, yPos+lineHeight, xPosDestination+8, yPos+lineHeight-4);
							drawDestination.DrawLine(mItemPen, xPosDestination, yPos+lineHeight, xPosDestination+8, yPos+lineHeight+4);														
						}
					}
					this.mBounds.X = Math.Min(xPosSource,xPosDestination);
					this.mBounds.Width = Math.Max(xPosSource, xPosDestination)-this.mBounds.X;
					if (itemBox.Height == 0){
						this.mBounds.Y = itemBox.Y-4;
						this.mBounds.Height = 8;
					}
					else{
						this.mBounds.Y = itemBox.Y;
						this.mBounds.Height = (yPos+lineHeight+4) - this.mBounds.Y;	
					}
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
				}
				else{
					itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET, MSCItem.ItemLayoutSize.Height-mInitialHeight);		
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					yPos += Math.Max(0,(lineHeight-(itemNameSize.Height+mInitialHeight)));
					itemStringFormat.Alignment = StringAlignment.Near;
					itemBox = new RectangleF(xPosSource-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET, yPos, itemNameSize.Width, itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush,itemBox);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource,yPos+itemNameSize.Height, xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height);
					drawDestination.DrawLine(mItemPen,xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height, xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height+mInitialHeight);
					drawDestination.DrawLine(mItemPen,xPosSource-MSCItem.ItemLayoutSize.Width/2,yPos+itemNameSize.Height+mInitialHeight, xPosSource,yPos+itemNameSize.Height+mInitialHeight);
					if (this.mStyle==MessageStyle.Synchron){
						PointF[] messagePolygon = new PointF[3];
						messagePolygon[0] = new PointF(xPosDestination, yPos+itemNameSize.Height+mInitialHeight);
						messagePolygon[1] = new PointF(xPosDestination-8, yPos+itemNameSize.Height+mInitialHeight-4);
						messagePolygon[2] = new PointF(xPosDestination-8, yPos+itemNameSize.Height+mInitialHeight+4);
						drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					}
					else{
						mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
						drawDestination.DrawLine(mItemPen, xPosDestination, yPos+lineHeight, xPosDestination-8, yPos+lineHeight-4);
						drawDestination.DrawLine(mItemPen, xPosDestination, yPos+lineHeight, xPosDestination-8, yPos+lineHeight+4);														
					}
					this.mBounds.X = itemBox.X;
					this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
					this.mBounds.Y = itemBox.Y;
					this.mBounds.Height = (yPos+itemNameSize.Height+mInitialHeight+4) - this.mBounds.Y;					
				}
			}
			itemStringFormat.Dispose();
		}
	}
}
