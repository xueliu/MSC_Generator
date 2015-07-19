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
 * Time: 19:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
//#define TRACE
//#define HelpDraw
using System;
using System.Collections;
using System.Drawing;
using mscElements;
using GeneratorGUI;
using System.Diagnostics;

namespace nGenerator
{
	/// <summary>
	/// Description of Generator.
	/// </summary>
	public struct InLineSize{
		public float Left;
		public float Right;
	}
	public struct DiagramLine{
		public int Page;
		public float Height;
	}
	partial class Generator
	{
		private enum GeneratorResult{
			OK,
			InstanceSpaceToSmall
		}

		private HeadLine headLine = new HeadLine("MSC");

		public const float LOOP_OFFSET				=10.0F;					// defines the horizontal offset for drawing the timer and measurement lines
		public const string ENV_RIGHT_STRING		="ENV_RIGHT";			// string constant for the right environment side
		public const string ENV_LEFT_STRING			="ENV_LEFT";			// string constant for the left environment side
		public const int ENV_RIGHT					=-10;					// process number of the right environment (for internal use only, have to be <0)
		public const int ENV_LEFT					=-11;					// process number of the left environment (for internal use only, have to be <0)
		public const float INLINE_OFFSET			=5;						// defines the horizontal offset for nesting of inlines
		
		public const float BOTTOM_MARGIN_MSC = 10f, TOP_MARGIN_MSC = 10f;
		public const float GEM_MIN_INSTANCE_SPACE	= 100;
		
		private uint maxLeftMargin = 200;
		private uint maxRightMargin = 200;
		private DiagramLine[] mDiagramLines = new DiagramLine[2];		//array of all lineheights in the msc (arrayindex=1 for the first line)
		private GeneratorResult generatorResult = GeneratorResult.OK;

		private ArrayList pageHeights;								// stores the heights of each page of the diagram. Necessery for auto height option
		private ArrayList processes;								// list of all process-IDs used in the msc
		private ArrayList items;									// list of all msc-items used in the msc
		private ArrayList lines;									// list of all lines such as timer line or measurement line, except inlines, used in the msc
		private ArrayList inLines;									// list of all inlines used in the msc
		
		private float 	mYInstanceOffset, 				// vertical offset for the first line of msc
						mYProcessName,					// vertical offset for the process names
						mProcessNameHeight,				// maximum height of the process names used in the msc
						mInstanceNameHeight, 			// maximum height of the instance names (process + actor) used in the msc
						mHeadHeight,					// height of the head line
						mAutoWidth				= 0;
		private uint 	mLines; 						// msc lines count
		private uint 	mDiagramPages 			= 0;
		private bool 	mEmptyDiagram			= true;
		
		/// <summary>
		/// clears all stored data of the diagram
		/// </summary>
		public void Clear()
		{
			Output.AutosizeOutputHeight = false;
			MSCItem.Clear();
			processes.Clear();
			items.Clear();
			lines.Clear();
			inLines.Clear();
			pageHeights.Clear();
			mYInstanceOffset = 110;
			mYProcessName = 0;
			mHeadHeight = 0;
			mProcessNameHeight = 0;
			mInstanceNameHeight = 0;
			mLines=0;
			Worksheet.Author = "";
			Worksheet.Company = "";
			Worksheet.Date = "";
			Worksheet.Version = "";
			Worksheet.DrawAuthor = true;
			Worksheet.DrawCompany = true;
			Worksheet.DrawFileName = true;
			Worksheet.DrawFootLine = false;
			Worksheet.DrawPrintDate = true;
			Worksheet.DrawVersion = true;
			this.SetMscStyle(MscStyle.SDL);
			this.SetMSCLeft(0);
			this.SetMSCRight(0);
			mAutoWidth = 600;
			System.GC.Collect();
			DiagramPages = 1;
			mEmptyDiagram = true;
		}
		public bool EmptyDiagram{
			get{
				return mEmptyDiagram;
			}
			set{
				mEmptyDiagram=value;
			}
		}
		public float HeadHeight{
			get{
				return mHeadHeight;
			}
			set{
				mHeadHeight=value;
			}
		}
		public float AutoWidth{
			get{
				return Math.Max(mAutoWidth,100.0f);
			}
		}
		public uint DiagramPages{
			get{
				return mDiagramPages;
			}
			set{
				mDiagramPages=value;
			}
		}
		public int ProcessesCount{
			get{
				return processes.Count;
			}
		}			
		public float[] PageHeights{
			get{
				return (float[]) pageHeights.ToArray(typeof(float));
			}
		}
		public uint YItemOffset{
			get{
				return MSC.VerticalOffset;
			}
			set{
				MSC.VerticalOffset=value;
			}
		}
		public float YProcessOffset{
			get{
				return mYInstanceOffset;
			}
			set{
				mYInstanceOffset=value;
			}
		}		
		public InterpretResult SetMscStyle(MscStyle style)
		{
			MSCItem.Style = style;
			return InterpretResult.Ok;
		}
		
		///<summary>
		/// Draws the given page 
		/// </summary>
		/// <param name="drawDestination">Graphics object of the draw destination</param>
		/// <param name="worksheet">worksheet of the drawing area</param>
		/// <param name="page">page to be drawed</param>
			

		public void DrawPage(Graphics drawDestination, GeneratorGUI.Worksheet worksheet, uint page)
		{
			float	mscHeight, 			// needed to calculate first and last msc line shall be drawed on current page
					lineBeginn;			// stores the vertical start position of msc line shall be drawed
			uint 	pageBeginnLine=1, 	// first msc line of the attended page
					pageEndLine=1;		// last msc line of the attended page
			float 	xSize, 				// horizontal size of the drawig area
					ySize;				// verical size of the drawig area
			
//			xSize = worksheet.Width - worksheet.LeftMargin - worksheet.RightMargin;
//			
//  			ySize = worksheet.Height-worksheet.BottomMargin - BOTTOM_MARGIN_MSC;
  			xSize = worksheet.GetWorksheetWidth();
  			ySize = worksheet.GetWorksheetHeight() - BOTTOM_MARGIN_MSC + worksheet.TopMargin;
  			if (generatorResult != GeneratorResult.OK){
  				DrawError(drawDestination, generatorResult);
  				return;
  			}
			if (processes.Count>0){		// is something to draw ?
  				if (page==0){
	  				pageBeginnLine = 1;
	  				pageEndLine = (uint)mDiagramLines.Length-2;
  				}
  				else{
					for (uint i=1; i<mDiagramLines.Length-1; i++){
						if (mDiagramLines[i].Page < page) 
							pageBeginnLine++; // calculate the first msc line of page
						if (mDiagramLines[i].Page==page)
							pageEndLine=i; // calculate the last msc line of page		
					}
  				}
				#region HelpDraw
				#if HelpDraw
									float x,xmax, y, ymax;
									StringFormat sf = new StringFormat();
									sf.Alignment = StringAlignment.Near;
									sf.LineAlignment = StringAlignment.Center;
									ymax = worksheet.GetWorksheetHeight();
									xmax = worksheet.GetWorksheetWidth();
									for (int i=0; i<processes.Count;i++){
										x = GetInstanceXPos(i) - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET * 2 - ((Process)processes[i]).LeftRand;
										drawDestination.DrawLine(Pens.LightBlue,x,0,x,ymax);
										x = GetInstanceXPos(i) + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET * 2 + ((Process)processes[i]).RightRand;
										drawDestination.DrawLine(Pens.LightBlue,x,0,x,ymax);
										
										x = GetInstanceXPos(i) - MSCItem.ItemLayoutSize.Width/2 - Generator.LOOP_OFFSET;
										drawDestination.DrawLine(Pens.LightGreen,x,0,x,ymax);
										x = GetInstanceXPos(i) + MSCItem.ItemLayoutSize.Width/2 + Generator.LOOP_OFFSET;
										drawDestination.DrawLine(Pens.LightGreen,x,0,x,ymax);
										
										x = GetInstanceXPos(i) - MSCItem.ItemLayoutSize.Width/2;
										drawDestination.DrawLine(Pens.OrangeRed,x,0,x,ymax);
										x = GetInstanceXPos(i) + MSCItem.ItemLayoutSize.Width/2;
										drawDestination.DrawLine(Pens.OrangeRed,x,0,x,ymax);
									}
									y = this.YProcessOffset;
									for (uint i=pageBeginnLine; i<=pageEndLine; i++){		// for all msc lines inside the attended page msc items shall be drawed
										if (mDiagramLines[i].Height != MSCItem.NEW_PAGE){
											drawDestination.DrawLine(Pens.LightBlue,0,y,xmax,y);
											y += (mDiagramLines[i].Height);		// calculate the vertical start position for next msc items
											drawDestination.DrawLine(Pens.LightSalmon,0,y+2,xmax,y+2);
											y += (this.YItemOffset);		// calculate the vertical start position for next msc items
											}
									}
				#endif
				#endregion
				DrawHeadLine(drawDestination,worksheet.LeftMargin,worksheet.TopMargin,xSize,page);	// draw the msc head line 
				// calculate all necessary values of the page shall be drawed
				mscHeight=this.YProcessOffset;
				lineBeginn=this.YProcessOffset;
				DrawLines(drawDestination,pageBeginnLine,pageEndLine, headLine.GetHeight(drawDestination, xSize), ySize, worksheet,page); // first all lines (timerline, measureline.) shall be drawed
				DrawInLines(drawDestination,pageBeginnLine,pageEndLine, headLine.GetHeight(drawDestination, xSize), ySize, worksheet.TopMargin);  // next all inlines shall be drawed
				for (uint i=pageBeginnLine; i<=pageEndLine; i++){		// for all msc lines inside the attended page msc items shall be drawed
					DrawItem(drawDestination, worksheet, i,lineBeginn, ySize, page);
					if (mDiagramLines[i].Height != MSCItem.NEW_PAGE) lineBeginn += mDiagramLines[i].Height+this.YItemOffset;		// calculate the vertical start position for next msc items
				}
				worksheet.PrintFootLine(drawDestination);
				DrawMargins(drawDestination, worksheet);				// draw worksheet margins
				#region HelpDraw
				#if HelpDraw
									
									drawDestination.FillRectangle(Brushes.White,0, ymax-100,100,100);
									drawDestination.DrawRectangle(Pens.Black,0, ymax-100,100,100);
									drawDestination.DrawLine(Pens.LightBlue,5,ymax-90, 25,ymax-90);
									drawDestination.DrawString("instance limits", new Font("Arial",8),Brushes.Black,new RectangleF(30,ymax-95,170,15), sf);
									drawDestination.DrawLine(Pens.LightGreen,5,ymax-75, 25,ymax-75);
									drawDestination.DrawString("loop offset", new Font("Arial",8),Brushes.Black,new RectangleF(30,ymax-80,170,15), sf);
									drawDestination.DrawLine(Pens.OrangeRed,5,ymax-60, 25,ymax-60);
									drawDestination.DrawString("layout size", new Font("Arial",8),Brushes.Black,new RectangleF(30,ymax-65,170,15), sf);
									drawDestination.DrawLine(Pens.Yellow,5,ymax-45, 25,ymax-45);
									drawDestination.DrawString("line begin", new Font("Arial",8),Brushes.Black,new RectangleF(30,ymax-50,170,15), sf);
									drawDestination.DrawLine(Pens.LightPink,5,ymax-30, 25,ymax-30);
									drawDestination.DrawString("line end", new Font("Arial",8),Brushes.Black,new RectangleF(30,ymax-35,170,15), sf);
									
									sf.Alignment = StringAlignment.Center;
									drawDestination.FillRectangle(Brushes.White, 0,0,worksheet.Width,15);
									drawDestination.DrawLine(Pens.Black, 0,0,worksheet.Width,0);
									for (int k=0; k<=worksheet.Width; k+=10){
										drawDestination.DrawLine(Pens.Black, k,0,k,3);
										if (k % 20 == 0){
											drawDestination.DrawString((k/10).ToString(), new Font("Arial",8),Brushes.Black,new RectangleF(k-10,4,20,15), sf);
										}
									}
									sf.Alignment = StringAlignment.Far;
									sf.LineAlignment = StringAlignment.Center;
									drawDestination.FillRectangle(Brushes.White, worksheet.Width-20,20,20,worksheet.Height-20);
									drawDestination.DrawLine(Pens.Black, worksheet.Width,0,worksheet.Width,worksheet.Height);
									for (int k=20; k<=worksheet.Height; k+=10){
										drawDestination.DrawLine(Pens.Black, worksheet.Width-3,k,worksheet.Width,k);
										if (k % 20 == 0){
											drawDestination.DrawString((k/10).ToString(), new Font("Arial",8),Brushes.Black,new RectangleF(worksheet.Width-20,k-6,17,12), sf);
										}
									}
									sf.Dispose();
				
				#endif
				#endregion
				this.EmptyDiagram = false;
			}
  			else{
  				this.EmptyDiagram = true;
  			}
		}
						
