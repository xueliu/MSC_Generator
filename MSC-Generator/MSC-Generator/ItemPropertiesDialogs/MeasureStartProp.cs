/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 04.04.2006
 * Time: 12:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using mscElements;

namespace MscItemProp
{
	/// <summary>
	/// Description of Name.
	/// </summary>
	//public delegate void AcceptClickEventHandler(object sender, EventArgs e);
	
	public class MeasureStartProp : Property
	{				
		public MeasureStartProp()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			SetSize();
			DrawPropertyImage();
			this.tabOptions.SelectedIndex = 2;
			this.hlpProvider.SetHelpKeyword(this.tabOptions, "dlgMeasureStart");
			this.hlpProvider.SetHelpNavigator(this.tabOptions, HelpNavigator.KeywordIndex);
		}
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasureStartProp));
			this.tabItem = new System.Windows.Forms.TabPage();
			this.groupBox21 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.optFormatOuter = new System.Windows.Forms.RadioButton();
			this.optFormatInner = new System.Windows.Forms.RadioButton();
			this.picPreview = new System.Windows.Forms.PictureBox();
			this.groupBox31 = new System.Windows.Forms.GroupBox();
			this.optDirectionL = new System.Windows.Forms.RadioButton();
			this.optDirectionR = new System.Windows.Forms.RadioButton();
			this.txtPropGate = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtPropMeasure = new System.Windows.Forms.TextBox();
			this.label71 = new System.Windows.Forms.Label();
			this.tabPageWorksheet.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.tabItem.SuspendLayout();
			this.groupBox21.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
			this.groupBox31.SuspendLayout();
			this.SuspendLayout();
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
			// hlpProvider
			// 
			this.hlpProvider.HelpNamespace = resources.GetString("hlpProvider.HelpNamespace");
			// 
			// tabProperties
			// 
			this.tabProperties.AccessibleDescription = null;
			this.tabProperties.AccessibleName = null;
			this.tabProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabProperties.Anchor")));
			this.tabProperties.AutoScroll = ((bool)(resources.GetObject("tabProperties.AutoScroll")));
			this.tabProperties.BackgroundImage = null;
			this.tabProperties.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabProperties.BackgroundImageLayout")));
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
			this.tabOptions.Controls.Add(this.tabItem);
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
			this.tabOptions.Controls.SetChildIndex(this.tabItem, 0);
			this.tabOptions.Controls.SetChildIndex(this.tabProperties, 0);
			this.tabOptions.Controls.SetChildIndex(this.tabPageWorksheet, 0);
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
			// tabItem
			// 
			this.tabItem.AccessibleDescription = null;
			this.tabItem.AccessibleName = null;
			this.tabItem.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabItem.Anchor")));
			this.tabItem.AutoScroll = ((bool)(resources.GetObject("tabItem.AutoScroll")));
			this.tabItem.BackgroundImage = null;
			this.tabItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabItem.BackgroundImageLayout")));
			this.tabItem.Controls.Add(this.groupBox21);
			this.tabItem.Controls.Add(this.txtPropGate);
			this.tabItem.Controls.Add(this.label8);
			this.tabItem.Controls.Add(this.txtPropMeasure);
			this.tabItem.Controls.Add(this.label71);
			this.tabItem.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabItem.Dock")));
			this.tabItem.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabItem, null);
			this.hlpProvider.SetHelpNavigator(this.tabItem, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabItem.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabItem, null);
			this.tabItem.ImageIndex = ((int)(resources.GetObject("tabItem.ImageIndex")));
			this.tabItem.ImageKey = resources.GetString("tabItem.ImageKey");
			this.tabItem.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabItem.ImeMode")));
			this.tabItem.Location = ((System.Drawing.Point)(resources.GetObject("tabItem.Location")));
			this.tabItem.Name = "tabItem";
			this.tabItem.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabItem.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.tabItem, ((bool)(resources.GetObject("tabItem.ShowHelp"))));
			this.tabItem.Size = ((System.Drawing.Size)(resources.GetObject("tabItem.Size")));
			this.tabItem.TabIndex = ((int)(resources.GetObject("tabItem.TabIndex")));
			this.tabItem.Text = resources.GetString("tabItem.Text");
			this.propToolTip.SetToolTip(this.tabItem, resources.GetString("tabItem.ToolTip"));
			this.tabItem.ToolTipText = resources.GetString("tabItem.ToolTipText");
			this.tabItem.UseVisualStyleBackColor = true;
			// 
			// groupBox21
			// 
			this.groupBox21.AccessibleDescription = null;
			this.groupBox21.AccessibleName = null;
			this.groupBox21.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox21.Anchor")));
			this.groupBox21.AutoSize = ((bool)(resources.GetObject("groupBox21.AutoSize")));
			this.groupBox21.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("groupBox21.AutoSizeMode")));
			this.groupBox21.BackgroundImage = null;
			this.groupBox21.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("groupBox21.BackgroundImageLayout")));
			this.groupBox21.Controls.Add(this.groupBox4);
			this.groupBox21.Controls.Add(this.picPreview);
			this.groupBox21.Controls.Add(this.groupBox31);
			this.groupBox21.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox21.Dock")));
			this.groupBox21.Font = null;
			this.hlpProvider.SetHelpKeyword(this.groupBox21, null);
			this.hlpProvider.SetHelpNavigator(this.groupBox21, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox21.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.groupBox21, null);
			this.groupBox21.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox21.ImeMode")));
			this.groupBox21.Location = ((System.Drawing.Point)(resources.GetObject("groupBox21.Location")));
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox21.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.groupBox21, ((bool)(resources.GetObject("groupBox21.ShowHelp"))));
			this.groupBox21.Size = ((System.Drawing.Size)(resources.GetObject("groupBox21.Size")));
			this.groupBox21.TabIndex = ((int)(resources.GetObject("groupBox21.TabIndex")));
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = resources.GetString("groupBox21.Text");
			this.propToolTip.SetToolTip(this.groupBox21, resources.GetString("groupBox21.ToolTip"));
			// 
			// groupBox4
			// 
			this.groupBox4.AccessibleDescription = null;
			this.groupBox4.AccessibleName = null;
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox4.Anchor")));
			this.groupBox4.AutoSize = ((bool)(resources.GetObject("groupBox4.AutoSize")));
			this.groupBox4.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("groupBox4.AutoSizeMode")));
			this.groupBox4.BackgroundImage = null;
			this.groupBox4.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("groupBox4.BackgroundImageLayout")));
			this.groupBox4.Controls.Add(this.optFormatOuter);
			this.groupBox4.Controls.Add(this.optFormatInner);
			this.groupBox4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox4.Dock")));
			this.groupBox4.Font = null;
			this.hlpProvider.SetHelpKeyword(this.groupBox4, null);
			this.hlpProvider.SetHelpNavigator(this.groupBox4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox4.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.groupBox4, null);
			this.groupBox4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox4.ImeMode")));
			this.groupBox4.Location = ((System.Drawing.Point)(resources.GetObject("groupBox4.Location")));
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox4.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.groupBox4, ((bool)(resources.GetObject("groupBox4.ShowHelp"))));
			this.groupBox4.Size = ((System.Drawing.Size)(resources.GetObject("groupBox4.Size")));
			this.groupBox4.TabIndex = ((int)(resources.GetObject("groupBox4.TabIndex")));
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = resources.GetString("groupBox4.Text");
			this.propToolTip.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
			// 
			// optFormatOuter
			// 
			this.optFormatOuter.AccessibleDescription = null;
			this.optFormatOuter.AccessibleName = null;
			this.optFormatOuter.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optFormatOuter.Anchor")));
			this.optFormatOuter.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optFormatOuter.Appearance")));
			this.optFormatOuter.AutoSize = ((bool)(resources.GetObject("optFormatOuter.AutoSize")));
			this.optFormatOuter.BackgroundImage = null;
			this.optFormatOuter.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optFormatOuter.BackgroundImageLayout")));
			this.optFormatOuter.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optFormatOuter.CheckAlign")));
			this.optFormatOuter.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optFormatOuter.Dock")));
			this.optFormatOuter.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optFormatOuter.FlatStyle")));
			this.optFormatOuter.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optFormatOuter, resources.GetString("optFormatOuter.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optFormatOuter, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optFormatOuter.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optFormatOuter, null);
			this.optFormatOuter.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optFormatOuter.ImageAlign")));
			this.optFormatOuter.ImageIndex = ((int)(resources.GetObject("optFormatOuter.ImageIndex")));
			this.optFormatOuter.ImageKey = resources.GetString("optFormatOuter.ImageKey");
			this.optFormatOuter.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optFormatOuter.ImeMode")));
			this.optFormatOuter.Location = ((System.Drawing.Point)(resources.GetObject("optFormatOuter.Location")));
			this.optFormatOuter.Name = "optFormatOuter";
			this.optFormatOuter.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optFormatOuter.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optFormatOuter, ((bool)(resources.GetObject("optFormatOuter.ShowHelp"))));
			this.optFormatOuter.Size = ((System.Drawing.Size)(resources.GetObject("optFormatOuter.Size")));
			this.optFormatOuter.TabIndex = ((int)(resources.GetObject("optFormatOuter.TabIndex")));
			this.optFormatOuter.Text = resources.GetString("optFormatOuter.Text");
			this.optFormatOuter.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optFormatOuter.TextAlign")));
			this.optFormatOuter.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optFormatOuter.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optFormatOuter, resources.GetString("optFormatOuter.ToolTip"));
			this.optFormatOuter.UseVisualStyleBackColor = true;
			this.optFormatOuter.CheckedChanged += new System.EventHandler(this.OptDirectionCheckedChanged);
			// 
			// optFormatInner
			// 
			this.optFormatInner.AccessibleDescription = null;
			this.optFormatInner.AccessibleName = null;
			this.optFormatInner.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optFormatInner.Anchor")));
			this.optFormatInner.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optFormatInner.Appearance")));
			this.optFormatInner.AutoSize = ((bool)(resources.GetObject("optFormatInner.AutoSize")));
			this.optFormatInner.BackgroundImage = null;
			this.optFormatInner.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optFormatInner.BackgroundImageLayout")));
			this.optFormatInner.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optFormatInner.CheckAlign")));
			this.optFormatInner.Checked = true;
			this.optFormatInner.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optFormatInner.Dock")));
			this.optFormatInner.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optFormatInner.FlatStyle")));
			this.optFormatInner.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optFormatInner, resources.GetString("optFormatInner.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optFormatInner, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optFormatInner.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optFormatInner, null);
			this.optFormatInner.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optFormatInner.ImageAlign")));
			this.optFormatInner.ImageIndex = ((int)(resources.GetObject("optFormatInner.ImageIndex")));
			this.optFormatInner.ImageKey = resources.GetString("optFormatInner.ImageKey");
			this.optFormatInner.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optFormatInner.ImeMode")));
			this.optFormatInner.Location = ((System.Drawing.Point)(resources.GetObject("optFormatInner.Location")));
			this.optFormatInner.Name = "optFormatInner";
			this.optFormatInner.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optFormatInner.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optFormatInner, ((bool)(resources.GetObject("optFormatInner.ShowHelp"))));
			this.optFormatInner.Size = ((System.Drawing.Size)(resources.GetObject("optFormatInner.Size")));
			this.optFormatInner.TabIndex = ((int)(resources.GetObject("optFormatInner.TabIndex")));
			this.optFormatInner.TabStop = true;
			this.optFormatInner.Text = resources.GetString("optFormatInner.Text");
			this.optFormatInner.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optFormatInner.TextAlign")));
			this.optFormatInner.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optFormatInner.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optFormatInner, resources.GetString("optFormatInner.ToolTip"));
			this.optFormatInner.UseVisualStyleBackColor = true;
			this.optFormatInner.CheckedChanged += new System.EventHandler(this.OptDirectionCheckedChanged);
			// 
			// picPreview
			// 
			this.picPreview.AccessibleDescription = null;
			this.picPreview.AccessibleName = null;
			this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("picPreview.Anchor")));
			this.picPreview.BackgroundImage = null;
			this.picPreview.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("picPreview.BackgroundImageLayout")));
			this.picPreview.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("picPreview.Dock")));
			this.picPreview.Font = null;
			this.hlpProvider.SetHelpKeyword(this.picPreview, null);
			this.hlpProvider.SetHelpNavigator(this.picPreview, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("picPreview.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.picPreview, null);
			this.picPreview.ImageLocation = null;
			this.picPreview.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("picPreview.ImeMode")));
			this.picPreview.Location = ((System.Drawing.Point)(resources.GetObject("picPreview.Location")));
			this.picPreview.Name = "picPreview";
			this.picPreview.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("picPreview.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.picPreview, ((bool)(resources.GetObject("picPreview.ShowHelp"))));
			this.picPreview.Size = ((System.Drawing.Size)(resources.GetObject("picPreview.Size")));
			this.picPreview.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("picPreview.SizeMode")));
			this.picPreview.TabIndex = ((int)(resources.GetObject("picPreview.TabIndex")));
			this.picPreview.TabStop = false;
			this.propToolTip.SetToolTip(this.picPreview, resources.GetString("picPreview.ToolTip"));
			this.picPreview.WaitOnLoad = ((bool)(resources.GetObject("picPreview.WaitOnLoad")));
			this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.PropertyImageRedraw);
			// 
			// groupBox31
			// 
			this.groupBox31.AccessibleDescription = null;
			this.groupBox31.AccessibleName = null;
			this.groupBox31.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox31.Anchor")));
			this.groupBox31.AutoSize = ((bool)(resources.GetObject("groupBox31.AutoSize")));
			this.groupBox31.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("groupBox31.AutoSizeMode")));
			this.groupBox31.BackgroundImage = null;
			this.groupBox31.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("groupBox31.BackgroundImageLayout")));
			this.groupBox31.Controls.Add(this.optDirectionL);
			this.groupBox31.Controls.Add(this.optDirectionR);
			this.groupBox31.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox31.Dock")));
			this.groupBox31.Font = null;
			this.hlpProvider.SetHelpKeyword(this.groupBox31, null);
			this.hlpProvider.SetHelpNavigator(this.groupBox31, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("groupBox31.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.groupBox31, null);
			this.groupBox31.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox31.ImeMode")));
			this.groupBox31.Location = ((System.Drawing.Point)(resources.GetObject("groupBox31.Location")));
			this.groupBox31.Name = "groupBox31";
			this.groupBox31.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox31.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.groupBox31, ((bool)(resources.GetObject("groupBox31.ShowHelp"))));
			this.groupBox31.Size = ((System.Drawing.Size)(resources.GetObject("groupBox31.Size")));
			this.groupBox31.TabIndex = ((int)(resources.GetObject("groupBox31.TabIndex")));
			this.groupBox31.TabStop = false;
			this.groupBox31.Text = resources.GetString("groupBox31.Text");
			this.propToolTip.SetToolTip(this.groupBox31, resources.GetString("groupBox31.ToolTip"));
			// 
			// optDirectionL
			// 
			this.optDirectionL.AccessibleDescription = null;
			this.optDirectionL.AccessibleName = null;
			this.optDirectionL.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optDirectionL.Anchor")));
			this.optDirectionL.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optDirectionL.Appearance")));
			this.optDirectionL.AutoSize = ((bool)(resources.GetObject("optDirectionL.AutoSize")));
			this.optDirectionL.BackgroundImage = null;
			this.optDirectionL.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optDirectionL.BackgroundImageLayout")));
			this.optDirectionL.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDirectionL.CheckAlign")));
			this.optDirectionL.Checked = true;
			this.optDirectionL.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optDirectionL.Dock")));
			this.optDirectionL.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optDirectionL.FlatStyle")));
			this.optDirectionL.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optDirectionL, resources.GetString("optDirectionL.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optDirectionL, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optDirectionL.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optDirectionL, null);
			this.optDirectionL.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDirectionL.ImageAlign")));
			this.optDirectionL.ImageIndex = ((int)(resources.GetObject("optDirectionL.ImageIndex")));
			this.optDirectionL.ImageKey = resources.GetString("optDirectionL.ImageKey");
			this.optDirectionL.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optDirectionL.ImeMode")));
			this.optDirectionL.Location = ((System.Drawing.Point)(resources.GetObject("optDirectionL.Location")));
			this.optDirectionL.Name = "optDirectionL";
			this.optDirectionL.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optDirectionL.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optDirectionL, ((bool)(resources.GetObject("optDirectionL.ShowHelp"))));
			this.optDirectionL.Size = ((System.Drawing.Size)(resources.GetObject("optDirectionL.Size")));
			this.optDirectionL.TabIndex = ((int)(resources.GetObject("optDirectionL.TabIndex")));
			this.optDirectionL.TabStop = true;
			this.optDirectionL.Text = resources.GetString("optDirectionL.Text");
			this.optDirectionL.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDirectionL.TextAlign")));
			this.optDirectionL.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optDirectionL.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optDirectionL, resources.GetString("optDirectionL.ToolTip"));
			this.optDirectionL.UseVisualStyleBackColor = true;
			this.optDirectionL.CheckedChanged += new System.EventHandler(this.OptDirectionCheckedChanged);
			// 
			// optDirectionR
			// 
			this.optDirectionR.AccessibleDescription = null;
			this.optDirectionR.AccessibleName = null;
			this.optDirectionR.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optDirectionR.Anchor")));
			this.optDirectionR.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optDirectionR.Appearance")));
			this.optDirectionR.AutoSize = ((bool)(resources.GetObject("optDirectionR.AutoSize")));
			this.optDirectionR.BackgroundImage = null;
			this.optDirectionR.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optDirectionR.BackgroundImageLayout")));
			this.optDirectionR.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDirectionR.CheckAlign")));
			this.optDirectionR.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optDirectionR.Dock")));
			this.optDirectionR.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optDirectionR.FlatStyle")));
			this.optDirectionR.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optDirectionR, resources.GetString("optDirectionR.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optDirectionR, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optDirectionR.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optDirectionR, null);
			this.optDirectionR.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDirectionR.ImageAlign")));
			this.optDirectionR.ImageIndex = ((int)(resources.GetObject("optDirectionR.ImageIndex")));
			this.optDirectionR.ImageKey = resources.GetString("optDirectionR.ImageKey");
			this.optDirectionR.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optDirectionR.ImeMode")));
			this.optDirectionR.Location = ((System.Drawing.Point)(resources.GetObject("optDirectionR.Location")));
			this.optDirectionR.Name = "optDirectionR";
			this.optDirectionR.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optDirectionR.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optDirectionR, ((bool)(resources.GetObject("optDirectionR.ShowHelp"))));
			this.optDirectionR.Size = ((System.Drawing.Size)(resources.GetObject("optDirectionR.Size")));
			this.optDirectionR.TabIndex = ((int)(resources.GetObject("optDirectionR.TabIndex")));
			this.optDirectionR.Text = resources.GetString("optDirectionR.Text");
			this.optDirectionR.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDirectionR.TextAlign")));
			this.optDirectionR.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optDirectionR.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optDirectionR, resources.GetString("optDirectionR.ToolTip"));
			this.optDirectionR.UseVisualStyleBackColor = true;
			this.optDirectionR.CheckedChanged += new System.EventHandler(this.OptDirectionCheckedChanged);
			// 
			// txtPropGate
			// 
			this.txtPropGate.AccessibleDescription = null;
			this.txtPropGate.AccessibleName = null;
			this.txtPropGate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtPropGate.Anchor")));
			this.txtPropGate.BackgroundImage = null;
			this.txtPropGate.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtPropGate.BackgroundImageLayout")));
			this.txtPropGate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtPropGate.Dock")));
			this.txtPropGate.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtPropGate, resources.GetString("txtPropGate.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtPropGate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtPropGate.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtPropGate, null);
			this.txtPropGate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtPropGate.ImeMode")));
			this.txtPropGate.Location = ((System.Drawing.Point)(resources.GetObject("txtPropGate.Location")));
			this.txtPropGate.MaxLength = ((int)(resources.GetObject("txtPropGate.MaxLength")));
			this.txtPropGate.Multiline = ((bool)(resources.GetObject("txtPropGate.Multiline")));
			this.txtPropGate.Name = "txtPropGate";
			this.txtPropGate.PasswordChar = ((char)(resources.GetObject("txtPropGate.PasswordChar")));
			this.txtPropGate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtPropGate.RightToLeft")));
			this.txtPropGate.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtPropGate.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtPropGate, ((bool)(resources.GetObject("txtPropGate.ShowHelp"))));
			this.txtPropGate.Size = ((System.Drawing.Size)(resources.GetObject("txtPropGate.Size")));
			this.txtPropGate.TabIndex = ((int)(resources.GetObject("txtPropGate.TabIndex")));
			this.txtPropGate.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtPropGate.TextAlign")));
			this.propToolTip.SetToolTip(this.txtPropGate, resources.GetString("txtPropGate.ToolTip"));
			this.txtPropGate.WordWrap = ((bool)(resources.GetObject("txtPropGate.WordWrap")));
			// 
			// label8
			// 
			this.label8.AccessibleDescription = null;
			this.label8.AccessibleName = null;
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label8.Anchor")));
			this.label8.AutoSize = ((bool)(resources.GetObject("label8.AutoSize")));
			this.label8.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label8.BackgroundImageLayout")));
			this.label8.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label8.Dock")));
			this.label8.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label8, null);
			this.hlpProvider.SetHelpNavigator(this.label8, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label8.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label8, null);
			this.label8.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label8.ImageAlign")));
			this.label8.ImageIndex = ((int)(resources.GetObject("label8.ImageIndex")));
			this.label8.ImageKey = resources.GetString("label8.ImageKey");
			this.label8.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label8.ImeMode")));
			this.label8.Location = ((System.Drawing.Point)(resources.GetObject("label8.Location")));
			this.label8.Name = "label8";
			this.label8.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label8.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
			this.label8.Size = ((System.Drawing.Size)(resources.GetObject("label8.Size")));
			this.label8.TabIndex = ((int)(resources.GetObject("label8.TabIndex")));
			this.label8.Text = resources.GetString("label8.Text");
			this.label8.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label8.TextAlign")));
			this.propToolTip.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
			// 
			// txtPropMeasure
			// 
			this.txtPropMeasure.AccessibleDescription = null;
			this.txtPropMeasure.AccessibleName = null;
			this.txtPropMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtPropMeasure.Anchor")));
			this.txtPropMeasure.BackgroundImage = null;
			this.txtPropMeasure.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("txtPropMeasure.BackgroundImageLayout")));
			this.txtPropMeasure.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtPropMeasure.Dock")));
			this.txtPropMeasure.Font = null;
			this.hlpProvider.SetHelpKeyword(this.txtPropMeasure, resources.GetString("txtPropMeasure.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.txtPropMeasure, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txtPropMeasure.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.txtPropMeasure, null);
			this.txtPropMeasure.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtPropMeasure.ImeMode")));
			this.txtPropMeasure.Location = ((System.Drawing.Point)(resources.GetObject("txtPropMeasure.Location")));
			this.txtPropMeasure.MaxLength = ((int)(resources.GetObject("txtPropMeasure.MaxLength")));
			this.txtPropMeasure.Multiline = ((bool)(resources.GetObject("txtPropMeasure.Multiline")));
			this.txtPropMeasure.Name = "txtPropMeasure";
			this.txtPropMeasure.PasswordChar = ((char)(resources.GetObject("txtPropMeasure.PasswordChar")));
			this.txtPropMeasure.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtPropMeasure.RightToLeft")));
			this.txtPropMeasure.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtPropMeasure.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtPropMeasure, ((bool)(resources.GetObject("txtPropMeasure.ShowHelp"))));
			this.txtPropMeasure.Size = ((System.Drawing.Size)(resources.GetObject("txtPropMeasure.Size")));
			this.txtPropMeasure.TabIndex = ((int)(resources.GetObject("txtPropMeasure.TabIndex")));
			this.txtPropMeasure.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtPropMeasure.TextAlign")));
			this.propToolTip.SetToolTip(this.txtPropMeasure, resources.GetString("txtPropMeasure.ToolTip"));
			this.txtPropMeasure.WordWrap = ((bool)(resources.GetObject("txtPropMeasure.WordWrap")));
			// 
			// label71
			// 
			this.label71.AccessibleDescription = null;
			this.label71.AccessibleName = null;
			this.label71.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label71.Anchor")));
			this.label71.AutoSize = ((bool)(resources.GetObject("label71.AutoSize")));
			this.label71.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label71.BackgroundImageLayout")));
			this.label71.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label71.Dock")));
			this.label71.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label71, null);
			this.hlpProvider.SetHelpNavigator(this.label71, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label71.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label71, null);
			this.label71.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label71.ImageAlign")));
			this.label71.ImageIndex = ((int)(resources.GetObject("label71.ImageIndex")));
			this.label71.ImageKey = resources.GetString("label71.ImageKey");
			this.label71.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label71.ImeMode")));
			this.label71.Location = ((System.Drawing.Point)(resources.GetObject("label71.Location")));
			this.label71.Name = "label71";
			this.label71.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label71.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label71, ((bool)(resources.GetObject("label71.ShowHelp"))));
			this.label71.Size = ((System.Drawing.Size)(resources.GetObject("label71.Size")));
			this.label71.TabIndex = ((int)(resources.GetObject("label71.TabIndex")));
			this.label71.Text = resources.GetString("label71.Text");
			this.label71.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label71.TextAlign")));
			this.propToolTip.SetToolTip(this.label71, resources.GetString("label71.ToolTip"));
			// 
			// MeasureStartProp
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
			this.hlpProvider.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this, null);
			//this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "MeasureStartProp";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.hlpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.propToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.tabPageWorksheet.ResumeLayout(false);
			this.tabPageWorksheet.PerformLayout();
			this.tabOptions.ResumeLayout(false);
			this.tabItem.ResumeLayout(false);
			this.tabItem.PerformLayout();
			this.groupBox21.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
			this.groupBox31.ResumeLayout(false);
			this.ResumeLayout(false);
		}
			//this.ClientSize = new System.Drawing.Size(base.ClientSize.Width, base.ClientSize.Height);
			//this.Location = new System.Drawing.Point(base.Location.X, base.Location.Y);
		private System.Windows.Forms.RadioButton optFormatInner;
		private System.Windows.Forms.RadioButton optFormatOuter;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtPropMeasure;
		private System.Windows.Forms.PictureBox picPreview;
		private System.Windows.Forms.GroupBox groupBox31;
		private System.Windows.Forms.TabPage tabItem;
		private System.Windows.Forms.RadioButton optDirectionL;
		private System.Windows.Forms.RadioButton optDirectionR;
		private System.Windows.Forms.GroupBox groupBox21;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPropGate;
		#endregion
		private System.Windows.Forms.Label label71;

		public override string PropText{
			get{
				int pos = mEditorText.IndexOf(',');
				if (pos==-1){
					pos = mEditorText.TrimEnd().Length;
					if (mEditorText.TrimEnd().EndsWith(";")) pos--;
					if (mEditorText.TrimEnd().EndsWith(";;")) pos--;
				}
				string command = mEditorText.Substring(0,pos).TrimEnd();
				command += ", \"" + this.GateText + "\",";
				command += " \"" + this.MeasureText + "\",";
				if(this.optDirectionL.Checked == true)
					command += "l";
				else if(this.optDirectionR.Checked == true)
					command += "r";
				if(this.optFormatInner.Checked == true)
					command += "";
				else if(this.optFormatOuter.Checked == true)
					command += ", *";
				if (mEditorText.EndsWith(";")) command +=";";
				if (mEditorText.EndsWith(";;")) command +=";";
				return command;				
			}
		}
		public string GateText{
			get{
				return DeformatText(this.txtPropGate.Text);
			}
			set{
				this.txtPropGate.Text = EnformatText(value);
			}
		}	
		public string MeasureText{
			get{
				return DeformatText(this.txtPropMeasure.Text);
			}
			set{
				this.txtPropMeasure.Text = EnformatText(value);
			}
		}	
		public MeasurePos MeasurePosition{
			get{
				if(this.optDirectionL.Checked == true)
					return MeasurePos.Left;
				else if(this.optDirectionR.Checked == true)
					return MeasurePos.Right;
				return MeasurePos.Left;				
			}
			set{
				if(value==MeasurePos.Left)
					this.optDirectionL.Checked = true;
				else if(value==MeasurePos.Right)
					this.optDirectionR.Checked = true;
			}
		}
		public CapStyle MeasureStyle{
			get{
				if(this.optFormatInner.Checked == true)
					return CapStyle.Inner;
				else if(this.optFormatOuter.Checked == true)
					return CapStyle.Outer;
				return CapStyle.Inner;				
			}
			set{
				if(value==CapStyle.Inner)
					this.optFormatInner.Checked = true;
				else if(value==CapStyle.Outer)
					this.optFormatOuter.Checked = true;
			}
		}
		private void DrawPropertyImage()
		{
			Graphics g = Graphics.FromImage(this.propertyImage);
			g.Clear(Property.previewBackColor);
			MeasureStart.RepertoryImage(g,this.MeasurePosition, this.MeasureStyle);
			g.Dispose();
			this.picPreview.Invalidate();
		}
		
		void OptDirectionCheckedChanged(object sender, System.EventArgs e)
		{
			DrawPropertyImage();
		}
		protected override void TabOptionsSelectedIndexChanged(object sender, EventArgs e)
		{
			base.TabOptionsSelectedIndexChanged(sender, e);
			if (this.tabOptions.SelectedIndex == 2){
				this.hlpProvider.SetHelpKeyword(this.tabOptions, "dlgMeasureStart");
				this.hlpProvider.SetHelpNavigator(this.tabOptions, HelpNavigator.KeywordIndex);
			}
		}
	}
}
