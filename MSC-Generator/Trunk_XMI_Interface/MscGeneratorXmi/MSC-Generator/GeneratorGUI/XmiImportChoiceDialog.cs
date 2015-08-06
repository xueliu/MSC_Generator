/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 21.01.2008
 * Zeit: 21:11
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of XmiImportChoiceDialog.
	/// </summary>
	public partial class XmiImportChoiceDialog : Form
	{	
		public XmiImportChoiceDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			// Set "PapyrusXmiFormat" as default
			importFormatChoiceComboBox.SelectedIndex = 1;
		}
		
		public ComboBox ImportFormatChoiceComboBox{
			get{
				return importFormatChoiceComboBox;
			}
		}
		
		void OkButtonClick(object sender, EventArgs e)
		{
			this.DialogResult= DialogResult.OK;
		}
		
		void CancelButtonClick(object sender, EventArgs e)
		{
			this.DialogResult= DialogResult.Cancel;
		}	
	}
}
