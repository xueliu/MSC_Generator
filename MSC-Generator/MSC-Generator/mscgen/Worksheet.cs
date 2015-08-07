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
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Diagnostics;
namespace GeneratorGUI
{
	public struct sWorksheetValues{
		public bool EnableFootLine;
		public byte Size;
		public byte Layout;
		public byte Unit;
		public int Width;
		public int Height;
		public int LeftMargin;
		public int RightMargin;
		public int TopMargin;
		public int BottomMargin;
		public float Dpi;
		
		public sWorksheetValues(bool enableFootLine, byte size, byte layout, byte unit, int width, int Height, int LeftMargin, int RightMargin, int TopMargin, int BottomMargin, float dpi)
		{
			this.EnableFootLine = enableFootLine;
			this.Size = size;
			this.Layout = layout;
			this.Unit = unit;
			this.Width = width;
			this.Height = Height;
			this.LeftMargin = LeftMargin;
			this.RightMargin = RightMargin;
			this.TopMargin = TopMargin;
			this.BottomMargin = BottomMargin;
			this.Dpi = dpi;
		}
	}
	/// <summary>
	/// Description of Worksheet.
	/// </summary>
	public class Worksheet
	{
        public static bool doNotCutWorksheet = false;

		private int mWidth, mHeight;
		private byte mSize, mLayout;
		private int mLeftMargin, mRightMargin, mTopMargin, mBottomMargin, mFootMargin;
		private byte mUnit;
		private float mDpi;
		
		private static FootLine footLine = new FootLine();
		private bool mPrintFootLine = true;
		
		private Image image = new Bitmap(100,100);		// needed to create graphics
		private Graphics graphics; // needed to define the Height of footline

		private string[] mUnits = new string[4] {"cm","mm","Zoll","Pixel"};
		private string[] mSizes = new string[7] {"Benutzerdefiniert","A0-ISO","A1-ISO","A2-ISO","A3-ISO","A4-ISO","A5-ISO"};
		
		public const byte WS_SIZE_USER_DEFINED 		= 0;
		public const byte WS_SIZE_A0_ISO			= 1;
		public const byte WS_SIZE_A1_ISO			= 2;
		public const byte WS_SIZE_A2_ISO			= 3;
		public const byte WS_SIZE_A3_ISO			= 4;
		public const byte WS_SIZE_A4_ISO			= 5;
		public const byte WS_SIZE_A5_ISO			= 6;
		
		public const byte WS_LAYOUT_VERTICAL		= 0;
		public const byte WS_LAYOUT_HORIZONTAL		= 1;
		
		public const byte WS_UNIT_CM				= 0;
		public const byte WS_UNIT_MM				= 1;
		public const byte WS_UNIT_INCH				= 2;
		public const byte WS_UNIT_PICSEL			= 3;
		
		public const float WS_INCH_CM				= 2.54F;
		
		public const float WS_SIZE_A5_Y				= 21.0F;
		public const float WS_SIZE_A5_X				= 14.85F;

		public const float WS_SIZE_A4_Y				= 29.7F;
		public const float WS_SIZE_A4_X				= 21.0F;
			
		public const float WS_SIZE_A3_Y				= 42.0F;
		public const float WS_SIZE_A3_X				= 29.7F;

		public const float WS_SIZE_A2_Y				= 59.4F;
		public const float WS_SIZE_A2_X				= 42.0F;

		public const float WS_SIZE_A1_Y				= 84.0F;
		public const float WS_SIZE_A1_X				= 59.4F;

		public const float WS_SIZE_A0_Y				= 118.8F;
		public const float WS_SIZE_A0_X				= 84.0F;
		
		public const int MAX_WIDTH = 5000;
		public const int MAX_HEIGHT = 5000;
		public const int MIN_WIDTH = 300;
		public const int MIN_HEIGHT = 300;	
		public const int MAX_MARGIN = 30;		//%
		public const int MIN_MARGIN = 0;		//%

        private static bool disableSizeCheck = false;

