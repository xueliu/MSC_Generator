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
 * Date: 02.01.2006
 * Time: 14:23
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
	public partial class LineComment : MSCItem
	{
		private int 			mProcess;
		private bool 			mDrawLine;
		private CommentPos 		mPos;
		
		public LineComment(uint fileLine, string name, uint line, int process)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= process;
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mPos 			= CommentPos.Left;
			this.mDrawLine 		= true;
			this.mFileLine 		= fileLine;
		}
		
		public LineComment(uint fileLine, string name, uint line, int process, CommentPos pos)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= process;
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mPos 			= pos;
			this.mDrawLine 		= true;
			this.mFileLine 		= fileLine;
		}
		public LineComment(uint fileLine, string name, uint line, int process, CommentPos pos, bool drawLine)
		{
			this.mName 			= name;
			this.mLine 			= line;
			this.mProcess 		= process;
			this.mItemPen 		= new Pen(Color.Black, 1);
			this.mPos 			= pos;
			this.mDrawLine 		= drawLine;
			this.mFileLine 		= fileLine;
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
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			if (this.mDrawLine){
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-20, MSCItem.ItemLayoutSize.Height);
			}
			else{
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2, MSCItem.ItemLayoutSize.Height);				
			}
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			itemStringFormat.Dispose();
			return itemNameSize.Height;
		}
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float lineHeight)
		{
			RectangleF itemBox;
			float xOffset=0.0f;
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			if (this.mDrawLine){
				xOffset = 20.0f;
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET-xOffset, MSCItem.ItemLayoutSize.Height);
			}
			else{
				xOffset = 1.0f;
				itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET, MSCItem.ItemLayoutSize.Height);
			}
			
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
			
			if (this.mPos==CommentPos.Right){
				itemStringFormat.Alignment = StringAlignment.Near;
				itemBox = new RectangleF(xPos+xOffset, yPos+lineHeight-itemNameSize.Height+10, itemNameSize.Width, itemNameSize.Height);
				drawDestination.FillRectangle(mBackBrush,itemBox);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				if (this.mDrawLine){
					drawDestination.DrawLine(mItemPen,xPos+5, yPos+lineHeight, xPos+xOffset, yPos+lineHeight);
				}
				this.mBounds = new RectangleF(xPos,yPos+lineHeight-itemNameSize.Height+10,xOffset+itemNameSize.Width, itemNameSize.Height);

			}
			else{
				itemStringFormat.Alignment = StringAlignment.Far;
				itemBox = new RectangleF(xPos-xOffset-itemNameSize.Width, yPos+lineHeight-itemNameSize.Height+10, itemNameSize.Width, itemNameSize.Height);
				drawDestination.FillRectangle(mBackBrush,itemBox);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				if (this.mDrawLine){
					drawDestination.DrawLine(mItemPen,xPos-5, yPos+lineHeight, xPos-xOffset, yPos+lineHeight);
				}			
				this.mBounds = new RectangleF(xPos-xOffset-itemNameSize.Width,yPos+lineHeight-itemNameSize.Height+10,xOffset+itemNameSize.Width, itemNameSize.Height);
			}
			itemStringFormat.Dispose();	
		}		
	}
}
