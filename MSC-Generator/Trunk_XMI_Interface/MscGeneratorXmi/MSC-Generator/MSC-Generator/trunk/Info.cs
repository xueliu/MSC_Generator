/*
 * Created by SharpDevelop.
 * User: Peter Dimov
 * Date: 14.12.2006
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Resources;

namespace nGenerator
{
	/// <summary>
	/// Description of Info.
	/// </summary>
	public partial class Info : System.Windows.Forms.Form
	{
		public Info()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ResourceManager strings = new ResourceManager ("nGenerator.strings", Assembly.GetAssembly(typeof(Info)));
			this.lblVersion.Text = string.Format(this.lblVersion.Text, Application.ProductVersion);
			this.lblLizenztyp.Text = "";
		}
	}
}
