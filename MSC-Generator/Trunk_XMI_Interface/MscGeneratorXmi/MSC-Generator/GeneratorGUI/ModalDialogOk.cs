/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 22.01.2008
 * Zeit: 17:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of ModalDialogOk.
	/// </summary>
	public partial class ModalDialogOk : Form
	{
		public ModalDialogOk(string dialogText)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.dialogDescriptionLabel.Text=dialogText;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public ModalDialogOk():this(""){}
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
