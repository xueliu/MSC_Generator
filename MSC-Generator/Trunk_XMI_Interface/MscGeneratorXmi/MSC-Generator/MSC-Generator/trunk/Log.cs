/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 20.06.2005
 * Time: 14:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace nGenerator
{
	/// <summary>
	/// Description of Log.
	/// </summary>
	public class Log : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblHead;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.PictureBox pictureBox1;
		public Log()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			OwenInitialize();
		}
		public Log(InterpretException[] exceptionList)
		{
			InitializeComponent();
			OwenInitialize();
			this.outputExceptions(exceptionList);
			
		}		
		private void OwenInitialize(){
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Output));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("Output.Icon")));			
		}
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Log));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.lblHead = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(36, 32);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(4, 52);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(544, 264);
			this.txtLog.TabIndex = 1;
			this.txtLog.Text = "";
			// 
			// lblHead
			// 
			this.lblHead.Location = new System.Drawing.Point(48, 8);
			this.lblHead.Name = "lblHead";
			this.lblHead.Size = new System.Drawing.Size(444, 36);
			this.lblHead.TabIndex = 0;
			this.lblHead.Text = "Während der Generierung sind Fehler aufgetreten.";
			// 
			// Log
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(552, 333);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.lblHead);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Log";
			this.Text = "Generierungs - Log";
			this.ResumeLayout(false);
		}
		#endregion
		private void outputExceptions(InterpretException[] exceptions)
		{
			string exceptionText = "";
			for (int i=0;i<exceptions.Length;i++){
				exceptionText += "Zeile " + exceptions[i].exceptionLine + ": ";
				switch (exceptions[i].result){
					case InterpretResult.IdentifierNotFound:
						exceptionText += "Der verwendete Identifizierer konnte nich zugeordnet werden." + "\r\n";
						break;
					case InterpretResult.InstanceNotFound:
						exceptionText += "Der verwendete Instanzidentifizierer konnte nich zugeordnet werden." + "\r\n";
						break;
					case InterpretResult.LineAllreadyExists:
						exceptionText += "Es existiert bereits eine nicht abgeschlossene Linie für diese Instanz." + "\r\n";
						break;
					case InterpretResult.LineNotExists:
						exceptionText += "Es existiert keine offene Linie für diese Instanz." + "\r\n";
						break;
					case InterpretResult.ParameterOutOfRange:
						exceptionText += "Der Parameter " + exceptions[i].exceptionParameter + " ist außerhalb des gültigen Bereichs." + "\r\n";
						break;
					case InterpretResult.UnknownCommand:
						exceptionText += "Unbekannter Befehl " + exceptions[i].exceptionCommand + "\r\n";
						break;
					case InterpretResult.UnknownParameter:
						exceptionText += "Unbekannter Parameter " + exceptions[i].exceptionParameter + "\r\n";
						break;
					case InterpretResult.WrongParameterNumber:
						exceptionText += "Falsche Parameteranzahl. Der Befehl  " + exceptions[i].exceptionCommand + " benötigt mindestens " + exceptions[i].exceptionParameter + " Parameter." + "\r\n";
						break;
				}
			}
			this.txtLog.Text = exceptionText;
		}
	}
}
