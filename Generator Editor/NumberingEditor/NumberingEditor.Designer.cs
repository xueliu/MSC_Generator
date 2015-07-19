/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 03.08.2006
 * Time: 10:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NumberingEditor
{
	partial class NumberingEditor : NumberingRichTextBox//: System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// NumberingEditor
			// 
//			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "NumberingEditor";
			this.Size = new System.Drawing.Size(152, 140);
			this.ResumeLayout(false);
		}
	//	private NumberingRichTextBox richTextBox1;
	}
}
