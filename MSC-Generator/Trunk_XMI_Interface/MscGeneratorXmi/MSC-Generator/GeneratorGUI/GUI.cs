/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.IO;
using sharpPDF;

namespace GeneratorGUI
{
	/// <summary>
	/// Description of GUI.
	/// </summary>
	public partial class GUI
	{
		protected Metafile imageMetaFile;
		protected Image imageBitmap;
		protected Worksheet worksheet;
		//private EditorWindow rtbMscEditor;
		protected ArrayList previewImages = new ArrayList();
		protected ArrayList repertory = new ArrayList();
		protected PrintDocument printDocument;
		
		protected object searchDialog = null;
		protected string searchText = "";
		protected string replaceText = "";
		protected int searchStartPosition = 0;
		protected bool searchWordOnly = false;
		protected bool searchUpperLowerCase = false;
		protected string appName = "Generator";
		protected string fileFilter = "Alle Dateien |*.*";
		protected string dragDropFileExtension = ".txt";
		protected string lastOpenedFile = "";
		protected uint outputZoom, printPage=0, maxPage=0;
		//draw variables
		protected IntPtr ipHDC;																	//necessary for wmf and emf export
		protected Graphics drawDestination;
		protected Worksheet tmpWorksheet;											// create temporary worksheet witout margins
		protected bool sourceFileWatchEnabled = true;
		protected bool sourceFileChanged = false;
		//undo variables
		private static int undoListLength = 100;
		private string[] undoList = new string[undoListLength];
		private string[] undoListRtf = new string[undoListLength];
		private int[] undoListCursorPosition = new int[undoListLength];
		private int undoListPosition = -1;
		private bool undoListChangedByUndoButton = false;
		private int possibleUndos = 0;
		private int possibleDos = 0;
		private string undoEditorText = "";
		protected bool outputMoved= false;
		private bool isRegistered = false;										
		
		public const int FILE_FORMAT_BMP		= 1;
		public const int FILE_FORMAT_GIF		= 2;
		public const int FILE_FORMAT_JPG		= 3;
		public const int FILE_FORMAT_PNG		= 4;
		public const int FILE_FORMAT_WMF		= 5;
		public const int FILE_FORMAT_EMF		= 6;
		
		private const int SMALL_ZOOM			= 10;
		
		protected FileStream fs = null;
		protected System.Drawing.Drawing2D.SmoothingMode imageSmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        protected float dpiOutput;
        protected string toolState;
 		private Tools tools;
        private static bool saveUndo = true;
		private static int exportFileFormatIndex = FILE_FORMAT_EMF;
        private bool mouseMoveIsAtWork = false;
        private bool mouseMoveAllow = false;
        private int mouseMovePositionX = 0;
        private int mouseMovePositionY = 0;
        private bool keyControlDown = false;
        private bool keyInsertDown = true;
        private Point oldPicOutputLocation = new Point();
        
        ResourceManager strings = new ResourceManager ("GeneratorGUI.Strings", Assembly.GetAssembly(typeof(GUI)));
        
        public GUI()
		{
        	//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
        	if(!Thread.CurrentThread.CurrentUICulture.ToString().ToLower().StartsWith("de") && !Thread.CurrentThread.CurrentUICulture.ToString().ToLower().StartsWith("en"))
        		Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
       
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			try{
				OwenInitializeComponent();		// not automaticly generated code to initialize components. Must be before InitializeComponent()!
				dpiOutput = imageBitmap.HorizontalResolution;		// dots per inch resolution of the GUI picture. Necessary to calculate the preview sizes
				worksheet.Dpi = dpiOutput;
				// initialize the status bar output
				this.stbpSize.Text = strings.GetString("Size") + this.worksheet.Width.ToString() + " x " + this.worksheet.Height.ToString();
				this.stbpZoom.Text = "Zoom: 100%";
				outputZoom = 100;
				this.picOutput.Size = new System.Drawing.Size(worksheet.GetWorksheetWidth(), worksheet.GetWorksheetHeight());
				this.dlgPreviewPage.Document = printDocument;
				RtbTextInitUndo();
				tools = new Tools(this);

				tools.Show();
                // TODO: this.CenterPage(); anstelle des Timers 
        	}
			catch (System.Security.SecurityException ex) {
		      MessageBox.Show(ex.Message);
			}
			catch (System.Exception ex){
		      MessageBox.Show(ex.Message);
			}
		}
        
        public ArrayList Repertory{
        	get{
        		return repertory;
        	}
        }
        public string ToolState{
        	get{
        		return tools.ToolState;
        	}
       }
        
       
        
		private void OwenInitializeComponent() {
			drawDestination = this.CreateGraphics();
			worksheet = new Worksheet();	// new worksheet object
			ipHDC = drawDestination.GetHdc();
			imageMetaFile = new Metafile(ipHDC,System.Drawing.Imaging.EmfType.EmfOnly); 										// open created empty emf file
			imageBitmap = new Bitmap(this.worksheet.GetWorksheetWidth(), this.worksheet.GetWorksheetHeight()); 		// working bitmap, draw destination of generated imageBitmap	
			this.printDocument = new PrintDocument();
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentPrintPage);
			this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PrintDocumentBeginPrint);
			this.rtbMscEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RtbEditorMouseDown);
            //searchDialog = new Search();
			
			this.picOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageClick);
//			this.picOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageClick);
			this.picOutput.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ImageWheel);
			this.picOutput.MouseEnter += new System.EventHandler(this.OnMouseEnter);
			this.picOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.PicOutputRedraw);
            this.tabWork.SelectedIndexChanged += new EventHandler(TabChanged);
            this.picOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicOutput_MouseDown);
            this.picOutput.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicOutput_MouseUp);
            this.picOutput.MouseMove += new System.Windows.Forms.MouseEventHandler(PicOutput_MouseMove);
            this.picOutput.KeyDown += new KeyEventHandler(PicOutput_KeyDown);
            this.picOutput.KeyUp += new KeyEventHandler(PicOutput_KeyUp);
            this.cmnuSearch.Click += new System.EventHandler(CmnuSearchClick);
            this.pnlOutput.DoubleClick += new EventHandler(PnlOutput_DoubleClick);
            this.Activated += new EventHandler(GUI_GotFocus);
//			this.cmnuSearchAgain.Click += new System.EventHandler(cmnuSearchAgainClick);
//			this.cmnuReplace.Click += new System.EventHandler(cmnuReplaceClick);
//			this.cmnuComment.Click += new System.EventHandler(cmnuCommentClick);
//			this.cmnuDo.Click += new System.EventHandler(cmnuDoClick);
//			this.cmnuUndo.Click += new System.EventHandler(cmnuUndoClick);
            
            this.picOutput.DoubleClick += new System.EventHandler(this.ImageDoubleClick);

            try{
				this.printDocument.DefaultPageSettings.Landscape = true;
			}
			catch{};	
			
			OptionsDialog.OptionsWorksheet = worksheet;
			OptionsDialog.TargetBounds = this.Bounds;
//			this.rtbMscEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorRedraw);

            this.lstPreview.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.DrawPreviewResize);
            this.lstPreview.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawPreview);
            this.lstPreview.SelectedIndexChanged += new System.EventHandler(this.SelectedPageChanged);
            this.rtbMscEditor.TextChanged += new System.EventHandler(this.EditorTextChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.GUIClose);
            this.rtbMscEditor.TextChanged += new System.EventHandler(this.RtbTextOnTextChanged);
            this.rtbMscEditor.LineChanged += new NumberingEditor.LineChangedEventHandler(RtbMscEditor_LineChanged);
            this.rtbMscEditor.KeyDown += new KeyEventHandler(RtbMscEditor_KeyDown);
            this.rtbMscEditor.KeyPress += new KeyPressEventHandler(RtbMscEditor_KeyPress);
            this.rtbMscEditor.SelectionChanged += new EventHandler(RtbMscEditor_SelectionChanged);
            
            ShowGraphicMenu();
            
            //Drag&Drop:
            this.DragEnter += new DragEventHandler(GUI_DragEnter);
            this.DragDrop += new DragEventHandler(GUI_DragDrop);
            this.AllowDrop = true;
            this.rtbMscEditor.DragEnter += new DragEventHandler(GUI_DragEnter);
            this.rtbMscEditor.DragDrop += new DragEventHandler(GUI_DragDrop);
        	this.rtbMscEditor.AllowDrop = true;
        }

        void GUI_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    if (System.IO.Path.GetExtension(files[0]).Equals(dragDropFileExtension))
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        void GUI_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                if (this.rtbMscEditor.Edited == true)
                {
                	switch (MessageBox.Show(strings.GetString("SaveFile?"), appName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                    		if(this.SaveFile())
                            	break;
                    		else
                    			return;
                        case DialogResult.Cancel:
                            return;
                        default:
                            break;
                    }
                }
                LoadFile(files[0], true);
            }
        }
        void RtbMscEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (rtbMscEditor.SelectedText.Length > 0)
            {
                this.umnuCut.Enabled = true;
                this.cmnuCut.Enabled = true;
                this.umnuCopy.Enabled = true;
                this.cmnuCopy.Enabled = true;
                this.tlbbCut.Enabled = true;
                this.tlbbCopy.Enabled = true;
                this.umnuDelete.Enabled = true;
                this.cmnuDelete.Enabled = true;
                
            }
            else
            {
                this.umnuCut.Enabled = false;
                this.cmnuCut.Enabled = false;
                this.umnuCopy.Enabled = false;
                this.cmnuCopy.Enabled = false;
                this.tlbbCut.Enabled = false;
                this.tlbbCopy.Enabled = false;
                this.umnuDelete.Enabled = false;
                this.cmnuDelete.Enabled = false;
                
            }
        }

        void RtbMscEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.ToString() == Keys.Insert.ToString())
            {
            	if (this.stbpInsert.Text == strings.GetString("Override"))
                    this.stbpInsert.Text = "";
                else
                    this.stbpInsert.Text = strings.GetString("Override");
            }
        }

        void RtbMscEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert && keyInsertDown)
            {
                keyInsertDown = false;
                if (this.stbpInsert.Text == strings.GetString("Override"))
                    this.stbpInsert.Text = "";
                else
                    this.stbpInsert.Text = strings.GetString("Override");
            }
            else
                keyInsertDown = true;
        }

       

        public static int ExportFileFormatIndex
        {
            get{
                return exportFileFormatIndex;
            }
            set{
                exportFileFormatIndex = value;
            }
        }
        public static bool SaveUndo
        {
            get{
                return saveUndo;
            }
            set{
                saveUndo = value;
            }
        }
        
		protected void WriteLog(string text)
		{
			if (fs != null){
			}
		}
		protected bool SourceFileWatchEnabled{
			get{
				return sourceFileWatchEnabled;
			}
			set{
				sourceFileWatchEnabled=value;
			}
		}
