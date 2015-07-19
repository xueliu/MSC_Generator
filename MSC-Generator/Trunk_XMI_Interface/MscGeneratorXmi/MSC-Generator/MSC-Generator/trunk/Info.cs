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
		public Info(LicenseKey.License license)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ResourceManager strings = new ResourceManager ("nGenerator.strings", Assembly.GetAssembly(typeof(Info)));
			this.lblVersion.Text = string.Format(this.lblVersion.Text, Application.ProductVersion);
			this.lblLizenztyp.Text = "";
			this.lblLizenzNr.Text = "";
			this.lblFirma1.Text = "";
			this.lblFirma2.Text = "";
			
			if ((license.licenseType == LicenseKey.LicenseType.Demo)||(license.valid == LicenseKey.ValidResult.NoLicensed)){
				this.lblLizenzNr.Text = "";
				this.lblFirma1.Text = strings.GetString ("Demoversion");
			}
			else{
				if (license.licenseDate.Year != 2255){
					this.lblLizenztyp.Text = string.Format (strings.GetString ("UnlimitedUseUntil"), license.licenseDate);
				}
				else if(license.licenseType == LicenseKey.LicenseType.NonCommercial){
					this.lblLizenztyp.Text = strings.GetString("NotCommercialUse");
				}
				this.lblLizenzNr.Text = strings.GetString("LicenseNr") + license.licenseNumber.ToString().Substring(0,4) + "-" + license.licenseNumber.ToString().Substring(4,4) + "-" + license.licenseNumber.ToString().Substring(8,4);;
				this.lblFirma1.Text = strings.GetString("LicensedTo") + license.company1;
				this.lblFirma2.Text = license.company2;
			}
		}
	}
}
