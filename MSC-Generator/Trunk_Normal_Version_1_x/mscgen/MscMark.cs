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
 * Time: 14:29
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
	public enum MarkPos{
		TopLeft,
		BottomLeft,
		TopRight,
		BottomRight
	}
	
	public partial class Mark : MSCItem
	{
		private int 		mProcess;
		private uint 		mInitialHeight;
		private MarkPos 	mPos;

		public Mark(uint fileLine, string name, uint line, int process)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 20;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MarkPos.TopLeft;
			this.mFileLine 			= fileLine;
		}
		
		public Mark(uint fileLine, uint line, int process)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 20;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MarkPos.TopLeft;
			this.mFileLine 			= fileLine;
		}

		public Mark(uint fileLine, string name, uint line, int process, MarkPos placement)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mFileLine 			= fileLine;
			if ((placement == MarkPos.BottomLeft) || (placement== MarkPos.BottomRight)){
				this.mInitialHeight 	= 3; 
			}
			else{
				this.mInitialHeight 	= 20; 
			}
		}
		
		public Mark(uint fileLine, uint line, int process, MarkPos placement)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mProcess 			= process;
			if ((placement == MarkPos.BottomLeft) || (placement== MarkPos.BottomRight)){
				this.mInitialHeight 	= 3; 
			}
			else{
				this.mInitialHeight 	= 20; 
			}
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
			return 	this.mInitialHeight;
		}
		
		public void DrawItem(Graphics drawDestination, float xPos, float xLeftPos,float xRightPos, float yPos, float lineHeight, float yItemOffset)
		{
			float placementOffsetH=0,placementOffsetV=0,xPosDestination=0;
			float[] pattern = {6f,6f};
			this.ItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.ItemPen.DashPattern = pattern;
			if ((this.mPos==MarkPos.TopRight)||(this.mPos==MarkPos.BottomRight)){
				placementOffsetH=MSCItem.ItemLayoutSize.Width+2*Generator.LOOP_OFFSET;
				xPosDestination = xRightPos;
			}
			else{
				xPosDestination = xLeftPos;
			}
			if ((this.mPos ==MarkPos.BottomLeft)||(this.mPos==MarkPos.BottomRight)){
				placementOffsetV=lineHeight+yItemOffset-2;
			}
			else{
				placementOffsetV=-2;
			}

			RectangleF itemBox;
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width, MSCItem.ItemLayoutSize.Height);
			
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			itemStringFormat.Alignment = StringAlignment.Near;
			if ((this.mPos==MarkPos.TopRight)||(this.mPos==MarkPos.BottomRight))
				itemBox = new RectangleF(xPosDestination-itemNameSize.Width, yPos+placementOffsetV-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);
			else
				itemBox = new RectangleF(xPosDestination, yPos+placementOffsetV-itemNameSize.Height, itemNameSize.Width, itemNameSize.Height);	
			drawDestination.FillRectangle(mBackBrush, itemBox);
			drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
			drawDestination.DrawLine(mItemPen,xPos, yPos+lineHeight, xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffsetH,yPos+placementOffsetV);
			drawDestination.DrawLine(mItemPen,xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffsetH,yPos+placementOffsetV, xPosDestination,yPos+placementOffsetV);				
			itemStringFormat.Dispose();
			this.mBounds.X = Math.Min(xRightPos-50,itemBox.X);
			this.mBounds.Width = Math.Max(itemBox.Width,50);
			this.mBounds.Y = yPos+placementOffsetV-2-itemBox.Height;
			this.mBounds.Height = 4+itemBox.Height;
			this.ItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}
	}
}