        private RectangleF mFootlineItemBox = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
        
        public static bool DisableSizeCheck
        {
            set
            {
                disableSizeCheck = value;
            }
            get
            {
                return disableSizeCheck;
            }
        }

		public static string Author{
			set{
				footLine.Author = value;
			}
			get{
				return footLine.Author;
			}
		}
		public static string Company{
			set{
				footLine.Company = value;
			}
			get{
				return footLine.Company;
			}
		}
		public static string Version{
			set{
				footLine.Version = value;
			}
			get{
				return footLine.Version;
			}
		}
		public static string Date{
			set{
				footLine.Date = value;
			}
			get{
				return footLine.Date;
			}
		}
		public static string FileName{
			set{
				footLine.FileName = value;
			}
			get{
				return footLine.FileName;
			}
		}
		public static bool DrawAuthor{
			set{
				footLine.DrawAuthor = value;
			}
			get{
				return footLine.DrawAuthor;
			}
		}
		public static bool DrawCompany{
			set{
				footLine.DrawCompany = value;
			}
			get{
				return footLine.DrawCompany;
			}
		}
		public static bool DrawVersion{
			set{
				footLine.DrawVersion = value;
			}
			get{
				return footLine.DrawVersion;
			}
		}
		public static bool DrawDate{
			set{
				footLine.DrawDate = value;
			}
			get{
				return footLine.DrawDate;
			}
		}		
		public static bool DrawPrintDate{
			set{
				footLine.DrawPrintDate = value;
			}
			get{
				return footLine.DrawPrintDate;
			}
		}		
		public static bool DrawFileName{
			set{
				footLine.DrawFileName = value;
			}
			get{
				return footLine.DrawFileName;
			}
		}		
		public static bool DrawFootLine{
			set{
				footLine.DrawFootLine = value;
			}
			get{
				return footLine.DrawFootLine;
			}
		}
		public bool EnableFootLine{
			set{
				mPrintFootLine = value;
			}
			get{
				return mPrintFootLine;
			}
		}
//public sWorksheetValues(bool enableFootLine, byte size, byte layout, byte unit, int width, int Height, int LeftMargin, int RightMargin, int TopMargin, int BottomMargin)
		
		public sWorksheetValues WorksheetValues{
			set{
				this.EnableFootLine = value.EnableFootLine;
				this.mWidth = value.Width;
				this.mHeight = value.Height;
				this.mSize = value.Size;
				this.mLayout = value.Layout;
				this.mUnit = value.Unit;
				this.mLeftMargin = value.LeftMargin;
				this.mRightMargin = value.RightMargin;
				this.mTopMargin = value.TopMargin;
				this.mBottomMargin = value.BottomMargin;
				this.mDpi = value.Dpi;
			}
			get{
				return new sWorksheetValues(this.EnableFootLine, this.mSize, this.mLayout, this.mUnit, this.mWidth, this.mHeight,this.mLeftMargin, this.mRightMargin, this.mTopMargin, this.mBottomMargin, this.mDpi);
			}
		}
		
