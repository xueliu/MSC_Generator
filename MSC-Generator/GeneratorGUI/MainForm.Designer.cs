/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 10:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GeneratorGUI
{
	partial class MainForm : GUI//System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
			this.pnlOutput.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabWork.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sourceFileWatch)).BeginInit();
			this.splitContainerEditor.Panel1.SuspendLayout();
			this.splitContainerEditor.Panel2.SuspendLayout();
			this.splitContainerEditor.SuspendLayout();
			this.SuspendLayout();
			// 
			// rtbMscEditor
			// 
			this.rtbMscEditor.AccessibleDescription = null;
			this.rtbMscEditor.AccessibleName = null;
			this.rtbMscEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rtbMscEditor.Anchor")));
			this.rtbMscEditor.AutoSize = ((bool)(resources.GetObject("rtbMscEditor.AutoSize")));
			this.rtbMscEditor.BackgroundImage = null;
			this.rtbMscEditor.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("rtbMscEditor.BackgroundImageLayout")));
			this.rtbMscEditor.BulletIndent = ((int)(resources.GetObject("rtbMscEditor.BulletIndent")));
			this.rtbMscEditor.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rtbMscEditor.Dock")));
			this.rtbMscEditor.Font = null;
			this.rtbMscEditor.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rtbMscEditor.ImeMode")));
			this.rtbMscEditor.Location = ((System.Drawing.Point)(resources.GetObject("rtbMscEditor.Location")));
			this.rtbMscEditor.MaxLength = ((int)(resources.GetObject("rtbMscEditor.MaxLength")));
			this.rtbMscEditor.Multiline = ((bool)(resources.GetObject("rtbMscEditor.Multiline")));
			this.rtbMscEditor.RightMargin = ((int)(resources.GetObject("rtbMscEditor.RightMargin")));
			this.rtbMscEditor.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rtbMscEditor.RightToLeft")));
			this.rtbMscEditor.ScrollBars = ((System.Windows.Forms.RichTextBoxScrollBars)(resources.GetObject("rtbMscEditor.ScrollBars")));
			this.rtbMscEditor.Size = ((System.Drawing.Size)(resources.GetObject("rtbMscEditor.Size")));
			this.rtbMscEditor.TabIndex = ((int)(resources.GetObject("rtbMscEditor.TabIndex")));
			this.rtbMscEditor.Text = resources.GetString("rtbMscEditor.Text");
			this.rtbMscEditor.WordWrap = ((bool)(resources.GetObject("rtbMscEditor.WordWrap")));
			this.rtbMscEditor.ZoomFactor = ((float)(resources.GetObject("rtbMscEditor.ZoomFactor")));
			// 
			// dlgSaveImage
			// 
			this.dlgSaveImage.Filter = resources.GetString("dlgSaveImage.Filter");
			this.dlgSaveImage.Title = resources.GetString("dlgSaveImage.Title");
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.Filter = resources.GetString("dlgOpenFile.Filter");
			this.dlgOpenFile.Title = resources.GetString("dlgOpenFile.Title");
			// 
			// tabPage2
			// 
			this.tabPage2.AccessibleDescription = null;
			this.tabPage2.AccessibleName = null;
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPage2.Anchor")));
			this.tabPage2.AutoScroll = ((bool)(resources.GetObject("tabPage2.AutoScroll")));
			this.tabPage2.BackgroundImage = null;
			this.tabPage2.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabPage2.BackgroundImageLayout")));
			this.tabPage2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPage2.Dock")));
			this.tabPage2.Font = null;
			this.tabPage2.ImageIndex = ((int)(resources.GetObject("tabPage2.ImageIndex")));
			this.tabPage2.ImageKey = resources.GetString("tabPage2.ImageKey");
			this.tabPage2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPage2.ImeMode")));
			this.tabPage2.Location = ((System.Drawing.Point)(resources.GetObject("tabPage2.Location")));
			this.tabPage2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPage2.RightToLeft")));
			this.tabPage2.Size = ((System.Drawing.Size)(resources.GetObject("tabPage2.Size")));
			this.tabPage2.TabIndex = ((int)(resources.GetObject("tabPage2.TabIndex")));
			this.tabPage2.Text = resources.GetString("tabPage2.Text");
			this.tabPage2.ToolTipText = resources.GetString("tabPage2.ToolTipText");
			this.tabPage2.Visible = ((bool)(resources.GetObject("tabPage2.Visible")));
			// 
			// pnlParameter
			// 
			this.pnlParameter.AccessibleDescription = null;
			this.pnlParameter.AccessibleName = null;
			this.pnlParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pnlParameter.Anchor")));
			this.pnlParameter.AutoScroll = ((bool)(resources.GetObject("pnlParameter.AutoScroll")));
			this.pnlParameter.AutoSize = ((bool)(resources.GetObject("pnlParameter.AutoSize")));
			this.pnlParameter.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("pnlParameter.AutoSizeMode")));
			this.pnlParameter.BackgroundImage = null;
			this.pnlParameter.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pnlParameter.BackgroundImageLayout")));
			this.pnlParameter.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pnlParameter.Dock")));
			this.pnlParameter.Font = null;
			this.pnlParameter.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pnlParameter.ImeMode")));
			this.pnlParameter.Location = ((System.Drawing.Point)(resources.GetObject("pnlParameter.Location")));
			this.pnlParameter.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pnlParameter.RightToLeft")));
			this.pnlParameter.Size = ((System.Drawing.Size)(resources.GetObject("pnlParameter.Size")));
			this.pnlParameter.TabIndex = ((int)(resources.GetObject("pnlParameter.TabIndex")));
			// 
			// picOutput
			// 
			this.picOutput.AccessibleDescription = null;
			this.picOutput.AccessibleName = null;
			this.picOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("picOutput.Anchor")));
			this.picOutput.BackgroundImage = null;
			this.picOutput.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("picOutput.BackgroundImageLayout")));
			this.picOutput.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("picOutput.Dock")));
			this.picOutput.Font = null;
			this.picOutput.ImageLocation = null;
			this.picOutput.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("picOutput.ImeMode")));
			this.picOutput.Location = ((System.Drawing.Point)(resources.GetObject("picOutput.Location")));
			this.picOutput.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("picOutput.Margin")));
			this.picOutput.Padding = ((System.Windows.Forms.Padding)(resources.GetObject("picOutput.Padding")));
			this.picOutput.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("picOutput.RightToLeft")));
			this.picOutput.Size = ((System.Drawing.Size)(resources.GetObject("picOutput.Size")));
			this.picOutput.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("picOutput.SizeMode")));
			this.picOutput.TabIndex = ((int)(resources.GetObject("picOutput.TabIndex")));
			this.picOutput.WaitOnLoad = ((bool)(resources.GetObject("picOutput.WaitOnLoad")));
			// 
			// pnlOutput
			// 
			this.pnlOutput.AccessibleDescription = null;
			this.pnlOutput.AccessibleName = null;
			this.pnlOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pnlOutput.Anchor")));
			this.pnlOutput.AutoScroll = ((bool)(resources.GetObject("pnlOutput.AutoScroll")));
			this.pnlOutput.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("pnlOutput.AutoScrollMargin")));
			this.pnlOutput.AutoSize = ((bool)(resources.GetObject("pnlOutput.AutoSize")));
			this.pnlOutput.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("pnlOutput.AutoSizeMode")));
			this.pnlOutput.BackgroundImage = null;
			this.pnlOutput.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pnlOutput.BackgroundImageLayout")));
			this.pnlOutput.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pnlOutput.Dock")));
			this.pnlOutput.Font = null;
			this.pnlOutput.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pnlOutput.ImeMode")));
			this.pnlOutput.Location = ((System.Drawing.Point)(resources.GetObject("pnlOutput.Location")));
			this.pnlOutput.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pnlOutput.RightToLeft")));
			this.pnlOutput.Size = ((System.Drawing.Size)(resources.GetObject("pnlOutput.Size")));
			this.pnlOutput.TabIndex = ((int)(resources.GetObject("pnlOutput.TabIndex")));
			// 
			// tabPage1
			// 
			this.tabPage1.AccessibleDescription = null;
			this.tabPage1.AccessibleName = null;
			this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPage1.Anchor")));
			this.tabPage1.AutoScroll = ((bool)(resources.GetObject("tabPage1.AutoScroll")));
			this.tabPage1.BackgroundImage = null;
			this.tabPage1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabPage1.BackgroundImageLayout")));
			this.tabPage1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPage1.Dock")));
			this.tabPage1.Font = null;
			this.tabPage1.ImageIndex = ((int)(resources.GetObject("tabPage1.ImageIndex")));
			this.tabPage1.ImageKey = resources.GetString("tabPage1.ImageKey");
			this.tabPage1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPage1.ImeMode")));
			this.tabPage1.Location = ((System.Drawing.Point)(resources.GetObject("tabPage1.Location")));
			this.tabPage1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPage1.RightToLeft")));
			this.tabPage1.Size = ((System.Drawing.Size)(resources.GetObject("tabPage1.Size")));
			this.tabPage1.TabIndex = ((int)(resources.GetObject("tabPage1.TabIndex")));
			this.tabPage1.Text = resources.GetString("tabPage1.Text");
			this.tabPage1.ToolTipText = resources.GetString("tabPage1.ToolTipText");
			this.tabPage1.Visible = ((bool)(resources.GetObject("tabPage1.Visible")));
			// 
			// tabWork
			// 
			this.tabWork.AccessibleDescription = null;
			this.tabWork.AccessibleName = null;
			this.tabWork.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("tabWork.Alignment")));
			this.tabWork.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabWork.Anchor")));
			this.tabWork.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("tabWork.Appearance")));
			this.tabWork.BackgroundImage = null;
			this.tabWork.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabWork.BackgroundImageLayout")));
			this.tabWork.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabWork.Dock")));
			this.tabWork.Font = null;
			this.tabWork.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabWork.ImeMode")));
			this.tabWork.ItemSize = ((System.Drawing.Size)(resources.GetObject("tabWork.ItemSize")));
			this.tabWork.Location = ((System.Drawing.Point)(resources.GetObject("tabWork.Location")));
			this.tabWork.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabWork.RightToLeft")));
			this.tabWork.RightToLeftLayout = ((bool)(resources.GetObject("tabWork.RightToLeftLayout")));
			this.tabWork.ShowToolTips = ((bool)(resources.GetObject("tabWork.ShowToolTips")));
			this.tabWork.Size = ((System.Drawing.Size)(resources.GetObject("tabWork.Size")));
			this.tabWork.TabIndex = ((int)(resources.GetObject("tabWork.TabIndex")));
			// 
			// dlgPreviewPage
			// 
			this.dlgPreviewPage.AccessibleDescription = null;
			this.dlgPreviewPage.AccessibleName = null;
			this.dlgPreviewPage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("dlgPreviewPage.Anchor")));
			this.dlgPreviewPage.AutoScroll = ((bool)(resources.GetObject("dlgPreviewPage.AutoScroll")));
			this.dlgPreviewPage.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("dlgPreviewPage.AutoScrollMargin")));
			this.dlgPreviewPage.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("dlgPreviewPage.AutoScrollMinSize")));
			this.dlgPreviewPage.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("dlgPreviewPage.AutoSizeMode")));
			this.dlgPreviewPage.BackgroundImage = null;
			this.dlgPreviewPage.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("dlgPreviewPage.BackgroundImageLayout")));
			this.dlgPreviewPage.ClientSize = ((System.Drawing.Size)(resources.GetObject("dlgPreviewPage.ClientSize")));
			this.dlgPreviewPage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("dlgPreviewPage.Dock")));
			this.dlgPreviewPage.Enabled = ((bool)(resources.GetObject("dlgPreviewPage.Enabled")));
			this.dlgPreviewPage.Font = null;
			this.dlgPreviewPage.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPreviewPage.Icon")));
			this.dlgPreviewPage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("dlgPreviewPage.ImeMode")));
			this.dlgPreviewPage.MaximumSize = ((System.Drawing.Size)(resources.GetObject("dlgPreviewPage.MaximumSize")));
			this.dlgPreviewPage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("dlgPreviewPage.RightToLeft")));
			this.dlgPreviewPage.RightToLeftLayout = ((bool)(resources.GetObject("dlgPreviewPage.RightToLeftLayout")));
			this.dlgPreviewPage.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("dlgPreviewPage.StartPosition")));
			this.dlgPreviewPage.Visible = ((bool)(resources.GetObject("dlgPreviewPage.Visible")));
			// 
			// lstRepertory
			// 
			this.lstRepertory.AccessibleDescription = null;
			this.lstRepertory.AccessibleName = null;
			this.lstRepertory.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstRepertory.Anchor")));
			this.lstRepertory.BackgroundImage = null;
			this.lstRepertory.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lstRepertory.BackgroundImageLayout")));
			this.lstRepertory.ColumnWidth = ((int)(resources.GetObject("lstRepertory.ColumnWidth")));
			this.lstRepertory.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstRepertory.Dock")));
			this.lstRepertory.Font = null;
			this.lstRepertory.HorizontalExtent = ((int)(resources.GetObject("lstRepertory.HorizontalExtent")));
			this.lstRepertory.HorizontalScrollbar = ((bool)(resources.GetObject("lstRepertory.HorizontalScrollbar")));
			this.lstRepertory.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstRepertory.ImeMode")));
			this.lstRepertory.IntegralHeight = ((bool)(resources.GetObject("lstRepertory.IntegralHeight")));
			this.lstRepertory.ItemHeight = ((int)(resources.GetObject("lstRepertory.ItemHeight")));
			this.lstRepertory.Location = ((System.Drawing.Point)(resources.GetObject("lstRepertory.Location")));
			this.lstRepertory.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstRepertory.RightToLeft")));
			this.lstRepertory.ScrollAlwaysVisible = ((bool)(resources.GetObject("lstRepertory.ScrollAlwaysVisible")));
			this.lstRepertory.Size = ((System.Drawing.Size)(resources.GetObject("lstRepertory.Size")));
			this.lstRepertory.TabIndex = ((int)(resources.GetObject("lstRepertory.TabIndex")));
			// 
			// lstPreview
			// 
			this.lstPreview.AccessibleDescription = null;
			this.lstPreview.AccessibleName = null;
			this.lstPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstPreview.Anchor")));
			this.lstPreview.BackgroundImage = null;
			this.lstPreview.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lstPreview.BackgroundImageLayout")));
			this.lstPreview.ColumnWidth = ((int)(resources.GetObject("lstPreview.ColumnWidth")));
			this.lstPreview.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstPreview.Dock")));
			this.lstPreview.Font = null;
			this.lstPreview.HorizontalExtent = ((int)(resources.GetObject("lstPreview.HorizontalExtent")));
			this.lstPreview.HorizontalScrollbar = ((bool)(resources.GetObject("lstPreview.HorizontalScrollbar")));
			this.lstPreview.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstPreview.ImeMode")));
			this.lstPreview.IntegralHeight = ((bool)(resources.GetObject("lstPreview.IntegralHeight")));
			this.lstPreview.ItemHeight = ((int)(resources.GetObject("lstPreview.ItemHeight")));
			this.lstPreview.Location = ((System.Drawing.Point)(resources.GetObject("lstPreview.Location")));
			this.lstPreview.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstPreview.RightToLeft")));
			this.lstPreview.ScrollAlwaysVisible = ((bool)(resources.GetObject("lstPreview.ScrollAlwaysVisible")));
			this.lstPreview.Size = ((System.Drawing.Size)(resources.GetObject("lstPreview.Size")));
			this.lstPreview.TabIndex = ((int)(resources.GetObject("lstPreview.TabIndex")));
			// 
			// splitContainerEditor
			// 
			this.splitContainerEditor.AccessibleDescription = null;
			this.splitContainerEditor.AccessibleName = null;
			this.splitContainerEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("splitContainerEditor.Anchor")));
			this.splitContainerEditor.AutoScroll = ((bool)(resources.GetObject("splitContainerEditor.AutoScroll")));
			this.splitContainerEditor.BackgroundImage = null;
			this.splitContainerEditor.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("splitContainerEditor.BackgroundImageLayout")));
			this.splitContainerEditor.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("splitContainerEditor.Dock")));
			this.splitContainerEditor.Font = null;
			this.splitContainerEditor.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("splitContainerEditor.ImeMode")));
			this.splitContainerEditor.IsSplitterFixed = ((bool)(resources.GetObject("splitContainerEditor.IsSplitterFixed")));
			this.splitContainerEditor.Location = ((System.Drawing.Point)(resources.GetObject("splitContainerEditor.Location")));
			this.splitContainerEditor.Orientation = ((System.Windows.Forms.Orientation)(resources.GetObject("splitContainerEditor.Orientation")));
			// 
			// splitContainerEditor.Panel1
			// 
			this.splitContainerEditor.Panel1.AccessibleDescription = null;
			this.splitContainerEditor.Panel1.AccessibleName = null;
			this.splitContainerEditor.Panel1.AutoScroll = ((bool)(resources.GetObject("splitContainerEditor.Panel1.AutoScroll")));
			this.splitContainerEditor.Panel1.BackgroundImage = null;
			this.splitContainerEditor.Panel1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("splitContainerEditor.Panel1.BackgroundImageLayout")));
			this.splitContainerEditor.Panel1.Font = null;
			this.splitContainerEditor.Panel1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("splitContainerEditor.Panel1.ImeMode")));
			this.splitContainerEditor.Panel1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("splitContainerEditor.Panel1.RightToLeft")));
			this.splitContainerEditor.Panel1MinSize = ((int)(resources.GetObject("splitContainerEditor.Panel1MinSize")));
			// 
			// splitContainerEditor.Panel2
			// 
			this.splitContainerEditor.Panel2.AccessibleDescription = null;
			this.splitContainerEditor.Panel2.AccessibleName = null;
			this.splitContainerEditor.Panel2.AutoScroll = ((bool)(resources.GetObject("splitContainerEditor.Panel2.AutoScroll")));
			this.splitContainerEditor.Panel2.BackgroundImage = null;
			this.splitContainerEditor.Panel2.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("splitContainerEditor.Panel2.BackgroundImageLayout")));
			this.splitContainerEditor.Panel2.Font = null;
			this.splitContainerEditor.Panel2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("splitContainerEditor.Panel2.ImeMode")));
			this.splitContainerEditor.Panel2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("splitContainerEditor.Panel2.RightToLeft")));
			this.splitContainerEditor.Panel2MinSize = ((int)(resources.GetObject("splitContainerEditor.Panel2MinSize")));
			this.splitContainerEditor.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("splitContainerEditor.RightToLeft")));
			this.splitContainerEditor.Size = ((System.Drawing.Size)(resources.GetObject("splitContainerEditor.Size")));
			this.splitContainerEditor.SplitterDistance = ((int)(resources.GetObject("splitContainerEditor.SplitterDistance")));
			this.splitContainerEditor.SplitterIncrement = ((int)(resources.GetObject("splitContainerEditor.SplitterIncrement")));
			this.splitContainerEditor.SplitterWidth = ((int)(resources.GetObject("splitContainerEditor.SplitterWidth")));
			this.splitContainerEditor.TabIndex = ((int)(resources.GetObject("splitContainerEditor.TabIndex")));
			// 
			// tlbbZoomFitWide
			// 
			this.tlbbZoomFitWide.Enabled = ((bool)(resources.GetObject("tlbbZoomFitWide.Enabled")));
			this.tlbbZoomFitWide.ImageIndex = ((int)(resources.GetObject("tlbbZoomFitWide.ImageIndex")));
			this.tlbbZoomFitWide.ImageKey = resources.GetString("tlbbZoomFitWide.ImageKey");
			this.tlbbZoomFitWide.Text = resources.GetString("tlbbZoomFitWide.Text");
			this.tlbbZoomFitWide.ToolTipText = resources.GetString("tlbbZoomFitWide.ToolTipText");
			this.tlbbZoomFitWide.Visible = ((bool)(resources.GetObject("tlbbZoomFitWide.Visible")));
			// 
			// MainForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleDimensions = ((System.Drawing.SizeF)(resources.GetObject("$this.AutoScaleDimensions")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackgroundImage = null;
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Font = null;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "MainForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Controls.SetChildIndex(this.tabWork, 0);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
			this.pnlOutput.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabWork.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sourceFileWatch)).EndInit();
			this.splitContainerEditor.Panel1.ResumeLayout(false);
			this.splitContainerEditor.Panel2.ResumeLayout(false);
			this.splitContainerEditor.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
