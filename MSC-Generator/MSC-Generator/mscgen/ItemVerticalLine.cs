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
 * Date: 23.05.2005
 * Time: 09:05
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
	
	public class ItemVerticalLine : MSCItem
	{
		private uint 		mLineBeginn;
		private uint 		mLineEnd;
		private int 		mProcess;
		private ItemPos 	mPos;
		private ItemStyle 	mItemStyle;
		private string 		mIdentifier;
		
		public ItemVerticalLine(uint line, int process, string identifier)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= ItemPos.Left;
			this.mItemStyle 		= ItemStyle.Normal;
			this.mIdentifier		= identifier;
		}
		public ItemVerticalLine(uint line, int process, string identifier, ItemPos placement)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mItemStyle 		= ItemStyle.Normal;
			this.mIdentifier		= identifier;
		}
		public ItemVerticalLine(uint line, int process, string identifier, ItemPos placement, ItemStyle itemstyle)
		{
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mPos 				= placement;
			this.mItemStyle 		= itemstyle;
			this.mIdentifier		= identifier;
		}
		public ItemPos ItemPlacement{
			get{
				return mPos;
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
		
		public int Process{
			get{
				return mProcess;
			}
			set{
				mProcess=value;
			}
		}
		public ItemStyle Itemstyle{
			get{
				return mItemStyle;
			}
		}
		
		public void DrawItem(Graphics drawDestination, float xPos, float yPosStart, float yPosEnd)
		{
			if (this.mItemStyle == ItemStyle.Normal){
				if (this.mPos==ItemPos.Right){
					xPos += 25;
				}
				else if (this.mPos==ItemPos.Left){
					xPos -= 25;
				}
			}
			else if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
				if (this.mPos==ItemPos.Right){
					xPos += MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				}
				else if (this.mPos==ItemPos.Left){
					xPos -= MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				}						
			}
			drawDestination.DrawLine(mItemPen,xPos,yPosStart,xPos,yPosEnd);		
		}
		public void DrawItemCarry(Graphics drawDestination, float xPos, float yPosStart, float yPosEnd)
		{
			float[] pattern = {1f,2f};
			if (this.mItemStyle == ItemStyle.Normal){
				if (this.mPos==ItemPos.Right){
					xPos += 25;
				}
				else if (this.mPos==ItemPos.Left){
					xPos -= 25;
				}
			}
			else if ((this.mItemStyle == ItemStyle.ExtendedInner)||(this.mItemStyle == ItemStyle.ExtendedOuter)){
				if (this.mPos==ItemPos.Right){
					xPos += MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				}
				else if (this.mPos==ItemPos.Left){
					xPos -= MSCItem.ItemLayoutSize.Width/2+Generator.LOOP_OFFSET;
				}						
			}				
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			mItemPen.DashPattern = pattern;
			drawDestination.DrawLine(mItemPen,xPos,yPosStart, xPos,yPosEnd);							
			mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		}		
	}
}
