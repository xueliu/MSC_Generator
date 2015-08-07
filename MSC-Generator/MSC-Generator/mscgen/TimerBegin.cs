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
 * Date: 22.05.2005
 * Time: 20:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Timer.
	/// </summary>
	public partial class TimerBegin : MSCItem
	{
		private int 		mProcess;
		private uint 		mInitialHeight;
		private ItemPos 	mPos;
		private ItemStyle 	mItemStyle;
		private string 		mIdentifier;

		public TimerBegin(uint fileLine, uint line, string identifier, int process)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= ItemStyle.Normal;
			this.mIdentifier		= identifier;
		}
		public TimerBegin(uint fileLine, uint line, string identifier, int process, string name)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;   //SDL layout
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= ItemStyle.Normal;
			this.mIdentifier		= identifier;
		}
		

		public TimerBegin(uint fileLine, uint line, string identifier, int process, string name, ItemPos placement)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= ItemStyle.Normal;
			this.mIdentifier		= identifier;
		}		
		public TimerBegin(uint fileLine, uint line, string identifier, int process, string name, ItemPos placement, ItemStyle itemstyle)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			this.mItemStyle 		= itemstyle;
			this.mIdentifier		= identifier;
		}
		
		public int Process{
			get{
				return mProcess;
			}
			set{
				mProcess=value;
			}
		}
		public string Identifier{
			get{
				return mIdentifier;
			}
			set{
				mIdentifier=value;
			}
		}
		
		public float GetHeight(Graphics drawDestination)
		{
			
			if ((this.mName.Length>0)&&(mMscStyle == MscStyle.SDL)){
				SizeF itemNameSize, itemTextSize= new SizeF(0,0);
				StringFormat itemStringFormat = new StringFormat();
				if (mMscStyle == MscStyle.SDL){
					itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-10, MSCItem.ItemLayoutSize.Height);
				}
				else if(mMscStyle == MscStyle.UML2){
					itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-10, MSCItem.ItemLayoutSize.Height);
				}
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
			RectangleF itemBox = new RectangleF(0,0,0,0);
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			
			if (mMscStyle == MscStyle.SDL){	
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-10, MSCItem.ItemLayoutSize.Height);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				if (this.mPos==ItemPos.Right){	
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine - itemNameSize.Width, yPos, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine, yPos, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = Math.Max(MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2, MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET + itemNameSize.Width);
						}
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos, yPos+lineHeight, xLine,yPos+lineHeight);
						PointF[] statePolygon = new PointF[3];
						statePolygon[0] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[1] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);
						statePolygon[0] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[1] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);				
					}
					else if (this.mItemStyle == ItemStyle.Normal){
						itemStringFormat.Alignment = StringAlignment.Near;
						itemBox = new RectangleF(xPos+1, yPos, itemNameSize.Width, itemNameSize.Height);
						this.mBounds.X = xPos;
						this.mBounds.Width = Math.Max(itemNameSize.Width,40);
						float xLine = xPos + 25;
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos, yPos+lineHeight, xLine,yPos+lineHeight);
						PointF[] statePolygon = new PointF[3];
						statePolygon[0] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[1] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);
						statePolygon[0] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[1] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);				
					}
				}
				else if (this.mPos==ItemPos.Left){	
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine, yPos, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xLine - Generator.LOOP_OFFSET;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine - itemNameSize.Width, yPos, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xLine - itemNameSize.Width;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET + itemNameSize.Width;
						}
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos, yPos+lineHeight, xLine,yPos+lineHeight);
						PointF[] statePolygon = new PointF[3];
						statePolygon[0] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[1] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);
						statePolygon[0] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[1] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);				
					}
					else if (this.mItemStyle == ItemStyle.Normal){
						itemStringFormat.Alignment = StringAlignment.Near;
						itemBox = new RectangleF(xPos-itemNameSize.Width-1, yPos, itemNameSize.Width, itemNameSize.Height);
						this.mBounds.X = Math.Min(xPos-itemNameSize.Width-1,xPos-35);
						this.mBounds.Width = Math.Max(itemNameSize.Width,35);
						float xLine = xPos - 25;
						drawDestination.FillRectangle(mBackBrush, itemBox);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos, yPos+lineHeight, xLine,yPos+lineHeight);
						PointF[] statePolygon = new PointF[3];
						statePolygon[0] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[1] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight-10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);
						statePolygon[0] = new PointF(xLine-Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[1] = new PointF(xLine+Generator.LOOP_OFFSET,yPos + lineHeight+10);
						statePolygon[2] = new PointF(xLine,yPos + lineHeight);
						drawDestination.DrawPolygon(mItemPen,statePolygon);				
					}
				}
			
				this.mBounds.Y = (lineHeight+yPos)-itemNameSize.Height-10;
				this.mBounds.Height = itemNameSize.Height+20;					
				itemStringFormat.Dispose();
			}
			else if (mMscStyle == MscStyle.UML2){
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-10, MSCItem.ItemLayoutSize.Height);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				if (this.mPos==ItemPos.Right){	
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Far;
							itemBox = new RectangleF(xLine - itemNameSize.Width, yPos+lineHeight+10, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine, yPos+lineHeight+10, itemNameSize.Width, itemNameSize.Height);
							this.mBounds.X = xPos;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET + itemNameSize.Width;
						}
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos+5, yPos + lineHeight, xPos+ MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine-5,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine+5,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine,yPos + lineHeight+10);
						
					}
					else if (this.mItemStyle == ItemStyle.Normal){
						itemStringFormat.Alignment = StringAlignment.Near;
						itemBox = new RectangleF(xPos+26, yPos+lineHeight+10, itemNameSize.Width, itemNameSize.Height);
						drawDestination.FillRectangle(mBackBrush, itemBox);
						this.mBounds.X = xPos;
						this.mBounds.Width = itemBox.X+itemNameSize.Width - xPos;
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos+5, yPos + lineHeight, xPos+35,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xPos+25, yPos + lineHeight, xPos+20,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xPos+25, yPos + lineHeight, xPos+30,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xPos+25, yPos + lineHeight, xPos+25,yPos + lineHeight+10);
					}
				}
				else if (this.mPos==ItemPos.Left){
					if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
						float xLine = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET;
						if (this.mItemStyle == ItemStyle.ExtendedInner){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine, yPos+lineHeight+10, itemNameSize.Width, itemNameSize.Height);				
							this.mBounds.X = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET*2;
							this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET*2;
						}
						else if (this.mItemStyle == ItemStyle.ExtendedOuter){
							itemStringFormat.Alignment = StringAlignment.Near;
							itemBox = new RectangleF(xLine-itemNameSize.Width, yPos+lineHeight+10, itemNameSize.Width, itemNameSize.Height);				
							this.mBounds.X = xLine-itemNameSize.Width;
							this.mBounds.Width = itemNameSize.Width + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET;
						}
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET*2, yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine-5,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine+5,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xLine, yPos + lineHeight, xLine,yPos + lineHeight+10);
					}
					else if (this.mItemStyle == ItemStyle.Normal){
						itemStringFormat.Alignment = StringAlignment.Far;
						itemBox = new RectangleF(xPos-26-itemNameSize.Width, yPos+lineHeight+10, itemNameSize.Width, itemNameSize.Height);
						drawDestination.FillRectangle(mBackBrush, itemBox);
						this.mBounds.X =(itemBox.X+itemBox.Width)-itemNameSize.Width;
						this.mBounds.Width = xPos-((itemBox.X+itemBox.Width)-itemNameSize.Width);
						drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
						drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos-35,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xPos-25, yPos + lineHeight, xPos-20,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xPos-25, yPos + lineHeight, xPos-25,yPos + lineHeight+10);
						drawDestination.DrawLine(mItemPen,xPos-25, yPos + lineHeight, xPos-30,yPos + lineHeight+10);
					}
				}
				this.mBounds.Y = yPos + lineHeight;
				this.mBounds.Height = itemBox.Y+itemBox.Height - this.mBounds.Y;
				
			}
		}		
	}
}
