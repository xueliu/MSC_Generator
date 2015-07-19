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
 * Date: 10.06.2005
 * Time: 13:19
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
	/// Description of Message.
	/// </summary>
	public class MessageEnd : MSCItem
	{
		private int 			mMessageSource;
		private int 			mMessageDestination;
		private uint 			mInitialHeight;
		private string 			mIdentifier;
		private MessageStyle 	mStyle;
		
		public MessageEnd(uint fileLine, string identifier, uint line, int messageSource, int messageDestination)
		{
			this.mLine 					= line;
			this.mMessageSource 		= messageSource;
			this.mMessageDestination 	= messageDestination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= MessageStyle.Normal;
			this.mIdentifier 			= identifier;
			mInitialHeight				= 1;
			this.mFileLine 				= fileLine;
			
		}
		public MessageEnd(uint fileLine, string identifier, uint line, int messageSource, int messageDestination, MessageStyle style)
		{
			this.mLine 					= line;
			this.mMessageSource 		= messageSource;
			this.mMessageDestination 	= messageDestination;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= style;
			this.mIdentifier 			= identifier;
			mInitialHeight				= 1;
			this.mFileLine 				= fileLine;
		}
		
		public string Identifier{
			get{
				return mIdentifier;
			}
			set{
				mIdentifier=value;
			}
		}
		public int MessageSource{
			get{
				return mMessageSource;
			}
			set{
				mMessageSource=value;
			}
		}
		
		public int MessageDestination{
			get{
				return mMessageDestination;
			}
			set{
				mMessageDestination=value;
			}
		}

		public float GetHeight(Graphics drawDestination)
		{
			return mInitialHeight;
		}
		
		public void DrawItem(Graphics drawDestination, float xPosSource, float xPosDestination, float yPos, float lineHeight,float xLeftPos,float xRightPos, ProcessStyle sourceStyle, ProcessStyle destinationStyle)
		{
			float[] pattern = {6f,6f};
			
			if (xPosSource == Generator.ENV_LEFT)
				xPosSource = xLeftPos;
			if (xPosSource == Generator.ENV_RIGHT)
				xPosSource = xRightPos;
			if (xPosDestination == Generator.ENV_LEFT)
				xPosDestination = xLeftPos;
			if (xPosDestination == Generator.ENV_RIGHT)
				xPosDestination = xRightPos;
			
			if (xPosDestination<xPosSource){
				xPosSource=xPosDestination+((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
				if ((destinationStyle == ProcessStyle.Activation)||(destinationStyle == ProcessStyle.Suspension))
					xPosDestination +=5;
			}
			if (xPosDestination>xPosSource){
				xPosSource=xPosDestination-((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
				if ((destinationStyle == ProcessStyle.Activation)||(destinationStyle == ProcessStyle.Suspension))
					xPosDestination -=5;
			}
			if (xPosDestination==xPosSource){
				xPosSource=xPosDestination-((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
				if ((destinationStyle == ProcessStyle.Activation)||(destinationStyle == ProcessStyle.Suspension))
					xPosDestination -=5;
			}
			if 	(this.mStyle==MessageStyle.Dashed){
				mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
				mItemPen.DashPattern = pattern;
			}
			if (mMscStyle == MscStyle.SDL){
				if (xPosDestination>=xPosSource){
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
					messagePolygon[1] = new PointF(xPosDestination-8, yPos+lineHeight-4);
					messagePolygon[2] = new PointF(xPosDestination-8, yPos+lineHeight+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					
				}
				if (xPosDestination<xPosSource){
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
					messagePolygon[1] = new PointF(xPosDestination+8, yPos+lineHeight-4);
					messagePolygon[2] = new PointF(xPosDestination+8, yPos+lineHeight+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
				}
				this.mBounds.X = Math.Min(xPosSource,xPosDestination);
				this.mBounds.Width = Math.Max(xPosSource, xPosDestination)-this.mBounds.X;
				this.mBounds.Y = yPos+lineHeight-4;
				this.mBounds.Height = 8;
			}
			else if(mMscStyle == MscStyle.UML2){
				if (xPosDestination>=xPosSource){
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					if ((mStyle == MessageStyle.Normal)||(mStyle == MessageStyle.Dashed)){
						drawDestination.DrawLine(mItemPen,xPosDestination, yPos+lineHeight, xPosDestination-8, yPos+lineHeight-4);
						drawDestination.DrawLine(mItemPen,xPosDestination, yPos+lineHeight, xPosDestination-8, yPos+lineHeight+4);					
					}
					else if (mStyle == MessageStyle.Synchron){
						PointF[] messagePolygon = new PointF[3];
						messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
						messagePolygon[1] = new PointF(xPosDestination-8, yPos+lineHeight-4);
						messagePolygon[2] = new PointF(xPosDestination-8, yPos+lineHeight+4);
						drawDestination.FillPolygon(Brushes.Black,messagePolygon);						
					}
				}
				if (xPosDestination<xPosSource){
					drawDestination.DrawLine(mItemPen,xPosSource, yPos+lineHeight, xPosDestination, yPos+lineHeight);
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					if ((mStyle == MessageStyle.Normal)||(mStyle == MessageStyle.Dashed)){
						drawDestination.DrawLine(mItemPen,xPosDestination, yPos+lineHeight, xPosDestination+8, yPos+lineHeight-4);
						drawDestination.DrawLine(mItemPen,xPosDestination, yPos+lineHeight, xPosDestination+8, yPos+lineHeight+4);					
					}
					else if (mStyle == MessageStyle.Synchron){
						PointF[] messagePolygon = new PointF[3];
						messagePolygon[0] = new PointF(xPosDestination, yPos+lineHeight);
						messagePolygon[1] = new PointF(xPosDestination+8, yPos+lineHeight-4);
						messagePolygon[2] = new PointF(xPosDestination+8, yPos+lineHeight+4);
						drawDestination.FillPolygon(Brushes.Black,messagePolygon);					
					}
				}
				this.mBounds.X = Math.Min(xPosSource,xPosDestination);
				this.mBounds.Width = Math.Max(xPosSource, xPosDestination)-this.mBounds.X;
				this.mBounds.Y = yPos+lineHeight-4;
				this.mBounds.Height = 8;
			}
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

		}
		
	}
}
