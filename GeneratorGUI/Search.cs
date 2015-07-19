/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of Search.
	/// </summary>
	public partial class Search
	{
		public event EventHandler OnSearchClick;
		public event EventHandler OnCancelClick;
		public event EventHandler OnClose;
		
		public Search()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SearchClose);
            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
		}

        void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                if (OnSearchClick != null) OnSearchClick(this, new EventArgs());
        }
		public string SearchText{
			get{
				return this.txtSearch.Text;
			}
			set{
				this.txtSearch.Text = value;
			}
		}
		public bool SearchWordOnly{
			get{
				return this.chkWordOnly.Checked;
			}
			set{
				this.chkWordOnly.Checked = value;
			}
		}
		public bool SearchUpperLowerCase{
			get{
				return this.chkCase.Checked;
			}
			set{
				this.chkCase.Checked = value;
			}
		}

		void SearchClose(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (OnClose != null) OnClose(this, new EventArgs());						
		}

        private void cmdSearchAgain_Click(object sender, EventArgs e)
        {
            if (OnSearchClick != null) OnSearchClick(this, new EventArgs());
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (OnCancelClick != null) OnCancelClick(this, new EventArgs());
        }

        


	}
}
