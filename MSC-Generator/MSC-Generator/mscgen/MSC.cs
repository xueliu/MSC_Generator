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
 * User: koto
 * Date: 11.07.2006
 * Time: 07:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace nGenerator
{
	
	public enum MscStyle{
		Unknown,
		UML2,
		SDL
	}
	/// <summary>
	/// Description of MSC.
	/// </summary>
	public class MSC
	{
		private static uint mLeftMargin = 0;
		private static uint mRightMargin = 0;
		
		protected static string mDiagramName = "";
		protected static MscStyle mMscStyle = MscStyle.UML2;
		protected static uint mVerticalOffset = 60;
		
		
		public MSC()
		{
		}
		
		public static uint VerticalOffset{
			get{
				return mVerticalOffset;
			}
			set{
				mVerticalOffset = value;
			}
		}
		public static string DiagramName{
			get{
				return mDiagramName;
			}
			set{
				mDiagramName = value;
			}
		}
		public static uint LeftMargin{
			get{
				return mLeftMargin;
			}
			set{
				mLeftMargin = value;
			}
		}
		public static uint RightMargin{
			get{
				return mRightMargin;
			}
			set{
				mRightMargin = value;
			}
		}
		public static MscStyle Style{
			get{
				return mMscStyle;
			}
			set{
				mMscStyle = value;
			}
		}
	}
}
