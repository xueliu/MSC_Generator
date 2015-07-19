/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 27.01.2006
 * Time: 12:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Drawing;

namespace mscPreview
{
	/// <summary>
	/// Description of PreviewWindow.
	/// </summary>
	public class FastPreviewList : ListBox
	{
		const short WM_PAINT = 0x00f;

		public static bool _Paint = true;

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == WM_PAINT)
		  	{
			  	if (_Paint){
		            base.WndProc(ref m);   // if we decided to paint this control, just call the RichTextBox WndProc
			  	}
		        else
		           m.Result = IntPtr.Zero;   //  not painting, must set this to IntPtr.Zero if not painting otherwise serious problems.
			}
			else base.WndProc (ref m);
		}
	}
}