		public Worksheet()
		{
			mSize = WS_SIZE_A4_ISO;
			mLayout = WS_LAYOUT_HORIZONTAL;
			mUnit = WS_UNIT_PICSEL;
			mWidth = 1123; mHeight = 794;			//A4
			mLeftMargin = 10; mRightMargin = 10; mTopMargin = 10; mBottomMargin = 10;
			graphics = Graphics.FromImage(image);		
		}
		~Worksheet()
		{
			graphics.Dispose();
			System.GC.Collect();
		}
		public int GetWorksheetWidth()
		{
            if (doNotCutWorksheet)
                return mWidth;
            return Math.Max((mWidth - mLeftMargin) - mRightMargin,100);
		}
		public int GetWorksheetHeight()
		{
            if(doNotCutWorksheet)
                return mHeight;
			float Height = ((mHeight - mTopMargin) - mBottomMargin);
			if (this.mPrintFootLine==true)
				Height -= footLine.getHeight(graphics, (mWidth - mLeftMargin) - mRightMargin);
			return Math.Max((int)Height,100);
		}
		public byte Size
		{
			get{
				return mSize;
			}
			set{
				mSize = value;
			}
		}
		public byte Layout{
			get{
				return mLayout;
			}
			set{
				mLayout = value;
			}
		}
		public byte Unit{
			get{
				return mUnit;
			}
			set{
				mUnit = value;
			}
		}
		public int LeftMargin{
			get{
				return mLeftMargin;
			}
			set{
				mLeftMargin = value;
			}
		}
		public int RightMargin{
			get{
				return mRightMargin;
			}
			set{
				mRightMargin = value;
			}
		}
		public int TopMargin{
			get{
				return mTopMargin;
			}
			set{
				mTopMargin = value;
			}
		}
		public int BottomMargin{
			get{
				return mBottomMargin;
			}
			set{
				mBottomMargin = value;
			}
		}
		public int FootMargin{
			get{
				return mFootMargin;
			}
			set{
				mFootMargin = value;
			}
		}
		public int Width{
			get{
				return mWidth;
			}
			set{
				mWidth = value;
			}
		}
		public int Height{
			get{
				return mHeight;
			}
			set{
				mHeight = value;
			}
		}
		public float Dpi{
			get{
				return mDpi;
			}
			set{
				mDpi = value;
			}
		}
		//drawItem(Graphics drawDestination, float xPos, float yPos, float width)
		public static void InitFootLine()
		{
			footLine.Initialize();
			
		}
		public bool CheckSizes()
		{
            if (disableSizeCheck)
            {
                int temp = 0;
                bool result = true;
                //Height
                temp = this.Height;
                this.Height = (int)Math.Max(this.Height, MIN_HEIGHT);
                this.Height = (int)Math.Min(this.Height, MAX_HEIGHT);
                if (temp != this.Height) result = false;

                //Width
                temp = this.Width;
                this.Width = (int)Math.Max(this.Width, MIN_WIDTH);
                this.Width = (int)Math.Min(this.Width, MAX_WIDTH);
                if (temp != this.Width) result = false;

                //Left Margin
                temp = this.LeftMargin;
                this.LeftMargin = (int)Math.Max(this.LeftMargin, (float)MIN_MARGIN / 100 * (float)this.Width);
                this.LeftMargin = (int)Math.Min(this.LeftMargin, (float)MAX_MARGIN / 100 * (float)this.Width);
                if (temp != this.LeftMargin) result = false;

                //Right Margin
                temp = this.RightMargin;
                this.RightMargin = (int)Math.Max(this.RightMargin, (float)MIN_MARGIN / 100 * (float)this.Width);
                this.RightMargin = (int)Math.Min(this.RightMargin, (float)MAX_MARGIN / 100 * (float)this.Width);
                if (temp != this.RightMargin) result = false;

                //Top Margin
                temp = this.TopMargin;
                this.TopMargin = (int)Math.Max(this.TopMargin, (float)MIN_MARGIN / 100 * (float)this.Height);
                this.TopMargin = (int)Math.Min(this.TopMargin, (float)MAX_MARGIN / 100 * (float)this.Height);
                if (temp != this.TopMargin) result = false;

                //Bottom Margin
                temp = this.BottomMargin;
                this.BottomMargin = (int)Math.Max(this.BottomMargin, (float)MIN_MARGIN / 100 * (float)this.Height);
                this.BottomMargin = (int)Math.Min(this.BottomMargin, (float)MAX_MARGIN / 100 * (float)this.Height);
                if (temp != this.BottomMargin) result = false;

                return result;
            }
            else
                return true;
		}

