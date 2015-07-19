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
	public delegate void AddText(NumberingEditor.NumberingRichTextBox ew);
	
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
		public void MakeText(NumberingEditor.NumberingRichTextBox ew)
		{
			at(ew);
		}
	}
}
