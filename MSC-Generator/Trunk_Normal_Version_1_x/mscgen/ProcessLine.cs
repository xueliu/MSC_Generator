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
 * Time: 13:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;

namespace mscElements
{
	/// <summary>
	/// Description of ProcessLine.
	/// </summary>
	/// 
	public enum ProcessStyle{
		NotUsed,
		Normal,
		Activation,
		Suspension,
		Coregion
	}
	public enum ProcessType{
		Normal,
		Actor,
		Dummy
	}
	
	public partial class ProcessLine : MSCItem
	{
		private uint 			mLineBeginn;
		private uint 			mLineEnd;
		private string 			mDescription;
		private int 			mProcess;
		private float 			mInitialHeight 		= 20;
		private uint 			mFirstPage 			= 0, 
								mLastPage 			= 0;
		private ProcessCreate 	mCreatingProcess 	= null;
		private ProcessStyle 	mStyle;
		private ProcessType 	mType;
		private uint 			mLeft 				= 0;
		private uint 			mRight 				= 0;
		private ProcessLine		mOldLine			=null;
		
		public ProcessLine(uint fileLine, uint line, int process, ProcessType type, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= "";
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription		= "";
			this.mStyle 			= ProcessStyle.Normal;
			this.mType 				= type;
			if(type==ProcessType.Actor) 
				mInitialHeight 		= 50;
			if(type==ProcessType.Dummy)
				this.mStyle			= ProcessStyle.NotUsed;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, uint line, int process, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription		= "";
			this.mStyle 			= ProcessStyle.Normal;
			this.mType 				= ProcessType.Normal;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, string description, uint line, int process, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= description;
			this.mStyle 			= ProcessStyle.Normal;
			this.mType 				= ProcessType.Normal;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, uint line, int process, ProcessStyle style, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= "";
			this.mStyle 			= style;
			this.mType 				= ProcessType.Normal;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, string description, uint line, int process, ProcessStyle style, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= description;
			this.mStyle 			= style;
			this.mType 				= ProcessType.Normal;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, uint line, int process, ProcessType type, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= "";
			this.mStyle 			= ProcessStyle.Normal;
			this.mType 				= type;
			if(type==ProcessType.Actor) 
				mInitialHeight 		= 50;
			if(type==ProcessType.Dummy)
				this.mStyle			= ProcessStyle.NotUsed;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, string description, uint line, int process, ProcessType type, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn	 	= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= description;
			this.mStyle 			= ProcessStyle.Normal;
			this.mType 				= type;
			if(type==ProcessType.Actor) 
				mInitialHeight 		= 50;
			if(type==ProcessType.Dummy)
				this.mStyle			= ProcessStyle.NotUsed;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, uint line, int process, ProcessStyle style, ProcessType type, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= "";
			this.mStyle 			= style;
			this.mType 				= type;
			if(type==ProcessType.Actor) 
				mInitialHeight 		= 50;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		public ProcessLine(uint fileLine, string name, string description, uint line, int process, ProcessStyle style, ProcessType type, ProcessCreate p, uint left, uint right, ProcessLine oldLine)
		{
			this.mName 				= name;
			this.mLineBeginn 		= line;
			this.mProcess 			= process;
			this.mLineEnd 			= 0;
			this.mItemPen 			= new Pen(Color.Black, 1);
			this.mDescription 		= description;
			this.mStyle 			= style;
			this.mType 				= type;
			if(type==ProcessType.Actor) 
				mInitialHeight 		= 50;
			this.mFileLine 			= fileLine;
			this.mCreatingProcess 	= p;
			this.mLeft 				= left;
			this.mRight 			= right;
			this.mOldLine			= oldLine;
		}
		
		public ProcessLine OldLine{
			get{
				return mOldLine;
			}
			set{
				mOldLine = value;
			}
		}
		public ProcessCreate CreatingProcess{
			get{
				return mCreatingProcess;
			}
			set{
				mCreatingProcess = value;
			}
		}
		public uint FirstPage{
			get{
				return mFirstPage;
			}
			set{
				mFirstPage=value;
			}
		}
		public uint LastPage{
			get{
				return mLastPage;
			}
			set{
				mLastPage=value;
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
		
		public string Description{
			get{
				return mDescription;
			}
		}
		public int ProcessIndex{
			get{
				return mProcess;
			}
			set{
				mProcess=value;
			}
		}
		public ProcessStyle ProcessStyle{
			get{
				return mStyle;
			}
			set{
				mStyle=value;
			}
		}
		public ProcessType ProcessType{
			get{
				return mType;
			}
			set{
				mType=value;
			}
		}
		public override bool IsOnPage(int page)
		{
			if ((this.FirstPage<=page)&&(this.LastPage>=page)) return true;
			else return false;
		}

		public float GetDescriptionHeight(Graphics drawDestination)
		{
			SizeF itemNameSize;
			StringFormat itemStringFormat = new StringFormat();
			itemNameSize = drawDestination.MeasureString(mDescription, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemStringFormat.Dispose();
			return itemNameSize.Height;			
		}
		public float GetNameHeight(Graphics drawDestination)
		{
			SizeF itemNameSize;
			StringFormat itemStringFormat = new StringFormat();
			itemNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
			itemStringFormat.Dispose();
			if (this.mType==ProcessType.Actor){
				return itemNameSize.Height+mInitialHeight;
			}
			else{
				return Math.Max(itemNameSize.Height,mInitialHeight);
			}
		}
		

		public void DrawItem(Graphics drawDestination, float xPos, float yPosStart, float yPosEnd)
		{
			float[] pattern = new float[2]{8f,8f};
			float[] patternUML = new float[2]{5f,5f};
			if (this.mType == ProcessType.Dummy) return;
			switch(this.mStyle){
				case ProcessStyle.Normal:
					if (mMscStyle == MscStyle.SDL){
						drawDestination.DrawLine(mItemPen,xPos,yPosStart, xPos,yPosEnd);
					}
					else if (mMscStyle == MscStyle.UML2){
						mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
						mItemPen.DashPattern = patternUML;
						drawDestination.DrawLine(mItemPen,xPos,yPosStart, xPos,yPosEnd);
						mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					}
					break;
				case ProcessStyle.Activation:
					drawDestination.FillRectangle(Brushes.LightGray,xPos-5, yPosStart, 10, yPosEnd-yPosStart);
					drawDestination.DrawLine(mItemPen,xPos+5,yPosStart, xPos+5,yPosEnd);
					drawDestination.DrawLine(mItemPen,xPos-5,yPosStart, xPos-5,yPosEnd);
					break;
				case ProcessStyle.Suspension:
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					mItemPen.DashPattern = pattern;
					drawDestination.DrawLine(mItemPen,xPos+5,yPosStart, xPos+5,yPosEnd);
					drawDestination.DrawLine(mItemPen,xPos-5,yPosStart, xPos-5,yPosEnd);
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					break;
				case ProcessStyle.Coregion:
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					mItemPen.DashPattern = pattern;
					drawDestination.DrawLine(mItemPen,xPos,yPosStart, xPos,yPosEnd);
					mItemPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					break;
			}
		}
		
		public void DrawProcessHead(Graphics drawDestination, float xPos, float yPosName,float processNameHeight,float instanceNameHeight, float ySize, uint page){
			if (mFirstPage==0) 
				mFirstPage = page;
			else
				mFirstPage = Math.Min(mFirstPage,page);
			mLastPage = Math.Max(mLastPage,page);
			
			RectangleF processBox, textBox;
			SizeF processNameSize, processDescriptionSize;
			StringFormat itemStringFormat = new StringFormat();				
			if (this.mType==ProcessType.Actor){
				processNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
				processDescriptionSize = drawDestination.MeasureString(mDescription, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);			
				itemStringFormat.Alignment = StringAlignment.Center;
				drawDestination.FillRectangle(mFillBrush,xPos-12, yPosName, 24, 47);
				drawDestination.DrawEllipse(mItemPen,xPos-8,yPosName,16,16);
				drawDestination.DrawLine(mItemPen,xPos,yPosName+16,xPos, yPosName+32);
				drawDestination.DrawLine(mItemPen,xPos-12,yPosName+20, xPos+12, yPosName+20);
				drawDestination.DrawLine(mItemPen,xPos,yPosName+32, xPos-12, yPosName+47);
				drawDestination.DrawLine(mItemPen,xPos,yPosName+32, xPos+12, yPosName+47);
				processBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName+mInitialHeight, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processNameSize.Height);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,processBox,itemStringFormat);	
				processBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName-processDescriptionSize.Height, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processDescriptionSize.Height);
				drawDestination.DrawString(mDescription,mItemFont,mItemStringBrush,processBox,itemStringFormat);	
				this.DrawItem(drawDestination,xPos,yPosName+instanceNameHeight,ySize);	
				this.mBounds.X = processBox.X;
				this.mBounds.Width = MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET;
				this.mBounds.Y = processBox.Y;
				this.mBounds.Height = processDescriptionSize.Height + instanceNameHeight;
				
			}
			else if (this.mType==ProcessType.Normal){
				processNameSize = drawDestination.MeasureString(mName, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);
				processNameSize.Height=Math.Max(processNameSize.Height,mInitialHeight);
				processDescriptionSize = drawDestination.MeasureString(mDescription, mItemFont, MSCItem.ItemLayoutSize, itemStringFormat);			
				itemStringFormat.Alignment = StringAlignment.Center;
				itemStringFormat.LineAlignment = StringAlignment.Center;
				processBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName+instanceNameHeight-processNameHeight, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processNameHeight);
				textBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2, yPosName+instanceNameHeight-processNameHeight, MSCItem.ItemLayoutSize.Width, processNameHeight);
				drawDestination.FillRectangle(mFillBrush,xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName+instanceNameHeight-processNameHeight, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processNameHeight);
				drawDestination.DrawRectangle(mItemPen,xPos - MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName+instanceNameHeight-processNameHeight, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processNameHeight);
				drawDestination.DrawString(mName,mItemFont,mItemStringBrush,textBox,itemStringFormat);	
				processBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName+instanceNameHeight-processNameHeight-processDescriptionSize.Height, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processDescriptionSize.Height);
				drawDestination.DrawString(mDescription,mItemFont,mItemStringBrush,processBox,itemStringFormat);	
				this.DrawItem(drawDestination,xPos,yPosName+instanceNameHeight,ySize);
				this.mBounds.X = processBox.X;
				this.mBounds.Y = processBox.Y;
				this.mBounds.Width = MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET;
				this.mBounds.Height = processBox.Height + processNameHeight;
			}
			else{
				processBox = new RectangleF(xPos-MSCItem.ItemLayoutSize.Width/2-Generator.LOOP_OFFSET/2, yPosName+instanceNameHeight-processNameHeight, MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET, processNameHeight);
				this.mBounds.X = processBox.X;
				this.mBounds.Y = processBox.Y;
				this.mBounds.Width = MSCItem.ItemLayoutSize.Width+Generator.LOOP_OFFSET;
				this.mBounds.Height = processNameHeight;
			}
			itemStringFormat.Dispose();	
		}
	}
}
