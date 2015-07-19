/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 17.01.2006
 * Time: 12:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
#define TRACE
using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Threading;
using mscElements;
using System.Windows.Forms;
using nGenerator;
using System.Diagnostics;

namespace mscEditor
{
	/// <summary>
	/// Description of Editor.
	/// </summary>
	public class Editor
	{
		
		private Color propertyCommandColor = Color.Orange;
		private Font propertyCommandFont = new Font("Tahoma",8,FontStyle.Bold);
		private Color commandColor = Color.Red;
		private Font commandFont = new Font("Tahoma",8,FontStyle.Bold);
		private Color instanceColor = Color.Blue;
		private Font instanceFont = new Font("Tahoma",8,FontStyle.Regular);
		private Color elementColor = Color.Chocolate;
		private Font elementFont = new Font("Tahoma",8,FontStyle.Regular);
		private Color parameterColor = Color.Violet;
		private Font parameterFont = new Font("Tahoma",8,FontStyle.Regular);
		private Color formatColor = Color.DarkTurquoise;
		private Font formatFont = new Font("Tahoma",8,FontStyle.Regular);
		private Color propertyColor = Color.DarkSlateGray;
		private Font propertyFont = new Font("Tahoma",8,FontStyle.Regular);		
		private Color normalColor = Color.Black;
		private Font normalFont = new Font("Tahoma",8,FontStyle.Regular);		
		private Color nodeColor = Color.Blue;
		private Font nodeFont = new Font("Tahoma",8,FontStyle.Bold);		
		
		private ArrayList mscCommands = new ArrayList();
		private ArrayList instances = new ArrayList();
		private ArrayList instanceError = new ArrayList();
		private NumberingEditor.NumberingRichTextBox mRtb;
		private int cursorPosition = 0;
		private object mParent = null;
		
		//private Thread ThChecks;
		//private delegate void ChecksDelegate();
		
		static bool work = false;
		
