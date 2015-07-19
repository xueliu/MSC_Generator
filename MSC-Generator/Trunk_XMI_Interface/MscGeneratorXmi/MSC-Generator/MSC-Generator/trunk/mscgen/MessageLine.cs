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
 * Time: 12:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of Loopline.
	/// </summary>
	public class MessageLine : MSCItem
	{
		private uint 			mLineBeginn;
		private uint 			mLineEnd;
		private int 			mMessageSource;
		private int 			mMessageDestination;
		private MessageStyle 	mStyle;
		private string 			mIdentifier;
		
		public MessageLine(string identifier, uint line, int source, int destination)
		{
			this.mLineBeginn 			= line;
			this.mMessageSource 		= source;
			this.mMessageDestination 	= destination;
			this.mLineEnd 				= 0;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= MessageStyle.Normal;
			this.mIdentifier 			= identifier;
		}
		public MessageLine(string identifier, uint line, int source, int destination, MessageStyle style)
		{
			this.mLineBeginn 			= line;
			this.mMessageSource 		= source;
			this.mMessageDestination 	= destination;
			this.mLineEnd 				= 0;
			this.mItemPen 				= new Pen(Color.Black, 1);
			this.mStyle 				= style;
			this.mIdentifier 			= identifier;
		}
		
		public MessageStyle MessageStyle{
			get{
				return mStyle;
			}
			set{
				mStyle=value;
			}
		}
		public uint LineBeginn{
			get{
				return mLineBeginn;
			}
			set{
				mLineBeginn=value;
			}
		}
		public uint LineEnd{
			get{
				return mLineEnd;
			}
			set{
				mLineEnd=value;
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
		public string Identifier{
			get{
				return mIdentifier;
			}
			set{
				mIdentifier=value;
			}
		}
		
		public void DrawItem(Graphics drawDestination, float xPosSource, float xPosDestination, float yPosStart, float yPosEnd,float xLeftPos,float xRightPos)
		{
			float[] pattern = {6f,6f};
			float xPos=0;
			if (xPosSource == Generator.ENV_LEFT)
				xPosSource = xLeftPos;
			if (xPosSource == Generator.ENV_RIGHT)
				xPosSource = xRightPos;
			if (xPosDestination == Generator.ENV_LEFT)
				xPosDestination = xLeftPos;
			if (xPosDestination == Generator.ENV_RIGHT)
				xPosDestination = xRightPos;
			
			if (xPosDestination>=xPosSource)
				xPos=xPosDestination-((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
			if (xPosDestination<xPosSource)
				xPos=xPosDestination+((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
			if (this.mStyle==MessageStyle.Dashed){
				mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
				mItemPen.DashPattern = pattern;
			}
			drawDestination.DrawLine(mItemPen,xPos,yPosStart, xPos,yPosEnd);							
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}
		public void DrawItemCarry(Graphics drawDestination, float xPosSource, float xPosDestination, float yPosStart, float yPosEnd,float xLeftPos,float xRightPos)
		{
			float[] pattern = {1f,2f};
			float xPos=0;
			if (xPosSource == Generator.ENV_LEFT)
				xPosSource = xLeftPos;
			else if (xPosSource == Generator.ENV_RIGHT)
				xPosSource = xRightPos;
			if (xPosDestination == Generator.ENV_LEFT)
				xPosDestination = xLeftPos;
			else if (xPosDestination == Generator.ENV_RIGHT)
				xPosDestination = xRightPos;
			if (xPosDestination>=xPosSource)
				xPos=xPosDestination-((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
			else if (xPosDestination<xPosSource)
				xPos=xPosDestination+((Generator.LOOP_OFFSET+Generator.LOOP_OFFSET/2)+MSCItem.ItemLayoutSize.Width/2);
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			drawDestination.DrawLine(mItemPen,xPos,yPosStart, xPos,yPosEnd);							
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}		
	}
}
