/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GeneratorGUI
{
	partial class OptionsDialog : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
			this.tabOptions = new System.Windows.Forms.TabControl();
			this.tabPageWorksheet = new System.Windows.Forms.TabPage();
			this.fraMargins = new System.Windows.Forms.GroupBox();
			this.lblBottomMargin = new System.Windows.Forms.Label();
			this.lblRightMargin = new System.Windows.Forms.Label();
			this.txtBottomMargin = new System.Windows.Forms.TextBox();
			this.txtRightMargin = new System.Windows.Forms.TextBox();
			this.lblTopMargin = new System.Windows.Forms.Label();
			this.txtTopMargin = new System.Windows.Forms.TextBox();
			this.txtLeftMargin = new System.Windows.Forms.TextBox();
			this.lblMarginLeft = new System.Windows.Forms.Label();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.cboUnits = new System.Windows.Forms.ComboBox();
			this.lblUnit = new System.Windows.Forms.Label();
			this.fraPreview = new System.Windows.Forms.GroupBox();
			this.pnlPreviewBack = new System.Windows.Forms.Panel();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.fraLayout = new System.Windows.Forms.GroupBox();
			this.optLayoutV = new System.Windows.Forms.RadioButton();
			this.optLayoutH = new System.Windows.Forms.RadioButton();
			this.lblHeight = new System.Windows.Forms.Label();
			this.lblWidth = new System.Windows.Forms.Label();
			this.cboPictureSize = new System.Windows.Forms.ComboBox();
			this.lblPictureSize = new System.Windows.Forms.Label();
			this.tabProperties = new System.Windows.Forms.TabPage();
			this.fraFootline = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkShowFootline = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chkFile = new System.Windows.Forms.CheckBox();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.chkToday = new System.Windows.Forms.CheckBox();
			this.txtToday = new System.Windows.Forms.TextBox();
			this.chkDate = new System.Windows.Forms.CheckBox();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.chkVersion = new System.Windows.Forms.CheckBox();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.chkCompany = new System.Windows.Forms.CheckBox();
			this.txtCompany = new System.Windows.Forms.TextBox();
			this.chkAuthor = new System.Windows.Forms.CheckBox();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAccept = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.hlpProvider = new System.Windows.Forms.HelpProvider();
			this.propToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tabOptions.SuspendLayout();
			this.tabPageWorksheet.SuspendLayout();
			this.fraMargins.SuspendLayout();
			this.fraPreview.SuspendLayout();
			this.pnlPreviewBack.SuspendLayout();
			this.fraLayout.SuspendLayout();
			this.tabProperties.SuspendLayout();
			this.fraFootline.SuspendLayout();
			this.SuspendLayout();
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
			this.tabOptions.Controls.Add(this.tabPageWorksheet);
			this.tabOptions.Controls.Add(this.tabProperties);
			this.tabOptions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabOptions.Dock")));
			this.tabOptions.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabOptions, resources.GetString("tabOptions.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.tabOptions, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabOptions.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabOptions, null);
			this.tabOptions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabOptions.ImeMode")));
			this.tabOptions.Location = ((System.Drawing.Point)(resources.GetObject("tabOptions.Location")));
			this.tabOptions.MaximumSize = new System.Drawing.Size(291, 873);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabOptions.RightToLeft")));
			this.tabOptions.RightToLeftLayout = ((bool)(resources.GetObject("tabOptions.RightToLeftLayout")));
			this.tabOptions.SelectedIndex = 0;
			this.hlpProvider.SetShowHelp(this.tabOptions, ((bool)(resources.GetObject("tabOptions.ShowHelp"))));
			this.tabOptions.ShowToolTips = ((bool)(resources.GetObject("tabOptions.ShowToolTips")));
			this.tabOptions.Size = ((System.Drawing.Size)(resources.GetObject("tabOptions.Size")));
			this.tabOptions.TabIndex = ((int)(resources.GetObject("tabOptions.TabIndex")));
			this.propToolTip.SetToolTip(this.tabOptions, resources.GetString("tabOptions.ToolTip"));
			// 
			// tabPageWorksheet
			// 
			this.tabPageWorksheet.AccessibleDescription = null;
			this.tabPageWorksheet.AccessibleName = null;
			this.tabPageWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabPageWorksheet.Anchor")));
			this.tabPageWorksheet.AutoScroll = ((bool)(resources.GetObject("tabPageWorksheet.AutoScroll")));
			this.tabPageWorksheet.BackColor = System.Drawing.Color.Transparent;
			this.tabPageWorksheet.BackgroundImage = null;
			this.tabPageWorksheet.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabPageWorksheet.BackgroundImageLayout")));
			this.tabPageWorksheet.Controls.Add(this.fraMargins);
			this.tabPageWorksheet.Controls.Add(this.txtHeight);
			this.tabPageWorksheet.Controls.Add(this.txtWidth);
			this.tabPageWorksheet.Controls.Add(this.cboUnits);
			this.tabPageWorksheet.Controls.Add(this.lblUnit);
			this.tabPageWorksheet.Controls.Add(this.fraPreview);
			this.tabPageWorksheet.Controls.Add(this.fraLayout);
			this.tabPageWorksheet.Controls.Add(this.lblHeight);
			this.tabPageWorksheet.Controls.Add(this.lblWidth);
			this.tabPageWorksheet.Controls.Add(this.cboPictureSize);
			this.tabPageWorksheet.Controls.Add(this.lblPictureSize);
			this.tabPageWorksheet.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabPageWorksheet.Dock")));
			this.tabPageWorksheet.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabPageWorksheet, null);
			this.hlpProvider.SetHelpNavigator(this.tabPageWorksheet, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPageWorksheet.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabPageWorksheet, null);
			this.tabPageWorksheet.ImageIndex = ((int)(resources.GetObject("tabPageWorksheet.ImageIndex")));
			this.tabPageWorksheet.ImageKey = resources.GetString("tabPageWorksheet.ImageKey");
			this.tabPageWorksheet.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabPageWorksheet.ImeMode")));
			this.tabPageWorksheet.Location = ((System.Drawing.Point)(resources.GetObject("tabPageWorksheet.Location")));
			this.tabPageWorksheet.Name = "tabPageWorksheet";
			this.tabPageWorksheet.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabPageWorksheet.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.tabPageWorksheet, ((bool)(resources.GetObject("tabPageWorksheet.ShowHelp"))));
			this.tabPageWorksheet.Size = ((System.Drawing.Size)(resources.GetObject("tabPageWorksheet.Size")));
			this.tabPageWorksheet.TabIndex = ((int)(resources.GetObject("tabPageWorksheet.TabIndex")));
			this.tabPageWorksheet.Text = resources.GetString("tabPageWorksheet.Text");
			this.propToolTip.SetToolTip(this.tabPageWorksheet, resources.GetString("tabPageWorksheet.ToolTip"));
			this.tabPageWorksheet.ToolTipText = resources.GetString("tabPageWorksheet.ToolTipText");
			this.tabPageWorksheet.UseVisualStyleBackColor = true;
			// 
			// fraMargins
			// 
			this.fraMargins.AccessibleDescription = null;
			this.fraMargins.AccessibleName = null;
			this.fraMargins.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("fraMargins.Anchor")));
			this.fraMargins.AutoSize = ((bool)(resources.GetObject("fraMargins.AutoSize")));
			this.fraMargins.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("fraMargins.AutoSizeMode")));
			this.fraMargins.BackgroundImage = null;
			this.fraMargins.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("fraMargins.BackgroundImageLayout")));
			this.fraMargins.Controls.Add(this.lblBottomMargin);
			this.fraMargins.Controls.Add(this.lblRightMargin);
			this.fraMargins.Controls.Add(this.txtBottomMargin);
			this.fraMargins.Controls.Add(this.txtRightMargin);
			this.fraMargins.Controls.Add(this.lblTopMargin);
			this.fraMargins.Controls.Add(this.txtTopMargin);
			this.fraMargins.Controls.Add(this.txtLeftMargin);
			this.fraMargins.Controls.Add(this.lblMarginLeft);
			this.fraMargins.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("fraMargins.Dock")));
			this.fraMargins.Font = null;
			this.hlpProvider.SetHelpKeyword(this.fraMargins, null);
			this.hlpProvider.SetHelpNavigator(this.fraMargins, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fraMargins.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.fraMargins, null);
			this.fraMargins.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("fraMargins.ImeMode")));
			this.fraMargins.Location = ((System.Drawing.Point)(resources.GetObject("fraMargins.Location")));
			this.fraMargins.Name = "fraMargins";
			this.fraMargins.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("fraMargins.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.fraMargins, ((bool)(resources.GetObject("fraMargins.ShowHelp"))));
			this.fraMargins.Size = ((System.Drawing.Size)(resources.GetObject("fraMargins.Size")));
			this.fraMargins.TabIndex = ((int)(resources.GetObject("fraMargins.TabIndex")));
			this.fraMargins.TabStop = false;
			this.fraMargins.Text = resources.GetString("fraMargins.Text");
			this.propToolTip.SetToolTip(this.fraMargins, resources.GetString("fraMargins.ToolTip"));
			// 
			// lblBottomMargin
			// 
			this.lblBottomMargin.AccessibleDescription = null;
			this.lblBottomMargin.AccessibleName = null;
			this.lblBottomMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblBottomMargin.Anchor")));
			this.lblBottomMargin.AutoSize = ((bool)(resources.GetObject("lblBottomMargin.AutoSize")));
			this.lblBottomMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblBottomMargin.BackgroundImageLayout")));
			this.lblBottomMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblBottomMargin.Dock")));
			this.lblBottomMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblBottomMargin, null);
			this.hlpProvider.SetHelpNavigator(this.lblBottomMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblBottomMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblBottomMargin, null);
			this.lblBottomMargin.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblBottomMargin.ImageAlign")));
			this.lblBottomMargin.ImageIndex = ((int)(resources.GetObject("lblBottomMargin.ImageIndex")));
			this.lblBottomMargin.ImageKey = resources.GetString("lblBottomMargin.ImageKey");
			this.lblBottomMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblBottomMargin.ImeMode")));
			this.lblBottomMargin.Location = ((System.Drawing.Point)(resources.GetObject("lblBottomMargin.Location")));
			this.lblBottomMargin.Name = "lblBottomMargin";
			this.lblBottomMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblBottomMargin.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblBottomMargin, ((bool)(resources.GetObject("lblBottomMargin.ShowHelp"))));
			this.lblBottomMargin.Size = ((System.Drawing.Size)(resources.GetObject("lblBottomMargin.Size")));
			this.lblBottomMargin.TabIndex = ((int)(resources.GetObject("lblBottomMargin.TabIndex")));
			this.lblBottomMargin.Text = resources.GetString("lblBottomMargin.Text");
			this.lblBottomMargin.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblBottomMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.lblBottomMargin, resources.GetString("lblBottomMargin.ToolTip"));
			// 
			// lblRightMargin
			// 
			this.lblRightMargin.AccessibleDescription = null;
			this.lblRightMargin.AccessibleName = null;
			this.lblRightMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblRightMargin.Anchor")));
			this.lblRightMargin.AutoSize = ((bool)(resources.GetObject("lblRightMargin.AutoSize")));
			this.lblRightMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblRightMargin.BackgroundImageLayout")));
			this.lblRightMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblRightMargin.Dock")));
			this.lblRightMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblRightMargin, null);
			this.hlpProvider.SetHelpNavigator(this.lblRightMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblRightMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblRightMargin, null);
			this.lblRightMargin.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblRightMargin.ImageAlign")));
			this.lblRightMargin.ImageIndex = ((int)(resources.GetObject("lblRightMargin.ImageIndex")));
			this.lblRightMargin.ImageKey = resources.GetString("lblRightMargin.ImageKey");
			this.lblRightMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblRightMargin.ImeMode")));
			this.lblRightMargin.Location = ((System.Drawing.Point)(resources.GetObject("lblRightMargin.Location")));
			this.lblRightMargin.Name = "lblRightMargin";
			this.lblRightMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblRightMargin.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblRightMargin, ((bool)(resources.GetObject("lblRightMargin.ShowHelp"))));
			this.lblRightMargin.Size = ((System.Drawing.Size)(resources.GetObject("lblRightMargin.Size")));
			this.lblRightMargin.TabIndex = ((int)(resources.GetObject("lblRightMargin.TabIndex")));
			this.lblRightMargin.Text = resources.GetString("lblRightMargin.Text");
			this.lblRightMargin.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblRightMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.lblRightMargin, resources.GetString("lblRightMargin.ToolTip"));
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
			this.txtBottomMargin.Name = "txtBottomMargin";
			this.txtBottomMargin.PasswordChar = ((char)(resources.GetObject("txtBottomMargin.PasswordChar")));
			this.txtBottomMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtBottomMargin.RightToLeft")));
			this.txtBottomMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtBottomMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtBottomMargin, ((bool)(resources.GetObject("txtBottomMargin.ShowHelp"))));
			this.txtBottomMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtBottomMargin.Size")));
			this.txtBottomMargin.TabIndex = ((int)(resources.GetObject("txtBottomMargin.TabIndex")));
			this.txtBottomMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtBottomMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtBottomMargin, resources.GetString("txtBottomMargin.ToolTip"));
			this.txtBottomMargin.WordWrap = ((bool)(resources.GetObject("txtBottomMargin.WordWrap")));
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
			this.txtRightMargin.Name = "txtRightMargin";
			this.txtRightMargin.PasswordChar = ((char)(resources.GetObject("txtRightMargin.PasswordChar")));
			this.txtRightMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtRightMargin.RightToLeft")));
			this.txtRightMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtRightMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtRightMargin, ((bool)(resources.GetObject("txtRightMargin.ShowHelp"))));
			this.txtRightMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtRightMargin.Size")));
			this.txtRightMargin.TabIndex = ((int)(resources.GetObject("txtRightMargin.TabIndex")));
			this.txtRightMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtRightMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtRightMargin, resources.GetString("txtRightMargin.ToolTip"));
			this.txtRightMargin.WordWrap = ((bool)(resources.GetObject("txtRightMargin.WordWrap")));
			// 
			// lblTopMargin
			// 
			this.lblTopMargin.AccessibleDescription = null;
			this.lblTopMargin.AccessibleName = null;
			this.lblTopMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTopMargin.Anchor")));
			this.lblTopMargin.AutoSize = ((bool)(resources.GetObject("lblTopMargin.AutoSize")));
			this.lblTopMargin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblTopMargin.BackgroundImageLayout")));
			this.lblTopMargin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTopMargin.Dock")));
			this.lblTopMargin.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblTopMargin, null);
			this.hlpProvider.SetHelpNavigator(this.lblTopMargin, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblTopMargin.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblTopMargin, null);
			this.lblTopMargin.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTopMargin.ImageAlign")));
			this.lblTopMargin.ImageIndex = ((int)(resources.GetObject("lblTopMargin.ImageIndex")));
			this.lblTopMargin.ImageKey = resources.GetString("lblTopMargin.ImageKey");
			this.lblTopMargin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTopMargin.ImeMode")));
			this.lblTopMargin.Location = ((System.Drawing.Point)(resources.GetObject("lblTopMargin.Location")));
			this.lblTopMargin.Name = "lblTopMargin";
			this.lblTopMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTopMargin.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblTopMargin, ((bool)(resources.GetObject("lblTopMargin.ShowHelp"))));
			this.lblTopMargin.Size = ((System.Drawing.Size)(resources.GetObject("lblTopMargin.Size")));
			this.lblTopMargin.TabIndex = ((int)(resources.GetObject("lblTopMargin.TabIndex")));
			this.lblTopMargin.Text = resources.GetString("lblTopMargin.Text");
			this.lblTopMargin.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTopMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.lblTopMargin, resources.GetString("lblTopMargin.ToolTip"));
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
			this.txtTopMargin.Name = "txtTopMargin";
			this.txtTopMargin.PasswordChar = ((char)(resources.GetObject("txtTopMargin.PasswordChar")));
			this.txtTopMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtTopMargin.RightToLeft")));
			this.txtTopMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtTopMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtTopMargin, ((bool)(resources.GetObject("txtTopMargin.ShowHelp"))));
			this.txtTopMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtTopMargin.Size")));
			this.txtTopMargin.TabIndex = ((int)(resources.GetObject("txtTopMargin.TabIndex")));
			this.txtTopMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtTopMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtTopMargin, resources.GetString("txtTopMargin.ToolTip"));
			this.txtTopMargin.WordWrap = ((bool)(resources.GetObject("txtTopMargin.WordWrap")));
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
			this.txtLeftMargin.Name = "txtLeftMargin";
			this.txtLeftMargin.PasswordChar = ((char)(resources.GetObject("txtLeftMargin.PasswordChar")));
			this.txtLeftMargin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtLeftMargin.RightToLeft")));
			this.txtLeftMargin.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtLeftMargin.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtLeftMargin, ((bool)(resources.GetObject("txtLeftMargin.ShowHelp"))));
			this.txtLeftMargin.Size = ((System.Drawing.Size)(resources.GetObject("txtLeftMargin.Size")));
			this.txtLeftMargin.TabIndex = ((int)(resources.GetObject("txtLeftMargin.TabIndex")));
			this.txtLeftMargin.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtLeftMargin.TextAlign")));
			this.propToolTip.SetToolTip(this.txtLeftMargin, resources.GetString("txtLeftMargin.ToolTip"));
			this.txtLeftMargin.WordWrap = ((bool)(resources.GetObject("txtLeftMargin.WordWrap")));
			// 
			// lblMarginLeft
			// 
			this.lblMarginLeft.AccessibleDescription = null;
			this.lblMarginLeft.AccessibleName = null;
			this.lblMarginLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblMarginLeft.Anchor")));
			this.lblMarginLeft.AutoSize = ((bool)(resources.GetObject("lblMarginLeft.AutoSize")));
			this.lblMarginLeft.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblMarginLeft.BackgroundImageLayout")));
			this.lblMarginLeft.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblMarginLeft.Dock")));
			this.lblMarginLeft.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblMarginLeft, null);
			this.hlpProvider.SetHelpNavigator(this.lblMarginLeft, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblMarginLeft.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblMarginLeft, null);
			this.lblMarginLeft.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMarginLeft.ImageAlign")));
			this.lblMarginLeft.ImageIndex = ((int)(resources.GetObject("lblMarginLeft.ImageIndex")));
			this.lblMarginLeft.ImageKey = resources.GetString("lblMarginLeft.ImageKey");
			this.lblMarginLeft.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblMarginLeft.ImeMode")));
			this.lblMarginLeft.Location = ((System.Drawing.Point)(resources.GetObject("lblMarginLeft.Location")));
			this.lblMarginLeft.Name = "lblMarginLeft";
			this.lblMarginLeft.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblMarginLeft.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblMarginLeft, ((bool)(resources.GetObject("lblMarginLeft.ShowHelp"))));
			this.lblMarginLeft.Size = ((System.Drawing.Size)(resources.GetObject("lblMarginLeft.Size")));
			this.lblMarginLeft.TabIndex = ((int)(resources.GetObject("lblMarginLeft.TabIndex")));
			this.lblMarginLeft.Text = resources.GetString("lblMarginLeft.Text");
			this.lblMarginLeft.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMarginLeft.TextAlign")));
			this.propToolTip.SetToolTip(this.lblMarginLeft, resources.GetString("lblMarginLeft.ToolTip"));
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
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.PasswordChar = ((char)(resources.GetObject("txtHeight.PasswordChar")));
			this.txtHeight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtHeight.RightToLeft")));
			this.txtHeight.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtHeight.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtHeight, ((bool)(resources.GetObject("txtHeight.ShowHelp"))));
			this.txtHeight.Size = ((System.Drawing.Size)(resources.GetObject("txtHeight.Size")));
			this.txtHeight.TabIndex = ((int)(resources.GetObject("txtHeight.TabIndex")));
			this.txtHeight.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtHeight.TextAlign")));
			this.propToolTip.SetToolTip(this.txtHeight, resources.GetString("txtHeight.ToolTip"));
			this.txtHeight.WordWrap = ((bool)(resources.GetObject("txtHeight.WordWrap")));
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
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.PasswordChar = ((char)(resources.GetObject("txtWidth.PasswordChar")));
			this.txtWidth.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtWidth.RightToLeft")));
			this.txtWidth.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtWidth.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtWidth, ((bool)(resources.GetObject("txtWidth.ShowHelp"))));
			this.txtWidth.Size = ((System.Drawing.Size)(resources.GetObject("txtWidth.Size")));
			this.txtWidth.TabIndex = ((int)(resources.GetObject("txtWidth.TabIndex")));
			this.txtWidth.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtWidth.TextAlign")));
			this.propToolTip.SetToolTip(this.txtWidth, resources.GetString("txtWidth.ToolTip"));
			this.txtWidth.WordWrap = ((bool)(resources.GetObject("txtWidth.WordWrap")));
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
			this.cboUnits.Name = "cboUnits";
			this.cboUnits.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboUnits.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cboUnits, ((bool)(resources.GetObject("cboUnits.ShowHelp"))));
			this.cboUnits.Size = ((System.Drawing.Size)(resources.GetObject("cboUnits.Size")));
			this.cboUnits.TabIndex = ((int)(resources.GetObject("cboUnits.TabIndex")));
			this.propToolTip.SetToolTip(this.cboUnits, resources.GetString("cboUnits.ToolTip"));
			this.cboUnits.SelectedIndexChanged += new System.EventHandler(this.CboUnits_SelectedIndexChanged);
			// 
			// lblUnit
			// 
			this.lblUnit.AccessibleDescription = null;
			this.lblUnit.AccessibleName = null;
			this.lblUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblUnit.Anchor")));
			this.lblUnit.AutoSize = ((bool)(resources.GetObject("lblUnit.AutoSize")));
			this.lblUnit.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblUnit.BackgroundImageLayout")));
			this.lblUnit.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblUnit.Dock")));
			this.lblUnit.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblUnit, null);
			this.hlpProvider.SetHelpNavigator(this.lblUnit, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblUnit.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblUnit, null);
			this.lblUnit.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblUnit.ImageAlign")));
			this.lblUnit.ImageIndex = ((int)(resources.GetObject("lblUnit.ImageIndex")));
			this.lblUnit.ImageKey = resources.GetString("lblUnit.ImageKey");
			this.lblUnit.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblUnit.ImeMode")));
			this.lblUnit.Location = ((System.Drawing.Point)(resources.GetObject("lblUnit.Location")));
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblUnit.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblUnit, ((bool)(resources.GetObject("lblUnit.ShowHelp"))));
			this.lblUnit.Size = ((System.Drawing.Size)(resources.GetObject("lblUnit.Size")));
			this.lblUnit.TabIndex = ((int)(resources.GetObject("lblUnit.TabIndex")));
			this.lblUnit.Text = resources.GetString("lblUnit.Text");
			this.lblUnit.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblUnit.TextAlign")));
			this.propToolTip.SetToolTip(this.lblUnit, resources.GetString("lblUnit.ToolTip"));
			// 
			// fraPreview
			// 
			this.fraPreview.AccessibleDescription = null;
			this.fraPreview.AccessibleName = null;
			this.fraPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("fraPreview.Anchor")));
			this.fraPreview.AutoSize = ((bool)(resources.GetObject("fraPreview.AutoSize")));
			this.fraPreview.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("fraPreview.AutoSizeMode")));
			this.fraPreview.BackgroundImage = null;
			this.fraPreview.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("fraPreview.BackgroundImageLayout")));
			this.fraPreview.Controls.Add(this.pnlPreviewBack);
			this.fraPreview.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("fraPreview.Dock")));
			this.fraPreview.Font = null;
			this.hlpProvider.SetHelpKeyword(this.fraPreview, null);
			this.hlpProvider.SetHelpNavigator(this.fraPreview, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fraPreview.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.fraPreview, null);
			this.fraPreview.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("fraPreview.ImeMode")));
			this.fraPreview.Location = ((System.Drawing.Point)(resources.GetObject("fraPreview.Location")));
			this.fraPreview.Name = "fraPreview";
			this.fraPreview.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("fraPreview.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.fraPreview, ((bool)(resources.GetObject("fraPreview.ShowHelp"))));
			this.fraPreview.Size = ((System.Drawing.Size)(resources.GetObject("fraPreview.Size")));
			this.fraPreview.TabIndex = ((int)(resources.GetObject("fraPreview.TabIndex")));
			this.fraPreview.TabStop = false;
			this.fraPreview.Text = resources.GetString("fraPreview.Text");
			this.propToolTip.SetToolTip(this.fraPreview, resources.GetString("fraPreview.ToolTip"));
			// 
			// pnlPreviewBack
			// 
			this.pnlPreviewBack.AccessibleDescription = null;
			this.pnlPreviewBack.AccessibleName = null;
			this.pnlPreviewBack.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pnlPreviewBack.Anchor")));
			this.pnlPreviewBack.AutoScroll = ((bool)(resources.GetObject("pnlPreviewBack.AutoScroll")));
			this.pnlPreviewBack.AutoSize = ((bool)(resources.GetObject("pnlPreviewBack.AutoSize")));
			this.pnlPreviewBack.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("pnlPreviewBack.AutoSizeMode")));
			this.pnlPreviewBack.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlPreviewBack.BackgroundImage = null;
			this.pnlPreviewBack.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pnlPreviewBack.BackgroundImageLayout")));
			this.pnlPreviewBack.Controls.Add(this.pnlPreview);
			this.pnlPreviewBack.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pnlPreviewBack.Dock")));
			this.pnlPreviewBack.Font = null;
			this.hlpProvider.SetHelpKeyword(this.pnlPreviewBack, null);
			this.hlpProvider.SetHelpNavigator(this.pnlPreviewBack, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("pnlPreviewBack.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.pnlPreviewBack, null);
			this.pnlPreviewBack.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pnlPreviewBack.ImeMode")));
			this.pnlPreviewBack.Location = ((System.Drawing.Point)(resources.GetObject("pnlPreviewBack.Location")));
			this.pnlPreviewBack.Name = "pnlPreviewBack";
			this.pnlPreviewBack.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pnlPreviewBack.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.pnlPreviewBack, ((bool)(resources.GetObject("pnlPreviewBack.ShowHelp"))));
			this.pnlPreviewBack.Size = ((System.Drawing.Size)(resources.GetObject("pnlPreviewBack.Size")));
			this.pnlPreviewBack.TabIndex = ((int)(resources.GetObject("pnlPreviewBack.TabIndex")));
			this.propToolTip.SetToolTip(this.pnlPreviewBack, resources.GetString("pnlPreviewBack.ToolTip"));
			// 
			// pnlPreview
			// 
			this.pnlPreview.AccessibleDescription = null;
			this.pnlPreview.AccessibleName = null;
			this.pnlPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pnlPreview.Anchor")));
			this.pnlPreview.AutoScroll = ((bool)(resources.GetObject("pnlPreview.AutoScroll")));
			this.pnlPreview.AutoSize = ((bool)(resources.GetObject("pnlPreview.AutoSize")));
			this.pnlPreview.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("pnlPreview.AutoSizeMode")));
			this.pnlPreview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pnlPreview.BackgroundImage = null;
			this.pnlPreview.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pnlPreview.BackgroundImageLayout")));
			this.pnlPreview.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pnlPreview.Dock")));
			this.pnlPreview.Font = null;
			this.hlpProvider.SetHelpKeyword(this.pnlPreview, null);
			this.hlpProvider.SetHelpNavigator(this.pnlPreview, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("pnlPreview.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.pnlPreview, null);
			this.pnlPreview.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pnlPreview.ImeMode")));
			this.pnlPreview.Location = ((System.Drawing.Point)(resources.GetObject("pnlPreview.Location")));
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pnlPreview.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.pnlPreview, ((bool)(resources.GetObject("pnlPreview.ShowHelp"))));
			this.pnlPreview.Size = ((System.Drawing.Size)(resources.GetObject("pnlPreview.Size")));
			this.pnlPreview.TabIndex = ((int)(resources.GetObject("pnlPreview.TabIndex")));
			this.propToolTip.SetToolTip(this.pnlPreview, resources.GetString("pnlPreview.ToolTip"));
			// 
			// fraLayout
			// 
			this.fraLayout.AccessibleDescription = null;
			this.fraLayout.AccessibleName = null;
			this.fraLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("fraLayout.Anchor")));
			this.fraLayout.AutoSize = ((bool)(resources.GetObject("fraLayout.AutoSize")));
			this.fraLayout.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("fraLayout.AutoSizeMode")));
			this.fraLayout.BackgroundImage = null;
			this.fraLayout.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("fraLayout.BackgroundImageLayout")));
			this.fraLayout.Controls.Add(this.optLayoutV);
			this.fraLayout.Controls.Add(this.optLayoutH);
			this.fraLayout.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("fraLayout.Dock")));
			this.fraLayout.Font = null;
			this.hlpProvider.SetHelpKeyword(this.fraLayout, null);
			this.hlpProvider.SetHelpNavigator(this.fraLayout, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fraLayout.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.fraLayout, null);
			this.fraLayout.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("fraLayout.ImeMode")));
			this.fraLayout.Location = ((System.Drawing.Point)(resources.GetObject("fraLayout.Location")));
			this.fraLayout.Name = "fraLayout";
			this.fraLayout.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("fraLayout.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.fraLayout, ((bool)(resources.GetObject("fraLayout.ShowHelp"))));
			this.fraLayout.Size = ((System.Drawing.Size)(resources.GetObject("fraLayout.Size")));
			this.fraLayout.TabIndex = ((int)(resources.GetObject("fraLayout.TabIndex")));
			this.fraLayout.TabStop = false;
			this.fraLayout.Text = resources.GetString("fraLayout.Text");
			this.propToolTip.SetToolTip(this.fraLayout, resources.GetString("fraLayout.ToolTip"));
			// 
			// optLayoutV
			// 
			this.optLayoutV.AccessibleDescription = null;
			this.optLayoutV.AccessibleName = null;
			this.optLayoutV.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optLayoutV.Anchor")));
			this.optLayoutV.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optLayoutV.Appearance")));
			this.optLayoutV.AutoSize = ((bool)(resources.GetObject("optLayoutV.AutoSize")));
			this.optLayoutV.BackgroundImage = null;
			this.optLayoutV.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optLayoutV.BackgroundImageLayout")));
			this.optLayoutV.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optLayoutV.CheckAlign")));
			this.optLayoutV.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optLayoutV.Dock")));
			this.optLayoutV.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optLayoutV.FlatStyle")));
			this.optLayoutV.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optLayoutV, resources.GetString("optLayoutV.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optLayoutV, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optLayoutV.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optLayoutV, null);
			this.optLayoutV.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optLayoutV.ImageAlign")));
			this.optLayoutV.ImageIndex = ((int)(resources.GetObject("optLayoutV.ImageIndex")));
			this.optLayoutV.ImageKey = resources.GetString("optLayoutV.ImageKey");
			this.optLayoutV.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optLayoutV.ImeMode")));
			this.optLayoutV.Location = ((System.Drawing.Point)(resources.GetObject("optLayoutV.Location")));
			this.optLayoutV.Name = "optLayoutV";
			this.optLayoutV.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optLayoutV.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optLayoutV, ((bool)(resources.GetObject("optLayoutV.ShowHelp"))));
			this.optLayoutV.Size = ((System.Drawing.Size)(resources.GetObject("optLayoutV.Size")));
			this.optLayoutV.TabIndex = ((int)(resources.GetObject("optLayoutV.TabIndex")));
			this.optLayoutV.Text = resources.GetString("optLayoutV.Text");
			this.optLayoutV.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optLayoutV.TextAlign")));
			this.optLayoutV.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optLayoutV.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optLayoutV, resources.GetString("optLayoutV.ToolTip"));
			// 
			// optLayoutH
			// 
			this.optLayoutH.AccessibleDescription = null;
			this.optLayoutH.AccessibleName = null;
			this.optLayoutH.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optLayoutH.Anchor")));
			this.optLayoutH.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optLayoutH.Appearance")));
			this.optLayoutH.AutoSize = ((bool)(resources.GetObject("optLayoutH.AutoSize")));
			this.optLayoutH.BackgroundImage = null;
			this.optLayoutH.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("optLayoutH.BackgroundImageLayout")));
			this.optLayoutH.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optLayoutH.CheckAlign")));
			this.optLayoutH.Checked = true;
			this.optLayoutH.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optLayoutH.Dock")));
			this.optLayoutH.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optLayoutH.FlatStyle")));
			this.optLayoutH.Font = null;
			this.hlpProvider.SetHelpKeyword(this.optLayoutH, resources.GetString("optLayoutH.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.optLayoutH, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("optLayoutH.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.optLayoutH, null);
			this.optLayoutH.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optLayoutH.ImageAlign")));
			this.optLayoutH.ImageIndex = ((int)(resources.GetObject("optLayoutH.ImageIndex")));
			this.optLayoutH.ImageKey = resources.GetString("optLayoutH.ImageKey");
			this.optLayoutH.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optLayoutH.ImeMode")));
			this.optLayoutH.Location = ((System.Drawing.Point)(resources.GetObject("optLayoutH.Location")));
			this.optLayoutH.Name = "optLayoutH";
			this.optLayoutH.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optLayoutH.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.optLayoutH, ((bool)(resources.GetObject("optLayoutH.ShowHelp"))));
			this.optLayoutH.Size = ((System.Drawing.Size)(resources.GetObject("optLayoutH.Size")));
			this.optLayoutH.TabIndex = ((int)(resources.GetObject("optLayoutH.TabIndex")));
			this.optLayoutH.TabStop = true;
			this.optLayoutH.Text = resources.GetString("optLayoutH.Text");
			this.optLayoutH.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optLayoutH.TextAlign")));
			this.optLayoutH.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("optLayoutH.TextImageRelation")));
			this.propToolTip.SetToolTip(this.optLayoutH, resources.GetString("optLayoutH.ToolTip"));
			// 
			// lblHeight
			// 
			this.lblHeight.AccessibleDescription = null;
			this.lblHeight.AccessibleName = null;
			this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblHeight.Anchor")));
			this.lblHeight.AutoSize = ((bool)(resources.GetObject("lblHeight.AutoSize")));
			this.lblHeight.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblHeight.BackgroundImageLayout")));
			this.lblHeight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblHeight.Dock")));
			this.lblHeight.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblHeight, null);
			this.hlpProvider.SetHelpNavigator(this.lblHeight, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblHeight.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblHeight, null);
			this.lblHeight.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblHeight.ImageAlign")));
			this.lblHeight.ImageIndex = ((int)(resources.GetObject("lblHeight.ImageIndex")));
			this.lblHeight.ImageKey = resources.GetString("lblHeight.ImageKey");
			this.lblHeight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblHeight.ImeMode")));
			this.lblHeight.Location = ((System.Drawing.Point)(resources.GetObject("lblHeight.Location")));
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblHeight.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblHeight, ((bool)(resources.GetObject("lblHeight.ShowHelp"))));
			this.lblHeight.Size = ((System.Drawing.Size)(resources.GetObject("lblHeight.Size")));
			this.lblHeight.TabIndex = ((int)(resources.GetObject("lblHeight.TabIndex")));
			this.lblHeight.Text = resources.GetString("lblHeight.Text");
			this.lblHeight.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblHeight.TextAlign")));
			this.propToolTip.SetToolTip(this.lblHeight, resources.GetString("lblHeight.ToolTip"));
			// 
			// lblWidth
			// 
			this.lblWidth.AccessibleDescription = null;
			this.lblWidth.AccessibleName = null;
			this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblWidth.Anchor")));
			this.lblWidth.AutoSize = ((bool)(resources.GetObject("lblWidth.AutoSize")));
			this.lblWidth.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblWidth.BackgroundImageLayout")));
			this.lblWidth.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblWidth.Dock")));
			this.lblWidth.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblWidth, null);
			this.hlpProvider.SetHelpNavigator(this.lblWidth, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblWidth.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblWidth, null);
			this.lblWidth.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblWidth.ImageAlign")));
			this.lblWidth.ImageIndex = ((int)(resources.GetObject("lblWidth.ImageIndex")));
			this.lblWidth.ImageKey = resources.GetString("lblWidth.ImageKey");
			this.lblWidth.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblWidth.ImeMode")));
			this.lblWidth.Location = ((System.Drawing.Point)(resources.GetObject("lblWidth.Location")));
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblWidth.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblWidth, ((bool)(resources.GetObject("lblWidth.ShowHelp"))));
			this.lblWidth.Size = ((System.Drawing.Size)(resources.GetObject("lblWidth.Size")));
			this.lblWidth.TabIndex = ((int)(resources.GetObject("lblWidth.TabIndex")));
			this.lblWidth.Text = resources.GetString("lblWidth.Text");
			this.lblWidth.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblWidth.TextAlign")));
			this.propToolTip.SetToolTip(this.lblWidth, resources.GetString("lblWidth.ToolTip"));
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
			this.cboPictureSize.Name = "cboPictureSize";
			this.cboPictureSize.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboPictureSize.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cboPictureSize, ((bool)(resources.GetObject("cboPictureSize.ShowHelp"))));
			this.cboPictureSize.Size = ((System.Drawing.Size)(resources.GetObject("cboPictureSize.Size")));
			this.cboPictureSize.TabIndex = ((int)(resources.GetObject("cboPictureSize.TabIndex")));
			this.cboPictureSize.Text = resources.GetString("cboPictureSize.Text");
			this.propToolTip.SetToolTip(this.cboPictureSize, resources.GetString("cboPictureSize.ToolTip"));
			this.cboPictureSize.SelectedIndexChanged += new System.EventHandler(this.CboPictureSize_SelectedIndexChanged);
			// 
			// lblPictureSize
			// 
			this.lblPictureSize.AccessibleDescription = null;
			this.lblPictureSize.AccessibleName = null;
			this.lblPictureSize.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblPictureSize.Anchor")));
			this.lblPictureSize.AutoSize = ((bool)(resources.GetObject("lblPictureSize.AutoSize")));
			this.lblPictureSize.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("lblPictureSize.BackgroundImageLayout")));
			this.lblPictureSize.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblPictureSize.Dock")));
			this.lblPictureSize.Font = null;
			this.hlpProvider.SetHelpKeyword(this.lblPictureSize, null);
			this.hlpProvider.SetHelpNavigator(this.lblPictureSize, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblPictureSize.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.lblPictureSize, null);
			this.lblPictureSize.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblPictureSize.ImageAlign")));
			this.lblPictureSize.ImageIndex = ((int)(resources.GetObject("lblPictureSize.ImageIndex")));
			this.lblPictureSize.ImageKey = resources.GetString("lblPictureSize.ImageKey");
			this.lblPictureSize.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblPictureSize.ImeMode")));
			this.lblPictureSize.Location = ((System.Drawing.Point)(resources.GetObject("lblPictureSize.Location")));
			this.lblPictureSize.Name = "lblPictureSize";
			this.lblPictureSize.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblPictureSize.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.lblPictureSize, ((bool)(resources.GetObject("lblPictureSize.ShowHelp"))));
			this.lblPictureSize.Size = ((System.Drawing.Size)(resources.GetObject("lblPictureSize.Size")));
			this.lblPictureSize.TabIndex = ((int)(resources.GetObject("lblPictureSize.TabIndex")));
			this.lblPictureSize.Text = resources.GetString("lblPictureSize.Text");
			this.lblPictureSize.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblPictureSize.TextAlign")));
			this.propToolTip.SetToolTip(this.lblPictureSize, resources.GetString("lblPictureSize.ToolTip"));
			// 
			// tabProperties
			// 
			this.tabProperties.AccessibleDescription = null;
			this.tabProperties.AccessibleName = null;
			this.tabProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabProperties.Anchor")));
			this.tabProperties.AutoScroll = ((bool)(resources.GetObject("tabProperties.AutoScroll")));
			this.tabProperties.BackColor = System.Drawing.Color.Transparent;
			this.tabProperties.BackgroundImage = null;
			this.tabProperties.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tabProperties.BackgroundImageLayout")));
			this.tabProperties.Controls.Add(this.fraFootline);
			this.tabProperties.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabProperties.Dock")));
			this.tabProperties.Font = null;
			this.hlpProvider.SetHelpKeyword(this.tabProperties, null);
			this.hlpProvider.SetHelpNavigator(this.tabProperties, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabProperties.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.tabProperties, null);
			this.tabProperties.ImageIndex = ((int)(resources.GetObject("tabProperties.ImageIndex")));
			this.tabProperties.ImageKey = resources.GetString("tabProperties.ImageKey");
			this.tabProperties.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabProperties.ImeMode")));
			this.tabProperties.Location = ((System.Drawing.Point)(resources.GetObject("tabProperties.Location")));
			this.tabProperties.Name = "tabProperties";
			this.tabProperties.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabProperties.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.tabProperties, ((bool)(resources.GetObject("tabProperties.ShowHelp"))));
			this.tabProperties.Size = ((System.Drawing.Size)(resources.GetObject("tabProperties.Size")));
			this.tabProperties.TabIndex = ((int)(resources.GetObject("tabProperties.TabIndex")));
			this.tabProperties.Text = resources.GetString("tabProperties.Text");
			this.propToolTip.SetToolTip(this.tabProperties, resources.GetString("tabProperties.ToolTip"));
			this.tabProperties.ToolTipText = resources.GetString("tabProperties.ToolTipText");
			this.tabProperties.UseVisualStyleBackColor = true;
			// 
			// fraFootline
			// 
			this.fraFootline.AccessibleDescription = null;
			this.fraFootline.AccessibleName = null;
			this.fraFootline.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("fraFootline.Anchor")));
			this.fraFootline.AutoSize = ((bool)(resources.GetObject("fraFootline.AutoSize")));
			this.fraFootline.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("fraFootline.AutoSizeMode")));
			this.fraFootline.BackgroundImage = null;
			this.fraFootline.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("fraFootline.BackgroundImageLayout")));
			this.fraFootline.Controls.Add(this.label6);
			this.fraFootline.Controls.Add(this.chkShowFootline);
			this.fraFootline.Controls.Add(this.label5);
			this.fraFootline.Controls.Add(this.label4);
			this.fraFootline.Controls.Add(this.label3);
			this.fraFootline.Controls.Add(this.label2);
			this.fraFootline.Controls.Add(this.label1);
			this.fraFootline.Controls.Add(this.chkFile);
			this.fraFootline.Controls.Add(this.txtFile);
			this.fraFootline.Controls.Add(this.chkToday);
			this.fraFootline.Controls.Add(this.txtToday);
			this.fraFootline.Controls.Add(this.chkDate);
			this.fraFootline.Controls.Add(this.txtDate);
			this.fraFootline.Controls.Add(this.chkVersion);
			this.fraFootline.Controls.Add(this.txtVersion);
			this.fraFootline.Controls.Add(this.chkCompany);
			this.fraFootline.Controls.Add(this.txtCompany);
			this.fraFootline.Controls.Add(this.chkAuthor);
			this.fraFootline.Controls.Add(this.txtAuthor);
			this.fraFootline.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("fraFootline.Dock")));
			this.fraFootline.Font = null;
			this.hlpProvider.SetHelpKeyword(this.fraFootline, null);
			this.hlpProvider.SetHelpNavigator(this.fraFootline, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fraFootline.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.fraFootline, null);
			this.fraFootline.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("fraFootline.ImeMode")));
			this.fraFootline.Location = ((System.Drawing.Point)(resources.GetObject("fraFootline.Location")));
			this.fraFootline.Name = "fraFootline";
			this.fraFootline.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("fraFootline.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.fraFootline, ((bool)(resources.GetObject("fraFootline.ShowHelp"))));
			this.fraFootline.Size = ((System.Drawing.Size)(resources.GetObject("fraFootline.Size")));
			this.fraFootline.TabIndex = ((int)(resources.GetObject("fraFootline.TabIndex")));
			this.fraFootline.TabStop = false;
			this.fraFootline.Text = resources.GetString("fraFootline.Text");
			this.propToolTip.SetToolTip(this.fraFootline, resources.GetString("fraFootline.ToolTip"));
			// 
			// label6
			// 
			this.label6.AccessibleDescription = null;
			this.label6.AccessibleName = null;
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
			this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
			this.label6.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label6.BackgroundImageLayout")));
			this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
			this.label6.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label6, null);
			this.hlpProvider.SetHelpNavigator(this.label6, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label6.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label6, null);
			this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
			this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
			this.label6.ImageKey = resources.GetString("label6.ImageKey");
			this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
			this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
			this.label6.Name = "label6";
			this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
			this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
			this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
			this.label6.Text = resources.GetString("label6.Text");
			this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
			this.propToolTip.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
			// 
			// chkShowFootline
			// 
			this.chkShowFootline.AccessibleDescription = null;
			this.chkShowFootline.AccessibleName = null;
			this.chkShowFootline.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkShowFootline.Anchor")));
			this.chkShowFootline.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkShowFootline.Appearance")));
			this.chkShowFootline.AutoSize = ((bool)(resources.GetObject("chkShowFootline.AutoSize")));
			this.chkShowFootline.BackColor = System.Drawing.Color.Transparent;
			this.chkShowFootline.BackgroundImage = null;
			this.chkShowFootline.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("chkShowFootline.BackgroundImageLayout")));
			this.chkShowFootline.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkShowFootline.CheckAlign")));
			this.chkShowFootline.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkShowFootline.Dock")));
			this.chkShowFootline.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkShowFootline.FlatStyle")));
			this.chkShowFootline.Font = null;
			this.hlpProvider.SetHelpKeyword(this.chkShowFootline, resources.GetString("chkShowFootline.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.chkShowFootline, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkShowFootline.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkShowFootline, null);
			this.chkShowFootline.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkShowFootline.ImageAlign")));
			this.chkShowFootline.ImageIndex = ((int)(resources.GetObject("chkShowFootline.ImageIndex")));
			this.chkShowFootline.ImageKey = resources.GetString("chkShowFootline.ImageKey");
			this.chkShowFootline.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkShowFootline.ImeMode")));
			this.chkShowFootline.Location = ((System.Drawing.Point)(resources.GetObject("chkShowFootline.Location")));
			this.chkShowFootline.Name = "chkShowFootline";
			this.chkShowFootline.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkShowFootline.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkShowFootline, ((bool)(resources.GetObject("chkShowFootline.ShowHelp"))));
			this.chkShowFootline.Size = ((System.Drawing.Size)(resources.GetObject("chkShowFootline.Size")));
			this.chkShowFootline.TabIndex = ((int)(resources.GetObject("chkShowFootline.TabIndex")));
			this.chkShowFootline.Text = resources.GetString("chkShowFootline.Text");
			this.chkShowFootline.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkShowFootline.TextAlign")));
			this.chkShowFootline.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkShowFootline.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkShowFootline, resources.GetString("chkShowFootline.ToolTip"));
			this.chkShowFootline.UseVisualStyleBackColor = false;
			this.chkShowFootline.CheckedChanged += new System.EventHandler(this.ChkShowFootline_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AccessibleDescription = null;
			this.label5.AccessibleName = null;
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label5.Anchor")));
			this.label5.AutoSize = ((bool)(resources.GetObject("label5.AutoSize")));
			this.label5.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label5.BackgroundImageLayout")));
			this.label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label5.Dock")));
			this.label5.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label5, null);
			this.hlpProvider.SetHelpNavigator(this.label5, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label5.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label5, null);
			this.label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.ImageAlign")));
			this.label5.ImageIndex = ((int)(resources.GetObject("label5.ImageIndex")));
			this.label5.ImageKey = resources.GetString("label5.ImageKey");
			this.label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label5.ImeMode")));
			this.label5.Location = ((System.Drawing.Point)(resources.GetObject("label5.Location")));
			this.label5.Name = "label5";
			this.label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label5.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
			this.label5.Size = ((System.Drawing.Size)(resources.GetObject("label5.Size")));
			this.label5.TabIndex = ((int)(resources.GetObject("label5.TabIndex")));
			this.label5.Text = resources.GetString("label5.Text");
			this.label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.TextAlign")));
			this.propToolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label4.BackgroundImageLayout")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label4, null);
			this.hlpProvider.SetHelpNavigator(this.label4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label4.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label4, null);
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImageKey = resources.GetString("label4.ImageKey");
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.propToolTip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label3.BackgroundImageLayout")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label3, null);
			this.hlpProvider.SetHelpNavigator(this.label3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label3.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label3, null);
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImageKey = resources.GetString("label3.ImageKey");
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.propToolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label2.BackgroundImageLayout")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label2, null);
			this.hlpProvider.SetHelpNavigator(this.label2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label2.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label2, null);
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImageKey = resources.GetString("label2.ImageKey");
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.propToolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label1.BackgroundImageLayout")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Font = null;
			this.hlpProvider.SetHelpKeyword(this.label1, null);
			this.hlpProvider.SetHelpNavigator(this.label1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label1.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.label1, null);
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImageKey = resources.GetString("label1.ImageKey");
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.propToolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
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
			this.hlpProvider.SetHelpKeyword(this.chkFile, null);
			this.hlpProvider.SetHelpNavigator(this.chkFile, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkFile.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkFile, null);
			this.chkFile.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFile.ImageAlign")));
			this.chkFile.ImageIndex = ((int)(resources.GetObject("chkFile.ImageIndex")));
			this.chkFile.ImageKey = resources.GetString("chkFile.ImageKey");
			this.chkFile.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkFile.ImeMode")));
			this.chkFile.Location = ((System.Drawing.Point)(resources.GetObject("chkFile.Location")));
			this.chkFile.Name = "chkFile";
			this.chkFile.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkFile.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkFile, ((bool)(resources.GetObject("chkFile.ShowHelp"))));
			this.chkFile.Size = ((System.Drawing.Size)(resources.GetObject("chkFile.Size")));
			this.chkFile.TabIndex = ((int)(resources.GetObject("chkFile.TabIndex")));
			this.chkFile.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFile.TextAlign")));
			this.chkFile.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkFile.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkFile, resources.GetString("chkFile.ToolTip"));
			this.chkFile.UseVisualStyleBackColor = true;
			// 
			// txtFile
			// 
			this.txtFile.AccessibleDescription = null;
			this.txtFile.AccessibleName = null;
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtFile.Anchor")));
			this.txtFile.BackColor = System.Drawing.SystemColors.ScrollBar;
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
			this.txtFile.Name = "txtFile";
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
			this.hlpProvider.SetHelpKeyword(this.chkToday, null);
			this.hlpProvider.SetHelpNavigator(this.chkToday, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkToday.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkToday, null);
			this.chkToday.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToday.ImageAlign")));
			this.chkToday.ImageIndex = ((int)(resources.GetObject("chkToday.ImageIndex")));
			this.chkToday.ImageKey = resources.GetString("chkToday.ImageKey");
			this.chkToday.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkToday.ImeMode")));
			this.chkToday.Location = ((System.Drawing.Point)(resources.GetObject("chkToday.Location")));
			this.chkToday.Name = "chkToday";
			this.chkToday.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkToday.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkToday, ((bool)(resources.GetObject("chkToday.ShowHelp"))));
			this.chkToday.Size = ((System.Drawing.Size)(resources.GetObject("chkToday.Size")));
			this.chkToday.TabIndex = ((int)(resources.GetObject("chkToday.TabIndex")));
			this.chkToday.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToday.TextAlign")));
			this.chkToday.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkToday.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkToday, resources.GetString("chkToday.ToolTip"));
			this.chkToday.UseVisualStyleBackColor = true;
			// 
			// txtToday
			// 
			this.txtToday.AccessibleDescription = null;
			this.txtToday.AccessibleName = null;
			this.txtToday.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtToday.Anchor")));
			this.txtToday.BackColor = System.Drawing.SystemColors.ScrollBar;
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
			this.txtToday.Name = "txtToday";
			this.txtToday.PasswordChar = ((char)(resources.GetObject("txtToday.PasswordChar")));
			this.txtToday.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtToday.RightToLeft")));
			this.txtToday.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtToday.ScrollBars")));
			this.hlpProvider.SetShowHelp(this.txtToday, ((bool)(resources.GetObject("txtToday.ShowHelp"))));
			this.txtToday.Size = ((System.Drawing.Size)(resources.GetObject("txtToday.Size")));
			this.txtToday.TabIndex = ((int)(resources.GetObject("txtToday.TabIndex")));
			this.txtToday.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtToday.TextAlign")));
			this.propToolTip.SetToolTip(this.txtToday, resources.GetString("txtToday.ToolTip"));
			this.txtToday.WordWrap = ((bool)(resources.GetObject("txtToday.WordWrap")));
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
			this.hlpProvider.SetHelpKeyword(this.chkDate, null);
			this.hlpProvider.SetHelpNavigator(this.chkDate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkDate.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkDate, null);
			this.chkDate.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkDate.ImageAlign")));
			this.chkDate.ImageIndex = ((int)(resources.GetObject("chkDate.ImageIndex")));
			this.chkDate.ImageKey = resources.GetString("chkDate.ImageKey");
			this.chkDate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkDate.ImeMode")));
			this.chkDate.Location = ((System.Drawing.Point)(resources.GetObject("chkDate.Location")));
			this.chkDate.Name = "chkDate";
			this.chkDate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkDate.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkDate, ((bool)(resources.GetObject("chkDate.ShowHelp"))));
			this.chkDate.Size = ((System.Drawing.Size)(resources.GetObject("chkDate.Size")));
			this.chkDate.TabIndex = ((int)(resources.GetObject("chkDate.TabIndex")));
			this.chkDate.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkDate.TextAlign")));
			this.chkDate.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkDate.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkDate, resources.GetString("chkDate.ToolTip"));
			this.chkDate.UseVisualStyleBackColor = true;
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
			this.txtDate.Name = "txtDate";
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
			this.hlpProvider.SetHelpKeyword(this.chkVersion, null);
			this.hlpProvider.SetHelpNavigator(this.chkVersion, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkVersion.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkVersion, null);
			this.chkVersion.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkVersion.ImageAlign")));
			this.chkVersion.ImageIndex = ((int)(resources.GetObject("chkVersion.ImageIndex")));
			this.chkVersion.ImageKey = resources.GetString("chkVersion.ImageKey");
			this.chkVersion.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkVersion.ImeMode")));
			this.chkVersion.Location = ((System.Drawing.Point)(resources.GetObject("chkVersion.Location")));
			this.chkVersion.Name = "chkVersion";
			this.chkVersion.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkVersion.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkVersion, ((bool)(resources.GetObject("chkVersion.ShowHelp"))));
			this.chkVersion.Size = ((System.Drawing.Size)(resources.GetObject("chkVersion.Size")));
			this.chkVersion.TabIndex = ((int)(resources.GetObject("chkVersion.TabIndex")));
			this.chkVersion.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkVersion.TextAlign")));
			this.chkVersion.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkVersion.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkVersion, resources.GetString("chkVersion.ToolTip"));
			this.chkVersion.UseVisualStyleBackColor = true;
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
			this.txtVersion.Name = "txtVersion";
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
			this.hlpProvider.SetHelpKeyword(this.chkCompany, null);
			this.hlpProvider.SetHelpNavigator(this.chkCompany, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkCompany.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkCompany, null);
			this.chkCompany.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCompany.ImageAlign")));
			this.chkCompany.ImageIndex = ((int)(resources.GetObject("chkCompany.ImageIndex")));
			this.chkCompany.ImageKey = resources.GetString("chkCompany.ImageKey");
			this.chkCompany.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkCompany.ImeMode")));
			this.chkCompany.Location = ((System.Drawing.Point)(resources.GetObject("chkCompany.Location")));
			this.chkCompany.Name = "chkCompany";
			this.chkCompany.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkCompany.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkCompany, ((bool)(resources.GetObject("chkCompany.ShowHelp"))));
			this.chkCompany.Size = ((System.Drawing.Size)(resources.GetObject("chkCompany.Size")));
			this.chkCompany.TabIndex = ((int)(resources.GetObject("chkCompany.TabIndex")));
			this.chkCompany.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkCompany.TextAlign")));
			this.chkCompany.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkCompany.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkCompany, resources.GetString("chkCompany.ToolTip"));
			this.chkCompany.UseVisualStyleBackColor = true;
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
			this.txtCompany.Name = "txtCompany";
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
			this.hlpProvider.SetHelpKeyword(this.chkAuthor, null);
			this.hlpProvider.SetHelpNavigator(this.chkAuthor, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chkAuthor.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.chkAuthor, null);
			this.chkAuthor.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAuthor.ImageAlign")));
			this.chkAuthor.ImageIndex = ((int)(resources.GetObject("chkAuthor.ImageIndex")));
			this.chkAuthor.ImageKey = resources.GetString("chkAuthor.ImageKey");
			this.chkAuthor.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAuthor.ImeMode")));
			this.chkAuthor.Location = ((System.Drawing.Point)(resources.GetObject("chkAuthor.Location")));
			this.chkAuthor.Name = "chkAuthor";
			this.chkAuthor.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAuthor.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.chkAuthor, ((bool)(resources.GetObject("chkAuthor.ShowHelp"))));
			this.chkAuthor.Size = ((System.Drawing.Size)(resources.GetObject("chkAuthor.Size")));
			this.chkAuthor.TabIndex = ((int)(resources.GetObject("chkAuthor.TabIndex")));
			this.chkAuthor.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAuthor.TextAlign")));
			this.chkAuthor.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("chkAuthor.TextImageRelation")));
			this.propToolTip.SetToolTip(this.chkAuthor, resources.GetString("chkAuthor.ToolTip"));
			this.chkAuthor.UseVisualStyleBackColor = true;
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
			this.txtAuthor.Name = "txtAuthor";
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
			// cmdCancel
			// 
			this.cmdCancel.AccessibleDescription = null;
			this.cmdCancel.AccessibleName = null;
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdCancel.Anchor")));
			this.cmdCancel.AutoSize = ((bool)(resources.GetObject("cmdCancel.AutoSize")));
			this.cmdCancel.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdCancel.AutoSizeMode")));
			this.cmdCancel.BackgroundImage = null;
			this.cmdCancel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdCancel.BackgroundImageLayout")));
			this.cmdCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdCancel.Dock")));
			this.cmdCancel.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdCancel.FlatStyle")));
			this.cmdCancel.Font = null;
			this.hlpProvider.SetHelpKeyword(this.cmdCancel, resources.GetString("cmdCancel.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.cmdCancel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cmdCancel.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.cmdCancel, null);
			this.cmdCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdCancel.ImageAlign")));
			this.cmdCancel.ImageIndex = ((int)(resources.GetObject("cmdCancel.ImageIndex")));
			this.cmdCancel.ImageKey = resources.GetString("cmdCancel.ImageKey");
			this.cmdCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdCancel.ImeMode")));
			this.cmdCancel.Location = ((System.Drawing.Point)(resources.GetObject("cmdCancel.Location")));
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdCancel.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cmdCancel, ((bool)(resources.GetObject("cmdCancel.ShowHelp"))));
			this.cmdCancel.Size = ((System.Drawing.Size)(resources.GetObject("cmdCancel.Size")));
			this.cmdCancel.TabIndex = ((int)(resources.GetObject("cmdCancel.TabIndex")));
			this.cmdCancel.Text = resources.GetString("cmdCancel.Text");
			this.cmdCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdCancel.TextAlign")));
			this.cmdCancel.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdCancel.TextImageRelation")));
			this.propToolTip.SetToolTip(this.cmdCancel, resources.GetString("cmdCancel.ToolTip"));
			this.cmdCancel.Click += new System.EventHandler(this.CmdCancelClick);
			// 
			// cmdAccept
			// 
			this.cmdAccept.AccessibleDescription = null;
			this.cmdAccept.AccessibleName = null;
			this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdAccept.Anchor")));
			this.cmdAccept.AutoSize = ((bool)(resources.GetObject("cmdAccept.AutoSize")));
			this.cmdAccept.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdAccept.AutoSizeMode")));
			this.cmdAccept.BackgroundImage = null;
			this.cmdAccept.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdAccept.BackgroundImageLayout")));
			this.cmdAccept.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdAccept.Dock")));
			this.cmdAccept.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdAccept.FlatStyle")));
			this.cmdAccept.Font = null;
			this.hlpProvider.SetHelpKeyword(this.cmdAccept, resources.GetString("cmdAccept.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.cmdAccept, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cmdAccept.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.cmdAccept, null);
			this.cmdAccept.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdAccept.ImageAlign")));
			this.cmdAccept.ImageIndex = ((int)(resources.GetObject("cmdAccept.ImageIndex")));
			this.cmdAccept.ImageKey = resources.GetString("cmdAccept.ImageKey");
			this.cmdAccept.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdAccept.ImeMode")));
			this.cmdAccept.Location = ((System.Drawing.Point)(resources.GetObject("cmdAccept.Location")));
			this.cmdAccept.Name = "cmdAccept";
			this.cmdAccept.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdAccept.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cmdAccept, ((bool)(resources.GetObject("cmdAccept.ShowHelp"))));
			this.cmdAccept.Size = ((System.Drawing.Size)(resources.GetObject("cmdAccept.Size")));
			this.cmdAccept.TabIndex = ((int)(resources.GetObject("cmdAccept.TabIndex")));
			this.cmdAccept.Text = resources.GetString("cmdAccept.Text");
			this.cmdAccept.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdAccept.TextAlign")));
			this.cmdAccept.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdAccept.TextImageRelation")));
			this.propToolTip.SetToolTip(this.cmdAccept, resources.GetString("cmdAccept.ToolTip"));
			this.cmdAccept.UseVisualStyleBackColor = true;
			this.cmdAccept.Click += new System.EventHandler(this.CmdAcceptClick);
			// 
			// cmdOk
			// 
			this.cmdOk.AccessibleDescription = null;
			this.cmdOk.AccessibleName = null;
			this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdOk.Anchor")));
			this.cmdOk.AutoSize = ((bool)(resources.GetObject("cmdOk.AutoSize")));
			this.cmdOk.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("cmdOk.AutoSizeMode")));
			this.cmdOk.BackgroundImage = null;
			this.cmdOk.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cmdOk.BackgroundImageLayout")));
			this.cmdOk.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdOk.Dock")));
			this.cmdOk.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdOk.FlatStyle")));
			this.cmdOk.Font = null;
			this.hlpProvider.SetHelpKeyword(this.cmdOk, resources.GetString("cmdOk.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this.cmdOk, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cmdOk.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this.cmdOk, null);
			this.cmdOk.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdOk.ImageAlign")));
			this.cmdOk.ImageIndex = ((int)(resources.GetObject("cmdOk.ImageIndex")));
			this.cmdOk.ImageKey = resources.GetString("cmdOk.ImageKey");
			this.cmdOk.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdOk.ImeMode")));
			this.cmdOk.Location = ((System.Drawing.Point)(resources.GetObject("cmdOk.Location")));
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdOk.RightToLeft")));
			this.hlpProvider.SetShowHelp(this.cmdOk, ((bool)(resources.GetObject("cmdOk.ShowHelp"))));
			this.cmdOk.Size = ((System.Drawing.Size)(resources.GetObject("cmdOk.Size")));
			this.cmdOk.TabIndex = ((int)(resources.GetObject("cmdOk.TabIndex")));
			this.cmdOk.Text = resources.GetString("cmdOk.Text");
			this.cmdOk.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdOk.TextAlign")));
			this.cmdOk.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("cmdOk.TextImageRelation")));
			this.propToolTip.SetToolTip(this.cmdOk, resources.GetString("cmdOk.ToolTip"));
			this.cmdOk.Click += new System.EventHandler(this.CmdOkClick);
			// 
			// hlpProvider
			// 
			this.hlpProvider.HelpNamespace = null;
			// 
			// OptionsDialog
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackgroundImage = null;
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdAccept);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.tabOptions);
			this.DoubleBuffered = true;
			this.Font = null;
			this.hlpProvider.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
			this.hlpProvider.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
			this.hlpProvider.SetHelpString(this, null);
			this.Icon = null;
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Name = "OptionsDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.hlpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.propToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.tabOptions.ResumeLayout(false);
			this.tabPageWorksheet.ResumeLayout(false);
			this.tabPageWorksheet.PerformLayout();
			this.fraMargins.ResumeLayout(false);
			this.fraMargins.PerformLayout();
			this.fraPreview.ResumeLayout(false);
			this.pnlPreviewBack.ResumeLayout(false);
			this.fraLayout.ResumeLayout(false);
			this.tabProperties.ResumeLayout(false);
			this.fraFootline.ResumeLayout(false);
			this.fraFootline.PerformLayout();
			this.ResumeLayout(false);
		}
		protected System.Windows.Forms.ToolTip propToolTip;
		protected System.Windows.Forms.HelpProvider hlpProvider;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		protected System.Windows.Forms.TabPage tabProperties;
		private System.Windows.Forms.Label lblPictureSize;
		protected System.Windows.Forms.ComboBox cboPictureSize;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.RadioButton optLayoutH;
		private System.Windows.Forms.RadioButton optLayoutV;
		private System.Windows.Forms.GroupBox fraLayout;
		private System.Windows.Forms.Panel pnlPreview;
		private System.Windows.Forms.Panel pnlPreviewBack;
		private System.Windows.Forms.GroupBox fraPreview;
		private System.Windows.Forms.Label lblUnit;
		protected System.Windows.Forms.ComboBox cboUnits;
		protected System.Windows.Forms.TextBox txtWidth;
		protected System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblMarginLeft;
        private System.Windows.Forms.Label lblTopMargin;
		private System.Windows.Forms.Label lblRightMargin;
        private System.Windows.Forms.Label lblBottomMargin;
		protected System.Windows.Forms.TabPage tabPageWorksheet;
		public System.Windows.Forms.TabControl tabOptions;
		private System.Windows.Forms.GroupBox fraMargins;
        protected System.Windows.Forms.CheckBox chkAuthor;
        protected System.Windows.Forms.CheckBox chkCompany;
        protected System.Windows.Forms.CheckBox chkVersion;
        protected System.Windows.Forms.CheckBox chkDate;
        protected System.Windows.Forms.CheckBox chkToday;
        protected System.Windows.Forms.CheckBox chkFile;
		private System.Windows.Forms.CheckBox chkShowFootline;
        protected System.Windows.Forms.TextBox txtAuthor;
        protected System.Windows.Forms.TextBox txtCompany;
        protected System.Windows.Forms.TextBox txtVersion;
        protected System.Windows.Forms.TextBox txtDate;
		private System.Windows.Forms.GroupBox fraFootline;
        protected System.Windows.Forms.TextBox txtLeftMargin;
        protected System.Windows.Forms.TextBox txtTopMargin;
        protected System.Windows.Forms.TextBox txtRightMargin;
        protected System.Windows.Forms.TextBox txtBottomMargin;
        protected System.Windows.Forms.TextBox txtToday;
        protected System.Windows.Forms.TextBox txtFile;
	}
}
