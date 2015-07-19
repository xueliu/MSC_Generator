using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WorkingWithDialogs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
				if (components != null) 
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.button1.Location = new System.Drawing.Point(40, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Modal";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.button2.Location = new System.Drawing.Point(160, 16);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Modeless";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 55);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(292, 22);
			this.statusBar1.TabIndex = 2;
			this.statusBar1.Text = "Ready...";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(292, 77);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "The Main Form";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			CustomerDialog myCustomerDialog = new CustomerDialog();
			if (myCustomerDialog.ShowDialog() == DialogResult.OK)
			{
				ShowCustomerName(myCustomerDialog);
			}
		}

		public void ShowCustomerName(CustomerDialog myCustomerDialog)
		{
			statusBar1.Text = myCustomerDialog.txtName.Text;
//			MessageBox.Show(myCustomerDialog.txtName.Text + " was entered into the database");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			CustomerDialog myCustomerDialog = new CustomerDialog(this);
			myCustomerDialog.Show();
		}
	}
}
