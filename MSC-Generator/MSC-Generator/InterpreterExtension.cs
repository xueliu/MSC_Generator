/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using mscElements;
using GeneratorGUI;

namespace nGenerator
{
	partial class Interpreter
	{
		public void InterpretDiagramTextNoWarnings(string text, Generator generator, Output output)
		{
			string[] lines 			= new string[]{String.Empty};
			uint line				=1;
			uint fileLine			=0;
			
			lines = text.Split('\n');
			sameline=false;
			for(int i=0; i<lines.Length; i++){
				fileLine++;
				line = InterpretLine(lines[i].Trim('\r'), line, fileLine, generator, output);
			}
			interpretExceptions.Clear();
		}

		public InterpretException[] InterpretDiagramText(string text, Generator generator, Output output)
		{
			string[] lines 			= new string[]{String.Empty};
			uint line				=1;
			uint fileLine			=0;
			
			interpretExceptions.Clear();
			lines = text.Split('\n');
			output.SetWorksheetWidth(1000.0f,Worksheet.WS_UNIT_PICSEL);
			output.SetWorksheetHeight(1000.0f,Worksheet.WS_UNIT_PICSEL); 
			sameline=false;
			
			for(int i=0; i<lines.Length; i++){
				fileLine++;
				line = InterpretLine(lines[i].Trim('\r'), line, fileLine, generator, output);
			}
			generator.addMSCEnd(line);
			if (interpretExceptions.Count>0){
				return (InterpretException[]) interpretExceptions.ToArray(typeof(InterpretException));
			}
			return null;
		}
		
	}
}
