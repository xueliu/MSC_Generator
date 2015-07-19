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
 * Date: 06.06.2005
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
	/// Description of TimeoutEnd.
	/// </summary>
	public partial class ProcessStop : MSCItem
	{
		private int 	mProcess;
		private uint 	mInitialHeight;

		public ProcessStop(uint fileLine, uint line, int process)
		{
			this.mName 				= "";
			this.mLine 				= line;
			this.mInitialHeight 	= STOPXSIZE/2;
			this.mProcess 			= process;
			this.mInitialHeight 	= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
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
		
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float lineHeight)
		{
			drawDestination.DrawLine(mItemPen,xPos-STOPXSIZE,yPos+lineHeight-STOPXSIZE, xPos+STOPXSIZE,yPos+lineHeight+STOPXSIZE);				
			drawDestination.DrawLine(mItemPen,xPos-STOPXSIZE,yPos+lineHeight+STOPXSIZE, xPos+STOPXSIZE,yPos+lineHeight-STOPXSIZE);				
			this.mBounds.X = xPos-STOPXSIZE;
			this.mBounds.Width = STOPXSIZE*2;
			this.mBounds.Y = yPos+lineHeight-STOPXSIZE;
			this.mBounds.Height = STOPXSIZE*2;					
		}		
	}
}
