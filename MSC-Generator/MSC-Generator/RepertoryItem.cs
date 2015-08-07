/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 16.01.2006
 * Time: 13:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using mscEditor;

namespace mscGenerator
{
	public delegate void AddText(NumberingRichTextBoxControl.NumberingRichTextBox ew);
	
	/// <summary>
	/// Description of RepertoryItem.
	/// </summary>
	
	public class RepertoryItem
	{
		Image mRepertoryImage;
		AddText at;
		
		public RepertoryItem(Image img, AddText x)
		{
			mRepertoryImage = new Bitmap(img);
			at = new AddText(x);
		}
		public Image repertoryImage{
			get{
				return mRepertoryImage;
			}
		}
		public void MakeText(NumberingRichTextBoxControl.NumberingRichTextBox ew)
		{
			at(ew);
		}
	}
}
