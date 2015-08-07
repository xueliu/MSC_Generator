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
 * Date: 10.06.2005
 * Time: 12:10
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
	public partial class MessageBegin : MSCItem
	{
		private int 			mMessageSource;
		private int 			mMessageDestination;
		private uint 			mInitialHeight;
		private string 			mIdentifier;
		private MessageStyle 	mStyle;
		
		public MessageBegin(uint fileLine, string identifier, string name, uint line, int messageSource, int messageDestination)
		{
			this.mName 					= name;
			this.mLine 					= line;
			this.mMessageSource 		= messageSource;
			this.mMessageDestination 	= messageDestination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= MessageStyle.Normal;
			this.mIdentifier 			= identifier;
			mInitialHeight				= 0;
			this.mFileLine 				= fileLine;
			
		}
		public MessageBegin(uint fileLine, string identifier, string name, uint line, int messageSource, int messageDestination, MessageStyle style)
		{
			this.mName 					= name;
			this.mLine 					= line;
			this.mMessageSource 		= messageSource;
			this.mMessageDestination 	= messageDestination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= style;
			this.mIdentifier 			= identifier;
			mInitialHeight				= 0;
			this.mFileLine 				= fileLine;
			
		}
		
		public string Identifier{
			get{
				return mIdentifier;
			}
			set{
				mIdentifier=value;
			}
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
			bool xisy = false;
			
			if (xPosSource == Generator.ENV_LEFT)
				xPosSource = xLeftPos;
			if (xPosSource == Generator.ENV_RIGHT)
				xPosSource = xRightPos;
			if (xPosDestination == Generator.ENV_LEFT)
				xPosDestination = xLeftPos;
			if (xPosDestination == Generator.ENV_RIGHT)
				xPosDestination = xRightPos;
			
			if (xPosDestination<xPosSource){
				xPosDestination+=((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource -=5;
			}
			if (xPosDestination>xPosSource){
				xPosDestination-=((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource +=5;
			}
			if (xPosDestination==xPosSource){
				xisy = true;
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension)){
					xPosSource -=5;
				}
			}
			if (!xisy){
				itemTextSize=new SizeF(Math.Abs(xPosDestination-xPosSource), MSCItem.ItemLayoutSize.Height);
				if 	(this.mStyle==MessageStyle.Dashed){
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					mItemPen.DashPattern = pattern;
				}
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				itemStringFormat.Alignment = StringAlignment.Center;
				if (xPosDestination>xPosSource){
					drawDestination.FillRectangle(mBackBrush, (xPosDestination+xPosSource)/2-itemNameSize.Width/2, yPos+lineHeight-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);
					itemBox = new RectangleF((xPosDestination+xPosSource)/2-itemNameSize.Width/2, yPos+lineHeight-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
				}
				if (xPosDestination<xPosSource){
					drawDestination.FillRectangle(mBackBrush, (xPosDestination+xPosSource)/2-itemNameSize.Width/2, yPos+lineHeight-itemNameSize.Height,itemNameSize.Width, itemNameSize.Height);
					itemBox = new RectangleF((xPosDestination+xPosSource)/2-itemNameSize.Width/2, yPos+lineHeight-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);			
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
				}
				this.mBounds.X = Math.Min(xPosSource,xPosDestination);
				this.mBounds.Width = Math.Max(xPosSource, xPosDestination)-this.mBounds.X;
				this.mBounds.Y = itemBox.Y;
				this.mBounds.Height = (yPos+lineHeight) - this.mBounds.Y;
			}
			else if(xisy){
				if 	(this.mStyle==MessageStyle.Dashed){
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					mItemPen.DashPattern = pattern;
				}
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET, MSCItem.ItemLayoutSize.Height-mInitialHeight);		
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				itemStringFormat.Alignment = StringAlignment.Near;
				itemBox = new RectangleF(xPosDestination-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET, yPos+lineHeight-itemNameSize.Height, itemTextSize.Width, itemNameSize.Height);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				drawDestination.DrawLine(mItemPen,xPosSource,yPos+lineHeight, xPosDestination-MSCItem.ItemLayoutSize.Width/2-(Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2),yPos+lineHeight);				
				this.mBounds.X = xPosSource-MSCItem.ItemLayoutSize.Width/2-(Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2);
				this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2-(Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2);
				this.mBounds.Y = itemBox.Y;
				this.mBounds.Height = (yPos+lineHeight) - this.mBounds.Y;
			}
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			itemStringFormat.Dispose();

		}		
	}
}
