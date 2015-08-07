/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of OptionsDialog.
	/// </summary>
	public partial class OptionsDialog
	{
        private static OptionsDialog activeDialog = null;							// reference to active dialog
        protected static Rectangle targetBounds = new Rectangle(0, 0, 500, 500);
        protected static Point dialogLocation = new Point (0,0);
        protected static Worksheet worksheet = new Worksheet();
        protected Worksheet optionWorksheet = new Worksheet();

        public virtual event EventHandler OnAcceptClick;
        protected bool changeByUpdate = false;
        protected bool chkShowFootlineChecked = true;
        protected bool cboUnitsIsActive = true;

		public OptionsDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            OwnInitializeComponent();
            InitializeValues();
            activeDialog = this;				// set reference to active dialog
            this.ShowPreview();
		}
		
		~OptionsDialog()
		{
			activeDialog = null;				// clear reference of active dialog
		}

        private void OwnInitializeComponent(){
            this.pnlPreview.Resize += new EventHandler(PnlPreview_Resize);
            this.pnlPreview.Paint += new PaintEventHandler(this.PreviewRedraw);
            this.optLayoutH.CheckedChanged += new EventHandler(OptLayoutH_CheckedChanged);
            this.optLayoutV.CheckedChanged += new EventHandler(OptLayoutV_CheckedChanged);
            this.txtHeight.KeyDown += new KeyEventHandler(TxtHeightKeyDown);
            this.txtWidth.KeyDown += new KeyEventHandler(TxtWidthKeyDown);
            this.txtWidth.LostFocus += new EventHandler(TxtWidthLostFocus);
            this.txtHeight.LostFocus += new EventHandler(TxtHeightLostFocus);
            this.txtLeftMargin.KeyDown += new KeyEventHandler(TxtLeftMarginKeyDown);
            this.txtLeftMargin.LostFocus += new EventHandler(TxtLeftMarginLostFocus);
            this.txtRightMargin.KeyDown += new KeyEventHandler(TxtRightMarginKeyDown);
            this.txtRightMargin.LostFocus += new EventHandler(TxtRightMarginLostFocus);
            this.txtTopMargin.KeyDown += new KeyEventHandler(TxtTopMarginKeyDown);
            this.txtTopMargin.LostFocus += new EventHandler(TxtTopMarginLostFocus);
            this.txtBottomMargin.KeyDown += new KeyEventHandler(TxtBottomMarginKeyDown);
            this.txtBottomMargin.LostFocus += new EventHandler(TxtBottomMarginLostFocus);
            this.Move += new EventHandler(DialogMove);
        }

        void PnlPreview_Resize(object sender, EventArgs e)
        {
            this.ShowPreview();
        }
		protected virtual void InitializeValues()
		{
           	string[] values = new string[0];
			float size;
			// localisation
			this.Shown += new System.EventHandler(this.ShowFirstTime);
//			this.Left = OptionsDialog.targetBounds.Right - this.Width;
//			this.Top = OptionsDialog.targetBounds.Y;
			this.Height = OptionsDialog.targetBounds.Height;
			optionWorksheet.WorksheetValues = worksheet.WorksheetValues;
			
			optionWorksheet.GetUnits(ref values);
			for(int i=0;i<values.GetLength(0);i++){
				this.cboUnits.Items.Add(values[i]);
			}
			
			this.cboUnits.SelectedIndex=optionWorksheet.Unit;
			this.cboUnits.DropDownStyle = ComboBoxStyle.DropDownList;
            
            if (optionWorksheet.Layout == Worksheet.WS_LAYOUT_HORIZONTAL)
                this.optLayoutH.Checked = true;
            else
                this.optLayoutV.Checked = true;
            
			optionWorksheet.GetSizes(ref values);
			for(int i=0;i<values.GetLength(0);i++){
				this.cboPictureSize.Items.Add(values[i]);
			}
			this.cboPictureSize.SelectedIndex= optionWorksheet.Size;
			this.cboPictureSize.DropDownStyle = ComboBoxStyle.DropDownList;
			
			size = optionWorksheet.CalcSize(optionWorksheet.Width, Worksheet.WS_UNIT_PICSEL, optionWorksheet.Unit);
			size = (float)Math.Round(size,2);
			this.txtWidth.Text = size.ToString();
			
			size = optionWorksheet.CalcSize(optionWorksheet.Height, Worksheet.WS_UNIT_PICSEL, optionWorksheet.Unit);
			size = (float)Math.Round(size,2);
			this.txtHeight.Text = size.ToString();

			size = optionWorksheet.CalcSize(optionWorksheet.LeftMargin, Worksheet.WS_UNIT_PICSEL, optionWorksheet.Unit);
			size = (float)Math.Round(size,2);
			this.txtLeftMargin.Text = size.ToString();

			size = optionWorksheet.CalcSize(optionWorksheet.RightMargin, Worksheet.WS_UNIT_PICSEL, optionWorksheet.Unit);
			size = (float)Math.Round(size,2);
			this.txtRightMargin.Text = size.ToString();

			size = optionWorksheet.CalcSize(optionWorksheet.TopMargin, Worksheet.WS_UNIT_PICSEL, optionWorksheet.Unit);
			size = (float)Math.Round(size,2);
			this.txtTopMargin.Text = size.ToString();

			size = optionWorksheet.CalcSize(optionWorksheet.BottomMargin, Worksheet.WS_UNIT_PICSEL, optionWorksheet.Unit);
			size = (float)Math.Round(size,2);
			this.txtBottomMargin.Text = size.ToString();

			SetSize();
            
		}

        private void OptLayoutH_CheckedChanged(object sender, EventArgs e)
        {
            if(changeByUpdate == false)
                ShowPreview();
        }
        protected virtual void OptLayoutV_CheckedChanged(object sender, EventArgs e)
        {
            if (changeByUpdate == false)
            {
                int temp=0;
                if (this.optLayoutH.Checked == true)
                {
                    this.optionWorksheet.Layout = Worksheet.WS_LAYOUT_HORIZONTAL;
                    if (optionWorksheet.Width < optionWorksheet.Height){
                    	temp = this.optionWorksheet.Width;
		                this.optionWorksheet.Width = this.optionWorksheet.Height;
		                this.optionWorksheet.Height = temp;
		                this.SetSize();
                    }
                }
                else
                {
                    this.optionWorksheet.Layout = Worksheet.WS_LAYOUT_VERTICAL;
                    if (optionWorksheet.Width > optionWorksheet.Height){
                    	temp = this.optionWorksheet.Width;
		                this.optionWorksheet.Width = this.optionWorksheet.Height;
		                this.optionWorksheet.Height = temp;
		                this.SetSize();
                    }
                }
            }
        }
        public static Point DialogLocation
        {
            set {
                dialogLocation = value;
            }
            get {
                return dialogLocation;
            }
        }
        public static Worksheet OptionsWorksheet
        {
            set {
                worksheet = value;
            }
            get {
                return worksheet;
            }
        }
        
        public static OptionsDialog ActiveDialog
        {
            set {
                activeDialog = value;
            }
            get {
                return activeDialog;
            }
        }
        public static Rectangle TargetBounds
        {
            set
            {
                targetBounds = value;
            }
        }
		
		protected virtual void SetSize()
		{
			if(cboPictureSize.Items.Count > optionWorksheet.Size)
				this.cboPictureSize.SelectedIndex= optionWorksheet.Size;
			
			this.txtWidth.Text = optionWorksheet.CalcSize(this.optionWorksheet.Width,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();
			this.txtHeight.Text = optionWorksheet.CalcSize(this.optionWorksheet.Height,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();			
			this.txtLeftMargin.Text = optionWorksheet.CalcSize(this.optionWorksheet.LeftMargin,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();
			this.txtTopMargin.Text = optionWorksheet.CalcSize(this.optionWorksheet.TopMargin,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();
			this.txtRightMargin.Text = optionWorksheet.CalcSize(this.optionWorksheet.RightMargin,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();
			this.txtBottomMargin.Text = optionWorksheet.CalcSize(this.optionWorksheet.BottomMargin,Worksheet.WS_UNIT_PICSEL, (byte) this.cboUnits.SelectedIndex).ToString();
			
			this.txtAuthor.Text = Worksheet.Author;
			this.txtCompany.Text = Worksheet.Company;
			this.txtDate.Text = Worksheet.Date;
			this.txtVersion.Text = Worksheet.Version;
			this.txtFile.Text = Worksheet.FileName;
			this.txtToday.Text = DateTime.Today.Date.ToString();
			
			this.chkAuthor.Checked = Worksheet.DrawAuthor;
			this.chkCompany.Checked = Worksheet.DrawCompany;
			this.chkDate.Checked = Worksheet.DrawDate;
			this.chkFile.Checked = Worksheet.DrawFileName;
			this.chkShowFootline.Checked = Worksheet.DrawFootLine;
			this.chkToday.Checked = Worksheet.DrawPrintDate;
			this.chkVersion.Checked = Worksheet.DrawVersion;
			
			if(cboUnitsIsActive)
			{
				switch(this.cboUnits.SelectedIndex){
					case Worksheet.WS_UNIT_CM:
						this.txtWidth.Text += " cm";
						this.txtHeight.Text += " cm";
						this.txtLeftMargin.Text += " cm";
						this.txtTopMargin.Text += " cm";
						this.txtRightMargin.Text += " cm";
						this.txtBottomMargin.Text += " cm";
						break;
					case Worksheet.WS_UNIT_MM:
						this.txtWidth.Text += " mm";
						this.txtHeight.Text += " mm";
						this.txtLeftMargin.Text += " mm";
						this.txtTopMargin.Text += " mm";
						this.txtRightMargin.Text += " mm";
						this.txtBottomMargin.Text += " mm";
						break;
					case Worksheet.WS_UNIT_INCH:
						this.txtWidth.Text +=" \"";
						this.txtHeight.Text += " \"";
						this.txtLeftMargin.Text += " \"";
						this.txtTopMargin.Text += " \"";
						this.txtRightMargin.Text += " \"";
						this.txtBottomMargin.Text += " \"";
						break;
					case Worksheet.WS_UNIT_PICSEL:
						this.txtWidth.Text +=" px";
						this.txtHeight.Text += " px";
						this.txtLeftMargin.Text += " px";
						this.txtTopMargin.Text += " px";
						this.txtRightMargin.Text += " px";
						this.txtBottomMargin.Text += " px";
						break;
				}
			}
			if (optionWorksheet.Width > optionWorksheet.Height)
				this.optLayoutH.Checked = true;
			else
				this.optLayoutV.Checked = true;
			this.ShowPreview();
		}
		
		protected void ShowPreview()
		{
			if ((this.optionWorksheet.Width==0)||(this.optionWorksheet.Height==0)) return;
			if (this.optionWorksheet.Width>this.optionWorksheet.Height){
				this.pnlPreview.Width = this.pnlPreviewBack.Width-20;
				this.pnlPreview.Height = (int)(((float)this.optionWorksheet.Height/(float)this.optionWorksheet.Width) * (this.pnlPreviewBack.Width-20));
				this.pnlPreview.Left = 10;
				this.pnlPreview.Top = (int)((this.pnlPreviewBack.Height/2)-(this.pnlPreview.Height/2));
			}
			else{
				this.pnlPreview.Height = this.pnlPreviewBack.Height-20;
				this.pnlPreview.Width = (int)(((float)this.optionWorksheet.Width/(float)this.optionWorksheet.Height) * (this.pnlPreviewBack.Height-20));
				this.pnlPreview.Top = 10;
				this.pnlPreview.Left = (int)((this.pnlPreviewBack.Width/2)-(this.pnlPreview.Width/2));
			}
			Graphics g = this.pnlPreview.CreateGraphics();
			PreviewRedraw(g);
		}
		
		
		void PreviewRedraw(object sender, PaintEventArgs e)
		{
			PreviewRedraw(e.Graphics);
		}
		
		private void PreviewRedraw(Graphics g)
		{
//			int LeftMargin = 0;
//			int RightMargin = 0;
//			int TopMargin = 0;
//			int BottomMargin = 0;
//			if (this.optionWorksheet.Width != 0 && this.optionWorksheet.LeftMargin != 0)
//				LeftMargin =  (int)(((float)((float)this.pnlPreview.Width / (float)this.optionWorksheet.Width)) * (float)this.optionWorksheet.LeftMargin);
//			if (this.optionWorksheet.Width != 0 && this.optionWorksheet.RightMargin != 0)
//				RightMargin =  this.pnlPreview.Width - (int)(((float)((float)this.pnlPreview.Width / (float)this.optionWorksheet.Width)) * (float)this.optionWorksheet.RightMargin);
//			if (this.optionWorksheet.Height != 0 && this.optionWorksheet.TopMargin != 0)
//				TopMargin =  (int)(((float)((float)this.pnlPreview.Height / (float)this.optionWorksheet.Height)) * (float)this.optionWorksheet.TopMargin);
//			if (this.optionWorksheet.Height != 0 && this.optionWorksheet.BottomMargin != 0)
//				BottomMargin =  this.pnlPreview.Height - (int)(((float)((float)this.pnlPreview.Height / (float)this.optionWorksheet.Height)) * (float)this.optionWorksheet.BottomMargin);
//			g.Clear(Color.White);
//			g.DrawLine(Pens.Red,LeftMargin,0,LeftMargin, this.pnlPreview.Height);
//			g.DrawLine(Pens.Red,RightMargin-1,0,RightMargin-1, this.pnlPreview.Height);
//			g.DrawLine(Pens.Red,0,TopMargin,this.pnlPreview.Width, TopMargin);
//			g.DrawLine(Pens.Red,0,BottomMargin-1,this.pnlPreview.Width, BottomMargin-1);
//			g.Dispose();
			
			int LeftMargin =  (int)(((float)((float)this.pnlPreview.Width / (float)this.optionWorksheet.Width)) * (float)this.optionWorksheet.LeftMargin);
			int RightMargin =  this.pnlPreview.Width - (int)(((float)((float)this.pnlPreview.Width / (float)this.optionWorksheet.Width)) * (float)this.optionWorksheet.RightMargin);
			int TopMargin =  (int)(((float)((float)this.pnlPreview.Height / (float)this.optionWorksheet.Height)) * (float)this.optionWorksheet.TopMargin);
			int BottomMargin =  this.pnlPreview.Height - (int)(((float)((float)this.pnlPreview.Height / (float)this.optionWorksheet.Height)) * (float)this.optionWorksheet.BottomMargin);
			g.Clear(Color.White);
			g.DrawLine(Pens.Red,LeftMargin,0,LeftMargin, this.pnlPreview.Height);
			g.DrawLine(Pens.Red,RightMargin-1,0,RightMargin-1, this.pnlPreview.Height);
			g.DrawLine(Pens.Red,0,TopMargin,this.pnlPreview.Width, TopMargin);
			g.DrawLine(Pens.Red,0,BottomMargin-1,this.pnlPreview.Width, BottomMargin-1);
			g.Dispose();
			
		}
		
        void CmdCancelClick(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
		
        protected virtual void CmdOkClick(object sender, System.EventArgs e)
        {
            this.SetWorksheetProps();	
            this.Dispose();	
        }
				
		protected virtual int TabOption{
			get{
				return this.tabOptions.SelectedIndex;
			}
			set{
				this.tabOptions.SelectedIndex = value;
			}
		}
		void TxtLeftMarginKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.txtLeftMargin.Text != optionWorksheet.LeftMargin.ToString())
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
					TxtLeftMarginChanged(sender, e);
		}
        void TxtLeftMarginLostFocus(object sender, System.EventArgs e)
        {
            if(changeByUpdate == false)
                if (this.txtLeftMargin.Text != optionWorksheet.LeftMargin.ToString())
                    TxtLeftMarginChanged(sender, e);
        }
		protected virtual void TxtLeftMarginChanged(object sender, System.EventArgs e)
		{
			float size;
			string s = String.Empty;
			char[] values;
			bool point = false;
			if(this.txtLeftMargin.Text == optionWorksheet.LeftMargin.ToString())
				return;
			if (this.txtLeftMargin.Modified){
				values = this.txtLeftMargin.Text.ToCharArray();
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
					this.optionWorksheet.LeftMargin = (int)optionWorksheet.CalcSize(size,(byte)this.cboUnits.SelectedIndex);
					this.CheckSizes();
				}
			}
		}
		void TxtRightMarginKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.txtRightMargin.Text != optionWorksheet.RightMargin.ToString())
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
					TxtRightMarginChanged(sender, e);
		}
        void TxtRightMarginLostFocus(object sender, System.EventArgs e)
        {
            if(changeByUpdate == false)
                if (this.txtRightMargin.Text != optionWorksheet.RightMargin.ToString())
                    TxtRightMarginChanged(sender, e);
        }
		protected virtual void TxtRightMarginChanged(object sender, System.EventArgs e)
		{
			float size;
			string s = String.Empty;
			char[] values;
			bool point = false;
			if(this.txtRightMargin.Text == optionWorksheet.RightMargin.ToString())
				return;
			if (this.txtRightMargin.Modified){
				values = this.txtRightMargin.Text.ToCharArray();
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
					this.optionWorksheet.RightMargin = (int) optionWorksheet.CalcSize(size,(byte)this.cboUnits.SelectedIndex);
					this.CheckSizes();
				}
			}
		}
					
		void TxtTopMarginKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.txtTopMargin.Text != optionWorksheet.TopMargin.ToString())
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
					TxtTopMarginChanged(sender, e);
		}
        void TxtTopMarginLostFocus(object sender, System.EventArgs e)
        {
            if(changeByUpdate == false)
                if (this.txtTopMargin.Text != optionWorksheet.TopMargin.ToString())
                    TxtTopMarginChanged(sender, e);
        }
		protected virtual void TxtTopMarginChanged(object sender, System.EventArgs e)
		{
			float size;
			string s = String.Empty;
			char[] values;
			bool point = false;
			if(this.txtTopMargin.Text == optionWorksheet.TopMargin.ToString())
				return;
			if (this.txtTopMargin.Modified){
				values = this.txtTopMargin.Text.ToCharArray();
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
					this.optionWorksheet.TopMargin = (int) optionWorksheet.CalcSize(size,(byte)this.cboUnits.SelectedIndex);
					this.CheckSizes();
				}
			}
		}
		void TxtBottomMarginKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.txtBottomMargin.Text != optionWorksheet.BottomMargin.ToString())
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
					TxtBottomMarginChanged(sender, e);
		}
        void TxtBottomMarginLostFocus(object sender, System.EventArgs e)
        {
            if(changeByUpdate == false)
                if (this.txtBottomMargin.Text != optionWorksheet.BottomMargin.ToString())
                    TxtBottomMarginChanged(sender, e);
        }
		protected virtual void TxtBottomMarginChanged(object sender, System.EventArgs e)
		{
			float size;
			string s = String.Empty;
			char[] values;
			bool point = false;
			if(this.txtBottomMargin.Text == optionWorksheet.BottomMargin.ToString())
				return;
			if (this.txtBottomMargin.Modified){
				values = this.txtBottomMargin.Text.ToCharArray();
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
					this.optionWorksheet.BottomMargin = (int)optionWorksheet.CalcSize(size,(byte)this.cboUnits.SelectedIndex);
					this.CheckSizes();
				}
			}
		}

		void TxtHeightKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.txtHeight.Text != optionWorksheet.Height.ToString())
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
					TxtHeightChanged(sender, e);
		}
        void TxtHeightLostFocus(object sender, System.EventArgs e)
        {
            if (changeByUpdate == false)
                if (this.txtHeight.Text != optionWorksheet.Height.ToString())
                    TxtHeightChanged(sender, e);
        }
        protected virtual void TxtHeightChanged(object sender, System.EventArgs e)
        {
            if (changeByUpdate == false)
            {
                float size;
                string s = String.Empty;
                char[] values;
                bool point = false;
                if (this.txtHeight.Text == optionWorksheet.Height.ToString())
                    return;
                if (this.txtHeight.Modified)
                {
                    values = this.txtHeight.Text.ToCharArray();
                    foreach (char c in values)
                    {
                        if (Char.IsDigit(c))
                            s += c;
                        if ((c == ',') && (point == false))
                        {
                            s += c;
                            point = true;
                        }
                    }
                    if (s != String.Empty)
                    {
                        size = (float)Convert.ToSingle(s);
                        this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(size, (byte)this.cboUnits.SelectedIndex);
                        this.CheckSizes();
                        this.cboPictureSize.SelectedIndex = 0;
                    }
                }
            }
        }

		void TxtWidthKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.txtWidth.Text != optionWorksheet.Width.ToString())
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
					TxtWidthChanged(sender, e);
		}
        void TxtWidthLostFocus(object sender, System.EventArgs e)
        {
            if(changeByUpdate == false)
                if (this.txtWidth.Text != optionWorksheet.Width.ToString())
                    TxtWidthChanged(sender, e);
        }
        protected virtual void TxtWidthChanged(object sender, System.EventArgs e)
        {
            if (changeByUpdate == false)
            {
                float size;
                string s = String.Empty;
                char[] values;
                bool point = false;
                if (this.txtWidth.Text == optionWorksheet.Width.ToString())
                    return;
                if (this.txtWidth.Modified)
                {
                    values = this.txtWidth.Text.ToCharArray();
                    foreach (char c in values)
                    {
                        if (Char.IsDigit(c))
                            s += c;
                        if ((c == ',') && (point == false))
                        {
                            s += c;
                            point = true;
                        }
                    }
                    if (s != String.Empty)
                    {
                        size = (float)Convert.ToSingle(s);
                        this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(size, (byte)this.cboUnits.SelectedIndex);
                        this.CheckSizes();
                        this.cboPictureSize.SelectedIndex = 0;
                    }
                }
            }
        }
		private void CheckSizes()
		{
			this.optionWorksheet.CheckSizes();			// check sizes of worksheet
			this.SetSize();								// correct sizes of worksheet options
			
		}
		protected virtual void ShowFirstTime(object sender, EventArgs e)
		{
			this.ShowPreview();

		}

        protected virtual void CmdAcceptClick(object sender, System.EventArgs e)
        {
            this.SetWorksheetProps();
            if (OnAcceptClick != null) OnAcceptClick(this, new EventArgs());
        }
		protected void CloseDialog(object sender, System.EventArgs e)
		{
			activeDialog=null;							// clear reference of active dialog
		}
		protected void SetWorksheetProps()				// take changes to worksheet
		{
			worksheet.WorksheetValues = this.optionWorksheet.WorksheetValues;
			
			Worksheet.Author = this.txtAuthor.Text;
			Worksheet.Company = this.txtCompany.Text;
			Worksheet.Date = this.txtDate.Text;
			Worksheet.Version = this.txtVersion.Text;
			Worksheet.DrawAuthor = this.chkAuthor.Checked;
			Worksheet.DrawCompany = this.chkCompany.Checked;
			Worksheet.DrawDate = this.chkDate.Checked;
			Worksheet.DrawVersion = this.chkVersion.Checked;
			Worksheet.DrawPrintDate = this.chkToday.Checked;
			Worksheet.DrawFileName = this.chkFile.Checked;
			Worksheet.DrawFootLine = this.chkShowFootline.Checked;
			
            
		}
        protected virtual void CboPictureSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPictureSize.SelectedIndex == Worksheet.WS_SIZE_A0_ISO)
            {
                this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A0_X, Worksheet.WS_UNIT_CM);
                this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A0_Y, Worksheet.WS_UNIT_CM);

            }
            if (this.cboPictureSize.SelectedIndex == Worksheet.WS_SIZE_A1_ISO)
            {
                this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A1_X, Worksheet.WS_UNIT_CM);
                this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A1_Y, Worksheet.WS_UNIT_CM);

            }
            if (this.cboPictureSize.SelectedIndex == Worksheet.WS_SIZE_A2_ISO)
            {
                this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A2_X, Worksheet.WS_UNIT_CM);
                this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A2_Y, Worksheet.WS_UNIT_CM);

            }
            if (this.cboPictureSize.SelectedIndex == Worksheet.WS_SIZE_A3_ISO)
            {
                this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A3_X, Worksheet.WS_UNIT_CM);
                this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A3_Y, Worksheet.WS_UNIT_CM);

            }
            if (this.cboPictureSize.SelectedIndex == Worksheet.WS_SIZE_A4_ISO)
            {

                this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A4_X, Worksheet.WS_UNIT_CM);
                this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A4_Y, Worksheet.WS_UNIT_CM);

            }
            if (this.cboPictureSize.SelectedIndex == Worksheet.WS_SIZE_A5_ISO)
            {
                this.optionWorksheet.Width = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A5_X, Worksheet.WS_UNIT_CM);
                this.optionWorksheet.Height = (int)optionWorksheet.CalcSize(Worksheet.WS_SIZE_A5_Y, Worksheet.WS_UNIT_CM);

            }
            if ((this.optLayoutH.Checked == true) && (this.cboPictureSize.SelectedIndex != Worksheet.WS_SIZE_USER_DEFINED))
            {
                int temp;
                temp = this.optionWorksheet.Width;
                this.optionWorksheet.Width = this.optionWorksheet.Height;
                this.optionWorksheet.Height = temp;
            }
            optionWorksheet.Size = (byte)this.cboPictureSize.SelectedIndex;

            this.SetSize();
        }

        protected virtual void CboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            optionWorksheet.Unit = (byte)this.cboUnits.SelectedIndex;
            this.SetSize();
        }

        public void UpdateValues(Worksheet w)
        {
            if (!this.IsDisposed)
            {
                worksheet = optionWorksheet = w;
                changeByUpdate = true;
                if (worksheet.Height > worksheet.Width)
                    optionWorksheet.Layout = Worksheet.WS_LAYOUT_VERTICAL;
                else
                    optionWorksheet.Layout = Worksheet.WS_LAYOUT_HORIZONTAL;
                if (optionWorksheet.Layout == Worksheet.WS_LAYOUT_HORIZONTAL)
                    this.optLayoutH.Checked = true;
                if (optionWorksheet.Layout == Worksheet.WS_LAYOUT_VERTICAL)
                    this.optLayoutV.Checked = true;
                CheckWSSizeISO();

                SetSize();

                changeByUpdate = false;
            }
        }

        protected void CheckWSSizeISO()
        {
            int dinWidth = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A0_Y, Worksheet.WS_UNIT_CM);
            int dinHeight = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A0_X, Worksheet.WS_UNIT_CM);
            if ((dinWidth == worksheet.Width && dinHeight == worksheet.Height) || (dinHeight == worksheet.Width && dinWidth == worksheet.Height))
            {
                this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_A0_ISO;
            }
            dinWidth = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A1_Y, Worksheet.WS_UNIT_CM);
            dinHeight = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A1_X, Worksheet.WS_UNIT_CM);
            if ((dinWidth == worksheet.Width && dinHeight == worksheet.Height) || (dinHeight == worksheet.Width && dinWidth == worksheet.Height))
            {
                this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_A1_ISO;
            }
            dinWidth = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A2_Y, Worksheet.WS_UNIT_CM);
            dinHeight = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A2_X, Worksheet.WS_UNIT_CM);
            if ((dinWidth == worksheet.Width && dinHeight == worksheet.Height) || (dinHeight == worksheet.Width && dinWidth == worksheet.Height))
            {
                this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_A2_ISO;
            }
            dinWidth = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A3_Y, Worksheet.WS_UNIT_CM);
            dinHeight = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A3_X, Worksheet.WS_UNIT_CM);
            if ((dinWidth == worksheet.Width && dinHeight == worksheet.Height) || (dinHeight == worksheet.Width && dinWidth == worksheet.Height))
            {
                this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_A3_ISO;
            }
            dinWidth = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A4_Y, Worksheet.WS_UNIT_CM);
            dinHeight = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A4_X, Worksheet.WS_UNIT_CM);
            if ((dinWidth == worksheet.Width && dinHeight == worksheet.Height) || (dinHeight == worksheet.Width && dinWidth == worksheet.Height))
            {
                this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_A4_ISO;
            }
            dinWidth = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_Y, Worksheet.WS_UNIT_CM);
            dinHeight = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_X, Worksheet.WS_UNIT_CM);
            if ((dinWidth == worksheet.Width && dinHeight == worksheet.Height) || (dinHeight == worksheet.Width && dinWidth == worksheet.Height))
            {
                this.cboPictureSize.SelectedIndex = Worksheet.WS_SIZE_A5_ISO;
            }
        }

        protected virtual void ChkShowFootline_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkShowFootline.Checked)
            {
                this.chkAuthor.Enabled = true;
                this.chkCompany.Enabled = true;
                this.chkDate.Enabled = true;
                this.chkFile.Enabled = true;
                this.chkToday.Enabled = true;
                this.chkVersion.Enabled = true;
                chkShowFootlineChecked = true;
            }
            else
            {
                this.chkAuthor.Enabled = false;
                this.chkCompany.Enabled = false;
                this.chkDate.Enabled = false;
                this.chkFile.Enabled = false;
                this.chkToday.Enabled = false;
                this.chkVersion.Enabled = false;
                chkShowFootlineChecked = false;
            }
        }
        private void DialogMove(object sender, EventArgs e)
        {
			OptionsDialog.DialogLocation = this.Location;
        }
		protected virtual void TabOptionsSelectedIndexChanged(object sender, EventArgs e)
		{
		}
		
		protected void SetFraFootLinePosition(Point p)
		{
			this.fraFootline.Location = p;
		}

		protected void SetButtonsVisible(bool visible)
		{
			this.cmdAccept.Visible = visible;
			this.cmdCancel.Visible = visible;
			this.cmdOk.Visible = visible;
		}
	}
}
