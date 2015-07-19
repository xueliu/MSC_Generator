/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 31.08.2006
 * Time: 19:15
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
	/// Description of InLineBeginn.
	/// </summary>
	partial class InLineBeginn
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(5, 15, 30, 15);
			itemStringFormat.Alignment = StringAlignment.Near;
			itemStringFormat.LineAlignment = StringAlignment.Near;
			PointF[] statePolygon = new PointF[5];
			statePolygon[0] = new PointF(5,15);
			statePolygon[1] = new PointF(40,15);
			statePolygon[2] = new PointF(40,25);
			statePolygon[3] = new PointF(35,30);
			statePolygon[4] = new PointF(5,30);
			drawDestination.FillPolygon(Brushes.White,statePolygon);
			drawDestination.DrawPolygon(Pens.Black,statePolygon);
			drawDestination.DrawRectangle(Pens.Black,5,15,70,50);
			drawDestination.DrawString("frag",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
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
				insertString = "fragmentend: FragmentId;";
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
				insertString = "fragmentbegin: FragmentId, FirstInstanceId, LastInstanceId, FragmentText;";
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
				string insertString = "fragmentbegin: FragmentId, FirstInstanceId, LastInstanceId, FragmentText;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				insertString = "fragmentend: FragmentId;";
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = nl+insertString.Length+1;		
			}
		}
		public override Property GetPropertyDialog(string text)
		{
			InLineBeginProp property = new InLineBeginProp();
			property.InlineText = this.mName.Replace("\n",@"\n");
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
