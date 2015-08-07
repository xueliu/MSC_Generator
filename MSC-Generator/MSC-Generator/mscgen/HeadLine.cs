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
 * Date: 30.05.2005
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Resources;
using System.Reflection;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of HeadLine.
	/// </summary>
	public partial class HeadLine : MSCItem
	{
		private Pen 	mHeadPen;
		private float 	mInitialHeight;
		
		public HeadLine(string name)
		{
			MSC.DiagramName 		= name;
			this.mName				= name;
			this.mHeadPen 			= new Pen(Color.Black, 1);
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mInitialHeight 	= 30;
		}
		public float GetHeight(Graphics drawDestination, float width)
		{
			SizeF 			headNameSize, 
							headLayoutSize 		= new SizeF(width, 100);
			StringFormat 	headStringFormat 	= new StringFormat();	
			
			headNameSize = drawDestination.MeasureString("MSC " + MSC.DiagramName, mItemFont, headLayoutSize, headStringFormat);
			return Math.Max(mInitialHeight, headNameSize.Height+10);
		}
		public void DrawItem(Graphics drawDestination, float xPos, float yPos, float width, uint site, uint sites)
		{
			RectangleF 		headBox;
			SizeF 			headNameSize, 
							headLayoutSize		= new SizeF(width, 100);
			StringFormat 	headStringFormat 	= new StringFormat();
			float 			prefixWidth 					= 0f;      				// width of prefix "msc" or "sd"
			Font			fontA;
			Font			fontB;
			try{
				fontA				= new Font(mItemFont.Name,mItemFont.Size,FontStyle.Regular,GraphicsUnit.Point);
				fontB				= new Font(mItemFont.Name,mItemFont.Size,FontStyle.Bold,GraphicsUnit.Point);
			}
			catch{
				fontA				= mItemFont;
				fontB				= mItemFont;				
			}
			this.mName = MSC.DiagramName;
			if (mMscStyle == MscStyle.UML2){
				prefixWidth = drawDestination.MeasureString("sd ",fontB, headLayoutSize, headStringFormat).Width;
				headBox = new RectangleF(xPos, yPos, prefixWidth, headLayoutSize.Height);
				drawDestination.DrawString("sd ",fontB,Brushes.Black,headBox,headStringFormat);
			}
			else {
				prefixWidth = drawDestination.MeasureString("MSC ",fontB, headLayoutSize, headStringFormat).Width;
				headBox = new RectangleF(xPos, yPos, prefixWidth, headLayoutSize.Height);
				drawDestination.DrawString("MSC ",fontB,Brushes.Black,headBox,headStringFormat);			
			}
			headLayoutSize = new SizeF(width-prefixWidth-40, 100);
			headNameSize = drawDestination.MeasureString(mName, fontA, headLayoutSize, headStringFormat);
			headStringFormat.LineAlignment = StringAlignment.Center;
			headBox = new RectangleF(xPos+prefixWidth, yPos, width-prefixWidth-40, headNameSize.Height);
			drawDestination.DrawString(mName,fontA,Brushes.Black,headBox,headStringFormat);			
			headStringFormat.LineAlignment = StringAlignment.Near;
			headStringFormat.Alignment = StringAlignment.Far;
			headBox = new RectangleF(width-150, yPos, 150, headNameSize.Height);
			ResourceManager strings = new ResourceManager (nGenerator.Output.stringResources, Assembly.GetAssembly(typeof(HeadLine)));
			if ((sites>1)&&(site>0)) drawDestination.DrawString(strings.GetString("Page ") + site + "/" + sites,fontA,Brushes.Black,headBox,headStringFormat);
			if (mMscStyle == MscStyle.UML2){
				drawDestination.DrawLine(mItemPen, xPos, yPos+headNameSize.Height, xPos+prefixWidth+headNameSize.Width,yPos+headNameSize.Height);
				drawDestination.DrawLine(mItemPen, xPos+prefixWidth+headNameSize.Width,yPos+headNameSize.Height, xPos+prefixWidth+10+headNameSize.Width, yPos+headNameSize.Height-10);
				drawDestination.DrawLine(mItemPen,xPos+prefixWidth+10+headNameSize.Width, yPos+headNameSize.Height-10, xPos+prefixWidth+10+headNameSize.Width, yPos);		
			}
		}
	}
}
