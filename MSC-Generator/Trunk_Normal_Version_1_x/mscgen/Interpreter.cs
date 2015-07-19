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
 * User: Koto
 * Date: 20.06.2005
 * Time: 09:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Resources;
using mscElements;
using GeneratorGUI;

namespace nGenerator
{
	/// <summary>
	/// Description of Interpreter.
	/// </summary>
	public enum InterpretResult{
		Ok,
		UnknownCommand,
		UnknownParameter,
		WrongParameterNumber,
		ParameterOutOfRange,
		InstanceNotFound,
		LineAllreadyExists,
		LineNotExists,
		IdentifierNotFound,
	}
	
	public struct InterpretException{
		
		public InterpretResult 		result;
		public uint 				exceptionLine;
		public uint 				exceptionParameter;
		public string 				exceptionCommand;
		
		public InterpretException(InterpretResult result, uint exceptionLine, uint exceptionParameter, string exceptionCommand)
		{
			this.result 				= result;
			this.exceptionCommand 		= exceptionCommand;
			this.exceptionLine 			= exceptionLine;
			this.exceptionParameter 	= exceptionParameter;
		}
		public InterpretException(InterpretResult result, uint exceptionLine, string exceptionCommand)
		{
			this.result 				= result;
			this.exceptionCommand 		= exceptionCommand;
			this.exceptionLine 			= exceptionLine;
			this.exceptionParameter 	= 0;
		}
		public InterpretException(InterpretResult result, uint exceptionLine)
		{
			this.result 				= result;
			this.exceptionCommand 		= "";
			this.exceptionLine 			= exceptionLine;
			this.exceptionParameter 	= 0;
		}
		public string Message 
		{
			get 
			{
				ResourceManager strings = new ResourceManager (nGenerator.Output.stringResources, Assembly.GetAssembly(typeof(Interpreter)));
				string exceptionText = "";
				switch (result){
					case InterpretResult.IdentifierNotFound:
						exceptionText += strings.GetString("Interpretator.IdentifierNotFound");
						break;
					case InterpretResult.InstanceNotFound:
						exceptionText += strings.GetString("Interpreter.InstanceNotFound");
						break;
					case InterpretResult.LineAllreadyExists:
						exceptionText += strings.GetString("Interpreter.LineAllreadyExists");
						break;
					case InterpretResult.LineNotExists:
						exceptionText += strings.GetString("Interpreter.LineNotExists");
						break;
					case InterpretResult.ParameterOutOfRange:
						exceptionText += string.Format(strings.GetString("Interpreter.ParameterOutOfRange"), exceptionParameter);
						break;
					case InterpretResult.UnknownCommand:
						exceptionText += string.Format(strings.GetString("Interpreter.UnknownCommand"), exceptionCommand);
						break;
					case InterpretResult.UnknownParameter:
						exceptionText += "Unbekannter Parameter " + exceptionParameter;
						break;
					case InterpretResult.WrongParameterNumber:
						exceptionText += string.Format(strings.GetString("Interpreter.WrongParameterNumber"), exceptionCommand, exceptionParameter);
						break;
				}
				return exceptionText;
			}
		}
	}
	public partial class Interpreter
	{
		private ArrayList 			interpretExceptions;
		private bool nl 			= false;
		private bool sameline 		= false;

