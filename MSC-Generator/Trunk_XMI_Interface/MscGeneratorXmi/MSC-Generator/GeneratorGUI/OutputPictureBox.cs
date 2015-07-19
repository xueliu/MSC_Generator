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
	public class OutputPictureBox : System.Windows.Forms.PictureBox
	{
        protected const int WM_PAINT = 0x000F;
        protected const int WM_MOVE = 0x0003;	 	
        private bool _paint = true;
        public OutputPictureBox()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
//   			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
//   			SetStyle(ControlStyles.DoubleBuffer, true);
//   			SetStyle(ControlStyles.EnableNotifyMessage, false);
//			SetStyle(ControlStyles.UserPaint, true);	
//			SetStyle(ControlStyles.ResizeRedraw, false);	
//   			SetStyle(ControlStyles.ContainerControl, false);
 			

        }
        public bool RePaint
        {
            get
            {
                return _paint;
            }
            set
            {
                _paint = value;
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }
        public override void Refresh()
        {
            base.Refresh();
        }
        public override bool PreProcessMessage(ref Message msg)
        {
            return base.PreProcessMessage(ref msg);
        }
        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
        }
        protected override void OnLoadCompleted(AsyncCompletedEventArgs e)
        {
            base.OnLoadCompleted(e);
        }
        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
        }
        protected override void OnNotifyMessage(Message m)
        {
            base.OnNotifyMessage(m);
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
        }
        protected override void InitLayout()
        {
            base.InitLayout();
        }
        protected override void OnParentBindingContextChanged(EventArgs e)
        {
            base.OnParentBindingContextChanged(e);
        }
        protected override void OnParentCursorChanged(EventArgs e)
        {
            base.OnParentCursorChanged(e);
        }
        protected override void OnParentVisibleChanged(EventArgs e)
        {
            base.OnParentVisibleChanged(e);
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }
        protected override void WndProc(ref Message m)
        {
            if (_paint != true)
            {
                m.Result = (IntPtr)0;
            }
            else
            {
#if DebugHelp
//			Trace.WriteLine(DebugHelp.WindowsMessageNameByMessage(m.Msg));
#endif
                base.WndProc(ref m);
            }
        }
	}
}
