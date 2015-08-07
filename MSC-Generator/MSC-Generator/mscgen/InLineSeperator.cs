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
 * Date: 09.06.2005
 * Time: 12:17
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
	public partial class InLineSeparator : MSCItem
	{
		private string 		mIdentifier;
		private float 		mInitialHeight;
		private int 		mProcessBeginn;
		private int 		mProcessEnd;
		
		public InLineSeparator(uint fileLine, string identifier, uint line, int processBeginn, int processEnd)
		{
			this.mLine 				= line;
			this.mIdentifier 		= identifier;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mInitialHeight 	= 0;
			this.mProcessBeginn 	= Math.Min(processBeginn, processEnd);
			this.mProcessEnd 		= Math.Max(processBeginn, processEnd);
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
			return mInitialHeight;
		}

		public void DrawItem(Graphics drawDestination, float xPosStart, float xPosEnd, float LeftMargin, float RightMargin, float yPos, float lineHeight)
		{
			float[] pattern = {6f,6f};
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			xPosStart = xPosStart - MSCItem.ItemLayoutSize.Width/2 - LeftMargin-Generator.LOOP_OFFSET*2;
			xPosEnd = xPosEnd + MSCItem.ItemLayoutSize.Width/2 + RightMargin+Generator.LOOP_OFFSET*2;
			drawDestination.DrawLine(mItemPen, xPosStart, yPos+lineHeight, xPosEnd, yPos+lineHeight);
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.mBounds = new RectangleF(xPosStart,yPos+lineHeight-3,xPosEnd-xPosStart, 6);
		}
	}
}
