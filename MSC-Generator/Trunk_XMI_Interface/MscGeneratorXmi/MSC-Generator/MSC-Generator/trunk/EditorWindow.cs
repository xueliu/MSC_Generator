/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 19.01.2006
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace mscEditor
{
	/// <summary>
	/// Description of EditorWindow.
	/// </summary>

	public struct ErrorPosition{
		public int start;
		public int end;
		
		public ErrorPosition(int s, int e)
		{
			start=s;
			end=e;
		}
	}
	
	public class LineNumbers : FlickerFreeRichTextBox
	{
		private Graphics g;
		private int oldSl=0, oldEl=0;
		private Font mF;
		private Point mP;
		private uint mMarkedRow;
		
		public LineNumbers()
		{
			this.SetStyle(ControlStyles.UserPaint, true);
		}
		public uint MarkedRow {
			get{
				return mMarkedRow;
			}
			set{
				mMarkedRow = value;
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(this.BackColor);
			for (int i=0; i<=(oldEl-oldSl)+1; i++){
				if ((i+oldSl)==mMarkedRow){
					e.Graphics.FillRectangle(Brushes.Red,0,mP.Y+i*mF.Height,29,mF.Height);
				}
				e.Graphics.DrawString((i+oldSl).ToString(), mF, Brushes.Black,1,mP.Y+i*mF.Height);
			}
		}
		public void SetNumbers()
		{
			g = this.CreateGraphics();
			g.Clear(this.BackColor);
			for (int i=0; i<=(oldEl-oldSl)+1; i++){
				if ((i+oldSl)==mMarkedRow){
					g.FillRectangle(Brushes.Red,1,mP.Y+i*mF.Height,29,mF.Height);
				}
				g.DrawString((i+oldSl).ToString(), mF, Brushes.Black,1,mP.Y+i*mF.Height);
			}
			g.Dispose();
		}
		public void SetNumbers(int sl, int el, Font f, Point p)
		{
			if ((oldSl==sl)&&(oldEl==el)) return;
			g = this.CreateGraphics();
			g.Clear(this.BackColor);
			for (int i=0; i<=(el-sl)+1; i++){
				if ((i+oldSl)==mMarkedRow){
					g.FillRectangle(Brushes.Red,1,p.Y+i*f.Height,29,f.Height);
				}
				g.DrawString((i+sl).ToString(), f, Brushes.Black,1,p.Y+i*f.Height);
			}
			//MessageBox.Show(numbers);
			g.Dispose();
			oldSl = sl;
			oldEl = el;
			mF = f;
			mP = p;
		}
	}
	
	
	public class EditorWindow : FlickerFreeRichTextBox
	{
		private LineNumbers rows;
		private bool kShift = false;
		private bool mEdited = false;
		static ErrorPosition[] errorPosition;
		public EditorWindow()
		{
			rows = new LineNumbers();
			errorPosition = new ErrorPosition[]{};
			this.AcceptsTab = true;
			this.SelectionIndent = 30;
			rows.BorderStyle = BorderStyle.None;
			rows.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			rows.Location = new Point(0,0);
			rows.Width = 29;
			rows.BackColor = Color.LightGray;
			rows.Enabled = false;
			rows.Dock = DockStyle.Left;
			this.Controls.Add(rows);
		}
		public static ErrorPosition[] ErrorPositions{
			get{
				return errorPosition;
			}
			set{
				errorPosition = value;
			}
		}
		public bool Edited{
			get{
				return mEdited;
			}
			set{
				mEdited = value;
			}			
		}
		public uint MarkedRow{
			get{
				return rows.MarkedRow;
			}
			set{
				rows.MarkedRow = value;
			}			
		}
		private void CalculateRows()
		{
		    Point pos = new Point(30, 5);
		    int firstIndex = this.GetCharIndexFromPosition(pos);
		    int firstLine = this.GetLineFromCharIndex(firstIndex);
		    Point firstPoint = this.GetPositionFromCharIndex(firstIndex);
		    pos.X = ClientRectangle.Width;
		    pos.Y = ClientRectangle.Height;
		    int lastIndex = this.GetCharIndexFromPosition(pos);
		    int lastLine = this.GetLineFromCharIndex(lastIndex);
		
		    pos = this.GetPositionFromCharIndex(lastIndex);
		    rows.SetNumbers(firstLine+1, lastLine+1,this.Font, firstPoint);
		}	
		public new void LoadFile(string path)
		{
			rows.MarkedRow = 0;
			this.Refresh();
			base.LoadFile(path);
		}
		public new void LoadFile(string path, RichTextBoxStreamType fileType)
		{
			rows.MarkedRow = 0;
			this.Refresh();
			base.LoadFile(path, fileType);
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			mEdited = true;
			if (e.KeyChar==(char)13){
		    	int line = this.GetLineFromCharIndex(this.SelectionStart);
		    	if (line > 0){
		    		for (int i=0;i<this.Lines[line-1].Length;i++){
		    			if (this.Lines[line-1].IndexOf('\t',i) == i){
		    				this.SelectedText = "\t";
		    				
		    			}
		    			else{
		    				break;
		    			}
		    		}
		    	}
			}
			else if (e.KeyChar=='\t'){
		    	int lineStart = this.GetLineFromCharIndex(this.SelectionStart+1);
		    	int lineEnd = this.GetLineFromCharIndex(this.SelectionStart + this.SelectionLength-1);
		    	if (lineStart < lineEnd){
		    		int index=0;
		    		int sSelStart;
		    		int sSelLength= this.SelectionLength;
		    		int selStart = this.SelectionStart;
		    		index = (this.Text.Substring(1,selStart).LastIndexOf('\n')+1);
		    		sSelStart = selStart = index+1;
		    		if (kShift==false){
			    		for (int i=lineStart; i<=lineEnd; i++){
			    			this.SelectionStart = selStart;
			    			this.SelectionLength = 0;
			    			this.SelectedText = "\t";
			    			index = this.Text.IndexOf('\n',selStart)+1;
			    			selStart = index;
			    			sSelLength++;
			    		}
		    		}
		    		else{
			    		for (int i=lineStart; i<=lineEnd; i++){
			    			this.SelectionStart = selStart;
			    			this.SelectionLength = 1;
			    			if (this.SelectedText == "\t"){
			    				this.SelectedText = "";
			    				sSelLength--;
			    			}
			    			index = this.Text.IndexOf('\n',selStart)+1;
			    			selStart = index;
		    			}
		    		}
		    		this.SelectionStart = sSelStart;
		    		this.SelectionLength = sSelLength;
		    		e.Handled = true;
		    	}
		    	else{
		    	}
			}
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if ((e.Control == true) && (e.KeyCode==Keys.Z)){
				this.Undo();
			}
			else if(e.KeyCode==Keys.ShiftKey){
				kShift=true;
			}
			base.OnKeyDown(e);
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if(e.KeyCode==Keys.ShiftKey){
				kShift=false;
			}
			base.OnKeyDown(e);
		}
		
		protected override void xPaint(){
			Graphics g = this.CreateGraphics();
			float x1, x2, y;
			PointF[] pt;
			foreach (ErrorPosition ep in errorPosition){
				y = this.GetPositionFromCharIndex(ep.start).Y + this.Font.Height;
				x1 = this.GetPositionFromCharIndex(ep.start).X;
				x2 = this.GetPositionFromCharIndex(ep.end).X;
				if (!((this.SelectionStart >=ep.start)&&(this.SelectionStart<=ep.end))){
					pt = new PointF[(int)x2-(int)x1];
					for(int i=0; i<(int)x2-(int)x1; i++){
						pt[i].X= x1+i;
						pt[i].Y= (y-1)+(i%3);
					}
					//g.CompositingQuality = CompositingQuality.HighQuality;
					g.SmoothingMode = SmoothingMode.HighQuality;
					if (pt.Length>=1)
						g.DrawCurve(Pens.Red,pt,1.0f);
					//g.DrawLine(Pens.Red, x1,y,x2,y);
				}
			}
			g.Dispose();
		}
		protected override void OnVScroll(EventArgs e)
		{
			base.OnVScroll(e);
			CalculateRows();
		}
		protected override void OnTextChanged(EventArgs e)
		{
			CalculateRows();
			base.OnTextChanged(e);
		}
		protected override void xVScroll()
		{
			CalculateRows();
		}
	}
	
	public class FlickerFreeRichTextBox : RichTextBox
	{
		const short WM_PAINT = 0x00f;
		const short WM_VSCROLL = 0x115;
		
		const short SB_BOTTOM = 7;
		const short SB_ENDSCROLL = 8;
		const short SB_LEFT = 6;
		const short SB_LINEDOWN = 1;
		const short SB_LINELEFT = 0;
		const short SB_LINERIGHT = 1;
		const short SB_LINEUP = 0;
		const short SB_PAGEDOWN = 3;
		const short SB_PAGELEFT = 2;
		const short SB_PAGERIGHT = 3;
		const short SB_PAGEUP = 2;
		const short SB_RIGHT = 7;
		const short SB_THUMBPOSITION = 4;
		const short SB_THUMBTRACK = 5;
		const short SB_TOP = 6;
		
		public static bool _Paint = true;
		
		protected virtual void xVScroll()
		{
			
		}
		protected virtual void xPaint()
		{
			
		}
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == WM_PAINT)
		  	{
			  	if (_Paint){
		            base.WndProc(ref m);   // if we decided to paint this control, just call the RichTextBox WndProc
		         	xPaint();
			  	}
		        else
		           m.Result = IntPtr.Zero;   //  not painting, must set this to IntPtr.Zero if not painting otherwise serious problems.
			 }

			 else if (m.Msg == WM_VSCROLL)
			 {
			 	base.WndProc(ref m);
			 	if ((m.WParam.ToInt32() & 0xFF) == SB_THUMBTRACK){			// nonrelevant high-order word that indicates the position that the scroll box has been dragged to. 
			 		xVScroll();
			 	}
			 }
			 else base.WndProc (ref m);   // message other than WM_PAINT, jsut do what you normally do.
		}
	}
}
