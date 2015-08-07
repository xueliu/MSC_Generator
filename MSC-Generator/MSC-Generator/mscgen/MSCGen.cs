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
 * Time: 19:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;

namespace nGenerator
{
	/// <summary>
	/// Description of Generator.
	/// </summary>
	public partial class Generator
	{
		public Generator()			
		{
			pageHeights = new ArrayList();		// stores the heights of each page of the diagram. Necessery for auto height option
			processes = new ArrayList();		// stores the instances (proces, actor, dummy) of the diagram
			items = new ArrayList();			// stores the items of the diagram
			lines = new ArrayList();			// stores the verical lines of instance, timer, measure, etc.
			inLines = new ArrayList();			// stores the inlines of ref and inline
			mYInstanceOffset = 110;
			mYProcessName = 0;
			mHeadHeight = 0;
			mProcessNameHeight = 0;
			mInstanceNameHeight = 0;
			mLines=0;
		}
	}
}