		/// <summary>
		/// draws the msc head line
		/// </summary>
		/// <param name="drawDestination">drawing area</param>
		/// <param name="xPos">left offset for the head line</param>
		/// <param name="yPos">top offset of the head line</param>
		/// <param name="width">width of the drawing area</param>
		/// <param name="page">current page</param>
		public void DrawHeadLine(Graphics drawDestination, float xPos, float yPos, float width, uint page)
		{
			headLine.DrawItem(drawDestination, xPos, yPos, width, page, this.DiagramPages);
		}
		
		/// <summary>
		/// draws margins
		/// </summary>
		/// <param name="drawDestination">drawing area</param>
		/// <param name="worksheet">worksheet of the drawing area</param>
		public void DrawMargins(Graphics drawDestination, Worksheet worksheet)
		{
			//if ((worksheet.TopMargin>0) && (worksheet.BottomMargin>0) && (worksheet.LeftMargin>0) && (worksheet.RightMargin>0)){
				drawDestination.DrawRectangle(Pens.Black, worksheet.LeftMargin, worksheet.TopMargin, ((worksheet.Width-worksheet.LeftMargin)-worksheet.RightMargin), worksheet.GetWorksheetHeight());
			//}
			//else /*if((worksheet.TopMargin==0) && (worksheet.BottomMargin==0) && (worksheet.LeftMargin==0) && (worksheet.RightMargin==0)){
			//	
			//}
			//else*/{
//				/*if (worksheet.TopMargin>0)*/ drawDestination.DrawLine(Pens.Black, worksheet.LeftMargin , worksheet.TopMargin, worksheet.Width-worksheet.RightMargin, worksheet.TopMargin);
//				if (worksheet.BottomMargin>0) drawDestination.DrawLine(Pens.Black, worksheet.LeftMargin , worksheet.Height-worksheet.BottomMargin-worksheet.FootMargin, worksheet.Width-worksheet.RightMargin, worksheet.Height-worksheet.BottomMargin-worksheet.FootMargin);
//				/*if (worksheet.BottomMargin>0)*/ drawDestination.DrawLine(Pens.Black, worksheet.LeftMargin , worksheet.TopMargin + worksheet.GetWorksheetHeight() , worksheet.Width-worksheet.RightMargin, worksheet.TopMargin + worksheet.GetWorksheetHeight());
//				/*if (worksheet.LeftMargin>0)*/ drawDestination.DrawLine(Pens.Black, worksheet.LeftMargin , worksheet.TopMargin, worksheet.LeftMargin, worksheet.TopMargin + worksheet.GetWorksheetHeight());
//				/*if (worksheet.RightMargin>0)*/ drawDestination.DrawLine(Pens.Black, worksheet.Width-worksheet.RightMargin , worksheet.TopMargin, worksheet.Width-worksheet.RightMargin, worksheet.TopMargin + worksheet.GetWorksheetHeight());				
//				if (worksheet.LeftMargin>0) drawDestination.DrawLine(Pens.Black, worksheet.LeftMargin , worksheet.TopMargin, worksheet.LeftMargin, worksheet.Height-worksheet.BottomMargin);
//				if (worksheet.RightMargin>0) drawDestination.DrawLine(Pens.Black, worksheet.Width-worksheet.RightMargin , worksheet.TopMargin, worksheet.Width-worksheet.RightMargin, worksheet.Height-worksheet.BottomMargin);				
//			}
		}
		/// <summary>
		/// calculate the number of pages and store the hight of each page
		/// </summary>
		/// <param name="ySize">height of the useable drawing area</param>						
		public uint GetPages(float ySize)
		{
			float mscHeight=this.YProcessOffset;
			uint mscPage=1;
			pageHeights.Clear();
			if (processes.Count==0){
				mEmptyDiagram = true;
				return 0;
			}
			mEmptyDiagram = false;
			for (int i=1; i<mDiagramLines.Length-1; i++){
				mscHeight +=(this.YItemOffset+mDiagramLines[i].Height);
				if (!Output.AutosizeOutputHeight){						// count pages only if auto height is not activated
					if (mDiagramLines[i].Height == MSCItem.NEW_PAGE){	// if new page is defined then new page
						mscPage++;
						pageHeights.Add (mscHeight - mDiagramLines[i].Height - this.YItemOffset + BOTTOM_MARGIN_MSC);		// store height of the page
						mscHeight = this.YProcessOffset;				// start drawing on new page at offset position
					}
					else if ((mscHeight>ySize-BOTTOM_MARGIN_MSC)&&(i<mDiagramLines.Length-2)){ // if diagram is higher then draw area and something else to draw
						mscPage++;
						pageHeights.Add (mscHeight - mDiagramLines[i].Height - this.YItemOffset + BOTTOM_MARGIN_MSC+1);		// store height of page
						mscHeight = this.YProcessOffset+this.YItemOffset+mDiagramLines[i].Height;			// and draw the item on new page
					}
					else if((mscHeight>ySize-BOTTOM_MARGIN_MSC)&&(i==mDiagramLines.Length-2)){ // if last item dont leave space for diagram end marks
						pageHeights.Add (mscHeight - mDiagramLines[i].Height - this.YItemOffset + BOTTOM_MARGIN_MSC+1);
						mscPage++;					
					}
				}
				else{														// if auto height is activated
					if (mDiagramLines[i].Height == MSCItem.NEW_PAGE){		// if new page is defined then new page
						mscPage++;
						pageHeights.Add (mscHeight - mDiagramLines[i].Height - this.YItemOffset + BOTTOM_MARGIN_MSC);	// store page height
						mscHeight = this.YProcessOffset;
					}
					else if ((mscHeight>3500-BOTTOM_MARGIN_MSC)&&(i<mDiagramLines.Length-2)){		// if page height is greater then max page size then new page
						mscPage++;
						pageHeights.Add (mscHeight - mDiagramLines[i].Height + BOTTOM_MARGIN_MSC+1);		// store page height
						mscHeight = this.YProcessOffset+this.YItemOffset+mDiagramLines[i].Height;
					}					
				}
				mDiagramLines[i].Page = (int) mscPage;
			}
			pageHeights.Add (mscHeight+ BOTTOM_MARGIN_MSC);			// store height of last page
   			this.DiagramPages = mscPage;
			return mscPage;
		}
		/// <summary>
		/// sets the back color for closed drawing objects in the diagram 
		/// </summary>
		/// <param name="color">back color to be set</param>
		/// <returns>nothing</returns>
		public void SetFillColor(Color color)	
		{
			MSCItem.ActualFillBrush  = new SolidBrush(color);
		}
		/// <summary>
		/// sets the text color for objects in the diagram 
		/// </summary>
		/// <param name="color">text color to be set</param>
		/// <returns>nothing</returns>
		public void SetTextColor(Color color) 
		{
			MSCItem.ActualStringBrush = new SolidBrush(color);
		}
		/// <summary>
		/// sets the back color for open objects in the diagram 
		/// </summary>
		/// <param name="color">back color to be set</param>
		/// <returns>nothing</returns>
		public void SetBackColor(Color color)
		{
			MSCItem.ActualBackBrush = new SolidBrush(color);

		}
		/// <summary>
		/// sets the left margin for the first instance inside the diagram 
		/// </summary>
		/// <param name="left">margin to be set in pixel</param>
		/// <returns>nothing</returns>		
		public bool SetMSCLeft(uint left)
		{
			if(left > maxLeftMargin)
				return false;
			MSC.LeftMargin = left;
			return true;
		}
		/// <summary>
		/// sets the right margin for the last instance inside the diagram 
		/// </summary>
		/// <param name="right">margin to be set in pixel</param>
		/// <returns>nothing</returns>		
		public bool SetMSCRight(uint right)
		{
			if(right > maxRightMargin)
				return false;
			MSC.RightMargin = right;
			return true;
		}		
		/// <summary>
		/// gives the left and right position of the inline item
		/// </summary>
		/// <param name="identifier">identifier of the inline item</param>
		/// <returns>left and right position of the inline item</returns>
		private InLineSize GetInLineSize(string identifier)
		{
			InLineSize inLineSize;
			inLineSize.Left = 0;
			inLineSize.Right = 0;
			IEnumerator enumerator = inLines.GetEnumerator();
			for (uint i=0;i<inLines.Count;i++){
				enumerator.MoveNext();
				if (enumerator.Current is InLine){
					if (((InLine)enumerator.Current).Identifier == identifier){
						inLineSize.Left = ((InLine)enumerator.Current).LeftOffset + ((Process)processes[((InLine)enumerator.Current).ProcessBeginn]).LeftRand;
						inLineSize.Right =((InLine)enumerator.Current).RightOffset + ((Process)processes[((InLine)enumerator.Current).ProcessEnd]).RightRand;
						break;
					}
				}
			}
			
			return inLineSize;
		}
		///<summary>
		/// returns the x position of an instance line
		///</summary>
		/// <param name="processNr">number of the instance</param>
		/// <returns>x position of the instance line</returns>
		private float GetInstanceXPos(int processNr)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			if (processNr == ENV_RIGHT) return ENV_RIGHT;
			if (processNr == ENV_LEFT) return ENV_LEFT;
			for(uint i=0;i<processNr;i++){
				enumerator.MoveNext();
			}
			enumerator.MoveNext();
			process = (Process) enumerator.Current;
			return process.XPos;
		}
		///<summary>
		/// calculates the max hight of all instance names and process names and stores them in class variables
		/// </summary>
		/// <param name="drawDestination">actual drawing area</param>
		private void CalcProcessesNameHeight(Graphics drawDestination)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if(enumerator.Current is ProcessLine){
					mInstanceNameHeight = Math.Max(mInstanceNameHeight, ((ProcessLine)enumerator.Current).GetNameHeight(drawDestination));
					if (((ProcessLine)enumerator.Current).ProcessType==ProcessType.Normal)
						mProcessNameHeight = Math.Max(mProcessNameHeight, ((ProcessLine)enumerator.Current).GetNameHeight(drawDestination));
						
				}
			}
		}
		///<summary>
		/// calculates the max height af all instance descriptions
		///  </summary>
		/// <param name="drawDestination">actual drawing area</param>
		/// <returns>max hight off all instance descriptions</returns>
		private float GetProcessesDescriptionHeight(Graphics drawDestination)
		{
			float processDescriptionHeight=0;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if(enumerator.Current is ProcessLine){
					processDescriptionHeight = Math.Max(processDescriptionHeight, ((ProcessLine)enumerator.Current).GetDescriptionHeight(drawDestination));
				}
			}
			return processDescriptionHeight;
		}
		
		#region calcLineHeights
		/// <summary>
		/// calculate the nesting depths of left side of all inline items of the given instance and stores them in the inline object
		/// </summary>
		/// <param name="process">instace, the nesting depths will be calculated for</param>
		/// <param name="lineBeginn">first line, the nesting depths will be calculated for</param>
		/// <param name="lineEnd">last line, the nesting depths will be calculated for</param>
		/// <returns>max depth of the inlines</returns>
		private byte CalcNestingDepthLeft(int process, uint lineBeginn, uint lineEnd){
			IEnumerator enumeratorIL = inLines.GetEnumerator();			byte tmpDepth=0;
			byte tmpDepthMax=0;
			for(uint i=0;i<inLines.Count;i++){
				enumeratorIL.MoveNext();
				if (enumeratorIL.Current is InLine){
					if ((((InLine)(enumeratorIL.Current)).LineBeginn>lineBeginn)&&(((InLine)(enumeratorIL.Current)).LineBeginn<lineEnd)&&(((InLine)(enumeratorIL.Current)).ProcessBeginn == process)){
						// use recursion to calculate the nesting depth
						tmpDepth = 1;
						tmpDepth += CalcNestingDepthLeft(process,((InLine)(enumeratorIL.Current)).LineBeginn,((InLine)(enumeratorIL.Current)).LineEnd);
						((InLine)(enumeratorIL.Current)).LeftOffset = Math.Max(((InLine)(enumeratorIL.Current)).LeftOffset, tmpDepth*INLINE_OFFSET);
					}
				}
				else if (enumeratorIL.Current is Reference){

					if ((((Reference)(enumeratorIL.Current)).Line>lineBeginn)&&(((Reference)(enumeratorIL.Current)).Line<lineEnd)&&(((Reference)(enumeratorIL.Current)).ProcessBeginn == process)){
							tmpDepth = 1;
						// use recursion to calculate the nesting depth
						((Reference)(enumeratorIL.Current)).LeftOffset = Math.Max(((Reference)(enumeratorIL.Current)).LeftOffset, 1*INLINE_OFFSET);
					}					
				}	
				if (tmpDepthMax < tmpDepth)
					tmpDepthMax = tmpDepth;
			}
			return tmpDepthMax;	
		}
		/// <summary>
		/// calculate the nesting depths of right side of all inline items of the given instance and stores them in the inline object
		/// </summary>
		/// <param name="process">instace, the nesting depths will be calculated for</param>
		/// <param name="lineBeginn">first line, the nesting depths will be calculated for</param>
		/// <param name="lineEnd">last line, the nesting depths will be calculated for</param>
		/// <returns>max depth of the inlines</returns>		
		private byte CalcNestingDepthRight(int process, uint lineBeginn, uint lineEnd){
			IEnumerator enumeratorIL = inLines.GetEnumerator();
			byte tmpDepth=0, tmpDepthMax=0;
			for(uint i=0;i<inLines.Count;i++){
				enumeratorIL.MoveNext();
				if (enumeratorIL.Current is InLine){
					if ((((InLine)(enumeratorIL.Current)).LineBeginn>lineBeginn)&&(((InLine)(enumeratorIL.Current)).LineBeginn<lineEnd)&&(((InLine)(enumeratorIL.Current)).ProcessEnd == process)){
						tmpDepth = 1;
						tmpDepth += CalcNestingDepthRight(process,((InLine)(enumeratorIL.Current)).LineBeginn,((InLine)(enumeratorIL.Current)).LineEnd);
						((InLine)(enumeratorIL.Current)).RightOffset = Math.Max(((InLine)(enumeratorIL.Current)).RightOffset, tmpDepth*INLINE_OFFSET);
					}
				}
				else if (enumeratorIL.Current is Reference){
					if ((((Reference)(enumeratorIL.Current)).Line>lineBeginn)&&(((Reference)(enumeratorIL.Current)).Line<lineEnd)&&(((Reference)(enumeratorIL.Current)).ProcessEnd == process)){
						tmpDepth = 1;
						// use recursion to calculate the nesting depth
						tmpDepth += CalcNestingDepthRight(process,((Reference)(enumeratorIL.Current)).Line,((Reference)(enumeratorIL.Current)).Line);
						((Reference)(enumeratorIL.Current)).RightOffset = Math.Max(((Reference)(enumeratorIL.Current)).RightOffset, tmpDepth*INLINE_OFFSET);
					}					
				}
				if (tmpDepthMax < tmpDepth)
					tmpDepthMax = tmpDepth;
			}
			return tmpDepthMax;	
		}
		///<summary>
		/// calculates the necessary margins for the inlines of an instance
		/// </summary>
		/// <param name="instance">instance number</param>
		/// <returns>the left and right margin of the instance</returns>
		private InLineSize GetMaxMargins(int instance)
		{
			InLineSize inLineSize;
			inLineSize.Left = 0;
			inLineSize.Right = 0;
			IEnumerator enumeratorIL = inLines.GetEnumerator();
			for(uint i=0;i<inLines.Count;i++){
				enumeratorIL.MoveNext();
				if (enumeratorIL.Current is InLine){			 
					if(((InLine)(enumeratorIL.Current)).ProcessBeginn==instance)
						inLineSize.Left = Math.Max(inLineSize.Left,((InLine)(enumeratorIL.Current)).LeftOffset);
					if(((InLine)(enumeratorIL.Current)).ProcessEnd==instance)
						inLineSize.Right = Math.Max(inLineSize.Right,((InLine)(enumeratorIL.Current)).RightOffset);
				}
				if (enumeratorIL.Current is Reference){		
					if(((Reference)(enumeratorIL.Current)).ProcessBeginn==instance)
						inLineSize.Left = Math.Max(inLineSize.Left,((Reference)(enumeratorIL.Current)).LeftOffset);
					if(((Reference)(enumeratorIL.Current)).ProcessEnd==instance)
						inLineSize.Right = Math.Max(inLineSize.Right,((Reference)(enumeratorIL.Current)).RightOffset);				
				}		
			}
			return inLineSize;
		}
		///<summary>
		/// calculates the necessary margins for the inlines and adds defined margins by an user
		/// </summary>
		private void CalcProcessMargins()
		{
			IEnumerator enumerator = processes.GetEnumerator();
			InLineSize inLineSize;
			inLineSize.Left = 0;
			inLineSize.Right = 0;
			for (int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				((Process)(enumerator.Current)).LeftMargin = 0.0f;
				((Process)(enumerator.Current)).RightMargin = 0.0f;
				CalcNestingDepthLeft(i,0,mLines);
				CalcNestingDepthRight(i,0,mLines);
				inLineSize = GetMaxMargins(i);
				((Process)(enumerator.Current)).LeftMargin += inLineSize.Left+Generator.LOOP_OFFSET*2;
				((Process)(enumerator.Current)).LeftMargin += ((Process)(enumerator.Current)).LeftRand;
				((Process)(enumerator.Current)).RightMargin += inLineSize.Right+Generator.LOOP_OFFSET*2;
				((Process)(enumerator.Current)).RightMargin += ((Process)(enumerator.Current)).RightRand;
				if(i==0)
					((Process)(enumerator.Current)).LeftMargin += MSC.LeftMargin;
				if(i==processes.Count-1)
					((Process)(enumerator.Current)).RightMargin +=MSC.RightMargin;
			}
		}
		/// <summary>
		/// calculates all offsets for the msc
		/// </summary>
		/// <param name="drawDestination">actual drawing area</param>
		/// <param name="worksheet">worksheet sizes of the drawing area</param>
		public void CalcOffsets(Graphics drawDestination, Worksheet worksheet)
		{
			IEnumerator enumerator;
			float 	instanceSpace, 		// horizontal space for every instance
					instanceOffset,		// x position of the first instance
				 	sumMargin=0,		// margin summation to affact each instance space
				 	xSize, 				// width of the drawing area without margins
					ySize;				// height of the drawing area without margins
			
			CalcProcessMargins();
			enumerator = processes.GetEnumerator();
			for(uint i=0;i<processes.Count;i++){		//calculate summation of all margins
				enumerator.MoveNext();
				sumMargin +=((Process)enumerator.Current).LeftMargin+((Process)enumerator.Current).RightMargin;
			}
			this.mAutoWidth = (sumMargin + processes.Count * 150);
			if (Output.AutosizeOutputWidth == true){
				worksheet.SetWorksheetWidth((int)this.mAutoWidth);
			}
			xSize = (worksheet.Width - worksheet.LeftMargin) - worksheet.RightMargin;	// calculate width of drawing area
			ySize = worksheet.GetWorksheetHeight();	// calculate height of drawing area
			Trace.WriteLine(DateTime.Now.TimeOfDay + " ySize: " + ySize.ToString());

			instanceSpace = (xSize-(INLINE_OFFSET*2)-sumMargin)/processes.Count;		// calculate the available space for each instance
			instanceOffset = INLINE_OFFSET+instanceSpace/2 + worksheet.LeftMargin;		// calculate the x positon of first instance
			HeadHeight = headLine.GetHeight(drawDestination, xSize);
			enumerator.Reset();
			sumMargin = 0;																
			for(uint i=0;i<processes.Count;i++){										// calculate the x position of each instance
				enumerator.MoveNext();
				sumMargin +=((Process)enumerator.Current).LeftMargin;			
				((Process)enumerator.Current).XPos = sumMargin + instanceOffset + i * instanceSpace;	
				sumMargin +=((Process)enumerator.Current).RightMargin;
			}
			MSCItem.ItemLayoutSize = new SizeF(instanceSpace,(ySize-this.YProcessOffset)-20);			// set the max size of msc items
			mProcessNameHeight=0;
			mInstanceNameHeight=0;
			this.CalcProcessesNameHeight(drawDestination);
			this.mYProcessName = worksheet.TopMargin + this.GetProcessesDescriptionHeight(drawDestination) + this.HeadHeight;	// set the verical position of instance name
			this.YProcessOffset = this.mYProcessName + mInstanceNameHeight+20; 			// set the vertical offset for first msc item			
			if (instanceSpace < GEM_MIN_INSTANCE_SPACE)									// check min horizontal space for instances
				this.generatorResult = GeneratorResult.InstanceSpaceToSmall;			// diagram can not be drawn
			else
				this.generatorResult = GeneratorResult.OK;								// insantce horizontal space ok
		}
		/// <summary>
		/// calculates all offsets and line heights for the msc
		/// </summary>
		/// <param name="drawDestination">actual drawing area</param>
		/// <param name="worksheet">worksheet sizes of the drawing area</param>
		/// <param name="font">font used in the msc</param>
		public void CalcLineHights(Graphics drawDestination, Worksheet worksheet, Font font)
		{
			IEnumerator enumerator;
			uint 	line=0;				// msc line counter
			float 	instanceSpace, 		// horizontal space for every instance
					instanceOffset,		// x position of the first instance
				 	sumMargin=0,		// margin summation to affact each instance space
				 	xSize, 				// width of the drawing area without margins
					ySize;				// height of the drawing area without margins
			
			CalcProcessMargins();
			enumerator = processes.GetEnumerator();
			for(uint i=0;i<processes.Count;i++){		//calculate summation of all margins
				enumerator.MoveNext();
				sumMargin +=((Process)enumerator.Current).LeftMargin+((Process)enumerator.Current).RightMargin;
			}
			this.mAutoWidth = (sumMargin + processes.Count * 150);
			if (Output.AutosizeOutputWidth == true){
				worksheet.SetWorksheetWidth((int)this.mAutoWidth);
			}
			xSize = (worksheet.Width - worksheet.LeftMargin) - worksheet.RightMargin;	// calculate width of drawing area
			ySize = worksheet.GetWorksheetHeight();	// calculate height of drawing area
			
			instanceSpace = (xSize-(INLINE_OFFSET*2)-sumMargin)/processes.Count;		// calculate the available space for each instance				
			if (instanceSpace < GEM_MIN_INSTANCE_SPACE){
				generatorResult = GeneratorResult.InstanceSpaceToSmall;
			}
			else{
				generatorResult = GeneratorResult.OK;
			}
			instanceOffset = INLINE_OFFSET+instanceSpace/2 + worksheet.LeftMargin;		// calculate the x positon of first instance
			HeadHeight = headLine.GetHeight(drawDestination, xSize);
			enumerator.Reset();
			sumMargin = 0;		
			for(uint i=0;i<processes.Count;i++){										// calculate the x position of each instance
				enumerator.MoveNext();
				sumMargin +=((Process)enumerator.Current).LeftMargin;			
				((Process)enumerator.Current).XPos = sumMargin + instanceOffset + i * instanceSpace;	
				sumMargin +=((Process)enumerator.Current).RightMargin;
			}
			MSCItem.ItemFont = font;
			MSCItem.ItemLayoutSize = new SizeF(instanceSpace,(ySize-this.YProcessOffset)-20);			// set the max size of msc items
			mProcessNameHeight=0;
			mInstanceNameHeight=0;
			this.CalcProcessesNameHeight(drawDestination);
			this.mYProcessName = worksheet.TopMargin + this.GetProcessesDescriptionHeight(drawDestination) + this.HeadHeight;	// set the verical position of instance name
			this.YProcessOffset = this.mYProcessName + mInstanceNameHeight+20; 			// set the vertical offset for first msc item
			if (mLines>0){
				mDiagramLines = new DiagramLine[mLines+2];
				enumerator = items.GetEnumerator();
				for(uint i=0;i<items.Count;i++){										// store the maximum line height of each msc line
					enumerator.MoveNext();
					if (enumerator.Current is State)
					{
						float xPosMin = GetInstanceXPos(processes.Count-1);
						float xPosMax = 0;
						
						for(int j=0; j<processes.Count; j++){
							if(((State)enumerator.Current).IsUsedProcess(j)){
								xPosMin = Math.Min(xPosMin,GetInstanceXPos(j));
								xPosMax = Math.Max(xPosMax,GetInstanceXPos(j));
							}
						}
						mDiagramLines[((State)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((State)enumerator.Current).Line].Height,((State)enumerator.Current).GetHeight(drawDestination,xPosMin,xPosMax));
						line = ((State)enumerator.Current).Line;
					}
					if (enumerator.Current is MSCEnd)
					{
						mDiagramLines[((MSCEnd)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MSCEnd)enumerator.Current).Line].Height,((MSCEnd)enumerator.Current).GetHeight(drawDestination));
						line = ((MSCEnd)enumerator.Current).Line;
					}
					if (enumerator.Current is MeasureStart)
					{
						mDiagramLines[((MeasureStart)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MeasureStart)enumerator.Current).Line].Height,((MeasureStart)enumerator.Current).GetHeight(drawDestination));
						line = ((MeasureStart)enumerator.Current).Line;
					}
					if (enumerator.Current is MeasureStop)
					{
						mDiagramLines[((MeasureStop)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MeasureStop)enumerator.Current).Line].Height,((MeasureStop)enumerator.Current).GetHeight(drawDestination));
						line = ((MeasureStop)enumerator.Current).Line;
					}
					if (enumerator.Current is MeasureBeginn)
					{
						mDiagramLines[((MeasureBeginn)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MeasureBeginn)enumerator.Current).Line].Height,((MeasureBeginn)enumerator.Current).GetHeight(drawDestination));
						line = ((MeasureBeginn)enumerator.Current).Line;
					}
					if (enumerator.Current is MeasureEnd)
					{
						mDiagramLines[((MeasureEnd)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MeasureEnd)enumerator.Current).Line].Height,((MeasureEnd)enumerator.Current).GetHeight(drawDestination));
						line = ((MeasureEnd)enumerator.Current).Line;
					}
					if (enumerator.Current is TimerBegin)
					{
						mDiagramLines[((TimerBegin)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((TimerBegin)enumerator.Current).Line].Height,((TimerBegin)enumerator.Current).GetHeight(drawDestination));
						line = ((TimerBegin)enumerator.Current).Line;
					}
					if (enumerator.Current is TimerEnd)
					{
						mDiagramLines[((TimerEnd)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((TimerEnd)enumerator.Current).Line].Height,((TimerEnd)enumerator.Current).GetHeight(drawDestination));
						line = ((TimerEnd)enumerator.Current).Line;
					}
					if (enumerator.Current is TimeoutBegin)
					{
						mDiagramLines[((TimeoutBegin)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((TimeoutBegin)enumerator.Current).Line].Height,((TimeoutBegin)enumerator.Current).GetHeight(drawDestination));
						line = ((TimeoutBegin)enumerator.Current).Line;
					}
					if (enumerator.Current is TimeoutEnd)
					{
						mDiagramLines[((TimeoutEnd)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((TimeoutEnd)enumerator.Current).Line].Height,((TimeoutEnd)enumerator.Current).GetHeight(drawDestination));
						line = ((TimeoutEnd)enumerator.Current).Line;
					}
					if (enumerator.Current is TimeoutStop)
					{
						mDiagramLines[((TimeoutStop)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((TimeoutStop)enumerator.Current).Line].Height,((TimeoutStop)enumerator.Current).GetHeight(drawDestination));
						line = ((TimeoutStop)enumerator.Current).Line;
					}
					if (enumerator.Current is TimeOut)
					{
						mDiagramLines[((TimeOut)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((TimeOut)enumerator.Current).Line].Height,((TimeOut)enumerator.Current).GetHeight(drawDestination));
						line = ((TimeOut)enumerator.Current).Line;
					}
					if (enumerator.Current is StopTimer)
					{
						mDiagramLines[((StopTimer)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((StopTimer)enumerator.Current).Line].Height,((StopTimer)enumerator.Current).GetHeight(drawDestination));
						line = ((StopTimer)enumerator.Current).Line;
					}
					if (enumerator.Current is SetTimer)
					{
						mDiagramLines[((SetTimer)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((SetTimer)enumerator.Current).Line].Height,((SetTimer)enumerator.Current).GetHeight(drawDestination));
						line = ((SetTimer)enumerator.Current).Line;
					}
					if (enumerator.Current is Comment)
					{
						if (((Comment)enumerator.Current).Position == CommentPos.OverAll){
							mDiagramLines[((Comment)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((Comment)enumerator.Current).Line].Height,((Comment)enumerator.Current).GetHeight(drawDestination,GetInstanceXPos(((Comment) enumerator.Current).Process), GetInstanceXPos(0),GetInstanceXPos(processes.Count-1), MSC.LeftMargin + ((Process)processes[0]).LeftRand, MSC.RightMargin + ((Process)processes[processes.Count-1]).RightRand));
						}
						else{
							mDiagramLines[((Comment)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((Comment)enumerator.Current).Line].Height,((Comment)enumerator.Current).GetHeight(drawDestination,GetInstanceXPos(((Comment) enumerator.Current).Process), worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin, MSC.LeftMargin + ((Process)processes[0]).LeftRand, MSC.RightMargin + ((Process)processes[processes.Count-1]).RightRand));
						}
						line = ((Comment)enumerator.Current).Line;	
					}
					if (enumerator.Current is LineComment)
					{
						mDiagramLines[((LineComment)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((LineComment)enumerator.Current).Line].Height,((LineComment)enumerator.Current).GetHeight(drawDestination));
						line = ((LineComment)enumerator.Current).Line;
					}
					if (enumerator.Current is Task)
					{
						mDiagramLines[((Task)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((Task)enumerator.Current).Line].Height,((Task)enumerator.Current).GetHeight(drawDestination));
						line = ((Task)enumerator.Current).Line;
					}
					if (enumerator.Current is mscElements.Message)
					{
						mDiagramLines[((mscElements.Message)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((mscElements.Message)enumerator.Current).Line].Height,((mscElements.Message)enumerator.Current).GetHeight(drawDestination, GetInstanceXPos(((mscElements.Message)enumerator.Current).MessageSource), GetInstanceXPos(((mscElements.Message)enumerator.Current).MessageDestination)));
						line = ((mscElements.Message)enumerator.Current).Line;
					}
					if (enumerator.Current is Mark)
					{
						mDiagramLines[((Mark)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((Mark)enumerator.Current).Line].Height,((Mark)enumerator.Current).GetHeight(drawDestination));
						line = ((Mark)enumerator.Current).Line;
					}
					if (enumerator.Current is FoundMessage)
					{
						mDiagramLines[((FoundMessage)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((FoundMessage)enumerator.Current).Line].Height,((FoundMessage)enumerator.Current).GetHeight(drawDestination));
						line = ((FoundMessage)enumerator.Current).Line;
					}
					if (enumerator.Current is LostMessage)
					{
						mDiagramLines[((LostMessage)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((LostMessage)enumerator.Current).Line].Height,((LostMessage)enumerator.Current).GetHeight(drawDestination));
						line = ((LostMessage)enumerator.Current).Line;
					}
					if (enumerator.Current is ProcessStop)
					{
						mDiagramLines[((ProcessStop)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((ProcessStop)enumerator.Current).Line].Height,((ProcessStop)enumerator.Current).GetHeight(drawDestination));
						line = ((ProcessStop)enumerator.Current).Line;
					}
					if (enumerator.Current is ProcessCreate)
					{
						mDiagramLines[((ProcessCreate)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((ProcessCreate)enumerator.Current).Line].Height,((ProcessCreate)enumerator.Current).GetHeight(drawDestination, GetInstanceXPos(((ProcessCreate)enumerator.Current).Source), GetInstanceXPos(((ProcessCreate)enumerator.Current).Destination)));
						line = ((ProcessCreate)enumerator.Current).Line;
					}
					if (enumerator.Current is ProcessRegion)
					{
						mDiagramLines[((ProcessRegion)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((ProcessRegion)enumerator.Current).Line].Height,((ProcessRegion)enumerator.Current).GetHeight(drawDestination));
						line = ((ProcessRegion)enumerator.Current).Line;
					}
					if (enumerator.Current is Reference)
					{
						mDiagramLines[((Reference)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((Reference)enumerator.Current).Line].Height,((Reference)enumerator.Current).GetHeight(drawDestination, GetInstanceXPos(((Reference)enumerator.Current).ProcessBeginn), GetInstanceXPos(((Reference)enumerator.Current).ProcessEnd)));
						line = ((Reference)enumerator.Current).Line;
					}
					if (enumerator.Current is InLineBeginn)
					{
						mDiagramLines[((InLineBeginn)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((InLineBeginn)enumerator.Current).Line].Height,((InLineBeginn)enumerator.Current).GetHeight(drawDestination));
						line = ((InLineBeginn)enumerator.Current).Line;
					}
					if (enumerator.Current is InLineEnd)
					{
						mDiagramLines[((InLineEnd)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((InLineEnd)enumerator.Current).Line].Height,((InLineEnd)enumerator.Current).GetHeight(drawDestination));
						line = ((InLineEnd)enumerator.Current).Line;
					}
					if (enumerator.Current is InLineSeparator)
					{
						mDiagramLines[((InLineSeparator)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((InLineSeparator)enumerator.Current).Line].Height,((InLineSeparator)enumerator.Current).GetHeight(drawDestination));
						line = ((InLineSeparator)enumerator.Current).Line;
					}
					if (enumerator.Current is InLineText)
					{
						mDiagramLines[((InLineText)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((InLineText)enumerator.Current).Line].Height,((InLineText)enumerator.Current).GetHeight(drawDestination, ((Process)processes[((InLineText)enumerator.Current).ProcessBeginn]).LeftRand));
						line = ((InLineText)enumerator.Current).Line;
					}
					if (enumerator.Current is MessageBegin)
					{
						mDiagramLines[((MessageBegin)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MessageBegin)enumerator.Current).Line].Height,((MessageBegin)enumerator.Current).GetHeight(drawDestination, GetInstanceXPos(((MessageBegin)enumerator.Current).MessageSource), GetInstanceXPos(((MessageBegin)enumerator.Current).MessageDestination)));
						line = ((MessageBegin)enumerator.Current).Line;
					}
					if (enumerator.Current is MessageEnd)
					{
						mDiagramLines[((MessageEnd)enumerator.Current).Line].Height = Math.Max(mDiagramLines[((MessageEnd)enumerator.Current).Line].Height,((MessageEnd)enumerator.Current).GetHeight(drawDestination));
						line = ((MessageEnd)enumerator.Current).Line;
					}
					if (enumerator.Current is NewPage)
					{
						mDiagramLines[((NewPage)enumerator.Current).Line].Height = ((NewPage)enumerator.Current).GetHeight();
						line = ((NewPage)enumerator.Current).Line;
					}
				}
			}
			if (instanceSpace < GEM_MIN_INSTANCE_SPACE)
				this.generatorResult = GeneratorResult.InstanceSpaceToSmall;
			else 
				this.generatorResult = GeneratorResult.OK;
		}
		#endregion
		///<summary>
		/// set pens for all msc items except process pens
		///</summary>
		/// <param name="pen">pen for all items in the msc</param>
		/// <returns>nothing</returns>
		public void ChangeAllItemPens(Pen pen)
		{
			IEnumerator enumerator = items.GetEnumerator();
			for(uint i=0;i<items.Count;i++){
				enumerator.MoveNext();
				((MSCItem) enumerator.Current).ItemPen = pen;
			}	
		}
		
		///<summary>
		/// set pens for all instances
		///</summary>
		/// <param name="pen">pen for all instances in the msc</param>
		/// <returns>nothing</returns>
		public void ChangeAllProcessPens(Pen pen)
		{
			IEnumerator enumerator = processes.GetEnumerator();
			for(uint i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				((Processes) enumerator.Current).ProcessPen = pen;
			}	
		}
		///<summary>
		/// returns the drawing style (normal, activation, suspension, coregion, not used) of a instance in the given msc line
		/// </summary>
		/// <param name="process">number of process</param>
		/// <param name="line">msc line</param>
		/// <returns>instance style</returns>
		private ProcessStyle GetProcessStyle(int process, uint line)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if (enumerator.Current is ProcessLine){
					if((((ProcessLine)enumerator.Current).ProcessIndex==process)&&(((ProcessLine)enumerator.Current).LineBeginn<line)&&((((ProcessLine)enumerator.Current).LineEnd>line)||(((ProcessLine)enumerator.Current).LineEnd==0)))
						return ((ProcessLine)enumerator.Current).ProcessStyle;
				}
			}
			return ProcessStyle.NotUsed;		
		}
		///<summary>
		/// draws msc items
		/// </summary>
		/// <param name="drawDestination">actual drawing area</param>
		/// <param name="worksheet">worksheet sizes of the drawing area</param>
		/// <param name="line">actual msc line</param>
		/// <param name="yPos">y start drawing position</param>
		/// <param name="ySize">height of the drawing area</param>
		/// <param name="page">current page</param>
		private void DrawItem(Graphics drawDestination, Worksheet worksheet, uint line, float yPos, float ySize, uint page)
		{
			IEnumerator enumerator = items.GetEnumerator();
			for(uint i=0;i<items.Count;i++){
				enumerator.MoveNext();
				//drawDestination.DrawRectangle(Pens.Red,((MSCItem)enumerator.Current).bounds.X,((MSCItem)enumerator.Current).bounds.Y,((MSCItem)enumerator.Current).bounds.Width,((MSCItem)enumerator.Current).bounds.Height);
				if (((MSCItem)enumerator.Current).Line == line) 
					((MSCItem)enumerator.Current).ItemPage = page;
				if (enumerator.Current is State)
				{
					if (((State)enumerator.Current).Line == line){
						float xPosMin = GetInstanceXPos(processes.Count-1);
						float xPosMax = 0;
						
						for(int j=0; j<processes.Count; j++){					// get the start and end x position of the state item
							if(((State)enumerator.Current).IsUsedProcess(j)){
								xPosMin = Math.Min(xPosMin,GetInstanceXPos(j));
								xPosMax = Math.Max(xPosMax,GetInstanceXPos(j));
							}
						}
						((State)enumerator.Current).DrawItem(drawDestination,xPosMin, xPosMax,yPos, mDiagramLines[line].Height);						
						for(int j=0; j<processes.Count; j++){					// for overlayed instance lines, that are not integrated in the state
								float xPos=0;									// instance lines have to be redrawed
							if(!((State)enumerator.Current).IsUsedProcess(j)){
								if (GetProcessStyle(j,line)!=ProcessStyle.NotUsed){
									xPos=GetInstanceXPos(j);
									if((xPos>xPosMin)&&(xPos<xPosMax))
										((State)enumerator.Current).DrawForegroundProcessLine(drawDestination,GetInstanceXPos(j),yPos,xPosMin, xPosMax, mDiagramLines[line].Height);
								}
							}
						}
					}
				}
				if (enumerator.Current is MSCEnd)
				{
					if (((MSCEnd)enumerator.Current).Line == line){
						for(int j=0; j<processes.Count; j++)
							if(GetProcessStyle(j,line)!=ProcessStyle.NotUsed)
								((MSCEnd)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(j),ySize);
					}
				}
				if (enumerator.Current is MeasureStart)
				{
					if (((MeasureStart)enumerator.Current).Line == line)
						((MeasureStart)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureStart)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is MeasureStop)
				{
					if (((MeasureStop)enumerator.Current).Line == line)
						((MeasureStop)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureStop)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is MeasureBeginn)
				{
					if (((MeasureBeginn)enumerator.Current).Line == line)
						((MeasureBeginn)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureBeginn)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is MeasureEnd)
				{
					if (((MeasureEnd) enumerator.Current).Line == line)
						((MeasureEnd) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureEnd) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is TimeOut)
				{
					if (((TimeOut)enumerator.Current).Line == line)
						((TimeOut)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((TimeOut)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is StopTimer)
				{
					if (((StopTimer)enumerator.Current).Line == line)
						((StopTimer)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((StopTimer)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is SetTimer)
				{
					if (((SetTimer)enumerator.Current).Line == line)
						((SetTimer)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((SetTimer)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is TimerBegin)
				{
					if (((TimerBegin)enumerator.Current).Line == line)
						((TimerBegin)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((TimerBegin)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is TimerEnd)
				{
					if (((TimerEnd) enumerator.Current).Line == line)
						((TimerEnd) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((TimerEnd) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is TimeoutBegin)
				{
					if (((TimeoutBegin)enumerator.Current).Line == line)
						((TimeoutBegin)enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((TimeoutBegin)enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is TimeoutEnd)
				{
					if (((TimeoutEnd) enumerator.Current).Line == line)
						((TimeoutEnd) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((TimeoutEnd) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is TimeoutStop)
				{
					if (((TimeoutStop) enumerator.Current).Line == line)
						((TimeoutStop) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((TimeoutStop) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is Comment)
				{
					if (((Comment) enumerator.Current).Line == line){
						if (((Comment)enumerator.Current).Position == CommentPos.OverAll){
							((Comment) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((Comment) enumerator.Current).Process), GetInstanceXPos(0),GetInstanceXPos(processes.Count-1),yPos, MSC.LeftMargin + ((Process)processes[0]).LeftRand, MSC.RightMargin + ((Process)processes[processes.Count-1]).RightRand);
						}
						else{
							((Comment) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((Comment) enumerator.Current).Process), worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin,yPos, MSC.LeftMargin + ((Process)processes[0]).LeftRand, MSC.RightMargin + ((Process)processes[processes.Count-1]).RightRand);
						}
					}
				}
				if (enumerator.Current is LineComment)
				{
					if (((LineComment) enumerator.Current).Line == line){
						((LineComment) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((LineComment) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
					}
				}
				if (enumerator.Current is Task)
				{
					if (((Task) enumerator.Current).Line == line)
						((Task) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((Task) enumerator.Current).Process),yPos, mDiagramLines[line].Height);
				}
				if (enumerator.Current is mscElements.Message)
				{
					if (((mscElements.Message) enumerator.Current).Line == line)
						((mscElements.Message) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((mscElements.Message) enumerator.Current).MessageSource),GetInstanceXPos(((mscElements.Message) enumerator.Current).MessageDestination),yPos,mDiagramLines[line].Height,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin, GetLifeLineStyle(((mscElements.Message) enumerator.Current).MessageSource, line), GetLifeLineStyle(((mscElements.Message) enumerator.Current).MessageDestination, line));
				}
				if (enumerator.Current is Mark)
				{
					if (((Mark) enumerator.Current).Line == line)
						((Mark) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((Mark) enumerator.Current).Process),worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin,yPos,mDiagramLines[line].Height, this.YItemOffset);
				}
				if (enumerator.Current is FoundMessage)
				{
					if (((FoundMessage) enumerator.Current).Line == line)
						((FoundMessage) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((FoundMessage) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is LostMessage)
				{
					if (((LostMessage) enumerator.Current).Line == line)
						((LostMessage) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((LostMessage) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is ProcessStop)
				{
					if (((ProcessStop) enumerator.Current).Line == line)
						((ProcessStop) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ProcessStop) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is ProcessCreate)
				{
					if (((ProcessCreate) enumerator.Current).Line == line)
						((ProcessCreate) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ProcessCreate) enumerator.Current).Source),GetInstanceXPos(((ProcessCreate) enumerator.Current).Destination),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is ProcessRegion)
				{
					if (((ProcessRegion) enumerator.Current).Line == line)
						((ProcessRegion) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ProcessRegion) enumerator.Current).Process),yPos,mDiagramLines[line].Height);
				}
				if (enumerator.Current is Reference)
				{
					if (((Reference) enumerator.Current).Line == line){
						((Reference) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((Reference) enumerator.Current).ProcessBeginn),GetInstanceXPos(((Reference) enumerator.Current).ProcessEnd),yPos,mDiagramLines[line].Height);
						
					}
				}
				if (enumerator.Current is InLineBeginn)
				{
					if (((InLineBeginn) enumerator.Current).Line == line){
						InLineSize inLineSize;
						inLineSize = GetInLineSize(((InLineBeginn) enumerator.Current).Identifier);
						((InLineBeginn) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLineBeginn) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLineBeginn) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right,yPos,mDiagramLines[line].Height);
						
					}
				}
				if (enumerator.Current is InLineEnd)
				{
					if (((InLineEnd) enumerator.Current).Line == line){
						InLineSize inLineSize;
						inLineSize = GetInLineSize(((InLineEnd) enumerator.Current).Identifier);
						((InLineEnd) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLineEnd) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLineEnd) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right,yPos,mDiagramLines[line].Height);
						
					}
				}
				if (enumerator.Current is InLineSeparator)
				{
					if (((InLineSeparator) enumerator.Current).Line == line){
						InLineSize inLineSize;
						inLineSize = GetInLineSize(((InLineSeparator) enumerator.Current).Identifier);
						((InLineSeparator) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLineSeparator) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLineSeparator) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right,yPos,mDiagramLines[line].Height);	
					}
				}
				if (enumerator.Current is InLineText)
				{
					if (((InLineText) enumerator.Current).Line == line){
						InLineSize inLineSize;
						inLineSize = GetInLineSize(((InLineText) enumerator.Current).Identifier);
						((InLineText) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLineText) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLineText) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right,yPos,mDiagramLines[line].Height);	
					}
				}
				if (enumerator.Current is MessageBegin)
				{
					if (((MessageBegin) enumerator.Current).Line == line)
						((MessageBegin) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MessageBegin) enumerator.Current).MessageSource),GetInstanceXPos(((MessageBegin) enumerator.Current).MessageDestination),yPos,mDiagramLines[line].Height,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin, GetLifeLineStyle(((mscElements.MessageBegin) enumerator.Current).MessageSource, line), GetLifeLineStyle(((mscElements.MessageBegin) enumerator.Current).MessageDestination, line));
				}
				if (enumerator.Current is MessageEnd)
				{
					if (((MessageEnd) enumerator.Current).Line == line)
						((MessageEnd) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MessageEnd) enumerator.Current).MessageSource),GetInstanceXPos(((MessageEnd) enumerator.Current).MessageDestination),yPos,mDiagramLines[line].Height,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin, GetLifeLineStyle(((mscElements.MessageEnd) enumerator.Current).MessageSource, line), GetLifeLineStyle(((mscElements.MessageEnd) enumerator.Current).MessageDestination, line));
				}
			}
		}
		///<summary>
		/// draws inlines between inlinebegin and inlineend including carry points on page begin and page end
		/// </summary>
		/// <param name="drawDestination">drawing area</param>
		/// <param name="pageBeginnLine">first line of page</param>
		/// <param name="pageEndLine">last line of page</param>
		/// <param name="yPos">max top position to draw inline</param>
		/// <param name="ySize">height of the drawing area</param>
		/// <param name="TopMargin">top margin height of the worksheet</param></param>
		public void DrawInLines(Graphics drawDestination, uint pageBeginnLine, uint pageEndLine, float yPos, float ySize, float TopMargin)
		{
			IEnumerator enumerator = inLines.GetEnumerator();
			float 	yPosStart, 				// y start position of the inline to draw
					yPosEnd;				// y end position of the inline to draw
			uint 	lineBeginnLine, 		// first line of the inline to draw
					lineEndLine;			// last line of the inline to draw
			InLineSize inLineSize;			// left and right position of the inline
			for(uint i=0;i<inLines.Count;i++){
				enumerator.MoveNext();
				// is inline on the current page
				if (enumerator.Current is InLine){
					if((((InLine) enumerator.Current).LineBeginn<=pageEndLine)&&(((InLine) enumerator.Current).LineEnd>=pageBeginnLine)){ // shall the line be drawed
						// calculate the y start and end positon of the inline
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						lineBeginnLine = Math.Max(pageBeginnLine, ((InLine) enumerator.Current).LineBeginn); // first line on the page where inline shall be drawed
						lineEndLine = Math.Min(pageEndLine, ((InLine) enumerator.Current).LineEnd);			 // last line on the page where inline shall be drawed
						for (uint j=pageBeginnLine; j<lineBeginnLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						for (uint j=pageBeginnLine; j<=lineEndLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosEnd += mDiagramLines[j].Height+this.YItemOffset;
						}
						inLineSize = GetInLineSize(((InLine) enumerator.Current).Identifier); // get left and right position of the inline
						
						// shall top carry line be drawed
						if (((InLine) enumerator.Current).LineBeginn<pageBeginnLine){
							((InLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((InLine) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLine) enumerator.Current).ProcessEnd),inLineSize.Left, inLineSize.Right ,yPosStart-this.YItemOffset, TopMargin+HeadHeight+TOP_MARGIN_MSC);
							((InLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLine) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLine) enumerator.Current).ProcessEnd),inLineSize.Left, inLineSize.Right ,yPosStart-this.YItemOffset, yPosStart);
						}
						// shall bottom carry line be drawed
						if (((InLine) enumerator.Current).LineEnd>pageEndLine){
							((InLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLine) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLine) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right , yPosEnd-this.YItemOffset, ySize-10);
							((InLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((InLine) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLine) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right ,ySize-10, ySize);
						}
						// draw inline on the page
						((InLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((InLine) enumerator.Current).ProcessBeginn),GetInstanceXPos(((InLine) enumerator.Current).ProcessEnd),inLineSize.Left,inLineSize.Right ,yPosStart, yPosEnd-this.YItemOffset);						
					}
				}
			}
		}
		///<summary>
		/// draws measurement, timing and instance lines and carry lines
		/// </summary>
		/// <param name="drawDestination">drawing area</param>
		/// <param name="pageBeginnLine">first line of page</param>
		/// <param name="pageEndLine">last line of page</param>
		/// <param name="yPos">max top position to draw inline</param>
		/// <param name="ySize">height of the drawing area</param>
		/// <param name="worksheet">worksheet of the drawing area</param>
		public void DrawLines(Graphics drawDestination, uint pageBeginnLine, uint pageEndLine, float yPos, float ySize, Worksheet worksheet, uint page)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			float 	yPosStart, 				// y start position of the inline to draw
					yPosEnd,				// y end position of the inline to draw
					TopMargin 		= worksheet.TopMargin,	//top margin height of the worksheet
					yHelpTop		= this.YItemOffset;  // helps draw a top carry line
			uint 	lineBeginnLine, 		// first line of the inline to draw
					lineEndLine;			// last line of the inline to draw
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				yHelpTop = this.YItemOffset;
				if (enumerator.Current is ItemVerticalLine){
					if((((ItemVerticalLine) enumerator.Current).LineBeginn<=pageEndLine)&&(((ItemVerticalLine) enumerator.Current).LineEnd>=pageBeginnLine)){	// shall loopline be drawed on the page
						// calculate the vertical start and end position for the loopline
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						lineBeginnLine = Math.Max(pageBeginnLine, ((ItemVerticalLine) enumerator.Current).LineBeginn);
						lineEndLine = Math.Min(pageEndLine, ((ItemVerticalLine) enumerator.Current).LineEnd);
						if (pageBeginnLine <= lineBeginnLine) yPosStart += 10;
						for (uint j=pageBeginnLine; j<lineBeginnLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						for (uint j=pageBeginnLine; j<=lineEndLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosEnd += mDiagramLines[j].Height+this.YItemOffset;
						}
						// shall top carry line be drawed
						if (((ItemVerticalLine) enumerator.Current).LineBeginn<=pageBeginnLine){
							((ItemVerticalLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) ,yPosStart-20, yPosStart);
							yHelpTop = 0;
						}
						// shall bottom carry line be drawed
						if (((ItemVerticalLine) enumerator.Current).LineEnd>=pageEndLine){
							yPosEnd-=10;
							((ItemVerticalLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) , yPosEnd, ySize-10);
							((ItemVerticalLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) ,ySize-10, ySize);
						}
						// draw loopline
						((ItemVerticalLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) ,yPosStart-yHelpTop, yPosEnd);						
					}
					// shall top carry line be drawed
					if(((ItemVerticalLine) enumerator.Current).LineBeginn==(pageEndLine+1)){
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						lineBeginnLine = Math.Max(pageBeginnLine, ((ItemVerticalLine) enumerator.Current).LineBeginn);
						if (pageBeginnLine <= lineBeginnLine) yPosStart += 10;
						for (uint j=pageBeginnLine; j<=pageEndLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						((ItemVerticalLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) , yPosStart-this.YItemOffset, ySize-10);
						((ItemVerticalLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) ,ySize-10, ySize);					
					}
					// shall bottom carry line be drawed
					if(((ItemVerticalLine) enumerator.Current).LineEnd==(pageBeginnLine-1)){
						((ItemVerticalLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((ItemVerticalLine) enumerator.Current).Process) ,this.YProcessOffset, TopMargin+HeadHeight + TOP_MARGIN_MSC);				
					}
				}
				if (enumerator.Current is MeasureLine){
					if((((MeasureLine) enumerator.Current).LineBegin<=pageEndLine)&&(((MeasureLine) enumerator.Current).LineEnd>=pageBeginnLine)){
						// calculate the vertical start and end position for the measure line
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						lineBeginnLine = Math.Max(pageBeginnLine, ((MeasureLine) enumerator.Current).LineBegin);
						lineEndLine = Math.Min(pageEndLine, ((MeasureLine) enumerator.Current).LineEnd);
						for (uint j=pageBeginnLine; j<lineBeginnLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						for (uint j=pageBeginnLine; j<=lineEndLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosEnd += mDiagramLines[j].Height+this.YItemOffset;
						}
						// shall top carry line be drawed
						if (((MeasureLine) enumerator.Current).LineBegin<=pageBeginnLine){
							((MeasureLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) ,yPosStart-20, yPosStart);
							yHelpTop = 0;
						}
						else if(((MeasureLine) enumerator.Current).MeasureCapStyle==CapStyle.Inner){
							yHelpTop -=10;
						}
						// shall bottom carry line be drawed
						if (((MeasureLine) enumerator.Current).LineEnd>=pageEndLine){
							yPosEnd-=10;
							((MeasureLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) , yPosEnd, ySize-10);
							((MeasureLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) ,ySize-10, ySize);
						}
						// draw measure line
						((MeasureLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) ,yPosStart - yHelpTop, yPosEnd);						
					}
					// shall top carry line be drawed
					if(((MeasureLine) enumerator.Current).LineBegin==(pageEndLine+1)){
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						for (uint j=pageBeginnLine; j<=pageEndLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						((MeasureLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) , yPosStart-this.YItemOffset+10, ySize-10);
						((MeasureLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) ,ySize-10, ySize);					
					}
					// shall bottom carry line be drawed
					if(((MeasureLine) enumerator.Current).LineEnd==(pageBeginnLine-1)){
						((MeasureLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((MeasureLine) enumerator.Current).Process) ,this.YProcessOffset, TopMargin+HeadHeight + TOP_MARGIN_MSC);				
					}
				}
				if (enumerator.Current is MessageLine){
					if((((MessageLine) enumerator.Current).LineBeginn<=pageEndLine)&&(((MessageLine) enumerator.Current).LineEnd>=pageBeginnLine)){
						// calculate the vertical start and end position for the message line
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						lineBeginnLine = Math.Max(pageBeginnLine, ((MessageLine) enumerator.Current).LineBeginn);
						lineEndLine = Math.Min(pageEndLine, ((MessageLine) enumerator.Current).LineEnd);
						for (uint j=pageBeginnLine; j<lineBeginnLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						for (uint j=pageBeginnLine; j<=lineEndLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosEnd += mDiagramLines[j].Height+this.YItemOffset;
						}
						// shall top carry line be drawed
						if (((MessageLine) enumerator.Current).LineBeginn<pageBeginnLine){
							((MessageLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((MessageLine) enumerator.Current).MessageSource),GetInstanceXPos(((MessageLine) enumerator.Current).MessageDestination) ,yPosStart-20, yPosStart,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin);
							yHelpTop = 0;
						}
						// shall bottom carry line be drawed
						if (((MessageLine) enumerator.Current).LineEnd>pageEndLine){
							yPosEnd-=10;
							((MessageLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MessageLine) enumerator.Current).MessageSource),GetInstanceXPos(((MessageLine) enumerator.Current).MessageDestination) , yPosEnd-this.YItemOffset, ySize-10,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin);
							((MessageLine) enumerator.Current).DrawItemCarry(drawDestination,GetInstanceXPos(((MessageLine) enumerator.Current).MessageSource),GetInstanceXPos(((MessageLine) enumerator.Current).MessageDestination) ,ySize-10, ySize,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin);
						}
						// draw message line
						((MessageLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((MessageLine) enumerator.Current).MessageSource),GetInstanceXPos(((MessageLine) enumerator.Current).MessageDestination) ,yPosStart-yHelpTop, yPosEnd-this.YItemOffset,worksheet.LeftMargin,worksheet.Width-worksheet.RightMargin);						
					}
				}
				if (enumerator.Current is ProcessLine){
					if((((ProcessLine) enumerator.Current).LineBeginn<=pageEndLine)&&((((ProcessLine) enumerator.Current).LineEnd>=pageBeginnLine)||(((ProcessLine) enumerator.Current).LineEnd==0))){
						// calculate the vertical start and end position for the instance line
						yPosStart=this.YProcessOffset;
						yPosEnd=this.YProcessOffset;
						lineBeginnLine = Math.Max(pageBeginnLine, ((ProcessLine) enumerator.Current).LineBeginn);
						lineEndLine = Math.Min(pageEndLine, ((ProcessLine) enumerator.Current).LineEnd);
						for (uint j=pageBeginnLine; j<=lineBeginnLine; j++){
							if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosStart += mDiagramLines[j].Height+this.YItemOffset;
						}
						if ((((ProcessLine) enumerator.Current).LineEnd>pageEndLine) ||(((ProcessLine) enumerator.Current).LineEnd==0))
						    yPosEnd = ySize;
						else{
							for (uint j=pageBeginnLine; j<=lineEndLine; j++){
								if (mDiagramLines[j].Height != MSCItem.NEW_PAGE) yPosEnd += mDiagramLines[j].Height+this.YItemOffset;
							}
							yPosEnd -=this.YItemOffset;
						}
						// shall the instance head be drawed on top of the page
						if (((ProcessLine) enumerator.Current).LineBeginn<pageBeginnLine){
							((ProcessLine) enumerator.Current).DrawProcessHead(drawDestination, GetInstanceXPos(((ProcessLine) enumerator.Current).ProcessIndex) ,this.mYProcessName,this.mProcessNameHeight,this.mInstanceNameHeight,yPosEnd, page);
						}
						// shall the instance line be drawed to end of page
						else if ((((ProcessLine) enumerator.Current).LineEnd>=pageEndLine)||(((ProcessLine) enumerator.Current).LineEnd==0)){
							((ProcessLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ProcessLine) enumerator.Current).ProcessIndex) , yPosStart-this.YItemOffset, yPosEnd);
						}
						// shall the instance line be drawed only inside the actual page
						else if ((((ProcessLine) enumerator.Current).LineEnd<=pageEndLine)&&(((ProcessLine) enumerator.Current).LineBeginn>=pageBeginnLine)){
							((ProcessLine) enumerator.Current).DrawItem(drawDestination,GetInstanceXPos(((ProcessLine) enumerator.Current).ProcessIndex) , yPosStart-this.YItemOffset, yPosEnd);							
						}
					}
				}
			}
		}
		/// <summary>
		/// returns the style of the lifeline
		/// </summary>
		/// <param name="process">number of process</param>
		/// <param name="line">line number of diagram line</param>
		/// <returns>Normal|Activation|Suspension|Coregion</returns>
		private ProcessStyle GetLifeLineStyle(int process, uint line)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if (enumerator.Current is ProcessLine){
					if((((ProcessLine) enumerator.Current).ProcessIndex == process) && (((ProcessLine) enumerator.Current).LineBeginn<=line)&&((((ProcessLine) enumerator.Current).LineEnd>line)||(((ProcessLine) enumerator.Current).LineEnd==0))){
						return ((ProcessLine) enumerator.Current).ProcessStyle;
					}
					if((((ProcessLine) enumerator.Current).ProcessIndex == process) && (((ProcessLine) enumerator.Current).LineBeginn==line+1)){
						return ((ProcessLine) enumerator.Current).ProcessStyle;
					}
				}
			}
			return ProcessStyle.Normal;
		}
		
		/// <summary>
		/// draws an acception on the drawing area
		/// </summary>
		/// <param name="drawDestination">drawin area</param>
		/// <param name="result">acception of generating proces</param>
		/// <returns>nothing</returns>
		private void DrawError(Graphics drawDestination, GeneratorResult result)
		{
			Icon icon1 = new Icon(SystemIcons.Exclamation, 12, 12);
			RectangleF textBox = new RectangleF(40, 10, 300, 300);
			StringFormat stringFormat = new StringFormat();
			switch(result){
				case GeneratorResult.InstanceSpaceToSmall:
					drawDestination.DrawIcon(icon1,10,10);
					drawDestination.DrawString("Die Breite des Diagramms ist nicht ausreichend zum Darstellen aller Instanzen",new Font("Arial",10),Brushes.Black,textBox,stringFormat);
					break;
			}
		}
	}
}
