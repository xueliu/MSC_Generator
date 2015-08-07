/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of InfoTemplate.
	/// </summary>
	public partial class InfoTemplate
	{
		public InfoTemplate()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.lblLizenztyp.Text = "Nicht für den kommerziellen Gebrauch.";
			this.lblLizenzNr.Text = "Lizenz Nr.: WXYZ-1234-ABCD";
			this.lblFirma1.Text = "Lizensiert für: Mustermann GmbH";
			this.lblFirma2.Text = "";
		}
		
		void LnkItesysLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(lnkItesys.Text);
		}
	}
}
