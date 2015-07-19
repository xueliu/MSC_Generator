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
 * Date: 20.12.2005
 * Time: 13:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;
namespace mscElements
{
	
	public enum CommentPos{
		Left,
		Right, 
		OverAll
	}
	
	/// <summary>
	/// Description of State.
	/// </summary>
	/// 
	public partial class Comment : MSCItem
	{
		private CommentPos 		pos;
		private int 			mCommentInstance;
		
		public Comment(uint fileLine, uint line, int instance, string name)
		{
			this.mName 					= name;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mLine 					= line;
			if (instance == Generator.ENV_RIGHT)
				this.pos 				= CommentPos.Right;
			else
				this.pos 				= CommentPos.Left;
			this.mFileLine 				= fileLine;
			this.mCommentInstance 		= instance;
		}
		public Comment(uint fileLine, uint line, int instance, string name, CommentPos pos)
		{
			this.mName 					= name;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mLine 					= line;
			this.mFileLine 				= fileLine;
			if (instance == Generator.ENV_LEFT)
				this.pos 				= CommentPos.Left;
			else if (instance == Generator.ENV_RIGHT)
				this.pos 				= CommentPos.Right;
			else
				this.pos 				= pos;
			this.mCommentInstance = instance;
		}
		public int Process{
			get{
				return mCommentInstance;
			}
			set{
				mCommentInstance=value;
			}
		}
		public CommentPos Position{
			get{
				return this.pos;
			}
		}

		public float GetHeight(Graphics drawDestination, float xPos, float xPosLeft, float xPosRight, float xLeftSpace,float xRightSpace)
		{
			SizeF itemNameSize, itemTextSize;
			float height = 0.0f;
			StringFormat itemStringFormat = new StringFormat();
			if (xPos == Generator.ENV_LEFT){
				xPosLeft += Generator.LOOP_OFFSET;
				if (xLeftSpace < (MSCItem.ItemLayoutSize.Width/2) * 0.8)
					xLeftSpace += MSCItem.ItemLayoutSize.Width/2;
				xLeftSpace = xLeftSpace - Generator.LOOP_OFFSET;
				itemTextSize=new SizeF(xLeftSpace, MSCItem.ItemLayoutSize.Height-10);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				height = itemNameSize.Height;
			}
			else if (xPos == Generator.ENV_RIGHT){
				xPosRight -= Generator.LOOP_OFFSET;
				if (xRightSpace < (MSCItem.ItemLayoutSize.Width/2) * 0.8)
					xRightSpace += MSCItem.ItemLayoutSize.Width/2;
				xRightSpace = xRightSpace - Generator.LOOP_OFFSET;
				xPosLeft = xPosRight - xRightSpace;
				itemTextSize=new SizeF(xRightSpace, MSCItem.ItemLayoutSize.Height-10);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				height = itemNameSize.Height;
			}
			else if (this.pos == CommentPos.OverAll){
				itemTextSize=new SizeF((xPosRight - xPosLeft) + MSCItem.ItemLayoutSize.Width, MSCItem.ItemLayoutSize.Height-10);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				height = itemNameSize.Height;				
			}
			else{
				if (this.pos == CommentPos.Left)
					itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-5+xLeftSpace, MSCItem.ItemLayoutSize.Height-10);
				else
					itemTextSize=new SizeF(MSCItem.ItemLayoutSize.Width/2-5+xRightSpace, MSCItem.ItemLayoutSize.Height-10);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				height = itemNameSize.Height;
			}
			itemStringFormat.Dispose();
			return height+15;
		}
		
