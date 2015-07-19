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
 * Date: 07.06.2005
 * Time: 15:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of ProcessRegion.
	/// </summary>
	public partial class ProcessRegion : MSCItem
	{
		private int 			mProcess;
		private uint 			mInitialHeight;
		private ProcessStyle 	mStyle;
		private ProcessStyle 	mOldStyle;

		public ProcessRegion(uint fileLine, uint line, int process, ProcessStyle style, ProcessStyle oldStyle)
		{
			this.mLine 				= line;
			this.mProcess 			= process;
			this.mInitialHeight 	= 0; 
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mFileLine 			= fileLine;
			this.mStyle 			= style;
			this.mOldStyle 			= oldStyle;
		}
		
		public int Process{
			get{
				return mProcess;
			}
			set{
				mProcess=value;
			}
		}
		
		//LG
		public ProcessStyle MStyle{
			get{
				return this.mStyle;
			}
		}
		
		public float GetHeight(Graphics drawDestination)
		{
			return 	this.mInitialHeight;
		}
		
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float lineHeight)
		{
			switch (this.mStyle){
				case ProcessStyle.Coregion:
					drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos+5,yPos + lineHeight);
					if (mMscStyle == MscStyle.UML2){
						drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight+5, xPos-5,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xPos+5, yPos + lineHeight+5, xPos+5,yPos + lineHeight);
					}
					this.mBounds = new RectangleF(xPos-5 , yPos + lineHeight-5, 10,8);
					break;
				case ProcessStyle.Suspension:
				case ProcessStyle.Activation:
					this.mBounds = new RectangleF(xPos-5 , yPos + lineHeight-5, 10,8);
					drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos+5,yPos + lineHeight);
					break;
				case ProcessStyle.Normal:
					drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight, xPos+5,yPos + lineHeight);
					if ((mOldStyle == ProcessStyle.Coregion)&&(mMscStyle == MscStyle.UML2)){
						drawDestination.DrawLine(mItemPen,xPos-5, yPos + lineHeight-5, xPos-5,yPos + lineHeight);
						drawDestination.DrawLine(mItemPen,xPos+5, yPos + lineHeight-5, xPos+5,yPos + lineHeight);	
					}
					break;
			}
			
		}		
	}
}
