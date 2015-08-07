/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 18:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
using mscEditor;
using MscItemProp;
	
namespace mscElements
{
	/// <summary>
	/// Description of TimeoutEnd.
	/// </summary>
	partial class TimerEnd
	{
		static public void RepertoryImage(Graphics drawDestination, ItemPos pos, ItemStyle style, MscStyle style2, TimerStyle tStyle)
		{
			StringFormat itemStringFormat = new StringFormat();				
			if (style2 == MscStyle.UML2){
				if (pos == ItemPos.Left){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(10,40,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,70,60,85,60);
						drawDestination.DrawLine(Pens.Black,75,10,75,60);
						if (tStyle == TimerStyle.End){
							drawDestination.DrawLine(Pens.Black,75,59,72,53);				
							drawDestination.DrawLine(Pens.Black,75,59,78,53);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,70,55,80,65);				
							drawDestination.DrawLine(Pens.Black,70,65,80,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						RectangleF itemBox = new RectangleF(0,40,35,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,30,60,85,60);
						drawDestination.DrawLine(Pens.Black,35,10,35,60);				
						if (tStyle == TimerStyle.End){
							drawDestination.DrawLine(Pens.Black,35,59,32,53);				
							drawDestination.DrawLine(Pens.Black,35,59,38,53);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,30,55,40,65);				
							drawDestination.DrawLine(Pens.Black,30,65,40,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(36,40,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,30,60,85,60);
						drawDestination.DrawLine(Pens.Black,35,10,35,60);				
						if (tStyle == TimerStyle.End){
							drawDestination.DrawLine(Pens.Black,35,59,32,53);				
							drawDestination.DrawLine(Pens.Black,35,59,38,53);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,30,55,40,65);				
							drawDestination.DrawLine(Pens.Black,30,65,40,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
				}
				else if (pos == ItemPos.Right){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(25,40,65,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,60,30,60);
						drawDestination.DrawLine(Pens.Black,25,10,25,60);
						if (tStyle == TimerStyle.End){
							drawDestination.DrawLine(Pens.Black,25,59,22,53);				
							drawDestination.DrawLine(Pens.Black,25,59,28,53);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,20,55,30,65);				
							drawDestination.DrawLine(Pens.Black,20,65,30,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						RectangleF itemBox = new RectangleF(65,40,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,60,70,60);
						drawDestination.DrawLine(Pens.Black,65,10,65,60);
						if (tStyle == TimerStyle.End){
							drawDestination.DrawLine(Pens.Black,65,59,62,53);				
							drawDestination.DrawLine(Pens.Black,65,59,68,53);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,60,55,70,65);				
							drawDestination.DrawLine(Pens.Black,60,65,70,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(0,40,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,60,70,60);
						drawDestination.DrawLine(Pens.Black,65,10,65,60);
						if (tStyle == TimerStyle.End){
							drawDestination.DrawLine(Pens.Black,65,59,62,53);				
							drawDestination.DrawLine(Pens.Black,65,59,68,53);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,60,55,70,65);				
							drawDestination.DrawLine(Pens.Black,60,65,70,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
				}
			}
			else if (style2 == MscStyle.SDL){
				if (pos == ItemPos.Left){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(10,40,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,75,60,85,60);
						drawDestination.DrawLine(Pens.Black,75,10,75,60);
						if (tStyle == TimerStyle.End){
							PointF[] capPolygon = new PointF[3];
							capPolygon[0] = new PointF(85, 60);
							capPolygon[1] = new PointF(79, 57);
							capPolygon[2] = new PointF(79, 63);
							drawDestination.FillPolygon(Brushes.Black,capPolygon);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,70,55,80,65);				
							drawDestination.DrawLine(Pens.Black,70,65,80,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						RectangleF itemBox = new RectangleF(0,40,35,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,35,60,85,60);
						drawDestination.DrawLine(Pens.Black,35,10,35,60);				
						if (tStyle == TimerStyle.End){
							PointF[] capPolygon = new PointF[3];
							capPolygon[0] = new PointF(85, 60);
							capPolygon[1] = new PointF(79, 57);
							capPolygon[2] = new PointF(79, 63);
							drawDestination.FillPolygon(Brushes.Black,capPolygon);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,30,55,40,65);				
							drawDestination.DrawLine(Pens.Black,30,65,40,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(36,40,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,85,10,85,70);
						drawDestination.DrawLine(Pens.Black,35,60,85,60);
						drawDestination.DrawLine(Pens.Black,35,10,35,60);				
						if (tStyle == TimerStyle.End){
							PointF[] capPolygon = new PointF[3];
							capPolygon[0] = new PointF(85, 60);
							capPolygon[1] = new PointF(79, 57);
							capPolygon[2] = new PointF(79, 63);
							drawDestination.FillPolygon(Brushes.Black,capPolygon);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,30,55,40,65);				
							drawDestination.DrawLine(Pens.Black,30,65,40,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
				}
				else if (pos == ItemPos.Right){
					if(style == ItemStyle.Normal){
						RectangleF itemBox = new RectangleF(25,40,65,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,60,25,60);
						drawDestination.DrawLine(Pens.Black,25,10,25,60);
						if (tStyle == TimerStyle.End){
							PointF[] capPolygon = new PointF[3];
							capPolygon[0] = new PointF(15, 60);
							capPolygon[1] = new PointF(21, 57);
							capPolygon[2] = new PointF(21, 63);
							drawDestination.FillPolygon(Brushes.Black,capPolygon);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,20,55,30,65);				
							drawDestination.DrawLine(Pens.Black,20,65,30,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
					}
					else if(style == ItemStyle.ExtendedOuter){
						RectangleF itemBox = new RectangleF(65,40,35,20);
						itemStringFormat.Alignment = StringAlignment.Near;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,60,65,60);
						drawDestination.DrawLine(Pens.Black,65,10,65,60);
						if (tStyle == TimerStyle.End){
							PointF[] capPolygon = new PointF[3];
							capPolygon[0] = new PointF(15, 60);
							capPolygon[1] = new PointF(21, 57);
							capPolygon[2] = new PointF(21, 63);
							drawDestination.FillPolygon(Brushes.Black,capPolygon);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,60,55,70,65);				
							drawDestination.DrawLine(Pens.Black,60,65,70,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
					else if(style == ItemStyle.ExtendedInner){
						RectangleF itemBox = new RectangleF(0,40,65,20);
						itemStringFormat.Alignment = StringAlignment.Far;
						drawDestination.DrawLine(Pens.DarkGray,15,10,15,70);
						drawDestination.DrawLine(Pens.Black,15,60,65,60);
						drawDestination.DrawLine(Pens.Black,65,10,65,60);
						if (tStyle == TimerStyle.End){
							PointF[] capPolygon = new PointF[3];
							capPolygon[0] = new PointF(15, 60);
							capPolygon[1] = new PointF(21, 57);
							capPolygon[2] = new PointF(21, 63);
							drawDestination.FillPolygon(Brushes.Black,capPolygon);
						}
						else if (tStyle == TimerStyle.Break){
							drawDestination.DrawLine(Pens.Black,60,55,70,65);				
							drawDestination.DrawLine(Pens.Black,60,65,70,55);							
						}
						drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);						
					}
				}
			}
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 30, 60, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			if (mMscStyle==MscStyle.SDL){
				drawDestination.DrawLine(Pens.Black,10,20,65,20);
				drawDestination.DrawLine(Pens.Black,10,60,65,60);
				PointF[] capPolygon = new PointF[3];
				capPolygon[0] = new PointF(65, 20);
				capPolygon[1] = new PointF(70, 15);
				capPolygon[2] = new PointF(60, 15);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				capPolygon[0] = new PointF(65, 20);
				capPolygon[1] = new PointF(70, 25);
				capPolygon[2] = new PointF(60, 25);
				drawDestination.DrawPolygon(Pens.Black,capPolygon);
				capPolygon[0] = new PointF(10, 60);
				capPolygon[1] = new PointF(10+8, 60-4);
				capPolygon[2] = new PointF(10+8, 60+4);
				drawDestination.FillPolygon(Brushes.Black,capPolygon);				
				drawDestination.DrawLine(Pens.Black,65,25,65,60);
			}
			else if(mMscStyle==MscStyle.UML2){
				drawDestination.DrawLine(Pens.Black,10,20,25,20);
				drawDestination.DrawLine(Pens.Black,10,60,25,60);				
				drawDestination.DrawLine(Pens.Black,20,20,20,60);				
				drawDestination.DrawLine(Pens.Black,20,21,23,27);				
				drawDestination.DrawLine(Pens.Black,20,21,17,27);				
				drawDestination.DrawLine(Pens.Black,20,59,23,53);				
				drawDestination.DrawLine(Pens.Black,20,59,17,53);				
			}
			drawDestination.DrawString("Timer",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			itemStringFormat.Dispose();
		}
		static public void RepertoryText(NumberingEditor.NumberingRichTextBox ew)
		{
			int ss = ew.SelectionStart;
			int se = ew.SelectionStart + ew.SelectionLength;
			string st = ew.SelectedText;
			if (se>0) se--;
			if (st.IndexOf('\n')>-1){
				string insertString;
				char [] c = ew.Text.ToCharArray();
				int i=0;
				for(i=se;i<c.Length;i++){
					if (c[i]=='\n'){
						i++;
						break;
					}
				}
				ew.SelectionStart = i;
				ew.SelectionLength = 0;
				insertString = "timerend: TimerId, TimerText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = i+insertString.Length+1;		
				
				for(i=ss;i>0;i--){
					if (c[i]=='\n'){
						i++;
						break;
					}
				}
				ew.SelectionStart = i;
				ew.SelectionLength = 0;
				insertString = "timerbegin: TimerId, InstanceId, TimerText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = i+insertString.Length+1;		
			}
			else{
				int nl = ew.Text.IndexOf('\n',se);
				if(nl>=0){
					nl++;
					ew.SelectionStart = nl;
					ew.SelectionLength = 0;
				}
				else {
					nl=ew.Text.Length;
					ew.SelectionStart = nl;
					ew.SelectionLength = 0;
					ew.SelectedText = "\n";		
				}
				string insertString = "timerbegin: TimerId, InstanceId, TimerText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				insertString = "timerend: TimerId, TimerText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = nl+insertString.Length+1;		
			}
		}
		public override Property GetPropertyDialog(string text)
		{
			TimerEndProp property = new TimerEndProp(this.ItemPos, this.IStyle);
			property.TimerText = this.mName.Replace("\n",@"\n");
			property.TimerStyle = this.mTimerStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
