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
 * Date: 03.06.2005
 * Time: 08:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Timeout.
	/// </summary>
	public partial class MeasureBeginn : MSCItem
	{
		private int 			mProcess;
		private uint 			mInitialHeight;
		private CapStyle 		mCapStyle;
		private MeasurePos 		mPos;
		
		public MeasureBeginn(uint fileLine, string name, uint line, int process)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;   //SDL layout
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MeasurePos.Left;
			this.mCapStyle 			= CapStyle.Inner;
			this.mFileLine 			= fileLine;
		}
		
		public MeasureBeginn(uint fileLine, uint line, int process)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MeasurePos.Left;
			this.mCapStyle 			= CapStyle.Inner;
			this.mFileLine 			= fileLine;
		}

		public MeasureBeginn(uint fileLine, string name, uint line, int process, MeasurePos placement)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mCapStyle 			= CapStyle.Inner;
			this.mFileLine 			= fileLine;
		}
		public MeasureBeginn(uint fileLine, string name, uint line, int process, MeasurePos placement, CapStyle style)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mCapStyle 			= style;
			this.mFileLine 			= fileLine;
		}
		
		public MeasureBeginn(uint fileLine, uint line, int process, string placement)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 10;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPlacement 		= CalcPlacement(placement);
			this.mCapStyle 			= CapStyle.Inner;
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

		public CapStyle MeasureCapStyle{
			get{
				return mCapStyle;
			}
			set{
				mCapStyle=value;
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
			float placementOffset	=0;
			float[] pattern 		= {6f,6f};
			RectangleF itemBox;
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET, MSCItem.ItemLayoutSize.Height);
			
			if (this.mPos == MeasurePos.Right){
				placementOffset=MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				this.mBounds.X = xPos;
				xPos += placementOffset;
			}
			else{
				this.mBounds.X = xPos-(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET*2);
				
			}
			this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET*2;
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			itemStringFormat.Alignment = StringAlignment.Near;
			if (this.mCapStyle==CapStyle.Inner){
				itemBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+1, yPos+lineHeight-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);
				drawDestination.FillRectangle(mBackBrush, itemBox);
				PointF[] statePolygon = new PointF[3];
				statePolygon[0] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET*2 + placementOffset,yPos + lineHeight+10);
				statePolygon[1] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2 + placementOffset,yPos + lineHeight+10);
				statePolygon[2] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+ placementOffset,yPos  + lineHeight);
				drawDestination.DrawPolygon(mItemPen,statePolygon);	
			}
			else{
				itemBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+1, yPos+lineHeight-itemNameSize.Height-10, itemNameSize.Width, itemNameSize.Height);
				drawDestination.FillRectangle(mBackBrush, itemBox);
				PointF[] statePolygon = new PointF[3];
				statePolygon[0] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET*2 + placementOffset,yPos + lineHeight-10);
				statePolygon[1] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2 + placementOffset,yPos + lineHeight-10);
				statePolygon[2] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+ placementOffset,yPos  + lineHeight);
				drawDestination.DrawPolygon(mItemPen,statePolygon);					
				mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
				mItemPen.DashPattern = pattern;
				drawDestination.DrawLine(mItemPen,xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+ placementOffset, yPos + lineHeight, xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+ placementOffset,yPos + lineHeight+10);
			}
			drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
			this.mBounds.Y = itemBox.Y;
			this.mBounds.Height = (yPos + lineHeight+10) - itemBox.Y;
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET,yPos + lineHeight);
			itemStringFormat.Dispose();	
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}
	}
}
