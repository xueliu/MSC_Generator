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
 * Date: 18.05.2005
 * Time: 08:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Collections;

namespace nGenerator
{
	/// <summary>
	/// Description of Processes.
	/// </summary>
	public class Processes
	{
		protected byte 			processesDirection;
		protected static SizeF 	processesLayoutSize;
		protected static Font 	processFont;		
		protected static int 	pCount=0;
		protected Pen 			mProcessPen;
		protected bool 			mDummy;
		protected float 		mLeftProcessMargin, 
								mRightProcessMargin;
		public const byte 		DIRECTION_HORIZONTAL			=0x00;
		public const byte 		DIRECTION_VERTICAL				=0x01;		
		
		public const int 		topSpace						=10;
		
		public Processes()
		{
			processesLayoutSize 	= new SizeF(100.0F, 100.0F);
			processesDirection 		= DIRECTION_HORIZONTAL;
			processFont 			= new Font("Arial",10,FontStyle.Regular,GraphicsUnit.Point);
			mLeftProcessMargin 		= 0;
			mRightProcessMargin 	= 0;
			mDummy					=false;
			pCount++;
		}
		~Processes()
		{
			pCount--;
		}
		public bool Dummy{
			get{
				return mDummy;
			}
			set{
				mDummy = value;
			}
		}
		public static int Count{
			get{
				return pCount;
			}
		}
		public float LeftMargin{
			get{
				return mLeftProcessMargin;
			}
			set{
				mLeftProcessMargin = value;
			}
		}
		public float RightMargin{
			get{
				return mRightProcessMargin;
			}
			set{
				mRightProcessMargin = value;
			}
		}
			
		public void SetSize(float height)
		{
			processesLayoutSize.Height = height;
		}
		public void SetSize(float width, float height)
		{
			processesLayoutSize.Width = width;
			processesLayoutSize.Height = height;
		}
		public void SetSize(SizeF size)
		{
			processesLayoutSize = size;
		}
		public void SetFont(Font font)
		{
			processFont = font;
		}
		public void ProcessesDraw()
		{
			//Process
		}
		public Pen ProcessPen{
			get{
				return mProcessPen;
			}
			set{
				mProcessPen=value;
			}
		}
	}
}
