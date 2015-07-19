/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 12:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using nGenerator;
using mscEditor;
using MscItemProp;

namespace mscElements
{
	
	partial class Message
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(18, 25, 52, 20);
			itemStringFormat.Alignment = StringAlignment.Center;
			drawDestination.DrawString("Message",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.LightGray,70,10,70,70);
			if (mMscStyle == MscStyle.SDL){
				drawDestination.DrawLine(Pens.Black,10,40,70,40);
				PointF[] messagePolygon = new PointF[3];
				messagePolygon[0] = new PointF(10, 40);
				messagePolygon[1] = new PointF(10+8, 40-4);
				messagePolygon[2] = new PointF(10+8, 40+4);
				drawDestination.FillPolygon(Brushes.Black,messagePolygon);
			}
			else if(mMscStyle == MscStyle.UML2){
				drawDestination.DrawLine(Pens.Black,10,40,70,40);
				drawDestination.DrawLine(Pens.Black,10,40,10+8, 40-4);
				drawDestination.DrawLine(Pens.Black,10,40,10+8, 40+4);								
			}
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, MessageStyle style, MscStyle style2)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 28, 60, 15);
			Pen pen = new Pen(Color.Black);
			float[] pattern = {3f,3f};
			itemStringFormat.Alignment = StringAlignment.Center;
			drawDestination.DrawString("Message",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			drawDestination.DrawLine(Pens.DarkGray,5,10,5,70);
			drawDestination.DrawLine(Pens.DarkGray,75,10,75,70);
			if (style2 == MscStyle.SDL){
				if((style == MessageStyle.Normal)||(style == MessageStyle.Synchron)){
					drawDestination.DrawLine(Pens.Black,5,40,75,40);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(5, 40);
					messagePolygon[1] = new PointF(5+8, 40-4);
					messagePolygon[2] = new PointF(5+8, 40+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
				}
				else if (style == MessageStyle.Dashed){
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					pen.DashPattern = pattern;	
					drawDestination.DrawLine(pen,5,40,75,40);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(5, 40);
					messagePolygon[1] = new PointF(5+8, 40-4);
					messagePolygon[2] = new PointF(5+8, 40+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;					
				}
			}
			else if(style2 == MscStyle.UML2){
				if( style == MessageStyle.Normal){
					drawDestination.DrawLine(Pens.Black,5,40,75,40);
					drawDestination.DrawLine(Pens.Black,5,40,5+8, 40-4);
					drawDestination.DrawLine(Pens.Black,5,40,5+8, 40+4);								
				}
				else if( style == MessageStyle.Dashed){
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					pen.DashPattern = pattern;	
					drawDestination.DrawLine(pen,5,40,75,40);
					pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;					
					drawDestination.DrawLine(Pens.Black,5,40,5+8, 40-4);
					drawDestination.DrawLine(Pens.Black,5,40,5+8, 40+4);													
				}
				else if( style == MessageStyle.Synchron){
					drawDestination.DrawLine(Pens.Black,5,40,75,40);
					PointF[] messagePolygon = new PointF[3];
					messagePolygon[0] = new PointF(5, 40);
					messagePolygon[1] = new PointF(5+8, 40-4);
					messagePolygon[2] = new PointF(5+8, 40+4);
					drawDestination.FillPolygon(Brushes.Black,messagePolygon);					
				}
			}
			pen.Dispose();
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
				insertString = "msgend: MsgId;";
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
				insertString = "msgbegin: MsgId, SourceInstanceId, DestinationInstanceId, MessageText;";
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
				string insertString = "msg: SourceInstanceId, DestinationInstanceId, MessageText;";			
				ew.SelectedText = insertString;
				ew.SelectedText = "\n";
				ew.SelectionStart = nl+insertString.Length+1;		
			}
		}
		public override Property GetPropertyDialog(string text)
		{
			MessageProp property = new MessageProp();
			property.MessageText = this.mName.Replace("\n",@"\n");
			property.Style = this.mStyle;
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
