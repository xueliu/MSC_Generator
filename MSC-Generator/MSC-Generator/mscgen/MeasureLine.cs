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
 * Time: 08:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	public enum CapStyle{
		Inner,
		Outer
	}
	public enum MeasurePos{
		Left,
		Right
	}
	/// <summary>
	/// Description of Loopline.
	/// </summary>
	/// 
	public class MeasureLine : MSCItem
	{
		uint 			mLineBeginn;
		uint 			mLineEnd;
		int 			mProcess;
		MeasurePos 		mPos;
		CapStyle 		mCapStyle;
		
		public MeasureLine(uint line, int process)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MeasurePos.Left;
			this.mCapStyle 			= CapStyle.Inner;
		}
		public MeasureLine(uint line, int process, MeasurePos placement)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mCapStyle 			= CapStyle.Inner;
		}
		public MeasureLine(uint line, CapStyle style, int process)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= MeasurePos.Left;
			this.mCapStyle 			= style;
		}
		public MeasureLine(uint line, CapStyle style, int process, MeasurePos placement)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mCapStyle 			= style;
		}
		public MeasurePos MeasurePlacement{
			get{
				return mPos;
			}
			set{
				mPos = value;
			}
		}
		public uint LineBegin{
			get{
				return mLineBeginn;
			}
			set{
				mLineBeginn=value;
			}
		}
		public uint LineEnd{
			get{
				return mLineEnd;
			}
			set{
				mLineEnd=value;
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
		public CapStyle MeasureCapStyle{
			get{
				return mCapStyle;
			}
			set{
				mCapStyle=value;
			}
		}		
		
		public void DrawItem(Graphics drawDestination, float xPos, float yPosStart, float yPosEnd)
		{
			float[] pattern = {6f,6f};
			float placementOffset = 0;
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			if (this.mPos==MeasurePos.Right){
				placementOffset = MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				xPos += placementOffset;
			}
			drawDestination.DrawLine(mItemPen,xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffset,yPosStart, xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffset,yPosEnd);							
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}
		public void DrawItemCarry(Graphics drawDestination, float xPos, float yPosStart, float yPosEnd)
		{
			float[] pattern = {1f,2f};
			float placementOffset = 0;
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			if (this.mPos==MeasurePos.Right){
				placementOffset = MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				xPos += placementOffset;
			}
			drawDestination.DrawLine(mItemPen,xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffset,yPosStart, xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET+placementOffset,yPosEnd);							
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}		
	}
}
