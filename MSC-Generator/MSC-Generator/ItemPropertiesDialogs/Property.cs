/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 06.04.2006
 * Time: 13:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GeneratorGUI;
using nGenerator;

namespace MscItemProp
{
	/// <summary>
	/// Description of Property.
	/// </summary>
	public class Property : OptionsDialog
	{

		private System.Windows.Forms.TabPage tabPageTest;
		
		public override event EventHandler OnAcceptClick;
		private static Point sPosition = new Point(0,0);
		protected int mID = -1;
		protected string mEditorText = "";
		protected Image propertyImage = new Bitmap(100,80);
		
		protected static Color previewBackColor = System.Drawing.Color.Transparent;
		
		public Property()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			SetSize();
			this.DiagramStyle = MSC.Style;
			this.DiagramName = MSC.DiagramName;
			this.AutosizeExport = Output.AutosizeExport;
			this.AutoHeight = Output.AutosizeOutputHeight;
			this.AutoWidth = Output.AutosizeOutputWidth;
			this.tabPageWorksheet.Controls.Add(this.chkAutoWidth);
			this.tabPageWorksheet.Controls.Add(this.chkAutoHeight);
			
		}
		public static Point Position{
			get{
				return sPosition;
			}
			set{
				sPosition = value;
			}
		}
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Property));
			this.tabPageTest = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDiagramName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.optStyleUML = new System.Windows.Forms.RadioButton();
			this.optStyleSDL = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkAutosizeExport = new System.Windows.Forms.CheckBox();
			this.chkAutoWidth = new System.Windows.Forms.CheckBox();
			this.chkAutoHeight = new System.Windows.Forms.CheckBox();
			this.tabProperties.SuspendLayout();
			this.tabPageWorksheet.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// hlpProvider
			// 
			this.hlpProvider.HelpNamespace = null;
			// 
			// tabProperties
			// 
			this.tabProperties.AccessibleDescription = null;
			this.tabProperties.AccessibleName = null;
			this.tabProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabProperties.Anchor")));
			this.tabProperties.AutoScroll = ((bool)(resources.GetObject("tabProperties.AutoScroll")));
			this.tabProperties.BackgroundImage = null;
			this.tabProperties.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabProperties.BackgroundImageLayout")));
			this.tabProperties.Controls.Add(this.groupBox3);
			this.tabProperties.Controls.Add(this.groupBox1);
			this.tabProperties.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabProperties.Dock")));
			this.tabProperties.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabProperties, null);
			this.hlpProvider.SetHelpNavigator(this.tabProperties, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabProperties.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabProperties, null);
			this.tabProperties.ImageIndex = ((int)(resources.GetObject("tabProperties.ImageIndex")));
			this.tabProperties.ImageKey = resources.GetString("tabProperties.ImageKey");
			this.tabProperties.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabProperties.ImeMode")));
			this.tabProperties.Location = ((System.Drawing.Point)(resources.GetObject("tabProperties.Location")));
			this.tabProperties.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabProperties.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.tabProperties, ((bool)(resources.GetObject("tabProperties.ShowHelp"))));
			this.tabProperties.Size = ((System.Drawing.Size)(resources.GetObject("tabProperties.Size")));
			this.tabProperties.TabIndex = ((int)(resources.GetObject("tabProperties.TabIndex")));
			this.tabProperties.Text = resources.GetString("tabProperties.Text");
			this.propToolTip.SetToolTip(this.tabProperties, resources.GetString("tabProperties.ToolTip"));
			this.tabProperties.ToolTipText = resources.GetString("tabProperties.ToolTipText");
			this.tabProperties.Visible = ((bool)(resources.GetObject("tabProperties.Visible")));
			this.tabProperties.Controls.SetChildIndex(this.groupBox1, 0);
			this.tabProperties.Controls.SetChildIndex(this.groupBox3, 0);
			// 
			// cboPictureSize
			// 
			this.cboPictureSize.AccessibleDescription = null;
			this.cboPictureSize.AccessibleName = null;
			this.cboPictureSize.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboPictureSize.Anchor")));
			this.cboPictureSize.BackgroundImage = null;
			this.cboPictureSize.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cboPictureSize.BackgroundImageLayout")));
			this.cboPictureSize.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboPictureSize.Dock")));
			this.cboPictureSize.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cboPictureSize.FlatStyle")));
			this.cboPictureSize.Font = null;
			this.hlpProvider.SetHelpKeyword(this.cboPictureSize, resources.GetString("cboPictureSize.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.cboPictureSize, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cboPictureSize.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.cboPictureSize, null);
			this.cboPictureSize.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboPictureSize.ImeMode")));
			this.cboPictureSize.IntegralHeight = ((bool)(resources.GetObject("cboPictureSize.IntegralHeight")));
			this.cboPictureSize.Location = ((System.Drawing.Point)(resources.GetObject("cboPictureSize.Location")));
			this.cboPictureSize.MaxDropDownItems = ((int)(resources.GetObject("cboPictureSize.MaxDropDownItems")));
			this.cboPictureSize.MaxLength = ((int)(resources.GetObject("cboPictureSize.MaxLength")));
			this.cboPictureSize.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboPictureSize.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cboPictureSize, ((bool)(resources.GetObject("cboPictureSize.ShowHelp"))));
			this.cboPictureSize.Size = ((System.Drawing.Size)(resources.GetObject("cboPictureSize.Size")));
			this.cboPictureSize.TabIndex = ((int)(resources.GetObject("cboPictureSize.TabIndex")));
			this.propToolTip.SetToolTip(this.cboPictureSize, resources.GetString("cboPictureSize.ToolTip"));
			// 
			// cboUnits
			// 
			this.cboUnits.AccessibleDescription = null;
			this.cboUnits.AccessibleName = null;
			this.cboUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboUnits.Anchor")));
			this.cboUnits.BackgroundImage = null;
			this.cboUnits.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cboUnits.BackgroundImageLayout")));
			this.cboUnits.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboUnits.Dock")));
			this.cboUnits.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cboUnits.FlatStyle")));
			this.cboUnits.Font = null;
			this.hlpProvider.SetHelpKeyword(this.cboUnits, resources.GetString("cboUnits.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.cboUnits, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cboUnits.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.cboUnits, null);
			this.cboUnits.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboUnits.ImeMode")));
			this.cboUnits.IntegralHeight = ((bool)(resources.GetObject("cboUnits.IntegralHeight")));
			this.cboUnits.Location = ((System.Drawing.Point)(resources.GetObject("cboUnits.Location")));
			this.cboUnits.MaxDropDownItems = ((int)(resources.GetObject("cboUnits.MaxDropDownItems")));
			this.cboUnits.MaxLength = ((int)(resources.GetObject("cboUnits.MaxLength")));
			this.cboUnits.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboUnits.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cboUnits, ((bool)(resources.GetObject("cboUnits.ShowHelp"))));
			this.cboUnits.Size = ((System.Drawing.Size)(resources.GetObject("cboUnits.Size")));
			this.cboUnits.TabIndex = ((int)(resources.GetObject("cboUnits.TabIndex")));
			this.propToolTip.SetToolTip(this.cboUnits, resources.GetString("cboUnits.ToolTip"));
			// 
			// txtWidth
			// 
			this.txtWidth.AccessibleDescription = null;
			this.txtWidth.AccessibleName = null;
			this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtWidth.Anchor")));
			this.txtWidth.BackgroundImage = null;
			this.txtWidth.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtWidth.BackgroundImageLayout")));
			this.txtWidth.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtWidth.Dock")));
			this.txtWidth.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtWidth, resources.GetString("txtWidth.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtWidth, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtWidth.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtWidth, null);
			this.txtWidth.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtWidth.ImeMode")));
			this.txtWidth.Location = ((System.Drawing.Point)(resources.GetObject("txtWidth.Location")));
			this.txtWidth.MaxLength = ((int)(resources.GetObject("txtWidth.MaxLength")));
			this.txtWidth.Multiline = ((bool)(resources.GetObject("txtWidth.Multiline")));
			this.txtWidth.PasswordChar = ((char)(resources.GetObject("txtWidth.PasswordChar")));
			this.txtWidth.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtWidth.RightToLeft")));
			this.txtWidth.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtWidth.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtWidth, ((bool)(resources.GetObject("txtWidth.ShowHelp"))));
			this.txtWidth.Size = ((System.Drawing.Size)(resources.GetObject("txtWidth.Size")));
			this.txtWidth.TabIndex = ((int)(resources.GetObject("txtWidth.TabIndex")));
			this.txtWidth.Text = resources.GetString("txtWidth.Text");
			this.txtWidth.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtWidth.TextAlign")));
			this.propToolTip.SetToolTip(this.txtWidth, resources.GetString("txtWidth.ToolTip"));
			this.txtWidth.WordWrap = ((bool)(resources.GetObject("txtWidth.WordWrap")));
			// 
			// txtHeight
			// 
			this.txtHeight.AccessibleDescription = null;
			this.txtHeight.AccessibleName = null;
			this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtHeight.Anchor")));
			this.txtHeight.BackgroundImage = null;
			this.txtHeight.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtHeight.BackgroundImageLayout")));
			this.txtHeight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtHeight.Dock")));
			this.txtHeight.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtHeight, resources.GetString("txtHeight.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtHeight, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtHeight.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtHeight, null);
			this.txtHeight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtHeight.ImeMode")));
			this.txtHeight.Location = ((System.Drawing.Point)(resources.GetObject("txtHeight.Location")));
			this.txtHeight.MaxLength = ((int)(resources.GetObject("txtHeight.MaxLength")));
			this.txtHeight.Multiline = ((bool)(resources.GetObject("txtHeight.Multiline")));
			this.txtHeight.PasswordChar = ((char)(resources.GetObject("txtHeight.PasswordChar")));
			this.txtHeight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtHeight.RightToLeft")));
			this.txtHeight.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtHeight.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtHeight, ((bool)(resources.GetObject("txtHeight.ShowHelp"))));
			this.txtHeight.Size = ((System.Drawing.Size)(resources.GetObject("txtHeight.Size")));
			this.txtHeight.TabIndex = ((int)(resources.GetObject("txtHeight.TabIndex")));
			this.txtHeight.Text = resources.GetString("txtHeight.Text");
			this.txtHeight.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtHeight.TextAlign")));
			this.propToolTip.SetToolTip(this.txtHeight, resources.GetString("txtHeight.ToolTip"));
			this.txtHeight.WordWrap = ((bool)(resources.GetObject("txtHeight.WordWrap")));
			// 
			// tabPageWorksheet
			// 
			this.tabPageWorksheet.AccessibleDescription = null;
			this.tabPageWorksheet.AccessibleName = null;
			this.tabPageWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPageWorksheet.Anchor")));
			this.tabPageWorksheet.AutoScroll = ((bool)(resources.GetObject("tabPageWorksheet.AutoScroll")));
			this.tabPageWorksheet.BackgroundImage = null;
			this.tabPageWorksheet.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabPageWorksheet.BackgroundImageLayout")));
			this.tabPageWorksheet.Controls.Add(this.chkAutoWidth);
			this.tabPageWorksheet.Controls.Add(this.chkAutoHeight);
			this.tabPageWorksheet.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPageWorksheet.Dock")));
			this.tabPageWorksheet.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabPageWorksheet, null);
			this.hlpProvider.SetHelpNavigator(this.tabPageWorksheet, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPageWorksheet.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabPageWorksheet, null);
			this.tabPageWorksheet.ImageIndex = ((int)(resources.GetObject("tabPageWorksheet.ImageIndex")));
			this.tabPageWorksheet.ImageKey = resources.GetString("tabPageWorksheet.ImageKey");
			this.tabPageWorksheet.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPageWorksheet.ImeMode")));
			this.tabPageWorksheet.Location = ((System.Drawing.Point)(resources.GetObject("tabPageWorksheet.Location")));
			this.tabPageWorksheet.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPageWorksheet.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.tabPageWorksheet, ((bool)(resources.GetObject("tabPageWorksheet.ShowHelp"))));
			this.tabPageWorksheet.Size = ((System.Drawing.Size)(resources.GetObject("tabPageWorksheet.Size")));
			this.tabPageWorksheet.TabIndex = ((int)(resources.GetObject("tabPageWorksheet.TabIndex")));
			this.tabPageWorksheet.Text = resources.GetString("tabPageWorksheet.Text");
			this.propToolTip.SetToolTip(this.tabPageWorksheet, resources.GetString("tabPageWorksheet.ToolTip"));
			this.tabPageWorksheet.ToolTipText = resources.GetString("tabPageWorksheet.ToolTipText");
			this.tabPageWorksheet.Visible = ((bool)(resources.GetObject("tabPageWorksheet.Visible")));
			this.tabPageWorksheet.Controls.SetChildIndex(this.chkAutoHeight, 0);
			this.tabPageWorksheet.Controls.SetChildIndex(this.chkAutoWidth, 0);
			this.tabPageWorksheet.Controls.SetChildIndex(this.cboPictureSize, 0);
			this.tabPageWorksheet.Controls.SetChildIndex(this.cboUnits, 0);
			this.tabPageWorksheet.Controls.SetChildIndex(this.txtWidth, 0);
			this.tabPageWorksheet.Controls.SetChildIndex(this.txtHeight, 0);
			// 
			// tabOptions
			// 
			this.tabOptions.AccessibleDescription = null;
			this.tabOptions.AccessibleName = null;
			this.tabOptions.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("tabOptions.Alignment")));
			this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabOptions.Anchor")));
			this.tabOptions.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("tabOptions.Appearance")));
			this.tabOptions.BackgroundImage = null;
			this.tabOptions.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabOptions.BackgroundImageLayout")));
			this.tabOptions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabOptions.Dock")));
			this.tabOptions.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabOptions, resources.GetString("tabOptions.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.tabOptions, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabOptions.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabOptions, null);
			this.tabOptions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabOptions.ImeMode")));
			this.tabOptions.Location = ((System.Drawing.Point)(resources.GetObject("tabOptions.Location")));
			this.tabOptions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabOptions.RightToLeft")));
			this.tabOptions.RightToLeftLayout = ((bool)(resources.GetObject("tabOptions.RightToLeftLayout")));
			this.hlpProvider.SetShowHelp(this.tabOptions, ((bool)(resources.GetObject("tabOptions.ShowHelp"))));
			this.tabOptions.ShowToolTips = ((bool)(resources.GetObject("tabOptions.ShowToolTips")));
			this.tabOptions.Size = ((System.Drawing.Size)(resources.GetObject("tabOptions.Size")));
			this.tabOptions.TabIndex = ((int)(resources.GetObject("tabOptions.TabIndex")));
			this.propToolTip.SetToolTip(this.tabOptions, resources.GetString("tabOptions.ToolTip"));
			this.tabOptions.TabIndexChanged += new System.EventHandler(this.TabOptionsSelectedIndexChanged);
			// 
			// chkAuthor
			// 
			this.chkAuthor.AccessibleDescription = null;
			this.chkAuthor.AccessibleName = null;
			this.chkAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkAuthor.Anchor")));
			this.chkAuthor.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkAuthor.Appearance")));
			this.chkAuthor.AutoSize = ((bool)(resources.GetObject("chkAuthor.AutoSize")));
			this.chkAuthor.BackgroundImage = null;
			this.chkAuthor.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkAuthor.BackgroundImageLayout")));
			this.chkAuthor.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAuthor.CheckAlign")));
			this.chkAuthor.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkAuthor.Dock")));
			this.chkAuthor.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkAuthor.FlatStyle")));
			this.chkAuthor.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkAuthor, resources.GetString("chkAuthor.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkAuthor, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkAuthor.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkAuthor, null);
			this.chkAuthor.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAuthor.ImageAlign")));
			this.chkAuthor.ImageIndex = ((int)(resources.GetObject("chkAuthor.ImageIndex")));
			this.chkAuthor.ImageKey = resources.GetString("chkAuthor.ImageKey");
			this.chkAuthor.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAuthor.ImeMode")));
			this.chkAuthor.Location = ((System.Drawing.Point)(resources.GetObject("chkAuthor.Location")));
			this.chkAuthor.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAuthor.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkAuthor, ((bool)(resources.GetObject("chkAuthor.ShowHelp"))));
			this.chkAuthor.Size = ((System.Drawing.Size)(resources.GetObject("chkAuthor.Size")));
			this.chkAuthor.TabIndex = ((int)(resources.GetObject("chkAuthor.TabIndex")));
			this.chkAuthor.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAuthor.TextAlign")));
			this.chkAuthor.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkAuthor.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkAuthor, resources.GetString("chkAuthor.ToolTip"));
			// 
			// chkCompany
			// 
			this.chkCompany.AccessibleDescription = null;
			this.chkCompany.AccessibleName = null;
			this.chkCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkCompany.Anchor")));
			this.chkCompany.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkCompany.Appearance")));
			this.chkCompany.AutoSize = ((bool)(resources.GetObject("chkCompany.AutoSize")));
			this.chkCompany.BackgroundImage = null;
			this.chkCompany.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkCompany.BackgroundImageLayout")));
			this.chkCompany.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCompany.CheckAlign")));
			this.chkCompany.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkCompany.Dock")));
			this.chkCompany.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkCompany.FlatStyle")));
			this.chkCompany.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkCompany, resources.GetString("chkCompany.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkCompany, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkCompany.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkCompany, null);
			this.chkCompany.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCompany.ImageAlign")));
			this.chkCompany.ImageIndex = ((int)(resources.GetObject("chkCompany.ImageIndex")));
			this.chkCompany.ImageKey = resources.GetString("chkCompany.ImageKey");
			this.chkCompany.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkCompany.ImeMode")));
			this.chkCompany.Location = ((System.Drawing.Point)(resources.GetObject("chkCompany.Location")));
			this.chkCompany.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkCompany.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkCompany, ((bool)(resources.GetObject("chkCompany.ShowHelp"))));
			this.chkCompany.Size = ((System.Drawing.Size)(resources.GetObject("chkCompany.Size")));
			this.chkCompany.TabIndex = ((int)(resources.GetObject("chkCompany.TabIndex")));
			this.chkCompany.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCompany.TextAlign")));
			this.chkCompany.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkCompany.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkCompany, resources.GetString("chkCompany.ToolTip"));
			// 
			// chkVersion
			// 
			this.chkVersion.AccessibleDescription = null;
			this.chkVersion.AccessibleName = null;
			this.chkVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkVersion.Anchor")));
			this.chkVersion.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkVersion.Appearance")));
			this.chkVersion.AutoSize = ((bool)(resources.GetObject("chkVersion.AutoSize")));
			this.chkVersion.BackgroundImage = null;
			this.chkVersion.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkVersion.BackgroundImageLayout")));
			this.chkVersion.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkVersion.CheckAlign")));
			this.chkVersion.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkVersion.Dock")));
			this.chkVersion.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkVersion.FlatStyle")));
			this.chkVersion.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkVersion, resources.GetString("chkVersion.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkVersion, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkVersion.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkVersion, null);
			this.chkVersion.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkVersion.ImageAlign")));
			this.chkVersion.ImageIndex = ((int)(resources.GetObject("chkVersion.ImageIndex")));
			this.chkVersion.ImageKey = resources.GetString("chkVersion.ImageKey");
			this.chkVersion.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkVersion.ImeMode")));
			this.chkVersion.Location = ((System.Drawing.Point)(resources.GetObject("chkVersion.Location")));
			this.chkVersion.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkVersion.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkVersion, ((bool)(resources.GetObject("chkVersion.ShowHelp"))));
			this.chkVersion.Size = ((System.Drawing.Size)(resources.GetObject("chkVersion.Size")));
			this.chkVersion.TabIndex = ((int)(resources.GetObject("chkVersion.TabIndex")));
			this.chkVersion.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkVersion.TextAlign")));
			this.chkVersion.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkVersion.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkVersion, resources.GetString("chkVersion.ToolTip"));
			// 
			// chkDate
			// 
			this.chkDate.AccessibleDescription = null;
			this.chkDate.AccessibleName = null;
			this.chkDate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkDate.Anchor")));
			this.chkDate.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkDate.Appearance")));
			this.chkDate.AutoSize = ((bool)(resources.GetObject("chkDate.AutoSize")));
			this.chkDate.BackgroundImage = null;
			this.chkDate.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkDate.BackgroundImageLayout")));
			this.chkDate.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkDate.CheckAlign")));
			this.chkDate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkDate.Dock")));
			this.chkDate.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkDate.FlatStyle")));
			this.chkDate.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkDate, resources.GetString("chkDate.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkDate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkDate.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkDate, null);
			this.chkDate.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkDate.ImageAlign")));
			this.chkDate.ImageIndex = ((int)(resources.GetObject("chkDate.ImageIndex")));
			this.chkDate.ImageKey = resources.GetString("chkDate.ImageKey");
			this.chkDate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkDate.ImeMode")));
			this.chkDate.Location = ((System.Drawing.Point)(resources.GetObject("chkDate.Location")));
			this.chkDate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkDate.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkDate, ((bool)(resources.GetObject("chkDate.ShowHelp"))));
			this.chkDate.Size = ((System.Drawing.Size)(resources.GetObject("chkDate.Size")));
			this.chkDate.TabIndex = ((int)(resources.GetObject("chkDate.TabIndex")));
			this.chkDate.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkDate.TextAlign")));
			this.chkDate.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkDate.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkDate, resources.GetString("chkDate.ToolTip"));
			// 
			// chkToday
			// 
			this.chkToday.AccessibleDescription = null;
			this.chkToday.AccessibleName = null;
			this.chkToday.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkToday.Anchor")));
			this.chkToday.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkToday.Appearance")));
			this.chkToday.AutoSize = ((bool)(resources.GetObject("chkToday.AutoSize")));
			this.chkToday.BackgroundImage = null;
			this.chkToday.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkToday.BackgroundImageLayout")));
			this.chkToday.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToday.CheckAlign")));
			this.chkToday.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkToday.Dock")));
			this.chkToday.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkToday.FlatStyle")));
			this.chkToday.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkToday, resources.GetString("chkToday.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkToday, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkToday.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkToday, null);
			this.chkToday.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToday.ImageAlign")));
			this.chkToday.ImageIndex = ((int)(resources.GetObject("chkToday.ImageIndex")));
			this.chkToday.ImageKey = resources.GetString("chkToday.ImageKey");
			this.chkToday.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkToday.ImeMode")));
			this.chkToday.Location = ((System.Drawing.Point)(resources.GetObject("chkToday.Location")));
			this.chkToday.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkToday.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkToday, ((bool)(resources.GetObject("chkToday.ShowHelp"))));
			this.chkToday.Size = ((System.Drawing.Size)(resources.GetObject("chkToday.Size")));
			this.chkToday.TabIndex = ((int)(resources.GetObject("chkToday.TabIndex")));
			this.chkToday.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToday.TextAlign")));
			this.chkToday.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkToday.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkToday, resources.GetString("chkToday.ToolTip"));
			// 
			// chkFile
			// 
			this.chkFile.AccessibleDescription = null;
			this.chkFile.AccessibleName = null;
			this.chkFile.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkFile.Anchor")));
			this.chkFile.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkFile.Appearance")));
			this.chkFile.AutoSize = ((bool)(resources.GetObject("chkFile.AutoSize")));
			this.chkFile.BackgroundImage = null;
			this.chkFile.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkFile.BackgroundImageLayout")));
			this.chkFile.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFile.CheckAlign")));
			this.chkFile.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkFile.Dock")));
			this.chkFile.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkFile.FlatStyle")));
			this.chkFile.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkFile, resources.GetString("chkFile.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkFile, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkFile.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkFile, null);
			this.chkFile.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFile.ImageAlign")));
			this.chkFile.ImageIndex = ((int)(resources.GetObject("chkFile.ImageIndex")));
			this.chkFile.ImageKey = resources.GetString("chkFile.ImageKey");
			this.chkFile.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkFile.ImeMode")));
			this.chkFile.Location = ((System.Drawing.Point)(resources.GetObject("chkFile.Location")));
			this.chkFile.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkFile.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkFile, ((bool)(resources.GetObject("chkFile.ShowHelp"))));
			this.chkFile.Size = ((System.Drawing.Size)(resources.GetObject("chkFile.Size")));
			this.chkFile.TabIndex = ((int)(resources.GetObject("chkFile.TabIndex")));
			this.chkFile.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFile.TextAlign")));
			this.chkFile.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkFile.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkFile, resources.GetString("chkFile.ToolTip"));
			// 
			// txtAuthor
			// 
			this.txtAuthor.AccessibleDescription = null;
			this.txtAuthor.AccessibleName = null;
			this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtAuthor.Anchor")));
			this.txtAuthor.BackgroundImage = null;
			this.txtAuthor.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtAuthor.BackgroundImageLayout")));
			this.txtAuthor.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtAuthor.Dock")));
			this.txtAuthor.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtAuthor, resources.GetString("txtAuthor.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtAuthor, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtAuthor.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtAuthor, null);
			this.txtAuthor.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtAuthor.ImeMode")));
			this.txtAuthor.Location = ((System.Drawing.Point)(resources.GetObject("txtAuthor.Location")));
			this.txtAuthor.MaxLength = ((int)(resources.GetObject("txtAuthor.MaxLength")));
			this.txtAuthor.Multiline = ((bool)(resources.GetObject("txtAuthor.Multiline")));
			this.txtAuthor.PasswordChar = ((char)(resources.GetObject("txtAuthor.PasswordChar")));
			this.txtAuthor.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtAuthor.RightToLeft")));
			this.txtAuthor.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtAuthor.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtAuthor, ((bool)(resources.GetObject("txtAuthor.ShowHelp"))));
			this.txtAuthor.Size = ((System.Drawing.Size)(resources.GetObject("txtAuthor.Size")));
			this.txtAuthor.TabIndex = ((int)(resources.GetObject("txtAuthor.TabIndex")));
			this.txtAuthor.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtAuthor.TextAlign")));
			this.propToolTip.SetToolTip(this.txtAuthor, resources.GetString("txtAuthor.ToolTip"));
			this.txtAuthor.WordWrap = ((bool)(resources.GetObject("txtAuthor.WordWrap")));
			// 
			// txtCompany
			// 
			this.txtCompany.AccessibleDescription = null;
			this.txtCompany.AccessibleName = null;
			this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtCompany.Anchor")));
			this.txtCompany.BackgroundImage = null;
			this.txtCompany.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtCompany.BackgroundImageLayout")));
			this.txtCompany.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtCompany.Dock")));
			this.txtCompany.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtCompany, resources.GetString("txtCompany.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtCompany, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtCompany.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtCompany, null);
			this.txtCompany.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtCompany.ImeMode")));
			this.txtCompany.Location = ((System.Drawing.Point)(resources.GetObject("txtCompany.Location")));
			this.txtCompany.MaxLength = ((int)(resources.GetObject("txtCompany.MaxLength")));
			this.txtCompany.Multiline = ((bool)(resources.GetObject("txtCompany.Multiline")));
			this.txtCompany.PasswordChar = ((char)(resources.GetObject("txtCompany.PasswordChar")));
			this.txtCompany.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtCompany.RightToLeft")));
			this.txtCompany.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtCompany.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtCompany, ((bool)(resources.GetObject("txtCompany.ShowHelp"))));
			this.txtCompany.Size = ((System.Drawing.Size)(resources.GetObject("txtCompany.Size")));
			this.txtCompany.TabIndex = ((int)(resources.GetObject("txtCompany.TabIndex")));
			this.txtCompany.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtCompany.TextAlign")));
			this.propToolTip.SetToolTip(this.txtCompany, resources.GetString("txtCompany.ToolTip"));
			this.txtCompany.WordWrap = ((bool)(resources.GetObject("txtCompany.WordWrap")));
			// 
			// txtVersion
			// 
			this.txtVersion.AccessibleDescription = null;
			this.txtVersion.AccessibleName = null;
			this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtVersion.Anchor")));
			this.txtVersion.BackgroundImage = null;
			this.txtVersion.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtVersion.BackgroundImageLayout")));
			this.txtVersion.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtVersion.Dock")));
			this.txtVersion.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtVersion, resources.GetString("txtVersion.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtVersion, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtVersion.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtVersion, null);
			this.txtVersion.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtVersion.ImeMode")));
			this.txtVersion.Location = ((System.Drawing.Point)(resources.GetObject("txtVersion.Location")));
			this.txtVersion.MaxLength = ((int)(resources.GetObject("txtVersion.MaxLength")));
			this.txtVersion.Multiline = ((bool)(resources.GetObject("txtVersion.Multiline")));
			this.txtVersion.PasswordChar = ((char)(resources.GetObject("txtVersion.PasswordChar")));
			this.txtVersion.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtVersion.RightToLeft")));
			this.txtVersion.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtVersion.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtVersion, ((bool)(resources.GetObject("txtVersion.ShowHelp"))));
			this.txtVersion.Size = ((System.Drawing.Size)(resources.GetObject("txtVersion.Size")));
			this.txtVersion.TabIndex = ((int)(resources.GetObject("txtVersion.TabIndex")));
			this.txtVersion.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtVersion.TextAlign")));
			this.propToolTip.SetToolTip(this.txtVersion, resources.GetString("txtVersion.ToolTip"));
			this.txtVersion.WordWrap = ((bool)(resources.GetObject("txtVersion.WordWrap")));
			// 
			// txtDate
			// 
			this.txtDate.AccessibleDescription = null;
			this.txtDate.AccessibleName = null;
			this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtDate.Anchor")));
			this.txtDate.BackgroundImage = null;
			this.txtDate.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtDate.BackgroundImageLayout")));
			this.txtDate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtDate.Dock")));
			this.txtDate.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtDate, resources.GetString("txtDate.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtDate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtDate.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtDate, null);
			this.txtDate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtDate.ImeMode")));
			this.txtDate.Location = ((System.Drawing.Point)(resources.GetObject("txtDate.Location")));
			this.txtDate.MaxLength = ((int)(resources.GetObject("txtDate.MaxLength")));
			this.txtDate.Multiline = ((bool)(resources.GetObject("txtDate.Multiline")));
			this.txtDate.PasswordChar = ((char)(resources.GetObject("txtDate.PasswordChar")));
			this.txtDate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtDate.RightToLeft")));
			this.txtDate.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtDate.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtDate, ((bool)(resources.GetObject("txtDate.ShowHelp"))));
			this.txtDate.Size = ((System.Drawing.Size)(resources.GetObject("txtDate.Size")));
			this.txtDate.TabIndex = ((int)(resources.GetObject("txtDate.TabIndex")));
			this.txtDate.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtDate.TextAlign")));
			this.propToolTip.SetToolTip(this.txtDate, resources.GetString("txtDate.ToolTip"));
			this.txtDate.WordWrap = ((bool)(resources.GetObject("txtDate.WordWrap")));
			// 
			// txtLeftMargin
			// 
			this.txtLeftMargin.AccessibleDescription = null;
			this.txtLeftMargin.AccessibleName = null;
			this.txtLeftMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtLeftMargin.Anchor")));
			this.txtLeftMargin.BackgroundImage = null;
			this.txtLeftMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtLeftMargin.BackgroundImageLayout")));
			this.txtLeftMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtLeftMargin.Dock")));
			this.txtLeftMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtLeftMargin, resources.GetString("txtLeftMargin.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtLeftMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtLeftMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtLeftMargin, null);
			this.txtLeftMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtLeftMargin.ImeMode")));
			this.txtLeftMargin.Location = ((System.Drawing.Point)(resources.GetObject("txtLeftMargin.Location")));
			this.txtLeftMargin.MaxLength = ((int)(resources.GetObject("txtLeftMargin.MaxLength")));
			this.txtLeftMargin.Multiline = ((bool)(resources.GetObject("txtLeftMargin.Multiline")));
			this.txtLeftMargin.PasswordChar = ((char)(resources.GetObject("txtLeftMargin.PasswordChar")));
			this.txtLeftMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtLeftMargin.RightToLeft")));
			this.txtLeftMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtLeftMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtLeftMargin, ((bool)(resources.GetObject("txtLeftMargin.ShowHelp"))));
			this.txtLeftMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtLeftMargin.Size")));
			this.txtLeftMargin.TabIndex = ((int)(resources.GetObject("txtLeftMargin.TabIndex")));
			this.txtLeftMargin.Text = resources.GetString("txtLeftMargin.Text");
			this.txtLeftMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtLeftMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtLeftMargin, resources.GetString("txtLeftMargin.ToolTip"));
			this.txtLeftMargin.WordWrap = ((bool)(resources.GetObject("txtLeftMargin.WordWrap")));
			// 
			// txtTopMargin
			// 
			this.txtTopMargin.AccessibleDescription = null;
			this.txtTopMargin.AccessibleName = null;
			this.txtTopMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtTopMargin.Anchor")));
			this.txtTopMargin.BackgroundImage = null;
			this.txtTopMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtTopMargin.BackgroundImageLayout")));
			this.txtTopMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtTopMargin.Dock")));
			this.txtTopMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtTopMargin, resources.GetString("txtTopMargin.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtTopMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtTopMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtTopMargin, null);
			this.txtTopMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtTopMargin.ImeMode")));
			this.txtTopMargin.Location = ((System.Drawing.Point)(resources.GetObject("txtTopMargin.Location")));
			this.txtTopMargin.MaxLength = ((int)(resources.GetObject("txtTopMargin.MaxLength")));
			this.txtTopMargin.Multiline = ((bool)(resources.GetObject("txtTopMargin.Multiline")));
			this.txtTopMargin.PasswordChar = ((char)(resources.GetObject("txtTopMargin.PasswordChar")));
			this.txtTopMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtTopMargin.RightToLeft")));
			this.txtTopMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtTopMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtTopMargin, ((bool)(resources.GetObject("txtTopMargin.ShowHelp"))));
			this.txtTopMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtTopMargin.Size")));
			this.txtTopMargin.TabIndex = ((int)(resources.GetObject("txtTopMargin.TabIndex")));
			this.txtTopMargin.Text = resources.GetString("txtTopMargin.Text");
			this.txtTopMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtTopMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtTopMargin, resources.GetString("txtTopMargin.ToolTip"));
			this.txtTopMargin.WordWrap = ((bool)(resources.GetObject("txtTopMargin.WordWrap")));
			// 
			// txtRightMargin
			// 
			this.txtRightMargin.AccessibleDescription = null;
			this.txtRightMargin.AccessibleName = null;
			this.txtRightMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtRightMargin.Anchor")));
			this.txtRightMargin.BackgroundImage = null;
			this.txtRightMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtRightMargin.BackgroundImageLayout")));
			this.txtRightMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtRightMargin.Dock")));
			this.txtRightMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtRightMargin, resources.GetString("txtRightMargin.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtRightMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtRightMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtRightMargin, null);
			this.txtRightMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtRightMargin.ImeMode")));
			this.txtRightMargin.Location = ((System.Drawing.Point)(resources.GetObject("txtRightMargin.Location")));
			this.txtRightMargin.MaxLength = ((int)(resources.GetObject("txtRightMargin.MaxLength")));
			this.txtRightMargin.Multiline = ((bool)(resources.GetObject("txtRightMargin.Multiline")));
			this.txtRightMargin.PasswordChar = ((char)(resources.GetObject("txtRightMargin.PasswordChar")));
			this.txtRightMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtRightMargin.RightToLeft")));
			this.txtRightMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtRightMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtRightMargin, ((bool)(resources.GetObject("txtRightMargin.ShowHelp"))));
			this.txtRightMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtRightMargin.Size")));
			this.txtRightMargin.TabIndex = ((int)(resources.GetObject("txtRightMargin.TabIndex")));
			this.txtRightMargin.Text = resources.GetString("txtRightMargin.Text");
			this.txtRightMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtRightMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtRightMargin, resources.GetString("txtRightMargin.ToolTip"));
			this.txtRightMargin.WordWrap = ((bool)(resources.GetObject("txtRightMargin.WordWrap")));
			// 
			// txtBottomMargin
			// 
			this.txtBottomMargin.AccessibleDescription = null;
			this.txtBottomMargin.AccessibleName = null;
			this.txtBottomMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtBottomMargin.Anchor")));
			this.txtBottomMargin.BackgroundImage = null;
			this.txtBottomMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtBottomMargin.BackgroundImageLayout")));
			this.txtBottomMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtBottomMargin.Dock")));
			this.txtBottomMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtBottomMargin, resources.GetString("txtBottomMargin.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtBottomMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtBottomMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtBottomMargin, null);
			this.txtBottomMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtBottomMargin.ImeMode")));
			this.txtBottomMargin.Location = ((System.Drawing.Point)(resources.GetObject("txtBottomMargin.Location")));
			this.txtBottomMargin.MaxLength = ((int)(resources.GetObject("txtBottomMargin.MaxLength")));
			this.txtBottomMargin.Multiline = ((bool)(resources.GetObject("txtBottomMargin.Multiline")));
			this.txtBottomMargin.PasswordChar = ((char)(resources.GetObject("txtBottomMargin.PasswordChar")));
			this.txtBottomMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtBottomMargin.RightToLeft")));
			this.txtBottomMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtBottomMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtBottomMargin, ((bool)(resources.GetObject("txtBottomMargin.ShowHelp"))));
			this.txtBottomMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtBottomMargin.Size")));
			this.txtBottomMargin.TabIndex = ((int)(resources.GetObject("txtBottomMargin.TabIndex")));
			this.txtBottomMargin.Text = resources.GetString("txtBottomMargin.Text");
			this.txtBottomMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtBottomMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtBottomMargin, resources.GetString("txtBottomMargin.ToolTip"));
			this.txtBottomMargin.WordWrap = ((bool)(resources.GetObject("txtBottomMargin.WordWrap")));
			// 
			// txtToday
			// 
			this.txtToday.AccessibleDescription = null;
			this.txtToday.AccessibleName = null;
			this.txtToday.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtToday.Anchor")));
			this.txtToday.BackgroundImage = null;
			this.txtToday.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtToday.BackgroundImageLayout")));
			this.txtToday.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtToday.Dock")));
			this.txtToday.Enabled = ((bool)(resources.GetObject("txtToday.Enabled")));
			this.txtToday.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtToday, null);
			this.hlpProvider.SetHelpNavigator(this.txtToday, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtToday.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtToday, null);
			this.txtToday.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtToday.ImeMode")));
			this.txtToday.Location = ((System.Drawing.Point)(resources.GetObject("txtToday.Location")));
			this.txtToday.MaxLength = ((int)(resources.GetObject("txtToday.MaxLength")));
			this.txtToday.Multiline = ((bool)(resources.GetObject("txtToday.Multiline")));
			this.txtToday.PasswordChar = ((char)(resources.GetObject("txtToday.PasswordChar")));
			this.txtToday.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtToday.RightToLeft")));
			this.txtToday.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtToday.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtToday, ((bool)(resources.GetObject("txtToday.ShowHelp"))));
			this.txtToday.Size = ((System.Drawing.Size)(resources.GetObject("txtToday.Size")));
			this.txtToday.TabIndex = ((int)(resources.GetObject("txtToday.TabIndex")));
			this.txtToday.Text = resources.GetString("txtToday.Text");
			this.txtToday.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtToday.TextAlign")));
			this.propToolTip.SetToolTip(this.txtToday, resources.GetString("txtToday.ToolTip"));
			this.txtToday.WordWrap = ((bool)(resources.GetObject("txtToday.WordWrap")));
			// 
			// txtFile
			// 
			this.txtFile.AccessibleDescription = null;
			this.txtFile.AccessibleName = null;
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtFile.Anchor")));
			this.txtFile.BackgroundImage = null;
			this.txtFile.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtFile.BackgroundImageLayout")));
			this.txtFile.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtFile.Dock")));
			this.txtFile.Enabled = ((bool)(resources.GetObject("txtFile.Enabled")));
			this.txtFile.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtFile, null);
			this.hlpProvider.SetHelpNavigator(this.txtFile, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtFile.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtFile, null);
			this.txtFile.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtFile.ImeMode")));
			this.txtFile.Location = ((System.Drawing.Point)(resources.GetObject("txtFile.Location")));
			this.txtFile.MaxLength = ((int)(resources.GetObject("txtFile.MaxLength")));
			this.txtFile.Multiline = ((bool)(resources.GetObject("txtFile.Multiline")));
			this.txtFile.PasswordChar = ((char)(resources.GetObject("txtFile.PasswordChar")));
			this.txtFile.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtFile.RightToLeft")));
			this.txtFile.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtFile.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtFile, ((bool)(resources.GetObject("txtFile.ShowHelp"))));
			this.txtFile.Size = ((System.Drawing.Size)(resources.GetObject("txtFile.Size")));
			this.txtFile.TabIndex = ((int)(resources.GetObject("txtFile.TabIndex")));
			this.txtFile.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtFile.TextAlign")));
			this.propToolTip.SetToolTip(this.txtFile, resources.GetString("txtFile.ToolTip"));
			this.txtFile.WordWrap = ((bool)(resources.GetObject("txtFile.WordWrap")));
			// 
			// tabPageTest
			// 
			this.tabPageTest.AccessibleDescription = null;
			this.tabPageTest.AccessibleName = null;
			this.tabPageTest.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPageTest.Anchor")));
			this.tabPageTest.AutoScroll = ((bool)(resources.GetObject("tabPageTest.AutoScroll")));
			this.tabPageTest.BackgroundImage = null;
			this.tabPageTest.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabPageTest.BackgroundImageLayout")));
			this.tabPageTest.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPageTest.Dock")));
			this.tabPageTest.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabPageTest, null);
			this.hlpProvider.SetHelpNavigator(this.tabPageTest, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPageTest.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabPageTest, null);
			this.tabPageTest.ImageIndex = ((int)(resources.GetObject("tabPageTest.ImageIndex")));
			this.tabPageTest.ImageKey = resources.GetString("tabPageTest.ImageKey");
			this.tabPageTest.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPageTest.ImeMode")));
			this.tabPageTest.Location = ((System.Drawing.Point)(resources.GetObject("tabPageTest.Location")));
			this.tabPageTest.Name = "tabPageTest";
			this.tabPageTest.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPageTest.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.tabPageTest, ((bool)(resources.GetObject("tabPageTest.ShowHelp"))));
			this.tabPageTest.Size = ((System.Drawing.Size)(resources.GetObject("tabPageTest.Size")));
			this.tabPageTest.TabIndex = ((int)(resources.GetObject("tabPageTest.TabIndex")));
			this.propToolTip.SetToolTip(this.tabPageTest, resources.GetString("tabPageTest.ToolTip"));
			this.tabPageTest.ToolTipText = resources.GetString("tabPageTest.ToolTipText");
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = null;
			this.groupBox1.AccessibleName = null;
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.AutoSize = ((bool)(resources.GetObject("groupBox1.AutoSize")));
			this.groupBox1.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("groupBox1.AutoSizeMode")));
			this.groupBox1.BackgroundImage = null;
			this.groupBox1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("groupBox1.BackgroundImageLayout")));
			this.groupBox1.Controls.Add(this.txtDiagramName);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Font = null;
			this.hlpProvider.SetHelpKeyword(this.groupBox1, null);
			this.hlpProvider.SetHelpNavigator(this.groupBox1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox1.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.groupBox1, null);
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.groupBox1, ((bool)(resources.GetObject("groupBox1.ShowHelp"))));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.propToolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
			// 
			// txtDiagramName
			// 
			this.txtDiagramName.AccessibleDescription = null;
			this.txtDiagramName.AccessibleName = null;
			this.txtDiagramName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtDiagramName.Anchor")));
			this.txtDiagramName.BackgroundImage = null;
			this.txtDiagramName.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtDiagramName.BackgroundImageLayout")));
			this.txtDiagramName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtDiagramName.Dock")));
			this.txtDiagramName.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtDiagramName, resources.GetString("txtDiagramName.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtDiagramName, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtDiagramName.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtDiagramName, null);
			this.txtDiagramName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtDiagramName.ImeMode")));
			this.txtDiagramName.Location = ((System.Drawing.Point)(resources.GetObject("txtDiagramName.Location")));
			this.txtDiagramName.MaxLength = ((int)(resources.GetObject("txtDiagramName.MaxLength")));
			this.txtDiagramName.Multiline = ((bool)(resources.GetObject("txtDiagramName.Multiline")));
			this.txtDiagramName.Name = "txtDiagramName";
			this.txtDiagramName.PasswordChar = ((char)(resources.GetObject("txtDiagramName.PasswordChar")));
			this.txtDiagramName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtDiagramName.RightToLeft")));
			this.txtDiagramName.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtDiagramName.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtDiagramName, ((bool)(resources.GetObject("txtDiagramName.ShowHelp"))));
			this.txtDiagramName.Size = ((System.Drawing.Size)(resources.GetObject("txtDiagramName.Size")));
			this.txtDiagramName.TabIndex = ((int)(resources.GetObject("txtDiagramName.TabIndex")));
			this.txtDiagramName.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtDiagramName.TextAlign")));
			this.propToolTip.SetToolTip(this.txtDiagramName, resources.GetString("txtDiagramName.ToolTip"));
			this.txtDiagramName.WordWrap = ((bool)(resources.GetObject("txtDiagramName.WordWrap")));
			// 
			// label7
			// 
			this.label7.AccessibleDescription = null;
			this.label7.AccessibleName = null;
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label7.Anchor")));
			this.label7.AutoSize = ((bool)(resources.GetObject("label7.AutoSize")));
			this.label7.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label7.BackgroundImageLayout")));
			this.label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label7.Dock")));
			this.label7.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label7, null);
			this.hlpProvider.SetHelpNavigator(this.label7, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label7.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label7, null);
			this.label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.ImageAlign")));
			this.label7.ImageIndex = ((int)(resources.GetObject("label7.ImageIndex")));
			this.label7.ImageKey = resources.GetString("label7.ImageKey");
			this.label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label7.ImeMode")));
			this.label7.Location = ((System.Drawing.Point)(resources.GetObject("label7.Location")));
			this.label7.Name = "label7";
			this.label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label7.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
			this.label7.Size = ((System.Drawing.Size)(resources.GetObject("label7.Size")));
			this.label7.TabIndex = ((int)(resources.GetObject("label7.TabIndex")));
			this.label7.Text = resources.GetString("label7.Text");
			this.label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.TextAlign")));
			this.propToolTip.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
			// 
			// groupBox2
			// 
			this.groupBox2.AccessibleDescription = null;
			this.groupBox2.AccessibleName = null;
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox2.Anchor")));
			this.groupBox2.AutoSize = ((bool)(resources.GetObject("groupBox2.AutoSize")));
			this.groupBox2.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("groupBox2.AutoSizeMode")));
			this.groupBox2.BackgroundImage = null;
			this.groupBox2.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("groupBox2.BackgroundImageLayout")));
			this.groupBox2.Controls.Add(this.optStyleUML);
			this.groupBox2.Controls.Add(this.optStyleSDL);
			this.groupBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox2.Dock")));
			this.groupBox2.Font = null;
			this.hlpProvider.SetHelpKeyword(this.groupBox2, null);
			this.hlpProvider.SetHelpNavigator(this.groupBox2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox2.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.groupBox2, null);
			this.groupBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox2.ImeMode")));
			this.groupBox2.Location = ((System.Drawing.Point)(resources.GetObject("groupBox2.Location")));
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox2.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.groupBox2, ((bool)(resources.GetObject("groupBox2.ShowHelp"))));
			this.groupBox2.Size = ((System.Drawing.Size)(resources.GetObject("groupBox2.Size")));
			this.groupBox2.TabIndex = ((int)(resources.GetObject("groupBox2.TabIndex")));
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = resources.GetString("groupBox2.Text");
			this.propToolTip.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
			// 
			// optStyleUML
			// 
			this.optStyleUML.AccessibleDescription = null;
			this.optStyleUML.AccessibleName = null;
			this.optStyleUML.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optStyleUML.Anchor")));
			this.optStyleUML.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optStyleUML.Appearance")));
			this.optStyleUML.AutoSize = ((bool)(resources.GetObject("optStyleUML.AutoSize")));
			this.optStyleUML.BackgroundImage = null;
			this.optStyleUML.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optStyleUML.BackgroundImageLayout")));
			this.optStyleUML.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optStyleUML.CheckAlign")));
			this.optStyleUML.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optStyleUML.Dock")));
			this.optStyleUML.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optStyleUML.FlatStyle")));
			this.optStyleUML.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optStyleUML, resources.GetString("optStyleUML.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optStyleUML, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optStyleUML.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optStyleUML, null);
			this.optStyleUML.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optStyleUML.ImageAlign")));
			this.optStyleUML.ImageIndex = ((int)(resources.GetObject("optStyleUML.ImageIndex")));
			this.optStyleUML.ImageKey = resources.GetString("optStyleUML.ImageKey");
			this.optStyleUML.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optStyleUML.ImeMode")));
			this.optStyleUML.Location = ((System.Drawing.Point)(resources.GetObject("optStyleUML.Location")));
			this.optStyleUML.Name = "optStyleUML";
			this.optStyleUML.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optStyleUML.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optStyleUML, ((bool)(resources.GetObject("optStyleUML.ShowHelp"))));
			this.optStyleUML.Size = ((System.Drawing.Size)(resources.GetObject("optStyleUML.Size")));
			this.optStyleUML.TabIndex = ((int)(resources.GetObject("optStyleUML.TabIndex")));
			this.optStyleUML.Text = resources.GetString("optStyleUML.Text");
			this.optStyleUML.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optStyleUML.TextAlign")));
			this.optStyleUML.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optStyleUML.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optStyleUML, resources.GetString("optStyleUML.ToolTip"));
			this.optStyleUML.UseVisualStyleBackColor = true;
			// 
			// optStyleSDL
			// 
			this.optStyleSDL.AccessibleDescription = null;
			this.optStyleSDL.AccessibleName = null;
			this.optStyleSDL.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optStyleSDL.Anchor")));
			this.optStyleSDL.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optStyleSDL.Appearance")));
			this.optStyleSDL.AutoSize = ((bool)(resources.GetObject("optStyleSDL.AutoSize")));
			this.optStyleSDL.BackgroundImage = null;
			this.optStyleSDL.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optStyleSDL.BackgroundImageLayout")));
			this.optStyleSDL.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optStyleSDL.CheckAlign")));
			this.optStyleSDL.Checked = true;
			this.optStyleSDL.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optStyleSDL.Dock")));
			this.optStyleSDL.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optStyleSDL.FlatStyle")));
			this.optStyleSDL.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optStyleSDL, resources.GetString("optStyleSDL.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optStyleSDL, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optStyleSDL.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optStyleSDL, null);
			this.optStyleSDL.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optStyleSDL.ImageAlign")));
			this.optStyleSDL.ImageIndex = ((int)(resources.GetObject("optStyleSDL.ImageIndex")));
			this.optStyleSDL.ImageKey = resources.GetString("optStyleSDL.ImageKey");
			this.optStyleSDL.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optStyleSDL.ImeMode")));
			this.optStyleSDL.Location = ((System.Drawing.Point)(resources.GetObject("optStyleSDL.Location")));
			this.optStyleSDL.Name = "optStyleSDL";
			this.optStyleSDL.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optStyleSDL.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optStyleSDL, ((bool)(resources.GetObject("optStyleSDL.ShowHelp"))));
			this.optStyleSDL.Size = ((System.Drawing.Size)(resources.GetObject("optStyleSDL.Size")));
			this.optStyleSDL.TabIndex = ((int)(resources.GetObject("optStyleSDL.TabIndex")));
			this.optStyleSDL.TabStop = true;
			this.optStyleSDL.Text = resources.GetString("optStyleSDL.Text");
			this.optStyleSDL.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optStyleSDL.TextAlign")));
			this.optStyleSDL.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optStyleSDL.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optStyleSDL, resources.GetString("optStyleSDL.ToolTip"));
			this.optStyleSDL.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.AccessibleDescription = null;
			this.groupBox3.AccessibleName = null;
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox3.Anchor")));
			this.groupBox3.AutoSize = ((bool)(resources.GetObject("groupBox3.AutoSize")));
			this.groupBox3.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("groupBox3.AutoSizeMode")));
			this.groupBox3.BackgroundImage = null;
			this.groupBox3.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("groupBox3.BackgroundImageLayout")));
			this.groupBox3.Controls.Add(this.chkAutosizeExport);
			this.groupBox3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox3.Dock")));
			this.groupBox3.Font = null;
			this.hlpProvider.SetHelpKeyword(this.groupBox3, null);
			this.hlpProvider.SetHelpNavigator(this.groupBox3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox3.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.groupBox3, null);
			this.groupBox3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox3.ImeMode")));
			this.groupBox3.Location = ((System.Drawing.Point)(resources.GetObject("groupBox3.Location")));
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox3.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.groupBox3, ((bool)(resources.GetObject("groupBox3.ShowHelp"))));
			this.groupBox3.Size = ((System.Drawing.Size)(resources.GetObject("groupBox3.Size")));
			this.groupBox3.TabIndex = ((int)(resources.GetObject("groupBox3.TabIndex")));
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = resources.GetString("groupBox3.Text");
			this.propToolTip.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
			// 
			// chkAutosizeExport
			// 
			this.chkAutosizeExport.AccessibleDescription = null;
			this.chkAutosizeExport.AccessibleName = null;
			this.chkAutosizeExport.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkAutosizeExport.Anchor")));
			this.chkAutosizeExport.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkAutosizeExport.Appearance")));
			this.chkAutosizeExport.AutoSize = ((bool)(resources.GetObject("chkAutosizeExport.AutoSize")));
			this.chkAutosizeExport.BackgroundImage = null;
			this.chkAutosizeExport.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkAutosizeExport.BackgroundImageLayout")));
			this.chkAutosizeExport.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutosizeExport.CheckAlign")));
			this.chkAutosizeExport.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkAutosizeExport.Dock")));
			this.chkAutosizeExport.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkAutosizeExport.FlatStyle")));
			this.chkAutosizeExport.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkAutosizeExport, resources.GetString("chkAutosizeExport.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkAutosizeExport, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkAutosizeExport.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkAutosizeExport, null);
			this.chkAutosizeExport.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutosizeExport.ImageAlign")));
			this.chkAutosizeExport.ImageIndex = ((int)(resources.GetObject("chkAutosizeExport.ImageIndex")));
			this.chkAutosizeExport.ImageKey = resources.GetString("chkAutosizeExport.ImageKey");
			this.chkAutosizeExport.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAutosizeExport.ImeMode")));
			this.chkAutosizeExport.Location = ((System.Drawing.Point)(resources.GetObject("chkAutosizeExport.Location")));
			this.chkAutosizeExport.Name = "chkAutosizeExport";
			this.chkAutosizeExport.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAutosizeExport.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkAutosizeExport, ((bool)(resources.GetObject("chkAutosizeExport.ShowHelp"))));
			this.chkAutosizeExport.Size = ((System.Drawing.Size)(resources.GetObject("chkAutosizeExport.Size")));
			this.chkAutosizeExport.TabIndex = ((int)(resources.GetObject("chkAutosizeExport.TabIndex")));
			this.chkAutosizeExport.Text = resources.GetString("chkAutosizeExport.Text");
			this.chkAutosizeExport.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutosizeExport.TextAlign")));
			this.chkAutosizeExport.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkAutosizeExport.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkAutosizeExport, resources.GetString("chkAutosizeExport.ToolTip"));
			this.chkAutosizeExport.UseVisualStyleBackColor = true;
			// 
			// chkAutoWidth
			// 
			this.chkAutoWidth.AccessibleDescription = null;
			this.chkAutoWidth.AccessibleName = null;
			this.chkAutoWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkAutoWidth.Anchor")));
			this.chkAutoWidth.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkAutoWidth.Appearance")));
			this.chkAutoWidth.AutoSize = ((bool)(resources.GetObject("chkAutoWidth.AutoSize")));
			this.chkAutoWidth.BackgroundImage = null;
			this.chkAutoWidth.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkAutoWidth.BackgroundImageLayout")));
			this.chkAutoWidth.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutoWidth.CheckAlign")));
			this.chkAutoWidth.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkAutoWidth.Dock")));
			this.chkAutoWidth.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkAutoWidth.FlatStyle")));
			this.chkAutoWidth.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkAutoWidth, resources.GetString("chkAutoWidth.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkAutoWidth, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkAutoWidth.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkAutoWidth, null);
			this.chkAutoWidth.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutoWidth.ImageAlign")));
			this.chkAutoWidth.ImageIndex = ((int)(resources.GetObject("chkAutoWidth.ImageIndex")));
			this.chkAutoWidth.ImageKey = resources.GetString("chkAutoWidth.ImageKey");
			this.chkAutoWidth.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAutoWidth.ImeMode")));
			this.chkAutoWidth.Location = ((System.Drawing.Point)(resources.GetObject("chkAutoWidth.Location")));
			this.chkAutoWidth.Name = "chkAutoWidth";
			this.chkAutoWidth.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAutoWidth.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkAutoWidth, ((bool)(resources.GetObject("chkAutoWidth.ShowHelp"))));
			this.chkAutoWidth.Size = ((System.Drawing.Size)(resources.GetObject("chkAutoWidth.Size")));
			this.chkAutoWidth.TabIndex = ((int)(resources.GetObject("chkAutoWidth.TabIndex")));
			this.chkAutoWidth.Text = resources.GetString("chkAutoWidth.Text");
			this.chkAutoWidth.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutoWidth.TextAlign")));
			this.chkAutoWidth.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkAutoWidth.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkAutoWidth, resources.GetString("chkAutoWidth.ToolTip"));
			this.chkAutoWidth.UseVisualStyleBackColor = true;
			this.chkAutoWidth.CheckedChanged += new System.EventHandler(this.ChkAutoWidthCheckedChanged);
			// 
			// chkAutoHeight
			// 
			this.chkAutoHeight.AccessibleDescription = null;
			this.chkAutoHeight.AccessibleName = null;
			this.chkAutoHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkAutoHeight.Anchor")));
			this.chkAutoHeight.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkAutoHeight.Appearance")));
			this.chkAutoHeight.AutoSize = ((bool)(resources.GetObject("chkAutoHeight.AutoSize")));
			this.chkAutoHeight.BackgroundImage = null;
			this.chkAutoHeight.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkAutoHeight.BackgroundImageLayout")));
			this.chkAutoHeight.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutoHeight.CheckAlign")));
			this.chkAutoHeight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkAutoHeight.Dock")));
			this.chkAutoHeight.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkAutoHeight.FlatStyle")));
			this.chkAutoHeight.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkAutoHeight, resources.GetString("chkAutoHeight.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkAutoHeight, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkAutoHeight.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkAutoHeight, null);
			this.chkAutoHeight.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutoHeight.ImageAlign")));
			this.chkAutoHeight.ImageIndex = ((int)(resources.GetObject("chkAutoHeight.ImageIndex")));
			this.chkAutoHeight.ImageKey = resources.GetString("chkAutoHeight.ImageKey");
			this.chkAutoHeight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAutoHeight.ImeMode")));
			this.chkAutoHeight.Location = ((System.Drawing.Point)(resources.GetObject("chkAutoHeight.Location")));
			this.chkAutoHeight.Name = "chkAutoHeight";
			this.chkAutoHeight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAutoHeight.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkAutoHeight, ((bool)(resources.GetObject("chkAutoHeight.ShowHelp"))));
			this.chkAutoHeight.Size = ((System.Drawing.Size)(resources.GetObject("chkAutoHeight.Size")));
			this.chkAutoHeight.TabIndex = ((int)(resources.GetObject("chkAutoHeight.TabIndex")));
			this.chkAutoHeight.Text = resources.GetString("chkAutoHeight.Text");
			this.chkAutoHeight.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAutoHeight.TextAlign")));
			this.chkAutoHeight.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkAutoHeight.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkAutoHeight, resources.GetString("chkAutoHeight.ToolTip"));
			this.chkAutoHeight.UseVisualStyleBackColor = true;
			this.chkAutoHeight.CheckedChanged += new System.EventHandler(this.ChkAutoHeightCheckedChanged);
			// 
			// Property
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackgroundImage = null;
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Font = null;
			this.HelpButton = true;
			this.hlpProvider.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this, null);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "Property";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.hlpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.propToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.Load += new System.EventHandler(this.PropertyLoad);
			this.tabProperties.ResumeLayout(false);
			this.tabPageWorksheet.ResumeLayout(false);
			this.tabPageWorksheet.PerformLayout();
			this.tabOptions.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox chkAutoWidth;
		private System.Windows.Forms.CheckBox chkAutoHeight;
		private System.Windows.Forms.CheckBox chkAutosizeExport;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label7;
		protected System.Windows.Forms.TextBox txtDiagramName;
		private System.Windows.Forms.RadioButton optStyleSDL;
		private System.Windows.Forms.RadioButton optStyleUML;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		#endregion
		
		protected override void  CmdOkClick(object sender, System.EventArgs e)
		{
			this.SetWorksheetProps();
			Output.AutosizeOutputHeight = this.chkAutoHeight.Checked;
			Output.AutosizeOutputWidth = this.chkAutoWidth.Checked;
			if (OnAcceptClick != null) OnAcceptClick(this, new EventArgs());
			this.Dispose();
		}
		protected override void  CmdAcceptClick(object sender, System.EventArgs e)
		{
			this.SetWorksheetProps();
			Output.AutosizeOutputHeight = this.chkAutoHeight.Checked;
			Output.AutosizeOutputWidth = this.chkAutoWidth.Checked;
			if (OnAcceptClick != null) OnAcceptClick(this, new EventArgs());
		}
		public int ItemID{
			get{
				return this.mID;
			}
			set{
				this.mID = value;
			}
		}
		public virtual string TitelText{
			get{
				return "";
			}
			set{
				
			}
		}
		public virtual string DiagramName{
			get{
				return this.txtDiagramName.Text;
			}
			set{
				this.txtDiagramName.Text = value;
			}
		}
		
		public virtual string EditorText{
			get{
				return this.mEditorText;
			}
			set{
				this.mEditorText = value;
			}
		}
		public virtual bool AutosizeExport{
			get{
				return this.chkAutosizeExport.Checked;
			}
			set{
				this.chkAutosizeExport.Checked = value;
			}
		}
		public virtual bool AutoWidth{
			get{
				return this.chkAutoWidth.Checked;
			}
			set{
				this.chkAutoWidth.Checked = value;
			}
		}
		public virtual bool AutoHeight{
			get{
				return this.chkAutoHeight.Checked;
			}
			set{
				this.chkAutoHeight.Checked = value;
			}
		}
		
		public virtual Size PropSize{
			get{
				return new Size(0,0);
			}
		}
		public virtual string PropText{
			get{
				return "";
			}
		}
		public virtual MscStyle DiagramStyle{
			get{
				if (this.optStyleSDL.Checked == true){
					return MscStyle.SDL;
				}
				else if (this.optStyleUML.Checked == true){
					return MscStyle.UML2;
				}
				return MscStyle.SDL;
			}
			set{
				if(value == MscStyle.SDL){
					this.optStyleSDL.Checked = true;
				}
				else if (value == MscStyle.UML2){
					this.optStyleUML.Checked = true;
				}
			}
		}
		public virtual void DiagramStyleChanged(MscStyle newStyle)
		{
			if(newStyle == MscStyle.SDL){
				this.optStyleSDL.Checked = true;
			}
			else if (newStyle == MscStyle.UML2){
				this.optStyleUML.Checked = true;
			}
		}
		// Event handler to redraw preview image
		protected void PropertyImageRedraw(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(propertyImage,new RectangleF(0,0,100,80));
		}
		
		void ChkAutoWidthCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chkAutoWidth.Checked == true){
				this.cboPictureSize.SelectedIndex = 0;
				this.cboPictureSize.Enabled = false;
				this.txtWidth.Enabled = false;
			}
			else{
				if (this.chkAutoHeight.Checked == false)
					this.cboPictureSize.Enabled = true;
				this.txtWidth.Enabled = true;
			}
		}
		
		void ChkAutoHeightCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chkAutoHeight.Checked == true){
				this.cboPictureSize.SelectedIndex = 0;
				this.cboPictureSize.Enabled = false;
				this.txtHeight.Enabled = false;
			}
			else{
				if (this.chkAutoWidth.Checked == false)
					this.cboPictureSize.Enabled = true;
				this.txtHeight.Enabled = true;
			}			
		}
		
		void PropertyLoad(object sender, System.EventArgs e)
		{
			this.hlpProvider.HelpNamespace = Output.HelpLocation;
		}
		
		protected override void TabOptionsSelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabOptions.SelectedIndex == 0){
				this.hlpProvider.SetHelpKeyword(this.tabOptions, "Arbeitsblatt");
				this.hlpProvider.SetHelpNavigator(this.tabOptions, HelpNavigator.KeywordIndex);
			}
			else if (this.tabOptions.SelectedIndex == 1){
				this.hlpProvider.SetHelpKeyword(this.tabOptions, "Einstellung");
				this.hlpProvider.SetHelpNavigator(this.tabOptions, HelpNavigator.KeywordIndex);
			}
		}
		// converts the editor text to dialog text
		protected string EnformatText(string text)
		{
			string result = string.Empty;
			char[] chars;
			bool slash = false;
			
			chars = text.ToCharArray();
			foreach(char c in chars){										// parse the text
				if ((c=='\\') && (slash==false)){
				    slash=true;
				}
				else if ((c=='\\')&&(slash==true)){
					result += "\\";
					slash = false;
				}
				else if ((c=='n')&&(slash==true)){
					result += "\r\n";
					slash = false;
				}
				else if ((c=='"') && (slash==true)){
					result += "\"";
				}
				else{
					result += c;
					slash=false;
				}
			
			}
			if (slash==true){
				result += '\\';
			}
			return result;											
		}
		
		// converts the dialog text to editor text
		protected string DeformatText(string text)
		{
			string result = string.Empty;
			char[] chars;
			
			chars = text.ToCharArray();
			foreach(char c in chars){										// parse the text
				if (c=='\\'){
				    result += "\\\\";
				}
				else if (c=='"'){
					result += "\\\"";
				}
				else{
					result += c;
				}			
			}
			return result.Replace("\r\n","\\n");
		}
	}
}
