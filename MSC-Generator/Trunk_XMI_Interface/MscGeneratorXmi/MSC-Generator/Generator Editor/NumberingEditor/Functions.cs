/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 03.08.2006
 * Time: 10:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace NumberingEditor
{
	public delegate void LineChangedEventHandler(object sender, LineChangedEventArgs e);
		
	public class LineChangedEventArgs : EventArgs
	{
		private int mLine;
		
		public int Line{
			get{
				return this.mLine;
			}
		}
		public LineChangedEventArgs(int line){
			this.mLine = line;
		}
	}
	
	public enum ScrollBarType : int
	{
		SbHorz 	= 0,
		SbVert 	= 1,
		SbCtl 	= 2,
		SbBoth 	= 3
	}
	
	public enum ScrollBarCommands : int
	{
		SB_BOTTOM 			= 7,
		SB_ENDSCROLL 		= 8,
		SB_LEFT 			= 6,
		SB_LINEDOWN 		= 1,
		SB_LINELEFT 		= 0,
		SB_LINERIGHT 		= 1,
		SB_LINEUP 			= 0,
		SB_PAGEDOWN 		= 3,
		SB_PAGELEFT 		= 2,
		SB_PAGERIGHT 		= 3,
		SB_PAGEUP 			= 2,
		SB_RIGHT 			= 7,
		SB_THUMBPOSITION 	= 4,
		SB_THUMBTRACK 		= 5,
		SB_TOP 				= 6
	}
	public enum ActivateCommands : int
	{
		WA_ACTIVE = 0,
		WA_CLICKACTIVE = 1,
		WA_INACTIVE	= 2
	}
	public class FlickerFreeRichTextBox : RichTextBox
	{

	 	protected const int WM_NULL = 0x0000;
	 	protected const int WM_CREATE = 0x0001;
	 	protected const int WM_DESTROY = 0x0002;
	 	protected const int WM_MOVE = 0x0003;
	 	protected const int WM_SIZE = 0x0005;
	 	protected const int WM_SETFOCUS = 0x0007;
	 	protected const int WM_KILLFOCUS = 0x0008;
	 	protected const int WM_ENABLE = 0x000A;
	 	protected const int WM_SETREDRAW = 0x000B;
	 	protected const int WM_SETTEXT = 0x000C;
	 	protected const int WM_GETTEXT = 0x000D;
	 	protected const int WM_GETTEXTLENGTH = 0x000E;
	 	protected const int WM_PAINT = 0x000F;
	 	protected const int WM_CLOSE = 0x0010;
	 	protected const int WM_QUERYENDSESSION = 0x0011;
	 	protected const int WM_QUIT = 0x0012;
	 	protected const int WM_QUERYOPEN = 0x0013;
	 	protected const int WM_ERASEBKGND = 0x0014;
	 	protected const int WM_SYSCOLORCHANGE = 0x0015;
	 	protected const int WM_ENDSESSION = 0x0016;
	 	protected const int WM_SHOWWINDOW = 0x0018;
	 	protected const int WM_WININICHANGE = 0x001A;
	 	protected const int WM_DEVMODECHANGE = 0x001B;
	 	protected const int WM_ACTIVATEAPP = 0x001C;
	 	protected const int WM_FONTCHANGE = 0x001D;
	 	protected const int WM_TIMECHANGE = 0x001E;
	 	protected const int WM_CANCELMODE = 0x001F;
	 	protected const int WM_SETCURSOR = 0x0020;
	 	protected const int WM_MOUSEACTIVATE = 0x0021;
	 	protected const int WM_CHILDACTIVATE = 0x0022;
	 	protected const int WM_QUEUESYNC = 0x0023;
	 	protected const int WM_GETMINMAXINFO = 0x0024;
	 	protected const int WM_PAINTICON = 0x0026;
	 	protected const int WM_ICONERASEBKGND = 0x0027;
	 	protected const int WM_NEXTDLGCTL = 0x0028;
	 	protected const int WM_SPOOLERSTATUS = 0x002A;
	 	protected const int WM_DRAWITEM = 0x002B;
	 	protected const int WM_MEASUREITEM = 0x002C;
 		protected const int WM_DELETEITEM = 0x002D;
	 	protected const int WM_VKEYTOITEM = 0x002E;
	 	protected const int WM_CHARTOITEM = 0x002F;
	 	protected const int WM_SETFONT = 0x0030;
	 	protected const int WM_GETFONT = 0x0031;
	 	protected const int WM_SETHOTKEY = 0x0032;
	 	protected const int WM_GETHOTKEY = 0x0033;
	 	protected const int WM_QUERYDRAGICON = 0x0037;
	 	protected const int WM_COMPAREITEM = 0x0039;
	 	protected const int WM_COMPACTING = 0x0041;
		protected const int WM_VSCROLL 	= 0x0115;
		protected const int WM_COPY = 0x0301;
		protected const int WM_CUT = 0x0300;
		protected const int WM_PASTE = 0x0302;
		protected const int WM_USER = 0x0400;

		protected const int EN_SETFOCUS = 0x100;
		protected const int EN_KILLFOCUS = 0x200;
		protected const int EN_CHANGE = 0x300;
		protected const int EN_UPDATE = 0x400;
		protected const int EN_ERRSPACE = 0x500;
		protected const int EN_MAXTEXT = 0x501;
		protected const int EN_HSCROLL = 0x601;
		protected const int EN_VSCROLL = 0x602;

		protected const int EM_GETSEL = 0xB0;
		protected const int EM_SETSEL = 0xB1;
		protected const int EM_GETRECT = 0xB2;
		protected const int EM_SETRECT = 0xB3;
		protected const int EM_SETRECTNP = 0xB4;
		protected const int EM_SCROLL = 0xB5;
		protected const int EM_LINESCROLL = 0xB6;
		protected const int EM_SCROLLCARET = 0xB7;
		protected const int EM_GETMODIFY = 0xB8;
		protected const int EM_SETMODIFY = 0xB9;
		protected const int EM_GETLINECOUNT = 0xBA;
		protected const int EM_LINEINDEX = 0xBB;

		protected const int EM_GETTHUMB = 0xBE;
		protected const int EM_LINELENGTH = 0xC1;
		protected const int EM_REPLACESEL = 0xC2;
		protected const int EM_GETLINE = 0xC4;
		protected const int EM_LIMITTEXT = 0xC5;
		protected const int EM_CANUNDO = 0xC6;
		protected const int EM_UNDO = 0xC7;
		protected const int EM_FMTLINES = 0xC8;
		protected const int EM_LINEFROMCHAR = 0xC9;
		protected const int EM_SETTABSTOPS = 0xCB;
		protected const int EM_SETPASSWORDCHAR = 0xCC;
		protected const int EM_EMPTYUNDOBUFFER = 0xCD;
		protected const int EM_GETFIRSTVISIBLELINE = 0xCE;
		protected const int EM_SETREADONLY = 0xCF;
		protected const int EM_SETWORDBREAKPROC = 0xD0;
		protected const int EM_GETWORDBREAKPROC = 0xD1;
		protected const int EM_GETPASSWORDCHAR = 0xD2;
		protected const int EM_GETLIMITTEXT = 0x425;
		protected const int EM_POSFROMCHAR = 0x426;
		protected const int EM_CHARFROMPOS = 0x427;
		//protected const int EM_SCROLLCARET = 0x431;
		protected const int EM_CANPASTE = 0x432;
		protected const int EM_DISPLAYBAND = 0x433;
		protected const int EM_EXGETSEL = 0x434;
		protected const int EM_EXLIMITTEXT = 0x435;
		protected const int EM_EXLINEFROMCHAR = 0x436;
		protected const int EM_EXSETSEL = 0x437;
		protected const int EM_FINDTEXT = 0x438;
		protected const int EM_FORMATRANGE = 0x439;
		protected const int EM_GETCHARFORMAT = 0x43A;
		protected const int EM_GETEVENTMASK = 0x43B;
		protected const int EM_GETOLEINTERFACE = 0x43C;
		protected const int EM_GETPARAFORMAT = 0x43D;
		protected const int EM_GETSELTEXT = 0x43E;
		protected const int EM_HIDESELECTION = 0x43F;
		protected const int EM_PASTESPECIAL = 0x440;
		protected const int EM_REQUESTRESIZE = 0x441;
		protected const int EM_SELECTIONTYPE = 0x442;
		protected const int EM_SETBKGNDCOLOR = 0x443;
		protected const int EM_SETCHARFORMAT = 0x444;
		protected const int EM_SETEVENTMASK = 0x445;
		protected const int EM_SETOLECALLBACK = 0x446;
		protected const int EM_SETPARAFORMAT = 0x447;
		protected const int EM_SETTARGETDEVICE = 0x448;
		protected const int EM_STREAMIN = 0x449;
		protected const int EM_STREAMOUT = 0x44A;
		protected const int EM_GETTEXTRANGE = 0x44B;
		protected const int EM_FINDWORDBREAK = 0x44C;
		protected const int EM_SETOPTIONS = 0x44D;
		protected const int EM_GETOPTIONS = 0x44E;
		protected const int EM_FINDTEXTEX = 0x44F;
		protected const int EM_SETUNDOLIMIT = 0x452;
		protected const int EM_REDO = 0x454;
		protected const int EM_CANREDO = 0x455;
		protected const int EM_GETUNDONAME = 0x456;
		protected const int EM_GETREDONAME = 0x457;
		protected const int EM_STOPGROUPTYPING = 0x458;
		protected const int EM_SETTEXTMODE = 0x459;
		protected const int EM_GETTEXTMODE = 0x45A;

		private int updating=0;
		private int oldEventMask=0;
	    [DllImport( "user32", CharSet = CharSet.Auto )]
	    private static extern int SendMessage( HandleRef hWnd,
	                                           int msg,
	                                           int wParam,
	                                           int lParam );
	    [DllImport( "user32", CharSet = CharSet.Auto )]
	    private static extern int SendMessageA( HandleRef hWnd,
	                                           int msg,
	                                           int wParam,
	                                           int lParam );
	    
				
		public void BeginUpdate()
		{
		    // Deal with nested calls.
		    ++updating;
		    
		    if ( updating > 1 )
		        return;
		    
		    // Prevent the control from raising any events.
		    oldEventMask = SendMessage( new HandleRef( this, Handle ),
		                               EM_SETEVENTMASK, 0, 0 );
		    
		    // Prevent the control from redrawing itself.
		    SendMessage( new HandleRef( this, Handle ),
		                WM_SETREDRAW, 0, 0 );
		}
		public void EndUpdate()
		{
		    // Deal with nested calls.
		    --updating;
		    
		    if ( updating > 0 )
		        return;
		    // Allow the control to redraw itself.
		    SendMessage( new HandleRef( this, Handle ),
		                 WM_SETREDRAW, 1, 0 );
		    
		    // Allow the control to raise event messages.
		    SendMessage( new HandleRef( this, Handle ),
		                 EM_SETEVENTMASK, 0, oldEventMask );
		}			
		public void MUndo()
		{
//			MessageBox.Show((SendMessageA( new HandleRef( this, Handle ),
//			                             EM_CANUNDO, 0, 0 )).ToString());
//		    MessageBox.Show((SendMessageA( new HandleRef( this, Handle ),
//			                             EM_GETTEXTMODE, 0, 0 )).ToString());
			//for (int i=0; i<10; i++)
			SendMessageA(new HandleRef( this, Handle ),
			                             EM_UNDO, 0, 0 );
		}
	}
	public struct ErrorPosition{
		public int start;
		public int end;
		
		public ErrorPosition(int s, int e)
		{
			start=s;
			end=e;
		}
	}	
	public class NumberingRichTextBox : FlickerFreeRichTextBox
	{
		public event LineChangedEventHandler LineChanged;
		
		private bool kShift = false;
		private bool mEdited = false;
		private uint markedRow = 0;
		private int curLine = 1;
		static ErrorPosition[] errorPosition;
		
		//Convert the unit used by the .NET framework (1/100 inch) 
		//and the unit used by Win32 API calls (twips 1/1440 inch)
		//important for public int Print()
		private const double anInch = 14.4;

		//important for public int Print()
		[StructLayout(LayoutKind.Sequential)] 
		private struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

		//important for public int Print()
		[StructLayout(LayoutKind.Sequential)]
		private struct CHARRANGE
		{
			public int cpMin;         //First character of range (0 for start of doc)
			public int cpMax;           //Last character of range (-1 for end of doc)
		}

		//important for public int Print()
		[StructLayout(LayoutKind.Sequential)]
		private struct FORMATRANGE
		{
			public IntPtr hdc;             //Actual DC to draw on
			public IntPtr hdcTarget;       //Target DC for determining text formatting
			public RECT rc;                //Region of the DC to draw to (in twips)
			public RECT rcPage;            //Region of the whole DC (page size) (in twips)
			public CHARRANGE chrg;         //Range of text to draw (see earlier declaration)
		}

		//important for public int Print()
		private const int WM_USER  = 0x0400;
		private const int EM_FORMATRANGE  = WM_USER + 57;
	
		//important for public int Print()
		[DllImport("USER32.dll")]
		private static extern IntPtr SendMessage (IntPtr hWnd , int msg , IntPtr wp, IntPtr lp); 
		
		public NumberingRichTextBox()
		{
			errorPosition = new ErrorPosition[]{};
			this.HideSelection = false;
			this.AcceptsTab = true;
		}
		public uint MarkedRow{
			get{
				return markedRow;
			}
			set{
				markedRow = value;
			}
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
		public string GetTextLine(uint line)
		{
			if (this.Lines.Length < line) return null;
			return this.Lines[line];
		}
		public void SetTextLine(uint line, string text)
		{
			int lineStartPosition = 0;
			int lineEndPosition = 0;
			if (this.Lines.Length < line) return;
			for(int i=1;i<line;i++){
				lineStartPosition = this.Text.IndexOf('\n',lineStartPosition)+1;
			}
			lineEndPosition = this.Text.IndexOf('\n',lineStartPosition);
			if (lineEndPosition==-1) lineEndPosition = this.Text.Length;
			this.SelectionStart = lineStartPosition;
			this.SelectionLength = lineEndPosition - lineStartPosition;
			this.SelectedText = text;
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			mEdited = true;
			if (e.KeyChar==(char)13){
		    	int line = this.GetLineFromCharIndex(this.SelectionStart);
                if (line > 0 && line <= Lines.Length)
                {
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
		    		if (kShift==true){
	    				int sSelStart= this.SelectionStart;
	    				int sSelLength= this.SelectionLength;
	    				int indexStart = (this.Text.Substring(1,sSelStart).LastIndexOf('\n')+2);
						int indexEnd = this.Text.IndexOf('\n',indexStart);
						if (indexEnd==-1) indexEnd = this.Text.Length;
	    				if (this.Text.Substring(indexStart,indexEnd-indexStart).StartsWith("\t")){
	    					this.SelectionStart = indexStart;
	    					this.SelectionLength = 1;
	    					this.SelectedText = "";
	    					this.SelectionStart = Math.Max((sSelStart-1),indexStart);
	    					this.SelectionLength = Math.Min(sSelLength,(this.Text.Length-indexStart));
	    				}
    					e.Handled = true;
		    		}
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
		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged(e);
			if( this.GetLineFromCharIndex(this.SelectionLength + this.SelectionStart) != this.curLine){
				this.curLine = this.GetLineFromCharIndex(this.SelectionLength + this.SelectionStart);
				if (this.SelectedText.EndsWith("\n")) this.curLine--;
				if (LineChanged != null)
					LineChanged(this, new LineChangedEventArgs(this.curLine+1));
				System.GC.Collect();
			}
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if(e.KeyCode==Keys.ShiftKey){
				kShift=false;
			}
			base.OnKeyDown(e);
		}
		public int SelectLine(int line)
		{
			int sPos = 0;
			int ePos = 0;
			for (int i=1; i<line; i++){
				sPos = this.Text.IndexOf('\n', sPos)+1;
				if (sPos == 0) return -1;
			}
			ePos = this.Text.IndexOf('\n', sPos);
			if (ePos == -1) ePos = this.Text.Length;
			this.Select(sPos, ePos-sPos);
			return 0;
		}
		protected void xPaint()
		{
//			if (!PaintLocked){
//				PaintLocked = true;
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
						//g.SmoothingMode = SmoothingMode.HighQuality;
						if (pt.Length>=1)
							g.DrawCurve(Pens.Red,pt,1.0f);
						//g.DrawLine(Pens.Red, x1,y,x2,y);
					}
				}
				g.Dispose();
				System.GC.Collect();
//				PaintLocked = false;
//			}
				
		}
		protected override void WndProc(ref Message m) 
		{
			base.WndProc(ref m);
			if (m.Msg == WM_PAINT) xPaint();
		}
		
		// Render the contents of the RichTextBox for printing
		//	Return the last character printed + 1 (printing start from this point for next page)
		public int Print( int charFrom, int charTo,PrintPageEventArgs e)
		{
			//Calculate the area to render and print
			RECT rectToPrint; 
			rectToPrint.Top = (int)(e.MarginBounds.Top * anInch);
			rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * anInch);
			rectToPrint.Left = (int)(e.MarginBounds.Left * anInch);
			rectToPrint.Right = (int)(e.MarginBounds.Right * anInch);

			//Calculate the size of the page
			RECT rectPage; 
			rectPage.Top = (int)(e.PageBounds.Top * anInch);
			rectPage.Bottom = (int)(e.PageBounds.Bottom * anInch);
			rectPage.Left = (int)(e.PageBounds.Left * anInch);
			rectPage.Right = (int)(e.PageBounds.Right * anInch);

			IntPtr hdc = e.Graphics.GetHdc();

			FORMATRANGE fmtRange;
			fmtRange.chrg.cpMax = charTo;				//Indicate character from to character to 
			fmtRange.chrg.cpMin = charFrom;
			fmtRange.hdc = hdc;                    //Use the same DC for measuring and rendering
			fmtRange.hdcTarget = hdc;              //Point at printer hDC
			fmtRange.rc = rectToPrint;             //Indicate the area on page to print
			fmtRange.rcPage = rectPage;            //Indicate size of page

			IntPtr res = IntPtr.Zero;

			IntPtr wparam = IntPtr.Zero;
			wparam = new IntPtr(1);

			//Get the pointer to the FORMATRANGE structure in memory
			IntPtr lparam= IntPtr.Zero;
			lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
			Marshal.StructureToPtr(fmtRange, lparam, false);

			//Send the rendered data for printing 
			res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam);

			//Free the block of memory allocated
			Marshal.FreeCoTaskMem(lparam);

			//Release the device context handle obtained by a previous call
			e.Graphics.ReleaseHdc(hdc);

			//Return last + 1 character printer
			return res.ToInt32();
		}

	}
}
