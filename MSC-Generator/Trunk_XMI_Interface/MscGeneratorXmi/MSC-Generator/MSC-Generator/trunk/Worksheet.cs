/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 21.05.2005
 * Time: 07:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace mscGenerator
{
	/// <summary>
	/// Description of Worksheet.
	/// </summary>
	public class Worksheet
	{
		private int mWidth, mHeight;
		private byte mSize, mLayout;
		private int mLeftMargin, mRightMargin, mTopMargin, mBottomMargin;
		private byte mUnit;
		private float mDpi;
		
		private string[] mUnits = new string[4] {"cm","mm","Zoll","Pixel"};
		private string[] mSizes = new string[5] {"Benutzerdefiniert","A2-ISO","A3-ISO","A4-ISO","A5-ISO"};
		
		public const byte WS_SIZE_USER_DEFINED 		= 0;
		public const byte WS_SIZE_A2_ISO			= 1;
		public const byte WS_SIZE_A3_ISO			= 2;
		public const byte WS_SIZE_A4_ISO			= 3;
		public const byte WS_SIZE_A5_ISO			= 4;
		
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

		public Worksheet()
		{
			mSize = WS_SIZE_A4_ISO;
			mLayout = WS_LAYOUT_HORIZONTAL;
			mUnit = WS_UNIT_PICSEL;
			mWidth = 1123; mHeight = 794;			//A4
			mLeftMargin = 10; mRightMargin = 10; mTopMargin = 10; mBottomMargin = 10;
		}
		
		public int getWorksheetWidth()
		{
			return (mWidth - mLeftMargin) - mRightMargin;
		}
		public int getWorksheetHeight()
		{
			return (mHeight - mTopMargin) - mBottomMargin;
		}
		public byte size{
			get{
				return mSize;
			}
			set{
				mSize = value;
			}
		}
		public byte layout{
			get{
				return mLayout;
			}
			set{
				mLayout = value;
			}
		}
		public byte unit{
			get{
				return mUnit;
			}
			set{
				mUnit = value;
			}
		}
		public int leftMargin{
			get{
				return mLeftMargin;
			}
			set{
				mLeftMargin = value;
			}
		}
		public int rightMargin{
			get{
				return mRightMargin;
			}
			set{
				mRightMargin = value;
			}
		}
		public int topMargin{
			get{
				return mTopMargin;
			}
			set{
				mTopMargin = value;
			}
		}
		public int bottomMargin{
			get{
				return mBottomMargin;
			}
			set{
				mBottomMargin = value;
			}
		}
		public int width{
			get{
				return mWidth;
			}
			set{
				mWidth = value;
			}
		}
		public int height{
			get{
				return mHeight;
			}
			set{
				mHeight = value;
			}
		}
		public float dpi{
			get{
				return mDpi;
			}
			set{
				mDpi = value;
			}
		}
		
		public void setMargins(int leftMargin, int rightMargin, int topMargin, int bottomMargin)
		{
			this.leftMargin = leftMargin;
			this.rightMargin = rightMargin;
			this.topMargin = topMargin;
			this.bottomMargin = bottomMargin;
		}
		
		public void addSize(float width, float height, byte unit)
		{
			switch(unit){
				case WS_UNIT_CM:
					this.mWidth = (int)((width/mDpi) * WS_INCH_CM);
					this.mHeight = (int)((height/mDpi) * WS_INCH_CM);
					break;
				case WS_UNIT_MM:
					this.mWidth = (int)((width/mDpi) * WS_INCH_CM *10);
					this.mHeight = (int)((height/mDpi) * WS_INCH_CM *10);
					break;
				case WS_UNIT_INCH:
					this.mWidth = (int)(width / mDpi);
					this.mHeight = (int)(height / mDpi);
					break;
				case WS_UNIT_PICSEL:
					this.mWidth = (int)width;
					this.mHeight = (int)height;
					break;
			}
		}
		
		public float calcSize(float size, byte unitSource)
		{
			switch (unitSource){
				case WS_UNIT_CM:
					return ((size/WS_INCH_CM)*mDpi);
				case WS_UNIT_MM:
					return ((size/WS_INCH_CM)*mDpi)/10;
				case WS_UNIT_INCH:
					return (size*mDpi);
				case WS_UNIT_PICSEL:
					return (float) Math.Round(size,0);
			}
			return 0;
		}
		
		public float calcSize(float size, byte unitSource, byte unitDestination)
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
		
		public void getSizes(ref string[] s)
		{
			s=mSizes;
		}
		public void getUnits(ref string[] s)
		{
			s=mUnits;
		}
	}
}
