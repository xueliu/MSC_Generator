/*

Copyright (C) 2005-2007 by Itesys Institut fuer Technische Systeme GmbH
http://www.itesys-gmbh.de   
mailto:software@itesys.de

This file is part of sdgen. Project home:
http://www.itesys-gmbh.de/home/produkte/msc_generator.html

sdgen is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

sdgen is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with sdgen; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

*/
/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using GeneratorGUI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using mscElements;
using CommandLine.Utility;

namespace nGenerator
{
	
	public partial class Output
	{
		public static string	stringResources = "sdgen.strings";
		private Worksheet worksheet = new Worksheet();
		private bool verbose; // Should progress status be displayed?
		private string format;
		private bool unknownFormat;
		private string files;
		private bool noFiles;
		private string srcDirectory;
		private string destDirectory;
		private bool singlePage;
		
		public static void Main(string[] args)
		{
			new Output(args);
		}
		
		private Arguments ParseArguments (string[] args)
		{
			// Initialize arguments object:
			Arguments arguments = new Arguments();
			arguments.addOption ("version", null, 0);
			arguments.addOption ("verbose", "v", 0);
			arguments.addOption ("help", null, 0);
			arguments.addOption ("format", "f", 1);
			arguments.addOption ("output-dir", "o", 1);
			arguments.addOption ("paged", "p", 0);
			arguments.addOption ("resolution", "r", 1);
			arguments.parse (args);
			//arguments.dump();
			return arguments;
		}
		
		private void ReadOptions (Arguments arguments)
		{
			// Read verbose mode:
			verbose = arguments ["verbose"] != null;
			
			// Get the selected format from the arguments list and
			// verify a correct format has been specified:
			format = "png";
			unknownFormat = false;
			StringCollection supportedFormats = new StringCollection();
			supportedFormats.AddRange (new String[] {"bmp", "emf", "gif", "jpg", "png", "wmf"});
			if (arguments ["format"] != null) {
				format = arguments ["format"];
				unknownFormat = !supportedFormats.Contains (format.ToLower());
			}
			
			// Read input and output directories (we want uniform dir separators):
			srcDirectory = Environment.CurrentDirectory.Replace('\\', '/');
			destDirectory = ".";
			if (arguments ["output-dir"] != null)
				destDirectory = arguments ["output-dir"].Replace('\\', '/');

			// Verify some files were selected for input:
			files = arguments ["-args"];
			noFiles = files.Length == 0;
			
			// Verify if paged mode was selected:
			singlePage = true;
			if (arguments ["paged"] != null)
				singlePage = false;
			
			int dpi = 96;
			if (arguments ["resolution"] != null)
				if (!System.Int32.TryParse (arguments ["resolution"], out dpi))
					dpi = 0;
			worksheet.Dpi = dpi;
			if (worksheet.Dpi > 600)
				worksheet.Dpi = 0;
		}
		
		private void RunGenerator()
		{
			try {
				generator = new Generator();

				DirectoryInfo srcDi = new DirectoryInfo(srcDirectory + "/" + Path.GetDirectoryName(files));
				DirectoryInfo destDi = new DirectoryInfo(destDirectory);
				FileInfo[] result = srcDi.GetFiles(Path.GetFileName(files));
				if (!destDi.Exists){
					if (verbose)
						Console.WriteLine ("Creating output directory " + destDirectory);
					Directory.CreateDirectory(@destDirectory);
				}
				if (result.Length > 0) {
					for (int i=0; i<result.Length; i++){
						if (verbose)
							Console.WriteLine ("Processing " + result[i].Name);
						generator.Clear();
						Output.AutosizeOutputHeight = true;
						// Load and parse input file:
						nGenerator.InterpretException[] exceptions;
						exceptions = this.LoadFile(result[i].FullName);
						if (exceptions != null)
							foreach (nGenerator.InterpretException exception in exceptions)
								Console.WriteLine (result[i].Name + ":" + exception.exceptionLine + " error: " + exception.Message);
						// Generate output:
						this.ExportImage(destDirectory + "/"  + result[i].Name, format);
					}
				} else {
					Console.WriteLine ("ERROR: Couldn't open the input file(s)!");
				}
			} catch (Exception e) {
				Console.WriteLine ("ERROR: " + e.Message);
				Console.WriteLine (e.ToString());
			}
		}
		
