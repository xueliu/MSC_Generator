/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GeneratorGUI
{
	partial class Log : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
			this.lstv = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.imageListLstv = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// lstv
			// 
			this.lstv.AccessibleDescription = null;
			this.lstv.AccessibleName = null;
			this.lstv.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("lstv.Alignment")));
			this.lstv.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstv.Anchor")));
			this.lstv.BackgroundImage = null;
			this.lstv.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lstv.BackgroundImageLayout")));
			this.lstv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.lstv.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstv.Dock")));
			this.lstv.Font = null;
			this.lstv.FullRowSelect = true;
			this.lstv.GridLines = true;
			this.lstv.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstv.ImeMode")));
			this.lstv.LabelWrap = ((bool)(resources.GetObject("lstv.LabelWrap")));
			this.lstv.Location = ((System.Drawing.Point)(resources.GetObject("lstv.Location")));
			this.lstv.MultiSelect = false;
			this.lstv.Name = "lstv";
			this.lstv.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstv.RightToLeft")));
			this.lstv.RightToLeftLayout = ((bool)(resources.GetObject("lstv.RightToLeftLayout")));
			this.lstv.Size = ((System.Drawing.Size)(resources.GetObject("lstv.Size")));
			this.lstv.SmallImageList = this.imageListLstv;
			this.lstv.TabIndex = ((int)(resources.GetObject("lstv.TabIndex")));
			this.lstv.UseCompatibleStateImageBehavior = false;
			this.lstv.View = System.Windows.Forms.View.Details;
			this.lstv.SelectedIndexChanged += new System.EventHandler(this.lstv_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = resources.GetString("columnHeader1.Text");
			this.columnHeader1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader1.TextAlign")));
			this.columnHeader1.Width = ((int)(resources.GetObject("columnHeader1.Width")));
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = resources.GetString("columnHeader2.Text");
			this.columnHeader2.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader2.TextAlign")));
			this.columnHeader2.Width = ((int)(resources.GetObject("columnHeader2.Width")));
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = resources.GetString("columnHeader3.Text");
			this.columnHeader3.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader3.TextAlign")));
			this.columnHeader3.Width = ((int)(resources.GetObject("columnHeader3.Width")));
			// 
			// imageListLstv
			// 
			this.imageListLstv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLstv.ImageStream")));
			this.imageListLstv.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListLstv.Images.SetKeyName(0, "Log 3.ico");
			this.imageListLstv.Images.SetKeyName(1, "Log 1.ico");
			this.imageListLstv.Images.SetKeyName(2, "Log 2.ico");
			// 
			// Log
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleDimensions = ((System.Drawing.SizeF)(resources.GetObject("$this.AutoScaleDimensions")));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackgroundImage = null;
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.lstv);
			this.Font = null;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "Log";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView lstv;
        private System.Windows.Forms.ImageList imageListLstv;
	}
}
