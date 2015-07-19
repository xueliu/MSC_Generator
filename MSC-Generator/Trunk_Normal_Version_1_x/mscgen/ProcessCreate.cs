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
 * Time: 16:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	public partial class ProcessCreate : MSCItem
	{
		private int 		mProcessSource;
		private int 		mProcessDestination;
		private string 		mMessName;
		private string 		mDescription;
		
		public ProcessCreate(uint fileLine, string name, string messName, uint line, int source, int destination)
		{
			this.mMessName 				= messName;
			this.mDescription 			= "";
			this.mName 					= name;
			this.mLine 					= line;
			this.mProcessSource 		= source;
			this.mProcessDestination 	= destination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mFileLine 				= fileLine;
			
		}
		
		public ProcessCreate(uint fileLine, string name, string messName, string description, uint line, int source, int destination)
		{
			this.mName 					= name;
			this.mMessName 				= messName;
			this.mDescription 			= description;
			this.mLine 					= line;
			this.mProcessSource 		= source;
			this.mProcessDestination 	= destination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mFileLine 				= fileLine;
		}
		public int Source{
			get{
				return mProcessSource;
			}
			set{
				mProcessSource=value;
			}
		}
		
		public int Destination{
			get{
				return mProcessDestination;
			}
			set{
				mProcessDestination=value;
			}
		}

		public float GetHeight(Graphics drawDestination, float xPosSource, float xPosDestination)
		{
			SizeF itemNameSize, itemMessSize, itemDescriptionSize;
			StringFormat itemStringFormat = new StringFormat();
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemDescriptionSize = drawDestination.MeasureString(mDescription, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemMessSize = drawDestination.MeasureString(mMessName, mItemFont, new SizeF(Math.Abs(xPosDestination-xPosSource)-MSCItem.ItemLayoutSize.Width/2,MSCItem.ItemLayoutSize.Height), itemStringFormat);
			itemStringFormat.Dispose();
			return Math.Max(itemNameSize.Height+itemDescriptionSize.Height, itemNameSize.Height/2+itemMessSize.Height) ;
		}
		
		public void DrawItem(Graphics drawDestination, float xPosSource, float xPosDestination, float yPos, float lineHeight, ProcessStyle sourceStyle, ProcessStyle destinationStyle)
		{
			if (xPosDestination<xPosSource){
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource -=5;
			}
			if (xPosDestination>xPosSource){
				if ((sourceStyle == ProcessStyle.Activation)||(sourceStyle == ProcessStyle.Suspension))
					xPosSource +=5;
			}
			RectangleF itemBox;
			float descY=0.0f, msgY=0.0f, procY=0.0f, procHeight=0.0f;
			SizeF itemNameSize, itemMessSize, itemDescriptionSize;
			StringFormat itemStringFormat = new StringFormat();
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemDescriptionSize = drawDestination.MeasureString(mDescription, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemMessSize = drawDestination.MeasureString(mMessName, mItemFont, new SizeF(Math.Abs(xPosDestination-xPosSource)-MSCItem.ItemLayoutSize.Width/2,MSCItem.ItemLayoutSize.Height), itemStringFormat);			
			itemStringFormat.Alignment = StringAlignment.Center;
			itemBox = new RectangleF(xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(0,itemMessSize.Height-((itemNameSize.Height/2)+itemDescriptionSize.Height)), MSCItem.ItemLayoutSize.Width, itemDescriptionSize.Height);
			descY = itemBox.Y;
			drawDestination.FillRectangle(Brushes.White, xPosDestination - MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(0,itemMessSize.Height-((itemNameSize.Height/2)+itemDescriptionSize.Height)), MSCItem.ItemLayoutSize.Width, itemDescriptionSize.Height);
			drawDestination.DrawString(mDescription,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
			itemBox = new RectangleF(xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height,itemMessSize.Height-(itemNameSize.Height/2)), MSCItem.ItemLayoutSize.Width, itemNameSize.Height);
			procY = itemBox.Y;
			procHeight = itemBox.Height;
			drawDestination.FillRectangle(mFillBrush, xPosDestination - MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height,itemMessSize.Height-(itemNameSize.Height/2)), MSCItem.ItemLayoutSize.Width, itemNameSize.Height);
			drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
			if(mMscStyle == MscStyle.SDL){
				if (xPosDestination>xPosSource){
					itemBox = new RectangleF((xPosSource+xPosDestination-MSCItem.ItemLayoutSize.Width/2)/2-itemMessSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-itemMessSize.Height, itemMessSize.Width, itemMessSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox.Left, itemBox.Top, itemBox.Width, itemBox.Height);	
					drawDestination.DrawRectangle(mItemPen, xPosDestination - MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height,itemMessSize.Height-(itemNameSize.Height/2)), MSCItem.ItemLayoutSize.Width, itemNameSize.Height);	
					drawDestination.DrawString(mMessName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height));
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height));
					messagePolygon[1] = new PointF(xPosDestination-MSCItem.ItemLayoutSize.Width/2-8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)+4);
					messagePolygon[2] = new PointF(xPosDestination-MSCItem.ItemLayoutSize.Width/2-8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);				
				}
				if (xPosDestination<xPosSource){
					itemBox = new RectangleF((xPosSource+xPosDestination+MSCItem.ItemLayoutSize.Width/2)/2-itemMessSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-itemMessSize.Height, itemMessSize.Width, itemMessSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox.Left, itemBox.Top, itemBox.Width, itemBox.Height);	
					drawDestination.DrawRectangle(mItemPen, xPosDestination - MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height,itemMessSize.Height-(itemNameSize.Height/2)), MSCItem.ItemLayoutSize.Width, itemNameSize.Height);	
					drawDestination.DrawString(mMessName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination+MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height));
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(xPosDestination+MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height));
					messagePolygon[1] = new PointF(xPosDestination+MSCItem.ItemLayoutSize.Width/2+8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)+4);
					messagePolygon[2] = new PointF(xPosDestination+MSCItem.ItemLayoutSize.Width/2+8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);				
				}
				msgY = itemBox.Y;
			}
			else if(mMscStyle == MscStyle.UML2){
				if (xPosDestination>xPosSource){
					itemBox = new RectangleF((xPosSource+xPosDestination-MSCItem.ItemLayoutSize.Width/2)/2-itemMessSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-itemMessSize.Height, itemMessSize.Width, itemMessSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox.Left, itemBox.Top, itemBox.Width, itemBox.Height);	
					drawDestination.DrawRectangle(mItemPen, xPosDestination - MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height,itemMessSize.Height-(itemNameSize.Height/2)), MSCItem.ItemLayoutSize.Width, itemNameSize.Height);	
					drawDestination.DrawString(mMessName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height));
					drawDestination.DrawLine(mItemPen,xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination-MSCItem.ItemLayoutSize.Width/2-8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)+4);
					drawDestination.DrawLine(mItemPen,xPosDestination-MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination-MSCItem.ItemLayoutSize.Width/2-8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-4);
				}
				if (xPosDestination<xPosSource){
					itemBox = new RectangleF((xPosSource+xPosDestination+MSCItem.ItemLayoutSize.Width/2)/2-itemMessSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-itemMessSize.Height, itemMessSize.Width, itemMessSize.Height);
					drawDestination.FillRectangle(mBackBrush, itemBox.Left, itemBox.Top, itemBox.Width, itemBox.Height);	
					drawDestination.DrawRectangle(mItemPen, xPosDestination - MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height,itemMessSize.Height-(itemNameSize.Height/2)), MSCItem.ItemLayoutSize.Width, itemNameSize.Height);	
					drawDestination.DrawString(mMessName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination+MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height));
					drawDestination.DrawLine(mItemPen,xPosDestination+MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination+MSCItem.ItemLayoutSize.Width/2+8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)+4);
					drawDestination.DrawLine(mItemPen,xPosDestination+MSCItem.ItemLayoutSize.Width/2, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height), xPosDestination+MSCItem.ItemLayoutSize.Width/2+8, yPos+Math.Max(itemDescriptionSize.Height+(itemNameSize.Height/2),itemMessSize.Height)-4);
				}				
				msgY = itemBox.Y;
			}
			if (xPosDestination>xPosSource){
				this.mBounds.X = xPosSource;
				this.mBounds.Width = (xPosDestination-xPosSource)+MSCItem.ItemLayoutSize.Width/2;
			}
			else{
				this.mBounds.X = xPosDestination - MSCItem.ItemLayoutSize.Width/2;
				this.mBounds.Width = (xPosDestination-xPosSource)+MSCItem.ItemLayoutSize.Width/2;				
			}
			this.mBounds.Y = Math.Min(msgY,descY);
			this.mBounds.Height = (procY+procHeight)-this.mBounds.Y;
			drawDestination.DrawLine(mItemPen, xPosDestination, yPos+Math.Max(itemDescriptionSize.Height+itemNameSize.Height,itemNameSize.Height/2+itemMessSize.Height),xPosDestination, yPos+lineHeight);
			itemStringFormat.Dispose();			
		}
	}
}