		public void PrintFootLine(Graphics drawDestination)
		{
			RectangleF ItemBox = new RectangleF(0, 0, 0, 0);
            
            if (doNotCutWorksheet)
            {
                if (this.mPrintFootLine == true)
                    footLine.drawItem(drawDestination, this.LeftMargin, this.GetWorksheetHeight() + this.TopMargin - footLine.getHeight(drawDestination, GetWorksheetWidth()), this.GetWorksheetWidth());
            }
            else
            {
                if (this.mPrintFootLine == true)
                    footLine.drawItem(drawDestination, this.LeftMargin, this.GetWorksheetHeight() + this.TopMargin, this.GetWorksheetWidth());
            }
            mFootlineItemBox = ItemBox;
       	}
		public void SetMargins(int LeftMargin, int RightMargin, int TopMargin, int BottomMargin)
		{
			this.LeftMargin = LeftMargin;
			this.RightMargin = RightMargin;
			this.TopMargin = TopMargin;
			this.BottomMargin = BottomMargin;
			this.FootMargin = 0;
		}
		
		public void AddSize(float width, float Height, byte unit)
		{
            switch(unit){
				case WS_UNIT_CM:
					this.mWidth = (int)((width/mDpi) * WS_INCH_CM);
					this.mHeight = (int)((Height/mDpi) * WS_INCH_CM);
					break;
				case WS_UNIT_MM:
					this.mWidth = (int)((width/mDpi) * WS_INCH_CM *10);
					this.mHeight = (int)((Height/mDpi) * WS_INCH_CM *10);
					break;
				case WS_UNIT_INCH:
					this.mWidth = (int)(width / mDpi);
					this.mHeight = (int)(Height / mDpi);
					break;
				case WS_UNIT_PICSEL:
					this.mWidth = (int)width;
					this.mHeight = (int)Height;
					break;
			}
		}
		
		public float CalcSize(float size, byte unitSource)
		{
            switch (unitSource)
            {
				case WS_UNIT_CM:
					return ((size/WS_INCH_CM)*mDpi);
				case WS_UNIT_MM:
					return ((size/WS_INCH_CM)*mDpi)/10;
				case WS_UNIT_INCH:
					return (size*mDpi);
				case WS_UNIT_PICSEL:
					return  (float) Math.Round(size,0);
			}
			return 0;
		}
		
		public float CalcSize(float size, byte unitSource, byte unitDestination)
		{
			float tempSize=0;
			
			switch (unitSource){
				case WS_UNIT_CM:
					tempSize = ((size/WS_INCH_CM)*mDpi);
					break;
				case WS_UNIT_MM:
					tempSize =  ((size/WS_INCH_CM)*mDpi)/10;
					break;
				case WS_UNIT_INCH:
					tempSize = (size*mDpi);
					break;
				case WS_UNIT_PICSEL:
					tempSize = size;
					break;
			}
			
			switch (unitDestination){
				case WS_UNIT_CM:
					return (float) Math.Round(((tempSize/mDpi)*WS_INCH_CM),2);
				case WS_UNIT_MM:
					return (float) Math.Round(((tempSize/mDpi)*WS_INCH_CM*10),2);
				case WS_UNIT_INCH:
					return (float) Math.Round((tempSize/mDpi),2);
				case WS_UNIT_PICSEL:
					return (float) Math.Round(tempSize,0);
			}
			return 0;
		}
		
		public void GetSizes(ref string[] s)
		{
			s=mSizes;
		}
		public void GetUnits(ref string[] s)
		{
			s=mUnits;
		}
        public void SetWorksheetHeight(int height)
        {
            if (doNotCutWorksheet)
            {
            	this.mHeight = height;
                return;
            }
            if (this.mPrintFootLine == true)
                height += (int)footLine.getHeight(graphics, (mWidth - mLeftMargin) - mRightMargin);
            this.mHeight = height + mTopMargin + mBottomMargin;

        }

        public void SetWorksheetWidth(int width)
        {
            if (doNotCutWorksheet)
            {
                this.mWidth = width;
                return;
            }
            this.mWidth = width + mLeftMargin + mRightMargin;

        }
        public RectangleF FootlineItemBox{
			get{
				return mFootlineItemBox;
			}
		}


	}
}
