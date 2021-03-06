﻿/*
 * Created by SharpDevelop.
 * User: Peter Dimov
 * Date: 14.12.2006
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nGenerator
{
	partial class Info : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lnkItesys = new System.Windows.Forms.LinkLabel();
			this.lblAllRights = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = resources.GetString("pictureBox1.AccessibleDescription");
			this.pictureBox1.AccessibleName = resources.GetString("pictureBox1.AccessibleName");
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pictureBox1.Anchor")));
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pictureBox1.BackgroundImageLayout")));
			this.pictureBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pictureBox1.Dock")));
			this.pictureBox1.Font = ((System.Drawing.Font)(resources.GetObject("pictureBox1.Font")));
			this.pictureBox1.ImageLocation = resources.GetString("pictureBox1.ImageLocation");
			this.pictureBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pictureBox1.ImeMode")));
			this.pictureBox1.Location = ((System.Drawing.Point)(resources.GetObject("pictureBox1.Location")));
			this.pictureBox1.MaximumSize = ((System.Drawing.Size)(resources.GetObject("pictureBox1.MaximumSize")));
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pictureBox1.RightToLeft")));
			this.pictureBox1.Size = ((System.Drawing.Size)(resources.GetObject("pictureBox1.Size")));
			this.pictureBox1.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("pictureBox1.SizeMode")));
			this.pictureBox1.TabIndex = ((int)(resources.GetObject("pictureBox1.TabIndex")));
			this.pictureBox1.TabStop = false;
			this.pictureBox1.WaitOnLoad = ((bool)(resources.GetObject("pictureBox1.WaitOnLoad")));
			// 
			// lnkItesys
			// 
			this.lnkItesys.AccessibleDescription = resources.GetString("lnkItesys.AccessibleDescription");
			this.lnkItesys.AccessibleName = resources.GetString("lnkItesys.AccessibleName");
			this.lnkItesys.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lnkItesys.Anchor")));
			this.lnkItesys.AutoSize = ((bool)(resources.GetObject("lnkItesys.AutoSize")));
			this.lnkItesys.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lnkItesys.BackgroundImageLayout")));
			this.lnkItesys.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lnkItesys.Dock")));
			this.lnkItesys.Font = ((System.Drawing.Font)(resources.GetObject("lnkItesys.Font")));
			this.lnkItesys.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lnkItesys.ImageAlign")));
			this.lnkItesys.ImageIndex = ((int)(resources.GetObject("lnkItesys.ImageIndex")));
			this.lnkItesys.ImageKey = resources.GetString("lnkItesys.ImageKey");
			this.lnkItesys.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lnkItesys.ImeMode")));
			this.lnkItesys.Location = ((System.Drawing.Point)(resources.GetObject("lnkItesys.Location")));
			this.lnkItesys.MaximumSize = ((System.Drawing.Size)(resources.GetObject("lnkItesys.MaximumSize")));
			this.lnkItesys.Name = "lnkItesys";
			this.lnkItesys.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lnkItesys.RightToLeft")));
			this.lnkItesys.Size = ((System.Drawing.Size)(resources.GetObject("lnkItesys.Size")));
			this.lnkItesys.TabIndex = ((int)(resources.GetObject("lnkItesys.TabIndex")));
			this.lnkItesys.TabStop = true;
			this.lnkItesys.Text = resources.GetString("lnkItesys.Text");
			this.lnkItesys.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lnkItesys.TextAlign")));
			// 
			// lblAllRights
			// 
			this.lblAllRights.AccessibleDescription = resources.GetString("lblAllRights.AccessibleDescription");
			this.lblAllRights.AccessibleName = resources.GetString("lblAllRights.AccessibleName");
			this.lblAllRights.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblAllRights.Anchor")));
			this.lblAllRights.AutoSize = ((bool)(resources.GetObject("lblAllRights.AutoSize")));
			this.lblAllRights.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblAllRights.BackgroundImageLayout")));
			this.lblAllRights.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblAllRights.Dock")));
			this.lblAllRights.Font = ((System.Drawing.Font)(resources.GetObject("lblAllRights.Font")));
			this.lblAllRights.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAllRights.ImageAlign")));
			this.lblAllRights.ImageIndex = ((int)(resources.GetObject("lblAllRights.ImageIndex")));
			this.lblAllRights.ImageKey = resources.GetString("lblAllRights.ImageKey");
			this.lblAllRights.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblAllRights.ImeMode")));
			this.lblAllRights.Location = ((System.Drawing.Point)(resources.GetObject("lblAllRights.Location")));
			this.lblAllRights.MaximumSize = ((System.Drawing.Size)(resources.GetObject("lblAllRights.MaximumSize")));
			this.lblAllRights.Name = "lblAllRights";
			this.lblAllRights.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblAllRights.RightToLeft")));
			this.lblAllRights.Size = ((System.Drawing.Size)(resources.GetObject("lblAllRights.Size")));
			this.lblAllRights.TabIndex = ((int)(resources.GetObject("lblAllRights.TabIndex")));
			this.lblAllRights.Text = resources.GetString("lblAllRights.Text");
			this.lblAllRights.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAllRights.TextAlign")));
			// 
			// lblCopyright
			// 
			this.lblCopyright.AccessibleDescription = resources.GetString("lblCopyright.AccessibleDescription");
			this.lblCopyright.AccessibleName = resources.GetString("lblCopyright.AccessibleName");
			this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblCopyright.Anchor")));
			this.lblCopyright.AutoSize = ((bool)(resources.GetObject("lblCopyright.AutoSize")));
			this.lblCopyright.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblCopyright.BackgroundImageLayout")));
			this.lblCopyright.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblCopyright.Dock")));
			this.lblCopyright.Font = ((System.Drawing.Font)(resources.GetObject("lblCopyright.Font")));
			this.lblCopyright.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblCopyright.ImageAlign")));
			this.lblCopyright.ImageIndex = ((int)(resources.GetObject("lblCopyright.ImageIndex")));
			this.lblCopyright.ImageKey = resources.GetString("lblCopyright.ImageKey");
			this.lblCopyright.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblCopyright.ImeMode")));
			this.lblCopyright.Location = ((System.Drawing.Point)(resources.GetObject("lblCopyright.Location")));
			this.lblCopyright.MaximumSize = ((System.Drawing.Size)(resources.GetObject("lblCopyright.MaximumSize")));
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblCopyright.RightToLeft")));
			this.lblCopyright.Size = ((System.Drawing.Size)(resources.GetObject("lblCopyright.Size")));
			this.lblCopyright.TabIndex = ((int)(resources.GetObject("lblCopyright.TabIndex")));
			this.lblCopyright.Text = resources.GetString("lblCopyright.Text");
			this.lblCopyright.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblCopyright.TextAlign")));
			// 
			// lblVersion
			// 
			this.lblVersion.AccessibleDescription = resources.GetString("lblVersion.AccessibleDescription");
			this.lblVersion.AccessibleName = resources.GetString("lblVersion.AccessibleName");
			this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblVersion.Anchor")));
			this.lblVersion.AutoSize = ((bool)(resources.GetObject("lblVersion.AutoSize")));
			this.lblVersion.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblVersion.BackgroundImageLayout")));
			this.lblVersion.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblVersion.Dock")));
			this.lblVersion.Font = ((System.Drawing.Font)(resources.GetObject("lblVersion.Font")));
			this.lblVersion.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblVersion.ImageAlign")));
			this.lblVersion.ImageIndex = ((int)(resources.GetObject("lblVersion.ImageIndex")));
			this.lblVersion.ImageKey = resources.GetString("lblVersion.ImageKey");
			this.lblVersion.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblVersion.ImeMode")));
			this.lblVersion.Location = ((System.Drawing.Point)(resources.GetObject("lblVersion.Location")));
			this.lblVersion.MaximumSize = ((System.Drawing.Size)(resources.GetObject("lblVersion.MaximumSize")));
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblVersion.RightToLeft")));
			this.lblVersion.Size = ((System.Drawing.Size)(resources.GetObject("lblVersion.Size")));
			this.lblVersion.TabIndex = ((int)(resources.GetObject("lblVersion.TabIndex")));
			this.lblVersion.Text = resources.GetString("lblVersion.Text");
			this.lblVersion.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblVersion.TextAlign")));
			// 
			// lblName
			// 
			this.lblName.AccessibleDescription = resources.GetString("lblName.AccessibleDescription");
			this.lblName.AccessibleName = resources.GetString("lblName.AccessibleName");
			this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblName.Anchor")));
			this.lblName.AutoSize = ((bool)(resources.GetObject("lblName.AutoSize")));
			this.lblName.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblName.BackgroundImageLayout")));
			this.lblName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblName.Dock")));
			this.lblName.Font = ((System.Drawing.Font)(resources.GetObject("lblName.Font")));
			this.lblName.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblName.ImageAlign")));
			this.lblName.ImageIndex = ((int)(resources.GetObject("lblName.ImageIndex")));
			this.lblName.ImageKey = resources.GetString("lblName.ImageKey");
			this.lblName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblName.ImeMode")));
			this.lblName.Location = ((System.Drawing.Point)(resources.GetObject("lblName.Location")));
			this.lblName.MaximumSize = ((System.Drawing.Size)(resources.GetObject("lblName.MaximumSize")));
			this.lblName.Name = "lblName";
			this.lblName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblName.RightToLeft")));
			this.lblName.Size = ((System.Drawing.Size)(resources.GetObject("lblName.Size")));
			this.lblName.TabIndex = ((int)(resources.GetObject("lblName.TabIndex")));
			this.lblName.Text = resources.GetString("lblName.Text");
			this.lblName.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblName.TextAlign")));
			// 
			// Info
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleDimensions = ((System.Drawing.SizeF)(resources.GetObject("$this.AutoScaleDimensions")));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.lnkItesys);
			this.Controls.Add(this.lblAllRights);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.pictureBox1);
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "Info";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblCopyright;
		private System.Windows.Forms.Label lblAllRights;
		private System.Windows.Forms.LinkLabel lnkItesys;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
