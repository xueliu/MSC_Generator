/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 21.05.2005
 * Time: 06:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace mscGenerator
{
	/// <summary>
	/// Description of WorkSheetOptions.
	/// </summary>
	public class WorkSheetOptions : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblPictureSize;
		private System.Windows.Forms.TabControl tabOptions;
		private System.Windows.Forms.Panel pnlPreview;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.RadioButton optLayoutV;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.ComboBox cboPictureSize;
		private System.Windows.Forms.GroupBox fraLayout;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox fraPreview;
		private System.Windows.Forms.ComboBox cboUnits;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblUnit;
		private System.Windows.Forms.RadioButton optLayoutH;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.Button cmdOk;
		public const uint MAX_WIDTH = 4000;
		public const uint MAX_HEIGHT = 4000;
		public const uint MIN_WIDTH = 400;
		public const uint MIN_HEIGHT = 400;
		
		
		private Worksheet worksheet;
		private byte size, layout, unit;
		private float sheetWidth, sheetHeight;
		private Output parent;
		public WorkSheetOptions(Worksheet w, Output o)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			worksheet = w;
			InitializeComponent();
			initializeValues();
			parent = o;
		}
		
		private void initializeValues()
		{
			string[] values = new string[0];
			float size;
			worksheet.getUnits(ref values);
			for(int i=0;i<values.GetLength(0);i++){
				this.cboUnits.Items.Add(values[i]);
			}
			if (worksheet.layout==Worksheet.WS_LAYOUT_HORIZONTAL)
				this.optLayoutH.Select();
			if (worksheet.layout==Worksheet.WS_LAYOUT_VERTICAL)
				this.optLayoutV.Select();
			this.cboUnits.SelectedIndex=worksheet.unit;
			this.cboUnits.DropDownStyle = ComboBoxStyle.DropDownList;
			this.unit = worksheet.unit;
			
			worksheet.getSizes(ref values);
			for(int i=0;i<values.GetLength(0);i++){
				this.cboPictureSize.Items.Add(values[i]);
			}
			this.cboPictureSize.SelectedIndex=worksheet.size;
			this.cboPictureSize.DropDownStyle = ComboBoxStyle.DropDownList;
			this.size = worksheet.size;
			
			this.layout = worksheet.layout;
			
			setSize();
			
			size = worksheet.calcSize(worksheet.width, Worksheet.WS_UNIT_PICSEL, worksheet.unit);
			size = (float)Math.Round(size,2);
			this.txtWidth.Text = size.ToString();
			this.sheetWidth = size;
			
			size = worksheet.calcSize(worksheet.height, Worksheet.WS_UNIT_PICSEL, worksheet.unit);
			size = (float)Math.Round(size,2);
			this.txtHeight.Text = size.ToString();
			this.sheetHeight = size;
			
			this.showPreview();
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.cmdOk = new System.Windows.Forms.Button();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.optLayoutH = new System.Windows.Forms.RadioButton();
			this.lblUnit = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.cboUnits = new System.Windows.Forms.ComboBox();
			this.fraPreview = new System.Windows.Forms.GroupBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.fraLayout = new System.Windows.Forms.GroupBox();
			this.cboPictureSize = new System.Windows.Forms.ComboBox();
			this.lblWidth = new System.Windows.Forms.Label();
			this.optLayoutV = new System.Windows.Forms.RadioButton();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lblHeight = new System.Windows.Forms.Label();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.tabOptions = new System.Windows.Forms.TabControl();
			this.lblPictureSize = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.fraPreview.SuspendLayout();
			this.fraLayout.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(260, 212);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(80, 24);
			this.cmdOk.TabIndex = 1;
			this.cmdOk.Text = "OK";
			this.cmdOk.Click += new System.EventHandler(this.CmdOkClick);
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(84, 76);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(84, 20);
			this.txtHeight.TabIndex = 11;
			this.txtHeight.Text = "textBox2";
			this.txtHeight.Leave += new System.EventHandler(this.txtHeightChanged);
			// 
			// optLayoutH
			// 
			this.optLayoutH.Location = new System.Drawing.Point(72, 40);
			this.optLayoutH.Name = "optLayoutH";
			this.optLayoutH.Size = new System.Drawing.Size(84, 20);
			this.optLayoutH.TabIndex = 1;
			this.optLayoutH.Text = "Querformat";
			this.optLayoutH.CheckedChanged += new System.EventHandler(this.OptLayoutHCheckedChanged);
			// 
			// lblUnit
			// 
			this.lblUnit.Location = new System.Drawing.Point(328, 4);
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.Size = new System.Drawing.Size(72, 16);
			this.lblUnit.TabIndex = 8;
			this.lblUnit.Text = "Einheiten:";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Controls.Add(this.pnlPreview);
			this.panel1.Location = new System.Drawing.Point(8, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(128, 128);
			this.panel1.TabIndex = 0;
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(84, 52);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(84, 20);
			this.txtWidth.TabIndex = 10;
			this.txtWidth.Text = "textBox1";
			this.txtWidth.Leave += new System.EventHandler(this.txtWidthChanged);
			// 
			// cboUnits
			// 
			this.cboUnits.Location = new System.Drawing.Point(328, 24);
			this.cboUnits.Name = "cboUnits";
			this.cboUnits.Size = new System.Drawing.Size(84, 21);
			this.cboUnits.TabIndex = 9;
			this.cboUnits.SelectedIndexChanged += new System.EventHandler(this.CboUnitsSelectedIndexChanged);
			// 
			// fraPreview
			// 
			this.fraPreview.Controls.Add(this.panel1);
			this.fraPreview.Location = new System.Drawing.Point(176, 4);
			this.fraPreview.Name = "fraPreview";
			this.fraPreview.Size = new System.Drawing.Size(144, 164);
			this.fraPreview.TabIndex = 7;
			this.fraPreview.TabStop = false;
			this.fraPreview.Text = "Vorschau";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(348, 212);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Abbrechen";
			this.cmdCancel.Click += new System.EventHandler(this.CmdCancelClick);
			// 
			// fraLayout
			// 
			this.fraLayout.Controls.Add(this.optLayoutH);
			this.fraLayout.Controls.Add(this.optLayoutV);
			this.fraLayout.Location = new System.Drawing.Point(4, 104);
			this.fraLayout.Name = "fraLayout";
			this.fraLayout.Size = new System.Drawing.Size(164, 64);
			this.fraLayout.TabIndex = 6;
			this.fraLayout.TabStop = false;
			this.fraLayout.Text = "Orientierung";
			// 
			// cboPictureSize
			// 
			this.cboPictureSize.Location = new System.Drawing.Point(4, 24);
			this.cboPictureSize.Name = "cboPictureSize";
			this.cboPictureSize.Size = new System.Drawing.Size(164, 21);
			this.cboPictureSize.TabIndex = 1;
			this.cboPictureSize.Text = " ";
			this.cboPictureSize.SelectedIndexChanged += new System.EventHandler(this.CboPictureSizeSelectedIndexChanged);
			// 
			// lblWidth
			// 
			this.lblWidth.Location = new System.Drawing.Point(4, 56);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(52, 20);
			this.lblWidth.TabIndex = 2;
			this.lblWidth.Text = "Breite:";
			// 
			// optLayoutV
			// 
			this.optLayoutV.Location = new System.Drawing.Point(72, 20);
			this.optLayoutV.Name = "optLayoutV";
			this.optLayoutV.Size = new System.Drawing.Size(84, 20);
			this.optLayoutV.TabIndex = 0;
			this.optLayoutV.Text = "Hochformat";
			this.optLayoutV.CheckedChanged += new System.EventHandler(this.OptLayoutVCheckedChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtHeight);
			this.tabPage1.Controls.Add(this.txtWidth);
			this.tabPage1.Controls.Add(this.cboUnits);
			this.tabPage1.Controls.Add(this.lblUnit);
			this.tabPage1.Controls.Add(this.fraPreview);
			this.tabPage1.Controls.Add(this.fraLayout);
			this.tabPage1.Controls.Add(this.lblHeight);
			this.tabPage1.Controls.Add(this.lblWidth);
			this.tabPage1.Controls.Add(this.cboPictureSize);
			this.tabPage1.Controls.Add(this.lblPictureSize);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(416, 178);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Arbeitsblatt";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(4, 80);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(48, 20);
			this.lblHeight.TabIndex = 3;
			this.lblHeight.Text = "Höhe:";
			// 
			// pnlPreview
			// 
			this.pnlPreview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pnlPreview.Location = new System.Drawing.Point(20, 20);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(88, 88);
			this.pnlPreview.TabIndex = 0;
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.tabPage1);
			this.tabOptions.Location = new System.Drawing.Point(4, 4);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.SelectedIndex = 0;
			this.tabOptions.Size = new System.Drawing.Size(424, 204);
			this.tabOptions.TabIndex = 0;
			// 
			// lblPictureSize
			// 
			this.lblPictureSize.Location = new System.Drawing.Point(4, 4);
			this.lblPictureSize.Name = "lblPictureSize";
			this.lblPictureSize.Size = new System.Drawing.Size(104, 20);
			this.lblPictureSize.TabIndex = 0;
			this.lblPictureSize.Text = "Bildgröße:";
			// 
			// WorkSheetOptions
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 239);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.tabOptions);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "WorkSheetOptions";
			this.Text = "Bild einrichten";
			this.panel1.ResumeLayout(false);
			this.fraPreview.ResumeLayout(false);
			this.fraLayout.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabOptions.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		void CboPictureSizeSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.cboPictureSize.SelectedIndex==Worksheet.WS_SIZE_A2_ISO){
				this.sheetWidth = worksheet.calcSize(Worksheet.WS_SIZE_A2_X,Worksheet.WS_UNIT_CM) ;
				this.sheetHeight = worksheet.calcSize(Worksheet.WS_SIZE_A2_Y,Worksheet.WS_UNIT_CM);
				
			}
			if (this.cboPictureSize.SelectedIndex==Worksheet.WS_SIZE_A3_ISO){
				this.sheetWidth = worksheet.calcSize(Worksheet.WS_SIZE_A3_X,Worksheet.WS_UNIT_CM) ;
				this.sheetHeight = worksheet.calcSize(Worksheet.WS_SIZE_A3_Y,Worksheet.WS_UNIT_CM);
				
			}
			if (this.cboPictureSize.SelectedIndex==Worksheet.WS_SIZE_A4_ISO){
				this.sheetWidth = worksheet.calcSize(Worksheet.WS_SIZE_A4_X,Worksheet.WS_UNIT_CM) ;
				this.sheetHeight = worksheet.calcSize(Worksheet.WS_SIZE_A4_Y,Worksheet.WS_UNIT_CM);
				
			}
			if (this.cboPictureSize.SelectedIndex==Worksheet.WS_SIZE_A5_ISO){
				this.sheetWidth = worksheet.calcSize(Worksheet.WS_SIZE_A5_X,Worksheet.WS_UNIT_CM) ;
				this.sheetHeight = worksheet.calcSize(Worksheet.WS_SIZE_A5_Y,Worksheet.WS_UNIT_CM);
				
			}
			if ((this.optLayoutH.Checked==true)&&(this.cboPictureSize.SelectedIndex!=Worksheet.WS_SIZE_USER_DEFINED)){
				float temp;
				temp = this.sheetWidth;
				this.sheetWidth = this.sheetHeight;
				this.sheetHeight = temp;
			}
			this.setSize();
		}
		
		void setSize()
		{
			this.txtWidth.Text = worksheet.calcSize(this.sheetWidth,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();
			this.txtHeight.Text = worksheet.calcSize(this.sheetHeight,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();			
			switch(this.cboUnits.SelectedIndex){
				case Worksheet.WS_UNIT_CM:
					this.txtWidth.Text += " cm";
					this.txtHeight.Text += " cm";
					break;
				case Worksheet.WS_UNIT_MM:
					this.txtWidth.Text += " mm";
					this.txtHeight.Text += " mm";
					break;
				case Worksheet.WS_UNIT_INCH:
					this.txtWidth.Text += " Zoll";
					this.txtHeight.Text += " Zoll";
					break;
			}
			this.showPreview();
		}
		
		void CboUnitsSelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.setSize();
		}
		void showPreview()
		{
			if (this.sheetWidth>this.sheetHeight){
				this.pnlPreview.Width = 108;
				this.pnlPreview.Height = (int)((this.sheetHeight/this.sheetWidth) * 108);
				this.pnlPreview.Left = 10;
				this.pnlPreview.Top = (int)((128-this.pnlPreview.Height)/2);
			}
			else{
				this.pnlPreview.Height = 108;
				this.pnlPreview.Width = (int)((this.sheetWidth/this.sheetHeight) * 108);
				this.pnlPreview.Top = 10;
				this.pnlPreview.Left = (int)((128-this.pnlPreview.Width)/2);
			}
		}
		
		void txtWidthChanged(object sender, System.EventArgs e)
		{
			float size;
			string s = String.Empty;
			char[] values;
			bool point = false;
			if (this.txtWidth.Modified){
				values = this.txtWidth.Text.ToCharArray();
				foreach(char c in values){
					if (Char.IsDigit(c))
						s += c;
					if ((c==',')&&(point==false)){
						s += c;
						point = true;
					}
				}
				if (s != String.Empty){
					size = (float) Convert.ToSingle(s);
					this.sheetWidth = Math.Max(worksheet.calcSize(size,(byte)this.cboUnits.SelectedIndex),MIN_WIDTH);
					this.sheetWidth = Math.Min(this.sheetWidth,MAX_WIDTH);
					this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_USER_DEFINED;
					this.setSize();
				}
			}
		}
		
		void txtHeightChanged(object sender, System.EventArgs e)
		{
			float size;
			string s = String.Empty;
			char[] values;
			bool point = false;
			if (this.txtHeight.Modified){
				values = this.txtHeight.Text.ToCharArray();
				foreach(char c in values){
					if (Char.IsDigit(c))
						s += c;
					if ((c==',')&&(point==false)){
						s += c;
						point = true;
					}
				}
				if (s != String.Empty){
					size = (float) Convert.ToSingle(s);
					this.sheetHeight = Math.Max(worksheet.calcSize(size,(byte)this.cboUnits.SelectedIndex),MIN_HEIGHT);
					this.sheetHeight = Math.Min(this.sheetHeight,MAX_HEIGHT);
					this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_USER_DEFINED;
					this.setSize();
				}
			}
		}
		
		void OptLayoutVCheckedChanged(object sender, System.EventArgs e)
		{
			float temp;
			temp = this.sheetWidth;
			this.sheetWidth = this.sheetHeight;
			this.sheetHeight = temp;
			this.setSize();

		}
		
		void CmdCancelClick(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		
		void CmdOkClick(object sender, System.EventArgs e)
		{
			worksheet.width = (int)this.sheetWidth;
			worksheet.height = (int)this.sheetHeight;
			worksheet.size = (byte)this.cboPictureSize.SelectedIndex;
			worksheet.unit = (byte)this.cboUnits.SelectedIndex;
			if (this.optLayoutH.Checked==true){
				worksheet.layout = Worksheet.WS_LAYOUT_HORIZONTAL;
			}
			else{
				worksheet.layout = Worksheet.WS_LAYOUT_VERTICAL;
			}
			parent.redrawRescaled();
			this.Dispose();
			
		}
		
		void OptLayoutHCheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		
	}
}
