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
 * Date: 01.06.2005
 * Time: 12:42
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
	public partial class SetTimer : MSCItem
	{
		private int 		mProcess;
		private uint 		mInitialHeight;
		private ItemPos 	mPos;
		
		public SetTimer(uint fileLine, string name, uint line, int process)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 20; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mFileLine 			= fileLine;
			
		}
		
		public SetTimer(uint fileLine, uint line, int process)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 20;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mFileLine 			= fileLine;
		}

		public SetTimer(uint fileLine, string name, uint line, int process, ItemPos placement)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 20; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
		}
		
		public SetTimer(uint fileLine, uint line, int process, ItemPos placement)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 20;
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
			float placementOffset=0;
			RectangleF itemBox;
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			
			if (this.mPos == ItemPos.Right){
				placementOffset=MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET+1;
				xPos += placementOffset;
			}
			
			itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET-1, MSCItem.ItemLayoutSize.Height);
			
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			itemStringFormat.Alignment = StringAlignment.Near;
			itemBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET, yPos+lineHeight-10-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);
			drawDestination.FillRectangle(mBackBrush, itemBox);
			drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);

			drawDestination.DrawLine(mItemPen,xPos, yPos + lineHeight, xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET, yPos + lineHeight);
			
			PointF[] statePolygon = new PointF[3];
			statePolygon[0] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET*2+placementOffset,yPos + lineHeight-10);
			statePolygon[1] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2+placementOffset,yPos + lineHeight-10);
			statePolygon[2] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffset,yPos + lineHeight);
			drawDestination.DrawPolygon(mItemPen,statePolygon);
			statePolygon[0] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET*2+placementOffset,yPos + lineHeight+10);
			statePolygon[1] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2+placementOffset,yPos + lineHeight+10);
			statePolygon[2] = new PointF(xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffset,yPos + lineHeight);
			drawDestination.DrawPolygon(mItemPen,statePolygon);
			this.mBounds.X = Math.Min(statePolygon[0].X, itemBox.X);
			this.mBounds.Width = MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET*2;
			this.mBounds.Y = yPos;
			this.mBounds.Height = lineHeight+10;					
			itemStringFormat.Dispose();	
		}		
	}
}
