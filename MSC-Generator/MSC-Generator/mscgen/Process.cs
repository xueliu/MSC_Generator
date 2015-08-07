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
 * Time: 08:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;

namespace nGenerator
{
	/// <summary>
	/// Description of Process.
	/// </summary>
	public class Process : Processes
	{
		private string 		processName;
		private Brush 		processBrush;
		private float 		mXPos;
		private uint 		mLeftRand;
		private uint 		mRightRand;
		
		public Process(string name, Brush brush, uint leftRand, uint rightRand)
		{
			this.processName 		= name;
			this.processBrush 		= brush;
			this.ProcessPen 		= new Pen(Color.Black, 1);
			this.mLeftRand 			= leftRand;
			this.mRightRand 		= rightRand;
		}
		public float XPos{
			get{
				return mXPos;
			}
			set{
				mXPos=value;
			}
		}
		public uint LeftRand{
			get{
				return mLeftRand;
			}
		}
		public uint RightRand{
			get{
				return mRightRand;
			}
		}
		
		public byte Direction{
			get{
				return processesDirection;
			}
			set{
				processesDirection = value;
			}
		}
		public string ProcessName{
			get{
				return processName;
			}
		}
	}
}
