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
 * Time: 12:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;
	
namespace mscElements
{
	
	public enum StateStyle{
		Box,
		Bracket
	}
	
	/// <summary>
	/// Description of State.
	/// </summary>
	/// 
	public partial class State : MSCItem
	{
		private int[] 		mProcess;
		private StateStyle 	mStyle;
		private float 		mInitialHeight = 15;
		private ItemPos		mPos;
		
		public State(uint fileLine, string name, uint line, int process)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= new int[1]{process};
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mStyle 		= StateStyle.Box;
			this.mFileLine 		= fileLine;
			this.mPos			= ItemPos.Top;
		}
		public State(uint fileLine, string name, uint line, int[] process)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= process;
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mStyle 		= StateStyle.Box;		
			this.mFileLine 		= fileLine;
			this.mPos			= ItemPos.Top;
		}
		public State(uint fileLine, string name, uint line, int process, StateStyle style)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= new int[1]{process};
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mStyle 		= style;
			this.mFileLine 		= fileLine;
			this.mPos			= ItemPos.Top;
		}
		public State(uint fileLine, string name, uint line, int[] process, StateStyle style)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= process;
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mStyle 		= style;			
			this.mFileLine 		= fileLine;
			this.mPos			= ItemPos.Top;
		}
		public State(uint fileLine, string name, uint line, int process, StateStyle style, ItemPos pos)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= new int[1]{process};
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mStyle 		= style;
			this.mFileLine 		= fileLine;
			this.mPos			= pos;
		}
		public State(uint fileLine, string name, uint line, int[] process, StateStyle style, ItemPos pos)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= process;
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mStyle 		= style;			
			this.mFileLine 		= fileLine;
			this.mPos			= pos;
		}
				
		public int[] Process{
			get{
				return mProcess;
			}
			set{
				mProcess=value;
			}
		}
		public bool IsUsedProcess(int process){
			for(int i=0;i<this.mProcess.Length;i++){
				if (process==this.mProcess[i]){
					return true;
				}
			}
			return false;
		}

		public float GetHeight(Graphics drawDestination, float xPosMin, float xPosMax)
		{
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			itemTextSize=new SizeF((xPosMax-xPosMin)+ MSCItem.ItemLayoutSize.Width-10, MSCItem.ItemLayoutSize.Height-10);
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			itemStringFormat.Dispose();
			this.mHeight = Math.Max(itemNameSize.Height, mInitialHeight);
			return this.mHeight;
		}
		public void DrawItem(Graphics drawDestination, float xPosMin, float xPosMax, float yPos, float height)
		{
			RectangleF itemBox;
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			float widthOffset = (MSCItem.ItemLayoutSize.Width/2-10);
			if (this.mPos == ItemPos.Bottom)
				yPos = (yPos+height)-this.mHeight;
			
			if (mMscStyle == MscStyle.SDL){
				if (this.mStyle==StateStyle.Box){
					itemTextSize=new SizeF((xPosMax-xPosMin)+ MSCItem.ItemLayoutSize.Width-10, MSCItem.ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemBox = new RectangleF(xPosMin-(MSCItem.ItemLayoutSize.Width/2-5), yPos, itemTextSize.Width, itemNameSize.Height);
					PointF[] statePolygon = new PointF[6];
					statePolygon[0] = new PointF(xPosMin-widthOffset,yPos);
					statePolygon[1] = new PointF(xPosMax+widthOffset,yPos);
					statePolygon[2] = new PointF(xPosMax+widthOffset+10,yPos+Math.Max(itemNameSize.Height, mInitialHeight)/2);
					statePolygon[3] = new PointF(xPosMax+widthOffset,yPos+Math.Max(itemNameSize.Height, mInitialHeight));
					statePolygon[4] = new PointF(xPosMin-widthOffset,yPos+Math.Max(itemNameSize.Height, mInitialHeight));
					statePolygon[5] = new PointF(xPosMin-widthOffset-10,yPos+Math.Max(itemNameSize.Height, mInitialHeight)/2);
					drawDestination.FillPolygon(mFillBrush,statePolygon);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawPolygon(mItemPen,statePolygon);
					this.mBounds = new RectangleF(xPosMin-widthOffset-10,yPos,(xPosMax-xPosMin)+widthOffset*2+20,Math.Max(itemNameSize.Height, mInitialHeight));
				}
				else{
					itemTextSize=new SizeF((xPosMax-xPosMin)+ MSCItem.ItemLayoutSize.Width, MSCItem.ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString("{" + mName + "}", mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemBox = new RectangleF(xPosMin-(MSCItem.ItemLayoutSize.Width/2), yPos, itemTextSize.Width, itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush,itemBox);
					drawDestination.DrawString("{" + mName + "}",mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					this.mBounds = itemBox;
				}
			}
			else if(mMscStyle == MscStyle.UML2){
				if (this.mStyle==StateStyle.Box){
					itemTextSize=new SizeF((xPosMax-xPosMin)+ MSCItem.ItemLayoutSize.Width-10, MSCItem.ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemBox = new RectangleF(xPosMin-(MSCItem.ItemLayoutSize.Width/2-5), yPos, itemTextSize.Width, Math.Max(itemNameSize.Height, mInitialHeight));
					drawDestination.FillRectangle(mFillBrush,itemBox);
					drawDestination.FillPie(mFillBrush,xPosMin-widthOffset-10,yPos,20,Math.Max(itemNameSize.Height, mInitialHeight),90,180);
					drawDestination.FillPie(mFillBrush,xPosMax+widthOffset-10,yPos,20,Math.Max(itemNameSize.Height, mInitialHeight),270,180);
					drawDestination.DrawLine(mItemPen,xPosMin-widthOffset,yPos,xPosMax+widthOffset,yPos);						
					drawDestination.DrawLine(mItemPen,xPosMin-widthOffset,yPos+Math.Max(itemNameSize.Height, mInitialHeight),xPosMax+widthOffset,yPos+Math.Max(itemNameSize.Height, mInitialHeight));
					drawDestination.DrawArc(mItemPen,xPosMin-widthOffset-10,yPos,20,Math.Max(itemNameSize.Height, mInitialHeight),90,180);
					drawDestination.DrawArc(mItemPen,xPosMax+widthOffset-10,yPos,20,Math.Max(itemNameSize.Height, mInitialHeight),270,180);
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					this.mBounds = new RectangleF(xPosMin-widthOffset-10,yPos,(xPosMax-xPosMin)+widthOffset*2+20,Math.Max(itemNameSize.Height, mInitialHeight));
				}
				else{
					itemTextSize=new SizeF((xPosMax-xPosMin)+ MSCItem.ItemLayoutSize.Width, MSCItem.ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString("{" + mName + "}", mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemBox = new RectangleF(xPosMin-(MSCItem.ItemLayoutSize.Width/2), yPos, itemTextSize.Width, itemNameSize.Height);
					drawDestination.FillRectangle(mBackBrush,itemBox);
					drawDestination.DrawString("{" + mName + "}",mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					this.mBounds = itemBox;
				}
			}
			itemStringFormat.Dispose();
		}
		public void DrawForegroundProcessLine(Graphics drawDestination, float xPos, float yPos, float xPosMin, float xPosMax, float height)
		{
			drawDestination.DrawLine(mItemPen, xPos, yPos, xPos, yPos+this.GetHeight(drawDestination, xPosMin, xPosMax));
		}		
	}
}