		public Editor(object parent, NumberingEditor.NumberingRichTextBox ew)
		{
			mRtb = ew;
			mscCommands.Clear();
			instances.Clear();
			mParent = parent;
			//define msc draw commands				command,elementIds,instanceIds,text,[format]
			mscCommands.Add(new MSCCommandSyntax("actor",new int[]{},new int[]{1},new int[]{2,3},new int[]{4,5},true)); 			//in help
			mscCommands.Add(new MSCCommandSyntax("comment",new int[]{},new int[]{1},new int[]{2},new int[]{3})); 					//in help
			mscCommands.Add(new MSCCommandSyntax("commentoverall",new int[]{},new int[]{},new int[]{1})); 							//in help
			mscCommands.Add(new MSCCommandSyntax("create",new int[]{},new int[]{1,2},new int[]{3,4,5})); 							//in help
			mscCommands.Add(new MSCCommandSyntax("dummyprocess",new int[]{},new int[]{1},new int[]{},new int[]{2,3},true)); 		//in help
			mscCommands.Add(new MSCCommandSyntax("found",new int[]{},new int[]{1},new int[]{2,3},new int[]{4}));					//in help
//			mscCommands.Add(new MSCCommandSyntax("inlinebegin",new int[]{1},new int[]{2,3},new int[]{4}));							//not supported
//			mscCommands.Add(new MSCCommandSyntax("inlineend",new int[]{1},new int[]{},new int[]{}));								//not supported
//			mscCommands.Add(new MSCCommandSyntax("inlineseperator",new int[]{1},new int[]{},new int[]{}));							//not supported
			mscCommands.Add(new MSCCommandSyntax("fragmentbegin",new int[]{1},new int[]{2,3},new int[]{4}));						//in help
			mscCommands.Add(new MSCCommandSyntax("fragmentend",new int[]{1},new int[]{},new int[]{}));								//in help
			mscCommands.Add(new MSCCommandSyntax("fragmentseparator",new int[]{1},new int[]{},new int[]{}));						//in help
			mscCommands.Add(new MSCCommandSyntax("fragmenttext",new int[]{1},new int[]{},new int[]{2}));							//in help
			mscCommands.Add(new MSCCommandSyntax("linecomment",new int[]{},new int[]{1},new int[]{2},new int[]{3,4}));				//in help
			mscCommands.Add(new MSCCommandSyntax("lost",new int[]{},new int[]{1},new int[]{2,3},new int[]{4}));						//in help
			mscCommands.Add(new MSCCommandSyntax("mark",new int[]{},new int[]{1},new int[]{2},new int[]{3}));						//in help
			mscCommands.Add(new MSCCommandSyntax("measurebegin",new int[]{},new int[]{1},new int[]{2},new int[]{3,4}));				//in help
			mscCommands.Add(new MSCCommandSyntax("measureend",new int[]{},new int[]{1},new int[]{2}));								//in help
			mscCommands.Add(new MSCCommandSyntax("measurestart",new int[]{},new int[]{1},new int[]{2,3},new int[]{4,5}));			//in help
			mscCommands.Add(new MSCCommandSyntax("measurestop",new int[]{},new int[]{1},new int[]{2,3},new int[]{4,5}));			//in help
			mscCommands.Add(new MSCCommandSyntax("msg",new int[]{},new int[]{1,2},new int[]{3},new int[]{4}));						//in help
			mscCommands.Add(new MSCCommandSyntax("msgbegin",new int[]{1},new int[]{2,3},new int[]{4},new int[]{5}));				//in help
			mscCommands.Add(new MSCCommandSyntax("msgend",new int[]{1},new int[]{},new int[]{}));									//in help
			mscCommands.Add(new MSCCommandSyntax("process",new int[]{},new int[]{1},new int[]{2,3},new int[]{4,5},true));			//in help
			mscCommands.Add(new MSCCommandSyntax("ref",new int[]{},new int[]{1,2},new int[]{3}));									//in help
			mscCommands.Add(new MSCCommandSyntax("regionend",new int[]{},new int[]{1},new int[]{}));								//in help
//			mscCommands.Add(new MSCCommandSyntax("regionstart",new int[]{},new int[]{1},new int[]{},new int[]{2}));					//not supported
			mscCommands.Add(new MSCCommandSyntax("regionbegin",new int[]{},new int[]{1},new int[]{},new int[]{2}));					//in help
			mscCommands.Add(new MSCCommandSyntax("settimer",new int[]{},new int[]{1},new int[]{2},new int[]{3}));					//in help
//			mscCommands.Add(new MSCCommandSyntax("sidecomment",new int[]{},new int[]{},new int[]{1},new int[]{2}));					//not supported
			mscCommands.Add(new MSCCommandSyntax("state",new int[]{},new int[]{1},new int[]{2},new int[]{3,4}));					//in help
			mscCommands.Add(new MSCCommandSyntax("stateoverall",new int[]{},new int[]{},new int[]{1}));								//in help
			mscCommands.Add(new MSCCommandSyntax("stop",new int[]{},new int[]{1},new int[]{})); 									//in help
			mscCommands.Add(new MSCCommandSyntax("stoptimer",new int[]{},new int[]{1},new int[]{2},new int[]{3}));					//in help
			mscCommands.Add(new MSCCommandSyntax("task",new int[]{},new int[]{1},new int[]{2},new int[]{3}));						
			mscCommands.Add(new MSCCommandSyntax("timeout",new int[]{},new int[]{1},new int[]{2},new int[]{3}));					//in help
//			mscCommands.Add(new MSCCommandSyntax("timeoutbegin",new int[]{},new int[]{1},new int[]{2},new int[]{3,4}));				//not supported
//			mscCommands.Add(new MSCCommandSyntax("timeoutend",new int[]{},new int[]{1},new int[]{2},new int[]{3}));					//not supported
//			mscCommands.Add(new MSCCommandSyntax("timeoutstop",new int[]{},new int[]{1},new int[]{2},new int[]{3}));				//not supported
			mscCommands.Add(new MSCCommandSyntax("timerbegin",new int[]{1},new int[]{2},new int[]{3},new int[]{4,5}));				//in help		
			mscCommands.Add(new MSCCommandSyntax("timerend",new int[]{1},new int[]{},new int[]{2},new int[]{3}));					//in help

			// define property commands
			mscCommands.Add(new MSCCommandSyntax("language", new int[]{1}));					//in help 
			mscCommands.Add(new MSCCommandSyntax("printauthor", new int[]{1}));					//in help 
			mscCommands.Add(new MSCCommandSyntax("printcompany", new int[]{1}));				//in help
			mscCommands.Add(new MSCCommandSyntax("printversion", new int[]{1}));				//in help
			mscCommands.Add(new MSCCommandSyntax("printdate", new int[]{1}));					//in help
			mscCommands.Add(new MSCCommandSyntax("printcreationdate", new int[]{1}));			//in help
			mscCommands.Add(new MSCCommandSyntax("printfilename", new int[]{1}));				//in help
			mscCommands.Add(new MSCCommandSyntax("printfootline", new int[]{1}));				//in help
			mscCommands.Add(new MSCCommandSyntax("author", new int[]{1}));						//in help
			mscCommands.Add(new MSCCommandSyntax("company", new int[]{1}));						//in help
			mscCommands.Add(new MSCCommandSyntax("version", new int[]{1}));						//in help
			mscCommands.Add(new MSCCommandSyntax("date", new int[]{1}));						//in help
			mscCommands.Add(new MSCCommandSyntax("backcolor", new int[]{1}));					//in help
			mscCommands.Add(new MSCCommandSyntax("fillcolor", new int[]{1}));					//in help
			mscCommands.Add(new MSCCommandSyntax("textcolor", new int[]{1}));					//in help
			mscCommands.Add(new MSCCommandSyntax("lineoffset", new int[]{1}));					//in help
//			mscCommands.Add(new MSCCommandSyntax("mscname", new int[]{1}));						//not supported
			mscCommands.Add(new MSCCommandSyntax("diagramname", new int[]{1}));					//in help
//			mscCommands.Add(new MSCCommandSyntax("mscheight", new int[]{1,2}));					//not supported
//			mscCommands.Add(new MSCCommandSyntax("mscmarginbottom", new int[]{1,2}));			//not supported
//			mscCommands.Add(new MSCCommandSyntax("mscmarginleft", new int[]{1,2}));				//not supported
//			mscCommands.Add(new MSCCommandSyntax("mscmarginright", new int[]{1,2}));			//not supported
//			mscCommands.Add(new MSCCommandSyntax("mscmargintop", new int[]{1,2}));				//not supported
//			mscCommands.Add(new MSCCommandSyntax("mscwidth", new int[]{1,2}));					//not supported
//			mscCommands.Add(new MSCCommandSyntax("mscstyle", new int[]{1},new RunCommandFunction(((Output)mParent).CBMscStyle)));	//not supported
			mscCommands.Add(new MSCCommandSyntax("diagramstyle", new int[]{1},new RunCommandFunction(((Output)mParent).CBMscStyle))); //in help
			mscCommands.Add(new MSCCommandSyntax("pagesize", new int[]{1,2,3}));				//in help
			mscCommands.Add(new MSCCommandSyntax("pagemargins", new int[]{1,2,3,4,5}));			//in help
			mscCommands.Add(new MSCCommandSyntax("left", new int[]{1}));						//in help
			mscCommands.Add(new MSCCommandSyntax("right", new int[]{1}));						//in help
			mscCommands.Add(new MSCCommandSyntax("font", new int[]{1,2,3}));					//in help
			mscCommands.Add(new MSCCommandSyntax("nextpage", new int[]{}));						//in help
						
			//mscCommands.Add(new MSCCommandSyntax("mscfont", new int[]{1}));
			
			//this.ThChecks = new Thread(new ThreadStart(Checks));
			//this.ThChecks.Start();
		}
		
