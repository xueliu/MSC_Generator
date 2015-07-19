/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 30.05.2005
 * Time: 08:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using LicenseKey;

namespace nGenerator
{
	/// <summary>
	/// Description of Start.
	/// </summary>
	public class Start : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer tmrTimeout;
		private System.Windows.Forms.PictureBox pictureBox1;
		
		private string mCompany1 = string.Empty;
		private string mCompany2 = string.Empty;
		private LicenseType mLicenseType = LicenseType.Free;
		private ulong mLicenseNumber = 0;
		private ValidResult mValidResult;
		
		public Start(string company1, string company2, LicenseType licenseType, ulong licenseNumber, ValidResult validResult)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			mCompany1 = company1;
			mCompany2 = company2;
			mLicenseType = licenseType;
			mLicenseNumber = licenseNumber;
			mValidResult = validResult;
			InitializeComponent();
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tmrTimeout = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = null;
			this.pictureBox1.AccessibleName = null;
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pictureBox1.Anchor")));
			this.pictureBox1.BackgroundImage = null;
			this.pictureBox1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pictureBox1.BackgroundImageLayout")));
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pictureBox1.Dock")));
			this.pictureBox1.Font = null;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.ImageLocation = null;
			this.pictureBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pictureBox1.ImeMode")));
			this.pictureBox1.Location = ((System.Drawing.Point)(resources.GetObject("pictureBox1.Location")));
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pictureBox1.RightToLeft")));
			this.pictureBox1.Size = ((System.Drawing.Size)(resources.GetObject("pictureBox1.Size")));
			this.pictureBox1.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("pictureBox1.SizeMode")));
			this.pictureBox1.TabIndex = ((int)(resources.GetObject("pictureBox1.TabIndex")));
			this.pictureBox1.TabStop = false;
			this.pictureBox1.WaitOnLoad = ((bool)(resources.GetObject("pictureBox1.WaitOnLoad")));
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PicStartRedraw);
			// 
			// tmrTimeout
			// 
			this.tmrTimeout.Enabled = true;
			this.tmrTimeout.Interval = 50000;
			this.tmrTimeout.Tick += new System.EventHandler(this.tmrTimeoutTick);
			// 
			// Start
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BackgroundImage = null;
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.pictureBox1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "Start";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		void tmrTimeoutTick(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		
		void PictureBox1Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		private void PicStartRedraw(object sender, PaintEventArgs e)
		{
			ResourceManager strings = new ResourceManager ("nGenerator.strings", Assembly.GetAssembly(typeof(Start)));
			RectangleF itemBox = new RectangleF(250, 160, 420, 400);
			e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.DrawString("MSC-SD-Generator",new Font("Arial",24,FontStyle.Bold,GraphicsUnit.Point),Brushes.Black,itemBox);
			itemBox = new RectangleF(400, 200, 400, 400);
			e.Graphics.DrawString("Version 1.1",new Font("Arial",16,FontStyle.Bold,GraphicsUnit.Point),Brushes.Black,itemBox);
			itemBox = new RectangleF(490, 0, 500, 400);
			e.Graphics.DrawString("Build " + Application.ProductVersion,new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
			if ((mValidResult == ValidResult.NoLicensed)||(mLicenseType == LicenseType.Demo)){
				itemBox = new RectangleF(2, 330, 400, 400);
				e.Graphics.DrawString(strings.GetString("Demoversion"),new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
			}
			else{
				float yPos = 345.0f;	
				if (mLicenseType == LicenseType.NonCommercial){
					itemBox = new RectangleF(2, yPos, 400, 400);
					e.Graphics.DrawString(strings.GetString("NotCommercialUse"),new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
					yPos -=15.0f;
				}
				if (mCompany2.Length > 0){
					itemBox = new RectangleF(80, yPos, 400, 400);					
					e.Graphics.DrawString(mCompany2,new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
					yPos -=15.0f;
				}
				itemBox = new RectangleF(2, yPos, 400, 400);
				e.Graphics.DrawString(strings.GetString("LicensedTo"),new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
				itemBox = new RectangleF(80, yPos, 400, 400);
				e.Graphics.DrawString(mCompany1,new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
				yPos -=15.0f;				
				itemBox = new RectangleF(2, yPos, 400, 400);
				e.Graphics.DrawString(strings.GetString("LicenseNr"),new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
				itemBox = new RectangleF(80, yPos, 400, 400);
				e.Graphics.DrawString(mLicenseNumber.ToString().Substring(0,4) + "-" + mLicenseNumber.ToString().Substring(4,4) + "-" + mLicenseNumber.ToString().Substring(8,4),new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point),Brushes.Black,itemBox);
			}
		}
	}
}
