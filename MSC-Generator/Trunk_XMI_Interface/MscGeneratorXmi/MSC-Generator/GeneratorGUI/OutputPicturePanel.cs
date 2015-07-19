//#define DebugHelp
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
#if DebugHelp
using DebugHelps;
#endif
//#define TRACE

namespace GeneratorGUI
{
	/// <summary>
	/// Description of MyPanel.
	/// </summary>
	public class OutputPicturePanel : System.Windows.Forms.Panel
	{
	 	protected const int WM_PAINT = 0x000F;
		private bool _paint = true;
        private bool mouseWheelAllow = true;

		public OutputPicturePanel()
		{
   			Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
   			Trace.AutoFlush = true;
   			Trace.Indent();
 			

		}
		public bool RePaint{
			get{
				return _paint;
			}
			set{
				_paint = value;
			}
		}
        public bool MouseWheelAllow
        {
            get
            {
                return mouseWheelAllow;
            }
            set
            {
                mouseWheelAllow = value;
            }
        }
		protected override void OnMouseWheel(MouseEventArgs e)
		{
            if (mouseWheelAllow)
			    base.OnMouseWheel(e);
		}
        
		public override bool PreProcessMessage(ref Message msg)
		{
			return base.PreProcessMessage(ref msg);
		}
		protected override void OnValidating(CancelEventArgs e)
		{
			if (_paint==true)
				base.OnValidating(e);
		}
        
		protected override void DefWndProc(ref Message m)
		{
			if (_paint==true)
				base.DefWndProc(ref m);
		}

		protected override void OnNotifyMessage(Message m)
		{
			if (_paint==true)
				base.OnNotifyMessage(m);
		}

		protected override void InitLayout()
		{
			if (_paint==true)
				base.InitLayout();
		}
		protected override void OnLayout(LayoutEventArgs levent)
		{
			if (_paint==true){
				base.OnLayout(levent);
			}
		}
        
		protected override Point ScrollToControl(Control activeControl)
		{
			//return base.ScrollToControl(activeControl);
			return this.AutoScrollPosition; 
		}

        
		protected override void AdjustFormScrollbars(bool displayScrollbars)
		{
			if (_paint==true){
				base.AdjustFormScrollbars(displayScrollbars);
			}
		}

        //protected override void OnResize(EventArgs e)
        //{
        ////	base.OnResize(e);
        //}
        //protected override void OnLocationChanged(EventArgs e)
        //{
        //    //base.OnLocationChanged(e);
        //}
        //        protected override void OnClientSizeChanged(EventArgs e)
        //        {
        ////			if (_paint==true)
        ////				base.OnClientSizeChanged(e);
        //        }
        //protected override void OnSizeChanged(EventArgs e)
        //{
        ////	base.OnSizeChanged(e);
        //}
        //protected override void OnAutoSizeChanged(EventArgs e)
        //{
        //    //base.OnAutoSizeChanged(e);
        //}
        //        protected override void OnInvalidated(InvalidateEventArgs e)
        //        {
        ////			if (_paint==true)
        ////				base.OnInvalidated(e);
        //        }
        //protected override void OnBackgroundImageChanged(EventArgs e)
        //{
        //    //base.OnBackgroundImageChanged(e);
        //}
        //protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        //{
        //    //base.OnBackgroundImageLayoutChanged(e);
        //}
        //public override void Refresh()
        //{
        //    //base.Refresh();
        //}
        //protected override void OnEnter(EventArgs e)
        //{
        //    //base.OnEnter(e);
        //}
//        protected override void OnVisibleChanged(EventArgs e)
//        {
////			if (_paint==true)
////				base.OnVisibleChanged(e);
//        }
        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}
        //protected override void OnScroll(ScrollEventArgs se)
        //{
        //    base.OnScroll(se);
        //}
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);
        //}
        //protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        //{
        //    //base.OnGiveFeedback(gfbevent);
        //}
        //protected override void OnGotFocus(EventArgs e)
        //{
        //    //base.OnGotFocus(e);
        //}
		protected override void OnCausesValidationChanged(EventArgs e)
		{
			base.OnCausesValidationChanged(e);
		}
		protected override void WndProc(ref Message m) 
		{
			if ((_paint!=true)){
				m.Result = (IntPtr)0;
			}
			else{
#if DebugHelp
	//if((m.Msg != DebugHelp.WM_NCHITTEST) && (m.Msg != DebugHelp.WM_MOUSEMOVE)&& (m.Msg != DebugHelp.WM_NCMOUSEMOVE)&& (m.Msg != DebugHelp.WM_SETCURSOR)&& (m.Msg != DebugHelp.WM_GETTEXTLENGTH)&& (m.Msg != DebugHelp.WM_GETTEXT))
//Trace.WriteLine("Panel: " + DebugHelp.WindowsMessageNameByMessage(m.Msg));
#endif			
				base.WndProc(ref m);
			}
		}
	}
}