		/*private void Checks()
		{
			ChecksDelegate Check = new ChecksDelegate(checkInstances);
			while((Thread.CurrentThread.ThreadState & ThreadState.Running)==ThreadState.Running){
				mRtb.Invoke(Check);
				Thread.Sleep(100);
			}
		}*/
		public bool Update{
			set{
				if (value==true){
					mRtb.BeginUpdate();
				}
				if (value==false){
					mRtb.EndUpdate();
				}
			}
		}
		private MSCCommandSyntax GetSyntax(string command)
		{
			IEnumerator enumerator = mscCommands.GetEnumerator();
			for(uint i=0; i<mscCommands.Count;i++){										
				enumerator.MoveNext();
				if (((MSCCommandSyntax) enumerator.Current).command.ToLower() == command.ToLower()){
					return (MSCCommandSyntax) enumerator.Current;
				}
			}
			return null;
		}		

		private bool IsValidInstance(string instance)
		{

			IEnumerator enumerator = instances.GetEnumerator();
			for(uint i=0; i<instances.Count;i++){										
				enumerator.MoveNext();
				if (enumerator.Current.ToString().Trim() == instance.Trim()){
					return true;
				}
			}
			return false;
		}		
		
		private void CheckInstances()
		{
			StringBuilder command;
			MSCCommandSyntax syntax = null;
			bool commandValid = false;
			bool quote = false, slash=false;
			int commandPos=0, posStart=0, posEnd;
			int selStart=0, selLength=0;
			string text = mRtb.Text;
			char[] c = text.ToCharArray();
			posEnd = c.Length;
			instances.Clear();
			instances.Add("ENV_RIGHT");
			instances.Add("ENV_LEFT");
			instanceError.Clear();
			for (int i=posStart; i<posEnd;i++)
			{
				switch(c[i]){
					case ':':
						slash=false;
						if (quote==true){
							selLength++;
							break;
						}
						if(commandPos==0){
							command = new StringBuilder(text.Substring(selStart,selLength).Trim());
							syntax = GetSyntax(command.ToString());
							
							if (syntax!=null){
								commandValid = true;
							}
						}
						commandPos++;
						if (i<text.Length) selStart = i+1;
						selLength = 0;
						break;
					case '\n':
						slash=false;
						if (commandValid==true){
							switch(syntax.GetParamType(commandPos)){
								case ParamType.InstanceID:
									if (syntax.instanceBuilder == true){
										instances.Add(text.Substring(selStart,selLength));
									}
									else{
										string tmpInstance = text.Substring(selStart,selLength);
										if ((tmpInstance.Trim().StartsWith("\"")) & (tmpInstance.Trim().EndsWith("\""))){
											tmpInstance = tmpInstance.Replace("\"","");
											string[] tmpInstances = tmpInstance.Split(',');
											for (int j=0; j<tmpInstances.Length;j++){
												if (!IsValidInstance(tmpInstances[j])){
													instanceError.Add(new NumberingEditor.ErrorPosition(selStart+tmpInstance.IndexOf(tmpInstances[j])+1,selStart+tmpInstance.IndexOf(tmpInstances[j])+tmpInstances[j].Length+1));
												}															
											}
										}
										else{
											if (!IsValidInstance(tmpInstance)){
												instanceError.Add(new NumberingEditor.ErrorPosition(selStart,selStart+selLength));
											}			
										}
									}
									break;
							}
						}
						if (i<text.Length) selStart = i+1;
						selLength =0;
						commandPos = 0;
						commandValid = false;
						quote = false;
						break;
					case ',':
					case ';':
						slash=false;
						if (quote==true){
							selLength++;
							break;
						}
						if (commandValid==true){
							switch(syntax.GetParamType(commandPos)){
								case ParamType.InstanceID:
									if (syntax.instanceBuilder == true){
										instances.Add(text.Substring(selStart,selLength));
									}
									else{
										string tmpInstance = text.Substring(selStart,selLength);
										if ((tmpInstance.Trim().StartsWith("\"")) & (tmpInstance.Trim().EndsWith("\""))){
											tmpInstance = tmpInstance.Replace("\"","");
											string[] tmpInstances = tmpInstance.Split(',');
											for (int j=0; j<tmpInstances.Length;j++){
												if (!IsValidInstance(tmpInstances[j])){
													instanceError.Add(new NumberingEditor.ErrorPosition(selStart+tmpInstance.IndexOf(tmpInstances[j])+1,selStart+tmpInstance.IndexOf(tmpInstances[j])+tmpInstances[j].Length+1));
												}															
											}
										}
										else{
											if (!IsValidInstance(tmpInstance)){
												instanceError.Add(new NumberingEditor.ErrorPosition(selStart,selStart+selLength));
											}			
										}
									}
									break;
							}
						}
						if (i<text.Length) selStart = i+1;
						selLength =0;
						commandPos++;
						break;
					case '\\':
						if (slash==false){
							slash=true;
						}
						else{
							slash=false;
						}
						selLength++;
						break;
					case '"':
						if (slash==false){
							if (quote==true) quote=false; else quote=true;
						}
						slash=false;
						selLength++;
						break;
					default:
						slash=false;
						selLength++;
						break;
				}
			}
			if (commandValid==true){
				switch(syntax.GetParamType(commandPos)){
					case ParamType.InstanceID:
						if (syntax.instanceBuilder == true){
							instances.Add(text.Substring(selStart,selLength));
						}
						else{
							string tmpInstance = text.Substring(selStart,selLength);
							if ((tmpInstance.Trim().StartsWith("\"")) & (tmpInstance.Trim().EndsWith("\""))){
								tmpInstance = tmpInstance.Replace("\"","");
								string[] tmpInstances = tmpInstance.Split(',');
								for (int j=0; j<tmpInstances.Length;j++){
									if (!IsValidInstance(tmpInstances[j])){
										instanceError.Add(new NumberingEditor.ErrorPosition(selStart+tmpInstance.IndexOf(tmpInstances[j])+1,selStart+tmpInstance.IndexOf(tmpInstances[j])+tmpInstances[j].Length+1));
									}															
								}
							}
							else{
								if (!IsValidInstance(tmpInstance)){
									instanceError.Add(new NumberingEditor.ErrorPosition(selStart,selStart+selLength));
								}			
							}
						}
						break;
				}
			}
			NumberingEditor.ErrorPosition[] temp = new NumberingEditor.ErrorPosition[instanceError.Count];
			IEnumerator enumerator = instanceError.GetEnumerator();
			for(uint i=0; i<instanceError.Count;i++){										
				enumerator.MoveNext();
				temp[i] = (NumberingEditor.ErrorPosition) enumerator.Current;
			}
			NumberingEditor.NumberingRichTextBox.ErrorPositions = temp;
		}

