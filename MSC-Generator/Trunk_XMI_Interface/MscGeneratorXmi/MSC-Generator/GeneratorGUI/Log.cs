/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
	public enum LogIcon{
		Note,
		Question,
		Error
	}
	
	/// <summary>
	/// Description of Log.
	/// </summary>
	/// 
	public partial class Log
	{
		private GUI gui;
        protected static Point dialogLocation = new Point (0,0);
        public Log()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
		public Log(GUI gui)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.gui = gui;
			this.Location = new System.Drawing.Point((gui.Location.X + gui.Width -this.Width-5)/2, gui.Location.Y-25+gui.Height-this.Height);
            this.lstv.Click +=new EventHandler(lstv_Click);
            this.lstv.DoubleClick += new EventHandler(lstv_DoubleClick);
            this.Move += new EventHandler(DialogMove);
		}

       
		public void AppendLogText(LogIcon icon, int line, string text){
			string sLine = line.ToString();
			
			if(line == -1)							//line-Werte von -1 werden nicht dargestellt!
				sLine = "";
			if(icon == LogIcon.Note){		//Darstellung des Note-Pics (Ausrufezeichen)
				ListViewItem item = this.lstv.Items.Add("",0);
				item.SubItems.Add(sLine);
				item.SubItems.Add(text);
			}
			if(icon == LogIcon.Error){		//Darstellung des Error-Pics (X)
				ListViewItem item = this.lstv.Items.Add("",1);
				item.SubItems.Add(sLine);
				item.SubItems.Add(text);
			}
			if(icon == LogIcon.Question){	//Darstellung des Question-Pics (Fragezeichen)
				ListViewItem item = this.lstv.Items.Add("",2);
				item.SubItems.Add(sLine);
				item.SubItems.Add(text);
       		}
		}
		public void ClearLogText(){
			this.lstv.Items.Clear();
		}
       
        void lstv_DoubleClick(object sender, EventArgs e)
        {
            gui.LogDoubleClick();
        }

        void lstv_Click(object sender, EventArgs e)
        {
            gui.LogClick();
        }

        private void lstv_SelectedIndexChanged(object sender, EventArgs e)
        {
            gui.LogSelectedIndexChanged();
        }

        public int ItemsCount
        {
            get
            {
                return this.lstv.Items.Count;
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
        private void DialogMove(object sender, EventArgs e)
        {
			Log.DialogLocation = this.Location;
        }
	}
}
