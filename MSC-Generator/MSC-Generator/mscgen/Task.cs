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
 * Time: 13:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	public partial class Task : MSCItem
	{
		private int 	mProcess;
		private ItemPos mPos;
		
		public Task(uint fileLine, string name, uint line, int process)
		{
			this.mName 		= name;
			this.mLine 		= line;
			this.mProcess 	= process;
			this.mItemPen 	= new Pen(Color.Black, 1);
			this.mFileLine 	= fileLine;
			this.mPos		= ItemPos.Top;
		}
		
		public Task(uint fileLine, string name, uint line, int process, ItemPos pos)
		{
			this.mName 		= name;
			this.mLine 		= line;
			this.mProcess 	= process;
			this.mItemPen 	= new Pen(Color.Black, 1);
			this.mFileLine 	= fileLine;
			this.mPos		= pos;
		}
		public ItemPos Position{
			get{
				return mPos;
			}
			set{
				mPos = value;
			}
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
			SizeF itemNameSize;
			StringFormat itemStringFormat = new StringFormat();
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemStringFormat.Dispose();
			mHeight = itemNameSize.Height;
			return mHeight;
		}
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float height)
		{
			RectangleF itemBox;
			SizeF itemNameSize;
			StringFormat itemStringFormat = new StringFormat();
			if (this.mPos == ItemPos.Bottom){
				yPos = (yPos + height)- mHeight;
			}
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2, yPos, MSCItem.ItemLayoutSize.Width, itemNameSize.Height);
			
			drawDestination.FillRectangle(mFillBrush, xPos - MSCItem.ItemLayoutSize.Width/2, yPos, MSCItem.ItemLayoutSize.Width, itemNameSize.Height);	
			drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
			drawDestination.DrawRectangle(mItemPen, xPos - MSCItem.ItemLayoutSize.Width/2, yPos, MSCItem.ItemLayoutSize.Width, itemNameSize.Height);	
			itemStringFormat.Dispose();
			this.mBounds = itemBox;
		}
	}
}
