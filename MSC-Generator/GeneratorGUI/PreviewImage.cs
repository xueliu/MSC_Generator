/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of PreviewImage.
	/// </summary>
	public class PreviewImage
	{
		private Image mPreviewImage;
			
		public PreviewImage(Image image)
		{
			mPreviewImage =new Bitmap(image);
		}
		public Image previewImage{
			get{
				return mPreviewImage;
			}
			set{
				mPreviewImage = value;
			}
		}
		public Image getImage(){
			return mPreviewImage;
		}
	}
}
