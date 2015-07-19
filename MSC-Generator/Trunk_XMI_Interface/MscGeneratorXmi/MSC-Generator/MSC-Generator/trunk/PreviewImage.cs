/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 25.05.2005
 * Time: 10:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace mscGenerator
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