		private void CheckCommands(int pos)
		{
			string command = string.Empty;
			MSCCommandSyntax syntax = null;
			bool commandValid = false;
			bool quote = false, slash = false;
			bool bracket = false;
			int commandPos=0, posStart=0, posEnd=mRtb.Text.Length;
			int selLength=0;
			char[] c = mRtb.Text.ToCharArray();
			if (pos>-1){
				posStart = mRtb.Text.Substring(0,pos).LastIndexOf('\n') +1;
				posEnd = mRtb.Text.IndexOf('\n',pos);
				if (posEnd==-1) posEnd=mRtb.Text.Length;
			}
			mRtb.SelectionStart=posStart;
			mRtb.SelectionLength = posEnd - posStart;
			mRtb.SelectionFont= normalFont;
			mRtb.SelectionColor = normalColor;								
			mRtb.SelectionLength=0;
//			c = mRtb.Text.ToCharArray(posStart, posEnd - posStart);
			for (int i=posStart; i<posEnd;i++)
//			int i = posStart-1;
//			foreach (char b in c)
			{
////				i++;
				switch(c[i]){
//				switch(b){
					case ':':
						slash=false;
						if ((quote==true)||(bracket==true)){
							selLength++;
							break;
						}
						if(commandPos==0){
							mRtb.SelectionLength = selLength;
							command = mRtb.SelectedText;
							syntax = GetSyntax(command.TrimStart(new char[2]{' ','\t'}));
							
							if (syntax!=null){
								commandValid = true;
								switch(syntax.Type){
									case CommandType.Command:
										mRtb.SelectionFont= commandFont;
										mRtb.SelectionColor = commandColor;
										break;
									case CommandType.Property:
										mRtb.SelectionFont= propertyCommandFont;
										mRtb.SelectionColor = propertyCommandColor;
										break;
								}
							}
							else{
								commandValid = false;
							}
						}
						commandPos++;
						if (i<mRtb.Text.Length) mRtb.SelectionStart = i+1;
						selLength = 0;
						break;
					case '\n':
						slash=false;
						if (commandValid==true){
							mRtb.SelectionLength = selLength;
							switch(syntax.GetParamType(commandPos)){
								case ParamType.Text:
									mRtb.SelectionFont= parameterFont;
									mRtb.SelectionColor = parameterColor;
									break;
								case ParamType.InstanceID:
									mRtb.SelectionFont= instanceFont;
									mRtb.SelectionColor = instanceColor;
									break;
								case ParamType.ElementID:
									mRtb.SelectionFont= elementFont;
									mRtb.SelectionColor = elementColor;
									break;			
								case ParamType.Format:
									mRtb.SelectionFont= formatFont;
									mRtb.SelectionColor = formatColor;
									break;			
								case ParamType.Property:
									mRtb.SelectionFont= propertyFont;
									mRtb.SelectionColor = propertyColor;
									break;			
							}
						}
						if (i<mRtb.Text.Length) mRtb.SelectionStart = i+1;
						selLength =0;
						commandPos = 0;
						commandValid = false;
						quote = false;
						break;
					case ',':
					case ';':
						slash=false;
						if ((quote==true)||(bracket==true)){
							selLength++;
							break;
						}
						if (commandValid==true){
							mRtb.SelectionLength = selLength;
							switch(syntax.GetParamType(commandPos)){
								case ParamType.Text:
									mRtb.SelectionFont= parameterFont;
									mRtb.SelectionColor = parameterColor;
									break;
								case ParamType.InstanceID:
									mRtb.SelectionFont= instanceFont;
									mRtb.SelectionColor = instanceColor;
									break;
								case ParamType.ElementID:
									mRtb.SelectionFont= elementFont;
									mRtb.SelectionColor = elementColor;
									break;			
								case ParamType.Format:
									mRtb.SelectionFont= formatFont;
									mRtb.SelectionColor = formatColor;
									break;			
								case ParamType.Property:
									mRtb.SelectionFont= propertyFont;
									mRtb.SelectionColor = propertyColor;
									break;			
							}
						}
						if (i<mRtb.Text.Length) mRtb.SelectionStart = i+1;
						selLength=0;
						commandPos++;
						break;
					case '\\':
						if (slash==false){
							slash=true;
						}
						else{
							slash=false;
						}
						selLength++;
						break;
					case '"':
						if (slash==false){
							if (quote==true) quote=false; else quote=true;
						}
						slash=false;
						selLength++;
						break;
					default:
						slash=false;
						selLength++;
						break;
				}
			}
			if (commandValid==true){
				mRtb.SelectionLength = selLength;
				switch(syntax.GetParamType(commandPos)){
					case ParamType.Text:
						mRtb.SelectionFont= parameterFont;
						mRtb.SelectionColor = parameterColor;
						break;
					case ParamType.InstanceID:
						mRtb.SelectionFont= instanceFont;
						mRtb.SelectionColor = instanceColor;
						break;
					case ParamType.ElementID:
						mRtb.SelectionFont= elementFont;
						mRtb.SelectionColor = elementColor;
						break;			
					case ParamType.Format:
						mRtb.SelectionFont= formatFont;
						mRtb.SelectionColor = formatColor;
						break;			
					case ParamType.Property:
						mRtb.SelectionFont= propertyFont;
						mRtb.SelectionColor = propertyColor;
						break;			
				}
				syntax.RunFunction(mRtb.GetLineFromCharIndex(posStart));
			}			
		}
		public void CheckComments(int pos)
		{
			bool comment = false;
			bool firstLetter = true;
			int firstLetterPos=0;
			int posStart=0, posEnd=posEnd=mRtb.Text.Length;
			char[] c = mRtb.Text.ToCharArray();
			if (pos>-1){
				posStart = mRtb.Text.Substring(0,pos).LastIndexOf('\n') +1;
				posEnd = mRtb.Text.IndexOf('\n',pos);
				if (posEnd==-1) posEnd=mRtb.Text.Length; else posEnd++;
			}
			for (int i=posStart; i<posEnd;i++)
			{
				switch(c[i]){
					case '#':
						if (firstLetter==true){
							comment=true;
							firstLetter=false;
							firstLetterPos = i;
						}
						break;
					case ' ':
						break;
					case '\t':
						break;
					case '\n':
						if (comment==true){
							mRtb.SelectionStart = firstLetterPos;
							mRtb.SelectionLength = i - firstLetterPos;
							mRtb.SelectionColor = Color.Green;
						}
						firstLetter = true;
						comment = false;
						break;
					default:
						firstLetter = false;
						break;
				}
			}
			if (comment==true){
				mRtb.SelectionStart = firstLetterPos;
				mRtb.SelectionLength = posEnd - firstLetterPos;
				mRtb.SelectionColor = Color.Green;
			}			
		}
		
