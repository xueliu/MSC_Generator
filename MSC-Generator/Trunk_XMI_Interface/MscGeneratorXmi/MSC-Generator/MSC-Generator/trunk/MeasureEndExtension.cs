/*
 * Created by SharpDevelop.
 * User: koto
 * Date: 01.09.2006
 * Time: 11:50
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
	/// Description of Timeout.
	/// </summary>
	partial class MeasureEnd
	{
		public override Property GetPropertyDialog(string text)
		{
			MeasureEndProp property = new MeasureEndProp();
			property.MeasureText = this.mName.Replace("\n",@"\n");
			property.ItemID = mID;
			property.EditorText = text;
			return property;
		}
	}
}
