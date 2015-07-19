/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 10:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeneratorGUI
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm
    {

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }
        //public MainForm()
        //{
        //    //
        //    // The InitializeComponent() call is required for Windows Forms designer support.
        //    //
        //    InitializeComponent();

        //    //
        //    // TODO: Add constructor code after the InitializeComponent() call.
        //    //

        //}
        public MainForm(string[] args)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

        }
        //protected override void DrawNew()
        //{	
        //}
        //protected override void RedrawImage()
        //{	
        //}
        //protected override void PrintDocumentPrintPage(object o, System.Drawing.Printing.PrintPageEventArgs ppea)
        //{	
        //}
        //protected override void InterpretFile(string s, bool b)
        //{	
        //}
    }
}