		public void CheckSyntax(int firstChar, int lastChar)
		{
			int i=firstChar;
			string text = mRtb.Text.Substring(firstChar,lastChar-firstChar);
			if (work!=true){
				work=true;
				mRtb.BeginUpdate();				
				cursorPosition = mRtb.SelectionStart;
				CheckInstances();
				CheckCommands(firstChar);
				CheckComments(firstChar);
				i=mRtb.Text.IndexOf('\n', i);
				while((i>-1)&&(i<=lastChar)){
					CheckCommands(i+1);
					CheckComments(i+1);
					i=mRtb.Text.IndexOf('\n', i+1);
				}
				mRtb.SelectionStart = cursorPosition;
				mRtb.SelectionLength = 0;
				mRtb.EndUpdate();
				work=false;		
			}
		}
		
		public void CheckSyntax()
		{
			if (work!=true){
				work=true;
				mRtb.BeginUpdate();				
				cursorPosition = mRtb.SelectionStart;
				CheckInstances();
				CheckCommands(cursorPosition);
				CheckComments(cursorPosition);
				mRtb.SelectionStart = cursorPosition;
				mRtb.SelectionLength = 0;
				mRtb.EndUpdate();
				work=false;		
			}
		}
		public void checkSyntaxAll()
		{
			if (work!=true){
				work=true;
				mRtb.BeginUpdate();
				cursorPosition = mRtb.SelectionStart;
				CheckInstances();
							Trace.WriteLine(DateTime.Now.TimeOfDay + " checkCommands");
 				CheckCommands(-1);
							Trace.WriteLine(DateTime.Now.TimeOfDay + " Fertig!");
 				CheckComments(-1);
 				mRtb.SelectionStart = cursorPosition;
				mRtb.SelectionLength = 0;
				mRtb.EndUpdate();
				work=false;		
			}
 		}
	}
}
