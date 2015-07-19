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
 * Date: 02.06.2005
 * Time: 10:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of TimeoutEnd.
	/// </summary>
	public partial class TimeoutStop : MSCItem
	{
		private int 		mProcess;
		private uint 		mInitialHeight;
		private ItemPos 	mPos;
		private ItemStyle 	mItemStyle;
		
		public TimeoutStop(uint fileLine, string name, uint line, int process)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mItemStyle 		= ItemStyle.Normal;
		}
		
		public TimeoutStop(uint fileLine, uint line, int process)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= ItemStyle.Normal;
		}

		public TimeoutStop(uint fileLine, string name, uint line, int process, ItemPos placement)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= ItemStyle.Normal;
		}		
		public TimeoutStop(uint fileLine, uint line, int process, ItemPos placement)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= ItemStyle.Normal;
		}
		public TimeoutStop(uint fileLine, string name, uint line, int process, ItemPos placement, ItemStyle itemstyle)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= itemstyle;
		}		
		public TimeoutStop(uint fileLine, uint line, int process, ItemPos placement, ItemStyle itemstyle)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= itemstyle;
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
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET-26, MSCItem.ItemLayoutSize.Height);
				
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				itemStringFormat.Dispose();
				if (mMscStyle == MscStyle.SDL){
					return itemNameSize.Height;
				}
				else if (mMscStyle == MscStyle.UML2){
					return itemNameSize.Height + this.mInitialHeight;
				}
				else{
					return 0;
				}
			}
			else{
				return 	this.mInitialHeight;
			}
		}
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float lineHeight)
		{
			float placementOffset=0;
			RectangleF itemBox = new RectangleF(0,0,0,0);
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			if (mMscStyle == MscStyle.SDL){
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET-26, MSCItem.ItemLayoutSize.Height);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				itemStringFormat.Alignment = StringAlignment.Near;
				placementOffset = yPos+(lineHeight-itemNameSize.Height)-STOPXSIZE;
				if (this.mPos==ItemPos.Right){	
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine - itemNameSize.Width-1, placementOffset, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine+1, placementOffset, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = Math.Max(MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2, MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET + itemNameSize.Width);
						}
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xLine,yPos,xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xPos,yPos+lineHeight, xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight-STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight+STOPXSIZE);				
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight+STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight-STOPXSIZE);				
						itemStringFormat.Dispose();
					}
					else if (this.mItemStyle == ItemStyle.Normal){
						float xLine = xPos + 25;
						itemStringFormat.Alignment = StringAlignment.Near;
						itemBox = new RectangleF(xPos + 26, placementOffset, itemNameSize.Width, itemNameSize.Height);
						this.mBounds.X = xPos;
						this.mBounds.Width = itemBox.Right - xPos;
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xLine,yPos,xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xPos,yPos+lineHeight, xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight-STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight+STOPXSIZE);				
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight+STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight-STOPXSIZE);				
						itemStringFormat.Dispose();						
					}
				}
				else if (this.mPos==ItemPos.Left){
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine+1, placementOffset, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xLine;
							this.mBounds.Width = xPos-xLine;
						}
						if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine-itemNameSize.Width-1, placementOffset, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xLine-itemNameSize.Width-1;
							this.mBounds.Width = xPos-xLine-itemNameSize.Width;
						}
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xLine,yPos,xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xPos,yPos+lineHeight, xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight-STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight+STOPXSIZE);				
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight+STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight-STOPXSIZE);				
						itemStringFormat.Dispose();
					}
					else if (this.mItemStyle == ItemStyle.Normal){
						float xLine = xPos - 25;
						itemStringFormat.Alignment = StringAlignment.Near;
						itemBox = new RectangleF(xPos - 26 -itemNameSize.Width, placementOffset, itemNameSize.Width, itemNameSize.Height);
						this.mBounds.X = xPos - 26 - itemNameSize.Width;
						this.mBounds.Width = 26 + itemNameSize.Width;
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xLine,yPos,xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xPos,yPos+lineHeight, xLine, yPos+lineHeight);
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight-STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight+STOPXSIZE);				
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE,yPos+lineHeight+STOPXSIZE, xLine+STOPXSIZE,yPos+lineHeight-STOPXSIZE);				
						itemStringFormat.Dispose();						
					}
				}
				this.mBounds.Y = itemBox.Y;
				this.mBounds.Height = itemBox.Height+8+STOPXSIZE;					
			}
			else if (mMscStyle == MscStyle.UML2){
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET-26, MSCItem.ItemLayoutSize.Height);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				if (this.mPos==ItemPos.Right){
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Far;
							itemBox = new RectangleF(xLine-itemNameSize.Width, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);	
							this.mBounds.X = xPos;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						else if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2+itemNameSize.Width;
						}
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos+5, yPos + lineHeight, xPos+ MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine,yPos);
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE, yPos + lineHeight-STOPXSIZE, xLine+STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						drawDestination.DrawLine(mItemPen,xLine+STOPXSIZE, yPos + lineHeight-STOPXSIZE, xLine-STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						this.mBounds.Y = yPos;
						this.mBounds.Height = lineHeight;										
						
					}
					else if (this.mItemStyle == ItemStyle.Normal){			
						itemStringFormat.Alignment = StringAlignment.Near;
						itemBox = new RectangleF(xPos+26, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos+5, yPos + lineHeight, xPos+35,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xPos+25, yPos + lineHeight, xPos+25,yPos);
						drawDestination.DrawLine(mItemPen,xPos+25-STOPXSIZE, yPos + lineHeight-STOPXSIZE, xPos+25+STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						drawDestination.DrawLine(mItemPen,xPos+25+STOPXSIZE, yPos + lineHeight-STOPXSIZE, xPos+25-STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						this.mBounds.X = xPos;
						this.mBounds.Width = itemBox.X+ itemNameSize.Width - xPos;
						this.mBounds.Y = itemBox.Y;
						this.mBounds.Height = yPos+ lineHeight+STOPXSIZE - itemBox.Y;	
					}
				}
				else if(this.mPos==ItemPos.Left){
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET*2;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						else if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Far;
							itemBox = new RectangleF(xLine-itemNameSize.Width, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xLine-itemNameSize.Width;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET+itemNameSize.Width;
						}
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET*2, yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine,yPos);
						drawDestination.DrawLine(mItemPen,xLine-STOPXSIZE, yPos + lineHeight-STOPXSIZE, xLine+STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						drawDestination.DrawLine(mItemPen,xLine+STOPXSIZE, yPos + lineHeight-STOPXSIZE, xLine-STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						this.mBounds.Y = yPos;
						this.mBounds.Height = lineHeight;	
		
					}
					else if (this.mItemStyle == ItemStyle.Normal){			
						itemStringFormat.Alignment = StringAlignment.Far;
						itemBox = new RectangleF(xPos-26-itemNameSize.Width, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos-35,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xPos-25, yPos + lineHeight, xPos-25,yPos);
						drawDestination.DrawLine(mItemPen,xPos-25-STOPXSIZE, yPos + lineHeight-STOPXSIZE, xPos-25+STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						drawDestination.DrawLine(mItemPen,xPos-25+STOPXSIZE, yPos + lineHeight-STOPXSIZE, xPos-25-STOPXSIZE,yPos+ lineHeight+STOPXSIZE);
						this.mBounds.X = xPos-35-itemNameSize.Width;
						this.mBounds.Width = 35+itemNameSize.Width;
						this.mBounds.Y = itemBox.Y;
						this.mBounds.Height = yPos+ lineHeight+STOPXSIZE - itemBox.Y;
					}
				}	
				itemStringFormat.Dispose();
			}
		}		
	}
}
