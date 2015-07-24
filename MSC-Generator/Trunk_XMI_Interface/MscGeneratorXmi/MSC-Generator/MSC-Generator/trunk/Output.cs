/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 18.05.2005
 * Time: 12:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
//#define TRACE
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Resources;
using LicenseKey;
using mscElements;
using mscEditor;
using mscPreview;
using MscItemProp;
using GeneratorGUI;
using NumberingEditor;
//LG
using xmiExport;
using xmiExportPapyrus;
using xmiImport;
using xmiImportPapyrus;
using System.Xml;
using xmi;


namespace nGenerator
{
	/// <summary>
	/// Description of Output.
	/// </summary>
	
	public sealed partial class Output : GUI
	{
		//TODO: Refaktorisieren (Umbenennen von Prozessen)
		//TODO: Propertyfenster einrasten
		public static string	stringResources = "nGenerator.strings";
		
		//private const uint 		appType					= 0x4D534301;
		//private License 		license 				= new License();
		private Editor editor = null;
		private MscStyle oldRepertoryStyle = MscStyle.Unknown;
		private bool mRedrawOutput = true;
		// if false no output redraw
		private Log log = null;
		private ResourceManager resources = new ResourceManager(typeof(Output));
		private static string helpLocation = string.Empty;
		public ResourceManager strings = new ResourceManager("nGenerator.strings", Assembly.GetAssembly(typeof(Output)));
		
		//LG
		private const string STANDARD_XMI_FORMAT = "StandardXmiFormat";
		private const string PAPYRUS_XMI_FORMAT = "PapyrusXmiFormat";
		private const string EMPTY_STRING = "";
		
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.Run(new Output(args));
		}
		
