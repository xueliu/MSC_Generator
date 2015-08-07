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
 * Date: 08.06.2005
 * Time: 14:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
namespace mscElements
{
	/// <summary>
	/// Description of InLineBeginn.
	/// </summary>
	public partial class InLineBeginn : MSCItem
	{
		private string 		mIdentifier;
		private int 		mProcessBeginn;
		private int 		mProcessEnd;
		private float 		mInitialHeight;
		
		public InLineBeginn(uint fileLine, string name, string identifier, uint line, int processBeginn, int processEnd)
		{
			this.mName 				= name;
			this.mLine 				= line;
			this.mIdentifier 		= identifier;
			this.mProcessBeginn 	= Math.Min(processBeginn, processEnd);
			this.mProcessEnd 		= Math.Max(processBeginn, processEnd);
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mInitialHeight 	= 20;
			this.mFileLine 			= fileLine;
		}
		public string Identifier{
			get{
				return mIdentifier;
			}
			set{
				mIdentifier=value;
			}
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
		public float GetHeight(Graphics drawDestination)
		{
			SizeF itemNameSize;
			StringFormat itemStringFormat = new StringFormat();
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemStringFormat.Dispose();
			return Math.Max(itemNameSize.Height,mInitialHeight);
		}
		public void DrawItem(Graphics drawDestination, float xPosStart, float xPosEnd, float LeftMargin, float RightMargin, float yPos, float lineHeight)
		{
			RectangleF itemBox;
			SizeF itemNameSize;
			float yOffset;
			xPosStart = xPosStart - MSCItem.ItemLayoutSize.Width/2 - LeftMargin-Generator.LOOP_OFFSET*2;
			xPosEnd = xPosEnd + MSCItem.ItemLayoutSize.Width/2 + RightMargin+Generator.LOOP_OFFSET*2;
			StringFormat itemStringFormat = new StringFormat();			
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemStringFormat.Alignment = StringAlignment.Near;
			yOffset = Math.Max(mInitialHeight, itemNameSize.Height);
			itemBox = new RectangleF(xPosStart, yPos, MSCItem.ItemLayoutSize.Width, itemNameSize.Height);
			PointF[] inLinePolygon = new PointF[5];
			inLinePolygon[0] = new PointF(xPosStart+1,yPos);
			inLinePolygon[1] = new PointF(xPosStart+itemNameSize.Width+10,yPos);
			inLinePolygon[2] = new PointF(xPosStart+itemNameSize.Width+10,yPos+yOffset-10);
			inLinePolygon[3] = new PointF(xPosStart+itemNameSize.Width,yPos+yOffset);
			inLinePolygon[4] = new PointF(xPosStart+1,yPos+yOffset);
			drawDestination.FillPolygon(mFillBrush, inLinePolygon);
			drawDestination.DrawLine(mItemPen, xPosStart, yPos, xPosEnd, yPos);
			drawDestination.DrawLine(mItemPen, xPosStart, yPos+yOffset, xPosStart+itemNameSize.Width, yPos+yOffset);
			drawDestination.DrawLine(mItemPen, xPosStart+itemNameSize.Width, yPos+yOffset, xPosStart+itemNameSize.Width+10, yPos+yOffset-10);
			drawDestination.DrawLine(mItemPen, xPosStart+itemNameSize.Width+10, yPos+yOffset-10, xPosStart+itemNameSize.Width+10, yPos);
			drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
			this.mBounds = new RectangleF(xPosStart,yPos,itemNameSize.Width+10, yOffset);
			itemStringFormat.Dispose();
		}			
	}
}
