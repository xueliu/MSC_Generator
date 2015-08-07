/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GeneratorGUI
{
	partial class Replace : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replace));
			this.txtReplace = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmdReplaceAll = new System.Windows.Forms.Button();
			this.cmdReplace = new System.Windows.Forms.Button();
			this.chkCase = new System.Windows.Forms.CheckBox();
			this.chkWordOnly = new System.Windows.Forms.CheckBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdSearchAgain = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtReplace
			// 
			this.txtReplace.AccessibleDescription = null;
			this.txtReplace.AccessibleName = null;
			this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtReplace.Anchor")));
			this.txtReplace.BackgroundImage = null;
			this.txtReplace.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtReplace.BackgroundImageLayout")));
			this.txtReplace.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtReplace.Dock")));
			this.txtReplace.Font = null;
			this.txtReplace.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtReplace.ImeMode")));
			this.txtReplace.Location = ((System.Drawing.Point)(resources.GetObject("txtReplace.Location")));
			this.txtReplace.MaxLength = ((int)(resources.GetObject("txtReplace.MaxLength")));
			this.txtReplace.Multiline = ((bool)(resources.GetObject("txtReplace.Multiline")));
			this.txtReplace.Name = "txtReplace";
			this.txtReplace.PasswordChar = ((char)(resources.GetObject("txtReplace.PasswordChar")));
			this.txtReplace.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtReplace.RightToLeft")));
			this.txtReplace.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtReplace.ScrollBars")));
			this.txtReplace.Size = ((System.Drawing.Size)(resources.GetObject("txtReplace.Size")));
			this.txtReplace.TabIndex = ((int)(resources.GetObject("txtReplace.TabIndex")));
			this.txtReplace.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtReplace.TextAlign")));
			this.txtReplace.WordWrap = ((bool)(resources.GetObject("txtReplace.WordWrap")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label2.BackgroundImageLayout")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Font = null;
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImageKey = resources.GetString("label2.ImageKey");
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			// 
			// cmdReplaceAll
			// 
			this.cmdReplaceAll.AccessibleDescription = null;
			this.cmdReplaceAll.AccessibleName = null;
			this.cmdReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdReplaceAll.Anchor")));
			this.cmdReplaceAll.AutoSize = ((bool)(resources.GetObject("cmdReplaceAll.AutoSize")));
			this.cmdReplaceAll.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdReplaceAll.AutoSizeMode")));
			this.cmdReplaceAll.BackgroundImage = null;
			this.cmdReplaceAll.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdReplaceAll.BackgroundImageLayout")));
			this.cmdReplaceAll.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdReplaceAll.Dock")));
			this.cmdReplaceAll.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdReplaceAll.FlatStyle")));
			this.cmdReplaceAll.Font = null;
			this.cmdReplaceAll.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdReplaceAll.ImageAlign")));
			this.cmdReplaceAll.ImageIndex = ((int)(resources.GetObject("cmdReplaceAll.ImageIndex")));
			this.cmdReplaceAll.ImageKey = resources.GetString("cmdReplaceAll.ImageKey");
			this.cmdReplaceAll.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdReplaceAll.ImeMode")));
			this.cmdReplaceAll.Location = ((System.Drawing.Point)(resources.GetObject("cmdReplaceAll.Location")));
			this.cmdReplaceAll.Name = "cmdReplaceAll";
			this.cmdReplaceAll.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdReplaceAll.RightToLeft")));
			this.cmdReplaceAll.Size = ((System.Drawing.Size)(resources.GetObject("cmdReplaceAll.Size")));
			this.cmdReplaceAll.TabIndex = ((int)(resources.GetObject("cmdReplaceAll.TabIndex")));
			this.cmdReplaceAll.Text = resources.GetString("cmdReplaceAll.Text");
			this.cmdReplaceAll.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdReplaceAll.TextAlign")));
			this.cmdReplaceAll.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdReplaceAll.TextImageRelation")));
			this.cmdReplaceAll.Click += new System.EventHandler(this.cmdReplaceAll_Click);
			// 
			// cmdReplace
			// 
			this.cmdReplace.AccessibleDescription = null;
			this.cmdReplace.AccessibleName = null;
			this.cmdReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdReplace.Anchor")));
			this.cmdReplace.AutoSize = ((bool)(resources.GetObject("cmdReplace.AutoSize")));
			this.cmdReplace.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdReplace.AutoSizeMode")));
			this.cmdReplace.BackgroundImage = null;
			this.cmdReplace.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdReplace.BackgroundImageLayout")));
			this.cmdReplace.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdReplace.Dock")));
			this.cmdReplace.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdReplace.FlatStyle")));
			this.cmdReplace.Font = null;
			this.cmdReplace.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdReplace.ImageAlign")));
			this.cmdReplace.ImageIndex = ((int)(resources.GetObject("cmdReplace.ImageIndex")));
			this.cmdReplace.ImageKey = resources.GetString("cmdReplace.ImageKey");
			this.cmdReplace.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdReplace.ImeMode")));
			this.cmdReplace.Location = ((System.Drawing.Point)(resources.GetObject("cmdReplace.Location")));
			this.cmdReplace.Name = "cmdReplace";
			this.cmdReplace.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdReplace.RightToLeft")));
			this.cmdReplace.Size = ((System.Drawing.Size)(resources.GetObject("cmdReplace.Size")));
			this.cmdReplace.TabIndex = ((int)(resources.GetObject("cmdReplace.TabIndex")));
			this.cmdReplace.Text = resources.GetString("cmdReplace.Text");
			this.cmdReplace.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdReplace.TextAlign")));
			this.cmdReplace.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdReplace.TextImageRelation")));
			this.cmdReplace.Click += new System.EventHandler(this.cmdReplace_Click);
			// 
			// chkCase
			// 
			this.chkCase.AccessibleDescription = null;
			this.chkCase.AccessibleName = null;
			this.chkCase.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkCase.Anchor")));
			this.chkCase.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkCase.Appearance")));
			this.chkCase.AutoSize = ((bool)(resources.GetObject("chkCase.AutoSize")));
			this.chkCase.BackgroundImage = null;
			this.chkCase.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkCase.BackgroundImageLayout")));
			this.chkCase.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCase.CheckAlign")));
			this.chkCase.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkCase.Dock")));
			this.chkCase.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkCase.FlatStyle")));
			this.chkCase.Font = null;
			this.chkCase.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCase.ImageAlign")));
			this.chkCase.ImageIndex = ((int)(resources.GetObject("chkCase.ImageIndex")));
			this.chkCase.ImageKey = resources.GetString("chkCase.ImageKey");
			this.chkCase.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkCase.ImeMode")));
			this.chkCase.Location = ((System.Drawing.Point)(resources.GetObject("chkCase.Location")));
			this.chkCase.Name = "chkCase";
			this.chkCase.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkCase.RightToLeft")));
			this.chkCase.Size = ((System.Drawing.Size)(resources.GetObject("chkCase.Size")));
			this.chkCase.TabIndex = ((int)(resources.GetObject("chkCase.TabIndex")));
			this.chkCase.Text = resources.GetString("chkCase.Text");
			this.chkCase.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCase.TextAlign")));
			this.chkCase.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkCase.TextImageRelation")));
			// 
			// chkWordOnly
			// 
			this.chkWordOnly.AccessibleDescription = null;
			this.chkWordOnly.AccessibleName = null;
			this.chkWordOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkWordOnly.Anchor")));
			this.chkWordOnly.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkWordOnly.Appearance")));
			this.chkWordOnly.AutoSize = ((bool)(resources.GetObject("chkWordOnly.AutoSize")));
			this.chkWordOnly.BackgroundImage = null;
			this.chkWordOnly.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkWordOnly.BackgroundImageLayout")));
			this.chkWordOnly.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkWordOnly.CheckAlign")));
			this.chkWordOnly.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkWordOnly.Dock")));
			this.chkWordOnly.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkWordOnly.FlatStyle")));
			this.chkWordOnly.Font = null;
			this.chkWordOnly.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkWordOnly.ImageAlign")));
			this.chkWordOnly.ImageIndex = ((int)(resources.GetObject("chkWordOnly.ImageIndex")));
			this.chkWordOnly.ImageKey = resources.GetString("chkWordOnly.ImageKey");
			this.chkWordOnly.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkWordOnly.ImeMode")));
			this.chkWordOnly.Location = ((System.Drawing.Point)(resources.GetObject("chkWordOnly.Location")));
			this.chkWordOnly.Name = "chkWordOnly";
			this.chkWordOnly.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkWordOnly.RightToLeft")));
			this.chkWordOnly.Size = ((System.Drawing.Size)(resources.GetObject("chkWordOnly.Size")));
			this.chkWordOnly.TabIndex = ((int)(resources.GetObject("chkWordOnly.TabIndex")));
			this.chkWordOnly.Text = resources.GetString("chkWordOnly.Text");
			this.chkWordOnly.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkWordOnly.TextAlign")));
			this.chkWordOnly.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkWordOnly.TextImageRelation")));
			// 
			// cmdCancel
			// 
			this.cmdCancel.AccessibleDescription = null;
			this.cmdCancel.AccessibleName = null;
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdCancel.Anchor")));
			this.cmdCancel.AutoSize = ((bool)(resources.GetObject("cmdCancel.AutoSize")));
			this.cmdCancel.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdCancel.AutoSizeMode")));
			this.cmdCancel.BackgroundImage = null;
			this.cmdCancel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdCancel.BackgroundImageLayout")));
			this.cmdCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdCancel.Dock")));
			this.cmdCancel.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdCancel.FlatStyle")));
			this.cmdCancel.Font = null;
			this.cmdCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdCancel.ImageAlign")));
			this.cmdCancel.ImageIndex = ((int)(resources.GetObject("cmdCancel.ImageIndex")));
			this.cmdCancel.ImageKey = resources.GetString("cmdCancel.ImageKey");
			this.cmdCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdCancel.ImeMode")));
			this.cmdCancel.Location = ((System.Drawing.Point)(resources.GetObject("cmdCancel.Location")));
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdCancel.RightToLeft")));
			this.cmdCancel.Size = ((System.Drawing.Size)(resources.GetObject("cmdCancel.Size")));
			this.cmdCancel.TabIndex = ((int)(resources.GetObject("cmdCancel.TabIndex")));
			this.cmdCancel.Text = resources.GetString("cmdCancel.Text");
			this.cmdCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdCancel.TextAlign")));
			this.cmdCancel.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdCancel.TextImageRelation")));
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdSearchAgain
			// 
			this.cmdSearchAgain.AccessibleDescription = null;
			this.cmdSearchAgain.AccessibleName = null;
			this.cmdSearchAgain.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdSearchAgain.Anchor")));
			this.cmdSearchAgain.AutoSize = ((bool)(resources.GetObject("cmdSearchAgain.AutoSize")));
			this.cmdSearchAgain.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdSearchAgain.AutoSizeMode")));
			this.cmdSearchAgain.BackgroundImage = null;
			this.cmdSearchAgain.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdSearchAgain.BackgroundImageLayout")));
			this.cmdSearchAgain.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdSearchAgain.Dock")));
			this.cmdSearchAgain.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdSearchAgain.FlatStyle")));
			this.cmdSearchAgain.Font = null;
			this.cmdSearchAgain.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdSearchAgain.ImageAlign")));
			this.cmdSearchAgain.ImageIndex = ((int)(resources.GetObject("cmdSearchAgain.ImageIndex")));
			this.cmdSearchAgain.ImageKey = resources.GetString("cmdSearchAgain.ImageKey");
			this.cmdSearchAgain.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdSearchAgain.ImeMode")));
			this.cmdSearchAgain.Location = ((System.Drawing.Point)(resources.GetObject("cmdSearchAgain.Location")));
			this.cmdSearchAgain.Name = "cmdSearchAgain";
			this.cmdSearchAgain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdSearchAgain.RightToLeft")));
			this.cmdSearchAgain.Size = ((System.Drawing.Size)(resources.GetObject("cmdSearchAgain.Size")));
			this.cmdSearchAgain.TabIndex = ((int)(resources.GetObject("cmdSearchAgain.TabIndex")));
			this.cmdSearchAgain.Text = resources.GetString("cmdSearchAgain.Text");
			this.cmdSearchAgain.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdSearchAgain.TextAlign")));
			this.cmdSearchAgain.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdSearchAgain.TextImageRelation")));
			this.cmdSearchAgain.Click += new System.EventHandler(this.cmdSearchAgain_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.AccessibleDescription = null;
			this.txtSearch.AccessibleName = null;
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtSearch.Anchor")));
			this.txtSearch.BackgroundImage = null;
			this.txtSearch.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtSearch.BackgroundImageLayout")));
			this.txtSearch.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtSearch.Dock")));
			this.txtSearch.Font = null;
			this.txtSearch.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtSearch.ImeMode")));
			this.txtSearch.Location = ((System.Drawing.Point)(resources.GetObject("txtSearch.Location")));
			this.txtSearch.MaxLength = ((int)(resources.GetObject("txtSearch.MaxLength")));
			this.txtSearch.Multiline = ((bool)(resources.GetObject("txtSearch.Multiline")));
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.PasswordChar = ((char)(resources.GetObject("txtSearch.PasswordChar")));
			this.txtSearch.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtSearch.RightToLeft")));
			this.txtSearch.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtSearch.ScrollBars")));
			this.txtSearch.Size = ((System.Drawing.Size)(resources.GetObject("txtSearch.Size")));
			this.txtSearch.TabIndex = ((int)(resources.GetObject("txtSearch.TabIndex")));
			this.txtSearch.Text = resources.GetString("txtSearch.Text");
			this.txtSearch.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtSearch.TextAlign")));
			this.txtSearch.WordWrap = ((bool)(resources.GetObject("txtSearch.WordWrap")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label1.BackgroundImageLayout")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Font = null;
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImageKey = resources.GetString("label1.ImageKey");
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			// 
			// Replace
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
			this.Controls.Add(this.txtReplace);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmdReplaceAll);
			this.Controls.Add(this.cmdReplace);
			this.Controls.Add(this.chkCase);
			this.Controls.Add(this.chkWordOnly);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdSearchAgain);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.label1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "Replace";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button cmdSearchAgain;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.CheckBox chkWordOnly;
		private System.Windows.Forms.CheckBox chkCase;
		private System.Windows.Forms.Button cmdReplace;
		private System.Windows.Forms.Button cmdReplaceAll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtReplace;
	}
}
