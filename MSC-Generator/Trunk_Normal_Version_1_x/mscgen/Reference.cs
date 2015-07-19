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
 * Date: 30.06.2005
 * Time: 09:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Reference.
	/// </summary>
	public partial class Reference : MSCItem
	{
		private int 	mProcessBeginn;
		private int 	mProcessEnd;
		private float 	mInitialHeight;
		private string 	mTitel;
		private float 	mXLeftOffset;
		private float 	mXRightOffset;
		
		public Reference(uint fileLine, string name, uint line, int processBeginn, int processEnd)
		{
			this.mName = name;
			this.mLine = line;
			this.mProcessBeginn = Math.Min(processBeginn, processEnd);
			this.mProcessEnd = Math.Max(processBeginn, processEnd);
			this.mItemPen = new Pen(Color.Black, 1);
			this.mTitel= "ref";
			this.mInitialHeight = 30;
			this.mFileLine = fileLine;
		}
		public int ProcessBeginn{
			get{
				return mProcessBeginn;
			}
			set{
				mProcessBeginn=value;
			}
		}
		public int ProcessEnd{
			get{
				return mProcessEnd;
			}
			set{
				mProcessEnd=value;
			}
		}
		public float LeftOffset{
			get{
				return this.mXLeftOffset;
			}
			set{
				this.mXLeftOffset = value;
			}
		}
		public float RightOffset{
			get{
				return this.mXRightOffset;
			}
			set{
				this.mXRightOffset = value;
			}
		}
		public float GetHeight(Graphics drawDestination, float xPosStart, float xPosEnd)
		{
			SizeF itemNameSize, itemAllowedNameSize;
			StringFormat itemStringFormat = new StringFormat();
			float LeftMargin, RightMargin;
			LeftMargin = this.mXLeftOffset;
			RightMargin = this.mXRightOffset;
			xPosStart = xPosStart - MSCItem.ItemLayoutSize.Width/2 - LeftMargin-Generator.LOOP_OFFSET*2;
			xPosEnd = xPosEnd + MSCItem.ItemLayoutSize.Width/2 + RightMargin+Generator.LOOP_OFFSET*2;
			itemAllowedNameSize = new SizeF(xPosEnd - xPosStart, MSCItem.ItemLayoutSize.Height);
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemAllowedNameSize, itemStringFormat);
			itemStringFormat.Dispose();
			return itemNameSize.Height + mInitialHeight;
		}
		public void DrawItem(Graphics drawDestination, float xPosStart, float xPosEnd, float yPos, float lineHeight)
		{
			RectangleF itemBox;
			SizeF itemNameSize, itemTitelSize, itemAllowedNameSize;
			float yOffset;
			float LeftMargin, RightMargin;
			LeftMargin = this.mXLeftOffset;
			RightMargin = this.mXRightOffset;
			xPosStart = xPosStart - MSCItem.ItemLayoutSize.Width/2 - LeftMargin-Generator.LOOP_OFFSET*2;
			xPosEnd = xPosEnd + MSCItem.ItemLayoutSize.Width/2 + RightMargin+Generator.LOOP_OFFSET*2;
			StringFormat itemStringFormat = new StringFormat();			
			itemTitelSize = drawDestination.MeasureString(mTitel, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemAllowedNameSize = new SizeF(xPosEnd - xPosStart, lineHeight);
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemAllowedNameSize, itemStringFormat);
			if (mMscStyle == MscStyle.UML2){
				itemStringFormat.Alignment = StringAlignment.Near;
				//itemStringFormat.Alignment = StringAlignment.Center;
				yOffset = itemTitelSize.Height;
				itemBox = new RectangleF(xPosStart, yPos, MSCItem.ItemLayoutSize.Width, MSCItem.ItemLayoutSize.Height);
				PointF[] inLinePolygon = new PointF[5];
				inLinePolygon[0] = new PointF(xPosStart,yPos);
				inLinePolygon[1] = new PointF(xPosStart+itemTitelSize.Width+10,yPos);
				inLinePolygon[2] = new PointF(xPosStart+itemTitelSize.Width+10,yPos+yOffset-10);
				inLinePolygon[3] = new PointF(xPosStart+itemTitelSize.Width,yPos+yOffset);
				inLinePolygon[4] = new PointF(xPosStart,yPos+yOffset);
				drawDestination.FillRectangle(Brushes.White,xPosStart,yPos,xPosEnd-xPosStart,lineHeight);
				drawDestination.FillPolygon(mFillBrush, inLinePolygon);
				drawDestination.DrawRectangle(mItemPen,xPosStart,yPos,xPosEnd-xPosStart,lineHeight);			
				drawDestination.DrawLine(mItemPen, xPosStart, yPos+yOffset, xPosStart+itemTitelSize.Width, yPos+yOffset);
				drawDestination.DrawLine(mItemPen, xPosStart+itemTitelSize.Width, yPos+yOffset, xPosStart+itemTitelSize.Width+10, yPos+yOffset-10);
				drawDestination.DrawLine(mItemPen, xPosStart+itemTitelSize.Width+10, yPos+yOffset-10, xPosStart+itemTitelSize.Width+10, yPos);
				drawDestination.DrawString(mTitel,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				itemBox = new RectangleF((xPosEnd+xPosStart+LeftMargin+RightMargin)/2 - itemNameSize.Width/2, yPos+yOffset+5, itemNameSize.Width, itemNameSize.Height);
				drawDestination.FillRectangle(mBackBrush, itemBox);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				this.mBounds = new RectangleF(xPosStart,yPos,xPosEnd-xPosStart,lineHeight);
				itemStringFormat.Dispose();
			}
			else if (mMscStyle == MscStyle.SDL){

				drawDestination.FillPie(mFillBrush,xPosStart,yPos,20,20,180,90);
				drawDestination.FillPie(mFillBrush,xPosStart,yPos+lineHeight-20,20,20,90,90);
				drawDestination.FillPie(mFillBrush,xPosEnd-20,yPos,20,20,270,90);
				drawDestination.FillPie(mFillBrush,xPosEnd-20,yPos+lineHeight-20,20,20,0,90);
				
				drawDestination.FillRectangle(mFillBrush, xPosStart, yPos+10, 10, lineHeight-20);
				drawDestination.FillRectangle(mFillBrush, xPosEnd-10, yPos+10, 10, lineHeight-20);
				drawDestination.FillRectangle(mFillBrush, xPosStart+10, yPos, xPosEnd-xPosStart-20, lineHeight);
				
				drawDestination.DrawLine(mItemPen,xPosStart+10,yPos,xPosEnd-10,yPos);
				drawDestination.DrawLine(mItemPen,xPosStart,yPos+10,xPosStart,yPos+lineHeight-10);						
				drawDestination.DrawLine(mItemPen,xPosStart+10,yPos+lineHeight,xPosEnd-10,yPos+lineHeight);						
				drawDestination.DrawLine(mItemPen,xPosEnd,yPos+10,xPosEnd,yPos+lineHeight-10);						

				drawDestination.DrawArc(mItemPen,xPosStart,yPos,20,20,180,90);
				drawDestination.DrawArc(mItemPen,xPosStart,yPos+lineHeight-20,20,20,90,90);
				drawDestination.DrawArc(mItemPen,xPosEnd-20,yPos,20,20,270,90);
				drawDestination.DrawArc(mItemPen,xPosEnd-20,yPos+lineHeight-20,20,20,0,90);

				itemStringFormat.LineAlignment = StringAlignment.Center;
				
				itemBox = new RectangleF((xPosEnd+xPosStart+LeftMargin+RightMargin)/2 - itemNameSize.Width/2, yPos, itemNameSize.Width, lineHeight);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				
				this.mBounds = new RectangleF(xPosStart,yPos,xPosEnd-xPosStart,lineHeight);
			}
		}			
	}
}
