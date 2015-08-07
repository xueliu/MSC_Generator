/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 04.04.2006
 * Time: 12:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IProp
{
	/// <summary>
	/// Description of Name.
	/// </summary>
	//public delegate void AcceptClickEventHandler(object sender, EventArgs e);
	
	public class IPropName : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdClose;
		private System.Windows.Forms.Label lblTitel;
		
		//public event AcceptClickEventHandler OnAcceptClick;
		public event EventHandler OnAcceptClick;
		public event EventHandler OnCancelClick;
		public event EventHandler OnCloseClick;
		
		public IPropName()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public Size IPropSize{
			get{
				return this.Size;
			}
		}
		public string IPropText{
			get{
				return this.txtText.Text;
			}
			set{
				this.txtText.Text = value;
			}
		}
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.lblTitel = new System.Windows.Forms.Label();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.txtText = new System.Windows.Forms.TextBox();
			this.cmdAccept = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTitel
			// 
			this.lblTitel.Location = new System.Drawing.Point(8, 8);
			this.lblTitel.Name = "lblTitel";
			this.lblTitel.Size = new System.Drawing.Size(504, 12);
			this.lblTitel.TabIndex = 5;
			// 
			// cmdClose
			// 
			this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClose.Location = new System.Drawing.Point(516, 4);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(20, 16);
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "X";
			this.cmdClose.Click += new System.EventHandler(this.CmdCloseClick);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.Location = new System.Drawing.Point(444, 48);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(92, 20);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "Abbruch";
			this.cmdCancel.Click += new System.EventHandler(this.CmdCancelClick);
			// 
			// txtText
			// 
			this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtText.Location = new System.Drawing.Point(48, 24);
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(388, 22);
			this.txtText.TabIndex = 1;
			this.txtText.Text = "";
			// 
			// cmdAccept
			// 
			this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAccept.Location = new System.Drawing.Point(444, 24);
			this.cmdAccept.Name = "cmdAccept";
			this.cmdAccept.Size = new System.Drawing.Size(92, 20);
			this.cmdAccept.TabIndex = 3;
			this.cmdAccept.Text = "Übernehmen";
			this.cmdAccept.Click += new System.EventHandler(this.CmdAcceptClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text";
			// 
			// IPropName
			// 
			this.Controls.Add(this.lblTitel);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdAccept);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.label1);
			this.Name = "IPropName";
			this.Size = new System.Drawing.Size(540, 136);
			this.ResumeLayout(false);
		}
		#endregion
		void CmdAcceptClick(object sender, System.EventArgs e)
		{
			if (OnAcceptClick != null) OnAcceptClick(this, new EventArgs());
		}
		
		void CmdCancelClick(object sender, System.EventArgs e)
		{
			if (OnCancelClick != null) OnCancelClick(this, new EventArgs());			
		}
		
		void CmdCloseClick(object sender, System.EventArgs e)
		{
			if (OnCloseClick != null) OnCloseClick(this, new EventArgs());			
		}
		
	}
}
