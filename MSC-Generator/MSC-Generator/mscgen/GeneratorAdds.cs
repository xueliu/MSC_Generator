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
 * Date: 11.07.2006
 * Time: 07:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Drawing;
using mscElements;


namespace nGenerator
{
	/// <summary>
	/// Description of ItemAdds.
	/// </summary>
	partial class Generator
	{
		#region addNewPage
		public void AddNewPage(uint fileLine, uint line)
		{
			items.Add(new mscElements.NewPage(fileLine, line));
		}
		
		#endregion
		#region addProcess
		public void AddProcess(uint fileLine, string id, Brush brush, uint line, ProcessType type, uint leftRand, uint rightRand)
		{
			processes.Add(new Process(id, brush,leftRand, rightRand));
			lines.Add(new ProcessLine(fileLine, line,processes.Count-1,type,null,leftRand, rightRand,null));
		}
		public void AddProcess(uint fileLine, string id, string name, Brush brush, uint line, uint leftRand, uint rightRand)
		{
			processes.Add(new Process(id, brush,leftRand, rightRand));
			lines.Add(new ProcessLine(fileLine, name, line,processes.Count-1,null,leftRand, rightRand,null));
		}
		public void AddProcess(uint fileLine, string id, string name, string description, Brush brush, uint line, uint leftRand, uint rightRand)
		{
			processes.Add(new Process(id, brush,leftRand, rightRand));
			lines.Add(new ProcessLine(fileLine, name,description, line,processes.Count-1,null,leftRand, rightRand,null));
		}
		public void AddProcess(uint fileLine, string id, string name, Brush brush, uint line, ProcessType type, uint leftRand, uint rightRand)
		{
			processes.Add(new Process(id, brush,leftRand, rightRand));
			lines.Add(new ProcessLine(fileLine, name, line,processes.Count-1, type,null,leftRand, rightRand,null));
		}
		public void AddProcess(uint fileLine, string id, string name, string description, Brush brush, uint line, ProcessType type, uint leftRand, uint rightRand)
		{
			processes.Add(new Process(id, brush,leftRand, rightRand));
			lines.Add(new ProcessLine(fileLine, name,description, line,processes.Count-1,type,null,leftRand, rightRand,null));
		}
		#endregion		
		#region addVerticalOffset
		public void AddVerticalOffset(uint offset)
		{
			MSC.VerticalOffset = offset;
		}
		#endregion
		#region addHead
		public void AddHead(string name)
		{
			MSC.DiagramName = name;
		}
		#endregion	
		#region addLineComment
		public InterpretResult AddLineComment(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new LineComment(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddLineComment(uint fileLine, string processName, uint line, string name, CommentPos pos)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new LineComment(fileLine, name, line, i,pos));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddLineComment(uint fileLine, string processName, uint line, string name, CommentPos pos, bool drawLine)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new LineComment(fileLine, name, line, i, pos, drawLine));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion
		#region addComment2
		public InterpretResult AddComment2(uint fileLine, uint line, string name, CommentPos pos)
		{
			items.Add(new Comment(fileLine, line, 0, name, pos));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddComment2(uint fileLine, uint line, string name, string instanceName, CommentPos pos)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int instance=-1;	
			if(instanceName==ENV_LEFT_STRING){
				instance = ENV_LEFT;
			}
			if(instanceName==ENV_RIGHT_STRING){
				instance = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == instanceName){
					instance=i;      
				}
			}
			if(instance != -1){
				items.Add(new Comment(fileLine, line, instance, name, pos));
				mLines = Math.Max(mLines, line);
				return InterpretResult.Ok;
			}
			else
				return InterpretResult.InstanceNotFound;
		}
		public InterpretResult AddComment2(uint fileLine, uint line, string name, string instanceName)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int instance=-1;	
			if(instanceName==ENV_LEFT_STRING){
				instance = ENV_LEFT;
			}
			if(instanceName==ENV_RIGHT_STRING){
				instance = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == instanceName){
					instance=i;      
				}
			}
			if(instance != -1){
				items.Add(new Comment(fileLine, line, instance, name));
				mLines = Math.Max(mLines, line);
				return InterpretResult.Ok;
			}
			else
				return InterpretResult.InstanceNotFound;
		}
		#endregion
		#region addTask
		public InterpretResult AddTask(uint fileLine, int process, uint line, string name)
		{
			if (process>=processes.Count){
				return InterpretResult.InstanceNotFound;
			}
			items.Add(new Task(fileLine, name, line, process));
			return InterpretResult.Ok;
		}
		
		public InterpretResult AddTask(uint fileLine, string processName, uint line, string name, ItemPos pos)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound=false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new Task(fileLine, name, line, i, pos));
					instanceFound=true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion		
		#region addMessage
		public InterpretResult AddMessage(uint fileLine, string sourceName, string destinationName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int source=-1, destination=-1;	
			if(sourceName==ENV_LEFT_STRING){
				source = ENV_LEFT;
			}
			if(sourceName==ENV_RIGHT_STRING){
				source = ENV_RIGHT;
			}
			if(destinationName==ENV_LEFT_STRING){
				destination = ENV_LEFT;
			}
			if(destinationName==ENV_RIGHT_STRING){
				destination = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == sourceName){
					source=i;      
				}
				if(process.ProcessName == destinationName){
					destination=i;
				}
			}
			if((source != -1)&&(destination != -1)){
				items.Add(new mscElements.Message(fileLine, name, line,source,destination));
				mLines = Math.Max(mLines, line);
				return InterpretResult.Ok;
			}
			else
				return InterpretResult.InstanceNotFound;
				
		}
		
		public InterpretResult AddMessage(uint fileLine, string sourceName, string destinationName, uint line, string name, MessageStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int source=-1, destination=-1;	
			if(sourceName==ENV_LEFT_STRING){
				source = ENV_LEFT;
			}
			if(sourceName==ENV_RIGHT_STRING){
				source = ENV_RIGHT;
			}
			if(destinationName==ENV_LEFT_STRING){
				destination = ENV_LEFT;
			}
			if(destinationName==ENV_RIGHT_STRING){
				destination = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == sourceName){
					source=i;      
				}
				if(process.ProcessName == destinationName){
					destination=i;
				}
			}
			if((source != -1)&&(destination != -1)){
				items.Add(new mscElements.Message(fileLine, name, line,source,destination, style));
				mLines = Math.Max(mLines, line);
				return InterpretResult.Ok;
			}
			else
				return InterpretResult.InstanceNotFound;
		}
		#endregion		
		#region addState
		public InterpretResult AddState(uint fileLine, uint line, string name, ItemPos pos)
		{
			int[] proc = new int[processes.Count];
			for (int j=0;j<processes.Count;j++){
				proc[j]=j;
			}
			items.Add(new State(fileLine, name, line,proc, StateStyle.Box, pos));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddState(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new State(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound == false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddState(uint fileLine, string[] processName, uint line, string name)
		{
			Process process;
			int[] proc = new int[processName.Length];
			IEnumerator enumerator = processes.GetEnumerator();
			for (int j=0;j<processName.Length;j++){
				proc[j]=-1;
				enumerator.Reset();
				for(int i=0;i<processes.Count;i++){
					enumerator.MoveNext();
					process = (Process) enumerator.Current;
					if(process.ProcessName == processName[j]){
						proc[j]=i;
						break;          
					}
				}
			}
			for (int j=0;j<processName.Length;j++){
				if (proc[j]==-1) return InterpretResult.InstanceNotFound;
			}
			items.Add(new State(fileLine, name, line, proc));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		public InterpretResult AddState(uint fileLine, uint line, string name,StateStyle style )
		{
			int[] proc = new int[processes.Count];
			for (int j=0;j<processes.Count;j++){
				proc[j]=j;
			}
			items.Add(new State(fileLine, name, line,proc,style));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddState(uint fileLine, string processName, uint line, string name,StateStyle style,ItemPos pos )
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new State(fileLine, name, line, i, style, pos));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound == false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddState(uint fileLine, string[] processName, uint line, string name,StateStyle style, ItemPos pos )
		{
			Process process;
			int[] proc = new int[processName.Length];
			IEnumerator enumerator = processes.GetEnumerator();
			for (int j=0;j<processName.Length;j++){
				proc[j]=-1;
				enumerator.Reset();
				for(int i=0;i<processes.Count;i++){
					enumerator.MoveNext();
					process = (Process) enumerator.Current;
					if(process.ProcessName == processName[j]){
						proc[j]=i;
						break;          
					}
				}
			}
			for (int j=0;j<processName.Length;j++){
				if (proc[j]==-1) return InterpretResult.InstanceNotFound;
			}
			items.Add(new State(fileLine, name, line, proc,style,pos));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		
		#endregion		
		#region addSetTimer
		
		public InterpretResult AddSetTimer(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new SetTimer(fileLine, name, line, i));
					instanceFound=true;
					break;          
				}
			}
			if(instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		public InterpretResult AddSetTimer(uint fileLine, string processName, uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new SetTimer(fileLine, line, i));
					instanceFound=true;
					break;          
				}
			}
			if(instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddSetTimer(uint fileLine, string processName, uint line, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new SetTimer(fileLine, name, line, i, placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion	
		#region addTimeOut
		
		public InterpretResult AddTimeOut(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeOut(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		
		public InterpretResult AddTimeOut(uint fileLine, string processName, uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeOut(fileLine, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddTimeOut(uint fileLine, string processName, uint line, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeOut(fileLine, name, line, i,placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion		
		#region addStopTimer
		public InterpretResult AddStopTimer(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new StopTimer(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddStopTimer(uint fileLine, string processName, uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new StopTimer(fileLine, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		public InterpretResult AddStopTimer(uint fileLine, string processName, uint line, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new StopTimer(fileLine, name, line, i, placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion
		#region addTimerBegin
		public InterpretResult AddTimerBegin(uint fileLine, string processName, uint line, string identifier)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimerBegin(fileLine, line, identifier,i));
					AddItemVerticalLine(fileLine, line,identifier,i);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddTimerBegin(uint fileLine, string processName, uint line, string identifier, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimerBegin(fileLine, line, identifier,i,name));
					AddItemVerticalLine(fileLine, line,identifier,i);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddTimerBegin(uint fileLine, string processName, uint line, string identifier, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimerBegin(fileLine, line, identifier,i,name, placement));
					AddItemVerticalLine(fileLine, line,identifier,i, placement);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddTimerBegin(uint fileLine, string processName, uint line, string identifier, string name, ItemPos placement, ItemStyle itemstyle)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimerBegin(fileLine, line, identifier,i,name, placement, itemstyle));
					AddItemVerticalLine(fileLine, line,identifier,i, placement, itemstyle);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion
		#region addTimerEnd
		public InterpretResult AddTimerEnd(uint fileLine, uint line, string identifier)
		{
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			for(uint i=0;i<lines.Count;i++){
				lEnumerator.MoveNext();
				if ( lEnumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Identifier == identifier)){
						((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
						items.Add(new TimerEnd(fileLine, line, identifier,((ItemVerticalLine) lEnumerator.Current).Process, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
						lineFound = true;
						break;
					}
			}
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		public InterpretResult AddTimerEnd(uint fileLine, uint line, string identifier, string name)
		{
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			for(uint i=0;i<lines.Count;i++){
				lEnumerator.MoveNext();
				if ( lEnumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Identifier == identifier)){
						((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
						items.Add(new TimerEnd(fileLine, line, identifier,((ItemVerticalLine) lEnumerator.Current).Process, name, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
						lineFound = true;
						break;
					}
			}
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		public InterpretResult AddTimerEnd(uint fileLine, uint line, string identifier, string name, TimerStyle tStyle)
		{
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			for(uint i=0;i<lines.Count;i++){
				lEnumerator.MoveNext();
				if ( lEnumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Identifier == identifier)){
						((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
						items.Add(new TimerEnd(fileLine, line, identifier,((ItemVerticalLine) lEnumerator.Current).Process, name, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle, tStyle));
						lineFound = true;
						break;
					}
			}
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		#endregion
		#region addTimeoutBeginn
		
		public InterpretResult AddTimeoutBeginn(uint fileLine, string processName, uint line, string name, ItemPos placement, ItemStyle itemstyle)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeoutBegin(fileLine, name, line, i, placement, itemstyle));
					AddItemVerticalLine(fileLine, line,"",i,placement, itemstyle);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult AddTimeoutBeginn(uint fileLine, string processName, uint line, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeoutBegin(fileLine, name, line, i, placement));
					AddItemVerticalLine(fileLine, line,"",i,placement);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		
		public InterpretResult AddTimeoutBeginn(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeoutBegin(fileLine, name, line, i));
					AddItemVerticalLine(fileLine, line,"",i);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		
		public InterpretResult AddTimeoutBeginn(uint fileLine, string processName,uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new TimeoutBegin(fileLine, line, i));
					AddItemVerticalLine(fileLine, line,"", i);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion		
		#region addTimeoutLineBeginn
		public InterpretResult AddItemVerticalLine(uint fileLine, uint line, string identifier, int process)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) enumerator.Current).LineEnd==0)&&(((ItemVerticalLine) enumerator.Current).Process == process)&&(((ItemVerticalLine) enumerator.Current).Identifier == identifier)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ItemVerticalLine(line+1, process,identifier));
			return InterpretResult.Ok;
		}
		public InterpretResult AddItemVerticalLine(uint fileLine, uint line, string identifier, int process, ItemPos placement)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) enumerator.Current).LineEnd==0)&&(((ItemVerticalLine) enumerator.Current).Process == process)&&(((ItemVerticalLine) enumerator.Current).ItemPlacement == placement)&&(((ItemVerticalLine) enumerator.Current).Identifier == identifier)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ItemVerticalLine(line+1, process, identifier, placement));
			return InterpretResult.Ok;
		}
		public InterpretResult AddItemVerticalLine(uint fileLine, uint line, string identifier, int process, ItemPos placement, ItemStyle itemstyle)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) enumerator.Current).LineEnd==0)&&(((ItemVerticalLine) enumerator.Current).Process == process)&&(((ItemVerticalLine) enumerator.Current).ItemPlacement == placement)&&(((ItemVerticalLine) enumerator.Current).Itemstyle == itemstyle)&&(((ItemVerticalLine) enumerator.Current).Identifier == identifier)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ItemVerticalLine(line+1, process, identifier, placement, itemstyle));
			return InterpretResult.Ok;
		}
		#endregion		
		#region addMeasureLineBeginn
		public InterpretResult AddMeasureLineBeginn(uint fileLine, uint line, int process)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MeasureLine)
					if((((MeasureLine) enumerator.Current).LineEnd==0)&&(((MeasureLine) enumerator.Current).Process == process)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new MeasureLine(line+1, process));
			return InterpretResult.Ok;
		}
		public InterpretResult addMeasureLineBeginn(uint fileLine, uint line, int process, MeasurePos placement)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MeasureLine)
					if((((MeasureLine) enumerator.Current).LineEnd==0)&&(((MeasureLine) enumerator.Current).Process == process)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new MeasureLine(line+1, process, placement));
			return InterpretResult.Ok;
		}
		public InterpretResult addMeasureLineBeginn(uint fileLine, uint line, int process, CapStyle style)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MeasureLine)
					if((((MeasureLine) enumerator.Current).LineEnd==0)&&(((MeasureLine) enumerator.Current).Process == process)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new MeasureLine(line+1, style, process));
			return InterpretResult.Ok;
		}
		public InterpretResult addMeasureLineBeginn(uint fileLine, uint line, int process, MeasurePos placement, CapStyle style)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MeasureLine)
					if((((MeasureLine) enumerator.Current).LineEnd==0)&&(((MeasureLine) enumerator.Current).Process == process)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new MeasureLine(line+1, style, process, placement));
			return InterpretResult.Ok;
		}
		#endregion		
		#region addTimeoutEnd
		
		public InterpretResult addTimeoutEnd(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutEnd(fileLine, name, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
							}
					}
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addTimeoutEnd(uint fileLine, string processName, uint line, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine){
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)&&(((ItemVerticalLine) lEnumerator.Current).ItemPlacement == placement)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutEnd(fileLine, name, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
						}
					}
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addTimeoutEnd(uint fileLine, string processName, uint line, string name, ItemPos placement, ItemStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine){
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)&&(((ItemVerticalLine) lEnumerator.Current).ItemPlacement == placement)&&(((ItemVerticalLine) lEnumerator.Current).Itemstyle == style)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutEnd(fileLine, name, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
						}
					}
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		public InterpretResult addTimeoutEnd(uint fileLine, string processName,uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutEnd(fileLine, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addTimeoutEnd(uint fileLine, string processName,uint line, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			IEnumerator lEnumerator = lines.GetEnumerator();		
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)&&(((ItemVerticalLine) lEnumerator.Current).ItemPlacement == placement)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutEnd(fileLine, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		public InterpretResult addTimeoutEnd(uint fileLine, uint line)
		{
			int process;
			process = addLineEnd(fileLine, line);		
			items.Add(new TimeoutEnd(fileLine, line, process));
			mLines = Math.Max(mLines, line);
			addLineEnd(fileLine, line, process);
			return InterpretResult.Ok;
		}
		#endregion		
		#region addLineEnd
		public int addLineEnd(uint fileLine, uint line)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ItemVerticalLine)
					if(((ItemVerticalLine) enumerator.Current).LineEnd==0){
					((ItemVerticalLine) enumerator.Current).LineEnd = line-1;
					return ((ItemVerticalLine) enumerator.Current).Process;
				}
			}
			return 0;
		}
		public InterpretResult addLineEnd(uint fileLine, uint line, int process)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			bool lineFound = false;
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ItemVerticalLine)
					if((((ItemVerticalLine) enumerator.Current).LineEnd==0)&&(((ItemVerticalLine) enumerator.Current).Process == process)){
						((ItemVerticalLine) enumerator.Current).LineEnd = line-1;
						lineFound = true;
						break;
					}
			}
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			return InterpretResult.Ok;
		}
		#endregion		
		#region addMeasureLineEnd
		public InterpretResult addMeasureLineEnd(uint fileLine, uint line, int process)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator lEnumerator = lines.GetEnumerator();
			bool lineFound = false;
			for(uint j=0;j<lines.Count;j++){
				lEnumerator.MoveNext();
				if(lEnumerator.Current is MeasureLine)
					if((((MeasureLine) lEnumerator.Current).LineEnd==0)&&(((MeasureLine) lEnumerator.Current).Process == process)){
						((MeasureLine) lEnumerator.Current).LineEnd = line-1;
						lineFound = true;
						break;
					}
			}
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			return InterpretResult.Ok;
		}
		public int addMeasureLineEnd(uint fileLine, uint line)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if(enumerator.Current is MeasureLine)
					if(((MeasureLine) enumerator.Current).LineEnd==0){
						((MeasureLine) enumerator.Current).LineEnd = line-1;
						return ((MeasureLine) enumerator.Current).Process;
					}
			}
			return 0;
		}
		#endregion		
		#region addTimeoutStop
		public InterpretResult addTimeoutStop(uint fileLine, string processName,uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					IEnumerator lEnumerator = lines.GetEnumerator();
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutStop(fileLine, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addTimeoutStop(uint fileLine, string processName,uint line, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					instanceFound = true;
					IEnumerator lEnumerator = lines.GetEnumerator();
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)&&(((ItemVerticalLine) lEnumerator.Current).ItemPlacement == placement)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutStop(fileLine, line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		public InterpretResult addTimeoutStop(uint fileLine, uint line)
		{
			int process;
			process = addLineEnd(fileLine, line);		
			items.Add(new TimeoutStop(fileLine, line, process));
			mLines = Math.Max(mLines, line);
			addLineEnd(fileLine, line, process);
			return InterpretResult.Ok;			
		}
		
		public InterpretResult addTimeoutStop(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					IEnumerator lEnumerator = lines.GetEnumerator();
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutStop(fileLine, name,line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addTimeoutStop(uint fileLine, string processName, uint line, string name, ItemPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					IEnumerator lEnumerator = lines.GetEnumerator();
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)&&(((ItemVerticalLine) lEnumerator.Current).ItemPlacement == placement)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutStop(fileLine, name,line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addTimeoutStop(uint fileLine, string processName, uint line, string name, ItemPos placement, ItemStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					IEnumerator lEnumerator = lines.GetEnumerator();
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						lEnumerator.MoveNext();
						if ( lEnumerator.Current is ItemVerticalLine)
							if((((ItemVerticalLine) lEnumerator.Current).LineEnd==0)&&(((ItemVerticalLine) lEnumerator.Current).Process == j)&&(((ItemVerticalLine) lEnumerator.Current).ItemPlacement == placement)&&(((ItemVerticalLine) lEnumerator.Current).Itemstyle == style)){
								((ItemVerticalLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new TimeoutStop(fileLine, name,line, j, ((ItemVerticalLine) lEnumerator.Current).ItemPlacement, ((ItemVerticalLine) lEnumerator.Current).Itemstyle));
								lineFound = true;
								break;
							}
					}
					break;
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion		
		#region addMscMark		
		public InterpretResult addMscMark(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new Mark(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addMscMark(uint fileLine, string processName, uint line, string name, MarkPos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new Mark(fileLine, name, line, i, placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion		
		#region addMscEnd
		public void addMSCEnd(uint line)
		{
			items.Add(new MSCEnd(line));
			mLines = Math.Max(mLines, line);
		}
		#endregion
		#region addMeasureBeginn
		
		public InterpretResult addMeasureBeginn(uint fileLine, string processName, uint line, string name, MeasurePos placement, CapStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureBeginn(fileLine, name, line, i,placement,style));
					addMeasureLineBeginn(fileLine, line,i,placement,style);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		
		public InterpretResult addMeasureBeginn(uint fileLine, string processName, uint line, string name, MeasurePos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureBeginn(fileLine, name, line, i,placement));
					addMeasureLineBeginn(fileLine, line,i,placement);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}		
		public InterpretResult addMeasureBeginn(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureBeginn(fileLine, name, line, i));
					AddMeasureLineBeginn(fileLine, line,i);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		public InterpretResult addMeasureBeginn(uint fileLine, string processName,uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureBeginn(fileLine, line, i));
					AddMeasureLineBeginn(fileLine, line, i);
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		#endregion	
		#region addMeasureEnd
		
		public InterpretResult addMeasureEnd(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					IEnumerator lEnumerator = lines.GetEnumerator();
					instanceFound = true;
					for(uint j=0;j<lines.Count;j++){
						lEnumerator.MoveNext();
						if(lEnumerator.Current is MeasureLine)
							if((((MeasureLine) lEnumerator.Current).LineEnd==0)&&(((MeasureLine) lEnumerator.Current).Process == i)){
								((MeasureLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new MeasureEnd(fileLine, name, line, i,((MeasureLine) lEnumerator.Current).MeasurePlacement, ((MeasureLine) lEnumerator.Current).MeasureCapStyle));
								lineFound = true;
								break;
							}
					}
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		public InterpretResult addMeasureEnd(uint fileLine, string processName,uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					IEnumerator lEnumerator = lines.GetEnumerator();
					instanceFound = true;
					for(uint j=0;j<lines.Count;j++){
						lEnumerator.MoveNext();
						if(lEnumerator.Current is MeasureLine){
							if((((MeasureLine) lEnumerator.Current).LineEnd==0)&&(((MeasureLine) lEnumerator.Current).Process == i)){
								((MeasureLine) lEnumerator.Current).LineEnd = line-1;
								items.Add(new MeasureEnd(fileLine, line, i,((MeasureLine) lEnumerator.Current).MeasurePlacement, ((MeasureLine) lEnumerator.Current).MeasureCapStyle));
								lineFound = true;
								break;
							}
						}
					}
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}

		public InterpretResult addMeasureEnd(uint fileLine, uint line)
		{
			int process;
			process = addLineEnd(fileLine, line);		
			items.Add(new MeasureEnd(fileLine, line, process));
			mLines = Math.Max(mLines, line);
			return addMeasureLineEnd(fileLine, line, process);
		}
		#endregion
		#region addMeasureStart
		public InterpretResult addMeasureStart(uint fileLine, string processName, uint line, string gate, string name, MeasurePos placement, CapStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStart(fileLine, name, gate, line, i, placement, style));
					instanceFound = true;
					break;
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStart(uint fileLine, string processName, uint line, string gate, string name, MeasurePos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStart(fileLine, name, gate, line, i, placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStart(uint fileLine, string processName, uint line, string gate, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStart(fileLine, name, gate, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStart(uint fileLine, string processName, uint line, string gate)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStart(fileLine, gate, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStart(uint fileLine, string processName, uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStart(fileLine, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		
		#endregion	
		#region addMeasureStop
		public InterpretResult addMeasureStop(uint fileLine, string processName, uint line, string gate, string name, MeasurePos placement, CapStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStop(fileLine, name, gate, line, i,placement, style));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		
		public InterpretResult addMeasureStop(uint fileLine, string processName, uint line, string gate, string name, MeasurePos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStop(fileLine, name, gate, line, i,placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStop(uint fileLine, string processName, uint line, string gate, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStop(fileLine, name, gate, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStop(uint fileLine, string processName, uint line, string gate)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStop(fileLine, gate, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addMeasureStop(uint fileLine, string processName, uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new MeasureStop(fileLine, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		
		#endregion	
		#region addFoundMessage
		public InterpretResult addFoundMessage(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new FoundMessage(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}		
		public InterpretResult addFoundMessage(uint fileLine, string processName, uint line, string name, string gate)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new FoundMessage(fileLine, name, gate, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addFoundMessage(uint fileLine, string processName, uint line, string name, string gate, MessagePos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new FoundMessage(fileLine, name, gate, line, i, placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		#endregion		
		#region addLostMessage
		public InterpretResult addLostMessage(uint fileLine, string processName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new LostMessage(fileLine, name, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}

		public InterpretResult addLostMessage(uint fileLine, string processName, uint line, string name, string gate)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new LostMessage(fileLine, name, gate, line, i));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addLostMessage(uint fileLine, string processName, uint line, string name, string gate, MessagePos placement)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			bool instanceFound = false;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new LostMessage(fileLine, name, gate, line, i, placement));
					instanceFound = true;
					break;          
				}
			}
			if (instanceFound==false)
				return InterpretResult.InstanceNotFound;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		#endregion		
		#region addProcessLineBeginn
		public InterpretResult addProcessLineBeginn(uint fileLine, string name, uint line, int process, ProcessCreate p, ProcessLine oldLine)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ProcessLine)
					if((((ProcessLine) enumerator.Current).LineEnd==0)&&(((ProcessLine) enumerator.Current).ProcessIndex == process)&&(((ProcessLine) enumerator.Current).ProcessType != ProcessType.Dummy)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ProcessLine(fileLine, name, line, process, p,0,0,oldLine));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addProcessLineBeginn(uint fileLine, string name, string description, uint line, int process, ProcessCreate p,ProcessLine oldLine)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ProcessLine)
					if((((ProcessLine) enumerator.Current).LineEnd==0)&&(((ProcessLine) enumerator.Current).ProcessIndex == process)&&(((ProcessLine) enumerator.Current).ProcessType != ProcessType.Dummy)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ProcessLine(fileLine, name, description, line, process, p,0,0, oldLine));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addProcessLineBeginn(uint fileLine, string name, uint line, int process, ProcessStyle style, ProcessCreate p,ProcessLine oldLine)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ProcessLine)
					if((((ProcessLine) enumerator.Current).LineEnd==0)&&(((ProcessLine) enumerator.Current).ProcessIndex == process)&&(((ProcessLine) enumerator.Current).ProcessType != ProcessType.Dummy)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ProcessLine(fileLine, name, line, process, style, p,0,0,oldLine));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		public InterpretResult addProcessLineBeginn(uint fileLine, string name, string description, uint line, int process, ProcessStyle style, ProcessCreate p,ProcessLine oldLine)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ProcessLine)
					if((((ProcessLine) enumerator.Current).LineEnd==0)&&(((ProcessLine) enumerator.Current).ProcessIndex == process)&&(((ProcessLine) enumerator.Current).ProcessType != ProcessType.Dummy)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new ProcessLine(fileLine, name, description, line, process, style, p,0,0,oldLine));
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;			
		}
		#endregion		
		#region addProcessLineEnd
		public InterpretResult addProcessLineEnd(uint fileLine, uint line, int process)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			bool lineFound = false;
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if(enumerator.Current is ProcessLine)
					if((((ProcessLine) enumerator.Current).LineEnd==0)&&(((ProcessLine) enumerator.Current).ProcessIndex == process)){
						((ProcessLine) enumerator.Current).LineEnd = line;
						lineFound = true;
					}
			}
			if (lineFound==false)
				return InterpretResult.LineNotExists;
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
			
		}
		#endregion		
		#region addProcessStop
		public InterpretResult addProcessStop(uint fileLine, int process, uint line)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			items.Add(new ProcessStop(fileLine, line, process));
			mLines = Math.Max(mLines, line);
			return addProcessLineEnd(fileLine, line, process);
		}
		
		public InterpretResult addProcessStop(uint fileLine, string processName, uint line)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processName){
					items.Add(new ProcessStop(fileLine, line, i));
					mLines = Math.Max(mLines, line);
					return addProcessLineEnd(fileLine, line, i);
				}
			}
			return InterpretResult.InstanceNotFound;
		}		
		#endregion
		#region addProcessCreate
		public InterpretResult addProcessCreate(uint fileLine, int processSource, int processDestination, uint line, string messName, string name)
		{
			if (processSource >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (processDestination >= processes.Count)
				return InterpretResult.InstanceNotFound;
			this.addProcessLineEnd(fileLine, line,processDestination);
			items.Add(new ProcessCreate(fileLine, name, messName, line, processSource, processDestination));
			mLines = Math.Max(mLines, line);
			return addProcessLineBeginn(fileLine, name, line, processDestination, ProcessStyle.Normal, (ProcessCreate)items[items.Count-1],null);
		}
		
		public InterpretResult addProcessCreate(uint fileLine, string processNameSource, string processNameDestination, uint line,  string messName, string name)
		{
			Process process;
			int processSource=-1, processDestination=-1;
			IEnumerator enumerator = processes.GetEnumerator();
			if(processNameSource==ENV_LEFT_STRING){
				processSource = ENV_LEFT;
			}
			if(processNameSource==ENV_RIGHT_STRING){
				processSource = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processNameSource){
					processSource = i;
				}
				if(process.ProcessName == processNameDestination){
					processDestination = i;
				}
			}
			if ((processSource!=-1)&&(processDestination!=-1))
			{
				this.addProcessLineEnd(fileLine, line,processDestination);
				items.Add(new ProcessCreate(fileLine, name, messName, line, processSource,processDestination));
				mLines = Math.Max(mLines, line);
				return addProcessLineBeginn(fileLine, name, line, processDestination, ProcessStyle.Normal, (ProcessCreate)items[items.Count-1],null);
			}
			else
				return InterpretResult.InstanceNotFound;
		}		
		public InterpretResult addProcessCreate(uint fileLine, int processSource, int processDestination, uint line, string messName, string name, string description)
		{
			if (processSource >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (processDestination >= processes.Count)
				return InterpretResult.InstanceNotFound;
			this.addProcessLineEnd(fileLine, line,processDestination);
			items.Add(new ProcessCreate(fileLine, name,messName, description, line, processSource, processDestination));
			mLines = Math.Max(mLines, line);
			return addProcessLineBeginn(fileLine, name, description, line, processDestination, ProcessStyle.Normal, (ProcessCreate)items[items.Count-1],null);
		}
		
		public InterpretResult addProcessCreate(uint fileLine, string processNameSource, string processNameDestination, uint line, string messName, string name, string description)
		{
			Process process;
			int processSource=-1, processDestination=-1;
			IEnumerator enumerator = processes.GetEnumerator();
			if(processNameSource==ENV_LEFT_STRING){
				processSource = ENV_LEFT;
			}
			if(processNameSource==ENV_RIGHT_STRING){
				processSource = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processNameSource){
					processSource = i;
				}
				if(process.ProcessName == processNameDestination){
					processDestination = i;
				}
			}
			if ((processSource!=-1)&&(processDestination!=-1))
			{	
				this.addProcessLineEnd(fileLine, line,processDestination);
				items.Add(new ProcessCreate(fileLine, name,messName, description, line, processSource,processDestination));
				mLines = Math.Max(mLines, line);
				return addProcessLineBeginn(fileLine, name, description, line, processDestination, ProcessStyle.Normal, (ProcessCreate)items[items.Count-1],null);
			}
			return InterpretResult.InstanceNotFound;
		}		
		#endregion
		#region addProcessRegion
		public InterpretResult addProcessRegion(uint fileLine, uint line, int process, ProcessStyle style)
		{
			if (process >= processes.Count)
				return InterpretResult.InstanceNotFound;
			IEnumerator enumerator = lines.GetEnumerator();
			bool lineFound = false;
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is ProcessLine){
					if((((ProcessLine) enumerator.Current).LineEnd==0)&&(((ProcessLine) enumerator.Current).ProcessIndex == process)) {
						string tmpName = ((ProcessLine) enumerator.Current).Name;
						string tmpDescription = ((ProcessLine) enumerator.Current).Description;
						this.addProcessLineEnd(fileLine, line,process);
						items.Add(new ProcessRegion(fileLine, line, process, style,((ProcessLine) enumerator.Current).ProcessStyle));
						this.addProcessLineBeginn(fileLine, tmpName,tmpDescription,line,process,style, ((ProcessLine) enumerator.Current).CreatingProcess, ((ProcessLine) enumerator.Current));
						lineFound = true;
						break;
					}
				}
			}
			if (lineFound == false){
				return InterpretResult.LineNotExists;
			}
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		public InterpretResult addProcessRegion(uint fileLine, string processName, uint line, ProcessStyle style)
		{
			IEnumerator enumeratorL = lines.GetEnumerator();
			IEnumerator enumeratorP = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumeratorP.MoveNext();
				if(((Process) enumeratorP.Current).ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						enumeratorL.MoveNext();
						if ( enumeratorL.Current is ProcessLine){
							if((((ProcessLine) enumeratorL.Current).LineEnd==0)&&(((ProcessLine) enumeratorL.Current).ProcessIndex == j)) {
								string tmpName = ((ProcessLine) enumeratorL.Current).Name;
								string tmpDescription = ((ProcessLine) enumeratorL.Current).Description;
								this.addProcessLineEnd(fileLine, line,j);
								items.Add(new ProcessRegion(fileLine, line, j, style, ((ProcessLine) enumeratorL.Current).ProcessStyle));
								this.addProcessLineBeginn(fileLine, tmpName,tmpDescription,line,j,style,((ProcessLine) enumeratorL.Current).CreatingProcess, ((ProcessLine) enumeratorL.Current));
								lineFound = true;
								break;
							}
						}
					
					}
					break;          
				}
			}
			if (instanceFound == false){
				return InterpretResult.InstanceNotFound;
			}
			if (lineFound == false){
				return InterpretResult.LineNotExists;
			}
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
			
		}
		public InterpretResult addProcessRegion(uint fileLine, string processName,uint line)
		{
			IEnumerator enumeratorL = lines.GetEnumerator();
			IEnumerator enumeratorP = processes.GetEnumerator();
			bool lineFound = false;
			bool instanceFound = false;
			for(int j=0;j<processes.Count;j++){
				enumeratorP.MoveNext();
				if(((Process) enumeratorP.Current).ProcessName == processName){
					instanceFound = true;
					for(uint i=0;i<lines.Count;i++){
						enumeratorL.MoveNext();
						if ( enumeratorL.Current is ProcessLine){
							if((((ProcessLine) enumeratorL.Current).LineEnd==0)&&(((ProcessLine) enumeratorL.Current).ProcessIndex == j)) {
								string tmpName = ((ProcessLine) enumeratorL.Current).Name;
								string tmpDescription = ((ProcessLine) enumeratorL.Current).Description;
								this.addProcessLineEnd(fileLine, line,j);
								items.Add(new ProcessRegion(fileLine, line, j, ProcessStyle.Normal, ((ProcessLine) enumeratorL.Current).ProcessStyle));									
								this.addProcessLineBeginn(fileLine, tmpName,tmpDescription,line,j,(((ProcessLine) enumeratorL.Current).OldLine==null)? ProcessStyle.Normal : ((ProcessLine) enumeratorL.Current).OldLine.ProcessStyle,((ProcessLine) enumeratorL.Current).CreatingProcess, (((ProcessLine) enumeratorL.Current).OldLine == null) ? null : ((ProcessLine) enumeratorL.Current).OldLine.OldLine);
								lineFound = true;
								break;
							}
						}
					}
					break;          
				}
			}
			if (instanceFound == false){
				return InterpretResult.InstanceNotFound;
			}
			if (lineFound == false){
				return InterpretResult.LineNotExists;
			}
			mLines = Math.Max(mLines, line);
			return InterpretResult.Ok;
		}
		
		#endregion
		#region addReference
		public InterpretResult addReference(uint fileLine, int processBeginn,int processEnd,uint line,string name)
		{
			Reference reference;
			if (processBeginn >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (processEnd >= processes.Count)
				return InterpretResult.InstanceNotFound;
			reference = new Reference(fileLine, name, line, processBeginn, processEnd);
			items.Add(reference);
			inLines.Add(reference);
			mLines = Math.Max(mLines, line);
			return InterpretResult.InstanceNotFound;
		}
		
		public InterpretResult addReference(uint fileLine, string processBeginn, string processEnd,uint line,string name )
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			Reference reference;
			int pb=-1, pe=-1;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processBeginn){
					pb=i;
				}
				if(process.ProcessName == processEnd){
					pe=i;
				}
			}
			if((pb>=0)&&(pe>=0)){
				reference = new Reference(fileLine, name, line, pb, pe);
				items.Add(reference);
				inLines.Add(reference);
				mLines = Math.Max(mLines, line);
				return InterpretResult.Ok;
			}
			return InterpretResult.InstanceNotFound;
		}
		#endregion
		#region addInLineBeginn
		public InterpretResult addInLineBeginn(uint fileLine, string identifier,int processBeginn,int processEnd,uint line,string name)
		{
			if (processBeginn >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (processEnd >= processes.Count)
				return InterpretResult.InstanceNotFound;
			items.Add(new InLineBeginn(fileLine, name, identifier, line, processBeginn, processEnd));
			mLines = Math.Max(mLines, line);
			return addInLineLineBeginn(fileLine, identifier,line,processBeginn, processEnd);
		}
		
		public InterpretResult addInLineBeginn(uint fileLine, string identifier,string processBeginn, string processEnd,uint line,string name )
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int pb=-1, pe=-1;
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == processBeginn){
					pb=i;
				}
				if(process.ProcessName == processEnd){
					pe=i;
				}
			}
			if((pb>=0)&&(pe>=0)){
				items.Add(new InLineBeginn(fileLine, name, identifier, line, pb, pe));
				mLines = Math.Max(mLines, line);
				return addInLineLineBeginn(fileLine, identifier,line,pb, pe);
			}
			return InterpretResult.InstanceNotFound;
		}
		#endregion
		#region addInLineLineBeginn
		public InterpretResult addInLineLineBeginn(uint fileLine, string identifier, uint line, int processBeginn, int processEnd)
		{
			if (processBeginn >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (processEnd >= processes.Count)
				return InterpretResult.InstanceNotFound;
			inLines.Add(new InLine(identifier, line, processBeginn, processEnd));
			return InterpretResult.Ok;
		}
		#endregion
		#region addInLineEnd
		public InterpretResult addInLineEnd(uint fileLine, string identifier, uint line)
		{
			IEnumerator enumerator = inLines.GetEnumerator();
			for(uint i=0;i<inLines.Count;i++){
				enumerator.MoveNext();
				if (enumerator.Current is InLine){
					if((((InLine) enumerator.Current).Identifier == identifier)&&(((InLine) enumerator.Current).LineEnd == 0)){
						items.Add(new InLineEnd(fileLine, identifier, line,((InLine) enumerator.Current).ProcessBeginn,((InLine) enumerator.Current).ProcessEnd));
						((InLine) enumerator.Current).LineEnd = line;
						mLines = Math.Max(mLines, line);
						return InterpretResult.Ok;
					}
				}
			}
			return InterpretResult.IdentifierNotFound;
		}
		#endregion
		#region addInLineSeperator
		public InterpretResult AddInLineSeparator(uint fileLine, string identifier, uint line)
		{
			IEnumerator enumerator = inLines.GetEnumerator();
			for(uint i=0;i<inLines.Count;i++){
				enumerator.MoveNext();
				if (enumerator.Current is InLine){
					if((((InLine) enumerator.Current).Identifier == identifier)&&(((((InLine) enumerator.Current).LineEnd == 0))||(((InLine) enumerator.Current).LineEnd < line))){
						items.Add(new InLineSeparator(fileLine, identifier, line,((InLine) enumerator.Current).ProcessBeginn,((InLine) enumerator.Current).ProcessEnd));
						mLines = Math.Max(mLines, line);
						return InterpretResult.Ok;
					}
				}
			}
			return InterpretResult.IdentifierNotFound;
		}
		#endregion
		#region AddInLineText
		public InterpretResult AddInLineText(uint fileLine, string identifier, uint line, string text)
		{
			IEnumerator enumerator = inLines.GetEnumerator();
			for(uint i=0;i<inLines.Count;i++){
				enumerator.MoveNext();
				if (enumerator.Current is InLine){
					if((((InLine) enumerator.Current).Identifier == identifier)&&(((((InLine) enumerator.Current).LineEnd == 0))||(((InLine) enumerator.Current).LineEnd < line))){
						items.Add(new InLineText(fileLine, identifier, line,((InLine) enumerator.Current).ProcessBeginn,((InLine) enumerator.Current).ProcessEnd, text));
						mLines = Math.Max(mLines, line);
						return InterpretResult.Ok;
					}
				}
			}
			return InterpretResult.IdentifierNotFound;
		}
		#endregion
		#region addMessageBeginn
		public InterpretResult addMessageBeginn(uint fileLine, string identifier, int source, int destination, uint line, string name)
		{
			if (source >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (destination >= processes.Count)
				return InterpretResult.InstanceNotFound;
			items.Add(new MessageBegin(fileLine, identifier,name, line, source, destination));
			return addMessageLineBeginn(fileLine, identifier, line, source,destination);
		}
		
		public InterpretResult addMessageBeginn(uint fileLine, string identifier, string sourceName, string destinationName, uint line, string name)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int source=-1, destination=-1;	
			if(sourceName==ENV_LEFT_STRING){
				source = ENV_LEFT;
			}
			if(sourceName==ENV_RIGHT_STRING){
				source = ENV_RIGHT;
			}
			if(destinationName==ENV_LEFT_STRING){
				destination = ENV_LEFT;
			}
			if(destinationName==ENV_RIGHT_STRING){
				destination = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == sourceName){
					source=i;      
				}
				if(process.ProcessName == destinationName){
					destination=i;
				}
			}
			if((source != -1)&&(destination != -1)){
				items.Add(new MessageBegin(fileLine, identifier,name, line,source,destination));
				mLines = Math.Max(mLines, line);
				return addMessageLineBeginn(fileLine, identifier, line, source,destination);
			}
			else
				return InterpretResult.InstanceNotFound;
		}
		public InterpretResult addMessageBeginn(uint fileLine, string identifier, int source, int destination, uint line, string name, MessageStyle style)
		{
			if (source >= processes.Count)
				return InterpretResult.InstanceNotFound;
			if (destination >= processes.Count)
				return InterpretResult.InstanceNotFound;
			items.Add(new MessageBegin(fileLine, identifier,name, line, source, destination, style));
			return addMessageLineBeginn(fileLine, identifier, line, source,destination,style);
		}
		
		public InterpretResult addMessageBeginn(uint fileLine, string identifier, string sourceName, string destinationName, uint line, string name, MessageStyle style)
		{
			Process process;
			IEnumerator enumerator = processes.GetEnumerator();
			int source=-1, destination=-1;	
			if(sourceName==ENV_LEFT_STRING){
				source = ENV_LEFT;
			}
			if(sourceName==ENV_RIGHT_STRING){
				source = ENV_RIGHT;
			}
			if(destinationName==ENV_LEFT_STRING){
				destination = ENV_LEFT;
			}
			if(destinationName==ENV_RIGHT_STRING){
				destination = ENV_RIGHT;
			}
			for(int i=0;i<processes.Count;i++){
				enumerator.MoveNext();
				process = (Process) enumerator.Current;
				if(process.ProcessName == sourceName){
					source=i;      
				}
				if(process.ProcessName == destinationName){
					destination=i;
				}
			}
			if((source != -1)&&(destination != -1)){
				items.Add(new MessageBegin(fileLine, identifier,name, line,source,destination, style));
				mLines = Math.Max(mLines, line);
				return addMessageLineBeginn(fileLine, identifier, line, source,destination,style);
			}
			else
				return InterpretResult.InstanceNotFound;
		}
		#endregion		
		#region addMessageLineBeginn
		public InterpretResult addMessageLineBeginn(uint fileLine, string identifier, uint line, int source, int destination)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MessageLine)
					if((((MessageLine) enumerator.Current).LineEnd==0)&&(((MessageLine) enumerator.Current).Identifier == identifier)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new MessageLine(identifier, line+1, source, destination));
			return InterpretResult.Ok;
		}
		public InterpretResult addMessageLineBeginn(uint fileLine, string identifier, uint line, int source, int destination, MessageStyle style)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MessageLine)
					if((((MessageLine) enumerator.Current).LineEnd==0)&&(((MessageLine) enumerator.Current).Identifier == identifier)) return InterpretResult.LineAllreadyExists;
			}
			lines.Add(new MessageLine(identifier,line+1, source, destination, style));
			return InterpretResult.Ok;
		}
		#endregion		
		#region addMessageEnd
		public InterpretResult addMessageEnd(uint fileLine, string identifier, uint line)
		{
			IEnumerator enumerator = lines.GetEnumerator();
			for(uint i=0;i<lines.Count;i++){
				enumerator.MoveNext();
				if ( enumerator.Current is MessageLine)
					if((((MessageLine) enumerator.Current).LineEnd==0)&&(((MessageLine) enumerator.Current).Identifier == identifier)){
						items.Add(new MessageEnd(fileLine, identifier,line, ((MessageLine) enumerator.Current).MessageSource,((MessageLine) enumerator.Current).MessageDestination, ((MessageLine) enumerator.Current).MessageStyle));
						((MessageLine) enumerator.Current).LineEnd=line;
						mLines = Math.Max(mLines, line);
						return InterpretResult.Ok;
					}
			}
			return InterpretResult.LineNotExists;
		}
		#endregion		
	
	}
}
