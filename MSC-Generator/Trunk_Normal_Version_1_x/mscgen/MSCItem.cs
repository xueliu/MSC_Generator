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
 * Date: 19.05.2005
 * Time: 12:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
namespace mscElements
{
	public enum ItemStyle{
		Normal,
		ExtendedInner,
		ExtendedOuter
	}
	public enum ItemPos{
		Left,
		Right,
		Top,
		Bottom
	}
	// planed for future use
	public struct ItemDrawingAttributes{
		public Graphics 	DrawDestination;
		public float 		DiagramLeft;
		public float 		DiagramRight;
		public float 		DiagramBottom;
		public float 		LineStart;
		public float 		LineHeight;
		public uint 		Page;
		
		public ItemDrawingAttributes(Graphics drawDestination, float diagramLeft, float diagramRight, float diagramBottom, float lineStart, float lineHeight, uint page)
		{
			this.DrawDestination 	= drawDestination;
			this.DiagramLeft 		= diagramLeft;
			this.DiagramRight 		= diagramRight;
			this.DiagramBottom 		= diagramBottom;
			this.LineStart 			= lineStart;
			this.LineHeight 		= lineHeight;
			this.Page 				= page;
		}
	}

	
	/// <summary>
	/// Description of MSCItem.
	/// </summary>
	
	public partial class MSCItem : MSC
	{
		
		private static SizeF 			sItemLayoutSize;
		protected static Font 			mItemFont			= new Font("Arial",10,FontStyle.Regular,GraphicsUnit.Point);
		protected static Font 			sItemFont			= new Font("Arial",10,FontStyle.Regular,GraphicsUnit.Point);
		protected static Brush 			sActualFillBrush 	= Brushes.White;
		protected static Brush 			sActualBackBrush 	= Brushes.White;
		protected static Pen 			sActualPen 			= Pens.Black;
		protected static Brush 			sActualStringBrush 	= Brushes.Black;
		private static int 				sRefID				= 0;
		
		protected uint 			mItemPage 					= 0;		
		protected string 		mName;
		protected string 		mCommand;
		protected int 			mID;
		protected int 			mFirstInstance 				= 0;
		protected int 			mLastInstance				= 0;
		protected uint 			mFileLine;
		protected Pen 			mItemPen;
		protected Brush 		mFillBrush;
		protected Brush 		mBackBrush;
		protected Brush 		mItemStringBrush;
		protected byte 			mPlacement;
		protected RectangleF 	mBounds 					= new RectangleF(0,0,0,0);
		protected uint 			mLine						= 0;
		protected float			mHeight						= 0;
		protected const byte 	PLACEMENT_RIGHT				= 0x01;
		protected const byte 	PLACEMENT_LEFT				= 0x00;
		protected const byte 	PLACEMENT_TOP				= 0x00;
		protected const byte 	PLACEMENT_BOTTOM			= 0x02;
		protected const uint 	STOPXSIZE					= 6;
		
		public const float 		NEW_PAGE					= -1.0f;
		
		
		public MSCItem()
		{
			MSCItem.ItemLayoutSize 		= new SizeF(300.0F,400.0F);
			mItemFont 				= sItemFont;
			this.mItemStringBrush 	= sActualStringBrush;
			this.mBackBrush 		= sActualBackBrush;
			this.mItemPen 			= sActualPen;
			this.mFillBrush 		= sActualFillBrush;
			this.mID 				= sRefID++;
		}
			
		public static void Clear()
		{
			sActualStringBrush 		= Brushes.Black;
			sActualFillBrush 		= Brushes.White;
			sActualBackBrush	 	= Brushes.White;
			sActualPen 				= Pens.Black;
			sItemFont				= new Font("Arial",10,FontStyle.Regular,GraphicsUnit.Point);
			MSC.VerticalOffset 		= 20;
			sRefID					= 0;
		}
		
		protected byte CalcPlacement(string placement)
		{
			char[] pl = placement.ToCharArray();
			byte result=0;
			if (pl.Length<1) return 0;
			for(int i=0; i<pl.Length; i++){
				switch (pl[i]){
					case 'r':
						result |= PLACEMENT_RIGHT;
						break;
					case 'l':
						result &= 0xFF - PLACEMENT_RIGHT;
						break;
					case 't':
						result &= 0xFF - PLACEMENT_BOTTOM;
						break;
					case 'b':
						result |= PLACEMENT_BOTTOM;
						break;
						
				}
			}
			return result;
		}
		public int ItemID{
			get{
				return mID;
			}
			set{
				mID=value;
			}
		}
		public static SizeF ItemLayoutSize{
			get{
				return sItemLayoutSize;
			}
			set{
				sItemLayoutSize = value;
			}
		}
		public static Font ItemFont{
			get{
				return sItemFont;
			}
			set{
				sItemFont = value;
				mItemFont = sItemFont;
			}
		}
		public int FirstInstance{
			get{
				return mFirstInstance;
			}
			set{
				mFirstInstance = value;
			}
		}
		public int LastInstance{
			get{
				return mLastInstance;
			}
			set{
				mLastInstance=value;
			}
		}
		public uint Line{
			get{
				return mLine;
			}
			set{
				mLine=value;
			}
		}
		public static Brush ActualFillBrush{
			get{
				return sActualFillBrush;
			}
			set{
				sActualFillBrush=value;
			}
		}		
		public static Brush ActualBackBrush{
			get{
				return sActualBackBrush;
			}
			set{
				sActualBackBrush=value;
			}
		}		
		public static Brush ActualStringBrush{
			get{
				return sActualStringBrush;
			}
			set{
				sActualStringBrush=value;
			}
		}		
		public static Pen ActualPen{
			get{
				return sActualPen;
			}
			set{
				sActualPen=value;
			}
		}		
		public uint ItemPage{
			get{
				return mItemPage;
			}
			set{
				mItemPage=value;
			}
		}		
		public Pen ItemPen{
			get{
				return mItemPen;
			}
			set{
				mItemPen=value;
			}
		}		
		public byte Placement{
			get{
				return mPlacement;
			}
			set{
				mPlacement=value;
			}
		}		
		public string Name{
			get{
				return mName;
			}
			set{
				mName=value;
			}
		}		
		public RectangleF bounds{
			get{
				return mBounds;
			}
		}
		public uint FileLine{
			get{
				return mFileLine;
			}
		}
		public virtual bool IsOnPage(int page)
		{
			if (page==ItemPage) return true;
			else return false;
		}
		public virtual void DrawItem(ItemDrawingAttributes drawingAttibutes)
		{
			
		}
	}
}
