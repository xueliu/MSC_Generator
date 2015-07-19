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
 * Date: 04.09.2006
 * Time: 19:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using mscElements;
	
namespace nGenerator
{
	/// <summary>
	/// Description of Output.
	/// </summary>
	
	partial class Output
	{
		private Generator 		generator 				= null;
		private static bool 	autosizeExport 			= false; 	// auto size image hight at export
		private static bool 	autosizeOutputHeight 	= false;	// auto size image hight at output
		private static bool 	autosizeOutputWidth 	= false;	// auto size image width at output
		
		public static bool AutosizeExport{
			get{
				return autosizeExport;
			}
			set{
				autosizeExport = value;
			}
		}
		public static bool AutosizeOutputHeight{
			get{
				return autosizeOutputHeight;
			}
			set{
				autosizeOutputHeight = value;
			}
		}
		public static bool AutosizeOutputWidth{
			get{
				return autosizeOutputWidth;
			}
			set{
				autosizeOutputWidth = value;
			}
		}
	}
}
