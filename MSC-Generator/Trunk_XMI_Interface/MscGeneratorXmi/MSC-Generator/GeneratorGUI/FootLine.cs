/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Resources;
using System.Reflection;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of HeadLine.
	/// </summary>
	
	public class FootLine
	{
		ResourceManager strings = new ResourceManager ("GeneratorGUI.Strings", Assembly.GetAssembly(typeof(GUI)));
		
		private Pen mFootPen;
		private Font mFootFont;
		private string mAuthor;
		private string mCompany;
		private string mVersion;
		private string mDate;
		private string mFileName;
		private string mPrintDate;
		
		private bool mDrawAuthor;
		private bool mDrawCompany;
		private bool mDrawVersion;
		private bool mDrawDate;
		private bool mDrawFileName;
		private bool mDrawPrintDate;
		private bool mDrawFootLine;
		
		private RectangleF mItemBox;
		
		public FootLine()
		{
			mAuthor 		= "";
			mCompany 		= "";
			mVersion 		= "";
			mDate 			= "";
			mFileName 		= "";
			mPrintDate 		= DateTime.Now.Date.ToShortDateString();
			
			mDrawAuthor 	= true;
			mDrawCompany 	= true;
			mDrawVersion 	= true;
			mDrawDate 		= true;
			mDrawFileName 	= true;
			mDrawPrintDate 	= true;
			mDrawFootLine 	= false;
			
			mFootPen 		= new Pen(Color.Black, 1);
			mFootFont 		= new Font("Arial",9,FontStyle.Regular,GraphicsUnit.Point);
			mItemBox		= new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
		}
		public void Initialize()
		{
			mAuthor 		= "";
			mCompany 		= "";
			mVersion 		= "";
			mDate 			= "";
			mFileName 		= "";
			mPrintDate 		= DateTime.Now.Date.ToShortDateString();
			
			mDrawAuthor 	= true;
			mDrawCompany 	= true;
			mDrawVersion 	= true;
			mDrawDate 		= true;
			mDrawFileName 	= true;
			mDrawPrintDate 	= true;
			mDrawFootLine 	= false;	
		}
		public RectangleF ItemBox{
			set{
				mItemBox = value;
			}
			get{
				return mItemBox;
			}
		}
		public string Author{
			set{
				mAuthor = value;
			}
			get{
				return mAuthor;
			}
		}
		public string Company{
			set{
				mCompany = value;
			}
			get{
				return mCompany;
			}
		}
		public string Version{
			set{
				mVersion = value;
			}
			get{
				return mVersion;
			}
		}
		public string Date{
			set{
				mDate = value;
			}
			get{
				return mDate;
			}
		}
		public string FileName{
			set{
				mFileName = value;
			}
			get{
				return mFileName;
			}
		}
		public bool DrawAuthor{
			set{
				mDrawAuthor = value;
			}
			get{
				return mDrawAuthor;
			}
		}
		public bool DrawCompany{
			set{
				mDrawCompany = value;
			}
			get{
				return mDrawCompany;
			}
		}
		public bool DrawVersion{
			set{
				mDrawVersion = value;
			}
			get{
				return mDrawVersion;
			}
		}
		public bool DrawDate{
			set{
				mDrawDate = value;
			}
			get{
				return mDrawDate;
			}
		}		
		public bool DrawPrintDate{
			set{
				mDrawPrintDate = value;
			}
			get{
				return mDrawPrintDate;
			}
		}		
		public bool DrawFileName{
			set{
				mDrawFileName = value;
			}
			get{
				return mDrawFileName;
			}
		}		
		public bool DrawFootLine{
			set{
				mDrawFootLine = value;
			}
			get{
				return mDrawFootLine;
			}
		}		
		public float getHeight(Graphics drawDestination, float width)
		{
			if(mDrawFootLine == false)
				return 0.0f;
			
			StringFormat footStringFormat 	= new StringFormat();
			float leftTitelWidth 			= drawDestination.MeasureString(strings.GetString("FileName"), mFootFont, new SizeF(width,100), footStringFormat).Width;
			float rightTitelWidth 			= drawDestination.MeasureString(strings.GetString("PrintDate"), mFootFont, new SizeF(width,100), footStringFormat).Width;
			float maxWidth 					= (width/2) - Math.Max(leftTitelWidth,rightTitelWidth);
			float leftHeight 				= 0;
			float rightHeight				= 0;
			
			if((mDrawCompany)&&(mCompany.Trim().Length>0)){
				leftHeight += drawDestination.MeasureString(mCompany, mFootFont, new SizeF(maxWidth,5000), footStringFormat).Height;
			}
			if((mDrawAuthor)&&(mAuthor.Trim().Length>0)){
				leftHeight += drawDestination.MeasureString(mAuthor, mFootFont, new SizeF(maxWidth,5000), footStringFormat).Height;
			}
			if((mDrawFileName)&&(mFileName.Trim().Length>0)){
				leftHeight += drawDestination.MeasureString(mFileName, mFootFont, new SizeF(maxWidth,5000), footStringFormat).Height;
			}
			
			if((mDrawDate)&&(mDate.Trim().Length>0)){
				rightHeight += drawDestination.MeasureString(mDate, mFootFont, new SizeF(maxWidth,5000), footStringFormat).Height;
			}
			if((mDrawPrintDate)&&(mPrintDate.Trim().Length>0)){
				rightHeight += drawDestination.MeasureString(mPrintDate, mFootFont, new SizeF(maxWidth,5000), footStringFormat).Height;
			}
			if((mDrawVersion)&&(mVersion.Trim().Length>0)){
				rightHeight += drawDestination.MeasureString(mVersion, mFootFont, new SizeF(maxWidth,5000), footStringFormat).Height;
			}

			return Math.Max(leftHeight,rightHeight);
		}
		public void drawItem(Graphics drawDestination, float xPos, float yPos, float width)
		{
			mItemBox = new RectangleF(xPos, yPos, 0, 0);
            if(mDrawFootLine == false)
				return;
			StringFormat footStringFormat 	= new StringFormat();
			RectangleF textBox;
			SizeF textSize;
			float leftTitelWidth 			= drawDestination.MeasureString(strings.GetString("FileName"), mFootFont, new SizeF(width,100), footStringFormat).Width;
			float rightTitelWidth 			= drawDestination.MeasureString(strings.GetString("PrintDate"), mFootFont, new SizeF(width,100), footStringFormat).Width;
			float titelWidth 				= Math.Max(leftTitelWidth,rightTitelWidth);
			float maxWidth 					= (width/2) - titelWidth; 
			float maxRightWidth				= 0;
			float leftHeight 				= 0;
			float rightHeight				= 0;
			string text						= "";
            float leftXPos					= xPos;
			
			if((mDrawCompany)&&(mCompany.Trim().Length>0)){
				text = strings.GetString("Company");
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(titelWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos, yPos+leftHeight, titelWidth, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				text = mCompany;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos + titelWidth, yPos+leftHeight, textSize.Width, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				leftHeight += textSize.Height;
			}
			if((mDrawAuthor)&&(mAuthor.Trim().Length>0)){
				text = strings.GetString("Author");
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(titelWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos, yPos+leftHeight, titelWidth, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				text = mAuthor;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos + titelWidth, yPos+leftHeight, textSize.Width, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				leftHeight += textSize.Height;
			}
			
			if((mDrawFileName)&&(mFileName.Trim().Length>0)){
				text = strings.GetString("FileName");
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(titelWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos, yPos+leftHeight, titelWidth, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				text = mFileName;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos + titelWidth, yPos+leftHeight, textSize.Width, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				leftHeight += textSize.Height;
			}
			
			if((mDrawDate)&&(mDate.Trim().Length>0)){
				text = mDate;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				maxRightWidth = Math.Max(maxRightWidth, textSize.Width);
			}
			if((mDrawPrintDate)&&(mPrintDate.Trim().Length>0)){
				text = mPrintDate;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				maxRightWidth = Math.Max(maxRightWidth, textSize.Width);
			}
			if((mDrawVersion)&&(mVersion.Trim().Length>0)){
				text = mVersion;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				maxRightWidth = Math.Max(maxRightWidth, textSize.Width);
			}
			
			xPos = ((xPos+width) - titelWidth) - maxRightWidth;
			
			if((mDrawDate)&&(mDate.Trim().Length>0)){
				text = strings.GetString("Date");
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(titelWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos, yPos+rightHeight, titelWidth, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				text = mDate;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos + titelWidth, yPos+rightHeight, textSize.Width, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				rightHeight += textSize.Height;
			}
			
			if((mDrawPrintDate)&&(mPrintDate.Trim().Length>0)){
				text = strings.GetString("PrintDate");
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(titelWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos, yPos+rightHeight, titelWidth, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				text = mPrintDate;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos + titelWidth, yPos+rightHeight, textSize.Width, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				rightHeight += textSize.Height;
			}
			
			if((mDrawVersion)&&(mVersion.Trim().Length>0)){
				text = strings.GetString("Version");
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(titelWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos, yPos+rightHeight, titelWidth, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				text = mVersion;
				textSize = drawDestination.MeasureString(text, mFootFont, new SizeF(maxWidth,5000), footStringFormat);
				textBox = new RectangleF(xPos + titelWidth, yPos+rightHeight, textSize.Width, textSize.Height);
				drawDestination.DrawString(text,mFootFont,Brushes.Black,textBox,footStringFormat);			
				
				rightHeight += textSize.Height;
			}
			if(rightHeight > leftHeight)
				mItemBox = new RectangleF(leftXPos, yPos, width, rightHeight);
			else
				mItemBox = new RectangleF(leftXPos, yPos, width, leftHeight);
		}
	}
}

