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
 * Date: 23.05.2005
 * Time: 12:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements 
{
	/// <summary>
	/// Description of MSCEnd.
	/// </summary>
	public class MSCEnd : MSCItem
	{
		private uint mInitialHeight;

		public MSCEnd(uint line)
		{
			this.mLine 				= line;
			this.mInitialHeight 	= 15;
			this.mItemPen 			= new Pen(Color.Black, 1);
		}
		public float GetHeight(Graphics drawDestination)
		{
			return 	this.mInitialHeight;
		}
		public void DrawItem(Graphics drawDestination, float xPos, float yPos)
		{
			if (mMscStyle == MscStyle.SDL)
				drawDestination.FillRectangle(Brushes.Black, xPos - MSCItem.ItemLayoutSize.Width/4, yPos-this.mInitialHeight, MSCItem.ItemLayoutSize.Width/2, this.mInitialHeight);	
		}
	}
}
