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
 * Date: 06.06.2005
 * Time: 09:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
	
namespace mscElements
{
	public enum MessagePos{
		Left,
		Right
	}
	/// <summary>
	/// Description of Timeout.
	/// </summary>
	public partial class FoundMessage : MSCItem
	{
		private int 		mProcess;
		private uint 		mInitialHeight;
		private string 		mGate;
		private MessagePos 	mPos;

		public FoundMessage(uint fileLine, string name, uint line, int process)
		{
			this.mName 				= name;
			this.mGate 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= (uint)Generator.LOOP_OFFSET*2;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MessagePos.Left;
			this.mFileLine 			= fileLine;
		}
		
		public FoundMessage(uint fileLine, string name, string gate, uint line, int process)
		{
			this.mName 				= name;
			this.mGate 				= gate;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= (uint)Generator.LOOP_OFFSET;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MessagePos.Left;
			this.mFileLine 			= fileLine;
		}

		public FoundMessage(uint fileLine, string name, uint line, int process, MessagePos placement)
		{
			this.mName 				= name;
			this.mGate 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= (uint)Generator.LOOP_OFFSET; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
		}
		
		public FoundMessage(uint fileLine, string name, string gate, uint line, int process, MessagePos placement)
		{
			this.mName 				= name;
			this.mGate 				= gate;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= (uint)Generator.LOOP_OFFSET;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
		}

		public int Process{
			get{
				return mProcess;
			}
			set{
				mProcess=value;
			}
		}
		
		public float GetHeight(Graphics drawDestination)
		{
		
			if (this.mName.Length>0){
				SizeF itemNameSize, itemTextSize;
				StringFormat itemStringFormat = new StringFormat();
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2, MSCItem.ItemLayoutSize.Height);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				itemStringFormat.Dispose();
				return itemNameSize.Height + this.mInitialHeight;
			}
			else{
				return 	this.mInitialHeight;
			}
		}		
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float lineHeight)
		{
			RectangleF 		itemBox;
			SizeF 			itemNameSize, 
							itemGateSize, 
							itemTextSize;
			StringFormat 	itemStringFormat 		= new StringFormat();
			PointF[] 		capPolygon 				= new PointF[3];	
			float 			rGate 					= 10.0f;
			
			itemTextSize	= new SizeF(MSCItem.ItemLayoutSize.Width/2-rGate*2, MSCItem.ItemLayoutSize.Height);
			itemNameSize 	= drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			itemGateSize 	= drawDestination.MeasureString(mGate, mItemFont, itemTextSize, itemStringFormat);
			
			itemStringFormat.Alignment = StringAlignment.Center;
			
			if (MSCItem.Style == MscStyle.SDL){
				if (this.mPos==MessagePos.Right){
					// Message
					capPolygon[0] = new PointF(xPos, yPos+lineHeight);
					capPolygon[1] = new PointF(xPos+8, yPos+lineHeight-4);
					capPolygon[2] = new PointF(xPos+8, yPos+lineHeight+4);
					itemBox = new RectangleF(xPos+8+itemTextSize.Width/2-itemNameSize.Width/2,yPos+(lineHeight-itemNameSize.Height),itemNameSize.Width,itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos+MSCItem.ItemLayoutSize.Width/2-rGate,yPos + lineHeight);
					drawDestination.FillPolygon(Brushes.Black,capPolygon);
					// Gate
					itemStringFormat.Alignment = StringAlignment.Far;
					itemBox = new RectangleF(xPos, yPos+lineHeight+rGate, MSCItem.ItemLayoutSize.Width/2+rGate, itemGateSize.Height);
					drawDestination.DrawString(mGate,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawEllipse(mItemPen, new RectangleF(xPos+MSCItem.ItemLayoutSize.Width/2-rGate,yPos+lineHeight-rGate, rGate*2,rGate*2));
		
					itemStringFormat.Dispose();
					
					this.mBounds.X = xPos;
				}
				else{
					capPolygon[0] = new PointF(xPos, yPos+lineHeight);
					capPolygon[1] = new PointF(xPos-8, yPos+lineHeight-4);
					capPolygon[2] = new PointF(xPos-8, yPos+lineHeight+4);				
					
					itemBox = new RectangleF(xPos-8-itemTextSize.Width/2-itemNameSize.Width/2,yPos+(lineHeight-itemNameSize.Height),itemNameSize.Width,itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos-MSCItem.ItemLayoutSize.Width/2+rGate,yPos + lineHeight);
					drawDestination.FillPolygon(Brushes.Black,capPolygon);
					// Gate
					itemStringFormat.Alignment = StringAlignment.Near;
					itemBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-rGate, yPos+lineHeight+rGate, MSCItem.ItemLayoutSize.Width/2+rGate, itemGateSize.Height);
					drawDestination.DrawString(mGate,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawEllipse(mItemPen, new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-rGate,yPos+lineHeight-rGate, rGate*2,rGate*2));
		
					itemStringFormat.Dispose();

					this.mBounds.X = xPos-(MSCItem.ItemLayoutSize.Width/2+rGate);
				}
				this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2+rGate;
				this.mBounds.Y = yPos+(lineHeight-itemNameSize.Height);
				this.mBounds.Height = itemNameSize.Height + itemGateSize.Height + rGate;
			}
			else if(MSCItem.Style == MscStyle.UML2){
				if (this.mPos==MessagePos.Right){
					// Message
					itemBox = new RectangleF(xPos+8+itemTextSize.Width/2-itemNameSize.Width/2,yPos+(lineHeight-itemNameSize.Height),itemNameSize.Width,itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos+MSCItem.ItemLayoutSize.Width/2-rGate,yPos + lineHeight);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos+8,yPos+lineHeight-4);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos+8,yPos+lineHeight+4);
					// Gate
					itemStringFormat.Alignment = StringAlignment.Far;
					itemBox = new RectangleF(xPos, yPos+lineHeight+rGate, MSCItem.ItemLayoutSize.Width/2+rGate, itemGateSize.Height);
					drawDestination.DrawString(mGate,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.FillEllipse(Brushes.Black, new RectangleF(xPos+MSCItem.ItemLayoutSize.Width/2-rGate,yPos+lineHeight-rGate, rGate*2,rGate*2));
		
					itemStringFormat.Dispose();
					
					this.mBounds.X = xPos;
				}
				else{					
					itemBox = new RectangleF(xPos-8-itemTextSize.Width/2-itemNameSize.Width/2,yPos+(lineHeight-itemNameSize.Height),itemNameSize.Width,itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos-MSCItem.ItemLayoutSize.Width/2+rGate,yPos + lineHeight);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos-8,yPos+lineHeight-4);
					drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos-8,yPos+lineHeight+4);
					// Gate
					itemStringFormat.Alignment = StringAlignment.Near;
					itemBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-rGate, yPos+lineHeight+rGate, MSCItem.ItemLayoutSize.Width/2+rGate, itemGateSize.Height);
					drawDestination.DrawString(mGate,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.FillEllipse(Brushes.Black, new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-rGate,yPos+lineHeight-rGate, rGate*2,rGate*2));
		
					itemStringFormat.Dispose();

					this.mBounds.X = xPos-(MSCItem.ItemLayoutSize.Width/2+rGate);
				}
				this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2+rGate;
				this.mBounds.Y = yPos+(lineHeight-itemNameSize.Height);
				this.mBounds.Height = itemNameSize.Height + itemGateSize.Height + rGate;
			}
		}		
	}
}