		public Output(string[] args)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			//Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
			//Trace.AutoFlush = true;
			//Trace.Indent();
			editor = new Editor(this, this.rtbMscEditor);
			generator = new Generator(this);
			fileFilter = strings.GetString("FileFilter");
			try {
				InitializeComponent();
				OwenInitializeComponent();
				//this.addRepertory();
				this.NewImage();
				// initialize the status bar output
				if (args.Length == 0) {
					Start start = new Start();
					start.ShowDialog();	
				}
				if (args.Length == 1) {
					this.LoadFile(args[0], true);
				}
				if (args.Length == 2) {
					string directory;
					if (args[0].LastIndexOf(@"\") < 1) {
						directory = Environment.CurrentDirectory;
					} else {
						directory = Path.GetDirectoryName(args[0]);
					}
					DirectoryInfo di = new DirectoryInfo(directory);
					FileInfo[] result = di.GetFiles(Path.GetFileName(args[0]));
					if (result.Length > 0) {
						for (int i = 0; i < result.Length; i++) {
							generator.Clear();
							this.LoadFile(result[i].FullName, false);
							this.ExportImage(result[i].FullName, args[1]);
						}
					}
					Application.ExitThread();
				}
				if (args.Length >= 3) {

					string srcDirectory, destDirectory;
					if (args[0].LastIndexOf(@"\") < 1) {
						srcDirectory = Environment.CurrentDirectory;
					} else {
						srcDirectory = Path.GetDirectoryName(args[0]);
					}
					destDirectory = args[1];
					DirectoryInfo srcDi = new DirectoryInfo(srcDirectory);
					DirectoryInfo destDi = new DirectoryInfo(destDirectory);
					FileInfo[] result = srcDi.GetFiles(Path.GetFileName(args[0]));
					if (!destDi.Exists) {
						Directory.CreateDirectory(@destDirectory);
					}
					if (result.Length > 0) {
						for (int i = 0; i < result.Length; i++) {
							generator.Clear();
							this.LoadFile(result[i].FullName, true);
							this.ExportImage(destDirectory + "\\" + result[i].Name, args[2]);
						}
					}
				}
			} catch (System.Security.SecurityException ex) {
				MessageBox.Show(ex.Message);
			} catch (System.Exception ex) {
				MessageBox.Show(ex.Message);
			}
			this.Show();
			this.CenterPage();
			this.ShowGraphicMenu();
		}
		public bool RedrawOutput {
			get {
				return mRedrawOutput;
			}
			set {
				mRedrawOutput = value;
			}
		}
		public static string HelpLocation {
			get {
				return helpLocation;
			}
			set {
				helpLocation = value;
			}
		}
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Output));
			this.hlpGen = new System.Windows.Forms.HelpProvider();
			this.umnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
			this.pnlOutput.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabWork.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sourceFileWatch)).BeginInit();
			this.splitContainerEditor.Panel1.SuspendLayout();
			this.splitContainerEditor.Panel2.SuspendLayout();
			this.splitContainerEditor.SuspendLayout();
			this.SuspendLayout();
			// 
			// rtbMscEditor
			// 
			this.hlpGen.SetHelpNavigator(this.rtbMscEditor, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.hlpGen.SetShowHelp(this.rtbMscEditor, true);
			this.rtbMscEditor.Size = new System.Drawing.Size(642, 389);
			this.rtbMscEditor.SelectionChanged += new EventHandler(EditorHelpRequested);
			// 
			// tabPage2
			// 
			this.hlpGen.SetShowHelp(this.tabPage2, true);
			this.tabPage2.Size = new System.Drawing.Size(872, 389);
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// pnlParameter
			// 
			this.pnlParameter.Location = new System.Drawing.Point(128, 389);
			this.hlpGen.SetShowHelp(this.pnlParameter, true);
			this.pnlParameter.Size = new System.Drawing.Size(744, 0);
			// 
			// picOutput
			// 
			this.hlpGen.SetShowHelp(this.picOutput, true);
			// 
			// pnlOutput
			// 
			this.hlpGen.SetShowHelp(this.pnlOutput, true);
			this.pnlOutput.Size = new System.Drawing.Size(744, 389);
			// 
			// tabPage1
			// 
			this.hlpGen.SetShowHelp(this.tabPage1, true);
			this.tabPage1.Size = new System.Drawing.Size(872, 389);
			this.tabPage1.Text = "Output";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabWork
			// 
			this.tabWork.Location = new System.Drawing.Point(0, 56);
			this.hlpGen.SetShowHelp(this.tabWork, true);
			this.tabWork.Size = new System.Drawing.Size(880, 415);
			// 
			// dlgPreviewPage
			// 
			this.dlgPreviewPage.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPreviewPage.Icon")));
			this.hlpGen.SetShowHelp(this.dlgPreviewPage, true);
			// 
			// lstRepertory
			// 
			this.hlpGen.SetShowHelp(this.lstRepertory, true);
			this.lstRepertory.Size = new System.Drawing.Size(225, 389);
			// 
			// lstPreview
			// 
			this.hlpGen.SetShowHelp(this.lstPreview, true);
			this.lstPreview.Size = new System.Drawing.Size(128, 389);
			// 
			// splitContainerEditor
			// 
			// 
			// splitContainerEditor.Panel1
			// 
			this.hlpGen.SetShowHelp(this.splitContainerEditor.Panel1, true);
			// 
			// splitContainerEditor.Panel2
			// 
			this.hlpGen.SetShowHelp(this.splitContainerEditor.Panel2, true);
			this.hlpGen.SetShowHelp(this.splitContainerEditor, true);
			this.splitContainerEditor.Size = new System.Drawing.Size(872, 389);
			this.splitContainerEditor.SplitterDistance = 225;
			// 
			// tlbbZoomFitWide
			// 
			this.tlbbZoomFitWide.Visible = false;
			// 
			// hlpGen
			// 
			this.hlpGen.HelpNamespace = Application.StartupPath + "\\MscGenHelp.chm";// "C:\\Dokumente und Einstellungen\\koto\\Eigene Dateien\\Intern\\MSC-Generator\\trunk\\bin" + 			"\\Debug\\MscGenHelp.chm";
			// 
			// umnuHelp
			// 
			this.umnuHelp.Name = "umnuHelp";
			this.umnuHelp.Size = new System.Drawing.Size(32, 19);
			// 
			// Output
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(880, 494);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "Output";
			this.hlpGen.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.OutputLoad);
			this.Controls.SetChildIndex(this.tabWork, 0);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
			this.pnlOutput.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabWork.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sourceFileWatch)).EndInit();
			this.splitContainerEditor.Panel1.ResumeLayout(false);
			this.splitContainerEditor.Panel2.ResumeLayout(false);
			this.splitContainerEditor.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.HelpProvider hlpGen;
		private ToolStripMenuItem umnuHelp;
		private void OwenInitializeComponent()
		{
			// 
			// umnuHelp
			// 
			this.umnuHelp.Name = "umnuHelp";
			this.umnuHelp.Size = new System.Drawing.Size(98, 22);
			this.umnuHelp.Text = strings.GetString("Help");
			this.umnuHelp.Click += new System.EventHandler(this.CmnuHelpClick);
			this.mnuInfo.DropDownItems.Add(umnuHelp);
			this.dragDropFileExtension = ".sc";
			CreatePDF();
			// 
		}
		protected override void OpenOptionsDialog()
		{
			if (OptionsDialog.ActiveDialog != null) { 			// if options dialog allready open
				OptionsDialog.ActiveDialog.Close();			// close him
			}
			Property sheetOptions = new Property();			// create and open new options dialog
			sheetOptions.OnAcceptClick += new System.EventHandler(this.DialogOptionsAccept);
			sheetOptions.Location = OptionsDialog.DialogLocation;
			sheetOptions.Show();
		}
		protected override void DialogOptionsAccept(object sender, System.EventArgs e)
		{
			MSC.Style = ((Property)sender).DiagramStyle;
			MSC.DiagramName = ((Property)sender).DiagramName;
			Output.AutosizeExport = ((Property)sender).AutosizeExport;
			editor.CheckSyntax();
			RedrawRescaled();
		}
		/// <summary>
		/// change the head part of diagram text to actual values. called after options dialog accept button 
		/// </summary>
		/// <returns>nothing</returns>
		
		public override void RedrawRescaled()
		{
			int startPos = 0;
			int endPos = 0;
			StringBuilder temp = new StringBuilder();
			editor.Update = true;
/*************************************************
 * 
 * FONT
 * 
 * ***********************************************/
			
			temp.Remove(0, temp.Length);
			temp.Append("Font: \"");
			temp.Append(MSCItem.ItemFont.FontFamily.Name);
			temp.Append("\", \"");
			temp.Append(MSCItem.ItemFont.Size.ToString());
			temp.Append("\", \"");
			if (MSCItem.ItemFont.Style == System.Drawing.FontStyle.Regular) {
				temp.Append("Regular");
			} else {
				if (MSCItem.ItemFont.Bold == true)
					temp.Append("Bold ");
				if (MSCItem.ItemFont.Italic == true)
					temp.Append("Italic ");
				if (MSCItem.ItemFont.Strikeout == true)
					temp.Append("Strikeout ");
				if (MSCItem.ItemFont.Underline == true)
					temp.Append("Underline ");
			}
			temp.Append("\"");
			startPos = this.rtbMscEditor.Find("FONT:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * PRINT FILENAME
 * 
 * ***********************************************/
			
			temp.Remove(0, temp.Length);
			temp.Append("PrintFileName: ");
			if (true == Worksheet.DrawFileName)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTFILENAME:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				if (true == Worksheet.DrawFootLine)
					this.rtbMscEditor.SelectedText = temp.ToString();
				else
					this.rtbMscEditor.SelectedText = "";
			} else if (true == Worksheet.DrawFootLine) {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * PRINT CREATIONDATE
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PrintCreationDate: ");
			if (true == Worksheet.DrawPrintDate)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTCREATIONDATE:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				if (true == Worksheet.DrawFootLine)
					this.rtbMscEditor.SelectedText = temp.ToString();
				else
					this.rtbMscEditor.SelectedText = "";
			} else if (true == Worksheet.DrawFootLine) {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * PRINT DATE
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PrintDate: ");
			if (true == Worksheet.DrawDate)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTDATE:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				if (true == Worksheet.DrawFootLine)
					this.rtbMscEditor.SelectedText = temp.ToString();
				else
					this.rtbMscEditor.SelectedText = "";
			} else if (true == Worksheet.DrawFootLine) {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * DATE
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("Date: ");
			if ("" == Worksheet.Date.Trim())
				temp.Append("\"\"");
			else
				temp.Append(Worksheet.Date);
			startPos = this.rtbMscEditor.Find("DATE:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}

/*************************************************
 * 
 * PRINT VERSION
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PrintVersion: ");
			if (true == Worksheet.DrawVersion)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTVERSION:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				if (true == Worksheet.DrawFootLine)
					this.rtbMscEditor.SelectedText = temp.ToString();
				else
					this.rtbMscEditor.SelectedText = "";
			} else if (true == Worksheet.DrawFootLine) {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * VERSION
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("Version: ");
			if ("" == Worksheet.Version.Trim())
				temp.Append("\"\"");
			else
				temp.Append(Worksheet.Version);
			startPos = this.rtbMscEditor.Find("VERSION:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
			
/*************************************************
 * 
 * PRINT COMPANY
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PrintCompany: ");
			if (true == Worksheet.DrawCompany)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTCOMPANY:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				if (true == Worksheet.DrawFootLine)
					this.rtbMscEditor.SelectedText = temp.ToString();
				else
					this.rtbMscEditor.SelectedText = "";
			} else if (true == Worksheet.DrawFootLine) {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * COMPANY
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("Company: ");
			if ("" == Worksheet.Company.Trim())
				temp.Append("\"\"");
			else
				temp.Append(Worksheet.Company);
			startPos = this.rtbMscEditor.Find("COMPANY:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * PRINT AUTHOR
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PrintAuthor: ");
			if (true == Worksheet.DrawAuthor)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTAUTHOR:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
					temp.Append("\n");
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				if (true == Worksheet.DrawFootLine)
					this.rtbMscEditor.SelectedText = temp.ToString();
				else
					this.rtbMscEditor.SelectedText = "";
			} else if (true == Worksheet.DrawFootLine) {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * AUTHOR
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("Author: ");
			if ("" == Worksheet.Author.Trim())
				temp.Append("\"\"");
			else
				temp.Append(Worksheet.Author);
			startPos = this.rtbMscEditor.Find("AUTHOR:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
			
/*************************************************
 * 
 * PRINT FOOTLINE
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PrintFootLine: ");
			if (true == Worksheet.DrawFootLine)
				temp.Append("yes");
			else
				temp.Append("no");
			startPos = this.rtbMscEditor.Find("PRINTFOOTLINE:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * LINEOFFSET
 * 
 * ***********************************************/
/*			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("LINEOFFSET");
			if (startPos>-1){
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n',startPos)==-1){
					endPos = this.rtbMscEditor.Text.Length;
				}
				else{
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n',startPos);
				}
				this.rtbMscEditor.Select(startPos,endPos-startPos);
				this.rtbMscEditor.SelectedText = "LineOffset: " + MSC.VerticalOffset;
			}
			else{
				this.rtbMscEditor.Select(0,0);
				this.rtbMscEditor.SelectedText = "LineOffset: " + MSC.VerticalOffset + "\n";
			}
*/
/*************************************************
 * 
 * BOTTOM MARGIN
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCMARGINBOTTOM");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
/*************************************************
 * 
 * RIGHT MARGIN
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCMARGINRIGHT");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}

/*************************************************
 * 
 * TOP MARGIN
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCMARGINTOP");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
/*************************************************
 * 
 * LEFT MARGIN
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCMARGINLEFT");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
				
/*************************************************
 * 
 * PAGEMARGINS
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("PAGEMARGINS");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "PageMargins: " + this.worksheet.LeftMargin.ToString() + ", " + this.worksheet.TopMargin.ToString() + ", " + this.worksheet.RightMargin.ToString() + ", " + this.worksheet.BottomMargin.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = "PageMargins: " + this.worksheet.LeftMargin.ToString() + ", " + this.worksheet.TopMargin.ToString() + ", " + this.worksheet.RightMargin.ToString() + ", " + this.worksheet.BottomMargin.ToString() + "\n";
			}
/*************************************************
 * 
 * WIDTH
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCWIDTH");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
/*************************************************
 * 
 * HEIGHT
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCHEIGHT");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}				
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
/*************************************************
 * 
 *PAGESIZE
 * 
 * ***********************************************/
			temp.Remove(0, temp.Length);
			temp.Append("PageSize: ");
			if (worksheet.Size != Worksheet.WS_SIZE_USER_DEFINED) {
				switch (worksheet.Size) {
					case Worksheet.WS_SIZE_A0_ISO:
						temp.Append("A0, ");
						break;
					case Worksheet.WS_SIZE_A1_ISO:
						temp.Append("A1, ");
						break;
					case Worksheet.WS_SIZE_A2_ISO:
						temp.Append("A2, ");
						break;
					case Worksheet.WS_SIZE_A3_ISO:
						temp.Append("A3, ");
						break;
					case Worksheet.WS_SIZE_A4_ISO:
						temp.Append("A4, ");
						break;
					case Worksheet.WS_SIZE_A5_ISO:
						temp.Append("A5, ");
						break;
				}
				switch (worksheet.Layout) {
					case Worksheet.WS_LAYOUT_HORIZONTAL:
						temp.Append("H");
						break;
					case Worksheet.WS_LAYOUT_VERTICAL:
						temp.Append("V");
						break;
				}
			} else {				// size user defined
				if (Output.AutosizeOutputWidth == true) {
					temp.Append("auto");
				} else {
					temp.Append(worksheet.Width.ToString());
				}
				if (Output.AutosizeOutputHeight == true) {
					temp.Append(", auto");
				} else {
					temp.Append(", " + worksheet.Height.ToString());
				}
			}
			startPos = this.rtbMscEditor.Find("PAGESIZE:", RichTextBoxFinds.WholeWord);
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = temp.ToString();
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
			}
/*************************************************
 * 
 * MSCSTYLE
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCSTYLE");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}				
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
/*************************************************
 * 
 * DIAGRAMSTYLE
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("DIAGRAMSTYLE");
			string style = "";
			if (MSC.Style == MscStyle.SDL) {
				style = "sdl";
			} else if (MSC.Style == MscStyle.UML2) {
				style = "uml";
			}
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "DiagramStyle: " + style;
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = "DiagramStyle: " + style + "\n";
			}
/*************************************************
 * 
 * MSCNAME
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("MSCNAME");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
				}				
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "";
			}
/*************************************************
 * 
 * DIAGRAMSTYLE
 * 
 * ***********************************************/
			startPos = this.rtbMscEditor.Text.ToUpper().IndexOf("DIAGRAMNAME");
			if (startPos > -1) {
				if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
					endPos = this.rtbMscEditor.Text.Length;
				} else {
					endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos);
				}
				this.rtbMscEditor.Select(startPos, endPos - startPos);
				this.rtbMscEditor.SelectedText = "DiagramName: " + MSC.DiagramName;
			} else {
				this.rtbMscEditor.Select(0, 0);
				this.rtbMscEditor.SelectedText = "DiagramName: " + MSC.DiagramName + "\n";
			}

			editor.Update = false;
			editor.checkSyntaxAll();
			generator.Clear();
			Interpreter interpreter = new Interpreter();	
			InterpretException[] results = interpreter.InterpretDiagramText(this.rtbMscEditor.Text, generator, this);		// interpret new .sc file
			this.WriteLog(results);
			base.RedrawRescaled();
 			

		}
		/// <description>redraw whole image list and output image</description>
		protected override void DrawNew()
		{
			if (this.RedrawOutput == false)
				return;
			this.RedrawOutput = false;															// dont allow the AddPreview redraw the output image
			generator.Clear();
			Interpreter interpreter = new Interpreter();	
			InterpretException[] results = interpreter.InterpretDiagramText(this.rtbMscEditor.Text, generator, this);		// interpret new .sc file
			this.WriteLog(results);
			this.InitDrawDestination();
			generator.CalcLineHights(drawDestination, tmpWorksheet, MSCItem.ItemFont);				// calculate new heights of all imageBitmap lines
			uint pages = this.GetPages();	
			//uint pages = generator.GetPages(tmpWorksheet.GetWorksheetHeight());					// calculate number of pages
			if (Output.AutosizeOutputWidth) {
				if (generator.EmptyDiagram == true) {
					worksheet.Width = 800;
				} else {
					try {
						worksheet.SetWorksheetWidth((int)generator.AutoWidth);
					} catch {
					}
				}
			}
			if (Output.AutosizeOutputHeight) {
				if (generator.EmptyDiagram == true) {
					worksheet.Height = 600;
				} else {
					try {
						worksheet.SetWorksheetHeight((int)generator.PageHeights[0]);
					} catch {
					}
				}
			}
			base.RedrawRescaled();
			drawDestination.Clear(Color.White);													// clear old picture
			drawDestination.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;	// set quality of output picture
			drawDestination.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			AddPreview();																		// draw all small pictures for the image list
			drawDestination.Dispose();
			this.RedrawOutput = true; 
			this.SetDiagramIsEmpty(generator.EmptyDiagram);
			if (pages == 0)
				return;																// if nothing to do, do nothing
			MSCItem item = null;
			if ((OptionsDialog.ActiveDialog != null) && (OptionsDialog.ActiveDialog is Property)) {
				item = generator.GetMscItemByID(((Property)OptionsDialog.ActiveDialog).ItemID);
				if (item != null) {
					if ((this.lstPreview.SelectedIndex == ((int)item.ItemPage - 1)) || ((int)item.ItemPage == 0)) 	// if selected page not changed or item (process, actor) on all pages
						this.RedrawImage();											// then force redraw
					else
						this.lstPreview.SelectedIndex = ((int)item.ItemPage - 1);	// else select page; redraw occurs on selected index change
				} else if (this.lstPreview.Items.Count > 0) {
					this.RedrawImage();
				}
			} else if (this.lstPreview.Items.Count > 0) {
				this.RedrawImage();
				//this.lstPreview.SelectedIndex = 0;
			}
			
			this.SetStatusBarSize(this.worksheet.GetWorksheetWidth(), this.worksheet.GetWorksheetHeight());
			this.picOutput.Invalidate();
			System.GC.Collect();// refresh the output picture
		}
		protected override void RescaleImage()
		{
			Trace.WriteLine(DateTime.Now.TimeOfDay + " Entering RescaleImage");
			base.RescaleImage();
			this.InitDrawDestination();
			generator.CalcLineHights(drawDestination, tmpWorksheet, MSCItem.ItemFont);				// calculate new heights of all imageBitmap lines
			Trace.WriteLine(DateTime.Now.TimeOfDay + " Leaving RescaleImage");
		}
		protected override void DrawPage(Graphics drawDestination, uint page)
		{
			generator.CalcOffsets(drawDestination, worksheet);
			generator.DrawPage(drawDestination, worksheet, page);
		}
		/// <description>redraw whole image list pictures</description>
		protected override void AddPreview()
		{
			uint pages;
			Image mscPreview = null;
			Graphics previewDestination = null, drawDestinationBmp = null;
			Worksheet w = new Worksheet();
			w.WorksheetValues = worksheet.WorksheetValues;
			float wHeight = worksheet.GetWorksheetHeight();
			float wWidth = worksheet.GetWorksheetWidth();
//			pages = this.GetPages();
			pages = generator.DiagramPages;
			generator.ChangeAllItemPens(new Pen(Color.Silver, 10));						// change all item pens and brushes for image list pictures
			generator.ChangeAllProcessPens(new Pen(Color.Silver, 10));
			
			this.lstPreview.Items.Clear();												// clear old image list
			previewImages.Clear();														// clear list of old image list pictures
			for (uint i = 1; i <= pages; i++) {												// for all pages a image list picture shall be generated
				if (Output.AutosizeOutputWidth) {
					if (generator.EmptyDiagram == true) {
						wWidth = worksheet.Width = 800;
					} else {
						worksheet.SetWorksheetWidth((int)generator.AutoWidth);
						wWidth = (int)generator.AutoWidth;
					}
				}
				if (Output.AutosizeOutputHeight) {
					if (generator.EmptyDiagram == true) {
						wHeight = worksheet.Height = 600;
					} else {
						worksheet.SetWorksheetHeight((int)generator.PageHeights[i - 1]); // correct height for export
						wHeight = (int)generator.PageHeights[i - 1];
					}
				}
				imageBitmap = new Bitmap((int)wWidth, (int)wHeight); 		// working bitmap, draw destination of generated msc
				drawDestinationBmp = Graphics.FromImage(imageBitmap);
				mscPreview = new Bitmap(90, Math.Min((int)(wHeight / (wWidth / 90)), 200));
				previewDestination = Graphics.FromImage(mscPreview);
				
				StringFormat previewStringFormat = new StringFormat();
				previewStringFormat.Alignment = StringAlignment.Center;
				previewStringFormat.LineAlignment = StringAlignment.Center;
				previewDestination.Clear(Color.White);
				drawDestinationBmp.Clear(Color.White);
				generator.DrawPage(drawDestinationBmp, worksheet, i);					// draw imageBitmap for image list picture
				previewDestination.DrawImage(imageBitmap, new RectangleF(0, 0, 90, mscPreview.Height));		// scale to width = 90
				previewDestination.DrawString(strings.GetString("Page ") + i.ToString(), new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point), Brushes.DarkBlue, new RectangleF(0, 0, 90, mscPreview.Height), previewStringFormat);
				previewStringFormat.Dispose();
				previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
				this.lstPreview.Items.Add("");	// add image list picture to image list
				//System.GC.Collect();
			}
			generator.ChangeAllItemPens(new Pen(Color.Black, 1));			// change back all item pens and brushes
			generator.ChangeAllProcessPens(new Pen(Color.Black, 1));
			if (this.lstPreview.Items.Count > 0)							// select first picture of image list
				this.lstPreview.SelectedIndex = 0;
			if (mscPreview != null)
				mscPreview.Dispose();
			if (previewDestination != null)
				previewDestination.Dispose();
		}
		private byte[] MakeGrey(byte[] b)
		{
			byte[] returnByte = new byte[3];
			byte greyValue = (byte)(((b[0] * 77) + (b[1] * 149) + (b[2] * 28)) / 256);
			for (int i = 0; i < 3; i++) {
				returnByte[i] = greyValue;
			}
			return returnByte;
		}
		public void AddRepertory()
		{
			if (oldRepertoryStyle == MSCItem.Style)
				return;								// dont redraw if style not changed
			oldRepertoryStyle = MSCItem.Style;
			
			Image mscRepertoryImage = new Bitmap(80, 80);
			Graphics g = Graphics.FromImage(mscRepertoryImage);
			this.lstRepertory.Items.Clear();										// clear old image list
			this.lstRepertory.Width = 245;
			repertory.Clear();														// clear list of old image list pictures
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.ProcessLine.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.ProcessLine.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.ProcessLine.RepertoryImageActor(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.ProcessLine.RepertoryTextActor)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.Message.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.Message.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			State.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.State.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");
			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.Task.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.Task.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();
			
//			g.Clear(Color.LightYellow);
//			g.DrawRectangle(Pens.Black,0,0,80,80);
//			mscElements.Comment.RepertoryImage(g);
//			repertory.Add(new RepertoryItem(mscRepertoryImage,new AddText(mscElements.Comment.RepertoryText)));	// add image list picture to array list
//			this.lstRepertory.Items.Add("");	// add image list picture to image list
//			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.Comment.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.Comment.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.FoundMessage.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.FoundMessage.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.InLineBeginn.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.InLineBeginn.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.InLineSeparator.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.InLineSeparator.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.InLineText.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.InLineText.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.LineComment.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.LineComment.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.LostMessage.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.LostMessage.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.MeasureBeginn.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.MeasureBeginn.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.MeasureStart.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.MeasureStart.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.MeasureStop.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.MeasureStop.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.Mark.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.Mark.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.ProcessCreate.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.ProcessCreate.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.ProcessStop.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.ProcessStop.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.Reference.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.Reference.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.SetTimer.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.SetTimer.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.StopTimer.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.StopTimer.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();
			
			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.TimeOut.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.TimeOut.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.TimerEnd.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.TimeoutEnd.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Clear(Color.LightYellow);
			g.DrawRectangle(Pens.Black, 0, 0, 80, 80);
			mscElements.ProcessRegion.RepertoryImage(g);
			repertory.Add(new RepertoryItem(mscRepertoryImage, new AddText(mscElements.ProcessRegion.RepertoryText)));	// add image list picture to array list
			this.lstRepertory.Items.Add("");	// add image list picture to image list
			System.GC.Collect();

			g.Dispose();
 						
		}
		protected override void DeleteData()
		{
			generator.Clear();
		}
		protected override uint GetPages()
		{
			uint pages = generator.GetPages(worksheet.GetWorksheetHeight());
			return pages;
		}
		protected override void RedrawImage()
		{
			if (this.RedrawOutput == false)
				return;
			if (Output.AutosizeOutputWidth) {
				this.picOutput.Width = (int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100));
			}
			if (Output.AutosizeOutputHeight) {				// if auto height activated
				worksheet.SetWorksheetHeight((int)generator.PageHeights[(uint)(this.lstPreview.SelectedIndex)]);		// set the hight of the Output
				this.picOutput.Height = (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100));	// to calculated height for the selected page
			}
			this.InitDrawDestination();
			generator.DrawPage(drawDestination, tmpWorksheet, (uint)(this.lstPreview.SelectedIndex + 1));		// generate selected page
			MSCItem item = null;
			if ((OptionsDialog.ActiveDialog != null) && (OptionsDialog.ActiveDialog is Property)) {
				item = generator.GetMscItemByID(((Property)OptionsDialog.ActiveDialog).ItemID);
				if (item != null) {
					rtbMscEditor.SelectLine((int)item.FileLine);
					generator.DrawSelection(drawDestination, item, this.lstPreview.SelectedIndex + 1);
				}
			}
			this.picOutput.Invalidate();																	// refresh output
			drawDestination.Dispose();
			this.SetStatusBarPages(this.lstPreview.SelectedIndex + 1, this.lstPreview.Items.Count);
			this.SetStatusBarSize(this.worksheet.GetWorksheetWidth(), this.worksheet.GetWorksheetHeight());		// refresh the status bar
		}
		
		protected override void PrintDocumentPrintPage(object sender, PrintPageEventArgs e)
		{
			uint pages = generator.DiagramPages;
			Worksheet w = new Worksheet();
			w.WorksheetValues = worksheet.WorksheetValues;						// store old worksheet
			Image exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);		// create export draw area
			e.Graphics.PageScale = 100.0f / (float)exportImage.HorizontalResolution;
			if (maxPage == 0)
				maxPage = pages;												// if not max page selected, print to last page

			if (Output.AutosizeOutputHeight) {				// if auto height activated
				worksheet.SetWorksheetHeight((int)generator.PageHeights[printPage - 1]);		// set the hight of the diagram to print
			}
			if (Output.AutosizeOutputWidth) {
				worksheet.SetWorksheetWidth((int)generator.AutoWidth);
			}
			if (worksheet.Width > worksheet.Height)
				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			DrawPage(e.Graphics, printPage);						// draw page to printer output
			if (printPage < Math.Min(maxPage, pages)) {										// another site to print ?
				e.HasMorePages = true;
				printPage++;
			}
			worksheet.WorksheetValues = w.WorksheetValues;					// restore old worksheet
			tmpWorksheet.Width = worksheet.GetWorksheetWidth();				
			tmpWorksheet.Height = worksheet.GetWorksheetHeight();
			tmpWorksheet.SetMargins(0, 0, 0, 0);
			Graphics drawDestination = Graphics.FromImage(exportImage);
			generator.CalcOffsets(drawDestination, tmpWorksheet);
			drawDestination.Dispose();
			System.GC.Collect();
		}
		protected override void InterpretFile(string fileName, bool showInProgram)
		{
			string s = String.Empty;
			generator.Clear();
			generator.AddHead(Worksheet.FileName);						// add filename as imageBitmap name first
			Interpreter interpreter = new Interpreter();
			InterpretException[] results = interpreter.InterpretFile(fileName, generator, this);		// interpret new .sc file			
			this.WriteLog(results);
			if (showInProgram) {
				editor.checkSyntaxAll();
				this.rtbMscEditor.Edited = false;
				this.rtbMscEditor.Modified = false;
				this.Text = "MSC-SD-Generator - " + fileName;
				base.RedrawRescaled();
			} else {
				RescaleImage();
			}
			System.GC.Collect();
		}

		protected override void InitNewImage()
		{
			this.rtbMscEditor.Text = "DiagramStyle: sdl\n" +
			"DiagramName: \"" + strings.GetString("New MSC") + "\"\n\n" +
			"PageSize: A4,H\n" +
			"PageMargins: 10,10,10,10\n" +
			"Font: Arial, 10, Regular\n" +
			"LineOffset: 20\n" +
			"Author: \"\"\n" +
			"Company: \"\"\n" +
			"Date: \"\"\n" +
			"Version: \"\"\n" +
			"PrintFootline: no";
			
			this.Text = "MSC-SD-Generator - " + strings.GetString("New MSC");
			this.rtbMscEditor.Edited = false;
			editor.checkSyntaxAll();
			this.RtbTextInitUndo();
			this.DrawNew();
			this.CenterPage();
		}
		protected override void ShowInfoDialog()
		{
//			Info info = new Info(license);
			Info info = new Info();
			info.ShowDialog();
			info.Dispose();		
			System.GC.Collect();
		}
		protected override void TabChanged(object sender, System.EventArgs e)
		{
			base.TabChanged(sender, e);
			if ((this.tabWork.SelectedIndex == 0) && (this.rtbMscEditor.Modified)) {
				DrawNew();
			}
		}
		protected override void HighlightEditorText()
		{
			if (editor != null)
				editor.CheckSyntax();			
		}
		protected override void ImageClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (outputMoved) {
				outputMoved = false;
				return;
			}
			this.InitDrawDestination();
			generator.CalcOffsets(drawDestination, tmpWorksheet);
			generator.DrawPage(drawDestination, tmpWorksheet, (uint)(this.lstPreview.SelectedIndex + 1));		// generate selected page
			Trace.WriteLine(DateTime.Now.TimeOfDay + ((float)e.X * (100.0f / (float)outputZoom)).ToString() + " - " + ((float)e.Y * (100.0f / (float)outputZoom)).ToString());
			MSCItem item = generator.GetMscItemByMouse((uint)(this.lstPreview.SelectedIndex + 1), (float)e.X * (100.0f / (float)outputZoom), (float)e.Y * (100.0f / (float)outputZoom));
			if (item != null) {
				rtbMscEditor.SelectLine((int)item.FileLine);
				generator.EditItemProperties((uint)(this.lstPreview.SelectedIndex + 1), item.ItemID, rtbMscEditor.Lines[item.FileLine - 1]);
				generator.DrawSelection(drawDestination, item, (this.lstPreview.SelectedIndex + 1));
				this.SetStatusBarPages(this.lstPreview.SelectedIndex + 1, this.lstPreview.Items.Count);
			} else {
				Rectangle bounds = new Rectangle(0, 0, 0, 0);
				if (OptionsDialog.ActiveDialog != null) {
					bounds = OptionsDialog.ActiveDialog.Bounds;
					OptionsDialog.ActiveDialog.Close();
				}
			}
			this.picOutput.Invalidate();// refresh output
			drawDestination.Dispose();
			System.GC.Collect();
		}
		public void SetMscStyle(MscStyle newStyle)
		{
			generator.SetMscStyle(newStyle);
			AddRepertory();
			if (OptionsDialog.ActiveDialog != null) {
				((Property)OptionsDialog.ActiveDialog).DiagramStyleChanged(newStyle);
			}
		}
		/// <summary>
		/// change the repertory images in editor called after change of diagram style
		/// </summary>
		/// <param name="line">line has been changed</param>
		public void CBMscStyle(int line)
		{
			Interpreter interpreter = new Interpreter();	
			interpreter.InterpretDiagramTextNoWarnings(this.rtbMscEditor.Lines[line], generator, this);		// interpret new .sc file
		}
		public void ChangeEditorText(uint line, string text)
		{
			this.rtbMscEditor.SetTextLine(line, text);
		}
		protected override void ExportImage(string filename, string format)
		{
			uint pages;
			Image exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);		// create export draw area
			Graphics drawDestination = Graphics.FromImage(exportImage);
			//MessageBox.Show(drawDestination.PageScale.ToString());
			Graphics grph;
			IntPtr ipHDC;																	//necessary for wmf and emf export
			Metafile mf;
			Trace.WriteLine(DateTime.Now.TimeOfDay + " height: " + worksheet.Height.ToString());
			Worksheet w = new Worksheet();
			w.WorksheetValues = worksheet.WorksheetValues;
			pages = GetPages();		// calculate imageBitmap page count
			if (pages > 0) {																	// something to do?
				if (Output.AutosizeExport == true) {
					int x = 0;
					for (int k = 0; k < generator.PageHeights.Length; k++)
						x +=	(int)generator.PageHeights[k] - (int)generator.YProcessOffset - (int)Generator.BOTTOM_MARGIN_MSC - (int)generator.YItemOffset;
					x += (int)generator.YProcessOffset + (int)Generator.BOTTOM_MARGIN_MSC + (int)generator.YItemOffset;
					worksheet.SetWorksheetHeight(x);
					if (Output.AutosizeOutputWidth) {
						worksheet.SetWorksheetWidth((int)generator.AutoWidth);
					}
					exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);
					Trace.WriteLine(DateTime.Now.TimeOfDay + " height: ");
					drawDestination = Graphics.FromImage(exportImage);
					switch (format.ToUpper()) {				// identify selected format
						case "BMP":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination, 0);
							exportImage.Save(filename + ".bmp");
							break;
						case "GIF":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination, 0);
							exportImage.Save(filename + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
							break;
						case "JPG":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination, 0);
							exportImage.Save(filename + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
							break;
						case "PNG":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination, 0);
							exportImage.Save(filename + ".png", System.Drawing.Imaging.ImageFormat.Png);
							break;
						case "WMF":
							drawDestination.Clear(Color.White);						
							exportImage.Save(filename + ".wmf", System.Drawing.Imaging.ImageFormat.Wmf);		// for save as wmf first empty wmf file shall be created
							grph = this.CreateGraphics(); 
							ipHDC = grph.GetHdc(); 
							mf = new Metafile(filename + ".wmf", ipHDC); 										// open created empty wmf file
							grph = Graphics.FromImage(mf); 
							grph.Clear(Color.White);
							grph.FillRectangle(Brushes.White, 0, 0, exportImage.Width, exportImage.Height);
							grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
							grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
							DrawPage(grph, 0);														// draw imageBitmap direct to wmf file
							grph.Dispose();
							mf.Dispose();
							break;
						case "EMF":
							System.IO.FileStream st = new FileStream(filename + ".emf", FileMode.Create);
							drawDestination.Clear(Color.White);						
							grph = this.CreateGraphics(); 
							ipHDC = grph.GetHdc(); 
							mf = new Metafile(st, ipHDC);
							grph = Graphics.FromImage(mf); 
							grph.Clear(Color.White);
							grph.FillRectangle(Brushes.White, 0, 0, exportImage.Width, exportImage.Height);
							grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
							grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
							DrawPage(grph, 0);														// draw imageBitmap direct to emf file
							grph.Dispose();
							st.Dispose();
							mf.Dispose();
							break;
					
					}					
				} else {
					if (filename.LastIndexOf('.') >= (filename.Length - 4)) {
						filename = filename.Substring(0, filename.LastIndexOf('.'));
					}
					for (uint i = 1; i <= pages; i++) {
						if (Output.AutosizeOutputHeight) {
							worksheet.SetWorksheetHeight((int)generator.PageHeights[i - 1]); // correct height for export
	
						}
						if (Output.AutosizeOutputWidth) {
							worksheet.SetWorksheetWidth((int)generator.AutoWidth);
						}
						exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);
						Trace.WriteLine(DateTime.Now.TimeOfDay + " height: ");
						drawDestination = Graphics.FromImage(exportImage);
						switch (format.ToUpper()) {				// identify selected format
							case "BMP":
								drawDestination.Clear(Color.White);						
								DrawPage(drawDestination, i);
								exportImage.Save(filename + "_" + i + ".bmp");
								break;
							case "GIF":
								drawDestination.Clear(Color.White);						
								DrawPage(drawDestination, i);
								exportImage.Save(filename + "_" + i + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
								break;
							case "JPG":
								drawDestination.Clear(Color.White);						
								DrawPage(drawDestination, i);
								exportImage.Save(filename + "_" + i + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
								break;
							case "PNG":
								drawDestination.Clear(Color.White);						
								DrawPage(drawDestination, i);
								exportImage.Save(filename + "_" + i + ".png", System.Drawing.Imaging.ImageFormat.Png);
								break;
							case "WMF":
								drawDestination.Clear(Color.White);						
								exportImage.Save(filename + "_" + i + ".wmf", System.Drawing.Imaging.ImageFormat.Wmf);		// for save as wmf first empty wmf file shall be created
								grph = this.CreateGraphics(); 
								ipHDC = grph.GetHdc(); 
								mf = new Metafile(filename + "_" + i + ".wmf", ipHDC); 										// open created empty wmf file
								grph = Graphics.FromImage(mf); 
								grph.Clear(Color.White);
								grph.FillRectangle(Brushes.White, 0, 0, exportImage.Width, exportImage.Height);
								grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
								grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
								DrawPage(grph, i);														// draw imageBitmap direct to wmf file
								grph.Dispose();
								mf.Dispose();
								break;
							case "EMF":
								System.IO.FileStream st = new FileStream(filename + "_" + i + ".emf", FileMode.Create);
								drawDestination.Clear(Color.White);						
								grph = this.CreateGraphics(); 
								ipHDC = grph.GetHdc(); 
								mf = new Metafile(st, ipHDC);
								grph = Graphics.FromImage(mf); 
								grph.Clear(Color.White);
								grph.FillRectangle(Brushes.White, 0, 0, exportImage.Width, exportImage.Height);
								grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
								grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
								DrawPage(grph, i);														// draw imageBitmap direct to emf file
								grph.Dispose();
								st.Dispose();
								mf.Dispose();
								break;
						}
					}
				}
			}
			worksheet.WorksheetValues = w.WorksheetValues;
			tmpWorksheet.Width = worksheet.GetWorksheetWidth();
			tmpWorksheet.Height = worksheet.GetWorksheetHeight();
			tmpWorksheet.SetMargins(0, 0, 0, 0);
			generator.CalcOffsets(drawDestination, tmpWorksheet);
			drawDestination.Dispose();
			exportImage.Dispose();
			GC.Collect();
		}
		protected override void ChangeFont()
		{
			this.dlgFont.ShowColor = false;
			//this.dlgFont.ShowEffects = false;
			this.dlgFont.ScriptsOnly = true;
			this.dlgFont.Font = MSCItem.ItemFont;
			if (this.dlgFont.ShowDialog() == DialogResult.OK) {										// open font dialog
				MSCItem.ItemFont = dlgFont.Font;
				int startPos = 0;
				int endPos = 0;
				StringBuilder temp = new StringBuilder();
				editor.Update = true;
				/*************************************************
		 * 
		 * FONT
		 * 
		 * ***********************************************/
					
				temp.Remove(0, temp.Length);											// replace font attributes in editor text
				temp.Append("Font: \"");
				temp.Append(MSCItem.ItemFont.FontFamily.Name);
				temp.Append("\", \"");
				temp.Append(MSCItem.ItemFont.Size.ToString());
				temp.Append("\", \"");
				if (MSCItem.ItemFont.Style == System.Drawing.FontStyle.Regular) {
					temp.Append("Regular");
				} else {
					if (MSCItem.ItemFont.Bold == true)
						temp.Append("Bold ");
					if (MSCItem.ItemFont.Italic == true)
						temp.Append("Italic ");
					if (MSCItem.ItemFont.Strikeout == true)
						temp.Append("Strikeout ");
					if (MSCItem.ItemFont.Underline == true)
						temp.Append("Underline ");
				}
				temp.Append("\"");
				startPos = this.rtbMscEditor.Find("FONT:", RichTextBoxFinds.WholeWord);
				if (startPos > -1) {
					if (this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) == -1) {
						endPos = this.rtbMscEditor.Text.Length;
					} else {
						endPos = this.rtbMscEditor.Text.ToUpper().IndexOf('\n', startPos) + 1;
						temp.Append("\n");
					}
					this.rtbMscEditor.Select(startPos, endPos - startPos);
					this.rtbMscEditor.SelectedText = temp.ToString();
					this.rtbMscEditor.SelectionStart = startPos;
				} else {
					this.rtbMscEditor.Select(0, 0);
					this.rtbMscEditor.SelectedText = temp.ToString() + "\n";
					this.rtbMscEditor.SelectionStart = 0;
				}
				editor.CheckSyntax();
				editor.Update = false;
				DrawNew();																		// redraw all
			}
		}
		public void WriteLog(InterpretException[] results)
		{
			string exceptionText = "";
			System.GC.Collect();
			if (results == null) {						// no errors were found
				if (log != null) {
					if (!log.IsDisposed) {				// if log window is visible
						log.ClearLogText();				// clear old log text
					}
				}
			} else {										// errors were found
				if (log == null) {						// create new log window if necessery
					log = new Log(this);
				}
				if (log.IsDisposed) {
					log = new Log(this);
				}
				log.Icon = (System.Drawing.Icon)(resources.GetObject("logIcon"));
				log.ClearLogText();
				log.Show();
				log.WindowState = System.Windows.Forms.FormWindowState.Normal;
				for (int i = 0; i < results.Length; i++) {			// write errors to log
					exceptionText = results[i].Message;
					log.AppendLogText(LogIcon.Note, (int)results[i].exceptionLine, exceptionText);
				}
				log.BringToFront();// show log window in front
			}
		}
		public override void LogClick()
		{			// log item was clicked so mark the line in editor
			if (this.tabWork.SelectedIndex == 0) {
				this.tabWork.SelectedIndex = 1;
				log.BringToFront();
			}
			try {
				this.rtbMscEditor.SelectLine(System.Int32.Parse(log.lstv.SelectedItems[0].SubItems[1].Text));
			} catch {
			}
		}
		
		public override void LogDoubleClick()
		{		// log item was clicked so mark the line in editor and hide log window
			if (this.tabWork.SelectedIndex == 0)
				this.tabWork.SelectedIndex = 1;
			this.BringToFront();
			try {
				this.rtbMscEditor.SelectLine(System.Int32.Parse(log.lstv.SelectedItems[0].SubItems[1].Text));
			} catch {
			}
		}
		
		public override void LogSelectedIndexChanged()
		{	 // selection in log window was changed so mark the new line in editor
			if (this.tabWork.SelectedIndex == 0) {
				this.tabWork.SelectedIndex = 1;
				log.BringToFront();
			}
			try {
				this.rtbMscEditor.SelectLine(System.Int32.Parse(log.lstv.SelectedItems[0].SubItems[1].Text));
			} catch {
			}
		}
		private void EditorHelpRequested(object sender, EventArgs e)
		{
			string s = this.rtbMscEditor.SelectedText;
			this.hlpGen.SetHelpKeyword(this.rtbMscEditor, s);
		}
		private void CmnuHelpClick(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this, "MscGenHelp.chm");
		}
		
		void OutputLoad(object sender, System.EventArgs e)
		{
			FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
			Output.HelpLocation = fi.DirectoryName + @"\MscGenHelp.chm";
			this.hlpGen.HelpNamespace = Output.HelpLocation;
		}
		protected override void RtbPaste()
		{
			string[] temp;
			if (System.Windows.Forms.Clipboard.GetText() != "") {
				this.rtbMscEditor.Paste();
				temp = System.Windows.Forms.Clipboard.GetText().Split('\n');
				editor.CheckSyntax(this.rtbMscEditor.GetFirstCharIndexFromLine(this.rtbMscEditor.GetLineFromCharIndex(this.rtbMscEditor.SelectionStart) - (temp.Length - 1)), this.rtbMscEditor.SelectionStart);
			}
		}
		protected void CreatePDF()
		{
		}
        
		//LG
		protected override void ExportToXmi()
		{
			MscDiagramInterpreter diagramInterpreter;
			XmlDocumentBuilder documentBuilder = null;
        	
			//ändern wenn GUI fertig ist
			int xmiExportType = XmiExportTypes.PAPYRUS_XMI_EXPORT;
        	
			switch (xmiExportType) {
				case XmiExportTypes.STANDARD_XMI_EXPORT:
					documentBuilder = new XmlDocumentBuilder();
					break;
        		
				case XmiExportTypes.PAPYRUS_XMI_EXPORT:
					documentBuilder = new PapyrusXmiDocumentBuilder();
					break;
				default:
					break;
			}
        	
			diagramInterpreter = new MscDiagramInterpreter(this.generator, documentBuilder);
			XmlDocument createdDocument = diagramInterpreter.InterpretMscDiagram();
			createdDocument.Save("C:\\testXmlExport.xmi");
        	
		}
        
		//LG

		protected override void ImportFromXmi()
		{	
			XmiImportChoiceDialog xmiFormatChoiceDialog = new XmiImportChoiceDialog();
			DialogResult xmiFormatDialogResult = xmiFormatChoiceDialog.ShowDialog();
			XmiDocumentImport documentImport;
			ArrayList[] editorContent = null;
       		
			if (xmiFormatDialogResult == DialogResult.OK) {
				Object xmiFormatObject = xmiFormatChoiceDialog.ImportFormatChoiceComboBox.SelectedItem;
				string xmiFormatString = xmiFormatObject.ToString();
       			
				if (xmiFormatString.Equals(STANDARD_XMI_FORMAT)) {
       				
				} else if (xmiFormatString.Equals(PAPYRUS_XMI_FORMAT)) {
					documentImport = new PapyrusXmiDocumentImport();
					editorContent = documentImport.ImportXmiDocument();
				}
			}
       		
			if (editorContent != null) {
				CreateEditorEntriesForDiagrams(editorContent);
			}
		}

		public void CreateEditorEntriesForDiagrams(ArrayList[] editorContentDiagrams)
		{
			int editorContentDiagramsCount = editorContentDiagrams.GetLength(0);
			this.rtbMscEditor.Clear();
			ArrayList editorContentCurrentDiagram;
       		
			for (int index = 0; index < editorContentDiagramsCount; index++) {
				editorContentCurrentDiagram = (ArrayList)editorContentDiagrams[index];
				IEnumerator itrEditorContentCurrentDiagram =
					editorContentCurrentDiagram.GetEnumerator();
				string currentEditorRow;
       		
				while (itrEditorContentCurrentDiagram.MoveNext()) {
					currentEditorRow = (string)itrEditorContentCurrentDiagram.Current;
					this.rtbMscEditor.AppendText(currentEditorRow);
				}
				this.editor.checkSyntaxAll();
			}
		}
	}
}
