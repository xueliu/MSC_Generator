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
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	public enum InLineType{
		Normal,
		Reference
	}
	/// <summary>
	/// Description of InLine.
	/// </summary>
	public partial class InLine:MSCItem
	{
		uint 		mLineBeginn;
		uint 		mLineEnd;
		int 		mProcessBeginn;
		int 		mProcessEnd;
		string 		mIdentifier;
		float 		mXLeftOffset;
		float 		mXRightOffset;
		InLineType 	mType;
		
		public InLine(string identifier, uint lineBeginn, int processBeginn, int processEnd)
		{
			this.mIdentifier 		= identifier;
			this.mLineBeginn 		= lineBeginn;
			this.mProcessBeginn 	= Math.Min(processBeginn, processEnd);
			this.mProcessEnd 		= Math.Max(processBeginn, processEnd);
			this.mXLeftOffset 		= 0;
			this.mXRightOffset 		= 0;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mType 				= InLineType.Normal;
		}
		public InLine(string identifier, uint lineBeginn, int processBeginn, int processEnd, InLineType type)
		{
			this.mIdentifier 		= identifier;
			this.mLineBeginn 		= lineBeginn;
			this.mProcessBeginn 	= Math.Min(processBeginn, processEnd);
			this.mProcessEnd 		= Math.Max(processBeginn, processEnd);
			this.mXLeftOffset 		= 0;
			this.mXRightOffset 		= 0;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mType 				= type;
		}
		public uint LineBeginn{
			get{
				return this.mLineBeginn;
			}
			set{
				this.mLineBeginn = value;
			}
		}
		public uint LineEnd{
			get{
				return this.mLineEnd;
			}
			set{
				this.mLineEnd = value;
			}
		}
		public int ProcessBeginn{
			get{
				return this.mProcessBeginn;
			}
			set{
				this.mProcessBeginn = value;
			}
		}
		public int ProcessEnd{
			get{
				return this.mProcessEnd;
			}
			set{
				this.mProcessEnd = value;
			}
		}
		public string Identifier{
			get{
				return this.mIdentifier;
			}
			set{
				this.mIdentifier = value;
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
		public void DrawItem(Graphics drawDestination, float xPosStart, float xPosEnd, float LeftMargin, float RightMargin, float yPosStart, float yPosEnd)
		{
			xPosStart = xPosStart - MSCItem.ItemLayoutSize.Width/2 - LeftMargin-Generator.LOOP_OFFSET*2;
			xPosEnd = xPosEnd + MSCItem.ItemLayoutSize.Width/2 + RightMargin+Generator.LOOP_OFFSET*2;
			if (this.mType == InLineType.Reference){
				drawDestination.FillRectangle(Brushes.White, xPosStart,yPosStart,xPosEnd - xPosStart, yPosEnd - yPosStart);
			}
			drawDestination.DrawLine(mItemPen,xPosStart,yPosStart, xPosStart,yPosEnd);
			drawDestination.DrawLine(mItemPen,xPosEnd,yPosStart, xPosEnd,yPosEnd);							
		}
		public void DrawItemCarry(Graphics drawDestination, float xPosStart, float xPosEnd, float LeftMargin, float RightMargin, float yPosStart, float yPosEnd)
		{
			float[] pattern 	= {1f,2f};
			xPosStart = xPosStart - MSCItem.ItemLayoutSize.Width/2 - LeftMargin-Generator.LOOP_OFFSET*2;
			xPosEnd = xPosEnd + MSCItem.ItemLayoutSize.Width/2 + RightMargin+Generator.LOOP_OFFSET*2;
			if (this.mType == InLineType.Reference){
				drawDestination.FillRectangle(Brushes.White, xPosStart,yPosStart,xPosEnd - xPosStart, yPosEnd - yPosStart);
			}
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			drawDestination.DrawLine(mItemPen,xPosStart,yPosStart,xPosStart,yPosEnd);							
			drawDestination.DrawLine(mItemPen,xPosEnd,yPosStart,xPosEnd,yPosEnd);							
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}		
	}
}