//		protected override void Dispose(bool disposing)
//		{
//			base.Dispose(disposing);
//		}
		

	/* FUNKTION: InterpretFile
	 * 
	 * IN:
	 * filename - Der vollständige Name und Pfad der geladenen Datei.
	 * showInProgram - Bestimmt, ob die geladene Datei dargestellt werden soll.
	 * 
	 * OUT:
	 * 
	 * BESCHREIBUNG:
	 * Die aufgabe der Funktion ist es, die Textdatei zu Interpretieren und ggf. 
	 * für die Darstellung zu sorgen. Der Editor wird bereits von der GUI geladen 
	 * jedoch ohne Highlighting.
	 */
		protected virtual void InterpretFile(string filename, bool showInProgram) { }

		
		
	/* FUNKTION: PrintDocumentPrintPage
	 * 
	 * IN: 
	 * Gemäß PrintPageEventHandler
	 * 
	 * OUT:
	 *
	 * BESCHREIBUNG:
	 * Aufgabe der funktion ist es, dass die Augabe gedruckt wird. Das Graphics-Object wird durch 
	 * PrintPageEventArgs e.Graphics geliefert.
	 */
        protected virtual void PrintDocumentPrintPage(object sender, PrintPageEventArgs e) { }  // in den Generator		
		
        
        protected virtual void PrintDocumentBeginPrint(object sender, PrintEventArgs e) { }
		
		
	/* FUNKTION: RedrawImage
	 * 
	 * IN: 
	 * 
	 * OUT:
	 *
	 * BESCHREIBUNG:
	 * Diese Funktion ist für das Neuzeichnen der aktuell angezeigten Seite zuständig 
	 */
        protected virtual void RedrawImage() { }
		
		
		
	/* FUNKTION: DrawNew
	 * 
	 * IN: 
	 * 
	 * OUT:
	 *
	 * BESCHREIBUNG:
	 * Diese Funktion ist für das Neuzeichnen der kompletten Ausgabe incl. Vorschau zuständig 
	 */
        protected virtual void DrawNew() { }
		
		
		
		/* Folgende Funktionen sollten in der erbenden Klasse überschrieben werden
		 * 
		 * void HighlightEditorText()
		 * void ImageClick(object sender, System.Windows.Forms.MouseEventArgs e)
		 * void ShowInfoDialog()
		 * void InitNewImage()
		 * void DrawPage(Graphics drawDestination, uint page)
		 * void AddPreview()
		 * uint GetPages()
		 * void DeleteData()
		 * 
		 * Zudem folgende Variablen überschrieben werden
		 * 
		 * appName = Name des Programms (nicht der exe !!)
		 * fileFilter = Filtertext für die Dialoge Open/Save File
		 * 
		 */
		
		protected virtual void OpenOptionsDialog()
		{
			if(OptionsDialog.ActiveDialog !=null){
				OptionsDialog.ActiveDialog.Close();
			}
			OptionsDialog.TargetBounds = this.Bounds;
			OptionsDialog sheetOptions = new OptionsDialog();
			sheetOptions.OnAcceptClick += new System.EventHandler(this.DialogOptionsAccept);
			sheetOptions.Location = OptionsDialog.DialogLocation;
			sheetOptions.Show();
		}
		protected virtual void DeleteData()
		{
			// dient zum Löschen der vorhandenen Diagramdaten
		}
		protected virtual void EditorTextChanged(object sender, System.EventArgs e)
		{
			HighlightEditorText();
		}
		protected virtual void HighlightEditorText()
		{
			// Funktion zum Syntax-Highlighting
			// Wenn nicht überladen, Kein highlighting
		}
		protected virtual void HighlightEditorTextAll()
		{
			
		}
		protected virtual void ImageDoubleClick(object sender, System.EventArgs e)
		{
		
		}
		protected virtual void ImageClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (outputMoved){
				outputMoved = false;
				return;
			}
			this.InitDrawDestination();
			drawDestination.DrawLine(Pens.Black,((float)e.X*(100.0f/(float)outputZoom))-15,((float)e.Y*(100.0f/(float)outputZoom)), ((float)e.X*(100.0f/(float)outputZoom))+15, ((float)e.Y*(100.0f/(float)outputZoom)));
			drawDestination.DrawLine(Pens.Black, (e.X*(100.0f/(float)outputZoom)),(e.Y*(100.0f/(float)outputZoom))-15, (e.X*(100.0f/(float)outputZoom)), (e.Y*(100.0f/(float)outputZoom))+15);
			drawDestination.DrawEllipse(Pens.Black, (e.X*(100.0f/(float)outputZoom))-10,(e.Y*(100.0f/(float)outputZoom))-10,20,20);
			drawDestination.DrawEllipse(Pens.Red,(e.X*(100.0f/(float)outputZoom))-5,(e.Y*(100.0f/(float)outputZoom))-5,10,10);
			drawDestination.FillEllipse(Brushes.Black,(e.X*(100.0f/(float)outputZoom))-2,(e.Y*(100.0f/(float)outputZoom))-2,4,4);
			this.picOutput.Invalidate();     // refresh output
			
			drawDestination.Dispose();
		}
		protected virtual void ShowInfoDialog()
		{
			InfoTemplate info = new InfoTemplate();
			info.ShowDialog();
			info.Dispose();			
		}
		protected virtual void NewImage()
		{
			if(this.rtbMscEditor.Edited == true){
				switch (MessageBox.Show(strings.GetString("SaveFile?"),appName,MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)){
				        case DialogResult.Yes:
				        	if(this.SaveFile())
                            	break;
                    		else
                    			return;
				        case DialogResult.Cancel:
				        	return;
				        default:
				        	break;
				}
			}
			this.rtbMscEditor.Clear();
			InitDrawDestination();
			this.picOutput.Invalidate();
			drawDestination.Dispose();
			InitNewImage();
			AddPreview();
			lastOpenedFile="";
		}
		protected virtual void InitNewImage()
		{
			//Daten löschen
			DeleteData();
			Worksheet.InitFootLine();
			
			//Standardtext für das Editorfenster, ggf. Heighlighting starten
			this.rtbMscEditor.Text = "Initialisierungstext";
			
			//Fenstertitel
			this.Text = appName + " - Neue Datei";
			this.rtbMscEditor.Edited = false;		
		}
		protected virtual void ExportImage()
		{
			string format, file;
			uint pages;
			pages = GetPages();		// calculate imageBitmap page count
			if (pages > 0)			// something to do?
			{
				dlgSaveImage.Filter="Bitmap (*.bmp)|*.bmp|GIF (.gif)|*.gif|JPEG (.jpg)|*.jpg|Portable Network Graphics (.png)|*.png|Windows Metafile (.wmf)|*.wmf|Enhanced Windows Metafile (.emf)|*.emf";
				dlgSaveImage.FilterIndex = GUI.ExportFileFormatIndex;
				dlgSaveImage.Title = strings.GetString("Export");
				if(lastOpenedFile != ""){
					if (lastOpenedFile.LastIndexOf('.') >= lastOpenedFile.Length -3){
						dlgSaveImage.FileName = lastOpenedFile.Substring(0,lastOpenedFile.LastIndexOf('.'));
					}
				}
				if (dlgSaveImage.ShowDialog()==DialogResult.OK){
					file=dlgSaveImage.FileName;
					switch (dlgSaveImage.FilterIndex){
						case 1:
							format="BMP";
							break;
						case 2:
							format="GIF";
							break;
						case 3:
							format="JPG";
							break;
						case 4:
							format="PNG";
							break;
						case 5:
							format="WMF";
							break;
						case 6:
							format="EMF";
							break;
						default:
							format="BMP";
							break;							
					}
					GUI.ExportFileFormatIndex = dlgSaveImage.FilterIndex;
					ExportImage(file, format);
				}
			}
		}
		
		protected virtual void ExportImage(string filename, string format)
		{
			try
			{
			uint pages;
			Image exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);		// create export draw area
			Graphics drawDestination = Graphics.FromImage(exportImage);
			Graphics grph;
			IntPtr ipHDC;																	//necessary for wmf and emf export
			Metafile mf;
			//EMetafile ef;
			pages = GetPages();		// calculate imageBitmap page count
			if (pages > 0)																	// something to do?
			{
				if (filename.LastIndexOf('.') >= (filename.Length-4)){
					filename = filename.Substring(0,filename.LastIndexOf('.'));
				}
				for (uint i=1; i<=pages; i++){
					switch (format.ToUpper()){				// identify selected format
						case "BMP":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination,i);
							exportImage.Save(filename + "_" + i + ".bmp");
							break;
						case "GIF":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination,i);
							exportImage.Save(filename + "_" + i + ".gif",System.Drawing.Imaging.ImageFormat.Gif);
							break;
						case "JPG":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination,i);
							exportImage.Save(filename + "_" + i + ".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
							break;
						case "PNG":
							drawDestination.Clear(Color.White);						
							DrawPage(drawDestination,i);
							exportImage.Save(filename + "_" + i + ".png",System.Drawing.Imaging.ImageFormat.Png);
							break;
						case "WMF":
							drawDestination.Clear(Color.White);						
							exportImage.Save(filename + "_" + i + ".wmf",System.Drawing.Imaging.ImageFormat.Wmf);		// for save as wmf first empty wmf file shall be created
							grph = this.CreateGraphics(); 
							ipHDC = grph.GetHdc(); 
							mf = new Metafile(filename + "_" + i + ".wmf", ipHDC); 										// open created empty wmf file
							grph = Graphics.FromImage(mf); 
							grph.Clear(Color.White);
							grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
							grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
							DrawPage(grph,i);														// draw imageBitmap direct to wmf file
							grph.Dispose();
							mf.Dispose();
							break;
						case "EMF":
							drawDestination.Clear(Color.White);						
							exportImage.Save(filename + "_" + i + ".emf",System.Drawing.Imaging.ImageFormat.Emf);  		// for save as emf first empty wmf file shall be created
							grph = this.CreateGraphics(); 
							ipHDC = grph.GetHdc(); 
							mf = new Metafile(filename + "_" + i + ".emf", ipHDC); 										// open created empty emf file
							grph = Graphics.FromImage(mf); 
							grph.Clear(Color.White);
							grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
							grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
							DrawPage(grph,i);														// draw imageBitmap direct to emf file
							grph.Dispose();
							mf.Dispose();
							break;
					}
				}
			}
			Worksheet tmpWorksheet = new Worksheet();						// recalculate back line hights for screen output
			tmpWorksheet.Width = worksheet.GetWorksheetWidth();
			tmpWorksheet.Height = worksheet.GetWorksheetHeight();
			tmpWorksheet.SetMargins(0,0,0,0);
			drawDestination.Dispose();
			exportImage.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		protected virtual void GUIClose(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.rtbMscEditor.Edited == true){
				switch (MessageBox.Show(strings.GetString("SaveFile?"),appName,MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)){
				        case DialogResult.Yes:
						if(!this.SaveFile())
								e.Cancel = true;
				        	break;
				        case DialogResult.No:
							break;
				        	case DialogResult.Cancel:
							e.Cancel = true;
				        	break;
				        default:
				        	break;
				}
			}
		}
		protected virtual void DrawPage(Graphics drawDestination, uint page)
		{
			// Zeichnet die Diagramseite auf dem übergebenen Graphics-Objekt
			
			Font f = new Font("Arial",30,FontStyle.Bold,GraphicsUnit.Point);
			StringFormat pageStringFormat = new StringFormat();
			pageStringFormat.Alignment = StringAlignment.Center;
			pageStringFormat.LineAlignment = StringAlignment.Center;
			
			drawDestination.Clear(Color.White);
			drawDestination.DrawString("Seite" + page.ToString()+ "\nFunktion nicht implementiert",f,Brushes.DarkBlue,new RectangleF(0,0,worksheet.GetWorksheetWidth() ,worksheet.GetWorksheetHeight()),pageStringFormat);
			
			pageStringFormat.Dispose();
			
		}
		protected virtual void AddPreview()
		{
			// Erstellt die Vorschau der erstellten Seiten auf der linken Seite der Oberfläche
			Image mscPreview = new Bitmap(90,60);
			Font f = new Font("Arial",30,FontStyle.Bold,GraphicsUnit.Point);
			Graphics previewDestination = Graphics.FromImage(mscPreview);
			StringFormat previewStringFormat = new StringFormat();
			previewStringFormat.Alignment = StringAlignment.Center;
			previewStringFormat.LineAlignment = StringAlignment.Center;
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("P",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("R",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("E",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("V",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("I",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("E",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewDestination.Clear(Color.White);
			previewDestination.DrawString("W",f,Brushes.DarkBlue,new RectangleF(0,0,90,mscPreview.Height),previewStringFormat);
			previewImages.Add(new PreviewImage(mscPreview));	// add image list picture to array list
			this.lstPreview.Items.Add("");	// add image list picture to image list
			previewStringFormat.Dispose();
			previewDestination.Dispose();
			mscPreview.Dispose();			
		}

		protected virtual uint GetPages()
		{
			// Liefert die Anzahl der erstellten Diagramseiten
			return 0;
		}

		protected virtual void Exit()
		{
            if (this.rtbMscEditor.Edited == true)
            {
                switch (MessageBox.Show(strings.GetString("SaveFile?"), appName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if(this.SaveFile())
                            	break;
                    		else
                    			return;
                    case DialogResult.Cancel:
                        return;
                    default:
                        break;
                }
            }
			this.Close();
		}

		protected virtual void LoadFile(string filename, bool showInProgram)
		{
			string s = String.Empty;
			string[] temp;
			temp = filename.Split('\\');								// get filename
			lastOpenedFile = filename;
			sourceFileWatch.Path = System.IO.Directory.GetParent(lastOpenedFile).FullName;
			Worksheet.InitFootLine();
			Worksheet tmpWorksheet = new Worksheet();								// create temporary worksheet without margins for screen otput
			tmpWorksheet.Width = worksheet.GetWorksheetWidth();
			tmpWorksheet.Height = worksheet.GetWorksheetHeight();
			tmpWorksheet.EnableFootLine = false;
			tmpWorksheet.SetMargins(0,0,0,0);
			if (showInProgram == true){
				this.stbpFile.Text = temp[temp.Length-1];
                Worksheet.FileName = temp[temp.Length - 1];
				this.rtbMscEditor.MarkedRow = 0;
				this.rtbMscEditor.LoadFile(lastOpenedFile,RichTextBoxStreamType.PlainText);
				this.tlbbSaveText.Enabled = false;				
				this.umnuSave.Enabled = false;
			}
			InterpretFile(filename, showInProgram);

			this.RtbTextInitUndo();
			this.rtbMscEditor.Edited = false;
			this.rtbMscEditor.Modified = false;
			this.Text = appName + " - " + lastOpenedFile;
			if (showInProgram == true){
				this.ZoomToPage();
				this.CenterPage();
			}
		}
		
		protected virtual void LoadFile()
		{
			if(this.rtbMscEditor.Edited == true){
				switch (MessageBox.Show(strings.GetString("SaveFile?"),appName,MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)){
				        case DialogResult.Yes:
				        	if(this.SaveFile())
                            	break;
                    		else
                    			return;
				        case DialogResult.Cancel:
				        	return;
				        default:
				        	break;
				}
			}
			dlgOpenFile.Filter=fileFilter;									// set open file dialog filter
			dlgSaveImage.FilterIndex = 0;
			if (dlgOpenFile.ShowDialog()==DialogResult.OK){								// show open file dialog
				lastOpenedFile = dlgOpenFile.FileName;
                DeleteData();
				Worksheet.InitFootLine();
                this.rtbMscEditor.MarkedRow = 0;
				this.rtbMscEditor.LoadFile(dlgOpenFile.FileName,RichTextBoxStreamType.PlainText);
				this.tlbbSaveText.Enabled = false;		
				this.umnuSave.Enabled = false;
				string[] temp;
				temp = dlgOpenFile.FileName.Split('\\');								// get filename
				this.stbpFile.Text = temp[temp.Length-1];
				Worksheet.FileName = temp[temp.Length-1];
				sourceFileWatch.Path = System.IO.Directory.GetParent(dlgOpenFile.FileName).FullName;
				InterpretFile(dlgOpenFile.FileName, true);				
				this.RtbTextInitUndo();
				this.rtbMscEditor.Edited = false;
				this.rtbMscEditor.Modified = false;
                this.ZoomToPage();
                this.CenterPage();
			}
		}
		protected virtual bool SaveAsFile()
		{		
			dlgSaveImage.Filter=fileFilter;
			dlgSaveImage.FilterIndex = 0;
			dlgSaveImage.FileName = lastOpenedFile;
			dlgSaveImage.OverwritePrompt = true;
			dlgSaveImage.Title = strings.GetString("SaveAs");
			if (dlgSaveImage.ShowDialog()==DialogResult.OK){
				this.sourceFileWatch.EnableRaisingEvents = false;
				string filename = dlgSaveImage.FileName;
				this.rtbMscEditor.SaveFile(filename,RichTextBoxStreamType.PlainText);
				this.rtbMscEditor.Edited = false;
				this.lastOpenedFile = filename;
				sourceFileWatch.Path = System.IO.Directory.GetParent(filename).FullName;
				this.Text = appName + " - " + lastOpenedFile;
				string[] temp = lastOpenedFile.Split('\\');								// get filename
				this.stbpFile.Text = temp[temp.Length-1];
				Worksheet.FileName = temp[temp.Length-1];
				this.sourceFileWatch.EnableRaisingEvents = true;
				this.tlbbSaveText.Enabled = false;
				this.umnuSave.Enabled = false;
				return true;
			}
			return false;
		}
		private void Search(object sender, System.EventArgs e)
		{
			if(searchText!=((Search)searchDialog).SearchText){
				searchText = ((Search)searchDialog).SearchText;
				searchStartPosition = this.rtbMscEditor.SelectionStart + this.rtbMscEditor.SelectionLength;
			}
			searchWordOnly = ((Search)searchDialog).SearchWordOnly;
			searchUpperLowerCase = ((Search)searchDialog).SearchUpperLowerCase;
			SearchAgain(sender, e);
		}
		private void SearchAgain(object sender, System.EventArgs e)
		{
			RichTextBoxFinds options = new RichTextBoxFinds();
			if (searchWordOnly) options |= RichTextBoxFinds.WholeWord;
			if (searchUpperLowerCase) options |= RichTextBoxFinds.MatchCase;
			if ((this.rtbMscEditor.Find(searchText,this.rtbMscEditor.SelectionStart + Math.Min(searchText.Length, this.rtbMscEditor.SelectionLength), options)==-1)&&(this.rtbMscEditor.SelectionStart + Math.Min(searchText.Length, this.rtbMscEditor.SelectionLength) > 0)){
				if(this.rtbMscEditor.Find(searchText,0, searchStartPosition ,options)==-1){
					MessageBox.Show(strings.GetString("TextNotFound"));
				}
			}
		}
		private void CloseSearch(object sender, System.EventArgs e)
		{
			if (searchDialog!=null){
				((Search)searchDialog).Close();
				searchDialog = null;
			}
		}
		private void CloseingSearch(object sender, System.EventArgs e)
		{
			if (searchDialog!=null){
				searchDialog = null;
			}
		}
		private void umnuSearchClick(object sender, System.EventArgs e)
		{
			if (searchDialog is Search) return;
			if (searchDialog != null){
				((Replace)searchDialog).Close();
			}
			searchDialog = new Search();
			if (this.rtbMscEditor.SelectionLength == 0){
				((Search)searchDialog).SearchText = searchText;
			}
			else{
				((Search)searchDialog).SearchText = this.rtbMscEditor.SelectedText.Split(new char[7]{'\n',' ', '\t','.',',',';',':'})[0];
			}
			((Search)searchDialog).OnSearchClick += new System.EventHandler(this.Search);
			((Search)searchDialog).OnCancelClick += new System.EventHandler(this.CloseSearch);
			((Search)searchDialog).OnClose += new System.EventHandler(this.CloseingSearch);
			((Search)searchDialog).Visible = true;
		}
		private void SearchReplace(object sender, System.EventArgs e)
		{
			if(searchText!=((Replace)searchDialog).SearchText){
				searchText = ((Replace)searchDialog).SearchText;
				replaceText = ((Replace)searchDialog).ReplaceText;
				searchStartPosition = this.rtbMscEditor.SelectionStart + replaceText.Length;
			}
			searchWordOnly = ((Replace)searchDialog).SearchWordOnly;
			searchUpperLowerCase = ((Replace)searchDialog).SearchUpperLowerCase;
			SearchReplaceAgain(sender, e);
		}
		private void SearchReplaceAgain(object sender, System.EventArgs e)
		{
			RichTextBoxFinds options = new RichTextBoxFinds();
			if (searchWordOnly) options |= RichTextBoxFinds.WholeWord;
			if (searchUpperLowerCase) options |= RichTextBoxFinds.MatchCase;
			if ((this.rtbMscEditor.Find(searchText,this.rtbMscEditor.SelectionStart + Math.Min(searchText.Length, this.rtbMscEditor.SelectionLength), options)==-1)&&(this.rtbMscEditor.SelectionStart + Math.Min(searchText.Length, this.rtbMscEditor.SelectionLength) > 0)){
				if(this.rtbMscEditor.Find(searchText,0 ,options)==-1){
					MessageBox.Show(strings.GetString("FileNotFound"));
				}
			}
		}
		private void Replace(object sender, System.EventArgs e)
		{
			this.rtbMscEditor.SelectedText = replaceText;
			if(searchText!=((Replace)sender).SearchText){
				searchText = ((Replace)sender).SearchText;
				replaceText = ((Replace)sender).ReplaceText;
				searchStartPosition = this.rtbMscEditor.SelectionStart + this.rtbMscEditor.SelectionLength;
			}
			searchWordOnly = ((Replace)sender).SearchWordOnly;
			searchUpperLowerCase = ((Replace)sender).SearchUpperLowerCase;
			SearchReplaceAgain(sender, e);			
		}
		protected void ReplaceAll(object sender, System.EventArgs e)
		{
			RichTextBoxFinds options = new RichTextBoxFinds();
			searchWordOnly = ((Replace)sender).SearchWordOnly;
			searchUpperLowerCase = ((Replace)sender).SearchUpperLowerCase;
			if (searchWordOnly) options |= RichTextBoxFinds.WholeWord;
			if (searchUpperLowerCase) options |= RichTextBoxFinds.MatchCase;
			searchText = ((Replace)sender).SearchText;
			replaceText = ((Replace)sender).ReplaceText;
			int startPos = 0;
			while (this.rtbMscEditor.Find(searchText,startPos ,options)!=-1){
				this.rtbMscEditor.SelectedText = replaceText;
				startPos = this.rtbMscEditor.SelectionStart + this.replaceText.Length;
			}
		}
	
		private void CloseReplace(object sender, System.EventArgs e)
		{
			if (searchDialog!=null){
				((Replace)sender).Close();
				searchDialog = null;
			}
		}
		private void CloseingReplace(object sender, System.EventArgs e)
		{
			if (searchDialog!=null){
				searchDialog = null;
			}
		}
		private void UmnuZoomInClick(object sender, System.EventArgs e)
		{
            this.ZoomInSmall();
		}
		private void UmnuZoomOutClick(object sender, System.EventArgs e)
		{
            this.ZoomOutSmall();
		}
		private void UmnuZoomFitClick(object sender, System.EventArgs e)
		{
			this.ZoomToPage();
			this.CenterPage();
		}
		private void UmnuZoomPageWidth(object sender, System.EventArgs e)
		{
			this.ZoomToPageWidth();
		}
		private void UmnuZoomPageHeight(object sender, System.EventArgs e)
		{
			this.ZoomToPageHeight();
		}
		private void Zoom25(object sender, System.EventArgs e)
		{
            this.ZoomSmall(25);
		}
		private void Zoom33(object sender, System.EventArgs e)
		{
            this.ZoomSmall(33);
		}
		private void Zoom50(object sender, System.EventArgs e)
		{
			this.ZoomSmall(50);
		}
		private void Zoom66(object sender, System.EventArgs e)
		{
            this.ZoomSmall(66);
		}
		private void Zoom100(object sender, System.EventArgs e)
		{
            this.ZoomSmall(100);
		}
		private void Zoom150(object sender, System.EventArgs e)
		{
            this.ZoomSmall(150);
		}
		private void Zoom200(object sender, System.EventArgs e)
		{
            this.ZoomSmall(200);
		}
		private void Zoom400(object sender, System.EventArgs e)
		{
            this.ZoomSmall(400);
		}
		private void Zoom600(object sender, System.EventArgs e)
		{
            this.ZoomSmall(600);
		}
		void umnuExitClick(object sender, System.EventArgs e)
		{
			this.Exit();
		}		
		public bool SetWorksheetSize(byte size, byte layout){
			worksheet.Size = size;
			worksheet.Layout = layout;
			switch(size){
				case Worksheet.WS_SIZE_A0_ISO:
					switch(layout){
						case Worksheet.WS_LAYOUT_HORIZONTAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A0_Y,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A0_X,Worksheet.WS_UNIT_CM);
							break;
						case Worksheet.WS_LAYOUT_VERTICAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A0_X,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A0_Y,Worksheet.WS_UNIT_CM);
							break;		
					}
					break;
				case Worksheet.WS_SIZE_A1_ISO:
					switch(layout){
						case Worksheet.WS_LAYOUT_HORIZONTAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A1_Y,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A1_X,Worksheet.WS_UNIT_CM);
							break;
						case Worksheet.WS_LAYOUT_VERTICAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A1_X,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A1_Y,Worksheet.WS_UNIT_CM);
							break;		
					}
					break;
				case Worksheet.WS_SIZE_A2_ISO:
					switch(layout){
						case Worksheet.WS_LAYOUT_HORIZONTAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A2_Y,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A2_X,Worksheet.WS_UNIT_CM);
							break;
						case Worksheet.WS_LAYOUT_VERTICAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A2_X,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A2_Y,Worksheet.WS_UNIT_CM);
							break;		
					}
					break;
				case Worksheet.WS_SIZE_A3_ISO:
					switch(layout){
						case Worksheet.WS_LAYOUT_HORIZONTAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A3_Y,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A3_X,Worksheet.WS_UNIT_CM);
							break;
						case Worksheet.WS_LAYOUT_VERTICAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A3_X,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A3_Y,Worksheet.WS_UNIT_CM);
							break;		
					}
					break;
				case Worksheet.WS_SIZE_A4_ISO:
					switch(layout){
						case Worksheet.WS_LAYOUT_HORIZONTAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A4_Y,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A4_X,Worksheet.WS_UNIT_CM);
							break;
						case Worksheet.WS_LAYOUT_VERTICAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A4_X,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A4_Y,Worksheet.WS_UNIT_CM);
							break;		
					}
					break;
				case Worksheet.WS_SIZE_A5_ISO:
					switch(layout){
						case Worksheet.WS_LAYOUT_HORIZONTAL:
                            worksheet.Width = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_Y, Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_X,Worksheet.WS_UNIT_CM);
                            break;
						case Worksheet.WS_LAYOUT_VERTICAL:
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_X,Worksheet.WS_UNIT_CM);
							worksheet.Height = (int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_Y,Worksheet.WS_UNIT_CM);
							break;		
					}
					break;										
			}
			return worksheet.CheckSizes();
		}
		public bool SetWorksheetWidth(float width, byte unit){
			width = worksheet.CalcSize(width, unit);
			worksheet.Width = (int)width;
			worksheet.Size = Worksheet.WS_SIZE_USER_DEFINED;
			return worksheet.CheckSizes();
		}
		public bool SetWorksheetHeight(float height, byte unit){
			height = worksheet.CalcSize(height, unit);
			worksheet.Height = (int)height;
			worksheet.Size = Worksheet.WS_SIZE_USER_DEFINED;
			return worksheet.CheckSizes();
		}
		public bool SetWorksheetLeftMargin(float margin, byte unit){
			margin = worksheet.CalcSize(margin, unit);
			worksheet.LeftMargin = (int)margin;
			return worksheet.CheckSizes();
		}
		public bool SetWorksheetRightMargin(float margin, byte unit){
			margin = worksheet.CalcSize(margin, unit);
			worksheet.RightMargin = (int)margin;
			return worksheet.CheckSizes();
		}
		public bool SetWorksheetTopMargin(float margin, byte unit){
			margin = worksheet.CalcSize(margin, unit);
			worksheet.TopMargin = (int)margin;
			return worksheet.CheckSizes();
		}
		public bool SetWorksheetBottomMargin(float margin, byte unit){
			margin = worksheet.CalcSize(margin, unit);
			worksheet.BottomMargin = (int)margin;
			return worksheet.CheckSizes();
		}
		public void SetWorksheetMargins(int leftMargin,int rightMargin,int topMargin,int bottomMargin){
			worksheet.LeftMargin = leftMargin;
			worksheet.RightMargin = rightMargin;
			worksheet.TopMargin = topMargin;
			worksheet.BottomMargin = bottomMargin;
			worksheet.CheckSizes();
		}
		public bool SetWorksheetLayout(byte layout){
			worksheet.Layout = layout;
			return true;
		}

		protected virtual void TabChanged(object sender, System.EventArgs e)
		{
			if (this.tabWork.SelectedIndex == 0){
				if (searchDialog != null){
					if (searchDialog is Search){
						CloseSearch(searchDialog, e);
					}
					else if(searchDialog is Replace){
						CloseReplace(searchDialog, e);
					}
				}
				
				ShowGraphicMenu();
         	}
			else {
				ShowEditorMenu();
			}
		}
		protected virtual void ShowGraphicMenu()
		{
            this.tlbbCopy.Visible = false;
            this.tlbbCut.Visible = false;
            this.tlbbPaste.Visible = false;
            this.umnuCopy.Enabled = false;
            this.umnuCut.Enabled = false;
            this.umnuPaste.Enabled = false;
			this.umnuSearch.Enabled = false;
            this.umnuSearchAgain.Enabled = false;
            this.umnuReplace.Enabled = false;
            this.umnuComment.Enabled = false;
            this.tlbbComment.Visible = false;
            this.tlbbSearch.Visible = false;
            this.umnuZoomFit.Enabled = true;
            this.umnuZoomFitHeight.Enabled = true;
            this.umnuZoomFitWide.Enabled = true;
            this.umnuZoomIn.Enabled = true;
            this.umnuZoomOut.Enabled = true;
            this.umnuZoomTo.Enabled = true;
            this.tlbbZoomF.Visible = true;
            this.tlbbZoomM.Visible = true;
            this.tlbbZoomP.Visible = true;
            this.tlbbZoomFitHeight.Visible = true;
            this.tlbbZoomFitWide.Visible = true;
            this.tlbbZoomFit100.Visible = true;
            this.umnuDelete.Enabled = false;
            this.umnuSelectAll.Enabled=false;
        }
		protected virtual void ShowEditorMenu()
		{
            this.umnuZoomFit.Enabled = false;
            this.umnuZoomFitHeight.Enabled = false;
            this.umnuZoomFitWide.Enabled = false;
            this.umnuZoomIn.Enabled = false;
            this.umnuZoomOut.Enabled = false;
            this.umnuZoomTo.Enabled = false;
            this.tlbbZoomF.Visible = false;
            this.tlbbZoomM.Visible = false;
            this.tlbbZoomP.Visible = false;
            this.tlbbZoomFitHeight.Visible = false;
            this.tlbbZoomFitWide.Visible = false;
            this.tlbbZoomFit100.Visible = false;
            this.tlbbCopy.Visible = true;
            this.tlbbCut.Visible = true;
            this.tlbbPaste.Visible = true;			
            this.umnuSearch.Enabled = true;
            this.umnuSearchAgain.Enabled = true;
            this.umnuReplace.Enabled = true;
            this.umnuComment.Enabled = true;
            this.tlbbComment.Visible = true;
            this.tlbbSearch.Visible = true;
            this.umnuDelete.Enabled = true;
            this.umnuSelectAll.Enabled=true;
            if(System.Windows.Forms.Clipboard.GetText()!="")
        	{
        		this.umnuPaste.Enabled = true;
        		this.cmnuPaste.Enabled = true;
        		this.tlbbPaste.Enabled = true;
        	}
        	else
        	{
        		this.umnuPaste.Enabled = false;
        		this.cmnuPaste.Enabled = false;
        		this.tlbbPaste.Enabled = false;
        	}
        	if(this.rtbMscEditor.SelectedText.Length > 0)
        	{
        		this.umnuCopy.Enabled = true;
            	this.umnuCut.Enabled = true;
            }
		}
		public virtual void RedrawRescaled()
		{
			imageBitmap.Dispose();
			imageBitmap = new Bitmap(this.worksheet.GetWorksheetWidth(), this.worksheet.GetWorksheetHeight()); 		// working bitmap, draw destination of generated msc
			this.stbpSize.Text = strings.GetString("Size") + this.worksheet.GetWorksheetWidth().ToString() + " x " + this.worksheet.GetWorksheetHeight().ToString();
			// resize the GUI image 
			this.picOutput.Width = ((int) (this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)));
			this.picOutput.Height = (int) (this.worksheet.GetWorksheetHeight() * ((float)outputZoom/(float)100));
			dpiOutput = imageBitmap.HorizontalResolution;
			worksheet.Dpi = dpiOutput;
			DrawNew();
		}
		protected virtual void RescaleImage()
		{
			imageBitmap.Dispose();
			imageBitmap = new Bitmap(this.worksheet.GetWorksheetWidth(), this.worksheet.GetWorksheetHeight()); 		// working bitmap, draw destination of generated msc
			// resize the GUI image 
			dpiOutput = imageBitmap.HorizontalResolution;
			worksheet.Dpi = dpiOutput;
		}
		protected virtual void PreviewPage()
		{
			// show the print preview
			printPage = 1;
			try{
				this.dlgPreviewPage.Text = strings.GetString("PrintPreview");
                this.dlgPreviewPage.Icon = this.Icon;
				if (this.dlgPreviewPage.ShowDialog()==DialogResult.OK){
					this.PrintImage();
				}
			}
			catch{}
			printPage = 1;
		}
		
		/// <description>redraw whole image list and GUI image</description>
		
		/// <description>redraw whole image list pictures</description>
		
		void PicOutputRedraw(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(imageMetaFile,new RectangleF(0,0,this.picOutput.Width,picOutput.Height));
		}
            
        protected void ZoomInSmall()
		{
            //zoom in center
            //mouse == center
            int centerX = (pnlOutput.Width / 2 - this.pnlOutput.DisplayRectangle.X - (this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X));
            int centerY = (pnlOutput.Height / 2 - this.pnlOutput.DisplayRectangle.Y - (this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y));
            Point mouse = new Point(centerX, centerY);
			int xnew = 0, ynew = 0;
			outputZoom = Math.Min(outputZoom+SMALL_ZOOM,300);			// max zoom 300
			this.pnlOutput.RePaint = false;
			this.picOutput.RePaint = false;
			int px = this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X;
			int py = this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y;
			float fx = (this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Width-1.0f;
			float fy = (this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Height - 1.0f;
			xnew = (int)((float)mouse.X * (fx) + (float)this.pnlOutput.HorizontalScroll.Value);
			ynew = (int)((float)mouse.Y * (fy) + (float)this.pnlOutput.VerticalScroll.Value);
			this.pnlOutput.SuspendLayout();
			this.picOutput.Size = new Size((int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)), (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)));
			this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pnlOutput.ResumeLayout(false);
			this.picOutput.RePaint = true;
			this.pnlOutput.RePaint = true;
			this.pnlOutput.Invalidate();
            this.pnlOutput.AutoScrollPosition = new Point(xnew, ynew);
        	this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";									// refresh statusbar
        }
        protected void ZoomOutSmall()
        {
            //zoom in center
            //mouse == center
            int centerX = (pnlOutput.Width / 2 - this.pnlOutput.DisplayRectangle.X - (this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X));
            int centerY = (pnlOutput.Height / 2 - this.pnlOutput.DisplayRectangle.Y - (this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y));
            Point mouse = new Point(centerX, centerY);
            int xnew = 0, ynew = 0;
            outputZoom = Math.Max(outputZoom - SMALL_ZOOM, 10);			// min zoom 10
            this.pnlOutput.RePaint = false;
            this.picOutput.RePaint = false;
            int px = this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X;
            int py = this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y;
            float fx = (this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Width - 1.0f;
            float fy = (this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Height - 1.0f;
            xnew = (int)((float)mouse.X * (fx) + (float)this.pnlOutput.HorizontalScroll.Value);
            ynew = (int)((float)mouse.Y * (fy) + (float)this.pnlOutput.VerticalScroll.Value);
            this.pnlOutput.SuspendLayout();
            this.picOutput.Size = new Size((int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)), (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)));
            this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pnlOutput.ResumeLayout(false);
            this.picOutput.RePaint = true;
            this.pnlOutput.RePaint = true;
            this.pnlOutput.Invalidate();
            this.pnlOutput.AutoScrollPosition = new Point(xnew, ynew);
            this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";										// refresh statusbar
        }
		protected void ZoomInSmall(Point mouse)
		{
            //zoom to mouse
			int xnew = 0, ynew = 0;
			outputZoom = Math.Min(outputZoom+SMALL_ZOOM,300);			// max zoom 300
            //this.pnlOutput.AutoScrollMargin = new Size((int)(outputZoom*2), (int)(outputZoom*2));
            this.pnlOutput.RePaint = false;
			this.picOutput.RePaint = false;
			int px = this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X;
			int py = this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y;
			float fx = (this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Width-1.0f;
			float fy = (this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Height - 1.0f;
			xnew = (int)((float)mouse.X * (fx) + (float)this.pnlOutput.HorizontalScroll.Value);
			ynew = (int)((float)mouse.Y * (fy) + (float)this.pnlOutput.VerticalScroll.Value);
            this.pnlOutput.SuspendLayout();
			this.picOutput.Size = new Size((int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)), (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)));
			this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pnlOutput.ResumeLayout(false);
			this.picOutput.RePaint = true;
			this.pnlOutput.RePaint = true;
			this.pnlOutput.Invalidate();
            this.pnlOutput.AutoScrollPosition = new Point(xnew, ynew);
         	this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";									// refresh statusbar
    	}
		
		protected void ZoomOutSmall(Point mouse)
		{
            //zoom to mouse
           	int xnew = 0, ynew = 0;
			outputZoom = Math.Max(outputZoom-SMALL_ZOOM,10);			// min zoom 10
            this.pnlOutput.RePaint = false;
			this.picOutput.RePaint = false;
			int px = this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X;
			int py = this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y;
			float fx = (this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Width-1.0f;
			float fy = (this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Height - 1.0f;
			xnew = (int)((float)mouse.X * (fx) + (float)this.pnlOutput.HorizontalScroll.Value);
			ynew = (int)((float)mouse.Y * (fy) + (float)this.pnlOutput.VerticalScroll.Value);
			this.pnlOutput.SuspendLayout();
			this.picOutput.Size = new Size((int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)), (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)));
			this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pnlOutput.ResumeLayout(false);
			this.picOutput.RePaint = true;
			this.pnlOutput.RePaint = true;
			this.pnlOutput.Invalidate();
            this.pnlOutput.AutoScrollPosition = new Point(xnew, ynew);
			this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";									// refresh statusbar
		}
        
        //protected void ZoomIn()
        //{
        //    this.pnlOutput.SuspendLayout();
        //    outputZoom = Math.Min(outputZoom+20,300);			// max zoom 300
        //    this.picOutput.Width = ((int) (((float)this.worksheet.GetWorksheetWidth()) * (((float)outputZoom) / 100.0f)));   // calculate GUI size
        //    this.picOutput.Height = ((int)(((float)this.worksheet.GetWorksheetHeight()) * (((float)outputZoom) / 100.0f)));
        //    this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
        //    //RedrawImage();
        //    this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";									// refresh statusbar
        //    this.pnlOutput.ResumeLayout(true);
        //}
		
        //protected void ZoomOut()
        //{
        //    this.pnlOutput.SuspendLayout();
        //    outputZoom = (uint) Math.Max((int)((int)outputZoom-20),(int)20);					// min zoom 20
        //    this.picOutput.Width = (int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100));	// calculate GUI size
        //    this.picOutput.Height = (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100));
        //    //RedrawImage();
        //    this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
        //    this.stbpZoom.Text = "Zoom: " + outputZoom + "%";									// refresh statusbar
        //    this.pnlOutput.ResumeLayout(true);
        //}
		
        //protected void zoomSet(uint zoom)															
        //{
        //    outputZoom = zoom;
        //    this.picOutput.Width = (int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100));	// calculate GUI size
        //    this.picOutput.Height = (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100));
        //    RedrawImage();
        //    this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";									// refresh statusbar
        //}


        protected void ZoomSmall(uint zoom)
        {
            //zoom in center
            int centerX = (pnlOutput.Width / 2 - this.pnlOutput.DisplayRectangle.X - (this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X));
            int centerY = (pnlOutput.Height / 2 - this.pnlOutput.DisplayRectangle.Y - (this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y));
            Point mouse = new Point(centerX, centerY);
            int xnew = 0, ynew = 0;
            outputZoom = Math.Min(zoom, 300);			// max zoom 300
            this.pnlOutput.RePaint = false;
            this.picOutput.RePaint = false;
            int px = this.picOutput.Location.X - this.pnlOutput.DisplayRectangle.X;
            int py = this.picOutput.Location.Y - this.pnlOutput.DisplayRectangle.Y;
            float fx = (this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Width - 1.0f;
            float fy = (this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)) / this.picOutput.Size.Height - 1.0f;
            xnew = (int)((float)mouse.X * (fx) + (float)this.pnlOutput.HorizontalScroll.Value);
            ynew = (int)((float)mouse.Y * (fy) + (float)this.pnlOutput.VerticalScroll.Value);
            this.pnlOutput.SuspendLayout();
            this.picOutput.Size = new Size((int)(this.worksheet.GetWorksheetWidth() * ((float)outputZoom / (float)100)), (int)(this.worksheet.GetWorksheetHeight() * ((float)outputZoom / (float)100)));
            this.picOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pnlOutput.ResumeLayout(false);
            this.picOutput.RePaint = true;
            this.pnlOutput.RePaint = true;
            this.pnlOutput.Invalidate();
            this.pnlOutput.AutoScrollPosition = new Point(xnew, ynew);
            this.stbpZoom.Text = "Zoom: " + outputZoom + "% ";									// refresh statusbar
        }

		public void ZoomToPage()																// fit GUI to screen
		{		
			float x,y, scale;
			x=((float)this.picOutput.Width / (float)(this.pnlOutput.Width-30));					// calculate max resize factor
			y=((float)this.picOutput.Height / (float)(this.pnlOutput.Height-30));
			scale = ((float)((Math.Max(x,y))));
            this.ZoomSmall((uint)((float)outputZoom / scale));									// set zoom
		}
		protected void ZoomToPageWidth()
		{
			float x;
			x=((float)this.picOutput.Width / (float)(this.pnlOutput.Width-30));					// calculate max resize factor
            this.ZoomSmall((uint)((float)outputZoom / x));
		}
		
		protected void ZoomToPageHeight()
		{
			float y;
			y=((float)this.picOutput.Height / (float)(this.pnlOutput.Height-30));
            this.ZoomSmall((uint)((float)outputZoom / y));	
		}
		protected virtual void ChangeFont()
		{
			if (this.dlgFont.ShowDialog()==DialogResult.OK)										// open font dialog
			{
				DrawNew();																		// redraw all
			}
		}
		protected virtual void DrawPreview(object sender, System.Windows.Forms.DrawItemEventArgs e)				// calculate row heights of image list
		{
			
			if(e.Index ==-1) return;															// something to do?		
			PreviewImage img;
			IEnumerator enumerator = previewImages.GetEnumerator();
			e.DrawBackground();
			for(uint i=0; i<previewImages.Count;i++){											// for all generetad preview images
				enumerator.MoveNext();
				if (i==e.Index){
					img = (PreviewImage) enumerator.Current;
					e.Graphics.DrawImage(img.previewImage,e.Bounds.X+4,e.Bounds.Y+2,img.previewImage.Width,img.previewImage.Height);	// add preview image to image list
				}
			}
		}
		protected virtual void DrawPreviewResize(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			e.ItemHeight = Math.Min(imageBitmap.Height /(imageBitmap.Width/90)+5,210);
		}
		protected virtual void RepertoryClick(object sender, System.EventArgs e)				// shows selected page
		{
			if (this.lstRepertory.SelectedIndex == -1) return;
			((RepertoryItem)(repertory[this.lstRepertory.SelectedIndex])).MakeText(this.rtbMscEditor);
			rtbMscEditor.Focus();
		}
		protected virtual void DrawRepertory(object sender, System.Windows.Forms.DrawItemEventArgs e)				// calculate row heights of image list
		{
			if(e.Index ==-1) return;															// something to do?
			RepertoryItem repertoryItem;
			IEnumerator enumerator = repertory.GetEnumerator();
			e.DrawBackground();
			for(uint i=0; i<repertory.Count;i++){											// for alExportToXmieneretad preview images
				enumerator.MoveNext();
				if (i==e.Index){
					repertoryItem = (RepertoryItem) enumerator.Current;
					e.Graphics.DrawImage(repertoryItem.repertoryImage,e.Bounds.X,e.Bounds.Y,repertoryItem.repertoryImage.Width, repertoryItem.repertoryImage.Height);	// add preview image to image list
				}
			}
		}
		protected virtual void DrawRepertoryResize(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			e.ItemHeight = imageBitmap.Height /(imageBitmap.Width/90)+5;
		}

		protected virtual void SelectedPageChanged(object sender, System.EventArgs e)				// shows selected page
		{
			//ClosePropertyWindow();
			RedrawImage();
		}
		protected virtual void FileChanged(object sender, System.IO.FileSystemEventArgs e)
		{
			if ((lastOpenedFile == e.FullPath)&&(sourceFileChanged==false)){
				this.sourceFileChanged = true;
			}
		}		
		protected virtual void InitDrawDestination()
		{
			drawDestination = this.picOutput.CreateGraphics();
			ipHDC = drawDestination.GetHdc();
			tmpWorksheet = new Worksheet();
			imageMetaFile.Dispose();
			imageMetaFile = new Metafile(ipHDC,new Rectangle(0,0,worksheet.GetWorksheetWidth(),worksheet.GetWorksheetHeight()),System.Drawing.Imaging.MetafileFrameUnit.Pixel);//System.Drawing.Imaging.EmfType.EmfPlusDual); 										// open created empty emf file
			drawDestination = Graphics.FromImage(imageMetaFile);
			tmpWorksheet.EnableFootLine = true;
			tmpWorksheet.Width = worksheet.GetWorksheetWidth();
			tmpWorksheet.Height = worksheet.GetWorksheetHeight();
			tmpWorksheet.SetMargins(0,0,0,0);
			tmpWorksheet.EnableFootLine = false;
			drawDestination.Clear(Color.White);
            drawDestination.SmoothingMode = imageSmoothingMode;		// set image quality
            drawDestination.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
		}
		protected virtual void PrintImage()
		{
			try{
				if(this.lstPreview.Items.Count==0) return;				// something to do?
				if(worksheet.Width> worksheet.Height)
					printDocument.DefaultPageSettings.Landscape = true;
				else
					printDocument.DefaultPageSettings.Landscape = false;
				dlgPrinter.Document = printDocument;					
				dlgPrinter.PrinterSettings.FromPage = 1;
				dlgPrinter.PrinterSettings.ToPage = 1;
				if (dlgPrinter.ShowDialog()==DialogResult.OK){			// show print dialog
					printPage = (uint)Math.Max(1,dlgPrinter.PrinterSettings.FromPage);
					if(dlgPrinter.PrinterSettings.PrintRange == PrintRange.AllPages){
						maxPage = 0;
					}
					else{
						maxPage = (uint)dlgPrinter.PrinterSettings.ToPage;
					}
					printDocument.Print();									// print page
				}
			}
			catch{}
		}
		private void UmnuSaveClick(object sender, System.EventArgs e)
		{
			this.SaveFile();
		}
		private void UmnuSaveAsClick(object sender, System.EventArgs e)
		{
			this.SaveAsFile();
		}
		private void UmnuPrintClick(object sender, System.EventArgs e)
		{
			
			this.PrintImage();
		}
		
		// L G
		private void UmnuXmiExportClick(object sender, System.EventArgs e)
		{
			this.ExportToXmi();
		}
		
		// L G
		private void UmnuXmiImportClick(object sender, System.EventArgs e)
		{
			this.ImportFromXmi();
		}
		
		private void UmnuPrinterClick(object sender, System.EventArgs e)
		{		
			Printer();
		}
		private void UmnuLoadClick(object sender, System.EventArgs e)
		{
			this.LoadFile();
		}
		private void UmnuDoClick(object sender, System.EventArgs e)
		{
			this.RtbTextDo();
		}
		private void UmnuUndoClick(object sender, System.EventArgs e)
		{
			this.RtbTextUndo();
		}
		protected virtual bool SaveFile()
		{
			if (lastOpenedFile==""){
				bool result = SaveAsFile();
				return result;
			}
			else{
				this.sourceFileWatch.EnableRaisingEvents = false;
				this.rtbMscEditor.SaveFile(lastOpenedFile,RichTextBoxStreamType.PlainText);
				this.tlbbSaveText.Enabled = false;
				this.umnuSave.Enabled = false;
				this.rtbMscEditor.Edited = false;
				this.sourceFileChanged = false;
				this.sourceFileWatch.EnableRaisingEvents = true;
				return true;
			}
		}
        //public void ClosePropertyWindow()
        //{
        //    this.pnlParameter.Controls.Clear();
        //    this.pnlParameter.Height = 0;
        //}		
		private void SetComment(object sender, System.EventArgs e)
		{
			int firstLine = this.rtbMscEditor.GetLineFromCharIndex(this.rtbMscEditor.SelectionStart);
			int lastLine = this.rtbMscEditor.GetLineFromCharIndex(this.rtbMscEditor.SelectionStart + this.rtbMscEditor.SelectionLength);
			if (this.rtbMscEditor.SelectedText.EndsWith("\n")) lastLine--;
			string[] temp = this.rtbMscEditor.Lines;
            int firstChar;
            if (this.rtbMscEditor.SelectionStart <= this.rtbMscEditor.Text.Length)
            {
            	firstChar = (this.rtbMscEditor.Text.Substring(1, Math.Max(this.rtbMscEditor.SelectionStart-1,0)).LastIndexOf('\n'));
                if (firstChar != -1) firstChar++;
                firstChar++;
            }
            else
                firstChar = 0;
			bool comment = true;
			for(int i=firstLine; i<=lastLine; i++){
				if (!temp[i].Trim().StartsWith("#")){
					comment = false;
					break;
				}
			}
			int rows = ((lastLine - firstLine)+1);
			if (comment){
				// wenn alle Zeilen Kommentar, Komentarzeichen entfernen
				this.rtbMscEditor.SelectionStart = firstChar;
				for (int i=1; i<rows; i++){
					this.rtbMscEditor.SelectionStart = this.rtbMscEditor.Text.IndexOf('#', this.rtbMscEditor.SelectionStart);
					this.rtbMscEditor.SelectionLength = 1;
					this.rtbMscEditor.SelectedText = "";
					this.rtbMscEditor.SelectionStart = this.rtbMscEditor.Text.IndexOf('\n',this.rtbMscEditor.SelectionStart)+1;					
				}
				this.rtbMscEditor.SelectionStart = this.rtbMscEditor.Text.IndexOf('#', this.rtbMscEditor.SelectionStart);
				this.rtbMscEditor.SelectionLength = 1;
				this.rtbMscEditor.SelectedText = "";
			}
			else{
				// wenn nicht alle Zeilen Kommentare, Kommentarzeichen einfügen
				this.rtbMscEditor.SelectionStart = firstChar;
				this.rtbMscEditor.SelectionLength = 0;
				for (int i=1; i<rows; i++){
					this.rtbMscEditor.SelectedText = "#";
					this.rtbMscEditor.SelectionStart = this.rtbMscEditor.Text.IndexOf('\n',this.rtbMscEditor.SelectionStart)+1;
				}
				this.rtbMscEditor.SelectedText = "#";
				this.rtbMscEditor.SelectionStart--;
			}
		}
		
		private void UmnuExportClick(object sender, System.EventArgs e)
		{
			this.ExportImage();
		}
		private void UmnuAboutClick(object sender, System.EventArgs e)
		{
			ShowInfoDialog();
		}
		
		void PnlParameterPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}
		private void RtbEditorMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			RtbEditorMouseDown();
			if(e.Button == System.Windows.Forms.MouseButtons.Right)
				this.contextMenu.Show(this.rtbMscEditor,new Point(e.X,e.Y));
		}
		protected virtual void RtbEditorMouseDown(){
			
		}
		private void CmnuSearchClick(object sender, System.EventArgs e)
		{
			UmnuSearchClick(sender, e);
		}
		private void CmnuSearchAgainClick(object sender, System.EventArgs e)
		{
			this.SearchAgain(sender, e);
		}
		private void CmnuReplaceClick(object sender, System.EventArgs e)
		{
			UmnuReplaceClick(sender, e);
		}
		private void CmnuCommentClick(object sender, System.EventArgs e)
		{
			this.SetComment(sender, e);
		}
		private void CmnuDoClick(object sender, System.EventArgs e)
		{
			this.UmnuDoClick(sender, e);
		}
		private void CmnuUndoClick(object sender, System.EventArgs e)
		{
			this.UmnuUndoClick(sender, e);
		}
        protected void SaveUndoText()
        {
            if (undoEditorText != this.rtbMscEditor.Text)
            {
                undoEditorText = this.rtbMscEditor.Text;
                EnableUnDoIcons(true);
                if (undoListChangedByUndoButton)
                    undoListChangedByUndoButton = false;
                else
                {
                    if (possibleUndos < undoListLength - 1)
                    {
                        possibleUndos++;
                    }
                    undoListPosition++;
                    if (undoListPosition >= undoListLength)
                    {
                        possibleUndos--;
                        undoListPosition = 0;
                    }
                    undoListRtf[undoListPosition] = this.rtbMscEditor.Rtf;
                    undoList[undoListPosition] = this.rtbMscEditor.Text;
                    this.EnableDoIcons(false);
                    possibleDos = 0;
                    this.rtbMscEditor.Edited = true;
                    undoListCursorPosition[undoListPosition] = this.rtbMscEditor.SelectionStart;
                }
            }
        }
		void RtbTextOnTextChanged(object sender, System.EventArgs e){
            if (saveUndo)
                SaveUndoText();
            this.tlbbSaveText.Enabled = true;
            this.umnuSave.Enabled = true;
       	}
		
		protected virtual void RtbTextUndo()
		{
			int textDelta = 0;
			this.rtbMscEditor.BeginUpdate();
			undoListChangedByUndoButton = true;
			undoListPosition--;
			if(undoListPosition < 0)
				undoListPosition = undoListLength-1;
			this.rtbMscEditor.Rtf = undoListRtf[undoListPosition];
			possibleUndos--;
			possibleDos++;
			if(possibleUndos<=0){
                this.EnableUnDoIcons(false);
          	}
            this.EnableDoIcons(true);
          	textDelta = undoList[undoListPosition].Length - undoList[undoListPosition+1].Length;
			if((undoListCursorPosition[undoListPosition+1] + textDelta) > 0)
				this.rtbMscEditor.Select(undoListCursorPosition[undoListPosition+1] + textDelta,0);
			this.rtbMscEditor.EndUpdate();
            if (this.tabWork.SelectedIndex == 0)
            {
                this.DrawNew();
            }
		}
		protected virtual void RtbTextDo()
		{
			this.rtbMscEditor.BeginUpdate();
			undoListChangedByUndoButton = true;
			if(possibleDos > 0){
				possibleDos--;
				possibleUndos++;
				undoListPosition++;
				if(undoListPosition > undoListLength-1)
					undoListPosition = 0;
				this.rtbMscEditor.Rtf = undoListRtf[undoListPosition];
				if(possibleDos<=0){
                    this.EnableDoIcons(false);
               	}
			}
			this.rtbMscEditor.Select(undoListCursorPosition[undoListPosition],0);
			this.rtbMscEditor.EndUpdate();
            if (this.tabWork.SelectedIndex == 0)
            {
                this.DrawNew();
            }
		}
		protected void RtbTextInitUndo(){
			undoEditorText = this.rtbMscEditor.Text;
			undoListPosition = 0;
			possibleDos = 0;
			possibleUndos = 0;
			undoList = new string[undoListLength];
			undoListRtf = new string[undoListLength];
			undoList[undoListPosition] = this.rtbMscEditor.Text;
			undoListRtf[undoListPosition] = this.rtbMscEditor.Rtf;
			undoListCursorPosition[undoListPosition] = this.rtbMscEditor.SelectionStart;
            this.EnableDoIcons(false);
            this.EnableUnDoIcons(false);
        }
        void RtbMscEditor_LineChanged(object sender, NumberingEditor.LineChangedEventArgs e)
        {
            SetLineNumber(e.Line);
        }
		
   		public void SetLineNumber(int line)
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
			this.stbpLine.Text = resources.GetString("stbpLine.Text") + line.ToString();
		}
		
		public virtual void LogClick(){
		}
		
		public virtual void LogDoubleClick(){
		}
		
		public virtual void LogSelectedIndexChanged(){
		}
		
		protected virtual void DialogOptionsAccept(object sender, EventArgs e)
		{
			this.RedrawRescaled();
		}
	
		void ContextMenuPopup(object sender, System.EventArgs e)
		{
			
		}
			
		protected override void OnActivated(System.EventArgs e)
		{
			//base.OnGotFocus(e);
			if ((sourceFileChanged == true)&&(sourceFileWatchEnabled == true)){
				sourceFileChanged = false;
				if (MessageBox.Show(strings.GetString("FileOutsideGeneratorChanged"), "Generator", MessageBoxButtons.YesNo) == DialogResult.Yes){
					LoadFile(this.lastOpenedFile,true);
				}
			}
		}
		
		protected virtual void Printer(){
			try{
				dlgPrinter.Document = printDocument;
				dlgPrinter.PrinterSettings.FromPage = 1;
				dlgPrinter.PrinterSettings.ToPage = 1;
				dlgPrinter.AllowSelection = false;
				dlgPrinter.AllowSomePages = false;
				dlgPrinter.ShowDialog();
				dlgPrinter.AllowSelection = true;
				dlgPrinter.AllowSomePages = true;
			}
			catch{}
		}
		
		void UmnuNewClick(object sender, System.EventArgs e)
		{
			this.NewImage();
		}
				
		protected virtual void UmnuLayoutClick(object sender, System.EventArgs e)
		{
            //WorkSheetOptions sheetOptions = new WorkSheetOptions(worksheet, this);
            //sheetOptions.ShowDialog();
            this.OpenOptionsDialog();
		}
		
		void UmnuExitClick(object sender, System.EventArgs e)
		{
			this.Exit();
		}
		
		void UmnuSearchClick(object sender, System.EventArgs e)
		{
            if (searchDialog is Search)
            {
                return;
            } 
            if (searchDialog != null)
            {
                ((Replace)searchDialog).Close();
            }
            searchDialog = new Search();
            if (this.rtbMscEditor.SelectionLength == 0)
            {
                ((Search)searchDialog).SearchText = searchText;
            }
            else
            {
                ((Search)searchDialog).SearchText = this.rtbMscEditor.SelectedText.Split(new char[7] { '\n', ' ', '\t', '.', ',', ';', ':' })[0];
            }
            ((Search)searchDialog).OnSearchClick += new System.EventHandler(this.Search);
            ((Search)searchDialog).OnCancelClick += new System.EventHandler(this.CloseSearch);
            ((Search)searchDialog).OnClose += new System.EventHandler(this.CloseingSearch);
            ((Search)searchDialog).Visible = true;
		}
		
		void UmnuSearchAgainClick(object sender, System.EventArgs e)
		{
			this.SearchAgain(sender, e);
		}
		
		void UmnuReplaceClick(object sender, System.EventArgs e)
		{
            if (searchDialog is Replace) return;
            if (searchDialog != null)
            {
                ((Search)searchDialog).Close();
            }
            searchDialog = new Replace();
            if (this.rtbMscEditor.SelectionLength == 0)
            {
                ((Replace)searchDialog).SearchText = searchText;
            }
            else
            {
                ((Replace)searchDialog).SearchText = this.rtbMscEditor.SelectedText.Split(new char[7] { '\n', ' ', '\t', '.', ',', ';', ':' })[0];
            }
            ((Replace)searchDialog).ReplaceText = replaceText;
            ((Replace)searchDialog).OnSearchClick += new System.EventHandler(this.SearchReplace);
            ((Replace)searchDialog).OnCancelClick += new System.EventHandler(this.CloseReplace);
            ((Replace)searchDialog).OnClose += new System.EventHandler(this.CloseingReplace);
            ((Replace)searchDialog).OnReplaceClick += new System.EventHandler(this.Replace);
            ((Replace)searchDialog).OnReplaceAllClick += new System.EventHandler(this.ReplaceAll);
            ((Replace)searchDialog).Visible = true;
		}
		
		void UmnuCommentClick(object sender, System.EventArgs e)
		{
			this.SetComment(sender, e);
		}
		
		void UmnuZoomFitWideClick(object sender, System.EventArgs e)
		{
            this.ZoomToPageWidth();
            this.CenterPage();
		}
		
		void UmnuZoomFitHeightClick(object sender, System.EventArgs e)
		{
           	this.ZoomToPageHeight();
            this.CenterPage();
		}
		
		void UmnuZoom600Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(600);
		}
		
		void UmnuZoom400Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(300);
		}
		
		void UmnuZoom200Click(object sender, System.EventArgs e)
		{
			this.ZoomSmall(200);
		}
		
		void UmnuZoom150Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(150);
		}
		
		void UmnuZoom100Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(100);
		}
		
		void UmnuZoom66Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(66);
		}
		
		void UmnuZoom50Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(50);
		}
		
		void UmnuZoom33Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(33);
		}
		
		void UmnuZoom25Click(object sender, System.EventArgs e)
		{
            this.ZoomSmall(25);
		}

        void UmnuZoom10Click(object sender, EventArgs e)
        {
            this.ZoomSmall(10);
        }
		void LtbMenuButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(Convert.ToUInt16(e.Button.Tag)){
				case 0:
					this.LoadFile();
					break;
				case 1:
					this.ExportImage();
					break;
				case 2:
					this.OpenOptionsDialog();
					break;	
				case 3:
					this.ChangeFont();
					break;
				case 4:
                    ZoomInSmall();
					break;
				case 5:
					ZoomOutSmall();
					break;
				case 6:
					this.ZoomToPage();
                    this.CenterPage();
					break;
				case 7:
					this.PrintImage();
                    break;
				case 8:
					this.PreviewPage();
					break;					
				case 9:
					if (lastOpenedFile != ""){
						this.LoadFile(lastOpenedFile,true);
					}
					break;
				case 10:
					this.SaveFile();
					break;
				case 11:
					this.NewImage();
					break;
				case 12:
					this.RtbTextUndo();
					break;
				case 13:
					this.RtbTextDo();
					break;
                case 14:
                    this.SetComment(sender,new EventArgs());
                    break;
                case 15:
                    this.UmnuSearchClick(sender, new EventArgs());
                    break;
                case 16:
                    this.ZoomToPageWidth();
                    this.CenterPage();
                    break;
                case 17:
                    this.ZoomToPageHeight();
                    this.CenterPage();
                    break;
                case 18:
                    this.RtbCut();
                    break;
                case 19:
                    this.RtbCopy();
                    break;
                case 20:
                    this.RtbPaste();
                    break;
                case 21:
                    this.Zoom100(sender, e);
                    break;
				}
		}

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PreviewPage();
        }

		protected override void OnShown(EventArgs e)
		{
			//base.OnShown(e);
		}
        protected override void OnGotFocus(EventArgs e)
		{
			//base.OnGotFocus(e);
		}
		
		private void ImageWheel(object sender, MouseEventArgs e)
		{
            if (keyControlDown)
            {
                if (e.Delta > 0)
                {
                    this.ZoomInSmall(e.Location);
                }
                else
                {
                    this.ZoomOutSmall(e.Location);
                }
            }
		}
  		private void OnMouseEnter(object sender, EventArgs e)
		{
			if ( this.picOutput.Focused == false )
			{
				if (this.ContainsFocus == true){
					this.pnlOutput.SuspendLayout();
					this.pnlOutput.RePaint = false;
					this.picOutput.RePaint = false;
					this.picOutput.Focus();
					this.pnlOutput.ResumeLayout(false);
					this.pnlOutput.RePaint = true;
					this.picOutput.RePaint = true;
				}
			}
		}

        void PicOutput_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        	if (mouseMoveIsAtWork) return;
            mouseMoveIsAtWork = true;
            if (mouseMoveAllow)
            {	
            	if(Math.Abs(oldPicOutputLocation.X - picOutput.Location.X)>0 || Math.Abs(oldPicOutputLocation.Y -picOutput.Location.Y)>0)
            	{
					outputMoved = true;
					this.Cursor = System.Windows.Forms.Cursors.SizeAll;
				}
		        this.pnlOutput.RePaint = false;
				this.picOutput.RePaint = false;
				float xnew = Math.Min(Math.Max(pnlOutput.HorizontalScroll.Value - (e.X - mouseMovePositionX) / 5, 0),this.pnlOutput.HorizontalScroll.Maximum );
				float ynew = Math.Min(Math.Max(pnlOutput.VerticalScroll.Value - (e.Y - mouseMovePositionY) / 5, 0),this.pnlOutput.VerticalScroll.Maximum );
				this.pnlOutput.SuspendLayout();
				this.pnlOutput.ResumeLayout(false);
				this.picOutput.RePaint = true;
				this.pnlOutput.RePaint = true;
				this.pnlOutput.Invalidate();
				this.pnlOutput.AutoScrollPosition = new Point((int)xnew, (int)ynew);
				this.pnlOutput.Refresh();
			}
            mouseMoveIsAtWork = false;
        }
        void PicOutput_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            mouseMoveAllow = false;
        }
        void PicOutput_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            oldPicOutputLocation = picOutput.Location;
			mouseMovePositionX = e.X;
            mouseMovePositionY = e.Y;
