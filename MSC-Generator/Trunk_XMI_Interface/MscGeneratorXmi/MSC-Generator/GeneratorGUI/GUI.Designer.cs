/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 using NumberingEditor;
namespace GeneratorGUI
{
	partial class GUI : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		 
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
			this.cmnuUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgPreviewPage = new System.Windows.Forms.PrintPreviewDialog();
			this.dlgPageSetup = new System.Windows.Forms.PageSetupDialog();
			this.sourceFileWatch = new System.IO.FileSystemWatcher();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.dlgFont = new System.Windows.Forms.FontDialog();
			this.dlgPrinter = new System.Windows.Forms.PrintDialog();
			this.dlgSaveImage = new System.Windows.Forms.SaveFileDialog();
			this.stbMscStatus = new System.Windows.Forms.StatusBar();
			this.stbpFile = new System.Windows.Forms.StatusBarPanel();
			this.stbpInsert = new System.Windows.Forms.StatusBarPanel();
			this.stbPage = new System.Windows.Forms.StatusBarPanel();
			this.stbpSize = new System.Windows.Forms.StatusBarPanel();
			this.stbpZoom = new System.Windows.Forms.StatusBarPanel();
			this.stbpLine = new System.Windows.Forms.StatusBarPanel();
			this.tabWork = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnlOutput = new GeneratorGUI.OutputPicturePanel();
			this.picOutput = new GeneratorGUI.OutputPictureBox();
			this.pnlParameter = new System.Windows.Forms.Panel();
			this.lstPreview = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitContainerEditor = new System.Windows.Forms.SplitContainer();
			this.lstRepertory = new System.Windows.Forms.ListBox();
			this.rtbMscEditor = new NumberingEditor.NumberingEditor();
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuNew = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuLoad = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuSaveAS = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuPrinter = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuLayout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuXmiExport = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuCut = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuSearch = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuSearchAgain = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuReplace = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuComment = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.umnuUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuDo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoomIn = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoomOut = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoomFit = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoomFitWide = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoomFitHeight = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoomTo = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom600 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom400 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom200 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom150 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom100 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom66 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom50 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom33 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom25 = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuZoom10 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.umnuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmnuCut = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			this.cmnuSearch = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuSearchAgain = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuReplace = new System.Windows.Forms.ToolStripMenuItem();
			this.kommentarToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			this.cmnuComment = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmnuDo = new System.Windows.Forms.ToolStripMenuItem();
			this.ltbMenu = new System.Windows.Forms.ToolBar();
			this.tlbbNew = new System.Windows.Forms.ToolBarButton();
			this.tlbbOpen = new System.Windows.Forms.ToolBarButton();
			this.tlbbSaveText = new System.Windows.Forms.ToolBarButton();
			this.tlbbSave = new System.Windows.Forms.ToolBarButton();
			this.tlbbRefresh = new System.Windows.Forms.ToolBarButton();
			this.tlbbSize = new System.Windows.Forms.ToolBarButton();
			this.tlbbFont = new System.Windows.Forms.ToolBarButton();
			this.tlbbSeperator1 = new System.Windows.Forms.ToolBarButton();
			this.tlbbPrint = new System.Windows.Forms.ToolBarButton();
			this.tlbbPreview = new System.Windows.Forms.ToolBarButton();
			this.tlbbSeperator2 = new System.Windows.Forms.ToolBarButton();
			this.tlbbUndo = new System.Windows.Forms.ToolBarButton();
			this.tlbbDo = new System.Windows.Forms.ToolBarButton();
			this.tlbbSeperator3 = new System.Windows.Forms.ToolBarButton();
			this.tlbbZoomP = new System.Windows.Forms.ToolBarButton();
			this.tlbbZoomM = new System.Windows.Forms.ToolBarButton();
			this.tlbbZoomF = new System.Windows.Forms.ToolBarButton();
			this.tlbbZoomFitWide = new System.Windows.Forms.ToolBarButton();
			this.tlbbZoomFitHeight = new System.Windows.Forms.ToolBarButton();
			this.tlbbSeperator4 = new System.Windows.Forms.ToolBarButton();
			this.tlbbComment = new System.Windows.Forms.ToolBarButton();
			this.tlbbSearch = new System.Windows.Forms.ToolBarButton();
			this.tlbbCut = new System.Windows.Forms.ToolBarButton();
			this.tlbbCopy = new System.Windows.Forms.ToolBarButton();
			this.tlbbPaste = new System.Windows.Forms.ToolBarButton();
			this.tlbbZoomFit100 = new System.Windows.Forms.ToolBarButton();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.sourceFileWatch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpFile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpInsert)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stbPage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpLine)).BeginInit();
			this.tabWork.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pnlOutput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.splitContainerEditor.Panel1.SuspendLayout();
			this.splitContainerEditor.Panel2.SuspendLayout();
			this.splitContainerEditor.SuspendLayout();
			this.mnuMain.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmnuUndo
			// 
			this.cmnuUndo.Image = ((System.Drawing.Image)(resources.GetObject("cmnuUndo.Image")));
			this.cmnuUndo.Name = "cmnuUndo";
			this.cmnuUndo.Size = new System.Drawing.Size(198, 22);
			this.cmnuUndo.Text = "Rückgängig";
			this.cmnuUndo.Click += new System.EventHandler(this.CmnuUndoClick);
			// 
			// dlgPreviewPage
			// 
			this.dlgPreviewPage.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.dlgPreviewPage.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.dlgPreviewPage.ClientSize = new System.Drawing.Size(1680, 997);
			this.dlgPreviewPage.Enabled = true;
			this.dlgPreviewPage.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPreviewPage.Icon")));
			this.dlgPreviewPage.Name = "dlgPreviewPage";
			this.dlgPreviewPage.Visible = false;
			this.dlgPreviewPage.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			// 
			// sourceFileWatch
			// 
			this.sourceFileWatch.EnableRaisingEvents = true;
			this.sourceFileWatch.SynchronizingObject = this;
			// 
			// dlgFont
			// 
			this.dlgFont.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dlgFont.FontMustExist = true;
			this.dlgFont.MaxSize = 20;
			this.dlgFont.MinSize = 8;
			// 
			// dlgPrinter
			// 
			this.dlgPrinter.AllowSomePages = true;
			// 
			// dlgSaveImage
			// 
			this.dlgSaveImage.OverwritePrompt = false;
			// 
			// stbMscStatus
			// 
			this.stbMscStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.stbMscStatus.Location = new System.Drawing.Point(0, 466);
			this.stbMscStatus.Name = "stbMscStatus";
			this.stbMscStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
									this.stbpFile,
									this.stbpInsert,
									this.stbPage,
									this.stbpSize,
									this.stbpZoom,
									this.stbpLine});
			this.stbMscStatus.ShowPanels = true;
			this.stbMscStatus.Size = new System.Drawing.Size(748, 23);
			this.stbMscStatus.TabIndex = 6;
			// 
			// stbpFile
			// 
			this.stbpFile.Name = "stbpFile";
			this.stbpFile.Width = 500;
			// 
			// stbpInsert
			// 
			this.stbpInsert.Name = "stbpInsert";
			this.stbpInsert.Width = 25;
			// 
			// stbPage
			// 
			this.stbPage.Name = "stbPage";
			this.stbPage.Text = "Seite: ";
			// 
			// stbpSize
			// 
			this.stbpSize.Name = "stbpSize";
			this.stbpSize.Text = "Größe: ";
			this.stbpSize.Width = 120;
			// 
			// stbpZoom
			// 
			this.stbpZoom.Name = "stbpZoom";
			// 
			// stbpLine
			// 
			this.stbpLine.Name = "stbpLine";
			this.stbpLine.Text = "Zeile: ";
			// 
			// tabWork
			// 
			this.tabWork.Controls.Add(this.tabPage1);
			this.tabWork.Controls.Add(this.tabPage2);
			this.tabWork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabWork.ItemSize = new System.Drawing.Size(80, 18);
			this.tabWork.Location = new System.Drawing.Point(0, 56);
			this.tabWork.Name = "tabWork";
			this.tabWork.SelectedIndex = 0;
			this.tabWork.Size = new System.Drawing.Size(748, 410);
			this.tabWork.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.pnlOutput);
			this.tabPage1.Controls.Add(this.pnlParameter);
			this.tabPage1.Controls.Add(this.lstPreview);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(740, 384);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Ausgabe";
			// 
			// pnlOutput
			// 
			this.pnlOutput.AutoScroll = true;
			this.pnlOutput.AutoScrollMargin = new System.Drawing.Size(1000, 1000);
			this.pnlOutput.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlOutput.Controls.Add(this.picOutput);
			this.pnlOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlOutput.Location = new System.Drawing.Point(128, 0);
			this.pnlOutput.MouseWheelAllow = true;
			this.pnlOutput.Name = "pnlOutput";
			this.pnlOutput.RePaint = true;
			this.pnlOutput.Size = new System.Drawing.Size(612, 384);
			this.pnlOutput.TabIndex = 17;
			this.pnlOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlOutputPaint);
			// 
			// picOutput
			// 
			this.picOutput.BackColor = System.Drawing.Color.White;
			this.picOutput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.picOutput.Location = new System.Drawing.Point(1000, 1000);
			this.picOutput.Margin = new System.Windows.Forms.Padding(10);
			this.picOutput.Name = "picOutput";
			this.picOutput.Padding = new System.Windows.Forms.Padding(10);
			this.picOutput.RePaint = true;
			this.picOutput.Size = new System.Drawing.Size(755, 271);
			this.picOutput.TabIndex = 1;
			this.picOutput.TabStop = false;
			// 
			// pnlParameter
			// 
			this.pnlParameter.BackColor = System.Drawing.SystemColors.Control;
			this.pnlParameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlParameter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlParameter.Location = new System.Drawing.Point(128, 384);
			this.pnlParameter.Name = "pnlParameter";
			this.pnlParameter.Size = new System.Drawing.Size(612, 0);
			this.pnlParameter.TabIndex = 18;
			// 
			// lstPreview
			// 
			this.lstPreview.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.lstPreview.CausesValidation = false;
			this.lstPreview.Dock = System.Windows.Forms.DockStyle.Left;
			this.lstPreview.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lstPreview.Location = new System.Drawing.Point(0, 0);
			this.lstPreview.Name = "lstPreview";
			this.lstPreview.ScrollAlwaysVisible = true;
			this.lstPreview.Size = new System.Drawing.Size(128, 384);
			this.lstPreview.TabIndex = 15;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainerEditor);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(740, 384);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Editor";
			// 
			// splitContainerEditor
			// 
			this.splitContainerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerEditor.Location = new System.Drawing.Point(0, 0);
			this.splitContainerEditor.Name = "splitContainerEditor";
			// 
			// splitContainerEditor.Panel1
			// 
			this.splitContainerEditor.Panel1.Controls.Add(this.lstRepertory);
			// 
			// splitContainerEditor.Panel2
			// 
			this.splitContainerEditor.Panel2.Controls.Add(this.rtbMscEditor);
			this.splitContainerEditor.Size = new System.Drawing.Size(740, 384);
			this.splitContainerEditor.SplitterDistance = 191;
			this.splitContainerEditor.SplitterWidth = 5;
			this.splitContainerEditor.TabIndex = 20;
			// 
			// lstRepertory
			// 
			this.lstRepertory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lstRepertory.ColumnWidth = 80;
			this.lstRepertory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstRepertory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lstRepertory.IntegralHeight = false;
			this.lstRepertory.ItemHeight = 80;
			this.lstRepertory.Location = new System.Drawing.Point(0, 0);
			this.lstRepertory.MultiColumn = true;
			this.lstRepertory.Name = "lstRepertory";
			this.lstRepertory.Size = new System.Drawing.Size(191, 384);
			this.lstRepertory.TabIndex = 1;
			this.lstRepertory.Click += new System.EventHandler(this.RepertoryClick);
			this.lstRepertory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawRepertory);
			this.lstRepertory.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.DrawRepertoryResize);
			// 
			// rtbMscEditor
			// 
			this.rtbMscEditor.AcceptsTab = true;
			this.rtbMscEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbMscEditor.Edited = false;
			this.rtbMscEditor.HideSelection = false;
			this.rtbMscEditor.Location = new System.Drawing.Point(0, 0);
			this.rtbMscEditor.MarkedRow = ((uint)(0u));
			this.rtbMscEditor.Name = "rtbMscEditor";
			this.rtbMscEditor.Size = new System.Drawing.Size(544, 384);
			this.rtbMscEditor.TabIndex = 19;
			this.rtbMscEditor.Text = "";
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnuFile,
									this.mnuEdit,
									this.mnuView,
									this.mnuInfo});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(748, 24);
			this.mnuMain.TabIndex = 8;
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.umnuNew,
									this.umnuLoad,
									this.umnuSave,
									this.umnuSaveAS,
									this.toolStripMenuItem2,
									this.umnuExport,
									this.toolStripMenuItem3,
									this.umnuPrinter,
									this.umnuPrint,
									this.umnuPrintPreview,
									this.toolStripMenuItem7,
									this.umnuLayout,
									this.toolStripMenuItem4,
									this.umnuXmiExport,
									this.toolStripSeparator1,
									this.umnuExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(46, 20);
			this.mnuFile.Text = "Datei";
			// 
			// umnuNew
			// 
			this.umnuNew.Image = ((System.Drawing.Image)(resources.GetObject("umnuNew.Image")));
			this.umnuNew.Name = "umnuNew";
			this.umnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.umnuNew.Size = new System.Drawing.Size(180, 22);
			this.umnuNew.Text = "Neu";
			this.umnuNew.Click += new System.EventHandler(this.UmnuNewClick);
			// 
			// umnuLoad
			// 
			this.umnuLoad.Image = ((System.Drawing.Image)(resources.GetObject("umnuLoad.Image")));
			this.umnuLoad.Name = "umnuLoad";
			this.umnuLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.umnuLoad.Size = new System.Drawing.Size(180, 22);
			this.umnuLoad.Text = "Öffnen";
			this.umnuLoad.Click += new System.EventHandler(this.UmnuLoadClick);
			// 
			// umnuSave
			// 
			this.umnuSave.Image = ((System.Drawing.Image)(resources.GetObject("umnuSave.Image")));
			this.umnuSave.Name = "umnuSave";
			this.umnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.umnuSave.Size = new System.Drawing.Size(180, 22);
			this.umnuSave.Text = "Speichern";
			this.umnuSave.Click += new System.EventHandler(this.UmnuSaveClick);
			// 
			// umnuSaveAS
			// 
			this.umnuSaveAS.Name = "umnuSaveAS";
			this.umnuSaveAS.Size = new System.Drawing.Size(180, 22);
			this.umnuSaveAS.Text = "Speichern unter...";
			this.umnuSaveAS.Click += new System.EventHandler(this.UmnuSaveAsClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
			// 
			// umnuExport
			// 
			this.umnuExport.Image = ((System.Drawing.Image)(resources.GetObject("umnuExport.Image")));
			this.umnuExport.Name = "umnuExport";
			this.umnuExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.umnuExport.Size = new System.Drawing.Size(180, 22);
			this.umnuExport.Text = "Exportieren";
			this.umnuExport.Click += new System.EventHandler(this.UmnuExportClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
			// 
			// umnuPrinter
			// 
			this.umnuPrinter.Name = "umnuPrinter";
			this.umnuPrinter.Size = new System.Drawing.Size(180, 22);
			this.umnuPrinter.Text = "Drucker einrichten...";
			this.umnuPrinter.Click += new System.EventHandler(this.UmnuPrinterClick);
			// 
			// umnuPrint
			// 
			this.umnuPrint.Image = ((System.Drawing.Image)(resources.GetObject("umnuPrint.Image")));
			this.umnuPrint.Name = "umnuPrint";
			this.umnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.umnuPrint.Size = new System.Drawing.Size(180, 22);
			this.umnuPrint.Text = "Drucken...";
			this.umnuPrint.Click += new System.EventHandler(this.UmnuPrintClick);
			// 
			// umnuPrintPreview
			// 
			this.umnuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("umnuPrintPreview.Image")));
			this.umnuPrintPreview.Name = "umnuPrintPreview";
			this.umnuPrintPreview.Size = new System.Drawing.Size(180, 22);
			this.umnuPrintPreview.Text = "Druckvorschau";
			this.umnuPrintPreview.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
			// 
			// umnuLayout
			// 
			this.umnuLayout.Image = ((System.Drawing.Image)(resources.GetObject("umnuLayout.Image")));
			this.umnuLayout.Name = "umnuLayout";
			this.umnuLayout.Size = new System.Drawing.Size(180, 22);
			this.umnuLayout.Text = "Eigenschaften";
			this.umnuLayout.Click += new System.EventHandler(this.UmnuLayoutClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
			// 
			// umnuXmiExport
			// 
			this.umnuXmiExport.Name = "umnuXmiExport";
			this.umnuXmiExport.Size = new System.Drawing.Size(180, 22);
			this.umnuXmiExport.Text = "XmiExport";
			this.umnuXmiExport.Visible = false;
			this.umnuXmiExport.Click += new System.EventHandler(this.UmnuXmiExportClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			this.toolStripSeparator1.Visible = false;
			// 
			// umnuExit
			// 
			this.umnuExit.Image = ((System.Drawing.Image)(resources.GetObject("umnuExit.Image")));
			this.umnuExit.Name = "umnuExit";
			this.umnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.umnuExit.Size = new System.Drawing.Size(180, 22);
			this.umnuExit.Text = "Beenden";
			this.umnuExit.Click += new System.EventHandler(this.UmnuExitClick);
			// 
			// mnuEdit
			// 
			this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.umnuCut,
									this.umnuCopy,
									this.umnuPaste,
									this.umnuDelete,
									this.toolStripMenuItem8,
									this.umnuSearch,
									this.umnuSearchAgain,
									this.umnuReplace,
									this.toolStripMenuItem5,
									this.umnuComment,
									this.umnuSelectAll,
									this.toolStripMenuItem6,
									this.umnuUndo,
									this.umnuDo});
			this.mnuEdit.Name = "mnuEdit";
			this.mnuEdit.Size = new System.Drawing.Size(75, 20);
			this.mnuEdit.Text = "Bearbeiten";
			// 
			// umnuCut
			// 
			this.umnuCut.Enabled = false;
			this.umnuCut.Image = ((System.Drawing.Image)(resources.GetObject("umnuCut.Image")));
			this.umnuCut.Name = "umnuCut";
			this.umnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.umnuCut.Size = new System.Drawing.Size(238, 22);
			this.umnuCut.Text = "Ausschneiden";
			this.umnuCut.Click += new System.EventHandler(this.UmnuCut_Click);
			// 
			// umnuCopy
			// 
			this.umnuCopy.Enabled = false;
			this.umnuCopy.Image = ((System.Drawing.Image)(resources.GetObject("umnuCopy.Image")));
			this.umnuCopy.Name = "umnuCopy";
			this.umnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.umnuCopy.Size = new System.Drawing.Size(238, 22);
			this.umnuCopy.Text = "Kopieren";
			this.umnuCopy.Click += new System.EventHandler(this.UmnuCopy_Click);
			// 
			// umnuPaste
			// 
			this.umnuPaste.Enabled = false;
			this.umnuPaste.Image = ((System.Drawing.Image)(resources.GetObject("umnuPaste.Image")));
			this.umnuPaste.Name = "umnuPaste";
			this.umnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.umnuPaste.Size = new System.Drawing.Size(238, 22);
			this.umnuPaste.Text = "Einfügen";
			this.umnuPaste.Click += new System.EventHandler(this.UmnuPaste_Click);
			// 
			// umnuDelete
			// 
			this.umnuDelete.Enabled = false;
			this.umnuDelete.Name = "umnuDelete";
			this.umnuDelete.ShortcutKeyDisplayString = "Entf";
			this.umnuDelete.Size = new System.Drawing.Size(238, 22);
			this.umnuDelete.Text = "Löschen";
			this.umnuDelete.Click += new System.EventHandler(this.UmnuDeleteClick);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(235, 6);
			// 
			// umnuSearch
			// 
			this.umnuSearch.Image = ((System.Drawing.Image)(resources.GetObject("umnuSearch.Image")));
			this.umnuSearch.Name = "umnuSearch";
			this.umnuSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.umnuSearch.Size = new System.Drawing.Size(238, 22);
			this.umnuSearch.Text = "Suchen...";
			this.umnuSearch.Click += new System.EventHandler(this.UmnuSearchClick);
			// 
			// umnuSearchAgain
			// 
			this.umnuSearchAgain.Name = "umnuSearchAgain";
			this.umnuSearchAgain.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.umnuSearchAgain.Size = new System.Drawing.Size(238, 22);
			this.umnuSearchAgain.Text = "Weitersuchen";
			this.umnuSearchAgain.Click += new System.EventHandler(this.UmnuSearchAgainClick);
			// 
			// umnuReplace
			// 
			this.umnuReplace.Name = "umnuReplace";
			this.umnuReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.umnuReplace.Size = new System.Drawing.Size(238, 22);
			this.umnuReplace.Text = "Ersetzten...";
			this.umnuReplace.Click += new System.EventHandler(this.UmnuReplaceClick);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(235, 6);
			// 
			// umnuComment
			// 
			this.umnuComment.Image = ((System.Drawing.Image)(resources.GetObject("umnuComment.Image")));
			this.umnuComment.Name = "umnuComment";
			this.umnuComment.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
			this.umnuComment.Size = new System.Drawing.Size(238, 22);
			this.umnuComment.Text = "Ein-/Auskommentieren";
			this.umnuComment.Click += new System.EventHandler(this.UmnuCommentClick);
			// 
			// umnuSelectAll
			// 
			this.umnuSelectAll.Name = "umnuSelectAll";
			this.umnuSelectAll.ShortcutKeyDisplayString = "Strg+A";
			this.umnuSelectAll.Size = new System.Drawing.Size(238, 22);
			this.umnuSelectAll.Text = "Alles markieren";
			this.umnuSelectAll.Click += new System.EventHandler(this.UmnuSelectAllClick);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(235, 6);
			// 
			// umnuUndo
			// 
			this.umnuUndo.Image = ((System.Drawing.Image)(resources.GetObject("umnuUndo.Image")));
			this.umnuUndo.Name = "umnuUndo";
			this.umnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.umnuUndo.Size = new System.Drawing.Size(238, 22);
			this.umnuUndo.Text = "Rückgängig";
			this.umnuUndo.Click += new System.EventHandler(this.UmnuUndoClick);
			// 
			// umnuDo
			// 
			this.umnuDo.Image = ((System.Drawing.Image)(resources.GetObject("umnuDo.Image")));
			this.umnuDo.Name = "umnuDo";
			this.umnuDo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.umnuDo.Size = new System.Drawing.Size(238, 22);
			this.umnuDo.Text = "Wiederherstellen";
			this.umnuDo.Click += new System.EventHandler(this.UmnuDoClick);
			// 
			// mnuView
			// 
			this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.umnuZoomIn,
									this.umnuZoomOut,
									this.umnuZoomFit,
									this.umnuZoomFitWide,
									this.umnuZoomFitHeight,
									this.umnuZoomTo});
			this.mnuView.Name = "mnuView";
			this.mnuView.Size = new System.Drawing.Size(59, 20);
			this.mnuView.Text = "Ansicht";
			// 
			// umnuZoomIn
			// 
			this.umnuZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("umnuZoomIn.Image")));
			this.umnuZoomIn.Name = "umnuZoomIn";
			this.umnuZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
			this.umnuZoomIn.Size = new System.Drawing.Size(217, 22);
			this.umnuZoomIn.Text = "Vergrößern";
			this.umnuZoomIn.Click += new System.EventHandler(this.UmnuZoomInClick);
			// 
			// umnuZoomOut
			// 
			this.umnuZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("umnuZoomOut.Image")));
			this.umnuZoomOut.Name = "umnuZoomOut";
			this.umnuZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
			this.umnuZoomOut.Size = new System.Drawing.Size(217, 22);
			this.umnuZoomOut.Text = "Verkleinern";
			this.umnuZoomOut.Click += new System.EventHandler(this.UmnuZoomOutClick);
			// 
			// umnuZoomFit
			// 
			this.umnuZoomFit.Image = ((System.Drawing.Image)(resources.GetObject("umnuZoomFit.Image")));
			this.umnuZoomFit.Name = "umnuZoomFit";
			this.umnuZoomFit.Size = new System.Drawing.Size(217, 22);
			this.umnuZoomFit.Text = "Auf Arbeitsfläche anpassen";
			this.umnuZoomFit.Click += new System.EventHandler(this.UmnuZoomFitClick);
			// 
			// umnuZoomFitWide
			// 
			this.umnuZoomFitWide.Image = ((System.Drawing.Image)(resources.GetObject("umnuZoomFitWide.Image")));
			this.umnuZoomFitWide.Name = "umnuZoomFitWide";
			this.umnuZoomFitWide.Size = new System.Drawing.Size(217, 22);
			this.umnuZoomFitWide.Text = "Auf Seitenbreite anpassen";
			this.umnuZoomFitWide.Click += new System.EventHandler(this.UmnuZoomFitWideClick);
			// 
			// umnuZoomFitHeight
			// 
			this.umnuZoomFitHeight.Image = ((System.Drawing.Image)(resources.GetObject("umnuZoomFitHeight.Image")));
			this.umnuZoomFitHeight.Name = "umnuZoomFitHeight";
			this.umnuZoomFitHeight.Size = new System.Drawing.Size(217, 22);
			this.umnuZoomFitHeight.Text = "Auf Seitenhöhe anpassen";
			this.umnuZoomFitHeight.Click += new System.EventHandler(this.UmnuZoomFitHeightClick);
			// 
			// umnuZoomTo
			// 
			this.umnuZoomTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.umnuZoom600,
									this.umnuZoom400,
									this.umnuZoom200,
									this.umnuZoom150,
									this.umnuZoom100,
									this.umnuZoom66,
									this.umnuZoom50,
									this.umnuZoom33,
									this.umnuZoom25,
									this.umnuZoom10});
			this.umnuZoomTo.Name = "umnuZoomTo";
			this.umnuZoomTo.Size = new System.Drawing.Size(217, 22);
			this.umnuZoomTo.Text = "Zoom auf";
			// 
			// umnuZoom600
			// 
			this.umnuZoom600.Name = "umnuZoom600";
			this.umnuZoom600.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom600.Text = "600 %";
			this.umnuZoom600.Visible = false;
			this.umnuZoom600.Click += new System.EventHandler(this.UmnuZoom600Click);
			// 
			// umnuZoom400
			// 
			this.umnuZoom400.Name = "umnuZoom400";
			this.umnuZoom400.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom400.Text = "300 %";
			this.umnuZoom400.Click += new System.EventHandler(this.UmnuZoom400Click);
			// 
			// umnuZoom200
			// 
			this.umnuZoom200.Name = "umnuZoom200";
			this.umnuZoom200.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom200.Text = "200 %";
			this.umnuZoom200.Click += new System.EventHandler(this.UmnuZoom200Click);
			// 
			// umnuZoom150
			// 
			this.umnuZoom150.Name = "umnuZoom150";
			this.umnuZoom150.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom150.Text = "150 %";
			this.umnuZoom150.Click += new System.EventHandler(this.UmnuZoom150Click);
			// 
			// umnuZoom100
			// 
			this.umnuZoom100.Name = "umnuZoom100";
			this.umnuZoom100.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom100.Text = "100 %";
			this.umnuZoom100.Click += new System.EventHandler(this.UmnuZoom100Click);
			// 
			// umnuZoom66
			// 
			this.umnuZoom66.Name = "umnuZoom66";
			this.umnuZoom66.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom66.Text = "66 %";
			this.umnuZoom66.Click += new System.EventHandler(this.UmnuZoom66Click);
			// 
			// umnuZoom50
			// 
			this.umnuZoom50.Name = "umnuZoom50";
			this.umnuZoom50.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom50.Text = "50 %";
			this.umnuZoom50.Click += new System.EventHandler(this.UmnuZoom50Click);
			// 
			// umnuZoom33
			// 
			this.umnuZoom33.Name = "umnuZoom33";
			this.umnuZoom33.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom33.Text = "33 %";
			this.umnuZoom33.Click += new System.EventHandler(this.UmnuZoom33Click);
			// 
			// umnuZoom25
			// 
			this.umnuZoom25.Name = "umnuZoom25";
			this.umnuZoom25.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom25.Text = "25 %";
			this.umnuZoom25.Click += new System.EventHandler(this.UmnuZoom25Click);
			// 
			// umnuZoom10
			// 
			this.umnuZoom10.Name = "umnuZoom10";
			this.umnuZoom10.Size = new System.Drawing.Size(105, 22);
			this.umnuZoom10.Text = "10 %";
			this.umnuZoom10.Click += new System.EventHandler(this.UmnuZoom10Click);
			// 
			// mnuInfo
			// 
			this.mnuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.umnuAbout});
			this.mnuInfo.Name = "mnuInfo";
			this.mnuInfo.Size = new System.Drawing.Size(24, 20);
			this.mnuInfo.Text = "?";
			// 
			// umnuAbout
			// 
			this.umnuAbout.Image = ((System.Drawing.Image)(resources.GetObject("umnuAbout.Image")));
			this.umnuAbout.Name = "umnuAbout";
			this.umnuAbout.Size = new System.Drawing.Size(95, 22);
			this.umnuAbout.Text = "Info";
			this.umnuAbout.Click += new System.EventHandler(this.UmnuAboutClick);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.cmnuCut,
									this.cmnuCopy,
									this.cmnuPaste,
									this.cmnuDelete,
									this.toolStripMenuItem9,
									this.cmnuSearch,
									this.cmnuSearchAgain,
									this.cmnuReplace,
									this.kommentarToolStripMenuItem,
									this.cmnuComment,
									this.cmnuSelectAll,
									this.toolStripMenuItem1,
									this.cmnuUndo,
									this.cmnuDo});
			this.contextMenu.Name = "contextMenuStrip1";
			this.contextMenu.Size = new System.Drawing.Size(199, 264);
			// 
			// cmnuCut
			// 
			this.cmnuCut.Enabled = false;
			this.cmnuCut.Image = ((System.Drawing.Image)(resources.GetObject("cmnuCut.Image")));
			this.cmnuCut.Name = "cmnuCut";
			this.cmnuCut.Size = new System.Drawing.Size(198, 22);
			this.cmnuCut.Text = "Ausschneiden";
			this.cmnuCut.Click += new System.EventHandler(this.CmnuCut_Click);
			// 
			// cmnuCopy
			// 
			this.cmnuCopy.Enabled = false;
			this.cmnuCopy.Image = ((System.Drawing.Image)(resources.GetObject("cmnuCopy.Image")));
			this.cmnuCopy.Name = "cmnuCopy";
			this.cmnuCopy.Size = new System.Drawing.Size(198, 22);
			this.cmnuCopy.Text = "Kopieren";
			this.cmnuCopy.Click += new System.EventHandler(this.CmnuCopy_Click);
			// 
			// cmnuPaste
			// 
			this.cmnuPaste.Enabled = false;
			this.cmnuPaste.Image = ((System.Drawing.Image)(resources.GetObject("cmnuPaste.Image")));
			this.cmnuPaste.Name = "cmnuPaste";
			this.cmnuPaste.Size = new System.Drawing.Size(198, 22);
			this.cmnuPaste.Text = "Einfügen";
			this.cmnuPaste.Click += new System.EventHandler(this.CmnuPaste_Click);
			// 
			// cmnuDelete
			// 
			this.cmnuDelete.Name = "cmnuDelete";
			this.cmnuDelete.Size = new System.Drawing.Size(198, 22);
			this.cmnuDelete.Text = "Löschen";
			this.cmnuDelete.Click += new System.EventHandler(this.CmnuDeleteClick);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(195, 6);
			// 
			// cmnuSearch
			// 
			this.cmnuSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmnuSearch.Image")));
			this.cmnuSearch.Name = "cmnuSearch";
			this.cmnuSearch.Size = new System.Drawing.Size(198, 22);
			this.cmnuSearch.Text = "Suchen";
			this.cmnuSearch.Click += new System.EventHandler(this.CmnuSearchClick);
			// 
			// cmnuSearchAgain
			// 
			this.cmnuSearchAgain.Name = "cmnuSearchAgain";
			this.cmnuSearchAgain.Size = new System.Drawing.Size(198, 22);
			this.cmnuSearchAgain.Text = "Weitersuchen";
			this.cmnuSearchAgain.Click += new System.EventHandler(this.CmnuSearchAgainClick);
			// 
			// cmnuReplace
			// 
			this.cmnuReplace.Name = "cmnuReplace";
			this.cmnuReplace.Size = new System.Drawing.Size(198, 22);
			this.cmnuReplace.Text = "Ersetzen";
			this.cmnuReplace.Click += new System.EventHandler(this.CmnuReplaceClick);
			// 
			// kommentarToolStripMenuItem
			// 
			this.kommentarToolStripMenuItem.Name = "kommentarToolStripMenuItem";
			this.kommentarToolStripMenuItem.Size = new System.Drawing.Size(195, 6);
			// 
			// cmnuComment
			// 
			this.cmnuComment.Image = ((System.Drawing.Image)(resources.GetObject("cmnuComment.Image")));
			this.cmnuComment.Name = "cmnuComment";
			this.cmnuComment.Size = new System.Drawing.Size(198, 22);
			this.cmnuComment.Text = "Ein-/Auskommentieren";
			this.cmnuComment.Click += new System.EventHandler(this.CmnuCommentClick);
			// 
			// cmnuSelectAll
			// 
			this.cmnuSelectAll.Name = "cmnuSelectAll";
			this.cmnuSelectAll.Size = new System.Drawing.Size(198, 22);
			this.cmnuSelectAll.Text = "Alles markieren";
			this.cmnuSelectAll.Click += new System.EventHandler(this.CmnuSelectAllClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
			// 
			// cmnuDo
			// 
			this.cmnuDo.Image = ((System.Drawing.Image)(resources.GetObject("cmnuDo.Image")));
			this.cmnuDo.Name = "cmnuDo";
			this.cmnuDo.Size = new System.Drawing.Size(198, 22);
			this.cmnuDo.Text = "Wiederherstellen";
			this.cmnuDo.Click += new System.EventHandler(this.CmnuDoClick);
			// 
			// ltbMenu
			// 
			this.ltbMenu.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.ltbMenu.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
									this.tlbbNew,
									this.tlbbOpen,
									this.tlbbSaveText,
									this.tlbbSave,
									this.tlbbRefresh,
									this.tlbbSize,
									this.tlbbFont,
									this.tlbbSeperator1,
									this.tlbbPrint,
									this.tlbbPreview,
									this.tlbbSeperator2,
									this.tlbbUndo,
									this.tlbbDo,
									this.tlbbSeperator3,
									this.tlbbZoomP,
									this.tlbbZoomM,
									this.tlbbZoomF,
									this.tlbbZoomFitWide,
									this.tlbbZoomFitHeight,
									this.tlbbSeperator4,
									this.tlbbComment,
									this.tlbbSearch,
									this.tlbbCut,
									this.tlbbCopy,
									this.tlbbPaste,
									this.tlbbZoomFit100});
			this.ltbMenu.ButtonSize = new System.Drawing.Size(25, 25);
			this.ltbMenu.DropDownArrows = true;
			this.ltbMenu.ImageList = this.imgList;
			this.ltbMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ltbMenu.Location = new System.Drawing.Point(0, 24);
			this.ltbMenu.Name = "ltbMenu";
			this.ltbMenu.ShowToolTips = true;
			this.ltbMenu.Size = new System.Drawing.Size(748, 32);
			this.ltbMenu.TabIndex = 9;
			this.ltbMenu.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.LtbMenuButtonClick);
			// 
			// tlbbNew
			// 
			this.tlbbNew.ImageIndex = 0;
			this.tlbbNew.Name = "tlbbNew";
			this.tlbbNew.Tag = "11";
			this.tlbbNew.ToolTipText = "Neues Diagramm";
			// 
			// tlbbOpen
			// 
			this.tlbbOpen.ImageIndex = 1;
			this.tlbbOpen.Name = "tlbbOpen";
			this.tlbbOpen.Tag = "0";
			this.tlbbOpen.ToolTipText = "Diagramm öffnen";
			// 
			// tlbbSaveText
			// 
			this.tlbbSaveText.ImageIndex = 2;
			this.tlbbSaveText.Name = "tlbbSaveText";
			this.tlbbSaveText.Tag = "10";
			this.tlbbSaveText.ToolTipText = "Diagramm Speichern";
			// 
			// tlbbSave
			// 
			this.tlbbSave.ImageIndex = 3;
			this.tlbbSave.Name = "tlbbSave";
			this.tlbbSave.Tag = "1";
			this.tlbbSave.ToolTipText = "Diagramm als Grafik exportieren";
			// 
			// tlbbRefresh
			// 
			this.tlbbRefresh.Name = "tlbbRefresh";
			this.tlbbRefresh.Tag = "9";
			this.tlbbRefresh.Visible = false;
			// 
			// tlbbSize
			// 
			this.tlbbSize.ImageIndex = 4;
			this.tlbbSize.Name = "tlbbSize";
			this.tlbbSize.Tag = "2";
			this.tlbbSize.ToolTipText = "Eigenschaften";
			// 
			// tlbbFont
			// 
			this.tlbbFont.ImageIndex = 5;
			this.tlbbFont.Name = "tlbbFont";
			this.tlbbFont.Tag = "3";
			this.tlbbFont.ToolTipText = "Schrifteinstellungen";
			// 
			// tlbbSeperator1
			// 
			this.tlbbSeperator1.Name = "tlbbSeperator1";
			this.tlbbSeperator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbbPrint
			// 
			this.tlbbPrint.ImageIndex = 6;
			this.tlbbPrint.Name = "tlbbPrint";
			this.tlbbPrint.Tag = "7";
			this.tlbbPrint.ToolTipText = "Drucken";
			// 
			// tlbbPreview
			// 
			this.tlbbPreview.ImageIndex = 7;
			this.tlbbPreview.Name = "tlbbPreview";
			this.tlbbPreview.Tag = "8";
			this.tlbbPreview.ToolTipText = "Druckvorschau";
			// 
			// tlbbSeperator2
			// 
			this.tlbbSeperator2.Name = "tlbbSeperator2";
			this.tlbbSeperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbbUndo
			// 
			this.tlbbUndo.ImageIndex = 8;
			this.tlbbUndo.Name = "tlbbUndo";
			this.tlbbUndo.Tag = "12";
			this.tlbbUndo.ToolTipText = "Rückgängig";
			// 
			// tlbbDo
			// 
			this.tlbbDo.ImageIndex = 9;
			this.tlbbDo.Name = "tlbbDo";
			this.tlbbDo.Tag = "13";
			this.tlbbDo.ToolTipText = "Wiederherstellen";
			// 
			// tlbbSeperator3
			// 
			this.tlbbSeperator3.Name = "tlbbSeperator3";
			this.tlbbSeperator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbbZoomP
			// 
			this.tlbbZoomP.ImageIndex = 10;
			this.tlbbZoomP.Name = "tlbbZoomP";
			this.tlbbZoomP.Tag = "4";
			this.tlbbZoomP.ToolTipText = "Ansicht vergrößern";
			// 
			// tlbbZoomM
			// 
			this.tlbbZoomM.ImageIndex = 11;
			this.tlbbZoomM.Name = "tlbbZoomM";
			this.tlbbZoomM.Tag = "5";
			this.tlbbZoomM.ToolTipText = "Ansicht verkleinern";
			// 
			// tlbbZoomF
			// 
			this.tlbbZoomF.ImageIndex = 12;
			this.tlbbZoomF.Name = "tlbbZoomF";
			this.tlbbZoomF.Tag = "6";
			this.tlbbZoomF.ToolTipText = "Ansicht auf Arbeitsfläche anpassen";
			// 
			// tlbbZoomFitWide
			// 
			this.tlbbZoomFitWide.ImageKey = "seitenbreite.ico";
			this.tlbbZoomFitWide.Name = "tlbbZoomFitWide";
			this.tlbbZoomFitWide.Tag = "16";
			this.tlbbZoomFitWide.ToolTipText = "Ansicht auf Seitenbreite anpassen";
			// 
			// tlbbZoomFitHeight
			// 
			this.tlbbZoomFitHeight.ImageKey = "seitenhöhe.ico";
			this.tlbbZoomFitHeight.Name = "tlbbZoomFitHeight";
			this.tlbbZoomFitHeight.Tag = "17";
			this.tlbbZoomFitHeight.ToolTipText = "Ansicht auf Seitenhöhe anpassen";
			// 
			// tlbbSeperator4
			// 
			this.tlbbSeperator4.Name = "tlbbSeperator4";
			this.tlbbSeperator4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.tlbbSeperator4.Visible = false;
			// 
			// tlbbComment
			// 
			this.tlbbComment.ImageIndex = 15;
			this.tlbbComment.Name = "tlbbComment";
			this.tlbbComment.Tag = "14";
			this.tlbbComment.ToolTipText = "Ein-/Auskommentieren";
			// 
			// tlbbSearch
			// 
			this.tlbbSearch.ImageIndex = 16;
			this.tlbbSearch.Name = "tlbbSearch";
			this.tlbbSearch.Tag = "15";
			this.tlbbSearch.ToolTipText = "Suchen";
			// 
			// tlbbCut
			// 
			this.tlbbCut.Enabled = false;
			this.tlbbCut.ImageIndex = 17;
			this.tlbbCut.Name = "tlbbCut";
			this.tlbbCut.Tag = "18";
			this.tlbbCut.ToolTipText = "Ausschneiden";
			// 
			// tlbbCopy
			// 
			this.tlbbCopy.Enabled = false;
			this.tlbbCopy.ImageKey = "copy.ico";
			this.tlbbCopy.Name = "tlbbCopy";
			this.tlbbCopy.Tag = "19";
			this.tlbbCopy.ToolTipText = "Kopieren";
			// 
			// tlbbPaste
			// 
			this.tlbbPaste.Enabled = false;
			this.tlbbPaste.ImageKey = "paste.ico";
			this.tlbbPaste.Name = "tlbbPaste";
			this.tlbbPaste.Tag = "20";
			this.tlbbPaste.ToolTipText = "Einfügen";
			// 
			// tlbbZoomFit100
			// 
			this.tlbbZoomFit100.ImageIndex = 20;
			this.tlbbZoomFit100.Name = "tlbbZoomFit100";
			this.tlbbZoomFit100.Tag = "21";
			// 
			// imgList
			// 
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			this.imgList.Images.SetKeyName(0, "new.png");
			this.imgList.Images.SetKeyName(1, "open.png");
			this.imgList.Images.SetKeyName(2, "save.png");
			this.imgList.Images.SetKeyName(3, "export.ico");
			this.imgList.Images.SetKeyName(4, "preferences.png");
			this.imgList.Images.SetKeyName(5, "font.png");
			this.imgList.Images.SetKeyName(6, "print.png");
			this.imgList.Images.SetKeyName(7, "preview.png");
			this.imgList.Images.SetKeyName(8, "undo.ico");
			this.imgList.Images.SetKeyName(9, "do.ico");
			this.imgList.Images.SetKeyName(10, "zoom+2.png");
			this.imgList.Images.SetKeyName(11, "zoom-2.png");
			this.imgList.Images.SetKeyName(12, "seitengröße.ico");
			this.imgList.Images.SetKeyName(13, "seitenbreite.ico");
			this.imgList.Images.SetKeyName(14, "seitenhöhe.ico");
			this.imgList.Images.SetKeyName(15, "comment.ico");
			this.imgList.Images.SetKeyName(16, "zoom+.png");
			this.imgList.Images.SetKeyName(17, "cut.ico");
			this.imgList.Images.SetKeyName(18, "copy.ico");
			this.imgList.Images.SetKeyName(19, "paste.ico");
			this.imgList.Images.SetKeyName(20, "100%3.ico");
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// GUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(748, 489);
			this.Controls.Add(this.tabWork);
			this.Controls.Add(this.ltbMenu);
			this.Controls.Add(this.stbMscStatus);
			this.Controls.Add(this.mnuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMain;
			this.MinimumSize = new System.Drawing.Size(500, 200);
			this.Name = "GUI";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.sourceFileWatch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpFile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpInsert)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stbPage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stbpLine)).EndInit();
			this.tabWork.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.pnlOutput.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.splitContainerEditor.Panel1.ResumeLayout(false);
			this.splitContainerEditor.Panel2.ResumeLayout(false);
			this.splitContainerEditor.ResumeLayout(false);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem umnuXmiExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolBarButton tlbbZoomFit100;
		private System.Windows.Forms.ToolStripMenuItem cmnuSelectAll;
		private System.Windows.Forms.ToolStripMenuItem cmnuDelete;
		private System.Windows.Forms.ToolStripMenuItem umnuSelectAll;
		private System.Windows.Forms.ToolStripMenuItem umnuDelete;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ImageList imgList;
        protected NumberingEditor.NumberingEditor rtbMscEditor;
		protected System.Windows.Forms.ToolStripMenuItem cmnuSearch;
		protected System.Windows.Forms.ToolStripMenuItem cmnuSearchAgain;
		protected System.Windows.Forms.ToolStripMenuItem cmnuReplace;
		protected System.Windows.Forms.ToolStripMenuItem cmnuComment;
		protected System.Windows.Forms.ToolStripMenuItem cmnuDo;
		protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		protected System.Windows.Forms.ToolStripSeparator kommentarToolStripMenuItem;
		protected System.Windows.Forms.ToolStripMenuItem umnuAbout;
		protected System.Windows.Forms.ToolStripMenuItem mnuInfo;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom25;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom33;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom50;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom66;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom100;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom150;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom200;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom400;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoom600;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoomTo;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoomFitHeight;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoomFitWide;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoomFit;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoomOut;
		protected System.Windows.Forms.ToolStripMenuItem umnuZoomIn;
		protected System.Windows.Forms.ToolStripMenuItem mnuView;
		protected System.Windows.Forms.ToolStripMenuItem umnuDo;
		protected System.Windows.Forms.ToolStripMenuItem umnuUndo;
		protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		protected System.Windows.Forms.ToolStripMenuItem umnuComment;
		protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		protected System.Windows.Forms.ToolStripMenuItem umnuReplace;
		protected System.Windows.Forms.ToolStripMenuItem umnuSearchAgain;
		protected System.Windows.Forms.ToolStripMenuItem umnuSearch;
		protected System.Windows.Forms.ToolStripMenuItem mnuEdit;
		protected System.Windows.Forms.ToolStripMenuItem umnuExit;
		protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		protected System.Windows.Forms.ToolStripMenuItem umnuLayout;
		protected System.Windows.Forms.ToolStripMenuItem umnuPrinter;
		protected System.Windows.Forms.ToolStripMenuItem umnuPrint;
		protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		protected System.Windows.Forms.ToolStripMenuItem umnuExport;
		protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		protected System.Windows.Forms.ToolStripMenuItem umnuSaveAS;
		protected System.Windows.Forms.ToolStripMenuItem umnuSave;
		protected System.Windows.Forms.ToolStripMenuItem umnuLoad;
		protected System.Windows.Forms.ToolStripMenuItem umnuNew;
		
		protected System.Windows.Forms.ToolStripMenuItem mnuFile;	
		protected System.Windows.Forms.SaveFileDialog dlgSaveImage;
		protected System.Windows.Forms.PrintDialog dlgPrinter;
		protected System.Windows.Forms.FontDialog dlgFont;
        protected System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ToolBarButton tlbbDo;
        private System.Windows.Forms.ToolBarButton tlbbUndo;
		private System.Windows.Forms.ToolBarButton tlbbPreview;
		private System.Windows.Forms.ToolBarButton tlbbPrint;
		private System.Windows.Forms.ToolBarButton tlbbSeperator2;
		private System.Windows.Forms.ToolBarButton tlbbZoomF;
		private System.Windows.Forms.ToolBarButton tlbbZoomM;
		private System.Windows.Forms.ToolBarButton tlbbZoomP;
		private System.Windows.Forms.ToolBarButton tlbbSeperator1;
		private System.Windows.Forms.ToolBarButton tlbbFont;
		private System.Windows.Forms.ToolBarButton tlbbSize;
		private System.Windows.Forms.ToolBarButton tlbbRefresh;
		private System.Windows.Forms.ToolBarButton tlbbSave;
		private System.Windows.Forms.ToolBarButton tlbbSaveText;
		private System.Windows.Forms.ToolBarButton tlbbOpen;
        private System.Windows.Forms.ToolBarButton tlbbNew;
		private System.Windows.Forms.StatusBarPanel stbpLine;
		private System.Windows.Forms.StatusBarPanel stbpZoom;
		private System.Windows.Forms.StatusBarPanel stbpSize;
		private System.Windows.Forms.StatusBarPanel stbPage;
		private System.Windows.Forms.StatusBarPanel stbpFile;
        private System.Windows.Forms.StatusBar stbMscStatus;
        protected System.Windows.Forms.TabPage tabPage2;
		protected System.Windows.Forms.Panel pnlParameter;
		//protected System.Windows.Forms.PictureBox picOutput;
		protected OutputPictureBox picOutput;
		protected OutputPicturePanel pnlOutput;
		protected System.Windows.Forms.TabPage tabPage1;
		protected System.Windows.Forms.TabControl tabWork;
		protected System.IO.FileSystemWatcher sourceFileWatch;
		protected System.Windows.Forms.PageSetupDialog dlgPageSetup;
        protected System.Windows.Forms.PrintPreviewDialog dlgPreviewPage;
        protected System.Windows.Forms.ToolStripMenuItem cmnuUndo;
        protected System.Windows.Forms.ToolStripMenuItem umnuPrintPreview;
		private System.Windows.Forms.ToolBar ltbMenu;
        public System.Windows.Forms.ListBox lstRepertory;
        private System.Windows.Forms.ToolStripMenuItem umnuZoom10;
        public System.Windows.Forms.ListBox lstPreview;
        protected System.Windows.Forms.SplitContainer splitContainerEditor;
        private System.Windows.Forms.StatusBarPanel stbpInsert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolBarButton tlbbSeperator3;
        private System.Windows.Forms.ToolBarButton tlbbComment;
        private System.Windows.Forms.ToolBarButton tlbbSeperator4;
        private System.Windows.Forms.ToolBarButton tlbbSearch;
        private System.Windows.Forms.ToolStripMenuItem umnuCut;
        private System.Windows.Forms.ToolStripMenuItem umnuCopy;
        private System.Windows.Forms.ToolStripMenuItem umnuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem cmnuCut;
        private System.Windows.Forms.ToolStripMenuItem cmnuCopy;
        private System.Windows.Forms.ToolStripMenuItem cmnuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        public System.Windows.Forms.ContextMenuStrip contextMenu;
        public System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolBarButton tlbbZoomFitHeight;
        private System.Windows.Forms.ToolBarButton tlbbCut;
        private System.Windows.Forms.ToolBarButton tlbbCopy;
        private System.Windows.Forms.ToolBarButton tlbbPaste;
        public System.Windows.Forms.ToolBarButton tlbbZoomFitWide;
        
		
        public NumberingEditor.NumberingEditor RtbMscEditor{
        	get{
        		return this.rtbMscEditor;	
        	}
        }
		
		void ToolStripMenuItem10Click(object sender, System.EventArgs e)
		{
			
		}
		
		void PnlOutputPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			}
	}
}
