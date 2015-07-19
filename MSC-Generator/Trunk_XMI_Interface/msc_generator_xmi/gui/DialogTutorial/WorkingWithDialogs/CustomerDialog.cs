using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WorkingWithDialogs
{
	/// <summary>
	/// Summary description for CustomerDialog.
	/// </summary>
	public class CustomerDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button MyCancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.TextBox txtEmail;
		public System.Windows.Forms.TextBox txtPhone;
		public System.Windows.Forms.TextBox txtFavoriteColor;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomerDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		Form1 TheParentForm = null;
		public CustomerDialog(Form1 parent)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			TheParentForm = parent;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OKButton = new System.Windows.Forms.Button();
			this.MyCancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtFavoriteColor = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(64, 168);
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// MyCancelButton
			// 
			this.MyCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.MyCancelButton.Location = new System.Drawing.Point(192, 168);
			this.MyCancelButton.Name = "MyCancelButton";
			this.MyCancelButton.TabIndex = 1;
			this.MyCancelButton.Text = "Cancel";
			this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Email:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Phone:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label4.Location = new System.Drawing.Point(8, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "Favorite Color:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(136, 24);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(128, 20);
			this.txtName.TabIndex = 6;
			this.txtName.Text = "";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(136, 56);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(128, 20);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.Text = "";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(136, 88);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(128, 20);
			this.txtPhone.TabIndex = 8;
			this.txtPhone.Text = "";
			// 
			// txtFavoriteColor
			// 
			this.txtFavoriteColor.Location = new System.Drawing.Point(136, 120);
			this.txtFavoriteColor.Name = "txtFavoriteColor";
			this.txtFavoriteColor.Size = new System.Drawing.Size(128, 20);
			this.txtFavoriteColor.TabIndex = 9;
			this.txtFavoriteColor.Text = "";
			// 
			// CustomerDialog
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.MyCancelButton;
			this.ClientSize = new System.Drawing.Size(314, 207);
			this.Controls.Add(this.txtFavoriteColor);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MyCancelButton);
			this.Controls.Add(this.OKButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "CustomerDialog";
			this.Text = "CustomerDialog";
			this.ResumeLayout(false);

		}
		#endregion

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			OKButton.DialogResult = DialogResult.OK;
			TheParentForm.ShowCustomerName(this);
			Close();
		}

		private void MyCancelButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
