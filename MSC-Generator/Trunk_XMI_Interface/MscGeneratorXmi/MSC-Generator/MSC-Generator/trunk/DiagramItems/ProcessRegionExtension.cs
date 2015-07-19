/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 07:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using nGenerator;
using MscItemProp;

namespace mscElements
{
	/// <summary>
	/// Description of ProcessRegion.
	/// </summary>
	partial class ProcessRegion
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			itemStringFormat.Alignment = StringAlignment.Near;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			RectangleF itemBox = new RectangleF(30, 30, 40, 20);
			drawDestination.DrawString("Region",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawLine(Pens.LightGray,20,10,20,20);
			drawDestination.DrawLine(Pens.LightGray,20,60,20,70);
			drawDestination.FillRectangle(Brushes.LightGray,15, 20, 10, 40);
			drawDestination.DrawLine(Pens.Black,15,20,25,20);
			drawDestination.DrawLine(Pens.Black,15,60,25,60);
			drawDestination.DrawLine(Pens.Black,15,20, 15,60);
			drawDestination.DrawLine(Pens.Black,25,20, 25,60);
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, ProcessStyle style, MscStyle style2)
		{
			float[] pattern = new float[2]{5f,5f};
			Pen pen = new Pen(Color.Black);
			drawDestination.DrawLine(Pens.DarkGray,40,10,40,20);
			drawDestination.DrawLine(Pens.DarkGray,40,60,40,70);
			drawDestination.DrawLine(Pens.Black,35,20,45,20);
			drawDestination.DrawLine(Pens.Black,35,60,45,60);
			switch(style){
				case ProcessStyle.Activation:
					drawDestination.FillRectangle(Brushes.DarkGray,35, 20, 10, 40);
					drawDestination.DrawLine(Pens.Black,35,20, 35,60);
					drawDestination.DrawLine(Pens.Black,45,20, 45,60);
					break;
				case ProcessStyle.Suspension:
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					pen.DashPattern = pattern;
					drawDestination.DrawLine(pen,35,20, 35,60);
					drawDestination.DrawLine(pen,45,20, 45,60);
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					break;
				case ProcessStyle.Coregion:
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					pen.DashPattern = pattern;
					drawDestination.DrawLine(pen,40,20, 40,60);
					if (style2 == MscStyle.UML2){
						drawDestination.DrawLine(Pens.Black,35,20, 35,25);
						drawDestination.DrawLine(Pens.Black,45,20, 45,25);
						drawDestination.DrawLine(Pens.Black,35,60, 35,55);
						drawDestination.DrawLine(Pens.Black,45,60, 45,55);
					}
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					break;
			}
			drawDestination.DrawLine(Pens.Black,35,20,45,20);
			drawDestination.DrawLine(Pens.Black,35,60,45,60);
			pen.Dispose();
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
				insertString = "regionend: InstanceId;";
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
				insertString = "regionbegin: InstanceId, Activation;";
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
				string insertString = "regionbegin: InstanceId, Activation;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				insertString = "regionend: InstanceId;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = nl+insertString.Length+1;		
			}
		}
		public override Property GetPropertyDialog(string text)
		{
			ProcessRegionProp property = new ProcessRegionProp();
			property.Style = this.mStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
