/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 21.01.2008
 * Zeit: 21:11
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace GeneratorGUI
{
	partial class XmiImportChoiceDialog
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
			this.importFormatChoiceComboBox = new System.Windows.Forms.ComboBox();
			this.labelDescribtion = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// importFormatChoiceComboBox
			// 
			this.importFormatChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.importFormatChoiceComboBox.FormattingEnabled = true;
			this.importFormatChoiceComboBox.Items.AddRange(new object[] {
									"StandardXmiFormat",
									"PapyrusXmiFormat"});
			this.importFormatChoiceComboBox.Location = new System.Drawing.Point(12, 65);
			this.importFormatChoiceComboBox.Name = "importFormatChoiceComboBox";
			this.importFormatChoiceComboBox.Size = new System.Drawing.Size(256, 21);
			this.importFormatChoiceComboBox.TabIndex = 0;
			// 
			// labelDescribtion
			// 
			this.labelDescribtion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDescribtion.Location = new System.Drawing.Point(12, 30);
			this.labelDescribtion.Name = "labelDescribtion";
			this.labelDescribtion.Size = new System.Drawing.Size(268, 21);
			this.labelDescribtion.TabIndex = 1;
			this.labelDescribtion.Text = "Bitte wählen Sie ein Import-Format ";
			// 
			// okButton
			// 
			this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okButton.Location = new System.Drawing.Point(60, 109);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(87, 23);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(153, 109);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(86, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Abbrechen";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// XmiImportChoiceDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(287, 163);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.labelDescribtion);
			this.Controls.Add(this.importFormatChoiceComboBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "XmiImportChoiceDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox importFormatChoiceComboBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label labelDescribtion;
	}
}