//            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            mouseMoveAllow = true;
        }

        void PicOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control)
            {
                keyControlDown = true;
                pnlOutput.MouseWheelAllow = false;
                //TODO: ZoomCurser aktivieren
            }
        }

        void PicOutput_KeyUp(object sender, KeyEventArgs e)
        {
            keyControlDown = false;
            pnlOutput.MouseWheelAllow = true;
            //TODO: ZoomCurser deaktivieren
        }
        
        public void CenterPage()
        {
            this.pnlOutput.AutoScrollPosition = new Point((int)(pnlOutput.HorizontalScroll.Maximum - pnlOutput.HorizontalScroll.LargeChange) / 2, (int)(pnlOutput.VerticalScroll.Maximum - pnlOutput.VerticalScroll.LargeChange) / 2);
        }
        
        protected virtual void GUI_GotFocus(object sender, EventArgs e)
        {
        	if(System.Windows.Forms.Clipboard.GetText()!="")
        	{
        		this.umnuPaste.Enabled = true;
        		this.cmnuPaste.Enabled = true;
        		this.tlbbPaste.Enabled = true;
        	}
        	else
        	{
        		this.umnuPaste.Enabled = false;
        		this.cmnuPaste.Enabled = false;
        		this.tlbbPaste.Enabled = false;
        	}
        }
        void PnlOutput_DoubleClick(object sender, EventArgs e)
        {
            this.ZoomToPage();
            this.CenterPage();
        }
        private void UmnuCut_Click(object sender, EventArgs e)
        {
            RtbCut();
        }

        private void UmnuCopy_Click(object sender, EventArgs e)
        {
            RtbCopy();
        }
        
        private void UmnuPaste_Click(object sender, EventArgs e)
        {
            RtbPaste();
        }

        private void CmnuCut_Click(object sender, EventArgs e)
        {
            RtbCut();
        }

        private void CmnuCopy_Click(object sender, EventArgs e)
        {
            RtbCopy();
        }

        private void CmnuPaste_Click(object sender, EventArgs e)
        {
            RtbPaste();
        }

        private void EnableDoIcons(bool enable)
        {
            this.ltbMenu.Buttons[12].Enabled = enable;
            this.umnuDo.Enabled = enable;
            this.cmnuDo.Enabled = enable;
        }
        private void EnableUnDoIcons(bool enable)
        {
            this.ltbMenu.Buttons[11].Enabled = enable;
            this.umnuUndo.Enabled = enable;
            this.cmnuUndo.Enabled = enable;
        }
        private void RtbCut()
        {
            this.rtbMscEditor.Cut();
            this.umnuPaste.Enabled = true;
            this.cmnuPaste.Enabled = true;
            this.tlbbPaste.Enabled = true;
        }
        private void RtbCopy()
        {
            this.rtbMscEditor.Copy();
            this.umnuPaste.Enabled = true;
            this.cmnuPaste.Enabled = true;
            this.tlbbPaste.Enabled = true;
        }
        protected virtual void RtbPaste()
        {
        	if(System.Windows.Forms.Clipboard.GetText()!="")
            	this.rtbMscEditor.Paste();
        }
		
		void UmnuDeleteClick(object sender, System.EventArgs e)
		{
			this.rtbMscEditor.SelectedText = "";
		}
		
		void UmnuSelectAllClick(object sender, System.EventArgs e)
		{
			this.rtbMscEditor.SelectAll();
		}
		
		void CmnuDeleteClick(object sender, System.EventArgs e)
		{
			this.rtbMscEditor.SelectedText = "";
		}
		
		void CmnuSelectAllClick(object sender, System.EventArgs e)
		{
			this.rtbMscEditor.SelectAll();
		}
		
		protected void SetStatusBarSize (int width, int height)
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
			this.stbpSize.Text = resources.GetString("stbpSize.Text") + width.ToString() + " x " + height.ToString();
		}
		
		protected void SetStatusBarPages (int current, int all)
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
			this.stbPage.Text = resources.GetString("stbPage.Text") + current.ToString() + "/" + all.ToString();
		}
		
		protected void SetDiagramIsEmpty (bool isEmpty)
		{
			if (isRegistered){
				this.tlbbSave.Enabled = isEmpty;
				this.umnuExport.Enabled = isEmpty;	
			}
		}
		
		protected void SetIsRegistered (bool isRegistered)
		{
			this.isRegistered = isRegistered;
			this.tlbbPrint.Enabled = isRegistered;
			this.tlbbSave.Enabled = isRegistered;
			this.tlbbPreview.Enabled = isRegistered;
			
		}
		protected void SetStbPageText(string text)
		{
			this.stbPage.Text = text;
		}
		
		protected void SetTlbbFontVisible(bool visible)
		{
			this.tlbbFont.Visible = visible;
		}
		
		protected void InitGUI()
		{
			this.InitializeComponent();
		}
		
		//LG the method that calls the implementation for the XmiExport   
		protected virtual void ExportToXmi(){}
		
		//LG the method that calls the implementation for the XmiImport   
		protected virtual void ImportFromXmi(){}

		public virtual void ToolCursor(bool state){
			this.pnlOutput.Cursor = Cursors.Arrow;
			//MessageBox.Show("Works!" + state);
		}
		public virtual void ToolZoom(bool state){
			//MessageBox.Show("Works fine!" + state);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
			Bitmap img = ((System.Drawing.Bitmap)(resources.GetObject("magnifier")));
			Cursor c = new Cursor (img.GetHicon());
			this.pnlOutput.Cursor = c;
		}

   	}	
}