		public void DrawItem(Graphics drawDestination, float xPos, float xPosLeft, float xPosRight, float yPos, float xLeftSpace,float xRightSpace)
		{
			RectangleF itemBox;
			SizeF itemNameSize, itemTextSize;
			StringFormat itemStringFormat = new StringFormat();
			
			itemStringFormat.Alignment = StringAlignment.Near;
			PointF[] statePolygon = new PointF[5];
			if (xPos == Generator.ENV_LEFT){
				xPosLeft += Generator.LOOP_OFFSET;
				if (xLeftSpace < (MSCItem.ItemLayoutSize.Width/2) * 0.8)
					xLeftSpace += MSCItem.ItemLayoutSize.Width/2;
				xLeftSpace = xLeftSpace - Generator.LOOP_OFFSET;
				itemTextSize=new SizeF(xLeftSpace, MSCItem.ItemLayoutSize.Height-10);
				xLeftSpace = Math.Max(itemTextSize.Width, (MSCItem.ItemLayoutSize.Width/2)* 0.8f);
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				
				itemBox = new RectangleF(xPosLeft, yPos+15, itemNameSize.Width, itemNameSize.Height);
				statePolygon[0] = new PointF(xPosLeft,yPos+10);
				statePolygon[1] = new PointF(xPosLeft+10,yPos);
				statePolygon[2] = new PointF(xPosLeft+xLeftSpace,yPos);
				statePolygon[3] = new PointF(xPosLeft+xLeftSpace,yPos+itemNameSize.Height+15);
				statePolygon[4] = new PointF(xPosLeft,yPos+itemNameSize.Height+15);
				drawDestination.FillPolygon(mFillBrush,statePolygon);
				
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				drawDestination.DrawPolygon(mItemPen,statePolygon);
				drawDestination.DrawLine(mItemPen,xPosLeft,yPos+10,xPosLeft+10,yPos+10);
				drawDestination.DrawLine(mItemPen,xPosLeft+10,yPos+10,xPosLeft+10,yPos);
				this.mBounds = new RectangleF(xPosLeft,yPos,xLeftSpace, itemNameSize.Height+15);
			}
			else if (xPos == Generator.ENV_RIGHT){
				xPosRight -= Generator.LOOP_OFFSET;
				if (xRightSpace < (MSCItem.ItemLayoutSize.Width/2) * 0.8)
					xRightSpace += MSCItem.ItemLayoutSize.Width/2;
				xRightSpace = xRightSpace - Generator.LOOP_OFFSET;
				itemTextSize=new SizeF(xRightSpace, MSCItem.ItemLayoutSize.Height-10);
				xRightSpace = Math.Max(itemTextSize.Width, (MSCItem.ItemLayoutSize.Width/2)* 0.8f);
				xPosLeft = xPosRight - xRightSpace;
				itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
				
				itemBox = new RectangleF(xPosLeft, yPos+15, itemNameSize.Width, itemNameSize.Height);
				statePolygon[0] = new PointF(xPosLeft,yPos+10);
				statePolygon[1] = new PointF(xPosLeft+10,yPos);
				statePolygon[2] = new PointF(xPosLeft+xRightSpace,yPos);
				statePolygon[3] = new PointF(xPosLeft+xRightSpace,yPos+itemNameSize.Height+15);
				statePolygon[4] = new PointF(xPosLeft,yPos+itemNameSize.Height+15);
				drawDestination.FillPolygon(mFillBrush,statePolygon);
				
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
				drawDestination.DrawPolygon(mItemPen,statePolygon);
				drawDestination.DrawLine(mItemPen,xPosLeft,yPos+10,xPosLeft+10,yPos+10);
				drawDestination.DrawLine(mItemPen,xPosLeft+10,yPos+10,xPosLeft+10,yPos);
				this.mBounds = new RectangleF(xPosLeft,yPos,xRightSpace, itemNameSize.Height+15);
			}
			else{
				if (this.pos == CommentPos.Left){
					xPosLeft = xPos - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET - xLeftSpace;
					xLeftSpace = MSCItem.ItemLayoutSize.Width/2+xLeftSpace;
					itemTextSize=new SizeF(xLeftSpace, MSCItem.ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemBox = new RectangleF(xPosLeft, yPos+15, itemNameSize.Width, itemNameSize.Height);
					statePolygon[0] = new PointF(xPosLeft,yPos+10);
					statePolygon[1] = new PointF(xPosLeft+10,yPos);
					statePolygon[2] = new PointF(xPosLeft+xLeftSpace,yPos);
					statePolygon[3] = new PointF(xPosLeft+xLeftSpace,yPos+itemNameSize.Height+15);
					statePolygon[4] = new PointF(xPosLeft,yPos+itemNameSize.Height+15);
					drawDestination.FillPolygon(mFillBrush,statePolygon);
					
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawPolygon(mItemPen,statePolygon);
					drawDestination.DrawLine(mItemPen,xPosLeft,yPos+10,xPosLeft+10,yPos+10);
					drawDestination.DrawLine(mItemPen,xPosLeft+10,yPos+10,xPosLeft+10,yPos);
					this.mBounds = new RectangleF(xPosLeft,yPos,xLeftSpace, itemNameSize.Height+15);
				}
				else if (this.pos == CommentPos.Right){
					xPosLeft = xPos + Generator.LOOP_OFFSET;
					xLeftSpace = ItemLayoutSize.Width/2+xRightSpace;
					itemTextSize=new SizeF(xLeftSpace, ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemBox = new RectangleF(xPosLeft, yPos+15, itemNameSize.Width, itemNameSize.Height);
					statePolygon[0] = new PointF(xPosLeft,yPos+10);
					statePolygon[1] = new PointF(xPosLeft+10,yPos);
					statePolygon[2] = new PointF(xPosLeft+xLeftSpace,yPos);
					statePolygon[3] = new PointF(xPosLeft+xLeftSpace,yPos+itemNameSize.Height+15);
					statePolygon[4] = new PointF(xPosLeft,yPos+itemNameSize.Height+15);
					drawDestination.FillPolygon(mFillBrush,statePolygon);
					
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawPolygon(mItemPen,statePolygon);
					drawDestination.DrawLine(mItemPen,xPosLeft,yPos+10,xPosLeft+10,yPos+10);
					drawDestination.DrawLine(mItemPen,xPosLeft+10,yPos+10,xPosLeft+10,yPos);
					this.mBounds = new RectangleF(xPosLeft,yPos,xLeftSpace, itemNameSize.Height+15);
				}
				else if (this.pos == CommentPos.OverAll){
//					xPosLeft = xPos + Generator.LOOP_OFFSET;
					xLeftSpace = (xPosRight - xPosLeft) + ItemLayoutSize.Width;
					itemTextSize=new SizeF(xLeftSpace, ItemLayoutSize.Height-10);
					itemNameSize = drawDestination.MeasureString(mName, mItemFont, itemTextSize, itemStringFormat);
					itemStringFormat.Alignment = StringAlignment.Center;
					itemBox = new RectangleF(xPosLeft - ItemLayoutSize.Width/2, yPos+15, xLeftSpace, itemNameSize.Height);
					statePolygon[0] = new PointF(xPosLeft- ItemLayoutSize.Width/2,yPos+10);
					statePolygon[1] = new PointF(xPosLeft- ItemLayoutSize.Width/2+10,yPos);
					statePolygon[2] = new PointF(xPosLeft- ItemLayoutSize.Width/2+xLeftSpace,yPos);
					statePolygon[3] = new PointF(xPosLeft- ItemLayoutSize.Width/2+xLeftSpace,yPos+itemNameSize.Height+15);
					statePolygon[4] = new PointF(xPosLeft- ItemLayoutSize.Width/2,yPos+itemNameSize.Height+15);
					drawDestination.FillPolygon(mFillBrush,statePolygon);
					
					drawDestination.DrawString(mName,mItemFont,mItemStringBrush,itemBox,itemStringFormat);
					drawDestination.DrawPolygon(mItemPen,statePolygon);
					drawDestination.DrawLine(mItemPen,xPosLeft - ItemLayoutSize.Width/2,yPos+10,xPosLeft - ItemLayoutSize.Width/2+10,yPos+10);
					drawDestination.DrawLine(mItemPen,xPosLeft - ItemLayoutSize.Width/2+10,yPos+10,xPosLeft - ItemLayoutSize.Width/2 +10,yPos);
					this.mBounds = new RectangleF(xPosLeft- ItemLayoutSize.Width/2 ,yPos,xLeftSpace, itemNameSize.Height+15);					
				}
			}
			itemStringFormat.Dispose();
		}
	}
}