		public Interpreter()
		{
			interpretExceptions 	= new ArrayList();
		}

		
		#region interpreter for new sc files
		public InterpretException[] InterpretFile(string filename, Generator generator, Output output)
		{
			string s 					= String.Empty;
			StreamReader sr 			= new StreamReader(@filename, Encoding.Default);
			uint line					=1;
			uint fileLine				=0;
			interpretExceptions.Clear();
			output.SetWorksheetWidth(1000.0f,Worksheet.WS_UNIT_PICSEL);
			output.SetWorksheetHeight(1000.0f,Worksheet.WS_UNIT_PICSEL); 
			sameline=false;
			do{
				s = sr.ReadLine();
				fileLine++;
				nl=false;
				if (s!=null){
					line = InterpretLine(s, line, fileLine, generator, output);
				}
			}while (s!=null);
			generator.addMSCEnd(line);
			sr.Close();
			if (interpretExceptions.Count>0){
				return (InterpretException[]) interpretExceptions.ToArray(typeof(InterpretException));
			}
			return null;
		}
		private uint InterpretLine(string s, uint line, uint fileLine, Generator generator, Output output)
		{
			string[] entities 			= new string[]{String.Empty};
			InterpretResult result 		= InterpretResult.Ok;
			bool startsameline			= false;
			
			s=s.Replace('\t',' ');
			s=s.Replace(@"\n","\n");
			s=s.Replace("\\\n", @"\n");
			if (s != ""){
				s=s.Trim();
				entities = this.SplitDiagramTextLine(s);
				if (entities.Length > 0){
					entities[0] = entities[0].Replace(" ","");
					entities[0] = entities[0].Replace("\t","");
					switch (entities[0].ToUpper()){
						case "":					// control character
							if (entities.Length > 1){
								if(entities[1]=="{")
									startsameline=true;
								if(entities[1]=="}"){
									line++;
									nl=true;
									sameline=false;
								}
							}
							break;
						case "}":
							sameline=false;
							break;
						case "AUTHOR":
							if (entities.Length>=2){
								Worksheet.Author = entities[1];
							}
							else{
								Worksheet.Author ="";
							}
							break;
						case "COMPANY":
							if (entities.Length>=2){
								Worksheet.Company = entities[1];
							}
							else{
								Worksheet.Company = "";
							}
							break;
						case "VERSION":
							if (entities.Length>=2){
								Worksheet.Version = entities[1];
							}
							else{
								Worksheet.Version = "";
							}
							break;
						case "DATE":
							if (entities.Length>=2){
								Worksheet.Date = entities[1];
							}
							else{
								Worksheet.Date = "";
							}
							break;
						case "PRINTAUTHOR":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawAuthor =true;
										break;
									case "NO":
										Worksheet.DrawAuthor =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PRINTCOMPANY":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawCompany =true;
										break;
									case "NO":
										Worksheet.DrawCompany =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PRINTVERSION":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawVersion =true;
										break;
									case "NO":
										Worksheet.DrawVersion =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PRINTDATE":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawPrintDate =true;
										break;
									case "NO":
										Worksheet.DrawPrintDate =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PRINTCREATIONDATE":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawPrintDate =true;
										break;
									case "NO":
										Worksheet.DrawPrintDate =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PRINTFILENAME":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawFileName =true;
										break;
									case "NO":
										Worksheet.DrawFileName =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PRINTFOOTLINE":
							if (entities.Length>=2){
								switch(entities[1].Trim().ToUpper()){
									case "YES":
										Worksheet.DrawFootLine =true;
										break;
									case "NO":
										Worksheet.DrawFootLine =false;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "DIAGRAMNAME":
						case "MSCNAME":
							if (entities.Length>=2){
								generator.AddHead(entities[1]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "LINEOFFSET":
							if (entities.Length>=2){
								byte tmp=0;
								try{
									tmp = System.Byte.Parse(entities[1]);
									if ((tmp >=1)&&(tmp<=100))
										generator.AddVerticalOffset(tmp);
									else
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));					
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "DIAGRAMSTYLE":
						case "MSCSTYLE":
							if (entities.Length>=2){
								switch(entities[1].ToUpper()){
									case "UML":
										output.SetMscStyle(MscStyle.UML2);
										break;
									case "SDL":
										output.SetMscStyle(MscStyle.SDL);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
								}	
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PAGESIZE":
							Output.AutosizeOutputHeight = false;
							Output.AutosizeOutputWidth = false;
							if (entities.Length>=4){
								double width=0, height=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									width = System.Double.Parse(entities[1]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									break;
								}
								try{
									height = System.Double.Parse(entities[2]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
									break;
								}
								switch(entities[3].ToUpper()){
									case "MM":
										unit=Worksheet.WS_UNIT_MM;
										break;
									case "CM":
										unit=Worksheet.WS_UNIT_CM;
										break;
									case "INCH":
										unit=Worksheet.WS_UNIT_INCH;
										break;
									case "PIXEL":
										unit=Worksheet.WS_UNIT_PICSEL;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
										break;
								}
								if (!output.SetWorksheetWidth((float)width,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								if (!output.SetWorksheetHeight((float)height,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
							}
							else if (entities.Length==3){
								double width=0, height=0;
								switch (entities[1].ToUpper()){
									case "A0":
										switch(entities[2].ToUpper()){
											case "HORIZONTAL":
											case "H":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A0_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											case "VERTICAL":
											case "V":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A0_ISO,Worksheet.WS_LAYOUT_VERTICAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											default:
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
												break;
										}
										break;
									case "A1":
										switch(entities[2].ToUpper()){
											case "HORIZONTAL":
											case "H":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A1_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											case "VERTICAL":
											case "V":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A1_ISO,Worksheet.WS_LAYOUT_VERTICAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											default:
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
												break;
										}
										break;
									case "A2":
										switch(entities[2].ToUpper()){
											case "HORIZONTAL":
											case "H":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A2_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											case "VERTICAL":
											case "V":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A2_ISO,Worksheet.WS_LAYOUT_VERTICAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											default:
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
												break;
										}
										break;
									case "A3":
										switch(entities[2].ToUpper()){
											case "HORIZONTAL":
											case "H":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A3_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											case "VERTICAL":
											case "V":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A3_ISO,Worksheet.WS_LAYOUT_VERTICAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											default:
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
												break;
										}
										break;
									case "A4":
										switch(entities[2].ToUpper()){
											case "HORIZONTAL":
											case "H":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A4_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											case "VERTICAL":
											case "V":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A4_ISO,Worksheet.WS_LAYOUT_VERTICAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											default:
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
												break;
										}
										break;
									case "A5":
										switch(entities[2].ToUpper()){
											case "HORIZONTAL":
											case "H":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A5_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											case "VERTICAL":
											case "V":
												if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A5_ISO,Worksheet.WS_LAYOUT_VERTICAL)) 
													interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
												break;
											default:
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
												break;
										}
										break;
									default:
										if (entities[1].Trim().ToUpper()=="AUTO"){
											width = 500;
											Output.AutosizeOutputWidth = true;
										}
										else{
											try{
												width = System.Double.Parse(entities[1]);
											}
											catch{
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
												break;
											}
										}
										if (entities[2].Trim().ToUpper()=="AUTO"){
											height = 1000;
											Output.AutosizeOutputHeight = true;
										}
										else{
											try{
												height = System.Double.Parse(entities[2]);
											}
											catch{
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
												break;
											}
										}
										if (!output.SetWorksheetWidth((float)width,Worksheet.WS_UNIT_PICSEL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										if (!output.SetWorksheetHeight((float)height,Worksheet.WS_UNIT_PICSEL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
										break;
								}
							}
							else if (entities.Length==2){
								switch (entities[1].Trim().ToUpper()){
									case "A0":
										if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A0_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
									case "A1":
										if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A1_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
									case "A2":
										if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A2_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
									case "A3":
										if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A3_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
									case "A4":
										if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A4_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
									case "A5":
										if (!output.SetWorksheetSize(Worksheet.WS_SIZE_A5_ISO,Worksheet.WS_LAYOUT_HORIZONTAL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										break;
									case "AUTO":
										Output.AutosizeOutputHeight = true;
										Output.AutosizeOutputWidth = true;
										if (!output.SetWorksheetWidth(500.0f,Worksheet.WS_UNIT_PICSEL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
										if (!output.SetWorksheetHeight(500.0f,Worksheet.WS_UNIT_PICSEL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
										break;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "MSCWIDTH":
							Output.AutosizeOutputWidth = false;
							if (entities.Length>=3){
								double tmp=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									tmp = System.Double.Parse(entities[1]);
									switch(entities[2].ToUpper()){
										case "MM":
											unit=Worksheet.WS_UNIT_MM;
											break;
										case "CM":
											unit=Worksheet.WS_UNIT_CM;
											break;
										case "INCH":
											unit=Worksheet.WS_UNIT_INCH;
											break;
										case "PIXEL":
											unit=Worksheet.WS_UNIT_PICSEL;
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
											break;
									}
									if (!output.SetWorksheetWidth((float)tmp,unit)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else if (entities.Length==2){
								double tmp=0;
								if (entities[1].Trim().ToUpper()=="AUTO"){
									Output.AutosizeOutputHeight = true;
								}
								else{
									try{
										tmp = System.Double.Parse(entities[1]);
										if (!output.SetWorksheetWidth((float)tmp,Worksheet.WS_UNIT_PICSEL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									}
									catch{
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
									}
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MSCHEIGHT":
							Output.AutosizeOutputHeight = false;
							if (entities.Length>=3){
								double tmp=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									tmp = System.Double.Parse(entities[1]);
									switch(entities[2].ToUpper()){
										case "MM":
											unit=Worksheet.WS_UNIT_MM;
											break;
										case "CM":
											unit=Worksheet.WS_UNIT_CM;
											break;
										case "INCH":
											unit=Worksheet.WS_UNIT_INCH;
											break;
										case "PIXEL":
											unit=Worksheet.WS_UNIT_PICSEL;
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
											break;
									}
									if (!output.SetWorksheetHeight((float)tmp,unit)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else if (entities.Length==2){
								double tmp=0;
								if (entities[1].Trim().ToUpper()=="AUTO"){
									Output.AutosizeOutputHeight = true;
								}
								else{
									try{
										tmp = System.Double.Parse(entities[1]);
										if (!output.SetWorksheetHeight((float)tmp,Worksheet.WS_UNIT_PICSEL)) 
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									}
									catch{
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
									}
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "PAGEMARGINS":
							if (entities.Length>=6){
								double left=0, right=0, top=0, bottom=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									left = System.Double.Parse(entities[1]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									break;
								}
								try{
									top = System.Double.Parse(entities[2]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
									break;
								}
								try{
									right = System.Double.Parse(entities[3]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
									break;
								}
								try{
									bottom = System.Double.Parse(entities[4]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
									break;
								}
								switch(entities[5].ToUpper()){
									case "MM":
										unit=Worksheet.WS_UNIT_MM;
										break;
									case "CM":
										unit=Worksheet.WS_UNIT_CM;
										break;
									case "INCH":
										unit=Worksheet.WS_UNIT_INCH;
										break;
									case "PIXEL":
										unit=Worksheet.WS_UNIT_PICSEL;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));
										break;
								}
								if (!output.SetWorksheetLeftMargin((float)left,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								if (!output.SetWorksheetTopMargin((float)top,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
								if (!output.SetWorksheetRightMargin((float)right,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
								if (!output.SetWorksheetBottomMargin((float)bottom,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));								
							}
							else if (entities.Length==5){
								double left=0, right=0, top=0, bottom=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									left = System.Double.Parse(entities[1]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									break;
								}
								try{
									top = System.Double.Parse(entities[2]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
									break;
								}
								try{
									right = System.Double.Parse(entities[3]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
									break;
								}
								try{
									bottom = System.Double.Parse(entities[4]);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
									break;
								}
								if (!output.SetWorksheetLeftMargin((float)left,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								if (!output.SetWorksheetTopMargin((float)top,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
								if (!output.SetWorksheetRightMargin((float)right,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
								if (!output.SetWorksheetBottomMargin((float)bottom,unit)) 
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));								
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,4,entities[0]));
							}
							break;							
						case "MSCMARGINLEFT":
							if (entities.Length>=3){
								double tmp=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									tmp = System.Double.Parse(entities[1]);
									switch(entities[2].ToUpper()){
										case "MM":
											unit=Worksheet.WS_UNIT_MM;
											break;
										case "CM":
											unit=Worksheet.WS_UNIT_CM;
											break;
										case "INCH":
											unit=Worksheet.WS_UNIT_INCH;
											break;
										case "PIXEL":
											unit=Worksheet.WS_UNIT_PICSEL;
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
											break;
									}
									if (!output.SetWorksheetLeftMargin((float)tmp,unit)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else if (entities.Length==2){
								double tmp=0;
								try{
									tmp = System.Double.Parse(entities[1]);
									if (!output.SetWorksheetLeftMargin((float)tmp,Worksheet.WS_UNIT_PICSEL)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MSCMARGINRIGHT":
							if (entities.Length>=3){
								double tmp=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									tmp = System.Double.Parse(entities[1]);
									switch(entities[2].ToUpper()){
										case "MM":
											unit=Worksheet.WS_UNIT_MM;
											break;
										case "CM":
											unit=Worksheet.WS_UNIT_CM;
											break;
										case "INCH":
											unit=Worksheet.WS_UNIT_INCH;
											break;
										case "PIXEL":
											unit=Worksheet.WS_UNIT_PICSEL;
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
											break;
									}
									if (!output.SetWorksheetRightMargin((float)tmp,unit)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else if (entities.Length==2){
								double tmp=0;
								try{
									tmp = System.Double.Parse(entities[1]);
									if (!output.SetWorksheetRightMargin((float)tmp,Worksheet.WS_UNIT_PICSEL)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "LANGUAGE":
							if (entities.Length>=2){
								System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(entities[1]);
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MSCMARGINTOP":
							if (entities.Length>=3){
								double tmp=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									tmp = System.Double.Parse(entities[1]);
									switch(entities[2].ToUpper()){
										case "MM":
											unit=Worksheet.WS_UNIT_MM;
											break;
										case "CM":
											unit=Worksheet.WS_UNIT_CM;
											break;
										case "INCH":
											unit=Worksheet.WS_UNIT_INCH;
											break;
										case "PIXEL":
											unit=Worksheet.WS_UNIT_PICSEL;
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
											break;
									}
									if (!output.SetWorksheetTopMargin((float)tmp,unit)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else if (entities.Length==2){
								double tmp=0;
								try{
									tmp = System.Double.Parse(entities[1]);
									if (!output.SetWorksheetTopMargin((float)tmp,Worksheet.WS_UNIT_PICSEL)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
//									else
//										output.RedrawRescaled();
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MSCMARGINBOTTOM":
							if (entities.Length>=3){
								double tmp=0;
								byte unit=Worksheet.WS_UNIT_PICSEL;
								try{
									tmp = System.Double.Parse(entities[1]);
									switch(entities[2].ToUpper()){
										case "MM":
											unit=Worksheet.WS_UNIT_MM;
											break;
										case "CM":
											unit=Worksheet.WS_UNIT_CM;
											break;
										case "INCH":
											unit=Worksheet.WS_UNIT_INCH;
											break;
										case "PIXEL":
											unit=Worksheet.WS_UNIT_PICSEL;
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
											break;
									}
									if (!output.SetWorksheetBottomMargin((float)tmp,unit)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
//									else
//										output.RedrawRescaled();
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else if (entities.Length==2){
								double tmp=0;
								try{
									tmp = System.Double.Parse(entities[1]);
									if (!output.SetWorksheetBottomMargin((float)tmp,Worksheet.WS_UNIT_PICSEL)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
//									else
//										output.RedrawRescaled();
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "LEFT":
							if (entities.Length >= 2){
								uint left=0;
								try{
									left = System.UInt32.Parse(entities[1]);
									if (!generator.SetMSCLeft(left)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "RIGHT":
							if (entities.Length >= 2){
								uint right=0;
								try{
									right = System.UInt32.Parse(entities[1]);
									if (!generator.SetMSCRight(right)) 
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "BACKCOLOR":
							if (entities.Length>=2){
								if (entities[1].Trim().ToUpper()=="NONE"){
									entities[1] = "White";
								}	
								Color mc = GetColorByString(entities[1]);
								if (mc==Color.Empty){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
								else{
									generator.SetBackColor(mc);	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "FILLCOLOR":
							if (entities.Length>=2){
								if (entities[1].Trim().ToUpper()=="NONE"){
									entities[1] = "White";
								}
								Color mc = GetColorByString(entities[1]);
								if (mc==Color.Empty){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
								else{
									generator.SetFillColor(mc);	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "TEXTCOLOR":
							if (entities.Length>=2){
								if (entities[1].Trim().ToUpper()=="NONE"){
									entities[1] = "Black";
								}
								Color mc = GetColorByString(entities[1]);
								if (mc==Color.Empty){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));	
								}
								else{
									generator.SetTextColor(mc);	
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "FONT":
							double fsize = 10.0f;
							System.Drawing.FontStyle fstyle = System.Drawing.FontStyle.Regular;
							FontFamily ff = null;
							if (entities.Length>=4){
								ff = this.GetFontFamilyByName(entities[1]);
								if (ff==null){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									break;
								}
								if ((entities[2].Trim()) != ""){
									try{
										fsize = System.Double.Parse(entities[2].Replace('.',','));
									}
									catch{
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
										break;
									}
								}
								if ((fsize > 20) || (fsize<6)){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
									break;									
								}
								entities[3] = entities[3].ToUpper().Trim();
								string[] styles = entities[3].Split(' ');
								foreach(string style in styles){
									switch(style.Trim()){
										case "REGULAR":
											fstyle |= System.Drawing.FontStyle.Regular;
											break;
										case "BOLD":
											fstyle |= System.Drawing.FontStyle.Bold;
											break;
										case "ITALIC":
											fstyle |= System.Drawing.FontStyle.Italic;
											break;
										case "STRIKEOUT":
											fstyle |= System.Drawing.FontStyle.Strikeout;
											break;
										case "UNDERLINE":
											fstyle |= System.Drawing.FontStyle.Underline;
											break;
										default:
											if(style.Length >0)
												interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));	
											break;
									}
								}
								try{
									MSCItem.ItemFont = new Font(ff,(float)fsize,fstyle);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
								}
							}
							else if (entities.Length==3){
								ff = this.GetFontFamilyByName(entities[1]);
								if (ff==null){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									break;
								}
								if ((entities[2].Trim()) != ""){
									try{
										fsize = System.Double.Parse(entities[2].Replace('.',','));
									}
									catch{
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
										break;
									}
								}
								if ((fsize > 20) || (fsize<6)){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
									break;									
								}
								MSCItem.ItemFont = new Font(ff,(float)fsize,fstyle);
							}
							else if (entities.Length==2){
								ff = this.GetFontFamilyByName(entities[1]);
								if (ff==null){
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,1,entities[0]));
									break;
								}
								MSCItem.ItemFont = new Font(ff,(float)fsize,fstyle);
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));								
							}
							break;
						case "ACTOR":
							if (entities.Length==3){
								generator.AddProcess(fileLine, entities[1], entities[2], Brushes.Black,0,ProcessType.Actor,0,0);										
							}
							else if (entities.Length==4){
								generator.AddProcess(fileLine, entities[1], entities[2], entities[3], Brushes.Black,0,ProcessType.Actor,0,0);
							}
							else if (entities.Length==5){
								uint leftRand;
								try{
									if(entities[4]=="") entities[4]="0";
									leftRand = System.UInt16.Parse(entities[4]);
									if (leftRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
										break;
									}
									generator.AddProcess(fileLine, entities[1], entities[2], entities[3], Brushes.Black,0,ProcessType.Actor,leftRand,0);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));	
								}
							}
							else if (entities.Length>=6){
								uint leftRand, rightRand;
								try{
									if(entities[4]=="") entities[4]="0";
									leftRand = System.UInt16.Parse(entities[4]);
									if (leftRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
										break;
									}
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));	
									break;
								}
								try{
									if(entities[5]=="") entities[5]="0";
									rightRand = System.UInt16.Parse(entities[5]);
									if (rightRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));
										break;
									}
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));	
									break;
								}
								generator.AddProcess(fileLine, entities[1], entities[2], entities[3], Brushes.Black,0,ProcessType.Actor,leftRand,rightRand);
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "PROCESS":
							if (entities.Length==3){
								generator.AddProcess(fileLine, entities[1], entities[2], Brushes.Black,0,0,0);
							}
							else if (entities.Length==4){
								generator.AddProcess(fileLine, entities[1], entities[2], entities[3], Brushes.Black,0,0,0);
							}
							else if (entities.Length==5){
								uint leftRand;
								try{
									if(entities[4]=="") entities[4]="0";
									leftRand = System.UInt16.Parse(entities[4]);
									if (leftRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
										break;
									}
									generator.AddProcess(fileLine, entities[1], entities[2], entities[3], Brushes.Black,0,ProcessType.Normal,leftRand,0);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));	
								}
							}
							else if (entities.Length>=6){
								uint leftRand, rightRand;
								try{
									if(entities[4]=="") entities[4]="0";
									leftRand = System.UInt16.Parse(entities[4]);
									if (leftRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
										break;
									}
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));	
									break;
								}
								try{
									if(entities[5]=="") entities[5]="0";
									rightRand = System.UInt16.Parse(entities[5]);
									if (rightRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));
										break;
									}
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));	
									break;
								}
								generator.AddProcess(fileLine, entities[1], entities[2], entities[3], Brushes.Black,0,ProcessType.Normal,leftRand,rightRand);
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "DUMMYPROCESS":
							if (entities.Length==2){
								generator.AddProcess(fileLine, entities[1], Brushes.Black,0, ProcessType.Dummy, 0,0);
							}
							else if (entities.Length==3){
								uint leftRand;
								try{
									if(entities[2]=="") entities[2]="0";
									leftRand = System.UInt16.Parse(entities[2]);
									if (leftRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
										break;
									}
									generator.AddProcess(fileLine, entities[1], Brushes.Black,0, ProcessType.Dummy,leftRand,0);
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
								}
							}
							else if (entities.Length>=4){
								uint leftRand, rightRand;
								try{
									if(entities[2]=="") entities[2]="0";
									leftRand = System.UInt16.Parse(entities[2]);
									if (leftRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
										break;
									}
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));	
									break;
								}
								try{
									if(entities[3]=="") entities[3]="0";
									rightRand = System.UInt16.Parse(entities[3]);
									if (rightRand > 200){
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
										break;
									}
								}
								catch{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));	
									break;
								}
								generator.AddProcess(fileLine, entities[1], Brushes.Black,0,ProcessType.Dummy,leftRand,rightRand);
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "STOP":
							if (entities.Length>=2){
								result = generator.addProcessStop(fileLine, entities[1], line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "CREATE":
							if (entities.Length==5){
								result=generator.addProcessCreate(fileLine, entities[1], entities[2], line, entities[3],entities[4]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length>=6){
								result=generator.addProcessCreate(fileLine, entities[1], entities[2], line, entities[3], entities[4],entities[5]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,4,entities[0]));
							}
							break;
						case "TASK":
							if (entities.Length>=4){
								switch (entities[3].ToLower()){
									case "b":
										result=generator.AddTask(fileLine,entities[1],line,entities[2], ItemPos.Bottom);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "t":
										result=generator.AddTask(fileLine,entities[1],line,entities[2], ItemPos.Top);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddTask(fileLine, entities[1],line,entities[2], ItemPos.Top);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "MARK":
							if (entities.Length>=4){
								switch (entities[3].Trim()){
									//TopLeft:
									case "tl":		// top-left
									case "lt":		// left-top
									case "l":		// left
									case "t":		// top
										result=generator.addMscMark(fileLine, entities[1],line,entities[2], MarkPos.TopLeft);
										break;
									//TopRight:
									case "tr":		// top-right
									case "rt":		// right-top
									case "r":		// right
										result=generator.addMscMark(fileLine, entities[1],line,entities[2], MarkPos.TopRight);
										break;
									//BottomLeft:
									case "b":		// bottom
									case "bl":		// bottom-left
									case "lb":		// left-bottom
										result=generator.addMscMark(fileLine, entities[1],line,entities[2], MarkPos.BottomLeft);
										break;
									//BottomRight:
									case "br":		// bottom-right
									case "rb":		// right-bottom
										result=generator.addMscMark(fileLine, entities[1],line,entities[2], MarkPos.BottomRight);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addMscMark(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "STATE":
							if (entities.Length>=5){
								ItemPos pos= ItemPos.Top;
								switch (entities[4]){
									case "t":
										pos = ItemPos.Top;
										break;
									case "b":
										pos = ItemPos.Bottom;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
										break;
								}
								switch (entities[3]){
									case"-":
									case"":
										result=generator.AddState(fileLine, entities[1].Split(','),line,entities[2], StateStyle.Box, pos);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "*":
										result=generator.AddState(fileLine, entities[1].Split(','),line,entities[2], StateStyle.Bracket, pos);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
										break;
								}								
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								switch (entities[3]){
									case "*":
										result=generator.AddState(fileLine, entities[1].Split(','),line,entities[2], StateStyle.Bracket, ItemPos.Top);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "-":
									case "t":
										result=generator.AddState(fileLine, entities[1].Split(','),line,entities[2], StateStyle.Box, ItemPos.Top);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "b":
										result=generator.AddState(fileLine, entities[1].Split(','),line,entities[2], StateStyle.Box, ItemPos.Bottom);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[0]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddState(fileLine, entities[1].Split(','),line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "STATEOVERALL":
							if (entities.Length>=3){
								ItemPos pos= ItemPos.Top;
								switch (entities[2]){
									case "t":
										pos = ItemPos.Top;
										break;
									case "b":
										pos = ItemPos.Bottom;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
										break;
								}
								result=generator.AddState(fileLine, line,entities[1],pos);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.AddState(fileLine, line,entities[1], ItemPos.Top);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MSG":
							if (entities.Length==4){
								result = generator.AddMessage(fileLine,entities[1],entities[2],line,entities[3]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length>=5){
								switch (entities[4]){
									case "*":
										result=generator.AddMessage(fileLine,entities[1],entities[2],line,entities[3],MessageStyle.Dashed);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "!":
										result=generator.AddMessage(fileLine,entities[1],entities[2],line,entities[3],MessageStyle.Synchron);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "+":
										result=generator.AddMessage(fileLine,entities[1],entities[2],line,entities[3],MessageStyle.Normal);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,3,entities[0]));
							}
							break;
						case "MSGBEGIN":
							if (entities.Length==5){
								result = generator.addMessageBeginn(fileLine, entities[1],entities[2],entities[3],line,entities[4]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length>=6){
								switch (entities[5]){
									case "*":
										result = generator.addMessageBeginn(fileLine, entities[1],entities[2],entities[3],line,entities[4],MessageStyle.Dashed);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "!":
										result=generator.addMessageBeginn(fileLine, entities[1],entities[2],entities[3],line,entities[4],MessageStyle.Synchron);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "+":
										result=generator.addMessageBeginn(fileLine, entities[1],entities[2],entities[3],line,entities[4],MessageStyle.Normal);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,4,entities[0]));
							}
							break;
						case "MSGEND":
							if (entities.Length>=2){
								result=generator.addMessageEnd(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "COMMENTOVERALL":
							if (entities.Length>=2){
								result = generator.AddComment2(fileLine, line,entities[1], CommentPos.OverAll);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "COMMENT":
							if (entities.Length>=4){
								switch (entities[3].Trim()){
									case "l":
										result = generator.AddComment2(fileLine, line,entities[2],entities[1], CommentPos.Left);
										break;
									case "r":
										result = generator.AddComment2(fileLine, line,entities[2],entities[1], CommentPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[2]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result = generator.AddComment2(fileLine, line, entities[2], entities[1]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "SIDECOMMENT":
							if (entities.Length>=3){
								switch (entities[2].Trim()){
									case "l":
										result = generator.AddComment2(fileLine, line,entities[1],"ENV_LEFT", CommentPos.Left);
										break;
									case "r":
										result = generator.AddComment2(fileLine, line,entities[1],"ENV_RIGHT",CommentPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[2]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if(entities.Length==2){
								result = generator.AddComment2(fileLine, line, entities[1],"ENV_LEFT");
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;									
						case "LINECOMMENT":
							if (entities.Length>=5){
								bool l = true;
								if (entities[4]=="*"){
									l = false;
								}
								else if (entities[4] == "-"){
									l = true;
								}
								else{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
								}
								switch (entities[3].Trim()){
									case "l":
										result = generator.AddLineComment(fileLine, entities[1],line,entities[2],CommentPos.Left,l);
										break;
									case "":
										result = generator.AddLineComment(fileLine, entities[1],line,entities[2],CommentPos.Left,l);
										break;
									case "r":
										result = generator.AddLineComment(fileLine, entities[1],line,entities[2],CommentPos.Right,l);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}										
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								switch (entities[3].Trim()){
									case "l":
										result = generator.AddLineComment(fileLine, entities[1],line,entities[2],CommentPos.Left);
										break;
									case "r":
										result = generator.AddLineComment(fileLine, entities[1],line,entities[2],CommentPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if(entities.Length==3){
								result = generator.AddLineComment( fileLine, entities[1], line,entities[2]);
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;									
						case "SETTIMER":
							if (entities.Length>=4){
								switch (entities[3].Trim()){
									case "l":
										result = generator.AddSetTimer(fileLine, entities[1],line,entities[2],ItemPos.Left);
										break;
									case "r":
										result = generator.AddSetTimer(fileLine, entities[1],line,entities[2],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}										
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddSetTimer(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.AddSetTimer(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "TIMEOUT":
							if (entities.Length>=4){
								switch (entities[3].Trim()){
									case "l":
										result = generator.AddTimeOut(fileLine, entities[1],line,entities[2],ItemPos.Left);
										break;
									case "r":
										result = generator.AddTimeOut(fileLine, entities[1],line,entities[2],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}										
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddTimeOut(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.AddTimeOut(fileLine, entities[1], line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "STOPTIMER":
							if (entities.Length>=4){
								switch (entities[3].Trim()){
									case "l":
										result = generator.AddStopTimer(fileLine, entities[1],line,entities[2],ItemPos.Left);
										break;
									case "r":
										result = generator.AddStopTimer(fileLine, entities[1],line,entities[2],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}										
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddStopTimer(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.AddStopTimer(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MEASURESTART":
							if (entities.Length>=6){
								if (entities[5]=="*"){
									switch (entities[4].Trim()){
										case "":
										case "l":
											result= generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Left,CapStyle.Outer);	
											break;
										case "r":
											result= generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Right,CapStyle.Outer);	
											break;											
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
											break;
									}
									if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								}
								else if (entities[5]=="-"){
									switch (entities[4].Trim()){
										case "":
										case "l":
											result= generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Left,CapStyle.Inner);	
											break;
										case "r":
											result= generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Right,CapStyle.Inner);	
											break;											
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
											break;
									}
									if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								}

								else{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));				
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==5){
								switch (entities[4].Trim()){
									case "":
									case "l":
										result= generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Left);	
										break;
									case "r":
										result= generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Right);	
										break;											
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								result=generator.addMeasureStart(fileLine, entities[1],line,entities[2],entities[3]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addMeasureStart(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else if (entities.Length==2){
								result=generator.addMeasureStart(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MEASURESTOP":
							if (entities.Length>=6){
								if (entities[5]=="*"){
									switch (entities[4].Trim()){
										case "":
										case "l":
											result= generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Left,CapStyle.Outer);	
											break;
										case "r":
											result= generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Right,CapStyle.Outer);	
											break;											
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
											break;
									}
									if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								}
								else if (entities[5]=="-"){
									switch (entities[4].Trim()){
										case "":
										case "l":
											result= generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Left,CapStyle.Inner);	
											break;
										case "r":
											result= generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Right,CapStyle.Inner);	
											break;											
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
											break;
									}
									if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								}
								else{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[0]));	
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==5){
								switch (entities[4].Trim()){
									case "":
									case "l":
										result= generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Left);	
										break;
									case "r":
										result= generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3],MeasurePos.Right);	
										break;											
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								result=generator.addMeasureStop(fileLine, entities[1],line,entities[2],entities[3]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addMeasureStop(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else if (entities.Length==2){
								result=generator.addMeasureStop(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MEASUREBEGIN":
							if (entities.Length>=5){
								if (entities[4]=="*"){
									switch (entities[3]){
										case "":
										case "l":
											result = generator.addMeasureBeginn(fileLine, entities[1],line,entities[2],MeasurePos.Left, CapStyle.Outer);
											break;
										case "r":
											result = generator.addMeasureBeginn(fileLine, entities[1],line,entities[2],MeasurePos.Right, CapStyle.Outer);
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
											break;
									}
								}
								else if (entities[4]=="-"){
									switch (entities[3]){
										case "":
										case "l":
											result = generator.addMeasureBeginn(fileLine, entities[1],line,entities[2],MeasurePos.Left, CapStyle.Inner);
											break;
										case "r":
											result = generator.addMeasureBeginn(fileLine, entities[1],line,entities[2],MeasurePos.Right, CapStyle.Inner);
											break;
										default:
											interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
											break;
									}
								}
								else{
									interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[0]));	
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								switch (entities[3]){
									case "":
									case "l":
										result = generator.addMeasureBeginn(fileLine, entities[1],line,entities[2],MeasurePos.Left);
										break;
									case "r":
										result = generator.addMeasureBeginn(fileLine, entities[1],line,entities[2],MeasurePos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addMeasureBeginn(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.addMeasureBeginn(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "MEASUREEND":
							if (entities.Length>=3){
								result=generator.addMeasureEnd(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.addMeasureEnd(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else if (entities.Length==1){
								result=generator.addMeasureEnd(fileLine, line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}	
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,0,entities[0]));
							}
							break;
						case "TIMERBEGIN":
							if (entities.Length>=6){
								ItemStyle itemstyle = ItemStyle.Normal;
								switch (entities[5].Trim()){
									case "i":
										itemstyle = ItemStyle.ExtendedInner;
										break;
									case "o":
										itemstyle = ItemStyle.ExtendedOuter;
										break;
									case "n":
										itemstyle = ItemStyle.Normal;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,5,entities[5]));
										break;
								}
								switch (entities[4].Trim()){
									case "":
									case "l":
										result = generator.AddTimerBegin(fileLine, entities[2],line,entities[1],entities[3],ItemPos.Left,itemstyle);
										break;
									case "r":
										result = generator.AddTimerBegin(fileLine, entities[2],line,entities[1],entities[3],ItemPos.Right,itemstyle);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==5){
								switch (entities[4].Trim()){
									case "":
									case "l":
										result = generator.AddTimerBegin(fileLine, entities[2],line,entities[1],entities[3],ItemPos.Left);
										break;
									case "r":
										result = generator.AddTimerBegin(fileLine, entities[2],line,entities[1],entities[3],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								result=generator.AddTimerBegin(fileLine, entities[2],line,entities[1],entities[3]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddTimerBegin(fileLine, entities[2],line, entities[1]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "TIMEREND":
							if (entities.Length>=4){
								switch (entities[3].Trim()){
									case "*":
										result = generator.AddTimerEnd(fileLine,line,entities[1],entities[2],TimerStyle.Break);
										break;
									case "-":
										result = generator.AddTimerEnd(fileLine,line,entities[1],entities[2],TimerStyle.End);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddTimerEnd(fileLine,line,entities[1],entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.AddTimerEnd(fileLine,line, entities[1]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "TIMEOUTBEGIN":
							if (entities.Length>=5){
								ItemStyle itemstyle = ItemStyle.Normal;
								switch (entities[4].Trim()){
									case "i":
										itemstyle = ItemStyle.ExtendedInner;
										break;
									case "o":
										itemstyle = ItemStyle.ExtendedOuter;
										break;
									case "n":
										itemstyle = ItemStyle.Normal;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[3]));
										break;
								}
								switch (entities[3].Trim()){
									case "":
									case "l":
										result = generator.AddTimeoutBeginn(fileLine, entities[1],line,entities[2],ItemPos.Left,itemstyle);
										break;
									case "r":
										result = generator.AddTimeoutBeginn(fileLine, entities[1],line,entities[2],ItemPos.Right,itemstyle);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								switch (entities[3].Trim()){
									case "":
									case "l":
										result = generator.AddTimeoutBeginn(fileLine, entities[1],line,entities[2],ItemPos.Left);
										break;
									case "r":
										result = generator.AddTimeoutBeginn(fileLine, entities[1],line,entities[2],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.AddTimeoutBeginn(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.AddTimeoutBeginn(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "TIMEOUTEND":
							if (entities.Length>=5){
								ItemStyle itemstyle = ItemStyle.Normal;
								switch (entities[4].Trim()){
									case "i":
										itemstyle = ItemStyle.ExtendedInner;
										break;
									case "o":
										itemstyle = ItemStyle.ExtendedOuter;
										break;
									case "n":
										itemstyle = ItemStyle.Normal;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[3]));
										break;
								}
								switch (entities[3].Trim()){
									case "":
									case "l":
										result = generator.addTimeoutEnd(fileLine, entities[1],line,entities[2],ItemPos.Left,itemstyle);
										break;
									case "r":
										result = generator.addTimeoutEnd(fileLine, entities[1],line,entities[2],ItemPos.Right,itemstyle);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								switch (entities[3].Trim()){
									case "":
									case "l":
										result = generator.addTimeoutEnd(fileLine, entities[1],line,entities[2],ItemPos.Left);
										break;
									case "r":
										result = generator.addTimeoutEnd(fileLine, entities[1],line,entities[2],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addTimeoutEnd(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.addTimeoutEnd(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else if (entities.Length==1){
								result=generator.addTimeoutEnd(fileLine, line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}	
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,0,entities[0]));
							}
							break;
						case "TIMEOUTSTOP":
							if (entities.Length>=5){
								ItemStyle itemstyle = ItemStyle.Normal;
								switch (entities[4].Trim()){
									case "i":
										itemstyle = ItemStyle.ExtendedInner;
										break;
									case "o":
										itemstyle = ItemStyle.ExtendedOuter;
										break;
									case "n":
										itemstyle = ItemStyle.Normal;
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[3]));
										break;
								}
								switch (entities[3].Trim()){
									case "":
									case "l":
										result = generator.addTimeoutStop(fileLine, entities[1],line,entities[2],ItemPos.Left,itemstyle);
										break;
									case "r":
										result = generator.addTimeoutStop(fileLine, entities[1],line,entities[2],ItemPos.Right,itemstyle);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								switch (entities[3].Trim()){
									case "":
									case "l":
										result = generator.addTimeoutStop(fileLine, entities[1],line,entities[2],ItemPos.Left);
										break;
									case "r":
										result = generator.addTimeoutStop(fileLine, entities[1],line,entities[2],ItemPos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,3,entities[3]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
									result=generator.addTimeoutStop(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==2){
								result=generator.addTimeoutStop(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}							
							else if (entities.Length==1){
								result=generator.addTimeoutStop(fileLine, line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}	
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,0,entities[0]));
							}
							break;
						case "FOUND":
							if (entities.Length>=5){
								switch (entities[4].Trim()){
									case "l":
										result = generator.addFoundMessage(fileLine, entities[1],line,entities[2],entities[3],MessagePos.Left);
										break;
									case "r":
										result = generator.addFoundMessage(fileLine, entities[1],line,entities[2],entities[3],MessagePos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[2]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								result=generator.addFoundMessage(fileLine, entities[1],line,entities[2],entities[3]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addFoundMessage(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "LOST":
							if (entities.Length>=5){
								switch (entities[4].Trim()){
									case "l":
										result = generator.addLostMessage(fileLine, entities[1],line,entities[2],entities[3],MessagePos.Left);
										break;
									case "r":
										result = generator.addLostMessage(fileLine, entities[1],line,entities[2],entities[3],MessagePos.Right);
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,4,entities[4]));
										break;
								}
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==4){
								result=generator.addLostMessage(fileLine, entities[1],line,entities[2],entities[3]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else if (entities.Length==3){
								result=generator.addLostMessage(fileLine, entities[1],line,entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "REGIONBEGIN":
						case "REGIONSTART":
							if (entities.Length>=3){
								switch(entities[2].ToUpper()){
									case "ACTIVATION":
										result=generator.addProcessRegion(fileLine, entities[1],line,ProcessStyle.Activation);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "SUSPENSION":
										result=generator.addProcessRegion(fileLine, entities[1],line,ProcessStyle.Suspension);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									case "COREGION":
										result=generator.addProcessRegion(fileLine, entities[1],line,ProcessStyle.Coregion);
										if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
										break;
									default:
										interpretExceptions.Add(new InterpretException(InterpretResult.ParameterOutOfRange,fileLine,2,entities[0]));
										break;
								}
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;
						case "REGIONEND":
							if (entities.Length>=2){
								result=generator.addProcessRegion(fileLine, entities[1],line);		
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "REF":
							if (entities.Length>=4){
								result=generator.addReference(fileLine, entities[1],entities[2],line,entities[3]);		
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,3,entities[0]));
							}
							break;
						case "FRAGMENTBEGIN":
						case "INLINEBEGIN":
							if (entities.Length>=5){
								result=generator.addInLineBeginn(fileLine, entities[1],entities[2],entities[3],line,entities[4]);		
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,4,entities[0]));
							}
							break;
						case "FRAGMENTEND":
						case "INLINEEND":
							if (entities.Length>=2){
								result=generator.addInLineEnd(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "FRAGMENTSEPARATOR":
						case "INLINESEPERATOR":
							if (entities.Length>=2){
								result=generator.AddInLineSeparator(fileLine, entities[1],line);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,1,entities[0]));
							}
							break;
						case "FRAGMENTTEXT":
						case "INLINETEXT":
							if (entities.Length>=3){
								result=generator.AddInLineText(fileLine, entities[1],line, entities[2]);
								if (result!=InterpretResult.Ok) interpretExceptions.Add(new InterpretException(result,fileLine,entities[0]));
								if (s.EndsWith(";;")){
									line++;
									generator.AddNewPage(fileLine, line);									
								}
								if (s.EndsWith(";")){
									line++;
									nl=true;
								}
								else{
									nl=false;
								}
							}
							else{
								interpretExceptions.Add(new InterpretException(InterpretResult.WrongParameterNumber,fileLine,2,entities[0]));
							}
							break;

						case "NEXTPAGE":
						case ";;":
							if (!nl) line++;
							generator.AddNewPage(fileLine, line);
							line++;
							nl=true;
							break;
						case ";":
							line++;
							break;
						case "#":
							break;
						default:
							interpretExceptions.Add(new InterpretException(InterpretResult.UnknownCommand,fileLine,entities[0]));
							break;
					}
				}
			}
			if ((sameline)&&(nl))
				line--;
			if (startsameline)
				sameline=true;
			return line;
		}
		private FontFamily GetFontFamilyByName(string font)
		{
			foreach (System.Drawing.FontFamily f in System.Drawing.FontFamily.Families){
				if(font.Trim().ToUpper() == f.Name.ToUpper()){
					return f;
				}
			}
			return null;
		}		
		private Color GetColorByString(string color)
		{
			try{
				return ColorTranslator.FromHtml(color);
			}
			catch{
				return Color.Empty;
			}
		}
		public string[] SplitDiagramTextLine(string mscLine)
		{
			ArrayList arr 			= new ArrayList();
			string tempText 		= "";
			string command			= "";
			int comEnd 				= -1;
			char[] chars;
			bool questionMarks		=false;
			bool slash				=false;
			string[] splittedText;
			
			mscLine = mscLine.Trim();
			if ((mscLine.StartsWith("#"))||(mscLine.StartsWith("//"))){		// ignore comments
			     splittedText=new string[1];
			     splittedText[0]="#";
			     return splittedText;
			}
			if ((mscLine.EndsWith(";;"))&&(mscLine.Length!=2))				// remove ; on line end
				mscLine = mscLine.Substring(0,mscLine.Length-2);
			if ((mscLine.EndsWith(";"))&&(mscLine!=";")&&(mscLine!=";;"))				// remove ; on line end
				mscLine = mscLine.Substring(0,mscLine.Length-1);
			comEnd = mscLine.IndexOf(":");									// get command
			if (comEnd >=0){
				command = mscLine.Substring(0,comEnd);
				mscLine = mscLine.Remove(0,comEnd+1);
			}
			if ((mscLine.EndsWith(";"))&&(mscLine.Length==1))				// if only new line use command ";"
				command =";";
			if ((mscLine.EndsWith(";;"))&&(mscLine.Length==2))				// if only new line use command ";"
				command =";;";
			chars = mscLine.ToCharArray();
			foreach(char c in chars){										// parse the parameters
				if ((c==',')&&(questionMarks==false)){
					arr.Add(tempText.Trim());
					tempText = "";
				}
				else if((c=='"')&&(questionMarks==false)&&(slash==false)){
					questionMarks = true;
				}
				else if((c=='"')&&(questionMarks==true)&&(slash==false)){
					questionMarks = false;
				}
				else if((c=='"')&&(slash==true)){
					tempText += c;
					slash = false;
				}
				else if((c=='\\')&&(slash==false)){
					slash=true;
				}
				else if((c=='\\')&&(slash==true)){
					tempText += c;
					slash=false;
				}
				else{
					if (slash==true){
						tempText += '\\';
					}
					tempText += c;
					slash=false;
				}
			}
			if (slash==true){
				tempText += '\\';
			}
			slash=false;
			if (tempText.Length>0)
				arr.Add(tempText.Trim());
			else 
				arr.Add("");
			Array temp = arr.ToArray(typeof(System.String));				// pack parameters to array without leading and conclusing blanks
			splittedText = new string[temp.Length+1];
			splittedText[0] = command;
			for (int i = 0; i<temp.GetLength(0);i++){
				splittedText[i+1] = (string) temp.GetValue(i);
			}
			return splittedText;											
		}
		#endregion		
	}
}
