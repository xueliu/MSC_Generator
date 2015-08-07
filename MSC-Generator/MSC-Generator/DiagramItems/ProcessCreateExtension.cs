/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 04.09.2006
 * Time: 07:27
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
	/// <summary>
	/// Description of Task.
	/// </summary>
	partial class ProcessCreate
	{
		static public void RepertoryImage(Graphics drawDestination)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 20, 60, 20);
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.LightGray,55,50,55,70);
			drawDestination.DrawLine(Pens.Black,10,45,40,45);
			if (mMscStyle==MscStyle.SDL){
				PointF[] messagePolygon = new PointF[3];
				messagePolygon[0] = new PointF(40, 45);
				messagePolygon[1] = new PointF(40-8, 45-4);
				messagePolygon[2] = new PointF(40-8, 45+4);
				drawDestination.FillPolygon(Brushes.Black,messagePolygon);				
			}
			else if (mMscStyle==MscStyle.UML2){
				drawDestination.DrawLine(Pens.Black,40, 45,40-8, 45-4);	
				drawDestination.DrawLine(Pens.Black,40, 45,40-8, 45+4);	
			}
			drawDestination.DrawRectangle(Pens.Black, 40,40,30,10);
			drawDestination.DrawString("Create",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			rPen.Dispose();
			itemStringFormat.Dispose();
		}
		static public void RepertoryImage(Graphics drawDestination, MscStyle style)
		{
			StringFormat itemStringFormat = new StringFormat();				
			RectangleF itemBox = new RectangleF(10, 20, 60, 20);
			float[] pattern = {4f,4f};
			Pen rPen = new Pen(Color.Black);
			rPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			rPen.DashPattern = pattern;
			itemStringFormat.Alignment = StringAlignment.Center;
			itemStringFormat.LineAlignment = StringAlignment.Center;
			drawDestination.DrawLine(Pens.LightGray,10,10,10,70);
			drawDestination.DrawLine(Pens.LightGray,55,50,55,70);
			drawDestination.DrawLine(Pens.Black,10,45,40,45);
			if (style==MscStyle.SDL){
				PointF[] messagePolygon = new PointF[3];
				messagePolygon[0] = new PointF(40, 45);
				messagePolygon[1] = new PointF(40-8, 45-4);
				messagePolygon[2] = new PointF(40-8, 45+4);
				drawDestination.FillPolygon(Brushes.Black,messagePolygon);				
			}
			else if (style==MscStyle.UML2){
				drawDestination.DrawLine(Pens.Black,40, 45,40-8, 45-4);	
				drawDestination.DrawLine(Pens.Black,40, 45,40-8, 45+4);	
			}
			drawDestination.DrawRectangle(Pens.Black, 40,40,30,10);
			drawDestination.DrawString("Create",new Font("Arial",8),Brushes.Black,itemBox,itemStringFormat);
			rPen.Dispose();
			itemStringFormat.Dispose();
		}
		static public void RepertoryText(NumberingEditor.NumberingRichTextBox ew)
		{
			int ss = ew.SelectionStart;
			int se = ew.SelectionStart + ew.SelectionLength;
			if (se>0) se--;
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
			insertString = "create: InstanceIdSource, InstanceIdDestination, MessageText, ProcessName, ProcessDescription;";
			ew.SelectedText = insertString;
			ew.SelectedText = "\n";
			ew.SelectionStart = i+insertString.Length+1;					
		}
		public override Property GetPropertyDialog(string text)
		{
			ProcessCreateProp property 	= new ProcessCreateProp();
			property.MessageText 		= this.mMessName.Replace("\n",@"\n");
			property.ProcessText 		= this.mName.Replace("\n",@"\n");
			property.DescriptionText 	= this.mDescription.Replace("\n",@"\n");
			property.ItemID 			= mID;
			property.EditorText 		= text;
			return property;
		}
	}
}