		public Output(string[] args)
		{
			Arguments arguments = ParseArguments (args);
			
			ReadOptions (arguments);
			// Either display version or help or generate the files
			if (arguments ["version"] != null) {
				PrintVersion();
			} else if (args.Length == 0 || arguments ["help"] != null) {
				PrintHelp();
			} else if (noFiles) {
				Console.WriteLine ("ERROR: No file(s) specified");
				Console.WriteLine ("");
			} else if (unknownFormat) {
				Console.WriteLine ("ERROR: Invalid format specified!");
				Console.WriteLine ("");
			} else if (destDirectory.Trim() == "") {
				Console.WriteLine ("ERROR: Empty output directory specified!");
			} else if (worksheet.Dpi == 0) {
				Console.WriteLine ("ERROR: Invalid dpi specified!");
			} else {
				RunGenerator();
			}
		}
		private nGenerator.InterpretException[] LoadFile(string filename)
		{
			string name = "";
			int pos = filename.LastIndexOf('/');
			if (pos != -1) {
				name = filename.Substring (pos+1);
				if (name.LastIndexOf (".sc") == name.Length - 3)
					name = name.Substring (0, name.Length - 3);
			}
			if (name == "")
				name = "Diagram"; // have a default name TODO:localize
			generator.Clear();
			generator.AddHead(name);
			Interpreter interpreter = new Interpreter();	
			return interpreter.InterpretFile(filename, generator, this);
		}
		private void ExportImage(string filename, string format)
		{
			uint pages;
			Image exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);		// create export draw area
			Bitmap b= new Bitmap(100,100);
			Graphics drawDestination = Graphics.FromImage(exportImage);
			Graphics grph;
			IntPtr ipHDC;																	//necessary for wmf and emf export
			Metafile mf;
			generator.CalcLineHights(drawDestination, worksheet, MSCItem.ItemFont);
			pages = generator.GetPages(worksheet.GetWorksheetHeight());		// calculate imageBitmap page count
			if (pages > 0)																	// something to do?
			{
				if (filename.LastIndexOf('.') >= (filename.Length-4)){
					filename = filename.Substring(0,filename.LastIndexOf('.'));
				}
				uint i = 1;
				string filenameSuffix = "";
//				if (singlePage)
//					i = pages = 0;
				for (; i<=pages; i++){
					if (i > 0)
						filenameSuffix = "_" + i.ToString();
					
					if (Output.AutosizeOutputHeight){
						uint index = i;
						if (index > 0)
							index--;
						worksheet.SetWorksheetHeight((int)generator.PageHeights[index]); // correct height for export
						exportImage = new Bitmap(this.worksheet.Width, this.worksheet.Height);
						drawDestination = Graphics.FromImage(exportImage);
					}
					if (Output.AutosizeOutputWidth){
						worksheet.SetWorksheetWidth((int)generator.AutoWidth);
					}
					switch (format.ToUpper()){				// identify selected format
						case "BMP":
							drawDestination.Clear(Color.White);						
				   			generator.CalcOffsets(drawDestination, worksheet);
				   			generator.DrawPage(drawDestination,worksheet, i);
							exportImage.Save(filename + filenameSuffix + ".bmp");
							break;
						case "GIF":
							drawDestination.Clear(Color.White);						
				   			generator.CalcOffsets(drawDestination, worksheet);
				   			generator.DrawPage(drawDestination,worksheet, i);
							exportImage.Save(filename + filenameSuffix + ".gif",System.Drawing.Imaging.ImageFormat.Gif);
							break;
						case "JPG":
							drawDestination.Clear(Color.White);						
				   			generator.CalcOffsets(drawDestination, worksheet);
				   			generator.DrawPage(drawDestination,worksheet, i);
							exportImage.Save(filename + filenameSuffix + ".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
							break;
						case "PNG":
							drawDestination.Clear(Color.White);						
				   			generator.CalcOffsets(drawDestination, worksheet);
				   			generator.DrawPage(drawDestination,worksheet, i);
							exportImage.Save(filename + filenameSuffix + ".png",System.Drawing.Imaging.ImageFormat.Png);
							break;
						case "WMF":
							drawDestination.Clear(Color.White);						
							exportImage.Save(filename + filenameSuffix + ".wmf",System.Drawing.Imaging.ImageFormat.Wmf);		// for save as wmf first empty wmf file shall be created
							grph = Graphics.FromImage(b);
							ipHDC = grph.GetHdc(); 
							mf = new Metafile(filename + filenameSuffix + ".wmf", ipHDC); 										// open created empty wmf file
							grph = Graphics.FromImage(mf); 
							grph.Clear(Color.White);
							grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
							grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
				   			generator.CalcOffsets(grph, worksheet);
				   			generator.DrawPage(grph,worksheet, i);
							grph.Dispose();
							mf.Dispose();
							break;
						case "EMF":
							System.IO.FileStream st= new FileStream(filename + "_" + i + ".emf",FileMode.Create);
							drawDestination.Clear(Color.White);						
							grph = Graphics.FromImage(b);
							ipHDC = grph.GetHdc(); 
							mf = new Metafile(st,ipHDC);
							grph = Graphics.FromImage(mf); 
							grph.Clear(Color.White);
							grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;					// set image quality
							grph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
				   			generator.CalcOffsets(grph, worksheet);
				   			generator.DrawPage(grph,worksheet, i);
							grph.Dispose();
							mf.Dispose();
							break;
					}
					if (verbose) {
						if (singlePage)
							Console.WriteLine("Diagram created.");
						else
							Console.WriteLine("Page " + i.ToString()+ " created.");
					}
				}
			}
			drawDestination.Dispose();
			b.Dispose();
			exportImage.Dispose();
		}
		public void SetMscStyle(MscStyle newStyle)
		{
			generator.SetMscStyle(newStyle);
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
							worksheet.Width=(int)worksheet.CalcSize(Worksheet.WS_SIZE_A5_Y,Worksheet.WS_UNIT_CM);
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
		private void PrintVersion() {
			Console.WriteLine ("MSC Generator 1.1");
			Console.WriteLine ("Copyright (C) 2005-2007 Itesys (http://www.itesys.de)");
			Console.WriteLine ("");
			Console.WriteLine ("This program comes with NO WARRANTY, to the extent permitted by law.");
			Console.WriteLine ("You may redistribute copies of this program under the terms of the ");
			Console.WriteLine ("GNU General Public License Version 2.");
		}
		private void PrintHelp() {
			Console.WriteLine ("Usage: sdgen [options] files");
			Console.WriteLine ("Exmaples: sdgen diagram.sc");
			Console.WriteLine ("          sdgen -f wmf diagram1.cs diagram2.cs");
			Console.WriteLine ("          sdgen -f wmf -o images *.cs");
			Console.WriteLine ("");
			Console.WriteLine ("Options:");
			Console.WriteLine ("  -f FMT --format=FMT  Selects the format of the generated images.");
			Console.WriteLine ("                       FMT can be bmp, emf, gif, jpg, png, wmf (default is png).");
			Console.WriteLine ("  -o DIR --output-dir=DIR  Directory to write generated files (default is .)");
			Console.WriteLine ("  -p --paged  Override the default of drawing each diagram on a single page.");
			Console.WriteLine ("  -r DPI --resolution DPI  Resolution of generated diagram image (default 96).");
			Console.WriteLine ("  -v --verbose  Outputs extra infomation about the progress.");
			Console.WriteLine ("");
			Console.WriteLine ("  --version  Outputs version info.");
			Console.WriteLine ("  --help  Outputs this help.");
		}
	}
}
